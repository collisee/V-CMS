<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="AdvertisementItemDisplay.aspx.cs" Inherits="VietNamNet.AddOn.Advertisement.AdvertisementItemDisplay" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <telerik:RadScriptBlock runat="server" ID="scriptBlock">

        <script type="text/javascript">
                
            function previewFileLink1()
            {
                var hidden = $get('<%=hidFileLink1.ClientID %>');
                if (hidden && hidden.value) window.open(hidden.value);
            }

            function previewFileLink11()
            {
                var hidden = $get('<%=hidFileLink11.ClientID %>');
                if (hidden && hidden.value) window.open(hidden.value);
            }

            function previewFileLink2()
            {
                var hidden = $get('<%=hidFileLink2.ClientID %>');
                if (hidden && hidden.value) window.open(hidden.value);
            }

        </script>
        
    </telerik:RadScriptBlock>
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
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="pd05">
        <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick" OnClientButtonClicking="radToolBarDefault_ClientButtonClicking">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/newitem.gif" CommandName="AddNew"
                        Text="Tạo mới" AccessKey="N">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/edititem.gif" CommandName="Edit"
                        Text="Sửa" AccessKey="E">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/delete.gif" CommandName="Delete"
                        Text="Xóa" AccessKey="D">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/10.gif" CommandName="Copy"
                        Text="Copy" AccessKey="C">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/goback1.gif" CommandName="GoBacktoView"
                        Text="Quay lại" AccessKey="G">
                    </telerik:RadToolBarButton>
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
            <br />
            <asp:Label ID="lblMessage" runat="server" CssClass="blue" Text="" Visible="false"></asp:Label>
            <br />
            <p>
                <asp:Label ID="lblNameLabel" runat="server" CssClass="label w150" Text="Tên Item:"></asp:Label>
                <asp:Label ID="lblName" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblLinkLabel" runat="server" CssClass="label w150" Text="Link:"></asp:Label>
                <asp:HyperLink ID="lnkLink" runat="server" CssClass="label" Target="_blank"></asp:HyperLink>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblAdvertisementTypeLabel" runat="server" CssClass="label w150" Text="Loại quảng cáo:"></asp:Label>
                <asp:Label ID="lblAdvertisementType" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblStartTimeLabel" runat="server" CssClass="label w150" Text="Ngày giờ bắt đầu:"></asp:Label>
                <asp:Label ID="lblStartTime" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblEndTimeLabel" runat="server" CssClass="label w150" Text="Ngày giờ kết thúc:"></asp:Label>
                <asp:Label ID="lblEndTime" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <asp:PlaceHolder ID="plhBanner" runat="server">
                <p>
                    <asp:Label ID="lblFileLink1Label" runat="server" CssClass="label w150" Text="File:"></asp:Label>
                    <asp:Label ID="lblFileLink1" runat="server" CssClass="label" Text=""></asp:Label>
                    <asp:HiddenField ID="hidFileLink1" runat="server"></asp:HiddenField>
                    &nbsp;
                    <img alt="Xem File" title="Xem File" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewFileLink1()" />
                    <br class="clear" />
                </p>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="plhAddcode" runat="server">
                <p>
                    <asp:Label ID="lblFileJSLabel" runat="server" CssClass="label w150" Text="File JS:"></asp:Label>
                    <asp:Label ID="lblFileJS" runat="server" CssClass="label w450" Text=""></asp:Label>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblCodeJSLabel" runat="server" CssClass="label w150" Text="Code JS:"></asp:Label>
                    <asp:Label ID="lblCodeJS" runat="server" CssClass="label w450" Text=""></asp:Label>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblExMode1Label" runat="server" CssClass="label w150" Text="Thứ tự:"></asp:Label>
                    <asp:Label ID="lblExMode1" runat="server" CssClass="label w450" Text=""></asp:Label>
                    <br class="clear" />
                </p>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="plhExpanding" runat="server">
                <p>
                    <asp:Label ID="lblFileLink11Label" runat="server" CssClass="label w150" Text="File 1:"></asp:Label>
                    <asp:Label ID="lblFileLink11" runat="server" CssClass="label" Text=""></asp:Label>
                    <asp:HiddenField ID="hidFileLink11" runat="server"></asp:HiddenField>
                    &nbsp;
                    <img alt="Xem File" title="Xem File" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewFileLink11()" />
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblFileLink2Label" runat="server" CssClass="label w150" Text="File 2:"></asp:Label>
                    <asp:Label ID="lblFileLink2" runat="server" CssClass="label" Text=""></asp:Label>
                    <asp:HiddenField ID="hidFileLink2" runat="server"></asp:HiddenField>
                    &nbsp;
                    <img alt="Xem File" title="Xem File" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewFileLink2()" />
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblExWidthLabel" runat="server" CssClass="label w150" Text="Chiều rộng (px):"></asp:Label>
                    <asp:Label ID="lblExWidth" runat="server" CssClass="label w450" Text=""></asp:Label>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblExHeightLabel" runat="server" CssClass="label w150" Text="Chiều cao (px):"></asp:Label>
                    <asp:Label ID="lblExHeight" runat="server" CssClass="label w450" Text=""></asp:Label>
                    <br class="clear" />
                </p>
                <p>
                    <asp:Label ID="lblExModeLabel" runat="server" CssClass="label w150" Text="Hướng:"></asp:Label>
                    <asp:Label ID="lblExMode" runat="server" CssClass="label w450" Text=""></asp:Label>
                    <br class="clear" />
                </p>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="plhIFrame" runat="server">
                <p>
                    <asp:Label ID="lblFileJS1Label" runat="server" CssClass="label w150" Text="File link:"></asp:Label>
                    <asp:Label ID="lblFileJS1" runat="server" CssClass="label w450" Text=""></asp:Label>
                    <br class="clear" />
                </p>
            </asp:PlaceHolder>
            <p>
                <asp:Label ID="lblDetailLabel" runat="server" CssClass="label w150" Text="Mô tả:"></asp:Label>
                <asp:Label ID="lblDetail" runat="server" CssClass="label w450"></asp:Label>
                <br class="clear" />
            </p>
        </asp:Panel>
        <asp:Panel ID="pnlAuditTrail" runat="server" CssClass="form-editor-container">
            <uc:AuditTrail id="AuditTrail1" runat="server">
            </uc:AuditTrail>
        </asp:Panel>
    </div>
</asp:Content>
