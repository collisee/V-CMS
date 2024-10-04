<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Petro.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCategory.ascx.cs"
  Inherits="VietNamNet.Websites.Petro.UserControls.Categories.PanelCategory" %>
<div class="homeleft">
  <%--<asp:HyperLink ID="hplCate" runat="server"></asp:HyperLink>--%>
  <asp:Repeater ID="rptHotNews" runat="server">
    <ItemTemplate>
      <div class="new-hot">
        <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
          class="border-img hot-img">
          <img width="300" height="186" alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>" />
        </a>
        <div class="hot-text">
          <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
            class="link cate-<%#DataBinder.Eval(Container.DataItem, "ArticleContentTypeId") %>-link">
            <%#DataBinder.Eval(Container.DataItem, "Name") %>
          </a>
          <div class="update2">
            <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %> (GMT+7)
          </div>
          <p>
            <%#DataBinder.Eval(Container.DataItem, "Lead") %>
          </p>
        </div>
        <div class="clear">
          ,</div>
      </div>
    </ItemTemplate>
  </asp:Repeater>
  <div id="list-cate-new" class="row">
    <asp:Repeater ID="rptCate" runat="server">
      <ItemTemplate>
        <div class="item">
          <div class="item_img border-img">
            <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
              <img width="142" height="85" alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>" /></a></div>
          <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
            class="item_link cate-<%#DataBinder.Eval(Container.DataItem, "ArticleContentTypeId") %>-link">
            <%#DataBinder.Eval(Container.DataItem, "Name") %>
          </a>
          <div class="update2">
            <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %> (GMT+7)
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
