---
title: Deploy and Manage Azure Resources
layout: page
sidebar: vsts
permalink: /labs/vsts/azureresource/
folder: /labs/vsts/azureresource/
---

## Overview

Azure Resource Manager enables you to work with the resources in your solution as a
group. You can deploy, update, or delete all the resources for your
solution in a single, coordinated operation. You use a template for
deployment and that template can work for different environments such as
testing, staging, and production. Resource Manager provides security,
auditing, and tagging features to help you manage your resources after
deployment.

## Pre-requisites

- Visual Studio 2015 Update 3 (download from [here](https://www.visualstudio.com/downloads/))

- Active Azure Account

- Azure SDK for VS 2015 (download from [here](https://azure.microsoft.com/en-in/downloads/))   
  
**Please follow the below steps**

1.  In Visual Studio, go to **File** \| **New Project** and select **Cloud**.
    Select **Azure Resource Group** and give a name **Azure Cloud Service**
    
    <img src="images/image1.png" width="585" height="359" />
    
2.  A new window would appear with a list of templates like WebApp+SQL,
    Logic App, Ubuntu Server etc. Because we want to create a custom
    resource group, we would choose “Blank Template” and click “OK”

    <img src="images/image2.png" width="559" height="421" />
    
3.  You can see the files that was created in Solution Explorer

    <img src="images/image3.png" width="624" height="332" />
    
    We have so many files created, let’s see what these files are.

       1. **Deploy-AzureResourceGroup.ps1:** A PowerShell script that invokes
            PowerShell commands to deploy to Azure Resource Manager

       2. **azuredeploy.json:** This defines the infrastructure that you want
          to deploy to Azure and the parameters that you can provide during
          the deployment. It also defines the dependencies between the
          resources so they are deployed in the correct order.

       3. **Azuredeployparameters.json:** A parameters file contains values
          that the template needs. These are the values that would be passed
          onto each deployment.

       4. **AzCopy.exe:** AzCopy is a Windows command-line utility designed
          for copying data to and from Microsoft Azure Blob, File, and Table
          storage using simple commands with optimal performance. You can copy
          data from one object to another within your storage account, or
          between storage accounts.

4. Open **azuredeploy.json** file and also open **JSON Outline** window in
    your Visual Studio. You can notice the summary information of the
    file at this moment in your JSON Outline. Currently there are no
    resources added.

   <img src="images/image4.png" width="624" height="333" />

5. You can add and modify existing resources to the JSON document from
    the **JSON Outline pane**. Let’s add the following resources to the
    template as shown below-

   ><b>Note</b>: To add the resources, right click on the “resources” from your JSON Outline and select “Add New Resource”

   <img src="images/image5.png" width="274" height="322" />
  
 
6. Create an App Service Plan with the name **MyHealthClinicDemo**

   <img src="images/image6.png" width="471" height="355" />

7. Create a WebApp with the name **MyHealthClinic** and map the App Service Plan to “MyHealthClinicDemo” that you created in                    the previous step

   <img src="images/image7.png" width="561" height="420" />

8. Add **Application Settings for WebApps** with the name “connection strings” that is associated with your WebApp

   <img src="images/image8.png" width="496" height="372" />

9. Create a SQL Server with the name **myhealthclinic** and add an instance of Azure SQL database with the name **myhealthclinicdb**

   <img src="images/image9.png" width="534" height="404" />

   <img src="images/image10.png" width="527" height="395" />


10. Upon adding all these resources, you should be able to see the parameters, variables and resources in your **JSON Outline pane**  as shown below

    <img src="images/image11.png" width="242" height="375" />

    >Now that we have all our resources ready, let’s deploy to Azure. Before deploying make sure the resource group doesn't exist so that you can verify post deployment that these resources were actually deployed from your Visual Studio.

11. Login to Azure Portal from [here](https://portal.azure.com) and verify.

    <img src="images/image12.png" width="466" height="379" />

12. Right click on the project from Solution Explorer &gt; click
    “Deploy” &gt; select “New Deployment”

    <img src="images/image13.png" width="497" height="433" />

13. A new window appears; select the Subscription you want to
    deploy with. Click on the Resource group drop down and create “new”.
    A new popup appears, provide a name for the resource group and
    choose a location you want this resource group to be deployed and
    click on create

    <img src="images/image14.png" width="624" height="301" />

14. Click on edit parameters and fill out the required details as shown

    <img src="images/image15.png" width="624" height="244" />

15. Click on Deploy

    <img src="images/image16.png" width="484" height="414" />

16. You will be prompted with a window to enter the db credentials.
    Remember the password that you had specified while you were editing
    the parameters in step 14

    <img src="images/image17.png" width="624" height="392" />

17. Post deployment, you will be seeing the resources in your Azure

    <img src="images/image18.png" width="624" height="354" />
