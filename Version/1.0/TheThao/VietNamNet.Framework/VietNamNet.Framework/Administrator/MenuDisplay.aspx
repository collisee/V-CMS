<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="MenuDisplay.aspx.cs" Inherits="VietNamNet.Framework.Administrator.MenuDisplay" %>
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
            <asp:Label ID="lblMessage" runat="server" CssClass="blue" Text="" Visible="false"></asp:Label>
            <br />
            <p>
                <asp:Label ID="lblParentNameLabel" runat="server" CssClass="label w150" Text="Menu cha:"></asp:Label>
                <asp:Label ID="lblParentName" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblOrderLabel" runat="server" CssClass="label w150" Text="Thứ tự:"></asp:Label>
                <asp:Label ID="lblOrder" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblNameLabel" runat="server" CssClass="label w150" Text="Tên:"></asp:Label>
                <asp:Label ID="lblName" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblDisplayNameLabel" runat="server" CssClass="label w150" Text="Tên hiển thị:"></asp:Label>
                <asp:Label ID="lblDisplayName" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblLinkLabel" runat="server" CssClass="label w150" Text="Link:"></asp:Label>
                <asp:Label ID="lblLink" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p class="none">
                <asp:Label ID="lblImageURLLabel" runat="server" CssClass="label w150" Text="ImageURL:"></asp:Label>
                <asp:Image ID="imageURL" runat="server" />
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblModuleNameLabel" runat="server" CssClass="label w150" Text="Module:"></asp:Label>
                <asp:Label ID="lblModuleName" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblAccessLabel" runat="server" CssClass="label w150" Text="Truy cập:"></asp:Label>
                <asp:CheckBoxList ID="cblFunctions" runat="server" DataTextField="Name" DataValueField="Ord" RepeatDirection="Horizontal" RepeatLayout="Flow" Enabled="False">
                </asp:CheckBoxList>
                <br class="clear" />
            </p>
        </asp:Panel>
        <asp:Panel ID="pnlAuditTrail" runat="server" CssClass="form-editor-container">
            <uc:AuditTrail ID="AuditTrail1" runat="server"></uc:AuditTrail>
        </asp:Panel>
    </div>
</asp:Content>
