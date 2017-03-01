---
title: Embracing Continuous Delivery with Release Management for Visual Studio 2017
layout: page    
sidebar: tfs
permalink: /labs/tfs/releasemanagement/
folder: /labs/tfs/releasemanagement/
---

## Overview

In this lab, you will learn about the release management features
    available in Visual Studio 2017 and its suite of release and
    deployment tools that automate the deployment of applications across
    the desktop, server, and the cloud. The release management features
    of Visual Studio 2017 help development and operations teams
    integrate with Team Foundation Server to configure and automate
    complex deployments of their automated builds to target environments
    more easily. Development teams can also model their release
    processes and track approvals, sign-offs, and visualize their
    release status.

## Pre-requisites

In order to complete this lab you will need the Visual Studio 2017
    virtual machine provided by Microsoft. For more information on
    acquiring and using this virtual machine, please see [this blog
    post](http://aka.ms/ALMVM).

Exercise 1 of the “Introduction to Team Foundation Build” lab is a
    prerequisite for this lab.

## Exercise 1: Continuous Release Management

In this exercise, you will use the release management features of
    Team Foundation Server to produce an automated deployment solution.
    This exercise will take an existing enterprise application and
    automate its deployment to the development team’s testing
    environment after each source check-in.

### Task 1: Configuring a continuous build

1.  Log in as **Brian Keller** (VSALM\\Brian). All user passwords are **P2ssw0rd**.

2.  Open **Internet Explorer**.

3.  Navigate to the **TFS FF Portal** using the bookmark at the top of the browser.

    <img src="media/image2.png" width="406" height="115" />

4.  Click the **Code** tab.

    <img src="media/image3.png" width="369" height="120" />

5.  You can easily edit files on the server and check them in from the browser, which is great for scenarios where you only need to make 
    minor tweaks. You’ll come back to this tab in future steps, so
    leave it open as you move forward.

6.  Right-click the **Build & Release | Builds** tab and select **Open
    in new tab** to view builds. You’re going to move back and forth
    between parts of TFS, so keeping these separate tabs open will
    make things easier as you go along. After the tab opens, switch to it.

    <img src="media/image4.png" width="460" height="131" />

7.  Click **New definition** to create a new build definition.

    <img src="media/image5.png" width="580" height="315" />

8.  Select the **Visual Studio** template and click **Next**.

    <img src="media/image6.png" width="585" height="437" />

9.  The default settings are fine here, so just check the box to enable **continuous integration** and click **Create**.

    <img src="media/image7.png" width="569" height="540" />

10. Select the **Repository** tab and update the **Mappings** so that
    both use the **“$/FabrikamFiber/Dev”** branch.

    <img src="media/image8.png" width="624" height="379" />

11. Return to the **Build** tab and select the **Visual Studio
    Build** step. Set the **MSBuild Arguments** to the text below.
    Also change the **Visual Studio Version** to **Visual Studio 2017**.

    **/p:OutDir=$(build.stagingDirectory)**

    <img src="media/image9.png" width="624" height="172" />

12. Remove the **Visual Studio Test** and **Index Sources & Publish
    Symbols** steps from the process.

    <img src="media/image10.png" width="375" height="255" />

13. Click **Save**.

    <img src="media/image11.png" width="388" height="105" />

14. Set the **Name** to **“Fabrikam Development CI”** and click **OK**.

    <img src="media/image12.png" width="461" height="267" />

15. Return to the browser tab opened to the **Code** hub.

16. Navigate to the path below to open a shared layout file used to
    present a consistent look and feel for the site.

    **$/FabrikamFiber/Dev/FabrikamFiber.CallCenter/FabrikamFiber.Web/Views/Shared/\_Layout.cshtml**

    <img src="media/image13.png" width="624" height="111" />

17. Click **Edit** to enable editing directly in the browser.

    <img src="media/image14.png" width="79" height="98" />

18. Locate the “Support” text within a **H2** tag (around line 29).
    Change it to “Support v2.0” and click the **Save** icon to check
    in the change. This check-in will invoke a build now that
    continuous integration builds have been enabled.

    <img src="media/image15.png" width="556" height="106" />

19. Switch back to the browser tab with the builds. Select the **Builds** tab.

    <img src="media/image16.png" width="389" height="135" />

20. There should now be a build in progress. Click it to review
    the progress.

    <img src="media/image17.png" width="624" height="160" />

21. You don’t need to wait for the build to complete to move on to the
    next step.

### Task 2: Creating a continuous release

1.  Now that there is an automatic build that occurs when changes are
    checked in, it’s time to set up a continuous release so that this
    new build can make its way out to stakeholders. Right-click the
    **Release** tab and select **Open in new tab**. You should now
    have three tabs open: Code, Build, and Release. Switch to the
    Release tab.

    <img src="media/image18.png" width="317" height="194" />

2.  To create your first release, click **New definition**.

    <img src="media/image19.png" width="514" height="266" />

3.  Select the **Empty** definition and click **Next**. You may need to
    scroll down to find it at the bottom.

    <img src="media/image20.png" width="587" height="328" />

4.  Check **Continuous deployment** and click **Create**. This indicates
    that the release should execute as soon as the build completes.
    Note that a default build definition is selected, which we could
    change if needed. It happens to be the one we want to work
    with here.

    <img src="media/image21.png" width="556" height="482" />

5.  Click the **Edit** button and change the release name to “Fabrikam
    Release” as the release name. Press **Enter**.

    <img src="media/image22.png" width="624" height="130" />

6.  By default, there is one environment, which you will rename “Dev”.
    This will represent the “Dev” environment used by the dev team
    during development.

    <img src="media/image23.png" width="497" height="263" />

7.  The first thing you need to do with this environment is to indicate
    the conditions under which it will be deployed to. Click the
    ellipses button in the environment box and select **Deployment
    conditions**.

    <img src="media/image24.png" width="345" height="288" />

8.  Under **Deployment conditions**, note that **After release
    creation** is already selected because this definition was
    configured as continuous. Press **Esc** to close the dialog.

    <img src="media/image25.png" width="624" height="464" />

9.  Now that the basic settings of the environment have been defined,
    it’s time to configure exactly how a release is deployed. This is
    done through a series of **Tasks** that involve any process you
    need to get the job done. The “Dev” environment is pretty
    straightforward since it just involves copying files from the
    build directory to a directory configured to be used by IIS (which
    happens to be on the same machine in this lab scenario). Click
    **Add tasks** to select which agent or server tasks you want as
    part of the workflow. Click **Add an agent phase**.

    <img src="media/image26.png" width="474" height="260" />

10. Under the **Utility** tab, click **Add** from **Copy Files** to add
    one of those tasks to the workflow. Note that you could add a
    variety of tasks to the process, so the dialog doesn’t close after
    you hit **Add**. Instead, just click it once and then click
    **Close** to return to the main view.

    <img src="media/image27.png" width="624" height="537" />

11. There are three key settings for the **Copy Files** task. First, set
    **Source Folder** to the path below.

    **$(System.DefaultWorkingDirectory)/Fabrikam Development CI/drop/\_PublishedWebSites/FabrikamFiber.Web**

12. Next, set **Target Folder** to the path below.

    **c:\\FabrikamRM\\WebSite\\DEV**

13. Finally, expand **Advanced** and check **Overwrite** to indicate
    that it’s okay to overwrite existing files at the destination.

    <img src="media/image28.png" width="517" height="240" />

14. Now that this process has been configured, click **Save**.

    <img src="media/image29.png" width="310" height="149" />

15. Open a new browser tab and navigate to the Fabrikam Fiber Dev site.
    Note that the “Support” text is still just “Support” because the
    most recent changes were checked in and built, but not deployed.

    <img src="media/image30.png" width="595" height="175" />

16. Switch to the browser tab open to the builds page (probably the
    second one).

17. Click **Queue new build**. Note that you could make another change
    to the source and check it in, but this process cuts to the chase.

    <img src="media/image31.png" width="555" height="58" />

18. Accept the defaults and click **OK**.

    <img src="media/image32.png" width="476" height="378" />

19. Switch to browser tab open to the releases.

20. Select the **Releases** tab to view release history.

    <img src="media/image33.png" width="318" height="84" />

21. If there are no releases in the view, refresh the browser every few
    seconds (or press the **Refresh** button in the UI). The build
    should complete pretty quickly and kick off the new release. When
    it appears, note that there is a single grey bar under
    **Environments**. This represents the **Dev** environment, which
    hasn’t begun yet. If the bar is blue, then that means the
    deployment is in progress. Green means it succeeded and red means
    it failed. Double-click the release to view the details.

    <img src="media/image34.png" width="624" height="102" />

22. There are many options for reviewing the release. Most of these are
    already familiar since you just went through the process of
    setting them up. But if you consider a scenario where there are
    many different releases occurring at the same time, it’s very
    useful to have easy access to all the settings and details used to
    define a release. Click the **Logs** tab to watch the
    process unfold.

    <img src="media/image35.png" width="624" height="203" />

23. Return to the **Summary** tab and refresh the view using the inline
    **Refresh** button until the deployment succeeds.

    <img src="media/image36.png" width="624" height="361" />

24. Return to the Fabrikam Fiber Dev browser tab and refresh it to
    confirm the changes have been deployed.

    <img src="media/image37.png" width="358" height="163" />

## Exercise 2: Gated Releases


While automated releases are great, sometimes you want to gate their
    progress by requiring user approval. In this exercise, you will
    add a second environment to the release process for QA and user
    acceptance testing. In this scenario, you will allow the release
    to reach the QA site, but only if it successfully deploys to Dev.
    Once it’s available on QA, it won’t be considered “success” until
    approved manually. Note that it’s just as easy to also
    (or alternatively) have this human approval gate prior to
    the deployment.

### Task 1: Adding a QA environment

1.  Return to the tab with all the releases (probably the third).

2.  Click the release name to return to its overview.

    <img src="media/image38.png" width="252" height="136" />

3.  Click **Edit** to enter edit mode.

    <img src="media/image39.png" width="292" height="130" />

4.  Click the ellipses in the **Dev** environment and select **Clone
    environment**. Your **QA** environment is the same as **Dev**,
    except that it’s copied to a different output folder. Using this
    clone technique saves a lot of configuration time.

    <img src="media/image40.png" width="319" height="343" />

5.  In the **Add new environment** dialog, select the option to specify
    **Specific users** for pre-deployment approval. Add **Brian
    Keller** as the user. Also ensure the **Deploy automatically** box
    is checked before clicking **Create**. Note that you can also
    configure post-deployment approvers and other common behaviors
    later on.

    <img src="media/image41.png" width="564" height="399" />

6.  Change the name of the new environment to “QA” and press **Enter**.

    <img src="media/image42.png" width="185" height="194" />

7.  In the **Copy Files** task, change the final destination folder from
    “DEV” to “UAT” (short for “User Acceptance Testing”).

    <img src="media/image43.png" width="624" height="142" />

8.  **Save** the release.

    <img src="media/image44.png" width="473" height="111" />

9.  Open a new browser tab and navigate to the Fabrikam Fiber QA site.
    Note that it still has the original support text.

    <img src="media/image45.png" width="574" height="175" />

10. Return to the browser tab open to the code view in TFS (probably the
    first one) and repeat the editing process to change the “Support
    v2.0” text to “Support v3.0”. Save and check in the change
    as before. This will kick off the build, which will hand off to
    the release to Dev, which will hand off to QA.

11. Return to the releases tab and click the link to view
    release history.

    <img src="media/image46.png" width="322" height="92" />

12. Note now that there are two release bars indicating status.
    Depending on how quickly you get here, these colors may vary by
    how far the release workflow has progressed. Refresh the data
    until you see the “awaiting approval” icon shown below (next to
    the blue bar). Click it when shown.

    <img src="media/image47.png" width="456" height="212" />

13. Enter an optional message and click **Approve**.

    <img src="media/image48.png" width="412" height="208" />

14. Refresh the results until both bars are green, which will indicate
    that both environment releases succeeded.

    <img src="media/image49.png" width="416" height="146" />

15. Return to the FF QA site (probably the last tab) and confirm the
    “v3.0” made it through.

    <img src="media/image50.png" width="456" height="166" />

## Exercise 3: Releasing To Azure (optional)

The release management tools are incredibly flexible. Not only can you
automate virtually anything, you can even leverage some of the
higher-lever tasks to easily perform complex processes, such as
deploying to an Azure web site.

### Task 1: Creating an Azure Web site and database

1.  Create an Azure account at <http://azure.com> if you don’t already
    have one.

2.  In a new browser tab, navigate to <https://portal.azure.com>.


3.  Select **+New | Data + Storage | SQL Database (new database)** to
    create a new database.

    <img src="media/image51.png" width="466" height="137" />

4.  Enter “fabrikam” as the **Database name**. Select a subscription (it
    doesn’t matter which one, but use the same one for all steps in
    this lab). Select **Create new** for **Resource group** and enter
    “fabrikam” as the name. Make sure **Select source** is set to
    **Blank database** and click **Configure required settings**.

    <img src="media/image52.png" width="289" height="343" />

5.  Click **Create a new server**.

6.  Enter a unique name for **Server name**, such as by including
    your name. Enter a admin username and password you can remember.
    Note that “P2ssw0rd” meets the password requirements. Click
    **Select** to select these options.

    <img src="media/image53.png" width="217" height="358" />

7.  Click **Create** on the first blade to create the database
    > and server. It’ll take some time to complete, but you can move on
    > to the next step while it works in the background.

8.  Select **+New | Web + Mobile | Web App** to create a new Azure
    > web site.

    <img src="media/image54.png" width="624" height="242" />

9.  For **App name**, enter a unique name, such as by using your name
    as part. Select the same **Subscription** and **Resource group**
    as before. If required to create an **App Service plan**, accept
    the defaults. Click **Create** to create.

    <img src="media/image55.png" width="288" height="474" />

10. Click the **Resource groups** tab from the left menu. Locate and
    click the **fabrikam** group created earlier.

    <img src="media/image56.png" width="345" height="226" />

11. Click the SQL Server (not the database) and click **Show firewall
    settings** in the new blade. There are two SQL icons, and the
    server is the one with the gear. The database is the one without.

    <img src="media/image57.png" width="510" height="114" />

12. You need to allow your current IP address to access the database, so
    click **Add client IP** (which will default to your current IP)
    and then click **Save**. No other external IPs will be allowed to
    connect to your database unless you explicitly let them.

    <img src="media/image58.png" width="164" height="103" />

13. From the **Resources** group, click your SQL database. In the new
    blade, click **Show database connection strings**.

    <img src="media/image59.png" width="504" height="122" />

14. This will provide you with a list of connection strings based
    on platform. Copy the **ADO.NET** string to your clipboard so you
    can configure your new web site to use it.

    <img src="media/image60.png" width="549" height="191" />

15. On the **fabrikam** database blade, click **Delete** and then
    confirm the deletion. You’ll publish an existing database using
    **SQL Server Management Studio** later on to save time.

    <img src="media/image61.png" width="378" height="33" />

16. In the **Resources** panel, click the web app created earlier. It’s
    the one with the globe icon by itself. In the rightmost blade that
    opens, click **Application settings**. Note that if the web app
    isn’t available yet, you can refresh the view by clicking the
    **fabrikam** link under **Resource group** in the database blade.

    <img src="media/image62.png" width="624" height="246" />

17. On this blade you can configure settings for your app, such as
    connection strings. Locate the **Connection strings** section and
    add a new entry with the key “FabrikamFiber-Express” and the value
    pasted from the clipboard. You’ll need to locate the
    “{your\_password\_here}” section and replace it (including braces)
    with the actual SQL password entered earlier. Press **Enter**
    to complete.

    **Server=tcp:
    fabrikam-johndoe.database.windows.net,1433;Database=fabrikam;User
    ID=johndoeadmin@fabrikam-johndoe;Password={your\_password\_here};Encrypt=True;TrustServerCertificate=False;Connection
    Timeout=30;**

    <img src="media/image63.png" width="442" height="93" />

18. Click **Save** from the toolbar to commit.

    <img src="media/image64.png" width="443" height="107" />

19. By now the SQL database should be available for use. From the
    > **Start Menu**, enter “SQL Server Management Studio” and launch
    > that app.

    <img src="media/image65.png" width="259" height="222" />

20. By default, the settings are in place for the server that hosts the
    database you want to set up in the cloud. Click **Connect**
    to connect.

    <img src="media/image66.png" width="469" height="300" />

21. Right-click the **FabrikamFiber-Express** database and select
    **Tasks | Deploy Database to Microsoft Azure SQL Database**.

    <img src="media/image67.png" width="624" height="504" />

22. On the **Introduction** page of the wizard, click **Next**.

23. Click **Connect** to set up the SQL Azure database connection.

    <img src="media/image68.png" width="349" height="227" />

24. In the **Connect to Server** dialog, enter the connection details
    for your SQL Azure database. For example, if your database name
    was “fabrikam-johndoe”, then the **Server name**
    is “fabrikam-johndoe.database.windows.net”. Click **Connect**
    when done. Note that if you plan to copy/paste any of this into
    the dialog you’ll want to first paste the current clipboard
    contents (the SQL script) into Notepad for temporary safekeeping.

    <img src="media/image69.png" width="294" height="221" />

25. Dasads

    <img src="media/image70.png" width="343" height="241" />

26. Click **Finish** on the final page of the wizard to deploy
    the database.

    <img src="media/image71.png" width="412" height="383" />

### Task 2: Configuring the build to produce a Web Deploy package

1.  Return to the browser tabs open to the builds section of the portal.

2.  Click **Edit** to edit the build definition.

    <img src="media/image72.png" width="553" height="46" />

3.  Select the **Visual Studio Build** step and add the following
    arguments after the existing arguments. Be sure to include a space
    before adding the new arguments.

    **/p:DeployOnBuild=true /p:WebPublishMethod=Package
    /p:PackageAsSingleFile=true /p:SkipInvalidConfigurations=true**

    <img src="media/image73.png" width="624" height="195" />

4.  Click **Save** to save the build definition. It will now produce the
    web deploy zip needed for publication to Azure.

    <img src="media/image74.png" width="284" height="114" />

### Task 3: Creating a release environment for Azure

1.  Return to the releases tab.

2.  Everything has been set up for releasing to Azure, so you just need
    to add an environment for it. Click the **Edit** link to enter
    edit mode.

    <img src="media/image75.png" width="207" height="152" />

3.  Select **Add environment | Create new environment**.

    <img src="media/image76.png" width="185" height="178" />

4.  Select the **Azure Website Deployment** template and click **Next**.

    <img src="media/image77.png" width="557" height="300" />

5.  Select **Brian Keller** as the pre-deployment approver again and
    click **Create**.

    <img src="media/image41.png" width="564" height="351" />

6.  Set the name of the new environment to **Prod-Azure** and press
    **Enter**.

    <img src="media/image78.png" width="127" height="240" />

7.  Click the **Ellipses** button for **Prod-Azure** and select **Assign
    approvers**.

    <img src="media/image79.png" width="322" height="336" />

8.  Add **Brian Keller** as the post-deployment approver and click
    **OK**.

    <img src="media/image80.png" width="624" height="422" />

9.  Remove the **Visual Studio Test** task from the workflow to keep
    things simple.

    <img src="media/image81.png" width="306" height="137" />

10. It’s now time to configure the connection to Azure. Click the
    **Manage** link next to the **Azure Subscription** field. This
    will bring you to the Azure connection configuration page.

    <img src="media/image82.png" width="500" height="100" />

11. Click **New Service Endpoint | Azure Classic**.

    <img src="media/image83.png" width="229" height="207" />

12. Select **Certificate Based** and click the **publish settings file**
    option at the bottom. This will open a link to download a publish
    settings file that contains the details needed to complete
    this form.

    <img src="media/image84.png" width="552" height="340" />

13. When prompted by the browser, select **Save As**, change the name to
    “creds.txt”, and save it to the desktop for easy access. Note that
    the browser may ask you to log in first.

14. Open “creds.txt” using notepad. It’s XML, but you’ll be able to
    parse out what you need by hand.

15. Locate the three key fields needed to configure the
    Azure connection. Note that if you have multiple Azure
    subscriptions, you’ll need to make sure you’re working with the
    one used to create the SQL server and web site earlier.

    <img src="media/image85.png" width="521" height="260" />

16. Set the **Connection** name to “Fabrikam Azure” and configure the
    remaining details using the data from creds.txt. Note that
    **Management Certificate** is all on the same line, despite the
    appearance with word wrapping. Click **Verify connection** to
    confirm and **OK** to continue.

    <img src="media/image86.png" width="565" height="503" />

17. After the connection has been created, you can close this tab.

18. Return to the releases tab. Click the **Refresh** button next to the
    **Manage** link. This will enable you to select the **Azure
    Subscription** connection you just created. Type in the **Web App
    Name** of the Azure web site created earlier and select the **Web
    App Location** used during creation.

    <img src="media/image87.png" width="498" height="125" />

19. Set the **Web Deploy Package** to the path below. Note that you
    could also specify additional arguments, such as a connection
    string, as part of this workflow if required.

    **$(System.DefaultWorkingDirectory)/Fabrikam Development
    CI/drop/\_PublishedWebsites/FabrikamFiber.Web\_Package/FabrikamFiber.Web.zip**

20. Save the release.

    <img src="media/image88.png" width="434" height="181" />

### Task 4: Checking in a change to kick off the release workflow

1.  Return to the code browser tab and locate the path below.

    **$/FabrikamFiber/Dev/FabrikamFiber.CallCenter/FabrikamFiber.Web/Global.asax.cs**

2.  Click the **Edit** button and comment out the
    **Database.SetInitializer** call in **Application\_Start**. This
    won’t work properly in Azure, so it needs to be commented out. It
    doesn’t matter since the DB was already set up manually.

3.  Save the file to check it in.

    <img src="media/image89.png" width="499" height="127" />

4.  Return to the releases tab in the browser. If the new release
    process doesn’t show up within a minute, refresh the window or use
    the refresh button. Approve the first two requests to begin the
    Azure deployment. You’ll know the bits have been deployed to
    production when you’re asked for the post-release signoff.

    <img src="media/image90.png" width="512" height="151" />

5.  Open a browser tab to the Azure site to confirm the deployment
    worked as expected. For example, if you named your site
    fabrikam-johndoe, then the URL would be
    <http://fabrikam-johndoe.azurewebsites.net>.

    <img src="media/image91.png" width="470" height="169" />

6.  Return to the releases tab and approve the release by clicking the
    icon, optionally entering a message, and clicking **Approve.**

    <img src="media/image92.png" width="492" height="216" />

7.  Now everyone can easily see that the most recent release made it all
    the way through the release pipeline and is live in the cloud.

    <img src="media/image93.png" width="210" height="54" />

### Task 5: Deploying to Azure from Visual Studio

1. While all of the automation available in Team Foundation Server provides a great “continuous integration, continuous deployment” (CICD) experience, sometimes you may still want to manually deploy a build directly from Visual Studio. And thanks to tight integration between Visual Studio and Azure,   it’s really easy to do.

2. Open a new instance of Visual Studio from the taskbar.

3. Open FabrikamFiber.CallCenter.sln from the Start Page.

   <img src="media/image94.png"/>

4. We’ll continue using the support version number as our change example. In Solution Explorer, double-click FabrikamFiber.Web\Views\Shared\_Layout.cshtml to open it.

   <img src="media/image95.png"/>

5. Locate the tag with the support version and increment it to v5.0.

   <img src="media/image96.png"/>

6. In Solution Explorer, right-click the FabrikamFiber.Web project and select Publish.

   <img src="media/image97.png"/>

7. Since this is the first time this project is being published to Azure, we will need to set up a publish profile. Select the Profile tab and click Microsoft Azure App Service.

   <img src="media/image98.png"/>

8. Since there is not yet an account associated with this instance of Visual Studio, click Add an account from the dropdown.

   <img src="media/image99.png"/>

9. Sign in using the Microsoft account your Azure subscription is associated with.

10. Select the App Service created earlier and click OK.

    <img src="media/image100.png"/>

11.	The Connection tab is automatically populated with the deployment information required to push the project out to the right Azure App Service. There’s nothing to tweak here, so click Next.

    <img src="media/image101.png"/>

12.	The Settings tab enables you to specify the build configuration you want to deploy, as well as file publication options and settings for databases detected from Web.config. We already configured the connection string earlier, so click Next to continue.

    <img src="media/image102.png"/>

13.	The Preview tab enables you to see exactly what will get pushed up to the service. Click Start Preview to see which files have changed.

    <img src="media/image103.png"/>

14.	There should be only one file: _Layout.cshtml. Click Publish.

    <img src="media/image104.png"/>

15.	You can review the publish progress in the Web Publish Activity pane at the bottom if Visual Studio. It should complete quickly since the one file being pushed is small.

    <img src="media/image105.png"/>

16.	Upon completion, the integrated browser will open to the public URL. Note the new version number, which confirms the deployment was successful.

    <img src="media/image106.png"/>

### Task 6: Working with Deployment Slots

1. Azure App Services offer deployment slots, which are parallel targets for application deployment. The most common scenario for using a deployment slot is to have a staging environment for your application to run against productions services, but without replacing the current production              application. If the staging deployment passes review, it can immediately be “swapped” in as the production slot with the click of a button. As an additional benefit, the swap can be quickly reversed in the event an issue is uncovered with the new build.

2. Return to the browser window open to the Azure portal.

3. Select the Resource groups tab from the left menu. Locate and click the fabrikam group created earlier.

   <img src="media/image107.png"/>

4. Click the App Service.

   <img src="media/image108.png"/>

5. Select the Deployment slots tab and click Add Slot. Note that the production slot is considered a “default” slot and is not shown as a separate slot in the user experience.

   <img src="media/image109.png"/>

6. Enter a Name of “staging” and select the Configuration Source that matched your existing deployment (there should be only one). Click OK to create the slot.
   
   <img src="media/image110.png"/>

7. Return to _Layout.cshtml in Visual Studio. Update the version text to “5.0”.

   <img src="media/image111.png"/>

8. In Solution Explorer, right-click the FabrikamFiber.Web project and select Publish.

   <img src="media/image112.png"/>

9. The new slot is treated as a unique deployment target, so we’ll need to set up a profile for it. However, your Microsoft and Azure accounts are already configured, so the experience will be even smoother. Select the Profile tab and click Microsoft Azure App Service.

   <img src="media/image113.png"/>

10.	Drill down to select the staging deployment slot and click OK. 

    <img src="media/image114.png"/>

11.	On the Connection tab you’ll notice that the settings are very similar to the production slot, except that the text “staging” is inserted within various strings. The key place of interest is that each URL differs from the production slot by having “-staging” inserted at the end of the lowest        subdomain. For example, if your subdomain started with “fabrikam-johndoe”, then a slot named “staging” would have the URL “fabrikam-johndoe-staging”. Click Publish to deploy.

    <img src="media/image115.png"/>

12.	Once the deployment finishes you’ll see the built-in browser navigate to the staging slot, which can be verified via the support version number.

    <img src="media/image116.png"/>

13.	However, if you take the “-staging” out of the URL and press Enter, you’ll see that the production site is still on v4.0, as expected.

    <img src="media/image117.png"/>

14.	Expand the Server Explorer from the left side of Visual Studio.

    <img src="media/image118.png"/>

15.	Drill down into the Azure node to review all of the assets accessible from within the IDE. Note the production slot is at the default level while the staging slot is one level deeper under Slots. You can do a lot from this pane, including opening file for editing (and saving back to Azure),         reviewing logs, managing WebJobs, and more.

    <img src="media/image119.png"/>

16.	Return to the browser window open to the Azure portal. Click Swap in the slots blade.

    <img src="media/image120.png"/>

17.	The default options here are exactly what we want: to swap the production and staging slots. Click OK. Note that if your apps rely on slot-level configuration settings (such as connection strings or app settings marked “slot”), then the worker processes will be restarted. If you’re working          under those circumstances and would like to warm up the app before the swap completes, you can select the Swap with preview swap type.

    <img src="media/image121.png"/>

18.	Return to Visual Studio and refresh the built-in browser by right-clicking with the document and selecting Refresh. Note that you can’t F5 since that would build and run the solution.

    <img src="media/image122.png"/>

19.	The production site should now show the v5.0 as expected.

    <img src="media/image123.png"/>

20.	You can also confirm that the staging slot is now hosting the former production build of v4.0. In the event something bad happened with the v5.0 build, you could simply run the swap again and this running build would be back in production.

    <img src="media/image124.png"/>

21.	It’s important to note that while we deployed to the staging slot using Visual Studio, you could have just as easily set up CICD in TFS to deploy to the staging slot as well. There are even tasks to automate the swapping of slots, so you could set up everything you need in the release               definition.

    




   
   
