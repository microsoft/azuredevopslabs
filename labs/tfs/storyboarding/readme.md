---
title: Building the Right Software - Generating Storyboards with Visual Studio 2017
layout: page    
sidebar: tfs
permalink: /labs/tfs/storyboarding/
folder: /labs/tfs/storyboarding/
---

Lab version: 15.0.26020.0

Last updated: 1/24/2017

## Overview


How often have you built the software that your users asked for, but not necessarily what they wanted? In a world of increasingly complex
software projects, it is critical that we can accurately capture  requirements from users, which can then be translated into working software. 
In this lab, you’ll learn how the capabilities of Visual Studio 2017 make it possible to both rapidly storyboard your requirements, and – as your 
software evolves – get rich, actionable feedback from users of your software which can help shape what you deliver.

## Pre-requisites
In order to complete this lab you will need the Microsoft Visual Studio 2017 ALM virtual machine provided by Microsoft. For more information on
acquiring and using this virtual machine, please see [this  post](http://aka.ms/almvm).
    
## Exercise 1: Introduction to Storyboarding

In this exercise, you will learn how to use the PowerPoint storyboarding add-in to create application storyboards. This will be accomplished by examining an existing storyboard file and by adding in some additional storyboard slides to address an additional user story.

### Task 1: Creating a Storyboard Linked to Work Item

1.  Log in as **Sachin Raj** (VSALM\\Sachin). All user passwords are
    **P2ssw0rd**.

2.  Launch **Internet Explorer** from the taskbar and select the **TFS FF Portal** button from the favorites bar at the top.

    <img src="./media/image1.png" width="354" height="53" />

3.  Locate the **New work item** tile. Enter the title “Service rep can view service ticket details from the dashboard” and select the type
    as **Product Backlog Item**. Click **Create** to create. 

    <img src="./media/image2.png" width="618" height="207" />

4.  When the dialog opens, click **Save** to save (but not close)
    the item.

    <img src="./media/image3.png" width="415" height="220" />

5.  Locate the **Storyboards** tab and then click **Start
    Storyboarding**.

    <img src="./media/image4.png" width="598" height="274" />

6.  Select the **Allow** button when prompted.

    <img src="./media/image5.png" width="415" height="289" />

7.  At this point, the new storyboard can be created from scratch using
    the full power of PowerPoint, including the tooling found in the
    **Storyboarding** tab. For the purposes of this lab, however, we
    will jump ahead to a storyboard that is already in progress. Close
    the PowerPoint window without saving any changes.

8.  Select the **Link To** button. If you have existing storyboards,
    such as in SharePoint, you could link to them here so that others
    can easily access and edit them.

    <img src="./media/image6.png" width="592" height="285" />

9.  This **Location** would be to a SharePoint location that is
    accessible to all team members. Click **Cancel**.

    <img src="./media/image7.png" width="557" height="209" />

### Task 2: Creating Storyboards in PowerPoint


1.  Open the PowerPoint file at **C:\\Samples\\FF Storyboard -
    Start.pptx**.

    <img src="./media/image8.png" width="406" height="176" />

2.  Select the **Storyboarding** tab at the top of the
    PowerPoint window.

    <img src="./media/image9.png" width="502" height="110" />

    **Note:** If you wanted to create a new storyboard from scratch,
        you would do so simply by loading PowerPoint and selecting the
        “blank presentation” option. Then use the tools provided in the
        Storyboarding tab.

3.  These storyboard slides show how the PowerPoint storyboarding add-in
    can be used to mock up UI for web and mobile applications. You can
    take advantage of slide masters and different layouts to create
    re-usable templates that are set up for your application. Select the
    **Layout** button to see some of the layouts that are available in
    this storyboarding PowerPoint file.

    <img src="./media/image10.png" width="539" height="323" />

    **Note:** If you wanted to make modifications to the slide
        master layouts, you would do so by selecting the **Edit Layout**
        button from the **Storyboarding** tab.

    <img src="./media/image11.png" width="265" height="71" />

4.  Press the **F5** key to view the storyboard in presentation mode.
    Click through the slides with the mouse or press the right arrow key
    until the presentation is finished. Note that the storyboard
    provides the look and feel for certain pieces of a web application
    and a Windows Phone application. Animations are used to show how the
    user is interacting with the application.

5.  Now let’s create some additional storyboards for the Fabrikam Fiber
    intranet site, where employees interface with customer data and
    service tickets. When creating storyboards, it can be helpful to
    document specific scenarios that translate to user stories for the
    development team to implement and test.

6.  Delete all the existing slides so that we can concentrate on the new
    user story (press **Ctrl-A** followed by **Delete**).

    <img src="./media/image12.png" width="618" height="274" />

7.  Select the **New Slide** drop-down button and choose the
    “**1\_Default**” layout from the “**Web Browser**” slide master.

    <img src="./media/image13.png" width="327" height="333" />

8.  Take a look at the new storyboard slide to see everything that is
    provided by the slide master. The entire chrome for the web
    application is there, which helps keep our storyboard slides
    looking consistent.

    <img src="./media/image14.png" width="575" height="434" />

9.  Note that the slide master also includes some placeholders for the
    web page title and address, which are editable. Modify the “**Web
    page title**” placeholder by entering “**Dashboard**” instead. This
    slide is going to represent the Dashboard page, which is designed to
    show a rollup of tickets, alerts & messages, and other
    company-wide information.

    <img src="./media/image15.png" width="295" height="154" />

10. As a quick aside, load the Fabrikam Fiber intranet site in Internet
    Explorer by clicking on the **FF Intranet** button in the favorites
    bar (<http://intranet.fabrikam.com>). This loads the Dashboard page.
    Take a glance at the UI shown here so that we can duplicate some of
    it in the storyboards.

    **Note:** Although storyboards normally precede implementation,
        in this lab you will occasionally refer to both storyboards in
        development and the finished product in order to help speed up
        the demonstration.

    <img src="./media/image16.png" width="623" height="455" />

11. Back in PowerPoint, add a new **Text Box** to the first slide.

    <img src="./media/image17.png" width="618" height="113" />

12. Enter the text “**Dashboard**” for the new text box to create the
    heading for this page and position it as shown in the
    following screenshot. Make the text **bold**, use font size of
    **16**, and select a **gray** font color.

    <img src="./media/image18.png" width="450" height="240" />

13. Now let’s create a button named “**Create New**” below the
    Dashboard title. Select the **Storyboard Shapes** button from the
    Storyboarding tab to load the panel.

    <img src="./media/image19.png" width="618" height="126" />

14. In the **Storyboard Shapes** panel on the right-hand side, type
    “**button**” into the search box to locate the Button shape.

    <img src="./media/image20.png" width="362" height="305" />

15. Drag and drop an instance of the **Button** shape from the Windows
    Apps category onto the slide, as it closely matches the shape of the
    existing buttons on the site

    <img src="./media/image21.png" width="624" height="301" />

16. Imagine that Fabrikam Fiber has a UI style guideline in place that
    we must adhere to. Change the text from the default to “**Create
    New**”, choose a **white** font color, and choose an **orange**
    shape fill color to match the required design.

    <img src="./media/image22.png" width="359" height="108" />

17. As you are storyboarding, you can create your own shapes to
    reuse later. Select the new button that you just created, select the
    **Add to My Shapes** button from the **Storyboarding** tab, and name
    the new shape “**Fabrikam Button**”.

    **Note:** Make sure you select the outer edge of the button
        shape (not the center part) in order to make the Add to My
        Shapes button available.

    <img src="./media/image23.png" width="618" height="200" />

18. You can sometimes speed up the storyboarding process by reusing
    existing assets. In this case, let’s take a screen clipping of the
    rest of the existing Dashboard page, rather than adding an actual
    data grid and manually populating it with data. First, ensure that
    the Internet Explorer window currently showing the Fabrikam Fiber
    intranet portal is visible and not minimized. Next, in the
    Storyboarding tab of PowerPoint, select the **Screenshot** drop down
    button and then select the **Screen Clipping** option.

    <img src="./media/image24.png" width="355" height="267" />

19. After PowerPoint minimizes itself to show the greyed-out Fabrikam
    Fiber Dashboard page, click and hold the left mouse button on the
    upper-left corner of the grid, move to the bottom-right to include
    Network Alerts, Messages, and so on, and then finally let the left
    mouse button up to select the region to use for the screen clipping.

    <img src="./media/image25.png" width="510" height="439" />

20. Back in PowerPoint, position and re-size the screen clipping so that
    it fits in nicely right below the Create New button.

    <img src="./media/image26.png" width="624" height="467" />

21. Back to the scenario we are storyboarding, imagine that the employee
    sees this dashboard and is concerned about one of the tickets that
    has been open for a long time without resolution or escalation, so
    she decides to view it by clicking on the reference number link.
    This should then load a view that shows the service ticket details.

    <img src="./media/image27.png" width="624" height="281" />

22. Start storyboarding this scenario by creating a **new slide** using
    the same layout as before. The new slide should go right after the
    first one that you created.

    <img src="./media/image13.png" width="327" height="333" />

23. Next, add in some fake ticket details (as shown in the
    screenshot below) using the techniques shown in this lab so far. In
    addition, make use of the **Street Map** and **Map Marker**
    storyboarding shapes to help represent the location of the
    customer residence.

    <img src="./media/image28.png" width="624" height="424" />

24. When storyboarding in PowerPoint, you can also build in a
    representation for the flow of an application using hyperlinks
    from shapes. Select the first slide that shows the Dashboard, then
    select the image that shows the grid of tickets, and finally click
    the **Hyperlink** button from the **Storyboarding** tab.

25. **Note:** If we chose to create this slide using a proper grid from
    the Storyboard Shapes menu, instead of a screen clipping, we would
    be able to create a hyperlink from a specific cell instead.

    <img src="./media/image29.png" width="618" height="371" />

26. In the **Insert Hyperlink** window, select the **Place in This
    Document** option, choose the **second slide**, and select **OK** to
    create the link.

    <img src="./media/image30.png" width="624" height="324" />

27. We can also take advantage of PowerPoint animations in order to
    improve the presentation of the storyboards. Return to the first
    slide (if not already there) and search for the “***mouse
    pointer***” shape in the **Storyboard Shapes** window. Drag and drop
    an instance of the mouse pointer onto the slide. This shape will be
    used to represent the user clicking on one of the service tickets on
    the Dashboard.

    <img src="./media/image31.png" width="624" height="256" />

28. Make the mouse pointer shape larger so that it is easier to see.

    <img src="./media/image32.png" width="422" height="191" />

29. In the **Animations** tab, select the **Add Animation** drop-down
    and select the **Custom Path** option near the bottom (scroll down
    to find it).

    <img src="./media/image33.png" width="618" height="371" />

30. Use the mouse to draw a path from the current location of the Mouse
    Pointer shape to one of the service ticket hyperlinks (the grid is
    just a picture). To do this, hold the left mouse button down near
    the Mouse Pointer shape and draw a line to the hyperlink, letting go
    of the mouse button and pressing the **Escape** key when done.

    <img src="./media/image34.png" width="624" height="277" />

31. Press the **F5** key to view the storyboard in presentation mode.
    Press the right arrow key to start the mouse cursor animation. When
    it reaches the hyperlink for the service ticket, press the right
    arrow key to navigate to the second slide. Press the **Esc** key
    when finished.

32. Close PowerPoint without saving changes.

