<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCategory1.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelCategory1" %>
<div id="home5_1" class="row">
  <div class="cattitle">
    <div class="cattitle1">
      <div class="cattitle2">
        <asp:Repeater ID="rptCateTitle" runat="server">
          <ItemTemplate>
            <div class="cattitlebg">
              <a href="/vn/<%#categoryUrl %>index.html">
                <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
              </a>
            </div>
          </ItemTemplate>
        </asp:Repeater>
      </div>
    </div>
    <div class="cattitle_sub">
      <%--<asp:Repeater ID="rptSubCate" runat="server">
        <ItemTemplate>
          <a href="/vn/<%#categoryUrl %>/index.html" class="sub_link">
            <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
          </a>
        </ItemTemplate>
      </asp:Repeater>--%>
      <asp:HyperLink ID="cattitle_sub0" runat="server" Visible="false"></asp:HyperLink>
      <asp:HyperLink ID="cattitle_sub1" runat="server" Visible="false" CssClass="sub_link"></asp:HyperLink>
      <asp:HyperLink ID="cattitle_sub2" runat="server" Visible="false" CssClass="sub_link"></asp:HyperLink>
      <asp:HyperLink ID="cattitle_sub3" runat="server" Visible="false" CssClass="sub_link"></asp:HyperLink>
      <asp:HyperLink ID="cattitle_sub4" runat="server" Visible="false" CssClass="sub_link"></asp:HyperLink>
      <asp:HyperLink ID="cattitle_sub5" runat="server" Visible="false" CssClass="sub_link"></asp:HyperLink>
    </div>
  </div>
  <div class="cattext">
    <div class="first_text">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div class="cat_box1">
            <a href="/vn/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html"
              class="left vien2 boder-img">
              <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=116&h=64" width="116" height="64" /></a></div>
          <a href="/vn/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html"
            class="avata <%#WebsitesUtils.GetArticleIcon(Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId"))) %>">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
          <div class="cat_intro">
            <%#DataBinder.Eval(Container.DataItem, "Lead")%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="first_list">
      <asp:Repeater ID="rptTop3" runat="server">
        <ItemTemplate>
          <div class="first_item">
            <a href="/vn/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html"
              class="link_b <%#WebsitesUtils.GetArticleIcon(Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId"))) %>">
              <%#DataBinder.Eval(Container.DataItem, "Name")%>
            </a>
          </div>
          <div class="clear">
            ,</div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="clear">
      ,</div>
    <asp:Repeater ID="rptTop2" runat="server">
      <ItemTemplate>
        <div class="cat_item">
          <a href="/vn/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html"
            class="<%#WebsitesUtils.GetArticleIcon(Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId"))) %>">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>
