<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTopNews.ascx.cs"
  Inherits="VietNamNet.Websites.English.UserControls.Homepage.PanelTopNews" %>
<div class="body-highlight">
  <asp:Repeater ID="rptTopNews" runat="server">
    <ItemTemplate>
      <div class="highlight-img">
        <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=412"
            width="412px" class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "" %>" />
        </a>
      </div>
      <div class="hl-content">
        <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <%#DataBinder.Eval(Container.DataItem, "Name")%>
        </a>
      </div>
      <div class="hl-des">
        <%#DataBinder.Eval(Container.DataItem, "Lead")%>
      </div>
    </ItemTemplate>
  </asp:Repeater>
  <div class="bg_title he10">
    &nbsp;</div>
  <div class="hl-list">
    <asp:Repeater ID="rptTopNewsOther" runat="server">
      <ItemTemplate>
        <div class="hl-item">
          <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <img alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=100&h=56"
              class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "" %>" />
          </a>
          <div class="hl-item-title">
            <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
              <%#DataBinder.Eval(Container.DataItem, "Name")%>
            </a>
          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
    <br class="clear" />
  </div>
</div>
