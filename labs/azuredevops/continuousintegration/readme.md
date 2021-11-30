---
title: Enabling Continuous Integration with Azure Pipelines
layout: page
sidebar: vsts
permalink: /labs/azuredevops/continuousintegration/
folder: /labs/azuredevops/continuousintegration/
version: Lab version - 1.37.1
updated: Last updated - 05/11/2020
redirect_from: "/labs/vsts/continuousintegration/index.htm"
---
<div class="rw-ui-container"></div>
<a name="Overview"></a>

## Overview ##

In this lab, you will learn how to configure continuous integration (CI) and continuous deployment (CD) for your applications using Build and Release in Azure Pipelines. This scriptable CI/CD system is both web-based and cross-platform, while also providing a modern interface for visualizing sophisticated workflows. Although we won't demonstrate all of the cross-platform possibilities in this lab, it is important to point out that you can also build for iOS, Android, Java (using Ant, Maven, or Gradle) and Linux.


<div class="bg-slap"><img src="./images/mslearn.png" class="img-icon-cloud" alt="MS teams" style="
    width: 48px; height: 48px;">Want additional learning? Check out the <a href="https://docs.microsoft.com/en-us/learn/modules/create-a-build-pipeline/" target="_blank"><b><u> Create a build pipeline with Azure Pipelines </u></b></a> module on Microsoft Learn.</div>


<a name="Prerequisites"></a>
### Prerequisites ###

- This lab requires you to complete task 1 from the <a href="../prereq/">prerequisite</a> instructions.

<a name="Exercise1"></a>
## Exercise 1: Introduction to Azure DevOps Build ##

<a name="Ex1Task1"></a>
### Task 1: Creating a basic build pipeline from a template ###

1. Navigate to your team project on Azure DevOps.

1. Navigate to **Pipelines \| Pipelines**.

    ![](images/000.png)

1. Open (click) the existing **PartsUnlimitedE2E** pipeline (which was created by the demo generator tool) and click on **Edit**

    ![](images/edit-pipeline.png)

1. Not to have two pipelines triggered later in the lab, disable the CI trigger for the template created pipeline (uncheck) and **Save**.

    ![](images/disable-ci.png)
 
1. Navigate back to **Pipelines \| Pipelines** and click **New pipeline** to create a new build pipeline.

    ![](images/001.png)

1. The default option for build pipelines involves using YAML to define the process. If you are interested in that, please check out that lab. For this lab, click **use the classic editor**.

    ![](images/002.png)

1. The first thing you'll need to do is to configure the source repository. Every major platform is available, but the default options are all we need here. This build will use the **master** branch of the **PartsUnlimited** repo. Leave the defaults and click **Continue**.

    ![](images/003.png)

1. Locate the **ASP.NET** template and click **Apply** to apply this template to the build definition. Note that there are many options that should cover all of our mainstream scenarios. For our purposes here, we'll just build the project using the baseline ASP.NET template.

    ![](images/template.png)

1. The process for this build pipeline is easy to follow. After getting the source, Azure DevOps will use NuGet to restore any dependent packages. Then, the project will be built and tested. The results will then be published to the configured target.

    ![](images/005.png)

1. Select the **Variables** tab. Here you can configure special parameters to be used during the build, such as the configuration or platform.

    ![](images/006.png)

1. Select the **Triggers** tab. These triggers enable you to automatically invoke builds on a schedule, when another build completes, or when changes are made to the source. Check **Enable continuous integration** so that this build will get invoked whenever source changes are committed.

    ![](images/007.png)

1. Select the **Options** tab. This section includes a wide variety of options related to the build workflow. Note that you'll generally configure options for specific build tasks on the configuration views of the tasks themselves.

    ![](images/008.png)


1. Select the **History** tab. There's nothing here yet, but it will show a history of changes you make to the build definition.

    ![](images/011.png)

1. Select **Save & Queue \| Save & Queue** to save and queue a new build.

    ![](images/012.png)

1. Accept the default options by clicking **Save and run**.

    ![](images/013.png)

<a name="Ex1Task2"></a>
### Task 2: Tracking and reviewing a build ###

1. Depending on load, the build may need to wait in the queue for a moment.

    ![](images/014.png)

1. Once the build begins, you'll be able to track the console output per task. Click **Agent job 1**.

    ![](images/015.png)

1. If you want to review an earlier task, you can scroll the right pane to review its logs.

    ![](images/016.png)

1. The build should eventually succeed. You can return to the summary view by clicking the back button.

    ![](images/017.png)

1. The summary view provides overview details about the build, including details about commits, tests, and artifacts.

    ![](images/018.png)

1. Select the **Tests** tab to review test performance for this build. Note that you also have easy access to the pipeline editor, the ability to queue a new build, and download the artifacts of this build.

    ![](images/019.png)

<a name="Ex1Task3"></a>
### Task 3: Invoking a continuous integration build ###

1. The build was configured earlier to support continuous integration. Navigate to the code for this project using **Repos \| Files**.

    ![](images/020.png)

1. Open the file at **PartsUnlimited-aspnet45/src/PartsUnlimitedWebsite/Views/Home/Index.cshtml**.

    ![](images/021.png)

1. Click **Edit**.

    ![](images/edit.png)

1. Make a minor cosmetic change, such as by tweaking the title of the document. Click **Commit**.

    ![](images/023.png)

1. Accept the default commit details and click **Commit**.

    ![](images/024.png)

1. A build should be underway shortly. Select **Pipelines \| Pipelines** to see if it's in progress.

    ![](images/025.png)

1. You should now see that a new build (note the **.2**) is in progress and that it was triggered by your change. Click the build to track it. Note that it may be queued behind another build pipeline configured for continuous integration.

    ![](images/026.png)

1. This build should run and succeed just like the previous build.

    ![](images/027.png)

