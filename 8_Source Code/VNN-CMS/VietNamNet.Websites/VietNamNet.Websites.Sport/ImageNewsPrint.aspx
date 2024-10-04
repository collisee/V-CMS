<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ImageNewsPrint.aspx.cs" Inherits="VietNamNet.Websites.Sport.ImageNewsPrint" %>

<%@ Register Src="UserControls/News/PanelSlideImagePrint.ascx" TagName="PanelSlideImagePrint" TagPrefix="uc" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-article-detail pdl5">
       <div id="thethao_slider">
          <uc:PanelSlideImagePrint ID="PanelSlideImagePrint1" runat="server" />
        </div>        
    </div>
    <br class="clear" />
    
</asp:Content>
