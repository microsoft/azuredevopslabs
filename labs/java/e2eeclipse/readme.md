---
title: End to End workflow with Eclipse 
layout: page
sidebar: java
permalink: /labs/java/e2eeclipse/
folder: /labs/java/e2eeclipse/
comments: true
---

In this exercise, you are going to see a typical end-to-end workflow for a Java developer. You should have completed the labs that set up automated build and release (this is a CI/CD pipeline. In this scenario, you will open the running MyShuttle application and discover a bug. You will then use the [Exploratory Testing extension](https://marketplace.visualstudio.com/items?itemName=ms.vss-exploratorytesting-web){:target="_blank"} to create a Bug work item in VSTS. You will then branch the code for fixing the bug. Once the bug is fixed on the branch, you will merge the code in via a Pull Request and code review. This will then automatically queue the build/release pipeline and your fix will be deployed.

This exercise assumes you have completed the exercise to create a Team Project and have set up the Docker private VSTS agent. You should also have completed the labs to set up an automated build for both the MyShuttleCalc and the MyShuttle2 repos as well as the release management lab. This exercise uses a team project named **jdev-labs**, though your team project name may differ.

## Install the Exploratory Testing Extension for Chrome

In this task you will install the [Exploratory Testing extension](https://marketplace.visualstudio.com/items?itemName=ms.vss-exploratorytesting-web){:target="_blank"} into Chrome.

1. Open Chrome and navigate to `https://chrome.google.com/webstore`. Enter **exploratory testing** into the search box. Locate the **Test & Feedback** extension from Microsoft Corporation and click **Add to Chrome**. Click Install in the dialog.

    ![Adding the Exploratory Test Extenions to Chrome](images/add-ext.png)

1. Once installed, a beaker icon appears in the top right of the Chrome toolbar. Click it to launch the UI.

1. Click on the gear icon to open the settings. Select **Connected**, enter your VSTS account URL and click Next.

    ![Connect to VSTS](images/connect-to-vsts.png)

1. Select your team project, expand it and select the default project team (which should have the same name as your team project). Click Save.

    ![Select the Team to Connect to](images/select-team.png)

    > Your team name may be different

## Configure Branch Policies

In this task you will enforce quality on the master branch by creating branch policies.

1. In Chrome, connect to your VSTS Team Project. Click on the Code link to open the Code Hub.

1. Click the Repo dropdown and select **Manage Repositories**.

    ![Manage Repositories](images/manage-repos.png)

1. In the tree, expand the MyShuttle2 repo and click on the master branch. Click the Branch Policies tab.

    ![Open branch policies](images/branch-policies.png)

1. Select the **Protect this branch** checkbox.

1. Select **Check for linked work items** and set the option to required.

1. Under Build validation, click Add build policy. Select MyShuttle2 from the list of build definitions and click Save.

    ![Policy configuration](images/policy.png)

    {% include note.html content= "You can enforce other policy options like comment resolution and minumum number of reviewers, as well as specify the merge options \(like squashing\). You can also configure default reviewers." %}

## Log a Bug using the Exploratory Test Extension

In this task you will start a test session, discover a bug in the MyShuttle app and log it to VSTS.

1. In the Test extension toolbar of the Exploratory Test extension, click the Play icon to start a testing session.

    ![Start a test sessions](images/start-test-session.png)

    {% include note.html content= "The test extension is now recording all of your interactions. You can see the Test Extension beaker icon has a green dot indicating that a test recording session is in progress." %}

1. Enter `http://localhost:8081/myshuttledev` in the toolbar to navigate to the application. Enter `fred` for the username and `fredpassword` for the password and click Log In.

    ![Log in to the app](images/login.png)

1. On the Dashboard page, click **Access Your Fare History** to navigate to the fare history page.

1. If you look at the totals for the Fare and Driver column in the table, you will notice that the total for the driver column is incorrect.

1. Click the Test Extension beaker icon and click the Camera icon (capture image).

    ![Click Add Screenshot](images/click-camera.png)

1. Capture the grid with the incorrect total. Annotate the image appropriately and click the Check (accept) icon.

    ![Capture an image of the Bug](images/add-screenshot.png)

1. Click the Test Extension beaker icon and click the flyout (lower right) of the icon with the page and exclamation mark (new bug). From the menu click Create bug.

    ![Create a new bug](images/new-bug.png)

1. In the title box, enter "Driver total incorrect" and click Save.

    ![Log the Bug](images/log-bug.png)

    {% include note.html content= "All the visited pages, notes added, screenshots and other information from the test session is automatically included as details for the Bug, so you do not have to add these details manually. You also should see a button next to the title box reading **0 Similar**. VSTS checks to see if there are bugs already logged with similar titles in an attempt to minimize logging of duplicate bugs." %}

1. Once the bug has been created, click the Stop button in the Test Extension toolbar to end the test session.

1. Navigate to your VSTS team project. Click Work to navigate to the Work Hub. In the toolbar, enter "driver" into the Search Work Items box and press enter or click the search icon.

    ![Search for the Bug](images/search-bug.png)

1. You should see the Bug that you just logged. Take a moment to review the Repro Steps.

    ![Bug details](images/bug-details.png)

1. Assign the Bug to yourself and change the state to Active. Click Save.

    ![Assign the Bug](images/assign-bug.png)

## Fix the Bug

In this task you will create a branch of the code to fix the Bug. You will then checkout the branch, fix the bug and commit the code. You will then create a Pull Request to merge the fix into master and see that this triggers the CI/CD pipeline to automatically deploy the fix to the dev environment.

{% include note.html content= "Use the personal access token (PAT)generated from the **Set up a Docker Build** lab that should be located at: `home/vmadmin/pat.txt`. Otherwise, follow the instructions from that lab again to generate a new PAT." %}

1. Launch Eclipse, if it is not already open. Open the MyShuttle2 project.

1. In Team Explorer, change the drop down to "Work Items".  If the drop down does not display work items, connect to your VSTS account via the Team Explorer Home page.

1. If there are no queries saved in VSTS, a query can be created in Eclipse (but not saved at this time). Right-click on the My Queries folder , select **New Query**.

    ![New query](images/newquery.png)

1. Run an existing query by double-clicking on it to locate the bug. Alternatively, right-click on the New Query panel and select **Run Query**. The output from the query will display the bug. Make a note of the bug ID.

    ![Confirm the bug is correctly assigned and in VSTS](images/findbug.png)

    > If you do not see the bug created earlier, ensure that it is assigned to you, since by default only work items assigned to you will appear in the work item list.

1. Create a new branch

    ![New branch](images/createbranch.png)

1. In the dialog, change the branch name to "totalsBug" and click Create.

    ![New branch](images/createbranch2.png)

1. In the project view of Eclipse, browse to `src/main/java/com.microsoft.example.servlet` and open the LoginServlet class.

1. Around line 35, you will see the cause of the bug: the `totalDriverFee` value is being calculated but the `driverFeeTotal` session attribute is being set to the `totalFareForDriver` value (this seems like a classic copy/paste error).

    Change this line of code:
    ```java
        session.setAttribute("driverFeeTotal", totalFareforDriver);
    ```
    to
    ```java
        session.setAttribute("driverFeeTotal", totalDriverFee);
    ```

1. Commit your changes by right-clicking the file and selecting Team -> Commit. Enter "Fixing totals bug #{ID of bug}" as the commit message. By putting the # symbol followed by an ID of a work item in a commit message, VSTS will automatically associate the work item with the commit when it is pushed to VSTS. In the example shown in the picture, the ID is #698. Click **Commit and Push** to push the changes to VSTS.

    ![Commit and Push](images/eclipse-newcommit.png)

1. If a window pops up that prompts for credentials, use the following values:

    | Name | Value |
    |---|---|
    | User | `_VSTS_Code_Access_Token` |
    | Password | `{PAT that you copied earlier}` |

    ![Login to Eclipse](images/eclipse-login.png)

    In the Push commits dialog click Push.

1. Now that the fix has been pushed to VSTS on a branch, you can create a Pull Request. This will be done in VSTS following the standard process for pull requests. Under the Code hub, click on Files in the MyShuttle2 repo and there should be a notification that you updated the `totalsBug` branch. Click the link next to **Create a pull request**.

    ![Create Pull Request](images/pullrequest.png)

1. In the pull request panel, click **Create** to create the pull request. Note that the bug gets associated with the commit.

    ![Create Pull Request](images/pullrequest2.png)

1. Once the pull request (PR) has been created, right-click on it in the PR list and click Open in Browser. You should see that the build is running (this is the build mandated by the Branch Policy you set up earlier).

    ![Build is running to validate the PR](images/pr-overview.png)

    {% include note.html content= "If there was a merge conflict, VSTS would warn you on the overview page. If there is no warning to this effect, then Git will be able to auto-merge the PR into the target branch. <br/>

    You have configured the release to only trigger when the build of the master branch is successful. Since this build is not initiated from the master branch, these changes will not yet be deployed." %}

1. Click on the Files tab to open the file compare. Make a note of the changes.

    ![PR File Compare](images/PR-file-compare.png)

    > You can comment on the code or files in the PR and have conversations with the team throughout the review process.

1. Click Approve to approve the PR.

1. Now that the policies have been fulfilled, you can complete the PR which will merge the changes into master (the target branch). Click Complete to do the merge.

1. In the dialog, accept the defaults and click Complete merge.

    ![Complete the merge](images/complete-merge.png)

1. The PR completion triggers a new build on the master branch, which in turn will trigger a release. _It also transitions the Bug work item state to Resolved_.

1. Click on Builds to view the builds. When the build completes, you will be able to view the unit test and code coverage results as well as the SonarQube analysis and quality gates (if you have configured SonarQube integration).

1. Click on Releases and open the latest release which should have triggered on the PR merge build completion event.

1. On the Release Summary page, you will view the linked Bug work item.

    ![Linked work item in Release](images/linked-bug-release.png)

1. Click on commits to view the incoming commits for this release. There is the commit to fix the bug as well as the commit to merge into master.

    ![Linked commits](images/linked-commits.png)

1. Click on the Tests tab to view the test results. The UI tests should be successful.

1. Open the MyShuttle2 app by navigating to the URL `http://localhost:8081/myshuttledev`. Log in again and verify that the totals column is correct and the Bug has been fixed.

    ![The bug has been fixed](images/bug-fixed.png)