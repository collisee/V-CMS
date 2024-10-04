<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="AdvertisementItemEdit.aspx.cs" Inherits="VietNamNet.AddOn.Advertisement.AdvertisementItemEdit" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>
<%@ Register Src="PanelAdvZone.ascx" TagName="PanelAdvZone" TagPrefix="uc" %>
<%@ Register Src="PanelAdvCategory.ascx" TagName="PanelAdvCategory" TagPrefix="uc" %>
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
                    var v = '';
                    for (i = 0; i < files.length; i++)
                    {
                        if (v) v += ',';
                        v += files[i].file;
                    }
                    textbox.set_value(v);
                }
            }

            function selectFileLink1()
            {
                OpenFileExplorerDialog('<%=txtFileLink1.ClientID %>');
            }

            function previewFileLink1()
            {
                var textbox = $find('<%=txtFileLink1.ClientID %>');
                if (textbox && textbox.get_value) window.open(textbox.get_value());
            }

            function selectFileLink11()
            {
                OpenFileExplorerDialog('<%=txtFileLink11.ClientID %>');
            }

            function previewFileLink11()
            {
                var textbox = $find('<%=txtFileLink11.ClientID %>');
                if (textbox && textbox.get_value) window.open(textbox.get_value());
            }

            function selectFileLink2()
            {
                OpenFileExplorerDialog('<%=txtFileLink2.ClientID %>');
            }

            function previewFileLink2()
            {
                var textbox = $find('<%=txtFileLink2.ClientID %>');
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
            <telerik:AjaxSetting AjaxControlID="cmbAdvertisementType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plhBanner" />
                    <telerik:AjaxUpdatedControl ControlID="plhAddcode" />
                    <telerik:AjaxUpdatedControl ControlID="plhExpanding" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="pd05">
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
            <p>
                <asp:Label ID="lblNameLabel" runat="server" CssClass="label w150" Text="Tên Item:"></asp:Label>
                <telerik:RadTextBox ID="txtName" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                <asp:Label ID="lblNameErrorLabel" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblLinkLabel" runat="server" CssClass="label w150" Text="Link:"></asp:Label>
                <telerik:RadTextBox ID="txtLink" runat="server" Width="450px" MaxLength="255" Text="#"></telerik:RadTextBox>
                <asp:Label ID="lblLinkErrorLabel" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblAdvertisementTypeLabel" runat="server" CssClass="label w150" Text="Loại quảng cáo:"></asp:Label>
                <telerik:RadComboBox ID="cmbAdvertisementType" runat="server" Width="454px" DataTextField="Name" DataValueField="Alias" AutoPostBack="True" OnSelectedIndexChanged="cmbAdvertisementType_SelectedIndexChanged">
                    <CollapseAnimation Duration="200" Type="OutQuint" />
                </telerik:RadComboBox>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblStartTimeLabel" runat="server" CssClass="label w150" Text="Ngày giờ bắt đầu:"></asp:Label>
                <telerik:RadDateTimePicker ID="radDpkStartTime" runat="server" Width="200px" Culture="Vietnamese (Vietnam)" MinDate="1753-01-01">
                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                    </Calendar>
                    <TimeView CellSpacing="-1" Culture="Vietnamese (Vietnam)">
                    </TimeView>
                    <TimePopupButton HoverImageUrl="" ImageUrl="" />
                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                </telerik:RadDateTimePicker>
                <asp:Label ID="lblStartTimeErrorLabel" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblEndTimeLabel" runat="server" CssClass="label w150" Text="Ngày giờ kết thúc:"></asp:Label>
                <telerik:RadDateTimePicker ID="radDpkEndTime" runat="server" Width="200px" Culture="Vietnamese (Vietnam)" MinDate="1753-01-01">
                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                    </Calendar>
                    <TimeView CellSpacing="-1" Culture="Vietnamese (Vietnam)">
                    </TimeView>
                    <TimePopupButton HoverImageUrl="" ImageUrl="" />
                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                </telerik:RadDateTimePicker>
                <asp:Label ID="lblEndTimeErrorLabel" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                <br class="clear" />
            </p>
            <asp:PlaceHolder ID="plhBanner" runat="server">
                <p>
                    <asp:Label ID="lblFileLink1Label" runat="server" CssClass="label w150" Text="File:"></asp:Label>
                    <telerik:RadTextBox ID="txtFileLink1" runat="server" Width="450px" MaxLength="255">
                    </telerik:RadTextBox>
                    <img alt="Chọn File" title="Chọn File" class="cpointer" src="/Images/SmallIcon/40.png" onclick="selectFileLink1()" />
                    <img alt="Xem File" title="Xem File" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewFileLink1()" />
                    <br class="clear" />
                </p>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="plhAddcode" runat="server">
                <p>
                    <asp:Label ID="lblFileJSLabel" runat="server" CssClass="label w150" Text="File JS:"></asp:Label>
                    <telerik:RadTextBox ID="txtFileJS" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblCodeJSLabel" runat="server" CssClass="label w150" Text="Code JS:"></asp:Label>
                    <telerik:RadTextBox ID="txtCodeJS" runat="server" Width="450px" Height="150px" TextMode="MultiLine" MaxLength="4000"></telerik:RadTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblExMode1Label" runat="server" CssClass="label w150" Text="Thứ tự:"></asp:Label>
                    <telerik:RadComboBox ID="cmbExMode1" runat="server" Width="454px">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                        <Items>
                            <telerik:RadComboBoxItem Text="Thêm file js trước khi gọi code" Value="0" runat="server" />
                            <telerik:RadComboBoxItem Text="Thêm code trước khi gọi file js" Value="1" runat="server" />
                        </Items>
                    </telerik:RadComboBox>
                    <br class="clear" />
                </p>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="plhExpanding" runat="server">
                <p>
                    <asp:Label ID="lblFileLink11Label" runat="server" CssClass="label w150" Text="File 1:"></asp:Label>
                    <telerik:RadTextBox ID="txtFileLink11" runat="server" Width="450px" MaxLength="255">
                    </telerik:RadTextBox>
                    <img alt="Chọn File" title="Chọn File" class="cpointer" src="/Images/SmallIcon/40.png" onclick="selectFileLink11()" />
                    <img alt="Xem File" title="Xem File" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewFileLink11()" />
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblFileLink2Label" runat="server" CssClass="label w150" Text="File 2:"></asp:Label>
                    <telerik:RadTextBox ID="txtFileLink2" runat="server" Width="450px" MaxLength="255">
                    </telerik:RadTextBox>
                    <img alt="Chọn File" title="Chọn File" class="cpointer" src="/Images/SmallIcon/40.png" onclick="selectFileLink2()" />
                    <img alt="Xem File" title="Xem File" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewFileLink2()" />
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblExWidthLabel" runat="server" CssClass="label w150" Text="Chiều rộng (px):"></asp:Label>
                    <telerik:RadNumericTextBox ID="txtExWidth" runat="server" MinValue="0" Value="0" Width="450px" CssClass="right">
                        <NumberFormat DecimalDigits="0" />
                    </telerik:RadNumericTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblExHeightLabel" runat="server" CssClass="label w150" Text="Chiều cao (px):"></asp:Label>
                    <telerik:RadNumericTextBox ID="txtExHeight" runat="server" MinValue="0" Value="0" Width="450px" CssClass="right">
                        <NumberFormat DecimalDigits="0" />
                    </telerik:RadNumericTextBox>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblExModeLabel" runat="server" CssClass="label w150" Text="Hướng:"></asp:Label>
                    <telerik:RadComboBox ID="cmbExMode" runat="server" Width="454px">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                        <Items>
                            <telerik:RadComboBoxItem Text="Trái dưới" Value="0" runat="server" />
                            <telerik:RadComboBoxItem Text="Phải dưới" Value="1" runat="server" />
                        </Items>
                    </telerik:RadComboBox>
                    <br class="clear" />
                </p>
            </asp:PlaceHolder>
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
    </div>
</asp:Content>
