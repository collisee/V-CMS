<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Category.aspx.cs"
  Inherits="VietNamNet.Websites.HSBC.Category" %>

<%@ Register Src="UserControls/PanelCategory.ascx" TagName="PanelCategory" TagPrefix="uc" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">  
  <uc:PanelCategory ID="PanelCategory1" runat="server" />
</asp:Content>
