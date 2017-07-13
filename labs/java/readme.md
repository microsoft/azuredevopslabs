---
title: DevOps with Visual Studio Team Services for Java - Hands-on-Labs 
layout: page
sidebar: mydoc_sidebar
permalink: /labs/java/index.html
folder: /labs/java/
comments: true
---

Overview and Creating the VM
----------------------------

[Microsoft Visual Studio Team Services](https://www.visualstudio.com/products/visual-studio-team-services-vs) makes your software lifecycle better and faster letting you code in Eclipse, IntelliJ, or your favorite Java IDE. You get free unlimited private Git repositories, agile planning and work item tracking tools, and support for builds and continuous integration using Ant, Maven, or Gradle.

The VSTS for Java on Ubuntu Virtual Machine Virtual Machine is a pre-configured, ready to run image on Azure and comes with a set of Hands-On-Labs/Demo scripts to help anyone who wants to learn how Visual Studio Team Services (and Team Foundation Server) provide cross platform tools that enable you to easily build Java solutions.

A set of hands-on-lab documents, which also function as demo scripts, are available for download along with this virtual machine.

Once you get your team environment set up, you'll start working on an Intranet site for a fictitious company, MyShuttle.biz, where you'll update the site, deploy it and test it all with the VM you're using and Visual Studio Team Services.

Target Audience
-----------------------------------------
The image and the accompanying hand-on-labs is for technical audience. As such, familiarity with Visual Studio Team Services, Java and Linux operating system would be preferred although it is not a strict prerequisite.

Hands on Labs
-------------

The labs should be followed in the following order, though there are some equivalent labs that allow you a "choose your adventure" experience:

1. [Setting up a new project on VSTS](creatingvstsaccount.html)
1. [Set up a Docker build agent](vstsbuildagent.html)
1. Either:
    1. [Cloning a VSTS Repo - IntelliJ](intellij.html) **OR**
    1. [Cloning a VSTS Repo - Eclipse](Cloning%20a%20VSTS%20Repo-IntelliJ.md)
1. Either:
    1. [Maven Package Management with VSTS and Jenkins](mavenjenkins.html) **OR**
    1. [Maven Package Management with VSTS Team Build](mavenvsts.html)
1. [Build Docker containers with VSTS](builddocker.html)
1. (Optional) [Managing Technical Debt with SonarQube and VSTS Team Build](Managing%20Technical%20Debt%20with%20SonarQube%20and%20VSTS%20Team%20Build.md)
1. [Release Management with VSTS](deployazure.html)
1. (Optional) [Release Containers to ACS Kubernetes with VSTS](Release%20Containers%20to%20ACS%20Kubernetes%20with%20VSTS.md)
1. Either:
    1. [End to End Workflow - IntelliJ](End%20to%20End%20Workflow-IntelliJ.md)
    1. [End to End Workflow - Eclipse](End%20to%20End%20Workflow-Eclipse.md)