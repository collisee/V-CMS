<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Petro.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelSearch.ascx.cs"
  Inherits="VietNamNet.Websites.Petro.UserControls.PanelSearch" %>
<div class="homeleft">
  <div id="list-cate-new" class="row">
    <asp:Repeater ID="rptSearchArticles" runat="server">
      <ItemTemplate>
        <div class="item">
          <div class="item_img border-img">
            <a href="/vn/tin-top/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
              <img width="142" height="85" alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>" /></a></div>
          <a href="/vn/tin-top/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
            class="item_link cate-<%#DataBinder.Eval(Container.DataItem, "ArticleContentTypeId") %>-link">
            <%#DataBinder.Eval(Container.DataItem, "Name") %>
          </a>
          <div class="update2">
            <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
            (GMT+7)
          </div>
          <div class="lead">
            <%#DataBinder.Eval(Container.DataItem, "Lead") %>
          </div>
          <div class="clear">
            ,</div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
  <div id="paging">
    <asp:HyperLink ID="hplPrev" runat="server" class="back">quay lại trang trước</asp:HyperLink>
    <asp:HyperLink ID="hplNext" runat="server" class="next">xem tiếp tin khác</asp:HyperLink>
    <div class="clear">
      ,</div>
  </div>
</div>
