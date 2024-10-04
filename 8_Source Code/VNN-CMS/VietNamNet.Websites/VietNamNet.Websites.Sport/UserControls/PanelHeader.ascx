<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelHeader.ascx.cs"
    Inherits="VietNamNet.Websites.Sport.UserControls.PanelHeader" %>
<%@ Register Src="Advertisements/PanelAdvA.ascx" TagName="PanelAdvA" TagPrefix="uc" %>
<div class="home-header">
    <div class="logo-thethao">
        <a href="/">
            <img alt="Trang chủ" title="Trang chủ" src="http://res.vietnamnet.vn/images/blank.gif" width="230" height="47" /></a>
        <div class="time-update pdt10">
            Cập nhật
            <%=Utilities.FormatDisplayDateTime(DateTime.Now) %>
            (GMT+7)
        </div>
    </div>
    <uc:PanelAdvA id="PanelAdvA1" runat="server" />
    <br class="clear" />
</div>