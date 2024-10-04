<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelBbcCateRight.ascx.cs" Inherits="VietNamNet.Websites.Sport.ui.BBC.PanelBbcCateRight" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="cate row_bbc">
    <div class="title2">
        <asp:Repeater ID="rptCateTitle" runat="server">
            <ItemTemplate>
                <a href="/vn/<%=categoryUrl %>index.html">
                    <%#WebsitesUtils.BuildCategoryLink(DataBinder.Eval(Container.DataItem, "CategoryUrl"), DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
                </a>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clear">,</div>
    </div>
                       
    <div>
    <asp:Repeater ID="rptNewsCate" runat="server">
        <ItemTemplate>
            <div class="item_listn">           
                <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                
                <div class="link_listen"></div>
        </div>
        </ItemTemplate>
    </asp:Repeater>
        
    </div>
</div> 
