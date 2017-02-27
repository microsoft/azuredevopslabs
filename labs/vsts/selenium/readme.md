---
title: UI Automation using Selenium Tests
layout: page
sidebar: vsts
permalink: /labs/vsts/selenium/
folder: /labs/vsts/selenium/
---

## Overview

Performing user interface testing as part of the build process is a great way of detecting unexpected changes and need not be difficult. This lab describes using Selenium to test your website in a continuous integration build.

### Task 1: Create the test project

As there is no template for Selenium testing, the easiest way to get started is to use the Unit Test template. This automatically adds the test framework references and enables you run and view the results from Visual Studio Test Explorer.

1. Open the File menu and choose New Project, then choose Test and select Unit Test. Alternatively, open the shortcut menu for the solution and choose Add then New. Choose Project and then Unit Test.

    > Save the new project and solution in your repository directory.

    <img src="./images/1.png" width="624"/>

2. After the project is created, you must add the Selenium and browser driver references used by the browser to execute the tests. 

3. Open the shortcut menu for the Unit Test project and choose Manage NuGet Packages. Add the following packages to your project:

    - Selenium.webdriver (for Firefox)
    - Selenium.webdriver.iedriver
    - Selenium.webdriver.Chromedriver
    - Selenium.webdriver.phantomJS.Xplatform

4. The Unit Test project creates a default class named UnitTest1.cs. To author a Selenium Test, replace the contents of the file with the following code.

        ````
        namespace HealthClinicSelenium
        {
            using System;
            using Microsoft.VisualStudio.TestTools.UnitTesting;
            using OpenQA.Selenium.Remote;
            using OpenQA.Selenium.Chrome;
            using OpenQA.Selenium.Firefox;
            using OpenQA.Selenium.PhantomJS;

            [TestClass]
            public class UnitTest1
            {
                private string baseURL = "http://{your_webapp}.azurewebsites.net/";
                private RemoteWebDriver driver;
                private string browser = string.Empty;
                public TestContext TestContext { get; set; }

                [TestMethod]
                [TestCategory("Selenium")]
                [Priority(1)]
                [Owner("FireFox")]
                public void TestMethod1()
                {
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                    driver.Navigate().GoToUrl(this.baseURL);

                    //do other Selenium things here!
                }

                [TestCleanup()]
                public void MyTestCleanup()
                {
                    driver.Quit();
                }

                [TestInitialize()]
                public void MyTestInitialize()
                {   
                    //Set the browswer from a build
                    browser = this.TestContext.Properties["browser"] != null ? this.TestContext.Properties["browser"].ToString() : "chrome";
                    switch (browser)
                    {
                        case "firefox":
                            driver = new FirefoxDriver();
                            break;
                        case "chrome":
                            driver = new ChromeDriver();
                            break;
                        case "ie":
                            driver = new InternetExplorerDriver();
                            break;
                        case "PhantomJS":
                            driver = new PhantomJSDriver();
                            break;
                        default:
                            driver = new PhantomJSDriver();
                            break;
                    }
                    if (this.TestContext.Properties["Url"] != null) //Set URL from a build
                    {
                        this.baseURL = this.TestContext.Properties["Url"].ToString();
                    }
                    else
                    {
                        this.baseURL = "http://{your_webapp}.azurewebsites.net/"; //default URL just to get started with
                    }
                }
            }
        }
    
    ````

5. Switch to the Azure Portal.

6. Go to your Azure Resource Group to get the URI of the Web App Service.

    <img src="./images/2.png"/>

7. Update the **baseURL** variable with the URI.

    > http://{your_webapp}.azurewebsites.net/

8. Download the phantomJS driver from <a href="http://phantomjs.org/download.html/">here</a>

9. Unblock the zip and extract the content. Include the phantomjs.exe file in the unittest project.

    <img src="./images/3.png"/>  

10. Run the Selenium test locally using Test Explorer.

    <img src="./images/4.png"/> 

### Task 2: Include the test in a Continuous Integration build

1. To include the Selenium test as part of a build, the source code must be in version control.

    <img src="./images/5.png"/> 

2.  Sign in to your Visual Studio Team Services account 

    > https://{youraccount}.visualstudio.com 

3. Select Build & Release > Explorer.

    <img src="./images/6.png"/>

4. Edit your build definition and add a Nuget, Visual Studio build and a Visual Studio Test task.

    <img src="./images/7.png" width="624"/>

5. From the **Visual Studio Test** task set the **URL, Browser and Test Category** parameters.

    - Test Assembly: Update the wildcards to be sure that the task will find your test assembly.
    - Override TestRun Parameters:  URL=http://{your_webapp}.azurewebsites.net/;Browser=PhantomJS

    > **NOTE:** The URL and Browser are passed in as Test Run Parameters.  If you look at the Unit Test class above you will see these parameters are used if they exist.

   <img src="./images/8.png"/>

6. Save the build definition and queue a new build. Notice that you can set the URL and Browser Properties in the Queue build dialog, because the code you used for the UnitTest1.cs class set the Allow at Queue Time variable.

    > **NOTE:** While you could run the Tests using the PhantomJS driver on the hosted build agent the other drivers will require to be run interactively –therefore will fail on the hosted build agent. The best solution is probably running your build agent or using Selenium Grid to remote those calls. 

    > The setting for the build controller is in the General tab of the build definition. For information about running your own build agent, see [Deploy a Windows build agent](https://www.visualstudio.com/en-us/docs/build/admin/agents/v2-windows)

7. To validate the test results from a build, open the build summary from the Explorer tab.

    <img src="./images/9.png" width="624"/>

    > The build summary includes a snapshot of the test results. There is also a Tests results page that highlights the build-on-build changes, including errors, stack traces, and the ability to easily create a bug that contains this information.

    <img src="./images/10.png" width="624"/>



