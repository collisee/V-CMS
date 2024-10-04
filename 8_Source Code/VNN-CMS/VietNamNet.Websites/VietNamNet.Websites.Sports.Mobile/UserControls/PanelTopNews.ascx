<%@ Import namespace="VietNamNet.Websites.Core.Common"%>
<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelTopNews.ascx.cs" Inherits="VietNamNet.Websites.Sports.Mobile.UserControls.PanelTopNews" %>
<table cellpadding="0" cellspacing="0" class="table-noibat" width="99%">
    <asp:Repeater ID="rptCategoryImg" runat="server">
        <ItemTemplate>
            <tr>
                <td align="left" class="cate-text" valign="top">
                    <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                        DataBinder.Eval(Container.DataItem, "ImageLink"), "img-top\" align=\"left", 100)%>
                    <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
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
                    <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
