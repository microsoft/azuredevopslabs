---
title: Working with Eclipse
layout: page
sidebar: vsts1
permalink: /labs/vstsextend/eclipse/
folder: /labs/vstsextend/eclipse/

---
Visual Studio Team Services  helps teams modernize their application development lifecycle and go from idea to deployment with continuous integration, testing, and deployment for any app targeting any platform. 

VSTS works with (m)any development tool including Visual Studio, Eclipse, IntelliJ, Android Studio, XCode, etc., to make it easy for developers to use VSTS.

This lab will walk you through a typical end-to-end workflow for a Java developer using VSTS and working with Eclipse. We will use a hypothetical customer called MyShuttle that provides a portal for its drivers to access travel history and see fares collected. This is a  Java application built on JSP/Servlet technology running on Apache Tomcat and using MySQL as the database. We will develop this on a Ubuntu desktop station and we will deploy the app on Azure.

In this lab, you will   
* Provision a VSTS project with some sample data and users 
* Provision a Ubuntu based VM with Eclipse installed
* Install and explore **Team Explorer Everywhere** , the VSTS plug-in for Eclipse
* Setup a build definition to build and test the code, then push it to a Azure Container Registry
* Setup an Azure Web app and configure a CD pipeline in VSTS

**Estimated time to complete the lab:**  1 hour

## Pre-requisites

1. **Microsoft Azure Account**: You need a valid and active azure account for the labs.

1. You need a **Visual Studio Team Services Account** and [Personal Access Token](https://docs.microsoft.com/en-us/vsts/accounts/use-personal-access-tokens-to-authenticate)

1. You will need a desktop station. Click on **Deploy to Azure** to provision a Ubuntu VM pre-installed with Eclipse, Docker, Jenkins, and all other software required to run this lab.

    <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoft%2FVSTS-DevOps-Labs%2Feclipse%2Feclipse%2Farm%2520template%2Fazuredeploy.json" target="_blank">
<img src="http://azuredeploy.net/deploybutton.png"/>
</a>

1. Once the machine is provisioned, you can RDP to it. From the **Overview** tab of the virtual machine, note the **DNS Name** and use *Remote Desktop* program to connect and log in

1. Log in with the user name and password provided.

## Exercise 1: Setting up VSTS project

1. Use <a href="https://vstsdemogenerator.azurewebsites.net" target="_blank">VSTS Demo Data Generator</a> to provision a project on your VSTS account.

1. Select the **MyShuttle-Java** for the template.

 ![VSTS Demo Generator](images/vstsdemogen.png)

3. Provide a project name and click **Create Project** to start provisioning. Once the project is provisioned, select the URL to navigate to the project that you provisioned.

1. You will see the work items, source code and CI/CD definitions already populated by the demo generator.
    ![VSTS Dashboard](images/vstsdashboard.png "MyShuttle Project in VSTS")

1. Navigate to the **Code** hub. You will notice we have two code repositories: One with the same name as your project - this repo contains the code for the web application and the other one **MyShuttleCalc** - contains the code for a class library  that is used by the MyShuttle application

    ![VSTS Code Repo](images/vstscoderepo.png "MyShuttle Code Repositories in VSTS")

Having VSTS setup, we will now log in to the virtual machine and set up Eclipse 

## Exercise 2: Setting up Eclipse

1. If you have not already, log in to the virtual machine

1. Click on the Eclipse icon in the toolbar to open the Eclipse Java IDE.

    ![Click Eclipse in the Toolbar](images/click-eclipse.png "Click Eclipse in the Toolbar")

1. The first time you run Eclipse, it will prompt you to choose a workspace. Specify a folder and click on the box **"Use this as the default and do not ask again"** if you want to Eclipse use that as default and not prompt you again.

1. We will install **Team Explorer Everywhere (TEE)**, the official plug-in for Eclipse from Microsoft to connect VSTS/TFS with Eclipse-based IDE on any platform. It is supported on Linux, Mac OS X, and Windows and is compatible with IDEs that are based on Eclipse 4.2 to 4.6.

1. After Eclipse has started, select **Help** | **Install New Software** to bring the install dialog page

1. Choose the **Add** button to add a new repository.  Use Team Explorer Everywhere as the name and specify *http://dl.microsoft.com/eclipse* for the location  

    ![Add Repository](images/AddRepository.cropped.png "Add Repository")

1. Choose the **OK** button.

1. In the list of features in the Install dialog box, select the check box that corresponds to the Team Explorer Everywhere plugin. 

    ![Select Team Explorer Everywhere](images/SelectTee.cropped.png "Select Team Explorer Everywhere")

    >**Note:** If you don't see this option, use the pull-down menu for "Work with:" and find the update site URL you just entered in the list and select it, then select the check box beside the plug-in mentioned above.

1.  Choose **Next** to follow the wizard to complete the installation. 

1.  Eclipse will need to restart. When Eclipse restarts,choose **Windows > Show View** and select **Other...**

1. Search for **Team Explorer**, select the **Team Explorer** View, and select **OK**.

    ![Checkout from Team Services Git](images/showtee2.png "Checkout from Team Services Git")

1. From the **Team Explorer** view, choose the radio button next to **Connect to a Team Foundation Server or Team Services account** then type in the name of the VSTS account (`https://{your-account-name}.visualstudio.com`) and press the **Next** button

    The "Follow the instructions to complete sign-in" window will pop up. Click on the hyperlink to be redirected to the Device Login page in a browser on the VM (Note that link may have a black background for security purposes). 

1. Log in to authenticate yourself. 

1. Return back to Eclipse, press the OK button in the device login window. The VSTS account should now show up in the list of servers to connect to. Press the **Close** button to close the current window.


## Exercise 3a: Clone MyShuttle from VSTS with Eclipse

Next, we will clone the two repositories that we have in VSTS, to a local Git repository. First, lets clone the repo that has the web application code.

1. In the **Team Explorer** panel, choose **Git Repositories**. This will list all the Git repositories in the project. 

1. Right-click the **MyShuttle2** repo in the team project and select **Import Repository**

    ![Select the VSTS repo](images/eclipse-select-repo.png "Select the VSTS repo")

    ![Select the VSTS repo](images/eclipse-select-repo2.png "Select the VSTS repo")

    Leave the defaults for the parent directory and repo folder name, then press the next button. This will clone the repo onto the VM.  

    ![Select the VSTS repo](images/eclipse-select-repo3.png "Select the VSTS repo")

1. We do not have any saved Eclipse projects in the repo. So, we can close the wizard now. We will instead import the project as a Maven project instead of Eclipse project. In the **"Import Projects from Team Foundation Server"** window, click the **Cancel** button.

    ![Select the VSTS repo](images/eclipse-importprojects.png "Select the VSTS repo")

1. The code has been cloned to the local repo. We can import from there. In Eclipse, choose **File -> Import...** to open the *Import* window. In the Import window, expand the Maven folder and choose **Existing Maven projects**. Then press the Next button. 

    ![Import the Maven project](images/eclipse-import-existingmavenprojects.png "Import the Maven project")

    For the root directory, click on the Browse button or type in the root directory path of /home/vmadmin/MyShuttle2. The pom.xml file should appear under projects to indicate the Maven project. Additionally, click the checkbox next to **Add project(s) to working set** to add myshuttle to the working set to access in the Package Explorer window as a separate project. Then click the Finish button

    ![Import the Maven project](images/eclipse-select-mavenproject.png "Import the Maven project")

1. Click on **Window -> Show View -> Package Explorer** in the toolbar at the top of Eclipse to view the myshuttle project in Eclipse in Package Explorer (You may have to minimize other windows to view the Package Explorer view cleanly)

    ![MyShuttle project](images/eclipse-myshuttle.png "MyShuttle project")

    > **Note**: The project will not currently compile and there may be build errors temporarily, since it has a dependency on a library (MyShuttleCalc) that it cannot resolve. You will fix this in the Package Management exercise.

### Exercise 3b: Clone the MyShuttleCalc repository

1. Repeat cloning a repository for MyShuttleCalc. Select the **MyShuttleCalc** repo in the team project and right-click the repo and select **Import Repository** 
  
1. Leave the defaults for the parent directory and repo folder name, then press the next button. This will clone the repo onto the VM. In the **Import Projects from Team Foundation Server** window, click the **Cance**l button. We will instead import the project as a Maven project instead of Eclipse project. 

1. Select **File -> Import...** to open the *Import* window. 1. In the Import window, expand the Maven folder and choose "Existing Maven projects." Then press the Next button. 

    >For the root directory, click on the Browse button or type in the root directory path of /home/vmadmin/MyShuttleCalc. The pom.xml file should appear under projects to indicate the Maven project. Additionally, click the checkbox next to "Add project(s) to working set" to add myshuttle to the working set to access in the Package Explorer window as a separate project. Then click the Finish button. 

1. Click on Window -> Show View -> Package Explorer in the toolbar at the top of Eclipse to view the myshuttle project in Eclipse in Package Explorer

    ![MyShuttleCalc project](images/eclipse-myshuttlecalc.png "MyShuttleCalc project")

## Exercise 4: Package Management with VSTS

Next, we will configure a VSTS build to publish the *MyShuttleCalc* package to a VSTS Maven Package feed so that it can be consumed by MyShuttle2 and any other applications that require the calculation code.

1. In VSTS, click on *Build & Release* and then Packages to go to the Package Hub. Click “+ New Feed” to create a new feed.

    ![VSTS Create Feed](images/vsts-create-feed.png "VSTS Create Feed")

1. Enter “Maven” for the feed name and click “Create”.

1. Now have a feed that you can publish package to. Next we will create credentials for the Maven feed. In the Packages Hub, make sure you have selected the Maven feed and click **Connect to Feed**. In the left menu, click on **Maven**.

1. Click **Generate Maven Credentials** to create a credentials snippet. Click the *Copy to Clipboard* button to copy the snippet to the clipboard.

    ![VSTS Maven Feed](images/maven-creds.png)

1. Back in Eclipse, open the `MyShuttleCala\maven\settings.xml`

1.  Delete the comment `<!-- paste maven package feed credentials section here !-->` and replace it with the snippet between the `<servers>` and `</servers>` tags so that the final result looks like this:

1. Press Ctrl-S (or File->Save) and save the file.

1. In VSTS, go back to the Connect to Feed dialog on your Maven feed. Click on the copy button in the section labeled `Add this feed to your project pom.xml inside the <repositories> tag`.

1. In your editor, open the `pom.xml` file. Update the `<repositories>` tag as well as the `<distributionManagement>` tag so that they point to your feed.

1.  Commit your changes to the repo.

1. **Important**: Copy the maven settings file to the .m2 directory so that local Maven operations will succeed by running the following command in a terminal:

    ```sh
    cp ~/MyShuttleCalc/maven/settings.xml ~/.m2/
    ```

1. **Important**: If you have the MyShuttle2 project already open in IntelliJ or Eclipse, close the instance of the IDE and reopen it.

## Exercise 4a:  Publishing the MyShuttleCalc library to the Maven feed.

Next we will run the **MyShuttleCalc** build to build and publish the MyShuttleCalc library to the Maven feed

1. In VSTS, Click on the **Build & Release** Hub and then click **Builds**

1. Select **MyShuttleCalc**. This build definition contains *maven* task with the following settings

    Field | Value | Notes |
    |---|---|---|
    | Options | `--settings ./maven/settings.xml` | Required to authenticate when pushing the Maven package to the feed. |
    | Goal(s) | `deploy -Dbuildversion=$(Build.BuildNumber)` | Tell Maven to publish the package, passing in the build number |
    | Code Coverage Tool | `JaCoCo` | Change the code coverage format |
    | Source Files Directory | `src/main` | These files must be included in the coverage results |


1. Select **Queue new build...**.Accept the defaults to queue the build and wait for the build to complete

1. When the build completes successfully,  Navigate back to the Maven package feed. There you will see the *MyShuttleCalc* package.

## Exercise 4b: Consuming the Package

Next , we will update the pom.xml file for the MyShuttle2 application so that it can consume the MyShuttleCalc package from the Maven package feed.

1. In VSTS, click on the **Build & Release** hub, click on **Packages**and select the Maven feed. Click on **Connect to Feed**. Click on the *copy* button in the section labeled `Add this feed to your project pom.xml inside the <repositories> tag`.

    ![Get the package repository settings from VSTS](images/maven-packagefeed-settings.png)

1. Open the MyShuttle2 project. Click on the **pom.xml** file.

1. In the `<repositories>` element there is a reference to a Maven repo. Paste in the repository settings you got from VSTS.

1. Find the `<dependency>` with `<groupId>com.microsoft.exampledep</groupId>` and update the version number to match the version number of the MyShuttleCalc package in your package feed. This may look something like:

    ```xml
    ...
    <dependency>
      <groupId>com.microsoft.exampledep</groupId>
      <artifactId>MyShuttleCalc</artifactId>
      <version>1.0.6</version>
    </dependency>
    ...
    ```

1. Copy the maven settings file from the MyShuttleCalc project (you updated this file in another lab to include the authentication settings for the Maven package feed). Run the following command in a terminal:

    ```sh
    cp ~/MyShuttleCalc/maven/settings.xml ~/MyShuttle2/maven/


1. You may have to reload the Maven project to update the plugins and dependencies. You can do this by right-clicking on the `myshuttle` working set/project, then selecting **Maven -> Update Project**. Then, keep the checkbox for `myshuttle` checked and press the OK button.

    ![Refresh Maven](images/eclipse-update-project.png)

1. Right-click on the `myshuttle` working set/project, then select Run As -> Maven build.

    ![Build Maven](images/eclipse-maven-build.png)

    In the configuration window, type in "compile" as the Maven Goal then press the Run button.

    ![Build Maven](images/eclipse-maven-configuration.png)

    >Note: Ensure that you have already copied the settings.xml file from MyShuttleCalc to the .m2 folder before you run this. Otherwise, you can specify the settings.xml file in MyShuttle2 by clicking on the "File System..." button to the right of the User settings field in the configuration window to reference a settings file other than in the default .m2 folder.

1. Commit and push your changes through Team Explorer Everywhere.

## Exercise 5:  Create a VSTS Build to Build Docker Images

In this task you will create a VSTS build definition that will create two containers (a mysql database container as well as a tomcat container for running the MyShuttle2 site). The build will publish the containers to the Azure Container Registry you just created.

1. In VSTS, from the **Build** hub, select and edit the **MyShuttle** build. This build definition contains a *maven* task to build the pom.xml file. The maven task has the following settings

    | Parameter | Value | Notes |
    | --------------- | ---------------------------- | ----------------------------------------------------------- |
    | Options | `-DskipITs --settings ./maven/settings.xml` | Skips integration tests during the build |
    |Code Coverage Tool | JaCoCo | Selects JaCoCo as the coverage tool |
    | Source Files Directory | `src/main` | Sets the source files directory for JaCoCo |

      ![Maven task settings](images/vsts-mavensettings.png)

1. Then there is **Copy** and **Publish** tasks to copy the artifacts to the staging directory and publish to VSTS (or a file share).

1. Next we use the **Docker Compose** task to build and publish the images. The settings of the Docker compose tasks are as follows:
    | Parameter | Value | Notes |
    | --------------- | ---------------------------- | ----------------------------------------------------------- |
    | Container Registry Type | Azure Container Registry | This is to connect to the Azure Container Registry you created earlier |
    | Azure Subscription | Your Azure subscription | The subscription that contains your registry |
    | Azure Container Registry | Your registry | Select the Azure Container registry you created earlier |
    | Additional Image Tags | `$(Build.BuildNumber)` | Sets a unique tag for each instance of the build |
    | Include Latest Tag | Check (set to true) | Adds the `latest` tag to the images produced by this build |

1. Click the "Save and Queue" button to save and queue this build.Make sure you are using the **Hosted Linux Agent** 

## Deploying to an Azure Web App for containers

In this exercise, we will setup a CD pipeline to deploy the web application to an Azure web app. First, let's create the Web App   

1. Sign into your [Azure Portal](https://portal.azure.com)

1. In the Azure Portal, choose **New, Web + Mobile** and then choose **Web App for Containers**

     ![New Web App for Containers](images/newwebapp.png)

1. Provide a name for the new web app, select existing or create new resource group for the web app. Then select **Configure Container** to specify the source repository for the images. Since we are using ACR to store the images, select **Azure Container Registry**. Select the **Registry, Image and Tag** from the respective drop-downs.Select **OK** and then select **Create** to start provisioning the web app

    ![Creating MyShuttle Web App for Containers](images/myshuttle-webapp.png)

1. Once the provisioning is complete, go to the web app properties page, and select the URL to browse the web app. You should see the default **Tomcat** page

1. Append **/myshuttledev** the web application context path for the app, to the URL to get to the MyShuttle login page. For example if your web app URL is `https://myshuttle-azure.azurewebsites.net/` , then your URL to the login page is `https://myshuttle-azure.azurewebsites.net/myshuttledev/`

    ![Login Page](images/loginpage.png)

    We could configure *Continuous Deployment* to deploy the web app is updated when a new image is pushed to the registry, within the Azure portal itself. However, setting up a VSTS CD pipeline will provide more flexibility and additional controls (approvals, release gates, etc.) for application deployment

1. Back in VSTS, select **Releases** from the **Build and Release**hub. Select **+** and then **Create Release Definition**

1. Select **Pipeline**. Click **+Add** to add the artifacts. Select **Build** for the source type. Select the **Project**, **Source** and the **Default version**.  Finally select **Add** to save the settings

1. Select the **Azure App Service Deployment** template and click **Apply**
    ![VSTS Add Artifact](images/vsts-cd-addartifact.png)

1. Open the environment. Select **Environment 1** and configure as follows

    * Pick the Azure subscription
    * Select **Linux App** for the **App Type**
    * Select the **App Service** that you created
    * Enter the **Container Registry** name and then
    * Enter ***Web*** for the **Repository**

    ![VSTS Release Defintion](images/vsts-cd-webapp.png)

1. Select the **Deploy Azure App Service** task and make sure that these settings are reflected correctly. Note that the task allows you to specify the **Tag** that you want to pull. This will allow you to achieve end-to-end traceability from code to deployment by using a build-specific tag for each deployment. For example, with the Docker build tasks  you can tag your images with the Build.ID for each deployment.

    ![Build Tags](images/vsts-buildtag.png)

1. Select **Save** and then click **+ Release | Create Release** to start a new release

1. Check the artifact version you want to use and then select **Create**

1. Wait for the release is complete and then navigate to the URL `http://{your web app name}.azurewebsites.net/myshuttledev`. You should be able to see the login page
