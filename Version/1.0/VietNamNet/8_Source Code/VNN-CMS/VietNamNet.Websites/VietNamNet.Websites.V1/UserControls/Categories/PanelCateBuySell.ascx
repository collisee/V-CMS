<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateBuySell.ascx.cs"
    Inherits="VietNamNet.Websites.V1.UserControls.Categories.PanelCateBuySell" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="cattext3-rv">
    <div class="cm_titlte">
        <asp:Repeater ID="rptCateTitle" runat="server">
            <ItemTemplate>
                <%#WebsitesUtils.BuildCategoryLink(categoryUrl, DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="ph_rv_list">
        <asp:Repeater ID="rpt_BuySellList" runat="server">
            <ItemTemplate>
                <div class="ph_rv_item_sp">
                  <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), "ph_rv_link", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
