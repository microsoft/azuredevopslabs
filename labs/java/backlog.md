---
title:  Managing your team project backlog
layout: page
sidebar: java
permalink: /labs/java/agile.html
folder: /labs/java/agile/
---

## Managing your team project backlog

In this exercise, you are going to examine the various portfolio
planning features of Visual Studio to group and manage your work and
that of your team using backlogs. This exercise assumes you have
completed Exercise 1, and have created a Team Project using the Scrum
template with a Git repo.


This exercise uses a team project named **jdev** (if you have chosen a
different name for your project, select the project you created in the
previous exercise). For this first part, you will create work items for
you in the lab. Later, you will create some more work items as you work
through the MyShuttle scenario.

1.  Login to your VSTS account and navigate to your project

2.  Click the **Work** link.

3.  On the left, click the **Features** link.  

    <img src="./images/backlog/image2.png" width="468" height="213" />

    You’re now on the **Features** backlog.

    <img src="./images/backlog/image3.png" width="468" height="160" />

1.  In the Title box, enter **Intranet Site Updates** and press Enter.

2.  Let’s add another feature. In the Title box, enter **Internet Site
    Updates** and press Enter.

    You now have defined two features.

    <img src="./images/backlog/image4.png" width="468" height="180" />

1.  Double-click the **Intranet Site Updates** feature to open the
    feature details and enter additional information such as who owns
    the feature, status, expected completion date, etc.

    <img src="./images/backlog/image5.png" width="698" height="329" />

1.  Change the value of the **State** field from **New** to **In
    Progress**.

    <img src="./images/backlog/image6.png" width="364" height="215" />

1.  Press tab to move to the **Assigned To** field, which current is set
    to **Unassigned**. Assign it to yourself.

2.  Select the **Iteration** field. Expand the combo-box to see the
    available values.

    <img src="./images/backlog/image7.png" width="977" height="441" />

1.  Select **Sprint 1**.

2.  In the **Description** field, type a short note like, **Complete
    updates to Intranet site for partners**.

    Note this is a rich text field, and you can use various types of
    formatting.

    <img src="./images/backlog/image8.png" width="629" height="344" />

1.  Click the links button on the right of the form.

    <img src="./images/backlog/image9.png" width="264" height="48" />

1.  Click the **Add link** drop down menu and select **New item** link.

    <img src="./images/backlog/image10.png" width="244" height="167" />

1.  Change the **Work item type** field to **Product Backlog Item** and
    make sure the **Link type** is set to **Child**.

2.  In the **Title** field, enter **Site Fit & Finish**.

    <img src="./images/backlog/image11.png" width="749" height="604" />

1.  Click **OK**. Visual Studio Team Services opens up the New Product
    Backlog Item screen. Feel free to add a description.

2.  When ready click **Save and close**.

    <img src="./images/backlog/image12.png" width="316" height="97" />

1.  Back on the Feature dialog, click **Save and close** to update and
    close the feature.

2.  Click the **Backlog Items** link to return to that backlog.

    <img src="./images/backlog/image13.png" width="292" height="99" />

1.  Double-click on the **Site Fit & Finish** Product Backlog Item (PBI)
    in the list to open up the dialog

2.  Change the **State** to **Committed**. You’ll notice that it’s
    assigned to you automatically because the parent feature was
    assigned to you.

3.  Click the links button on the right of the form.

    <img src="./images/backlog/image9a.png" width="286" height="51" />

1.  Click the **Add link** drop down menu and select **New Item** link.

    <img src="./images/backlog/image10.png" width="246" height="169" />

1.  Change the **Work item type** field to **Task** and make sure the
    **Link type** is set to **Child**.

2.  In the **Title** field, enter **Add master branding**. Click **OK**
    when ready.

3.  Feel free to explore a bit, add a description if you like and then
    click **Save and close** to finish using Task dialog.

4.  Back at the PBI screen Click **Save and close** to close the Product
    Backlog Item.

5.  Click the small triangle to the left the Explore VS Team
    Services PBI.

    <img src="./images/backlog/image14.png" width="347" height="71" />

    You can now see any of the child tasks associated with the PBI.

    <img src="./images/backlog/image15.png" width="370" height="71" />

    You can also see parent items (in the case Features).

1.  On the command bar above the backlog, click the Hide link to the
    right of the Parents label to “show” the parent Features.

    <img src="./images/backlog/image16.png" width="513" height="37" />

    You now can see the Parent Features.

    <img src="./images/backlog/image17.png" width="468" height="219" />

1.  Under the Backlog items title, click the Board link.

     <img src="./images/backlog/image18.png" width="146" height="55" />

1.  In the Committed column, on the only card, click the
    <img src="./images/backlog/image19.png" width="43" height="32" /> item.

    <img src="./images/backlog/image20.png" width="170" height="175" />

    You can see the child task here.

1.  Click the **+ Add task** item.

2.  In the open text area, type **Add master navigation to menu page**
    and press **<span style="font-variant:small-caps;">Enter</span>**.

    <img src="./images/backlog/image21.png" width="167" height="210" />

    You can see all of your work for the active sprint by accessing the
**Task Board**.

1.  On the left, click **Sprint 1** under **Current**.

    <img src="./images/backlog/image22.png" width="152" height="200" />

    Now you can see your work for the just the current sprint.

    <img src="./images/backlog/image23.png" width="279" height="173" />

    You need to assign the **Add master navigation to menu page** Task to you.

1.  Move your mouse and hover over the card and you’ll get a combo-box
    that opens up.

    <img src="./images/backlog/image24.png" width="254" height="139" />

1.  Assign the task to yourself.

    One more thing you need to do is add an estimate for each work item.

2.  In the task board mouse over at the bottom right corner of the task card and enter the value **1**. This is nothing but **Remaining Work** field , you can also open the work item and then update **Remaining Work** field value and save the changes. Repeat this for another task in task board.
    
    <img src="./images/backlog/image25.png" width="335" height="123" />

    Now you want to show that you’ve started working.

1.  Drag and drop the **Add Master Branding** work item to the **In
    progress** column.

    <img src="./images/backlog/image26.png" width="335" height="123" />

1.  In the upper right corner of the Task board, click the **Settings**
    icon

    <img src="./images/backlog/image27.png" width="226" height="27" />

    This opens the Settings dialog where you can make adjustments to many
    features of the Work Hub including the Task board.

1.  For **Task** check the **Show ID** checkbox to show the work item ID
    on the cards.

    <img src="./images/backlog/image28.png" width="240" height="90" />

1.  Click **Save and Close** when done.

    Now you’ll be able to see the Work Item ID easily when you look at
    the Task board. You’ll use the IDs later when you commit code to
    your Git repo in the next exercise.

<pre>This is a quick introduction to the Agile Planning tools and Work Items. You’ll work with them 
some more later. If you want to read more about the Agile Planning tools, Sprint Planning, and the Scrum
template follow this <a href="https://msdn.microsoft.com/en-us/Library/vs/alm/Work/scrum/sprint-planning">link</a></pre>
