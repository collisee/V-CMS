<%@ OutputCache CacheProfile="ArticleCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="NewsDetailPrint.aspx.cs" Inherits="VietNamNet.Websites.Sport.NewsDetailPrint" %>

<%@ Register Src="UserControls/News/PanelContentNewsPrint.ascx" TagName="PanelContentNewsPrint" TagPrefix="uc" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-article-detail pdl5">
        <uc:PanelContentNewsPrint id="PanelContentNewsPrint1" runat="server" />
    </div>
    <br class="clear" />
</asp:Content>
