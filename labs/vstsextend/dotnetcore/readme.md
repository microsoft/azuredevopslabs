# Deploy an ASP.NET Core application to Azure App Service using VSTS

This lab shows how to deploy an ASP.NET Core application to Azure App Service with Visual Studio Team Services.

[ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/) is a cross-platform, high-performance, open-source framework for building modern, cloud-based, Internet-connected applications. With ASP.NET Core, you can:

- Build web apps and services, IoT apps, and mobile backends.
- Use your favorite development tools on Windows, macOS, and Linux.
- Deploy to the cloud or on-premises
- Run on .NET Core or .NET Framework.

## Pre-requisites for the lab

1. An active **Microsoft Azure** account.

1. An active **VSTS** account. Create a new account from [here](https://docs.microsoft.com/en-us/vsts/accounts/create-account-msa-or-work-student).

1. A [Personal Access Token](https://docs.microsoft.com/en-us/vsts/accounts/use-personal-access-tokens-to-authenticate) (PAT).

## Setting up the VSTS Project

1. Use [VSTS Demo Data Generator](https://vstsdemogenerator.azurewebsites.net/?name=MyHealthClinic) to provision a project on your VSTS account.

   ![](images/vsts_demoGen.png)

1. Once the project is provisioned, select the URL to navigate to the project.

   ![](images/project_provision.png)

## Exercise 1: Endpoint Creation

Since the connections are not established during project provisioning, we will manually create the endpoints.

In VSTS, navigate to **Services** by clicking the gear icon ![](images/gear.png), and click **+ New Service Endpoint**. Select **Azure Resource Manager**. Specify **Connection name**, select your **Subscription** from the dropdown and click **OK**. We use this endpoint to connect **VSTS** with **Azure**.

   ![](images/endpoint_creation.png)

   You will be prompted to authorize this connection with Azure credentials. Disable pop-up blocker in your browser if you see a blank screen after clicking OK, and retry the step.

## Exercise 2: Configure Release

Now that connections are established, we will manually map the endpoints to release definition.

> **Note** : You will encounter an error - **TFS.WebApi.Exception: Page not found** for Azure tasks in the release definition. This is due to a recent change in the VSTS Release Management API. While we are working on updating VSTS Demo Generator to resolve this issue, you can fix this by typing a random text in the **Azure Subscription** field and click the **Refresh** icon next to it. Once the field is refreshed, you can select the endpoint from the drop down.

1. Go to **Releases** under **Build & Release** tab, edit the release definition **MyHealthClinicE2E**.

   ![](images/create_release.png)

1. Select **Tasks** and click **Dev**.

   ![](images/release_2.png)

1. Under **Azure Resource Group Deployment** task, update **Azure subscription** with the endpoint components from the dropdown and select the desired **location**.

   ![](images/release_3.png)

1. Under **Azure App Service Deploy** task, update **Azure subscription** with the endpoint components from the dropdown. Under the **Slot** section enter the slot name as **Dev**.

   ![](images/release_4.png)

1. Similarly update **Azure subscription** with the endpoint components for **QA** and **Production** environments. Go to **Tasks** and select **QA**.

   ![](images/qa.png)

1. Under **Azure App Service Deploy** task, update **Azure subscription** with the endpoint components from the dropdown. Under the **Slot** section enter the slot name as **Staging**.

   ![](images/qa_1.png)

1. Go to **Tasks** and select **Production**.

   ![](images/prod.png)

1. Under **Azure App Service Deploy** task, update **Azure subscription** with the endpoint components from the dropdown and click **Save** to save the release definition.

   ![](images/prod_1.png)

## Exercise 3: Triggering a Continuous Integration (CI) build

1. Go to the **Code** hub.

   ![](images/code_hub.png)

1. We have a **DOTNETCORE** app code provisioned by the demo generator system. We will deploy this to Azure app service.

1. We have a Continuous Integration (CI) build setup to run upon a code commit. Let's make a simple change to the code to trigger the CI build.

1. Open the file **Index.cshtml** by navigating to the below path-

   > **MyHealthClinic/src/MyHealth.Web/Views/Home/Index.cshtml**

   ![](images/code_edit.png)

1. Edit the code. For this example, let's change **line 33** to change the text from **Login** to **Private Area**.

   ![](images/update_code.png)

1. Select **Commit** to save and commit the changes.

1. The code commit will trigger the CI build. Go to the **Build** tab to see the CI build running in progress.

   ![](images/build_in_progress.png)

   While the build is in progress, let's explore the build definition. The tasks that is used in the build definition are listed in the table below.

   |Tasks| Usage|
   |-----|------|
   |![](images/dotnetcore.png) **Restore**| dotnet command-line tool restores all the package dependencies like **ASP.NET Core Identity, ASP.NET Core session** etc. required to build this project|
   |![](images/npm.png) **npm Install**| npm task installs the npm packages (javascript dependencies) like **babelify, browserify** etc. required to build this project|
   |![](images/bower.png) **Bower Install**|We will use this task to manage components that contain HTML, CSS, JavaScript, fonts and even image files. Example: jquery, angular, webcomponentsjs etc|
   |![](images/gulp.png) **Gulp**| gulp task compiles sass files, uglify and compress js files|
   |![](images/dotnetcore.png) **Build**| We will use dotnet command-line tool to build the project and its dependencies into a set of binaries|
   |![](images/dotnetcore.png) **Test**| dotnet command-line tool wil run unit tests as part of build process to ensure the code quality. This project contains 6 unit tests|
   |![](images/dotnetcore.png) **Publish**| We will use this task to create a package with published content for the web deployment|
   |![](images/vstest.png) **Publish Test Results**| We will use this task to publish the unit test result|
   |![](images/copyfiles.png) **Copy Files**| We will copy the zipped file and the ARM template to a staging directory|
   |![](images/publishartifacts.png) **Publish Build Artifacts**| And finally, we will publish the files in the staging directory which were copied in the previous step|

1. Click on the build number to open the live console.

   ![](images/build_number.png)

   ![](images/build_in_progress_2.png)

1. Once the build is complete click on the build number, to see the summary which shows **Test Results** as shown.

   ![](images/build_summary.png)

## Exercise 4: Continuous Delivery

We are using **Infrastructure as a Code** in the release pipeline. We have a release configured to deploy the application which is associated to the build and triggered when the build is successful.

1. Go to **Releases** tab under **Build and Release** hub.

1. Select the **MyHealthClinicE2E** definition, you will see the release in-progress.

   ![](images/release.png)

1. While the release is in-progress, let's explore the tasks used. Click **edit** to see the release pipeline. We have three environments **Dev, QA** and **Production**.

   ![](images/pipeline.png)

   >Go to the Dev environment, you will see 2 tasks are used. Let us explore the tasks.

   ![](images/release_tasks.png)

   - **Azure Resource Group Deployment**: The project used in this lab contains frontend (Azure App Service) and backend (Azure SQL DB) services. We will provision these services as PAAS on Azure using ARM templates. This task will create the above services in a resource group **dotnetcore.**

   - **Azure App Service Deploy**: The task is used to deploy a Web project to the Azure App Service created above.

1. Click on **View releases**.

   ![](images/view_releases.png)

1. Double click on the release to see the release summary.

   ![](images/release_summary1.png)

   ![](images/release_summary.png)

1. Login to [Azure Portal](https://portal.azure.com) and search a **Resource Group** with the name **dotnetcore**.

   ![](images/azure_resources.png)

1. Navigate to either Dev or Staging web app in the resource group and you will see the application is deployed successfully with the changes.

   ![](images/mhc_web_app.png)

## Summary

**Visual Studio Team Services** simplifies creation of continuous integration and continuous delivery pipelines for your application to be deployed to Azure.
