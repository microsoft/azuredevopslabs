---
title: Generating Demo Data in the Azure DevOps Server 2019 Virtual Machine
layout: page
sidebar: vsts
permalink: /labs/devopsserver/demogenerator/
folder: /labs/devopsserver/demogenerator/
version: Lab version - 16.0.0
updated: Last updated - 4/3/2019
---
<div class="rw-ui-container"></div>

<a name="Overview"></a>
## Overview ##

In this lab, you will learn about how to generate demo data using the built-in demo generator for use with the Azure DevOps Server 2019 virtual machine. The demo generator is a web utility that uses the Azure DevOps Server API to populate the data, so it will require a personal access token.

<a name="Exercise1"></a>
## Exercise 1: Generating Demo Data in the Azure DevOps Server 2019 Virtual Machine ##

<a name="Ex1Task1"></a>
### Task 1: Generating demo data in the Azure DevOps Server 2019 virtual machine ###

1. Log in as **Sachin Raj (VSALM\Sachin)**. All user passwords are **P2ssw0rd**.

1. Install Google Chrome. The demo generator site does not support Internet Explorer.

1. Use Chrome to navigate to [http://vsalm:8080/tfs](http://vsalm:8080/tfs). This is the root of your Azure DevOps site.

1. From Sachin's profile dropdown, select **Security**.

    ![](images/000.png)

1. Click **Add** to create a new personal access token.

    ![](images/001.png)

1. Enter a **Description** for the token and click **Create Token**.

    ![](images/002.png)

1. Copy the token for use in the demo generator.

    ![](images/003.png)

1. Navigate to [http://vsalm:7676](http://vsalm:7676/). This is the locally hosted demo generator.

1. Enter a **Server Name** of **"vsalm"**, a **Port** of **"8080"**, and paste your token for the **PAT**. Enter the name of an existing **Collection**, such as **"PartsUnlimitedCollection"**. Click **Validate** to confirm.

    ![](images/004.png)

1. Enter a **New Project Name**. If you're replacing the existing **Parts Unlimited** project, be sure to delete it from the collection before continuing. Click **Choose template**.

    ![](images/005.png)

1. Select the **PartsUnlimited** template and click **Apply**.

    ![](images/006.png)

1. Click **Create Project**.

    ![](images/007.png)

1. It will take a minute or two for the project to finish creating.

    ![](images/008.png)

1. When the project is ready, click **Navigate to project** to visit the portal.

    ![](images/009.png)

