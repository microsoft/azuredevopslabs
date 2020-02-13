---
title: Managing Technical Debt with Azure DevOps and SonarCloud
layout: page
sidebar: vsts
permalink: /labs/azuredevops/sonarcloud/
folder: /labs/azuredevops/sonarcloud/
version: Lab version - 15.8.2
updated: Last updated - 9/6/2018
---
<div class="rw-ui-container"></div>
<a name="Overview"></a>

## Overview ##

In this lab, you will be introduced to technical debt, how to configure your Azure Build definitions to use SonarCloud, how to understand the analysis results, and finally how to configure quality profile to control the rule set used by SonarCloud for analyzing your project.

Technical debt is the set of problems in a development effort that make forward progress on customer value inefficient. Technical debt saps productivity by making code hard to understand, fragile, time-consuming to change, difficult to validate, and creates unplanned work that blocks progress. Technical debt saps an org's strength due to high costs in customer support, and, eventually, some combination of these issues creates a larger problem that someone runs into. Technical debt is insidious. It starts small and grows over time through rushed changes, lack of context and lack of discipline. It can materialize out of nowhere even for a project regarded as clean at some point in time, due to a change in project circumstances: prototype code may be promoted to serve as the basis for a feature; code produced for the U.S. market may be proposed for international, instantly creating debt related to localizability; technologies evolve, but the app doesn't keep up.

<a name="Prerequisites"></a>
### Prerequisites ###

- A SonarCloud account from [https://sonarcloud.io](https://sonarcloud.io/).

- This lab requires you to complete task 1 from the <a href="../prereq/">prerequisite</a> instructions.

<a name="Exercise1"></a>
## Exercise 1: Managing Technical Debt with Azure DevOps and SonarCloud ##

<a name="Ex1Task1"></a>
### Task 1: Install and configure the SonarCloud extension ###

1. Navigate to your team project on Azure DevOps.

1. SonarCloud is provided as a marketplace extension. From the **Marketplace** navigation dropdown, select **Browse Marketplace**.

    ![](images/000.png)

1. Search for **"SonarCloud"**.

    ![](images/001.png)

1. Select the **SonarCloud** option.

    ![](images/002.png)

1. Click **Get it free**.

    ![](images/003.png)

1. Select the organization to install **SonarCloud** into. This should be the organization that contains your **Parts Unlimited** project. Click **Install**.

    ![](images/004.png)

1. Click **Proceed to organization**.

    ![](images/005.png)

1. Navigate to your **Parts Unlimited** team project.

<a name="Ex1Task2"></a>
### Task 2: Integrating a build with SonarCloud ###

1. Navigate to **Pipelines \| Pipelines**.

    ![](images/006.png)

1. Select **New pipeline** to create a new build pipeline.

    ![](images/007.png)

1. Click **use the classic editor**.

    ![](images/008.png)

1. Accept the default options and click **Continue**.

    ![](images/009.png)

1. Select the **.NET Desktop with SonarCloud** template and click **Apply**.

    ![](images/010.png)

1. This build definition is pretty standard for a .NET project, except that it also includes three additional tasks for **SonarCloud**. Note that you could easily integrate these specific tasks with your existing build definitions. There's no need to start from scratch like we are in this lab.

    ![](images/011.png)

1. Set the **Agent pool** to **Hosted**. It should be the first option and have the **Visual Studio** logo.

    ![](images/012.png)

1. Select the **Prepare analysis on SonarCloud** task. This task defines the connection configuration for any later tasks.

    ![](images/013.png)

1. Click **New** to configure a new **SonarCloud Service Endpoint**.

    ![](images/014.png)

1. Click **your SonarCloud account security page** to open the account page in a new tab.

    ![](images/015.png)

1. Navigate to [https://sonarcloud.io](https://sonarcloud.io/) and sign in to your SonarCloud account.

1. Click "My account link" and move to "Security" tab

    ![](images/015a.png)

1. To generate a token, enter a name like **"azuredevops"** and click **Generate**.

    ![](images/016.png)

1. When the token is generated, click **Copy** to copy it to your clipboard. This token is tied to your account and the only thing necessary to access the service on your behalf.

    ![](images/017.png)

1. Enter a **Service connection name** of **"SonarCloud"** and paste the token as the **SonarCloud Token**. Click **Verify and save**.

    ![](images/018.png)

1. Select **SonarCloud** as the **SonarCloud Service Endpoint** and select an **Organization** associated with the account. You'll also need to provide a globally unique **Project Key**, such as **"partsunlimited.YOURNAME"**.

    ![](images/019.png)

1. Select **Save & queue \| Save & queue** to kick off a new build.

    ![](images/020.png)

1. Click the new build link to follow its progress through to completion.

    ![](images/021.png)

<a name="Ex1Task3"></a>
### Task 3: Reviewing SonarCloud results ###

1. From the left panel, select the **Run Code Analysis** task. This contains the processes where SonarCloud analyzes the code.

    ![](images/022.png)

1. Near the end of the log, locate the URL to the results viewer and open it.

    ![](images/023.png)

1. The SonarCloud results are organized for easy access to the key results you're looking for.

    ![](images/024.png)

1. Select the **Issues** tab. This provides a convenient way to filter and sort the results so that you can attack the section you feel needs immediate attention. Select the first result.

    ![](images/025.png)

1. The code view provides an in-depth review of each issue, along with suggestions and configuration options. For this issue, select **Open \| Resolve as won't fix**.

    ![](images/026.png)

1. Select the **Measures** tab. This provides a visualization of issues as selected by the available filters.

    ![](images/027.png)

1. Filter down to see the **Reliability \| Overview**. This enables you to hover over the various assets to see the amount of effort required to fix and/or maintain various components for reliability.

    ![](images/028.png)

1. Select the **Code** tab and drill into the **PartsUnlimitedWebsite** project. This provides a way to review project issues at a file level.

    ![](images/029.png)

1. Open **Bootstrapper.cs**.

    ![](images/030.png)

1. Locate the first issue related to having commented code. Expand it using the **chevron** and click the **ellipses** to see a detailed explanation and references as to the relevance and importance of this rule.

    ![](images/031.png)

1. Expand the **Administration** option. Note that there is an incredible amount of flexibility available here for customizing your SonarCloud analysis.

    ![](images/032.png)

