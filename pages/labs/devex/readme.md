# Collaboration Experiences for Development Teams using Team Foundation Server 2017

<p align="center">
<img src="./media/image1.png"/>
</p>

## Overview

In this lab, you’ll learn about some of the features in Visual
    Studio 2017 and Team Foundation Server 2017 that enable
    collaboration experiences for development teams including Team
    Rooms, Lightweight Code Comments, and CodeLens.

### Pre-requisites

In order to complete this lab you will need the Visual Studio 2017
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

* Team Room Collaboration

* Lightweight Code Comments

* CodeLens

Estimated time to complete this lab: **60 minutes**.


## Exercise 1: Team Room Collaboration

In this exercise, you will learn about the Team Room feature in Team
    Foundation Server 2017 (and at visualstudio.com). Team Rooms provide
    a durable collaboration space where members can chat and view
    pertinent events, thereby allowing them to remain in loose contact
    throughout the workday.

#### Task 1: Team Rooms Introduction

1.  Log in as **Sachin Raj** (VSALM\\Sachin). All user passwords are
    **P2ssw0rd**.

2.  Launch **Internet Explorer** from the taskbar and click the **TFS
    Portal** button from the favorites bar at the top.

    <img src="./media/image2.png" width="269" height="83" />

    **Note:** There is also a **Web Portal** link in the Team Explorer
    window within Visual Studio.

    <img src="./media/image3.png" width="343" height="206" />

3.  Click the **Rooms** link to navigate to the first team room.

    <img src="./media/image4.png" width="412" height="137" />

    **Note:** There is also a team room tile on the home page of
    each project.

    <img src="./media/image5.png" width="573" height="324" />

4.  Each team under a project has a room created for them, which you can
    browse from the **Rooms Explorer** on the left side of the screen.
    Select the **Fabrikam Fiber Team Room** to visit that room.

    <img src="./media/image6.png" width="246" height="214" />

5.  On the right side you can participate in team discussions. By
    default, the room shows the recorded messages and activity for the
    current day.

    <img src="./media/image7.png" width="648" height="284" />

6.  Since the team room content is persistent, team members can go back
    in time to see what happened while they were gone from work. Click
    the back arrow to the left of the current date.

    <img src="./media/image8.png" width="480" height="83" />

7.  It appears that we didn’t miss anything important in the team room,
    so we can return to the current date by clicking the **Live** link.

    <img src="./media/image9.png" width="472" height="75" />


#### Task 2: Team Room Mentions and Links

1.  Now let’s take a look at some of the types of mentions and links
    that can be inserted via team room chat. The first type is the team
    member mention, which can be inserted anywhere by typing the ‘**@**’
    symbol followed by the name. As Sachin, try this out by typing
    “**good morning @**” into the textbox at the bottom of the window.
    Note that a list of room members is presented as soon as you type
    the ‘@’ symbol.

    <img src="./media/image10.png" width="536" height="346" />

2.  Continue typing **‘Brian Keller**’ or select his name from the list
    and then press **Enter**.

    <img src="./media/image11.png" width="518" height="42" />

3.  Before we move on, go ahead and get another team member connected to
    the room using remote desktop. In the new remote desktop window,
    login with user name “**VSALM\\Brian**” and password “**P2ssw0rd**”.
    Once connected and logged in, navigate to the **Default Team Room**
    as you previously did.

    **Note:** You can also RDP to ‘localhost’ from within the VM itself.

4.  Note that **Brian’s** view of the message from Sachin renders
    differently than it would for others since he was the
    person addressed.

    <img src="./media/image12.png" width="648" height="162" />

5.  Another type of mention can be used for referencing project
    work items. As **Sachin**, add a message to the team that mentions
    work item \#236.

    <img src="./media/image13.png" width="417" height="66" />

6.  Click the work item link from the team room chat to see that it does
    link to the specified work item.

    <img src="./media/image14.png" width="551" height="61" />

    <img src="./media/image15.png" width="648" height="347" />

7.  Close the tab showing the work item to return to the team room chat.

8.  Some other patterns render as links include URLs, UNC network paths,
    and email addresses.

    <img src="./media/image16.png" width="516" height="165" />

#### Task 3: Team Room Events

1.  Another key feature of team rooms is that various events can be
    selected and configured to automatically feed in additional
    information, thereby providing additional context to active and
    historical team discussions. Click **Manage events…**.

    <img src="./media/image17.png" width="143" height="230" />

2.  The **Configure Events for Fabrikam Fiber Team Room** window that
    appears shows four different options, **Build Completion**, Code
    Changes, Work Item Updates, and Code Reviews. Build completion
    events can be setup to appear whenever selected builds complete.

    <img src="./media/image18.png" width="632" height="330" />

3.  Select the **Code Changes** tab. These events can be setup to appear
    whenever code is checked into selected team projects.

    <img src="./media/image19.png" width="631" height="319" />

4.  Click the **Work Item Updates** tab. These events can be setup to
    appear whenever a work item is created or an existing work item has
    the state or assignment changed. Let’s set this event up by checking
    the box next to the area path and then clicking **Save and Close**
    to use the default options.

    <img src="./media/image20.png" width="630" height="325" />

5.  Navigate to work item **\#236** in TFS web access by clicking the
    link in the room chat window.

    <img src="./media/image21.png" width="516" height="165" />

6.  Change the work item from state to **In Progress** and then click
    **Save**.

    <img src="./media/image22.png" width="364" height="299" />

7.  Return to the room and note that an event is raised in the chat
    window describing the state transition. It should only take a moment
    for it to show up, but you can also refresh the page after a few
    minutes if needed.

    <img src="./media/image23.png" width="444" height="46" />

8.  The Team Room feature has been designed with extensibility in mind,
    so that will allow development teams to add in custom events and
    clients in the future. If you are interested in learning more about
    this extensibility, look at the [Team Rooms REST
    API](https://www.visualstudio.com/en-us/integrate/api/chat/overview)
    for more information.

## Exercise 2: Lightweight Code Comments
-----------------------------------------------------------------------------------------------------------------------------------

In this exercise, you will learn about the Lightweight Code Comment
    feature (first introduced with Team Foundation Server 2013), that
    allows team members to comment on code. This enables interactive or
    time shifted conversations about code, all from a very nice inline
    experience in the browser.

1.  Log in as **Sachin Raj** (VSALM\\Sachin) if not already logged in.
    All user passwords are **P2ssw0rd**.

2.  Launch **Internet Explorer** from the taskbar and click the **TFS FF
    Portal** button from the favorites bar at the top.

    <img src="./media/image24.png" width="256" height="93" />

3.  Select **Code | Changesets**.

    <img src="./media/image25.png" width="498" height="177" />

4.  Load changeset 75 by entering “**75**” into the changeset search box
    and pressing **Enter**.

    <img src="./media/image26.png" width="605" height="51" />

5.  This changeset contains two file edits, with the changes highlighted
    in the diff viewer.

    <img src="./media/image27.png" width="648" height="714" />

6.  Click the **Add Comment** button to add a comment to the changeset.

    <img src="./media/image28.png" width="648" height="218" />

7.  Enter a comment such as “**What was the reason for changing the
    connection strings?**” Press **Enter** when done.

    <img src="./media/image29.png" width="365" height="232" />

8.  To comment on a specific file, click the first **Web.config** link
    to load that specific edit.

    <img src="./media/image30.png" width="560" height="176" />

9.  Click the **Add Comment** button.

    <img src="./media/image31.png" width="457" height="194" />

10. Add a short comment of your choosing.

    <img src="./media/image32.png" width="648" height="201" /> Figure 29

11. Move the mouse cursor over the lines of the file and note that the
    same **Add Comment** button appears in the margin. Click that button
    while holding the mouse cursor over one of the lines to add a line
    comment of your choice.

    <img src="./media/image33.png" width="486" height="89" />

    <img src="./media/image34.png" width="426" height="142" />

    **Note:** You can even highlight parts of a sentence and comment on
    them if desired.


12. Connect to the VM as **Brian** using the same method that you chose
    in exercise 1, and then navigate to **changeset 75** in the Fabrikam
    Fiber web portal. Note that you can see the comments left by Sachin.

    <img src="./media/image35.png" width="528" height="566" />


13. Click **reply** within Sachin’s first comment and leave a response
    to his question.

    <img src="./media/image36.png" width="391" height="241" />

    <img src="./media/image37.png" width="378" height="293" />
 

## Exercise 3: CodeLens

In this exercise, you will learn about the CodeLens feature first
    introduced with Visual Studio 2013 and Team Foundation Server 2013
    that provides code insights about classes, methods, and properties
    directly within the code editor.

1.  Log in as **Sachin Raj** (VSALM\\Sachin) if not already. All user
    passwords are **P2ssw0rd**.

2.  Launch **Visual Studio 2017** from the taskbar.

3.  In **Team Explorer – Home**, click **Source Control Explorer**.

    <img src="./media/image38.png" width="350" height="304" />

4.  Locate the **Dev** branch and open **FabrikamFiber.CallCenter.sln**.

    <img src="./media/image39.png" width="563" height="202" />

5.  In **Solution Explorer**, expand the **FabrikamFiber.Web |
    Controllers** folder and double-click **CustomersController.cs** to
    open it.

    <img src="./media/image40.png" width="394" height="325" />

6.  After loading **CustomersController.cs** in the code editor, note
    that both the class and its methods show a single line
    of indicators. These indicators are meant to provide developers a
    heads-up-display of sorts - with information about how the code is
    being used, tested, and changed.

    **Note:** CodeLens is available for managed code only.

    <img src="./media/image41.png" width="624" height="273" />

7.  Scroll down to locate the **Create** method that takes a Customer
    object as a parameter, and then click the **references indicator**.
    This shows other code references to this method.

    <img src="./media/image42.png" width="624" height="168" />

    **Note:** You can also hold down the **Alt** key and press the
    number key shown above each indicator as a shortcut.

    <img src="./media/image43.png" width="370" height="98" />

8.  If you were to double-click on one of the references, you would be
    taken to the specified location in code. Press the **Escape**
    key instead.

9.  Click the **Timeline** indicator above the same Create method
    as before. Note that before clicking it, you can see who made the
    most recent change.

    <img src="./media/image44.png" width="624" height="211" />

10. Click the **Authors & Changes** indicator to view all authors,
    changeset descriptions, and dates.

    <img src="./media/image45.png" width="624" height="163" />

11. **Right-click** one of the rows shown for the expanded
    **Changes** indicator. Note that you can choose to view the diff,
    view the changeset details, track the changset, get this version, or
    even send email to the author.

    <img src="./media/image46.png" width="618" height="170" />

12. Press the **Escape** key.

13. Press **Ctrl+Shift+B** to build the solution.

14. Click the **Tested By** indicator shown above the Create method.
    This lens currently shows that associated tests have not
    been executed.

    <img src="./media/image47.png" width="624" height="138" />

15. Click **Run All** to execute the tests.

    <img src="./media/image48.png" width="325" height="97" />

16. It appears that one of the tests failed, so click the **Tested By**
    indicator once again to see which test is causing a problem.

    <img src="./media/image49.png" width="365" height="53" />

17. Let’s take a look at the test itself to determine if the fix needs
    to happen there or in the Create method being tested.
    **Double-click** the **CreateNullCustomer** test to navigate to
    its definition.

    <img src="./media/image50.png" width="624" height="86" />

18. After looking at the **CreateNullCustomer** test, we can see that it
    is expecting an **ArgumentNullException** to be thrown when the
    Create method is called with a null parameter. Note that there is
    also a **Test Status** indicator shown next to the test
    method itself.

    <img src="./media/image51.png" width="379" height="116" />

19. Select the indicator showing the failed **CreateNullCustomer** test
    to see additional summary information.

    <img src="./media/image52.png" width="624" height="195" />

20. Throwing this exception seems like a reasonable expectation, so
    let’s go ahead and make the fix in the Create method. Return to
    **CustomersController.cs** and add the following code to the
    beginning of the Create method that takes a Customer parameter.
    
````

if (customer == null)
{ 
    throw new System.ArgumentNullException("customer");
}

````


<img src="./media/image53.png" width="442" height="181" />


21. With the fix in place, click the **Tested By** indicator,
    single-click on the **CreateNullCustomer** test, and then click
    **Run** to re-run just the failed test.

 <img src="./media/image54.png" width="624" height="126" />



22. All tests that reference the Create method now pass.

  <img src="./media/image55.png" width="347" height="56" />

  **Note:** With all tests passing, nothing stands out visually in the
    CodeLens indicator line. This demonstrates one of the goals of
    CodeLens - to provide useful information without getting in the way
    or being distracting. Nevertheless the feature can be customized or
    even turned off in **Tools | Options** if desired.

<img src="./media/image56.png" width="564" height="293" />


**As a final note, CodeLens also supports a number of indicators for
    Git repositories also. This provides author, change and work item
    indicators that work very similarly to their Team Foundation Version
    Control counterparts. Unlike the CodeLens support for TFVC, CodeLens
    for Git is computed solely on the client side. This means that you
    can use the feature for any Git repository whether it is local,
    cloned from TFS Git, cloned from GitHub or another Git source.**


