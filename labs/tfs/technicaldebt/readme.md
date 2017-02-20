---
title: Managing Technical Debt with Team Foundation Server 2017 and SonarQube
layout: page    
sidebar: tfs
permalink: /labs/tfs/technicaldebt/
folder: /labs/tfs/technicaldebt/
---

**Overview**

In this lab, you will be introduced to Technical debt, how to configure your Team Build Definitions to use SonarQube, how to understand the analysis results and finally how to configure quality profile to control the rule set used by SonarQube for analyzing your project.

Technical debt is the set of problems in a development effort that make forward progress on customer value inefficient. Technical debt saps productivity by making code hard to understand, fragile, time-consuming to change, difficult to validate, and creates unplanned work that blocks progress. Technical debt saps an org's strength due to high costs in customer support, and, eventually, some combination of these issues creates a larger problem that someone runs into. Technical debt is insidious.  It starts small and grows over time through rushed changes, lack of context and lack of discipline.  It can materialize out of nowhere even for a project regarded as clean at some point in time, due to a change in project circumstances: prototype code may be promoted to serve as the basis for a feature; code produced for the U.S. market may be proposed for international, instantly creating debt related to localizability; technologies evolve, but the app doesn’t keep up.

> SonarQube is an open source platform for understanding and managing technical debt, it provides different ways to analyze and measure technical quality from project portfolio to method.

### Pre-requisites



 **Exercise 1: Exercise 1: Install and Configure SonarQube and SonarQube MSBuild Runner**
