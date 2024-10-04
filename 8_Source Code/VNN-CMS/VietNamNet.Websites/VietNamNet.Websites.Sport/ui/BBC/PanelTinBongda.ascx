<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTinBongda.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.ui.BBC.PanelTinBongda" %>
<div class="khung22">
  <div class="new_fb">
    <div class="title2">
      <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
          <%#WebsitesUtils.BuildCategoryLink(categoryUrl, DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <asp:Repeater ID="rptTop3" runat="server">
      <ItemTemplate>
        <div class="item_new">
          <div class="new_img">
            <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
              DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 104, 60)%>
          </div>
          <div class="new_text">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                            DataBinder.Eval(Container.DataItem, "Name"), "link_content", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
          <div class="text_content">
            <%#DataBinder.Eval(Container.DataItem, "Lead")%>
          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
    <div class="list_new">
      <asp:Repeater ID="rptTop5" runat="server">
        <ItemTemplate>
          <div class="item_listn">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
  </div>
</div>
