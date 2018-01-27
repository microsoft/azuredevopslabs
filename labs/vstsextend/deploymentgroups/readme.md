---
title: Multi-machine deployments using VSTS
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/deploymentgroups/
folder: /labs/vstsextend/deploymentgroups/
---

Last updated : {{ "now" | date: "%b %d, %Y" }}.

## Overview

 Earlier with the VSTS Release Management, if you had to deploy an application to multiple servers, you had to manually enable Windows PowerShell remoting on each of the server, open the required ports and install the deployment agent. Also, for a roll-out deployment, the pipelines had to be managed manually.

With the introduction of the [Deployment Groups](https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/release/deployment-groups/), the above challenges will be overcome.

The Deployment Group installs a deployment agent on each of the target servers within a group and instructs the Release Management to gradually deploy to all machines belonging to that Deployment Group. Multiple pipelines can be created for roll-out deployments so that the latest version of the application can be provided gradually to multiple user groups for validating the new features.

## Pre-requisites

1. **Microsoft Azure Account**: You need a valid and active azure account for the labs.

1. You need a **Visual Studio Team Services Account** and [Personal Access Token](https://docs.microsoft.com/en-us/vsts/accounts/use-personal-access-tokens-to-authenticate)

## Setting up the Environment

We will use an ARM template to provision the below resources on Azure:

- Six VMs (web servers) with IIS configured

- A SQL server VM (db server) and

- Azure Network Load Balancer

1. Click on the **Deploy to Azure** to provision the resources. It takes approximately 10-15 minutes to complete the deployment.

   [![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoft%2FVSTS-DevOps-Labs%2Fdeploymentgroups%2Fdeploymentgroups%2Fazurewebsqldeploy.json)

   ![](images/azure.png)

1. Once the deployment is successful, you will see the resources in your Azure Portal.

   ![](images/resources.png)

1. Click on **DB server VM**.

   ![](images/azure_resource.png)

1. Note down the **DNS** name. This value will be used later in an exercise.

   ![](images/sql_dns.png)

## Setting up the VSTS Project

1. Use the [VSTS Demo Generator](https://vstsdemogenerator.azurewebsites.net/?name=DeploymentGroups&templateid=77368) to provision a project on your VSTS account.

   ![](images/vstsdemogen.png)

1. Once the project is provisioned, click on the URL to navigate to the project.

   ![](images/vsts_demo.png)

## Exercise 1: Endpoint Creation

Since the connections are not established during project provisioning, we will manually create the endpoints.

1. In VSTS, navigate to the **Services** by clicking on the gear icon, and click on the **+ New Service Endpoint** button. Select the **Azure Resource Manager** tab. Specify the **Connection name**, select your **Subscription** from the dropdown and click on the **OK** button. We will use this endpoint to connect **VSTS** and **Azure**.

   ![](images/service_endpoint.png)

   ![](images/connection_name.png)

1. Create an endpoint of type **Team Foundation Server/Team Services**. Select the **Token based authentication** option and specify the following details-

   - **Connection Name**: Give any name

   - **Connection Url**: Your VSTS account Url

   - **Personal Access Token**: Your VSTS Personal Access Token

   Created endpoint is used in release definition in the later exercise. We create this connection because  agent registration with deployment group requires access to your VSTS project.

   ![](images/vsts.png)

## Exercise 2: Creating Deployment Group

[Deployment Groups](https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/release/deployment-groups/) in VSTS makes it easier to organize the servers that you want to use to host your app. A deployment group is a collection of machines with a VSTS deployment agent on each of them. Each machine interacts with VSTS to coordinate deployment of your app.

1. Go to **Deployment Groups** under **Build & Release** tab. Click **Add deployment group** .

   ![](images/add_deploymentgroup.png)

1. Provide  **Deployment group name**, and click create. You will see the registration script generated.

   ![](images/name_dg.png)

   ![](images/script_dg.png)

## Exercise 3: Configure Release

We have the target machines available in the deployment group to deploy the application. The release definition uses **Phases** to deploy to target servers.

A [Phase](https://docs.microsoft.com/en-us/vsts/build-release/concepts/process/phases) is a logical grouping of tasks that defines the runtime target on which the tasks will execute. A deployment group phase executes tasks on the machines defined in a deployment group.

1. Go to Release under **Build & Release** tab. Edit the release definition **Deployment Groups** and select **Tasks**.

    ![](images/release_tab.png)

    ![](images/task.png)

1. You will see tasks grouped under **Agent phase**, **Database deploy phase** and **IIS Deployment phase**.

   ![](images/phases.png)

   - **Agent Phase**: In this phase , we will associate the target servers to the deployment group. The below task is used-

     - **Azure Resource Group Deployment**: This task will automate the configuration of the deployment group agents to the web and db servers.

       ![](images/agent_phase.png)

   - **Database deploy phase**: This deployment group phase executes tasks on the machines defined in the deployment group. This phase is linked to **db** tag.

     - **Deploy Dacpac**: This task is used to deploy dacpac file to the DB server.

       ![](images/db_tag.png)

        </br>

       ![](images/dacpac.png)

   - **IIS Deployment phase**: In this phase, we deploy application to the web servers.This phase is linked to **web** tag. We use following tasks-

      - **Azure Network Load Balancer**: As the target machines are connected to NLB, this task will disconnect machines from NLB before the deployment and re-connects to NLB after the deployment.

      - **IIS Web App Manage**: The task runs on the deployment target machine(s) registered with the Deployment Group configured for the task/phase. It creates a webapp and application pool locally with the name **PartsUnlimited** running under the port
      **80**

      - **IIS Web App Deploy**: The task runs on the deployment target machine(s) registered with the Deployment Group configured for the task/phase. It deploys the application to the IIS server using **Web Deploy**.

        ![](images/iis.png)

1. We can control the number of concurrent deployments by setting the **Maximum number of targets in parallel**. For example, in this lab we have 6 web servers, setting the target servers to **50%** will deploy the build artifact to 3 web servers parallely and then to the remaining 3 servers.

   ![](images/targets.png)

1. Go to **Disconnect Azure Network Load Balancer** task and update the following details-

   - **Azure Subscription**: ARM Endpoint created in **Exercise 1**

   - **Resource Group**: Name of the Resource Group which was created while provisioning the environment

   - **Load Balancer Name**: Select the name from the dropdown

   - **Action**: Set the action to **Disconnect Primary Network Interface**

   ![](images/disconnect_lb.png)

1. Go to **Connect Azure Network Load Balancer** and update the following details-

    - **Azure Subscription**: ARM Endpoint created in **Exercise 1**

    - **Resource Group**: Name of the Resource Group which was created while provisioning the environment

    - **Load Balancer Name**: Select the name from the dropdown

    - **Action**: Set the action to **Connect Primary Network Interface**

    ![](images/connect_lb.png)

1. Go to **Variables** tab and click on edit  to update the **DefaultConnectionString** value with **Your SQL_DNS name**.

   ![](images/release_variable.png)

1. Click **Save** and **Create release**.

   ![](images/save.png)

   ![](images/create_release.png)

   ![](images/release.png)

1. Once the release is complete, you will see the deployments are done to DB and Web Servers. Go to Logs to see the summary.

    ![](images/release_summary.png)

1. In one of your web servers, go to **DNS** to access the application.

   > [**Azure Load Balancer**](https://docs.microsoft.com/en-us/azure/load-balancer/load-balancer-overview) is being used here which  distributes incoming traffic among healthy instances of services defined in a load-balanced set. So, **DNS** of all web servers are the same.

    ![](images/web_server.png)

    ![](images/web_dns.png)

1. The deployed web application is displayed.

    ![](images/application.png)

## Summary

With Visual Studio Team Services and Azure, we can build and release dotnet applications to multiple target servers using Deployment Groups.