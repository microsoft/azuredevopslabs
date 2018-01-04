

## Overview

It takes several teams to develop large software projects. Very large projects require multiple autonomous teams that can manage their own backlog and priority while contributing to a unified direction for that project. Regular reviews of the project schedule with these teams help ensure that the teams are working toward common goals. Delivery Plans provide the needed multi-team view of your project schedule.

Delivery Plans provides an easier way to see work across teams and projects. Available as an extension, Delivery plan makes it easy for you to review the schedule of stories or features your teams plan to deliver . You can see scheduled work items by sprint (iteration path) of selected teams against a calendar view.

## Pre-requisite

- You will need to install the Delivery Plan extension to your VSTS account in order to continue this lab

## Installing delivery plans extension

1. Go to <a href="https://marketplace.visualstudio.com">Visual Studio MarketPlace</a>

   <img src="images/15.png" />

2. Search for **Delivery Plans** in the search box and click on **install**

   <img src="images/16.png"/>

   <img src="images/17.png"/>

3. Select the account to which you want to install the extension and click **Install** to proceed with the installation.

   <img src="images/18.png"/>

## Creating a Delivery Plan

1. From your VSTS account, go to **Plans** page that appears under **Work** hub.

   <img src="images/1.png" />

2. To add a plan, click **New Plan** from the Plans page

   <img src="images/2.png" />

   >All users, except users assigned Stakeholder access, have permissions to create a plan and manage the plans they create. 

3. Provide a name for the plan **MyHealth Clinic Release 1**. Select the project, team and the backlog to appear in your plan.

   <img src="images/3.png" />
   
4. Click on **create**. You should now see the plan which is created.

   <img src="images/4.png" />

## Customizing the plan

Once you've defined a plan, you can further customize it. 

1. Click the  gear icon to open the Settings dialog.

   <img src="images/5.png" />

2. You can customize the plan by editing the teams, setting field criteria, adding markers etc.

   Here, we add the **Effort** field criteria. Only work items that contain the effort greater than 5 will appear in the Delivery Plan.

   <img src="images/6.png" />

   Now you will see all backlog items with effort greater than 5.

   <img src="images/20.png" />

3. You can add multiple teams and view the backlog items. Go to **Teams** tab from the settings page and click on **Add Team** to add new team. Select the project, team and backlog level as shown and click on save.

   <img src="images/21.png" />

   You will see multiple teams in your plan now.

   <img src="images/22.png" />

4. Markers help you to track key dates and events. To set a marker, open the **Markers page**, specify a date and select a color.

   <img src="images/7.png" />

   Markers appear on the plan as shown: 

   <img src="images/8.png" />

5. To configure the information shown on cards, click on the gear icon and go to **Fields** under the cards section. Add additional fields if required. For example add a field **AreaPath**. The work items show the information related to the areapath that belongs to.

   <img src="images/9.png" />

   You can now see the work items along with the area path on the cards as shown.

   <img src="images/23.png">

6. To quickly change the cards to only show their Title, enter the keyboard shortcut **T**. This will hide all other fields, as shown in the following image, the Assigned to field no longer appears. 

   <img src="images/10.png" />

7. As changes occur to the schedule, you can update the iteration for a backlog item by moving a card to a different iteration. This will help to drive alignment across your organization.

   <img src="images/11.png" />

8. To gain a summary view of work that is schedule, collapse all teams. You can then more easily look for gaps in the forward forecast.

   For example, here you can see the count of Backlogs for MHC Team for the next 3 sprints. You can collapse/expand team rows by clicking the team name or the sprint name.

   <img src="images/12.png" />

9. Delivery Plans show the scheduled work items by sprint (iteration path) of selected teams against a calendar view to ensure your teams are aligned with your organizational goals.

   For example, here you can see the features and backlogs of multiple teams that are delivered and are in progress states. This gives the teams heads up as to how many features/backlogs are delivered in the current sprint.

   <img src="images/19.png" /> 

## Interactive elements of plans

Each team's backlog specified in a Delivery Plan appears as a row within the plan view. When collapsed, a roll-up of the backlog items shows. When expanded, a card for each backlog item appears, organized by their assigned iteration.

<img src="images/13.png" />

In the following example, MHC Team backlogs expanded, 1 item was scheduled for delivery in Sprint 1.

<img src="images/14.png" />

You can also quickly see that: 

- MHC Team is currently working on Sprint 1 deliverables

- Sprint 1 began on July 7th and is scheduled to end July 25th

- The team expects to deliver the backlogs shown by the cards

A benefit of Delivery Plans is to view multiple teams across your projects that you care about.






