<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="VietNamNet.Framework.UserInfo" Title="VietNamNet Framework - Thông tin người dùng" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">

    <div class="pd05">
        <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            &nbsp;
        </asp:Panel>
        <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
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
                        <asp:Label ID="lblStatus" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblLoginNameLabel" runat="server" CssClass="label w150" Text="Tên đăng nhập:"></asp:Label>
                        <asp:Label ID="lblLoginName" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblFullNameLabel" runat="server" CssClass="label w150" Text="Tên đầy đủ:"></asp:Label>
                        <asp:Label ID="lblFullName" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblEmailLabel" runat="server" CssClass="label w150" Text="Email:"></asp:Label>
                        <asp:Label ID="lblEmail" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblAvatarLabel" runat="server" CssClass="label w150" Text="Hình ảnh đại diện:"></asp:Label>
                        <asp:Image ID="imgAvatar" runat="server" Width="150px" />
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSexLabel" runat="server" CssClass="label w150" Text="Giới tính:"></asp:Label>
                        <asp:Label ID="lblSex" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblBirthdayLabel" runat="server" CssClass="label w150" Text="Ngày sinh:"></asp:Label>
                        <asp:Label ID="lblBirthday" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblAddressLabel" runat="server" CssClass="label w150" Text="Địa chỉ:"></asp:Label>
                        <asp:Label ID="lblAddress" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblPhoneLabel" runat="server" CssClass="label w150" Text="Điện thoại:"></asp:Label>
                        <asp:Label ID="lblPhone" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblMobileLabel" runat="server" CssClass="label w150" Text="Di động:"></asp:Label>
                        <asp:Label ID="lblMobile" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblYahooLabel" runat="server" CssClass="label w150" Text="Yahoo:"></asp:Label>
                        <asp:Label ID="lblYahoo" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSkypeLabel" runat="server" CssClass="label w150" Text="Skype:"></asp:Label>
                        <asp:Label ID="lblSkype" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblFacebookLabel" runat="server" CssClass="label w150" Text="Facebook:"></asp:Label>
                        <asp:Label ID="lblFacebook" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblDetailLabel" runat="server" CssClass="label w150" Text="Mô tả:"></asp:Label>
                        <asp:Label ID="lblDetail" runat="server" CssClass="label w450"></asp:Label>
                        <br class="clear" />
                    </p>
            </telerik:RadPageView>
                <telerik:RadPageView ID="rpvMemberOf" runat="server">
                    <div class="pd10">
                        <telerik:RadGrid ID="radGridMemberOf" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
                            Width="300px" GridLines="None" AllowMultiRowSelection="true">
                            <MasterTableView ClientDataKeyNames="Id" DataKeyNames="Id" GroupLoadMode="Client"
                                NoMasterRecordsText="Kh&#244;ng c&#243; nhóm n&#224;o.">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="GroupName" HeaderText="Nhóm" UniqueName="LoginName">
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="True">
                                <Scrolling AllowScroll="True" UseStaticHeaders="True"/>
                            </ClientSettings>
                            <FilterMenu EnableTheming="True">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
                            </FilterMenu>
                            <GroupingSettings CollapseTooltip="Đ&#243;ng" ExpandTooltip="Mở" GroupSplitFormat="" />
                            <PagerStyle FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang tiếp"
                                NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
                        </telerik:RadGrid>
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
