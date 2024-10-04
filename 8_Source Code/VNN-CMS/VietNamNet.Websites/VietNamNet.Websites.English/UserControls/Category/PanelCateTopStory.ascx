<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateTopStory.ascx.cs"
  Inherits="VietNamNet.Websites.English.UserControls.Category.PanelCateTopStory" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="cate-stories">
  <%--<div class="bg_title">Top Stories</div>--%>
  <asp:Repeater ID="rptCateTitle" runat="server">
    <ItemTemplate>
      <div class="bg_title">
        <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
      </div>
    </ItemTemplate>
  </asp:Repeater>
  <asp:Repeater ID="rptTopStories" runat="server">
    <ItemTemplate>
      <div class="hn-item1">
        <a class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "hn-img" %>"
          href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <img alt="" width="80" height="45" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=80&h=45">
        </a><a class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "hn-title3" : "hn-title2" %>"
          href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <%#DataBinder.Eval(Container.DataItem, "Name")%>
        </a>
        <br class="clear">
      </div>
    </ItemTemplate>
    <AlternatingItemTemplate>
      <div class="hn-item2">
        <a class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "hn-img" %>"
          href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <img alt="" width="80" height="45" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=80&h=45">
        </a><a class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "hn-title3" : "hn-title2" %>"
          href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <%#DataBinder.Eval(Container.DataItem, "Name")%>
        </a>
        <br class="clear">
      </div>
    </AlternatingItemTemplate>
  </asp:Repeater>
</div>
