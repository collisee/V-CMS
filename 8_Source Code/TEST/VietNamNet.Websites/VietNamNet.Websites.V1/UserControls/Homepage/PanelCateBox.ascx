<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateBox.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelCateBox" %>
<div class="row">
  <div class="cattext3">
    <div class="cm_titlte">
      <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
          <a href="/vn/<%=categoryUrl %>index.html">
            <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
          </a>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    
    <div class="cattext2_1">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div class="vien2 boder-img">
            <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
              <img alt="" title="" src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=116&height=64" width="116" height="64" /></a></div>
          <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="cmtitle">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="cattext2_2">
      <asp:Repeater ID="rptNext" runat="server">
        <ItemTemplate>
          <div class="cm_item">
            <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "cm_link1" : "cm_link" %>">
              <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="<%#WebsitesUtils.GetArticleIcon(Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId"))) %>">
                <%#DataBinder.Eval(Container.DataItem, "Name")%>
              </a>
            </div>
            <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "cm_img" %>">
              <img alt="" title="" src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=62&height=34" width="62" height="34" /></a>
            <div class="clear">
              ,</div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="clear">
      ,</div>
  </div>
</div>
