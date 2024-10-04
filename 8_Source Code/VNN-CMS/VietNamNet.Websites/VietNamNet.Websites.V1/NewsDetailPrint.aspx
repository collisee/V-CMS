<%@ OutputCache CacheProfile="ArticleCache" %>

<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="NewsDetailPrint.aspx.cs"
    Inherits="VietNamNet.Websites.V1.NewsDetailPrint" %>

<%@ Register Src="UserControls/News/PanelNewDetailPrint.ascx" TagName="PanelNewDetailPrint" TagPrefix="uc" %>
<%@ Register Src="UserControls/Categories/PanelCateTicker.ascx" TagName="PanelCateTicker" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement" TagPrefix="uc" %>
    
     
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div id="home5">
        <uc:PanelCateTicker ID="PanelCateTicker1" runat="server" />
        <uc:PanelNewDetailPrint id="PanelNewsDetail1" runat="server" /> 
    </div>
    <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" />
</asp:Content>
