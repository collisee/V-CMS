<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VerticalMenu.ascx.cs"
    Inherits="VietNamNet.Framework.UserControls.LayoutClassical.VerticalMenu" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div>
    <telerik:RadTreeView runat="server" ID="radMenu" Style="overflow: visible;"
        DataFieldID="Id" DataValueField="Id" DataFieldParentID="PId" DataTextField="DisplayName" DataNavigateUrlField="Link" OnNodeDataBound="radMenu_NodeDataBound">
        <CollapseAnimation Type="OutQuint" Duration="100"></CollapseAnimation>
        <ExpandAnimation Duration="100"></ExpandAnimation>
    </telerik:RadTreeView>
</div>
<div>
    &nbsp;</div>
