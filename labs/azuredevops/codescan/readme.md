---
title: Code Scanning with Azure DevOps
layout: page
sidebar: vsts
permalink: /labs/azuredevops/codescan/
folder: /labs/azuredevops/codescan/
version: Lab version - 1.37.1
updated: Last updated - 22/07/2024
---
<div class="rw-ui-container"></div>
<a name="Code Scanning"></a>

<a name="Ex0Task1"></a>
## Prerequisites ##
In this exercise, you will set up the **Tailwind Traders** project in Azure DevOps to explore the features on GitHub Advanced Security for Azure DevOps (GHAzDO). Complete the following steps to set up the Tailwind Traders project in Azure DevOps from [prerequisites](../prereq-ghas/readme.md).


## Getting Started

If you followed **Module 0 - Setup and Automation** you will have already enabled **_GitHub Advanced Security for Azure DevOps_**, **_Secret Scanning_**, and **_Push Protection_** at the repository level.

Once this is enabled, navigate to https://dev.azure.com/mstechbootcamp/, select your team project **tp-<**yourgithubhandle**>**, and select the **TailwindTraders** repository to begin working through this module.

------
## Contents

- [Lab 1: Setting up Code Scanning](#lab-1-setting-up-code-scanning)
- [Lab 2: Review Code Scanning Alerts](#lab-2-review-code-scanning-alerts-gain-insights)
- [Lab 3: Resolution of Code Scanning Alerts](#lab-3-resolution-of-code-scanning-alerts-fix-leak)

------

## Lab 1: Setting up code scanning
Code scanning is a pipeline-based scanning tool and aggregated per repository. Add the code scanning task following the build steps of a pipeline that builds the code you want to scan.

1. Click on **Pipelines**, then click on **tailwindtraders-codescanning.yml**, and click **Edit** to enable code scanning.

2. Add the tasks in the following order directly to your YAML pipeline file:
    - Advanced Security Initialize CodeQL
    - Advanced Security AutoBuild (language-dependent)
    - Advanced Security Perform CodeQL Analysis
    - Advanced Security Publish Results

    ```yaml
     - task: AdvancedSecurity-Codeql-Init@1
     - task: AdvancedSecurity-Codeql-Autobuild@1
     - task: AdvancedSecurity-Codeql-Analyze@1
     - task: AdvancedSecurity-Codeql-Publish@1
    ```

<details>
<summary>Solution</summary>

```yaml

trigger:
- main

variables:
  resource-group: "ghazdo-workshops"
  BuildConfiguration: "Release"
  BuildPlatform: "any cpu"
  Parameters.RestoreBuildProjects: "**/*.csproj"
  Parameters.TestProjects: "**/*[Tt]ests/*.csproj"
  webapp_name: tailwind-github-demo
  advancedsecurity.submittoadvancedsecurity: true

pool:
  vmImage: windows-latest

stages:
- stage: 'AdvancedSecurityScan'
  displayName: 'Advanced Security'
  jobs:
  - job: 
    displayName: 'Advanced Security Scanning'
    steps:
    
    # Setup Node.js environment
    - task: NodeTool@0
      displayName: 'Use Node 10.16.3'
      inputs:
        versionSpec: 10.16.3
    
    # Initializes the CodeQL tools for scanning.
    - task: AdvancedSecurity-Codeql-Init@1
      inputs:
        languages: 'csharp, javascript'

    # Autobuild attempts to build any compiled languages  (C/C++, C#, or Java).
    - task: AdvancedSecurity-Codeql-Autobuild@1
    
    # Performs CodeQL Analysis
    - task: AdvancedSecurity-Codeql-Analyze@1
      
    # Publish Results to Advance Security Dashboard
    - task: AdvancedSecurity-Publish@1
        
```

</details>

3. Click **Save** to save the pipeline configuration file.

4. The build will automatically run the build, Code Scanning task and publish the results to Advanced Security. this might take up to 5 minutes to complete.

    ![Image](images/2023-06-15_16-00-08.png =900x)

> **ProTip!** Always use a separate pipeline, not the main build pipeline. Code Scanning can be a time-intensive build task.

## Lab 2: Review Code Scanning Alerts (Gain Insights)
GitHub experts, security researchers, and community contributors write and maintain the default CodeQL queries used for code scanning. The queries are regularly updated to improve analysis and reduce any false positive results. You can also write your own queries to customize your code scanning experience.

1. You can view the specific queries and task details used by CodeQL by looking through the build log, similar to dependency scanning.

2. Click on **Pipelines**, then click on **tailwindtraders-codescanning.yml**, click the last run.

3. Under **Jobs**, click on **Advanced Security Scanning** to view logs.

4. Click on **AdvancedSecurityCodeqlInit** step to view details.

    ![Image](images/2023-06-24_11-12-08.png =900x)

### Alerts Review
Code scanning alerts include code scanning flags by repository that alert of code-level application vulnerabilities.

1. Go to the **Repos** tab and click on the **Advanced Security** menu item on the bottom.
2. Click on **Code scanning** to see a list of all the code scanning alerts that have been found.  This includes the **Alert** and **First detected** date.

    ![Image](images/2023-06-24_11-15-55.png =900x)

### Alerts Details
Select an alert for more details, including remediation guidance. Each alert includes a location, description, example, and severity. You can also view the code that triggered the alert.

1. Click on **_Clear-text logging of sensitive information_** to see more details about the alert and what you can do to clean up the alert.

2. Notice this includes the **Recommendation**, **Locations** found, **Remediation Steps**, **Severity**, and the **Date** it was first intruduced. We can easily clean this up and dismiss the alert.

3. Click on the **Locations** to see the code that triggered the alert, line **805**.

    ![Image](images/2023-06-27_13-59-37.png =900x)

```csharp
console.log(chalk.white(JSON.stringify(profile, null, 2)));
```

### Dismissing Alert
Code scanning you may encounter errors in the history of code scanning results. Resolving errors in the history typically involves investigating the specific errors reported and taking appropriate actions to address them. You can follow these steps to dismiss the alert.

2. Click the browser **Back** button to return to the **_Clear-text logging of sensitive information_** alert to see how we easily dismiss it.

3. Click on **Close alert** to dismiss the alert, and select **Risk Accepted**, then click **Close**.

    ![Image](images/2023-06-24_11-23-38.png =300x)

    > Note: This only dismisses the alert for your selected branch. Other branches that contain the same vulnerability stay active until dismissed.

4. Let's run the **tailwindtraders-codescanning** build to scan the repo again. Click on **Pipelines**, click **tailwindtraders-codescanning**, the click **Run Pipeline**.

5. Once the build completes, go to the **Azure DevOps Advanced Security dashboard** and click on **Code scanning**.

6. You will see that the alert **_Clear-text logging of sensitive information_** no longer exists, as it is now revoked.

## Lab 3: Resolution of Code Scanning Alerts (Fix Leak)
GitHub Advanced Security for Azure DevOps code scanning alerts include code scanning flags by repository that alert of code-level application vulnerabilities. Code scanning alerts are aggregated per repository and are available in the Advanced Security tab under Repos.

### Reviewing Alerts
1. Go to the **Repos** tab and click on the **Advanced Security** menu item on the bottom.
2. Click on **Code scanning** to see a list of all alerts that have been found. This includes the **Alert** and **First detected** date.

    ![Image](images/2023-06-23_14-04-23.png =900x)

3. Click on **_SQL query built from user-controlled sources_** to see more details about the alert and what you can do to clean up the secret.

2. Notice this includes the **Recommendation**, **Locations** found, **Remediation Steps**, **Severity**, and the **Date** it was first intruduced. Following the steps can resolve the alert, allowing it to be dismissed.

    ![Image](images/2023-06-27_14-08-35.png =900x)

5. Review the **Recommendation**, **Example**, and **Locations** to understand the issue and how to resolve it.

**ProTip!** By parameterizing the query and using placeholders, this adapted code helps prevent SQL injection by treating the values as parameters rather than directly concatenating them into the query.

### Resolving Alerts
1. This is simple to fix using the method **use parameters with dynamic SQL** described in the **Remediation steps**.

    > Note: SQL injection is consistently ranked among the top vulnerabilities in web applications. It is considered a high-priority issue due to its potential to cause significant damage and compromise the security of an application and its underlying data.

2. Click on **Locations found** to see the code that triggered the alert.

    ![Image](images/2023-06-23_14-18-59.png =800x)

3. Click on the **Edit** button to edit the file. Replace line **17** with the following code:

    ```csharp
    string query = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
    ```

4. Add the following two lines of code right after line **21**:

    ```csharp
    command.Parameters.AddWithValue("@username", username);
    command.Parameters.AddWithValue("@password", password);
    ```

<details>
<summary>Solution</summary>

```csharp
        public bool AuthenticateUser(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE Username = @username AND Password = @password";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Close();
                        return true;
                    }

                    reader.Close();
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

```

</details>

5. Click **Commit** to save changes.  Enter **SqlInjectionFix** for branch name and check **Create a pull request**, then click **Commit** again.

    > Note: This step is necessary since the main branch is protected by a pull request pipeline.

    ![Image](images/2023-06-23_14-25-00.png =450x)

6. Click **Create** on the New pull request page to merge the changes into the main branch.

    ![Image](images/2023-06-23_14-36-29.png =700x)

7. This will run the **tailwindtraders-pullrequests** pipeline and validate the changes.

8. Once the pipeline has completed, click **Approve** and **Complete**

9. Change **Merge Type** to **Squash commit** and check box **Delete SqlInjectionFix after merging**, to merge changes into the main branch.

    ![Image](images/2023-06-23_14-52-52.png =400x)

    > Note: The build will run automatically, initiating the code scanning task and publishing the results to Advanced Security.

### Dismissing Alert
Code scanning you may encounter errors in the history of code scanning results. Resolving errors in the history typically involves investigating the specific errors reported and taking appropriate actions to address them. You can follow these steps to dismiss the alert.

1. Once the pipeline **tailwindtraders-build.yml** and **tailwindtraders-codescanning** have completed, go to the **Azure DevOps Advanced Security dashboard** and click on **Code scanning**.

    > Note: The build will run automatically, initiating the secret scanning task, publish the results to Advanced Security, and alert will automatically closed. However, the exposed issue will still be in the history and must be dismissed.

2. Click on the following item, **_SQL query built from user-controlled sources_** to see the alert and how we easily dismiss it.

3. Click on **Close alert** to dismiss the alert, and select **Revoked**, then click **Close**.

    ![Image](images/2023-06-24_08-15-20.png)

    > Note: Once the code is merged into main, GHAzDO starts off a background scan of this repo and looks for exposed credentials.  The scan doesn't just look at tip of main either, since attackers would look through all the branches and entire commit history.

5. Go to the **Azure DevOps Advanced Security dashboard** and click on **Code scanning**, you will see a list of all the exposed Secrets alerts that have been found.

6. You will see that the alert **_SQL query built from user-controlled sources_** no longer exists, as it is now revoked.

**ProTip!** Anyone with contributor permissions for a repository can view a summary of all alerts for a repository but only project administrators can dismiss Advanced Security alerts.

>Note: Code Scanning queries are open source, so you can view and contribute to the queries in the https://github.com/github/codeql repository.

## Congratulations you've made it to the end! &#x1F389;

### References

- [GitHub Advanced Security for Azure DevOps, Code Scanning](https://learn.microsoft.com/en-us/azure/devops/repos/security/configure-github-advanced-security-features?view=azure-devops&tabs=yaml#set-up-code-scanning)

- [CodeQL query help for C#](https://codeql.github.com/codeql-query-help/csharp/)

- [Browsing security advisories in the GitHub Advisory Database](https://docs.github.com/en/code-security/security-advisories/global-security-advisories/browsing-security-advisories-in-the-github-advisory-database)

- [Open source repository containing the standard CodeQL libraries and queries](https://github.com/github/codeql)

- [Azure DevOps - Extra Setting up self-hosted agents](https://learn.microsoft.com/en-us/azure/devops/repos/security/configure-github-advanced-security-features?view=azure-devops&tabs=yaml#set-up-code-scanning)