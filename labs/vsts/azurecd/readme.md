# Generate CI/CD pipeline automatically from Azure Portal

Continuous Delivery is a great option for projects that require multiple and frequent contributions to be integrated.

Continuous Delivery in Team Services simplifies setting up a robust deployment pipeline for your app to publish the most recent updates to Azure App Service. The pipeline can be configured to build, runs tests, and deploy to a staging slot and then to production.

You must store your app's source code in a Team Services Git, GitHub, or any other Git repository to use Azure Continuous Delivery. Team Foundation Version Control (TFVC) repositories are not supported at present.

## Pre requisites

1. Azure Subscription

2. Visual Studio Team Services account. If you don’t have one, you can create from <a href="https://www.visualstudio.com/">here</a>

3. You can use the <a href="https://vstsdemogenerator.azurewebsites.net/">VSTS Demo Data generator</a> to provison a project with pre-defined data on to your Visual Studio Team Services account. Please use the **My Health Clinic** template to follow the hands-on-labs

**Note:** Currently supported/recommended to use the same account for VSTS and Azure to setup the CD pipeline. Else you would end up with exceptions and won't be able to setup. 

## Configure

1. Go to Azure Portal from <a href="https://portal.azure.com">here</a>

2. Select your web app, If you haven't created a web app, do this now by choosing the "+" icon, selecting **Web App** from the **Web + Mobile** category, and providing a name and a resource group.

   <img src="images/1.png">

3. In your app's menu blade, choose **Continuous Delivery (Preview)** and then choose **Configure**

   <img src="images/2.png">

4. Select **Choose repository** and select **Visual Studio Team Services** 

   <img src="images/3.png">

5. Select the **VSTS account, project, repository**, and **branch** where you have your ***My Health Clinic*** project. When you're done, choose OK.

   <img src="images/4.png">

  > In addition to Visual Studio Team Services, you can also select other Git repositories such as GitHub or External Git (a Git  repository not hosted in Team Services or GitHub, For instance, BitBucket). You will have to provide the account, repository and branch details and if it is a private repository, you will need to provide the credentials

6. Select **Configure Continuous Delivery** and choose the web application framework you used to develop your app. Since we are targeting .NET Core, select **ASP.NET Core**.

   <img src="images/5.png">

   This choice influences the way that Azure Continuous Delivery builds and packages the app for deployment. At present, ASP.NET, ASP.NET Core, PHP, Python, and Node.js are supported. When you're done, choose **OK**.

7. You can load test your web application before the changes are deployed to production. You will need to select a web app within the same resource group. If you are specifying for the first time, you can select **Create New** and provide the information to create a new instance. For this exercise, we will skip load test and move to the next step.

8. You can also select to deploy the changes to staging first (for testing purposes) and then promote the changes to production. Select **Configure deployment** and choose **YES**. Select **Create New** option for ***Deployment Slot***  and select **OK**.

   <img src="images/7.png">

1. Choose **OK** to create and execute the Continuous Delivery workflow.

   <img src="images/8.png">

  >The workflow will create a build and a release definition in the Team Services account together with a service endpoint to connect to Azure. A new slot for staging is created for the web app. Once the setup has completed successfully, a build is triggered that builds and packages the application for deployment and when the build has completed successfully, a new release is created and the deployment triggered
  
2. You can see the status of the steps from the the Activity Log.

   <img src="images/9.png">

3. In the **Successfully set up Continuous Delivery...** item, choose the Build Definition link to open the project containing your app in Team Services, and see the summary for the build definition. 

   <img src="images/12.png">

   <img src="images/11.png">

4. Choose **Edit** to see the tasks that have been added and configured.

   <img src="images/13.png">

   Different tasks are added to the build definition depending on the app framework you selected. For example, .NET Core task is used for ASP.NET Core apps.

5. In the **Successfully set up Continuous Delivery...** item, choose the Release Definition link to open the project containing your app in Team Services, and see the list of releases for this definition. Choose **Edit** to see the tasks that have been added and configured.

   <img src="images/14.png">

6. The release definition that is created depends on whether you chose to include a load test and/or a staging deployment. If you chose either or both, your release definition will have two environments named **Test** and **Production**. As shown below, the **Test** environment has two tasks: **Azure App Service Deploy** deploys the app to the Azure App Service you selected for load testing, and **Cloud-based Web Performance** task execute the load test.

   <img src="images/15.png">

7. The **Production** environment, shown below, has an **Azure App Service Deploy** task. If you chose to use a staging deployment, the latest changes are deployed to the staging slot and then an **Azure App Service Manage** task performs a slot swap between staging and production slots.

   <img src="images/16.png">

   If you opted out of both load test and a staging deployment, your release definition will have a single environment with just one Azure App Service Deploy task to deploy the latest changes to your Azure App Service.

   There are also links in other items in the Activity Log that open commits, builds, build reports, releases, deployment slots, and the deployed app itself, in relevant windows or apps.

8. Click on **Release summary** to ensure the deployment was successful. 

   <img src="images/18.png">

9. Browse to the web app post deployment. You will notice that the app is running, but is missing out all the stylings, images etc. You should see something like this as shown below.

   <img src="images/19.png">

   This is because during the compilation couple of **js dependencies** are missed out which we will be adding to the build definition in our next task.

## Customizing the CD pipeline

1. Go to your build definition from your VSTS account that was created and edit.

   <img src="images/20.png">

2. Click on **Add Task** and search for **npm install** from the search box.

   <img src="images/21.png">

3. Place the task after .NET restore step. Set the **Working folder** to **src/MyHealth.Web** and retain the rest as it is.

   <img src="images/22.png">

4. Click on **Add task** and search for **bower** task from the search box.

   <img src="images/23.png">

5. Place the task after npm step. Set the **Bower JSON Path** to **src/MyHealth.Web/bower.json**

   <img src="images/24.png">

6. Click on **Add task** and search for **gulp** task from the search box.

   <img src="images/25.png">

7. Place the task after bower step. Set the **Gulp File path** to **src/MyHealth.Web/gulpfile.js**

   <img src="images/26.png">

8. Click **save** and Queue the build. 

9. Once the build is completed successfully, we see the pipeline triggered automatically.

10. You can verify this by going to the release hub and check if the deployment is successfully completed. You can refresh the web page and you should see the web page with all the images, stylings etc as shown below.

    <img src="images/27.png">

> You can stop a deployment to your Azure App Service by choosing **Disconnect** at the top of the **Continuous Deployment** blade. This deletes the Azure Continuous Delivery configuration in the Azure portal and turns off the build triggers in your Team Services account for this configuration.

<img src="images/17.png">

To ensure the build and release history is preserved, the build and release definitions are not deleted from Team Services when you disconnect.













 
   

