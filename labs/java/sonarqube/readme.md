---
title: Managing Technical Debt with SonarQube and VSTS
layout: page
sidebar: java
permalink: /labs/java/sonarqube/
folder: /labs/java/sonarqube/
comments: true
---

In this exercise, you are going to configure integration between the build system and SonarQube. SonarQube is a well established technical debt management system. Keeping tabs on your technical debt gives you objective measures that you can use to make informed decisions about maintenance, refactoring and enhancements to your code base.

This exercise assumes you have completed the exercises to create a Team Project and have set up the Docker private VSTS agent. You should also have created a VSTS Team Build for MyShuttle2. This exercise uses a team project named **jdev-labs**, though your team project name may differ.

{% include note.html content= "SonarQube is running in a docker container on your VM. It is only accessible from within the VM. It is therefore not secure - this is not a recommended production configuration." %}

## Create a SonarQube Endpoint in VSTS

In this task you will create a Generic SonarQube Endpoint in VSTS. This endpoint abstracts authentication from the build tasks. After obtaining a token from SonarQube, you will create the endpoint in VSTS.

1. Connect to the virtual machine using the user credentials specified during the creation of the VM in Azure.

1. Open Chrome and browse to `http://localhost:9000` to open SonarQube. Click on Login.

    ![Log in to SonarQube](images/login.png)

1. Log in as the administrator using username `admin` and password `admin`.

1. Open a new tab in Chrome and browse to `http://<youraccount>.visualstudio.com` (where `youraccount` is the account you created in VSTS).

1. Click on the `jdev` team project to navigate to it.

1. Click on the gear icon and select Services to navigate to the service endpoint configuration page. Click **+ New Service Endpoint** and select Generic from the list of options. Enter the following information and click OK.

    | Property | Value | Notes |
    | --------------- | ---------------------------- | ----------------------------------------------------------- |
    | Connection name | `Azure VM SonarQube` | Display name for the endpoint |
    | Server URL | `http://10.0.0.4:9000` | The URL for the SonarQube server. Use the Azure internal network IP address so that the build agent running in the Docker container can reach Sonarqube |
    | User name | `admin` | This could be anything - it will not be used for SonarQube since the token is sufficient |
    | Password/Token Key | `admin` | The default password for admin user in SonarQube |

    ![Create the Sonarqube Endpoint](images/create-endpoint.png)

## Create a SonarQube Project

In this task you will create a SonarQube project.

1. In Chrome, go back to SonarQube (http://localhost:9000) and log in as administrator if you are not already logged in.

1. Click on Administration in the toolbar and then click on the Projects tab.

1. Click **Create Project**.

    ![Go to projects](images/goto-projects.png)

1. Enter `MyShuttle2` for both the name and key of the project (name is the display name and key is the unique identifier within SonarQube).

    ![Create a SonarQube project](images/create-project.png)

## Modify the Build to Integrate with SonarQube

In this task you will modify the MyShuttle2 build to integrate with SonarQube.

1. In VSTS, click on **Build & Release** and then **Builds** to view your builds. Click on the MyShuttle2 build. Click on  **...** to the right of the build definition, then click Edit.

    ![Edit build definition](images/edit-builddefinition.png)

1. Click on the Maven task and scroll down to the Code Analysis section.

1. Select the **Run SonarQube Analysis** option and configure the remaining settings as follows:

    | Parameter | Value | Notes |
    | --------------- | ---------------------------- | ----------------------------------------------------------- |
    | SonarQube Endpoint | `<your endpoint>` | The generic Service Endpoint to SonarQube you just created |
    | SonarQube Project Name | `MyShuttle2` | The name of the project in SonarQube |
    | SonarQube Project Key | `MyShuttle2` | The key of the project in SonarQube |
    | SonarQube Project Version | `1.0` | A major version number |
    | Include full analysis report... | Checked | Waits for SonarQube analysis to complete before proceeding |
    | Fail the build on quality gate failure... | Checked | Fails the build if SonarQube quality gates fail |

    ![Maven SonarQube settings](images/build-sonarqube.png)

1. Save and queue the build.

1. When the build completes, there will be a new SonarQube section in the summary page. Click on the build number and scroll below issues to see the SonarQube status.

    ![SonarQube success](images/quality-gate-success.png)

1. Click on the Detailed Report link to open the project in SonarQube.

    ![SonarQube project](images/sonarqube-success.png)

1. You can click on the MyShuttle2 project to get details of the analysis for the project.

## Updating a Quality Gate

In this task you will update a quality gate in SonarQube and see that failing the quality gate fails the build. You will then update the gate to warn rather than fail.

1. In SonarQube (http://localhost:9000) click on the Quality Gates in the top toolbar. Click on "SonarQube Way" (the default quality gate) to see its settings. Click on the "Add Condition" dropdown at the bottom of the list of rules and select Coverage.

    ![Add a new condition to the SonarQube Way quality gate](images/add-condition.png)

1. Enter **50** for the Warning value and **30** for the Error value and click Add.

    ![Update the Quality Gate](images/config-coverage-fail.png)

1. Back in VSTS, queue another MyShuttle2 build.

1. When the build completes, it should have a failed result. Click on the build number and look for the SonarQube section in the summary page.

    ![Failing quality gates fails the build](images/quality-gate-fail.png)

1. Go back to SonarQube and edit the Quality Gate that you just modified. Clear the Error value so that you only get a warning if the coverage < 50% instead of failing the build. Click Update. Additionally, under the Coverage on New Code metric, set the 80% value to a warning message instead of error and click Update. In the Reliability Rating on New Code metric, change the error threshold from A to blank (click on the "X" next to the A), then click Update.

    ![Update Quality Gates in SonarQube](images/update-qualitygates.png)

1. Queue a new build and see that now the build succeeds, but there is a Quality Gate warning.

    ![Quality gate warning](images/quality-gate-warn.png)