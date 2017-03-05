---
title: ALM VM 2017 - Hands-on-Labs 
layout: page    
sidebar: tfs
permalink: /labs/tfs/
comments: true
folder: /labs/tfs/
---

## Overview
The Microsoft Visual Studio ALM VM and the accompanying hands-on-labs are now updated to Visual Studio and Team Foundation Server 2017. This Virtual Machine is configured with:

- Microsoft Windows Server 2016 Standard Evaluation    
- Microsoft Visual Studio Enterprise 2017     
- Microsoft Visual Studio Team Foundation Server 2017     
- Microsoft Office Professional Plus 2016 (Word, PowerPoint, Excel, Outlook)     
- Microsoft Visio Professional 2016     
- Microsoft SQL Server 2016 Standard Edition   
- Sample users and data required to support hands-on-lab scripts      

## Accessing the Virtual Machine

You can get access to the virtual machine the following ways:

- **Download the Virtual Machine** - You can download the virtual machine, if you prefer to use it offline. Please see below for instructions to download the VM.
- **Try it on Technet Virtual Labs** - You can also access the virtual machine online on **TechNet Virtual Labs**  - no downloads or complex setup required. You can experience it right from your browser.
- **Run it on Azure** - If you prefer to run the VM on Azure, you can simply upload the VHD to your Azure storage and create a VM from the VHD. If you are setting up the labs for a traning, you  might want to consider the [Azure DevTest Labs](https://docs.microsoft.com/en-us/azure/devtest-lab/devtest-lab-training-lab) for training.

### Downloading and extracting the VM   
The size of the download is about 30 GB. It is recommended that you use a utility like [**Free download manager**](http://www.freedownloadmanager.org/).  This utility provides:   
    - Auto-resume support for interrupted downloads.
    - Multiple simultaneous download streams for (usually) a much faster download experience.
    - As the name implies, it’s completely free.    

- Download and install Free download manager if you currently do not have one installed 
- Open and select all the [download URLs](almvm2017url.txt) from the text file. Press ***CTRL+C*** to copy the selected URLs to clipboard.
- Select Menu - ***Paste URLs from clipboard***      
- When the download is complete, double-click the .exe file to self-extract the RAR files to a folder       
- Read the “Working with the …” document to start using the VM     

![Free Download Manager](fdm.png)


>There are quite a number of important instructions on how to use the VM including activating the VM, taking snapshots/check points, etc, documented.We highly recommend that you read through the[Working with the Visual Studio 2017 ALM Virtual Machine]() document prior to using the VM, even if you may have used the earlier version of the VM. 

>Note that The VM has about 15 GB of free hard disk space. Should you want to increase the size of the disk, you will need to do so before creating snapshots/check points. You can refer this article on [TechNet]() for instructions on expanding the virtual hard disk.

## Hands-On-Labs

Here are the 2017 hands-on-labs for Team Foundation Server. If you want to access the labs offline, you can download them as MS Word documents from <a href="https://github.com/Microsoft/almvm/tree/master/labs/Word">here</a>
<table width="100%">
<thead><td><b>
Lab Name</b>
</td>
</thead>
<tr><td>Working with the Visual Studio 2017 ALM Virtual Machine</td></tr>
<tr><td><a href="agile/">Agile Planning and Portfolio Management with Team Foundation Server 2017</a></td></tr>
<tr><td><a href="branchingandmerging/">Branching and Merging Visualization with Visual Studio Team Foundation Server 2017</a></td></tr>
<tr><td><a href="storyboarding/">Building the Right Software - Generating Storyboards and Collecting Stakeholder Feedback with Visual Studio 2017</a></td></tr>
<tr><td><a href="architecturevalidation/">Code Discovery using Live Dependency Validation in Visual Studio Enterprise 2017</a>    <span class="label label-success">New</span></td></tr>
<tr><td><a href="devteamcollaboration/">Collaboration Experiences for Development Teams using Team Foundation Server 2017</a></td></tr>
<tr><td><a href="devexp/">Developer experience enhancements in Visual Studio 2017</a>     <span class="label label-success">New</span></td></tr>
<tr><td><a href="debugging/">Debugging with IntelliTrace using Visual Studio Enterprise 2017</a></td></tr>
<tr><td><a href="intellitrace/">Diagnosing Issues in Production with IntelliTrace and Visual Studio 2017</a></td></tr>
<tr><td><a href="releasemanagement/">Embracing Continuous Delivery with Release Management for Visual Studio 2017</a></td></tr>
<tr><td><a href="exploratorytesting/">Exploratory Testing and Feedback Management with Team Foundation Server 2017</a></td></tr>
<tr><td><a href="intellitest/">Generate Unit Tests with IntelliTest using Visual Studio Enterprise 2017</a></td></tr>
<tr><td><a href="smartword4tfs/">Introduction to SmartOffice4TFS</a></td></tr>
<tr><td><a href="smartword4tfs/">Introduction to the Modern Requirements Suite4TFS & Team Foundation Server 2017</a></td></tr>
<tr><td><a href="appinsights/">Instrumenting ASP.NET with Application Insights in Visual Studio 2017</a></td></tr>
<tr><td><a href="liveunittesting/">Live Unit Testing in Visual Studio 2017</a>    <span class="label label-success">New</span></td></tr>
<tr><td><a href="vsproductivity/">Making Developers More Productive with Visual Studio Team Foundation Server 2017</a></td></tr>
<tr><td><a href="technicaldebt/">Managing Technical Debt with Team Foundation Server 2017 and SonarQube</a></td></tr>
<tr><td><a href="packagemanagement/">Package Management in Team Foundation Server 2017</a>    <span class="label label-success">New</span></td></tr>
<tr><td><a href="readyroll/">ReadyRoll- Develop and deploy databases in Visual Studio Enterprise 2017</a>    <span class="label label-success">New</span></td></tr>
<tr><td><a href="sqlprompt/">SQL Prompt for Visual Studio Enterprise 2017</a>    <span class="label label-success">New</span></td></tr>
<tr><td><a href="build/">Team Foundation Build 2017</a></td></tr>
<tr><td><a hrf="manualtesting/">Test Planning and Management with Team Foundation Server 2017</a></td></tr>
<tr><td><a href="codedui/">UI Automation using Coded UI Tests with Visual Studio Enterprise 2017</a></td></tr>
<tr><td><a href="unittesting/">Unit Testing, Code Coverage and Code Clone Analysis with Visual Studio 2017</a></td></tr>
<tr><td><a href="codeanalysis/">Using Code Analysis with Visual Studio 2017 to Improve Code Quality</a></td></tr>
<tr><td><a href="git/">Version Controlling with Git using Team Foundation Server 2017</a></td></tr>
<tr><td><a href="load/">Web Application Load and Performance Testing with Visual Studio 2017</a></td></tr>
<tr><td><a href="editorconfig/">Working with EditorConfig in Visual Studio 2017</a>    <span class="label label-success">New</span></td></tr>
</table>