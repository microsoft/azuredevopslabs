---
title: DevOps with Visual Studio Team Services for Java - Hands-on-Labs 
layout: page
sidebar: java
permalink: /labs/java/index.html
folder: /labs/java/
comments: true
---

[Visual Studio Team Services (VSTS)](https://www.visualstudio.com/products/visual-studio-team-services-vs) and [Team Foundation Server (TFS)](https://www.visualstudio.com/tfs/) provide an integrated set of services and tools to manage your software projects, from planning and development through testing and deployment to speed the development and delivery of your software applications across platforms, including iOS, Android, Java, Linux or Windows. 

## Overview  of the Java Hands-on-Lab

DevOps for Java teams with Microsoft Visual Studio Team Services hands-on-lab is provided to give you a first-hand, technical experience on how you can leverage the Microsoft DevOps platform for Java development. The labs cover 
  * Creating a new VSTS account
  * Using the Agile  tools to plan and track work items  
  * Using VSTS with your Eclipse and IntelliJ
  * Running Junit tests and analyzing code coverage with Jacoco and Cobertura
  * Continuous Integration with Team Build or Jenkins
  * Managing Technical Debt with SonarQube 
  * Deploying Docker containers to Azure with an Automated delivery pipeline 

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

<!--<table>
<tr>
<td>Phase</td>
<td>Lab Name</td>
</tr>
<tr>
<td>Getting Started</td>
<td><a href="creatingvstsaccount.html">1. Setting up a new project on VSTS</a></td>
</tr>
<tr>
<td><b>Plan</b></td><td><a href="agile.html">2. Agile Planning and Portfolio Management with Visual Studio Team Services </a></td>
</tr>
<tr><td><b>Develop</b></td><td><a href="intellij.html">3. Cloning a VSTS Repo - IntelliJ</a> <i>(If IntelliJ is your choice of IDE)</i> <b>OR</b><br /><a href="intellij.html">3. Cloning a VSTS Repo - Eclipse</a><i>(If you prefer Eclipse)</i></td>
</tr>
<tr rowspan="3">
<td> <b>Continuous Integration</b></td><td><a href="vstsbuildagent.html">3. Set up a Docker build agent</a></td></tr>
<tr> <td></td><td> <a href="mavenjenkins.html">4. Using Jenkins with Visual Studio Team Services</a> <b>OR</b><br /> <a href="mavenvsts.html">Using VSTS Team Build with Visual Studio Team Services</a></td></tr>
<tr><td></td> <td> <a href="vstsbuildagent.html">5. Building and Publishing Docker Images with VSTS</a></td></tr>
<td><b>Test</b></td><td><a href="techdebt.html">6. Managing Technical Debt with SonarQube and VSTS Team Build </a></td>
<tr rowspan="2">
<td> <b>Continuous Delivery</b></td><td><a href="vstsbuildagent.html">7.Release Management with VSTS</a></td>
<tr> <td></td><td> <a href="mavenjenkins.html">8.Release Containers to ACS Kubernetes with VSTS </a> <b>OR</b><br /> <a href="mavenvsts.html">Using VSTS Team Build with Visual Studio Team Services</a></td></tr></table>-->

<table width="100%">
   <thead>
      <tr>
         <th width="25%"><b>Phase</b></th>
		 <th width="55%"><b>Lab Name</b></th>
         <th width="75%"><b>Last Updated</b></th>
      </tr>
   </thead>
   <tr>
      <td><a href="/">Getting Started</a></td>
	  <td><a href="/">Setting up a new project on VSTS</a></td>
      <td>April 19, 2017</td>
   </tr>
   <tr>
      <td><a href="/">Plan</a></td>
	  <td><a href="/">Agile Planning and Portfolio Management with Visual Studio Team Services </a></td>
      <td>April 22, 2017</td>
   </tr>
   <tr>
      <td><a href="/">Develop</a></td>
	  <td><a href="/">Cloning a VSTS Repo - IntelliJ</a> (If IntelliJ is your choice of IDE) <b>OR</b> <br/> <a href="/">Cloning a VSTS Repo - Eclipse</a> (If you prefer Eclipse)</td>
      <td>May 15, 2017</td>
   </tr>
   <tr>
      <td><a href="/">Continuous Integration</a></td>
	  <td><a href="/">Using Jenkins with Visual Studio Team Services</a> <b>OR</b> <br/><a href="" >Using VSTS Team Build with Visual Studio Team Services</a><br/><br/> <a href="/">Building and Publishing Docker Images with VSTS</a></td>
      <td>April 22, 2017</td>
   </tr>
   <tr>
      <td><a href="/">Test</a></td>
	  <td><a href="/">Managing Technical Debt with SonarQube and VSTS Team Build </a></td>
      <td>May 10, 2017</td>
   </tr>
      <tr>
      <td><a href="/">Continuous Delivery</a></td>
	  <td><a href="azurecd/">Release Management with VSTS</a><br/><br/><a href="/">Release Containers to ACS Kubernetes with VSTS</a> <b>OR</b> <br/> <a href="" >Using VSTS Team Build with Visual Studio Team Service</a></td>
	  <td>July 19, 2017</td>
   </tr>
</table>
