<%@ OutputCache CacheProfile="CategoryCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="Categories.aspx.cs"
  Inherits="VietNamNet.Websites.Sport.Categories" %>

<%@ Register Src="UserControls/Advertisements/PanelAdvC1.ascx" TagName="PanelAdvC1" TagPrefix="uc" %>
<%@ Register Src="UserControls/Categories/PanelTop.ascx" TagName="PanelTop" TagPrefix="uc" %>
<%@ Register Src="UserControls/Categories/PanelCateContent.ascx" TagName="PanelCateContent" TagPrefix="uc" %>
<%@ Register Src="UserControls/Categories/PanelMostRead.ascx" TagName="PanelMostRead" TagPrefix="uc" %>
<%@ Register Src="UserControls/Survey/PaneSurvey.ascx" TagName="PanelSurvey" TagPrefix="Survey" %>
<%@ Register Src="UserControls/News/PanelContentImageSport.ascx" TagName="PanelContentImageSport" TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelSmallCateBox.ascx" TagName="PanelSmallCateBox" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB1.ascx" TagName="PanelAdvB1" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC4.ascx" TagName="PanelAdvC4" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC6.ascx" TagName="PanelAdvC6" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC7.ascx" TagName="PanelAdvC7" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelTheodong.ascx" TagName="PanelTheodong" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="home-center">
    <uc:PanelTop ID="PanelTop1" runat="server" CategoryAlias="the-thao" />
    <div class="home-center-right">
        <uc:PanelAdvC1 ID="PanelAdvC1_1" runat="server" />
    </div>
    <br class="clear" />
  </div>
  <div class="home-left">
<div class="cate-list">
  <div class="cate-list-top">
    &nbsp;</div>
  <div class="pdlr5">
    <uc:PanelAdvB1 ID="PanelAdvB1_1" runat="server" />
    <uc:PanelCateContent ID="PanelCateContent1" runat="server" />
  </div>
  <div class="cate-list-bottom">
    &nbsp;</div>
</div>
  </div>
  <div class="home-right">
    <div class="box-list">
      <uc:PanelMostRead ID="PanelMostRead1" runat="server" />
      <Survey:PanelSurvey ID="PanelSurvey1" runat="server" />
      <uc:PanelContentImageSport ID="PanelContentImageSport1" runat="server" CategoryAlias="anh-the-thao" FirstIndexRecord="1" LastIndexRecord="5" />
      <uc:PanelAdvC6 ID="PanelAdvC6_1" runat="server" />
      <uc:PanelSmallCateBox ID="PanelSmallCateBox1" runat="server" CategoryAlias="tennis" FirstIndexRecord="1" LastIndexRecord="3" />
      <uc:PanelSmallCateBox ID="PanelSmallCateBox2" runat="server" CategoryAlias="dua-xe" FirstIndexRecord="1" LastIndexRecord="3" />
      <uc:PanelAdvC7 ID="PanelAdvC7_1" runat="server" />
    </div>
    <uc:PanelAdvC4 ID="PanelAdvC4_1" runat="server" />
  </div>
  <br class="clear" />
  <uc:PanelTheodong ID="PanelTheodong1" runat="server" CategoryAlias="theo-dong-su-kien" FirstIndexRecord="1" LastIndexRecord="10" />

<!-- Add code -->
	<script type="text/javascript" src="http://delivery.adnetwork.vn/247/adclick/ads_em9uZV9NVEk0T1RrNU16ZzBNbDh4TWpnNU9Ua3pOamN5WHpJME1GOHlNREE9Lmh0bWxVNzI4STdWRTEwMTAxMDc4Mk0zOFc=/"></script>
<!-- end of Add code -->
</asp:Content>
