---
title: Maven Package Management with Visual Studio Team Services
layout: page
sidebar: java
permalink: /labs/java/mavenpmvsts/
folder: /labs/java/mavenpmvsts/
comments: true
---
In this exercise, you are going to set up package management with Maven in VSTS. This repo contains a class library (MyShuttleCalc) that is used by the MyShuttle2 application. You will configure a VSTS build to publish the MyShuttleCalc package to a VSTS Maven Package feed so that it can be consumed by MyShuttle2 and any other applications that require the calculation code.

This exercise assumes you have completed the exercises to create a Team Project, have set up the Docker private VSTS agent, and imported the MyShuttleCalc and MyShuttle2 GitHub repos into your VSTS team project. This exercise also assumes that you have cloned the repos in either IntelliJ or Eclipse. This exercise uses a team project named **jdev-labs**, though your team project name may differ.

{% include note.html content="This exercise shows how to do a Maven build using VSTS. To see how to perform a Maven build using Jenkins that still integrates into the VSTS Package Feed, please refer to the [**Maven Package Management with Jenkins**](../mavenpmjenkins) lab" %}

## Create a Maven Package Feed

In this task you will create a Maven package feed. You will publish packages to this feed as well as consume packages from this feed.

1. In VSTS, click on **Build & Release** and then Packages to navigate to the Package Hub. Click **+ New Feed** to create a new feed.

    ![Create a new feed](images/vsts-create-feed.png)

1. Enter **Maven** for the feed name and click **Create**.

    ![Create the new feed](images/vsts-new-feed.png)

   You now have a feed that you can publish package to.

## Create a Maven Settings File with the Feed Credentials

In this task you will create credentials for the Maven feed. You will then create a settings.xml file containing the credentials.

1. In the Packages Hub, make sure you have selected the Maven feed and click **Connect to Feed**.

1. In the left menu, click on Maven.

   {% include note.html content= "At the time of writing, Maven package feeds was a preview feature. You will need to enable the Maven package feed feature in order to connect to Package Management to/from Maven." %}

1. Click **Generate Maven Credentials**.

    ![Generate Maven Credentials](images/maven-generate-creds.png)

1. VSTS creates a credentials snippet. Click **Copy to Clipboard** to copy the snippet to the clipboard.

    ![Copy the Maven Credentials](images/maven-creds.png)

1. In your editor, open the `MyShuttleCalc\maven\settings.xml`.

1. Delete the comment `<!-- paste maven package feed credentials section here !-->` and replace it with the snippet text between the tags `<servers>` and `</servers>` so that the final result looks like this:

    ![Paste the Maven Credentials](images/maven-paste-creds.png)

1. Press Ctrl-S (or File -> Save) to save the file.

1. In VSTS, go back to the **Connect to Feed** dialog on your Maven feed. Click copy in the section labeled `Add this feed to your project pom.xml inside the <repositories> tag`.

    ![Get the package repository settings from VSTS](images/maven-packagefeed-settings.png)

1. In your editor, open the `pom.xml` file. Update the `<repositories>` tag as well as the `<distributionManagement>` tag so that they now point to your feed.

    ![Updating the repo settings in pom.xml](images/pom-repo.png)

1. Commit your changes to the repo.

   {% include note.html content= "If this is your first commit to VSTS, you will be prompted to update your display name and email address for the repo. These are only for display purposes but are usually matched to your VSTS profile." %}

### IntelliJ

1. Click **VCS -> Commit Changes** to commit your changes to the repo.

![Commit changes](images/vcs-commit.png)

- Enter **Adding maven credentials** for the commit message.

- Click the drop-down next to **Commit** and select **Commit and Push**.

### Eclipse

{% include note.html content= "Use the personal access token (PAT)generated from the **Set up a Docker Build** lab that should be located at: `home/vmadmin/pat.txt`. Otherwise, follow the instructions from that lab again to generate a new PAT." %}

- In Eclipse, right click on the project or the pom.xml file and select **Team -> Commit**.

- Enter **Adding maven credentials** for the commit message and click **Commit and Push**.

- Verify that the remote location is accurate and click **Next**.

- If a window prompts for credentials, use the following values:

    | Name | Value |
    |---|---|
    | User | `_VSTS_Code_Access_Token` |
    | Password | `{PAT that you copied earlier}` |

  ![Login to Eclipse](images/eclipse-login.png)

1. **Important**: Copy the maven settings file to the .m2 directory so that local Maven operations will succeed by running the following command in a terminal:

    ```sh
    cp ~/MyShuttleCalc/maven/settings.xml ~/.m2/
    ```

1. **Important**: If you have the MyShuttle2 project already open in IntelliJ or Eclipse, close the instance of the IDE and reopen it.

## Creating a VSTS Build for Publishing a Maven Package

In this task you will create a build that will publish the MyShuttleCalc library to the Maven feed.

1. Open VSTS and connect to your team project. Click on the **Build & Release** Hub and then click Builds. Click on **+New** to create a new build definition.

    ![New build definition](images/new-build.png)

1. In the templates window, type **maven** into the search box. Click apply on the Maven template.

    ![Apply the Maven template](images/maven-template.png)

1. In the Process page, change the name of the build to **MyShuttleCalc**.

    ![Change the name](images/process-name.png)

1. Click on Options.

1. Update the Build number format to `0.0$(rev:.r)` and update the build queue to `default` (this is the queue that the VSTS agent in the container is joined to).

    ![Build options](images/build-options.png)

1. Click on Tasks. Click on the Maven task. Edit the following settings:

    | Field | Value | Notes |
    |---|---|---|
    | Options | `--settings ./maven/settings.xml` | Required to authenticate when pushing the Maven package to the feed. |
    | Goal(s) | `deploy -Dbuildversion=$(Build.BuildNumber)` | Tell Maven to publish the package, passing in the build number |
    | Code Coverage Tool | `JaCoCo` | Change the code coverage format |
    | Source Files Directory | `src/main` | These files must be included in the coverage results |

    ![Maven task options](images/maven-task-opts.png)

1. Click **Save and Queue**. Accept the defaults to queue the build.

1. A green status bar indicates that the build has been queued. Click on the build number to view the logs in real time.

    ![Open the build logs](images/click-build-number.png)

1. When the build completes successfully, you can click on the build number to view the summary. Note the test results and code coverage.

    ![Build summary page](images/build-summary.png)

    {% include note.html content= "Each time you run the build, the patch number \(the last of the 3-digit version numbers\) will increment. In the image above, the build has run 6 times so the latest build number is 0.0.6. The package version matches the build number because we supplied the build version number to Maven in the Maven task." %}

1. Navigate back to the Maven package feed. There you will see the MyShuttleCalc package.

    ![The MyShuttleCalc package in the feed](images/package-in-feed.png)
