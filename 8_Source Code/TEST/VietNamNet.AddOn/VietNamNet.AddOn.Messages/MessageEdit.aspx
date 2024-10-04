<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="MessageEdit.aspx.cs" Inherits="VietNamNet.AddOn.Messages.MessageEdit" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="pnlToolbar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlToolbar" />
                    <telerik:AjaxUpdatedControl ControlID="pnlForm" />
                    <telerik:AjaxUpdatedControl ControlID="pnlAuditTrail" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbMsgType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlReceiver" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="pd05">
        <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick" ValidationGroup="SendMessage">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveitem.gif" CommandName="Save"
                        Text="Lưu nháp" AccessKey="S">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/9.png" CommandName="Send"
                        Text="Gửi" AccessKey="E">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/goback1.gif" CommandName="GoBacktoView"
                        Text="Quay lại" AccessKey="G">
                    </telerik:RadToolBarButton>
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
            <uc:ErrorMessage ID="ErrorMessage1" runat="server" Visible="false" />
            <br />
            <asp:Panel ID="pnlReceiver" runat="server">
                <p>
                    <asp:Label ID="lblMsgTypeLabel" runat="server" CssClass="label w150" Text="Người nhận:"></asp:Label>
                    <telerik:RadComboBox ID="cmbMsgType" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="cmbMsgType_SelectedIndexChanged">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="C&#225; nh&#226;n" Value="0" />
                            <telerik:RadComboBoxItem runat="server" Text="Nh&#243;m" Value="1" />
                            <telerik:RadComboBoxItem runat="server" Text="Tất cả" Value="2" />
                        </Items>
                    </telerik:RadComboBox>
                    <telerik:RadComboBox ID="cmbMsgReceiver" runat="server" Width="300px" DataTextField="Name" DataValueField="Id"
                        AllowCustomText="True" MarkFirstMatch="True" EmptyMessage="Chọn người nhận...">
                    </telerik:RadComboBox>
                    <asp:Label ID="lblReceiverError" runat="server" CssClass="red" Text="*"></asp:Label>
                </p>
            </asp:Panel>
            <p>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn phải nhập <b>Tiêu đề</b><br />" Display="Dynamic" ControlToValidate="txtSubject" ValidationGroup="SendMessage"></asp:RequiredFieldValidator>
                <asp:Label ID="lblSubjectLabel" runat="server" CssClass="label w150" Text="Tiêu đề:"></asp:Label>
                <telerik:RadTextBox ID="txtSubject" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                <asp:Label ID="Label1" runat="server" CssClass="red" Text="*"></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblDetailLabel" runat="server" CssClass="label w150" Text="Nội dung:"></asp:Label>
                <telerik:RadTextBox ID="txtDetail" runat="server" Width="450px" Height="150px" TextMode="MultiLine" MaxLength="4000"></telerik:RadTextBox>
                <br class="clear" />
            </p>
            <br />
        </asp:Panel>
        <asp:Panel ID="pnlAuditTrail" runat="server" CssClass="form-editor-container">
            <uc:AuditTrail id="AuditTrail1" runat="server">
            </uc:AuditTrail>
        </asp:Panel>
    </div>
</asp:Content>
