<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="VietNamNet.Framework.Administrator.UserEdit" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <telerik:RadScriptBlock runat="server" ID="scriptBlock">

        <script type="text/javascript">
            
            function onRowDropping(sender, args) {
                if(sender.get_id()=="<%=radGridGroups.ClientID %>") {
                    var node = args.get_destinationHtmlElement();
                    if(!isChildOf('<%=radGridMemberOf.ClientID %>', node)) {
                        args.set_cancel(true);
                    }
                }
                if(sender.get_id()=="<%=radGridMemberOf.ClientID %>") {
                    var node = args.get_destinationHtmlElement();
                    if(!isChildOf('<%=radGridGroups.ClientID %>', node)) {
                        args.set_cancel(true);
                    }
                }
            }

            function isChildOf(parentId, element) {
                while(element) {
                    if(element.id && element.id.indexOf(parentId) > -1) {
                        return true;
                    }
                    element = element.parentNode;
                }
                return false;
            }
            
        </script>

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
    <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="pnlToolbar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlToolbar" />
                    <telerik:AjaxUpdatedControl ControlID="pnlForm" />
                    <telerik:AjaxUpdatedControl ControlID="pnlAuditTrail" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="radGridGroups">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radGridGroups" />
                    <telerik:AjaxUpdatedControl ControlID="radGridMemberOf" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="radGridMemberOf">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radGridGroups" />
                    <telerik:AjaxUpdatedControl ControlID="radGridMemberOf" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="pd05">
        <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick" ValidationGroup="ChangePassword">
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
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" SelectedIndex="0">
                <Tabs>
                    <telerik:RadTab Text="Thông tin chung"></telerik:RadTab>
                    <telerik:RadTab Text="Nhóm"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="rpvInfo" runat="server">
                    <p>
                        <asp:Label ID="lblStatusLabel" runat="server" CssClass="label w150" Text="Trạng thái:"></asp:Label>
                        <telerik:RadComboBox ID="cmbStatus" runat="server" Width="450px" MarkFirstMatch="True">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                            <Items>
                                <%--<telerik:RadComboBoxItem runat="server" Text="Chưa kích hoạt" Value="Chưa kích hoạt" />--%>
                                <telerik:RadComboBoxItem runat="server" Text="Hoạt động" Value="Hoạt động" />
                                <telerik:RadComboBoxItem runat="server" Text="Khóa" Value="Khóa" />
                                <%--<telerik:RadComboBoxItem runat="server" Text="Danh sách đen" Value="Danh sách đen" />
                                <telerik:RadComboBoxItem runat="server" Text="Danh sách trắng" Value="Danh sách trắng" />
                                <telerik:RadComboBoxItem runat="server" Text="Danh sách đỏ" Value="Danh sách đỏ" />--%>
                            </Items>
                        </telerik:RadComboBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="Bạn phải nhập tên <b>Tên đăng nhập</b><br />" ControlToValidate="txtLoginName" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblLoginNameLabel" runat="server" CssClass="label w150" Text="Tên đăng nhập:"></asp:Label>
                        <telerik:RadTextBox ID="txtLoginName" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <asp:Label ID="Label1" runat="server" CssClass="red" Text="*"></asp:Label>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="Bạn phải nhập <b>Email</b><br />" ControlToValidate="txtEmail" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ErrorMessage="Sai định dạng <b>Email</b><br />" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="ChangePassword"></asp:RegularExpressionValidator>
                        <asp:Label ID="lblEmailLabel" runat="server" CssClass="label w150" Text="Email:"></asp:Label>
                        <telerik:RadTextBox ID="txtEmail" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <asp:Label ID="Label2" runat="server" CssClass="red" Text="*"></asp:Label>
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
                        <asp:Label ID="Label3" runat="server" CssClass="red" Text="*"></asp:Label>
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
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvMemberOf" runat="server">
                    <div>
                        <div class="fleft pd10">
                            <div style="font-size:16px;font-weight:bold;padding:8px 0;">Danh sách Nhóm</div>
                            <telerik:RadGrid ID="radGridGroups" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
                                Width="300px" GridLines="None" OnNeedDataSource="radGridGroups_NeedDataSource" AllowMultiRowSelection="true" OnRowDrop="radGridGroups_RowDrop" OnItemCommand="radGridGroups_ItemCommand" AllowFilteringByColumn="True">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView ClientDataKeyNames="Id,Name" DataKeyNames="Id,Name" GroupLoadMode="Client"
                                    NoMasterRecordsText="Kh&#244;ng c&#243; nh&#243;m n&#224;o.">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Name" HeaderText="Nh&#243;m" UniqueName="Name" FilterControlWidth="150px" ShowFilterIcon="false" AutoPostBackOnFilter="true">
                                            <HeaderStyle Font-Bold="True" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings AllowRowsDragDrop="True" EnableRowHoverStyle="True">
                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"/>
                                    <Resizing AllowColumnResize="True" />
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True"/>
                                    <ClientEvents OnRowDblClick="RowDblClick" OnRowDropping="onRowDropping" />
                                </ClientSettings>
                                <FilterMenu EnableTheming="True">
                                    <CollapseAnimation Duration="200" Type="OutQuint" />
                                </FilterMenu>
                                <GroupingSettings CollapseTooltip="Đ&#243;ng" ExpandTooltip="Mở" GroupSplitFormat="" />
                                <PagerStyle FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang tiếp"
                                    NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" Mode="NumericPages" />
                            </telerik:RadGrid>
                        </div>
                        <div class="fleft pd10">
                            <div style="font-size:16px;font-weight:bold;padding:8px 0;">Thành viên của Nhóm</div>
                            <telerik:RadGrid ID="radGridMemberOf" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
                                Width="300px" GridLines="None" OnNeedDataSource="radGridMemberOf_NeedDataSource" AllowMultiRowSelection="true" OnRowDrop="radGridMemberOf_RowDrop" OnItemCommand="radGridMemberOf_ItemCommand" AllowFilteringByColumn="True">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView ClientDataKeyNames="Id,GroupId,UserId,GroupName" DataKeyNames="Id,GroupId,UserId,GroupName" GroupLoadMode="Client"
                                    NoMasterRecordsText="Kh&#244;ng c&#243; nh&#243;m n&#224;o.">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="GroupName" HeaderText="Nh&#243;m" UniqueName="GroupName" FilterControlWidth="150px" ShowFilterIcon="false" AutoPostBackOnFilter="true">
                                            <HeaderStyle Font-Bold="True" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SaveStatus" HeaderText="SaveStatus" UniqueName="SaveStatus" Visible="False">
                                            <HeaderStyle Font-Bold="True" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings AllowRowsDragDrop="True" EnableRowHoverStyle="True">
                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"/>
                                    <Resizing AllowColumnResize="True" />
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True"/>
                                    <ClientEvents OnRowDblClick="RowDblClick" OnRowDropping="onRowDropping" />
                                </ClientSettings>
                                <FilterMenu EnableTheming="True">
                                    <CollapseAnimation Duration="200" Type="OutQuint" />
                                </FilterMenu>
                                <GroupingSettings CollapseTooltip="Đ&#243;ng" ExpandTooltip="Mở" GroupSplitFormat="" />
                                <PagerStyle FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang tiếp"
                                    NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" Mode="NumericPages" />
                            </telerik:RadGrid>
                        </div>
                        <br class="clear" />
                    </div>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </asp:Panel>
        <asp:Panel ID="pnlAuditTrail" runat="server" CssClass="form-editor-container">
            <uc:AuditTrail id="AuditTrail1" runat="server">
            </uc:AuditTrail>
        </asp:Panel>
    </div>
</asp:Content>
