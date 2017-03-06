---
title: Continuous Integration using Visual Studio Team Services
layout: page
sidebar: vsts
permalink: /labs/vsts/continuousintegration/
folder: /labs/vsts/continuousintegration/
---

## Overview

Visual Studio Team Services simplifies <a href="https://www.visualstudio.com/en-us/docs/build/overview/">Continuous integration</a> for your applications regardless of what platform you are targeting, or what language you are using.

- Build on Linux, Mac, and Windows.

- Use multi-platform build agents for Android, iOS, Java, .NET, and other applications.

- Seamless integration with work, test, code, build, and release.

- Track your builds with real-time build status.

When many developers collaborate on complex software projects, it can be a long and unpredictable process to integrate different parts of code together. However, you can make this process more efficient and more reliable if you build and deploy your project continuously.

Continuous integration (CI) is the process of integrating your code into a shared repository as frequently as possible. During code integration, a build break or a test failure can inform you, in a timely manner, of an error in your code.

## Pre-requisites

In order to complete this lab you will need- 

- **Visual Studio Team Services account**. If you don't have one, you can create from <a href="https://www.visualstudio.com/">here</a>

- **Visual Studio 2017** or higher version

- You can use the **[VSTS Demo Data generator](http://vstsdemogenerator.azurewebsites.net/Environment/Create)** to provison a project with pre-defined data on to your Visual Studio Team Services account. Please use the ***My Health Clinic*** template to follow the hands-on-labs.

- If you are not using the VSTS Demo Data Generator, you can clone the code from here


## Exercise 1: Build ASP.NET CORE

ASP.NET Core is a lean and composable framework for building web and cloud applications. Here we'll show you how to automatically build the **HealthClinic ASP.NET Core** application.

### Task1 : Creating New Build Definition

1. From your VSTS account overview page, select your team project. 

2. Click **Build and Release** tab and select **Builds**.

   <img src="images/1.png" width="624"/>

3. Click on **New** to create build definition. You can enable **New Build Editor**.

   <img src="images/2.png" width="624"/>

4. Select the **Empty** template to start a new build definition from scratch.
   If a template is relevant to your scenario, select to automatically add some steps and apply typical settings.
   If there's no template for your scenario, select **Empty Process** and then add the build steps you need.

   <img src="images/3.png" width="624"/>

5. Specify the code you want to build by selecting **Get Sources**. You can fetch your code from **GitHub, SVN** etc. Since we have our code in this project, we would select **This Project**.
   You can also specify as to which branch you want to build. Select **master** branch as we would have stable code.

   <img src="images/4.png" width="624"/>


### Task 2: Adding Build Tasks

1. Click **Add Task**.

    <img src="images/5.png" width="624"/>

2. Add a **Command Line** task to restore the project dependencies from the **Utility** section.
   
    <img src="images/6.png" width="624"/>
   
3. Add **npm** task from the **Package** section.

    <img src="images/7.png" width="624"/>

4. Add **gulp** task from the **Build** section.

    <img src="images/8.png" width="624"/>

5. Add **Visual Studio Build** task from the **Build** section.

    <img src="images/9.png" width="624"/>
    
6. Select the **Command Line** task and update its properties:
    - Tool: dotnet
    - Arguments: restore

    > **dotnet** is a general driver for running the .NET core command-line commands.

    > **dotnet restore** command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project.json file. By default, the restoration of dependencies and tools are done in parallel.

     <img src="images/10.png" width="624"/>
    

7. Select the **npm** task and update its properties:
    - Commands: install
    - working folder: src/MyHealth.Web
    
    > This command installs all the  packages described by the package.json file, and any packages that it depends on.
    > It also installs the dependencies in the local **node_modules** folder.

    <img src="images/11.png" width="624"/>

8. Select the **gulp** task and update its properties:
    - Gulp File Path: src/MyHealth.Web/gulpfile.js
    - Advanced>Working Directory: src/MyHealth.Web

    > **Gulp** is a task runner that solves the problem of repetition. It's often used to do front-end tasks like using pre-processors like Sass or LESS, optimizing assets like CSS, JavaScript, and images, Reloading the browser automatically whenever a file is saved.

     <img src="images/12.png" width="624"/>     

9. Select the **Visual Studio Build** task and update its properties:
    - Solution: 01_Demos_ASPNET5.sln

    <img src="images/13.png" width="624"/>     

10. Click **Save.**

    <img src="images/14.png" width="624"/>

    <img src="images/15.png" width="624"/>
         

11. You can queue builds automatically or manually. Now, you will run it manually.

12. Click **Queue Build.**
    
    <img src="images/16.png" width="624"/>

    <img src="images/17.png" width="624"/>

13. A new build is running.

    <img src="images/18.png" width="624"/>

## Exercise 2: Replicating Build Definitions

If your definition has a pattern that you want to replicate in other definitions, clone it or create a template.

1. Go to your **Build** tab and select the definition that you want to clone and click **clone**.

   <img src="images/19.png" width="624"/>

2. You should see a cloned definiton once done from your list of builds with the name **clone.**

   <img src="images/20.png" width="624"/>

3. Click on **New** build definition to create a new build definition from our cloned template.

   
## Exercise 3: Defining process

1. Go to your **Build** from your VSTS account.

2. Edit the build definition and click on **Options**.

   <img src="images/21.png" width="624"/>

   > **Description:** If you specify a description here, it is shown near the name of the build definition when you select it in the Build area of your team project.

   > **Build number format:** If you leave it blank, your completed build is given a unique integer as its name. But you can give completed builds much more useful names that are meaningful to your team. You can use a combination of tokens, variables, and underscore characters.

   > **Default agent queue:** Select the queue that's attached to the pool that contains the agents you want to run this definition.
   To build your code or deploy your software you need at least one agent, and as you add more code and people, you'll eventually need more.

   > **Build job authorization scope:** Specify the authorization scope for a build job.
    **Project Collection**, if the build needs access to multiple team projects.

   > **Demands:** Use demands to make sure that the capabilities your build needs are present on the build agents that run it. Demands are asserted automatically by build steps or manually by you.

3. Click on **Triggers**. On the Triggers tab you specify the events that will trigger the build. You can use the same build definition for both CI and Scheduled builds.

   > **Continuous integration (CI):** Select this trigger if you want the build to run whenever someone checks in code.

   > **Batch changes:** Select this check box if you have a lot of team members uploading changes often and you want to reduce the number of builds you are running. If you select this option, when a build is running, the system waits until the build is completed and then queues another build of all changes that have not yet been built. If you are using batched changes, you can also specify a maximum number of concurrent builds per branch.

   > **Branch filters:** You can specify the branches where you want to trigger builds. You can use wildcard characters.

   > **Path filters:** You can also specify path filters to reduce the set of files that you want to trigger a build.

   <img src="images/22.png" width="624"/>

4. Click on **Scheduled**. Select the days and time when you want to run the build and configure accordingly.

   <img src="images/23.png" width="624"/>

5. Click on the **Variables** tab. We can add new user-defined variables.

   > - BuildConfiguration: debug
   > - BuildPlatform: any cpu
   > - WebDir: src/MyHealth.Web
   > **Secret Variables:** We recommend that you make the variable **Secret** if it contains a password, keys, or some other kind of data that you need to avoid exposing.

   <img src="images/24.png" width="624"/>

6. Now, modify the build steps to use the new variables. Click on the **Visual Studio Build** task from your build definition.
   Update the task to use the new variables.

   <img src="images/25.png" width="624"/>

7. Click on the **gulp** task and use the **WebDir** variable in the working directory property.

   <img src="images/26.png" width="624"/>

8. At the beginning of the build process, the build agent downloads the files from your remote repository into a local sources directory. After you select the repository, you can specify options for how the files are downloaded.

   > You can build code from different repos: Git, GitHub, Subversion and External Git.
   > - **Repository:** Select a repository in your team project.
   > - **Default branch:** Select the branch that you want to be the default when you manually queue this build.
   
   <img src="images/27.png" width="624"/>

9. Click on the **Retention** tab. In most cases you don't need completed builds longer than a certain number of days. Your retention policies automatically delete old completed builds to minimize clutter.
   You modify these policies on the Retention tab of your build definition.

## Exercise 4: Working with Artifacts

An artifact is a deployable component of your application. Visual Studio Team Services has the ability to explicitly manage the content of artifacts during a build. 

1.  Go to your **Build** Definition and edit. Click on **Add Task** ti add few tasks.

2.  Add **Command Line** task from the **Utility** section and update its properties.
    - Tool: dotnet
    - Arguments: publish -c $(BuildConfiguration) $(WebDir)/project.json

   <img src="images/32.png" width="624"/>

3. Add **Archive Files** task from the **Utility** section and update its properties to zip the project output.
    - Root Folder: $(Build.SourcesDirectory)\$(WebDir)\bin\$(BuildConfiguration)\netcoreapp1.0\publish
    - Prefix root folder name to archive paths: Uncheck this option.
    - Archive File to create: $(Build.SourcesDirectory)\$(WebDir)\bin\webapp.zip

   <img src="images/28.png" width="624"/>

   <img src="images/31.png" width="624"/>

4. Add **Publish Build Artifacts** task from the **Utility** section and update its properties to publish the web project.
    - Path to publish: $(Build.SourcesDirectory)\$(WebDir)\bin\webapp.zip
    - Artifact Name: WebApp
    - Artifact Type: Server
   
   <img src="images/29.png" width="624"/>

   <img src="images/30.png" width="624"/>

5. Click **Save and Queue** build. 

6. You should see the **Build Summary** once completed.

   <img src="images/33.png" width="624"/>

7. Click on **artifacts** to view the packaged content.

   <img src="images/34.png" width="624"/>
   
   <img src="images/35.png" />

8. The webapp artifact contains the application files ready to be deployed.
   

## Exercise 5: Running Tests with Build

Make sure your app still works after every commit and build using VSTS. Find problems earlier by running tests automatically with each build. When your build is done, review your test results to start resolving the problems that you find.

Your build definition includes a test task that runs unit tests. For example, if you're building a Visual Studio solution in Team Services, your build definition includes a Visual Studio Test task. After your build starts, this task automatically runs all the unit tests in your solution on the same build machine.

>**Note**- HealthClinic uses ASP.NET core so you need to use the dotnet tool to run the tests.

<img src="images/36.png" />

<img src="images/37.png" />

1. Go to your build definition and edit. 

2. Add **Command Line** task from the **Utility** section and update its properties.
    - Tool: dotnet
    - Arguments: test -xml TestResults.xml - the test command is defined in the unit test project.
    - Working Folder: 

    > The dotnet test command is used to execute unit tests in a given project. Unit tests are class library projects that have dependencies on the unit test framework (for example, NUnit or xUnit) and the dotnet test runner for that unit testing framework. These are packaged as NuGet packages and    are restored as ordinary dependencies for the project.
        
   <img src="images/38.png" width="624"/>

   > Test projects also need to specify a test runner property in project.json using the "testRunner" node. This value should contain the name of the unit test framework.

   <img src="images/39.png" width="624"/>

3. Add **Publish Test Result** task from the **Test** section and update its properties.
    - Test Result Format: XUnit
    - Test Results Files: **/*TestResults.xml
    - Always run: true - to be sure that the results are published when the unit tests fail.

   <img src="images/40.png" width="624"/>

4. Save the build and queue.

5. You should see the build summary showing along with Test results.

   <img src="images/41.png" width="624"/> 

6. Click on **Test** to view detailed summary of Test Results.

   <img src="images/42.png" width="624"/>

7. You can also fail tests. Go to your Visual Studio. Expand **MyHealth.API.IntegrationTests** project. 

8. Click on **GetDoctors.cs** and modify the assert of the unit test **Administrator_Can_GetDoctors**.

   <img src="images/43.png" width="624"/>

9. Commit and Sync the changes.

   <img src="images/44.png" />

10. Review the summary for your test run results, including a comparison between the current build and the last build.

    <img src="images/45.png" width="624"/>

    <img src="images/46.png" width="624"/>

    <img src="images/47.png"/>

11. You can also organize your test results using the group and outcome lists. You'll find changes in new, failed, and passed tests, how long these tests took to run, how long these tests have been failing, and more.
    
    <img src="images/48.png"/>

    <img src="images/49.png"/>

12. To start debugging a failed test, open it and review the resulting error and stack trace.

    <img src="images/50.png"/>

13. Revert back the changes done and commit so that you have a clean build summary with all passed tests.
   





   
