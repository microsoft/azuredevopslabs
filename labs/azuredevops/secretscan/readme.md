---
title: Secret Scanning with Azure DevOps
layout: page
sidebar: vsts
permalink: /labs/azuredevops/secretscan/
folder: /labs/azuredevops/secretscan/
version: Lab version - 1.37.1
updated: Last updated - 22/07/2024
---
<div class="rw-ui-container"></div>
<a name="Secret Scanning"></a>

<a name="Ex0Task1"></a>
## Prerequisites ##
In this exercise, you will set up the **Tailwind Traders** project in Azure DevOps to explore the features on GitHub Advanced Security for Azure DevOps (GHAzDO). Complete the following steps to set up the Tailwind Traders project in Azure DevOps from [prerequisites](../prereq-ghas/readme.md).

## Getting Started

If you followed **Module 0 - Setup and Automation** you will have already enabled **_GitHub Advanced Security for Azure DevOps_**, **_Secret Scanning_**, and **_Push Protection_** at the repository level.

Once this is enabled, navigate to https://dev.azure.com/mstechbootcamp/, select your team project **tp-<**yourgithubhandle**>**, and select the **TailwindTraders** repository to begin working through this module.

------
## Contents

- [Lab 1: Secret Scanning Alerts](#lab-1-secret-scanning-alerts)
- [Lab 2: Protection of Repositories](#lab-2-protection-of-repositories)
- [Lab 3: Resolution of Secret Detections](#resolution-of-dependency-detections)
------

## Overview of Secret Scanning
Secret Scanning scans your codebase and other resources to identify potential secrets that may have been inadvertently committed and provides alerts to mitigate the risk of exposure. Push protection also prevents any credentials from being leaked in the first place.

Once this is toggled on, it starts off a background scan of this repo and look for exposed credentials.  The scan doesn't just look at tip of main, since attackers would look through all the branches and entire commit history.

## Lab 1: Secret Scanning Alerts (Gain Insights)
The Advance Security Alert hub is where all alerts are raised and where we gain insights, specifically under the category of **Secrets**. When a secret is found, you can click on it to access more information. The secret may be located in different places, including various commits.

### Secrets Review
1. Go to the **Repos** tab and click on the **Advanced Security** menu item on the bottom.
2. Click on **Secrets** to see a list of all the exposed Secrets alerts that have been found.  This includes the **Alert** and **Introduced** date.

    ![Image](images/2023-06-21_14-31-01.png =650x) 

3. Click on **_Microsoft Azure CosmosDB identifiable master key..._** to see more details about the alert and what you can do to clean up the secret.

4. Notice this includes the **Recommendation**, **Locations** found, **Remediation Steps**, **Severity**, and the **Date** it was first intruduced. We can easily clean this up and dismiss the alert.

    ![Image](images/2023-06-24_16-35-54.png =650x) 

## Lab 2: Protection of Repositories (Stop the Leak)
Once a credential touches the repo, it's too late. Hackers might have already exploited it. The only way forward is to eliminate these leaks permanently and to find all the place they're actually being used in production.

> Note: **Good news**, GHAzDO focuses on preventing this in the first place.  **Bad news**, these need to be manually fixed. There isn't an Easy Button.

### Push Protection
Push Protection helps protect your repository by preventing unauthorized or malicious code from being pushed to your repository's branches.

### Updating Secrets
You can follow these steps to update a file.

1. While viewing the alert details, click on the line of code, **_appsettings.json_**.

    ![Image](images/2023-06-21_14-39-26.png =550x) 

2. Click **Edit** to edit the file.  This will open up the code editor and highlight the exact location of the secret. In this case, it's in the **.json** file.

3. On **line 31**, update the **MongoConnectionString** to use the correct server name **"ghazdoservername:"**. Be sure to ONLY replace server name and NOT the entire connection string.

    ```json
        "MongoConnectionString": "mongodb://ghazdoservername:..."
    ```

4. Click **Commit** to save changes.  Enter **fixsecret** for branch name and check **Create a pull request**, then click **Commit** again.

5. The commit was rejected because the repository has both secret and branch protection enabled.  This is a good thing!  It's preventing us from checking in the exposed secret.  Let's fix this.

    ![Image](images/2023-06-21_16-09-57.png =450x)    

    > Note: the code went up to the server, analyzed, then rejected, not stored anywhere.  Using Secret push scanning, it catches secrets right before it becomes a problem.

**ProTip!** This can't happen during a Pull Request. Once the code has pushed into topic branch, it's too late. PR analysis is best for dependency scanning but not secret push scanning, they are different.

### Fixing Exposed Secrets
You can follow these steps to fix the exposed secret.

1. Click **Cancel** to return to the code editor.

    > Note: This scenerio is all too common.  A developer is testing an applicatioin locally and needs to connect to a database, so what do they do?  Of course, just put the connection string in the **appsettings.json** file.  They forget to remove it before checking in the code.  Now the secret is exposed in the repo, and not just the tip. The exposed credential will still be in the history.  This is a huge security hole!

2. On **line 31**, change the **MongoConnectionString** to be empty **""**.

    ```json
        "MongoConnectionString": ""
    ```

3. Click **Commit** to save changes.  Enter **fixsecret** for branch name and check **Create a pull request**, then click **Commit** again.

    > Note: This step is necessary since the main branch is protected by a pull request pipeline.

4. Click **Create a pull request** to merge the changes into the main branch.

    ![Image](images/2023-06-23_12-28-07.png =550x)       

5. Click **Create** on the New pull request page.

6. This will run the **tailwindtraders-pullrequests** pipeline and validate the changes.

7. Once the pipeline has completed, click **Approve** and **Complete**

8. Change **Merge Type** to **Squash commit** and check box **Delete fixsecret after merging**, to merge changes into the main branch.

    ![Image](images/2023-06-23_08-44-13.png =450x)       

    > Note: The build will run automatically, initiating the dependency scanning task and publishing the results to Advanced Security and alert automatically closed.

### Dismissing Alert
You can follow these steps to dismiss the alert.

1. Once the pipeline **tailwindtraders-build.yml** has completed, go to the **Azure DevOps Advanced Security dashboard** and click on **Secrets**.

2. Click on the following item, **_Microsoft Azure CosmosDB identifiable master key..._** to see the exposed secret an how we easily dismiss the alert.

3. Click on **Close alert** to dismiss the alert, and select **Revoked**, then click **Close**.

    ![Image](images/2023-06-21_15-01-17.png =300x)  

    > Note: Once the code is merged into **main**, GHAzDO starts off a background scan of this repo and looks for exposed credentials.  The scan doesn't just look at tip of main either, since attackers would look through all the branches and entire commit history.

5. Go to the **Azure DevOps Advanced Security dashboard** and click on **Secrets**, you will see a list of all the exposed Secrets alerts that have been found.

6. You will see that the alert **_Microsoft Azure CosmosDB identifiable master key..._** no longer exists, as it is now revoked.

<details>
<summary>Summary</summary>
Exposed credentials pose a significant security risk, as they are responsible for major security breaches.  As a developer, it is crucial to take responsibility for fixing these issues rather than ignoring them.  Once a credential is present in a repository, it may have already been exploited by hackers.  The only effective solution is to permanently eliminate these leaks.  It is essential to locate all the instances where the credentials are being used in production systems.  This requires actively identifying and replacing each occurrence with a new credential to ensure complete elimination of the compromised credentials.
</details>

## Lab 3: Resolution of Secret Detections (Fix Issues)
When a secret is detected in a repository, it is important to take prompt action to remediate the issue and ensure the security of your codebase.

> Note: To keep this example simple, we're going to make 2 code changes for 1 Pull Request in 1 feature branch.  In a real-world scenario, you would want to make 2 separate Pull Requests or use an IDE to make all the changes at once.

1. Click **Repos**, click **Branches**, click **New branch**, enter **fixsecret** for the branch name, and click **Create**.

2. Go to the **Azure DevOps Advanced Security dashboard** and click on **Secrets**, you will see a list of all the exposed Secrets alerts that have been found.  This includes the **Alert**, **Introduced** date.

3. Click on the following item, **_Azure Logic App SAS_** to see the exposed secret and what we can do to clean up the secret. This includes the **Recommendation**, **Locations** found, **Remediation Steps**, **Severity**, and the **Date** it was first intruduced.

    ![Image](images/2023-06-21_15-25-27.png =700x)  

4. Click on the **Locations** to see the code that triggered the alert.

    ![Image](images/2023-06-21_15-53-50.png =500x)  

5. This will show you the code that triggered the alert.

6. On line **262**, hightlight the untire URL between the **""** and cut-in-paste into Notepad to save the URL, we'll need it later.

7. Replace the URL with **#{SASURL}#** between the quotes to look like this.

    ```html
        "url": "#{SASURL}#"
    ```
    > Note: This token will be replaced with the actual value during the build process.

10. Click **Commit** to save changes.  Confirm **fixsecret** for branch name, then click **Commit** again.

11. Next, we need to update the build pipeline to add a variable.  Click on **Pipelines** and click on **tailwindtraders-build.yml**.

12. Click on **Edit** to edit the pipeline. Change to the **fixsecret** branch.

    ![Image](images/2023-06-23_12-20-30.png =500x)      

13. Click on **Variables** and click **+ New Variable**. Enter **SASURL** for the name and paste the URL from Notepad into the value field.

    ![Image](images/2023-06-23_13-44-04.png =400x)  

14. Click **Keep this value secret** to hide the value, then click **Ok** and **Save**.

15. Next we need to edit the pipeline and add a new build task to replace the **#{SASURL}#** with the actual value.

16. While still in edit mode, add the following task between **Restore** and **Build** tasks, around line **40**.  This will replace the **#{SASURL}#** with the actual value in the **_TailwindTradeBot.dialog_** file.

    ```yaml
    - task: qetza.replacetokens.replacetokens-task.replacetokens@3
      inputs:
        targetFiles: '**/*.dialog'
        encoding: 'auto'
        tokenPattern: 'custom'
        tokenPrefix: '#{'
        tokenSuffix: '}#'
        verbosity: 'detailed'
        keepToken: false
    ```
    <details>
    <summary>Solution</summary>

    ```yaml
    - task: DotNetCoreCLI@2
        displayName: Restore
        inputs:
        command: restore
        projects: '$(Parameters.RestoreBuildProjects)'

    - task: qetza.replacetokens.replacetokens-task.replacetokens@3
      inputs:
        targetFiles: '**/*.dialog'
        encoding: 'auto'
        tokenPattern: 'custom'
        tokenPrefix: '#{'
        tokenSuffix: '}#'
        verbosity: 'detailed'
        keepToken: false

    - task: DotNetCoreCLI@2
        displayName: Build
        inputs:
        projects: '$(Parameters.RestoreBuildProjects)'
        arguments: '--configuration $(BuildConfiguration)'

    ```
    </details>

17. Select **Commit directly to the fixsecret branch**, then click **Save**.

    ![Image](images/2023-06-23_12-24-59.png =400x)  

18. Once the commit is saved, click on **Repos**, click **Pull Requests**, and click **Create a pull request** to merge the changes from branch **fixsecret** into branch **main**.

    ![Image](images/2023-06-23_12-28-07.png =550x)  

19. For the Title, enter **Fixed secret by adding a build token**, and click **Create**. This will run the **tailwindtraders-pullrequests** pipeline to validate changes.

20. Once the **tailwindtraders-pullrequests** pipeline has completed, click **Approve** and **Complete**.

21. Change **Merge Type** to **Squash commit** and check box **Delete fixsecret after merging**, to merge changes into the main branch.

    ![Image](images/2023-06-23_08-44-13.png =400x)  

**ProTip!** Squash Merge is important. If we just commit, the exposed credential will still be in the history. To avoid this, fix code, use a Squash Merge, push it to repo, and you're done!

> Note: The build will run automatically, initiating the secret scanning task, publish the results to Advanced Security, and alert will automatically closed. However, the exposed issue will still be in the history and must be dismissed.

### Dismissing Alert
You can follow these steps to dismiss the alert.

1. Once the pipeline **tailwindtraders-build.yml** has completed, go to the **Azure DevOps Advanced Security dashboard** and click on **Secrets**.

2. Click on the following item, **_Azure Logic App SAS..._** to see the exposed secret an how we easily dismiss the alert.

3. Click on **Close alert** to dismiss the alert, and select **Revoked**, then click **Close**.

    ![Image](images/2023-06-21_15-01-17.png =300x) 

    > Note: Once the code is merged into **main**, GHAzDO starts off a background scan of this repo and looks for exposed credentials.  The scan doesn't just look at tip of main either, since attackers would look through all the branches and entire commit history.

4. Go to the **Azure DevOps Advanced Security dashboard** and click on **Secrets**, you will see a list of all the exposed Secrets alerts that have been found.

5. You will see that the alert **_Azure Logic App SAS..._** no longer exists, as it is now revoked.

> Note: Anyone with contributor permissions for a repository can view a summary of all alerts for a repository but only project administrators can dismiss Advanced Security alerts.

<details>
<summary>Supported Secrets</summary>

### Supported Secrets
The table provides information on the secrets supported by secret scanning. It lists the token provider's name and specifies the type of alert generated for each token. The "User" column indicates tokens for which leaks are reported to users after a push, specifically for repositories with GitHub Advanced Security enabled. The "Push protection" column indicates tokens for which leaks are reported to users upon push, specifically for repositories with both secret scanning and push protection enabled.

![Image](images/2023-06-12-154929.png =550x) 

> Note: For entire list, see [Supported Secrets](https://learn.microsoft.com/en-us/azure/devops/repos/security/github-advanced-security-secret-scanning?view=azure-devops#supported-secrets)

</details>

## Congratulations you've made it to the end! &#x1F389;

And with that, you've now concluded **Module 2: Secret Scanning**. You can now move on to your next module (in most cases that will be **Module 3: Code Scanning**).

### References

- [GitHub Advanced Security for Azure DevOps, Secret scanning](https://learn.microsoft.com/en-us/azure/devops/repos/security/github-advanced-security-secret-scanning?view=azure-devops)

- [GitHub Advanced Security for Azure DevOps, Push protection](https://learn.microsoft.com/en-us/azure/devops/repos/security/github-advanced-security-push-protection?view=azure-devops)

- [Replace Tokens task](https://github.com/qetza/vsts-replacetokens-task/tree/master/tasks/ReplaceTokensV3)

