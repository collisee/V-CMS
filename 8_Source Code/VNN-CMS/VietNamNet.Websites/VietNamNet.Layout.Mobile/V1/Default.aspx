<%@ Page MasterPageFile="~/V1/Default.Master" Language="C#" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="VietNamNet.Layout.Mobile.V1.Default1" %>
<%@ Register Src="UserControls/PanelTopNews.ascx" TagName="PanelTopNews" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelHotNews.ascx" TagName="PanelHotNews" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelCategory.ascx" TagName="PanelCategory" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelMostRead.ascx" TagName="PanelMostRead" TagPrefix="uc" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <table cellpadding="0" cellspacing="0" class="table-content" width="99%">
        <tr>
            <td align="left" class="content-item" valign="top">
                <%--<uc:PanelTopNews ID="PanelTopNews1" runat="server" />--%>
                <%--<uc:PanelHotNews ID="PanelHotNews1" runat="server" CategoryAlias="moi-nong" FirstIndexRecord="1" LastIndexRecord="4" />--%>
                <uc:PanelCategory ID="PanelCategory0" runat="server" CategoryAlias="moi-nong" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory1" runat="server" CategoryAlias="xa-hoi" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory2" runat="server" CategoryAlias="giao-duc" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory3" runat="server" CategoryAlias="the-gioi" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory4" runat="server" CategoryAlias="van-hoa" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory5" runat="server" CategoryAlias="kinh-te" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory6" runat="server" CategoryAlias="the-thao" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory7" runat="server" CategoryAlias="ttol" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory8" runat="server" CategoryAlias="2sao" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory9" runat="server" CategoryAlias="cong-nghe" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory10" runat="server" CategoryAlias="khoa-hoc" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory11" runat="server" CategoryAlias="ban-doc" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelCategory ID="PanelCategory12" runat="server" CategoryAlias="tam-diem" FirstIndexRecord="1" LastIndexRecord="4" />
            </td>
        </tr>
        <tr>
            <td>
                <uc:PanelMostRead ID="PanelMostRead1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
