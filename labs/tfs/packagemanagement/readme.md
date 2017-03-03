---
title: Package Management in Team Foundation Server 2017
layout: page
sidebar: tfs
permalink: /labs/tfs/packagemanagement/
folder: /labs/tfs/packagemanagement/
---

Lab version: 15.0.26020.0

Last updated: 2/24/2017


## Overview

Package Management is an extension that makes it easy to discover,
install, and publish NuGet and npm packages in Team Foundation Server.
It's deeply integrated with other hubs like Build so that package
management can become a seamless part of your existing workflows.

## Pre-requisites

In order to complete this lab you will need the Visual Studio 2017
virtual machine provided by Microsoft. For more information on acquiring
and using this virtual machine, please see [this blog
post](http://aka.ms/almvm).

## Exercise 1: Working with the package management service


### Task 1: Configuring the service


1.  Log in as **Sachin Raj (VSALM\\Sachin)**. All user passwords are
    **P2ssw0rd**.

2.  Launch **Internet Explorer** from the taskbar.

3.  From the **Settings Gear** menu, select **Access levels**.

    <img src="media/image1.png" width="544" height="184" />

4.  The **Package Management** service comes with Team
    Foundation Server. It is licensed per-user, although Visual Studio
    Enterprise licenses include access. In this case, our demo users are
    all licensed with Visual Studio Enterprise, although they are not
    yet assigned that access level. We will start that process now by
    selecting the **VS Enterprise** tab.

    <img src="media/image2.png" width="597" height="427" />

5.  Click **Add**.

    <img src="media/image3.png" width="624" height="92" />

6.  Add **Sachin Raj** as a licensed user and click **Save changes**.

    <img src="media/image4.png" width="618" height="239" />

7.  Now that Sachin (the current user) is licensed, the package
    management functionality will appear in his TFS experience. Click
    the **TFS PU Portal** shortcut to navigate to the
    **PartsUnlimited** project.

    <img src="media/image5.png" width="624" height="94" />

8.  From the **Build & Release** menu, select **Packages**. This option
    is new now that Sachin is licensed to use package management.

    <img src="media/image6.png" width="548" height="143" />

9.  There are no feeds by default.

    <img src="media/image7.png" width="624" height="191" />

### Task 2: Creating and connecting to a feed


1.  Click **New feed**. This feed will be a collection of NuGet packages
    available to users within the organization and will sit alongside
    the public NuGet feed as a peer. The scenario in this lab will focus
    on the workflow for using with the package management service, so
    the actual architectural and development decisions are
    purely illustrative.

    <img src="media/image8.png" width="314" height="205" />

2.  This feed will include common functionality that can be shared
    across projects in this organization. Set the name to
    **“PartsUnlimitedShared”** and click **Create**. Leave the default
    security options.

    <img src="media/image9.png" width="520" height="475" />

3.  Any user who wants to connect to this NuGet feed must configure
    their environment. Click **Connect to feed**.

    <img src="media/image10.png" width="506" height="429" />

4.  Copy the **Package source URL**. This is the only thing Visual
    Studio and NuGet need to start taking advantage of the new feed.
    Leave the dialog open in the browser.

    <img src="media/image11.png" width="624" height="360" />

5.  Launch **Visual Studio** from the taskbar.

6.  Select **Tools \| NuGet Package Manager \| Package Manager Settings**.

7.  Locate the **Package Sources** section and click the **Add** button
    to add a new package source.

    <img src="media/image12.png" width="624" height="361" />

8.  Set the **Name** to **“PartsUnlimitedShared”** and paste the
    **Source** URL copied earlier. Click **Update** followed by **OK**.
    Visual Studio is now connected to the new feed.

    <img src="media/image13.png" width="624" height="358" />

### Task 3: Creating and publishing a NuGet package


1.  From the main menu of **Visual Studio**, select **File | New |
    Project**. We will now create a shared assembly that will be
    published as a NuGet package so that other teams can integrate it
    and stay up to date without having to work directly with the
    project source.

2.  From the **Visual C\#** section, select the **Class Library**
    template and set the **Name** to **“PartsUnlimited.Shared”**. Click
    **OK** to create the project.

    <img src="media/image14.png" width="624" height="351" />

3.  In **Solution Explorer**, delete **Class1.cs**.

    <img src="media/image15.png" width="354" height="191" />

4.  Press **Ctrl+Shift+B** to build the project. In the next task we’ll
    use **NuGet.exe** to generate a NuGet package directly from the
    built project, but it requires the project to be built first.

5.  Return to the browser and click **Download NuGet**. Save it to the
    desktop folder for convenience.

    <img src="media/image16.png" width="624" height="360" />

6.  Return to **Visual Studio**. From **Solution Explorer**, right-click
    the **PartsUnlimited.Shared** project node and select **Open Folder
    in File Explorer**.

    <img src="media/image17.png" width="355" height="555" />

7.  Move the downloaded **nuget.exe** into this folder so that it’s a
    peer to the **.csproj** file.

    <img src="media/image18.png" width="624" height="194" />

8.  In the same **Windows Explorer** window, select **File | Open
    command prompt**.

    <img src="media/image19.png" width="245" height="149" />

9.  Execute the line below to create a **.nupkg** file from the project.
    Note that this is a quick shortcut to package the NuGet bits
    together for deployment. NuGet is very customizable and offers a lot
    of great flexibility for providing detailed information
    for consumers. You can learn more over on the [NuGet package
    creation
    page](https://docs.microsoft.com/en-us/nuget/create-packages/overview-and-workflowhttps:/docs.microsoft.com/en-us/nuget/create-packages/overview-and-workflow).

    1.  nuget.exe pack PartsUnlimited.Shared.csproj

10. NuGet builds a minimal package based on the information it is able
    to pull from the project. For example, note that the name is
    **PartsUnlimited.Shared.1.0.0.0.nupkg**. That version number was
    pulled from the assembly.

    <img src="media/image20.png" width="624" height="108" />

11. Return to **Visual Studio**. From **Solution Explorer**, open
    **Properties\\AssemblyInfo.cs**.

    <img src="media/image21.png" width="352" height="207" />

12. The **AssemblyVersion** attribute specifies the version number to
    build into the assembly. Each NuGet release requires a unique
    version number, so if we continue to use this method for creating
    packages, we will need to remember to increment this
    before building.

    <img src="media/image22.png" width="596" height="93" />

13. Return to the **command prompt** and execute the following command
    (it should be on one line). Note that you need to provide an “API
    Key”, which can be any non-empty string. We’re using
    **“VSTS”** here.

    - nuget.exe push -source "PartsUnlimitedShared" -ApiKey VSTS
        PartsUnlimited.Shared.1.0.0.0.nupkg

14. The command should succeed after a few seconds.

    <img src="media/image23.png" width="624" height="89" />

15. Return to the browser window open to TFS and **refresh** the window.
    You should now see the organization’s NuGet package is published in
    the feed.

    <img src="media/image24.png" width="624" height="243" />

### Task 4: Importing a NuGet package

1.  Open a new instance of **Visual Studio** from the taskbar. We will
    now add a reference to the **PartsUnlimited.Shared** NuGet package
    to an existing project.

2.  From the **Start Page**, open **PartsUnlimited.sln**. This is the
    primary project for the PartsUnlimited team.

    <img src="media/image25.png" width="362" height="195" />

3.  In **Solution Explorer**, right-click the **References** node under
    the **PartsUnlimitedWebsite** project and select **Manage NuGet
    Packages**.

    <img src="media/image26.png" width="349" height="309" />

4.  Click the **Browse** tab and change the **Package source** to
    **PartsUnlimitedShared**. The only package will be the one we just
    added, so click **Install** to add it to the project.

    <img src="media/image27.png" width="624" height="308" />

5.  Confirm the add by clicking **OK**.

    <img src="media/image28.png" width="434" height="239" />

6.  Press **Ctrl+Shift+B** to build the project. It should succeed. The
    NuGet package doesn’t add any value yet, but at least we know
    it’s there.

### Task 5: Updating a NuGet package

1.  Switch to the instance of **Visual Studio** that has the
    **PartsUnlimited.Shared** project open (the NuGet source project).

2.  In **Solution Explorer**, right-click the **PartsUnlimited.Shared**
    project node and select **Add | New Item**.

    <img src="media/image29.png" width="619" height="342" />

3.  Select the **Class** template and enter the **Name
    “TaxService.cs”**. Click **Add** to add the class. We can pretend
    that tax calculation will be consolidated into this shared class and
    managed centrally so that other teams can simply work with the
    NuGet package.

    <img src="media/image30.png" width="624" height="351" />

4.  Replace the code in the new file with the code below. For now it
    will just hardcode a 10% rate.

    ```
      // C\#

        namespace PartsUnlimited.Shared

        {

        public class TaxService

        {

        static public decimal CalculateTax(decimal taxable,
        string postalCode)

        {

        return taxable \* (decimal).1;

        }

        }

        }
    ```

5.  Since we’re updating the assembly (and package), return to
    **AssemblyInfo.cs** and update the **AssemblyVersion** to
    **1.1.0.0**.

    <img src="media/image31.png" width="588" height="85" />

6.  Press **Ctrl+Shift+B** to build the project.

7.  Return to the **command prompt** and execute the following line to
    repackage the NuGet package. Note that the new package will have the
    updated version number.

    - nuget.exe pack PartsUnlimited.Shared.csproj

8.  Execute the following line to publish the updated package. Note that
    the version number has changed to reflect the new package.

    - nuget.exe push -source "PartsUnlimitedShared" -ApiKey VSTS
        PartsUnlimited.Shared.1.1.0.0.nupkg

9.  Return to the browser window open to **TFS** and refresh the page.
    You will still be looking at the 1.0.0.0 version of the package, but
    you can change that by clicking the new link to **1.1.0.0**.

    <img src="media/image32.png" width="253" height="92" />

10. Switch back to the instance of **Visual Studio** open to the main
    **PartsUnlimited** project (with **PartsUnlimitedWebsite**).

11. From **Solution Explorer**, open
    **PartsUnlimitedWebsite\\Utils\\DefaultShippingTaxCalculator.cs**.

    <img src="media/image33.png" width="296" height="244" />

12. Locate the call to **CalculateTax** around line **20** and add the
    qualifier **”PartsUnlimited.Shared.TaxService”** to the beginning.
    The original code called a method internal to this class, so the
    code we’re adding to the beginning of the line is redirecting it to
    code from our NuGet assembly. However, since this project hasn’t
    updated the NuGet package yet, it’s still referencing 1.0.0.0 and
    doesn’t have these new changes available, so the code will
    not build.

    <img src="media/image34.png" width="624" height="246" />

13. In **Solution Explorer**, right-click the **References** node and
    select **Manage NuGet Packages**.

    <img src="media/image35.png" width="304" height="303" />

14. NuGet is aware of our update, so click the **Updates** tab to view
    the details. Click **Update** to bring down the new version.

    <img src="media/image36.png" width="624" height="344" />

15. Click **OK** to approve the update.

16. **Press** **F5** to build and run the site. It should work
    as expected.


