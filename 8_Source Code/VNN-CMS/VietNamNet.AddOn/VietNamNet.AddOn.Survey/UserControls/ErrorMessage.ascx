<%@ Control Language="C#" AutoEventWireup="true" Inherits="VietNamNet.Framework.System.ErrorMessage" %>
<p>
    <asp:Label ID="lblError" runat="server" Text="Lỗi:" CssClass="red"></asp:Label>
    <br class="clear" />
</p>
    <asp:BulletedList ID="bllMessage" runat="server" CssClass="red">
    </asp:BulletedList>
    <br class="clear" />
