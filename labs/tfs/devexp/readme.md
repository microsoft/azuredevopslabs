---
title: Developer experience enhancements in Visual Studio 2017
layout: page    
sidebar: tfs
permalink: /labs/tfs/devexp/
folder: /labs/tfs/devexp/
---

Lab version: 15.0.26020.0

Last updated: 2/13/2017

## Overview

Visual Studio 2017 introduces a wealth of features and enhancements
designed to significantly improve the productivity of developers. Many
of these improvements focus on saving time and effort on everyday tasks,
such as code navigation, IntelliSense, refactoring, code fixes, and
debugging. In this lab, we’ll take a quick tour of some of the many
benefits.

There are also a wealth of new features and enhancements in Visual
Studio 2017 covered in other labs. Be sure to check out hands-on labs on
topics such as Azure, Git, EditorConfig, Live Unit Testing, Live
Architecture Dependency Validation, and more. In addition, there has
been a significant investment in performance throughout the IDE, ranging
from <a href="https://blogs.msdn.microsoft.com/visualstudio/2016/10/10/faster-visual-studio-15-startup/" />faster startup
times</a>
and <a href="https://blogs.msdn.microsoft.com/visualstudio/2016/10/11/shorter-solution-load-time-in-visual-studio-15/" />lightweight solution
load</a>
to <a href="https://blogs.msdn.microsoft.com/visualstudio/2016/10/05/announcing-visual-studio-15-preview-5/" />improved performance in everyday
features</a>.

For a more exhaustive list of what’s new in Visual Studio 2017, please
check out the <a href="https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes#whats-new-in-visual-studio-2017" />release
notes</a>.

## Prerequisites

1.  In order to complete this lab you will need the Visual Studio 2017
    virtual machine provided by Microsoft. For more information on
    acquiring and using this virtual machine, please see <a href="http://aka.ms/almvm"/>this blog
    post</a>.

## Exercise 1: Developer experience enhancements in Visual Studio 2017

### Task 1: Working with the new modular installer

1.  Log in as **Sachin Raj (VSALM\\Sachin)**. All user passwords are
    **P2ssw0rd**.

2.  Open **Windows Explorer** and navigate to **C:\\Bits**. Double-click
    the VS installer to launch it.

    <img src="media/image1.png" width="382" height="160" />

3.  If asked to update the installer, do so.

4.  Accept the terms to continue.

    <img src="media/image2.png" width="457" height="102" />

5.  After accepting the terms, the installer may offer to update
    Visual Studio. Click **Cancel** to skip this. While updates are now
    really fast, they’re not the focus of this lab.

    <img src="media/image3.png" width="532" height="130" />

6.  Expand the menu next to the **Launch** button and select **Modify**.

    <img src="media/image4.png" width="405" height="309" />

7.  The new lightweight and componentized installer breaks down Visual
    Studio into independent workloads that lets you install just what
    you need, helping you get going much faster. Some workloads have
    already been installed on the VM, such as **.NET desktop
    development** and **Web development**. Selecting these workloads
    ensured that the installer would set up everything needed to perform
    the task associated with those types of development, which you can
    view in the **Summary \| Individual components** section on the
    right side.

    <img src="media/image5.png" width="624" height="212" />

8.  However, let’s say that your role has changed and you’re now also
    working on Universal Windows Platform apps. Click that workload and
    Visual Studio will calculate what needs to be set up (along with
    offering optional components).

    <img src="media/image6.png" width="624" height="342" />

9.  Of course you can still select individual components to install,
    regardless of selected workflow. Select the **Individual
    components** tab to see a flat list of all the tools, features, and
    SDKs available.

    <img src="media/image7.png" width="438" height="206" />

10. Close all installer windows.

### Task 2: Boosting your productivity

1.  Launch **Visual Studio** from the taskbar.

2.  Open the **PartsUnlimited.sln** solution from the **Start Page**.

    <img src="media/image8.png" width="365" height="194" />

3.  **Navigate To** has been completely overhauled and renamed **Go To
    All**. From the main menu, select **Edit \| Go To** and select **Go
    To All**.

    <img src="media/image9.png" width="553" height="184" />

4.  **Go To All** consolidates the search experience across project
    assets and offers easy filtering. Type **“home”** and select
    different results from the list. Each will open in the temporary
    editor slot so that you can preview the file contents.

    <img src="media/image10.png" width="461" height="203" />

5.  Select the **Types** filter. This adds a “t” to the front of the
    query, indicating that you want to filter by types. You can also
    manually type that filter yourself in the future to save time. Click
    **HomeController** and press **Enter** to open it in a
    permanent slot.

    <img src="media/image11.png" width="447" height="168" />

6.  Press **Ctrl+T** to reopen **Go To All**. Type **“:”** (a colon) to
    filter the query to **Go To Line**. Note that there is a tip
    provided to let you know what input is valid here, such as 1-127 due
    to the number of lines in the file.

    <img src="media/image12.png" width="455" height="117" />

7.  Finish the search by completing **“: 33”** and clicking the line
    result provided.

    <img src="media/image13.png" width="454" height="102" />

8.  The **“th”** (the first half of “this”) and **IntelliSense** will
    jump in with an expected set of suggestions. In addition,
    IntelliSense also provides a set of filters at the bottom so that
    you can zero in on types, properties, etc. It’s also more intuitive
    about parameters and will default to the option it thinks is best
    when possible. Plus, IntelliSense supports **dozens** of programming
    languages out of the box.

    <img src="media/image14.png" width="343" height="166" />

9.  Complete typing **“this.GT”**. IntelliSense also recognizes capital
    letters as shorthand and will refine results based on the available
    options that fit the typed pattern. In this case there are two valid
    options for “this” that have capital **G** followed by a capital
    **T** later in their name. Select **GetTopSellingProducts** to
    complete the code.

    <img src="media/image15.png" width="624" height="100" />

10. **Find All References** has also gotten a makeover in Visual
    Studio 2017. Right-click **GetTopSellingProducts** and select **Find
    All References**.

    <img src="media/image16.png" width="505" height="200" />

11. The results window is now much more modern with grouping and color.
    Hovering over one of the results even provides a peek preview.

    <img src="media/image17.png" width="528" height="167" />

12. Remove the partial line of code you just added in the
    previous steps.

13. Set a breakpoint at line 33 by clicking the grey bar to its left.

    <img src="media/image18.png" width="624" height="107" />

14. Press **F5** to launch the site in debug mode. Wait until the
    breakpoint hits.

15. One of the nifty new features in the debugging experience is the
    ability to **Run to Click**. Hover next to the line of code at line
    40 and click the **Run to Click** button that appears. The debugger
    will now execute until it hits that line.

    <img src="media/image19.png" width="624" height="151" />

16. After the step, a **PerfTip** will appear next to the current line
    indicating how long it took to execute to get here. While this
    number is probably pretty low for this scenario, it might be much
    larger in others. If you click the **PerfTip**, it will bring you
    directly to the **Diagnostic Tools** so that you can
    start reviewing.

    <img src="media/image20.png" width="346" height="132" />

    <img src="media/image21.png" width="310" height="386" />


