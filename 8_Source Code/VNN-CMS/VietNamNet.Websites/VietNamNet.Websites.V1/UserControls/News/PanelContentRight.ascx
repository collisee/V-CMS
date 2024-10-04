<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentRight.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.News.PanelContentRight" %>
<%@ Register Src="PanelContentMoinong.ascx" TagName="PanelContentMoinong" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelCateBox1.ascx" TagName="PanelCateBox1" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelCateBox.ascx" TagName="PanelCateBox" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelMostRead.ascx" TagName="PanelMostRead" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_1_3.ascx" TagName="PanelAdvC_1_3"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_4_5.ascx" TagName="PanelAdvC_4_5"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_6_14.ascx" TagName="PanelAdvC_6_14"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelAdvC_17.ascx" TagName="PanelAdvC_17" TagPrefix="uc" %>
<div class="home5right">
  <div class="home5_right">
    <div>
      <uc:PanelContentMoinong id="PanelContentMoinong1" runat="server" CategoryAlias="moi-nong" />
      <uc:PanelAdvC_1_3 ID="PanelAdvC_1_3_1" runat="server" />
      <div class="clear">
        ,</div>
    </div>
    <!--top bvkh-->
    <uc:PanelCateBox ID="PanelCateBox1" runat="server" CategoryAlias="xa-hoi" FirstIndexRecord="1" LastIndexRecord="4" />
    <!--top bvkh end-->
    <!--top Nong-->
    <uc:PanelCateBox ID="PanelCateBox2" runat="server" CategoryAlias="quoc-te" FirstIndexRecord="1" LastIndexRecord="4" />
    <!--top Nong end-->
    <!--top Phapdinh-->
    <uc:PanelCateBox ID="PanelCateBox3" runat="server" CategoryAlias="chinh-tri" FirstIndexRecord="1" LastIndexRecord="4" />
    <!--top Phapdinh end-->
    <div class=" row">
      <!--top statitic-->
      <uc:PanelMostRead ID="PanelMostRead1" runat="server" />
      <!--top statitic end-->
      <!--qc right2-->
      <uc:PanelAdvC_4_5 ID="PanelAdvC_4_5_1" runat="server" />
      <div class="clear">
        ,</div>
      <!--qc right2 end-->
    </div>
    <div class=" row">
      <div>
        <div class="tt_ck"> 
          <!--top Theodongsukien-->
          <uc:PanelCateBox1 ID="PanelCateBox1_1" runat="server" CategoryAlias="giao-duc" FirstIndexRecord="1" LastIndexRecord="3" />
          <!--top Theodongsukien end-->
          <!--top Tieudiem-->
          <uc:PanelCateBox1 ID="PanelCateBox1_2" runat="server" CategoryAlias="khoa-hoc" FirstIndexRecord="1" LastIndexRecord="3" />
          <!--top Tieudiem end-->
           <uc:PanelAdvC_17 ID="PanelAdvC_17_1" runat="server" />
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