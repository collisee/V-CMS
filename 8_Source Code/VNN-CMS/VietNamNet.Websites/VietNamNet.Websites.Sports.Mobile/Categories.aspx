<%@ OutputCache CacheProfile="CategoryCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="VietNamNet.Websites.Sports.Mobile.Categories" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/PanelCategory.ascx" TagName="PanelCategory" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <table cellpadding="0" cellspacing="0" class="table-content" width="99%">
        <tr>
            <td align="left" class="content-item" valign="top">
                <uc:PanelCategory ID="PanelCategory1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <div style="text-align:right;"><a href="/vn/<%=categoryAlias %>/page/<%=pageNumber + 1 %>/index.html">Xem tiếp...</a></div>
            </td>
        </tr>
    </table>
</asp:Content>
