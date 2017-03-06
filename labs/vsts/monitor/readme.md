---
title: Monitoring Applications using Application Insights
layout: page
sidebar: vsts
permalink: /labs/vsts/monitor/
folder: /labs/vsts/monitor/
---

## Overview

<a href="https://docs.microsoft.com/en-us/azure/application-insights/">Application Insights</a> comes as part of Visual Studio. You get automatic instrumentation for ASP.NET developers and vital application telemetry data right out of the box; including usage, exceptions, requests, performance, and logs.

Monitor web apps—whether written in Java, Ruby, Python, PHP, Node.JS, or other languages—using open source SDKs. Install the Status Monitor on your existing Azure App Services and virtual machines through the Azure portal to get performance monitoring without needing to update and redeploy your application.

Visual Studio Application Insights is an extensible analytics service that monitors your live web application. With it you can detect and diagnose performance issues, and understand what users actually do with your app. It's designed for developers, to help you continuously improve performance and usability. It works for apps on a wide variety of platforms including .NET, Node.js and J2EE, hosted on-premises or in the cloud.

It provides benefits as:

- Exceptions and performance diagnostics.
- Interactive data analysis.
- Azure diagnostics.
- Proactive detection.

## Pre-requisites

In order to complete this lab you will need-

- **Visual Studio Team Services account**. If you don't have one, you can create from <a href="https://www.visualstudio.com/">here</a>

- **Visual Studio 2017** or higher version

- You can use the **[VSTS Demo Data generator](http://vstsdemogenerator.azurewebsites.net/Environment/Create)** to provison a project with pre-defined data on to your Visual Studio Team Services account. Please use the ***My Health Clinic*** template to follow the hands-on-labs.

- If you are not using the VSTS Demo Data Generator, you can clone the code from here


## Exercise 1: Configure Application Insights

In this lab we have the existing **01_Demos_ASPNET5** .NET Core application, when creating all the infrastructure for the labs, we will need the newly created **Instrumentation key** to be configured in this project so Application Insights can work. 

1. Open Visual Studio 2017.
    
    <img src="images/1.png" width="624"/>

2. Open **01_Demos_ASPNET5** solution. Under **MyHealth.Web** project locate the **appsettings.json** file.  

    <img src="images/2.png" />

    <img src="images/3.png" width="624"/>

3. Locate this line from that file.
  
    ```
    "InstrumentationKey": "YOUR_INSTRUMENTATION_KEY"
    ```

4. Substitute the text **YOUR_INSTRUMENTATION_KEY** with the key of your existing Application Insights service.

    <img src="images/4.png" width="624"/>

5. Application Insights comes in the form of a Nuget package. Review the **project.json** file of the web project and look for the Application Insights package added.

    <img src="images/5.png" width="624"/>

6. Open the file **Startup.cs**.

    <img src="images/6.png" />

    > In this file we give the startup options for the website, we need to configure Application Insights to read the configuration.  
    > Unlike the setup for other Application Insights SDKs, adding the SDK doesn’t automatically configure a range of modules to collect different kinds of telemetry. We’re going to add the modules for Telemetry and Exception so we need to do a couple of modifications to the **Startup.cs**

    <img src="images/7.png" />

7. Locate the method **ConfigureServices** and check the line **services.AddApplicationInsightsTelemetry(Configuration);**. 

    > This will load the configuration for Application Insights from the configuration file for the site.
    
    <img src="images/8.png" />

8. Now locate the method **Configure** and check these lines:
    
    ```
    * app.UseApplicationInsightsRequestTelemetry();
    * app.UseApplicationInsightsExceptionTelemetry();
    ```

    > With these two lines we are configuring the application to send Telemetry information as well as Exception information to the configured Application Insights.

    <img src="images/9.png" />
   
9. Locate the file **_Layout.cshtml** inside the **Views \| Shared** folder in the web application and open it.

    > We need to configure also the client-side reporting of Application Insights telemetry, which will allow us to have telemetry data of what is happening at the client side of our web application.  
    > This **_Layout.cshtml** page in ASP.NET is the base page for all the rest of the pages for the application, so adding this code here will add the code in the rest of the pages of the application at runtime.

    <img src="images/10.png" />

    <img src="images/11.png" />    

10. Look at the first line **@inject Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration TelemetryConfiguration**.
    This injects the configuration part of Application Insights to be available for the client-side scripting.

    <img src="images/12.png" />

11. Now look at the line **@Html.ApplicationInsightsJavaScript(TelemetryConfiguration)**.
    This will add the needed Javascript code in the page so Application Insights client-side telemetry sends information about client-side execution.

    <img src="images/13.png" />

## Exercise 2: Viewing Telemetry

Now that we have configured the application to send telemetry data to Application Insights, let's review how to send the date and see the telemetry from Visual Studio and the Azure Portal.

1. Launch the application from Visual Studio and navigate through the application.

   <img src="images/14.png" width="624"/>

2. Stop the application from Visual Studio. Even when debugging the application locally it will start sending information to Application Insights. Now we will review the information captured by Application Insights.

3. Right click on the project **MyHealth.Web** in the **Solution Explorer** and select **Application Insights \| Search Debug Session Telemetry**.

   <img src="images/15.png" width="624"/>

   >This view shows telemetry generated in the server side of your app. Experiment with the filters, and click any event to see more detail.

   <img src="images/16.png" width="624"/>

4. Right click again on the project **MyHealth.Web** in the **Solution Explorer** and select **Application Insights \| Open Application Insights Portal**.

   <img src="images/17.png" />

   >The portal opens on a view of the telemetry from your app.

   <img src="images/18.png" width="624"/>

5. Click on **Server response time**.

   <img src="images/19.png" />

   >This opens the azure *blade* with all the information about the server response time of all the calls which have ocurred to the application, and its times. So we can detect for example bottlenecks in our application in particular pages.

   <img src="images/20.png" />

6. Click on **Page View Load Time**.

   <img src="images/21.png" />

   >We have a lot of other metrics avaliable, like **Page view load time** which measures times from client side informing how long the pages take to load in the client side.

   <img src="images/22.png" />

   >Click again, in this new *blade* in **Page View Load Time** in the upper part, you can continue drilling down through all the information in Application Insights. 

   <img src="images/23.png" width="624"/>

## Exercise 3: Adding Application Insights to New Web Application

Let's create a new web application and review how can we add Application Insights from the beginning.

1. Open Visual Studio. Select **File \| New Project**.

   <img src="images/24.png" width="624"/>

2. Select **Visual C# \| .NET Core \| ASP.NET Core Web Application**, ensure to mark the checkbox **Add Application Insights to Project**.

   <img src="images/25.png" width="624"/>

   >In this step we are adding Application Insights to the project, if you want to review default values or make any change on them, click on **Configure Settings**

   <img src="images/26.png" />

3. Click **Ok** on the next screen.

   <img src="images/27.png" width="624"/>

4. Open **appsetings.json** file and check the **Instrumentation Key** has been added.

   <img src="images/28.png" />

   >As we saw in this lab configuring Application Insights, we have now the key already added from the beginning. The **Nuget package, Startup.cs file** and **_layout.cshtml files** has been modified to include Application Insights.

5. Open **Startup.cs** file, as you also see the lines for Application Insights configuration has already been added automatically.

   <img src="images/29.png" width="624"/>

6. Open **_Layout.cshtml** and check the particular line for client-side Javascript telemetry.

   <img src="images/30.png" width="624"/>

7. Open **project.json** file and check the Application Insights package has also been added.

   <img src="images/31.png" />

From this point we can also run the application, and see telemetry data as we did at the beginning of this same lab.
