<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
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
            <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "show", "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 374, 208)%>
          </div>
          <div class="content">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "title", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
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
          <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>
