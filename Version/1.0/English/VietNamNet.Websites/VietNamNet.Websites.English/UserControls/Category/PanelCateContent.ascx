<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateContent.ascx.cs"
  Inherits="VietNamNet.Websites.English.UserControls.Category.PanelCateContent" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<asp:Repeater ID="rptContent" runat="server">
  <ItemTemplate>
    <div class="cate-left">
      <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "hc-img" %>">
        <a href="/en/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <img alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=150" width="150" /></a>
      </div>
      <a class="hc-title" href="/en/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
        <%#DataBinder.Eval(Container.DataItem, "Name")%>
      </a>
      <div class="cate-time">
        <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
        (GMT+7)</div>
      <div class="hc-intro">
        <%#DataBinder.Eval(Container.DataItem, "Lead")%>
      </div>
      <br class="clear" />
    </div>
  </ItemTemplate>
  <AlternatingItemTemplate>
    <div class="cate-right">
      <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "hc-img" %>">
        <a href="/en/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <img alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=150" width="150" /></a>
      </div>
      <a class="hc-title" href="/en/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
        <%#DataBinder.Eval(Container.DataItem, "Name")%>
      </a>
      <div class="cate-time">
        <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
        (GMT+7)</div>
      <div class="hc-intro">
        <%#DataBinder.Eval(Container.DataItem, "Lead")%>
      </div>
      <br class="clear" />
    </div>
    <br class="clear" />
    <div class="kengang" />
    &nbsp;</div>
  </AlternatingItemTemplate>
</asp:Repeater>
<br class="clear" />
<div class="right pd5">
  <asp:HyperLink ID="hplPrev" runat="server">Back</asp:HyperLink>
  &nbsp; &nbsp;
  <asp:HyperLink ID="hplNext" runat="server">Next</asp:HyperLink>
</div>
