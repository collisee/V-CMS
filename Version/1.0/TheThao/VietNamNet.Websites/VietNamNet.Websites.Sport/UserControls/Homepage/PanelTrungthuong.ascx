<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTrungthuong.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.Homepage.PanelTrungthuong" %>
<div class="bbc-box">
  <div class="bbc-top">
    &nbsp;</div>
  <div class="pdlr5 ">
    <div class="box-item-title-trungthuong">.</div>
    <div class="pd10 box-item-content-trungthuong">
      <asp:Repeater ID="rptMostRead" runat="server">
        <ItemTemplate>
          <div class="box-item">           
            <div class="box-item-link">
              <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                    DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            </div>
            <div class="clear">
              &nbsp;</div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
  </div>
  <div class="bbc-bottom">
    &nbsp;</div>
</div>
