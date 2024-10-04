<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentMoinong.ascx.cs"
  Inherits="VietNamNet.Websites.Clip.UserControls.News.PanelContentMoinong" %>
<div class="thongke">
  <div class="thongke2">
    <div class="cm_titlte">
      <a href="#">TIN mới</a>
    </div>
    <asp:Repeater ID="rptMoinong" runat="server">
      <ItemTemplate>
        <div class="thongke_item">
          <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>
