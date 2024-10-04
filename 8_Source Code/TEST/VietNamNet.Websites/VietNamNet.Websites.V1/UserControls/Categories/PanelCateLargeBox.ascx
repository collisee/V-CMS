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
              <img src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=116&height=64" width="116" height="64" /></a></div>
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
              <a href="<%#DataBinder.Eval(Container.DataItem, "Id")%>" class="<%#WebsitesUtils.GetArticleIcon(Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId"))) %>">
                <%#DataBinder.Eval(Container.DataItem, "Name")%>
              </a>
            </div>
            <a href="<%#DataBinder.Eval(Container.DataItem, "Id")%>" class="cm_img">
              <img src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=62&height=34" width="62" height="34" /></a>
            <div class="clear">
              ,</div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="clear">,</div>
  </div>
</div>