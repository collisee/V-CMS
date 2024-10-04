<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateBoxTuan.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelCateBoxTuan" %>
<div class="row">
  <div class="cattitleTVN">
    <div class="cattitle1TVN">
      <a href="http://tuanvietnam.vietnamnet.vn" target="_blank" title="TUANVIETNAM.NET">
        <img alt="" height="22" src="http://res.vietnamnet.vn/images/blank.gif" width="120" />
      </a>
    </div>
  </div>
  <div class="clear">
    ,</div>
  <div class="cattext2">
    <div class="cattext2_1">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div class="vien2 boder-img">
            <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 116, 64)%>
          </div>
          <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "cmtitle", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="cattext2_2">
      <asp:Repeater ID="rptNext" runat="server">
        <ItemTemplate>
          <div class="cm_item">
            <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "cm_link1" : "cm_link" %>">
              <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                    DataBinder.Eval(Container.DataItem, "Name"), "cmtitle", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            </div>
            <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "cm_img", "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 116, 64)%>
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
