<%@ Page MasterPageFile="~/V1/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="VietNamNet.Layout.Mobile.V1.News" %>
<%@ Register Src="~/UserControls/PanelNewsDetail.ascx" TagName="PanelNewsDetail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelNewsMore.ascx" TagName="PanelNewsMore" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <table border="0" cellpadding="0" cellspacing="0" width="99%">
        <tr>
            <td class="cate-title" align="left">
                <asp:HyperLink ID="lnkCategory" runat="server" NavigateUrl="/vn/index.html"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="left">
                <uc:PanelNewsDetail ID="PanelNewsDetail1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <uc:PanelNewsMore ID="PanelNewsMore1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
