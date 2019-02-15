---
title: GitHub integration with Azure Boards
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/github-azureboards/
folder: /labs/vstsextend/github-azureboards/
---
<div class="rw-ui-container"></div>

## Overview 

**DevOps** is not just about automation; while continuous integration and continuous delivery are key practices, teams also need continuous planning. As the saying software, development is a team sport - it is vital that everyone stays on the same page. While GitHub issues help teams manage work artifacts such as issues and bugs which might be sufficient for individuals and small teams, but they do not scale well to support the needs of enterprise teams.  

 ![](images/github-azureboards.png)
 
**Azure Boards** provides a wealth of project management functionality that spans Kanban boards, backlogs, team dashboards, and
custom reporting. By connecting Azure Boards with GitHub repositories, teams can take advantage of the rich project management capabilities. You can create links between GitHub commits and pull requests to work items tracked in Azure Boards. This enables a seamless way for you to use GitHub for software development while using Azure Boards to plan and track your work.

In this lab, you'll see how easy it is to set up
**Azure Boards** with your **GitHub** projects and how you can start seeing
benefits immediately.

 {% include important.html content= "Before you proceed with this lab we recommend you to complete the **[GitHub integration with Azure Pipelines](../github-azurepipelines)** lab." %}

## Exercise 1: Managing GitHub Projects with Azure DevOps

## Task 1: Connecting GitHub with Azure Boards 


1. Return to the web app tab and click **Login**.

    ![](images/image85.png)
   
   

1. Log in with any email and password.

    ![](images/image86.png)
   

1. Click **Book**.

    ![](images/image87.png)
   

1. Expand the airport dropdown to note that it's not sorted
    alphabetically by city.

    ![](images/image88.png)

     Let us assume that in our scenario, users will need to be able to book flights by selecting the cities involved. We will create a new
    user story to sort the airports listed in the booking form in alphabetical order by city. Ordinarily, we would create the user
    story at a higher level and add tasks to define how the story is to be implemented, but for our demo purposes here we'll leave it as
    a single work item.

1.  Return to the **Azure DevOps** tab.

1.  Navigate to **Boards \| Backlogs**.

    ![](images/image76.png)

    > If you don't see the **Boards** navigate to **Project settings** and enable **Azure Boards**
       ![](images/azureboards.png)
    
1.  Click **New Work Item** and add a user story with the title **As a customer, I want to see airports sorted by city**. Press **Enter** to create.

    ![](images/image77.png)

    In addition to working with work items in a backlog, we have a very flexible Kanban board option. With the
    board, we can edit items on a card in line, or even drag cards around to change their state and assignment. Let's take ownership of
    the new user story so we can begin work.

1.  Click **View as board**.

    ![](images/image78.png)

1.  Drag the newly created user story to the **Active** column.

    ![](images/image79.png)

1.  Dropping the user story onto the **Active** column assigns it to you
    and sets its **State** to **Active**. Make note of the task ID for
    reference later during a future commit and pull request.

    ![](images/image80.png)

    In order to complete our integration, we'll need to wire up a connection between this project and the GitHub repo.


## Task 2: Connecting GitHub Repo to Azure Boards

1.  Click **Project settings**.

    ![](images/image81.png)

1.  Under **Boards**, select **GitHub connections**.

    ![](images/image82.png)

1.  Click **Connect your GitHub account**.

    ![](images/image83.png)

1. Select the project repo and click **Save**.

    ![](images/image84.png)

    Let's take a look at our deployed site to see
    what the current booking experience is like. As you can see, the
    airports appear to be sorted by airport code, which isn't the
behaviour we want our users to see.

   

## Task 3: Committing to Complete a Task


1.  Return to **Visual Studio Code**.

    We'll start off by creating a new branch for this
    task. The work itself is pretty straightforward. We just need to
    locate the place where airports are provided to the user experience
    and make sure they're being sorted by city name.

2.  Click the **master** branch at the bottom of the window.

    ![](images/image89.png)
   

3.  From the top of the screen, click **Create new branch**.

    ![](images/image90.png)
   

4.  Enter the name **"airport-sorting"** and press **Enter**. This will
    activate the new branch.

    ![](images/image91.png)
   

5.  From the **Explorer** tab, open
    **src/services/airports.service.js**.

    ![](images/image92.png)
   

6.  Locate the **getAll** function and replace the existing code
    with the code below. This will sort the
    airports by the city.

    ````JavaScript

        getAll(){
                return this._airports.filter(a => a.code).map(avoidEmptyCity).sort((a, b) => (a.city > b.city) ? 1 : -1);
            }

    ````

    ![](images/image93.png)
   

7.  Press **Ctrl+S** to save the file.

    We'll commit it using a comment that includes special syntax to link it to the Azure Boards task we saw earlier. Now this commit will become trackable from project management, as
    long as we include the phrase "Fixes AB\#ID".

8.  Switch to the **Source Control** tab and enter a commit message of
    **"Changes airport sorting. Fixes AB\#3464."**, but replace **3464**
    with the actual ID of the Azure Boards task. Press **Ctrl+Enter**
    and confirm the commit if prompted.

    ![](images/image94.png)
   

9.  Click the **Publish Changes** button at the bottom of the screen.

    ![](images/image95.png)
   

10. When the push has completed, return to the GitHub browser tab.

    With the commit pushed, we'll create a pull
    request to drive those changes back into the master branch. In this
    case we're inheriting the title from the commit, but having the pull
    request mention "Fixes AB\#ID" will link and complete the target
    work item when the pull request is merged.

11. Click **Compare & pull request**, which should appear on its own. If
    not, refresh.

    ![](images/image96.png)
   

12. Change the **base fork** to point at your project. By default it
    points at the original Microsoft repo, so be sure to change it.

    ![](images/image97.png)
   

13. The title should initialize to the commit message entered earlier.
    Click **Create pull request**.

    ![](images/image98.png)
   

14. Return to Visual Studio Code.

    Now we'll switch to the other side of the pull
    request and take on the role of reviewer. We can use Visual Studio
    Code to check out the pull request, analyze changes, and comment.
    Assuming we trust the fix, we can merge the pull request to update
    master and kick off the CI/CD.

15. Under **GitHub Pull Requests \| All**, right-click the pull request
    and select **Checkout Pull Request**.

    ![](images/image99.png)
   

16. Expand the **Changes in Pull Request** tree.

    ![](images/image100.png)
   

17. Select the **Description** from under the original pull request.

    ![](images/image101.png)
   

18. Review the details of the pull request.

    ![](images/image102.png)
   

19. Click **Merge pull request** and confirm the merge.

    ![](images/image103.png)
   

    Once the deployment works its way through the build
    and release, we can confirm the new functionality.

1. Follow the CI/CD pipeline through to completion.

1. Refresh the web app site. Return to the booking page (you'll need to
    log in again) and confirm the airports are sorted by the city now
    (scroll down past the airports with no city name).

    ![](images/image104.png)
   
1. Return to the Azure DevOps tab open to the Kanban board.

    Since the user story, we were working on was
    linked in a pull request that was approved, Azure DevOps will
    automatically transition the state of the work item to "Closed". You
    can also see that the related GitHub commits and pull request were
    linked to the work item.

1. The user story should have already moved to the **Closed** state and
    column. Click to open it.

    ![](images/image105.png)
   

1. The commit and pull request should now be visible under
    **Development**.

    ![](images/image106.png)

## Summary

Many organizations have their projects hosted in GitHub, and we just
achieved how you can set up automated deployment to Azure in minutes. And
it doesn't matter what kind of application they're building or what kind
of environment they're deploying to. Once this automation is in place,
companies can turn their focus to developing business value instead of
infrastructure.
