---
title: Managing Delivery Plans with Team Foundation Server
layout: page
sidebar: tfs
permalink: /labs/tfs/deliveryplans/
folder: /labs/tfs/deliveryplans/
version: Lab version - 15.4.1
updated: Last updated - 10/31/2017
---
<div class="rw-ui-container"></div>

## Overview

It takes several teams to develop large software projects. Very large projects require multiple autonomous teams that can manage their own backlog and priority while contributing to a unified direction for that project. Regular reviews of the project schedule with these teams help ensure that the teams are working toward common goals. Delivery Plans provide the needed multi-team view of your project schedule.

## Prerequisites

In order to complete this lab you will need the Visual Studio 2017 virtual machine provided by Microsoft. Click the button below to launch the virtual machine on the Microsoft Hands-on-Labs portal.

<a href="https://labondemand.com/AuthenticatedLaunch/38311?providerId=4" class="launch-hol" role="button" target="_blank"><span class="lab-details">Launch the virtual machine</span></a>

Alternatively, you can download the virtual machine from [here](../almvmdownload/)

## Exercise 1: Managing Delivery Plans with Team Foundation Server 2018

### Task 1: Demo setup

1. Log in as **Sachin Raj (VSALM\Sachin)**. All user passwords are **P2ssw0rd**.

1. Launch **Internet Explorer** from the taskbar.

1. Click the **TFS PU Portal** shortcut to navigate to the PartsUnlimited TFS portal.

    ![](images/000.png)

1. From the **Settings** navigation dropdown, select **Work**.

    ![](images/001.png)

1. The project has been configured to have an extremely long **Iteration 2** for the purposes of many of the labs. However, this lab requires the iterations to be configured relative to the current date, so a few tweaks will be required. Select **Edit** from the **Iteration 2** dropdown.

    ![](images/002.png)

1. Change the **Start date** to today's date. For the purposes of this lab, we'll assume that we are at the very beginning of iteration 2. Set the **End date** to the second Friday from now (less than two weeks). Click **Save and close**.

    ![](images/003.png)

1. Edit **Iteration 3** in the same manner, but set its start date to the Monday after **Iteration 2's End Date**. **Iteration 3** should end on the Friday eleven days later.

   ![](images/004.png)

### Task 2: Installing the Delivery Plans extension

1. Delivery Plans is provided as an optional extension to TFS. From the **Marketplace** navigation dropdown, select **Manage extensions**.

    ![](images/005.png)

1. Click **Browse local extensions**.

    ![](images/006.png)

1. Select the **Delivery Plans** extension.

    ![](images/007.png)

1. Click **Install**.

    ![](images/008.png)

1. Select the **PartsUnlimitedCollection** and click **Continue**.

    ![](images/009.png)

1. Click **Confirm** to confirm the installation.

    ![](images/010.png)

1. Close the browser tab.

### Task 3: Creating a delivery plan

1. Click the **TFS PU Portal** shortcut to navigate to the project's landing page.

    ![](images/011.png)

1. From the **Work** dropdown, select **Plans**.

    ![](images/012.png)

1. Click **New plan**.

    ![](images/013.png)

1. Since you may want to have multiple delivery plans for different aspects of your project, provide the specific name **"Web delivery"**. It should default to the only team in the project at this time (**PartsUnlimited Team**), so select **Stories** and click **Create**. Note that you could also organize your deliveries by **Features** if you used that model instead. There is also the option to add additional teams and criteria to filter stories/features by, but we'll revisit those later.

    ![](images/014.png)

1. Due to the iteration reconfiguration performed earlier, the "Today" marker is right at the beginning of **Iteration 2**. We have a number of stories listed for delivery in this iteration, and we can also see an empty **Iteration 3**. Note that one of the stories shown is "Closed". Although it's useful to see the progress of work, we'll use that as an example by which to filter items out in a moment.

    ![](images/015.png)

1. Click the **Configure plan settings** button.

    ![](images/016.png)

1. Select the **Field criteria** tab and click **Add criteria**.

    ![](images/017.png)

1. Set the new criteria to filter down to items where **State** does not equal (**<>**) **Closed**.

    ![](images/018.png)

1. We can also add a custom marker to keep track of significant dates. Select the **Markers** tab and click **Add marker**.

    ![](images/019.png)

1. Select the third Friday from today (it will be the Friday in the middle of **Iteration 3**) and set the **Label** to **"Team offsite"**. Select magenta as the **Color** and click **Save**.

    ![](images/020.png)

1. The first thing to notice is that the "Closed" story is no longer visible on the delivery plan due to the criteria set in the configuration. In addition, there is now a magenta marker in the middle of **Iteration 3** that says **"Team offsite"** when clicked.

    ![](images/021.png)

1. Another neat feature of the delivery plan extension is the ability to easily scale the calendar. Drag the **Scale** slider all the way to the left to view multiple months at once.

    ![](images/022.png)

1. Slide it all the way to the right to zoom in to a much more precise view.

   ![](images/023.png)

### Task 4: Adding a second team to the project

1. Our delivery plan has been pretty simple so far because we only have the one team. However, the real power of delivery planning comes into play when orchestrating multiple autonomous teams across their efforts. From the **Settings** navigation dropdown, select **Overview**.

    ![](images/024.png)

1. Click **New team**.

    ![](images/025.png)

1. This new team will be responsible for the efforts that involve integrating with external services, such as 3rd party services for things like weather forecasts and payment processing. Set the **Team name** to **"External integration team"** and click **Create team**.

    ![](images/026.png)

1. Select the **Work** tab.

    ![](images/027.png)

1. Note the dates of **Iteration 2** and **Iteration 3**. We're going to add two new iterations for the external services team that do not align exactly with the main team's schedule.

    ![](images/028.png)

1. With the root **PartsUnlimited** node select, click **New child**.

    ![](images/029.png)

1. Set the **Iteration name** to **"Sprint 50"**. Use today as the **Start date** and set the **End date** to three Fridays from today. This will also happen to be the day of the team offsite. Click **Save and close**.

    ![](images/030.png)

1. Use the same process to add a **Sprint 51** that starts the Monday after **Sprint 50** ends and has an end date three Fridays later.

    ![](images/031.png)

1. The last thing we need to do to configure the new team is to specify that it uses those new project sprints as its iterations. Select the **Overview**tab and click **External integration team**.

    ![](images/032.png)

1. Select the **Work** tab and then the **Iterations** child tab.

    ![](images/033.png)

1. Click **Select iterations** and use the **+ Iteration** button to select **Sprint 50** and **Sprint 51**. Click **Save and close**.

   ![](images/034.png)

### Task 5: Making delivery decisions

1. From the **Work** dropdown, select **Plans**.

    ![](images/035.png)

1. Click the **Web delivery** plan created earlier.

    ![](images/036.png)

1. Click the **Configure plan settings** button.

    ![](images/037.png)

1. Select the **Teams** tab and click **Add team**.

    ![](images/038.png)

1. Select the **External integration team** and **Stories**. Click **Save**.

    ![](images/039.png)

1. Use the **Scale** slider to fit the width of **Sprint 50** and **Sprint 51**.

    ![](images/040.png)

1. The new team doesn't have any stories added yet. Fortunately, you can add them directly to their team and iteration using the inline functionality. Select the **Sprint 50** iteration. Click the **New item** button that appears.

    ![](images/041.png)

1. Enter **"Integrate with weather service"** and press **Enter**. That item is now in the backlog with its area and iteration configured.

    ![](images/042.png)

1. Follow the same process to add an item for integrating with a credit card service to **Sprint 51**.

    ![](images/043.png)

1. Now we can step back to see how these two teams are working toward our common goals. Upon closer examination, it appears that the main team is planning to expose some credit card functionality during the current iteration that will not be available until well after it's over. It's a good thing we have this view to catch these sort of potential problems early on.

    ![](images/044.png)

1. The first thing we should do is to move the credit card integration work to an earlier iteration. Drag and drop the credit card story onto **Sprint 50**. In order to free up the bandwidth, drag the weather service story onto **Sprint 51**.

    ![](images/045.png)

1. Next, drag the end user credit card story from **Iteration 2** to **Iteration 3** so that there's a chance the dependencies will be available in time for this team to be unblocked.

    ![](images/046.png)

1. Now we can review the delivery plan again. It should be more feasible now.

    ![](images/047.png)

1. There are a lot of ways to quickly customize the view of the delivery plan. For example, pressing the **'t'** key will toggle between showing all configured fields and showing just the title. Try that now.

    ![](images/048.png)

1. You can also collapse all teams (or specific teams) using the toggle buttons next to their names.

    ![](images/049.png)
