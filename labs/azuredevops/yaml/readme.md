---
title: Configuring CI/CD Pipelines as Code with YAML in Azure DevOps
layout: page
sidebar: vsts
permalink: /labs/azuredevops/yaml/
folder: /labs/azuredevops/yaml/
version: Lab version - 1.33.1
updated: Last updated - 4/30/2019
---
<div class="rw-ui-container"></div>

<a name="Overview"></a>
## Overview ##

Many teams prefer to define their build and release pipelines using YAML (Yet Another Markup Language). This allows them to access the same pipeline features as those using the visual designer, but with a markup file that can be managed like any other source file. YAML build definitions can be added to a project by simply adding their source file to the root of the repository. Azure DevOps also provides default templates for popular project types, as well as a YAML designer to simplify the process of defining build and release tasks.

<a name="Prerequisites"></a>
### Prerequisites ###

- This lab requires you to complete task 1 from the [prerequisite instructions](../prereq).

<a name="Exercise1"></a>
## Exercise 1: Configuring CI/CD Pipelines as Code with YAML in Azure DevOps ##

<a name="Ex1Task1"></a>
### Task 1: Creating Azure resources ###

1. This lab requires a deployment of the Parts Unlimited project out to an Azure app service. To do this, you will need to spin up the necessary infrastructure. Log in to your Azure account at [https://portal.azure.com](https://portal.azure.com/).

1. Click **Create a resource** and search for **"web sql"**.

    ![](images/000.png)

1. Select the **Web App + SQL** option published by Microsoft.

    ![](images/001.png)

1. Click **Create**.

    ![](images/002.png)

1. Enter a globally unique name for the app service. You may find it easiest to incorporate your name, such as **"pul-yaml-johndoe"**. Select the option to **create a new** resource group named **"partsunlimited"**.

    ![](images/003.png)

1. Select the option to configure the **SQL Database**. Click **Create a new database** and enter the name **"partsunlimited"**.

    ![](images/004.png)

1. Select the option to configure the **Target server** and click **Create a new server**. Enter a globally unique server name, such as **"pul-yaml-johndoe"** and provide admin credentials. Click **Select** to confirm the server settings.

    ![](images/005.png)

1. Click **Select** to confirm the database settings.

    ![](images/006.png)

1. Click **Create** to create the resources. Note that you may need to create an app service plan first, if you do not yet have one.

    ![](images/007.png)

1. It will take a few minutes for the resources to provision, so you can move on to the next task.

<a name="Ex1Task2"></a>
### Task 2: Configuring the Parts Unlimited project ###

1. Navigate to your team project on Azure DevOps in a new browser tab. Before digging into the YAML pipelines, you will want to disable the existing build pipeline.

1. Navigate to **Pipelines**.

    ![](images/008.png)

1. Select the existing **PartsUnlimitedE2E** pipeline.

    ![](images/009.png)

1. From the dropdown, select **Pause pipeline**.

    ![](images/010.png)

<a name="Ex1Task3"></a>
### Task 3: Adding a YAML build definition ###

1. Navigate to the **Pipelines** hub.

    ![](images/011.png)

1. Click **New pipeline**. We will use the wizard to automatically create the YAML definition based on our project.

    ![](images/012.png)

1. Select the **Azure Repos Git** as the source hosting platform. Note the others supported.

    ![](images/013.png)

1. Select the **PartsUnlimited** repo.

    ![](images/014.png)

1. Select the **ASP.NET** template as the starting point for your pipeline.

    ![](images/015.png)

1. As this lab was initially built for VS2017, and the latest released VM Image is currently VS2019, the VMImage the build will run on needs to be updated to the older version of the hosted build agent.  Update the vmImage attribute in the pool section of the YAML to 'vs2017-win2016'.  A complete list of available hosted agent VM's can be found on the [Microsoft Docs Website](https://docs.microsoft.com/en-us/azure/devops/pipelines/agents/hosted?view=azure-devops).

    ![](images/YamlVmImageEdit.png)

1. Review the contents of the YAML definition. It will be saved as a new file called **"azure-pipelines.yml"** in the root of the repository and contain everything needed to build and test a typical ASP.NET solution. Click **Save and run**.

    ![](images/016.png)

1. Click **Save and run** to confirm the commit.

    ![](images/017.png)

1. Track the build until it completes. Click **Job** to see the logs.

    ![](images/018.png)

1. Each task from the YAML file is available for review, including any warnings and errors.

    ![](images/019.png)

1. Close the tasks view.

    ![](images/020.png)

1. Select the **Tests** tab.

    ![](images/021.png)

1. The tests should now succeed as expected.

    ![](images/022.png)

<a name="Ex1Task4"></a>
### Task 4: Adding continuous delivery to the YAML definition ###

1. Now that the build and test processes are successful, we can now add delivery to the YAML definition. From the options dropdown, select **Edit pipeline**.

    ![](images/023.png)

1. Set the cursor on a new line at the end of the YAML definition. This will be the location where new tasks are added.

    ![](images/024.png)

1. Select the **Azure App Service Deploy** task.

    ![](images/025.png)

1. Select the Azure subscription where you created the app service earlier. Click **Authorize** and follow the path to complete authorization.

    ![](images/026.png)

1. Enter the **App Service name** you used to create the app service earlier. Update the **Package or folder** to **"$(build.artifactstagingdirectory)/*.zip"**. Click **Add**.

    ![](images/027.png)

1. The YAML that defines the task will be added to the cursor location in the file.

    ![](images/028.png)

1. Click **Save** to commit the changes.

    ![](images/029.png)

1. Confirm the **Save**. This will begin a new build.

    ![](images/030.png)

1. Return to the **Pipelines** view.

    ![](images/031.png)

1. From the **Runs** tab, open the new build.

    ![](images/032.png)

1. Click **Job** to follow each task.

    ![](images/033.png)

1. Expand the **AzureRmWebAppDeployment** task to review the steps performed during the Azure deployment. Once the task completes, your app will be live on Azure.

    ![](images/034.png)

<a name="Ex1Task5"></a>
### Task 5: Reviewing the deployed site ###

1. Return to the Azure portal browser tab.

1. Navigate to the app service created earlier.

1. Select the **Configuration** tab.

    ![](images/035.png)

1. Click the **defaultConnection** setting.

    ![](images/036.png)

1. Update the **Name** to **"DefaultConnectionString"**, which is the key expected by the application. This will enable it to connect to the database created for the app service. Click **Update**.

    ![](images/037.png)

1. Click **Save** to apply the changes.

    ![](images/038.png)

1. Return to the **Overview** tab.

    ![](images/039.png)

1. Click the **URL** to open your site in a new tab.

    ![](images/040.png)

1. The deployed site should load expected.

    ![](images/041.png)

