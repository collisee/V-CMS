<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelBBCCateBox.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.Homepage.PanelBBCCateBox" %>
<div class="bbc-box">
  <div class="bbc-top">
    &nbsp;</div>
  <div class="pdlr5">
    <div class="bbc-title">
      <a href="/vn/bbc-tieng-viet/index.html">
        <img src="http://res.vietnamnet.vn/images/blank.gif" width="300px" height="37" /></a></div>
    <div class="pd10">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
              DataBinder.Eval(Container.DataItem, "Name"), "bbc-img", "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 90)%>
          <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "bbc-link", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          <div class="bbc-lead">
            <%#DataBinder.Eval(Container.DataItem, "Lead")%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
      <br class="clear" />
      <div style="height:5px; overflow:hidden;">&nbsp;</div>
      <asp:Repeater ID="rptTop2" runat="server">
        <ItemTemplate>
          <font face="arial" color="#666666" style="font-size: 9pt; font-weight: 700;">+ Multimedia:
          </font>
          <div class="bbc-multimedia">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
      <asp:Repeater ID="rptTop3" runat="server">
        <ItemTemplate>
          <font face="arial" color="#666666" style="font-size: 9pt; font-weight: 700;">+ Bình
            luận: </font>
          <div class="bbc-binhluan">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
      <asp:Repeater ID="rptTop4" runat="server">
        <ItemTemplate>
          <font face="arial" color="#666666" style="font-size: 9pt; font-weight: 700;">+ Hồ
            sơ: </font>
          <div class="bbc-hoso">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
  </div>
  <div class="bbc-bottom">
    &nbsp;</div>
</div>
