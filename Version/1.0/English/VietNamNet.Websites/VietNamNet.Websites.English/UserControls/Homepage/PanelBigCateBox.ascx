<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelBigCateBox.ascx.cs"
  Inherits="VietNamNet.Websites.English.UserControls.Homepage.PanelBigCateBox" %>
<div class="body680-box3">
  <div class="body680-top3">
    &nbsp;
  </div>
  <div class="box-style">
    <div class="bg_title2">
      <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
          <a href="/en/<%=categoryUrl %>index.html" style="padding-left: 10px">
            <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
          </a>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="boxst-new">
      <asp:Repeater ID="rptNews" runat="server">
        <ItemTemplate>
          <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=200"
              width="200" class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "" %>" /></a>
          <div class="box-st-title">
            <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
              class="bold">
              <%#DataBinder.Eval(Container.DataItem, "Name")%>
            </a>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="boxst-list">
      <asp:Repeater ID="rptNewsOther" runat="server">
        <ItemTemplate>
          <div class="boxlist-item">
            <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
              class="boxlist-img">
              <img alt="" height="56" width="100" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=100&h=56" /></a>
            <a class="hc-title" href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
              <%#DataBinder.Eval(Container.DataItem, "Name")%>
            </a>
            <div class="boxlist-intro">
              <%#DataBinder.Eval(Container.DataItem, "Lead")%>
            </div>
          </div>
          <br class="clear" />
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <br class="clear" />
  </div>
  <div class="body680-bottom3">
    &nbsp;
  </div>
</div>
