<%@ OutputCache CacheProfile="ArticleCache" %>
<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="NewsDetailPrint.aspx.cs" Inherits="VietNamNet.Websites.English.NewsDetailPrint" %>

<%@ Register Src="UserControls/News/PanelContentNews.ascx" TagName="PanelContentNews" TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelContentCateName.ascx" TagName="PanelContentCateName" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-body">
        <uc:PanelContentCateName ID="PanelContentCateName1" runat="server" />
        <div class="content-article">
            <uc:PanelContentNews ID="PanelContentNews1" runat="server" />
        </div>
    </div>
</asp:Content>

