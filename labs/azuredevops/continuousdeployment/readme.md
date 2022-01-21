---
title: Embracing Continuous Delivery with Azure Pipelines
layout: page
sidebar: vsts
permalink: /labs/azuredevops/continuousdeployment/
folder: /labs/azuredevops/continuousdeployment/
version: Lab version - 1.39.0
updated: Last updated - 21/01/2022
redirect_from: "/labs/vsts/continuousdeployment/index.htm"
---
<div class="rw-ui-container"></div>
<a name="Overview"></a>

## Overview ##

In this lab, you will learn about the release management features available in Azure Pipelines that automate the deployment of applications. These features help development and operations teams integrate with Azure DevOps Server to configure and automate complex deployments of their automated builds to target stages more easily. Development teams can also model their release processes and track approvals, sign-offs, and visualize their release status.


<div class="bg-slap"><img src="./images/mslearn.png" class="img-icon-cloud" alt="MS teams" style="width: 48px; height: 48px;">Want additional learning? Check out the <a href="https://docs.microsoft.com/en-us/learn/modules/create-release-pipeline/" target="_blank"><b><u> Create a release pipeline in Azure Pipelines </u></b></a> module on Microsoft Learn.</div>


<a name="Prerequisites"></a>
### Prerequisites ###

- An Azure account (free from [https://azure.com/free](https://azure.com/free)).

- Complete task 1 from the <a href="../prereq/">prerequisite</a>  instructions.

<a name="Exercise1"></a>
## Exercise 1: Embracing Continuous Delivery with Azure DevOps ##

<a name="Ex1Task1"></a>
### Task 1: Setting up Azure resources ###

1. Start off by creating the Azure resources needed for this lab. This includes a database and two app services: one for QA and one for production. Log into your account at [https://portal.azure.com](https://portal.azure.com/).

1. Click **Create a resource** and search for **"SQL Database"**. Select **SQL Database**.

    ![](images/searchsqldb.png)


1. Click **Create**.
    
    ![](images/clickcreatesql.png)


1. Under **Resource group**, click **Create new**.

    ![](images/003.png)

1. Enter a **Name** of **"partsunlimited"** and click **OK**.

    ![](images/004.png)

1. Enter a **Database name** of **"partsunlimited"** and click **Create new** to create a new server.

    ![](images/005.png)

1. Enter a unique name for **Server name**, such as by including your name. Enter an admin username and password you can remember. Note that **"P2ssw0rd"** meets the password requirements. Click **OK** to confirm these options.

    ![](images/sqlserverdetails.png)

1. In **Compute + storage** select **Configure Database**. Select **Basic** service tier and click **Apply**.

    ![](images/configuredb.png)

    ![](images/basicsqltier.png)


1. Click **Review + create**.

    ![](images/008.png)

1. Click **Create**. It'll take some time to complete, but you can move on to the next step while it works in the background.

    ![](images/009.png)

1. From Azure Portal home page search for **"App Services"** and select **App Services**.

    ![](images/searchappservices.png)


1. Click **Create** in App Services page.
    
    ![](images/createappservice.png)

1. Under **Project Details**, select the same **Subscription** and **Resource Group** used for the database.

    ![](images/013.png)

1. For **Name**, enter a unique name, such as by using your name as part. Since this will be for our QA deployment, append the name with **"-qa"**. Select the **ASP.NET 4.8 Runtime stack**.

    ![](images/014.png)

1. On **App Service plan** select **create new** and name it **plan**. Change the size to **S1** (under Production).

    ![](images/s1.png)


1. Click **Review and create**.

    ![](images/015.png)

1. Click **Create**.

    ![](images/016.png)

1. Repeat the process above to create a second app service for the production stage. This time, append the **Name** with **"-prod"** instead. **You can use the same App Service Plan created before for QA**.

    ![](images/017.png)

1. While the Azure resources are created, go ahead and configure the SQL server.

1. Click the **Resource groups** tab from the left menu. Locate and click the **partsunlimited** group.

1. Click the SQL server resource created earlier.

1. Select the **Firewalls and virtual networks** tab from the **Security** section.

1. Set **"Allow Azure services and resources to access this server"** to **Yes** to allow the App Services to access this SQL server.
   
   ![](images/sqlfirewall.png)
1. Click **Save** on the top of the tab.

1. Continue on to the next task. Leave this browser tab open for later.

<a name="Ex1Task2"></a>
### Task 2: Creating a continuous release to the QA stage ###

1. Navigate to your team project on Azure DevOps in a new browser tab. It should be at [https://dev.azure.com/YOURACCOUNT/Parts%20Unlimited](https://dev.azure.com/YOURACCOUNT/Parts Unlimited).

1. Navigate to **Pipelines \| Releases**.

    ![](images/018.png)

1. **Delete** the existing **PartsUnlimitedE2E** release pipeline. We'll start fresh here.

    ![](images/019.png)

1. Click **New pipeline**.

    ![](images/020.png)

1. There are many starting templates to choose from, or you can even begin with an empty process template. In this case, select the **Azure App Service Deployment** and click **Apply**.

    ![](images/021.png)

1. Rename the default stage to **"QA"**. This template will deploy to QA, and then to a production stage. We'll set up this one first.

    ![](images/022.png)

1. Rename the release pipeline to **"PUL-CICD"**.

    ![](images/023.png)

1. The first thing to define is exactly what should be deployed. Click **Add** in the **Artifacts** section to specify the artifact to deploy.

    ![](images/024.png)

1. There are many types of artifacts, but this one will be pretty simple: a project built from the **PartsUnlimitedE2E** build pipeline that already exists in this team project. Click **Add**.

    ![](images/025.png)

1. Now that the artifact has been defined, it's time to configure the deployment to QA. Click **1 job, 1 task** in the **QA** stage.

    ![](images/026.png)

1. Select the **Azure subscription** you used earlier to create the resources and click **Authorize**. If you need to create a connection to an Azure account associated with a different Microsoft account, click **New** and follow that workflow before continuing.

    ![](images/027.png)

1. Follow the workflow to authorize access to your Azure account.

1. Enter the **App service name** used earlier when creating the QA app service.

    ![](images/028.png)

1. Return to the **Pipeline** tab.

    ![](images/029.png)

1. Click the **Triggers** button to define what triggers will invoke this deployment.

    ![](images/030.png)

1. **Enable** the **Continuous deployment trigger**. Add a **Build branch filter** that points at the **The build pipeline's default branch**. This will kick off the deployment when the build completes.

    ![](images/031.png)

1. **Save** the release pipeline.

    ![](images/032.png)

<a name="Ex1Task3"></a>
### Task 3: Configuring the Azure app services ###

1. Return to the browser tab open to the Azure portal.

1. Click the **Resource groups** tab from the left menu. Locate and click the **partsunlimited** group created earlier.

    ![](images/033.png)

1. Click your SQL database (something like **pul-johndoe/partsunlimited**). Make sure you click the database you created and not the server. Note that it may take a few minutes for the database and server to become available, so click the **Refresh** button every once in a while to check in.

    ![](images/034.png)

1. In the new blade, click **Show database connection strings**.

    ![](images/035.png)

1. This will provide you with a list of connection strings based on platform. Copy the **ADO.NET** string to your clipboard so you can configure your new web site to use it. Close this blade.

    ![](images/036.png)

1. Open a new instance of **Notepad** and paste the connection string into it. This will make it easier to edit and retrieve later on in case anything happens to the clipboard copy.

1. Use the breadcrumb navigation to return to the **partsunlimited** resource group.

    ![](images/037.png)

1. Click the **QA** app service created earlier.

    ![](images/038.png)

1. Select the **Configuration** tab from the **Settings** section.

    ![](images/039.png)

1. On this blade you can configure settings for your app, such as connection strings. Click **New connection string**.

    ![](images/040.png)

1. Locate the **Connection strings** section and add a new entry with the key **"DefaultConnectionString"** and the value pasted from the clipboard. You'll need to locate the "{your_username}" and "{your_password}" sections and replace them (including braces) with the actual SQL credentials entered earlier. Be sure the **Type** is set to **SQLAzure** and click **OK**.

    ![](images/041.png)

1. Click **Save** to commit.

    ![](images/042.png)

1. Repeat the process above to add the same connection string to the production app service.

<a name="Ex1Task4"></a>
### Task 4: Invoking a continuous delivery release to QA ###

1. Return to the browser tab open to your Azure DevOps project.

1. Now that the release pipeline is in place, it's time to commit a change in order to invoke a build and release. You'll need to make a few changes like this over the course of this lab, so it's recommended that you use a separate tab for **Code \| Files** to keep that part of the process separate.

    ![](images/043.png)

1. Navigate to **PartsUnlimited-aspnet45/src/PartsUnlimitedWebsite/Views/Shared/_Layout.cshtml**. This is a file that defines the general layout of the site and is a good place to make a change that will be easily visible after deployment.

    ![](images/044.png)

1. Click **Edit** to edit the file inline.

    ![](images/045.png)

1. Locate the **Parts Unlimited Logo** and add the text **"v2.0"** after it. This will be an easy thing to check for after deployment.

    ![](images/046.png)

1. **Commit** the changes back to the repo. This will kick off a build based on the preconfigured build pipeline.

    ![](images/047.png)

1. Navigate to the **Pipelines** hub.

    ![](images/048.png)

1. Open the most recent build for **PartsUnlimitedE2E**. It may be queued, in progress, or already completed.

    ![](images/049.png)

1. Follow the build until completion.

    ![](images/050.png)

1. Click the **Releases** tab to see the new release get going.

    ![](images/051.png)

1. Click the release. As with the build, it may be queued, in progress, or already completed when you get here.

    ![](images/052.png)

1. Follow the release until it succeeds.

    ![](images/053.png)

1. You can now close this tab if you prefer.

    ![](images/054.png)

1. In a new browser tab, navigate to the QA site. It will be the name of your app service plus **".azurewebsites.net"**. It should show the **v2.0** added earlier.

    <a name="![](images/055.png)"></a>
     ### ![](images/055.png) ###

<a name="Ex1Task5"></a>
### Task 5: Creating a gated release to the production stage ###

1. Return to the Azure DevOps browser tab.

1. Click on **Pipelines>Pipelines** and click on **Edit** (top-right) to modify the release definition.

1. As release pipelines get more sophisticated, it becomes important to define gates to ensure quality throughout the release pipeline. Since the next stage we're deploying to is production, we'll need to be sure to include both automated quality gates as well as a manual approver gate. Return to the release pipeline browser tab and click **Clone** in the **QA** stage. Since the production stage is virtually the same, we can reuse almost all of the existing configuration.

    ![](images/056.png)

1. The new stage is added after the current one, which is what we want. However, before we can consider the QA deployment successful, we'll need to define a post-deployment condition. Click the **Post-deployment conditions** button on the **QA** stage.

    ![](images/057.png)

1. **Enable** the **Gates** option.

    ![](images/058.png)

1. There are several kinds of gates available that can automatically test virtually anything you need to make sure a deployment is in good shape. These could be the return values of Azure functions or REST APIs, queries to Azure for alerts, or work item queries in Azure DevOps. You can also configure how long the platform should delay before evaluating the gates for the first time. In this case, change that to **0** so it will test them immediately after deployment. Then click **Add** \| **Query Work Items**.

    ![](images/059.png)

1. Select the **Query** for **Shared Queries \| Critical Bugs**. We will make it our policy that the QA deployment cannot be considered a success until all critical bugs have been resolved.

    ![](images/060.png)

1. Expand **Evaluation options** and update the **Time between re-evaluation of gates** to **5**. If this gate fails, we want it to reevaluate the query every 5 minutes until it clears because engineers will need some time to confirm those critical bugs are fixed in the current version. However, if those bugs aren't cleared and the release isn't manually failed, this configuration will automatically fail the gate after 1 day.

    ![](images/061.png)

1. For the Query Gate to work, Project Build Service would require Read permission to queries. Go to **Azure Boards > Queries > All > Shared Queries > "..." > Security**.

    ![](images/permissions.png)

1. Search for the **"(YOUR PROJECT NAME) Build Service "**, if not included by default (not  Project Collection Build Service!) and give it **Read > Allow** permission.

    ![](images/permissions2.png)

1. We can now turn our focus to the production stage. Select the **Copy of QA** stage.

    ![](images/062.png)

1. Rename it to **"Prod"**.

    ![](images/063.png)

1. Click its **Pre-deployment conditions** button.

    ![](images/064.png)

1. **Enable** the **Pre-deployment approvals** and add yourself as an **Approver**. The idea here is that you won't be asked to approve the production deployment until after the QA deployment has succeeded. At that point, someone on this list will need to approve the deployment to production. Also clear the box for **User requesting a release of deployment should not approve** if it's checked. For the purposes of this lab, you can approve releases you have requested.

    ![](images/065.png)

1. Click the **Prod** stage's **1 job, 1 task**.

    ![](images/066.png)

1. Update the **App service name** to reflect the "**-prod**" (instead of **"-qa"**).

    ![](images/067.png)

1. **Save** the release pipeline.

    ![](images/068.png)

1. Repeat the process for changing the codebase at **"PartsUnlimited-aspnet45/src/PartsUnlimitedWebsite/Views/Shared/_Layout.cshtml"** followed earlier in a new tab. This time, update the version number from **"2.0"** to **"3.0"**. This will invoke the release pipeline.

1. As before, follow the release until it is deploying to QA. Click to follow the release itself once available.

1. Eventually there will be an issue with the QA deployment. While it deployed out successfully, one of the quality gates failed. This will need to be resolved for that stage to be approved. Click the **View post-deployment gates** button.

    ![](images/069.png)

1. It looks like the **Query Work Items** gate is failing. This means that there is a critical bug that must be cleared.

    ![](images/070.png)

1. Open a new tab to **Boards \| Queries** to locate the bug.

    ![](images/071.png)

1. Use the query list on the **All** tab to open the **Shared Queries \| Critical Bugs** query.

    ![](images/072.png)

1. Open the one bug by clicking it.

    ![](images/073.png)

1. Ordinarily you'd check the site to confirm the bug was fixed, but we'll skip ahead here and mark it **Done**. Click **Save** and close the tab.

    ![](images/074.png)

1. Return to the release pipeline tab. Depending on timing, it may take up to five minutes for Azure DevOps to check the query again. Once it does, the bugs will be cleared and the release will be approved. You can then click **Approve** to approve deployment to production.

    ![](images/075.png)

1. Confirm the deployment.

    ![](images/076.png)

1. Click the **In progress** link to follow the release workflow.

    ![](images/077.png)

1. It may take a moment for the release to kick off and complete.

    ![](images/078.png)

1. Once the release has completed, open a new tab to the production app service URL. It should be the same as your QA URL, but with **"-prod"** instead of **"-qa"**. Note the **v3.0**.

    ![](images/079.png)

<a name="Ex1Task6"></a>
### Task 6: Working with deployment slots ###

1. Return to the browser window open to the Azure portal.

1. Azure App Services offer **deployment slots**, which are parallel targets for application deployment. The most common scenario for using a deployment slot is to have a staging stage for your application to run against productions services, but without replacing the current production application. If the staging deployment passes review, it can immediately be "swapped" in as the production slot with the click of a button. As an additional benefit, the swap can be quickly reversed in the event an issue is uncovered with the new build. Locate the resource group created earlier and click the **prod** app service.

    ![](images/080.png)

1. Select the **Deployment slots** tab. If you see a message indicating that your current pricing tier does not support slots, follow the workflow to upgrade this service to a **Production** tier or higher and then return here. You may need to refresh the browser for the **Add Slot** option to become enabled.

    ![](images/081.png)

1. Click **Add Slot**. Note that the **production** slot is considered a "default" slot and is not shown as a separate slot in the user experience.

    ![](images/082.png)

1. Enter a **Name** of **"staging"** and select the **Configuration Source** that matched your existing deployment (there should be only one). Click **Add** to create the slot.

    ![](images/083.png)

1. Return to the Azure DevOps tab with the **Prod** stage pipeline editor.

1. Select the **Deploy Azure App Service** task.

    ![](images/084.png)

1. Check **Deploy to Slot...** and set the **Resource group** and **Slot** to those created earlier.

    ![](images/085.png)

1. **Save** the release pipeline.

    ![](images/086.png)

1. Follow the workflow from earlier to commit a change to the codebase at **"PartsUnlimited-aspnet45/src/PartsUnlimitedWebsite/Views/Shared/_Layout.cshtml"** by updating the layout template from **"3.0"** to **"4.0"**.

1. Follow the release pipeline through deployment and approve the release to production when requested.

1. When the production deployment has completed, refresh that browser tab. Note that there shouldn't be any change since the deployment was pushed to a different slot.

    ![](images/087.png)

1. Open a new tab to the **staging** slot. This will be the same as your production URL, but with **"-staging"** appended to the app service name within the domain. This should reflect the new **v4.0**.

    ![](images/088.png)

1. Return to the browser window open to the **Azure portal**. Click **Swap** in the deployment slots blade.

    ![](images/089.png)

1. The default options here are exactly what we want: to swap the production and staging slots. Click **Swap**. Note that if your apps rely on **slot-level configuration settings** (such as connection strings or app settings marked "slot"), then the worker processes will be restarted. If you're working under those circumstances and would like to warm up the app before the swap completes, you can select the **Swap with preview** swap type.

    ![](images/090.png)

1. Return to the **prod** browser window (not the staging slot) and refresh. It will now be the 4.0 version.

    ![](images/091.png)

