<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelOtherNews.ascx.cs"
    Inherits="VietNamNet.Websites.V1.UserControls.Categories.PanelOtherNews" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="pd05">
    <div class="othernews-title pd05">
        Các tin khác</div>
    <div class="pl10">
        <asp:Repeater ID="rptOtherNews" runat="server">
            <ItemTemplate>
                <div class="pb05">
                  <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
