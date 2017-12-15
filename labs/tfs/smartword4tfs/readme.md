---
title: Introduction to the Modern Requirements Suite4TFS & Team Foundation Server 2017
layout: page    
sidebar: tfs
permalink: /labs/tfs/smartword4tfs/
folder: /labs/tfs/smartword4tfs/
---

Lab version: 14.0.25123

Last updated: 2/23/2017

## Overview

The Modern Requirements Suite4TFS provides a collaborative platform
    based on ‘a single source of truth’, while automating each phase of
    your requirements lifecycle. The user interface is Microsoft Office
    or, SmartOffice4TFS, ensuring that you, and your new recruits, can
    start enjoying the benefits quickly. You can also use the browser
    based interface, inteGREAT4TFS. Microsoft’s industry leading TFS /
    VSTS is the requirements database, with optional extensions
    supporting your end to end ALM process. Whether you deploy it on
    premises or in the Azure cloud, it provides the security,
    scalability and workflow management clients’ demand; while
    supporting Agile, Waterfall or Hybrid methodologies.

In this lab, you will learn about scrum management using the Modern
    Requirements Suite4TFS modules and augmented by Team Foundation
    Server 2017 and how these tools can help you to quickly track work
    across your entire team.

## Pre-requisites

In order to complete this lab, you will need SmartWord4TFS,
    inteGREAT4TFS and the Visual Studio ALM Virtual Machine 2017  provided
    by Microsoft. For more information about the Modern Requirements
    Suite4TFS products, please visit [this
    URL](http://www.modernrequirements.com/). The information about
    acquiring and using the Visual Studio 2017 virtual machine is
    available [here](http://aka.ms/VS15ALMVM).

> **Important note:** This lab requires you to use the default state of the virtual machine, before any modifications are made to work items or source in TFS. If you followed the “Working With…” instructions, you should have a snapshot/checkpoint of the virtual machine before working with it for the first time. Apply the snapshots/checkpoints before starting this lab.

## Installing SmartWord4TFS

1. Go to the following link :
    <http://www.modernrequirements.com/application-lifecycle-management-virtual-machine/>

2. Please submit the online registration form and click submit to
    download button (refer to the screen shot).

    <img src="media/130.png" width="538" height="358" />

3. You will be navigated to the download page.

4. Click on **SmartWord4TFS web installer (590 KB)**.

    <img src="media/131.png" width="610" height="494" />

    > For system requirements [inteGREAT4TFS installation
    guide](file:///C:\Users\bsavelson\AppData\Local\Microsoft\Windows\INetCache\Content.Outlook\VG0J8XD1\inteGREAT4TFS%20installation%20guide)
    & [SmartWord4TFS installation
    guide](file:///C:\Users\bsavelson\AppData\Local\Microsoft\Windows\INetCache\Content.Outlook\VG0J8XD1\SmartWord4TFS%20installation%20guide)

5. Once the installer is downloaded click the installer to start the
    installation process.

**Installation Process**

The following screenshot shows the online installer.

1.  Run the **SmartWord4TFS.exe** file

    <img src="media/132.png" width="462" height="289" />

2.  Click the **Next** Button to start the installation process.

    <img src="media/133.png" width="432" height="354" />

3.  Read the License Agreement, select **I Agree** option and click the
    **Next** Button.

    <img src="media/134.png" width="434" height="356" />

4.  Set the desired installation location and the relevant user accounts
    then click the **Next** Button.

    <img src="media/135.png" width="433" height="354" />

5.  Select the desired mode (**Author** or **Reviewer**) and click the
    **Next** Button.

    <img src="media/136.png" width="430" height="352" />

6.  Select if the templates are to be installed and then click
    **Next** Button.

    <img src="media/137.png" width="432" height="354" />

7.  Click the **Next** Button to begin copying the files onto
    your system.

    <img src="media/138.png" width="430" height="352" />

8.  The actual installation starts based on selections done in
    previous steps.

    <img src="media/139.png" width="425" height="349" />

9.  Click on the **Close** Button to complete the installation process.

    <img src="media/140.png" width="430" height="352" />

10. The **SmartWord4TFS** Tab (or **SmartWord4TFS Review** Tab if you
    chose to install the **Reviewer Mode**) can now be accessed in
    Microsoft Word.

    <img src="media/141.png" width="625" height="60" />

    >The downloaded version provides 30 days trial period for users to evaluate the application.

11. Click the **About** option in Ribbon Bar **Activate** Button (in the
    **About** window)

    <img src="media/142.png" width="623" height="245" />

    >After submitting the online registration form you will receive the License key for 6 month duration to the provided email address. This software key is provided for non-production use only.

12. Enter the provided Activation key and click **Activate** button.

    <img src="media/143.png" width="493" height="309" />

13. Entering a valid Activation Key activates SmartWord4TFS.

    <img src="media/144.png" width="466" height="296" />

**Installation Process for inteGREAT4TFS**

Download the inteGREAT4TFS installer using the same process described above for SmartWord4TFS.

1. Double click the **inteGREAT4TFS 2017.exe** file.

   <img src="media/145.png" width="643" height="350" />

2. Select the terms and conditions agreement check box and then click
    the **Next** Button.

   <img src="media/146.png" width="431" height="534" />

3. Enter the following Windows credentials and then click the **Next** Button.:

   > Username = **Administrator**  
   > Password = **P2ssw0rd**

   <img src="media/147.png" width="433" height="536" />

   > Application would be installed, even if incorrect windows
    credentials entered during the installation, however user will not be able to login into the application.

4. Configure **Redis Installation** options\* and click the
    **Install** Button.

   <img src="media/148.png" width="463" height="574" />

   > **Auto Install Redis** option is the recommended option if Redis is
      not already installed on the VM.
      The relevant files are installed.

   <img src="media/149.png" width="431" height="535" />

5. Complete the Installation of **inteGREAT4TFS** by clicking the
    **Finish** Button.

    <img src="media/150.png" width="432" height="535" />


-   Please note down the Service URL (highlighted in the above images).
    This would be helpful later on.

-   This completes the installation process of inteGREAT4TFS. After
    installing all SmartOffice4TFS and inteGREAT4TFS modules we can
    proceed to the following exercises.

## Exercise 1: SmartWord4TFS

The templates created in SmartWord4TFS can be distributed to all
stakeholders enabling them to create and manage Work Items from MS-Word
in relevant Team Projects on the Team Foundation Server.

In this exercise we would use an MS-Word template\* to create new Work
Items and publish these Work Items on the Fabrikam Fiber Team Project.

>Refer to **Appendix A** at the end of this file for instructions to
create the template being used in this exercise.

### Task 1: Document Authoring in SmartWord4TFS

1. Open the Word Template (created using **Appendix A**) by
    double-clicking on it.

   <img src="media/129.png" width="643" height="469" />

2. The template with empty Work Item Smart Parts is opened. The
    controls that are used to set Individual properties of any work item
    are called **Smart Parts**. These are used to create new Work Items
    so these can be published on the Team Project.

   <img src="media/128.png" width="497" height="341" />

3. Click the SMARTWORD4TFS Tab.

   <img src="media/127.png" width="643" height="78" />

4. Click the **Choose Team Project** option.

   <img src="media/126.png" width="325" height="144" />

5. Choose **FabrikamFibreCollection** **Fabrikam Fiber** (Team Project)
    click the **Connect** Button.

   <img src="media/125.png" width="542" height="396" />

6. Click inside the **Feature Title** smart part.

   <img src="media/124.png" width="403" height="272" />

7. Enter a suitable name for the Feature Work Item.

   <img src="media/123.png" width="602" height="204" />

   >The ID of a Work Item is automatically given by the connected Team
    Project, when that Work Item is first published on the Team Project therefore we would leave that field for the time being as it would be populated after the Work Item is published.

8. Similarly, enter values in all Smart Parts of the Work Items.

   <img src="media/122.png" width="559" height="411" />

9. Click the **Publish** option in the Ribbon Bar.

   <img src="media/121.png" width="426" height="144" />

   - There is a subtle difference between **Publish** (shown here) and
    **Publish Selected** (accessed through drop down).

   - **Publish** option publishes all Work Items while **Publish
    Selected** only publishes the Work Item whose smart parts are
    selected by the user.

10. Provide any comments (if desired) and click the **Yes** Button.

    <img src="media/120.png" width="427" height="175" />

11. The Work Items are published on the Fabrikam Fiber Team Project.

    <img src="media/119.png" width="603" height="443" />

12. Now add values in the Smart Part of the Bug Work Item.

    <img src="media/118.png" width="579" height="186" />

    - At this moment we have run out of Smart Parts. So far we have been
    using the Smart Parts that came with the template. What if we need
    to add more Work Items? To do this we need to **Insert Smart Part.**  
    

13. Click **Document Authoring** **Insert Smart Part** **Product Backlog
    Item** **Bug**

    <img src="media/117.png" width="545" height="174" />

14. Add values to the new Bug Smart Parts.

    - We now have two Bug Work Items ready to be published. However, in
    order to elaborate the Publish Selected functionality, we would
    publish only one. This is done by first selecting the Smart Parts of
    the desired Bug Work Item.

    - To select the Smart Parts of the desired Work Item, a user may
    select all of the relevant Smart Parts, partially selecting any one
    Smart Part, or even just placing the cursor in any of the Smart
    Parts of that Work Item would also suffice.

15. Place the cursor inside any of the Smart Parts of the Bug that we
    created in Step 6.

    <img src="media/116.png" width="603" height="215" />

16. Click **Publish** **Publish Selected** option in the Ribbon Bar.

    <img src="media/115.png" width="425" height="156" />

17. The desired Bug is published on the Fabrikam Fiber Team Project.

    <img src="media/114.png" width="567" height="331" />

    - The last step is to check the published Work Items on the
    Team Project.

18. Run **Visual Studio 2017**.

19. Run the **All Bugs** query.

    <img src="media/113.png" width="602" height="437" />

    - The Bug Work Item can be seen in the Team Project. Similarly we can
    run relevant queries, to check other Work Items on the Team Project
    that we published before the Bug Work Item.

    <img src="media/112.png" width="591" height="211" />

    <img src="media/111.png" width="595" height="450" />

    <img src="media/110.png" width="536" height="564" />

    - The image depicts SmartWord4TFS’ support of Rich Content Data to be
    published on the Team Project.

### Task 2: Instant Document Reporting with SmartWord4TFS using a Template

You will learn how to update Work Items on the Team Project while staying in Word.

1. Log in as **Julia Ilyiana** (VSALM\\Julia). All user passwords are
    **P2ssw0rd**.

2. Start MS-Word and open the **Product Backlog Item List.dotx** from
    the **Documents** folder.

3. All necessary work to populate the file with Product Backlog Items
    is already in place in the document. The report is generated by a
    single click, as shown in the document.

   <img src="media/109.png" width="576" height="299" />

4. Click the SMARTWORD4TFS Tab.

   <img src="media/108.png" width="643" height="78" />

5. Click the **Refresh** option.

   <img src="media/107.png" width="401" height="100" />

6. Refreshing the document populates it by fetching all the PBIs from
    Fabrikam Fiber Team Project. Similar documents can be created to
    generate reports about desired Work Items. For more details contact
    [Modern Requirements](http://www.modernrequirements.com/contact/).

   <img src="media/106.png" width="538" height="520" />

   - Now we will update one of our PBIs and publish the updated Work Item
    on the Team Project.

7. Click inside the last Product Backlog Item and update its
    description as shown in the image.

   <img src="media/105.png" width="491" height="247" />

8. Click the **Publish Publish Selected** option.

   <img src="media/104.png" width="523" height="137" />

   - This option publishes the updates on our Fabrikam Fiber
    Team Project.

9. Run **Visual Studio 2017**.

10. Run the relevant query and open the PBI that we updated in Word.
    We can see that our PBI has been updated on the Team Project.

    <img src="media/103.png" width="581" height="438" />

### Task 3: Document Reporting using Queries

In the previous exercise we used a ready-made template to create an
instant report. This exercise explores the query option to create a
report with more freedom in what to include in the report

1. Log in as **Julia Ilyiana** (VSALM\\Julia). All user passwords are
    **P2ssw0rd**.

2. Start MS-Word and create a new document.

3. Format the document as required including header/footer, title page,
    document control information etc.

   <img src="media/102.png" width="515" height="374" />

4. Click the **SMARTWORD4TFS** Tab.

   <img src="media/101.png" width="643" height="78" />

5. Click the **Choose Team Project** **Team Project** option.

   <img src="media/100.png" width="250" height="148" />

6. Choose **FabrikamFibreCollection** **Fabrikam Fiber** (Team Project)
    click the **Connect** Button.

   <img src="media/99.png" width="542" height="396" />

7. Click the **Queries** option and select the desired query from the
    drop-down menu.

   <img src="media/98.png" width="468" height="212" />

8. The Query Dialogue Box appears with the following information and
    options:

   -  **Query Name** (i.e. the selected Query)

   -  **Query Type** (i.e. Is the query a simple list or a tree)

   -  Work Item Count

   -  **Without smart content** Check Box: If selected the query would be
    inserted as tables with plane text. The values in the table would
    not be smart content.

   -  **Insert at cursor position** Check Box: If selected the query would
    be inserted at the current cursor location, otherwise at the end of
    the document.

   -  **Insert query block only** Check Box: If selected; an empty query
    control is added in the document without any Work Items (refer to
    the image at the bottom of the page). The query control can be
    refreshed later, to be filled with the relevant Work Items. *The
    Template we used in Exercise 2 was created by using this option.  

    <img src="media/97.png" width="332" height="202" />

9. Enable only the middle check box while leaving the other two
    checkboxes un-selected. Then click the **OK** Button.

   <img src="media/96.png" width="341" height="207" />

10. The result of the query is added in the document.

    <img src="media/95.png" width="561" height="288" />

## Appendix A: Designing a SmartWord4TFS Template using Wizard

In this appendix you will learn how to create a new SmartWord4TFS
template from scratch using the Wizard.

- The Wizard makes the template designing process quite easy even for
    novice users. Another way is to create the template using individual
    controls but that is for advanced users and hence not discussed in
    this exercise.

1. Log in as **Julia Ilyiana** (VSALM\\Julia). All user passwords are
    **P2ssw0rd**.

2. Start MS-Word and create a new document.

3. Format the document as required including header/footer, title page,
    document control information etc.

    <img src="media/1.png" width="552" height="410" />

4. Click the **SMARTWORD4TFS** Tab.

    <img src="media/2.png" width="643" height="78" />

5. Click the **Choose Team Project** **Team Project** option.

    <img src="media/3.png" width="250" height="148" />

6. Choose **FabrikamFibreCollection** **Fabrikam Fiber** (Team Project)
    click the **Connect** Button.

    <img src="media/4.png" width="542" height="396" />

7. Click the **Wizard** option.

    <img src="media/5.png" width="358" height="110" />

8. Click the **Create section** Button (at top left of the window).

    <img src="media/6.png" width="414" height="135" />

9. Enter a suitable name for the section.

    <img src="media/7.png" width="217" height="114" />

   - This section would serve as a root node and would be used to show a
    certain type of Work Item. We could have sub-section(s) to display
    the Work Items in the desired hierarchy.

10. Select the desired Work Item Type.

    <img src="media/8.png" width="414" height="125" />

11. Select the desired Section Type, to determine how the Work Item
    would be displayed in the template/document.

    <img src="media/9.png" width="405" height="115" />

12. Select the desired field from the available list and include it in
    the Smart Part using the arrow button.

    - Users can select multiple fields by holding down the **Ctrl** key
    and clicking all the desired fields from the list.

    <img src="media/10.png" width="479" height="361" />

13. Arrange the selected fields in the desired order (using
    arrow buttons) and customize them (if desired).

    <img src="media/11.png" width="609" height="355" />

14. Users can make a selected field to be hidden, using the
    relevant checkbox. For the Hidden fields, users have to provide
    corresponding default values. Hidden field do not appear in the Word
    document, however their default values are published automatically
    on TFS (along with other normal fields) when users perform a
    **Publish** command.

    <img src="media/12.png" width="333" height="143" />

    >**Note** that not every field can be a hidden field. For such fields,
    the relevant check boxes remain disabled as evident from the **ID**
    and **Title** check boxes shown in the above image.

15. Give a heading for the selected fields as you want it to appear in
    the template/document. The Heading could be given using Section
    Heading or selected from the drop down control.

    <img src="media/13.png" width="643" />

    - This completes the formatting of a Work Item node that started with step 9

16. Now click the **Create Sub Section** Button (at top left of
    the window).

    <img src="media/14.png" width="173" height="111" />

17. Enter a suitable name (e.g. PBI) for the sub section, as we did for
    the section in step 9.

18. Repeat Step 9 to 14 with the sub section, this time formatting the
    node for **Product Backlog Item**.

    - During the course of creating this guide we have designed the
    template with the following section hierarchy:

    <img src="media/15.png" width="187" />

19. Click the **Apply** Button to save the changes and complete the
    template creation process.

    <img src="media/16.png" width="583"/>

    - This completes the template creation process. The hierarchy of nodes
    becomes visible in the document as shown in the following image. Now
    we only need to save the template.

    <img src="media/17.png" width="548" height="411" />

20. Save the document as a template (with .dotx extension) to complete
    the template creation process.

## Exercise 2: Traceability Management with inteGREAT4TFS

In this exercise you will learn how to create an Intersection Matrix
using the Trace Analysis module of inteGREAT4TFS.

inteGREAT4TFS is an online application that complements
    SmartOffice4TFS in managing Team Projects. inteGREAT4TFS consists of
    many distinct modules such as: **Trace Analysis**, **SmartOffice
    Library**, **Simulation, Diagram, Use Case,** **Review** and
    **Baselining**. In this HOL, we would be using the **Trace
    Analysis** module only.

### Task 1: Accessing inteGREAT4TFS and Creating an Intersection Matrix

1. Log in as **Administrator** with the password **P2ssw0rd**.

2. Start Internet Explorer.

3. Access the following URL: **VSALM:8080**
   
   <img src="media/18.png" width="542" height="385" />

4. The Login Page for inteGREAT4TFS is displayed in the browser.

   <img src="media/19.png" width="611" height="434" />

   - Following login details are to be used:

   - TFS Server URL: [**http://VSALM:8080/tfs**](http://VSALM:8080/tfs)

   - User ID: **Administrator**  
      Password: **P2ssw0rd**

5. Enter the login details and click the **Sign In** Button.

   <img src="media/20.png" width="428" height="390" />

6. Enter a valid key (if provided) to activate OR use the
    **Trial** option.

   <img src="media/21.png" width="643" height="457" />

   - Home page is displayed.

7. Click the **Browse** link.

   <img src="media/22.png" width="306" height="217" />

8. Expand **FabrikamFibreCollection** node select **Fabrikam Fiber**
    (Team Project) click the **Navigate** Button.

   <img src="media/23.png" width="536" height="383" />

9. Upon successful connection, the Dashboard of the selected Team
    Project (**Fabrikam Fiber**) is displayed.

   <img src="media/24.png" width="598" height="425" />

   **Dashboard in inteGREAT4TFS**

   **Dashboard** is the place where the user gets useful information
    about the team project. It also leads the users to the desired
    module in inteGREAT4TFS. Users can select their desired module in a
    number of ways. Since we would be using the **Trace Analysis**
    module in this exercise, we would select it.

10. Select the **Trace Analysis** link from the highlighted links shown
    in the following image.

    <img src="media/25.png" width="581" height="277" />

    - The landing page of the Trace Analysis module is displayed.
    Originally it would be empty since we have not created any
    traceability as of yet.

11. Click **New** and then **Traceability** options from the drop down.

    <img src="media/26.png" width="281" height="378" />

12. Enter a suitable name for the Intersection Matrix and click the
    **OK** Button.

    <img src="media/27.png" width="397" height="106" />

13. Clicking the **Next** button takes us to the Editor page where we
    configure the settings to create the Intersection (and also
    the Horizontal) Matrix.

14. The Intersection Matrix can be created as **Work Item Type** or
    **Saved-Query Type**. In this lab we will create the matrix as Work
    Item Type.

15. The Work Item Type gives more control to user enabling him to choose
    the desired Work Item instead of pre-saved queries. In the
    Saved-Query type, users can only select those Work Items for which a
    relevant query exists in the selected Team Project.

16. Set the Area and Iteration Path as **Fabrikam Fiber** (if not
    already selected).

    <img src="media/28.png" width="574" height="326" />

17. Select the desired Link Type.

    <img src="media/29.png" width="518" height="324" />

18. Select the desired Row Work Item Type.

    <img src="media/30.png" width="517" height="323" />

19. Similarly, select the desired Column Work Item Type.

    <img src="media/31.png" width="513" height="320" />

20. Now click the **Run Query** option in the Toolbar.

    <img src="media/32.png" width="527" height="235" />

21. The Intersection Matrix is generated.

    <img src="media/33.png" width="583" height="414" />

22. To view the matrix in full screen mode, click the **Full Screen**
    Button at the top-right side of the matrix.

    <img src="media/34.png" width="382" height="281" />

23. The Matrix is displayed in Full Screen Mode. You can also adjust the
    Zoom Ratio to view more information simultaneously.

    <img src="media/35.png" width="643" height="457" />

24. To exit from the Full Screen Mode click the same button once again.

    <img src="media/36.png" width="193" height="148" />

### Task 2: Adding/deleting relationships in Intersection Matrix

In this exercise you will learn how to add or remove relationships in
the Intersection Matrix.

1. The arrows in the intersection cell of the matrix denote that a relation exists between corresponding Work Items of the row
   and column.

   <img src="media/image1.png" width="289" height="146" />

2. All types of relationships are grouped into three link types. The
    following table sums up the legends used.

   <img src="media/image2.png" width="23" height="23" />

   <img src="media/image3.png" width="23" height="22" />

   <img src="media/image4.png" width="23" height="22" />

**Adding a Relationship**

1. Invoke **Trace Analysis** module from Dashboard.

2. Create / open an Intersection Matrix.

3. Determine the intersection cell for creating a relationship between
    corresponding Work Items.

   <img src="media/image5.png" width="553" height="393" />

4. Place the mouse over the intersection cell.

   - The cell would show a + sign.

   <img src="media/image6.png" width="483" height="278" />

5. Click the + sign.

6. Select the desired type of relationship.

   <img src="media/image7.png" width="316" height="342" />

7. Click the **OK** Button.

   <img src="media/image8.png" width="316" height="342" />

8. The relationship is created in the target cell of the
    Intersection Matrix.

   <img src="media/image9.png" width="583" height="414" />

The relationship does not only show-up in the matrix. It can also be
seen using Web Access or Visual Studio

**Deleting a relationship**

Deleting the relationship is very similar to how we created the relationship.

1. Determine the intersection cell for deleting relationship between
    corresponding Work Items.

2. Place the mouse over the intersection cell.

   - The cell would show a - sign.

    <img src="media/image10.png" width="546" height="314" />

3. Click the - sign.

4. Click the **OK** Button.

    <img src="media/image11.png" width="372" height="245" />

5. The relationship is deleted.

    <img src="media/image12.png" width="583" height="415" />

### Task 3: Editing Work Items

In this exercise you will learn how to edit Work Item properties (apart
from link/relationship property that we have already discussed in
previous exercise).

1. Invoke **Trace Analysis** module from Dashboard.

2. Create / open an Intersection Matrix.

3. Now place the mouse over the desired Work Item.

   <img src="media/image13.png" width="581" height="413" />

4. Click the **Edit** icon in the popup window.

   <img src="media/image14.png" width="367" height="148" />

5. Edit the desired properties of the Work Item and click the
    **Save** Button.

   <img src="media/image15.png" width="553" height="275" />

6. Close the popup window.

   <img src="media/image16.png" width="550" height="273" />

7. The changes to the Work Item are saved.

### Task 4: Creating a Horizontal Matrix

In this exercise you will learn how to create a Horizontal Matrix. 

The Horizontal Matrix shows what are the relations of a particular type of Work Item, and what are the relations of those relations,
and so on (up-till level 3).

1. Invoke **Trace Analysis** module from Dashboard.

2. Click **New** and then **Traceability** options from the drop down.

   <img src="media/image17.png" width="281" height="378" />

3. Enter a suitable name for the Horizontal Matrix and click the **OK** Button.

   <img src="media/image18.png" width="444" height="120" />

   - Clicking the **Next** button takes us to the Editor page where we configure the settings to create the Horizontal (and also the Intersection) Matrix.

4. Click the **Custom** option.

   <img src="media/image19.png" width="506" height="190" />

5. Select the desired **Area** and **Iteration Path**.

   <img src="media/image20.png" width="506" height="187" />

6. Select the relevant Work Item for Column 1.

   <img src="media/image21.png" width="542" height="338" />

   The Column 1 Work Item tells inteGREAT4TFS to show the list of all the Work Items of the selected type.

   - The Column 2 Work Item tells inteGREAT4TFS to show the list of
    selected type of Work Items that are linked with the Column 1
    Work Items. Similar principle is followed for Colum 3 & 4 Work Items

   - If a Column 1 Work Item has no relation with Column 2 Work Items but
    has a link with Column 3 or 4 Work Item(s) then it is also shown
    bypassing Column 2 Work Item.

   - Selecting Column 1 Work Item is mandatory while all other columns
    are optional.

7. Similarly select the relevant Work Item(s) for additional Columns
    (if desired).

   <img src="media/image22.png" width="536" height="140" />

8. Click the **Run** Button in the Toolbar.

   <img src="media/image23.png" width="551" height="339" />

9. The Horizontal Matrix is generated and displayed.

   <img src="media/image24.png" width="576" height="409" />

### Task 5: Export to Excel

In this exercise you would learn how to export the desired type of matrix (Intersection or horizontal) to MS-Excel.

1. Invoke **Trace Analysis** module from Dashboard.

2. Create / open the desired type of matrix.

3. Click the **Export To Excel** option in the Mini Toolbar.

   <img src="media/image25.png" width="310" height="224" />

4. The Excel file is created.

   <img src="media/image26.png" width="570" height="66" />

5. The file can now be opened in MS-Excel using **Open** or **Save**
    option as desired.

   <img src="media/image27.png" width="584" height="415" />

## Exercise 3: Baseline Management with inteGREAT4TFS

In this exercise you will learn how to access inteGREAT4TFS and create a baseline using it.

inteGREAT4TFS is an online application that complements
    SmartOffice4TFS in managing Team Projects. inteGREAT4TFS consists of
    many distinct modules such as: **Trace Analysis**, **SmartOffice
    Library**, **Simulation, Diagram, Use Case,** **Review** and
    **Baselining**. In this hands on lab, we would be using the
    **Baselining** module only.

### Task 1: Accessing inteGREAT4TFS and creating a baseline

1. Log in as **Brian Harry** (VSALM\\Brian). All user passwords are
    **P2ssw0rd**.

2. Start Internet Explorer.

3. Access the following URL: **VSALM:8028**

   <img src="media/37.png" width="592" height="421" />

4. The Login Page for inteGREAT4TFS is displayed in the browser.

   <img src="media/38.png" width="612" height="435" />

   Following login details are to be used:

   - TFS Server URL: [**http://VSALM:8080/tfs**](http://VSALM:8080/tfs)

   - User ID: **Administrator**  
     Password: **P2ssw0rd**

5. Enter the login details and click the **Sign In** Button.

   <img src="media/39.png" width="349" height="317" />

   - Home page is displayed.

6. Click the **Browse** link.

   <img src="media/40.png" width="306" height="217" />

7. Expand **FabrikamFibreCollection** node select **Fabrikam Fiber**
    (Team Project) click the **Navigate** Button.

   <img src="media/41.png" width="529" height="378" />

8. Upon successful connection, the Dashboard of the selected Team
    Project (**Fabrikam Fiber**) is displayed.

   <img src="media/42.png" width="610" height="433" />

   **Dashboard in inteGREAT4TFS**

   **Dashboard** is the place where **the** user gets useful
    information about the team project. It also leads the users to the
    desired module in inteGREAT4TFS. Users can select their desired
    module in a number of ways. Since we would be using the
    **Baselining** module in this exercise, we would select it.

9. Select the **Baselining** link from the highlighted links shown in
    the following image.
 
   <img src="media/43.png" width="603" />

10. In case **Manage** hub is used to invoke the module, user has to
    additionally select the Baseline option afterwards.

    <img src="media/44.png" width="347" height="112" />

11. The landing page of Baselining module is displayed. Originally it
    would be empty since we have not created any baseline as of yet.

12. Click **New** and then **Baseline** options from the drop down.

    <img src="media/45.png" width="271" height="359" />

13. Enter a suitable name for the baseline; provide a description and
    click the **Next** Button.

    <img src="media/46.png" width="460" height="351" />

14. Clicking the **Next** button takes us to the query window where we
    have to search for the Work Items that we want to include in
    the baseline. We can search based on saved queries, IDs, full or
    part of the name.

15. Select the desired query and click the **Find** Button.

    <img src="media/47.png" width="557" height="440" />

16. Select the desired Work Items from the query result and click the
    Add Work Items Button.

    <img src="media/48.png" width="479" height="378" />

17. The Work Items window is closed and the added Work Items are listed
    in a new page. At this moment we have created a list of Work Items
    that are ready to be included in our baseline. However the baseline
    itself has not yet been created. This extra step helps users to
    include additional Work Items, remove unwanted ones, or edit them
    before finalizing the baseline.

18. Click the Save Button.

    <img src="media/49.png" width="467" height="259" />

19. The baseline is created

    <img src="media/50.png" width="568" height="404" />

### Task 2: Generating Baseline Reporting

A Baseline Report is created for a particular baseline. It contains details about the Work Item it contains.

1. Invoke the **Baselining** module from Dashboard.

2. Click the desired baseline in the Baseline Explorer Panel under
    Project Baselines.

   <img src="media/51.png" width="494" height="301" />

3. Click the **Generate Report** option in the toolbar.

   <img src="media/52.png" width="474" height="273" />

4. The report is generated and can be opened in Microsoft Word.

   <img src="media/53.png" width="600" height="427" />

### Task 3: Comparing Baselines

In this exercise you will learn how to compare two baselines and create a difference report.

1. Invoke the **Baselining** module from Dashboard.

2. Open the desired baseline using the Baseline Explorer Panel.

3. Now click the **Compare** Tab (below the baseline’s name in the Main Panel)

   <img src="media/54.png" width="426" height="241" />

4. Click on the downward arrow in the Main Toolbar.

   <img src="media/55.png" width="506" height="202" />

5. Select the desired baseline to compare with the current baseline

   <img src="media/56.png" width="517" height="308" />

6. The comparison between two baselines is shown in the Grid. The Work
    Items that were updated are mentioned as Changed in the “**Comp.
    Status”** column (highlighted in the image).

   <img src="media/57.png" width="523" height="372" />

7. The actual updates in the selected Work Items are shown in the
    **Work Item Details Panel** (at the right hand side of the window).
    If the difference is not evident, then click the **Summary** Button
    at the top right of the Work Items Details Pane. This would show
    only the differential values in the pane.

8. To switch to the **Summary Mode** (for easy viewing of updates),
    click the **Summary** option in the **Work Item Details Panel**.

   <img src="media/58.png" width="544" height="240" />

9. The **Work Item Details Panel** now shows only the values that
    were updated.

   <img src="media/59.png" width="588" height="418" />

10. Click the **Difference Report** option in the Main Toolbar.

    <img src="media/60.png" width="508" height="284" />

11. Enter required information and click the **Generate** Button.

    <img src="media/61.png" width="376" height="133" />

12. The Difference Report is created in MS-Word format. Save or Open the file to complete the process.

    <img src="media/62.png" width="578" height="66" />

    <img src="media/63.png" width="512" height="364" />

### Task 4: Copying Baselines

In this exercise you will learn how to copy a baseline (or its Work
Items) to create a new baseline. The copied baseline can be pasted into
the same team project or into another project. In both cases the process
is same, with only change in the target team project option.

1. Open the desired baseline.

2. Click the **Copy Work Items** option in the Main Toolbar.

   <img src="media/64.png" width="343" height="234" />

3. The Copy Work Item Window appears. Its options are divided under three sections as marked in the image.

   <img src="media/65.png" width="419" height="281" />

4. The Team Project option (in the Target Team Project section) tells where the baseline will be copied. Into the same team project or
   into another one, for example a re-use library project?

   <img src="media/66.png" width="586" height="393" />

5. Set the options in the **Team Project** section and then click the
    **Work Items** Tab in the window.

   <img src="media/67.png" width="394" height="154" />

6. Here All Work Items are shown that are in the selected baseline.
    Users can select all Work Items (using **Select All** Button) or
    individually select the desired Work Items (using **Ctrl + click)**.

   <img src="media/68.png" width="601" height="403" />

7. Select the desired Work Items and then click the **Options** Tab.

   <img src="media/69.png" width="318" height="154" />

8. If we enable the **Create Baseline of copy work item(s)** checkbox
    (marked in the image below) then the baseline is copied as well,
    otherwise only the selected work items are copied.

9. Set desired options and click the **Copy** Button.

   <img src="media/70.png" width="598" height="401" />

10. A copy of the baseline is created and a message is displayed.

    <img src="media/71.png" width="325" height="199" />

11. The newly created baseline is now accessible through the Baseline
    Explorer Panel.

    <img src="media/72.png" width="595" height="423" />

## Exercise 4: Review Management with inteGREAT4TFS

### Task 1: Creating a Review Request

In this exercise you will learn about how to create a Review Request
using the Review Management module of inteGREAT4TFS.

inteGREAT4TFS is an online application that complements
    SmartOffice4TFS in managing Team Projects. inteGREAT4TFS consists of
    many distinct modules such as: **Trace Analysis**, **SmartOffice
    Library**, **Simulation, Diagram, Use Case,** **Review** and
    **Baselining**. In this HOL, we will be using the **Review**
    module only.

1. Using the method described in baseline/traceability HOL, log in as
    **Administrator.**

2. Navigate to the inteGREAT4TFS Dashboard.

   <img src="media/73.png" width="562" height="399" />

   **Dashboard in inteGREAT4TFS**

   **Dashboard** is the place where the user gets useful information
    about the team project. It also leads the users to the desired
    module in inteGREAT4TFS. Users can select their desired module in a
    number of ways. Since we will be using the **Review** module in this
    exercise, we will select the Review link that leads to our
    desired module.

3. Select the **Review Management** link from the highlighted links shown in the following image.

   <img src="media/74.png" width="598" height="285" />

4. The landing page of the Review Management is displayed. The landing
    page would be empty since neither we have generated any Review
    Requests nor any requests have been assigned to us as of yet.

5. Click **New** and then **Review Request** option from the drop down.

   <img src="media/75.png" width="240" height="328" />

6. The Review Request Popup is displayed. This popup is used to configure all the settings for the Review Requests.

   <img src="media/76.png" width="570" height="329" />

7. Select the Reviewers from the drop-down list.

   <img src="media/77.png" width="296" height="236" />

   > You can select more than one reviewer

8. Similarly, select the desired Approvers.

   <img src="media/78.png" width="391" height="299" />

   > **Reviewers** only provide comments while **Approvers** can
    also approve/reject. A particular person can be either selected as a reviewer or an approver.

9. Enter appropriate subject for the review request.

   <img src="media/79.png" width="403" height="310" />

   >The subject of the Review Request becomes the subject of the email that is sent by inteGREAT4TFS to the selected Approvers/Reviewers.

10. Scroll down to get to the other steps in the window.

11. Provide a purpose for the review (if desired). Alternatively
    collapse the section by clicking on the down arrow at far right.

    <img src="media/80.png" width="603" height="245" />

12. Click the Add Work Items button.

    <img src="media/81.png" width="416" height="223" />

13. Run the relevant query.

    <img src="media/82.png" width="518" height="404" />

    >A list of Work Item appears depending upon the query we ran. We can now select the desired ones from the list.

14. Select the desired Work Items (for which the review is desired) and
    click the **Add Work Item** button.

    <img src="media/83.png" width="436" height="344" />

15. Set the Due Date.

    <img src="media/84.png" width="561" height="323" />

16. To preview the request, click the **Preview** button.

    <img src="media/85.png" width="593" height="342" />

    >The Preview is displayed. In preview, only the text box area
    is editable. All other information such as recipients, Due Date etc.
    are shown in read-only format. If these need to be edited then user
    has to go back and alter the relevant options.

17. Make formatting updates (if desired) and click the Send button.

    <img src="media/86.png" width="562" height="324" />

18. The Review Request is created and becomes visible at the module's
    landing page.

    <img src="media/87.png" width="549" height="391" />

### Task 2: Responding to the Review Requests

In this exercise you will learn about how to respond to a Review Request
using the Review Management module of inteGREAT4TFS.

1. The Review Requests assigned to a user are arranged under **Assigned to Me** heading in the Folder Explorer.

   <img src="media/88.png" width="182" height="287" />

   >The process to respond to the review requests is slightly different
    for Reviewers and for Approvers. The following steps describe the
    process for Approvers. The Reviewers can only give their comments.
    The Accept/Reject options don’t appear in the UI for reviewers.

2. Click the relevant Review Request under the **Reviewed** **Assigned
    To Me** heading in the Folder Explorer.

   <img src="media/89.png" width="228" height="301" />

3. Select the Work Item for which the review is to be given.

   <img src="media/90.png" width="535" height="332" />

4. Provide a comment (if desired)

   <img src="media/91.png" width="529" height="198" />

5. Click **Accept** or **Reject** Button.

   <img src="media/92.png" width="396" height="280" />

6. The response for the selected Work Item is completed.

   <img src="media/93.png" width="572" height="367" />

7. Repeat the process with all other Work Items of the Review Request.

   >Giving comment is not mandatory for approvers; however, it is mandatory for stakeholders.

   <img src="media/94.png" width="261" height="111" />

8. If **Accept All** or **Reject All** option is selected instead of
    simple Accept/Reject then the response is finalized for all Work
    Items of the Review Request and the user does not have to repeat the
    whole process for each Work Item as mentioned in last step.
