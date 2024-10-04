<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateBoxVNR.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelCateBoxVNR" %>
<div class="box-vnr500">
  <div class="vnr500">
    <div class="vnr500-title">
      <a href="http://community.vnr500.vn" target="_blank">
        <img alt="" height="25" src="/images/blank.gif" width="145" />
      </a>
    </div>
    <div class="vnr500-text">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div class="cat_box1">
            <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "left vienvnr500 boder-img", "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 116, 64)%>
          </div>
          <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "linkvnr500", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          <div class="vnr500_intro">
            <%#DataBinder.Eval(Container.DataItem, "Lead")%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
      <div class="clear">
        ,</div>
      <asp:Repeater ID="rptNext" runat="server">
        <ItemTemplate>
          <div class="cat_item">
            <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
  </div>
</div>
