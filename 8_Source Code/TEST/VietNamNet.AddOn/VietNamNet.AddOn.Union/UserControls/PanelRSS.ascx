<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelRSS.ascx.cs" Inherits="VietNamNet.AddOn.Union.UserControls.PanelRSS" %>
<div class="list">
    <asp:Repeater ID="rptRSS" runat="server">
        <ItemTemplate>
            <div class="item">
                <a href="<%#DataBinder.Eval(Container.DataItem, "Link") %>" target="_blank"><%#DataBinder.Eval(Container.DataItem, "Title") %></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>



