<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelSmallCateBox.ascx.cs"
  Inherits="VietNamNet.Websites.English.UserControls.Homepage.PanelSmallCateBox" %>
<div class="bg_title2">
  <asp:Repeater ID="rptCateTitle" runat="server">
    <ItemTemplate>
      <a href="/en/<%=categoryUrl %>index.html">
        <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
      </a>
    </ItemTemplate>
  </asp:Repeater>
</div>
<asp:Repeater ID="rptNews" runat="server">
  <ItemTemplate>
    <div class="hc-img">
      <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
        <img src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=150" width="150"
          class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "" %>" /></a>
    </div>
    <a class="hc-title" href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
      <%#DataBinder.Eval(Container.DataItem, "Name")%>
    </a>
    <div class="hc-intro">
      <%#DataBinder.Eval(Container.DataItem, "Lead")%>
    </div>
  </ItemTemplate>
</asp:Repeater>
<br class="clear" />
<asp:Repeater ID="rptNewsOther" runat="server">
  <ItemTemplate>
    <div class="hc-item">
      <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
        <%#DataBinder.Eval(Container.DataItem, "Name")%>
      </a>
    </div>
  </ItemTemplate>
</asp:Repeater>
