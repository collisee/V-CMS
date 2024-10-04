<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import namespace="VietNamNet.Layout.Mobile.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCategory.ascx.cs"
    Inherits="VietNamNet.Layout.Mobile.V1.UserControls.PanelCategory" %>
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
                <asp:Repeater ID="rptCategoryImg" runat="server">
                    <ItemTemplate>
                        <tr>
                            <%--<td align="left" valign="top" class="noibat-img" valign="middle" width="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "0" : "110" %>">
                                <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#VNN4MobileUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "" %>">
                                    <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>&width=110" width="110" /></a>
                            </td>--%>
                            <td align="left" class="cate-text" valign="top">
                                <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#VNN4MobileUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "" %>">
                                    <img class="img-top" alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>&width=100" width="100" align="left" /></a>
                                <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#VNN4MobileUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                                </a>
                                <p class="cate-intro">
                                    <%#DataBinder.Eval(Container.DataItem, "Lead") %>
                                </p>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
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
