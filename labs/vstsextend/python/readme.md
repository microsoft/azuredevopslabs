# Deploy Python application to Azure App Service using VSTS

## Overview

**Python** is a server-side scripting language and a powerful tool for making dynamic and interactive web pages.

This lab shows how to deploy a **Python** application to **Azure App Service** from  **Visual Studio Team Services**. We will use  with [Django](https://www.djangoproject.com/) framework for deployment.

## Pre-requisites for the lab

1. An active **Microsoft Azure** account.

1. An active **VSTS** account. Create a new account from [here](https://docs.microsoft.com/en-us/vsts/accounts/create-account-msa-or-work-student).

1. A [Personal Access Token](https://docs.microsoft.com/en-us/vsts/accounts/use-personal-access-tokens-to-authenticate) (PAT).

## Setting Up the VSTS Project

 1. Use <a href="https://vstsdemogenerator.azurewebsites.net/?name=Python&templateid=77369" target="_blank">VSTS Demo Generator</a> to provision a Python project on your VSTS account.

    <img src="images/vsts_demo.png">

 2. Once the project is provisioned, click the URL to navigate to the project.

    <img src="images/python_template.png">

## Exercise 1: Endpoint Creation

Since the connections are not established during project provisioning, we will manually create the endpoints.

In VSTS, navigate to **Services** by clicking the gear icon, and click  **+ New Service Endpoint**. Select **Azure Resource Manager**. Specify connection name, select your subscription from the drop down and click OK. We use this endpoint to connect VSTS with Azure.

   <img src ="images/service_endpoint.png">

You will be prompted to authorize this connection with Azure credentials.

**Note**: Disable pop-up blocker in your browser if you see a blank screen after clicking OK, and retry the step.

## Exercise 2: Configure Release

We will provision the resources on **Azure** using ARM template in the **release definition**.

> **Note**: You will encounter an error - **TFS.WebApi.Exception: Page not found** for Azure tasks in the release definition. This is due to a recent change in the VSTS Release Management API. While we are working on updating VSTS Demo Generator to resolve this issue, you can fix this by typing a random text in the **Azure Subscription** field and click the **Refresh** icon next to it. Once the field is refreshed, you can select the endpoint from the drop down.

1. Go to **Releases** under **Build and Release** tab, Select release definition **Python** and click **Edit**

   <img src ="images/releaseedit.png">

2. Go to **Tasks** and select **Dev** environment.

   <img src ="images/environment.png">

3. Under **Azure Resource Group Deployment** task, update **Azure subscription** and **Location**.

   <img src ="images/azure_sub.png">

4. Under **Install Python Extension** task, update **Azure subscription**.

   <img src ="images/python_sub.png">

5. Under **Azure App Service Deploy** task, update **Azure subscription** and click **Save**.

   <img src ="images/deploy_app.png">

    <table width="75%">
    <thead>
        <tr>
          <th width="67%"><b>Tasks</b></th>
          <th><b>Usage</b></th>
        </tr>
    </thead>
    <tr>
        <td><img src="images/azure_resource.png"> <b>Azure Resource Group Deployment</b></td>
        <td>This task will create a resource group with the name <b>Python</b> and  provision an <b>App service</b> and <b>App Service Plan</b> </td>
    </tr>
      <tr>
        <td><img src="images/azure_app_service.png"> <b>Install Python Extension </b></td>
        <td>Installs the specific version of Python into Azure App Service</td>
    </tr>
    <tr>
        <td><img src="images/azure_deploy.png"> <b>Azure App Service Deploy</b></td>
        <td>The task is used to update Azure App Service to deploy Web Apps to azure.</td>
    </tr>
    <tr>
    </table>

## Exercise 3: Trigger CI-CD with code change

**Python** is an interpreted language, and hence compilation is not required. We will archive the files in the build and use the package in the release for deployment. Update the code to trigger CI-CD using **Hosted build agent**.

1. Go to **Code** tab and navigate to the below path to edit the file.

   >python/app/templates/app/index.html

   <img src ="images/code_tab.png">

2. Go to line number **32**, modify **Continuous Delivery** to **Continuous Delivery for Python** and commit the code.

   <img src ="images/commit_code.png">

3. Go to **Builds** tab under **Build and Release** tab to see the build in progress.

   <img src="images/build.png">

   <br/>

   <img src="images/in_progress_build.png">

   Let's explore the build definition while the build is in-progress. The tasks used are listed as shown.

   <table width="80%">
    <thead>
      <tr>
         <th width="60%"><b>Tasks</b></th>
         <th><b>Usage</b></th>
      </tr>
    </thead>
    <tr>
        <td><img src="images/archive_files.png"> <b>Archive files</b></td>
        <td>creates zip file for deployment</td>
    </tr>
    <tr>
        <td><img src="images/copy_files.png"> <b>Copy Files</b></td>
        <td>copies ARM template which is used to provision resources on azure </td>
    </tr>
    <tr>
        <td><img src="images/publish_artifact.png"> <b>Publish Build Artifacts</b></td>
        <td> publishes the build artifacts </td>
    </tr>
    </table>

   <br/>

4. The build generates artifact which is used for deployment to Azure.

   <img src ="images/build_result.png">

5. Once the build is complete, it triggers the CD pipeline. You can notice the linked release is in progress by navigating to Releases under Build and Release. The release will provision the Azure Web app and deploy the zip file generated by the associated build.

   <img src ="images/release_in_progress.png">

   <br/>

   <img src ="images/release_succesful.png">

   <br/>

6. Login to [Azure Portal](https://portal.azure.com) and go to  the **Resource Group** with the name **Python**. You will see the resources **App Service** and **App Service Plan**.

   <img src ="images/azure_portal.png">

7. Select the **App Service** and from the Overview tab, click Browse to see the application deployed.

   <img src ="images/pythonapp.png">

## Summary

This lab shows how to create a continuous integration(CI) and continuous deployment (CD) pipeline for Python code with Visual Studio Team Services (VSTS) on Azure..

## Feedback

Please let <a href="mailto:devopsdemos@microsoft.com">us</a> know if you have any feedback on this lab.