---
title: Working with the Microsoft Visual Studio DevOps (Winter Update) Virtual Machine
layout: page
sidebar: tfs
permalink: /labs/devopsserver/started/
folder: /labs/devopsserver/started/
updated: blank
---
## Overview

The Microsoft® Visual Studio® ALM/DevOps Virtual Machine is a single virtual machine image that contains fully installed and configured copies of the software listed below. This virtual machine requires Hyper-V, and can be used with Windows Server 2008 R2 SP1, Windows 8 (SLAT-capable processor required)/Windows Server
2012, Windows 8.1/Windows Server 2012 R2, Windows Server 2016, or Windows 10. The detailed instructions in this document assume that you are using Windows 10, although the instructions are similar for other operating systems.

The 2019 (Winter Update) virtual machine contains the following pre-configured software:

1. Microsoft Windows Server 2016 Standard Evaluation

2. Microsoft Visual Studio Enterprise 2019 (16.0.0)

3. Microsoft Azure DevOps Server 2019

4. Microsoft Office Professional Plus 2016 (Word, PowerPoint, Excel, Outlook)

5. Microsoft SQL Server Standard 2017

6. Sample users and data required to support hands-on-lab scripts which accompany this download.

## Activation

The virtual machine requires online activation if you wish to use it
more than 10 days. For this to occur, your VM will need to be connected
to a virtual network that has Internet access. We strongly recommend
that you only connect this virtual machine to the Internet temporarily
and promptly disable Internet access once activation is complete. Please
refer to the section “Configure this Virtual Machine with Hyper-V” below
for more information.

## Expiration

If you choose to activate your virtual machine, it will begin a 180-day
trial of Windows Server 2012 Standard Evaluation. After the 180 days is
over you will need to stop using this virtual machine.

## Rollback

It is strongly recommended that you implement a rollback strategy for
restoring this virtual machine to a previous point in time. This is
helpful in case you make a mistake, or if you want to reset the state of
the original sample data contained within this virtual machine. Hyper-V
uses a concept called checkpointing. The hands-on-labs which were built
for use with this virtual machine were tested using a “clean” state of
the virtual machine; therefore it is recommended that you restore to a
clean checkpoint before you start each hands-on-lab. See the section
titled “Working with Checkpoints” below for more information.

## Labs/Demo Scripts

A set of hands-on-lab documents, which also function as demo scripts,
are available for download along with this virtual machine. The latest
version of these documents can be downloaded from
[here](http://aka.ms/almvm). These hands-on-labs provide a guided
experience for you to learn about the new application lifecycle
management capabilities of Visual Studio 2019, as well as application
lifecycle management features which have been introduced since Visual
Studio 2010.

## Recommended System Configuration

You will want to provide as much RAM as possible to this virtual
machine. A minimum of 8GB is suggested. But you should not allocate all
of your physical memory to a virtual machine or you can “starve” your
host machine of the RAM it needs to complete other tasks. For example,
if you have 16GB of physical memory on your computer then a good
allocation for your virtual machine might be 12GB. This can be a process
of trial and error.

By default, when you import this virtual machine it will be configured
with a certain amount of RAM and number of virtual processors. If you
have the necessary hardware, you can increase this allocation after the
import step by using the Hyper-V console and accessing the settings for
this virtual machine.

If you have more than one hard drive, place the VHD file on a physical
drive that is different from your system drive. Use the drive with the
faster spindle rate if it is a mechanical drive or use an SSD drive. If
you use an external hard drive, faster interfaces such as eSata or
Firewire 800 will work better. Be careful with slower laptop drives and
USB 1.1 interfaces.

<table style="width:100%; background: aliceblue;">
   <tr>
      <th class="text_center">Test</th>
      <th class="text_center">Requirement for Hyper-V Host Machine</th>
   </tr>
   <tr>
      <td >Operating System</td>
      <td class="text_center">Microsoft Windows® Server 2008 R2 with the Hyper-V role enabled
         <br>Microsoft Windows® Server 2012 with the Hyper-V role enabled
         <br>Microsoft Windows® 8 with Hyper-V enabled
         <br>Microsoft Windows® 8.1 with Hyper-V enabled
         <br>Microsoft Windows® Sever 2012 R2 with Hyper-V enabled
         <br>Microsoft Windows® 10 with Hyper-V enabled
         <br>Microsoft Windows® Sever 2016 with Hyper-V enabled
      </td>
   </tr>
   <tr>
      <td >Drive Formatting</td>
      <td class="text_center">NTFS</td>
   </tr>
   <tr>
      <td>Processor</td>
      <td class="text_center">Intel VT or AMD-V capable, *SLAT-capable CPU required if using Windows 8*</td>
   </tr>
   <tr>
      <td>RAM</td>
      <td class="text_center">8 GB of free physical RAM (9 GB or more recommended)</td>
   </tr>
   <tr>
      <td>Hard disk space required for install</td>
      <td class="text_center">80 GB (more if using checkpoints)</td>
   </tr>
</table>

## How to Log In

Select the user you want to log in as and the password box will appear.
All accounts use the same password: **P2ssw0rd** (capital letter P, the
number two, the letter s, the letter s, the letter w, the number zero,
the letter r, and the letter d).

## Configuring the Virtual Machine with Hyper-V

This section lists the tasks that you must perform using a server with
the Hyper-V role enabled.

<table style="width:100%; border-collapse:collapse; table-layout:fixed; background: aliceblue;">
   <tr>
      <th></th>
      <th></th>
   </tr>
   <tr >
      <td >
         <p>1. Import and configure the Virtual Machine</p>
         <p>Due to the activation and expiration models in Windows Server, it’s highly
            recommended that you do one of the following:
            - Retain a copy of the unaltered VM 
            - Create and retain a checkpoint from before first run of the VMs
         </p>
      </td>
      <td>
         <p>a. Under <b>Actions</b>, click <b>Import Virtual Machine</b></p>
         <p>b. If you are going to import to a Windows Server 2008 R2 machine, move the VHD file from the WMIv2\\Virtual Hard Disks folder to the WMIv1\\Virtual Hard Disks folder</p>
         <p>c. Use the <b>Browse</b> button to select the folder where the virtual machine package was extracted. Keep default settings. Browse to either the <b>“WMIv1”</b> or “<b>WMIv2”</b> folder depending upon if you are going to import to Server 2008 R2 or Windows8.1/Server 2012 R2 (or later), respectively</p>
         <p>d. Click <b>Select Folder</b> when you have browsed to this path.
            <br><img src="media/image1.png" style="height: 260px;"/>
            <br><img src="media/image2.png" style="height: 215px;"/>
         </p>
         <p>e. Click <b>Next</b> through each remaining page of the import wizard, then <b>Finish</b>, and wait for the import operation to complete.</p>
         <p>f. The new virtual machine will show up in your Virtual Machines list.</p>
         <p>g. Optionally, you can right-click this virtual machine to configure various <b>Settings.</b> For example you may wish to increase the number of virtual processors (depending on your hardware) or adjust the amount of RAM allocated to this virtual machine. Read the “Recommended System Configuration” section above for tips about RAM allocation.</p>
         <p>h. <b>Start</b> the virtual image.</p>
         <p>i. Once the machine starts, log in as <b>Sachin</b>. All passwords are <b>P2ssw0rd</b>.</p>
         <p>j. After you login it may take a few minutes to finish the configuration install new drivers. Once done, you may be prompted to reboot.</p>
         <p>k. After reboot the machine is ready to use.</p>
      </td>
   </tr>
   <tr>
      <td>
         <p>2. Activate the operating system.</p>
         <p>This step should be automatic once you connect the VM to the Internet.</p>
      </td>
      <td>
         <p>a. Open the Hyper-V Manager on the host.</p>
         <p>b. Select the VM in the Virtual Machines pane</p>
         <p>c. Click Settings in the Actions pane.</p>
         <p>d. Configure the network adapter to use an external network adapter. *(For information on how to configure an external network adapter with Hyper-V please consult the Hyper-V documentation)*</p>
         <p>e. Your settings should resemble the following screenshot (the actual name of your external network may vary)</p>
         <img src="media/image3.png" style="height:325px; padding-left: 10px;"/>
         <p>f. Click OK to close the settings dialog.</p>
         <p>g. <b>Start</b> the virtual machine if it isn’t already running.</p>
         <p>h. Once the machine starts, log in as <b>Sachin</b>. All passwords are <b>P2ssw0rd</b>.</p>
         <p>i. Typically, you can simply give the guest OS a few minutes in order to automatically activate the 180 day trial, but you can always double-check in the Control Panel.</p>
         <p>j. From the Start menu, open the <b>Control Panel</b>.</p>
         <p>k. Double-click on the <b>System</b> control panel applet.</p>
         <p>l. If necessary, click on <b>Activate Windows Now</b> at the bottom of the System applet.</p>
         <p>m. Click on <b>Activate Windows online now</b>. If you have successfully enabled Internet access for your virtual machine then this step should just take a few moments.</p>
         <p>n. Your virtual machine will now remain active for up to 180 days from this point in time. You can confirm this by looking at the bottom of the System control panel applet.</p>
         <p>o. Proceed to step 3 below to configure your virtual machine for use with an <b>internal</b> network adapter. Step 3 is very important since there is no active virus protection software on this virtual machine, and it may not contain the latest security patches, so you shouldn’t leave this virtual machine in an Internet-facing state.</p>
      </td>
   </tr>
   <tr>
      <td>3. Configure an internal network adapter</td>
      <td>
         <p>a. Open the <b>Hyper-V Manager</b> on the host.</p>
         <p>b. Select the VM in the Virtual Machines pane.</p>
         <p>c. Click <b>Settings</b> in the Actions pane.</p>
         <p>d. Configure the network adapter to use an internal network adapter. *(For information on how to configure an external network adapter with Hyper-V please consult the Hyper-V documentation)*</p>
         <p>e. Your settings should resemble the following screenshot (the actual name of your internal network may vary)</p>
         <img src="media/image4.png" style="height:325px; padding-left: 10px;"/>
         <p>f. Click OK to <b>close</b> the settings dialog.</p>
         <p>g. It is highly recommended that you now take a checkpoint of the virtual machine so that you can return to this state later if you need to. See “*Working with Checkpoints*” below for more information.</p>
      </td>
   </tr>
</table>

## Working with Checkpoints

Hyper-V introduces the concept of “checkpoints” which can be used to revert a virtual machine to a previous configuration state. The
hands-on-labs which were built for use with this virtual machine were tested for use with a “clean” state of the virtual machine; it is
recommended that you restore to a clean checkpoint before you start each hands-on-lab. As delivered, this virtual machine does not include any
checkpoints.
<table style="background: aliceblue;">
    <tr>
        <th class="text_center">Tasks</th>
        <th class="text_center">Detailed Steps</th>
    </tr>
    <tr>
        <td><p>1. Create a Checkpoint</p></td>
        <p>Note that having many checkpoints can adversely affect performance. You can delete checkpoints you no longer need and Hyper-V will merge these when the VM is not running.</p>
        <td class="text_center">
            <p>a. Prepare the VM(s) in the state you wish to capture.</p>
            <p>b. Open or return to the Hyper-V Manager</p>
            <p>c. Select the VM and click Checkpoint under Actions.</p>
            <p>d. Wait for the checkpoint captures to complete.</p>
            <p>e. (optional) Right-click a checkpoint to rename it.</p>
        </td>
     </tr>   
    <tr>
        <td>2. Apply a Checkpoint</td>
        <td class="text_center"><p>a. Open or return to the Hyper-V Manager</p>
        <p>b.Select the VM, right-click on the checkpoint you wish to use, and choose Apply. You will be prompted to save the current state as a checkpoint. Doing so will retain your current state, skipping will discard it.</p></td>
    </tr>
</table>

## Date and Time

Previous versions of this virtual machine were hard-coded to boot up
with a specific demo date that was in the past. This updated version of
the virtual machine will match the real-world date and time by default,
eliminating many of the headaches associated with being disconnected
from the real-world date. Only one lab requires the date to be set
specifically to a certain demo date (the Agile Planning and Portfolio
Management lab), and instructions for how to do this are provided at the
beginning of that lab.

## Feedback

If you have comments or general feedback, please e-mail [devopsdemos@microsoft.com](mailto:devopsdemos@microsoft.com).
