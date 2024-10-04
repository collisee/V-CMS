<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Category.aspx.cs"
  Inherits="VietNamNet.Websites.Petro.Category" %>

<%@ Register Src="UserControls/Categories/PanelCategory.ascx" TagName="PanelCategory" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelRight.ascx" TagName="PanelRight" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">  
  <uc:PanelCategory ID="PanelCategory1" runat="server" />
  <uc:PanelRight ID="PanelRight1" runat="server" />
</asp:Content>
