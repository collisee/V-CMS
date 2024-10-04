<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import namespace="VietNamNet.Websites.Core.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTopNews.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelTopNews" %>
<div class="first_hot">
  <div id="news-top">
    <div class="first">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div id="gallery">
            <a href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="show">
              <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>" />
              <%--<img alt="" title="" src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=374&height=208" />--%>
            </a>
          </div>
          <div class="content">
            <a href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="title">
              <%#DataBinder.Eval(Container.DataItem, "Name")%>
            </a>
            <div class="lead">
              <p>
                <%#DataBinder.Eval(Container.DataItem, "Lead")%>
              </p>
            </div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
  </div>
  <div class="first_hot_list">
    <asp:Repeater ID="rptTopOther" runat="server">
      <ItemTemplate>
        <div class="first_hot_item">
          <a href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <%#HttpUtility.HtmlEncode((string)(DataBinder.Eval(Container.DataItem, "Name")))%>
          </a>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>
