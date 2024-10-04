<%@ Import namespace="VietNamNet.Layout.Mobile.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelMostRead.ascx.cs"
    Inherits="VietNamNet.Layout.Mobile.V1.UserControls.PanelMostRead" %>
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="left" valign="top">
            <table cellpadding="0" cellspacing="0" width="99%">
                <tr>
                    <td class="cate-title" colspan="2">
                        <asp:HyperLink ID="lnkCategory" runat="server" NavigateUrl="/vn/index.html"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="content-item">
            <table cellpadding="0" cellspacing="0" class="table-cate" width="99%">
                <asp:Repeater ID="rptCategory" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="cate-item" colspan="2">
                                <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#VNN4MobileUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                                </a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </td>
    </tr>
</table>
