---
title: DevOps with Visual Studio Team Services for Java - Hands-on-Labs 
layout: page
sidebar: java
permalink: /labs/java/index.html
folder: /labs/java/
comments: true
---

[Visual Studio Team Services(VSTS)](https://www.visualstudio.com/products/visual-studio-team-services-vs) and [Team Foundation Server (TFS)](https://www.visualstudio.com/tfs/) provide an integrated set of services and tools to manage your software projects, from planning and development through testing and deployment to speed the development and delivery of your software applications across platforms, including iOS, Android, Java, Linux or Windows. 

## Overview  of the Java Hands-on-Lab

DevOps for Java teams with Microsoft Visual Studio Team Services hands-on-lab is provided to give you a first-hand, technical experience on how you can leverage the Microsoft DevOps platform for Java development. The labs cover 
  * Creating a new VSTS account
  * Using the Agile  tools to plan and track work items  
  * Using VSTS with your Eclipse and IntelliJ
  * Running Junit tests and analyzing code coverage with Jacoco and Cobertura
  * Continuous Integration with Team Build or Jenkins
  * Managing Technical Debt with SonarQube 
  * Deploying Docker containers to Azure with an Automated delivery pipeline 
          
 ## VSTS for Java on Ubuntu Virtual Machine Virtual Machine
      
<img src="images/nwc_logo.png"  align="bottom" />

Courtesy of our partner NorthWest Cadence, we have a pre-built virtual machine image that is pre-configured with all the software you require to run through the labs. The "Creating the VM" section below has instructions on how you can run a copy of this image in your own Azure subscription.

## Target Audience

The image and the accompanying hand-on-labs is for technical audience. As such, familiarity with Visual Studio Team Services, Java and Linux operating system would be preferred although it is not a strict prerequisite.

## Creating the VM

1. Create the VM and dependent resources.
    
    Simply click the Deploy to Azure button below and follow the wizard to create the resources. You will need to log in to the Azure Portal.
                                                                     
	<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fnwcadence%2Fjava-dev-vsts%2Fmaster%2Fenv%2FJavaDevVSTS.json" target="_blank">
		<img src="http://azuredeploy.net/deploybutton.png"/>
	</a>
	<a href="http://armviz.io/#/?load=https%3A%2F%2Fraw.githubusercontent.com%2Fnwcadence%2Fjava-dev-vsts%2Fmaster%2Fenv%2FJavaDevVSTS.json" target="_blank">
		<img src="http://armviz.io/visualizebutton.png"/>
	</a>

    The resources will be deployed to a Resource Group. You can delete the resource group in order to remove all the created resources at any time.

	The VM will take a few minutes (~20) to complete. The VM is installing required software and configuring the environment for the labs.

If you require assistance with these labs, you can contact Northwest Cadence through their [website](http://nwcadence.com).

## Hands on Labs

The labs should be followed in the following order, though there are some equivalent labs that allow you a "choose your adventure" experience:

1. [Setting up a new project on VSTS](Setting%20up%20a%20new%20project%20on%20VSTS.md)
1. [Set up a Docker build agent](vstsbuildagent.html)
1. Either:
    1. [Cloning a VSTS Repo - IntelliJ](Cloning%20a%20VSTS%20Repo-IntelliJ.md) **OR**
    1. [Cloning a VSTS Repo - Eclipse](Cloning%20a%20VSTS%20Repo-Eclipse.md)
1. Either:
    1. [Maven Package Management with VSTS and Jenkins](Maven%20Package%20Management%20with%20VSTS%20and%20Jenkins.md) **OR**
    1. [Maven Package Management with VSTS Team Build](Maven%20Package%20Management%20with%20VSTS%20Team%20Build.md)
1. [Build Docker containers with VSTS](Build%20Docker%20containers%20with%20VSTS.md)
1. (Optional) [Managing Technical Debt with SonarQube and VSTS Team Build](Managing%20Technical%20Debt%20with%20SonarQube%20and%20VSTS%20Team%20Build.md)
1. [Release Management with VSTS](Release%20Management%20with%20VSTS.md)
1. Either:
    1. [End to End Workflow - IntelliJ](End%20to%20End%20Workflow-IntelliJ.md)
    1. [End to End Workflow - Eclipse](End%20to%20End%20Workflow-Eclipse.md) 