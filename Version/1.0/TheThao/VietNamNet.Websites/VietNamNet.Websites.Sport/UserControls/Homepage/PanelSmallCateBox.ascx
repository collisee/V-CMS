<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelSmallCateBox.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.Homepage.PanelSmallCateBox" %>
<div class="bbc-box">
  <div class="bbc-top">
    &nbsp;</div>
  <div class="pdlr5 ">
    <div class="box-item-title">
      <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
          <%#WebsitesUtils.BuildCategoryLink(categoryUrl, DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="pd10 ">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div class="box-item">
            <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "box-item-img", "box-item-img",
                  DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 41, 30)%>
            <div class="box-item-link">
              <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                    DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            </div>
            <div class="clear">
              &nbsp;</div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
      <%--<div class="box-xemthem">
        <img src="http://res.vietnamnet.vn/sports/images/xemthem.gif" width="76" height="20" />
      </div>--%>
    </div>
  </div>
  <div class="bbc-bottom">
    &nbsp;</div>
</div>
