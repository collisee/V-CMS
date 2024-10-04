<%@ OutputCache CacheProfile="HomepageCache" %>
<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="VietNamNet.Websites.Sports.Mobile.Default1" %>
<%@ Register Src="~/UserControls/PanelTopNews.ascx" TagName="PanelTopNews" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelCategory.ascx" TagName="PanelCategory" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelMostRead.ascx" TagName="PanelMostRead" TagPrefix="uc" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <table cellpadding="0" cellspacing="0" class="table-content" width="99%">
        <tr>
            <td align="left" class="content-item" valign="top">
                <uc:PanelCategory ID="PanelCategory0" runat="server" CategoryAlias="tin-noi-bat" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory1" runat="server" CategoryAlias="premier-league" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory2" runat="server" CategoryAlias="la-liga" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory3" runat="server" CategoryAlias="serie-a" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory4" runat="server" CategoryAlias="bundesliga" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory5" runat="server" CategoryAlias="champions-league" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory6" runat="server" CategoryAlias="v-league" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory7" runat="server" CategoryAlias="doi-tuyen-viet-nam" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory8" runat="server" CategoryAlias="hau-truong" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory9" runat="server" CategoryAlias="dien-dan" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory10" runat="server" CategoryAlias="giao-luu-truc-tuyen" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory11" runat="server" CategoryAlias="bbc-tieng-viet" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory12" runat="server" CategoryAlias="anh-the-thao" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelMostRead ID="PanelMostRead1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
