<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelOtherNews.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.News.PanelOtherNews" %>
<div id="article-others" class="row">
  <div class="tab-nav">
    <div class="content-more">
      Tin khác</div>
    <div class="clear">
      ,</div>
  </div>
  <div class="tab-content">
    <asp:Repeater ID="rptMore" runat="server">
      <ItemTemplate>
        <div class="item">
          <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>
