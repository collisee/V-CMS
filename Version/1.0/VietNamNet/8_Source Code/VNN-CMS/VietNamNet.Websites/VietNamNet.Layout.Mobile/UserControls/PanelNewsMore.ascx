<%@ Import namespace="VietNamNet.Layout.Mobile.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelNewsMore.ascx.cs" Inherits="VietNamNet.Layout.Mobile.UserControls.PanelNewsMore" %>
<div style="padding:10px;">
    <div style="padding-bottom:10px;">
        <b>Các tin khác:</b>
    </div>
    <asp:Repeater ID="rptMore" runat="server">
        <ItemTemplate>
            <div class="item cate-item">
                <a class="content-link" href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#VNN4MobileUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                </a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <br />
</div>