<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateBoxHoptac.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.PanelCateBoxHoptac" %>
<div class="hoptac_item">
  <asp:Repeater ID="rptCateTitle" runat="server">
    <ItemTemplate>
      <%#WebsitesUtils.BuildCategoryLink(categoryUrl, DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), "hoptac_link")%>
    </ItemTemplate>
  </asp:Repeater>
  <asp:Repeater ID="rptTop" runat="server">
    <ItemTemplate>
      <div class="hoptac_img boder-img">
        <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
            DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
            DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 100, 57)%>
      </div>
      <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
            DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
    </ItemTemplate>
  </asp:Repeater>
</div>
