---
title: DevOps with Visual Studio Team Services for Java - Hands-on-Labs 
layout: page
sidebar: mydoc_sidebar
permalink: /labs/java/
folder: /labs/java/
comments: true
---


## Overview

DevOps for Java teams with [Microsoft Visual Studio Team Services](https://www.visualstudio.com/products/visual-studio-team-services-vs) hands-on-lab is provided to give you a first-hand, technical experience on how you can leverage the Microsoft DevOps platform for Java development. The labs cover both using the built-in first-party cross-platform tools and as well as using your existing toolset to build and deploy Java applications.

Thanks to our partners NorthWest Cadence for building a pre-built virtual machine image that is preconfigured with all the software you require to run through the labs. The "Creating the VM" section below has instructions on how you can run a copy of this image in your own Azure subscription.


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
1. [Set up a Docker build agent](Set%20up%20a%20Docker%20build%20agent.md)
1. Either:
    1. [Cloning a VSTS Repo - IntelliJ](Cloning%20a%20VSTS%20Repo-IntelliJ.md) **OR**
    1. [Cloning a VSTS Repo - Eclipse](Cloning%20a%20VSTS%20Repo-IntelliJ.md)
1. Either:
    1. [Maven Package Management with VSTS and Jenkins](Maven%20Package%20Management%20with%20VSTS%20and%20Jenkins.md) **OR**
    1. [Maven Package Management with VSTS Team Build](Maven%20Package%20Management%20with%20VSTS%20Team%20Build.md)
1. [Build Docker containers with VSTS](Build%20Docker%20containers%20with%20VSTS.md)
1. (Optional) [Managing Technical Debt with SonarQube and VSTS Team Build](Managing%20Technical%20Debt%20with%20SonarQube%20and%20VSTS%20Team%20Build.md)
1. [Release Management with VSTS](Release%20Management%20with%20VSTS.md)
1. (Optional) [Release Containers to ACS Kubernetes with VSTS](Release%20Containers%20to%20ACS%20Kubernetes%20with%20VSTS.md)
1. Either:
    1. [End to End Workflow - IntelliJ](End%20to%20End%20Workflow-IntelliJ.md)
    1. [End to End Workflow - Eclipse](End%20to%20End%20Workflow-Eclipse.md)