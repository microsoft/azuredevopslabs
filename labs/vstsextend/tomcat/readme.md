---
title: Deploying a MySQL database backed Java app to Tomcat on Azure with Azure DevOps
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/tomcat/
folder: /labs/vstsextend/tomcat/
---

## Overview

In this lab, you will learn how you can use Azure Pipelines to deploy a Java web application to [Apache Tomcat](http://tomcat.apache.org/){:target="_blank"} with a MySQL database on Azure. Apache Tomcat is an open-source Java Servlet Container developed by the Apache Software Foundation (ASF). MySQL is a very popular open-source relational database management system.

For this lab, you will use Azure App Service and Azure Database for MySQL, a relational database service based on the open source MySQL Server engine. It is a fully managed database as a service,  capable of handing mission-critical workload with predictable performance and dynamic scalability.

### What's covered in this lab

This lab will show how you will

- Create a new Azure App Service with a MYSQL database server and configure the web app to use Apache Tomcat
- Use Azure App Service Task to deploy a WAR file

### Before you begin

1. Refer the [Getting Started](../Setup/) page before you follow the exercises.

1. Use  **MyShuttle** as a template to provision the new Azure DevOps project using the [Azure DevOps Demo Generator](https://azuredevopsdemogenerator.azurewebsites.net/?TemplateId=77371&Name=MyShuttle){:target="_blank"}.

## Exercise 1: Creating Azure Web App and MySQL database

1. Click the below button to provision a Website and MySQL Database together to start developing even faster.

    [![Tomcat Configuration](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.WebSiteMySQLDatabase){:target="_blank"}

1. This template provides two MySQL options :

    - **Azure Database for MySQL** provides a managed database service for app development. ***You will choose this option.***
    - **MySQL In app** is an App Service feature where MySQL database is created for your web app. In this scenario, MySQL server is running on the same instance side by side with your web server hosting the site. This is recommended for development purposes and has no additional cost.

    ![Create Web App+MySQL](images/createwebappmysql.png)

1. Wait for the Web App and the database to be provisioned. It roughly takes 3-5 minutes.

1. Navigate to the resource group that you have created. You should see a **Azure Database for MySQL server** provisioned. Select the database server.

   ![Resource Group](images/resourcegroup.png)

1. Select **Properties**. Save the **SERVER NAME** and **SERVER ADMIN LOGIN NAME** to a notepad.

    ![Database properties](images/dbproperties.png)

    In this example, the server name is **myshuttle-1-mysqldbserver.mysql.database.azure.com** and the admin user name is **mysqldbuser@myshuttle-1-mysqldbserver**.

## Exercise 2: Updating the App Settings for the Web App

Next, navigate to the Web app that you have created. As you are deploying a Java application, you need to change the web app's web container to Apache Tomcat.

1. Click **Application Settings**. To change it to Tomcat, you will first need to install Java. Select a **Java Version** to install and then change **Web container** to use Apache Tomcat. For this purpose of the lab, you will choose ***Java 8*** and ***Apache Tomcat 9.0*** though the version number would not matter much for the simple app that we are deploying.

    ![Setting Web container to Tomcat](images/webcontainer.png)

1. Click on **Save** and wait for the update to be applied. The web page will now look like the below image.

    ![Default Java App](images/defaultappjava.png)

    Next, you need to update the connection strings for the web app to connect to the database correctly. There are multiple ways you can do this - but for the purpose of this lab, you will take a simple approach by updating it directly on the Azure portal.

1. From the Azure portal, select the Web app you provisioned. Select **Application Settings** and scroll down to the **Connection Strings** section.

1. Add a new **MySQL** connection string with **MyShuttleDb** as the name, paste the following string for the value and replace **MySQL Server Name**, **your user name** and **your password** with the appropriate values -

   > `jdbc:mysql://{MySQL Server Name}:3306/alm?useSSL=true&requireSSL=false&autoReconnect=true&user={your user name}&password={your password}`

   ![DB Connection](images/dbconnstrings.png)

    - MySQL Server Name : Value that you copied previously from the MySQL server Properties.
    - your user name : Value that you copied previously from the MySQL server Properties.
    - your password : Value that you provided during the creation of MYSQL database server in the *Deploy to Azure* phase.

1. Click on **Save** to save the connection string.

    > {% include note.html content= "Connection Strings configured here will be available as environment variables, prefixed with connection type for Java apps (also for PHP, Python and Node apps). In the **DataAccess.java** file under **src/main/java/com/microsoft/example** folder, we retrieve the connection string using the following code" %}

    ````Java
    String conStr = System.getenv("MYSQLCONNSTR_MyShuttleDb");
    ````

You have now setup and configured all the resources that is needed to deploy and run the MyShuttle application.

## Exercise 3: Deploy the changes to Web App

1. Select **Pipelines** and then, **Builds**. Choose the build **MyShuttleBuild** and click **Edit Pipeline** to view the build definition.

    ![Builds](images/choosebuilddefn.png)
    
   > The lab uses the standard **Maven** build template to compile the code, copy and publish the resulting artifacts for deployment. An additional file which is copied here is the *CreateMYSQLDB.sql* file which creates a MYSQL database and inserts a few records into it during the deployment.

1. Click **Queue** to queue the build and wait for the build to complete.

    ![Queue Build](images/queuebuild.png)
    ![Queue Build 2](images/clickqueue.png)

1. Once the build succeeds, Select **Releases** under **Pipelines**.

1. Select **MyShuttle Release** and click **Edit Pipeline** to open the release definition.

   ![Edit MyShuttle Release Definition ](images/editrelease.png)

1. Make sure the artifact is pointing to the **Build** artifact as shown below. If you are following this lab from Jenkins hands-on-lab, make sure the artifact is pointing to Jenkins.

   ![Team Build Artifact](images/addartifacts.png)
   
1. Click **Tasks**, select **Azure-Dev** and choose the **Azure subscription** details from the drop down. Click **Authorize** and login to your Azure subscription in the pop-up window. Provide or choose the created **App Service Name** with the web app that you created previously in this lab.

   ![Link Parameters](images/parameters.png)


1. Click **Tasks** and select **Execute Azure MySQL : SqlTaskFile** task and provide the following details. 

    * Azure Subscription Details : Select the appropriate subscription.
    * Host Name : Select the **MySQL Database server** host name that was created.
    * Server Admin Login : Provide the **SERVER ADMIN LOGIN NAME** that you noted down previously.
    * Password : Provide the password that you created during the creation of *Azure Web App + MYSQL* database server in the Azure portal.

   ![Execute Azure MySQL Task](images/azuremysqltask.png)

1. Select the **Deploy Azure App Service** task and ensure that the created **App service name** is reflected correctly.

   {% include note.html content= "We are using the **Deploy Azure App Service** task. This task is used to update Azure App Service to deploy Web Apps and WebJobs to Azure.  The task works on cross platform agents running Windows, Linux or Mac and uses the underlying deployment technologies of Web Deploy and Kudu. The task works for ASP.NET, ASP.NET Core 1 and Node.js based web applications. Note that this task works with  Azure Resource Manager APIs only." %}


1. Click on **Save** and then **+Release \| Create Release** to start a new release

   ![MyShuttle Release Definition](images/createrelease.png)

1. Wait for the release to complete. Then navigate to the Web App and select the **URL** from the overview blade. Add **/myshuttledev** context to the URL. For instance -  [http://myshuttle1.azurewebsites.net/myshuttledev](http://myshuttle1.azurewebsites.net/myshuttledev){:target="_blank"}

1. Select **Login** and try logging in to the site with any one of the following credentials.

   |Username|Password|
   |--|--|
   |barney|barneypassword|
   |fred|fredpassword|

1. If your database was setup correctly and the connection parameters are valid, you should be able to login to the portal.

    {% include warning.html content="If you encounter an error with ***The specified CGI application encountered an error and the server terminated the process*** message, check whether you have entered the app settings variables and values (for the database connection) correctly" %}

    ![MyShuttle page after login](images/myshuttle-afterlogin.png)

## Summary

In this lab, you have learnt how to deploy a Tomcat based Java application with MySQL database on Azure with Azure Pipelines.
