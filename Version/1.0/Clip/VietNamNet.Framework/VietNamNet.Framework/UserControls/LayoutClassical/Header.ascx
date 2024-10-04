<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="VietNamNet.Framework.UserControls.LayoutClassical.Header" %>
<div id="h_logo">
    <div class="logo">
        <a href="/"><img border="0" alt="Trang chủ" title="Trang chủ" height="80" src="/Images/logovnn.png" /></a></div>
    <div class="skin-chooser">
        <label>Giao diện:</label>
        <telerik:RadComboBox ID="cmbLayout" runat="server" OnSelectedIndexChanged="cmbLayout_SelectedIndexChanged"
             DataTextField="Name" DataValueField="File" AutoPostBack="True">
        </telerik:RadComboBox>
        <br /><br />
        <label>Chủ đề:</label>
        <telerik:RadSkinManager runat="server" ID="RadSkinManager1" ShowChooser="true"
            PersistenceKey="Skin" PersistenceMode="Session" OnSkinChanged="RadSkinManager1_SkinChanged" />
    </div>
    <br class="clear" />
</div>
