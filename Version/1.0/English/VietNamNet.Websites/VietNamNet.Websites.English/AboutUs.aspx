<%@ OutputCache CacheProfile="SystemCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="AboutUs.aspx.cs"
    Inherits="VietNamNet.Websites.English.AboutUs" %>

<%@ Register Src="UserControls/PanelAboutUs.ascx" TagName="PanelAboutUs" TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateLatestNews.ascx" TagName="PanelCateLatestNews"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelTellUs.ascx" TagName="PanelTellUs" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelInFocus.ascx" TagName="PanelInFocus" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateTopStory.ascx" TagName="PanelCateTopStory"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC1.ascx" TagName="PanelAdvC1"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC2.ascx" TagName="PanelAdvC2"
  TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-body">
        <div class="body680">
            <div class="body680-box3">
            <div class="body680-top3a">
                &nbsp;
            </div>
            <uc:PanelAboutUs ID="PanelAboutUs1" runat="server" />
            <div class="body680-bottom3">
                &nbsp;
            </div>
            </div>
        </div>
        <div class="body310">
            <div class="body310-top">
                &nbsp;
            </div>
            <div class="pdlr5">
                <uc:PanelAdvC1 ID="PanelAdvC1_1" runat="server" />
                <uc:PanelCateTopStory CategoryAlias="top-stories" FirstIndexRecord="1" LastIndexRecord="8" ID="PanelCateTopStory1"
                    runat="server" />
                <uc:PanelCateLatestNews CategoryAlias="lastest-news" FirstIndexRecord="1" LastIndexRecord="10"
                    ID="PanelCateLatestNews1" runat="server" />
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
    </div>
    <div class="clear">
    </div>
    <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" CategoryAlias="homepage" />
</asp:Content>
