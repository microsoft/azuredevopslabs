---
title: DevOps with Visual Studio Team Services for Java - Hands-on-Labs 
layout: page
sidebar: java
permalink: /labs/java/
folder: /labs/java/
comments: true
---
![](images/all_logo.png)

[Visual Studio Team Services (VSTS)](https://www.visualstudio.com/products/visual-studio-team-services-vs) and [Team Foundation Server (TFS)](https://www.visualstudio.com/tfs/) provide an integrated set of services and tools to manage your software projects, from planning and development through testing and deployment to speed the development and delivery of your software applications across platforms, including iOS, Android, Java, Linux or Windows.

## Overview  of the Java Hands-on-Lab

DevOps for Java teams with Microsoft Visual Studio Team Services hands-on-lab is provided to give you a first-hand, technical experience on how you can leverage the Microsoft DevOps platform for Java development. The labs cover

- Creating a new VSTS account
- Using the Agile  tools to plan and track work items
- Using VSTS with your Eclipse and IntelliJ
- Running Junit tests and analyzing code coverage with Jacoco and Cobertura
- Continuous Integration with Team Build or Jenkins
- Managing Technical Debt with SonarQube
- Deploying Docker containers to Azure with an Automated delivery pipeline

## Virtual Machine

![](images/nwc_logo.png)

Our partner NorthWest Cadence has built a virtual machine image that is pre-configured with all the software you require to run through the labs. You can find instructions on provisioning and connecting to the virtual machine [here.](https://github.com/nwcadence/java-dev-vsts)

## Target Audience

The image and the accompanying hand-on-labs is for technical audience. As such, familiarity with Visual Studio Team Services, Java and Linux operating system would be preferred although it is not a strict prerequisite.

## Provisioning the Project using VSTSDemoGenerator

You can use [Visual Studio Team Services Demo Generator](https://vstsdemogenerator.azurewebsites.net/?Name=MyShuttle-Java) to provision a project with pre-defined data on to your VSTS account to follow the hands-on-labs.

## Hands on Labs

The labs should be followed in the following order, though there are some equivalent labs that allow you a "choose your adventure" experience:

| Labs |
|------|
| [Setting up a new project on VSTS](settingvstsproject)|
|[Set up a Docker build agent](dockerbuildagent)|
|[Cloning a VSTS Repo - IntelliJ](intellijgit)|
|[Cloning a VSTS Repo - Eclipse](eclipsegit)|
|[Maven Package Management with VSTS and Jenkins](mavenpmjenkins)|
|[Maven Package Management with VSTS Team Build](mavenpmvsts)|
|[Build Docker containers with VSTS](builddocker)|
|[Managing Technical Debt with SonarQube and VSTS Team Build](sonarqube)|
|[Release Management with VSTS](releasemanagement)|
|[End to End Workflow - IntelliJ](e2eintellij)|
|[End to End Workflow - Eclipse](e2eeclipse)|
