<%@ Import namespace="VietNamNet.Layout.Mobile.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCategory.ascx.cs"
    Inherits="VietNamNet.Layout.Mobile.UserControls.PanelCategory" %>
<div class="categories">
    <div class="cattitle">
        <div class="cattitle1">
            <div class="cattitle2">
                <div class="cattitlebg">
                    <asp:HyperLink ID="lnkCategory" runat="server" NavigateUrl="/vn/index.html"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
    <asp:Repeater ID="rptCategory" runat="server">
        <ItemTemplate>
            <div class="<%# Container.ItemIndex == 0 ? "item1" : "item" %>">
                <a class="<%# Container.ItemIndex == 0 ? "hot-link" : "content-link" %>" href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#VNN4MobileUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                    <%#DataBinder.Eval(Container.DataItem, "Name").ToString().Replace("& ", "&amp; ") %>
                </a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
