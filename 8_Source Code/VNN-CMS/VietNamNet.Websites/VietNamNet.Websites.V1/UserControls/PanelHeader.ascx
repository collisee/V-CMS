<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelHeader.ascx.cs"
    Inherits="VietNamNet.Websites.V1.UserControls.PanelHeader" %>
<%@ Register Src="PanelAdvA.ascx" TagName="PanelAdvA" TagPrefix="uc" %>
<div id="header">
    <uc:PanelAdvA ID="PanelAdvA_1" runat="server" />
    <div id="logo">
        <a class="logo transp" href="/vn/index.html"></a>
    </div>
    <div class="clear">
        ,</div>
</div>
