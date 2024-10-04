<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelContentNewsPath.ascx.cs" Inherits="VietNamNet.Websites.Sport.UserControls.News.PanelContentNewsPath" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%--<div class="breadcrumbBox pdl5">
    <a href="#">Thể thao</a> <a href="#"><%=strCatePath %></a>    
</div>--%>

<div class="breadcrumbBox pdl5">
    <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
            <a href="/">Thể thao</a>&nbsp;&rsaquo;&nbsp;
            <%#WebsitesUtils.BuildCategoryLink(DataBinder.Eval(Container.DataItem, "CategoryUrl"), DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
        </ItemTemplate>
    </asp:Repeater>
</div>
