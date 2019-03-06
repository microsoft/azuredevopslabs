---
title: Using secrets from Azure Key Vault in a pipeline
layout: page
sidebar: vsts2
permalink: /labs/vstsextend/azurekeyvault/
folder: /labs/vstsextend/azurekeyvault/
---

<div class="rw-ui-container"></div>

## Overview 
Azure Key Vault helps teams to securely store and manage sensitive information such as keys, password, certificates, etc. in a centralized storage which are safeguarded by industry-standard algorithms, key lengths, and even hardware security modules. This prevents information exposure through source code,  a common mistake that many developers make. Many developers leave sensitive information such as database connection strings, passwords, private keys, etc. in their source code which when gained by malicious users can result in undesired consequences. Access to a key vault requires proper authentication and authorization and with RBAC, teams can have even fine granular control who has what permissions over the sensitive data.

## What’s covered in this lab
In this lab, you will see how you can use Azure Key Vault in a pipeline

1. We will create a key vault, from the Azure portal, to store a MySQL server password
1. We will configure permissions to let a service principal to read the value
1. We will retrieve the password in an Azure pipeline and passed on to subsequent tasks

### Before you begin

1. Refer the [Getting Started](../Setup/) page before you begin following the exercises.
1. Fork the [**SmartHotel360-CouponManagement**](https://github.com/Microsoft/SmartHotel360-CouponManagement) repository to your GitHub account


### Creating a service principal 

1. We will be using a service principal for authentication. If you do not already have a service principal, you can create one.

1. Login to the [**Azure Portal**](https://portal.azure.com) 

1. Open the Azure cloud shell. Select **Bash** when prompted to choose shell.

1. Enter the following command replacing the ***service principal*** and ***password*** with your desired values. 

Because data in the Key Vaults are sensitive and business critical, you need to secure access to your key vaults by allowing only authorized applications and users. To access the data from the vault, you will need to provide read (Get) permissions to the service principal that you will be using for authentication in the pipeline. 

Azure Pipelines uses security principal for authentication and t

### Creating a KeyVault

1. Enter "Key vault" in the search field and press enter. Select **Key Vaults**

1. Select **Add** and create a new key vault


