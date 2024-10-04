<%@ OutputCache CacheProfile="ArticleCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="Detail.aspx.cs"
  Inherits="VietNamNet.Websites.V1.ui.khoahoc.Detail" %>

<%@ Register Src="~/UserControls/Survey/PaneSurvey.ascx" TagName="PaneSurvey" TagPrefix="vnn" %>
<%@ Register Src="~/UserControls/News/PanelContentListFeedback.ascx" TagName="PanelContentListFeedback"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/News/PanelNewsDetail.ascx" TagName="PanelNewsDetail"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/News/PanelNewsFeedback.ascx" TagName="PanelNewsFeedback"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/News/PanelOtherNews.ascx" TagName="PanelOtherNews"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelCateBox1.ascx" TagName="PanelCateBox1"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelCateBox.ascx" TagName="PanelCateBox"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateTicker.ascx" TagName="PanelCateTicker"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelMostRead.ascx" TagName="PanelMostRead"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateContentViewDate.ascx" TagName="PanelCateContentViewDate"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvB_1.ascx" TagName="PanelAdvB_1"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateSmallBox.ascx" TagName="PanelCateSmallBox"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_1_3.ascx" TagName="PanelAdvC_1_3"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_4_5.ascx" TagName="PanelAdvC_4_5"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateLargeBox.ascx" TagName="PanelCateLargeBox"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_6_14.ascx" TagName="PanelAdvC_6_14"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateContent.ascx" TagName="PanelCateContent"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateHotNews.ascx" TagName="PanelCateHotNews"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateCenterPoint.ascx" TagName="PanelCateCenterPoint"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateHotSlide.ascx" TagName="PanelCateHotSlide"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/News/PanelContentMoinong.ascx" TagName="PanelContentMoinong"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/News/PanelArticleTracking.ascx" TagName="PanelArticleTracking" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <uc:PanelCateTicker ID="PanelCateTicker1" runat="server" />
  <div id="home5">
    <div class="home5left">
      <uc:PanelNewsDetail ID="PanelNewsDetail1" runat="server" />
      <uc:PanelNewsFeedback ID="PanelNewsFeedback1" runat="server" />
      <uc:PanelContentListFeedback ID="PanelContentListFeedback1" runat="server" />
      <uc:PanelOtherNews ID="PanelOtherNews1" runat="server" />
    </div>
    <div class="home5right">
      <div class="home5_right">
        <div>
          <uc:PanelContentMoinong ID="PanelContentMoinong1" runat="server" CategoryAlias="moi-nong" />
          <uc:PanelAdvC_1_3 ID="PanelAdvC_1_3_1" runat="server" />
          <div class="clear">
            ,</div>
        </div>
        <uc:PanelCateBox CategoryAlias="khoa-hoc-suc-khoe-gioi-tinh" FirstIndexRecord="1"
          LastIndexRecord="3" ID="PanelCateBox2" runat="server" />
        <uc:PanelCateBox CategoryAlias="khoa-hoc-moi-truong" FirstIndexRecord="1" LastIndexRecord="3"
          ID="PanelCateBox1" runat="server" />
        <div class="row">
          <uc:PanelMostRead CategoryAlias="xa-hoi" ID="PanelMostRead1" runat="server" />
          <uc:PanelAdvC_4_5 ID="PanelAdvC_4_5_1" runat="server" />
          <div class="clear">
            ,</div>
        </div>
        <div class="row">
          <div>
            <div class="tt_ck">
              <uc:PanelCateBox1 CategoryAlias="khoa-hoc-trong-nuoc" ID="PanelCateBox1_2" FirstIndexRecord="1"
                LastIndexRecord="3" runat="server" />
              <uc:PanelCateBox1 CategoryAlias="khoa-hoc-quoc-te" ID="PanelCateBox1_1" FirstIndexRecord="1"
                LastIndexRecord="3" runat="server" />
              <uc:PanelCateBox1 CategoryAlias="khoa-hoc-tieu-diem" ID="PanelCateBox1_3" FirstIndexRecord="1"
                LastIndexRecord="3" runat="server" />
              <vnn:PaneSurvey ID="PaneSurvey1" runat="server" CategoryAlias="khoa-hoc" />
            </div>
            <uc:PanelAdvC_6_14 ID="PanelAdvC_6_14_1" runat="server" />
            <div class="clear">
              ,</div>
          </div>
        </div>
      </div>
    </div>
    <div class="clear">
      ,</div>
  </div>
  <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" />
    <uc:PanelArticleTracking ID="PanelArticleTracking1" runat="server" />
</asp:Content>
