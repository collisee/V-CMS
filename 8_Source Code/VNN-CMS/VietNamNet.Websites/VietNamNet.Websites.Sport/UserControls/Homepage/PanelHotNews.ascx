<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelHotNews.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.Homepage.PanelHotNews" %>
<div class="hot-list">
  <div class="hl-top">
    &nbsp;</div>
  <div class="pdlr5">
    <div class="hl-title">
      <a href="/vn/tin-moi-nong/index.html">
        <img src="http://res.vietnamnet.vn/images/blank.gif" width="80px" height="20" /></a>
    </div>
    <div class="hl_group">
      <asp:Repeater ID="rptMoinong" runat="server">
        <ItemTemplate>
          <div class="hl-item">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                          DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>    
  </div>
  <div class="hl-bottom">
    &nbsp;</div>
</div>
