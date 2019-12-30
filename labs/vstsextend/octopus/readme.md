---
title: Automating Deployments from Azure Repos with Octopus Deploy
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/octopus/
folder: /labs/vstsextend/octopus/
---
<div class="rw-ui-container"></div>
## Overview

[Octopus Deploy](https://Octopus.com) is an automated deployment server that makes it easy to automate deployment of ASP.NET web applications, Java applications, NodeJS application and custom scripts to multiple environments.

<!-- Azure DevOps includes a first-class, powerful release management capability that simplifies deployment of any application to any platform. But teams who prefer or already have chosen Octopus deploy, can use the **[Octopus Deploy Integration](https://marketplace.visualstudio.com/items?itemName=octopusdeploy.octopus-deploy-build-release-tasks)** extension available on **Extensions for Azure DevOps** that provides Build and Release tasks to integrate Octopus Deploy with Azure DevOps and Azure DevOps Server.

This lab shows how we can integrate Azure DevOps/Azure DevOps Server Build with Octopus to automate build and deployment of an ASP.NET Core application to an Azure App Service. -->

Azure DevOps will be handle the build/CI automation part of the process and will work with Octopus Deploy to handle deployment orchestration. The Octopus setup contains a central deployment server, along with “Tentacle” agents that run on any target VMs where deployment will take place. 

Here, we will see how to use Octopus Deploy in conjunction with Azure DevOps to deploy in the cloud in a repeatable and reliable way. 

## Before you begin

1. Refer the [Getting Started](../Setup/) before you begin to follow the below exercises.

## Setting up the Environment

Octopus Deploy has two components:

* **Octopus Server** - a centralized web front-end that orchestrates deployments , and
* **Tentacle** - agent that needs to be on every target endpoint.

We will spin up an Octopus server on Azure. Click the **Deploy to Azure** button below to provision an Octopus Server.

   [![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/octopus.octopusdeployoctopus-deploy){:target="_blank"}

1. It takes approximately 15 minutes for the deployment to complete. Once the deployment is successful, connect to Octopus server using DNS, and login with Octopus Admin username and password.

   ![Octopus_login](images/OctopusDeploy15_1.png)

1. You will see the Octopus deploy web portal.

    ![Octopus Dashboard](images/OctopusDeploy15_2.png)

## Generating Service Principal Names(SPN) details from Azure

We need to generate SPN details to get **Tenant ID**, **Application ID** and **Application Password/Key** which will be used in the later part of the lab.

1. Login to your Azure account and click on **Cloud Shell**.

    ![webapp](images/CloudShellMicrosoftAzure.png)

1. Select **Bash** or **Powershell** to run the command which will generate the SPN details.
 
    ![webapp](images/DashboardMicrosoftAzure2.png)

1. Create Storage account as Azure Cloud Shell requires an Azure file share to persist files, If you already have one select it or create new. Select the subscription and click on **Create storage**. 
    ![webapp](images/DashboardMicrosoftAzure3.png)

1. Once the storage account is provisioned, enter the following command by replacing ServicePrincipalName with your desired value.

    `az ad sp create-for-rbac -n ServicePrincipalName`

   It will give you a JSON output as shown in the image. Copy the output to notepad or text file. You will need them later.
   
   ![SPN](images/azureserviceprincipal.png)

## Setting up the Deployment Target

Since, the deployment target is an Azure WebApp, we need to create one.

Click the button below to provision an Azure WebApp.

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.WebSite){:target="_blank"}

## Generate Octopus API Key

An *API key* is used to authenticate Azure DevOps with Octopus server. Using API key lets you keep your username and password a secret.

1. From the Octopus Deploy portal, select **Profile** under *User* menu.

   ![User Profile](images/OctopusDeploy15_3.png)

1. Select **My API Key** and click **New API Key** to create one. We will use the API Key to connect Octopus Deploy with Azure DevOps

   ![Request New API Key](images/APIKey.png)

1. Specify a **purpose**, for instance, **Azure DevOps Integration** and click **Generate New**.

   ![Generate New API Key](images/OctopusDeploy7.png)

1. Copy the API Key to clipboard and save this to a notepad as you might use it for future requests.

   ![Generated API Key](images/OctopusDeploy8.png)

## Setting up the Azure DevOps team project

1. Use [Azure DevOps Demo Generator](https://azuredevopsdemogenerator.azurewebsites.net/?Name=octopus&TemplateId=77370){:target="_blank"} to provision the project on your Azure DevOps Organization.

## Exercise 1: Configure Deployment Target in Octopus Server

Let us create a deployment environment in Octopus server and link to Azure using Management Certificate. Environments are deployment targets consisting of machines or services used by Octopus Deploy to deploy applications. With Octopus Deploy,  we  can deploy applications to Windows servers, Linux servers, Microsoft Azure, or even an offline package drop.

Grouping  our deployment targets by environment lets you define your deployment processes and have Octopus deploy the right versions of our software to the right environments at the right time.

In this lab, we are using **Azure App Service** as the deployment target.

1. On the Octopus portal dashboard, select **Create environments** to go into the **Infrastructure** page.

   ![CreateEnvironment](images/CreateEnvironment.png)

1. Once inside, click **Add Environment**.

   ![AddEnvironment](images/OctopusDeploy15_4.png)

1. Provide the environment name and click **Save**.

   ![DevEnvironment](images/OctopusDeploy15_5.png)

1. Octopus Deploy provides first-class support for deploying Azure Cloud Services and Azure Web Applications. To deploy software to Azure,   we must add  our  Azure subscription to Octopus Deploy, and then use the built-in step templates to deploy to the cloud. Once the environment is created, click on **Accounts** select **Azure Subscription** from **ADD ACCOUNT** dropdown.


   ![Add Account](images/OctopusDeploy15_6.png)

1. Octopus Deploy authenticates with Azure with one of the two methods:

    * To deploy to Azure Resource Manager (ARM), Octopus requires [**Azure Service Principal Account**](https://octopus.com/docs/infrastructure/azure/creating-an-azure-account/creating-an-azure-service-principal-account){:target="_blank"}.

    * To deploy to Cloud Services and Azure Web Apps, Octopus requires [**Azure Management Certificate**](https://octopus.com/docs/infrastructure/azure/creating-an-azure-account/creating-an-azure-management-certificate-account){:target="_blank"}. 

    Enter the following details -

    * **Name**: Provide an account name
    * **Subscription ID**: Your [Azure Subscription ID](https://blogs.msdn.microsoft.com/mschray/2016/03/18/getting-your-azure-subscription-guid-new-portal/){:target="_blank"}
    * **Authentication Method**: Choose **Use a Service Principal**
    * **Tenant ID**, **Application ID**, **Application Password/Key**: Created earlier in the lab


   ![Create Account](images/AccountOctopusDeploy.png)

   ![Create Account](images/accountOctopusDeploy2.png)

1. Click **SAVE AND TEST** and notice that your account is verified.

   ![Download Certificate](images/accountverifyOctopusDeploy.png)

1. To add the deployment target, go to **Deployment Targets**, click on **ADD DEPLOYMENT TARGET**, select **Azure Web App** and click **NEXT**.

   ![O8](images/AddDeploymentTargetsOctopusDeploy.png)

   ![O8](images/NewDeploymentTarget.png)

1. In **Create deployment target** page, provide **Display Name**, choose **Environment** from the dropdown, add **Target Roles**(Tags), select the **Account** which was created earlier and select **Azure Web App** from the dropdown as shown below and click **Save**..

   ![O9](images/Createdeploymenttarget.png)

   ![O9](images/Createdeploymenttarget2.png)

## Exercise 2: Create Project in Octopus

Let us create a Project in Octopus to deploy the package to **Azure App Service**. A [**Project**](https://octopus.com/docs/deployment-process/projects){:target="_blank"} is a collection of deployment steps and configuration variables that define how your software is deployed.

1. Go to the Octopus dashboard and click on **Create a project**.

   ![Project](images/Project.png)

1. Click on **ADD PROJECT**, provide the project name, description and click on **SAVE**.

   ![AddProject](images/OctopusDeploy15_11.png)

   ![PUProject](images/Projects.png)

1. Once the project is created, click **Define your deployment process**. The [deployment process](https://octopus.com/docs/deploying-applications/deployment-process){:target="_blank"} is like a recipe for deploying your software.

   ![DefineProcess](images/project2.png)

1. Click on **ADD STEP** to see a list of built-in step templates, custom step templates, and community contributed step templates.

   ![AddStep](images/Project3.png)

1. **Search** for **Azure Web App** template and click **Add**.

   ![AddWebAppStep](images/Project4.png)

1. Populate the step template with required details -

   * **Step Name** : A short, unique name for the template.
   * **On Behalf Of** : Choose the target role from the drop down that was created in previous exercise step **8**. 
   * **Package ID** : Type-in as **Asp.netcore** (if you are providing different package ID, update it in Package Application task of the build definition)

   ![PkgID](images/project5.png)

   ![Azure](images/project6.png)

1. Click **Save** to complete the project creation and its deployment process.

## Exercise 3: Triggering CI-CD

In this exercise, we will package the ASP.NET Core application and push the package to Octopus Server. We will use build tasks of **Octopus Deploy Integration** extension which was installed during Team Project provisioning.

| Tasks| Usage|
|-------| ------|
|![dotnetcore](images/dotnetcore.png) **Restore**| dotnet command-line tool restores all the package dependencies like **ASP.NET Core Identity, ASP.NET Core session** etc. required to build this project|
|![dotnetcore](images/dotnetcore.png) **Build**| We will use dotnet command-line tool to build the project and its dependencies into a set of binaries|
|![dotnetcore](images/dotnetcore.png) **Publish**| We will use this task to create a package with published content for the web deployment|
|![octopuspackage](images/octopuspackage.png) **Package Application** | We will package the ASP.NET Core build output into a zip file with the version number|
|![pushpackage](images/pushpackage.png) **Push packages to Octopus**| The copied package will be pushed to Octopus server from the artifacts directory|
|![createoctopus](images/createoctopus.png) **Create Octopus Release**|Automates the creation of release in Octopus server. A release captures all the project and package details to be deployed over and over in a safe and repeatable way|
|![releaseoctopus](images/releaseoctopus.png) **Deploy Octopus Release**| Automates the deployment of release in Octopus server. A deployment is the execution of the steps to deploy a release to an environment. An individual release can be deployed numerous times to different environments|

1. Go to **Builds** under **Pipelines** tab, select **Octopus** build definition and click on **Edit**.

   ![BuildDefinition](images/Builds11.png)


1. In **Push Packages to Octopus** task, update **Octopus Deploy Server** field with the created endpoint value.


   ![QBuild](images/BuildAzureDevOpsServices1.png)

1. In **Create Octopus Release** task, update **Octopus Deploy Server** field with the created endpoint value and choose the created **Project** from drop down.

    ![Update1](images/BuildAzureDevOpsServices2.png)

1. In **Deploy Octopus Release** task, update **Octopus Deploy Server** field with the created endpoint value, choose the appropriate values from the drop down for fields - **Project**  and **Deploy to Environments** and **Save & Queue** the build definition.

    ![Update](images/BuildAzureDevOpsServices3.png)

1. Navigate back to the **Build** tab see progress of the build.

    ![BuildProgress](images/BuildPipelines.png)

1. Once the build completes, go to Octopus portal project dashboard to see the release progress.

    ![CD-Octopus](images/OctopusDeploy24.png)

1. Go to the created Azure Web App from your **Azure Portal** and click **Browse**.

   ![Browse](images/MicrosoftAzure24.png)

1. You will see the associated ASP.NET Core application up and running.

   ![Changes](images/PartsUnlimited.png)


## Summary

The lab demonstrates how Azure Pipelines pick up a code commit, build the changes and push the deployment to Octopus which deploys to an Azure Web App.