<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateTopNews.ascx.cs"
    Inherits="VietNamNet.Websites.English.UserControls.Category.PanelCateTopNews" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="body-highlight">
    <div class="bg_title3">
        <asp:Repeater ID="rptCateName" runat="server">
            <ItemTemplate>
                <a class="cate-name" href="/en/<%#DataBinder.Eval(Container.DataItem, "CategoryUrl") %>index.html">
                    <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:Repeater ID="rptTopNews" runat="server">
        <ItemTemplate>
            <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "highlight-img" %>">
                <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                    <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=412" width="412px" />
                </a>
            </div>
            <div class="hl-content">
                <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                    <%#DataBinder.Eval(Container.DataItem, "Name")%>
                </a>
            </div>
            <div class="hl-des">
                <%#DataBinder.Eval(Container.DataItem, "Lead")%>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
