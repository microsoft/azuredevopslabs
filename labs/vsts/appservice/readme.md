---
title: Deploy an ASP.NET Web App in Azure App Service
layout: page
sidebar: vsts
permalink: /labs/vsts/appservice/
folder: /labs/vsts/appservice/
---

Last updated : {{ "now" | date: "%b %d, %Y" }}.

## Overview

[App
Service](https://docs.microsoft.com/en-us/azure/app-service/app-service-value-prop-what-is)
is a platform-as-a-service (PaaS) offering of Microsoft Azure. Create
web and mobile apps for any platform or device. Integrate your apps with
SaaS solutions, connect with on-premises applications, and automate your
business processes.

**The following illustration shows the completed application:**

<img src="media/image1.png" width="501" height="328" />

## Pre-Requisites

1.  Visual Studio 2015 Update 3 (download from
    [here](https://www.visualstudio.com/downloads/))

2.  Active Azure Account

3.  Azure SDK for VS 2015 (download from
    [here](https://azure.microsoft.com/en-in/downloads/))

4.  Microsoft Web Deploy (download from
    [here](https://www.microsoft.com/en-us/download/details.aspx?id=43717))

Since we already have the source code in the [repo](https://github.com/hsachinraj/DevOps-Immersion-Labs/tree/master/source) we could use the same
for our Azure App Service deployment. You can also create your own app
and try deploying the same.

1. Load the “01\_Demos\_ASPNET5.sln” from your Visual Studio and wait until the package restoration is complete. If any issues found, try the below workarounds-

    1. Clean the solution and try to rebuild, which should work fine. Also
    make sure you have connected to the internet while restoring the
    packages as these would get downloaded over the internet

    2. Close your Visual Studio and try to clear the temp of your system
    and reload the solution, which should work fine.

    > <b>Note</b>: Make sure you have the dev environment setup properly as
    > discussed in the pre-requisites section of this lab or you may end up
    > with issues.
    >
    > Upon loading the solution, do a local build to make sure that your
    > application works fine without any issues and you should see your app
    > running locally.

    <img src="media/image2.png" width="514" height="289" />

2. Right click on “MyHealth.Web” and select “publish”. You will see a new
    window automatically open to indicate that the resources will be created
    in Azure, which will host all application resources. Fill in the
    required information and make sure to change the type to Web App.

    <img src="media/image3.png" width="624" height="568" />

3. Select a publish target to “Microsoft Azure App Service” since we would
    be publishing a WebApp to Azure App Service.

    <img src="media/image4.png" width="427" height="336" />

4. Upon selecting the publish target to Microsoft Azure App Service, you
   will get a new window to fill in the information for publishing. On the
   top right corner, you can manage your Azure accounts. Select one of the
   account that you wish to host against and click on “New” to create a new
   Resource group.

      <img src="media/image5.png" width="536" height="401" />

5. Log into Azure portal from [here](https://portal.azure.com)
      
      <img src="media/1.png" width="457" height="269" />
      
6. Upon login you should see there are no resource group created at the moment in your resource groups.

      <img src="media/image6.png" width="457" height="269" />

7. From your Visual Studio, upon clicking “New”, you will get another window to configure the App
    Service Plan.

    <img src="media/image7.png" width="318" height="356" />

8. Upon filling out the required information, click on “Services” to add a
    new service.

    <img src="media/image8.png" width="476" height="353" />

9. You will get a new window when clicked on services. Your web application
    will have a SQL database in the future, so fill out the required
    information to configure SQL Server as shown-

    <img src="media/image9.png" width="316" height="355" />

10. Configure SQL database as shown-

    <img src="media/image10.png" width="346" height="392" />

11. Finally, you should see the services upon configured-

    <img src="media/image11.png" width="420" height="315" />

12. Click on create so that the deployment starts by spinning up all those
    resources on Azure. You can see at the bottom of the window which shows
    the status of your deployments.

    <img src="media/image12.png" width="444" height="332" />

13. Once successfully created, you should see the resources in your Visual
    Studio “Server Explorer”.

    <img src="media/image13.png" width="471" height="338" />

14. With the previous steps, you generated the Azure resources for your
    deployments.

15. In your solution explorer, right click on the MyHealth.Web and click
 Publish. You will see Publish Web dialog box. The wizard shows you a
 list of available Publish Profiles. If you select Microsoft Azure App
 Service, you can see a list of available subscriptions and the resource
 groups that were previously created. Select the resource group that you
 created to deploy the web application.

    <img src="media/image14.png" width="596" height="445" />

16. After you select the resource group, the page that opens shows the
 connection information. The default parameters will populate the fields.
 You can modify these fields if required or leave it as it is. To test
 that the connection works correctly, click on Validate Connection.

    <img src="media/image15.png" width="545" height="429" />

17. In the **Settings** page, you can configure the deployment type
 depending on whether you require in a Debug/Release mode. You can check
 the box for using default connection string at run time.

    <img src="media/image16.png" width="553" height="438" />

18. On the last page, Preview, you can determine the changes that affect the
 Azure environment.

    <img src="media/image17.png" width="474" height="374" />

19. At last, click Publish. The **Output** window displays information about
 the deployment. When it’s completed, it displays a successful message.

    <img src="media/image18.png" width="624" height="331" />

20. You can see the website in the browser that will open.

    <img src="media/image19.png" width="624" height="335" />

21. When you go back to your Azure portal and see, you have all the
 resources that was created and published from your Visual Studio.

    <img src="media/image20.png" width="376" height="270" />

22. Once the app is running fine, you can verify by doing some changes to
 the UI. So that you make sure that your app is actually running in Azure
 App Service. To open remote files, go to your server explorer from
 Visual Studio.

23. Login to your Azure from Server Explorer. Expand the node Azure &gt; App
 Service &gt; YOUR RESOURCE GROUP &gt; YOUR WEBAPP &gt; Files &gt; Views
 &gt; Index.cshtml and replace the line as below

     `<li><a asp-controller="Account" asp-action="Login">Secret area</a></li> with <li><a asp-controller="Account" asp-action="Login">Secret area</a></li>`

24. Save the changes and refresh the browser. You should see the changes
 reflecting in the site now.

    <img src="media/image21.png" width="624" height="333" />

25. We can also remote debug our application from Azure within our Visual Studio.

    Put a breakpoint in your code and Right click and select Publish. You should see the new window as shown-

    <img src="media/image22.png" width="465" height="349" />

26. Publish the debug files so that you can show remote debugging-

    <img src="media/image23.png" width="478" height="379" />

27. Click on Publish. From your Visual Studio, go to **Debug** &gt; click
 **Attach to Process,** enter the azure websites URL along with its port
 and select **dnx.exe** process

    <img src="media/image24.png" width="465" height="352" />

    <img src="media/image25.png" width="459" height="311" />

28. Finally, from your Server Explorer &gt; App Service node, attach the
 debugger. Refresh the browser and you would be hitting your breakpoint
 wherever you would have set. And that’s how you gonna remote debug
 ASP.NET apps on Azure. To learn more about remote debugging, see [Remote
 Debug ASP .NET Core Apps on
 Azure](https://blogs.msdn.microsoft.com/webdev/2016/03/21/remote-debug-aspnet-core-on-azure/)

    <img src="media/image26.png" width="501" height="353" />
