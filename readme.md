---
layout: homepage
title: Microsoft ALM VM
keywords: ALM VM homepage
tags: [overview]
permalink: index.html
comments: true
summary: 
redirect_to: https://almvm.azurewebsites.net
---
        
 <!--<img src="http://vsalmvm.azurewebsites.net/wp-content/uploads/2015/09/ALM-VM-banner-0915.png" width="760" height="177" />-->

<br>
<span class="introText">
The Microsoft Visual Studio ALM Virtual Machine is a virtual machine pre-installed with Visual Studio & Team Foundation server along with other supporting software coming pre-configured with sample projects, users, data and a set of hands-on-labs/demo scripts to get started with all the ALM Capabilities that Microsoft Visual Studio Team Foundation Server/Visual Studio Team Services provides. 
</span>
<br />
<br />
 
<div class="lab-columns">
    <div class="lab-item-none"></div>
    <div class="lab-item" align="center">
          <span class="headnews"> <b> Team Foundation Server Labs</b></span><br />
             <a href="labs/tfs"><img src="images/vside.png"/></a><br />
           <span class="mainPageText"> Access the Microsoft ALM Virtual Machine and Team Foundation Server Hands-on-Labs</span><br /><br />
           <a href="labs/tfs" class="c-glyph"><span class="lab-details">View Details</span></a>
    </div>
    <div class="lab-item-none"></div>
    <div class="lab-item" align="center">
         <span class="headnews"> <b> Team Services Labs</b></span><br />
        <a href="labs/vsts"><img src="images/vstslogo.png"/></a><br />
       <span class="mainPageText"> Follow the Visual Studio Team Services Hands-on-Labs</span><br /><br />
       <a href="labs/vsts" class="c-glyph"><span class="lab-details">View Details</span></a>
    </div>
</div>
 <div class="clear"></div>

<br />

<h2> Recent News </h2>
 {% for post in site.posts limit:10 %}
<div class="headline">

<span class="headnews">
<a href="{{ post.pageurl | prepend: site.baseurl| prepend: site.url }}">{{ post.title | xml_escape }}</a>
</span> 
<p>
{{ post.content }}
</p>
<div class="newsitem">
<span class="newsfooter">
<span class="glyphicon glyphicon-time"></span> &nbsp;{{ post.pubdate }}  &nbsp;&nbsp;&nbsp; <span class="glyphicon glyphicon-user"></span> &nbsp; {{ post.Author }}   &nbsp;&nbsp;&nbsp; <span class="glyphicon glyphicon-link"></span>&nbsp;<a href="{{ post.pageurl | prepend: site.baseurl| prepend: site.url }}">   Link</a>
</span>
</div>
</div>

{% endfor %}


 








