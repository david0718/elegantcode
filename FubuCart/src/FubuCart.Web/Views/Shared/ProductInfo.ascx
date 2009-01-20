<%@ Control Language="C#" AutoEventWireup="true" Inherits="ProductInfo" %>
<h2 class="title"><a href="<%= this.UrlTo().PublishedProduct(Model) %>"><%= Model.Name %></a></h2>
<div class="content"><%= Model.Description %></div>
<div class="content"><%= Model.Category.Name%></div> 
<div class="more"></div>