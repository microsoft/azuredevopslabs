---
title: Package Management with Visual Studio Team Services
layout: page
sidebar: vsts
permalink: /labs/vsts/pul/packagemanagement/
folder: /labs/vsts/pul/packagemanagement/
---

Lab version:15.7.3

Last updated:6/17/2018

<a name="Overview"></a>
## Overview ##

Package Management is an extension that makes it easy to discover, install, and publish NuGet, npm, and Maven packages in Visual Studio Team Services. It's deeply integrated with other hubs like Build so that package management can become a seamless part of your existing workflows.

<a name="Prerequisites"></a>
### Prerequisites ###

- Visual Studio 2017

- This lab requires you to complete tasks 1 and 2 from the prerequisite instructions

<a name="Exercise1"></a>
## Exercise 1: Working with the package management service ##

<a name="Ex1Task1"></a>
### Task 1: Configuring the service ###

1. Navigate to your team project on VSTS.

1. Delivery Plans is provided as a marketplace extension. From the **Marketplace** navigation dropdown, select **Browse Marketplace**.

    ![](images/000.png)

1. Search for **"Package Management"**.

    ![](images/001.png)

1. Select the **Package Management** option.

    ![](images/002.png)

1. Click **Get**.

    ![](images/003.png)

1. Select the account to install **Package Management** into. This should be the account that contains your Parts Unlimited project. Then select the licensing option that best fits your circumstances.

    ![](images/004.png)

1. Click **Proceed to account**.

    ![](images/005.png)

1. Click the Parts Unlimited project link to return to its dashboard.

    ![](images/006.png)

<a name="Ex1Task2"></a>
### Task 2: Creating and connecting to a feed ###

1. Navigate to the **Packages** hub. This is a new option added by the Package Management extension.

    ![](images/007.png)

1. Click **New feed**. This feed will be a collection of NuGet packages available to users within the organization and will sit alongside the public NuGet feed as a peer. The scenario in this lab will focus on the workflow for using with the package management service, so the actual architectural and development decisions are purely illustrative.

    ![](images/008.png)

1. This feed will include common functionality that can be shared across projects in this organization. Set the name to **"PartsUnlimitedShared"** and click **Create**. Leave the default security options.

    ![](images/009.png)

1. Any user who wants to connect to this NuGet feed must configure their environment. Click **Connect to feed**.

    ![](images/010.png)

1. Copy the **Package source URL**. This is the only thing Visual Studio and NuGet need to start taking advantage of the new feed. Leave the dialog open in the browser.

    ![](images/011.png)

1. Launch a new instance of **Visual Studio**. Do not use the instance open from cloning the primary **Parts Unlimited** solution.

1. Select **Tools | NuGet Package Manager | Package Manager Settings**.

1. Locate the **Package Sources** section and click the **Add** button to add a new package source.

    ![](images/012.png)

1. Set the **Name** to **"PartsUnlimitedShared"** and paste the **Source** URL copied earlier. Click **Update** followed by **OK**. Visual Studio is now connected to the new feed.

    ![](images/013.png)

<a name="Ex1Task3"></a>
### Task 3: Creating and publishing a NuGet package ###

1. From the main menu of **Visual Studio**, select **File | New | Project**. We will now create a shared assembly that will be published as a NuGet package so that other teams can integrate it and stay up to date without having to work directly with the project source.

1. From the **Visual C#** section, select the **Class Library** template and set the **Name** to **"PartsUnlimited.Shared"**. Click **OK** to create the project.

    ![](images/014.png)

1. In **Solution Explorer**, delete **Class1.cs**.

    ![](images/015.png)

1. Right-click the project node and select **Properties**.

    ![](images/016.png)

1. Set the **Target framework** to **.NET Framework 4.5.1** and click **Yes** to confirm the change.

    ![](images/017.png)

1. Press **Ctrl+Shift+B** to build the project. In the next task we'll use **NuGet.exe** to generate a NuGet package directly from the built project, but it requires the project to be built first.

1. Return to the browser and click **Download NuGet + VSTS Credential Provider**. Extract the zip somewhere you can easily access.

    ![](images/018.png)

1. Return to **Visual Studio**. From **Solution Explorer**, right-click the **PartsUnlimited.Shared** project node and select **Open Folder in File Explorer**.

    ![](images/019.png)

1. Move the downloaded **nuget.exe** and **CredentialProvider.VSS.exe** files into the folder containing the **.csproj** file.

    ![](images/020.png)

1. In the same **Windows Explorer** window, select **File | Open Windows PowerShell | Open Windows PowerShell as administrator**.

    ![](images/021.png)

1. Execute the line below to create a **.nupkg** file from the project. Note that this is a quick shortcut to package the NuGet bits together for deployment. NuGet is very customizable and offers a lot of great flexibility for providing detailed information for consumers. You can learn more over on the [NuGet package creation page](https://docs.microsoft.com/en-us/nuget/create-packages/overview-and-workflowhttps:/docs.microsoft.com/en-us/nuget/create-packages/overview-and-workflow).

    ```
    ./nuget.exe pack PartsUnlimited.Shared.csproj
    ```
1. NuGet builds a minimal package based on the information it is able to pull from the project. For example, note that the name is **PartsUnlimited.Shared.1.0.0.nupkg**. That version number was pulled from the assembly.

    ![](images/022.png)

1. Return to **Visual Studio**. From **Solution Explorer**, open **Properties\AssemblyInfo.cs**.

    ![](images/023.png)

1. The **AssemblyVersion** attribute specifies the version number to build into the assembly. Each NuGet release requires a unique version number, so if we continue to use this method for creating packages, we will need to remember to increment this before building.

    ![](images/024.png)

1. Return to the **PowerShell** window and execute the following command (it should be on one line). Note that you need to provide an "API Key", which can be any non-empty string. We're using **"VSTS"** here. Log in using your VSTS credentials when asked.

    ```
    ./nuget.exe push -source "PartsUnlimitedShared" -ApiKey VSTS PartsUnlimited.Shared.1.0.0.nupkg
    ```
1. The command should succeed after a few seconds.

    ![](images/025.png)

1. Return to the browser window open to VSTS and **refresh** the window. You should now see the organization's NuGet package is published in the feed. Click it to view the details.

    ![](images/026.png)

1. The details have been imported and are now ready for others to consume.

    ![](images/027.png)

<a name="Ex1Task4"></a>
### Task 4: Importing a NuGet package ###

1. Switch to the instance of **Visual Studio** that has the full **Parts Unlimited** solution open.

1. In **Solution Explorer**, right-click the **References** node under the **PartsUnlimitedWebsite** project and select **Manage NuGet Packages**.

    ![](images/028.png)

1. Click the **Browse** tab and change the **Package source** to **PartsUnlimitedShared**. The only package will be the one we just added, so click **Install** to add it to the project.

    ![](images/029.png)

1. If asked, confirm the add by clicking **OK**.

    ![](images/030.png)

1. Press **Ctrl+Shift+B** to build the project. It should succeed. The NuGet package doesn't add any value yet, but at least we know it's there.

<a name="Ex1Task5"></a>
### Task 5: Updating a NuGet package ###

1. Switch to the instance of **Visual Studio** that has the **PartsUnlimited.Shared** project open (the NuGet source project).

1. In **Solution Explorer**, right-click the **PartsUnlimited.Shared** project node and select **Add | New Item**.

    ![](images/031.png)

1. Select the **Class** template and enter the **Name "TaxService.cs"**. Click **Add** to add the class. We can pretend that tax calculation will be consolidated into this shared class and managed centrally so that other teams can simply work with the NuGet package.

    ![](images/032.png)

1. Replace the code in the new file with the code below. For now it will just hardcode a 10% rate.

    ```c#
    namespace PartsUnlimited.Shared
    {
        public class TaxService
        {
            static public decimal CalculateTax(decimal taxable, string postalCode)
            {
                return taxable * (decimal).1;
            }
        }
    }
    ```
1. Since we're updating the assembly (and package), return to **AssemblyInfo.cs** and update the **AssemblyVersion** to **1.1.0.0**.

    ![](images/033.png)

1. Press **Ctrl+Shift+B** to build the project.

1. Return to the **PowerShell** window and execute the following line to repackage the NuGet package. Note that the new package will have the updated version number.

    ```
    ./nuget.exe pack PartsUnlimited.Shared.csproj
    ```
1. Execute the following line to publish the updated package. Note that the version number has changed to reflect the new package.

    ```
    ./nuget.exe push -source "PartsUnlimitedShared" -ApiKey VSTS PartsUnlimited.Shared.1.1.0.nupkg
    ```
1. Return to the browser window open to **VSTS** and refresh the page. You will still be looking at the 1.0.0 version of the package, but you can change that by selecting the **Versions** tab and selecting **1.1.0**.

    ![](images/034.png)

1. Switch back to the instance of **Visual Studio** open to the main **PartsUnlimited** project (with **PartsUnlimitedWebsite**).

1. From **Solution Explorer**, open **PartsUnlimitedWebsite\Utils\DefaultShippingTaxCalculator.cs**.

    ![](images/035.png)

1. Locate the call to **CalculateTax** around line **20** and add the qualifier **"PartsUnlimited.Shared.TaxService."** to the beginning. The original code called a method internal to this class, so the code we're adding to the beginning of the line is redirecting it to code from our NuGet assembly. However, since this project hasn't updated the NuGet package yet, it's still referencing 1.0.0.0 and doesn't have these new changes available, so the code will not build.

    ![](images/036.png)

1. In **Solution Explorer**, right-click the **References** node and select **Manage NuGet Packages**.

    ![](images/037.png)

1. NuGet is aware of our update, so click the **Updates** tab to view the details. Click **Update** to bring down the new version. If the **Updates** tab hasn't yet updated, you can still update the package from the **Browse** tab. Note that there may be many NuGet updates available, but you should only need to update **PartsUnlimited.Shared**.

    ![](images/038.png)

1. If asked, click **OK** to approve the update.

1. Press **F5** to build and run the site. It should work as expected.

