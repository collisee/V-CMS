<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Captcha.ascx.cs" Inherits="VietNamNet.Framework.UserControls.Captcha" %>
	<p>
	    <asp:Label ID="lblText" runat="server" CssClass="label w150 bold" Text="Hình ảnh kiểm tra:"></asp:Label>
	    <asp:Image ID="imgCaptcha" runat="server" />
	    <br class="clear" />
	    <asp:Label ID="lblEmpty" runat="server" CssClass="label w150 bold" Text="Nhập mã xác nhận:"></asp:Label>
	    <asp:TextBox ID="txtCaptcha" runat="server" CssClass="w200"></asp:TextBox>
	    <br class="clear" />
	</p>
