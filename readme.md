---
layout: homepage
title: Microsoft ALM VM
keywords: ALM VM homepage
tags: [overview]
permalink: index.html
comments: true
summary: 
---
        
 <!--<img src="http://vsalmvm.azurewebsites.net/wp-content/uploads/2015/09/ALM-VM-banner-0915.png" width="760" height="177" />-->

<br>
<span class="introText">
The Microsoft Visual Studio ALM Virtual Machine is a virtual machine pre-installed with Visual Studio & Team Foundation server along with other supporting software coming pre-configured with sample projects, users, data and a set of hands-on-labs/demo scripts to get started with all the ALM Capabilities that Microsoft Visual Studio Team Foundation Server/Visual Studio Team Services provides. 
</span>

<br />
<br />
 
 {% for post in site.posts limit:10 %}
<div class="headline">

<span class="headnews">
<a href="{{ post.pageurl | prepend: site.baseurl| prepend: site.url }}">{{ post.title | xml_escape }}</a>
</span> 
<p>
{{ post.content }}
</p>
<br />
<div class="newsitem">
<span class="newsfooter">
<span class="glyphicon glyphicon-time"></span> &nbsp;{{ post.pubdate }}  &nbsp;&nbsp;&nbsp; <span class="glyphicon glyphicon-user"></span> &nbsp; {{ post.Author }}   &nbsp;&nbsp;&nbsp; <span class="glyphicon glyphicon-link"></span>&nbsp;<a href="{{ post.pageurl | prepend: site.baseurl| prepend: site.url }}">   Link</a>
</span>
</div>
</div>
<br/>
{% endfor %}







