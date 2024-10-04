<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelClipNoibat.ascx.cs"
  Inherits="VietNamNet.Websites.V1.ui._3g.PanelClipNoibat" %>
<!--top statitic-->
<div class="clip-hot">
  <div class="clip-hot-title">
    Clip Nổi Bật</div>
  <asp:Repeater ID="rptClipNoibat" runat="server">
    <ItemTemplate>
      <div class="clip-hot-block">
        <div class="clip_hot_thumwar">
          <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
            DataBinder.Eval(Container.DataItem, "Name"), "hot_thumwar", "none",
            DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 170, 95)%>
          <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
            "&nbsp;", "play_ico", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        </div>
        <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
            DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
      </div>
    </ItemTemplate>
  </asp:Repeater>
</div>
<!--top statitic end-->
