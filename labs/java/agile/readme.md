---
title:  Managing your team project backlog
layout: page
sidebar: java
permalink: /labs/java/agile/
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

1. Login to your VSTS account and navigate to your project

1. Click the **Work** link.

1. On the left, click the **Features** link.

    ![](images/image2.png)

    You are now on the **Features** backlog.

    ![](images/image3.png)

1. In the Title box, enter **Intranet Site Updates** and press Enter.

1. Let us add another feature. In the Title box, enter **Internet Site
    Updates** and press Enter.

    You now have defined two features.

    ![](images/image4.png)

1. Double-click the **Intranet Site Updates** feature to open the
    feature details and enter additional information such as who owns
    the feature, status, expected completion date, etc.

    ![](images/image5.png)

1. Change the value of the **State** field from **New** to **In Progress**.

    ![](images/image6.png)

1. Press tab to move to the **Assigned To** field, which current is set
    to **Unassigned**. Assign it to yourself.

1. Select the **Iteration** field. Expand the combo-box to see the
    available values.

    ![](images/image7.png)

1. Select **Sprint 1**.

1. In the **Description** field, type a short note like, **Complete
    updates to Intranet site for partners**.

    > Note this is a rich text field, and you can use various types of
    formatting.

    ![](images/image8.png)

1. Click the links button on the right of the form.

    ![](images/image9.png)

1. Click the **Add link** drop down menu and select **New item** link.

    ![](images/image10.png)

1. Change the **Work item type** field to **Product Backlog Item** and
    make sure the **Link type** is set to **Child**.

1. In the **Title** field, enter **Site Fit & Finish**.

    ![](images/image11.png)

1. Click **OK**. Visual Studio Team Services opens up the New Product
    Backlog Item screen. Feel free to add a description.

1. When ready, click **Save and close**.

    ![](images/image12.png)

1. Back on the Feature dialog, click **Save and close** to update and
    close the feature.

1. Click the **Backlog Items** link to return to that backlog.

    ![](images/image13.png)

1. Double-click on the **Site Fit & Finish** Product Backlog Item (PBI)
    in the list to open up the dialog

1. Change the **State** to **Committed**. You’ll notice that it is
    assigned to you automatically because the parent feature was
    assigned to you.

1. Click the links button on the right of the form.

    ![](images/image9a.png)

1. Click the **Add link** drop down menu and select **New Item** link.

    ![](images/image10.png)

1. Change the **Work item type** field to **Task** and make sure the
    **Link type** is set to **Child**.

1. In the **Title** field, enter **Add master branding**. Click **OK**
    when ready.

1. Feel free to explore a bit, add a description if you like and then
    click **Save and close** to finish using Task dialog.

1. Back at the PBI screen, Click **Save and close** to close the Product
    Backlog Item.

1. Click the small triangle to the left the Explore VS Team
    Services PBI.

    ![](images/image14.png)

    You can now see any of the child tasks associated with the PBI.

    ![](images/image15.png)

    You can also see parent items (in the case Features).

1. On the command bar above the backlog, click the Hide link to the
    right of the Parents label to “show” the parent Features.

    ![](images/image16.png)

    You now can see the Parent Features.

    ![](images/image17.png)

1. Under the Backlog items title, click the Board link.

     ![](images/image18.png)

1. In the Committed column, on the only card, click the
    ![](images/image19.png) item.

    ![](images/image20.png)

    You can see the child task here.

1. Click the **+ Add task** item.

1. In the open text area, type **Add master navigation to menu page**
    and press **Enter**.

    ![](images/image21.png)

    You can see all of your work for the active sprint by accessing the
**Task Board**.

1. On the left, click **Sprint 1** under **Current**.

    ![](images/image22.png)

    Now you can see your work for just the current sprint.

    ![](images/image23.png)

    You need to assign the **Add master navigation to menu page** Task to you.

1. Move your mouse and hover over the card and you will get a combo-box
    that opens up.

    ![](images/image24.png)

1. Assign the task to yourself.

    One more thing you need to do is add an estimate for each work item.

1. In the task board, mouseover at the bottom right corner of the task card and enter the value **1**. This is the **Remaining Work** field, you can also open the work item and then update **Remaining Work** field value and save the changes. Repeat this for another task in task board.

    ![](images/image25.png)

    Now you want to show that you have started working.

1. Drag and drop the **Add Master Branding** work item to the **In
    progress** column.

    ![](images/image26.png)

1. In the upper right corner of the Task board, click the **Settings**
    icon

    ![](images/image27.png)

    This opens the Settings dialog where you can make adjustments to many
    features of the Work Hub including the Task board.

1. For **Task**, check the **Show ID** checkbox to show the work item ID
    on the cards.

    ![](images/image28.png)

1. Click **Save and Close** when done.

    Now you will be able to see the Work Item ID easily when you look at
    the Task board. You will use the IDs later when you commit code to
    your Git repo in the next exercise.

This is a quick introduction to the Agile Planning tools and Work Items. You will work with them again later. If you want to read more about the Agile Planning tools, Sprint Planning, and the Scrum
template follow this [link](https://msdn.microsoft.com/en-us/Library/vs/alm/Work/scrum/sprint-planning)
