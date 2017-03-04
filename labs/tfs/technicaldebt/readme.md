---
title: Managing Technical Debt with Team Foundation Server 2017 and SonarQube
layout: page    
sidebar: tfs
permalink: /labs/tfs/technicaldebt/
folder: /labs/tfs/technicaldebt/
---

**Overview**

In this lab, you will be introduced to Technical debt, how to configure your Team Build Definitions to use SonarQube, how to understand the analysis results and finally how to configure quality profile to control the rule set used by SonarQube for analyzing your project.

Technical debt is the set of problems in a development effort that make forward progress on customer value inefficient. Technical debt saps productivity by making code hard to understand, fragile, time-consuming to change, difficult to validate, and creates unplanned work that blocks progress. Technical debt saps an org's strength due to high costs in customer support, and, eventually, some combination of these issues creates a larger problem that someone runs into. Technical debt is insidious.  It starts small and grows over time through rushed changes, lack of context and lack of discipline.  It can materialize out of nowhere even for a project regarded as clean at some point in time, due to a change in project circumstances: prototype code may be promoted to serve as the basis for a feature; code produced for the U.S. market may be proposed for international, instantly creating debt related to localizability; technologies evolve, but the app doesn’t keep up.

> SonarQube is an open source platform for understanding and managing technical debt, it provides different ways to analyze and measure technical quality from project portfolio to method.

### Prerequisites

1- In order to complete this lab you will need the Visual Studio 2017 virtual machine provided by Microsoft. For more information on acquiring and using this virtual machine, please see [this blog post](http://aka.ms/ALMVM).

2- You will need to manually install SonarQube on the above virtual machine using the recommended installation guide created by the Visual Studio ALM Rangers, please see this installation guide on GitHub. Alternatively, you may follow exercise 1 in this lab to install and configure SoanrQube for demo and evaluation purposes.

3- You will need to download and install SonarQube VSTS extension from [VSTS marketplace] (https://marketplace.visualstudio.com/items?itemName=SonarSource.sonarqube)

## Exercises 

This hands-on lab includes the following exercises:

* Install and configure SonarQube Server.

* Install and configure SonarQube Extension.

* Analyzing with SonarQube Extension for VSTS/TFS.

Estimated time to complete this lab: **45 minutes**.

**Exercise 1: Install and Configure SonarQube Server**

In this exercise, you will learn about the main installation and configuration points required to install and configure SonarQube for demo purposes
> Note: The steps provided below are the main steps needed to install SonarQube and SonarQube Extensions on this VM for demo and evaluation purposes. We recommend following the installation guide created by the Visual Studio ALM Rangers for more detailed instructions, please see this [installation guide on GitHub](https://github.com/SonarSource/sonar-.net-documentation).

1.	Download **SonarQube** Server from the SonarQube downloads.

<img src="./media/techdebt_img1.png" />

2.	Download **Java SE Runtime Environment (JRE)** from the Oracle Jave SE downloads page. Select the Download under JRE. Select Accept License Agreement and click the Windows x64 that points to exe file.

<img src="./media/techdebt_img2.png" />

3.	Download the latest [**SonarC#** ](https://docs.sonarqube.org/pages/viewpage.action?pageId=1441900)sonar-csharp-plugin-X.Y.jar available from the SonarQube plugin library

<img src="./media/techdebt_img3.png" />

4.	Download **SonarQube** extension from [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=SonarSource.sonarqube).
	
<img src="./media/techdebt_img4.png" />

5.	Log in as <b>Sachin Raj</b> (VSALM\\Sachin)</b>. All user passwords are <b>P2ssw0rd</b>

6.	Copy **sonarqube-x.x.zip**, **jre-XuXXX-windows-x64.exe**, **sonar-csharp-plugin-X.Y.jar** and **SonarSource.sonarqube-X.X.X.vsix** to the virtual machine.

7.	Install Java SE Runtime Environment on the VM.

8.	Right-click on sonarqube-x.x.x.zip, select Properties and then click on the Unblock button

9.	Unzip SonarQube-x.x.zip on to a folder, for example use C:\SonarQube\SonarQube-x.x.x. 

10.	In the extracted folder navigate to **Conf** folder, edit **sonar.properties** file to change the default web port for example **9090**. 

`By default, SonarQube uses port **9000** which is currently being used in the virtual machine for FabrikamFiber QA web site (FF QA). For the purpose of this lab you can provide port 9090.`

11. Copy **sonar-csharp-plugin-X.Y.jar** to SonarQube directory (C:\SonarQube\SonarQube-x.x.x\) under **extensions\plugins\** subdirectory.

13. Run SonarQube by opening a **command prompt** and change the directory to SonarQube extracted folder cd C:\SonarQube\SonarQube-x.x.x\bin\windows-x86-64 and Run **StartSonar.bat**. Wait until you get a confirmation on the command prompt that the process is up and running.

<img src="./media/techdebt_img5.png"/>

14. Open you browser and navigate to http://vsalm:9090 to access the SonarQube portal

<img src="./media/techdebt_img6.png" />


