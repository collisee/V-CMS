<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelSlideImagePath.ascx.cs" Inherits="VietNamNet.Websites.Sport.UserControls.News.PanelSlideImagePath" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="breadcrumbBox">
       <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
            <a href="/">Thể thao</a>&nbsp;&rsaquo;&nbsp;
            <%#WebsitesUtils.BuildCategoryLink(DataBinder.Eval(Container.DataItem, "CategoryUrl"), DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
        </ItemTemplate>
    </asp:Repeater>
</div>