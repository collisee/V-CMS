<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentRight.ascx.cs"
  Inherits="VietNamNet.Websites.Clip.UserControls.News.PanelContentRight" %>
<%@ Register Src="~/UserControls/Categories/PanelCatePoll.ascx" TagName="PanelCatePoll" TagPrefix="vnnSurvey" %>
<%@ Register Src="PanelContentPoll.ascx" TagName="PanelContentPoll" TagPrefix="uc" %>
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
<div class="home5right">
  <div class="home5_right">
    <div>
      <uc:PanelContentMoinong id="PanelContentMoinong1" runat="server" CategoryAlias="moi-nong" />
      <uc:PanelAdvC_1_3 ID="PanelAdvC_1_3_1" runat="server" />
      <div class="clear">
        ,</div>
    </div>
    <!--top bvkh-->
    <uc:PanelCateBox ID="PanelCateBox1" runat="server" CategoryAlias="xa-hoi-chuyen-dong-tre" />
    <!--top bvkh end-->
    <!--top Nong-->
    <uc:PanelCateBox ID="PanelCateBox2" runat="server" CategoryAlias="xa-hoi-ghi-tu-phap-dinh" Visible="false" />
    <!--top Nong end-->
    <!--top Phapdinh-->
    <uc:PanelCateBox ID="PanelCateBox3" runat="server" CategoryAlias="quoc-te-the-gioi-do-day" />
    <!--top Phapdinh end-->
    <div class=" row">
      <!--top statitic-->
      <uc:PanelMostRead ID="PanelMostRead1" runat="server" CategoryAlias="xa-hoi" />
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
            <vnnSurvey:PanelCatePoll ID="PanelCatePoll1" runat="server" />
            
          <!--top Theodongsukien-->
          <uc:PanelCateBox1 ID="PanelCateBox1_1" runat="server" CategoryAlias="xa-hoi-tieu-diem" />
          <!--top Theodongsukien end-->
          <!--top Tieudiem-->
          <div class="row">
            <uc:PanelCateBox1 ID="PanelCateBox1_2" runat="server" CategoryAlias="theo-dong-su-kien" />
          </div>
          <!--top Tieudiem end-->
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