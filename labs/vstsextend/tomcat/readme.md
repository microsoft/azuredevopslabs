---
title: Deploying a MySQL database backed Java app to Tomcat on Azure with Azure DevOps
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/tomcat/
folder: /labs/vstsextend/tomcat/
---

Last updated : {{ "now" | date: "%b %d,%Y" }}

## Overview

In this lab, you will learn how you can use Release Management(RM) in Azure DevOps to deploy a Java web application to [Apache Tomcat](http://tomcat.apache.org/){:target="_blank"} with a MySQL database on Azure. Apache Tomcat is an open-source Java Servlet Container developed by the Apache Software Foundation (ASF). MySQL is a popular open-source relational database management system.

For this purpose of the lab, we will use Azure App Service and Azure Database for MySQL, a relational database service based on the open source MySQL Server engine. It is a fully managed database as a service offering capable of handing mission-critical workload with predictable performance and dynamic scalability.

{% include note.html content= "This article deploys a Java app to App Service on Windows. To deploy a **Net Core App** container to Azure, please see  [deploying Docker .NET Core container to Azure App Service](../docker){:target=\"_blank\"}. To deploy a Dockerized Java application, see [Deploying a Dockerized Java App to Azure Web App for Containers](../dockerjava/){:target=\"_blank\"}" %}

### What's covered in this lab

This lab will show how you can

- Create a new Azure App Service and configure it to use Apache Tomcat
- Create a new MySQL database
- Use Azure App Service Task to deploy a WAR file

### Prerequisites for the lab

Refer the [Getting Started](../readme) before you start the exercises.

## Exercise 1: Setting up VSTS team project

1. Use  **MyShuttle** as the template to provision the new Azure DevOps project using the [Azure DevOps Demo Generator](https://azuredevopsdemogenerator.azurewebsites.net/Environment/Create?TemplateId=77373&TemplateName=MyShuttle){:target="_blank"}.

## Exercise 2: Creating Azure Web App and MySQL database

1. We will use the **Web App + MySQL** Azure template from the Azure Marketplace to create a Website and MySQL Database together to start developing even faster.

    [![Tomcat Configuration](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.WebSiteMySQLDatabase){:target="_blank"}

1. This template provides two MySQL options :

    - **Azure Database for MySQL** provides a managed database service for app development. ***We will choose this option.***
    - **MySQL In app** is an App Service feature where MySQL database is created for your web app. In this scenario, MySQL server is running on the same instance side by side with your web server hosting the site. This is recommended to development purposes and has no additional cost.

    ![Create Web App+MySQL](images/createwebappmysql.png)

1. Wait for the Web App and the database to be provisioned. It roughly takes 3-5 minutes.

## Exercise 3: Configuring MySQL database

1. Navigate to the resource group that you have created. You should see a **Azure Database for MySQL server** provisioned. Select the database server.

   ![Resource Group](images/resourcegroup.png)

1. Select **Properties**. Note down **SERVER NAME** and **SERVER ADMIN LOGIN NAME**.

    ![Database properties](images/dbproperties.png)

    In this example, the server name is **myshuttle-1-mysqldbserver.mysql.database.azure.com** and the admin user name is **mysqldbuser@myshuttle-1-mysqldbserver**.

1. We will use the MySQL command-line tool to establish a connection to the Azure Database for MySQL server. We will run the MySQL command-line tool from the Azure Cloud Shell in the browser. To launch the Azure Cloud Shell, click the `>_` icon in the top right toolbar.

   ![Launch Azure Cloudshell](images/azurecloudshell.png)

1. Enter the following command

    ```HTML
    wget https://raw.githubusercontent.com/hsachinraj/azure-arm-templates/master/vstsazurejl_arm/mydbscript.script
    ```
    This should download the file that we want to execute on the server.

1. Next, we will execute the SQL from the downloaded file on the database server. Enter the following command

    ````SQL
    mysql -h myshuttle-1-mysqldbserver.mysql.database.azure.com -u mysqldbuser@myshuttle-1-mysqldbserver -p < mydbscript.script
    ````
    Enter the password that you specified during provisioning the database

    ![Creating DB](images/createdatabase.png)

    {% include note.html content= "This should create the database, tables and populate records for us." %}

## Exercise 4: Updating the App Settings for the Web App

Next, navigate to the Web app that you have created. As we are deploying a Java application, we need to change the web app's web container to Apache Tomcat.

1. Click **Application Settings**. To change it to Tomcat, we will first need to install Java. Select a **Java Version** to install and then change **Web container** to use Apache Tomcat. For this purpose of the lab, we will choose ***Java 8*** and ***Apache Tomcat 9.0*** though the version number would not matter much for the simple app that we are deploying.

    ![Setting Web container to Tomcat](images/webcontainer.png)

1. Click **Save** and wait for the update to be applied. Then navigate to the web app URL again and now you should see a different page.

    ![Default Java App](images/defaultappjava.png)

    Next, we need to update the connection strings for the web app to connect to the database correctly. There are multiple ways you can do this - but for the purpose of this lab, we will take a simple approach. We will update it directly on the Azure portal.

1. From the Azure portal, select the Web app you provisioned. Select **Application Settings** and scroll down to the **Connection Strings** section.

1. Add a new MySQL connection string with **MyShuttleDb** as the name, paste following string for the value and replace **MySQL Server Name**, **your user name** and **your password** with the appropriate values -

   `jdbc:mysql://{MySQL Server Name}:3306/alm?useSSL=true&requireSSL=false&autoReconnect=true&user={your user name}&password={your password}`

1. Click **Save** to save the connection string.

    {% include note.html content= "Connection Strings configured here will be available as environment variables, prefixed with connection type for Java apps (also for PHP, Python and Node apps). In the **DataAccess.java** file under **src/main/java/com/microsoft/example** folder, we retrieve the connection string using the following code" %}

    ````Java
    String conStr = System.getenv("MYSQLCONNSTR_MyShuttleDb");
    ````

You have now setup and configured all the resources that is needed to deploy and run the MyShuttle application.

## Exercise 5: Deploying to App Service from Azure DevOps

1. Navigate to the Azure DevOps project that you provisioned.

1. Select **Pipelines** and then **Releases**.

1. Select **MyShuttle Release** and click **Edit** to open the release definition.

   ![Edit MyShuttle Release Definition ](images/editrelease.png)

1. If you following this lab from Jenkins hands-on-lab, make sure the artifact is pointing to Jenkins. Otherwise, it should be pointing to the **Team Build** artifact as shown below:

   ![Team Build Artifact](images/addartifacts.png)

1. Select the **Deploy Azure App Service**, select the Azure subscription from the drop down, click **Authorize** and ensure that the app service name is reflected correctly.

   {% include note.html content= "We are using the **Deploy Azure App Service** task. This task is used to update Azure App Service to deploy Web Apps and WebJobs to Azure.  The task works on cross platform agents running Windows, Linux or Mac and uses the underlying deployment technologies of Web Deploy and Kudu. The task works for ASP.NET, ASP.NET Core 1 and Node.js based web applications. Note that this task works with  Azure Resource Manager APIs only." %}

1. Click **Save** and then **+Release \| Create Release** to start a new release

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