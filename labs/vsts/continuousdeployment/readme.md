---
title: Continuous Deployment using Visual Studio Team Services
layout: page
sidebar: vsts
permalink: /labs/vsts/continuousdeployment/
folder: /labs/vsts/continuousdeployment/
---

Last updated : {{ "now" | date: "%b %d,%Y" }}.

## Overview

<a href="https://www.visualstudio.com/en-us/docs/release/overview/">Release Management</a> is a service in Visual Studio Team Services that helps you automate the deployment and testing of your software in multiple environments. Using Release Management, you can either fully automate the delivery of your software all the way to production, or set up semi-automated processes with approvals and on-demand deployments. It is an essential element of DevOps that helps your team continuously deliver software to your customers at a faster pace and with lower risk.

Release Management can be used by all kinds of software developers for continuous automated deployment, or by large enterprises to improve efficiency and collaboration between various teams that participate in release processes.

To use Release Management, you create release definitions, in which you specify the automation tasks that should be run in each environment. These automation tasks can be to deploy your software and to run tests against it. You can group multiple environments in each definition to model your software lifecycle. You can then set up the deployment in each environment to be automatically triggered upon completion of a build, at scheduled times, or on successful deployment to a previous environment.

## Pre-requisites

In order to complete this lab you will need- 

- **Visual Studio Team Services account**. If you don't have one, you can create from <a href="https://www.visualstudio.com/">here</a>

- **Visual Studio 2017** or higher version

- You can use the **[VSTS Demo Data generator](http://vstsdemogenerator.azurewebsites.net/Environment/Create)** to provison a project with pre-defined data on to your Visual Studio Team Services account. Please use the ***My Health Clinic*** template to follow the hands-on-labs.

- If you are not using the VSTS Demo Data Generator, you can clone the code from here

## Exercise 1: Connect To Microsoft Azure

1.  Sign in to your Visual Studio Team Services account. 

2.	From your account overview page, select your team project. To find your team project, use can search as well.

    <img src="images/1.png" width="624"/> 

3.	Choose the **gear icon** to open the administrative control panel.

    <img src="images/2.png" width="624"/> 

4.	Go to **Services** and click on **New Service Endpoint** to add one.

    <img src="images/3.png" width="624"/> 

5.	From the drop down, select **Azure Resource Manager**.

    <img src="images/4.png" />

6.	Provide a Connection name **MHC-Azure** and select the subscription.

    <img src="images/5.png" />

## Exercise 2: Creating Release Definitions

1. Go to your **Release** tab from your VSTS account.

    <img src="images/7.png" width="624"/>

2. Click on **+** to create a new release definition.

    <img src="images/8.png" />

3. In the Create new release definition dialog, select the **Azure App Service Deployment** template and choose **Next.**

    <img src="images/9.png" />

4. In the next page, select the **build definition** you created earlier and choose **Create.** 

    <img src="images/10.png" />

5. This creates a new release definition with one default environment. Rename the Environment to **Dev**.

    <img src="images/11.png" width="624"/>

6. In the **Azure Subscription**, map the endpoint which we created in **Exercise 1**.

    <img src="images/12.png" width="624"/>

7. If you would have hosted the WebApp on Azure, you will get an App Service which has to be mapped in your release definition. If you haven't published on Azure, you can follow this <a href="https://almvm.azurewebsites.net/labs/vsts/appservice/"/>post</a> to host.

    <img src="images/13.png" width="624"/>

8. Select the **MyHealth.Web.zip** file to deploy.

    <img src="images/14.png" width="624"/>

9. We will replace the database connection string in the **appsettings.json** to point to a database server on Azure.

   <img src="images/48.png" />

10. Go to **Variables** tab and create a variable with the below name and value.

    >Note:  You will need to create a SQL database server on Azure prior to this step. If you have an existing SQL Server on Azure, you can use it, Otherwise follow this <a href="http://bit.ly/2o2IDTy" >blog post</a>for step-by-step intsructions.

    >Name: ConnectionStrings.DefaultConnection

    >Value: Server=tcp:{yourdbserver},1433;Database=myhealthclinic;User ID={dbuserid};Password={dbpassword};Trusted_Connection=False;Encrypt=True;

9. Give a name for the new release definition and Save the release definition.

10. Create a **new release** and select the **latest** build to deploy it to the single environment in the definition.

    <img src="images/15.png" width="624"/>

    <img src="images/16.png" width="624"/>

11. Go to the release definition log to view the process.

    <img src="images/17.png" />

    <img src="images/18.png" />

12. You can go to the Azure Portal and get the existing Web App Service URI.

    <img src="images/19.png" width="624"/>

13. Click on **Private area** to login.
    - Username: User
    - Password: P2ssw0rd@1

    <img src="images/20.png" width="624"/>

    <img src="images/21.png" />

14. Once logged in, you should see this dashboard.

    <img src="images/22.png" width="624"/>

## Exercise 3: Manage Releases

### Task 1: Triggers

1. A Release definition can be configured to automatically create a new release when it detects new artifacts are available.
   Typically as a result of a new build of the application. Click on **Triggers** from your release definition as shown.

   <img src="images/23.png" width="624"/>

   > - **Manual:** No releases are initiated automatically when a new build of the source artifacts occurs. All releases for this release definition must be created manually by choosing the Release icon in a release definition or from a build summary. 

   > - **Continuous Deployment:** A new release is created automatically when Release Management detects new built artifacts are available. When you select this option, a drop-down list enables you to select which of the artifact sources linked to this release definition will trigger a new release.

   > - **Scheduled:** A new release is created based on a schedule you specify. When you select this option, a set of controls enables you to select the days of the week and the time of day that Release Management will automatically create a new release.

   > **NOTE:** However, even though a release is automatically created, it might not be deployed automatically to an environment. To enable automatic deployment, you must also configure environment deployment triggers in each environment for which you want automated deployments to occur. The lower section of the Triggers tab lists the environments configured for this release definition.

2. Click on **Continuous Deployment** to create a new release automatically.

   <img src="images/24.png" width="624"/>

3. Click on the **...** button on the environment and select **Deployment Conditions**.

    > The deployment conditions dialog for the environment shows the currently configured environment deployment triggers and deployment queuing policies. Users with permission to edit release definitions can edit the deployment conditions here, including environment deployment triggers and deployment queuing policies.

   <img src="images/25.png" width="624"/>

### Task 2: Artifacts

An artifact is a deployable component of your application. Team Services has the ability to explicitly manage the content of artifacts during a build. 

1. Click on **Artifacts** tab from your release definition.

   ```
   1. When authoring a release definition, you link the appropriate artifact sources to your release definition. For example, you might link a release definition to a Team Build build definition, or to a Jenkins project.
   2. When creating a release, you specify the exact version of these artifact sources; for example, the number of a build coming from Team Build, or the version of a build coming from a Jenkins project.
   3. After a release is created, you cannot change these versions. A release is fundamentally defined by the versioned artifacts that make up the release. As you deploy the release to various environments, you will be deploying and validating the same artifacts in all environments.
   ```

   <img src="images/26.png" width="624"/>

2. Click **Link an artifact source** and fill the required details.

   >Type: Specify the build artifact that you are referring from.

   >Project: The project that you are interested to deploy.

   >Source(Build Definition): The build definition that you wish to deploy. Select the created build from our Continuous Integration exercise.
   > Default Version: Select the latest.

   ```
   1. A single release definition can be linked to multiple artifact sources. In this case, when you create a release, you specify individual versions for each of these sources.
   2. You can link multiple artifact sources to the same release definition. A common example for this is when you deploy micro services, each one coming from a different build definition. Another example is where you manage the application code in one repository and the configuration files in a different repository.
   ```

   >**NOTE**: At present, Release Management can trigger creation of new releases from only one of the artifact sources. When a new release is created, the latest versions of all the other sources are deployed.

   <img src="images/27.png" width="624"/>


### Task 3: Variables

You can use the default variables, and define custom variables, that enable you to:
    
> - Share values across all of the environments with release definition variables. Choose a release definition variable when you need to use the same value across all the environments and tasks in the release definition, and you want to be able to change the value in a single place.
> - Share values across all of the tasks within one specific environment with environment variables. Use an environment-level variable for values that vary from environment to environment (and are the same for all the tasks in an environment).
> - Run your deployments in debug mode to show additional information that can help you resolve issues and failures.

1. Click on **Variables** tab from your release definition.

   <img src="images/28.png" width="624"/>

2. Using variables at both release definition and environment scope helps you to:

   > - Avoid duplication of values, making it easier to update all occurrences as one operation.
   > - Store sensitive values in a way that they cannot be seen or changed by users of the release definitions.

  
3. Click **Enviroment variables**. You can view and edit the variables defined for individual environments in the release definition in this tab by selecting Environment variables from the list at the right of the toolbar.

   <img src="images/29.png" width="624"/>

4. Go back to your environments and select **...**. Click on **configure variables**.

   <img src="images/30.png" width="624"/>

5. Similar to our build variables, we can also configure release variables and could be used during our deployments. 


### Task 4: Running release in debug mode

You can show additional information as release executes by running the entire release, or just the tasks in an individual release environment, in debug mode. This can help you resolve issues and failures.

1. Go back to **Variables** from your release definition.

2. To initiate debug mode for an entire release, add a variable named System.Debug with the value true.

   <img src="images/31.png" width="624"/>

3. Save the release definition and queue a new release to check the log.


### Task 5: Clone, Export, and Import a release definition

1. Select your release definition from the list of releases that you have.

   <img src="images/32.png" width="624"/>

2. Open the shortcut menu by clicking on **...** and select Clone, Export etc to clone or export the release definition.

   <img src="images/33.png" />

  > **Clone** to create a complete copy of the selected definition with "Copy" appended to the name.

  > **Export** to create a JSON file containing a full representation of the selected release definition that you can save to your local computer.


## Exercise 4: Environments

A release definition is a collection of environments. An environment is a logical entity that represents where you want to deploy a release. Physically, the deployment in an environment may happen to a collection of servers, a cloud, multiple clouds, or an app store. The deployment steps in an environment are described using tasks.

<img src="images/34.png" />  

### Task 1: Adding environments

1. Select your release definition and click edit.

2. Click on **Add enviroment** and choose **Create new environment.**

   <img src="images/35.png" />
  
3. Select **Azure App Service Deployment** template. 

4. Choose Next and select the pre-deployment approval, trigger, and queue settings for the new environment.

   <img src="images/36.png" />

5. You can add as many environments with different tasks for your deployment based on the needs.

### Task 2: Cloning environments

A release definition often contains several environments such as development, testing, QA, and production. Typically, all of these environments are fundamentally similar and the techniques used to set up and deploy to each one are the same with the exception of minor differences in configuration for each environment and task (such as target URLs, service paths, and server names).

1. Select the existing enviroment and choose Clone environment on the shortcut menu that opens from the environment's ellipses (...).

   <img src="images/37.png" />

2. Choose Next and select the pre-deployment approval, trigger, and queue settings for the new environment.

3. Choose Create and then edit the new environment name as required.

   <img src="images/38.png" />

4. After you have created and configured your environments, you could add tasks to them as we saw in the previous steps.

### Task 3: Environment Templates

When you start a new release definition, or when you add an environment to an existing release definition, you can choose from a list of templates for each environment.

These templates pre-populate the environment with the appropriate tasks and settings, which can considerably reduce the time and effort required to create a release definition. Alternatively, you can choose to start with an empty release definition that contains only a single default empty environment, or an empty environment that contains no tasks.

You can also create your own custom environment templates from an environment you have populated and configured.

1. Select the existing enviroment and choose **Save as template** on the ellipses (...).

   <img src="images/39.png" />

2. Enter name, description and choose OK.

   <img src="images/40.png" />

3. The custom templates you create appear in the Custom tab of the Create new release definition dialog.

   <img src="images/41.png" />

### Task 4: Approvals and Approvers

You can define approvers for each environment in a release definition. When a release is created from a release definition that contains approvers, the deployment stops at each point where approval is required until the specified approver grants approval or rejects the release (or re-assigns the approval to another user).

1. Select one of the environment and click on ellipsis (...). Select **Assign Approvers**.

   <img src="images/42.png" />

2. In the Approvals tab of the Configure dialog you specify details for pre-deployment and post-deployment approvers. When the Automatic checkbox is set for an approval step, the deployment is automatically approved.

   <img src="images/43.png" width="624"/>

3. When you select the Specific Users option, you can specify and edit one or more approvers for an approval step. You can type part of the name and choose from the drop-down list of matching user names defined for the project.

   <img src="images/44.png" width="624"/>

4. You can add multiple approvers for both pre-deployment and post-deployment settings. When you add multiple approvers, you can also control how they can approve the deployment.

   <img src="images/45.png" width="624"/>

5. Save the release definition and queue a new release. Go to the release definition log to view the process.

   <img src="images/46.png" width="624"/>

6. Click **Approve or reject**. The release will continue deploying in the desired enviroment.

   <img src="images/47.png" width="624"/>
    

