<%@ OutputCache CacheProfile="HomepageCache" %>
<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs"
  Inherits="VietNamNet.Websites.English._Default" %>

<%@ Register Src="UserControls/Homepage/PanelTopNews.ascx" TagName="PanelTopNews"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelTopStories.ascx" TagName="PanelTopStories"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelSmallCateBox.ascx" TagName="PanelSmallCateBox"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelBigCateBox.ascx" TagName="PanelBigCateBox"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelTellUs.ascx" TagName="PanelTellUs" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelVideoClip.ascx" TagName="PanelVideoClip" TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateLatestNews.ascx" TagName="PanelCateLatestNews"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelInFocus.ascx" TagName="PanelInFocus" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB1.ascx" TagName="PanelAdvB1"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB2.ascx" TagName="PanelAdvB2"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB3.ascx" TagName="PanelAdvB3"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC1.ascx" TagName="PanelAdvC1"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC2.ascx" TagName="PanelAdvC2"
  TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="home-body">
    <div class="body-block1">
      &nbsp;
    </div>
    <div class="body680">
      <div class="body680-box1">
        <uc:PanelTopNews ID="PanelTopNews1" runat="server" CategoryAlias="top-hot-news" />
        <uc:PanelTopStories CategoryAlias="top-stories" FirstIndexRecord="1" LastIndexRecord="8"
          ID="PanelTopStories1" runat="server" />
        <br class="clear" />
        <div class="body680-bottom1a">
          &nbsp;
        </div>
      </div>
      <!-- Day la doan Quang cao B12 -->
      <uc:PanelAdvB1 ID="PanelAdvB1_1" runat="server" />
      <!-- End doan Quang cao B12 -->
      <div class="body680-box2">
        <div class="body680-top2">
          &nbsp;
        </div>
        <div class="pdlr5">
          <div class="home-cate-left">
            <uc:PanelSmallCateBox CategoryAlias="politics" ID="PanelSmallCateBox1" runat="server" />
          </div>
          <div class="home-cate-right">
            <uc:PanelSmallCateBox CategoryAlias="business" ID="PanelSmallCateBox2" runat="server" />
          </div>
          <br class="clear" />
        </div>
        <!-- Thêm div nay thi bat dau show 2 cate tren trang chu -->
        <div class="doble-cat">
          &nbsp;
        </div>
        <div class="pdlr5">
          <div class="home-cate-left">
            <uc:PanelSmallCateBox CategoryAlias="society" ID="PanelSmallCateBox3" runat="server" />
          </div>
          <div class="home-cate-right">
            <uc:PanelSmallCateBox CategoryAlias="arts-entertainment" ID="PanelSmallCateBox4"
              runat="server" />
          </div>
          <br class="clear" />
        </div>
        <div class="doble-cat">
          &nbsp;
        </div>
        <div class="pdlr5">
          <div class="home-cate-left">
            <uc:PanelSmallCateBox CategoryAlias="travel" ID="PanelSmallCateBox5" runat="server" />
          </div>
          <div class="home-cate-right">
            <uc:PanelSmallCateBox CategoryAlias="education" ID="PanelSmallCateBox6" runat="server" />
          </div>
          <br class="clear" />
        </div>
        <div class="doble-cat">
          &nbsp;
        </div>
        <div class="pdlr5">
          <div class="home-cate-left">
            <uc:PanelSmallCateBox CategoryAlias="science-technology" ID="PanelSmallCateBox7"
              runat="server" />
          </div>
          <div class="home-cate-right">
            <uc:PanelSmallCateBox CategoryAlias="environment" ID="PanelSmallCateBox8" runat="server" />
          </div>
          <br class="clear" />
        </div>
        <div class="doble-cat">
          &nbsp;
        </div>
        <div class="pdlr5">
          <div class="home-cate-left">
            <uc:PanelSmallCateBox CategoryAlias="sports" ID="PanelSmallCateBox9" runat="server" />
          </div>
          <div class="home-cate-right">
            <uc:PanelSmallCateBox CategoryAlias="world-news" ID="PanelSmallCateBox10" runat="server" />
          </div>
          <br class="clear" />
        </div>
        <div class="body680-bottom2">
          &nbsp;
        </div>
      </div>
      <!-- Day la doan Quang cao B34 -->
      <uc:PanelAdvB2 ID="PanelAdvB2_1" runat="server" />
      <!-- End doan Quang cao B34 -->
      <uc:PanelBigCateBox CategoryAlias="vietnam-in-photos" ID="PanelBigCateBox1" runat="server" />
      <uc:PanelBigCateBox CategoryAlias="what-on" ID="PanelBigCateBox2" runat="server" />
    </div>
    <div class="body310">
      <div class="pdlr5">
        <uc:PanelAdvC1 ID="PanelAdvC1_1" runat="server" />
        <uc:PanelCateLatestNews CategoryAlias="lastest-news" FirstIndexRecord="1" LastIndexRecord="10"
          ID="PanelCateLatestNews1" runat="server" />
        <uc:PanelVideoClip CategoryAlias="xa-hoi" ID="PanelVideoClip1" runat="server" />
        <uc:PanelTellUs CategoryAlias="reader-tell-us" ID="PanelTellUs1" runat="server" />
        <uc:PanelAdvC2 ID="PanelAdvC2_2" runat="server" />
      </div>
      <div class="body310-bottom">
        &nbsp;
      </div>
    </div>
    <br class="clear" />
    <uc:PanelInFocus CategoryAlias="in-focus" FirstIndexRecord="1" LastIndexRecord="13"
      ID="PanelInFocus1" runat="server" />
    <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" CategoryAlias="homepage" />
  </div>
</asp:Content>
