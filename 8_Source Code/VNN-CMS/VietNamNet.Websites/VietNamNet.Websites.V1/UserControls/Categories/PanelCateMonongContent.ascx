<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateMonongContent.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Categories.PanelCateMonongContent" %>
<!--list tin-->
<div class="row list-news2">
  <asp:Repeater ID="rptListContentTop" runat="server">
    <ItemTemplate>
      <div class="item2">
        <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
            DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
            DataBinder.Eval(Container.DataItem, "ImageLink"), "fl_left", 200, 112)%>
        <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
            DataBinder.Eval(Container.DataItem, "Name"), "item_link", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        <div class="lead">
          <%#DataBinder.Eval(Container.DataItem, "Lead")%>
        </div>
        <div class="clear">
          ,</div>
      </div>
    </ItemTemplate>
  </asp:Repeater>
  <asp:Repeater ID="rptListContent" runat="server">
    <ItemTemplate>
      <div class="item2">
        <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
            DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
            DataBinder.Eval(Container.DataItem, "ImageLink"), "fl_left", 116, 64)%>
        <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
            DataBinder.Eval(Container.DataItem, "Name"), "item_link", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        <div class="lead">
          <%#DataBinder.Eval(Container.DataItem, "Lead")%>
        </div>
        <div class="clear">
          ,</div>
      </div>
    </ItemTemplate>
  </asp:Repeater>
</div>
<div id="paging">
  <table border="0" width="100%">
    <tr>
      <td align="left">
        <asp:HyperLink ID="hplPrev" runat="server">&lt;&lt;Trang trước</asp:HyperLink>
      </td>
      <td align="right">
        <asp:HyperLink ID="hplNext" runat="server">Trang sau&gt;&gt;</asp:HyperLink>
      </td>
    </tr>
  </table>
  <div class="clear">
    ,</div>
</div>
