<%@ Control Language="C#" AutoEventWireup="true" Inherits="VietNamNet.Framework.System.AuditTrail" %>
<hr size="1"  />
<p>
    <asp:Label ID="Label1" runat="server" Text="Khởi tạo lúc:&nbsp;"></asp:Label>
    <asp:Label ID="lblCreatedAt" runat="server" Font-Bold="true" Text=""></asp:Label>
    <asp:Label ID="Label3" runat="server" Text=", bởi&nbsp;"></asp:Label>
    <asp:LinkButton ID="lbtnCreatedBy" runat="server" Font-Bold="true" OnClick="lbtnCreatedBy_Click"></asp:LinkButton>
    <asp:HiddenField ID="hidCreatedBy" runat="server" />
    <br class="clear" />
</p>
<p>
    <asp:Label ID="Label4" runat="server" Text="Thay đổi lần cuối lúc:&nbsp;"></asp:Label>
    <asp:Label ID="lblLastModifiedAt" runat="server" Font-Bold="true" Text=""></asp:Label>
    <asp:Label ID="Label6" runat="server" Text=", bởi&nbsp;"></asp:Label>
    <asp:LinkButton ID="lbtnLastModifiedBy" runat="server" Font-Bold="true" OnClick="lbtnLastModifiedBy_Click"></asp:LinkButton>
    <asp:HiddenField ID="hidLastModifiedBy" runat="server" />
    <br class="clear" />
</p>
