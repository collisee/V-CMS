<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SystemMenu.ascx.cs" Inherits="VietNamNet.Framework.UserControls.LayoutDefault.SystemMenu" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadMenu runat="Server" ID="radMenu" Width="100%" Style="z-index:1000;"
    DataFieldID="Id" DataValueField="Id" DataFieldParentID="PId" DataTextField="DisplayName" DataNavigateUrlField="Link" OnItemDataBound="radMenu_ItemDataBound">
</telerik:RadMenu>
