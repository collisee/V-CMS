<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateCenterPoint.ascx.cs"
    Inherits="VietNamNet.Websites.V1.UserControls.Categories.PanelCateCenterPoint" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="first_new">
    <div class="boder1">
        <img alt="#" src="http://res.vietnamnet.vn/images/new_boder1.gif" width="280px" height="3" /></div>
    <ul>
        <asp:Repeater ID="rptCenterPoint" runat="server">
            <ItemTemplate>
                <div class="cate_item1">
                    <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                    <div class="cate_intro1">
                        <%#DataBinder.Eval(Container.DataItem, "Lead") %>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="boder2">
        <img alt="#" src="http://res.vietnamnet.vn/images/new_boder2.gif" width="280px" height="3" /></div>
</div>
