<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateBoxHoptac.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.PanelCateBoxHoptac" %>
<div class="hoptac_item">
  <asp:Repeater ID="rptCateTitle" runat="server">
    <ItemTemplate>
      <a class="hoptac_link" href="/vn/<%#categoryUrl %>index.html">
        <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
      </a>
    </ItemTemplate>
  </asp:Repeater>
  <asp:Repeater ID="rptTop" runat="server">
    <ItemTemplate>
      <div class="hoptac_img boder-img">
        <a href="/vn/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <img alt="" title="" src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=100&height=57" width="100" height="57" /></a></div>
      <a href="/vn/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
        <%#DataBinder.Eval(Container.DataItem, "Name")%>
      </a>
    </ItemTemplate>
  </asp:Repeater>
</div>
