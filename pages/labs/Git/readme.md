---
title: Getting Started with Git using Team Foundation Server 2017
layout: page
sidebar: mydoc_sidebar
permalink: /labs/git/
folder: _site
---


<img src="media/image1.png" />




<span id="_Toc428376556" class="anchor"><span id="_Toc430533659" class="anchor"><span id="_Toc472630954" class="anchor"></span></span></span>**Overview**
---------------------------------------------------------------------------------------------------------------------------------------------------------

In this lab, you’ll learn about Git support in Team Foundation Server 2017 and Visual Studio 2017. Git is a distributed version 
control system. Git repositories can live locally (such as on a developer’s machine) and can now be hosted by Team Foundation Server.
You will learn how to establish a local Git repository, which can easily be synchronized with a centralized Git repository in Team 
Foundation Server. In addition, you will learn about Git branching and merging support.

### **Pre-requisites**

*  In order to complete this lab you will need the Visual Studio 2017
    virtual machine provided by Microsoft. For more information on
    acquiring and using this virtual machine, please see [this blog
    post](http://aka.ms/ALMVM).

### About the Fabrikam Fiber Scenario

This set of hands-on-labs uses a fictional company, Fabrikam Fiber,
    as a backdrop to the scenarios you are learning about. Fabrikam
    Fiber provides cable television and related services to the
    United States. They are growing rapidly and have embraced Windows
    Azure to scale their customer-facing web site directly to end-users
    to allow them to self-service tickets and track technicians. They
    also use an on-premises ASP.NET MVC application for their customer
    service representatives to administer customer orders.

In this set of hands-on labs, you will take part in a number of
    scenarios that involve the development and testing team at
    Fabrikam Fiber. The team, which consists of 8-10 people, has decided
    to use Visual Studio application lifecycle management tools to
    manage their source code, run their builds, test their web sites,
    and plan and track the project.


### Exercises

This hands-on lab includes the following exercises:

   * Getting Started with Git

   * Git Branching and Merging

Estimated time to complete this lab: **60 minutes**.



## Exercise 1: Getting Started with Git
  

In this exercise, you will learn how to create, clone, and push commits to a Git repository with Team Foundation Server.    

### Task 1: Create a Git Repository

1.  Log in as **Sachin Raj** (VSALM\\Sachin). All user passwords are
    **P2ssw0rd**.

2.  Launch **Visual Studio 2017** from the taskbar and open **Team
    Explorer**. You should now be connected to the FabrikamFiber
    team project. If you are not automatically connected to the
    FabrikamFiber project, click the **Connect to Team Projects** button
    (<img src="media/image2.png" width="18" height="22" />) to do so.

3.  There are a few reasons why Fabrikam Fiber might want to use Git as
    their source control option within Team Foundation Server. One
    reason could be that they are collaborating with developers using a
    tool such as Xcode, which supports the Git protocol natively.
    Another reason could be that they have developers working offline
    (such as during a commute) who want to commit code locally when they
    are offline and check this code into Team Foundation Server when
    they get into the office. Microsoft now offers teams the ability to
    utilize Git without sacrificing the integrated application lifecycle
    management capabilities offered by Team Foundation Server. Visual
    Studio 2017 also provides developers with a great experience for
    working with any Git repository – whether it’s hosted by Team
    Foundation Server, a local repository, or another Git provider.

4.  Select **File | New | Team Project** from the main menu.

5.  Name the new project “**FabrikamCommunity**” and click **Next**.

    <img src="media/image3.png" width="423" height="344" />
    
   
6.  Select the **Scrum** process template and click **Next**
    to continue.

    <img src="media/image4.png" width="418" height="343" />


7.  Select the **Git** version control system and then click **Finish**.

    <img src="media/image5.png" width="378" height="308" />


8.  After the new Git team project has been created, click **Close** to
    return to Visual Studio.
 

### Task 2: Clone Git Repository

1.  In **Team Explorer**, click **Clone this repository**.

    <img src="media/image6.png" width="351" height="151" />


2.  Accept the default endpoint and repository location and then click
    **Clone**.

    <img src="media/image7.png" width="343" height="282" />
 

### Task 3: Commit Code and Link to Work Item

1.  In **Team Explorer – Home**, click **Settings**.

    <img src="media/image8.png" width="225" height="253" />


2.  Click **Global Settings** under **Git**.

    <img src="media/image9.png" width="251" height="299" />


3.  Enter an email address for Sachin Raj (**Sachin@vsalm**) and then
    click **Update**.

    <img src="media/image10.png" width="349" height="348" />


4.  Click the **Home** button in **Team Explorer**.

    <img src="media/image11.png" width="344" height="44" />

5.  Create a new work item for the product backlog by selecting **Team |
    New Work Item | Product Backlog Item** from the main menu. This will
    launch the **New Product Backlog Item** form in TFS via a browser.

6.  Enter a title of “**Create new web site**” and then click the
    **Save** button. Take note of the **ID** once the work item
    is saved.

    <img src="media/image12.png" width="531" height="213" />


7.  Return to Visual Studio. In **Team Explorer – Home**, click **New…**
    underneath the **Solutions** section.

    <img src="media/image13.png" width="351" height="409" />


8.  In the **New Project** window, select the **Visual C\# | Web |
    ASP.NET Web Application** template and click **OK**.

    <img src="media/image14.png" width="624" height="351" />


9.  Select the **MVC** template, **de-select** the option to “**Host in
    the cloud**”, and then click **OK**.

    <img src="media/image15.png" width="624" height="406" />


10. In **Team Explorer – Home**, click **Changes**.

    <img src="media/image16.png" width="352" height="249" />


11. Scroll down the list of included changes to the end and note that
    .gitattributes and .gitignore files were automatically added to
    the project. The **.gitattributes** file contains various settings
    to control Git behavior whereas the **.gitignore** file specifies
    patterns and extensions to ignore when detecting changes.

    <img src="media/image17.png" width="318" height="146" />


12. Enter a commit message of “**initial MVC site for work item
    \#247**”. If the Product Backlog Item that you saved has a different
    ID, use that number instead. Typing ‘**\#**’ followed by the work
    item ID will automatically link the commit to the work item when
    pushed to the server.

    <img src="media/image18.png" width="351" height="116" />



13. Commit the changes by clicking **Commit All**. Note that the commit
    is persisted locally and is not shared with the server.

    <img src="media/image19.png" width="280" height="93" />


14. Let’s make a small change to the web site. In **Solution Explorer**,
    open **\_Layout.cshtml** from the **Views\\Shared** folder.

    <img src="media/image20.png" width="280" height="261" />

15.  Modify the title as shown in the following screenshot (from “**My
     ASP.NET Application**” to “**Community**”).

     <img src="media/image21.png" width="536" height="124" />


16. In **Team Explorer – Changes**, enter a commit message and then
    click **Commit All**. **Save** changes to files when prompted.

    <img src="media/image22.png" width="300" height="156" />



### Task 4: Synchronize Commits with Server

1.  Navigate to the commits view by clicking **Sync**.

    <img src="media/image23.png" width="343" height="73" />

2.  The **Team Explorer – Synchronization** view shows both incoming and
    outgoing commits. However, since this project has not yet been
    published to source control, you will need to do that now by
    clicking **Publish**. Once the project has been published, we’ll use
    **Push** for future changes.

    <img src="media/image24.png" width="342" height="259" />

3.  Click **Sync** to perform both a **pull** and a **push** to ensure
    we have the latest source before pushing our updates. It’s unlikely
    that anyone else has made any changes since our initial checkin, but
    it won’t hurt to check.

    <img src="media/image25.png" width="284" height="63" />

    <img src="media/image26.png" width="272" height="57" />


4.  Finally, let’s take a quick peek at what these commits look like in
    the web portal. In **Team Explorer – Home**, click **Web Portal**.

    <img src="media/image27.png" width="261" height="161" />


5.  From the **Code** dropdown in the web portal, select **History**.

    <img src="media/image28.png" width="479" height="153" />


6.  This view lists commits. Note that the relative size of the commits
    (in terms of number of modified files) can be determined by viewing
    the size of the circles rendered to the left of the commits. Click
    the first (bottom) commit.

    <img src="media/image29.png" width="480" height="280" />
````
Note: It may take a few moments after pushing a commit before the commit size indicators show up. You can refresh the page
    if necessary.
````

Note that the “**Create new web site**” work item is linked to the commit. Click the link to open the work item.

````
Note: It may take a few minutes before the work item gets linked to the commit. In the event that the link has not been made yet, go
    ahead and continue on with the rest of the lab.
````
  <img src="media/image30.png" width="364" height="332" />

  <img src="media/image31.png" width="277" height="113" />



## Exercise 2: Git Branching and Merging

In this exercise, you will learn about Git branching and merging
    support in Visual Studio. In general, branching is often used to
    help switch development contexts and to isolate risk. Git branching
    is no different in that regard. Creating a Git branch is a
    lightweight (and therefore fast) operation, as you are simply
    creating a new reference to an existing commit. This is very
    different from Team Foundation Version Control (TFVC) branching
    where the entire source tree needs to be duplicated server-side. We
    will also take a quick look at the merging support for Git projects.

### Task 1: Branching

1.  Return to Visual Studio and open **Team Explorer – Home**.

2.  Click **Branches**.

    <img src="media/image32.png" width="345" height="147" />


3.  Let’s say that we would like to create a new branch to do some
    development work on the web site. Right-click the **master** branch
    node and select **New Local Branch From**.

    <img src="media/image33.png" width="340" height="256" />


4.  Provide a name of **Development**, select the **master** branch,
    select the **Checkout Branch** option, and then click **Create
    Branch**.

    <img src="media/image34.png" width="346" height="164" />


5.  Note that you are now connected to the new local branch, and that it
    has not been published to the server yet.

    <img src="media/image35.png" width="348" height="169" />


6.  In **Solution Explorer**, open the **HomeController.cs** file from
    the **Controllers** folder.

7.  Modify the **About** method as shown in the following screenshot.

    <img src="media/image36.png" width="422" height="122" />

8.  Right-click somewhere in the whitespace of the editor and select
    **Source Control | Commit**.

    <img src="media/image37.png" width="564" height="248" />

9.  In **Team Explorer - Changes**, enter a commit message of “**dev
    version**” and click **Commit All**. Save the changes when prompted.

    <img src="media/image38.png" width="349" height="153" />


10. At this point, the changes have been committed locally. In the **Team Explorer – Changes** window, click the **Development** branch
    link to quickly navigate to the **Team Explorer - Branches** view.

    <img src="media/image39.png" width="346" height="97" />


11. Double-click the **Master** branch and note that original version of
    the *HomeController.cs* file is shown in the code editor window.

    <img src="media/image40.png" width="255" height="127" />

    <img src="media/image41.png" width="409" height="113" />

12. You don’t have to publish the branch to the server yet if you want
    to continue working locally. As you saw in the previous exercise,
    you can continue to work locally and add additional commits to the
    new branch. In **Team Explorer – Branches**, **right-click** the
    **Development** branch and select **View History**.

    <img src="media/image42.png" width="265" height="223" />

    <img src="media/image43.png" width="624" height="78" />

13. When you are ready, you can delete the branch, merge it back into
    your master branch, or push it to the server-side repository so that
    teammates can access it. Let’s go ahead and publish the branch by
    **right-clicking** the Development branch and selecting the
    **Publish Branch** option.

    <img src="media/image44.png" width="345" height="295" />

    <img src="media/image45.png" width="277" height="166" />


14. Now let’s say that another team member makes a modification to the
    **HomeController.cs** file and commits that change to the master
    branch, before Sachin has a chance to merge in her
    development changes.

15. Open a **Remote Desktop** session to **VSALM**. Connect using user **Deniz Ercoskun** (VSALM\\Deniz). All user passwords are
    **P2ssw0rd**.

16. Launch **Visual Studio** from the taskbar.

17. Connect to the **FabrikamCommunity** team project (using the
    **Manage Connections** button as before, and this time select
    **Manage Connections | Connect to Team Project**).

18. Select the **FabrikamCommunity** team project and then click
    **Connect**.

    <img src="media/image46.png" width="475" height="503" />

19. From **Team Explorer**, click **Clone this repository**.

    <img src="media/image47.png" width="339" height="86" />

20. Click **Clone** to perform the clone.

    <img src="media/image48.png" width="342" height="231" />

21. **Double-click** the **MvcApplication1.sln** solution shown in
    **Solution Explorer**.

    <img src="media/image49.png" width="340" height="202" />

22. Modify the same ***HomeController.cs*** file that Sachin did, but
    this time change the text to be something different.

    <img src="media/image50.png" width="491" height="119" />

23. As before, right-click within the whitespace of the code editor and
    select **Source Control | Commit**.

24. In **Team Explorer – Changes**, enter a commit message of “**Deniz
    version**” and then click **Commit All**. Save changes
    when prompted. Note that Deniz has committed changes to the
    master branch.

    <img src="media/image51.png" width="341" height="138" />


25. Click **Sync** from the commit response.

    <img src="media/image52.png" width="341" height="72" />

26. Click **Sync** to execute the actual sync.

    <img src="media/image53.png" width="343" height="232" />

27. Switch users back to **Sachin** by minimizing the remote
    desktop session.

### Task 2: Merging

1.  From Sachin’s perspective, he has so far created a local branch
    based off the master, made a change to a file, and then published
    that branch. He would then like to go ahead and merge his
    Development branch back into the master branch.

2.  In **Team Explorer – Branches**, select the **Merge** dropdown.

    <img src="media/image54.png" width="345" height="166" />

3.  Select **Development** as the source and **Master** as the target.
    Click **Merge** to start the process.

    <img src="media/image55.png" width="346" height="203" />


4.  Note that the **Master** repository is currently selected and that
    ***HomeController.cs*** shows the **Development** version of
    the text. The merge was performed locally by updating the **Master**
    branch to point to the latest commit of the **Development** branch.

    <img src="media/image56.png" width="570" height="119" />


5.  **Right-click** the **Master** branch in **Team Explorer –
    Branches** and select the **View History…** option.

    <img src="media/image57.png" width="297" height="295" />

6.  The history view should look identical to the one you saw earlier,
    except this time both the Development and Master branch designators
    (in red) point to the same commit.

    <img src="media/image58.png" width="624" height="76" />

7.  Still unaware of Deniz’s change that she pushed to the **Main**
    branch earlier, Sachin will now attempt to push his commit. Navigate
    to the **Team Explorer - Synchronization** view and then click
    **Sync** to attempt a pull and a push with the server.

    <img src="media/image59.png" width="345" height="242" />

````
Note: If you see a popup notifying that an open file has been changed externally, click **Yes** as this is expected.
````

8.  Visual Studio reports that we can’t push our commit yet due to
    a conflict. Click **Resolve the Conflicts**.

    <img src="media/image60.png" width="340" height="407" />

9.  In the **Team Explorer – Resolve Conflicts** view, select the
    ***HomeController.cs*** file listed under the **Conflicts** section
    and then click **Merge**.

    <img src="media/image61.png" width="349" height="258" />


10. The Merge window used for Git conflict resolution is very similar to
    the one used with Team Foundation Version Control. We will go ahead
    and assume that Sachin’s change is correct, so check the box shown
    in the top-right pane.

    <img src="media/image62.png" width="566" height="308" />


11. Click **Accept Merge**.

    <img src="media/image63.png" width="567" height="99" />


12. Click **Commit Merge**.

    <img src="media/image64.png" width="375" height="114" />

13. In the Team Explorer – Changes view, note that conflicts have been
    resolved but the merge still needs to be committed. Enter a message
    and then click the **Commit Staged** dropdown and select **Commit
    Staged and Sync**.

    <img src="media/image65.png" width="340" height="354" />


14. Click **Web Portal** from **Team Explorer – Home**.

    <img src="media/image66.png" width="234" height="167" />

15. Select the **Code | History** from the navigation.

    <img src="media/image67.png" width="469" height="144" />

16. Here we can see a full list of our commits so far.

    <img src="media/image68.png" width="491" height="441" />

17. Select the **Branches** tab to view all branches published to
    the repository.

    <img src="media/image69.png" width="624" height="135" />
 

### Task 3: Managing Security and Permissions

1.  Now let’s take a quick peek at managing security and permissions for
    Git repositories hosted in Team Foundation Server. Select the
    **FabrikamCommunity** dropdown and then **Manage Repositories**.

    <img src="media/image70.png" width="162" height="149" />

2.  The first thing to note is that you can create additional Git
    repositories within the same team project.

    <img src="media/image71.png" width="385" height="216" />

3.  Select the **FabrikamCommunity** repository node. You can manage
    repository level security here for your users and security groups.

    <img src="media/image72.png" width="624" height="290" />


4.  Select the **Master** branch node. Security level settings that
    affect only the currently selected branch can be made here,
    providing fine-grained control for your repository if needed.

    <img src="media/image73.png" width="624" height="310" />


### Task 4: Branch Policies

  When you want people on your team to review code in a Git team
    project, you can use a pull request to review and merge the code.
    Pull requests enable developers working in topic branches to get
    feedback on their changes from other developers prior to submitting
    the code into the master branch. Any developer participating in the
    review can see the code changes, leave comments in the code, and
    give a "thumbs up" approval if they're satisfied with those changes.



1.  Although it is possible to utilize pull requests without any further
    configuration, let’s take a quick look at how to setup
    branch policies. Select the **Branch Policies** tab.

    <img src="media/image74.png" width="610" height="78" />

2.  You can make use of branch policies that effectively put in a gate
    that helps prevent inadvertent or low quality commits by
    automatically initiating a build, or by requiring code reviews by
    certain individuals. Select the option to **Require…reviewers per
    pull request** and set the minimum number of reviewers to “1”.

    <img src="media/image75.png" width="340" height="106" />

````
    Note:** It is also possible to configure branch policy such that a build is triggered whenever updates are made to the master branch.
    You can even have the merge fail when the build fails. This is
    useful for teams looking to adopt continuous integration.
````


3.  It is also possible to require specific reviewers for specific
    portions of your code base. For example, let’s say that Sachin needs
    to sign off on all changes made to the ASP.NET MVC controllers.
    Click **Add a new path**.

    <img src="media/image76.png" width="411" height="177" />

4.  Leave the default options of **Enabled** and **Required** selected,
    set the **Path** to be everything in the **Controllers** folder, and
    then click **Add User**.

    <img src="media/image77.png" width="624" height="61" />

5.  Select **Sachin Raj** from the Add Required Reviewers window and
    then click **Save Changes**.

    <img src="media/image78.png" width="624" height="274" />

6.  Click **Save Changes** to update the master branch policies. Close
    the administration browser tab.

    <img src="media/image79.png" width="623" height="121" />


### Task 5: Code Review and Merge using Pull Requests

1.  Switch back to the **Deniz** RDP session.

2.  In the **Team Explorer - Branches** view, double-click **master** to
    change to that branch.

3.  In the **Team Explorer - Synchronization** view, note that there are
    two incoming commits listed (if there are not, try a
    **Fetch** operation).

4.  Click **Sync** to ensure that the local copy of master matches
    what’s on the server. If you have **HomeController.cs** open in the
    editor, you may be prompted to reload it.

    <img src="media/image80.png" width="344" height="211" />


5.  Now let’s say that Deniz is working on the project and needs to
    update some of the controller code. To do this, she will first
    create a topic branch based on master. In **Team Explorer -
    Branches**, right-click the **master** branch and select **New Local
    Branch From**…

    <img src="media/image81.png" width="343" height="323" />

6.  For the branch name, use something like
    “**users/deniz/controllerupdate**”. Use the default option to
    “**Checkout branch**”. Click **Create Branch**.

    <img src="media/image82.png" width="339" height="168" />


7.  Update the **About** method from **HomeController.cs** with a new
    message, something like “**Deniz’s enhanced description page.**”

    <img src="media/image83.png" width="490" height="115" />


8.  In **Team Explorer - Changes**, provide a commit message and then
    **Commit All**. Save the changes when prompted.

    <img src="media/image84.png" width="341" height="143" />

9.  In **Team Explorer - Branches**, right-click the topic branch and
    select **Publish Branch**.

    <img src="media/image85.png" width="345" height="400" />

10. After successfully publishing the branch, click **Create a pull
    request**. This will open the pull request on the portal via
    your browser.

    <img src="media/image86.png" width="346" height="115" />

11. Click **New pull request** to create a pull request with the
    default options.

    <img src="media/image87.png" width="624" height="398" />

12. After the pull request is created, note that the pull request view
    shows what merge is proposed, Deniz’s description is provided, and
    there are tabs listing affected files and commits. It also indicates
    that there are no merge conflicts detected, and that due to branch
    policy, Sachin must approve the changes in order to proceed

    <img src="media/image88.png" width="624" height="266" />

13. To demonstrate the branch policy in action, let’s say Deniz attempts
    to complete the pull request by herself. Click **Complete** and then
    **Complete Merge**.

    <img src="media/image89.png" width="378" height="68" />


14. Note that Deniz is notified that the request first needs to be
    approved by all required reviewers first.

    <img src="media/image90.png" width="624" height="157" />

15. At this point in the workflow, Sachin needs to be notified of this
    pull request through some communication channel, whether that is in
    person, through Skype, through team room notification, or via TFS
    pull request alert. For the purposes of this short exercise,
    however, we will just skip to Sachin checking pull requests for
    this project.

16. Switch users back to **Sachin**.

17. In the web portal, navigate to the **FabrikamCommunity** project and
    select **Code | Pull Requests** view.

    <img src="media/image91.png" width="463" height="198" />

18. Select the link provided on the pull request from Deniz.

    <img src="media/image92.png" width="415" height="177" />

19. At this point, Sachin can review all of the files and commits
    associated with the pull request and make a decision. It is also
    possible for Sachin to have a conversation with Deniz (and perhaps
    other reviewers) in order to help make the decision, or perhaps even
    request additional work be performed before the pull request will
    be approved.

20. Let’s assume that Sachin is ready to approve the request as-is, so
    select **Approve | Approve**.

    <img src="media/image93.png" width="396" height="224" />

21. Now that all policies have been fulfilled, click **Complete** and
    **Complete merge** to finish the process.

    <img src="media/image94.png" width="412" height="54" />

22. Switch users back to **Deniz**.

23. Refresh the pull request view and note that it has been updated as
    expected with the actions made by Sachin.

    <img src="media/image95.png" width="624" height="282" />