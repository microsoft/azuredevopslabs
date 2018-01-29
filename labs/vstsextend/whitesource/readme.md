---
title: Checking Vulnerabilities using WhiteSource Bolt with Visual Studio Team Services
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/whitesource/
folder: /labs/vstsextend/whitesource/
---
Last updated : {{ "now" | date: "%b %d,%Y" }}

## Overview

[WhiteSource](https://www.whitesourcesoftware.com/){:target="_blank"} is the leader in continuous open source software security and compliance management. WhiteSource integrates into your build process, no matter your programming languages, build tools, or development environments. It works automatically, continuously, and silently in the background, checking the security, licensing, and quality of your open source components against WhiteSource constantly-updated deﬁnitive database of open source repositories

WhiteSource provides WhiteSource Bolt, a lightweight open source security and management solution developed specifically for integration with Microsoft's Visual Studio Team Services (and TFS). It works per project and does not offer real-time alert capabilities like the **Full platform** offering which is generally recommended for larger development teams wanting to automate their open source management throughout the entire software development lifecycle (from the repositories to post-deployment stages) and across all projects and products.

This lab shows how you can use **WhiteSource Bolt with VSTS** to automatically detect and alerts on vulnerable open source components, outdated libraries, and licenses compliance issues in your code. We will be using WebGoat, a deliberately insecure web application maintained by OWASP designed to teach web application security lessons.

Team Services integration with WhiteSource Bolt will enable you to:

1. Detect and remedy vulnerable open source components.
1. Generate comprehensive open source inventory reports per project or build.
1. Enforce open source license compliance, including dependencies’ licenses.
1. Identify outdated open source libraries with recommendations to update.

## Prerequisites for the lab

1. You will need a **Visual Studio Team Services Account**. If you do not have one, you can sign up for free [here](https://www.visualstudio.com/products/visual-studio-team-services-vs){:target="_blank"}

1. You will need a **Personal Access Token** to set up your project using the Demo Generator. Please see this [article](https://docs.microsoft.com/en-us/vsts/accounts/use-personal-access-tokens-to-authenticate){:target="_blank"} for instructions to create your token.

    {% include note.html content= "You should treat Personal Access Tokens like passwords. It is recommended that you save them somewhere safe so that you can re-use them for future requests." %}

1. The **WhiteSource Bolt** extension from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=whitesource.ws-bolt){:target="_blank"} needs to be installed and enables on your VSTS account.

## Setting up the VSTS project

1. Use [VSTS Demo Data Generator](https://vstsdemogenerator.azurewebsites.net/?name=WhiteSource%20Bolt&templateid=77362){:target="_blank"} to provision the  WhiteSource project on your VSTS account.

   ![VSTSDemogenerator](images/VSTSDemogenerator.png)

1. Once the project is provisioned, click the URL to navigate to the project.

   ![VSTSDemogenerator-create](images/VSTSDemogenerator-create.png)

## Exercise 1: Activate WhiteSource Bolt

After installing the extension, you will need to activate your project with an activation code.

In your Team project, under **Build and Release** section, go to **White Source Bolt** tab and activate **14-days** [trial license](https://www.whitesourcesoftware.com/whitesource_bolt_visualstudio_2017/#activate){:target="_blank"}

![Dev_Essentials](images/Dev_Essentials.png)

If you are a Visual Studio Enterprise subscriber, you are entitled to 6-months free subscription. You can get your activation code from the [Visual Studio Enterprise benefit page](https://my.visualstudio.com/){:target="_blank"} and follow the [instructions](https://www.whitesourcesoftware.com/vse_whitesource_bolt//#activate){:target="_blank"}

![ActivateWhiteSourceBolt](images/ActivateWhiteSourceBolt.png)

Upon activation, the below message is displayed.

![14daystrial](images/14daystrial.png)

## Exercise 2: Trigger a build

We have a **Java code** provisioned by the demo generator system. We will use **WhiteSource Bolt** extension to check the vulnerable components present in this code.

1. Go to **Build and Release** tab, click the build definition and click on **Queue new build...** to trigger a build.

   ![build-def](images/build-def.png)

   ![queue-build](images/queue-build.png)

1. You can see the build in progress status.

   ![inprogress_build](images/inprogress_build.png)

1. While the build is in progress, let's explore the build definition. The tasks that is used in the build definition are listed in the table below.

    |Tasks|Usage|
    |----|------|
    |![maven](images/maven.png) **Maven**| builds Java code with the provided pom xml file|
    |![whitesourcebolt](images/whitesourcebolt.png) **WhiteSource Bolt**| scans the code in the provided working directory/root directory to detect security vulnerabilities, problematic open source licenses|
    |![copy-files](images/copy-files.png) **Copy Files**| copies the resulting JAR files from source to destination folder using match patterns|
    |![publish-build-artifacts](images/publish-build-artifacts.png) **Publish Build Artifacts**| publishes the artifacts produced by the build|

1. Once the build is completed, you will see the summary which shows **test results, code coverage** as shown below.

   ![build_summary](images/build_summary.png)

1. From the build summary, go to **WhiteSource Bolt Build Report** to see the vulnerability report.

   ![report](images/report.png)

## Analyze Reports

WhiteSource bolt automatically detects OpenSource components in the software including transitive dependencies and their respective licenses.

### Security Dashboard

The security dashboard shows the vulnerability of the build.
This report shows the list of all vulnerable open source components with **Vulnerability Score, Vulnerable Libraries, Severity Distribution**.

![Security](images/Security.png)

You can see the opensource license distribution and a detailed view of all components and links to their metadata and licensed references.

### Outdated Libraries

WhiteSource Bolt also tracks outdated libraries in the project getting all the detailed information and links to newer versions and recommendations.

![outdatedlibraries](images\outdatedlibraries.png)

## Summary

With VSTS and WhiteSource Bolt integration you can *shift-left* your open source management. The integration allows you to have alert in real time on vulnerabilities and other issues to help you take immediate action.