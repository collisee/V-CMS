<%@ OutputCache CacheProfile="ArticleCache" %>
<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="NewsDetail.aspx.cs"
    Inherits="VietNamNet.Websites.English.NewsDetail" %>

<%@ Register Src="UserControls/PanelTellUs.ascx" TagName="PanelTellUs" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelTopStory.ascx" TagName="PanelTopStory" TagPrefix="uc" %>
<%@ Register Src="UserControls/Survey/PaneSurvey.ascx" TagName="PaneSurvey" TagPrefix="vnn" %>
<%@ Register Src="UserControls/News/RightComment.ascx" TagName="RightComment" TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentListFeedback.ascx" TagName="PanelContentListFeedback"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelReadBox.ascx" TagName="PanelReadBox" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelLatestNews.ascx" TagName="PanelLatestNews" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelInFocus.ascx" TagName="PanelInFocus" TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentReadOn.ascx" TagName="PanelContentReadOn"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentFeedback.ascx" TagName="PanelContentFeedback"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentNews.ascx" TagName="PanelContentNews"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentSocialBar.ascx" TagName="PanelContentSocialBar"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentCateName.ascx" TagName="PanelContentCateName"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
    TagPrefix="uc" %>

<%@ Register Src="UserControls/Advertisements/PanelAdvB1.ascx" TagName="PanelAdvB1" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB2.ascx" TagName="PanelAdvB2" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB3.ascx" TagName="PanelAdvB3" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC1.ascx" TagName="PanelAdvC1" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC2.ascx" TagName="PanelAdvC2" TagPrefix="uc" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-body">
        <div class="body680">
            <div class="body680-top3">
                &nbsp;</div>
            <div class="body680-box3">
                <div class="pdlr5">
                    <uc:PanelContentCateName ID="PanelContentCateName1" runat="server" />
                    <div class="content-article">
                        <uc:PanelContentNews ID="PanelContentNews1" runat="server" />
                         <vnn:PaneSurvey ID="PaneSurvey1" runat="server" />
                    </div>
                    <div class="pd5 ">
                        <uc:PanelContentFeedback ID="PanelContentFeedback1" runat="server" />
                        <uc:PanelContentReadOn ID="PanelContentReadOn1" runat="server" />
                        <br class="clear" />
                        <uc:PanelContentListFeedback ID="PanelContentListFeedback1" runat="server" />
                    </div>
                </div>
                <div class="body680-bottom3">
                    &nbsp;</div>
            </div>
            <uc:PanelAdvB1 ID="PanelAdvB1_1" runat="server" />
        </div>
        <div class="body310">
            <div class="body310-top">
                &nbsp;</div>
            <div class="pdlr5">
                <uc:PanelAdvC1 ID="PanelAdvC1_1" runat="server" />
                <uc:PanelTopStory CategoryAlias="top-stories" FirstIndexRecord="1" LastIndexRecord="10" id="PanelTopStory1" runat="server" />
                <uc:PanelLatestNews CategoryAlias="lastest-news" FirstIndexRecord="1" LastIndexRecord="10" ID="PanelLatestNews1" runat="server" /> 
                <uc:PanelTellUs CategoryAlias="reader-tell-us" ID="PanelTellUs1" runat="server" />
                <uc:PanelAdvC1 ID="PanelAdvC1_2" runat="server" />
            </div>
            <div class="body310-bottom">
                &nbsp;</div>
        </div>
        <br class="clear" />
        <uc:PanelInFocus CategoryAlias="in-focus" FirstIndexRecord="1" LastIndexRecord="13"
            ID="PanelInFocus1" runat="server" />
    </div>
    <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" CategoryAlias="homepage" />
</asp:Content>
