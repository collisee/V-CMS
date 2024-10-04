<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelHeader.ascx.cs"
  Inherits="VietNamNet.Websites.English.UserControls.PanelHeader" %>
<%@ Register Src="Advertisements/PanelAdvA.ascx" TagName="PanelAdvA" TagPrefix="uc" %>
<div class="home-header">
  <div class="home-logo fl_l">
    <div class="logo-english fl_l">
      <a href="/">
        <img alt="" title="" src="/images/blank.gif" width="172" height="100" /></a>
    </div>
    <div class="update-english fl_l">
      <%=strNow%>
      
    </div>
    <br class="clear" />
  </div>
  <div class="home-banner fl_l ">
    <a href="/en/about-us/index.html" class="pdlr8">ABOUT US</a> | <a href="http://vietnamnet.vn"
      class="pdlr8">VIETNAMESE</a> | <a href="/en/rss/index.html" class="pdlr8">RSS</a>
    <uc:PanelAdvA ID="PanelAdvA" runat="server" />
  </div>
  <br class="clear" />
  <div class="home-menu">
    <div class="menu-first">
      <div class="menu-artive  fl_l text11">
        <a href="/en/index.html">Home</a></div>
      <div class="menu-link  fl_l text11">
        <a href="/en/special-report/index.html">Special Reports </a>
      </div>
      <div class="menu-link  fl_l text11">
        <a href="/en/vietnam-in-photos/index.html">Vietnam In Photos</a>
      </div>
      <div class="menu-link  fl_l text11">
        <a href="/en/what-on/index.html">What’s On </a>
      </div>
      <div class="menu-link  fl_l text11">
        <a href="/en/vietnam-reference/index.html">Vietnam Reference</a></div>
      <div class="box-search fl_r  text11">
        <input type="text" class="input-search" watermark="Search.." onkeydown="searchkey(event)" />
        <img src="/images/button_search.gif" width="18" height="16" onclick="search();" style="cursor: pointer;" />
      </div>
      <br class="clear" />
    </div>
    <div class="sub-menu">
      <a href="/en/politics/index.html" class="sub-link">Government </a><a href="/en/business/index.html"
        class="sub-link">Business </a><a href="/en/society/index.html" class="sub-link">Society
        </a><a href="/en/arts-entertainment/index.html" class="sub-link">Art & Entertainment
        </a><a href="/en/travel/index.html" class="sub-link">Travel </a><a href="/en/education/index.html"
          class="sub-link">Education </a><a href="/en/science-technology/index.html" class="sub-link">
            Science & IT </a><a href="/en/environment/index.html" class="sub-link">Environment
            </a><a href="/en/sports/index.html" class="sub-link">Sports </a><a href="/en/world-news/index.html"
              class="sub-link">World News </a>
    </div>
  </div>
</div>
