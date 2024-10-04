<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateBox1.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelCateBox1" %>
<div class="thitruong">
  <div class="cm_titlte">
    <asp:Repeater ID="rptCateTitle" runat="server">
      <ItemTemplate>
        <a href="/vn/<%=categoryUrl %>index.html">
          <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
        </a>
      </ItemTemplate>
    </asp:Repeater>
  </div>
  <asp:Repeater ID="rptNext" runat="server">
    <ItemTemplate>
      <div class="thitruong_item">
        <%--<a href="/vn/<%=categoryUrl %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html"
          class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "thitruong_img" %>">
          <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=62&h=34" width="62" height="34" /></a>--%>
        <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
              DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                   DataBinder.Eval(Container.DataItem, "ImageLink"), "thitruong_img", 62, 34)%>
        <div class="thitruong_link">
          <%--<a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html"
            class="<%#WebsitesUtils.GetArticleIcon(Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId"))) %>">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>--%>
          <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "cmtitle", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        </div>
        <div class="clear">
          ,</div>
      </div>
    </ItemTemplate>
  </asp:Repeater>
</div>
