---
title: Deploying to Azure VM using Deployment Groups
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/deploymentgroups/
folder: /labs/vstsextend/deploymentgroups/
---
<div class="rw-ui-container"></div>

## Overview

In the earlier versions of Azure DevOps, if the application needed to be deployed to multiple servers, the Windows PowerShell remoting had to be enabled manually, the required ports opened and the deployment agent installed on each of the servers. The pipelines had to be managed manually if a roll-out deployment was required.

All the above challenges have been handled seamlessly with the introduction of the [Deployment Groups](https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/release/deployment-groups/){:target="_blank"}.

The Deployment Group installs a deployment agent on each of the target servers in the configured group and instructs the Release Pipeline to gradually deploy the application to all these servers that belong to the Deployment Group. Multiple pipelines can be created for the roll-out deployments so that the latest version of the application could be provided in a phased manner to the multiple user groups for validating the newly introduced features.

### What's covered in this lab?

This lab covers the configuration of the deployment groups and details how the deployment groups could be used in the Azure DevOps.

### Before you begin

1. Refer to the [Getting Started](../Setup/) page to know the prerequisites for this lab.

1. Click the [Azure DevOps Demo Generator](https://azuredevopsdemogenerator.azurewebsites.net/?TemplateId=77368&Name=deploymentgroups) link and follow the instructions in [Getting Started](../Setup/) page to provision the project to your **Azure DevOps**.

## Setting up the Environment

The following resources will be provisioned on the Azure using an ARM template:

* Six Virtual Machines (VM) web servers with IIS configured

* SQL server VM (DB server)

* Azure Network Load Balancer

1. Click on the **Deploy to Azure** button to initiate the resource provisioning. It takes approximately 10-15 minutes to complete the deployment. Provide all the necessary information as is shown.

   [![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoft%2Falmvm%2Fmaster%2Flabs%2Fvstsextend%2Fdeploymentgroups%2Farmtemplate%2Fazurewebsqldeploy.json){:target="_blank"}

   ![Azure](images/azure.png)

1. Once the deployment is successful, the list of all the resources will be displayed on the Azure Portal.

   ![Resources](images/resources.png)

1. Click on the DB server VM which has **sqlSrv** in its name to view the details.

   ![DB Server](images/azure_resource.png)

1. Make a note of the `DNS` name. This value will be required later in an exercise.

   ![SQL DNS](images/sql_dns.png)

## Exercise 1: Creating Deployment Groups and Configuring Release

The Azure DevOps makes it easier to organize the servers for deploying the applications. A deployment group is a collection of machines with a deployment agent on each of them. Each of the  machine interacts with the Azure DevOps to coordinate the deployment of the app.

 > Since there is no configuration change required for the build pipeline, the build will be triggered automatically after the project is provisioned.

1. From the pipelines, select the [**Deployment Groups**](https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/release/deployment-groups/){:target="_blank"} option. Click on the **Add a deployment group** button to configure.

   ![Deployment group](images/deploymentgroup.png)

1. Provide a **Deployment group name** of your choice and click on the **Create** button. A registration script generated will be displayed.

   ![Deployment group](images/deploymentgroup2.png)

   ![Registration script](images/dgscript.png)

   > The target servers will be available in the deployment group for deploying the application. You can register the target servers using the script above. In this lab, we automatically register our target servers in the release pipeline. The release definition uses **Phases** to deploy the application to the target servers. A [Phase](https://docs.microsoft.com/en-us/vsts/build-release/concepts/process/phases){:target="_blank"} is a logical grouping of the tasks that defines the runtime target on which the tasks will execute. A deployment group phase executes tasks on the machines defined in a deployment group.

1. Naviagate to **Pipelines** \| **Releases**. Select the release pipeline and click **Edit**.

    ![Release](images/releasepipeline.png)

1. In the pipeline select the stage **Dev** from the tasks dropdown to view the  deployment tasks in pipeline.

   ![Environment](images/releaseenvironment.png)

1. The tasks will be grouped under the **Agent phase**, **Deployment group phase** and **IIS Deployment phase**.

   ![Phases](images/differentphases.png)

1. **Agent Phase**: In this phase, the target servers will be associated to the deployment group using the Azure Resource Group Deployment task.

     * **Azure Resource Group Deployment**: This task will automate the configuration of the deployment group agents to the web and db servers. 

        ![Agent Phase](images/agent_phase.png)
     
       - Authorize the correct Azure subscription from the drop down or click **Manage** to associate a new Azure subscription. 
       - Choose the **Resource Group** that was created previously in Azure Portal.
       - In the **Azure Pipelines service connection**, click **+ New** to create a new service connection of your Azure DevOps account. 
       
       - With the *Token Based Authentication*, provide the **Name, Azure DevOps URL and PAT**. Then click **Verify and save**.

         ![Service Connection](images/azuredevopsserviceconnection.png)

       - Choose the **Team Project** that was provisioned with Azure DevOps Demo Generator tool.
       - Choose the **Deployment Group**.

         ![Resource Group Deploy](images/teamprojectdg.png)

  1.  **Deployment group phase**: This deployment group phase executes tasks on the machines defined in the deployment group. This phase is linked to the **db** tag. Choose the **Deployment Group** from the drop down.

      ![tag](images/db_tag.png)

      * **Deploy Dacpac**: This task is used to deploy the dacpac file to the DB server.

        ![dacpac](images/dacpac.png)

   1. **IIS Deployment phase**: In this phase, the application will be deployed to the web servers using the below tasks. This phase is linked to **web** tag. Choose the **Deployment Group** from the drop down. 

      * **Azure Network Load Balancer**: As the target machines are connected to the NLB, this task will disconnect the machines from the NLB prior to the deployment and reconnect them back to the NLB after the deployment.

      * **IIS Web App Manage**: The task runs on the deployment target machine(s) registered with the Deployment Group configured for the task/phase. It creates a webapp and application pool locally with the name **PartsUnlimited** running under the port **80**

      * **IIS Web App Deploy**: The task runs on the deployment target machine(s) registered with the Deployment Group configured for the task/phase. It deploys the application to the IIS server using **Web Deploy**.

      * The number of concurrent deployments can be controlled by setting the value in the **Maximum number of targets in parallel** field. For example, in this lab, since there are 6 web servers, setting the target servers to **50%** will deploy the build artifacts to 3 web servers in parallel at a time.

        ![IIS](images/iis.png)

1. Select the **Disconnect Azure Network Load Balancer** task and provide the following details:

   * **Azure Subscription**: Choose the associated Azure subscription from the drop down.

   * **Resource Group**: Name of the Resource Group which was created while provisioning the environment.

   * **Load Balancer Name**: Select the name from the dropdown.

   * **Action**: Set the action to **Disconnect Primary Network Interface**

   ![Disconnect load balancer](images/disconnect_lb.png)

1. Select the **Connect Azure Network Load Balancer** task and provide the following details:

    * **Azure Subscription**: An ARM Endpoint created in the **Exercise 1**

    * **Resource Group**: Name of the Resource Group which was created while provisioning the environment

    * **Load Balancer Name**: Select the name from the dropdown

    * **Action**: Set the action to **Connect Primary Network Interface**

    ![Connect load balancer](images/connect_lb.png)

1. Click on the **Variables** tab and select the **Pipeline Variables** option. Enter the variable values as below

         
   | Variable Name | Variable Value  |
   |--|--|
   | DatabaseName | PartsUnlimited-Dev |
   | DBPassword | P2ssw0rd@123 |
   | DBUserName |sqladmin  |
   | DefaultConnectionString | Data Source=YOUR_DNS_NAME.cloudapp.azure.com;Initial Catalog=PartsUnlimited-Dev;User ID=sqladmin;Password=P2ssw0rd@123;MultipleActiveResultSets=False;Connection Timeout=30; |
   | ServerName | localhost |

    {% include important.html content= "Make sure to replace your SQL server DNS name (which you noted from Azure Portal earlier) in **DefaultConnectionString** variable" %}

    It will look like as below

    ![Variables](images/variables.png)

    Your DefaultConnectionString will be like as below after replacing SQL DNS.

    `Data Source=dgsqlw4zktxlvx7ddu.centralindia.cloudapp.azure.com.cloudapp.azure.com;Initial Catalog=PartsUnlimited-Dev;User ID=sqladmin;Password=P2ssw0rd@123;MultipleActiveResultSets=False;Connection Timeout=30;`


1.  **Save** the changes and click on the **Create release** then **Create**

    ![New Release](images/release.png)

1. Once the release is completed, the deployments will be completed in the DB and Web servers. Click on the logs to view the release summary.

    ![Release Summary](images/release_summary.png)

1. In the Azure Portal, click the **DNS** of any web application instance, to access the application.

   {% include important.html content= "The [**Azure Load Balancer**](https://docs.microsoft.com/en-us/azure/load-balancer/load-balancer-overview){:target=\"_blank\"} will distribute incoming traffic among healthy instances of servers defined in a load-balanced set. Hence the **DNS** of all web server instances will be the same." %}

   ![Web Server](images/web_server.png)

   ![Web DNS](images/web_dns.png)

1. The deployed web application will be launched and the various features can be browsed.

    ![Web application](images/application.png)

## Clean up resources

Since the lab uses multiple virtual machines and other resources, ensure you delete the resource group after the lab completion to avoid incurring charges.

## Summary

Using Azure DevOps and Azure, the web applications can be easily compiled and deployed to multiple target servers using Deployment Groups.