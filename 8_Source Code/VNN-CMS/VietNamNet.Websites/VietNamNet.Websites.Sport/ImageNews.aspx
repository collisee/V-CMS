<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ImageNews.aspx.cs" Inherits="VietNamNet.Websites.Sport.ImageNews" %>

<%@ Register Src="UserControls/News/PanelSlideImagePath.ascx" TagName="PanelSlideImagePath"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelSlideImageContent.ascx" TagName="PanelSlideImageContent"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelSlideImageList.ascx" TagName="PanelSlideImageList"
    TagPrefix="uc" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-article-detail pdl5">
       <div id="thethao_slider">
           <uc:PanelSlideImagePath id="PanelSlideImagePath1" runat="server" />
           <uc:PanelSlideImageContent id="PanelSlideImageContent1" runat="server" />   
           <uc:PanelSlideImageList ID="PanelSlideImageList1" runat="server" />           
</div>        
    </div>
    <br class="clear" />
</asp:Content>
