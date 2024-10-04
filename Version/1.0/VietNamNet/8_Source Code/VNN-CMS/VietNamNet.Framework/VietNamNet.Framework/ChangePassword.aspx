<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="VietNamNet.Framework.ChangePassword" Title="VietNamNet Framework - Đổi mật khẩu" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="pnlChangePassword" runat="server" LoadingPanelID="radAjaxLoadingPanel1" CssClass="pd05">
        <p>
            <asp:Label ID="lblErrorLabel" runat="server" CssClass="red" Text=""></asp:Label>
            <asp:Label ID="lblInfoLabel" runat="server" CssClass="blue" Text=""></asp:Label>
        </p>
        <p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn phải nhập <b>Mật khẩu cũ</b><br />" Display="Dynamic" ControlToValidate="txtOldPwd" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
            <asp:Label ID="lblOldPwdLabel" runat="server" CssClass="label w150" Text="Mật khẩu cũ:"></asp:Label>
            <telerik:RadTextBox ID="txtOldPwd" runat="server" TextMode="Password" Width="200px" MaxLength="50"></telerik:RadTextBox>
            <asp:Label ID="Label1" runat="server" CssClass="red" Text="*"></asp:Label>
            <br class="clear" />
        </p>
        <p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn phải nhập <b>Mật khẩu mới</b><br />" Display="Dynamic" ControlToValidate="txtPwd" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
            <asp:Label ID="lblPwdLabel" runat="server" CssClass="label w150" Text="Mật khẩu mới:"></asp:Label>
            <telerik:RadTextBox ID="txtPwd" runat="server" TextMode="Password" Width="200px" MaxLength="50"></telerik:RadTextBox>
            <asp:Label ID="Label2" runat="server" CssClass="red" Text="*"></asp:Label>
            <br class="clear" />
        </p>
        <p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Bạn phải nhập <b>Mật khẩu mới lần 2</b><br />" Display="Dynamic" ControlToValidate="txtRepPwd" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic" ErrorMessage="<b>Mật khẩu  mới</b> và <b>Nhập lại Mật khẩu  mới</b> không giống nhau<br />" ControlToValidate="txtRepPwd" ControlToCompare="txtPwd" ValidationGroup="ChangePassword"></asp:CompareValidator>
            <asp:Label ID="lblRepPwdLabel" runat="server" CssClass="label w150" Text="Nhập lại mật khẩu mới:"></asp:Label>
            <telerik:RadTextBox ID="txtRepPwd" runat="server" TextMode="Password" Width="200px" MaxLength="50"></telerik:RadTextBox>
            <asp:Label ID="Label3" runat="server" CssClass="red" Text="*"></asp:Label>
            <br class="clear" />
        </p>
        <p>
            <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" ValidationGroup="ChangePassword"></asp:Button>
        </p>
    </telerik:RadAjaxPanel>
</asp:Content>
