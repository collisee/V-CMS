<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import namespace="VietNamNet.Websites.Core.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelMostRead.ascx.cs"
    Inherits="VietNamNet.Websites.Sports.Mobile.UserControls.PanelMostRead" %>
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="left" valign="top">
            <table cellpadding="0" cellspacing="0" width="99%">
                <tr>
                    <td class="cate-title" colspan="2">
                        Đọc nhiều nhất
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
                                <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                                    DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </td>
    </tr>
</table>
