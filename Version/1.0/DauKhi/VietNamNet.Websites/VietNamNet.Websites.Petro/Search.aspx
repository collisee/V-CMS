<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="VietNamNet.Websites.Petro.Search" Title="Untitled Page" %>

<%@ Register Src="UserControls/PanelSearch.ascx" TagName="PanelSearch" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelRight.ascx" TagName="PanelRight" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplhContainer" runat="server">
  <uc:PanelSearch id="PanelSearch1" runat="server" />
  <uc:PanelRight ID="PanelRight1" runat="server" />
</asp:Content>