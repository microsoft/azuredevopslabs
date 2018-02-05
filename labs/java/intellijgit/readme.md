---
title: Working with IntelliJ 
layout: page
sidebar: java
permalink: /labs/java/intellijgit/
folder: /labs/java/intellijgit/
comments: true
---

In this exercise, you are going to open the MyShuttle2 repo from your VSTS account in your VM for editing in IntelliJ.
This exercise assumes you have completed Exercise 1, have created a Team Project that uses Git for version control, and imported the MyShuttle2 GitHub repo into your team project. This exercise uses a team project named **jdev-labs**, though your team project name may differ.

## Connect to VSTS from IntelliJ

1. Click on the IntelliJ icon in the toolbar to open IntelliJ IDEA.

    ![Click IntelliJ in the Toolbar](images/click-intellij.png)

1. The first time you run IntelliJ, it will prompt for IntelliJ settings and theme settings. Click on **Do not import settings,** then click on **Skip All and Set Defaults** to use the defaults.

    ![Accept the default IntelliJ theme](images/intellij-defaults.png)

1. When the Welcome dialog appears, click Configure and then select Plugins.

    ![Click on Configure to configure Plugins](images/intellij-config-plugins.png)

1. In the search box type `visual studio team services` and click the **Search in repositories** link in the main window.

    ![Search for the VSTS plugin](images/intellij-search-vsts.png)

1. Click Install to install the extension. The install button will change to a **Restart** button. Click it to restart IntelliJ.

    ![Install the plugin and restart IntelliJ](images/intellij-click-install.png)

1. When IntelliJ restarts, the Welcome dialog will appear again. Click **Check out from Version Control** and select **Team Services Git**.

    ![Checkout from Team Services Git](images/intellij-open-from-vsts.png)

1. Click on **Sign in...** to sign in to your VSTS account.

    ![Sign in to VSTS](images/intellij-vsts-signin.png)

## Clone MyShuttle2 from VSTS with IntelliJ

1. Once you are authenticated, enter **MyShuttle2** into the search bar and select the MyShuttle2 repo from your team project. Click Clone to clone the repo to the VM.

    ![Select the VSTS repo](images/intellij-select-repo.png)

1. IntelliJ detects a Maven project file (pom.xml) and asks if you want to open it. Click **Yes** to open the project. You can dismiss the Tip of the Day dialog that appears.

1. Press **Alt-1** to open the Project View.

1. Expand `src\main\java\com.microsoft.example` and click on **DataAccess** to open the DataAccess class.

1. A yellow warning appears in the main editor window prompting you to **Setup SDK**. Click on the link.

    ![Setup the JDK for the project](images/intellij-setup-sdk.png)

1. In the Select Project SDK dialog, click **Configure...**

    ![Click on Configure](images/intellij-jdk-configure.png)

1. In the upper left, click the green **+** icon to add a new SDK.

    ![Add an SDK](images/intellij-add-sdk.png)

1. Select `java-8-openjdk-amd64` from the folder list and click OK. Click OK through the rest of the dialogs.

    ![Select the SDK folder](images/intellij-select-sdk.png)

    {% include note.html content= "The project will not currently compile as it has a dependency on a library (MyShuttleCalc) that it cannot resolve. You will fix this in the [**Package Management lab**](../mavenpmvsts)." %}

## Clone MyShuttleCalc from VSTS with IntelliJ

1. While the MyShuttle2 project is open in IntelliJ, in the toolbar at the top of IntelliJ, select **File -> New -> Project from Version Control -> Team Services Git**.

    ![New Team Services Git project](images/intellij-new-myshuttlecalc-project.png)

1. Enter **MyShuttleCalc** into the search bar and select the MyShuttleCalc repo from your team project. Click Clone to clone the repo to the VM.

    ![Clone the MyShuttleCalc repo](images/intellij-clone-myshuttlecalc.png)

1. IntelliJ will prompt you to open the project in the same or a new window. Choose **New Window** to open another instance of IntelliJ with the MyShuttleCalc project.

    ![New window](images/intellij-new-window.png)

1. IntelliJ should open in a new instance with the project loaded.

    ![MyShuttleCalc](images/intellij-myshuttlecalc.png)