<%@ Import namespace="VietNamNet.AddOn.Union.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelNewsMore.ascx.cs" Inherits="VietNamNet.AddOn.Union.UserControls.News.PanelNewsMore" %>
<div class="list">
    <div style="padding:10px 0;border-top:dotted 1px #cccccc;">
        <b>Các tin đã đưa:</b>
    </div>
    <asp:Repeater ID="rptMore" runat="server">
        <ItemTemplate>
            <div class="item">
                <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"><%#DataBinder.Eval(Container.DataItem, "Name") %></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
