<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="GroupDisplay.aspx.cs" Inherits="VietNamNet.Framework.Administrator.GroupDisplay" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
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
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/goback1.gif" CommandName="GoBacktoView"
                        Text="Quay lại" AccessKey="G">
                    </telerik:RadToolBarButton>
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
            <asp:Label ID="lblMessage" runat="server" CssClass="blue" Text="" Visible="false"></asp:Label>
            <br />
            <p>
                <asp:Label ID="lblNameLabel" runat="server" CssClass="label w150" Text="Tên Nhóm:"></asp:Label>
                <asp:Label ID="lblName" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblDetailLabel" runat="server" CssClass="label w150" Text="Mô tả:"></asp:Label>
                <asp:Label ID="lblDetail" runat="server" CssClass="label w450"></asp:Label>
                <br class="clear" />
            </p>
            <div class="pd10">
                <div style="font-weight:bold;padding:8px 0;">Thành viên của Nhóm</div>
                <telerik:RadGrid ID="radGridMembers" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
                    Width="400px" GridLines="None" AllowMultiRowSelection="true" OnNeedDataSource="radGridMembers_NeedDataSource">
                    <MasterTableView ClientDataKeyNames="Id" DataKeyNames="Id" GroupLoadMode="Client"
                        NoMasterRecordsText="Kh&#244;ng c&#243; nhóm n&#224;o.">
                        <Columns>
                            <telerik:GridBoundColumn DataField="LoginName" HeaderText="Tên đăng nhập" UniqueName="LoginName">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FullName" HeaderText="Tên đầy đủ" UniqueName="FullName">
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
        </asp:Panel>
        <asp:Panel ID="pnlAuditTrail" runat="server" CssClass="form-editor-container">
            <uc:AuditTrail id="AuditTrail1" runat="server">
            </uc:AuditTrail>
        </asp:Panel>
    </div>
</asp:Content>
