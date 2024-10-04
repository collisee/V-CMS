<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VietNamNet.AddOn.CMS.Reports.Login" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
<div class="module form-login-container form-container">
    <div class="module-border module-top">
        <div class="b1 m-border">
        </div>
        <div class="b2 m-border">
        </div>
        <div class="b3 m-border">
        </div>
        <div class="b4 m-border">
        </div>
    </div>
    <div class="module-header m-border">
        Đăng nhập hệ thống
    </div>
    <div class="module-content m-border">
        <div class="frm-row">
            <asp:Label ID="lblMsg" runat="server" Text="" CssClass="red"></asp:Label>
        </div>
        <div class="frm-row">
            <asp:Label ID="lblError" runat="server" Text="" CssClass="red"></asp:Label>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Login" ErrorMessage="Bạn phải nhập <b>Tên đăng nhập</b><br />" Display="Dynamic" ControlToValidate="txtLoginName"></asp:RequiredFieldValidator>
            <asp:Label ID="lblLoginName" runat="server" Text="Tên đăng nhập" CssClass="frm-label" Width="100px"></asp:Label>
            <telerik:RadTextBox ID="txtLoginName" runat="server" CssClass="frm-input" Width="200px" ValidationGroup="Login">
            </telerik:RadTextBox>
            <br class="clear" />
        </div>
        <div class="frm-row">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Login" ErrorMessage="Bạn phải nhập <b>Mật khẩu</b><br />" Display="Dynamic" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            <asp:Label ID="lblPassword" runat="server" Text="Mật khẩu" CssClass="frm-label" Width="100px"></asp:Label>
            <telerik:RadTextBox ID="txtPassword" runat="server" CssClass="frm-input" Width="200px" TextMode="Password" ValidationGroup="Login">
            </telerik:RadTextBox>
            <br class="clear" />
        </div>
            <telerik:RadCaptcha ID="radCaptchaLogin" runat="server" ValidationGroup="Login" CaptchaTextBoxLabel="" MinTimeout="3" ProtectionMode="MinimumTimeout" ErrorMessage="Robot! Hãy dừng lại! Hãy đăng nhập sau 3 giây!!!" Display="Dynamic">
            </telerik:RadCaptcha>
        <div class="frm-row center">
            <asp:Button ID="btnSubmit" runat="server" Text="Đăng nhập" OnClick="btnSubmit_Click" ValidationGroup="Login" />
        </div>
    </div>
    <div class="module-border module-bottom">
        <div class="b4 m-border">
        </div>
        <div class="b3 m-border">
        </div>
        <div class="b2 m-border">
        </div>
        <div class="b1 m-border">
        </div>
    </div>
</div>
</asp:Content>
