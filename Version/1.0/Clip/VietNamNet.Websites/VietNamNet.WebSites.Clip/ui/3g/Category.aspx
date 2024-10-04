<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="Category.aspx.cs"
  Inherits="VietNamNet.Websites.Clip.ui._3g.Category" Title="VietNamNet - 3G Hot | 3G Hot" %>

<%@ Register Src="PanelClipNoibat.ascx" TagName="PanelClipNoibat" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCatePoll.ascx" TagName="PanelCatePoll"
  TagPrefix="vnnSurvey" %>
<%@ Register Src="~/UserControls/Categories/PanelTamdiem3g.ascx" TagName="PanelTamdiem3g"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCate3gContent.ascx" TagName="PanelCate3gContent"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateTicker.ascx" TagName="PanelCateTicker"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelMostRead.ascx" TagName="PanelMostRead"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelCateBox1.ascx" TagName="PanelCateBox1"
  TagPrefix="uc" %>
<%@ Register Src="PanelCategoryPlaylist.ascx" TagName="PanelCategoryPlaylist" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvB_1.ascx" TagName="PanelAdvB_1"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_1_3.ascx" TagName="PanelAdvC_1_3"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_4_5.ascx" TagName="PanelAdvC_4_5"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_6_14.ascx" TagName="PanelAdvC_6_14"
  TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--<uc:PanelCateTicker ID="PanelCateTicker1" runat="server" />--%>
  <div id="icon">
    <div class="cate">
      <a href="/vn/video-3g-hot/index.html">clip mobile</a>
    </div>
    <%--          <div class="clip_update">
			Cập nhật lúc 9h00 ngày 24/5/2010
		  </div>
--%>
  </div>
  <div id="home4">
    <!-- Tieu Diem -->
    <div id="home4_1">
      <uc:PanelCategoryPlaylist ID="PanelCategoryPlaylist1" runat="server" CategoryAlias="video-3g-hot" />
      <div class="clip_class3 row">
        <a href="#" class="clip_cate_link">
          <img alt="" title="" src="/images/thoisu.jpg" width="168" height="60" /></a> <a href="#"
            class="clip_cate_link">
            <img alt="" title="" src="/images/mobile.jpg" width="168" height="60" /></a>
        <a href="#" class="clip_cate_link">
          <img alt="" title="" src="/images/giaitri.jpg" width="168" height="60" /></a>
      </div>
    </div>
    <div id="home4_2">
      <div class="sent_clip">
        <img alt="Gửi video" title="Gửi video" src="/images/sentfile.gif" width="300" height="54" /></div>
      <uc:PanelAdvC_1_3 ID="PanelAdvC_1_3_1" runat="server" />
    </div>
    <!-- END Tieu Diem -->
  </div>
  <div class="clear">
    ,</div>
  <div id="home5">
    <div class="home5left">
      <!--qc center-->
      <uc:PanelCate3gContent ID="PanelCate3gContent1" runat="server" CategoryAlias="video-3g-hot" />
    </div>
    <div class="home5right">
      <div class="home5_right">
        <div class=" row">
          <!--top statitic-->
          <%--<uc:PanelMostRead ID="PanelMostRead1" runat="server" CategoryAlias="xa-hoi" />--%>
          <uc:PanelClipNoibat id="PanelClipNoibat1" runat="server" CategoryAlias="video-3g-hot"
            FirstIndexRecord="1" LastIndexRecord="3"/>
          <!--top statitic end-->
          <!--qc right2-->
          <uc:PanelTamdiem3g ID="PanelTamdiem3g1" runat="server" CategoryAlias="video-3g-hot"
            FirstIndexRecord="1" LastIndexRecord="4" />
          <div class="clear">
            ,</div>
          <!--qc right2 end-->
        </div>
        <div class=" row">
          <div>
            <div class="tt_ck">
              <!--top Theodongsukien-->
              <uc:PanelCateBox1 CategoryAlias="video-3g-hot" ID="PanelCateBox1_2" runat="server" />
              <!--top Theodongsukien end-->
              <vnnSurvey:PanelCatePoll ID="PanelCatePoll1" runat="server" />
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
  <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" />
</asp:Content>
