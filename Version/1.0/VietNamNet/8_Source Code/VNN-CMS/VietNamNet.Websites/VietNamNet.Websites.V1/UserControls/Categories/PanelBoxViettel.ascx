<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelBoxViettel.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Categories.PanelBoxViettel" %>
<div class="row">
  <div class="cattext3">
    <div class="cm_titlte">
      <div class="menu">
        <div class="clear">
          ,</div>
      </div>
      <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
            <%#WebsitesUtils.BuildCategoryLink(categoryUrl, DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
        </ItemTemplate>
      </asp:Repeater>
      <div class="clear">
        ,</div>
    </div>
    <div class="box-hoidap">
      <marquee direction="up" scrolldelay="200" onmouseout="this.start()" onmouseover="this.stop()"
        height="100px">
        <asp:Repeater ID="rptMoinong" runat="server">
          <ItemTemplate>
            <div id="ph_rv_item">
              <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                    DataBinder.Eval(Container.DataItem, "Name"), "ph_rv_link", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            </div>
          </ItemTemplate>
        </asp:Repeater>
      </marquee>
    </div>
  </div>
</div>
