<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="AdvertisementZoneEdit.aspx.cs" Inherits="VietNamNet.AddOn.Advertisement.AdvertisementZoneEdit" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>
<%@ Register Src="PanelAdvBlock.ascx" TagName="PanelAdvBlock" TagPrefix="uc" %>
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
            <telerik:AjaxSetting AjaxControlID="pnlBlock">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlBlock" />
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
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" SelectedIndex="0">
                <Tabs>
                    <telerik:RadTab Text="Thông tin chung"></telerik:RadTab>
                    <telerik:RadTab Text="Danh sách block"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="rpvCommonInfo" runat="server">
                    <p>
                        <asp:Label ID="lblNameLabel" runat="server" CssClass="label w150" Text="Tên Zone:"></asp:Label>
                        <telerik:RadTextBox ID="txtName" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <asp:Label ID="lblNameErrorLabel" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblHolderIdLabel" runat="server" CssClass="label w150" Text="Zone Id:"></asp:Label>
                        <telerik:RadTextBox ID="txtHolderId" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <asp:Label ID="lblHolderIdErrorLabel" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblModeLabel" runat="server" CssClass="label w150" Text="Chế độ:"></asp:Label>
                        <telerik:RadComboBox ID="cmbMode" runat="server" Width="454px">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                            <Items>
                                <telerik:RadComboBoxItem Text="Thứ tự" Value="1" runat="server" />
                                <telerik:RadComboBoxItem Text="Ngẫu nhiên" Value="0" runat="server" />
                            </Items>
                        </telerik:RadComboBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblDirectionLabel" runat="server" CssClass="label w150" Text="Hướng:"></asp:Label>
                        <telerik:RadComboBox ID="cmbDirection" runat="server" Width="454px">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                            <Items>
                                <telerik:RadComboBoxItem Text="Chiều dọc" Value="0" runat="server" />
                                <telerik:RadComboBoxItem Text="Chiều ngang" Value="1" runat="server" />
                            </Items>
                        </telerik:RadComboBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblWidthLabel" runat="server" CssClass="label w150" Text="Chiều rộng (px):"></asp:Label>
                        <telerik:RadNumericTextBox ID="txtWidth" runat="server" MinValue="0" Value="0" Width="450px" CssClass="right">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblHeightLabel" runat="server" CssClass="label w150" Text="Chiều cao (px):"></asp:Label>
                        <telerik:RadNumericTextBox ID="txtHeight" runat="server" MinValue="0" Value="0" Width="450px" CssClass="right">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblDetailLabel" runat="server" CssClass="label w150" Text="Mô tả:"></asp:Label>
                        <telerik:RadTextBox ID="txtDetail" runat="server" Width="450px" Height="150px" TextMode="MultiLine" MaxLength="4000"></telerik:RadTextBox>
                        <br class="clear" />
                    </p>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvBlock" runat="server">
                    <asp:Panel ID="pnlBlock" runat="server">
                        <uc:PanelAdvBlock ID="pnlAdvBlock" runat="server" EditOption="1" />
                    </asp:Panel>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </asp:Panel>
        <asp:Panel ID="pnlAuditTrail" runat="server" CssClass="form-editor-container">
            <uc:AuditTrail id="AuditTrail1" runat="server">
            </uc:AuditTrail>
        </asp:Panel>
    </div>
</asp:Content>
