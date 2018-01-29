---
title: Deploy PHP application to Azure App Service using VSTS
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/php/
folder: /labs/vstsextend/php/
---

Last updated : {{ "now" | date: "%b %d, %Y" }}.
## Overview

**PHP** is a server-side scripting language, and a powerful tool for making dynamic and interactive Web pages.

This lab shows how to deploy **PHP** application to **Azure App** service using **Visual Studio Team Services**.

### Pre-requisites for the lab

1. **Microsoft Azure Account**: You will need a valid and active Azure account for the Azure labs. If you do not have one, you can sign up for a [free trial](https://azure.microsoft.com/en-us/free/){:target="_blank"}

    * If you are a Visual Studio Active Subscriber, you are entitled for a $50-$150 credit per month. You can refer to this [link](https://azure.microsoft.com/en-us/pricing/member-offers/msdn-benefits-details/){:target="_blank"} to find out more including how to activate and start using your monthly Azure credit.

    * If you are not a Visual Studio Subscriber, you can sign up for the FREE [Visual Studio Dev Essentials](https://www.visualstudio.com/dev-essentials/){:target="_blank"} program to create **Azure free account** (includes 1 year of free services, $200 for 1st month).

1. You will need a **Visual Studio Team Services Account**. If you do not have one, you can sign up for free [here](https://www.visualstudio.com/products/visual-studio-team-services-vs){:target="_blank"}

1. You will need a **Personal Access Token** to set up your project using the Demo Generator. Please see this [article](https://docs.microsoft.com/en-us/vsts/accounts/use-personal-access-tokens-to-authenticate){:target="_blank"} for instructions to create your token.

  {% include note.html content= "You should treat Personal Access Tokens like passwords. It is recommended that you save them somewhere safe so that you can re-use them for future requests." %}

## Setting Up the VSTS Project

1. Use [VSTS Demo Data Generator](https://vstsdemogenerator.azurewebsites.net/?name=PHP&templateid=77365){:target="_blank"} to provision a PHP project on your VSTS account.

   ![vstsdemogen](images/vstsdemogen.png)

1. Once the project is provisioned, click the URL to navigate to the project.

   ![vsts_demogenerator_create](images/vsts_demogenerator_create.png)

## Exercise 1: Endpoint Creation

Since the connections are not established during project provisioning, we will manually create the endpoints.

In VSTS, navigate to **Services** by clicking the gear icon ![gear](images/gear.png) , and click  **+ New Service Endpoint**. Select **Azure Resource Manager**. Specify connection name, select your subscription from the dropdown and click OK. We use this endpoint to connect VSTS with Azure.

   ![services_endpoint](images/services_endpoint.png)

You will be prompted to authorize this connection with Azure credentials.

{% include note.html content= "Disable pop-up blocker in your browser if you see a blank screen after clicking OK, and retry the step." %}

## Exercise 2: Configure Release Definition

We will use ARM template as **Infrastructure as a Code**  in the release definition to provisions a Web App and a Web App Service Plan under the specified resource group.

  {% include note.html content= "You will encounter an error - **TFS.WebApi.Exception: Page not found** for Azure tasks in the steps **3** & **4** of this exercise. This is due to a recent change in the VSTS Release Management API. While we are working on updating VSTS Demo Generator to resolve this issue, you can fix this by typing a random text in the **Azure Subscription** field and click the **Refresh** icon next to it. Once the field is refreshed, you can select the endpoint from the drop down." %}

1. Go to **Releases** under **Build and Release** tab, Select release definition **PHP** and click **Edit**

   ![release_def](images/release_def.png)

1. Go to **Tasks** and select **Dev** environment.

   ![dev_release](images/dev_release.png)

1. Under **Azure Resource Group Deployment** task, update **Azure subscription** and **Location**.

   ![azure_sub](images/azure_sub.png)

1. Under **Azure App Service Deploy** task, update **Azure subscription** and click **Save**.

   ![azure_app_service](images/azure_app_service.png)

   <table width="70%">
    <thead>
      <tr>
        <th width="60%"><b>Tasks</b></th>
        <th><b>Usage</b></th>
      </tr>
    </thead>
    <tr>
      <td><img src="images/azure_resource.png"> <b>Azure Resource Group Deployment</b></td>
      <td>Uses the provided ARM template to create a resource group with App Service plan and App Service</td>
    </tr>
    <tr>
      <td><img src="images/webapp.png"> <b>Azure App Service Deploy</b></td>
      <td>deploys a PHP application to the created App service</td>
    </tr>
   </table>

## Exercise 3: Deploying the application

**PHP** is an interpreted language, so we don't have to compile the code. Instead we will create an archive file which will be deployed to the Azure App Service.

Let's make a code change to trigger a CI-CD pipeline to build and deploy the application.

1. Go to **Code** tab and navigate to the below path to edit the file.

   >php/config.php

   ![code1](images/code1.png)

1. Go to line number **11**, modify **PHP** to **DevOps for PHP using VSTS** and commit the code.

   ![code_editing](images/code_editing.png)

1. Go to **Builds** tab under **Build and Release** tab to see the associated CI build in progress.

   ![build](images/build.png)

   ![in_progress_build](images/in_progress_build.png)

   Let's explore the build definition. The tasks used in the build definition are listed as shown.

   <table width="70%">
    <thead>
      <tr>
        <th width="60%"><b>Tasks</b></th>
        <th><b>Usage</b></th>
      </tr>
    </thead>
    <tr>
      <td><img src="images/Archive.png"> <b>Archive files</b></td>
      <td>We will archive all the files in the folder to a zip file</td>
    </tr>
    <tr>
      <td><img src="images/copyfiles.png"> <b>Copy Files</b></td>
      <td>Copy the ARM template and the Zip file to the artifact folder</td>
    </tr>
    <tr>
      <td><img src="images/PublishArtifact.png"> <b>Publish Build Artifacts</b></td>
      <td>Publish the build artifacts so that it is available to the Release pipeline</td>
    </tr>
   </table>

1. Once the build is complete, it triggers the CD pipeline. You can notice the linked release is in progress by navigating to **Releases** under **Build and Release**. The release will provision the Azure Web app and deploy the zip file generated by the associated build.

   ![Release in progress](images/release_in_progress.png)

1. Alternatively, you can also login to the [Azure Portal](https://portal.azure.com){:target="_blank"} and navigate to the **Resource Group** that contains the Web App that was provisioned in the CD pipeline

   ![azure](images/azure.png)

1. Select the **App Service** and from the **Overview** tab,  click **Browse** to see the application deployed.

   ![website_php](images/website_php.png)
