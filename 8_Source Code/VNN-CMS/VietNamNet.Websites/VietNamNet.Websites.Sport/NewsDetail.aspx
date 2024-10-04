<%@ OutputCache CacheProfile="ArticleCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="NewsDetail.aspx.cs"
    Inherits="VietNamNet.Websites.Sport.NewsDetail" %>

<%@ Register Src="UserControls/News/PanelHotNews.ascx" TagName="PanelHotNews" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/News/PanelArticleTracking.ascx" TagName="PanelArticleTracking" TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentListFeedback.ascx" TagName="PanelContentListFeedback" TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentListFeedback1.ascx" TagName="PanelContentListFeedback1" TagPrefix="uc" %>

<%@ Register Src="UserControls/News/PanelOtherNews.ascx" TagName="PanelOtherNews" TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelNewsFeedback.ascx" TagName="PanelNewsFeedback" TagPrefix="uc" %> 
<%@ Register Src="UserControls/Survey/PaneGame.ascx" TagName="PaneGame" TagPrefix="Survey" %>
<%@ Register Src="UserControls/News/PanelContentImageSport.ascx" TagName="PanelContentImageSport" TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentSportComment.ascx" TagName="PanelContentSportComment" TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentNewsPath.ascx" TagName="PanelContentNewsPath" TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentNews.ascx" TagName="PanelContentNews" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelTheodong.ascx" TagName="PanelTheodong" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvB1.ascx" TagName="PanelAdvB1" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC4.ascx" TagName="PanelAdvC4" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC5.ascx" TagName="PanelAdvC5" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC6.ascx" TagName="PanelAdvC6" TagPrefix="uc" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC7.ascx" TagName="PanelAdvC7" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-left">
        <div class="home-article-detail pdl5">
            <uc:PanelContentNewsPath ID="PanelContentNewsPath1" runat="server" />
            <uc:PanelContentNews ID="PanelContentNews1" runat="server" />  
                         
            <uc:PanelAdvB1 ID="PanelAdvB1_1" runat="server" />
             
            <uc:PanelContentListFeedback ID="PanelContentListFeedback1" runat="server" Visible="false" />  
            <uc:PanelContentListFeedback1 ID="PanelContentListFeedback2" runat="server" />  
                   
            <uc:PanelNewsFeedback ID="PanelNewsFeedback1" runat="server" />
            <uc:PanelHotNews FirstIndexRecord="1" LastIndexRecord="5" id="PanelHotNews1" runat="server" />
            <uc:PanelOtherNews FirstIndexRecord="1" LastIndexRecord="10" ID="PanelOtherNews1" runat="server" />
        </div>
    </div>
    <div class="home-right">
        <div class="box-list pdt2">
            <uc:PanelAdvC5 ID="PanelAdvC5_1" runat="server" />
       
            <Survey:PaneGame ID="PanelGame1" runat="server"  />          
            <uc:PanelContentImageSport ID="PanelContentImageSport1" runat="server" CategoryAlias="anh-the-thao" FirstIndexRecord="1" LastIndexRecord="5" />
            <uc:PanelAdvC6 ID="PanelAdvC6_1" runat="server" />
            <uc:PanelContentSportComment CategoryAlias="binh-luan-cung-nha-bao" FirstIndexRecord="1" LastIndexRecord="5" ID="PanelContentSportComment1" runat="server" />
            <uc:PanelAdvC7 ID="PanelAdvC7_1" runat="server" />
        </div>
        <uc:PanelAdvC4 ID="PanelAdvC4_1" runat="server" />
    </div>
    <br class="clear" />
    <uc:PanelTheodong ID="PanelTheodong1" runat="server" CategoryAlias="theo-dong-su-kien" FirstIndexRecord="1"
        LastIndexRecord="10" />
     <uc:PanelArticleTracking ID="PanelArticleTracking1" runat="server" />

<!-- Add code -->
	<script type="text/javascript" src="http://delivery.adnetwork.vn/247/adclick/ads_em9uZV9NVEk0T1RrNU16ZzBNbDh4TWpnNU9Ua3pOamN5WHpJME1GOHlNREE9Lmh0bWxVNzI4STdWRTEwMTAxMDc4Mk0zOFc=/"></script>
<!-- end of Add code -->
</asp:Content>
