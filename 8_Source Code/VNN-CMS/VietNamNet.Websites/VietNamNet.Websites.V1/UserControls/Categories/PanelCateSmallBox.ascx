<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateSmallBox.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.Categories.PanelCateSmallBox" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>

<div class="cate_cm">
    <div class="cm_titlte">
        <asp:Repeater ID="rptCateTitle" runat="server">
            <ItemTemplate>
                <a href="/vn/<%#DataBinder.Eval(Container.DataItem, "CategoryUrl") %>index.html">
                    <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:Repeater ID="rptSmallBox" runat="server">
        <ItemTemplate>
            <div class="thitruong_item">
                <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                    DataBinder.Eval(Container.DataItem, "Name"), "thitruong_img", "none",
                    DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 62, 34)%>
                <div class="thitruong_link">
                  <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                </div>
                <div class="clear">
                    ,</div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
