<%@ Import Namespace="VietNamNet.Websites.Petro.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelLeft.ascx.cs" Inherits="VietNamNet.Websites.Petro.UserControls.PanelLeft" %>
<%@ Register Src="Homepage/PanelCategories.ascx" TagName="PanelCategories" TagPrefix="uc" %>
<%@ Register Src="Homepage/PanelHotNews.ascx" TagName="PanelHotNews" TagPrefix="uc" %>
<%@ Register Src="Homepage/PanelTopNews.ascx" TagName="PanelTopNews" TagPrefix="uc" %>
<%@ Register Src="Homepage/PanelTopVideo.ascx" TagName="PanelTopVideo" TagPrefix="uc" %>
<div class="homeleft">
    <uc:PanelHotNews ID="PanelHotNews1" runat="server" CategoryAlias="tin-hot" />
    <div class="cate-list row">
        <div class="cate">
            <uc:PanelTopNews ID="PanelTopNews1" runat="server" />
            <uc:PanelTopVideo ID="PanelTopVideo1" runat="server" />
            <div class="clear">&nbsp;</div>
        </div>
        <uc:PanelCategories ID="PanelCategories1" runat="server" CategoryAlias="dong-chay-vang-den" />
        <uc:PanelCategories ID="PanelCategories2" runat="server" CategoryAlias="bien-dau" />
        <uc:PanelCategories ID="PanelCategories3" runat="server" CategoryAlias="mach-dau" />
        <uc:PanelCategories ID="PanelCategories4" runat="server" CategoryAlias="hydrocarbon-300-do-c" />
        <uc:PanelCategories ID="PanelCategories5" runat="server" CategoryAlias="camera-dau-khi" />
        <uc:PanelCategories ID="PanelCategories6" runat="server" CategoryAlias="nguoi-di-tim-lua" />
        <uc:PanelCategories ID="PanelCategories7" runat="server" CategoryAlias="cua-so-dau" />
    </div>
</div>
