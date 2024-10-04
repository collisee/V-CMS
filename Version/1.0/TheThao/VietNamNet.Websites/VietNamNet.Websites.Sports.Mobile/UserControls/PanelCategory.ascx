<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import namespace="VietNamNet.Websites.Core.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCategory.ascx.cs"
    Inherits="VietNamNet.Websites.Sports.Mobile.UserControls.PanelCategory" %>
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="left" valign="top">
            <table cellpadding="0" cellspacing="0" width="99%">
                <tr>
                    <td class="cate-title" colspan="2">
                      <asp:Repeater ID="rptCateTitle" runat="server">
                        <ItemTemplate>
                          <%#WebsitesUtils.BuildCategoryLink(categoryUrl, DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
                        </ItemTemplate>
                      </asp:Repeater>
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
                            <td align="left" class="cate-text" valign="top">
                                <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                                    DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                                    DataBinder.Eval(Container.DataItem, "ImageLink"), "img-top\" align=\"left", 100)%>
                                <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                                    DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
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
                                <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                                    DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </td>
    </tr>
</table>
