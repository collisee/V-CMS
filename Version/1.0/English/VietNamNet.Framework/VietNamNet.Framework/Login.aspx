<%@ Page MasterPageFile="~/Default.Master" Title="VietNamNet Framework - Đăng nhập hệ thống" Language="C#" AutoEventWireup="true" Codebehind="Login.aspx.cs" Inherits="VietNamNet.Framework.Login" %>

<%@ Register Src="~/UserControls/Login.ascx" TagName="Login" TagPrefix="uc" %>
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
        <uc:Login ID="Login1" runat="server" />
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
