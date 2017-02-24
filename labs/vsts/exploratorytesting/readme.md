---
title: Exploratory Testing and Feedback Management with Visual Studio Team Services
layout: page
sidebar: tfs
permalink: /labs/vsts/exploratorytesting/
folder: /labs/vsts/exploratorytesting/
---

## Overview

In this lab, you will learn about the <a href="https://www.visualstudio.com/en-us/docs/test/manual-exploratory-testing/getting-started/perform-exploratory-tests/">Exploratory Testing</a> and feedback management capabilities provided in the Test & Feedback extension. 
You will learn about how exploratory testing (also called XT, or agile testing) has become a first-class experience in the toolset. 
This allows a tester to more flexibly test the underlying software without relying solely on formal est cases. 
You’ll also learn about how you can manage the process of eliciting and managing the customer feedback lifecycle.


## Pre-requisites

In order to complete this lab you will need Visual Studio Team Services account and Exploratory Testing Plugin.  For more information on creating VSTS account, please see [this blog post]().

## Exercise 1: Exploratory Testing

### Task 1: Installing the Chrome Extension

1.  Log in to your VSTS account.

2. Install **Google Chrome** from <http://google.com/chrome>. This lab
   requires Chrome to be used as the browser.

3. Launch **Chrome** from the taskbar.

4. Navigate to the **Visual Studio Marketplace** at
    <http://marketplace.visualstudio.com>.

5. Select the **Visual Studio Team Services** tab. Search for
    “**feedback**” and click the **Test & Feedback** extension.

    <img src="images/image1.png" width="624" height="378" />

6. Click on **Install** button on the details page.

    <img src="images/image2.png" width="624" height="228" />

7. Click **Install** for the Chrome extension.

    <img src="images/image3.png" width="624" height="251" />

8. In the **Chrome Web Store**, click **Add to Chrome**.

    <img src="images/image4.png" width="624" height="196" />

9.  Confirm the installation when asked.

    <img src="images/image5.png" width="342" height="232" />

10. To open the extension, click the extension icon that will appear on
    the right of the address bar. Select the **Connection
    Settings** tab. Enter “**YOUR VSTS ACCOUNT URL**” as the **Server URL** and click
    **Next**.

    <img src="images/image6.png" width="489" height="468" />

11. The extension can be used in two modes: **Connected** and
    **Standalone** mode. If you have Team Foundation Server (TFS)
    connection or a Visual Studio Team Services (VSTS) account, select
    Connected mode. Standalone mode is for users who don’t have TFS (or
    VSTS account) and want to use the extension to file bugs and share
    the report with their team.

12. After connecting to VSTS, you will need to select the team you want
    these efforts associated with. Select the **Fabrikam Fiber Team** when available. Now
    all of your work item creation and searching will be scoped to the
    area path. Click **Save** to continue.

    <img src="images/image7.png" width="484"/>


### Task 2: Exploratory Testing with the Chrome Extension

1.  To start an exploratory testing session, click the **Start session**
    button from the extension toolbar.

    <img src="images/image8.png" width="270" height="64" />

2.  Navigate to <http://intranet.fabrikam.com>.

3.  Click the first dashboard ticket to view it.

    <img src="images/image9.png" width="270" height="164" />

4.  Click the **Escalate** button to attempt to escalate the ticket.
    This will lead to a 404 page, which is a bug.

    <img src="images/image10.png" width="382" height="102" />

5.  Click the **Exploratory Testing** icon button and click the
    **Capture screenshot** button.

    <img src="images/image11.png" width="397" height="76" />

6.  Select a section of the screen and change the name of the screenshot
    to something more descriptive. Note that there are a variety of
    drawing tools available to really help you get your point across.
    Click the **Blur area** button.

    <img src="images/image12.png" width="485" height="220" />

7.  Highlight a section of the screenshot, which will be blurred out to
    become illegible. This makes it easy to report bugs and create other
    work items without risking sensitive information. Click the **Save
    screenshot** button to add it to the current session’s timeline.

    <img src="images/image13.png" width="480" height="224" />

8.  Click the **Add note** button to start a note. Type in something
    insightful and click **Save** to save the note to the
    session’s timeline.

    <img src="images/image14.png" width="384" height="280" />

9.  You can also record screen video to capture flaky issues like
    flickering, abnormal behavior of the web application etc. that are
    difficult to capture using screenshots alone. To record your screen
    click the **Record screen** button and click **Start recording**.

    <img src="images/image15.png" width="376" height="182" />

10. Select the appropriate screen you want to record from the
    **Application Window** tab. In this case, select the 404 page and
    click **Share**. The recording for the screen selected has started.

    <img src="images/image16.png" width="582" height="433" />

11. Slowly highlight part of the page. This task doesn’t need to be
    critically accurate, but is rather just something to produce video
    to review later on.

    <img src="images/image17.png" width="325" height="135" />

12. Click the **Stop recording** button on the extension to stop
    recording the screen. The screen recording gets saved.

    <img src="images/image18.png" width="495" height="276" />

13. Click on the **View session timeline** button. You can see that all
    the content – screenshots, notes and videos you’ve captured are
    available in the current session’s timeline. You can open the
    screenshots, read your notes or play the video from here.

    <img src="images/image19.png" width="299" height="334" />


### Task 3: Creating Bugs with the Chrome Extension


1.  Click the **Create bug** icon button followed by the expanded
    **Create bug** text button.

    <img src="images/image20.png" width="383" />

2.  Enter **“Escalate ticket results in 404”** as the name of the bug.
    All the screenshots and videos captured earlier are already a part
    of the bug. In addition to this the image action log (user actions)
    has also been inserted for you so that it’s easy for others to
    easily reproduce the issue. Click **Save** to save the bug to VSTS.

    <img src="images/image21.png" width="488" height="365" />

3.  Another great feature of this extension is its ability to view
    similar bugs and thus reduce redundant issues. Let’s say you were
    another tester who happened to find this same bug and weren’t aware
    that it was already logged. Click the **Create bug** icon button
    followed by the expended **Create bug** text button again to start a
    new bug form.

    <img src="images/image20.png" width="387" height="112" />

4.  As you type the title **“404 escalate**” for the bug you will notice
    that the extension has detected that there is already another bug in
    the backlog with a similar title. Click 1 **similar** to view the
    similar bug.

    <img src="images/image22.png" width="369" height="142" />

5.  This bug appears to be the same as the one we were about to file, so
    select it and click **Edit** to edit the existing bug rather than to
    file a new bug.

    <img src="images/image23.png" width="366" height="183" />

6.  At this time the current repro steps are added to the image
    action log. In practice, you would now review the existing repro
    steps to determine if you located this bug using a different method,
    in which case you would update the contents to indicate that your
    method is an alternative repro. Click **Save** to save the bug.

    <img src="images/image24.png" width="367" height="381" />

7.  Click the **View session timeline** icon button and click the last
    created **Bug** link to open it.

    <img src="images/image25.png" width="479" />

8.  Now back on the VSTS site, you can update the bug as needed, such as
    by assigning it to someone or adjusting the severity.

    <img src="images/image26.png" width="624" />

9.  In Chrome, end the testing session by clicking the **Stop
    Session** button.

    <img src="images/image27.png" width="543" height="93" />

10. Close Chrome.


## Exercise 2: Eliciting and Managing Feedback

In this exercise, you will learn about managing the feedback
    lifecycle in VSTS. During the course of software development, it is
    important to capture feedback from project stakeholders (end-users,
    product owners, and so on) to ensure that the progress the team is
    making is on track to meet the requirements that the stakeholders
    have in mind. It enables the capture of audio, video, screenshots,
    and other attachments to be linked to Visual Studio team Services
    feedback work items.


### Task 1: Creating Feedback Requests

1.  In Chrome, navigate to **YOUR VSTS SITE**.

2.  Navigate to the **FabrikamFiber** project via the navigation
    dropdown in the top left corner.

    <img src="images/image28.png" width="230"/>

3.  Select **Work \| Backlogs**.

    <img src="images/image29.png" width="314"/>

4.  For our purposes in this lab, let’s assume that we would like to get
    some feedback on the Fabrikam Fiber intranet portal’s ability to
    edit customer records. Enter a **Title** of “**Improve customer edit
    experience**” and click **Add** to create a new backlog item.

    <img src="images/image30.png" width="609" height="140" />

5.  Double-click the newly created work item.

    <img src="images/image31.png" width="624" height="103" />

6.  Open the work item and click **Request feedback** to elicit feedback on this work item.

    <img src="images/image32.png" width="624"/>

7.  In the Request Feedback dialog, select **any user** as the
    stakeholder to request feedback from. Note that the **user** is assigned to
    the **Stakeholder** access level in VSTS, so providing feedback via
    this feature is something they can uniquely offer. Optionally add
    more color to the subject or body and click **Send**.

    <img src="images/image33.png" width="478" height="290" />

    >Note: You can add as many feedback items as you want by
        clicking on the ‘**Request feedback**’ link.

8.  Press **Esc** to close the work item.


### Task 2: Using the Feedback Client

1. Open the email as a **user** that you requested earlier for providing feedback from your inbox. You could go to your respective users inbox and see that a feedback request
   would have arrived with the name **VisualStudioOnline@microsoft.com**.

2. The email provides the high-level details and easy access to the
    feedback experience. Click **Provide feedback**. If asked to select
    a browser, choose **Chrome**.

    <img src="images/image34.png" width="624" />

3. Click the extension button to expand it.

    <img src="images/image35.png" width="438" height="42" />

4. The **Work Items** tab will be selected and scoped in to the
    feedback item.

    <img src="images/image36.png" width="473" height="323" />

5. Navigate to <http://intranet.fabrikam.com>.

6. Follow the instructions provided by selecting the **Customers** link
    to navigate to the Customers page.

    <img src="images/image37.png" width="624" height="95" />

7. Next, select the **Edit** link for one of the listed customers.

    <img src="images/image38.png" width="461" height="251" />

8. Customer records contain phone numbers, and the users of the
    Fabrikam Fiber intranet portal commonly need to update these phone
    numbers for customers who are calling about their service. Here we
    can see that the edit screen does not allow us to update that
    customer field.

    <img src="images/image39.png" width="319" height="420" />

9. Expand the feedback extension and select the **Notes** tab. Enter
    “**We need to provide a way to update customer phone numbers.**”
    Click **Save**.

    <img src="images/image40.png" width="489" height="238" />

10. Attach a screenshot by clicking the **Screenshot** button.

    <img src="images/image41.png" width="486" height="59" />

11. Enter “**Need phone number**” and click the **Confirm** button.

    <img src="images/image42.png" width="624" height="497" />


12. Select the **Provide feedback** tab and click **Provide feedback**.

    <img src="images/image43.png" width="488" height="105" />

13. Enter “**Will be good with phone number**” and set the ratings to
    five stars. Click **Save**.

    <img src="images/image44.png" width="488" height="448" />

14. Select the **Feedback requests** tab and click the **Complete
    feedback request** button that appears when you hover. This will
    also end the feedback session.

    <img src="images/image45.png" width="472" height="205" />


### Task 3: Collecting and Acting on Feedback


1. Return to your VSTS account.

2. Navigate to the **Work** \| **Queries** page and click on the **Editor**.
   Change the query to search **Feedback Response** work item. You should see 
   1 response in the results.

    <img src="images/image46.png" width="472" height="205" />

3. Locate the Feedback Response that was just created. Double click to open.

    <img src="images/image47.png" width="472" height="205" />

4. You can see the direct feedback.

    <img src="images/image48.png" width="472" height="205" />

5. Select **links** and note that this Feedback
    Response work item is a child of the original Feedback Request work
    item that was emailed.

    <img src="images/image49.png" width="472" height="205" />

6. Based on the feedback received, the team can then create additional
    work items as necessary in order to act upon the feedback. Select
    the **Add Link** button.

    <img src="images/image50.png" width="472" height="205" />

7. Go with the default work item type of **Bug**, and provide a title
    such as “**No customer phone number field for updates.**” Select the
    **OK** button.

    <img src="images/image51.png" width="472" />

8. Click **Save and Close** and note the individual that is assigned to
    the bug will have the associated feedback context linked to it
    for reference.




