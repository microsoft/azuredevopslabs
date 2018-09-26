---
title: Feature Flag Management with LaunchDarkly and AzureDevOps
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/launchdarkly/
folder: /labs/vstsextend/launchdarkly/
---

Last updated : {{ "now" | date: "%b %d, %Y" }}

## Overview

[**LaunchDarkly**](https://launchdarkly.com/) is a continuous delivery platform that provides feature flags as a service and allows developers to iterate quickly and safely. LaunchDarkly gives you the power to separate feature rollout from code deployment and manage feature flags at scale. With the integration of LaunchDarkly with Azure DevOps services allow developers to release confidently with less risk. You can tie feature flag roll-outs to Azure DevOps work items to get complete control over who sees what when. By managing feature flags in the context of Azure DevOps release pipelines, unlock the true power of DevOps.

### What’s covered in this lab

In this lab, you will learn 

1. How to implement a very simple feature flag for an ASP.NET MVC application.
1. How to integrate LaunchDarkly with Azure DevOps 
1. How to roll-out LaunchDarkly feature flags in Azure DevOps release pipelines

### Before you begin

1. **LaunchDarkly account**: You will need a LaunchDarkly account. If you don't have one sign up for a trial account [here](https://launchdarkly.com).
1. **Azure DevOps services Organization**: You will need an Azure DevOps services account. If you don’t have one, you can sign up for one, from [here](https://www.visualstudio.com/)
1. **Microsoft Azure Account**: You will need a valid and active Azure account. If you do not have one,
You can create a [free Azure account](https://azure.microsoft.com/en-us/free/) and enjoy 12 months of free Azure services
If you are a Visual Studio Active Subscriber, you are entitled to a $50-$150 credit per month. You can refer to this [link](https://azure.microsoft.com/en-us/pricing/member-offers/msdn-benefits-details/) to find out more including how to activate and start using your monthly Azure credit.
1. Visual Studio 2017 version 15.4 or later with [.Net Core SDK](https://www.microsoft.com/net/learn/get-started/windows#windows) installed.


### Setting up the Azure DevOps project
1. Use the [Azure DevOps Demo Generator](https://azuredevopsdemogenerator.azurewebsites.net/) to provision the project on your Azure DevOps organization.

   **Azure DevOps Demo Generator** helps you create projects on your Azure DevOps Organization with pre-populated sample content that includes source code, work items, iterations, service endpoints, build and release definitions based on a template you choose.

    ![demogen](images/demogen.png)
   This URL will automatically select **LaunchDarkly** template in the demo generator. If you want to try other projects, use this URL instead -https://azuredevopsdemogenerator.azurewebsites.net/

1.  Follow the [simple walkthrough](https://docs.microsoft.com/en-us/azure/devops/demo-gen/use-vsts-demo-generator-v2?view=vsts) to know how to use the Azure DevOps Demo Generator.

## Exercise 1: Create a Feature Flag in LaunchDarkly

1. Sign in to your [LaunchDarkly](https://app.launchdarkly.com/) account. You’re then taken to the portal where you can create your first Feature Flag. Click    ![](images/createfeatureflag_button.png)

   ![](images/createfeatureflag.png)

1. In the Create a feature flag window enter **Member Portal** as feature flag name and click **Save Flag** 

    ![](images/memberportal-featureflag.png)

1. You’ve created a flag named **Member Portal** that you want to use to determine the visibility of the **Member Portal** feature in your ASP.NET MVC web app. Now your dashboard looks as below
   
   ![](images/dashboard.png)

1. To integrate LaunchDarkly into your application, you need an SDK key. If you go the **Account settings** in the portal, you see that there are two predefined environments: production and test.  You can use the production environment SDK key for this project. Copy SDK key and paste it into your notepad. You need this in the following exercise.

   ![](images/sdkkey.png)

## Exercise 2: Integrate LaunchDarkly in your Web application
   1. Make sure **Work Item management** toggle is **On** in your Azure DevOps services project as shown below. This will automatically create links for work items mentioned in a commit comment.
      
       ![](images/workitemlinking.png)

   1. Now navigate to the **Repos** within the project portal, select **Clone** and then select **Clone in Visual Studio**.

      ![](images/Clonerepo.gif)

   1. When the code opens in Visual Studio, if you are prompted to sign into Azure DevOps Services,  use the same credentials (that you used above to create the azure devops project), choose the local path to clone the repo and select **Clone**.

      ![](images/clone.png)

   1. In **Team Explorer** select **Branches** and right click **launch-darkly** branch and select **checkout**. Select **PartsUnlimited.sln** to open the project.
 
      ![](images/checkoutLaunchdarkly.gif)

   1. To integrate **LaunchDarkly** with .NET applications you need to install  NuGet package with the LaunchDarkly client. In the current project we have already added for ease of use.

        ![](images/ldclient.png)

   1. Launch the application locally once. You would be able to see **Member Portal** on right side corner of the application.

       ![](images/launchapp.png)

       ![](images/memberportal.png)


         Assume that this **Member Portal** module is a new feature and you would like to control this feature using **LaunchDarkly Feature flag** so that when you turn on the flag in LaunchDarkly then only this feature should be visible to users else not.

    1. Open **HomeController.cs** from the path **\PartsUnlimitedWebsite\Controllers** and replace the code from  following [code snippet](https://raw.githubusercontent.com/Hoyg/azuredevopslabs/launchdarkly/labs/vstsextend/launchdarkly/codesnippet/HomeController.cs).

    1. Open **AccountController.cs** from the path **\PartsUnlimitedWebsite\Controllers** and replace the code from  following [code snippet](https://raw.githubusercontent.com/Hoyg/azuredevopslabs/launchdarkly/labs/vstsextend/launchdarkly/codesnippet/AccountController.cs).

    1. Open **_Layout.chtml** from the path **PartsUnlimitedWebsite\Views\Shared** and replace line 55 ` @await Html.PartialAsync("_Login")` with the below code.

       `
       @if (ViewBag.togglevalue == true)
         {
          @await Html.PartialAsync("_Login")
         }
      `

    1. In **Home Controller.cs** and **AccountController.cs** replace **\_\_YourLaunchDarklySDKKey__** with your LaunchDarkly account SDK key which you have copied in previous exercise.

       ` static LdClient client = new LdClient("__YourLaunchDarklySDKKey__");`

         ![](images/replacesdkkey.png)

       {% include note.html content= "So what did we do? The HomeController starts with initializing a static LaunchDarkly client. And the methods to view **MemberPortal** are modified to check the Feature flag toggle in LaunchDarkly is On or Off. Finally, the _Layout.cshtml page checks the toggle value and renders the MemberPortal link if the flag is turned on." %}

    1. Now **Save** all the changes and launch the application locally. Since the **MemberPortal** flag which we created is turned off we would be not able to see **Member portal** link as below.
          ![](images/dashboard.png)
          ![](images/ldoff.png)

        So we have implemented feature flag control using LaunchDarkly. In the next exercise, we will try to Turn the feature flag on in Azure DevOps Release pipeline using the LaunchDarkly extension. To include feature flags as part of release process we need to associate this changes with the Azure DevOps work item to get complete control. 

    1. Note down the Work item id which is assigned to you as shown below. (in my case it is 2051 )

       ![](images/workassigned.gif)

        
     1. Now navigate to **Changes** tab in Team Explorer and enter comment suffixed with work item id with hash tag (ex: integrated LaunchDarkly #2051) and select **Commit and Push** to push all the changes to the Repo.
       
        ![](images/pushldchanges.gif)

## Exercise 3: Automatically rollout your LaunchDarkly feature flags during release.

1. We need a LaunchDarkly access token to integrate with Azure DevOps services. Visit the [Access Tokens](https://app.launchdarkly.com/settings/tokens) tab on the Account Settings page in LaunchDarkly. If you don't have, create one and copy access token to the clipboard.
  
   ![](images/launchdarklypat.png)

1. In Azure DevOps project navigate to Project Settings-->Build and Release-->Service connections. Select **+New service connection** and choose **LaunchDarkly**.
      ![](images/launchdarklyendpoint.png)

1. In **Add LaunchDarkly service connection** window give connection name and paste the access token which you copied in the first step and click **OK**

   ![](images/ldserviceconnection.png)

1. Open the work item assigned to you and select the radio button beside your **MemberPortal** feature flag under **LaunchDarkly** tab and save changes.

   ![](images/selectfeatureflanginWit.png)

1. Navigate to **Releases** under **Pipelines**. Select **LaunchDarkly_CD** pipeline and click **Edit pipeline**.

   ![](images/editpipeline.png)

1. Select **Stage 1** to view the tasks in the pipeline.
     
     ![](images/stage1.png)
1. You would see three tasks as shown below

      ![](images/3tasks.png)

   **Azure Resource Group Deployment**: This task helps you to deploy an Azure app service for your PartsUnlimited website using ARM template.

   **LaunchDarkly Rollout**:  This task helps to rollout/ turn on the feature flag in your LaunchDarkly subscription

   **Azure App Service Deploy**: This task deploys the PartsUnlimited web app to the app service created in the first task.

1. Select **Azure Resource Group Deployment** task and choose your Azure subscription. Then click Authorize to configure Azure service connection.

     ![](images/task1.png) 

1. Select **Launch Darkly** task and choose your LaunchDarkly service connection from the Account drop down
      
      ![](images/task2.png)
1. Select **Azure App Service Deploy** task and choose your Azure subscription. **Save** your changes.

    ![](images/task3.png)

1. Now you are done with the configuring release pipeline. Navigate to Pipelines-->Builds and Queue **LaunchDarkly-CI** build. Once the build completes successfully a release would be triggered to deploy app and rollout feature flag in launch darkly.
   
    ![](images/buildandrelease.gif)

1. Once the release completes successfully you would be able to see **MemberPortal** feature flag is turned on in LaunchDarkly dashboard.
   
    ![](images/featureflagon.png) 

1. Go to your Azure portal and browse the application deployed by release pipeline.
    
     ![](images/appservice.png) 

     You will see the **Member Portal** is enabled on your website.

      ![](images/browseapp.png) 
 

    
