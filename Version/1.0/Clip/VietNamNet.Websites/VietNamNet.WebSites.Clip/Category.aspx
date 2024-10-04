<%@ OutputCache CacheProfile="CategoryCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="Category.aspx.cs"
  Inherits="VietNamNet.WebSites.Clip.Category" Title="Untitled Page" %>

<%@ Register Src="~/UserControls/PanelClipNoibat.ascx" TagName="PanelClipNoibat"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelTamdiem3g.ascx" TagName="PanelTamdiem3g" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelCate3gContent.ascx" TagName="PanelCate3gContent"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelCategoryPlaylist.ascx" TagName="PanelCategoryPlaylist"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvB_1.ascx" TagName="PanelAdvB_1" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvC_1_3.ascx" TagName="PanelAdvC_1_3" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvC_4_5.ascx" TagName="PanelAdvC_4_5" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvC_6_14.ascx" TagName="PanelAdvC_6_14" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="icon">
    <div class="cate">
      <a href="/vn/index.html">clip mobile</a>
    </div>
  </div>
  <div id="home4">
    <!-- Tieu Diem -->
    <div id="home4_1">
      <uc:PanelCategoryPlaylist ID="PanelCategoryPlaylist1" runat="server" />
      <div class="clip_class3 row">
        <a href="/vn/clip-mobile-thoi-su/index.html" class="clip_cate_link">
          <img alt="" title="" src="/images/thoisu.jpg" width="168" height="60" /></a> <a href="/vn/clip-mobile-mobile/index.html"
            class="clip_cate_link">
            <img alt="" title="" src="/images/mobile.jpg" width="168" height="60" /></a>
        <a href="/vn/clip-mobile-radio/index.html" class="clip_cate_link">
          <img alt="" title="" src="/images/radio.gif" width="168" height="60" /></a>
      </div>
    </div>
    <div id="home4_2">
      <div class="sent_clip">
        <a href="/vn/upload/index.html" target="_blank"><img alt="Gửi video" title="Gửi video" src="/images/sentfile.gif" width="300" height="54" /></a></div>
      <uc:PanelAdvC_1_3 ID="PanelAdvC_1_3_1" runat="server" />
    </div>
    <!-- END Tieu Diem -->
  </div>
  <div class="clear">
    ,</div>
  <div id="home5">
    <div class="home5left">
      <!--qc center-->
      <uc:PanelCate3gContent ID="PanelCate3gContent1" runat="server" />
    </div>
    <div class="home5right">
      <div class="home5_right">
        <div class=" row">
          <!--top statitic-->
          <uc:PanelClipNoibat ID="PanelClipNoibat1" runat="server" CategoryAlias="clip-mobile-noi-bat"
            FirstIndexRecord="1" LastIndexRecord="3" />
          <!--qc right2-->
          <uc:PanelTamdiem3g ID="PanelTamdiem3g1" runat="server" CategoryAlias="clip-mobile-tieu-diem"
            FirstIndexRecord="1" LastIndexRecord="4" />
          <div class="clear">
            ,</div>
          <!--qc right2 end-->
        </div>
        <div class=" row">
          <div>
            <div class="tt_ck">

            </div>
            <!--qc right 3 -->
            <uc:PanelAdvC_6_14 ID="PanelAdvC_6_14_1" runat="server" />
            <!--qc right 3 end-->
            <div class="clear">
              ,</div>
          </div>
        </div>
      </div>
    </div>
    <div class="clear">
      ,</div>
  </div>
  <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" CategoryAlias="video_3g_hot" />
</asp:Content>
