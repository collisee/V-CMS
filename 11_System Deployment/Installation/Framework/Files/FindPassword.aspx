<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="FindPassword.aspx.cs" Inherits="VietNamNet.Framework.FindPassword" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="pnlChangePassword" runat="server" LoadingPanelID="radAjaxLoadingPanel1" CssClass="pd05">
        <p>
            <asp:Label ID="lblErrorLabel" runat="server" CssClass="red" Text="Sai Tên đăng nhập hoặc Email!!!"></asp:Label>
            <asp:Label ID="lblInfoLabel" runat="server" CssClass="blue" Text="Đã tìm kiếm thành công! Hãy kiểm tra email để nhận thông tin chi tiết!"></asp:Label>
        </p>
        <p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn phải nhập <b>Tên đăng nhập</b><br />" Display="Dynamic" ControlToValidate="txtLoginName"></asp:RequiredFieldValidator>
            <asp:Label ID="lblLoginNameLabel" runat="server" CssClass="label w150" Text="Tên đăng nhập:"></asp:Label>
            <telerik:RadTextBox ID="txtLoginName" runat="server" Width="200px" MaxLength="255"></telerik:RadTextBox>
            <br class="clear" />
        </p>
        <p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn phải nhập <b>Email</b><br />" Display="Dynamic" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ErrorMessage="Sai định dạng <b>Email</b><br />" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <asp:Label ID="lblEmailLabel" runat="server" CssClass="label w150" Text="Email:"></asp:Label>
            <telerik:RadTextBox ID="txtEmail" runat="server" Width="200px" MaxLength="255"></telerik:RadTextBox>
            <br class="clear" />
        </p>
        <p>
            <asp:Button ID="btnFind" runat="server" Text="Tìm mật khẩu" OnClick="btnFind_Click"></asp:Button>
        </p>
    </telerik:RadAjaxPanel>
</asp:Content>
