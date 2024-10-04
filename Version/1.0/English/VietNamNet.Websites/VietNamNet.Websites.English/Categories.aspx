<%@ OutputCache CacheProfile="CategoryCache" %>
<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Categories.aspx.cs"
    Inherits="VietNamNet.Websites.English.Categories" %>

<%@ Register Src="UserControls/PanelTellUs.ascx" TagName="PanelTellUs" TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateAd2.ascx" TagName="PanelCateAd2" TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateAd1.ascx" TagName="PanelCateAd1"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateLatestNews.ascx" TagName="PanelCateLatestNews"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateTopStory.ascx" TagName="PanelCateTopStory"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateReadBox.ascx" TagName="PanelCateReadBox"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateReadOn.ascx" TagName="PanelCateReadOn"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateContent.ascx" TagName="PanelCateContent"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelInFocus.ascx" TagName="PanelInFocus" TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateHotNews.ascx" TagName="PanelCateHotNews"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Category/PanelCateTopNews.ascx" TagName="PanelCateTopNews"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB1.ascx" TagName="PanelAdvB1"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB2.ascx" TagName="PanelAdvB2"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB3.ascx" TagName="PanelAdvB3"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC1.ascx" TagName="PanelAdvC1"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC2.ascx" TagName="PanelAdvC2"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-body">
        <div class="body-block1">
            &nbsp;</div>
        <div class="body680">
            <div class="body680-box1">
                <uc:PanelCateTopNews ID="PanelCateTopNews1" runat="server" />
                <uc:PanelCateHotNews FirstIndexRecord="1" LastIndexRecord="7" ID="PanelCateHotNews1" runat="server" />
                <br class="clear" />
                <div class="body680-bottom1a">
                    &nbsp;</div>
            </div>
            <!-- Day la doan Quang cao B12 -->
            <uc:PanelAdvB1 ID="PanelAdvB1_1" runat="server" />
            <!-- End doan Quang cao B12 -->
            <div class="body680-box3">
                <div class="body680-top3">
                    &nbsp;</div>
                <div class="pdlr5">
                    <uc:PanelCateContent FirstIndexRecord="1" LastIndexRecord="10" ID="PanelCateContent1"
                        runat="server" />
                    <uc:PanelCateReadOn FirstIndexRecord="1" LastIndexRecord="10" ID="PanelCateReadOn1"
                        runat="server" />
                </div>
                <div class="body680-bottom3">
                    &nbsp;</div>
            </div>
            <!-- Day la doan Quang cao B34 -->
            <uc:PanelAdvB2 ID="PanelAdvB2_1" runat="server" />
            <!-- End doan Quang cao B34 -->
        </div>
        <div class="body310">
            <div class="pdlr5">
                <uc:PanelAdvC1 ID="PanelAdvC1_1" runat="server" />
                <uc:PanelCateTopStory CategoryAlias="top-stories" FirstIndexRecord="1" LastIndexRecord="8" ID="PanelCateTopStory1"
                    runat="server" />
                <uc:PanelCateLatestNews CategoryAlias="lastest-news" FirstIndexRecord="1" LastIndexRecord="10" ID="PanelCateLatestNews1"
                    runat="server" />
                <uc:PanelTellUs CategoryAlias="reader-tell-us" ID="PanelTellUs1" runat="server" />                
                <uc:PanelAdvC2 ID="PanelAdvC2_2" runat="server" />
            </div>
            <div class="body310-bottom">
                &nbsp;</div>
        </div>
        <br class="clear" />
        <uc:PanelInFocus FirstIndexRecord="1" LastIndexRecord="15" ID="PanelInFocus1" runat="server"
            CategoryAlias="in-focus" />
    </div>
    <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" CategoryAlias="homepage" />
</asp:Content>
