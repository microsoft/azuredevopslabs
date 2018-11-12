---
title: DevOps with Visual Studio Team Services for Java - Hands-on-Labs 
layout: page
sidebar: java
permalink: /labs/java/
folder: /labs/java/
comments: true
updated: blank
---
![all_logo](images/all_logo.png)

[Visual Studio Team Services (VSTS)](https://www.visualstudio.com/products/visual-studio-team-services-vs){:target="_blank"} and [Team Foundation Server (TFS)](https://www.visualstudio.com/tfs/){:target="_blank"} provide an integrated set of services and tools to manage your software projects, from planning and development through testing and deployment to speed the development and delivery of your software applications across platforms, including iOS, Android, Java, Linux or Windows.

## Overview  of the Java Hands-on-Lab

**DevOps for Java teams with Microsoft Visual Studio Team Services** hands-on lab is provided to give you a first-hand, technical experience on how you can leverage the Microsoft DevOps platform for Java development. The labs cover

- Creating a new VSTS account
- Using the Agile  tools to plan and track work items
- Using VSTS with your Eclipse and IntelliJ
- Running Junit tests and analyzing code coverage with Jacoco and Cobertura
- Continuous Integration with Team Build or Jenkins
- Managing Technical Debt with SonarQube
- Deploying Docker containers to Azure with an Automated delivery pipeline

## Get the accompanying Virtual Machine

![nwc_logo](images/nwc_logo.png)

Our partner NorthWest Cadence has built a virtual machine image that is pre-configured with all the software you require to run through the labs. You can find instructions on provisioning and connecting to the virtual machine [here.](https://github.com/nwcadence/java-dev-vsts){:target="_blank"}

{% include important.html content="The image and the accompanying hand-on-labs is for technical audience. As such, familiarity with Visual Studio Team Services, Java and Linux operating system would be preferred although it is not a strict prerequisite" %}

## Hands-on Labs

The labs should be followed in the following order, though there are some equivalent labs that allow you a **choose your adventure** experience:

<table width="100%">
   <thead>
      <tr>
         <th width="75%"><b>Lab Name</b></th>
      </tr>
   </thead>
   <tr>
      <td><a href="settingvstsproject/">Setting up a new project on VSTS</a></td>
   </tr>
   <tr>
      <td><a href="dockerbuildagent/">Set up a Docker build agent</a></td>
   </tr>
   <tr>
      <td><a href="intellijgit/">Cloning a VSTS Repo - IntelliJ</a> <b>or</b> <a href="eclipsegit/">Cloning a VSTS Repo - Eclipse</a> </td>
   </tr>
   <tr>
      <td><a href="mavenpmjenkins/">Maven Package Management with VSTS and Jenkins</a> <b>or</b> <a href="mavenpmvsts/">Maven Package Management with VSTS Team Build</a></td>
   </tr>
   <tr>
      <td><a href="builddocker/">Build Docker containers with VSTS</a></td>
   </tr>
   <tr>
      <td><a href="sonarqube/">Managing Technical Debt with SonarQube and VSTS Team Build</a></td>
   </tr>
   <tr>
      <td><a href="releasemanagement/">Release Management with VSTS</a></td>
   </tr>
   <tr>
      <td><a href="e2eintellij/">End to End Workflow - IntelliJ</a></td>
   </tr>
   <tr>
      <td><a href="e2eeclipse/">End to End Workflow - Eclipse</a></td>
   </tr>
</table>
