---
layout: homepage
title: Modern DevOps practices with Azure, Azure DevOps and Team Foundation Server
keywords: ALM VM homepage
tags: [overview]
permalink: default.html
comments: true
landingpage: false
description: Learn how you can implement modern DevOps practices with  Azure, Azure DevOps Services and Team Foundation Server.
---

<div class="bg-image">
   <div class="container pading-t-10">
      <div class="row">
         <div class="row">
            <div class="col-sm-12">
               <div style="margin-top:20px">
                  <h1>Azure DevOps Hands-On Labs</h1>
                  <div class="herotext2" style="margin-top:10px">
                     Evaluating your next DevOps toolchain? Want to go deep and learn how you can implement modern DevOps practices?<br /><br />
                     Learn how you can plan smarter, collaborate better, and ship faster with a set of modern dev services. 
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</div>

<div class="container">
   <div class="row">
      <div class="col-sm-10" style="padding-top:20px">
         <h1>New to Azure DevOps?</h1>
         <div style="margin-top:2px">
            Don't have an account? No worries! Sign up for a <b>free</b> Azure DevOps organization now and get
            <ul class="tick">
               <li>Automated CI/CD pipelines</li>
               <li>Free unlimited private Git repositories</li>
               <li>Configurable Kanban boards, and </li>
               <li>Extensive automated and cloud-based load testing tools.</li>
            </ul>
         </div>
         <a href="https://go.microsoft.com/fwlink/?LinkId=2014881" class="launch-hol" role="button" target="_blank" onclick="pageTracker._trackEvent('SignUp', 'Click', 'New User SignUp');" style="
            align-self:  right;"><span class="lab-details">Sign up for free now</span></a>
      </div>
   </div>
</div>

<div class="container padding-t-30">
   <div class="row">
      <div class="col-sm-12 tab-border">
         <ul class="nav nav-tabs tab-bg-color" role="tablist">
            <li class="nav-item">
               <a class="nav-link active tab-bor-sm tabs-padding-bor-rad" data-toggle="pill" href="#services-labs">Azure DevOps</a>
            </li>
            <li class="nav-item">
               <a class="nav-link tab-bor-sm tabs-padding-bor-rad" data-toggle="pill" href="#server-labs">Team Foundation Server</a>
            </li>
         </ul>
         <!-- Tab panes -->
         <div class="tab-content bg-color-wit-mlr">
            <div id="services-labs" class="container tab-pane active">
               <div class="col-sm-12">
                  <!--h2 class="pading-t-10">Azure DevOps Services</h2--> 
                  <div>
                     <p>Simplify and speed up the DevOps process with Azure DevOps services. The following labs will help you to get started with Azure DevOps services to automate software delivery and meet business needs.</p>
                  </div>
               </div>
               <div class="col-sm-12">
                  <h2>Getting started</h2>
                  <div class="row equal-height-columns">
                     <div class="col-sm-4 col-xs-12">
                        <div class="bg-color-grey equal-height-column mar-left-40">
                           <ul>
                              <li><a href="/labs/azuredevops/agile/" class="barleft">Agile Planning and Portfolio Management with Azure Boards </a></li>
                              <li><a href="/labs/azuredevops/git/" class="barleft">Version Controlling with Azure Repos  </a></li>
                              <li><a href="/labs/azuredevops/packagemanagement/" class="barleft">Package Management with Azure Artifacts</a></li>
                              <li><a href="/labs/azuredevops/continuousintegration/" class="barleft">Enabling Continuous Integration with Azure Pipelines</a></li>
                           </ul>
                        </div>
                     </div>
                     <div class="col-sm-4 col-xs-12">
                        <div class="bg-color-grey equal-height-column mar-left-40">
                           <ul>
                              <li><a href="/labs/azuredevops/continuousdeployment/" class="barleft">Embracing Continuous Delivery with Azure Pipelines</a></li>
                              <li><a href="/labs/azuredevops/testmanagement/" class="barleft">Test Planning and Management with Azure Test Plans</a></li>
                              <li><a href="/labs/azuredevops/exploratorytesting/" class="barleft">Exploratory Testing with Azure Test Plans</a></li>
                              <li><a href="/labs/azuredevops/load/" class="barleft">Web Application Load and Performance Testing</a></li>
                           </ul>
                        </div>
                     </div>
                     <div class="col-sm-4 col-xs-12">
                        <div class="bg-color-grey equal-height-column mar-left-40">
                           <ul>
                              <li><a href="/labs/azuredevops/deliveryplans/" class="barleft">Managing Project Schedules across teams with Delivery Plans</a></li>
                              <li><a href="/labs/azuredevops/sonarcloud/" class="barleft">Managing Technical Debt with Azure DevOps and SonarCloud</a></li>
                              <li><a href="/labs/azuredevops/wiki/" class="barleft">Collaborating with Azure DevOps Wiki</a></li>
                              <li><a href="/labs/azuredevops/yaml/" class="barleft">Configuring Build as Code with YAML in Azure Pipelines</a></li>
                           </ul>
                        </div>
                     </div>
                  </div>
               </div>
               <div class="col-sm-12 col-xs-12">
                  <h2>Azure DevOps Integration with 3rd party tools</h2>
                  <p>Azure DevOps provides integration with popular open source and third-party tools and services—across the entire DevOps workflow. Use the tools and languages you know. Spend less time integrating and more time delivering higher-quality software, faster.
                  </p>
               </div>
               <div class="col-sm-12 mar-bot">
                  <!-- <h3 id="step-by-step-tutorials">Step-by-Step Tutorials</h3>  -->
                  <div class="row equal-height-columns">
                     <div class="col-sm-4 col-xs-12">
                        <div class="bg-color-white equal-height-column">
                           <ul class="mar-left-40">
                              <li class="osslist"> <img src="/images/launchdarkly.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/launchdarkly"> Feature Flag Management with LaunchDarkly</a></li>
                               <li class="osslist"> <img src="/images/github-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/azuredevops/github-integration/"> Integrate Your GitHub Projects With Azure Pipelines</a></li>
                              <li class="osslist"> <img src="/images/jenkins-42.png" height="42" class="icon-bor-p-m" /> <a href="/labs/vstsextend/jenkins/"> Integrating with Jenkins</a>    </li>
                              <li class="osslist"> <img src="/images/tomcat-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/tomcat/"> Deploying a Java application on Tomcat  </a>    </li>
                              <li class="osslist"> <img src="/images/sonarqube-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/sonarqube/"> Technical Debt Management with SonarQube</a> </li>
                              <li class="osslist"> <img src="/images/whitesource-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/WhiteSource/"> OSS governance with WhiteSource</a></li>
                              <li class="osslist"> <img src="/images/octopus-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/Octopus/"> Integrating Octopus Deploy</a></li>
                              <li class="osslist"> <img src="/images/selenium-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/Selenium/"> Driving continuous testing with Selenium</a></li>
                           </ul>
                        </div>
                     </div>
                     <div class="col-sm-4 col-xs-12">
                        <div class="bg-color-white equal-height-column">
                           <ul class="mar-left-40">
                              <li class="osslist"> <img src="/images/eclipse-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/eclipse/"> Developing with Eclipse for Java projects</a></li>
                              <li class="osslist"> <img src="/images/kubernetes.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/kubernetes/"> Deploying to Azure Kubernetes Service (AKS)</a></li>
                               <li class="osslist"> <img src="/images/docker-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/docker/"> Deploying Docker Containers to Azure App Service</a></li>
                              <li class="osslist"> <img src="/images/docker-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/dockerjava/"> Deploying a Dockerized Java app to Azure Web App for Containers</a></li>
                              <!-- <li class="osslist"> <img src="/images/java-42.png" height="42" class="icon-bor-p-m"/> <a href="/labs/java/"> DevOps with VSTS and Azure for Java projects  </a>    </li> -->
                              <li class="osslist"> <img src="/images/nodejs-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vsts/nodejs/">DevOps for Node.js with VSTS and Azure   </a>    </li>
                              <li class="osslist"> <img src="/images/python-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/python/"> How to deploy a Python application to Azure from VSTS</a></li>
                              <li class="osslist"> <img src="/images/php.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/PHP/"> Deploying a PHP application to Azure</a></li>
                           </ul>
                        </div>
                     </div>
                     <div class="col-sm-4 col-xs-12">
                        <div class="bg-color-white equal-height-column">
                           <ul class="mar-left-40">
                              <li class="osslist"> <img src="/images/azure-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/deploymentgroups/"> Working with Deployment Groups</a></li>
                              <li class="osslist"> <img src="/images/AzureFunction.jpg" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/azurefunctions/"> Deploying Azure Functions using Azure DevOps</a></li>
                              <li class="osslist"> <img src="/images/aspnet-logo-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/aspnetmodernize/"> Modernizing your existing ASP.NET Apps with Azure</a></li>
                              <li class="osslist"> <img src="/images/vsts-1-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/releasegates/"> Controlling deployments using Release Gates</a> </li>
                              <li class="osslist"> <img src="/images/parasoft-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/parasoft/"> Leverage virtual services with Parasoft Virtualize</a></li>
                              <li class="osslist"> <img src="/images/sonarcloud-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/sonarcloud/"> Managing Technical Debt using VSTS and SonarCloud</a></li>
                              <li class="osslist"> <img src="/images/7pacetimetracker-42.png" height="42" class="icon-bor-p-m"/><a href="/labs/vstsextend/timetracker/"> Track Time With 7pace Timetracker</a> </li>
                           </ul>
                        </div>
                     </div>
                  </div>
               </div>
               <div class="col-sm-12">
                  <h2>Prerequisites</h2>
                  In order to complete these labs you will need:
                  <ul>
                     <li>
                        <strong>Azure DevOps services Organization:</strong> Of course! you will need an Azure DevOps services account. If you don’t have one, you can sign up for one, from <a href="https://www.visualstudio.com/" target="_blank">here</a>
                     </li>
                     <li>
                        <strong>Microsoft Azure Account</strong>: You will need a valid and active Azure account. If you do not have one, 
                        <ul>
                           <li>
                              You can create a <a href="https://azure.microsoft.com/en-us/free/" target="_blank">free Azure account</a> and enjoy 12 months of free Azure services
                           </li>
                           <li>
                              If you are a Visual Studio Active Subscriber, you are entitled for a $50-$150 credit per month. You can refer to this <a href="https://azure.microsoft.com/en-us/pricing/member-offers/msdn-benefits-details/" target="_blank">link</a> to find out more including how to activate and start using your monthly Azure credit.
                           </li>
                        </ul>
                     </li>
                     <li>
                        <a href="https://vstsdemogenerator.azurewebsites.net" target="_blank"><strong>Azure DevOps Demo Generator:</strong></a> You can use the Azure DevOps Demo Generator to provision a project with pre-defined data on to your Azure DevOps services organization.
                     </li>
                  </ul>
               </div>
            </div>
            <div id="server-labs" class="container tab-pane fade">
               <div class="col-sm-12">
                  Learn how you can remove barriers between teams, encourage collaboration, and improve the flow of value to your customers with Visual Studio and Team Foundation Server. <br />
               </div>
               <div class="col-sm-12">
                  <div class="row equal-height-columns">
                     <div class="col-sm-4 col-xs-12">
                        <div class="bg-color-grey equal-height-column">
                           <h4 class="bor-bot">Agile Planning</h4>
                           <ul class="mar-left-40">
                              <li><a href="/labs/tfs/agile/" class="barleft">Agile Planning and Portfolio Management </a></li>
                              <li><a href="/labs/tfs/agileworkitems/" class="barleft">Agile Work Item Management </a></li>
                              <li><a href="/labs/tfs/smartword4tfs/" class="barleft">Introduction to the Modern Requirements Suite4TFS</a></li>
                              <li><a href="/labs/tfs/deliveryplans/" class="barleft">Managing Delivery Plans</a></li>
                           </ul>
                           <h4 class="bor-bot">Develop</h4>
                           <ul class="mar-left-40">
                              <li><a href="/labs/tfs/devteamcollaboration/" class="barleft">Collaboration Experiences for Development Teams with Wiki</a> </li>
                              <li><a href="/labs/tfs/debugging/" class="barleft">Debugging with IntelliTrace </a>    </li>
                              <li><a href="/labs/tfs/snapshotdebugger/" class="barleft">Debugging with Snapshot Debugger</a> </li>
                              <li><a href="/labs/tfs/intellitrace/" class="barleft">Diagnosing Issues in Production with IntelliTrace</a> </li>
                              <li><a href="/labs/tfs/devexp/" class="barleft">Developer experience enhancements</a> </li>
                              <li><a href="/labs/tfs/intellitest/" class="barleft">Generate Unit Tests with IntelliTest</a> </li>
                              <li><a href="/labs/tfs/livedependencyvalidation/" class="barleft">Live Dependency Validation</a> </li>
                           </ul>
                        </div>
                     </div>
                     <div class="col-sm-4 col-xs-12">
                        <div class="bg-color-grey equal-height-column">
                           <ul class="mar-left-40">
                              <li><a href="/labs/tfs/liveunittesting/" class="barleft">Live Unit Testing, Code Coverage, and Code Clone Analysis</a> </li>
                              <li><a href="/labs/tfs/vsproductivity/" class="barleft"> Making Developers More Productive</a> </li>
                              <li><a href="/labs/tfs/sqlprompt/" class="barleft"> SQL Prompt</a> </li>
                              <li><a href="/labs/tfs/codeanalysis/" class="barleft"> Using Code Analysis to Improve Code Quality</a> </li>
                              <li><a href="/labs/tfs/git/" class="barleft"> Version Controlling with Git </a> </li>
                              <li><a href="/labs/tfs/editorconfig/" class="barleft"> Working with EditorConfig</a> </li>
                           </ul>
                           <h4 class="bor-bot">Continuous Integration</h4>
                           <ul class="mar-left-40">
                              <li><a href="/labs/tfs/technicaldebt/" class="barleft">Managing Technical Debt with SonarQube </a>    </li>
                              <li><a href="/labs/tfs/packagemanagement/" class="barleft">Package Management  </a>    </li>
                              <li><a href="/labs/tfs/build/" class="barleft">Enabling Continuous Delivery </a> </li>
                           </ul>
                           <h4 class="bor-bot">Test Management and Execution</h4>
                           <ul class="mar-left-40">
                              <li><a href="/labs/tfs/liveunittesting/" class="barleft">Unit Testing, Code Coverage, and Code Clone Analysis </a>    </li>
                              <li><a href="/labs/tfs/intellitest/" class="barleft">Generate Unit Tests with IntelliTest</a>    </li>
                           </ul>
                        </div>
                     </div>
                     <div class="col-sm-4 col-xs-12">
                        <div class="bg-color-grey equal-height-column">
                           <ul class="mar-left-40">
                              <li><a href="/labs/tfs/manualtesting/" class="barleft">Test Planning and Management </a> </li>
                              <li><a href="/labs/tfs/exploratorytesting/" class="barleft">Exploratory Testing and Feedback Management  </a>    </li>
                              <li><a href="/labs/tfs/codedui/" class="barleft">UI Automation using Coded UI Tests</a>    </li>
                              <li><a href="/labs/tfs/load/" class="barleft">Web Application Load and Performance Testing  </a> </li>
                           </ul>
                           <h4 class="bor-bot">Continuous Delivery</h4>
                           <ul class="mar-left-40">
                              <li><a href="/labs/tfs/releasemanagement/" class="barleft">Embracing Continuous Delivery with Release Management </a>    </li>
                              <li><a href="/labs/tfs/readyroll/" class="barleft">Develop and deploy databases with ReadyRoll</a>    </li>
                           </ul>
                           <h4 class="bor-bot">Application Monitoring</h4>
                           <ul class="mar-left-40">
                              <li><a href="/labs/tfs/appinsights/" class="barleft">Instrumenting ASP.NET with Application Insights </a>    </li>
                           </ul>
                           <h4 class="bor-bot">Azure</h4>
                           <ul class="mar-left-40">
                              <li><a href="/labs/tfs/armtemplates/" class="barleft">Authoring ARM Templates with Visual Studio </a>    </li>
                              <li><a href="/labs/tfs/aspnetazure/" class="barleft">Deploying a SQL Database backed ASP.NET app to Azure </a>    </li>
                           </ul>
                        </div>
                     </div>
                  </div>
               </div>
               <div class="col-sm-12">
                  <h2>Get the accompanying VM</h2>
                  <p>To make it easy for you to follow the labs, we offer a virtual machine pre-installed with Visual Studio Enterprise 2017 (15.5),  Visual Studio Team Foundation Server 2018, Office and pre-configured with sample projects, users and data.</p>
                  <p>You can get access to the virtual machine the following ways:</p>
                  <ul>
                     <li>
                        <strong>Download the Virtual Machine</strong> - You can download the virtual machine, if you prefer to use it offline. The size of the download is about 18 GB and we highly recommend that you use a download manager to download the VHD file. The <strong><a href="labs/tfs/almvmdownload\">Accessing the VM</a></strong> page has detailed instructions on downloading the VM, including links to both current and the previous versions of TFS labs.
                     </li>
                     <li>
                        <strong>Try it on Microsoft Hands-on Labs</strong> - If you are evaluating or want to try the labs without the hassle of downloading or setting up the virtual machine, you can access them from the <a href="labs/tfs/technet/"><strong>Microsoft Hands-on-Labs</strong></a> center. You only need a browser. There is absolutely no download or setup required!
                     </li>
                     <li>
                        <strong>Run it on Azure</strong> - Though the VM is currently not supported to run on Azure, you can simply upload the VHD to Azure as a specialized VHD and create a VM from it. Thanks to <strong>Pieter Gheysens</strong> who has written a PowerShell script to create VM instances based on the ALM VM. His <a href="https://intovsts.net/2018/01/03/generating-azure-vms-from-a-specialized-vhd-file/" target="_blank">blog</a> has more details.
                        If you want to and customize and upload the VHD yourself, please see this article for step-by-step instructions - <a href="https://docs.microsoft.com/en-us/azure/virtual-machines/windows/create-vm-specialized" target="_blank">Create a Windows VM from a specialized disk</a>
                     </li>
                  </ul>
               </div>
            </div>
         </div>
      </div>
   </div>
</div>