<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="PopupViewCache.aspx.cs" Inherits="VietNamNet.Framework.Administrator.PopupViewCache" Title="Thông tin Cache" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <div class="pd05">
        <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
            <p>
                <asp:Label ID="lblKeyLabel" runat="server" CssClass="label w150" Text="Key:"></asp:Label>
                <asp:Label ID="lblKey" runat="server" CssClass="label w350" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblLengthLabel" runat="server" CssClass="label w150" Text="Length:"></asp:Label>
                <asp:Label ID="lblLength" runat="server" CssClass="label w350" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblValueLabel" runat="server" CssClass="label w150" Text="Value:"></asp:Label>
                <asp:Label ID="lblValue" runat="server" CssClass="label w350" Text=""></asp:Label>
                <br class="clear" />
            </p>
        </asp:Panel>
    </div>
</asp:Content>
