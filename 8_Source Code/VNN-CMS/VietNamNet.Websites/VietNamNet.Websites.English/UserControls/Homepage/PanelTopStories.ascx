<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTopStories.ascx.cs"
  Inherits="VietNamNet.Websites.English.UserControls.Homepage.PanelTopStories" %>
<div class="body-hotnew">
  <div class="bg_title">
    Top Stories</div>
  <asp:Repeater ID="rptTopStories" runat="server">
    <ItemTemplate>
      <div class="hn-item1">
        <a href="#" class="hn-img">
          <img alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=80&h=45"
            width="80" height="45" /></a> <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
              class="hn-title">
              <%#DataBinder.Eval(Container.DataItem, "Name")%>
            </a>
        <br class="clear" />
      </div>
    </ItemTemplate>
    <AlternatingItemTemplate>
      <div class="hn-item2">
        <a href="#" class="hn-img">
          <img alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=80&h=45"
            width="80" height="45" class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "" %>" /></a>
        <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
          class="hn-title">
          <%#DataBinder.Eval(Container.DataItem, "Name")%>
        </a>
        <br class="clear" />
      </div>
    </AlternatingItemTemplate>
  </asp:Repeater>
</div>
