---
title: Automating Deployments with VSTS and Octopus Deploy
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/octopus/
folder: /labs/vstsextend/octopus/
---
Last updated : {{ "now" | date: "%b %d,%Y" }}

## Overview

Last updated : {{ "now" | date: "%b %d, %Y" }}.

[Octopus Deploy](https://Octopus.com){:target="_blank"} is an automated deployment server that makes it easy to automate deployment of ASP.NET web applications, Java applications, NodeJS application and custom scripts to multiple environments.

Visual Studio Team Services includes a first-class, powerful release management capability that simplifies deployment of any application to any platform. But teams who prefer or already have chosen Octopus deploy, can use the **[Octopus Deploy Integration](https://marketplace.visualstudio.com/items?itemName=octopusdeploy.octopus-deploy-build-release-tasks){:target="_blank"}** extension available on the Visual Studio Marketplace that provides Build and Release tasks to integrate Octopus Deploy with Team Services and Team Foundation Server.

This lab shows how  we  can integrate VSTS/TFS Team Build and Octopus to automate build and deployment application using a sample PHP application that will be deployed to an Azure App Service.

1. You will need a **Visual Studio Team Services Account**. If you do not have one, you can sign up for free [here](https://www.visualstudio.com/products/visual-studio-team-services-vs){:target="_blank"}

1. You will need a  **Personal Access Token** to set up your project using the Demo Generator. Please see this [article](https://docs.microsoft.com/en-us/vsts/accounts/use-personal-access-tokens-to-authenticate){:target="_blank"} for instructions to create your token.

    {% include note.html content= "You should treat Personal Access Tokens like passwords. It is recommended that you save them somewhere safe so that you can re-use them for future requests." %}

## Setting up the Environment

Octopus Deploy has two components:

* **Octopus Server** - a centralized web front-end that orchestrates deployments , and
* **Tentacle** - agent that needs to be on every target endpoint.

We will spin up a Octopus server on Azure. Click the **Deploy to Azure** button below to provision a Octopus Server.

   <a href="https://portal.azure.com/#create/octopus.octopusdeployoctopus-deploy" target="_blank">![](http://azuredeploy.net/deploybutton.png)</a>


1. Click on **Create** button.

   ![click_create](images/click_create.png)

1. Provide **Resource group** name and click **OK**.
   ![create_RG](images/create_RG.png)

1. Provide Octopus server **Domain Name**, VM Admin **username and password**, and SQL admin **username and password**. Note down the Domain Name (DNS) as this is used later to connect to Octopus server.

   ![server_details](images/server_details.png)

1. Provide Octopus Admin **username and password**. This is used to login to Octopus server. Also provide your **name, organization name** and **email address** to activate trial license for octopus server. Click OK.

   ![octopus_details](images/octopus_details.png)

1. Click **OK** in the Summary section.

   ![summary](images/summary.png)

1. Click **Create** in the Buy section.

   ![click_create2](images/click_create2.png)

1. Once the deployment is successful, connect to Octopus server using DNS, and login with Octopus Admin username and password.

   ![O1](images/O1.png)

1. You will see the Octopus deploy web portal.

    ![Octopus Dashboard](images/octopusportal.png)

1. From the Octopus Deploy portal, select **Profile** under *User* menu.

   ![User Profile](images/userprofile.png)

1. Select **My API Key** and click **New API Key** to create one. We will use the API Key to connect Octopus Deploy with Team Services

   ![Request New API Key](images/APIKey.png)

1. Specify a **purpose**, for e.g., **VSTS Integration** and click **Generate New**.

   ![Generate New API Key](images/Generate_new.png)

1. Copy the API Key to clipboard and save this somewhere as you may use it for future requests.

   ![Generated API Key](images/Key.png)

## Setting up Team Services project

1. Use [VSTS Demo Data Generator](https://vstsdemogenerator.azurewebsites.net/?TemplateId=77370&name=octopus){:target="_blank"} to provision the project on our VSTS account.

   ![VSTS Demo Generator](images/1.png)

1. Provide a name for your project. Paste, the Octopus URL (VM's DNS URL) that was created previously, API Key and click on **Create Project**.

1. Once the project is provisioned, click the URL to navigate to the project.

   ![VSTS Demo Generator](images/DemoGen.png)

   {% include note.html content= "This URL will automatically select Octopus template in the demo generator. If you want to try other projects, use this URL instead - [https://vstsdemogenerator.azurewebsites.net/](https://vstsdemogenerator.azurewebsites.net/)" %}

## Exercise 1: Configure Deployment Target in Octopus Server

Let us create a deployment environment in Octopus server and link to Azure using Management Certificate. Environments are deployment targets consisting of machines or services used by Octopus Deploy to deploy software. With Octopus Deploy,  we  can deploy software to Windows servers, Linux servers, Microsoft Azure, or even an offline package drop.

Grouping  our deployment targets by environment lets you define your deployment processes and have Octopus deploy the right versions of our software to the right environments at the right time.

In this lab, we are using Azure App Service as the deployment target.

1. From the Octopus portal, select **Create environments** to go into the **Infrastructure** page

   ![CreateEnvironment](images/CreateEnvironment.png)

1. Once inside, click **Add Environment**.

   ![AddEnvironment](images/AddEnvironment.png)

1. Provide the environment name and click **Save**.

   ![DevEnvironment](images/DevEnvironment.png)

1. Octopus Deploy provides first-class support for deploying Azure Cloud Services and Azure Web Applications. To deploy software to Azure,   we must add  our  Azure subscription to Octopus Deploy, and then use the built-in step templates to deploy to the cloud. Once the environment is created, click on **Accounts**.

   ![Select Accounts](images/Dev.png)

1. Select **ADD ACCOUNT**.

   ![Add Account](images/AddAccount.png)

1. Octopus Deploy authenticates with Azure in one of two methods:

    * To deploy to Azure Resource Manager (ARM), Octopus requires [**Azure Service Principal Account**](https://octopus.com/docs/infrastructure/azure/creating-an-azure-account/creating-an-azure-service-principal-account){:target="_blank"}

    * [**Azure Management Certificate**](https://octopus.com/docs/infrastructure/azure/creating-an-azure-account/creating-an-azure-management-certificate-account){:target="_blank"} is used by Octopus to deploy to Cloud Services and Azure Web Apps.

    Enter the following details -

    * **Name**: Provide an account name
    * **Subscription ID**: Your [Azure Subscription ID](https://blogs.msdn.microsoft.com/mschray/2016/03/18/getting-your-azure-subscription-guid-new-portal/){:target="_blank"}
    * **Authentication Method**: Choose **Use Management Certificate**

   ![Create Account](images/CreateAccount.png)

1. Click **Save** and notice that a management certificate is generated. Download this certificate.

   ![Download Certificate](images/DownloadCertificate.png)

1. To upload the certificate in Azure, go to [Azure Portal](https://portal.azure.com){:target="_blank"} and search for **Subscriptions**.

   ![O8](images/O8.png)

1. Click on the Subscription.

   ![O9](images/O9.png)

1. Scroll down and click **Management certificates**.

    ![O10](images/O10.png)

1. Click **Upload** to upload the certificate which was downloaded in the **step 7**.

    ![O11](images/O11.png)

    ![O12](images/O12.png)

1. Once the certificate is uploaded successfully, go back to Octopus portal and click **Save and Test**. If the test succeeds,  we should be able to configure Octopus to deploy application packages to Azure.

    ![VerificationSuccess](images/VerificationSuccess.png)

## Exercise 2: Create Project in Octopus

Let us create a Project in Octopus to deploy the package to **Azure App Service**. A [**Project**](https://octopus.com/docs/deployment-process/projects){:target="_blank"} is a collection of deployment steps and configuration variables that define how your software is deployed.

1. Go to Octopus dashboard and click **Create a project**.

   ![Project](images/Project.png)

1. Click on **ADD PROJECT**, provide the project name, description and click on **SAVE**.

   ![AddProject](images/AddProject.png)

   ![PUProject](images/PUProject.png)

1. Once the project is created, click **Define your deployment process**. The [deployment process](https://octopus.com/docs/deploying-applications/deployment-process){:target="_blank"} is like a recipe for deploying your software.

   ![DefineProcess](images/DefineProcess.png)

1. Click on **ADD STEP** to see a list of built-in step templates, custom step templates, and community contributed step templates.

   ![AddStep](images/AddStep.png)

1. **Search** for **Azure Web App** template and click **Add**.

   ![AddWebAppStep](images/AddWebAppStep.png)

1. Populate the step template with required details -

   * **Step Name** : A short, unique name for the template.
   * **Package ID** : PHP (if you are providing different package ID, update it in **Package PHP** task of the build definition)
   * **Azure account** & **Web App** : Select from the dropdown

   ![PkgID](images/PkgID.png)

   ![Azure](images/Azure.png)

1. Clicking **Save** should define the project creation and its deployment process.

## Exercise 3: Triggering CI-CD

In this exercise, we will package PHP application and push the package to Octopus Server. We will use build tasks of **Octopus Deploy Integration** extension which was installed during Team Project provisioning.

| Tasks| Usage|
|-------| ------|
|![octopuspackage](images/octopuspackage.png) **Package Application** | We will package the PHP source code into a zip file with the version number|
|![copyfiles](images/copyfiles.png) **Copy Files**| The Copy Files task will copy the generated package to artifacts directory in VSTS|
|![pushpackage](images/pushpackage.png) **Push packages to Octopus**| The copied package will be pushed to Octopus server from VSTS artifacts directory|
|![createoctopus](images/createoctopus.png) **Create Octopus Release**|Automates the creation of release in Octopus server. A release captures all the project and package details to be deployed over and over in a safe and repeatable way|
|![releaseoctopus](images/releaseoctopus.png) **Deploy Octopus Release**| Automates the deployment of release in Octopus server. A deployment is the execution of the steps to deploy a release to an environment. An individual release can be deployed numerous times to different environments|

1. Go to **Builds** under **Build and Release** tab and click on **Octopus** build definition.

   ![BuildDefinition](images/BuildDefinition.png)

1. **Edit** the build definition to update Octopus server endpoint.

   ![EditBD](images/EditBD.png)

1. In **Push Packages to Octopus** task, update **Octopus Deploy Server** field with the created endpoint value.

   {% include note.html content= "You will encounter an error - **TFS.WebApi.Exception: Page not found** for Azure tasks in the release definition. This is due to a recent change in the VSTS Release Management API. While we are working on updating VSTS Demo Generator to resolve this issue, you can fix this by typing a random text in the **Azure Subscription** field and click the **Refresh** icon next to it. Once the field is refreshed, you can select the endpoint from the drop down." %}

   ![QBuild](images/QBuild.png)

1. In **Create Octopus Release** task, update **Octopus Deploy Server** field with the created endpoint value and **Project** fields.

    ![Update1](images/Update1.png)

1. In **Deploy Octopus Release** task, update **Octopus Deploy Server** field with the created endpoint value, choose the appropriate values from the drop down for fields - **Project**  and **Deploy to Environments**.

    ![Update](images/Update.png)

1. Save the build definition.

    ![Save](images/Save.png)

1. Go to **Code** tab and edit the file **functions.php**

    ![EditFile](images/EditFile.png)

1. Update the **line 41** as shown, change the title to - **PHP DevOps Using VSTS, Octopus and Azure** and **commit** the changes.

    ![EditCommit](images/EditCommit.png)

1. Go to **Build** tab, you will see in-progress build.

    ![BuildProgress](images/BuildProgress.png)

1. Once the build completes, go to Octopus portal project dashboard. We will see the release completion in Octopus.

    ![CD-Octopus](images/CD-Octopus.png)

1. Go to Azure Web App from your **[Azure Portal](https://portal.azure.com){:target="_blank"}** and click on **Browse**.

   ![Browse](images/Browse.png)

1. You will see the PHP application up and running.

   ![Changes](images/Changes.png)
