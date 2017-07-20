

## Overview

Delivery Plans provides an easier way to see work across teams and projects. Available as an extension, Delivery plan makes it easy for you to review the schedule of stories or features your teams plan to deliver . You can see scheduled work items by sprint (iteration path) of selected teams against a calendar view.

## Pre-requisites

In order to add and configure a plan, you must have the following in place: 

- Delivery Plan Extension

- Be granted Basic access in Team Services (Users with Stakeholder access can't add or view plans)

- Defined iteration paths for the team project

- You will need to install the Delivery plan extension to your VSTS account in order to continue this lab

## Adding Delivery Plan Extension to the VSTS account

1. Go to <a href="https://marketplace.visualstudio.com">Visual Studio MarketPlace</a>

   <img src="images/15.png" />

2. Search for **Delivery Plans** in the search box and click on **install**

   <img src="images/16.png"/>

   <img src="images/17.png"/>

3. Select the account to which you want to install the extension and select **Continue** to proceed with the installation.

   <img src="images/18.png"/>

## Add a Plan

1. From your VSTS account, go to **Plans** page that appears under **work hub**

   <img src="images/1.png" />

2. To add a plan, click **New Plan** from the Plans page

   <img src="images/2.png" />

   >All users, except users assigned Stakeholder access, have permissions to create a plan and manage the plans they create. 

3. Provide a name for the plan **MyHealth Clinic Release 1**. Select the project, **MyHealth Clinic team** and the backlog to appear in your plan.

   <img src="images/3.png" />
   
4. Click on **create**. You should now see the plan which is created.

   <img src="images/4.png" />

## Edit a plan, add field criteria, customize cards, and add markers

Once you've defined a plan, you can further customize it. 

1. Click the  gear icon to open the Settings dialog.

   <img src="images/5.png" />

2. You can customize the plan by editing the teams, setting field criteria, adding markers etc.

   Here, we add the **Effort** field criteria. Only work items that contain the effort greater than 5 will appear in the Delivery Plan.

   <img src="images/6.png" />

3. To set a marker, open the **Markers page**, specify a date and select a color.

   <img src="images/7.png" />

   Markers appear on the plan as shown: 

   <img src="images/8.png" />

4. To configure the information shown on cards, click on the gear icon and go to **Fields** under the cards section. Add additional fields if required. For example add a field **AreaPath**. The work items show the information related to the areapath that belongs to.

   <img src="images/9.png" />

5. To quickly change the cards to only show their Title, enter the keyboard shortcut **t**. This will hide all other fields, as shown in the following image, the Assigned to field no longer appears. To persist this view, edit the plan's settings for card fields.

   <img src="images/10.png" />

6. As changes occur to the schedule, you can update the iteration for a backlog item by moving a card to a different iteration. This will help to drive alignment across your organization.

   <img src="images/11.png" />

7. To gain a summary view of work that is schedule, collapse all teams. You can then more easily look for gaps in the forward forecast.

   For example, here you can see the count of Backlogs for MyHealthClinic Team for the next 3 sprints. You can collapse/expand team rows by clicking the team name or the sprint name.

   <img src="images/12.png" />

8. Delivery Plans show the scheduled work items by sprint (iteration path) of selected teams against a calendar view to ensure your teams are aligned with your organizational goals.

   For example, here you can see the features and backlogs of multiple teams that are delivered and are in progress states. This gives the teams heads up as to how many features/backlogs are delivered in the current sprint.

   <img src="images/19.png" /> 


## Interactive elements of plans

Each team's backlog specified in a Delivery Plan appears as a row within the plan view. When collapsed, a roll-up of the backlog items shows. When expanded, a card for each backlog item appears, organized by their assigned iteration.

<img src="images/13.png" />

In the following example, MyHealthClinic Team backlogs expanded, two items are scheduled for delivery in Sprint 5.

<img src="images/14.png" />

You can also quickly see that: 

- MyHealthClinic Team is currently working on Sprint 5 deliverables

- Sprint 5 began on June 6th and is scheduled to end June 30th

- The team expects to deliver the two backlogs shown by the cards

A benefit of Delivery Plans is to view multiple teams across your projects that you care about. Two main ways to view more teams within the plan view is to collapse all teams to focus on summary data and to minimize the number of fields displayed on cards.






