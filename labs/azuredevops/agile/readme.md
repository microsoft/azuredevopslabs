---
title: Agile Planning and Portfolio Management with Azure Boards
layout: page
sidebar: vsts
permalink: /labs/azuredevops/agile/
folder: /labs/azuredevops/agile/
version: Lab version - 1.37.1
updated: Last updated - 10/11/2020
redirect_from: "/labs/vsts/agile/index.htm"
---
<div class="rw-ui-container"></div>
<a name="Overview"></a>

## Overview ##

In this lab, you will learn about the agile planning and portfolio management tools and processes provided by Azure Boards and how they can help you quickly plan, manage, and track work across your entire team. You will explore the product backlog, sprint backlog, and task boards which can be used to track the flow of work during the course of an iteration. We will also take a look at how the tools have been enhanced in this release to scale for larger teams and organizations.

<div class="bg-slap"><img src="./images/mslearn.png" class="img-icon-cloud" alt="MS teams" style="
    width: 48px; height: 48px;">Want additional learning? Check out the  <a href="https://docs.microsoft.com/en-us/learn/modules/choose-an-agile-approach/" target="_blank"><b><u> Agile approach to software development </u></b></a> module on Microsoft Learn.</div>

<a name="Prerequisites"></a>
### Prerequisites ###

- This lab requires you to complete task 1 from the <a href="../prereq/">prerequisite</a> instructions. (No cloning needed for this lab, skip Task 2)

<a name="Exercise1"></a>
## Exercise 1: Agile Project Management ##

<a name="Ex1Task1"></a>
### Task 1: Working with teams, areas, and iterations ###

1. Navigate to your Parts Unlimited project on Azure DevOps. It will be something like [https://dev.azure.com/YOURACCOUNT/Parts%20Unlimited](https://dev.azure.com/YOURACCOUNT/Parts Unlimited).

1. Open the settings page using the **Project settings** navigation located at the bottom left of the page.

    ![](images/settings.png)

1. Select the **Teams** tab. There are already a few teams in this project, but you'll make a new one for this lab. Click **New team**.

    ![](images/001.png)

1. Use **"PUL-Web"** as the **Team name** and click **Create team** (Leave defaults).

    ![](images/002.png)

1. Select the newly created team to view its details.

    ![](images/003.png)

1. By default, the new team has only you as its member. You can use this view to manage membership, notifications, dashboards, and more. But first you will want to define the schedule and scope of the team. Click **Iterations and Area Paths**.

    ![](images/004.png)

1. Select the **Iterations** tab and click **Select iterations**. This team will use the same iteration schedule that's already in place for the other teams, although you can take a different route if that's better for your organization.

    ![](images/iteration.png)

1. Select **Parts Unlimited\Sprint 1** and click **Save and close**. Note that this first sprint has already passed. This is because the demo data generator is designed to build out project history so that this sprint occurs in the past.

    ![](images/006.png)

1. Repeat the process to add **Sprint 2** and **Sprint 3** (add them as in previous step). The second sprint is our current iteration, and the third is in the near future.

    ![](images/007.png)

1. Select the **Areas** tab. By default, there is an area matching the name of the team.

    ![](images/008.png)

1. From the area dropdown, select **Include sub areas**. The default setting for all teams is to exclude sub-area paths. We will change it to include sub-areas so that the team gets visibility into all of the work items from all teams. Optionally, the management team could also choose to not include sub-areas, thereby removing work items from their view as soon as they are assigned to one of the teams.

    ![](images/009.png)

<a name="Ex1Task2"></a>
### Task 2: Working with work items ###

Work items play a prominent role in Azure DevOps. Whether describing work to be done, impediments to release, test definitions, or other key items, work items are the workhorse of modern projects. In this task you'll focus on using various work items to set up the plan to extend the Parts Unlimited site with a product training section. While it can be daunting to build out such a substantial part of a company's offering, Azure DevOps and the Scrum process make it very manageable.

![](images/010.png)

This task is designed to illustrate a variety of ways you can create different kinds of work items, as well as to demonstrate the breadth of features available on the platform. As a result, these steps should not be viewed as prescriptive guidance for project management. The features are intended to be flexible enough to fit your process needs, so explore and experiment as you go.

1. Navigate to **Overview \| Dashboards**.

    ![](images/011.png)

1. Select the **Overview** dashboard for **Parts Unlimited Team**.

    ![](images/012.png)

1. There are many ways to create work items in Azure DevOps, and we'll explore a few of them. Sometimes it's as simple as firing one off from a dashboard. In the **New Work Item** form, type **"Product training"** and select the **Epic** type. Click **Create**.

    ![](images/new-wit.png)
    ![](images/013.png)

1. Assign the new work item to yourself and set the **Area** to **Parts Unlimited\PUL-Web**. Set the **Iteration** to **Parts Unlimited\Sprint 2** and click **Save & Close**. Ordinarily you would want to fill out as much information as possible, but you can run lean here for the purposes of this lab.

    ![](images/014.png)

1. Navigate to **Boards \| Work Items**.

    ![](images/015.png)

1. Locate the newly created epic for **Product training** and open it.

    ![](images/016.png)

1. The work item form includes everything you could ever want to know about a work item. This includes details about who it's assigned to, its status across many parameters, and all the associated information and history for how it has been handled since creation. One of the key areas to focus on is the **Related Work**. One of the ways to add a feature to this epic is to select **Add link \| New item**.

    ![](images/017.png)

1. Set the **Link Type** to **Child**, **Work item type** to **Feature** and set the **Title** to **"Training dashboard"**. Click **OK**.

    ![](images/018.png)

1. That **Assignment**, **Area**, and **Iteration** should already set to the same as the epic, and it's even linked to the parent item it was created from. Click **Save & Close**.

    ![](images/019.png)

1. Navigate to the **Boards** view.

    ![](images/020.png)

1. Select **PUL-Web Boards**. This will open the board for that particular team.

    ![](images/021.png)

1. Switch the board from showing **Backlog items** to showing **Features**. This will make it easy to add tasks and other work items to the features.

    ![](images/022.png)

1. From the **Training dashboard** dropdown, select **Add Product Backlog Item**.

    ![](images/023.png)

1. Name the first backlog item **"As a customer, I want to view new tutorials"** and press **Enter** to save. This creates a new **Product Backlog Item** (PBI) work item that is a child of the feature and shares its area and iteration.

    ![](images/024.png)

1. Add two more PBIs designed to enable the customer to see their recently viewed tutorials and to request new tutorials.

    ![](images/025.png)

1. Switch the task board view back to **Backlog items**.

    ![](images/026.png)

1. Backlog items have a state that defines where they are relative to being completed. While you could open and edit the work item using the form, it's easier to just drag cards on the board. Drag the first work item to **Approved**.

    ![](images/027.png)

1. You can also expand work item cards to get to conveniently editable details.

    ![](images/028.png)

1. Assign the moved PBI to yourself.

    ![](images/029.png)

1. Drag the second work item to the **Committed** stage.

    ![](images/030.png)

1. Drag the final PBI to the **Done** stage.

    ![](images/031.png)

1. The task board is one view into the backlog. View the tabular form by clicking **View as Backlog**.

    ![](images/032.png)

1. Click the **Expand** button, which allows you to view nested tasks under these work items. Another easy way to create work items is using the **Add** button on the backlog. Click it to add a new task to the first backlog item.

    ![](images/033.png)

1. Set the **Title** to **"Add page for most recent tutorials"**. Set the **Remaining Work** to **"5"** and the **Activity** to **"Development"**. Click **Save & Close**.

    ![](images/034.png)

1. Add another task to **"Optimize data query for most recent tutorials"**. Set its **Remaining Work** to **"3"** and its **Activity** to **"Design"**. Click **Save & Close**.

    ![](images/035.png)

<a name="Ex1Task3"></a>
### Task 3: Working with filters in backlogs and boards ###

Azure Boards comes with filtering capabilities. With filter functions, you can interactively apply one or more filters to an Azure Boards tool.  Filter functions available in Work items, Boards, Backlogs, Sprint Backlogs and Taskboards, Queries, and Delivery Plans. In this exercise, you will see the filters in the boards and backlogs.

1. Navigate to the **Backlog Items** view. 
1. Choose Filter ![](images/filter-icon.png) Or, enter the **Ctrl+Shift+f** keyboard shortcut.
  
   ![](images/backlog_filter.png)

1. Choose the filters of interest. The filter icon changes to a solid icon, Filter ![](images/filtered.png) , to indicate filtering is applied.

   Only those work items that satisfy all of the chosen filter criteria are showed on the page.


   ![](images/backlog_filter2.png)

    {% include note.html content= "When filtering is applied for backlogs, the add-a-backlog-item panel, reordering (stack ranking), and forecasting tools are disabled." %}

1. To clear the filtering, choose **Clear and dismiss filters**.
   ![](images/clearfilters.png)

   Filters remain in place until you explicitly clear them. When you refresh your backlog, board, or other tool, or sign in from another browser, filters remain set to your previous values.

1. Filtering functions similarly in Boards and Backlog view. To choose the filter criteria, switch to the Boards view and select filter.
    
    ![](images/boards_filter.png)

1. You can filter the work items in boards or backlog view uisng a key word or Assigned To, Work Item Type, States, Area Path and Iteration Path fields.

    {% include tip.html content= "For more detailed information about the filter functions and how you can apply one or more filters to an Azure Boards tool visit this  page
    [Interactively filter backlogs, boards, queries, and plans in Azure Boards](https://learn.microsoft.com/en-us/azure/devops/boards/backlogs/filter-backlogs-boards-plans?view=azure-devops) {:target=\"_blank\"}" %}


<a name="Ex1Task4"></a>
### Task 4: Managing sprints and capacity ###

Your team builds the sprint backlog during the sprint planning meeting, typically held on the first day of the sprint. Each sprint corresponds to a time-boxed interval which supports your team's ability to work using Agile processes and tools. During the planning meeting, your product owner works with your team to identify those stories or backlog items to complete in the sprint.

Planning meetings typically consist of two parts. In the first part, the team and product owner identify the backlog items that the team feels it can commit to completing in the sprint, based on experience with previous sprints. These items get added to the sprint backlog. In the second part, your team determines how it will develop and test each item. They then define and estimate the tasks required to complete each item. Finally, your team commits to implementing some or all the items based on these estimates.

1. Your sprint backlog should contain all the information your team needs to successfully plan and complete work within the time allotted without having to rush at the end. Before you start planning your sprint, you'll want to have created, prioritized, and estimated your backlog and defined your sprints. Navigate to the **Sprints** view using the navigation.

    ![](images/036.png)

1. From the **View options** dropdown, select the **Work details** panel option.

    ![](images/037.png)

1. The current sprint has a pretty limited scope. There are two tasks in the **To do** stage that combine for 8 hours of estimated work. At this point, neither task has been assigned.

    ![](images/038.png)

1. Assign the **Add page** task to yourself. Note that this updates the capacity view.

    ![](images/039.png)

1. Select the **Capacity** tab. This view enables you to define what activities a user can take on and at what level of capacity. In this case, set your capacity to allow **"1"** hour of **Development** per day. Note that you can add additional activities per user in the case they do more than just development.

    ![](images/040.png)

1. However, let's assume you're going to take some vacation. Click **0 days** under **Days off**.

    ![](images/041.png)

1. Set your vacation to span five work days during the current sprint (within the next few weeks). Click **OK**.

    ![](images/042.png)

1. Click **Save**.

    ![](images/043.png)

1. Return to the **Taskboard**.

    ![](images/044.png)

1. Note that the capacity view has been updated to reflect your available bandwidth. This exact number may vary, but for the screenshots here, that sprint capacity is 11 hours (1 hour per day over 11 working days).

    ![](images/045.png)

1. One convenient feature of the boards is that you can easily update key data in-line. It's a good practice to regularly update the **Remaining Work** estimate to reflect the amount of time expected for each task. Let's say you've reviewed the work for the **Add page** task and found that it will actually take longer than originally expected. Set it to whatever your total capacity is for this sprint.

    ![](images/046.png)

1. Note how this expands the **Development** and your personal capacities to their maximum. Since they're large enough to cover the assigned tasks, they stay green. However, the overall **Team** capacity is exceeded due to the additional 3 hours required by the other task.

    ![](images/047.png)

1. One way to resolve this capacity issue would be to move the task to a future iteration. There are a few ways this could be done. First, you could open the task here and edit it in the dialog. The **Backlog** view, on the other hand, provides an in-line menu option to move it. Don't move it now.

    ![](images/048.png)

1. Return to the **Taskboard** view.

    ![](images/049.png)

1. Select **People** from the **View options** dropdown.

    ![](images/050.png)

1. This adjusts your view such that you can review the progress of tasks by person instead of by backlog item.

    ![](images/051.png)

1. There is also a lot of customization available. Click the **Configure team settings** button.

    ![](images/052.png)

1. On the **Styles** tab, click **Add Styling rule** and set the **Name** to **"Development"**. Choose a green **Card color**. This will color all cards green if they meet the rule criteria set below.

    ![](images/053.png)

1. Add a rule for **Activity = Development**. This will set all cards assigned to **Development** activities green.

    ![](images/054.png)

1. The **Backlogs** tab allows you to set the levels available for navigation. Epics are not included by default, but you could change that here.

    ![](images/055.png)

1. You can also specify the **Working days** the team follows. This applies to capacity and burndown calculations.

    ![](images/056.png)

1. The **Working with bugs** tab allows you to specify how bugs are presented on the board.

    ![](images/057.png)

1. Click **Save and close** to save the styling rule.

    ![](images/058.png)

1. The task associated with **Development** is now green and very easy to identify.

    ![](images/059.png)

<a name="Ex1Task5"></a>
### Task 5: Customizing Kanban boards ###

To maximize a team's ability to consistently deliver high quality software, Kanban emphasize two main practices. The first, visualize the flow of work, requires you to map your team's workflow stages and configure your Kanban board to match. The second, constrain the amount of work in progress, requires you to set work-in-progress (WIP) limits. You're then ready to track progress on your Kanban board and monitor key metrics to reduce lead or cycle time. Your Kanban board turns your backlog into an interactive signboard, providing a visual flow of work. As work progresses from idea to completion, you update the items on the board. Each column represents a work stage, and each card represents a user story (blue cards) or a bug (red cards) at that stage of work. However, every team develops its own process over time, so the ability to customize the Kanban board to match the way your team works is crucial.

1. Navigate to **Boards**.

    ![](images/060.png)

1. Click the **Configure team settings** button.

    ![](images/061.png)

1. You can apply style rules to change the color of cards on kanban boards and task boards. Styling rules make the cards with important information stand out. Select **Styles** tab. On the Styles tab, click Add Styling rule and set the Name to “High Priority”. Choose a Red Card color. This will color all cards red if they meet the rule criteria set below.
    
    ![](images/styles_kanban.png)

1. Add a rule for **Priority = 1**. This will set all cards with priority **1** to  red. You can add more clauses in the query if required. Open the work item **As a customer, I want to view new tutorials** and change priority to **1**
    
    ![](images/styles_kanban2.png)

1. Click **Save and close** to save the styling rule.

1. The backlogs with priority **1** is now red and very easy to identify.
   
    ![](images/styles_kanban3.png)

1. Click the **Configure team settings** button.

    ![](images/061.png)

1. The team is emphasizing work done with data, so there is special attention paid to any task associated with accessing or storing data. Select the **Tag colors** tab. Click **Add tag color** enter a tag of **"data"**. Whenever a backlog item or bug is tagged with **data**, that tag will be highlighted.

    ![](images/062.png)

1. You can also specify which **Annotations** you would like included on cards to make them easier to read and navigate. When an annotation is enabled, the child work items of that type are easily accessible by clicking the visualization on each card.

    ![](images/063.png)

1. The **Tests** tab enables you to configure how tests appear and behave on the cards.

    ![](images/064.png)

1. Click **Save and close**.

    ![](images/065.png)

1. Open the **view new tutorials** backlog item.

    ![](images/066.png)

1. Add tags for **"data"** and **"ux"**. Click **Save & Close**.

    ![](images/067.png)

1. Note that the two tags are now visible on the card, although the **data** tag is highlighted yellow as configured.

    ![](images/068.png)

1. Click the **Configure team settings** button.

    ![](images/069.png)

1. Select the **Columns** tab. This section allows you to add new stages to the workflow. Click **Add Column** and set the **Name** to **"QA Approved"**. Set the **WIP limit** to **"1"**, which indicates that only one work item should be in this stage at a time. You would ordinarily set this higher, but there are only two work items to demonstrate the feature with here. Move the stage to occur between **Committed** and **Done**.

    ![](images/070.png)

1. Click **Save and close**.

    ![](images/071.png)

1. You will now see the new stage in the workflow.

    ![](images/072.png)

1. Move the work items from **Committed** and **Done** into **QA Approved**.

    ![](images/073.png)

1. The stage now exceeds its **WIP** limit and is colored red as a warning.

    ![](images/074.png)

1. Move the **recently viewed** backlog item back to **Committed**.

    ![](images/075.png)

1. Click the **Configure team settings** button.

    ![](images/076.png)

1. Return to the **Columns** tab and select **QA Approved**. A lag often exists between when work gets moved into a column and when work starts. To counter that lag and reveal the actual state of work in progress, you can turn on split columns. When split, each column contains two sub-columns: **Doing** and **Done**. Split columns let your team implement a pull model. Without split columns, teams push work forward, to signal that they've completed their stage of work. However, pushing it to the next stage doesn't necessarily mean that a team member immediately starts work on that item. Check **Split column into doing and done** to create two separate columns for this.

    ![](images/077.png)

1. As your team updates the status of work as it progresses from one stage to the next, it helps that they agree on what **done** means. By specifying the **Definition of done** criteria for each Kanban column, you help share the essential tasks to complete before moving an item into a downstream stage. Add a **Definition of done** using markdown, such as **"Passes \*\*all\*\* tests."**. Click **Save and close**.

    ![](images/078.png)

1. Note that the **QA Approved** stage now has **Doing** and **Done** columns.

    ![](images/079.png)

1. You can also click the icon next to the column header to read the **Definition of done**.

    ![](images/080.png)

1. Click the **Configure team settings** button.

    ![](images/081.png)

1. Your Kanban board supports your ability to visualize the flow of work as it moves from new to done. When you add **swimlanes**, you can also visualize the status of work that supports different service-level classes. You can create a swimlane to represent any other dimension that supports your tracking needs. From the **Swimlanes** tab, click **Add Swimlane** and set the **Name** to **"Expedite"**. Click **Save and close**.

    ![](images/082.png)

1. Drag and drop the **Committed** work item onto **QA Approved \| Doing** so that it gets recognized as having priority when QA bandwidth becomes available.

    ![](images/083.png)

1. If you would like to review a more sophisticated board with many more work items, select the **Parts Unlimited Team** from the team dropdown.

    ![](images/084.png)

1. This board provides a playground for you to experiment with and review the results.

    ![](images/085.png)

<a name="Ex1Task6"></a>
### Task 6: Defining dashboards ###

1. Select **Overview \| Dashboards**.

    ![](images/086.png)

1. From the dashboard dropdown, select **Parts Unlimited Team Overview**. Dashboards allow teams to visualize status and monitor progress across the project. At a glance, you can make informed decisions without having to drill down into other parts of your team project site. The Overview page provides access to a default team dashboard which you can customize by adding, removing, or rearranging the tiles. Each tile corresponds to a widget that provides access to one or more features or functions.

    ![](images/087.png)

1. From the dashboard dropdown, select **New dashboard**.

    ![](images/088.png)

1. Set the **Name** to **"Product training"** and select the **PUL-Web** team. Click **Create**.

    ![](images/089.png)

1. Click **Add a widget**.

    ![](images/090.png)

1. In the **Add Widget** panel, search for **"sprint"** to find existing widgets that focus on sprints. Select **Sprint Overview** and click **Add**.

    ![](images/091.png)

1. Many widgets have options you can configure. Click the **Settings** button.

    ![](images/092.png)

1. The quantity and depth of settings will vary by widget. Click **Close** to dismiss.

    ![](images/093.png)

1. Search the widgets again for **"sprint"** and add the **Sprint Capacity** widget.

    ![](images/094.png)

1. Click **Done Editing**.

    ![](images/095.png)

1. You can now review two important aspects of your current sprint on your custom dashboard.

    ![](images/096.png)

1. Another way of customizing dashboards is to generate charts based on work item queries, which you can share to a dashboard. Select **Boards \| Queries**.

    ![](images/097.png)

1. Click **New query**.

    ![](images/098.png)

1. Set the first term to **Work Item Type = Task** and the second term to **Area Path = Parts Unlimited\PUL-Web**.

    ![](images/099.png)

1. Click **Save query**.

    ![](images/100.png)

1. Set the **Name** to **"Web tasks"** and the **Folder** to **Shared Queries**. Click **OK**.

    ![](images/101.png)

1. Select the **Charts** tab and click **New chart**.

    ![](images/102.png)

1. Click **New chart**.

    ![](images/103.png)

1. Set the **Name** of the chart to **"Web tasks - By assignment"** and **Group by** to **Assigned To**. Click **OK** to save.

    ![](images/104.png)

1. You can now add this chart to a dashboard.

    ![](images/105.png)

<a name="Ex1Task7"></a>
### Task 7: Customizing team process ###

In Azure DevOps, you customize your work tracking experience through a process. A process defines the building blocks of the work item tracking system as well as other sub-systems you access through Azure DevOps. Whenever you create a team project, you select the process which contains the building blocks you want for your project.

Azure DevOps supports two process types. The first, the core system processes-Scrum, Agile, and CMMI system processes-are locked. You cannot customize these processes. The second type, inherited processes, you create from a core system process. These processes you can customize.

In addition, all processes are shared. That is, one or more team projects can reference a single process. Instead of customizing a single team project, you customize a process. Changes made to the process automatically update all team projects that reference that process.

Once you've created an inherited process, you can customize it, create team projects based on it, and migrate existing team projects to reference it. The Git team project can't be customized until it's migrated to an inherited process.

In this task we'll create a new process that inherits from Scrum. The one change we'll make is to add a backlog item field designed to track to a proprietary PartsUnlimited ticket ID.

1. Click the **Azure DevOps** logo in the top left corner to navigate to the account root.

    ![](images/106.png)

1. From the left bottom corner, click **Organization settings**.

    ![](images/107.png)

1. Select the **Process** tab under **Boards**.

    ![](images/process.png)

1. From the **Scrum** dropdown, select **Create inherited process**.

    ![](images/109.png)

1. Set the name of the inherited process to **Customized Scrum** and click **Create process**.

    ![](images/110.png)

1. Open **Customized Scrum**. You may need to refresh the browser for this to become visible.

    ![](images/111.png)

1. Select **Product Backlog Item**.

    ![](images/112.png)

1. Click **New field**.

    ![](images/113.png)

1. Set the **Name** of the new field to **"PUL Ticket ID"**.

    ![](images/114.png)

1. On the **Layout** tab, set the **Label** to **"Ticket ID"**. Also **Create a new group** for **"PartsUnlimited"**. Click **Add field**.

    ![](images/115.png)

1. Now that the customized process has been configured, let's switch the Parts Unlimited project to use it. Return to the **All processes** root using the breadcrumb.

    ![](images/116.png)

1. Our project currently uses **Scrum**, so select that process.

    ![](images/117.png)

1. Switch to the **Projects** tab.

    ![](images/118.png)

1. From the context menu for **Parts Unlimited**. Select **Change process**.

    ![](images/119.png)

1. Select the **Customized Scrum** process and click **Save**.

    ![](images/120.png)

1. Return to the account dashboard using the logo link.

    ![](images/121.png)

1. Open the **Parts Unlimited** portal.

    ![](images/122.png)

1. Select **Boards \| Work Items**.

    ![](images/123.png)

1. Open the first backlog item.

    ![](images/124.png)

1. You will now see the **Ticket ID** field under the **PartsUnlimited** group defined during the process customization. You can treat this like any other text field.

    ![](images/125.png)

1. Once the work item is saved, Azure DevOps will also save the new custom information so that it will be available for queries and through the rest of Azure DevOps.

## Introduction to Delivery Plans

 In this lab, you learnt about the agile planning and portfolio management tools and processes provided by Azure Boards and how they can help you quickly plan, manage, and track work across your entire team. 
 
 When you are working with multiple backlogs, multiple teams, and team backlogs from different projects, you would require a roadmap view for your plan, a view to track dependencies, and a progress view of your plan. **Delivery Plans** is the way to go.

 **Delivery Plans** is part of the Azure Boards offering that brings roadmap plans to customers. **Delivery Plans** provide visibility into features under development by several teams across several sprints. With Delivery Plans, portfolio managers can review the schedule of stories or features their teams plan to deliver. Delivery Plans show the scheduled work items by sprint (iteration path) of selected teams against a calendar view.


 <div class="bg-slap"><img src="./images/deliveryplans.png" class="img-icon-cloud" alt="MS teams" style="
    width: 48px; height: 48px;">Want additional learning about Delivery Plans? Check out the  <a href="https://azuredevopslabs.com/labs/azuredevops/deliveryplans/" target="_blank"><b><u> Building a roadmap and tracking dependencies across teams with Delivery Plans </u></b></a> lab.</div>

## Reference Video

Thanks to **Nagaraj Bhairaji** for making a video on this lab. You can watch the following video that walks you through all the steps explained in this lab

<figure class="video_container">
  <iframe width="560" height="315" src="https://www.youtube.com/embed/WWUf5OWeBD0" frameborder="0" allowfullscreen="true"> </iframe>
</figure>