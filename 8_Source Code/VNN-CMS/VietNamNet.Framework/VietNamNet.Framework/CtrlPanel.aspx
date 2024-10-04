<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="CtrlPanel.aspx.cs" Inherits="VietNamNet.Framework.CtrlPanel" Title="VietNamNet Framework - Thông tin cá nhân" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <telerik:RadScriptBlock runat="server" ID="scriptBlock">

        <script type="text/javascript">
                
            var controlId = '';
            
            function OpenFileExplorerDialog(ctrlId, text)
            {
                controlId = ctrlId;
                var wnd = $find('<%= FileExplorerWindow.ClientID %>');
                //add the name of the function to be executed when RadWindow is closed
                wnd.add_close(OnFileSelected);
                wnd.show();
            }

            //This function is called from the FileExplorer.aspx page
            function OnFileSelected(wnd, args)
            {
                var textbox = $find(controlId);
                //if (textbox && textbox.set_value) textbox.set_value(args.get_argument().fileSelected);
                if (textbox && textbox.set_value)
                {
                    var files = args.get_argument();
                    if (!files || !files.length) return;
                    var v = '';
                    for (i = 0; i < files.length; i++)
                    {
                        if (v) v += ',';
                        v += files[i].file;
                    }
                    textbox.set_value(v);
                }
            }

            function selectAvatar()
            {
                OpenFileExplorerDialog('<%=txtAvatar.ClientID %>');
            }

            function previewAvatar()
            {
                var textbox = $find('<%=txtAvatar.ClientID %>');
                if (textbox && textbox.get_value) window.open(textbox.get_value());
            }

        </script>

    </telerik:RadScriptBlock>
    <telerik:RadWindow runat="server" Width="680px" Height="550px" VisibleStatusbar="false"
        Behaviors="Close,Move" NavigateUrl="/FileManager.aspx" ID="FileExplorerWindow" Modal="True">
    </telerik:RadWindow>
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div class="pd05">
        <telerik:RadAjaxPanel ID="radAjaxPanelView" runat="server" LoadingPanelID="radAjaxLoadingPanel1">
            <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
                <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick">
                    <Items>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveitem.gif" CommandName="Save"
                            Text="Lưu" AccessKey="S">
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
                <asp:Label ID="lblInfoLabel" runat="server" CssClass="blue" Text="Thay đổi thông tin thành công!"></asp:Label>
                <p>
                    <asp:Label ID="lblStatusLabel" runat="server" CssClass="label w150" Text="Trạng thái:"></asp:Label>
                    <asp:Label ID="lblStatus" runat="server" CssClass="label w450"></asp:Label>
                    <br class="clear" />
                </p>
                <p>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="Bạn phải nhập tên <b>Tên đăng nhập</b><br />" ControlToValidate="txtLoginName"></asp:RequiredFieldValidator>--%>
                    <asp:Label ID="lblLoginNameLabel" runat="server" CssClass="label w150" Text="Tên đăng nhập:"></asp:Label>
                    <telerik:RadTextBox ID="txtLoginName" runat="server" Width="450px" MaxLength="255" Enabled="false"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblPasswordLabel" runat="server" CssClass="label w150" Text="Mật khẩu:"></asp:Label>
                    <telerik:RadTextBox ID="txtPassword" runat="server" TextMode="Password" Width="450px"
                        Text="" MaxLength="50"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblRetypePasswordLabel" runat="server" CssClass="label w150" Text="Gõ lại Mật khẩu:"></asp:Label>
                    <telerik:RadTextBox ID="txtRetypePassword" runat="server" TextMode="Password" Width="450px"
                        Text="" MaxLength="50"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblFullNameLabel" runat="server" CssClass="label w150" Text="Tên đầy đủ:"></asp:Label>
                    <telerik:RadTextBox ID="txtFullName" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="Bạn phải nhập <b>Email</b><br />" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ErrorMessage="Sai định dạng <b>Email</b><br />" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
                    <asp:Label ID="lblEmailLabel" runat="server" CssClass="label w150" Text="Email:"></asp:Label>
                    <telerik:RadTextBox ID="txtEmail" runat="server" Width="450px" MaxLength="255" Enabled="false"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblAvatarLabel" runat="server" CssClass="label w150" Text="Hình ảnh đại diện:"></asp:Label>
                    <telerik:RadTextBox ID="txtAvatar" runat="server" Width="450px" MaxLength="255">
                    </telerik:RadTextBox>
                    <img alt="Chọn Hình ảnh đại diện" title="Chọn Hình ảnh đại diện" class="cpointer" src="/Images/SmallIcon/40.png" onclick="selectAvatar()" />
                    <img alt="Xem Hình ảnh đại diện" title="Xem Hình ảnh đại diện" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewAvatar()" />
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblSexLabel" runat="server" CssClass="label w150" Text="Giới tính:"></asp:Label>
                    <telerik:RadComboBox ID="cmbSex" runat="server" Width="450px" MarkFirstMatch="True">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Nam" Value="Nam" />
                            <telerik:RadComboBoxItem runat="server" Text="Nữ" Value="Nữ" />
                        </Items>
                    </telerik:RadComboBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblBirthdayLabel" runat="server" CssClass="label w150" Text="Ngày sinh:"></asp:Label>
                    <telerik:RadDatePicker ID="radDpkBirthday" runat="server" Culture="Vietnamese (Vietnam)" Width="90px" MinDate="1900-01-01">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblAddressLabel" runat="server" CssClass="label w150" Text="Địa chỉ:"></asp:Label>
                    <telerik:RadTextBox ID="txtAddress" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblPhoneLabel" runat="server" CssClass="label w150" Text="Điện thoại:"></asp:Label>
                    <telerik:RadTextBox ID="txtPhone" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblMobileLabel" runat="server" CssClass="label w150" Text="Di động:"></asp:Label>
                    <telerik:RadTextBox ID="txtMobile" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblYahooLabel" runat="server" CssClass="label w150" Text="Yahoo:"></asp:Label>
                    <telerik:RadTextBox ID="txtYahoo" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblSkypeLabel" runat="server" CssClass="label w150" Text="Skype:"></asp:Label>
                    <telerik:RadTextBox ID="txtSkype" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblFacebookLabel" runat="server" CssClass="label w150" Text="Facebook:"></asp:Label>
                    <telerik:RadTextBox ID="txtFacebook" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblDetailLabel" runat="server" CssClass="label w150" Text="Mô tả:"></asp:Label>
                    <telerik:RadTextBox ID="txtDetail" runat="server" Width="450px" Height="150px" TextMode="MultiLine" MaxLength="4000"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
            </asp:Panel>
            <asp:Panel ID="pnlAuditTrail" runat="server" CssClass="form-editor-container">
                <uc:AuditTrail id="AuditTrail1" runat="server">
                </uc:AuditTrail>
            </asp:Panel>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>
