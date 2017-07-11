---
title: Maven Package Management with Visual Studio Team Services
layout: page
sidebar: mydoc_sidebar
permalink: /labs/java/mavenbuild/
folder: /labs/java/mavenbuild/
comments: true
---

In this exercise, you are going to clone a Github repo into VSTS. This repo contains a class library (MyShuttleCalc) that is used by the MyShuttle2 application. You will configure a VSTS build to publish the MyShuttleCalc package to a VSTS Maven Package feed so that it can be consumed by MyShuttle2 and any other applications that require the calculation code.

This exercise assumes you have completed the exercises to create a Team Project and have set up the Docker private VSTS agent. This exercise uses a team project named **jdev**, though your team project name may differ.

> **Note**: It is not necessary to clone Github repos into VSTS. VSTS will work just fine with Github (or other Git hoster)  repos. However, some linkages from source code to other aspects of the DevOps pipeline (such as work items, builds or releases) work best if the code is in VSTS.

> **Note**: This exercise shows how to do a Maven build using just VSTS. To see how to perform a Maven build using Jenkins that still integrates into the VSTS Package Feed, please refer to [Maven Package Management with VSTS Team Build](./Maven Package Management with VSTS Team Build,md).

Importing the MyShuttleCalc code from Github into VSTS
------------------------------------------------------

In this task you will import the MyShuttleCalc code from Github into VSTS. If you have already done so, skip this step.

1. Connect to the virtual machine with the user credentials which you specified when creating the VM in Azure.
1. Open Chrome and browse to `http://<youraccount>.visualstudio.com` (where `youraccount` is the account you created in VSTS).
1. Click on the `jdev` team project to navigate to it. Click on Code in the blue toolbar at the top to open the Code Hub.
1. Click on the repo drop-down in the upper left (in the grey toolbar) and select "New repository".

    <img src="./images//import-repo.png" alt="Import a repository in the Code Hub"/>

1. Enter the following url: `https://github.com/nwcadence/MyShuttleCalc.git` and click Import.

    <img src="./images//import-repo-url.png" alt="Enter the URL/>

1. After a few moments, the code will be imported.

Create a Maven Package Feed
---------------------------

In this task you will create a Maven package feed. You will publish packages to this feed as well as consume packages from this feed.

1. In VSTS, click on "Build & Release" and then Packages to go to the Package Hub. Click "+ New Feed" to create a new feed.

    <img src="./images//vsts-create-feed.png" alt="Create a new feed/>

1. Enter "Maven" for the feed name and click "Create".

<img src="./images//vsts-new-feed.png" alt="Create the new feed/>

You now have a feed that you can publish package to.

Clone the MyShuttleCalc repo
----------------------------
In this task you will clone the MyShuttleCalc repo. This repo contains a Maven package settings file that you will need to authenticate to the Maven feed. If you have already done so, skip this step.

1. Click on the IntelliJ icon in the toolbar to open IntellJ IDEA.

    <img src="./images//click-intellij.png" alt="Click IntelliJ in the Toolbar/>

1. Click "Check out from Version Control" and select "Team Services Git".

    <img src="./images//intellij-open-from-vsts.png" alt="Checkout from Team Services Git/>

> **Note**: (If you have a project open, then you can also click File->New->Project from Version Control->Team Services Git)

1. Click on "Sign in..." to sign in to your VSTS account.

    <img src="./images//intellij-vsts-signin.png" alt="Sign in to VSTS/>

1. Once you have authenticated, enter "MyShuttleCalc" into the search bar and select the MyShuttleCalc repo from your team project. Click the Clone button to clone the repo to the VM.

    <img src="./images//intellij-select-repo.png" alt="Select the VSTS repo/>

1. IntelliJ detects a Maven project file (pom.xml) and asks if you want to open it. Click "Yes" to open the project.

Create a Maven Settings File with the Feed Credentials
------------------------------------------------------

In this task you will create credentials for the Maven feed. You will then create a settings.xml file containing the credentials.

1. In the Packages Hub, make sure you have selected the Maven feed and click "Connect to Feed".
1. In the left menu, click on Maven.

> **Note**: At the time of writing, Maven package feeds are a preview feature. You will need to enable the Maven package feed feature in order to connect to Package Management to/from Maven.

1. Click "Generate Maven Credentials"

    <img src="./images//maven-generate-creds.png" alt="Generate Maven Credentials/>

1. VSTS creates a credentials snippet. Click the Copy to Clipboard button to copy the snippet to the clipboard.

    <img src="./images//maven-creds.png" alt="Copy the Maven Credentials/>

1. In IntelliJ, open the `MyShuttleCalc\maven\settings.xml`.
1. Delete the comment `<!-- paste maven package feed credentials section here !-->` and replace it with the snippet between the `<servers>` and `</servers>` tags so that the final result looks like this:

    <img src="./images//maven-paste-creds.png" alt="Paste the Maven Credentials/>

1. Press Ctrl-S (or File->Save) and save the file.
1. In VSTS, go back to the Connect to Feed dialog on your Maven feed. Click on the copy button in the section labeled `Add this feed to your project pom.xml inside the <repositories> tag`.

    <img src="./images//maven-packagefeed-settings.png" alt="Get the package repository settings from VSTS/>

1. In IntelliJ, open the `pom.xml` file. Update the `<repositories>` tag as well as the `<distributionManagement>` tag so that they point to your feed.

    <img src="./images//pom-repo.png" alt="Updating the repo settings in pom.xml/>

1. Click VCS->Commit Changes to commit your changes to the repo.

    <img src="./images//vcs-commit.png" alt="Commit changes/>

1. Enter "Adding maven credentials" to the commit message.
1. Click the drop-down next to the Commit button and select "Commit and Push".

> **Note**: If this is your first commit to VSTS, you will be prompted to update your display name and email address for the repo. These are simply for display purposes, but usually are matched to your VSTS profile.

1. Copy the maven settings file to the .m2 directory so that local Maven operations will succeed by running the following command in a terminal:

```sh
cp ~/MyShuttleCalc/maven/settings.xml ~/.m2/
```

Creating a VSTS Build for Publishing a Maven Package
----------------------------------------------------

In this task you will create a build that will publish the MyShuttleCalc library to the Maven feed.

1. Open VSTS and connect to your team project. Click on the Build & Release Hub and then click Builds. Click on +New to create a new build definition.

    <img src="./images//new-build.png" alt="New build definition/>

1. In the templates window, type "maven" into the search box. Click apply on the Maven template.

    <img src="./images//maven-template.png" alt="Apply the Mavent template/>

1. In the Process page, change the name of the build to "MyShuttleCalc".

    <img src="./images//process-name.png" alt="Change the name/>

1. Click on Options.
1. Update the Build number format to `0.0$(rev:.r)` and update the build queue to `default` (this is the queue that the VSTS agent in the container is joined to).

    <img src="./images//build-options.png" alt="Build options/>

1. Click on Tasks. Click on the Maven task. Edit the following settings:

| Field | Value | Notes |
|---|---|---|
| Options | `--settings ./maven/settings.xml` | Required to authenticate when pushing the Maven package to the feed. |
| Goal(s) | `deploy -Dbuildversion=$(Build.BuildNumber)` | Tell Maven to publish the package |
| Code Coverage Tool | `JaCoCo` | Change the code coverage format |
| Source Files Directory | `src/main` | These files must be included in the coverage results |

    <img src="./images//maven-task-opts.png" alt="Maven task options/>

1. Click Save and Queue. Accept the defaults to queue the build.
1. A green status bar indicates that the build has been queued. Click the build number to follow the logs in real time.

    <img src="./images//click-build-number.png" alt="Open the build logs/>

1. When the build completes successfully, you can click on the build number to view the summary. Note the test results and code coverage.

    <img src="./images//build-summary.png" alt="Build summary page/>

> **Note**: Each time you run the build, the patch number (the last of the 3-digit version numbers) will increment. In the image above, the build has run 6 times so the latest build number is 0.0.6. The package version matches the build number because we supplied the build version number to Maven in the Maven task.

1. Navigate back to the Maven package feed. There you will see the MyShuttleCalc package.

    <img src="./images//package-in-feed.png" alt="The MyShuttleCalc package in the feed/>

