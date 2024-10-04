<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelBVKH.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelBVKH" %>
<div class="bvhk-new">
  <div class="cm_titlte">
    <a href="/vn/bao-ve-nguoi-tieu-dung/index.html">Bảo vệ người tiêu dùng</a>
  </div>
  <div class="bvkh-new-text ">
    <asp:Repeater ID="rptTop" runat="server">
      <ItemTemplate>
        <div class="cat_box1">
          <%--<a class="left vien2 boder-img" href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html"
            title="<%#DataBinder.Eval(Container.DataItem, "Name")%>">
            <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=116&h=64"
              width="116" height="64" />
          </a>--%>
          <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 116, 64)%>
        </div>
        <%--<a class="avata" href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html">
          <%#DataBinder.Eval(Container.DataItem, "Name")%>
        </a>--%>
        <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "cmtitle", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
      </ItemTemplate>
    </asp:Repeater>
    <div class="clear">
      ,</div>
    <asp:Repeater ID="rptNext" runat="server">
      <ItemTemplate>
        <div class="bvkh-item">
          <%--<a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html"
            title="<%#DataBinder.Eval(Container.DataItem, "Name")%>" class="link_b">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>--%>
          <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "cmtitle", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
  <!-- end porlet BVKH -->
</div>
