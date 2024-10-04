<%@ OutputCache CacheProfile="CategoryCache" %>

<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Category.aspx.cs"
  Inherits="VietNamNet.Websites.V1.ui.quocte.Category" %>

<%@ Register Src="~/UserControls/Categories/PanelCateImageNews.ascx" TagName="PanelCateImageNews"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Survey/PaneSurvey.ascx" TagName="PaneSurvey" TagPrefix="vnn" %>
<%@ Register Src="~/UserControls/Categories/PanelOtherNews.ascx" TagName="PanelOtherNews"
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
<%@ Register Src="~/UserControls/Categories/PanelAdvC_1_3.ascx" TagName="PanelAdvC_1_3"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_4_5.ascx" TagName="PanelAdvC_4_5"
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
<%@ Register Src="~/UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
  TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  <uc:PanelCateTicker CategoryAlias="quoc-te" ID="PanelCateTicker1" runat="server" />
  <div id="home4">
    <div id="home4_1">
      <uc:PanelCateHotNews CategoryAlias="quoc-te" ID="PanelCateHotNews1" runat="server" />
      <uc:PanelCateCenterPoint CategoryAlias="quoc-te" ID="PanelCateCenterPoint1" runat="server" />
      <div class="clear">
        ,</div>
      <uc:PanelCateHotSlide CategoryAlias="quoc-te-tam-diem" FirstIndexRecord="1" LastIndexRecord="15"
        ID="PanelCateHotSlide1" runat="server" />
    </div>
    <div id="home4_2">
      <uc:PanelAdvC_1_3 ID="PanelAdvC_1_3_2" runat="server" />
    </div>
  </div>
  <div class="clear">
    ,</div>
  <div id="home5">
    <div class="home5left">
      <div>
        <uc:PanelAdvB_1 ID="PanelAdvB_1_1" runat="server" />
      </div>
      <uc:PanelCateContent CategoryAlias="quoc-te" ID="PanelCateContent1" runat="server" />
      <uc:PanelOtherNews CategoryAlias="quoc-te" ID="PanelOtherNews1" runat="server" />
    </div>
    <div class="home5right">
      <div class="home5_right">
        <uc:PanelCateBox CategoryAlias="quoc-te-ho-so" FirstIndexRecord="1" LastIndexRecord="3"
          ID="PanelCateBox2" runat="server" />
        <uc:PanelCateBox CategoryAlias="quoc-te-the-gioi-do-day" FirstIndexRecord="1" LastIndexRecord="3"
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
              <uc:PanelCateImageNews CategoryAlias="quoc-te-tam-diem" FirstIndexRecord="1" LastIndexRecord="3"
                ID="PanelCateImageNews1" runat="server" />
              <uc:PanelCateBox1 CategoryAlias="quoc-te-binh-luan" ID="PanelCateBox1_2" FirstIndexRecord="1"
                LastIndexRecord="3" runat="server" />
              <uc:PanelCateBox1 CategoryAlias="quoc-te-vietnam-the-gioi" FirstIndexRecord="1" LastIndexRecord="3"
                ID="PanelCateBox1_1" runat="server" />
              <uc:PanelCateBox1 CategoryAlias="quoc-te-tieu-diem" FirstIndexRecord="1" LastIndexRecord="3"
                ID="PanelCateBox1_3" runat="server" />
              <vnn:PaneSurvey ID="PaneSurvey1" runat="server" CategoryAlias="quoc-te" />
            </div>
            <uc:PanelAdvC_6_14 ID="PanelAdvC_6_14_1" runat="server" />
            <div class="clear">
              ,</div>
          </div>
        </div>
        <div class="row"></div>
      </div>
    </div>
    <div class="clear">
    </div>
  </div>
  <uc:PanelAdvertisement CategoryAlias="quoc-te" ID="PanelAdvertisement1" runat="server" />
</asp:Content>
