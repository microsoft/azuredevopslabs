#Web Application Load and Performance Testing

##Overview

In this lab, you will be introduced to the **[Web performance and Load testing capabilities](https://www.visualstudio.com/en-us/docs/test/performance-testing/getting-started/getting-started-with-performance-testing)** provided in **Visual Studio Enterprise 2017**.
You will walk through a scenario using a fictional online storefront where your goal is to model and analyze its performance with a
number of simultaneous users. This will involve the definition of web performance tests that represent users browsing and ordering products,
the definition of a load test based on the web performance tests, and finally the analysis of the load test results.

![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image1.png?raw=true)

##Pre-requisites

- Visual Studio 2017 (download [here](https://www.visualstudio.com/vs/visual-studio-2017-rc/))

- Download the Parts Unlimited project [here](https://github.com/Microsoft/PartsUnlimited/tree/aspnet45)


##Demo 1: Creating Web Performance Tests

1. Download and extract the zip file.

2. Open the solution in **Visual Studio 2017**.

3. Right click on the **Parts Unlimited** solution and click **Add New Project** and select **Web Performance and Load Test Project template from Visual C# | Test**. Name the project and click **OK**.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image2.png?raw=true)
 
 
 
##Demo 2: Recording Web Tests

1. The new web and load test project is created with default test settings and a single web test definition file named **WebTest1.webtest**. Click the **Add Recording button** at the top of the Web Performance Test Editor to start recording as shown below

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image3.png?raw=true)
 
2. **Internet Explorer** and the **Web Test Recorder** now opens in **Record mode**. You can verify by looking at the toolbar at the top of the recorder window. You can also pause, stop, or reset the recording at any time.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image4.png?raw=true)
 
 ````
 **Note**- While the Web Test Recorder is in the Record state, requests will be recorded completely with "think time".
 Keep this in mind, as you record scenarios, as you think the average user would pause on product pages, wait a few seconds to
 make sure your credit card is correct, and so on. We are not just creating the web test to ensure requests and responses are correct,
 we will also use it to do some load testing later on.
 ````

3. In the next few steps, let's play a role of **customer** by browsing few products and drilling into the product details. The goal here is to create a profile that represents the typical browsing scenario for the site for a single user.

4. From your **Internet Explorer**, type [http://partsunlimiteddev.azurewebsites.net](http://partsunlimiteddev.azurewebsites.net) to launch the **Parts Unlimited website**. Note that the requests are logged in the **test recorder** as shown below-

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image5.png?raw=true)

 ###Note- If your application is hosted locally, you can access the local site or else you can use the azure hosted website http://partsunlimiteddev.azurewebsites.net
 
5. Once you complete browsing the products, click **stop** in your Test recorder. The web test detects all the **dynamic parameters** and runs your test producing a **pass/fail** result.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image6.png?raw=true)
 
 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image7.png?raw=true)
 
 
##Demo 3: Working with Web Tests in Visual Studio

1. Once the Web Test Recorder stops recording and returns to Visual Studio, 2 tasks will commence.
 - **Dynamic Parameters**- that could not be identified and extracted during the recording will be identified. Examples of dynamic parameters include cookie values, ASP.NET view state, query string parameters, and post parameters. Extracting dynamic parameters when they are first used will allow the test to be run at any time in the future and therefore we will be able to utilize them as part of a load test.
 
 - **The recorded web performance test will run and display results.**

2. Take a moment to view the recorded web requests and see that query string parameters were automatically extracted. Visual Studio will also look and extract **hidden HTML fields** and **form post parameters** as shown below-

  ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image8.png?raw=true)
 
 **Note**- There are 2 types of rules that can be applied to the response for each HTTP request, **validation** and **extraction**.

  - **Validation rules**- can be used to verify that pages have specific text, tags, attributes, or form fields on them.
 
  - **Extraction rules**- can be used to store results in the test context as name value pairs. These rules can extract form fields, text, attributes, headers, regular expressions, and hidden fields.
 
3. In Solution Explorer, right-click on the **WebTest1.webtest** and select rename to change the name to **“Browsing.webtest”**. This will make it easier to keep track of the scenarios that we record.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image9.png?raw=true)
 
4. Let’s take a look at the recorded think times to make sure they are appropriate. Click the **Set Request Details** button from the toolbar to open the Request Details window.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image10.png?raw=true)
 
5. The **Request Details** window shows a grid containing all requests along with a reporting name, think time (in seconds), and response time goals (in seconds). For the purpose of this lab, make sure that the sum of all think times is no more than about **15 seconds**. This will help us ensure that we can get good results when we create a load test later on. Click **OK** to continue if you made any changes.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image11.png?raw=true)
 
###Demo 4: Recording an Additional Web Test Scenario

1. Now let’s add in another web test to represent a customer that browses and purchases a product from the Parts Unlimited website. Select **Project | Add Web Performance Test** from the main menu in Visual Studio. We could have created a single web test that included both the browsing and buying scenario, but composing the tests in this fashion will make constructing a realistic load test easier later on.

2. Navigate to the **Parts Unlimited** Website and **login**.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image12.png?raw=true)
 
3. You can register as a **new user** or you can use the default **Login Credentials**.
 
 - **Login credentials**: Username- **Administrator@test.com**, Password- **YouShouldChangeThisPassword1!**
 
 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image13.png?raw=true)
 
4. Once logged in, click on **Brakes** as shown below.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image14.png?raw=true)
 
5. Select **Brake Rotor**.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image15.png?raw=true)
 
6. Click **Add to Cart**.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image16.png?raw=true)
 
7. Click **Checkout**.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image17.png?raw=true)
 
8. Fill out the order form with some test data and click on **Submit Order**.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image18.png?raw=true)
 
9. Once Checkout is complete, you can click on **view your order** to review your order details.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image19.png?raw=true)
 
 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image20.png?raw=true)
 
10. Click **Stop** button in Web Test Recorder to return to Visual Studio.

11. From your **Solution Explorer**, right click on **WebTest1.webtest** and rename it to **Buying.webtest**.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image21.png?raw=true)
 

###Demo 5: Viewing Web Test Result details

1. Load the **Test Results** window and note that the test run that was automatically kicked off ended up failing. Double-click the test run to view the test result details.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image22.png?raw=true)
 
2. The **Test Result** Details window shows the sequential list of HTTP requests, responses, some Visual Studio test context, and other details. Take a few minutes to familiarize yourself with the information available here.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image23.png?raw=true)
 
3. Scroll down to the request that shows where the web performance test failed and select it. Note that the returned status code is a 200 and the Request and Response tabs look fine.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image24.png?raw=true)
 
4. Response to **Details** and **Login** shows failure even though we have **HTTP 200**.

5. If you click on the **Details** tab, you will see that the test failed because a **Response URL Validation** rule was expecting to see the same response URL that was recorded during the Web Test definition.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image25.png?raw=true)
 
6. Now that we understand why the web test failed, we can modify  the web test, so that it will succeed and still give us a good test representing a user browsing and ordering a product. Scroll down to the failed tests, **right click** and **go to web test** and delete the failed tests.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image26.png?raw=true)
 
 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image27.png?raw=true)
 
7. You can see that the web test is passing after the modification as seen below-

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image28.png?raw=true)
 
8. Let's take a look at the recorded think times to make sure they are appropriate. Click the **Set Request** Details button from the toolbar to open the Request Details window.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image29.png?raw=true)
 
9. Make sure that the sum of all think times are not more than about **30 seconds**. This will help ensure that we can get good results when we create a load test later on. Click **OK** to continue if you made any changes.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image30.png?raw=true)
 
###Demo 6: Adding Load Test

In this exercise, we will use the web performance tests that we created in the previous exercise as the basis of a load test. Building one or more web performance tests that accurately reflect a user scenario is critical to the foundation of a useful load test. To create a load test we will define user load, specify the web performance tests to use, the type of network and browser simulation to use, and the performance counters and other metrics that we want to collect for the duration of the test.

1. Select **Project | Add Load Test** from the main menu in Visual Studio.

2. In the New Load Test Wizard, select **On-premise Load Test** and click **Next** to start defining the load test scenario.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image31.png?raw=true)
 
3. The Run Settings for a load test allow you to specify how long the test should run using either time duration or a specific number of test iterations. We will use a time duration, but change it to **1 minute** for demo purpose. The default sampling rate of **15 seconds** is fine here, and it is a good choice in general for shorter test runs. If you want to run longer tests, consider sampling less often as it will generate a lot less data to store in the load test database. Click **Next** to continue.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image32.png?raw=true)
 
4. Enter a name for the scenario like **“BrowseAndOrderProduct”** but leave the default think time profile in place. The default uses the think times of the web performance tests as a median value with a normal distribution used to generate some variation. The goal is a more realistic generation of load on the web site. Click the **Next** button to continue on to the Load Pattern definition screen.
 
 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image33.png?raw=true)
 
5. Use the **Constant load** option (the default) for this load test, but change the User Count to **5 users** since we are operating within a virtual machine. It is important to keep the simulated user count low enough such that the machine has enough resources to properly run IIS and the load test on the same machine. Depending upon the web site under test, using a step load to ramp up usage of the web site may be more realistic, but it also requires longer test runs. Click **Next** to continue on to the Test Mix Model definition screen.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image34.png?raw=true)
 
 **Note:** The limit on the number of virtual users that you can use in your load tests was removed in Visual Studio Ultimate 2012 (and above). You no longer have to purchase virtual user licenses to increase the number of virtual users that you can use in your load tests. The Visual Studio Ultimate Trial license, however, does limit you to 25 virtual users and only allows local tests.

6. Read the description of each test mix model by clicking on it and viewing the description that appears on the right-hand side. Let’s say that our current production site gives us some indication of the percentage of browsing users that end up making purchases. Select the first option that models the test mix based on the total number of tests and then click **Next** to continue on to the Test Mix screen.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image35.png?raw=true)
 
7. Click **Add** to load the Add Tests window.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image36.png?raw=true)
 
8. **Select** both tests, add them to the test mix, and then click OK.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image37.png?raw=true)
 
 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image38.png?raw=true)

 **Note:** Load tests can include a mix of coded UI tests, web performance tests, and even other test types such as unit tests. It is important to note that for Coded UI tests, you need one virtual or physical machine per user that you are simulating since it assumes that it has control over the entire user interface.
 
 
9. Let’s say that our production logs tell us that **25% of users** browsing the site will end up buying something. Change the Distribution to reflect this knowledge and then click **Next** to continue on to the Network Mix screen.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image39.png?raw=true)
 
10. The Network Mix screen allows you to choose one or more network types and specify the distribution of those types across the tests to be executed by the virtual users. Select the **Network Type** dropdown to see the available options.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image40.png?raw=true)
 
11. Leave the default Network Type of **LAN** in place and click **Next** to continue on to the Browser Mix screen.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image41.png?raw=true)
 
 **Note:** Network emulation will not work when operating within the virtual machine environment because the URL under test loops back to localhost

12. The **Browser Mix** screen allows you to specify one or more browser types and specify the distribution of those types across the tests to be executed by the virtual users. Just like the network mix, this allows us to more realistically model how the users interact with the web site. For the purpose of this exercise leave the default at **100% Internet Explorer 9.0** and click Next to continue on to the Counter Sets screen.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image42.png?raw=true)
 
13. The **Counter Sets** screen allows you to specify the computers and counter sets to gather performance counters during the load test. Click the **Add Computer** button and type the computer name.

14. Select the **ASP.NET** and **SQL** counter sets to monitor since we are load testing a website. Note that **Controller Computer** and **Agent Computers** collect some data by default, and that both of these represent the same machine in this case. Once the counter sets have been set click **Finish** to save the configuration.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image43.png?raw=true)
 
 **Note**: It is possible to modify or add counter sets to be used during load tests by working directly with the **.CounterSet XML files** located in the **%programfiles(x86)%\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\Templates\LoadTest\CounterSets** directory. The LoadTest directory also contains **Network and Browser** definitions.
 
15. Let’s take a quick look at the **test settings** file. In Solution Explorer, **double-click** on the **Local.testsettings** file.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image44.png?raw=true)
 
16. Note that you could perform test runs using **Visual Studio Team Services**, but for the purpose of this lab, we will run them locally. Select the **“Run tests using local computer or a test controller”** option if not already selected.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image45.png?raw=true)
 
17. In the **Test Settings** window, select the **Data and Diagnostics** option to see the available adapters. Options include an **ASP.NET Profiler, Event Log, IntelliTrace, Network Emulation**, and more. No adapters are selected by default because many of them have a significant impact on the machines under test and can generate a large amount of data to be stored over the course of long load tests.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image46.png?raw=true)
 
18. Close the **Test Settings** window and click **Yes** to save changes if asked.

###Demo 7: Configuring Test Controller

1. Open the load test that we defined in the previous demo by **double-clicking** on it in Solution Explorer.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image47.png?raw=true)
 
2. Click the **Manage Test Controllers** button in the Load Test Editor toolbar.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image48.png?raw=true)
 
3. Note that the selected Controller is set to **Local – No controller**. Click the ellipses button to setup the connection string to the load test results store.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image49.png?raw=true)
 
4. Leave the settings to the default as shown below-

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image50.png?raw=true)
 
5. Click **Close** to exit out of the Manage Test Controller window.

###Demo 8: Executing and Monitoring Load Test

1. Start the load test by clicking the **Run Test** button from the toolbar.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image51.png?raw=true)
 
2. Once the load test initializes and starts a **1-minute** test run, the load test results window will load with the **Graphs view** visible. By default, you should see **four panels** showing some key statistics, with some key performance counters listed below that. Data is sampled every **5 seconds** by default, but that can be changed in the load test settings.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image52.png?raw=true)
 
**Note:** Screenshots showing statistics and graphs may vary widely from those that you see during your walkthrough of this lab. This is due to the different hardware that you are running this virtual machine on. In addition, you may see some threshold violations that result from the VM being busy during test. In a real world situation, in which you want to drive more virtual users, you would probably be served by using multiple machines during test, not only to generate the load but also for each component of your system, as it will be deployed in production.

###Demo 9: Viewing Load Test Results

1. After the load test run finishes, it will automatically switch to the Summary view. The Summary view shows overall aggregate values and other key information about the test. Note that the hyperlinks to specific pages open up even more details in the **Tables view**.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image53.png?raw=true)
 
2. Switch to the **Graphs** view by clicking on the **Graphs** button in the toolbar. Note that you can manipulate the graphs that you view. Select the panels drop down control in the toolbar and select the **Two Horizontal Panels** option.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image54.png?raw=true)
 
3. By default, the top graph will show **Key Indicators** and the bottom graph will show **Page Response Time**. Two very important sets of data for any web application.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image55.png?raw=true)
 
4. Click on one of the **Key Indicator graph lines or data points** and select it. This will also highlight the counter that it is associated with the below graphs. The red line from the screenshot below represents the **User Load** at different points during the load test.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image56.png?raw=true)
 
5. Click on the **Pages/Sec** row from the Key Indicators section of the counter grid to highlight it in the graph. In the screenshot shown below we can see that the **average number of pages per second** over the duration of the test was 2.85 (this may vary for you).

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image57.png?raw=true)
 
###Demo 10: Generating and Viewing Load Test Trend Reports

1. Even though the initial load test may result in some numbers that don’t seem to provide a wealth of information it does provide a good baseline and allow us to make relative measures between test runs to help measure performance impacts of code changes. For example, if we had seen a relatively high level of batch requests per second during our initial load tests, perhaps that could be addressed by adding in some additional caching, and then re-testing to make sure that the request per second goes down.

2. Run the load test one more time so that we have at least two test results to work with so that we can see how to perform some trend analysis.

3. When the second load test is complete, click the **Create Excel Report** button from the toolbar to load Excel.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image58.png?raw=true)

4. In the **Generate a Load Test** Report window within Excel make sure that the **Create a report** option is selected and then click **Next** to continue.
 
  ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image59.png?raw=true)
  
5. When prompted for the type of report to generate, select **Trend** and click Next.
 
  ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image60.png?raw=true)
  
6. For Report Name, enter **LoadTestTrend** and click **Next** to continue.
 
  ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image61.png?raw=true)
  
7. Select at least two load test runs to generate the trend report and then click **Next** to continue.
 
  ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image62.png?raw=true)
  
8. When prompted for counters to add to the report note that there will be a number of pre-selected defaults. Leave those defaults in place and click **Finish** to generate the report.
 
  ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image63.png?raw=true)
  
9. After the report is generated a table of contents will be displayed that provides hyperlinks to specific report sheets. Click the **Avg. Page Time** link.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image64.png?raw=true)
 
10. The **Avg. Page Time graph** shows the average page time taken over the entire load test for each test run that you selected for trend analysis. The page time is a measure that includes all requests that were made for a web page so it is a useful performance indicator to measure. Since we did not make any modifications to the application under test we do not expect to see significant differences between the test runs.

 ![](https://github.com/Microsoft/VSE2017-SalesEnablement-Demos/blob/master/Feature%20Demos/Load%20Testing/images/image65.png?raw=true)
