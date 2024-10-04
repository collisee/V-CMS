<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelBigCateBox.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.Homepage.PanelBigCateBox" %>
<div class="box-cate">
  <div class="box-cate-top">
    &nbsp;</div>
  <div class="pdlr5">
    <div class="bc-title">
      <div class="bc-rss">
        <a href="/rss/<%=CategoryAlias%>.rss">
          <img src="http://res.vietnamnet.vn/images/blank.gif" width="15" height="15" /></a>
      </div>
      <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
          <%#WebsitesUtils.BuildCategoryLink(categoryUrl, DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="bc-new">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
              DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), "bc-new-img", 128, 70)%>
          <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
              DataBinder.Eval(Container.DataItem, "Name"), "bc-new-title", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          <div class="bc-lead">
            <%#DataBinder.Eval(Container.DataItem, "Lead")%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="bc-list">
      <asp:Repeater ID="rptTop3" runat="server">
        <ItemTemplate>
          <div class="bc-list-item">
            <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "bc-list-img", "none",
                  DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 41, 30)%>
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          <br class="clear" /></div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
  <br class="clear" />
  <div class="bc-group">
    <asp:Repeater ID="rptTop2" runat="server">
      <ItemTemplate>
        <div class="bc-item">
          <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>
<div class="box-cate-bottom">
  &nbsp;</div>
</div> 