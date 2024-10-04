<%@ OutputCache CacheProfile="CategoryCache" %>
<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Search.aspx.cs"    Inherits="VietNamNet.Websites.V1.Search" Title="Tìm kiếm" %>
<%@ Register Src="UserControls/Search/PanelSearchContent.ascx" TagName="PanelSearchContent" TagPrefix="vnnSearch" %>
 
<%@ Register Src="~/UserControls/Search/PanelTitle.ascx" TagName="PanelTitle"  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateContent.ascx" TagName="PanelCateContent"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelOtherNews.ascx" TagName="PanelOtherNews"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelCateBox.ascx" TagName="PanelCateBox"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateMonongContent.ascx" TagName="PanelCateMonongContent"
  TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1"> 
   <uc:PanelTitle ID="PanelTitle1" runat="server"  Title="Tìm kiếm" />

  <div id="home5">    
    <div class="home5left">
        <div class="row list-news2">
            <vnnSearch:PanelSearchContent ID="PanelSearchContent1" runat="server" /> 
        </div>
    </div>
    <div class="home5right">
      <div class="home5_right">
        <uc:PanelCateBox CategoryAlias="xa-hoi" FirstIndexRecord="1" LastIndexRecord="4"
          ID="PanelCateBox1" runat="server" />
        <uc:PanelCateBox CategoryAlias="giao-duc" FirstIndexRecord="1" LastIndexRecord="4"
          ID="PanelCateBox2" runat="server" />
        <uc:PanelCateBox CategoryAlias="chinh-tri" FirstIndexRecord="1" LastIndexRecord="4"
          ID="PanelCateBox3" runat="server" />
        <uc:PanelCateBox CategoryAlias="phong-su-dieu-tra" FirstIndexRecord="1" LastIndexRecord="4"
          ID="PanelCateBox4" runat="server" />
        <uc:PanelCateBox CategoryAlias="kinh-te" FirstIndexRecord="1" LastIndexRecord="4"
          ID="PanelCateBox5" runat="server" />
        <uc:PanelCateBox CategoryAlias="quoc-te" FirstIndexRecord="1" LastIndexRecord="4"
          ID="PanelCateBox6" runat="server" />
        <uc:PanelCateBox CategoryAlias="van-hoa" FirstIndexRecord="1" LastIndexRecord="4"
          ID="PanelCateBox7" runat="server" />
        <uc:PanelCateBox CategoryAlias="khoa-hoc" FirstIndexRecord="1" LastIndexRecord="4"
          ID="PanelCateBox8" runat="server" />
        <uc:PanelCateBox CategoryAlias="cong-nghe-thong-tin-vien-thong" FirstIndexRecord="1"
          LastIndexRecord="4" ID="PanelCateBox9" runat="server" />
        <uc:PanelCateBox CategoryAlias="ban-doc-phap-luat" FirstIndexRecord="1" LastIndexRecord="4"
          ID="PanelCateBox10" runat="server" />
      </div>
    </div>
    <div class="clear">
    </div>
  </div>
  <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server"  CategoryAlias="trang-chu"/>

</asp:Content>
