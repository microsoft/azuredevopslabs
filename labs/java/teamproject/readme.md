---
title: Creating your Visual Studio Team Services account and Team project 
layout: page
sidebar: mydoc_sidebar
permalink: /labs/java/teamproject/
folder: /labs/java/teamproject/
comments: true
---

This exercise will walk you through the steps to creating your Visual
Studio Team Services account and create a new project. **If you already
have a VSTS account, you can skip a few steps and jump to step 13.**
Before you do step 13, you’ll need to log in to your VSTS account and
start the New Team Project wizard. You can then follow the steps (the
instructions assume you’re creating an account *and* a Team Project at
the same time but that’s not mandatory—you just need an account in which
you have Project Collection Administrator permissions).

Depending upon whether or not you have an MSDN Subscription, and whether
you’ve tried Visual Studio Team Services before, you can get started a
few ways. Regardless, you’ll need a valid Microsoft Account or already
linked Organizational Account to move forward.

Creating your Visual Studio Team Services account
-------------------------------------------------

1.  Login to the virtual machine.

2.  Start the Firefox web browser.

3.  If you don’t have an existing Microsoft account that you want to
    use, visit <http://www.outlook.com> to create a Microsoft Account
    and optionally get yourself a free personal e-mail address. If you
    have a Microsoft account you want to use, just continue to the
    next step.

4.  Navigate to <http://www.visualstudio.com>.

5.  In the upper right-hand corner, click the **Sign In** link.

    <img src="./images/image2.png" width="624" height="294" />

1.  The site redirects you to a log in page like the following if you’re
    not already logged in (If you don’t see the following screen
    continue to the next step). Enter your e-mail address for your
    Microsoft account and its password and click **Sign in**.

    <img src="./images/image3.png" width="452" height="258" />

1.  Once you’ve logged in, you might be greeted with a page (*if not,
    jump to the next step*), like the following, that will allow you
    to confirm your **display name**, **contact e-mail**, and your
    **country/region**. Once you set this information, you can change
    it later. Under the **Hello,** field, enter your first and
    last name. If you want to receive e-mail notifications from Visual
    Studio Team Services at a different e-mail address than the one
    associated with your Microsoft account, change the address shown
    under the **We’ll reach you at:** field. Click **Continue**.

    <img src="./images/image4.png" width="281" height="404" />

    You should now be at the **My Information** page. You’ll jump from here to the account creation process.

    Please continue reading before making choices.

    <pre>When you are creating an account, there are two pieces of data that you will need to provide. 
    However, from time to time, we experiment with different ways to onboard new customers. It is possible 
    what you see will vary. In general, the following data is required.</pre>

    The first piece of data is the **Account URL**. Currently, all Visual  Studio Team Services accounts live within the top-level
    **visualstudio.com** domain. The account name you choose could be something personal, like your name, or something more work-related, like
    your company name. If you do intend to set up your account to share with others at your organization, you might want to coordinate this with
    those in your organization that manage your servers and infrastructure. 

    The second field that affects your account is where Microsoft hosts your
    account. Visual Studio Team Services is a purpose-built cloud service
    hosted in Microsoft Azure. You should pick the one that is closest to
    you and the majority of users of your account.

    Once you have an account, you need at least one Team Project to track
    you work, store your code, test, and run builds. This lab gives you
    specific instructions so you can use some tools and complete the lab.
    Understand that Visual Studio Team Services is very flexible and that
    you should explore it after the event.

    The next section describes the Visual Studio Team Services on-boarding
    experience. What you see can and will vary if it is your first time
    accessing Visual Studio Team Services or not.

1.  On the right of the **My Information** page find the **Create a free
    account now** link and click it.

    <img src="./images/image5.png" width="624" height="263" />

    Once you do this, the experience you get might vary. If this is your
    very first time creating a team project, you will be prompted to create
    an account. Generally, you will see a screen like the following.

    <img src="./images/image6.png" width="468" height="208" />

1.  Enter a value in the **Account URL** field. It is possible you might
    have to try a couple different names.

2.  Click the **Change Options** link.

    <img src="./images/image7.png" width="279" height="205" />

1.  Select the appropriate region.

    <img src="./images/image8.png" width="285" height="191" />

1.  Click the **Create Account** button.

    If you have picked an account name in use, you will receive a warning.
    Pick a different name and try again.

    Creating a new account is typically fast and can take as little as a few
    seconds to complete. 
    
1. Once done, you will be directed to the **Create
    your first project** page that helps you create your first Team Project.
    Continue to the steps after the following screen shot to fill in the
    details.

    <img src="./images/image9.png" width="624" height="360" />

1.  Enter **jdev** in the **Project name** field for your Team Project.
    If you use **jdev** while you are doing in this lab, your screen
    will match the screen shots and instructions here.

2.  Select the **Scrum** process template. *This is required*.

3.  Select **Git** for Version Control. *This is also required*.

4.  If you are provided the option, place a check next to **Create a
    README.md file to describe the project**. If you do not get the
    option, there is nothing to worry about. Just continue.

    <img src="./images/image10.png" width="397" height="212" />

1.  Click **Create Project**.

    Visual Studio Team Services queues up a job to build your Team
    Project and, once again, in as little as a few seconds, you will
    have a new Team Project.

2.  Once done, you should be at your CODE hub in your Team Project.
    Continue reading if you don’t see a screen like below.

    <img src="./images/image11.png" width="624" height="167" />

1.  If you don’t see the CODE hub but instead see a dialog like the
    following, click **Add code**. If you just see your Team Project’s
    home page, click the CODE hub link and continue.

    <img src="./images/image12.png" width="402" height="229" />

1.  If your CODE hub looks a bit different than the figure from earlier
    (usually because you don’t have a README.md), click the **Create a
    ReadMe file** button. Once you’ve done this, you’re ready to
    continue on.

    <img src="./images/image13.png" width="303" height="357" />

Now you’re going to manage your backlog with Visual Studio Team
Services. You can read more about account creation and more at
<https://www.visualstudio.com/en-us/docs/setup-admin/team-services/connect-to-visual-studio-team-services>

