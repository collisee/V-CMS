<%@ OutputCache CacheProfile="SystemCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="RSS.aspx.cs"
  Inherits="VietNamNet.Websites.Sport.RSS" %>

<%@ Register Src="~/UserControls/RSS/PanelRSS.ascx" TagName="PanelRSS" TagPrefix="uc" %>

<%@ Register Src="~/UserControls/PanelTheodong.ascx" TagName="PanelTheodong" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <uc:PanelRSS ID="PanelRSS1" runat="server" />
  <uc:PanelTheodong ID="PanelTheodong1" runat="server" CategoryAlias="theo-dong-su-kien" FirstIndexRecord="1"
    LastIndexRecord="10" />
</asp:Content>
