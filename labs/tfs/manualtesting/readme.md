---
title: Test Planning and Management with Team Foundation Server 2017
layout: page
sidebar: tfs
permalink: /labs/tfs/manualtesting/
folder: /labs/tfs/manualtesting/
---

## Overview

In this lab, you will learn how to use Microsoft Team Foundation
    Server 2017 to manage your project’s testing lifecycle. This project
    will guide you through creating test plans designed efficiently
    validate your software milestones. You will also create and execute
    manual tests that can be consistently reproduced over the course of
    each release.

## Pre-requisites

In order to complete this lab you will need the Visual Studio 2017
    virtual machine provided by Microsoft. For more information on
    acquiring and using this virtual machine, please see [this blog
    post](http://aka.ms/almvm).


## Exercises

This Hands-On Lab comprises the following exercises:

* Managing Test Plans, Suites, and Cases

* Authoring, Running, and Analyzing Manual Tests

Estimated time to complete this lab: **60 minutes**.

## Exercise 1: Managing Test Plans, Suites, and Cases


In this exercise, you will learn how to create and manage test plans, test suites, and test cases.

### Task 1: Understanding Test Plans, Suites, and Cases

1.  Log in as **Sachin Raj** (VSALM\\Sachin). All user passwords are **P2ssw0rd**.


   >**Note:** If you are connecting to the VM over a RDP, it is
    recommended that you either run in windowed mode (not full screen)
    or alternatively ensure that both the host machine and the RDP
    session use the same resolution. This will help ensure smooth action
    recordings during this lab.


2.  Navigate to <http://vsalm:8080/tfs>.


3.  Use the top navigation dropdown to select the **PartsUnlimited** project.

    <img src="./media/image2.png" width="352" height="125" />

4.  Select **Test | Test Plans** to open the **Test Hub**. The test hub
    provides a central place for all test planning, execution,
    and analysis.

    <img src="./media/image3.png" width="265" height="75" />

    In general, every major milestone in a project should have its own
    **test plan**. Within each test plan are **test suites**, which are
    collections of **test cases** (and optionally other test suites)
    designed to validate a work item, such as a feature implementation
    or bug fix. Each test case is designed to confirm a specific
    behavior and may belong to one or more test suites. The Parts
    Unlimited project has multiple milestones (v1.0, v2.0, and v2.1),
    and each has its own test plan. Confirm the test plan for the
    current milestone (**v2.1**) is selected.

    <img src="./media/image4.png" width="424" height="270" />

5.  Expand the **Regression tests** suite and select the suite of tests
    for the bug **New products do not show up on site**. This suite of
    tests focuses on that work item, which happens to be a bug.

    <img src="./media/image5.png" width="329" height="112" />

6.  On the right side you can see that this test suite has two test
    cases designed to confirm expected behavior of the bug fix.
    Double-click the **Administrator can create product** test case.

    <img src="./media/image6.png" width="624" height="206" />

7.  This dialog provides all the info you need on this test case. Locate
    the **Related Work** panel and note that this test case is linked
    two other work items. The first (red) is a bug and the
    second (blue) is a user story. Click the user story to view it.

    <img src="./media/image7.png" width="384" height="164" />

8.  In the user story view, note that both the bug and test case are
    linked in the **Related Work** panel. Press **Esc** to close the
    user story and return to the test case.

    <img src="./media/image8.png" width="624" height="282" />

9.  Back in the test case dialog, click the related bug to view it.

    <img src="./media/image9.png" width="384" height="164" />

10. As expected, the user story is present in the **Related
    Work** section. It really is easy to navigate through any kind of
    work item and asset to understand the relationships and
    dependencies present in a given project. You can also see that
    there are two separate test cases in use to verify the behavior of
    this bug, which are the test cases we saw in the panel earlier.
    Press **Esc** to close the bug. Press **Esc** again to close the
    test case and return to the test suite view.

    <img src="./media/image10.png" width="624" height="305" />

### Task 2: Managing Tests

1.  Sometimes a set of test cases should be run in a specific order to
    maximize efficiency. Click **Order tests** to specify the order
    these test cases should be run.

    <img src="./media/image11.png" width="329" height="70" />

2.  The two test cases here are designed to test for a regression
    against a bug fixed earlier. In that bug, items that were added or
    edited were no longer visible on the site. While both of these
    test cases could be run separately to confirm the behavior, it
    probably makes more sense to run the test case that creates a new
    item first so that the second case (which involves editing an
    existing item) can just use that item again. This may not be the
    right approach for other scenarios, but we’ll use it for this lab.
    Drag and drop the second test case above the first and click
    **Done**.

    <img src="./media/image12.png" width="505" height="144" />

3.  You can now see that the **Order** has been updated and that the
    list is now sorted by it.

    <img src="./media/image13.png" width="519" height="168" />

4.  Another significant aspect of testing has to do with the environment
    each test is run in. For this web app, the browser and operating
    system are key considerations. Right now all the tests only use
    one configuration: Windows 10.

    <img src="./media/image14.png" width="347" height="88" />

5.  Now let’s suppose the test team has acquired an iPad Pro and wants
    to add it into the test matrix. It’s really easy to register this
    environment as a new configuration so that test cases can
    specify it. Select the **Configurations** tab.

    <img src="./media/image15.png" width="624" height="259" />

6.  Note that there are three existing configurations for **Windows
    10**, **iPhone 7**, and **Android 4**. Each test configuration
    includes a name and a description, as well as a set of
    customizable **Configuration variables**. This project has two
    configuration variables for **Browser** and **Operating System**.
    You can easily add more and/or edit the available entries
    for each. However, since these variables fit for our iPad Pro
    scenario, we can just use them as-is. Click the **Add** dropdown
    and select **New test configuration**.

    <img src="./media/image16.png" width="210" height="141" />

7.  Set the **Name** to **“iPad Pro”**.

    <img src="./media/image17.png" width="556" height="157" />

8.  Click **Add configuration variable** twice and set the **Browser**
    to **Safari** and **Operating System** to **iOS 10**.

    <img src="./media/image18.png" width="382" height="162" />

9.  Click **Save** to save the new configuration.

    <img src="./media/image19.png" width="311" height="182" />

10. Return to the **Test Plans** tab.

    <img src="./media/image20.png" width="325" height="81" />

11. Click the dropdown next to the test suite we’ve been working with so
    far and select **Assign configurations to test suite**.

    <img src="./media/image21.png" width="319" height="392" />

12. Check the **iPad Pro** option and click **Save**.

    <img src="./media/image22.png" width="581" height="198" />

13. Notice that each test case has been duplicated with an additional
    configuration for **iPad Pro**. Now each environment can be tested
    and tracked separately.

    <img src="./media/image23.png" width="624" height="217" />

### Task 3: Authoring Tests

1.  Expand the dropdown next to the **v2.1** test plan and select **New
    static suite.** A **static suite** of test cases is a suite where
    the cases have been manually assigned. You can also create suites
    based on common requirements (**requirements-based suite**) or a
    query of test cases and/or work items (**query-based suite**).

    <img src="./media/image24.png" width="229" height="206" />


2.  Set the name of the new suite to **“Authentication tests”**. These
    tests will all focus on functionality related to
    user authentication. Remember that you can easily share test cases
    across suites, so there’s minimal redundancy when having a lot of
    overlapping suites.

    <img src="./media/image25.png" width="237" height="82" />

3.  Expand the dropdown next to the newly created suite and select **New
    > requirements-based suite**.

    <img src="./media/image26.png" width="229" height="162" />

4.  You could customize the query used to specify which requirements are
    retrieved, but just leave the defaults and click **Run query**.
    Locate and select the three user stories related to registering,
    logging in, and logging out. Click **Create suites** to create a
    test suite for each user story.

    <img src="./media/image27.png" width="624" height="174" />

5.  Select the second user story that focuses on users being able to
    log in.

    <img src="./media/image28.png" width="298" height="131" />

6.  While you can create test cases one at a time, it’s sometimes easier
    to use a grid layout to quickly add many test cases. In the test
    cases panel, select **New | New test case using grid**.

    <img src="./media/image29.png" width="203" height="187" />

7.  Enter a few test cases and click the **Save All** button. The
    **Title** will be the eventual title of the test case. **Step
    Action** will be the first (and possibly only) step of the test.
    If that step has an expected result, you can specify it as **Step
    Expected Result**.

    <img src="./media/image30.png" width="624" height="182" />

8.  You can optionally continue to add and edit work items in the
    grid view. When satisfied, return back to the list view by
    clicking the **View: Grid** toggle.

    <img src="./media/image31.png" width="624" height="199" />

9.  The list view shows the same data, but in a different view.

    <img src="./media/image32.png" width="624" height="216" />

10. Another option to create suites is via work item query. Expand the
    dropdown next to the **Authentication tests** suite and select
    **new query-based suite**.

    <img src="./media/image33.png" width="219" height="205" />

11. Let’s say you wanted to create a set of test suites based on bugs in
    the Web site area of the project. Change the **Work Item Type** to
    **Microsoft.BugCategory** (to search bugs) and change the **Area
    Path** to **PartsUnlimited\\Web site**. Click **Run query**. You
    now have a list of bugs that you can select to create suites from,
    if you choose.

    <img src="./media/image34.png" width="624" height="284" />

12. Press **Esc** to close the dialog.

## Exercise 2: Authoring, Running, and Analyzing Manual Tests

In this exercise, you will learn how to create a manual test plan
    and populate it with steps. The plan can later be run to confirm the
    expected behavior of your software. In this lab, we’re going to
    focus on creating a new manual test case and running it.

### Task 1: Installing the Test & Feedback Extension

1.  Install **Google Chrome** from <http://google.com/chrome>. The rest
    of this exercise will use Chrome as its browser.


2.  Navigate to the **Visual Studio Marketplace** at
    <http://marketplace.visualstudio.com>.

3.  Select the **Visual Studio Team Services** tab. Search for
    “**feedback**” and click the **Test & Feedback** extension.

    <img src="./media/image35.png" width="624" height="378" />

4.  Click on **Install** button on the details page.

    <img src="./media/image36.png" width="624" height="228" />

5.  Click **Install** for the Chrome extension.

    <img src="./media/image37.png" width="624" height="251" />

6.  In the **Chrome Web Store**, click **Add to Chrome**.

    <img src="./media/image38.png" width="624" height="196" />

7.  Confirm the installation when asked.

    <img src="./media/image39.png" width="342" height="232" />

8.  To open the extension, click the extension icon that will appear on
    the right of the address bar. Select the **Connection
    Settings** tab. Enter “**vsalm**” as the **Server URL** and click
    **Next**.

    <img src="./media/image40.png" width="489" height="468" />

9.  The extension can be used in two modes: **Connected** and
    **Standalone** mode. If you have Team Foundation Server (TFS)
    connection or a Visual Studio Team Services (VSTS) account, select
    Connected mode. Standalone mode is for users who don’t have TFS (or
    VSTS account) and want to use the extension to file bugs and share
    the report with their team.

10. After connecting to TFS, you will need to select the team you want
    these efforts associated with. Select the
    **PartsUnlimitedCollection** and select the **PartsUnlimited Team**
    at the end of the chain. Click **Save** to continue.

    <img src="./media/image41.png" width="480" height="251" />

### Task 2: Authoring a Manual Test Plan

1.  In Chrome, navigate to <http://vsalm:8080/tfs>.

2.  Asd

    <img src="./media/image42.png" width="280" height="110" />

3.  Fds

    <img src="./media/image43.png" width="400" height="76" />

4.  ds

    <img src="./media/image44.png" width="334" height="143" />


5.  Name the new suite **“End-to-end tests”** and press **Enter**.

    <img src="./media/image45.png" width="221" height="60" />

6.  From the **Tests** tab, select **New | New test case** to create a
    new test case.

    <img src="./media/image46.png" width="314" height="149" />

7.  In the **Title** box, type “**Confirm that order number appears
    after successful order**” as the name of the new test case.

    <img src="./media/image47.png" width="404" height="125" />

8.  At this point, we’re ready to add steps to this manual test. Each
    step includes an **Action**, which describes the action the tester
    needs to perform. Optionally, a step can include an **Expected
    Result**, which describes the expected result of the given action.
    In the **Steps** panel, create a step for each of the following
    **Actions**, only one of which has an **Expected Result**. See the
    next paragraph for an alternate, faster way to add the actions.

    | Action                                                                                | Expected Result                                     |
    |---------------------------------------------------------------------------------------|-----------------------------------------------------|
    | Open http://www.partsunlimited.com                                                    |                                                     |
    | Click Brakes                                                                          |                                                     |
    | Click Disk and Pad Combo                                                              |                                                     |
    | Click Add to Cart                                                                     |                                                     |
    | Click Checkout                                                                        |                                                     |
    | Enter @Email, @Password                                                               |                                                     |
    | Enter @Name, @Phone, @Email, @Address, @City, @State, @PostalCode, @Country, @Promo   |                                                     |
    | Click Submit Order                                                                    |                                                     |
    | Confirm order page has order \#                                                       | Order \# should appear on order confirmation page   |
    | Log out                                                                               |                                                     |
    | Close browser                                                                         |                                                     |

    >Note: If you end up with an extra empty step, delete it.


9.  At this point, the **Steps** panel should look similar to the
    following:

    <img src="./media/image48.png" width="624" height="204" />


10. Note the “Enter @Email, @Password” and “Enter @Name, @Phone, @Email,
    @Address, @City, @State, @PostalCode, @Country, @Promo” steps. In
    these steps, we used the **@** sign to indicate that there were
    iteration-specific variables to be used during the manual
    test pass. We can define which variables to use by scrolling down
    to the **Parameter Values** section of this form and entering them
    for each iteration.

    <img src="./media/image49.png" width="624" height="79" />

11. Use the following table to set up values for two iterations.

    | Email               | Password   | Name         | Phone          | Address              |
    |---------------------|------------|--------------|----------------|----------------------|
    | <admin@test.com>    | P@ssw0rd   | Admin User   | 425-555-1234   | One Microsoft Way    |
    | <sachin@test.com>   | P@ssw0rd   | Sachin Raj   | 555-555-5555   | Two Tailspin Trail   |

    | City          | State   | PostalCode   | Country   | Promo   |
    |---------------|---------|--------------|-----------|---------|
    | Redmond       | WA      | 98052        | USA       | FREE    |
    | Springfield   | IL      | 11135        | USA       | FREE    |


12. The **Parameter Values** section should now look like this. Note
    that you can enter as many iterations as you need to fully test
    the breadth of the scenario.

    <img src="./media/image50.png" width="624" height="97" />



13. Click **Save & Close** to save the test case.

    <img src="./media/image51.png" width="624" height="96" />

### Task 3: Running a Manual Test Plan

In this task, you will learn how to run the manual test plan that we created earlier.

1.  Return to **IE. R**ight-click the test case created earlier and
    select **Run with options** to begin a manual test run.

    <img src="./media/image52.png" width="624" height="223" />

2.  There are a few options that you can use to customize each test run.
    The first option is to select a **Runner**, which will be the
    browser in this scenario. Next, you may have the option to specify
    which kinds of **data to collect**. Finally, you may optionally
    specify which build is being tested to make it easier to associate
    the results with the build they were from. Click the **Browse**
    button to select a build.

    <img src="./media/image53.png" width="476" height="316" />

3.  Das

    <img src="./media/image54.png" width="624" height="260" />

4.  Press **Esc** to dismiss the **Find Builds** window without
    selecting a build.

5.  Click **OK** to continue.

    <img src="./media/image55.png" width="476" height="403" />

6.  If the **Test Runner** window does not appear, check to see if it
    was blocked by the pop-up blocker. If so, click the **Pop-up
    blocker** button, select **Always allow pop-ups…**, and then click
    **Done**. You can then launch the test run again with success.

    <img src="./media/image56.png" width="476" height="223" />

7.  In the **Test Runner** window, expand the **Test 1 of 1: Iteration
    1** dropdown. Note that there are two iterations: one for each set
    of parameters specified in the test case. In the first iteration,
    the <admin@test.com> account is used. In the second,
    <sachin@test.com> will be used.

    <img src="./media/image57.png" width="357" height="314" />

8.  The first step in the test is to open
    [www.partsunlimited.com](http://www.partsunlimited.com). To do
    this, open a new window in Chrome. If you’re working on a large
    screen, it may be easier to resize the new window to fit next to
    the **Test Runner** window. Otherwise you can just switch back
    and forth.

    <img src="./media/image58.png" width="624" height="176" />

    >**Note:** The
    [www.partsunlimited.com](http://www.partsunlimited.com) URL is
    hardcoded in the hosts file to point at a website on the local VM.
    As a result, you must use this full domain when testing.

9.  Once the site loads, return to the **Test Runner** and click the
    **Pass test step** button.

    <img src="./media/image59.png" width="454" height="154" />

10. The next step is to click the **Brakes** menu item.

    <img src="./media/image60.png" width="403" height="212" />

11. Then click the **Disk and Pad Combo** product.

    <img src="./media/image61.png" width="288" height="428" />

12. The next step is to click **Add to cart**.

    <img src="./media/image62.png" width="624" height="314" />

13. On the next page, click **Checkout**.

    <img src="./media/image63.png" width="624" height="269" />

14. Log in using the credentials specified in the next step.

    <img src="./media/image64.png" width="540" height="320" />

15. Fill out the shipping information and add the promo code. Click
    **Submit Order**.

    <img src="./media/image65.png" width="624" height="315" />

16. Confirm the order number is shown on the confirmation page. Be sure
    to pass this step as it is the only one with an expected result.

    <img src="./media/image66.png" width="364" height="291" />

17. The last steps are to log out via **Profile | Log off** and to close
    the browser window.

    <img src="./media/image67.png" width="445" height="192" />

18. Move to the next iteration by clicking **next** in the **Test
    Runner**. This will load the next set of parameters.

    <img src="./media/image68.png" width="451" height="83" />

19. Follow the test case steps until you reach the login step. This will
    fail because there isn’t a <sachin@test.com> account.

    <img src="./media/image69.png" width="432" height="348" />

20. The **Test Runner** provides three valuable ways to record media
    from a test run. The first option is to take screenshots. The
    second is to capture each user action in an image action log. The
    final is to record the screen as a video. Select the failed step
    and click the first option to take a screenshot. From the
    dropdown, select the **Log in** window the tests are being run in.

    <img src="./media/image70.png" width="434" height="314" />

21. Crop the screen down to show the login form and error message.
    Specify the name **“No Sachin account”** and click the
    **Confirm** button.

    <img src="./media/image71.png" width="624" height="312" />

22. Add a comment of **“Sachin account does not exist”** and fail the
    test using the **Fail test step** button.

    <img src="./media/image72.png" width="437" height="233" />

23. Click **Create bug** to log a new bug.

    <img src="./media/image73.png" width="317" height="56" />

24. Enter the bug title of **“Sachin test account does not exist”** and
    click **Save & Close** to log the bug.

    <img src="./media/image74.png" width="453" height="153" />

25. Since the test cannot be completed due to a bug not directly related
    to the functionality being tested, expand the **Mark test case
    result** dropdown and select **Block test**. Click **Save and
    close** to save the test run.

    <img src="./media/image75.png" width="455" height="209" />

26. Close the test browser windows.

### Task 4: Analyzing Manual Test Results

In this task, you will learn how to review the results of a manual test run.

1.  Return to the browser window hosting the **Test Hub**. Select the
    > **Runs** tab and double-click the most recent test run to open it.

    <img src="./media/image76.png" width="624" height="250" />

2.  The **Run summary** tab provides an overview of the test run, as
    well as high-level details on the results of all tests included as
    part of the run.

    <img src="./media/image77.png" width="624" height="391" />

3.  Select the **Test results** tab. This tab lists the results of each
    individual test case included in the run along with their results.
    Since there was only one test case included here, double-click it
    to open.

    <img src="./media/image78.png" width="479" height="144" />

4.  You can review all details for this particular test case run
    from here.

    <img src="./media/image79.png" width="624" height="395" />

5.  Scroll to the bottom to locate the iterations. Expand the
    second iteration.

    <img src="./media/image80.png" width="562" height="176" />

6.  Review the results of each step in this iteration, as well as the
    failed login step, which shows the screenshot attached during the
    test run.

    <img src="./media/image81.png" width="624" height="206" />

### Task 5: Creating Shared Steps

In this task, you will learn how to create shared steps. A shared
    step combines multiple steps that are commonly performed in sequence
    into a single logical step, which can be shared across tests. If the
    process defined by the shared steps ever changes in the future, you
    can update the shared step in one place and it will be reflected in
    all tests that reference it.


1.  Click the test case link in the **Summary** section to open the test
    case editor.

    <img src="./media/image82.png" width="414" height="235" />

2.  Select steps 2-4 (use **Shift+Click**) and click the **Create shared
    steps** button.

    <img src="./media/image83.png" width="355" height="251" />

3.  Set the name of these shared steps to **“Add Disk and Pad Combo to
    cart”** and click **Create**.

    <img src="./media/image84.png" width="408" height="120" />

4.  Now you can see the previous steps replaced with the shared steps.
    Double-click the shared steps to open.

    <img src="./media/image85.png" width="276" height="116" />

5.  If necessary, you can revisit these steps later on to update them
    for new requirements.

    <img src="./media/image86.png" width="624" height="376" />

6.  Press **Esc** to close the **Shared Steps** dialog.

7.  Click **Save & Close** to save the test case.

    <img src="./media/image87.png" width="345" height="40" />
