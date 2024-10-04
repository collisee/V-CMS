<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs"
  Inherits="VietNamNet.Websites.Petro._Default" %>

<%@ Register Src="UserControls/PanelLeft.ascx" TagName="PanelLeft" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelRight.ascx" TagName="PanelRight" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
  <uc:PanelLeft ID="PanelLeft1" runat="server" />
  <uc:PanelRight ID="PanelRight1" runat="server" />
</asp:Content>
