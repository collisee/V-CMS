<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import namespace="VietNamNet.Websites.Core.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelNewsMore.ascx.cs" Inherits="VietNamNet.Websites.Sports.Mobile.UserControls.PanelNewsMore" %>
<div style="padding:10px;">
    <div style="padding-bottom:10px;">
        <b>Các tin khác:</b>
    </div>
    <asp:Repeater ID="rptMore" runat="server">
        <ItemTemplate>
            <div class="item cate-item">
                    <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <br />
</div>