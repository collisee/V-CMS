<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="AdvertisementLayoutEdit.aspx.cs" Inherits="VietNamNet.AddOn.Advertisement.AdvertisementLayoutEdit" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>
<%@ Register Src="PanelAdvZone.ascx" TagName="PanelAdvZone" TagPrefix="uc" %>
<%@ Register Src="PanelAdvCategory.ascx" TagName="PanelAdvCategory" TagPrefix="uc" %>
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
            <telerik:AjaxSetting AjaxControlID="pnlZone">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlZone" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlCategory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlCategory" />
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
                    <telerik:RadTab Text="Danh sách zone"></telerik:RadTab>
                    <telerik:RadTab Text="Danh sách danh mục"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="rpvCommonInfo" runat="server">
                    <p>
                        <asp:Label ID="lblNameLabel" runat="server" CssClass="label w150" Text="Tên Layout:"></asp:Label>
                        <telerik:RadTextBox ID="txtName" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <asp:Label ID="lblNameErrorLabel" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblDetailLabel" runat="server" CssClass="label w150" Text="Mô tả:"></asp:Label>
                        <telerik:RadTextBox ID="txtDetail" runat="server" Width="450px" Height="150px" TextMode="MultiLine" MaxLength="4000"></telerik:RadTextBox>
                        <br class="clear" />
                    </p>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvZone" runat="server">
                    <asp:Panel ID="pnlZone" runat="server">
                        <uc:PanelAdvZone ID="pnlAdvZone" runat="server" EditOption="1" />
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvPublish" runat="server">
                    <asp:Panel ID="pnlCategory" runat="server">
                        <uc:PanelAdvCategory ID="pnlAdvCategory" runat="server" EditOption="1" />
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
