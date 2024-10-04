<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelTop.ascx.cs" Inherits="VietNamNet.Framework.UserControls.LayoutClassical.PanelTop" %>
<asp:LinkButton ID="lbtnLogout" runat="server" OnClick="lbtnLogout_Click" CssClass="fright">Thoát</asp:LinkButton>
<asp:Label ID="Label2" runat="server" Text="&nbsp;-&nbsp;" CssClass="fright"></asp:Label>
<asp:LinkButton ID="lbtnChangePass" runat="server" OnClick="lbtnChangePass_Click" CssClass="fright">Đổi mật khẩu</asp:LinkButton>
<asp:Label ID="Label1" runat="server" Text="&nbsp;|&nbsp;" CssClass="fright"></asp:Label>
<asp:LinkButton ID="lbtnUser" runat="server" OnClick="lbtnUser_Click" CssClass="bold fright"></asp:LinkButton>
<asp:LinkButton ID="lbtnFindPassword" runat="server" CssClass="fright" OnClick="lbtnFindPassword_Click">Quên mật khẩu</asp:LinkButton>
<asp:Label ID="Label3" runat="server" Text="&nbsp;|&nbsp;" CssClass="fright"></asp:Label>
<asp:LinkButton ID="lbtnLogin" runat="server" OnClick="lbtnLogin_Click" CssClass="fright">Đăng nhập</asp:LinkButton>
<asp:Label ID="lblDateTime" runat="server" Text=""></asp:Label>
<br class="clear" />