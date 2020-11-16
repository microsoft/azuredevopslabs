---
title: Driving continuous quality of your code with SonarCloud
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/sonarcloud/
folder: /labs/vstsextend/sonarcloud/
---

<div class="rw-ui-container"></div>

## Overview

[SonarCloud](https://about.sonarcloud.io/){:target="\_blank"} is a cloud-based code quality and security service.
The main features of SonarCloud are:

- 23 languages: Java, JS, C#, C/C++, Objective-C, TypeScript, Python, ABAP, PLSQL, T-SQL and more.
- Thousands of rules to track down hard-to-find bugs and quality issues thanks to powerful static code analyzers.
- Cloud CI Integrations, with Travis, Azure DevOps, BitBucket, AppVeyor and more.
- Deep code analysis, to explore all source files, whether in branches or pull requests, to reach a green Quality Gate and promote the build.
- Fast and Scalable

<div class="bg-slap"><img src="./images/mslearn.png" class="img-icon-cloud" alt="MS teams" style="width: 48px; height: 48px;">Want additional learning? Check out the <a href="https://docs.microsoft.com/en-us/learn/modules/scan-for-vulnerabilities/" target="_blank"><b><u> Scan code for vulnerabilities in Azure Pipelines</u></b></a> module on Microsoft Learn.</div>

### What's covered in this lab

In this lab, you will learn how to integrate Azure DevOps Services with SonarCloud:

- Setup an Azure DevOps project and CI build to integrate with SonarCloud
- Analyze SonarCloud reports
- Integrate static analysis into the Azure DevOps pull request process

### Prerequisites for the lab

1. You will need a Microsoft account.

2. Using this account, sign in to [**Azure DevOps Services**](https://dev.azure.com){:target="\_blank"}.

3. Create a new Azure DevOps project for this lab:
  
   Every project in Azure DevOps belongs to an organization. You will be placed into an automatically created default organization on sign in, the name of which is based on your user name (in our example, the user Claudia Sonarova has been given the organization **claudiasonarova**).
   
   Inside this organization, create a project called **SonarExamples**:
   
   > Unless you intend to sign up for a paid plan with SonarCloud (see below), make sure that you set your Azure DevOps project to be public. If you *do* intend to sign up for a paid plan, then you can use a private or public project.

   ![Create project](images/azdo_create_project.png)

   Import the **Sonar Scanning Examples repository** from GitHub at https://github.com/SonarSource/sonar-scanning-examples.git .
   
   Go to **Repos** in your project overview:

   ![Go to repos](images/azdo_project_repos.png)

   Then, click **Import**:

   ![Import repo](images/azdo_import_repo.png)

   See [here](https://docs.microsoft.com/en-us/azure/devops/repos/git/import-git-repository?view=azure-devops) for detailed instructions on importing a repository.

   The scanning examples repository contains sample projects for a number of build systems and languages including C# with MSBuild, and Maven and Gradle with Java.

4. Install the SonarCloud Azure DevOps extension in your Azure DevOps account

   Navigate to the [SonarCloud extension](https://marketplace.visualstudio.com/items?itemName=SonarSource.sonarcloud) in the Visual Studio Marketplace and click **Get it free** to install it, and **Proceed to organization** once the installation has finished.

   ![Marketplace](images/ex1/sc_marketplace.png)


   ![Marketplace installed](images/ext-installed.png)

   > If you do not have the appropriate permissions to install an extension from the marketplace, a request will be sent to the account administrator to ask them to approve the installation.

   The SonarCloud extension contains build tasks, build templates and a custom dashboard widget.

5. Using the same account as you used for Azure Devops, sign into SonarCloud: https://sonarcloud.io/

   ![SonarCloud Welcome](images/sonarcloud.io2.png)

6. In SonarCloud, create an organization and, within that, a new project. The organization and project you set up in SonarCloud will mirror the organization and project that you set up in Azure DevOps.

   Once you sign in, click **Import project from Azure** on the welcome page:

   ![SonarCloud Welcome](images/import.png)

   Add your Azure DevOps organization name (dev.azure.com/{YOUR-ORG}) , create and provide  a personal access token in your Azure DevOps organization settings. **Check the following scope: Code (Read & Write)**. [Create PAT](https://docs.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate?view=azure-devops&tabs=preview-page)

   ![PAT](images/pat1.png)


   ![PAT](images/pat2.png)

    ![SonarCloud org creation](images/org-create.png)
   
   Choose an organization key. Note that the key must be unique within the SonarCloud system. In our example, we will use
   
   **`YOURNAME-azdo-org`**

   Click **Continue**
   
   Make sure that the the green checkmark appears beside the **Key** field. This indicates that the key is unique across SonarCloud.

   ![SonarCloud org creation](images/org-create2.png)


   Next, you can choose your plan. For this example, we choose a free plan (that is, one for public repos only), but you can choose a paid plan if you intend to have private repos:

   ![Create SonarCloud organization](images/sc_create_org.png)

   You have now created the SonarCloud organization that will mirror your Azure DevOps organization.

   The next step is to create, within that organization, the SonarCloud project that will mirror the Azure DevOps project **SonarExamples**. Click on **Analyze new project**.

   ![Create SonarCloud project](images/new-project.png)

   Choose your Azure DevOps project and click **Set up**.

   ![Create SonarCloud project](images/choose-project.png)


   Lets follow the guide in Sonarqube to set up the scanning in Azure Pipelines:

   ![Scan using pipeline](images/with-pipelines.png)


   You can skip extension creation (if done previosly). Click **Continue**. Click on the **.NET** option and keep these instructions close for Exercise 1. We will need the information shown  to set up a Service Connection (from Azure DevOps to Sonarcloud) and configure the scanning in the pipeline.

   ![Scan using pipeline](images/pipeline-guide3.png)

## Exercise 1: Set up a pipeline that integrates with SonarCloud

We will set up a new build pipeline that integrates with SonarCloud to analyze the **SonarExamples** code. 

1. In your new Azure DevOps project, go to **Pipelines** under the **Pipelines** tab, then click on **Create Pipeline**:

![Create pipeline](images/azdo_create_pipeline.png)

Here you have two options. You can can configure the pipeline with either the **YAML editor**, or with the **classic editor**.

With the classic editor, you can take advantage of the pre-defined templates that were installed as part of the SonarCloud Extension, above. With the YAML editor you need to use a separately provided YAML file. **Choose one of the options (YAML OR CLASSIC)**:

### YAML Editor

1. We will not be using this feature today. In our case we want to analyze code in the git repo that we imported earlier, right in the same account as this pipeline. So, we select **Azure Repos Git**:

   ![Select Azure Repos](images/azdo_yaml_select_azure_repos.png)

1. On the next screen select the git repository that you imported earlier, **SonarExamples**:

   ![Select SonarExamples](images/azdo_yaml_select_sonarexamples.png)

1. Now select a YAML file template. We will be building and analyzing the .NET code in our example imported repository, so we will start by choosing the **.NET Desktop** YAML template:

   ![Choose .NET Desktop template](images/azdo_yaml_configure_pipeline_dot_net.png)

1. The YAML editor will open with the template YAML file. In order to configure it correctly you will need to adjust it (or replace it) so that it looks like the following example file:

   [net-desktop-sonarcloud.yml](https://github.com/SonarSource/sonar-scanner-vsts/blob/master/yaml-pipeline-templates/net-desktop-sonarcloud.yml)

   we need to customize it to our needs:

   1. Modify the Build task, change the pointer to the solution **(add wildcards as our solution is not located in the root of the repo):

      ![](images/wildcard.png)

   1. Modify the Prepare Sonarcloud task with your own information. Follow the information in Sonarcloud previous windows to:
   
      1. **Setup a service connection**
      1. Modify the task with **the values provided on the Sonarcloud window guide**. Use your service endpoint created and organization/project name and key values, not the default ones!! click **Add** after modifying those values.

   ![guide](images/pipeline-guide3.png)
   ![task](images/task.png)

   When you are done making the changes to the file, click **Save and Run**:

   ![Save and run YAML](images/azdo_yaml_save_run.png)

   ![Commit YAML](images/azdo_yaml_save_run_commit.png)

### Classic Editor (skip if YAML option chosen before)

1. To configure the pipeline using the classic editor, select **Use the classic editor** on the **Where is your code?** page:

   ![Use classic editor](images/azdo_classic_select.png)

2. Select **Azure Repos Git**, choose **SonarExamples** under **Repository** and **master** under **Default branch...**, then click **Continue**:

   ![Select SonarExamples](images/azdo_classic_select_sonarexamples.png)

   > The SonarCloud extension installed earlier provides SonarCloud-enabled custom build templates for Maven, Gradle, .NET Core and .NET Desktop applications. The templates are based on the standard Azure DevOps templates but with additional analysis-specific tasks and some pre-configured settings.

3. Select the **.NET Desktop with SonarCloud** template.

   ![.NET Desktop with SonarCloud template](images/azdo_classic_select_template.png)

   The template contains all of the necessary tasks and most of the required settings. However, You will need to provide a few additional settings.

4. Select _Azure Pipelines_ in **Agent pool**, then choose _vs2017-win2016_ in **Agent Specification**:

   ![Agent pool](images/azdo_agent_pool.png)

5. Get the SonarCloud endpoint token from previous sonarcloud guide. This is a token generated by SonarCloud that identifies your account on that system and allows other services, in this case, Azure DevOps, to connect to that account. (token in "Add a new Sonarcloud Service Endpoint)

   ![Token](images/pipeline-guide3.png)

6. Copy the token and in Azure DevOps pipeline > Prepare Analysis:


   ![Prepare analysis](images/azdo_prepare_analysis.png)

   Click on the **+ New** button:

   ![Click new endpoint](images/azdo_click_new_endpoint.png)

   Paste the endpoint token  in to the field **SonarCloud Token**, give the endpoint a name and click **Verify and save**:

   ![New service connection](images/azdo_new_service_connection.png)

7. If the token was correctly copied, Azure DevOps should connect with your SonarCloud account and you should be able to click on the **Organization** drop-down and see the organization you created earlier and choose it from the dropdown (in our case `claudiasonarova-azdo-org`):

   ![New service connection](images/azdo_choose_org.png)


   Now enter the key of the project that you created within that organization on SonarCloud (**you can find it on the sonarcloud setup guide too**):


   ![New service connection](images/azdo_enter_project.png)

8. [Optional] Enable the _Publish Quality Gate Result_ step

   This step is not required unless you want to use the pre-deployment gate along with Release Pipelines.
    If this step is enabled, a summary of the analysis results will appear on the _Extensions_ tab of the _Build Summary_ page. However, this will delay the completion of the build until the processing on SonarCloud has finished.

   ![New service connection](images/azdo_publish_quality_gate.png)

9. Save and queue the build. Once the build has completed you should see something like this:

   ![Recently run pipelines](images/azdo_manually_run.png)

10. If you enabled the _Publish Quality Gate Result_ step above the Build Summary will contain a summary of the analysis report.

    ![SonarCloud analysis report](images/azdo_sc_analysis_report.png)

11. Either click on the **Detailed SonarCloud Report** link in the build summary to open the project in SonarCloud, or browse to SonarCloud and view the project.


   To be able to see the Quality gate result, after running he first report we need to "Set New Code Definition" and choose "Previous Version". Next pipeline runs will be able to get a Quality Gate result.

   ![SonarCloud New code def](images/new-code-def.png)

   ![SonarCloud New code def](images/new-code-def2.png)

   ![SonarCloud report](images/sc_report.png)


   We have now created a new organization on SonarCloud and configured an Azure DevOps build to perform analysis and push the results of the build to SonarCloud.

## Exercise 2: Analyze SonarCloud Reports

Open the **SonarExamples** project in the SonarCloud Dashboard. Under **_Bugs and Vulnerabilities_**, we can see a bug has been found.

![Bug found](images/sc_bug_found.png)

The page has other metrics such as **_Code Smells_**, **_Coverage_**, **_Duplications_** and **_Size_**. The following table briefly explains each of these terms.

| Terms | Description |
| --- | --- |
| **Bugs** | An issue that represents something wrong in the code. If this has not broken yet, it will, and probably at the worst possible moment. This needs to be fixed |
| **Vulnerabilities** | A security-related issue which represents a potential backdoor for attackers |
| **Code Smells** | A maintainability-related issue in the code. Leaving it as-is means that at best maintainers will have a harder time than they should make changes to the code. At worst, they'll be so confused by the state of the code that they'll introduce additional errors as they make changes |
| **Coverage** | To determine what proportion of your project's code is actually being tested by tests such as unit tests, code coverage is used. To guard effectively against bugs, these tests should exercise or 'cover' a large proportion of your code |
| **Duplications** | The duplications decoration shows which parts of the source code are duplicated |
| **Size** | Provides the count of lines of code within the project including the number of statements, Functions, Classes, Files and Directories |

{% include important.html content= "Notice that a **C** is displayed alongside the bug count. This is the **Reliability Rating**. **C** indicates that there is **at least 1 major bug** in this code. For more information on Reliability Rating, click [here](https://docs.sonarqube.org/display/SONAR/Metric+Definitions#MetricDefinitions-Reliability). For more information on rule types see [here](https://docs.sonarqube.org/latest/user-guide/rules/) and for more information on severities, see [here](https://docs.sonarqube.org/latest/user-guide/issues/)." %}

1. Click on the **Bugs** count to see the details of the bug. The Issues page will appear:

   ![Click on bugs](images/sc_issues.png)

2. Click on the bug to navigate to the code. You will see the error in line number 9 of **Program.cs** file as **Change this condition so that it does not always evaluate to 'true'; some subsequent code is never executed.**:

   ![Bug details](images/sc_bug_in_code.png)

3. We can also see which lines of code are not covered by tests:

   ![Test coverage](images/sc_bug_in_code_coverage.png)

   Our sample project is very small and has no historical data. However, there are thousands of [public projects on SonarCloud](https://sonarcloud.io/explore/projects){:target="\_blank"} that have more interesting and realistic results.



## Exercise 3: Set up pull request integration

Configuring SonarCloud analysis to run when a pull request is created involves two steps:

- A SonarCloud project needs to be provided with an access token so it can add PR comments to Azure DevOps, and
- Branch Policy needs to be configured in Azure DevOps to trigger the PR build

1. Create a **Personal Access Token** in Azure DevOps.

   - Follow the instructions in this [article](https://docs.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate?view=azure-devops) to create a token with **Code (read and write)** scope.

     > SonarCloud will post comments to the pull request as if it is a user who owns the personal access token. The recommended practice is to create a separate "bot" Azure DevOps user for this so that it is clear which comments are from real developers and which are from SonarCloud.

   Make sure to set the scope under **Code** to **Read & write**:

   ![Personal access token permissions](images/azdo_create_pat.png)

   Click **Create** and copy the generated token:

   ![Copy personal access token](images/azdo_copy_pat.png)

   > You should treat Personal Access Tokens like passwords. It is recommended that you save them somewhere safe so that you can re-use them for future requests.

2. Configure SonarCloud to analyze pull requests

   - Browse to the **Sonar Examples** dashboard in SonarCloud
   - Click on **Administration** > **General Settings**

     ![Click general settings](images/sc_click_general_settings.png)

   - Select the **Pull Requests** tab
   - Set the **Provider** drop-down to **Azure DevOps Services** and click **Save**
   - Paste in the **Personal access token** you copied earlier and click **Save**

     ![Pull request configuration](images/sc_pull_request_config.png)

3. Configure the branch policy for the project in Azure DevOps

   - Navigate to the **SonarExamples** project in Azure DevOps
   - Click on **Repos**, **Branches** to view the list of branches
   - Click on the settings link ("**...**") for **master** and select **Branch policies**

     ![Click branch policies](images/azdo_click_branch_policies.png)

   - Click the **+** beside **Build Validation** to add a new build policy:

     ![Click add build policy](images/azdo_click_add_build_policy.png)

   - Select the build definition we created earlier from the **Build definition** drop-down
   - Set the **Display name** to **SonarCloud analysis**
   - Click **Save**

     ![Add build policy](images/azdo_add_build_policy.png)

   Azure DevOps is now configured to trigger a SonarCloud analysis when any pull request targeting the **master** branch is created.

4. Create a new pull request

   Now we will make a change to a file and create a new request so that we can check that the pull request triggers an analysis.

   - Navigate to the code file **Program.cs** at **sonarqube-scanner-msbuild/CSharpProject/SomeConsoleApplication/Program.cs** and click **Edit**
   - Add an empty method to the code as shown in the following screen shot, then click **Commit...**

   ``public void Unused(){}``

      ![Edit program](images/azdo_add_unused.png)

   In the dialog that appears,

   - Change the branch name from **master** to **branch1**
   - Check the **Create a pull request** checkbox
   - Click **Commit**, then click **Create** on the next screen to submit the pull request

      ![Commit changes](images/azdo_commit_pr.png)

      ![Create pull request](images/azdo_create_pr.png)

      If the pull request integration is correctly configured the UI will show that an analysis build is in progress.

     ![Analysis in progress](images/azdo_pr_analysis_in_progress.png)

5. Review the results of the Pull Request analysis

   The results show that the analysis builds completed successfully, but that the new code in the PR failed the Code Quality check.
   Comment has been posted to the PR for the new issue that was discovered.

   ![Check failed](images/check_failed.png)

   ![Check failed](images/azdo_pr_comment.png)

   Note that the only issues in code that was changed or added in the pull request are reported - pre-existing issues in **Program.cs** and other files are ignored.

6. Block pull requests if the Code Quality check failed

   At this point, it is still possible to complete the pull request and commit the changes even though the Code Quality check has failed.
   However, it is simple to configure Azure DevOps to block the commit unless the Code Quality check passes:

   - Go to the **Branch Policy** page of the **master** branch (since the master branch is the one you will want your pull requests to merge into, this is where you have to adjust the policy).
   - Click **Add status policy**

      ![Return to branch policies](images/azdo_add_status_check.png)

   - Select **SonarCloud/quality gate** from the **Status to check** drop-down
   - Set the **Policy requirement** to **Required**
   - Click **Save**

     ![vsts_status_policy_add](images/azdo_add_status_policy.png)

   Users will now be unable to merge the pull request until the Code Quality check is successful (the Code Quality check succeeds when all issues have been either fixed or marked as **confirmed** or **resolved** in SonarCloud).

## Exercise 4: Check the SonarCloud Quality Gate status in a Continuous Deployment scenario (In Preview)

**Disclaimer: This feature is in preview, and may not reflect its final version. Please look at the notes at the end of this exercise for more information.**

Starting from version 1.8.0 of the SonarCloud extension for Azure DevOps, a pre-deployment gate is available for your release pipeline. It allows you to check the status of the SonarCloud Quality Gate for the artifact you want to deploy and block the deployment if the Quality Gate failed.

Prerequisites :

- Enable the **Publish Quality Gate Result** in your build pipeline
- Have an artifact built and published in this pipeline to feed the release pipeline

Setup :

1. Click on **Pipelines** on the left pane, then click on **Releases**
1. Click on **New Pipeline**

   ![new_release_pipeline](images/ex4/new_release_pipeline.png)

1. On the template selection, choose the template you want. We will choose **Empty job** for this exercise.

   ![empty_job](images/ex4/empty_job.png)

1. Close for now the Stage properties
1. Click on the pre-deployment conditions on Stage 1

   ![pre_deploy_conditions](images/ex4/predeploy_conditions.PNG)

1. Click on **Enabled** beside **Gates**
1. Click on **+ Add**, then select **SonarCloud Quality Gate status check**

   ![pre_deploy_conditions_settings](images/ex4/predeploy_conditions_settings.PNG)

1. In order to have the fastest result possible for this exercise, we recommend you to set the evaluations options as per this screenshot (See [how Gate evaluation flow works](https://docs.microsoft.com/en-us/azure/devops/pipelines/release/approvals/gates?view=azure-devops), as per Microsoft Documentation)

   ![gate_setting](images/ex4/gate_setting.PNG)

1.  That's it. You can close this panel.
1. Click now on **Add an artifact** on the left.
1. Currently, only build artifacts are supported. Choose the project and the source (build pipeline) of your artifact, its alias should match the name of the artifact published in the build pipeline.
1. Click on **Add**

    ![artifact_setting](images/ex4/artifact_settings.PNG)

1. Setup the CD trigger.

   ![artifact_setting](images/cd.PNG)

1. You can now save your pipeline.
1. Go back to the build pipeline section, trigger a build of the pipeline that creates the artifact.
1. Once the build is completed and succeeded, it will trigger the CD automatically.

   
1. Go to the  **Releases** page.
1. After few minutes (as set up on the point 8 of this exercise), your Quality Gate check should have been performed (at least twice to get a 'go/nogo' for the stage), and if it's green, it should look like this:

   ![qg_green](images/ex4/qg_green.PNG)

Otherwise, if it's failed, then read important notes below to find out how it happened and how to get a green Quality Gate.

**Important notes about this feature**

- The **Publish Quality Gate Result** task in your build pipeline has to be enabled in order for the release gate to work.
- If the Quality Gate is in the failed state, it will not be possible to get the pre-deployment gate passing as this status will remain in its initial state. You will have to execute another build with either the current issues corrected in SonarCloud or with another commit for fixing them.
- Please note also that current behavior of the pre-deployment gates in Release Pipelines is to check the status every 5 minutes, for a duration of 1 day by default. However, if a Quality Gate for a build has failed it will remain failed so there is no point in re-checking the status. Knowing this, you can set the timeout after which gates fail to a maximum of 6 minutes so the gate will be evaluated only twice as described above, or just cancel the release itself.
- Only the primary build artifact related Quality Gate of the release will be checked.
- During a build, if multiple analyses are performed, all of the related Quality Gates are checked. If one of them has the status either WARN, ERROR or NONE, then the Quality Gate status on the Release Pipeline will be failed.

## Summary

With the **SonarCloud** extension for **Azure DevOps Services**, you can embed automated testing in your CI/CD pipeline to automate the measurement of your technical debt including code semantics, testing coverage, vulnerabilities. etc. You can also integrate the analysis into the Azure DevOps pull request process so that issues are discovered before they are merged.
