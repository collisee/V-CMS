<%@ Page MasterPageFile="~/V1/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="VietNamNet.Layout.Mobile.V1.Category" %>
<%@ Register Src="UserControls/PanelCategory.ascx" TagName="PanelCategory" TagPrefix="uc" %>
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
