<%@ OutputCache CacheProfile="SystemCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="RSS.aspx.cs"
    Inherits="VietNamNet.Websites.English.RSS" %>

<%@ Register Src="UserControls/RSS/panelRSSdesc.ascx" TagName="panelRSSdesc" TagPrefix="rss" %>
<%@ Register Src="UserControls/Homepage/PanelTopNews.ascx" TagName="PanelTopNews"    TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelTopStories.ascx" TagName="PanelTopStories"    TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelSmallCateBox.ascx" TagName="PanelSmallCateBox"    TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelBigCateBox.ascx" TagName="PanelBigCateBox"    TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelTellUs.ascx" TagName="PanelTellUs" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelVideoClip.ascx" TagName="PanelVideoClip" TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateLatestNews.ascx" TagName="PanelCateLatestNews"    TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelInFocus.ascx" TagName="PanelInFocus" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"    TagPrefix="uc" %>
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
            <rss:panelRSSdesc ID="PanelRSSdesc1" runat="server" />
            <div class="body680-bottom3">
                &nbsp;
            </div>
            </div>
        </div>
        <div class="body310">
            <div class="pdlr5">
                <uc:PanelAdvC1 ID="PanelAdvC1_1" runat="server" />
                <uc:PanelCateTopStory CategoryAlias="top-stories" FirstIndexRecord="1" LastIndexRecord="8" ID="PanelCateTopStory1"
                    runat="server" />
                <uc:PanelCateLatestNews CategoryAlias="lastest-news" FirstIndexRecord="1" LastIndexRecord="10"
                    ID="PanelCateLatestNews1" runat="server" />
                <uc:PanelVideoClip CategoryAlias="xa-hoi" ID="PanelVideoClip1" runat="server" />
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
    <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" CategoryAlias="homepage" />
</asp:Content>
