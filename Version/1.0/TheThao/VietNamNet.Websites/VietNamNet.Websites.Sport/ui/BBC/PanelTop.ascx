<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTop.ascx.cs" Inherits="VietNamNet.Websites.Sport.ui.BBC.PanelTop" %>
<div class="khung21">
  <div class="hot">
    <asp:Repeater ID="rptTop" runat="server">
      <ItemTemplate>
        <div class="hot_img">
          <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
              DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 464, 260)%>
        </div>
        <div class="hot_title">
          <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
              DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        </div>
        <div class="hot_text">
          <%#DataBinder.Eval(Container.DataItem, "Lead")%>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>
