---
title: Node.js and Express Continuous Deployment with Visual Studio Team Services and Azure App Services
layout: page
sidebar: vsts
permalink: /labs/vsts/nodejs/express/
folder: /labs/vsts/nodejs/express/
---

[Express](https://expressjs.com/) is a minimal, flexible web application framework for Node.js developers that provides a robust set of features for both web and mobile web developers. The [Express package](https://www.npmjs.com/package/express) is available via [NPM](https://www.npmjs.com/), easily installable into any Node.js application using the command `npm install express`. In most cases Express needn't be installed as a global package using the `-g` NPM switch, as the convention is that Express is installed independently into each Node.js app during development. 

This demo will walk you through the process of creating a new Node.js web app that uses Express. Then you'll create a new Visual Studio Team Services project to use for storing the code and continuously deploying the app to Azure App Service. A video of the end-to-end demo is below. 

<a href="https://www.youtube.com/watch?v=VN_ZvlCZ_kc"><img src="../media/09-video-box.png" /></a>

## Scaffolding a new Express app using Yeoman

To ease the process of bootstrapping a Node.js Express application, developers can use the [Yeoman](http://yeoman.io) template engine. Yeoman - known as **yo** from it's NPM CLI command name - has hundreds of scaffolders for all sorts of projects. Luckilly, Yeoman is easilly installable as an NPM package just like Express and many other Node.js components. 

### Install Yeoman and the Express generator

1. Run the command `npm install -g yo`. 

   > Talk track: Yeoman can be installed easily using NPM. In some cases `sudo` might be required, based on your local NPM environment settings. If your permissions require it, use the command `sudo npm install -g yo`. 

   <img src="../media/01-install-yo.png" width="624"/>
   
2. Type `yo` at the command prompt.

   > Talk track: Yeoman provides some on-screen help. To search for a package if you're not sure of the name, select the option **Install a generator** as shown below. 

   <img src="../media/02-install-a-generator.png" width="624"/>
      
3. Type `express` at the prompt and hit enter to search the Yeoman template database for Express-related scaffolders. 

   <img src="../media/03-find-express.png" width="624"/>
      
4. Scroll through the list of results until you see the generator named, simply, **express**, and then hit enter. 

   > Talk track: Yeoman should install the Express generator and present a confirmation message.

   <img src="../media/04-express-selected.png" width="624"/>
      
5. Once this completes, hit `Ctrl-C` to close the Yeoman instance. 

   > Talk track: Now the development environment is set up and ready for the creation of a new web app built using Node.js and Express whenever you need. The next step is to actually generate a new app. 

   <img src="../media/05-express-installed.png" width="624"/>
      
### Generate a Skeleton Express app

1. In the command prompt, enter the command `yo express` to create a new Express application. 

    > Talk track: It is usually wise to create a new directory in which the command is executed to have a clean starting point. Yeoman will ask a series of questions about your preferences for the app. You can vary this selection based on your preferences. 

    <img src="../media/07-express-generator-options.png" width="624"/>
        
2. Enter the command `code .` to start Visual Studio Code with the new Express app's folder open. 

    <img src="../media/08-code-command.png" width="624"/>
        
3. Edit `gulpfile.js` to turn off local hosting during the Gulp build. The code for the `default` task should be commented out: 

    ```javascript
    gulp.task('default', [
        //'develop'
    ]);
    ```

    > Talk track: [Gulp](https://gulpjs.com/) is a popular JavaScript build tool used by Node.js developers to automate the workflow of building web apps. The Express generator bootstraps using either Gulp or [Grunt](https://gruntjs.com/), another popular JavaScript build tool. Both Gulp and Grunt are supported by individual build steps in Team Services, so either popular framework will work out of the box with VSTS and Azure. 

    > **Note:** Keep VS Code open after you make this code change, as in the next step we'll use the Azure Tools extension to create a new App Service to host our Node.js code. 

## Create an Azure App Service using VS Code

There are a number of various extensions for VS Code that provide Azure functionality. Extensions like the [Azure CLI Tools](https://marketplace.visualstudio.com/items?itemName=ms-vscode.azurecli) make it easy to write scripts that make use of the [Azure CLI](http://docs.microsoft.com/cli/azure) to perform administrative tasks in your Azure nn. The [MS SQL](https://marketplace.visualstudio.com/items?itemName=ms-mssql.mssql) extension gives SQL querying capability. 

The [Azure Tools for VS Code](http://aka.ms/vscodeazuretools) provide a series of convenient features for creating new Azure resources. We'll use the Azure Tools for VS Code in this next section to login to an Azure subscription and create a new Azure App Service, all within VS Code. 

### Login to your Azure subscription

1. Hit `Ctrl-Shift-P` (or `Cmd-Shift-P` on Mac) to open the command palette in VS Code. Type the word `login` to pull up the `Azure Login` command. 

    > Talk track: The Azure Tools for VS Code add convenient commands to the VS Code editor that streamline various Azure tasks, like logging in and creating App Services. The first step we'll need to do is to login to our Azure subscription within VS Code. 

    > **Note**: If you want to login using a Microsoft account (hotmail.com, live.com, outlook.com), you'll need to set the `azure.tenantId` configuration property in your VS Code user settings. There is documentation on the Azure Tools extension [marketplace page](http://aka.ms/vscodeazuretools) describing how to do this. 

    <img src="../media/18-vscode-login.png" width="624"/>
        
2. Click the **Sign in** button to open the web page. 

    > Talk track: VS Code will get a login token and direct you to the device login page. Once there, you'll be able to simply paste in the login code from your clipboard. 

    <img src="../media/19-login-result.png" width="624"/>
    
3. Once the device login page opens put the cursor into the text box. 

   <img src="../media/20-devicelogin.png" width="624"/>
   
4. Hit `Ctrl-V` or `Cmd-V` on Mac, or use the context menu to paste the login code into the textbox. 

   <img src="../media/21-paste-code.png" width="624"/>
   
5. Click the **Continue** button to perform the login routine. 

    > Talk track: Once you click Continue, you'll be able to select which of the organizational or Microsoft accounts you want to use to login to your Azure subscription. 

    <img src="../media/22-loggedin.png" width="624"/>
    
6. Once the login page loads, flip back to VS Code and you'll see the login success information message in the editor. 

   > Talk track: Now that VS Code is logged in to your Azure subscription, other commands can be executed against it to do things like create App Services or to list your Azure resources in the editor.

   > Once you are logged in you have access to all Azure geographic regions, and if you have multiple Azure subscriptions you should have access to each of them from within VS Code. 
    
   > Currently, the login isn't persisted between VS Code instances. When you close VS Code your login will be terminated, and you'll need to login to your subscription again when you re-open VS Code. 

   <img src="../media/23-notification.png" width="624"/>
   
## Create the App Service Web App

To setup continuous deployment to an Azure App Service, an Azure App Service resource must be created into which code can be deployed. Luckilly, Visual Studio, Visual Studio for Mac, and Visual Studio Code all make this a rather easy task directly within the various IDEs. 

1. In VS Code, use the `Ctrl-Shift-P` (or `Cmd-Shift-P` on a Mac) keystroke to once again open the command palette. Type the phrase `web app` to filter the list of commands to those related to Azure App Service Web Apps. 

    > Talk track: VS Code provides two options here - simple and advanced. Simple will create all the resources you need for a single App Service - the resource group, hosting plan, and actual App Service - all at once using the name you provide. The Advanced process will allow you to pick an existing Resource Group and/or Hosting Plan to use for your new App Service. 

    <img src="../media/24-create-site.png" width="624"/>
    
2. Type in a name for the App Service. Note, if an existing App Service with this name exists you'll be informed with an error message. 

    <img src="../media/25-new-site-name.png" width="624"/>
    
3. Once the App Service is created VS Code will show you a confirmation message to let you know the site is created. 

    <img src="../media/26-new-site-created.png" width="624"/>
    
## Viewing the new App Service in the Azure Portal

1. In VS Code, use the `Ctrl-Shift-P` (or `Cmd-Shift-P` on a Mac) keystroke to once again open the command palette. Type the phrase `browse` to filter the list of commands to those related to browsing resources or resource groups in the Azure portal. 

    > Talk track: The Azure Tools for VS code provide some convenient features like "Browse Resource" and "Browse Resource Group" directly from the command palette. These commands make it easy to get to the Azure portal "blade" for a specific resource. 

    <img src="../media/27-browse-resource-command.png" width="624"/>
    
2. Typing the name of the resource you want to view filters the list in the editor. 

    <img src="../media/28-search-resource-name.png" width="624"/>
    
3. Once you select a resource to view within VS Code it'll open directly in the Azure portal in your default browser. Click the link in the portal's overview section to open the new App Service in a separate tab. 

    > Talk track: By opening the new App Service up in the Azure portal I have access to all of the settings and configuration features the Azure portal offers. If I want to set up a deployment slot, add a WebJob, or change an environment variable, I can do all of these things directly within the Azure portal. 

    > I can also click the link to my new App Service to open it up in my browser. 

    <img src="../media/29-resource-in-portal.png" width="624"/>
    
4. The App Service should open in your browser, displaying the default App Service start page. 

    > Talk track: The start page has a helpful video walking through some of the features and details of App Service. Once you deploy custom code to your App Service, the start page will stop rendering, and your custom code will begin rendering instead. 

    <img src="../media/30-start-page-in-browser.png" width="624"/>
    
## Use Team Services to Enable Continuous Deployment

Now that the app is ready to be deployed we'll set up a new Team Services project and set it up with Git so the code can be easily committed and continuously deployed. 

### Create the new Team Services Project 

1. Browse to your Team Services account at [https://{youraccount}.visualstudio.com](https://{youraccount}.visualstudio.com). Give the project a name and click **Create**. 

    > Talk track: A VSTS project is used to track your source code, work items, and builds. If you don't have any existing projects the screen below will be displayed. If you already have any projects, click the **New Project** button to pull up this screen. 

    <img src="../media/10-new-vsts-project.png" width="624"/>
    
2. If you haven't already created Git credentials click the **Generate Git credentials** button, then provide a username and password to be used when interacting with this project. Then, click the **Copy clone url to clipboard** button as shown below. 

    > Talk track: In this step you'll copy the Git repository URL to your clipboard so that you can use it from the command line to set up your Git repository's remote. This enables you to be able to push your code from the development machine to your VSTS instance. 

    <img src="../media/11-copy-clone-url.png" width="624"/>
    
3. At a command prompt in your project's folder, type the command `git init` to initialize a new repository locally. Then, type `git remote add origin {copied URL}` to add the remote to your local repository. Then, `add` and `commit` the files to the repository. Finally, use `git push origin master` to push the Express app code up to the VSTS project's Git repository. 

    > Talk track: VSTS supports the popular Git source control mechanism in addition to the native Team Services source control provider. As quickly as your code is committed to the project, it can be deployed using commit triggers. All the power and versatility of Git is available with any of your new VSTS projects. 

    <img src="../media/12-git-commit.png" width="624"/>
    
4. Click on the **Code** tab in your Team Services browser. 

    > Talk track: Note the button in the code tab labelled **Set up build**. This gives us one-click access to where we can create a new build definition to enable Continuous Integration and Deployment. 

    <img src="../media/13-code-displayed.png" width="624"/>
    
### Create the Build Definition

1. Click the **Set up build** button in the **Files** page in the browser. 

    <img src="../media/14-click-the-button.png" width="624"/>
    
2. Find the build template named **NodeJS with Gulp** and click the **Apply** button. 

    > Talk track: This will create a build definition with some standard build steps conventional in any Gulp-based Node.js build process. You'll be able to customize any of these steps once the definition is created. 

    <img src="../media/15-start-with-gulp.png" width="624"/>
    
3. Give the build definition the name `DevDeploy` and select **Hosted** from the **Default agent queue** menu. 

    > Talk track: We'll use the `Hosted` build agent queue here since our build will need Node and NPM to build. The `Default` build agent may not always have these items available, but `Hosted` agents will. 

    <img src="../media/16-name-select-hosted.png" width="624"/>
    
4. Click the **Copy Publish Artifact: drop** build task to see the details of this task. 

    > Talk track: Note the **Copy Root** and **Contents** items in this build task. These allow you to specify where the build drop will be stored once the build is completed. You'll make use of this build drop in the next step when we wire up the continuous deployment build task. 

    <img src="../media/17-drop-file.png" width="624"/>
    
5. Click the **Add Task** button under the list of build tasks. Select the **Azure App Service Deploy** task and click the **Add** button next to it. 

    > Talk track: Now that the Express app is being built by the build definition using NPM and Gulp we can specify the Azure App Service to which it'll be deployed during Continuous Deployment. 

    <img src="../media/31-new-app-service-deploy-task.png" width="624"/>
    
6. Note that the **Azure subscription** and **App Service name** menus are both required.

    > Talk track: If you don't already have an Azure subscription specified you can click the gear icon next to the Azure subscription menu. This will give you access to the Service connections area in your Team Service account instance where Azure connections can be added. 

    <img src="../media/32-select-sub.png" width="624"/>
    
7. Select the Azure subscription in which your destination App Service is housed. 

    > Talk track: You can add as many Azure subscriptions here as you need, and your builds would be able to deploy to any App Service in any of your subscriptions. 

    <img src="../media/33-sub-menu.png" width="624"/>
    
8. Select the App Service you created earlier within VS Code to use as the deployment target for your Node.js source code. 

    > Talk track: All of your App Services in the selected subscription will appear here.

    <img src="../media/35-app-selected.png" width="624"/>
    
9. Click the previous build task (the "Copy Publish Artifact: drop" task) and take note of the **Copy root** and **Contents** text boxes. 

    > Talk track: As mentioned earlier, the drop file location and filename text boxes will be used together to build the actual location of the ZIP file containing your build's source code. You'll want to copy these two values as you'll want to paste them into the Deploy build task. 

    <img src="../media/36-copy-build-file-path.png" width="624"/>
    
10. Once you've copied these two value and pasted them both into the Deploy build task, the value of the task's **Package or folder** textbox should represent the full path the ZIP file being built by your VSTS build. 

    <img src="../media/37-paste-build-file.png" width="624"/>
    
11. Check the checkbox labelled **Generate Web.config** to enable that section of the task window. Then click the ellipse button next to the text box to open up the **Web.config parameters** dialog. 

    > Talk track: App Service uses the Web.config file to know how to start up the Node.js app. In order to properly kick off the App Service code on each request, the Web.config file needs to have the correct JavaScript file name identified as the "start point" for this app. 
    
    > Luckilly, the Team Services App Service Deploy task takes this into account and provides a simple method of editing the file so that it's specific to Node.js applications.

    <img src="../media/38-need-web-config-changes.png" width="624"/>
    
12. Select **node** from the Web.config parameters screen's **Application framework** menu. Then, change the **NodeStartFile** value to be `app.js` since the Express app's default filename is `app.js`.

    <img src="../media/39-specify-app-js-filename.png" width="624"/>
    
### Run the Build

Now the build definition is complete running it will result in the code being deployed to the Azure App Service. 

1. To kick off the manual build, click the **Save and Queue** spin button in the build definition page. Then, select the **Save and queue** option to save the definition and trigger the build. 

    <img src="../media/40-save-and-queue.png" width="624"/>
    
2. Click the **Queue** button on the **Queue build for deploy** dialog. 

    > Talk track: Clicking this will result in the dialog closing, and the build will begin. When it does you'll see a notice in the build definition page with a link to monitor the running build. 

    <img src="../media/41-queue-window.png" width="624"/>
    
3. Click the queued build link to drill into the running build. 

    > Talk track: Now I'll drill into the build I just triggered. 

    <img src="../media/42-build-queued-notification.png" width="624"/>
    
4. The build log is visible in the browser. 

    > Talk track: The Team Services build window shows the current build as it is running, with color-coding intact for Information, Error, and Verbose content levels. 

    <img src="../media/43-build-running.png" width="624"/>
    
5. Wait until the build has completed. 

    > **Note**: This may take some time (2-3 minutes or more) so it'd be a good opportunity to take questions, have a side demo or pre-deployed instance lined up, or something like that. 

    <img src="../media/44-build-completed.png" width="624"/>
    
6. Open up a browser (or refresh the already-open browser tab) on the App Service URL. 

    > Talk track: Startup page is gone and the default Express template code is displayed. Now whenever I perform this build again the site will be updated automatically. 
    
    > I could clone this build definition, aim it at another App Service, and enable multiple-environment support in my end-to-end build pipeline. 
    
    > As you'll see in a moment, builds can be triggered due to a variey of different triggers. 

    <img src="../media/45-app-deployed.png" width="624"/>
    
### Enabling triggered builds

1. Click the **Triggers** tab in Team Services. 

    > Talk track: In this demo we'll take a look at how a build trigger can be created to fire the build whenever the source code is updated. 
    
    > Enabling on-commit builds is as easy as toggling a button and specifying a branch.  

    <img src="../media/46-enable-trigger.png" width="624"/>
    
2. Edit the code in `controllers/home.js` so that the `articles` variable in the `get` method is instantiated using the code below. 

    > Talk track: I'll add some code to the controller to hand back a real model. 

    ```javascript
    var articles = [
        new Article({
        'title': 'First Article',
        'text' : 'This is the text of the first article'
        }),
        new Article({
        'title': 'Second Article',
        'text' : 'This is the text of the second article'
        })
    ];
    ```

    <img src="../media/47-edit-controller-code.png" width="624"/>
    
3. Edit the code in `view\index.handlebars` to add a `dl` list containing a presentation of the articles in the view model. 

    > Talk track: Now I'll update the vide to show the collection. 

    ```handlebars
    <dl>
        {{ "{{#each articles"}}}}
        <dt>{{title}}</dt>
        <dd>{{text}}</dd>
        {{/each}}
    </dl>
    ````

    <img src="../media/48-edit-view-code.png" width="624"/>
    
4. Commit the code to the repository. 

    > Talk track: By committing the code change to the repository I'll trigger the build, which will re-deploy the code to Azure App Service. 

    <img src="../media/49-commit-to-git.png" width="624"/>
    
5. Go back to the build definition in Team Services and take note that a new build has been queued. 

    > Talk track: As soon as I committed the code and pushed the changes into my Team Services Git repository, the build was automatically triggered. This enables continuous deployment on code updates to my App Service. 
    > 
    > If continuous deployment isn't your thing, you could also enable a triggered build, so that code could be deployed once a day, a week, or however often you need. 

    <img src="../media/50-new-build-queued.png" width="624"/>
    
6. Refresh the site in the browser. 

    > Talk track: Once the build completes I can refresh my browser and see that the changes have taken place right away. 

    <img src="../media/51-new-changes-deployed.png" width="624"/>
    