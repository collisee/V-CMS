<%@ OutputCache CacheProfile="CategoryCache" %>

<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="Category.aspx.cs"
  Inherits="VietNamNet.Websites.V1.ui.tinnoibat.Category" Title="Untitled Page" %>

<%@ Register Src="~/UserControls/Categories/PanelCateTicker.ascx" TagName="PanelCateTicker"
  TagPrefix="uc" %>
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
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <uc:PanelCateTicker ID="PanelCateTicker1" runat="server" />
  <div id="home5">
    <div class="home5left">
      <uc:PanelCateMonongContent ID="PanelCateMonongContent1" runat="server" />
      <%--<uc:PanelCateContent ID="PanelCateContent1" runat="server" />--%>
      <%--<uc:PanelOtherNews ID="PanelOtherNews1" runat="server" />--%>
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
  <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" />
</asp:Content>
