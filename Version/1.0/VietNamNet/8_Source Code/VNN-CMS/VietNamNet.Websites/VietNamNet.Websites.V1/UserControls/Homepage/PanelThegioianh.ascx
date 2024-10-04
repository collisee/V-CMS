<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelThegioianh.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelThegioianh" %>
<div class="tg_anh">
  <div class="tg_anh-title">
    <a href="#">
      <img src="/images/blank.gif" width="90" height="30" /></a>
  </div>
  <div class="tg_anh-text ">
    <asp:Repeater ID="rptTop" runat="server">
      <ItemTemplate>
        <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html"
          title="<%#DataBinder.Eval(Container.DataItem, "Name")%>">
          <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=290&h=175"
            width="290" height="175" />
        </a>
        <div class="tg_anh-link">
          <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </div>
      </ItemTemplate>
    </asp:Repeater>
    <asp:Repeater ID="rptNext" runat="server">
      <ItemTemplate>
        <div class="tg_anh-item">
          <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html"
            title="<%#DataBinder.Eval(Container.DataItem, "Name")%>">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>
