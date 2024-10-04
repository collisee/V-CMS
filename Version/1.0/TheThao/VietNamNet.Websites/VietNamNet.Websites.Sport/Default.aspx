<%@ OutputCache CacheProfile="HomepageCache" %>

<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs"
  Inherits="VietNamNet.Websites.Sport._Default" %>

<%@ Register Src="UserControls/Homepage/PanelTopNews.ascx" TagName="PanelTopNews"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelHotNews.ascx" TagName="PanelHotNews"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelLiveScore.ascx" TagName="PanelLiveScore"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB1.ascx" TagName="PanelAdvB1"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB2.ascx" TagName="PanelAdvB2"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB3.ascx" TagName="PanelAdvB3"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB4.ascx" TagName="PanelAdvB4"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB5.ascx" TagName="PanelAdvB5"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC1.ascx" TagName="PanelAdvC1"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC2.ascx" TagName="PanelAdvC2"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC3.ascx" TagName="PanelAdvC3"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelTrungthuong.ascx" TagName="PanelTrungthuong"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelBBCCateBox.ascx" TagName="PanelBBCCateBox"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelBigCateBox.ascx" TagName="PanelBigCateBox"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelClip.ascx" TagName="PanelClip" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelMostRead.ascx" TagName="PanelMostRead" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Survey/PaneSurvey.ascx" TagName="PanelSurvey" TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentImageSport.ascx" TagName="PanelContentImageSport"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelSmallCateBox.ascx" TagName="PanelSmallCateBox"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC4.ascx" TagName="PanelAdvC4"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelTheodong.ascx" TagName="PanelTheodong" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  <div class="home-center">
    <div class="home-center-left pdt5">
      <uc:PanelTopNews ID="PanelTopNews1" runat="server" CategoryAlias="tin-noi-bat" FirstIndexRecord="1"
        LastIndexRecord="3" />
      <uc:PanelHotNews ID="PanelHotNews1" runat="server" CategoryAlias="tin-moi-nong" FirstIndexRecord="1"
        LastIndexRecord="9" />
      <br class="clear" />
      <uc:PanelLiveScore ID="PanelLiveScore1" runat="server" />
    </div>
    <div class="home-center-right">
      <uc:PanelAdvC1 ID="PanelAdvC1_1" runat="server" />
      <uc:PanelTrungthuong ID="PanelTrungthuong1" runat="server" CategoryAlias="trung-thuong" />
      <uc:PanelBBCCateBox ID="PanelBBCCateBox1" runat="server" CategoryAlias="bbc-tieng-viet-tin-bong-da" />
    </div>
    <br class="clear" />
  </div>
  <div class="home-left">
    <uc:PanelAdvB1 ID="PanelAdvB1_1" runat="server" />
    <uc:PanelBigCateBox ID="PanelBigCateBox1" runat="server" CategoryAlias="premier-league" />
    <uc:PanelBigCateBox ID="PanelBigCateBox2" runat="server" CategoryAlias="la-liga" />
    <uc:PanelAdvB2 ID="PanelAdvB2_1" runat="server" />
    <uc:PanelBigCateBox ID="PanelBigCateBox3" runat="server" CategoryAlias="serie-a" />
    <uc:PanelBigCateBox ID="PanelBigCateBox4" runat="server" CategoryAlias="bundesliga" />
    <uc:PanelAdvB3 ID="PanelAdvB3_1" runat="server" />
    <uc:PanelBigCateBox ID="PanelBigCateBox5" runat="server" CategoryAlias="champions-league" />
    <uc:PanelBigCateBox ID="PanelBigCateBox6" runat="server" CategoryAlias="v-league" />
    <uc:PanelAdvB4 ID="PanelAdvB4_1" runat="server" />
    <uc:PanelBigCateBox ID="PanelBigCateBox7" runat="server" CategoryAlias="doi-tuyen-viet-nam" />
    <uc:PanelBigCateBox ID="PanelBigCateBox8" runat="server" CategoryAlias="hau-truong" />
    <uc:PanelAdvB5 ID="PanelAdvB5_1" runat="server" />
    <uc:PanelBigCateBox ID="PanelBigCateBox9" runat="server" CategoryAlias="dien-dan" />
    <uc:PanelBigCateBox ID="PanelBigCateBox10" runat="server" CategoryAlias="giao-luu-truc-tuyen" />
  </div>
  <div class="home-right">
    <uc:PanelClip ID="PanelClip1" runat="server" />
    <uc:PanelAdvC2 ID="PanelAdvC2_1" runat="server" />
    <br class="clear" />
    <div class="pdt3">
      <uc:PanelMostRead ID="PanelMostRead1" runat="server" CategoryAlias="the-thao" />
      <uc:PanelAdvC3 ID="PanelAdvC3_1" runat="server" />
      <br class="clear" />
    </div>
    <div class="box-list pdt2">
      <uc:PanelSurvey ID="PanelSurvey1" runat="server" CategoryAlias="trang-chu" />
      <uc:PanelContentImageSport ID="PanelContentImageSport1" runat="server" CategoryAlias="anh-the-thao"
        FirstIndexRecord="1" LastIndexRecord="5" />
      <uc:PanelSmallCateBox ID="PanelSmallCateBox1" runat="server" CategoryAlias="tennis"
        FirstIndexRecord="1" LastIndexRecord="3" />
      <uc:PanelSmallCateBox ID="PanelSmallCateBox2" runat="server" CategoryAlias="dua-xe"
        FirstIndexRecord="1" LastIndexRecord="3" />
      <uc:PanelSmallCateBox ID="PanelSmallCateBox3" runat="server" CategoryAlias="cac-mon-khac"
        FirstIndexRecord="1" LastIndexRecord="3" />
    </div>
    <uc:PanelAdvC4 ID="PanelAdvC4_1" runat="server" />
  </div>
  <br class="clear" />
  <uc:PanelTheodong ID="PanelTheodong1" runat="server" CategoryAlias="theo-dong-su-kien"
    FirstIndexRecord="1" LastIndexRecord="10" />
</asp:Content>
