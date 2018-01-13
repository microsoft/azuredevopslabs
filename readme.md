---
layout: homepage
title: Home
keywords: ALM VM homepage
tags: [overview]
permalink: default.html
comments: true
landingpage: false
summary: 
---

<br />
<div class="rowMain">
<div class="productcolmain">
  <div class="pageheader">
             <b>Microsoft Visual Studio DevOps Hands-On-Labs</b> </div>
     <div class="herotext2">       
              Hands-on-labs for Visual Studio Team Foundation Server and Visual Studio Team Services
  </div>
</div>
</div>

<br>
<span class="introText">
The Microsoft ALM/DevOps Hands-On-Labs is a set of self-paced labs based on Visual Studio Team Foundation Server and Visual Studio Team Services. Evaluating your next DevOps toolchain? Want to go deep and learn how you can implement modern DevOps practices with Visual Studio, Team Services and Azure? If you said yes to any of these questions, then this VM and Hands-on-labs are what you are looking for.
</span>
<br />
<br />
 <div align="center" class="labcols">
<div class="row">
    <div class="lab-item col-md-4" align="center">
          <span class="headnews"> <b> <a href="labs/tfs" class="labmain">Getting started with Visual Studio Team Foundation Server</a></b></span><br />
             <a href="labs/tfs"><img style="margin: 10px;" src="images/tile-self-hosted-server.png" width="120" height="120"/></a><br />         
           <a href="labs/tfs" class="c-glyph"><span class="lab-details">View Details</span></a>
    </div>
    <div class="lab-item col-md-4" align="center">
         <span class="headnews"> <b><a href="labs/vsts" class="labmain"> Getting started with Visual Studio Team Services</a></b></span><br />
        <a href="labs/vsts"><img style="margin: 10px;" src="images/tile-cloud-hosted-server.png" width="120" height="120"/></a><br />
       <a href="labs/vsts" class="c-glyph"><span class="lab-details">View Details</span></a>
    </div>
     <div class="lab-item col-md-4" align="center">
         <span class="headnews"> <b><a href="labs/java" class="labmain"> Extend and Integrate with VSTS</a></b></span><br />
        <a href="labs/java"><img style="margin: 10px;" src="images/tile-integrate-with-cloud-services.png" width="120" height="120"/></a><br />
       <a href="labs/java" class="c-glyph"><span class="lab-details">View Details</span></a>
    </div>        
</div>
</div>
 <div class="clear"></div>

<br />

h2 >>Announcements </h2>
 {% for post in site.posts limit:   5 %}
<div class="headline">

<span class="headnews">
<a href="{{ post.pageurl | prepend: site.baseurl| prepend: site.url }}" class="postitem">{{ post.title | xml_escape }}</a>
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