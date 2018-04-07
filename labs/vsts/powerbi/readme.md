---
title: Connect to Visual Studio Team Services with Power BI
layout: page
sidebar: vsts
permalink: /labs/vsts/powerbi/
folder: /labs/vsts/powerbi/
---

Last updated : {{ "now" | date: "%b %d, %Y" }}.

## Overview

You can gain insight and analyze the progress and quality of your project by connecting Power BI to the data collected and stored for Team Services.

Power BI is a suite of business analytics tools that deliver insights throughout your organization. Connect to hundreds of data sources, simplify data prep, and drive ad hoc analysis. Produce beautiful reports, then publish them for your organization to consume on the web and across mobile devices. Everyone can create personalized dashboards with a unique, 360-degree view of their business. And scale across the enterprise, with governance and security built-in.

{% include important.html content= "The Visual Studio Team Services (VSTS) Content Pack for Power BI has been deprecated on November 15, 2017 primarily due to the negative impact it has had on VSTS accounts, including throttling end users access. Support will continue for all existing [PowerBI.com](https://powerbi.microsoft.com/en-us/){:target=\"_blank\"} data sets based on the Content Pack. However, you won’t be able to create any new data sets.<br/>

The [Analytics Marketplace extension](https://marketplace.visualstudio.com/items?itemName=ms.vss-analytics){:target=\"_blank\"} and upcoming updates to the [Power BI Desktop connector](https://docs.microsoft.com/en-us/vsts/report/powerbi/data-connector-connect){:target=\"_blank\"} for VSTS are intended to replace and improve on the capabilities of the Content Pack. While the Analytics Marketplace extension currently supports Work Item Tracking data, we will update it to support additional data types including Tests, Build, Release and Version Control. In the interim, you can use [VSTS REST APIs](https://www.visualstudio.com/en-us/docs/integrate/api/overview){:target=\"_blank\"} as an alternative to the Content Pack to report on these additional data types." %}

## Prerequisites

1. You should have Office365 account in order to integrate Visual Studio Team Services with Power BI

1. Visual Studio Team Services account. If you don't have one, you can create from [here](https://www.visualstudio.com/team-services){:target="_blank"}

{% include tip.html content ="You can start a free trial if you don't have Office365 account from [here](https://teams.microsoft.com/start){:target=\"_blank\"}" %}

## Authorize Power BI to access your account data

Your first step requires you to authorize Power BI to access your Team Services account. Choose between one of these two connection scenarios when connecting to Power BI:

**Scenario #1**: You use the same Azure Active Directory (AAD) account to log in to Team Services and Power BI.

**Scenario #2**: You use an MSA (Microsoft account/LiveID) to log in to Team Services or you use different AAD credentials to log into Team Services than you use to log into Power BI.

## Log in to Power BI

1. Go to [Power BI](http://powerbi.com){:target="_blank"} site

   ![1](images/1.png)

1. Click **Sign In** in the upper right corner to log in to Power BI.

   ![2](images/2.png)

1. You can use either AAD or MSA account to log in.

   {% include note.html content= "If you don't have a Power BI account you can create one by entering your email address and click Use it free." %}

## Managing Workspaces

Workspaces in Power BI allows you to have isolated area to monitor your teams work. You can add, remove, edit and grant permissions either to edit or read the contents present in the workspace.

1. Go to **Workspaces** and click on **Create app workspace**.

   ![11](images/11.png)

1. Give a name for the workspace and set the desired permissions. For this lab let's keep it default and create one.

   ![12](images/12.png)

1. A new workspace is created now.

   ![13](images/13.png)

## Connect to services with content packs for Power BI

You can connect to content packs for a number of services you use to run your business, such as Salesforce, Microsoft Dynamics, Visual Studio Team Services and Google Analytics. Power BI starts by using your credentials to connect to the service, and then creates a Power BI dashboard and a set of Power BI reports that automatically show your data and provide visual insights about your business.

1. Click **Get Data** on the left bottom corner to select .

   ![3](images/3.png)

1. You can pull out the data either from one of the sources. Since we are integrating with VSTS, select **Services** and click on **Get**.

   ![4](images/4.png)

1. Browse the content packs, or tap in the search box and type keywords:

   ![29](images/29.png)

1. In the search box, type **Visual Studio** and click on **Get it now**.

   ![5](images/5.png)

1. Enter **YOUR ACCOUNT NAME**, if your Team Services URl is **YOURACCOUNTNAME.visualstudio.com**. Also enter the Project name that you want to track and click on **Next**

   ![6](images/6.png)

1. A window would appear to allow the access to your VSTS account. Click **Sign in**.

   ![8](images/8.png)

1. A window would pop up to allow the permission to read the data from the VSTS account. Click on **Accept**.

   ![9](images/9.png)

1. Now the data is being imported and you will see the notification on the right corner top.

   ![7](images/7.png)

1. Once the data is imported, you will see the dashboard with the data.

   ![10](images/10.png)

## Reports in Power BI

A Power BI report is a multi-perspective view into a dataset, with visualizations that represent different findings and insights from that dataset.  A report can have a single visualization or pages full of visualizations. Depending on your job role, you may be someone who creates reports and/or you may be someone who consumes or uses reports.

1. Click on **Reports** and select **Visual Studio Team Services**. By default when the data is imported, a report would have generated automatically.

   ![14](images/14.png)

1. The report along with the data is shown. Modify the report to show the desired data. To do so, click on **Edit report** on the top.

   ![15](images/15.png)

1. Visualizations and additional data can be added from the filter sets and the visualizations table from the right side.

   ![16](images/16.png)

1. Different reports can be obtained. Agile Status report, Sprint Status report, Git report etc.

   ![17](images/17.png)

   ![18](images/18.png)

   ![19](images/19.png)

1. Add new pages to the report with the desired data. Click on + at the bottom of the report to add new and select the visualizations and data to appear in the page.

   ![20](images/20.png)

## Q&A in Power BI

Sometimes the fastest way to get an answer from your data, is to ask a question using natural language.  For example, **what were total sales last year?**  Use Q&A to explore your data using intuitive, natural language capabilities and receive answers in the form of charts and graphs. Q&A is different from a search engine -- Q&A only provides results about the data in Power BI.

Asking the question is just the beginning. Have fun traveling through your data refining or expanding your question, uncovering trust-worthy new information, zeroing in on details and zooming out for a broader view. You’ll be delighted by the insights and discoveries you make.

The experience is truly interactive…and fast! Powered by an in-memory storage, response is almost instantaneous.

1. From your workspace, go to Dashboard and click on **Ask a question about your data**

   ![21](images/21.png)

1. Place your cursor in the question box. Even before you start typing, Q&A displays a new screen with suggestions to help you form your question.

   ![23](images/23.png)

   This list contains:

    a. The questions used to create tiles that are already pinned to the dashboard, and

    b. The name of tables in the underlying dataset(s).

    You can always choose one of these questions as a starting point and continue to refine the question to find the specific answer you are looking for. Or, use a table name to help you word a new question.

1. Select from the dropdown or begin typing your own question.

   ![24](images/24.png)

1. As you type a question, Power BI Q&A picks the best visualization to display your answer; and the visualization changes dynamically as you modify the question. Q&A also helps you formulate your question with auto-completion, by restating your question, and with other textual and visual aids.

   ![25](images/25.png)

1. When you type a query, Power BI looks for an answer in any dataset that has a tile on that dashboard.  If all the tiles are from datasetA, then your answer will come from datasetA.  If there are tiles from datasetA and datasetB, then Q&A will search for the best answer from those 2 datasets.

   {% include important.html content= "If you only have one tile from datasetA and you remove it from your dashboard, Q&A will no longer have access to datasetA." %}

1. When you're happy with the result, pin the visualization to a dashboard by selecting the pin icon in the top right corner.

   ![26](images/26.png)

1. You can pin this to an **Existing dashboard** or to a **New dashboard**. Select **Existing dashboard.**

   ![27](images/27.png)

1. Go back to dashboard, you should see the pinned item now.

   ![28](images/28.png)