<%@ OutputCache CacheProfile="CategoryCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="Search.aspx.cs"
  Inherits="VietNamNet.Websites.Sport.Search" %>

<%@ Register Src="UserControls/Search/PanelSearchContent.ascx" TagName="PanelSearchContent"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC1.ascx" TagName="PanelAdvC1"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Categories/PanelTop.ascx" TagName="PanelTop" TagPrefix="uc" %>
<%@ Register Src="UserControls/Categories/PanelMostRead.ascx" TagName="PanelMostRead"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Survey/PaneSurvey.ascx" TagName="PanelSurvey" TagPrefix="Survey" %>
<%@ Register Src="UserControls/News/PanelContentImageSport.ascx" TagName="PanelContentImageSport"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelSmallCateBox.ascx" TagName="PanelSmallCateBox"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC4.ascx" TagName="PanelAdvC4"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC6.ascx" TagName="PanelAdvC6"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC7.ascx" TagName="PanelAdvC7"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelTheodong.ascx" TagName="PanelTheodong" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="home-left">
    <uc:PanelSearchContent ID="PanelSearchContent1" runat="server" />
  </div>
  <div class="home-right">
    <div class="box-list">
      <uc:PanelMostRead ID="PanelMostRead1" runat="server" />
      <Survey:PanelSurvey ID="PanelSurvey1" runat="server" />
      <uc:PanelContentImageSport ID="PanelContentImageSport2" runat="server" CategoryAlias="anh-the-thao"
        FirstIndexRecord="1" LastIndexRecord="5" />
      <uc:PanelAdvC6 ID="PanelAdvC6_2" runat="server" />
      <uc:PanelSmallCateBox ID="PanelSmallCateBox1" runat="server" CategoryAlias="quan-vot"
        FirstIndexRecord="1" LastIndexRecord="3" />
      <uc:PanelSmallCateBox ID="PanelSmallCateBox2" runat="server" CategoryAlias="dua-xe"
        FirstIndexRecord="1" LastIndexRecord="3" />
      <uc:PanelAdvC7 ID="PanelAdvC7_2" runat="server" />
    </div>
    <uc:PanelAdvC4 ID="PanelAdvC4_2" runat="server" />
  </div>
  <br class="clear" />
  <uc:PanelTheodong ID="PanelTheodong2" runat="server" CategoryAlias="theo-dong-su-kien"
    FirstIndexRecord="1" LastIndexRecord="10" />
</asp:Content>
