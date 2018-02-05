---
title: Maven Package Management with VSTS and Jenkins
layout: page
sidebar: java
permalink: /labs/java/mavenpmjenkins/
folder: /labs/java/mavenpmjenkins/
comments: true
---

In this exercise, you will configure a Jenkins build to get the source code from the VSTS repo, compile and then publish the MyShuttleCalc package to a VSTS Maven Package feed so that it can be consumed by MyShuttle2 and any other applications that require the calculation code.

This exercise assumes you have completed the exercises to create a Team Project, have set up the Docker private VSTS agent, and imported the MyShuttleCalc and MyShuttle2 GitHub repos into your VSTS team project. This exercise also assumes that you have cloned the repos in either IntelliJ or Eclipse. This exercise uses a team project named **jdev-labs**, though your team project name may differ.

{% include note.html content="This exercise shows how to do a Maven build using Jenkins. To see how to perform a Maven build using just VSTS Team Build that integrates into the VSTS Package Feed, please refer to [**Maven Package Management with VSTS**](../mavenpmvsts/).

<br/>

Port 8080 is not open on the Azure VM for security purposes. However, since a local agent is running in Docker on the VM, it will be able to build and interact with VSTS." %}

## Configure Package Management

Before getting to the build, you will need to create the Maven Package Feed and then update the Maven settings file in the project to specify where to publish the package to. All these instructions are in the [Maven Package Management with VSTS Team Build](../mavenpmvsts) lab. Please complete the following exercises from that lab:

- Create a Maven Package Feed
- Create a Maven Settings File with the Feed Credentials

## Create an SSH Key for Git authentication

In this task you will create an SSH key to authenticate to the VSTS repo. You need to create an SSH key if you do not already have one and then upload the public key to VSTS. The Jenkins job will use the key to authenticate to the repo.

1. On your VM, open a terminal by clicking on the Terminal Emulator icon in the toolbar.

    ![Click on the terminal icon in the Toolbar](images/click-terminal.png)

1. Enter the following command:

    ```sh
    ssh-keygen -C "jdev.com"
    ```

    and press Enter thrice to use the default values for the id_rsa location and an empty pass phrase.

   ![Create an SSH key](images/generate-key.png)

   > The domain is not important - use any value you want. You can also provide a pass phrase, though this will cause a prompt each time you use the key.

1. Enter the following command to print out the public key in the terminal:

    ```sh
    cat /home/vmadmin/.ssh/id_rsa.pub
    ```

1. Select all of the text (from `ssh-rsa` to `jdev.com`), right-click and select "Copy".

1. Go back to Chrome and browse to your VSTS Team Project.

1. Click on your profile image in the upper right. In the menu, click Security.

    ![Click on Security under your Profile image](images/click-security.png)

1. Click on "SSH public keys" and click Add.

1. Enter "jdev" for the Description and then paste into the Key Data the contents of the public key from the clipboard.

    ![Add a new public key](images/add-ssh-key-to-vsts.png)

   > Once you set the SSH credentials, you can use the SSH URL when cloning repositories.

## Configure the Jenkins Maven installation

In this task you will configure the Maven installation settings for Jenkins.

1. On your VM, open Chrome and browse to `http://localhost:8080` to open Jenkins.

1. From the list of links in the left, click **Manage Jenkins**. On the management page, click **Global Tool Configuration**.

1. Scroll the list down to Maven. Click **Add Maven** to add a new Maven installation.

1. Enter `default` as the name. Deselect the **Install Automatically** checkbox and enter `/usr/share/maven` for the MAVEN_HOME property.

    ![Configure the Jenkins Maven installation](images/configure-maven.png)

1. Click Save.

## Create a Maven Job

In this task you will create a Maven job in Jenkins to compile MyShuttleCalc and to deploy the package to the VSTS Package feed.

1. Open your VSTS Team Project in Chrome and click Code to open the Code Hub. Select **MyShuttleCalc** from the list of repos.

    ![Navigate to MyShuttleCalc repo](images/navigate-to-repo.png)

1. In the upper right, click Clone. Switch to the SSH tab and copy the SSH url into the clipboard. 

    ![Copy the SSH url](images/ssh-url.png)

1. Go back to Jenkins in your browser. In the list of items in the left navigation pane in Jenkins, click **New Item**.

1. Enter `MyShuttleCalc` for the item name and click on "Maven Project". Click OK.

1. In the Source Code Management section, select Git. Paste in the SSH url to the MyShuttleCalc repo.

1. Click Add in the Credentials section and select Jenkins.

1. In the dialog, change the "Kind" to "SSH Username with private key".

1. Select the "Enter directly" option under "Private Key".

1. Open a terminal, type `cat ~/.ssh/id_rsa` (or open it in any editor) and paste the contents into the Key textbox. Enter a passphrase (if you used one - otherwise leave it empty). Enter `vmadmin` as the ID. Click Add.

    ![Enter the SSH key info](images/ssh-key.png)

1. Your Source Code Management should now look like this:

    ![Source Code Management](images/sc-management.png)

1. In the Build section, ensure that "Root POM" is `pom.xml`. Set the "Goals and options" to `deploy -Dbuildversion=1.0.${BUILD_NUMBER}`. Click Advanced to expand the advanced settings. Change the **Settings file** to **Settings file in filesystem** and set the **File path** to `maven/settings.xml`. These settings instruct Maven to compile, test and package the code and then publish the package to the repository defined in the settings.xml file that was previously modified to include the authentication token.

    ![Build settings](images/build-settings.png)

1. Scroll down to Post-build Actions. Click **Add post-build action** and select **Record JaCoCo coverage report**. You can leave all the default settings unchanged. This publishes the JaCoCo results for this job.

    ![JaCoCo post-build action](images/jacoco-post-build.png)

1. Add a new post-build action - select **Archive the artifacts**. Set **Files to archive** to `**/MyShuttleCalc*.jar`. This saves the MyShuttleCalc jar file as an artifact from this job.

1. Add a new post-build action - select **Collect results for TFS/Team Services**. This step allows Jenkins to collect test results and coverage results so that they are available to VSTS. Click Add twice to add the two collectors:

    - **Type**: JUnit, **Files to include**: `**/TEST-*.xml`
    - **Type**: JaCoCo, **Files to include**: `**/jacoco/**`

    ![VSTS Results action](images/vsts-post-build.png)

1. Click Save.

## Schedule a Build

In this task you will run the build to ensure that it runs successfully.

1. Click **Build Now** in the links on the left to start a build. Alternatively you can schedule the build from the dashboard by clicking **Schedule build**.

    ![Click schedule build](images/click-schedule.png)

1. Click on the build number to open the build. Click on "Console Output" to view the logs.

1. When the build completes, you can click on **Back to project** to go to the build summary. You should see test and coverage results as well as a link to the jar artifact.

    ![Jenkins build results](images/jenkins-results.png)

1. Navigate to the Maven Package feed in VSTS. You should see the latest package with the version number matching 1.0._jenkins-build-number_.

    ![Package in feed](images/package-feed.png)

## Integrate VSTS Team Build and Jenkins

In this task you will configure a Team Build in VSTS that will trigger the Jenkins job and collect the results. This technique offers the integration between source control, work item tracking,test and release so that you get the output in VSTS even though the build is done in Jenkins.

1. In Jenkins, click on the Jenkins logo to navigate to the dashboard.

1. Click **Manage Jenkins** and then click **Configure Global Security**.

1. In the Access Control section, select **Jenkin's own user database** and select **Allow users to sign up**. Ensure User Authorization is selected for **Anyone can do anything**.

    ![Configure security](images/jenkins-security.png)

1. On the upper-right of the black toolbar, click **Sign up**. Create a new user account and make a note of the credentials as you will need them later.

1. Navigate to your VSTS Team Project and click on the gear icon and then Services.

1. Click **+ New Service Endpoint** and select Jenkins from the list.

1. Enter the following:

    | Name | Value | Notes |
    | --------------- | ---------------------------- | ----------------------------------------------------------- |
    | Connection Name | `Azure VM Jenkins` | The name of this connection |
    | Server URL | `http://10.0.0.4:8080`  | The internal IP address of the Azure VM on port 8080 (the Jenkins port)
    | Username | The username you created in Jenkins | |
    | Password | The password you created in Jenkins | |

1. Click **Verify connection** to ensure that the connection is valid.

    ![Jenkins endpoint](images/jenkins-endpoint.png)

1. In VSTS, click on **Build & Release -> Builds** to navigate to the Builds hub.

1. Click **+ New** to create a new definition.

1. Enter "jenkins" into the search box and press enter. Click on the Jenkins template and click Apply. Configure the following settings and tasks.

1. In **Process** settings

    | Parameter | Value | Notes |
    | --------------- | ---------------------------- | --------------------------------------- |
    | Default agent queue | `default` | Run this build on your VSTS agent container |
    | Job Name | `MyShuttleCalc` | The name of the Jenkins job
    | Jenkins service endpoint | `Azure VM Jenkins` | The endpoint you just created for Jenkins |

1. In **Get Sources** settings

    Connect to the MyShuttleCalc repo on the master branch.

1. Configure the **Queue Jenkins Job: MyShuttleCalc** task as follows:

    ![Queue Jenkins task](images/queue-jenkins.png)

1. Configure the **Download artifacts produced by MyShuttleCalc** task as follows:

    ![Download artifacts task](images/download-artifacts.png)

1. Insert a **Publish Test Results** task and configure it as follows:

    | Parameter | Value | Notes |
    | --------------- | ---------------------------- | ------------------------------------- |
    | Test result format | `JUnit` | Publish JUnit results |
    | Test results files | `**/TEST-*.xml` | File containing test results
    | Search Folder | `$(Build.ArtifactStagingDirectory)` | Root folder for search operation |

    ![Publish test results task](images/publish-test-results.png)

1. Insert a **Publish Code Coverage Results** task and configure it as follows:

    | Parameter | Value | Notes |
    | --------------- | ---------------------------- | ------------------------------------------------------------------------------------------------- |
    | Code Coverage Tool | `JaCoCo` | Publish JaCoCo results |
    | Summary File | `$(Build.ArtifactStagingDirectory)/jenkinsResults/MyShuttleCalc/team-results/jacoco/target/site/jacoco/jacoco.xml` | File containing JaCoCo results
    | Report Directory | `$(Build.ArtifactStagingDirectory)/jenkinsResults/MyShuttleCalc/team-results/jacoco/target/site/jacoco` | Folder containing detailed coverage reports |

    ![Publish code coverage results task](images/publish-coverage-results.png)

1. The final list of tasks should look as follows:

    ![Build tasks](images/vsts-tasks.png)

1. Save and queue the build.

1. When the build completes, click on the build number to view the results.

    ![Build results](images/vsts-results.png)