---
title: Debugging with Snapshot Debugger
layout: page
sidebar: vsts
permalink: /labs/devopsserver/snapshotdebugger/
folder: /labs/devopsserver/snapshotdebugger/
version: Lab version - 16.0.0
updated: Last updated - 4/4/2019
redirect_from: "labs/tfs/snapshotdebugger/index.htm"
---
<div class="rw-ui-container"></div>

<a name="Overview"></a>
## Overview ##

Many developers still rely on traditional or live debugging techniques which shows only your applications current state with limited data about past events. You either have to guess what happened based on your current state, or you have to recreate these events by rerunning your app. Developers rely on breakpoints to try capturing some of the errors that might appear because of unknown events, sometimes even a breakpoint won't be able to reach the issue - after all, maybe the breakpoint won't be hit at all.

Diagnosing issues in the cloud is especially time consuming for a few reasons:

- Issues are often caused by different configuration, data, and usage patterns

- You don't have the same debugging tools readily available in the cloud that you have locally

- Your production site is serving live traffic, so you are limited in what you can do

Snapshot Debugger expands this traditional debugging experience by recording specific events and data at these points in time. This lets you see what happened in your application when the exception was thrown with call stack information and variables. Snapshot Debugger enables to you drill down into an application's code at the exact moment that the exception occurred to help pinpoint causes of issues without having to negatively impact the performance of the app while it's in production. Snapshot Debugger will help you find any problem, no matter how hard, especially when logs leave you hanging.

<a name="Prerequisites"></a>
## Prerequisites ##

In order to complete this lab you will need the DevOps Server 2019 virtual machine provided by Microsoft. Click the button below to launch the virtual machine on the Microsoft Hands-on-Labs portal.

<a href="https://www.microsoft.com/handsonlabs/selfpacedlabs/details/DT00158" class="launch-hol" role="button" target="_blank"><span class="lab-details">Launch the virtual machine</span></a>

Alternatively, you can download the virtual machine from [here](../devopsvmdownload).

You also need an [Azure account](https://azure.microsoft.com/) ([Get a $25 monthly Azure credit by joining Visual Studio Dev Essentials](https://www.visualstudio.com/dev-essentials/)).

<a name="Exercise1"></a>
## Exercise 1: Debugging with Snapshot Debugger ##

<a name="Ex1Task1"></a>
### Task 1: Configuring Application Insights for Snapshot Debugging ###

1. Log in as **Sachin Raj (VSALM\Sachin)**. All user passwords are **P2ssw0rd**.

1. Launch **Visual Studio** from the taskbar.

1. Open the **PartsUnlimited** solution from the **Start Page**.

    ![](images/000.png)

1. Right-click the project node and select **Configure Application Insights**.

    ![](images/001.png)

1. Click **Update SDK** to update to the latest Application Insights SDK.

    ![](images/002.png)

1. Click **Get Started**.

    ![](images/003.png)

1. Click **Sign in** and log in with the Microsoft account associated with your Azure account.

    ![](images/004.png)

1. Click **Configure settings** to configure the SDK to create a new resource group for this Application Insights instance.

    ![](images/005.png)

1. Select **PartsUnlimitedWebsite** as the **Resource Group** and click **OK**.

    ![](images/006.png)

1. Click **Register** to create the resource.

    ![](images/007.png)

1. Click **Collect traces from System.Diagnostics**.

    ![](images/008.png)

1. From **Solution Explorer**, right-click the **PartsUnlimitedWebsite** project node and select **Manage NuGet Packages**.

    ![](images/009.png)

1. From the **Browse** tab, search for **"snapshot collector"**and select **Microsoft.ApplicationInsights.SnapshotCollector**. Click **Install** and accept any licenses.

    ![](images/010.png)

1. Open **ApplicationInsights.config** from the root of the web app folder. This file defines which modules, initializers, sinks, and other configuration settings to use.

    ![](images/011.png)

<a name="Ex1Task2"></a>
### Task 2: Updating the project source ###

1. In order to have something to debug, we will introduce an unhandled exception. Use **Solution Explorer** to search for **"string"** and open the **StringContainsProductSearch** constructor.

    ![](images/012.png)

1. Scroll down to the **Search** method and add the line below within the **catch** block. By default, the search feature swallows all exceptions to avoid a broken user experience, but in this case we want any exceptions to raise up so Application Insights can track them.

    ```c#
    throw;
    ```
    ![](images/013.png)

<a name="Ex1Task3"></a>
### Task 3: Publishing the application to Azure ###

1. In **Solution Explorer**, right-click the project node and select **Publish**.

    ![](images/014.png)

1. Keep the defaults and click **Publish**.

    ![](images/015.png)

1. Select the **Resource Group** created earlier for the Application Insights instance. If you left it as the default, it should be **PartsUnlimitedWebsite**. Note that certain features, such as attaching the snapshot debugger (in a later task) require a paid app service plan. You may confirm that this app service plan's **Size** is not **"Free"** or **"Shared"** using the **New** button next to its field.

    ![](images/016.png)

1. Under **Explore additional Azure services** click **Create a SQL Database**.

    ![](images/017.png)

1. Under **Database server**, click **New**.

    ![](images/018.png)

1. Provide credentials for the database. You may select your own or use something like **sysadmin** and **P2ssw0rd**. Click **OK**.

    ![](images/019.png)

1. Update the **Connection String Name** to **"DefaultConnectionString"**. This is the property Visual Studio will look for in your Web.config to replace with the Azure SQL Database connection string during the publish process. Click **OK**.

    ![](images/020.png)

1. Click **Create** to create the app service and publish the app.

    ![](images/021.png)

1. The deployment process will take a few moments.

    ![](images/022.png)

1. Once it completes, your application will be published and a browser will be opened to it in Visual Studio.

<a name="Ex1Task4"></a>
### Task 4: Generating and tracing some failures ###

1. Use the Parts Unlimited site to search for **"jumper lead"**.

    ![](images/023.png)

1. There should be a hit since this is a stocked product.

    ![](images/024.png)

1. Search again for **"jumper leads"** (note the plural).

    ![](images/025.png)

1. This time there is a page crash, which is clearly a bug since the site search is supposed to support both of these search strings. Go back and run the same search a few more times (at least five) for this same string to confirm that the site crashes reliably.

1. Open a new browser window to the Azure portal at [https://portal.azure.com](https://portal.azure.com/) and log in.

1. Start searching for **"parts"** and click the **PartsUnlimitedWebsite** result for Application Insights.

    ![](images/026.png)

1. Click the **Failures** tab. This section enables you to aggregate and explore all site failures in a single place.

    ![](images/027.png)

1. Select the **Exceptions** tab. In the **Top 10 exception types** table, locate **ArgumentOutOfRange** exception. If there are none, click the **Refresh** button as it may take a few minutes for the reports to come in. Otherwise, click the **Count** link to review exceptions of that type.

    ![](images/028.png)

1. Click the **Suggested** exception.

    ![](images/029.png)

1. The exception blade provides a lot of useful information about the user and the request to help you diagnose the issue. In addition, a debug snapshot was automatically taken at the time of the exception in order to make it even easier to track down where the issue occurred and why. Click **Open debug snapshot**. Note that it may take several minutes for this option to appear for an exception. If the option is not visible, close the blade and wait a minute before reopening it via the option in the previous step.

    ![](images/030.png)

1. The first time you attempt to view a snapshot you will likely see an access error. Click the provided button to add the appropriate permissions.

    ![](images/031.png)

1. Click **Download Snapshot**. It will take a moment to prepare the download.

    ![](images/032.png)

1. Right-click **Download file** and save it somewhere convenient, such as the desktop.

    ![](images/033.png)

1. Return to **Visual Studio**.

1. Select **File \| Open \| File** and open the diagnostic session file downloaded earlier. Approve any warnings about the trustworthiness of the file.

1. This minidump provides a ton of valuable information about the state of the machine and its memory at the time of the exception. However, we're specifically interested in the state of the application. Click **Debug with Managed Only**.

    ![](images/034.png)

1. If presented with a warning regarding **Just My Code**, select the option to **Disable Just My Code and Continue**.

    ![](images/035.png)

1. The snapshot will load the app at the exact moment of the exception. Based on the details provided, it's easy to deduce that the bug is due to indexing past the length of the query when attempting to remove the pluralzation. Click the next item in the call stack to view the calling code.

    ![](images/036.png)

1. We can see here why the error was never being exposed to end users-the exceptions were being swallowed. Unfortunately, they also weren't being tracked. This would probably be another issue to fix while addressing the core bug.

    ![](images/037.png)

1. Now that we know what the error is and why it wasn't getting surfaced, we can generate a code map of this path to see if it might be an unknown problem in other parts of the application. Right-click the reference to **Depluralize** and select **Code Map \| Find All References on Code Map**.

    ![](images/038.png)

1. Fortunately, we can see here that this **Search** method is the only reference to **Depluralize**. Right-click **Search** and select **Find All References** to see what code calls into this method.

    ![](images/039.png)

1. Besides a few tests, the only other references to this bug come from the **Index** and **Search** handlers. This kind of information is very useful in deciding how to deal with a bug like this.

    ![](images/040.png)

1. Select **Debug \| Stop Debugging** to end the session.

<a name="Ex1Task5"></a>
### Task 5: Working with Snappoints and Logpoints ###

1. In addition to automatic snapshots, Application Insights enables two additional features that make it easy to debug production apps: **Snappoints** and **Logpoints**. Snappoints are like breakpoints in that they allow you to take snapshots of a system when a given line is executed, but without actually noticeably pausing the execution of the application. Logpoints work in the same way, except that they allow you to inject custom logging into production apps on the fly.

1. Select **View \| Cloud Explorer**.

1. Click the **Account** button.

    ![](images/041.png)

1. Select the subscription containing your deployment and click **Apply**.

    ![](images/042.png)

1. Right-click the app service and select **Attach Snapshot Debugger**.

    ![](images/043.png)

1. Select or create the storage you would like to use for the session and click **Attach**.

    ![](images/044.png)

1. Use **Cloud Explorer** to **Stop** the app service.

    ![](images/045.png)

1. Allow the app service to be restarted.

1. After attaching, bring up **StringContainsProductSearch.cs**. You will see a yellow message at the top of the editor indicating that you are in a debugging session for an application running in Azure. Click the margin next to the exception handler's **throw** line in the **Search** method added earlier. Ordinarily this would set a breakpoint, but since you're attached with the Snapshot Debugger, it sets a **Snappoint**.

    ![](images/046.png)

1. Right-click the snappoint and select **Actions**.

    ![](images/047.png)

1. By default, a snappoint will capture a snapshot when this line is hit. You can optionally configure it using conditions, just like a breakpoint. You can also insert a logpoint by entering the **Message** "**Search query failed! {query}"**. This will get logged when the production code hits this line. Note that you get IntelliSense support here. Click **Close**.

    ![](images/048.png)

1. Click **Start Collection** to begin collecting snapshots at the snappoint.

    ![](images/049.png)

1. Use the browser to search for **"jumper leads"** once again.

    ![](images/050.png)

1. This will trigger a flurry of activity in the **Diagnostic Tools** window. Note that the logpoint includes the interpolated string specified earlier, including the search string.

    ![](images/051.png)

1. You can also expand the snapshot to click on **View Snapshot**.

    ![](images/052.png)

1. This will load the snapshot for debugging, just like if it were running locally. However, keep in mind that this is just a snapshot of the system at the time of the snappoint line being executed.

    ![](images/053.png)

1. Select **Debug \| Stop Debugging** to end the session.

