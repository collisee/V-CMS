<%@ OutputCache CacheProfile="CategoryCache" %>
<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Search.aspx.cs"    Inherits="VietNamNet.Websites.Clip.Search" Title="Tìm kiếm" %>
<%@ Register Src="UserControls/Search/PanelSearchContent.ascx" TagName="PanelSearchContent" TagPrefix="vnnSearch" %>
 
<%@ Register Src="~/UserControls/PanelClipNoibat.ascx" TagName="PanelClipNoibat"  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelTamdiem3g.ascx" TagName="PanelTamdiem3g" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"   TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvB_1.ascx" TagName="PanelAdvB_1" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvC_1_3.ascx" TagName="PanelAdvC_1_3" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvC_4_5.ascx" TagName="PanelAdvC_4_5" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvC_6_14.ascx" TagName="PanelAdvC_6_14" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1"> 
<div id="icon">
    <div class="cate">
      <a href="/vn/index.html">Tìm kiếm</a>
    </div>
  </div>
<div id="home5">
    <div class="home5left">
        <div id="list_clip_new" class="row" >
            <vnnSearch:PanelSearchContent ID="PanelSearchContent1" runat="server" />
        </div>
    </div>
    <div class="home5right"> 
    <div class="home5_right"> 
        <div class="row">
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
</div> 
<div class="clear">
            ,</div>
</asp:Content>
