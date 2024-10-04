<%@ Import namespace="VietNamNet.Layout.Mobile.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelTopNews.ascx.cs" Inherits="VietNamNet.Layout.Mobile.UserControls.PanelTopNews" %>
<div class="new-hot">
<div class="categories">
    <asp:Repeater ID="rptCategory" runat="server">
        <ItemTemplate>
            <div class="<%# Container.ItemIndex == 0 ? "item1" : "item" %>">
                <a class="<%# Container.ItemIndex == 0 ? "hot-link" : "content-link" %>" href="/vn/<%#DataBinder.Eval(Container.DataItem, "CategoryAlias") %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#VNN4MobileUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                </a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
</div>
