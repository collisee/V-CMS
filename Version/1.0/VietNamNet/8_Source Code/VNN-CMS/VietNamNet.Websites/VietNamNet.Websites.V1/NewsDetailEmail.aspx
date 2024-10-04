<%@ Page Language="C#" AutoEventWireup="true" Codebehind="NewsDetailEmail.aspx.cs"
  Inherits="VietNamNet.Websites.V1.NewsDetailEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
</head>
<body>
  <form id="Form1" method="post" runat="server">
    <div>
      <asp:Label ID="lblMessage" runat="server"></asp:Label></div>
    <div>
      <asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
    <div>
      <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox></div>
    <div>
      <asp:TextBox ID="txtTo" runat="server"></asp:TextBox></div>
    <div>
      <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox></div>
    <div>
      <asp:Button ID="btnSend" runat="server" Text="Gửi" OnClick="btnSend_Click" /></div>
  </form>
</body>
</html>
