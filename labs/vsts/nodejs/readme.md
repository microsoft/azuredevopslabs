# DevOps with Node.js, Team Services, and Azure App Service

In this session, we will present a scenario where Visual Studio Team Services (VSTS) can enable Node.js developers with continuous integration and deployment features. The scenario demonstrates how a Node.js developer using [Visual Studio Code](http://code.visualstudio.com) and various Azure-related VS Code extensions to create a new Azure App Service and use Git-based deployment. You'll learn how a Node.js developer can use VSTS to ensure that their code is deployed automatically to an Azure App Service when code is committed to a VSTS Git repository. 

## Demo Setup

1. If you don't already have a Visual Studio Dev Essentials and Visual Studio Team Services account, create one at [my.visualstudio.com](http://my.visualstudio.com). 
1. If you don't already have an Azure subscription, create one [here](https://azure.microsoft.com/en-us/free/). 
1. Install Git if you don't already have it installed. 
1. Install Node.js either by using the downloadable installers from [Node.js](https://nodejs.org) or using various command-line tools. Mac users can install Node.js using [Homebrew](https://brew.sh/) using the command `brew install node`.
1. Install [Visual Studio Code](http://code.visualstudio.com).
1. Install the [Azure App Service Tools](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azureappservice) using the VS Code Extensions Palette (search for *azure*).
1. Once you have installed Visual Studio Code and the App Service Tools extension, open Visual Studio Code. In Code, use `Ctrl-Shift-P` (or `Cmd-Shift-P` on a Mac) to open up the command palette. Type the word `path` to filter the command menu, and then select the command **Install 'code' command in PATH** to make it easy to open Visual Studio Code from your command line. 

    ![Installing code to your path](media/01-setup.png)

## Demo Steps

- [Express MVC Web App Scenario](express/) - Contains the end-to-end demo steps. 