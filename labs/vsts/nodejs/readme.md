---
title: DevOps for Node.js with Visual Studio Team Services and Azure
layout: page
sidebar: vsts
permalink: /labs/vsts/nodejs/
folder: /labs/vsts/nodejs/
---

In this session, we will present a scenario where Visual Studio Team Services (VSTS) can enable Node.js developers with continuous integration and deployment features. The scenario demonstrates how a Node.js developer using [Visual Studio Code](http://code.visualstudio.com) and various Azure-related VS Code extensions to create a new Azure App Service and use Git-based deployment. You'll learn how a Node.js developer using the popular server-side MVC framework known as Express can use VSTS to ensure that their code is deployed automatically to an Azure App Service when code is committed to a VSTS Git repository. 

## Demo Setup

1. If you don't already have a Visual Studio Dev Essentials and Visual Studio Team Services account, create one at [my.visualstudio.com](http://my.visualstudio.com). 

1. If you don't already have an Azure subscription, create one [here](https://azure.microsoft.com/en-us/free/). 

1. Install Git if you don't already have it installed. 

1. Install Node.js either by using the downloadable installers from [Node.js](https://nodejs.org) or using various command-line tools. Mac users can install Node.js using [Homebrew](https://brew.sh/) using the command `brew install node`.

1. Install [Visual Studio Code](http://code.visualstudio.com).

1. Install the [Azure Tools for VS Code](http://aka.ms/vscodeazuretools) using either the VS Code Extensions Palette (search for *azure tools*) or by running the command `ext install azuretoolsforvscode` at the VS Code command palette.

1. Once you have installed Visual Studio Code, open an instance of the editor. In Code, use `Ctrl-Shift-P` (or `Cmd-Shift-P` on a Mac) to open up the command palette. Type the word `path` to filter the command menu, and then select the command **Install 'code' command in PATH** to make it easy to open Visual Studio Code from your command line. 

   <img src="media/06-path.png" />

## Demo Steps

- <a href="/labs/vsts/nodejs/express/">Express MVC Web App Scenario</a> - Contains the end-to-end demo steps.

## Setting up the Environment

Click on **Deploy to Azure** to create **Visual Studio 2017 Enterprise** Virtual Machine.

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoft%2Falmvm%2Fmaster%2Farmtemplates%2Fnodejs%2Ftemplate.json" target="_blank">
    <img src="http://azuredeploy.net/deploybutton.png"/>
    </a>

    
