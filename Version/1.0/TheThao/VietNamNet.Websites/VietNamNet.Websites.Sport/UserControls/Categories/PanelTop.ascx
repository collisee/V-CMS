<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTop.ascx.cs" Inherits="VietNamNet.Websites.Sport.UserControls.Categories.PanelTop" %>
<div class="home-center-left pdt5">
  <div class="hot-news2">
    <div class="hn2-top">
      &nbsp;</div>
    <div class="pdlr5">
      <div class="patway">
        <%--<div class="cate-select">
          <select class="select-fast">
            <option>Lựa chọn nhanh </option>
          </select>
        </div>--%>
        <asp:Repeater ID="rptCateTitle" runat="server">
          <ItemTemplate>
            <%#WebsitesUtils.BuildCategoryLink(categoryUrl, DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
          </ItemTemplate>
        </asp:Repeater>
      </div>
      <div class="cate-top">
        <asp:Repeater ID="rptTop" runat="server">
          <ItemTemplate>
            <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                  DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 380, 210)%>
            <div class="cate-top-title">
              <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                  DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            </div>
            <div class="cate-top-lead">
              <%#DataBinder.Eval(Container.DataItem, "Lead")%>
            </div>
          </ItemTemplate>
        </asp:Repeater>
      </div>
    </div>
    <div class="hn2-bottom">
      &nbsp;</div>
  </div>
  <div class="hot-list2">
    <div class="hl2-top">
      &nbsp;</div>
    <div class="pdlr5">
      <div class="hl_group2">
        <asp:Repeater ID="rptTop3" runat="server">
          <ItemTemplate>
            <div class="<%#Container.ItemIndex == 0 ? "hl-item2a" : "hl-item2" %>">
              <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            </div>
          </ItemTemplate>
        </asp:Repeater>
      </div>
    </div>
    <div class="hl2-bottom">
      &nbsp;</div>
  </div>
  <br class="clear" />
</div>
