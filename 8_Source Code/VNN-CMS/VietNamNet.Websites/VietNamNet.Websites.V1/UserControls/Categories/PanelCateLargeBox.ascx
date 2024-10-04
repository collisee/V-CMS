<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelCateLargeBox.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.Categories.PanelCateLargeBox" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>

<div class="row">
  <div class="cattext3">
    <div class="cm_titlte">
      <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
          <a href="<%#DataBinder.Eval(Container.DataItem, "CategoryId")%>">
            <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
          </a>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="cattext2_1">
      <asp:Repeater ID="rptTop1" runat="server">
        <ItemTemplate>
          <div class="vien2 boder-img">
            <a href="<%#DataBinder.Eval(Container.DataItem, "Id")%>">
              <img src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=116&h=64" width="116" height="64" /></a></div>
          <a href="<%#DataBinder.Eval(Container.DataItem, "Id")%>" class="cmtitle">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="cattext2_2">
      <asp:Repeater ID="rptTopNext" runat="server">
        <ItemTemplate>
          <div class="cm_item">
            <div class="cm_link">
              <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                    DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            </div>
            <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "cm_img", "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 62, 34)%>
            <div class="clear">
              ,</div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="clear">,</div>
  </div>
</div>