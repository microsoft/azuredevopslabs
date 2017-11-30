---
title: Visual Studio Team Services Demo Generator- Overview 
layout: page
sidebar: vsts
permalink: /labs/vsts/VSTSDemoGenerator/
folder: /labs/vsts/VSTSDemoGenerator/
---

## Overview 

Visual Studio Team Services Demo Generator helps you create projects on your Visual Studio Team Services account with preset sample content which includes source code, work items, service endpoints, build and release definitions based on a template you choose.

The purpose of this system is to help follow hands-on-labs, demos and other education material provided by the Microsoft Visual Studio marketing team.

Before you start:

- You will need a Visual Studio Team Services account - if you do not have one, you can 
<a href="http://bit.ly/2dwMwYR">create</a> one now
- You will need a Personal Access Token for the account. An overview of PAT with instructions to create is available <a href="http://bit.ly/2okeOyJ">here</a>


## How to use?

1. Browse to <a href="https://vstsdemogenerator.azurewebsites.net/" target="_blank">VSTS Demo Generator</a>

   <img src="images/1.png"/>

2. Enter your ***VSTS account name*** and ***personal access token*** and then Click on **Verify & Continue** 

   <img src="images/2.png"/>

3. Provide a name for your project and select the template you want to provision from the drop-down list

   <img src="images/3.png"/>

4. Some templates may require additional extensions to be installed to your VSTS account. The system will check if these extensions are already installed. A green tick before the extension means that the extension is already installed. If the extensions needs to be installed, you can select the extension which will take you to the page on Visual Studio Team Services Marketplace, from where you can  install the extension. 

   <img src="images/4.png"/> 

5. Click on **Install**  to install the extension to your account.

   <img src="images/5.png"/>

6. After the extension is installed, return back to the VSTS Demo Generator tab and refresh the page.  Select **Create Project**. You will see the status while project is being created.

   <img src="images/6.png"/>

7. Upon successful creation of a project, you will see a link with the URL to the team project you created.

   <img src="images/7.png"/>

8. Select the link to navigate to the project and confirm the project was successfully generated.

   <img src="images/8.png"/>

>**Note:** You will need to provide your own information such as URLs, user name, password, etc for the endpoints created. You will need to provide them before you attempt to use them, say in build, release definitions, for example.




   




