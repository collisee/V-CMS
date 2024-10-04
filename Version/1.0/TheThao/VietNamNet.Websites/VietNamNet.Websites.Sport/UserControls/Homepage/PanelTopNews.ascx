<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTopNews.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.Homepage.PanelTopNews" %>
<div class="hot-news">
  <div class="hn-top">
    &nbsp;</div>
  <div class="pdlr5">
    <div class="hn-hot">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div id="gallery">
            <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "hn-img", "none",
                  DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 421, 270)%>
          </div>
          <div class="hn-text">
            <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            <div class="hn-lead">
              <%#DataBinder.Eval(Container.DataItem, "Lead")%>
            </div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="hn-slide ">
      <%--<div class="hn-slide-back">
        <a href="#">
          <img src="http://res.vietnamnet.vn/sports/images/backtop.png" width="31" height="30" />
        </a>
      </div>--%>
      <div class="hn-group">
        <asp:Repeater ID="rptTop2" runat="server">
          <ItemTemplate>
            <div class="hn-item">
              <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
              DataBinder.Eval(Container.DataItem, "Name"), "hn-item-image", "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 73, 46)%>
              <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "hn-item-link", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            </div>
          </ItemTemplate>
        </asp:Repeater>
        <br class="clear" />
      </div>
      <%--<div class="hn-slide-next">
        <a href="#">
          <img src="http://res.vietnamnet.vn/sports/images/nexttop.png" width="31" height="30" />
        </a>
      </div>--%>
    </div>
  </div>
  <div class="hn-bottom">
    &nbsp;</div>
</div>
