<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="NewsDetailPrint.aspx.cs" Inherits="VietNamNet.Websites.Clip.NewsDetailPrint" %>

<%@ Register Src="~/UserControls/PanelNewsDetail.ascx" TagName="PanelNewsDetail"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .article_content{width:100%;}
        #article-tool{display:none;}
        .icon-slot, .link_hot{display:none;}
    </style>
    <div id="home5">
        <uc:PanelNewsDetail ID="PanelNewsDetail1" runat="server" />
    </div>
    <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" />
</asp:Content>
