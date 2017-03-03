---
title: Instrumenting ASP.NET with Application Insights in Visual Studio 2017
layout: page
sidebar: tfs
permalink: /labs/tfs/appinsights/
folder: /labs/tfs/appinsights/
---

Lab version: 15.0.26020.0

Last updated: 2/28/2017


## Overview

[Visual Studio Application
Insights](https://azure.microsoft.com/services/application-insights) is
an extensible analytics service that helps you understand the
performance and usage of your live web application. It's designed for
developers, to help you continuously improve the performance and
usability of your app. It works with web apps on .NET or J2EE, hosted
on-premises or in the cloud. You can also apply it to Windows background
services and desktop apps.

In this lab we will start with a fresh ASP.NET application and explore
how you can instrument it with Application Insights. This will make it
easier to track site usage and patterns, as well as to detect, diagnose,
and triage issues related to performance and more.

## Pre-requisites

In order to complete this lab you will need the Visual Studio 2017
virtual machine provided by Microsoft. For more information on acquiring
and using this virtual machine, please see [this blog
post](http://aka.ms/almvm).

You will also need an Azure account, which you can set up at
<http://azure.com>.

## Exercise 1: Instrumenting with Application Insights

### Task 1: Adding Application Insights to an ASP.NET Application


1.  Log in as **Sachin Raj (VSALM\\Sachin)**. All user passwords are
    **P2ssw0rd**.

2.  Launch **Visual Studio** from the taskbar.

3.  Select **File \| New \| Project** from the main menu.

4.  From the **Visual C\# \| Web** section, select the **ASP.NET Web
    Application (.NET Framework)** template and enter a **Name** of
    **“AppInsightsLab”**. Click **OK** to continue.

    <img src="media/image1.png" width="624" height="310" />

5.  Select the **MVC** template and uncheck **Host in the cloud**.
    Everything we’re covering here works just as well regardless of
    where it’s hosted, so we’ll work locally to keep things simple.
    Click **OK** to create the project.

    <img src="media/image2.png" width="624" height="408" />

6.  Press **F5** to build and run the app. As you can see, there’s
    nothing special here yet. Close the browser to end the
    debugging session.

7.  In **Solution Explorer**, right-click the **AppInsightsLab** project
    node and select **Application Insights | Configure Application
    Insights**.

    <img src="media/image3.png" width="238" height="148" />

8.  By default, the NuGet references to the core Application Insights
    packages are added. However, you’ll need to connect with an Azure
    account to collect and analyze data. Click **Get started for free**.

    <img src="media/image4.png" width="479" height="509" />

9.  Click **Sign in** and sign in with your Azure account.

    <img src="media/image5.png" width="439" height="253" />

10. Click **Register for free** to use the default settings. Click
    **Finish** when the process completes.

    <img src="media/image6.png" width="467" height="338" />

11. Click **Collect traces from System.Diagnostics** to add that trace
    listener to the project. This will enable you to send logs to
    Application Insights so that they can be merged in with other
    telemetry data collected in the application. Click **Finish** when
    the process completes.

    <img src="media/image7.png" width="468" height="364" />

12. Let’s walk through **Solution Explorer** to take a look at what was
    added and changed to the project. First, locate the **Application
    Insights** folder inside the **Connected Services** node. This
    provides a link to more information on getting started.

    <img src="media/image8.png" width="355" height="194" />

13. Expand the **References** node and locate the
    **Microsoft.AI.\*** assemblies. These are the payloads of NuGet
    packages added by Application Insights.

    <img src="media/image9.png" width="356" height="214" />

14. Double-click the **ErrorHandler\\AiHandleErrorAttribute.cs** file to
    open it.

    <img src="media/image10.png" width="359" height="89" />

15. This class contains a global exception handler that automatically
    sends unhandled exceptions to Application Insights for logging.

    <img src="media/image11.png" width="624" height="193" />

16. Double-click the **Views\\Shared\\\_Layout.cshtml** file to open it.

    <img src="media/image12.png" width="360" height="103" />

17. This file is the outer-most template for HTML pages rendered by
    this application. Application Insights has inserted initialization
    code inside the **&lt;head&gt;** tag so that you can immediately
    start using the JavaScript API to instrument the client-side portion
    of the application. Note the **instrumentationKey** property in the
    middle of the code block. This key is unique to your Application
    Insights account.

    <img src="media/image13.png" width="624" height="221" />

18. Double-click **ApplicationInsights.config** to open it.

    <img src="media/image14.png" width="359" height="50" />

19. This file contains virtually all of the configuration used by
    Application Insights on the server. Note the same **InstrumentationKey**.

    <img src="media/image15.png" width="590" height="194" />

20. Finally, **packages.config** has been updated to reflect the NuGet
    packages and **Web.config** has been updated to reflect the
    assembly references.

    <img src="media/image16.png" width="360" height="69" />

### Task 2: Tracking usage data

1.  Press **F5** to build and run the project. Navigate around the site
    for a few pages using the navigation links at the top to
    generate traffic. Be sure to visit the **Contact** page.

    <img src="media/image17.png" width="387" height="257" />

2.  Leave the browser window open and return to **Visual Studio**.

3.  Click the **Application Insights** button. Note that it may be
    minimized inside a collapsed menu button if the window is narrow.

    <img src="media/image18.png" width="467" height="87" />

4.  The default action of the button is to open the **Application
    Insights Search**. This provides access to the full set of telemetry
    data collection throughout the application’s history. Search for
    **“contact”** and click the first result that comes up.

    <img src="media/image19.png" width="624" height="238" />

5.  The **Request Details** that open provide a wealth of information
    about the collected data from the request, such as the request and
    response details. Click the **Track Operation** tab.

    <img src="media/image20.png" width="402" height="270" />

6.  The **Track Operation** tab provides the details and timeline of the
    steps involved in the request. In this case, it’s a pretty simple
    single-step operation that succeeded.

    <img src="media/image21.png" width="409" height="222" />

### Task 3: Working with the Application Insights Portal

1.  Open a new browser window (not a new tab in the debug
    browser window) and navigate to <https://portal.azure.com>. The
    portal provides even more functionality.

2.  Click **Application Insights** from the navigation menu.

    <img src="media/image22.png" width="216" height="288" />

3.  Click the **AppInsightsLab** account to open it.

    <img src="media/image23.png" width="179" height="77" />

4.  The **Overview** blade provides a dashboard view of the account.
    There are shortcut links and standard reports as well.

    <img src="media/image24.png" width="624" height="443" />

5.  Click the **Open chart in Analytics** button.

    <img src="media/image25.png" width="543" height="405" />

6.  This will open the extremely powerful **Analytics** engine for query
    and analysis. You can create virtually any kind of report you need
    using the flexible syntax and access to everything in the platform.
    Close the browser tab.

    <img src="media/image26.png" width="624" height="292" />

7.  Back on the **Overview** blade, click **Alerts**. Alerts are
    proactive notifications the platform can send you based on the
    circumstances you define.

    <img src="media/image27.png" width="565" height="107" />

8.  Click **Add alert**.

    <img src="media/image28.png" width="161" height="100" />

9.  Expand the **Metric** dropdown to see the list of metrics you can
    monitor for alerts. Close the alert blades until you return to the
    **Overview** blade.

    <img src="media/image29.png" width="278" height="547" />

10. **Smart Detection** is a machine learning feature that learns about
    your app’s behavior over time and can proactively identify
    circumstances that may be unexpected so that you can be alerted.

    <img src="media/image30.png" width="565" height="107" />

11. Click **Web tests**. Web tests are automated processes you can
    configure Application Insights to run periodically to ensure the
    application is running as expected.

    <img src="media/image31.png" width="565" height="107" />

12. Click **Add web test**.

    <img src="media/image32.png" width="359" height="126" />

13. You can create web tests that either ping a URL periodically or run
    a **.webtest** file you provide in order to determine whether the
    site is running as expected. Close the test blades until you return
    to the **Overview** blade for this project.

    <img src="media/image33.png" width="289" height="569" />

14. Click the **Live Stream** button to begin live streaming the
    Application Insights collections into the portal.

    <img src="media/image34.png" width="565" height="107" />

15. Return to the debug test app browser and use the navigation links to
    generate some site traffic. Close the debug application browser
    window (not the portal window) when done.

    <img src="media/image17.png" width="387" height="257" />

16. Return to the portal window and notice how the traffic you just
    generated is already showing up.

    <img src="media/image35.png" width="562" height="258" />

17. Close the **Live Metrics Stream** blade.

18. Click the **App map** button.

    <img src="media/image36.png" width="565" height="107" />

19. The **Application Map** is a visual layout of the dependency
    relationships of your application components. Each component shows
    KPIs such as load, performance, failures, and alerts, to help you
    discover any component causing a performance issue or failure. You
    can click through from any component to more detailed diagnostics,
    such as Application Insights events. If your app uses Azure
    services, you can also click through to Azure diagnostics, such as
    SQL Database Advisor recommendations. Click the **+** button to
    expand the **Client**
    relationships.<img src="media/image37.png" width="524" height="120" />

20. Besides the **Server**, the **Client** also has a dependency on
    **AJAX** requests, which you can see here.

    <img src="media/image38.png" width="624" height="79" />

### Task 4: Tracking exceptions

1.  Return the **Solution Explorer** in **Visual Studio** and
    double-click **Controllers\\HomeController.cs** to open that file.

    <img src="media/image39.png" width="353" height="269" />

2.  Insert the following line of code at the top of the
    **Contact** method.

    ```
    // C\#

        throw new Exception("Contact exception!");

    ```

3.  The final method should look like this.

    <img src="media/image40.png" width="471" height="143" />

4.  Press **F5** to build and run the newly flawed project.

5.  Navigate to the **Contact** page.

    <img src="media/image41.png" width="380" height="52" />

6.  This will throw an exception and break in **Visual Studio**. Press
    **F5** to continue anyway.

7.  In **Visual Studio**, click the **Application Insights** button.

    <img src="media/image42.png" width="201" height="69" />

8.  There should be data in the view, but if there isn’t, click the
    **Reset** button and set the **Time range** to **Last 30 minutes**.
    This occasionally needs to be done to refresh the view. Note that
    there is now an **Exception** tracked.

    <img src="media/image43.png" width="624" height="126" />

9.  Locate and click on the **Exception** in the list view.

    <img src="media/image44.png" width="624" height="83" />

10. Like the request earlier, you can also click **Track Operation** to
    see the steps involved to get to this exception.

    <img src="media/image45.png" width="404" height="139" />

11. As we already knew, the exception began with a request to
    **Home/Contact**.

    <img src="media/image46.png" width="374" height="265" />

12. Expand the **Application Insights** dropdown and select **Explore
    Telemetry Trends**.

    <img src="media/image47.png" width="312" height="210" />

13. The **Application Insights Trends** tool visualizes how your
    application's important telemetry events change over time, helping
    you quickly identify problems and anomalies. By linking you to more
    detailed diagnostic information, Trends can help you improve your
    app's performance, track down the causes of exceptions, and uncover
    insights from your custom events. Change the **Telemetry Type** to
    **Exceptions** and click **Analyze Telemetry** to see the trends
    for exceptions.

    <img src="media/image48.png" width="407" height="81" />

14. Return to the portal window, which should still be open to the
    **Application Map**. Click **Refresh**.

    <img src="media/image49.png" width="596" height="91" />

15. Note that the **Server** now indicates that there is a warning,
    which is a direct result of the exception. Click the warning.

    <img src="media/image50.png" width="248" height="97" />

16. Scroll to the bottom of the new blade and click the exception.

    <img src="media/image51.png" width="541" height="142" />

17. In the **Exceptions** panel, click **Contact exception!** to review
    its details.

    <img src="media/image52.png" width="538" height="122" />

18. Even in the portal, you can review the full stack trace and other
    details about the exception.

    <img src="media/image53.png" width="568" height="465" />

19. Return to **HomeController.cs** in **Visual Studio**. Note the two
    **CodeLens** markers on the right side of the **Contact** method.
    Click the last one to review **Exception** details. Click the one
    before it to view requests. These are pulling data from Application
    Insights to provide you with timely information in the editor.

    <img src="media/image54.png" width="624" height="227" />

20. Close the debug app browser window.

### Task 5: Integrating telemetry

1.  Add the following code inside the **About** method. This will track
    a server-side custom event every time someone visits **Home/About**.

    ```
    // C\#

        var ai = new Microsoft.ApplicationInsights.TelemetryClient();

        ai.TrackEvent("About - server");
    
    ```

2.  In **Solution Explorer**, double-click **Views\\Home\\About.cshtml**
    to open it.

    <img src="media/image55.png" width="301" height="99" />

3.  Add the following code to the end of the file. It will use the
    JavaScript API to track a custom browser-side event when the
    **About** page is visited.

    ```
    @section scripts

        {

        &lt;script type="text/javascript"&gt;

        appInsights.trackEvent("About - client");

        &lt;/script&gt;

        }
    ```

4.  Press **F5** to build and launch the site. Since **About.cshtml**
    was open, it should open to that page. Otherwise, navigate to it
    using the link at the top.

5.  In **Visual Studio**, click **Application Insights**.

    <img src="media/image56.png" width="221" height="38" />

6.  Now you should see a **Custom Event** has been tracked, which is
    from the server-side telemetry.

    <img src="media/image57.png" width="624" height="266" />

7.  Return to the portal window and close all blades until you get back
    to the **Overview** blade. Click the **Page view load time** chart.

    <img src="media/image58.png" width="624" height="393" />

8.  Click the **Page Views** chart.

    <img src="media/image59.png" width="576" height="297" />

9.  Click **Filters**.

    <img src="media/image60.png" width="270" height="89" />

10. Check the **Custom Event** filter to add it. This will add
    browser-side events to the report. Click **Update**.

    <img src="media/image61.png" width="299" height="369" />

11. On the **Search** blade, you will now see the custom event in
    the chart. You can now even drill in to the event to get more
    details, see other requests in the same session, and more.

    <img src="media/image62.png" width="576" height="539" />


