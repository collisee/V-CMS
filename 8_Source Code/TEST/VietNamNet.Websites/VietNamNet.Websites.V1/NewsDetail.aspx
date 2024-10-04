<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="NewsDetail.aspx.cs"
    Inherits="VietNamNet.Websites.V1.NewsDetail" %>

<%@ Register Src="UserControls/Categories/PanelCateTicker.ascx" TagName="PanelCateTicker"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentPoll.ascx" TagName="PanelContentPoll"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelNewsDetail.ascx" TagName="PanelNewsDetail"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelNewsFeedback.ascx" TagName="PanelNewsFeedback"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelOtherNews.ascx" TagName="PanelOtherNews"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentRight.ascx" TagName="PanelContentRight"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="home5">
        <uc:PanelCateTicker ID="PanelCateTicker1" runat="server" />
        <div class="home5left">
            <uc:PanelNewsDetail ID="PanelNewsDetail1" runat="server" />
            <uc:PanelContentPoll ID="PanelContentPoll1" runat="server" />
            <uc:PanelNewsFeedback ID="PanelNewsFeedback1" runat="server" />
            <uc:PanelOtherNews ID="PanelOtherNews1" runat="server" />
        </div>
        <uc:PanelContentRight ID="PanelContentRight1" runat="server" />
        <div class="clear">
            ,</div>
    </div>
    <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" />
</asp:Content>
