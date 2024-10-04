<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentMoinong.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.News.PanelContentMoinong" %>
<div class="thongke">
  <div class="thongke2">
    <div class="cm_titlte">
      <a href="#">TIN mới</a>
    </div>
    <asp:Repeater ID="rptMoinong" runat="server">
      <ItemTemplate>
        <div class="thongke_item">
          <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>
