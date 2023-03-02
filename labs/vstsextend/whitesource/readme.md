---
title: Managing Open-source security and license with Mend (formerly WhiteSource)
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/whitesource/
folder: /labs/vstsextend/whitesource/
---
<div class="rw-ui-container"></div>

## Overview

[Mend (formerly WhiteSource)](https://www.mend.io/){:target="_blank"} is the leader in continuous open source software security and compliance management. Mend integrates into your build process, irrespective of your programming languages, build tools, or development environments. It works automatically, continuously, and silently in the background, checking the security, licensing, and quality of your open source components against WhiteSource constantly-updated deﬁnitive database of open source repositories.

Mend provides Mend Bolt, a lightweight open source security and management solution developed specifically for integration with Azure DevOps and Azure DevOps Server. It works per project and does not offer real-time alert capabilities like the **Full platform**  which is generally recommended for larger development teams, wanting to automate their open source management throughout the entire software development lifecycle (from the repositories to post-deployment stages) and across all projects and products.

### What's covered in this lab

This lab shows how you can use **Mend Bolt with Azure DevOps** to automatically detect alerts on vulnerable open source components, outdated libraries, and license compliance issues in your code. You will be using WebGoat, a deliberately insecure web application, maintained by OWASP designed to teach web application security lessons.

Azure DevOps integration with Mend Bolt will enable you to:

1. Detect and remedy vulnerable open source components.
1. Generate comprehensive open source inventory reports per project or build.
1. Enforce open source license compliance, including dependencies’ licenses.
1. Identify outdated open source libraries with recommendations to update.

### Before you begin

1. Refer the [Getting Started](../Setup/) page before you follow the exercises.

1. Use [Azure DevOps Demo Generator](https://azuredevopsdemogenerator.azurewebsites.net/?name=WhiteSource-Bolt&templateid=77362){:target="_blank"} to provision the WhiteSource project on your Azure DevOps Organization.

## Exercise 1: Activate Mend Bolt

### Prerequisites to integrate Azure DevOps with Mend
Ensure the following:

1. Your Azure DevOps organization is connected to an Azure AD via **Organization Settings > Azure Active Directory**.
    
      ![ADO-ADConnect](images/ADO-ADConnect.png)
1. In your Azure DevOps navigate to **Organization Settings** and select **Mend** under Extensions. Provide your Work Email, Company Name and other details and click **Create Account** button to start using the Free version.


   ![Mendboltactivation](images/Mendboltactivation.png)


## Exercise 2: Trigger a build

You have a **Java code** provisioned by the Azure DevOps demo generator. You will use **Mend Bolt** extension to check the vulnerable components present in this code.

1. Go to **Pipelines** section under **Pipelines** tab, select the build definition **WhiteSourceBolt** and click on **Run pipeline** to trigger a build. Click **Run** (leave defaults).

   ![build-def](images/run.png)
   
   {% include note.html content= "We also have a YAML build pipeline if that's something you're interested in. To proceed through the YAML pipeline, choose **WhiteSourceBolt-YAML** and click **Edit** to view the YAML pipeline." %}

1. To view the build in progress status, click on job named **Phase 1**.

   ![inprogress_build](images/phase.png)


   ![queue-build](images/progress.png)

1. While the build is in progress, let's explore the build definition. The tasks that are used in the build definition are listed in the table below.

    |Tasks|Usage|
    |----|------|
    |![npm](images/npm.png) **npm**| Installs and publishes npm packages required for the build|
    |![maven](images/maven.png) **Maven**| builds Java code with the provided pom xml file|
    |![whitesourcebolt](images/mend2.png)**Mend Bolt**| scans the code in the provided working directory/root directory to detect security vulnerabilities, problematic open source licenses|
    |![copy-files](images/copy-files.png) **Copy Files**| copies the resulting JAR files from the source to the destination folder using match patterns|
    |![publish-build-artifacts](images/publish-build-artifacts.png) **Publish Build Artifacts**| publishes the artifacts produced by the build
    
1. Once the build is completed, click back navigation to  see the summary which shows **Test results, Build artifacts** etc. as shown below. 

   ![go back](images/back.png)
   ![build_summary](images/build_summarynew.png)

1. Navigate to **WhiteSource Bolt Build Report** tab  and wait for the report generation of the completed build to see the vulnerability report. This report shows the list of all vulnerable open source components with **Vulnerability Score**, **Vulnerable Libraries**, **Severity Distribution**

   
   ![report](images/whitesourcebuildreport.png)

## Exercise 3: Analyze Reports

Mend bolt automatically detects OpenSource components in the software including transitive dependencies and their respective licenses.

### Security Vulnerabilities

The security vulnerability section shows **vulnerabilty**, **name of the library**, **description** and **Top Fix**


![Security](images/securityvelnerability.png)

### License risks
You can see the opensource license distribution and a detailed view of all components and links to their metadata and licensed references.

 ![LicenceRisks](images/mendlicencerisks1.png)



## Summary

With Azure DevOps and Mend Bolt integration, you can *shift-left* your open source management. The integration allows you to have alerts in real time, on vulnerabilities and other issues to help you take immediate action.
