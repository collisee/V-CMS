<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="GroupEdit.aspx.cs" Inherits="VietNamNet.Framework.Administrator.GroupEdit" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <telerik:RadScriptBlock runat="server" ID="scriptBlock">

        <script type="text/javascript">
            
            function onRowDropping(sender, args) {
                if(sender.get_id()=="<%=radGridUsers.ClientID %>") {
                    var node = args.get_destinationHtmlElement();
                    if(!isChildOf('<%=radGridMembers.ClientID %>', node)) {
                        args.set_cancel(true);
                    }
                }
                if(sender.get_id()=="<%=radGridMembers.ClientID %>") {
                    var node = args.get_destinationHtmlElement();
                    if(!isChildOf('<%=radGridUsers.ClientID %>', node)) {
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
            <telerik:AjaxSetting AjaxControlID="radGridUsers">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radGridUsers" />
                    <telerik:AjaxUpdatedControl ControlID="radGridMembers" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="radGridMembers">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radGridUsers" />
                    <telerik:AjaxUpdatedControl ControlID="radGridMembers" />
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
            <p>
                <asp:Label ID="lblNameLabel" runat="server" CssClass="label w150" Text="Tên Nhóm:"></asp:Label>
                <telerik:RadTextBox ID="txtName" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblDetailLabel" runat="server" CssClass="label w150" Text="Mô tả:"></asp:Label>
                <telerik:RadTextBox ID="txtDetail" runat="server" Width="450px" Height="150px" TextMode="MultiLine" MaxLength="4000"></telerik:RadTextBox>
                <br class="clear" />
            </p>
            <br />
            <div>
                <div class="fleft pd10">
                    <div style="font-size:16px;font-weight:bold;padding:8px 0;">Danh sách Người dùng</div>
                    <telerik:RadGrid ID="radGridUsers" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
                        Width="350px" GridLines="None" OnNeedDataSource="radGridUsers_NeedDataSource" AllowMultiRowSelection="true" OnRowDrop="radGridUsers_RowDrop" AllowFilteringByColumn="True" OnItemCommand="radGridUsers_ItemCommand">
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView ClientDataKeyNames="Id,LoginName,FullName" DataKeyNames="Id,LoginName,FullName" GroupLoadMode="Client"
                            NoMasterRecordsText="Kh&#244;ng c&#243; nh&#243;m n&#224;o.">
                            <Columns>
                                <telerik:GridBoundColumn DataField="LoginName" HeaderText="T&#234;n đăng nhập" UniqueName="LoginName" FilterControlWidth="150px" ShowFilterIcon="false" AutoPostBackOnFilter="true">
                                    <HeaderStyle Font-Bold="True" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FullName" HeaderText="T&#234;n đầy đủ" UniqueName="FullName" FilterControlWidth="150px" ShowFilterIcon="false" AutoPostBackOnFilter="true">
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
                            NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
                    </telerik:RadGrid>
                </div>
                <div class="fleft pd10">
                    <div style="font-size:16px;font-weight:bold;padding:8px 0;">Thành viên của Nhóm</div>
                    <telerik:RadGrid ID="radGridMembers" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
                        Width="350px" GridLines="None" OnNeedDataSource="radGridMembers_NeedDataSource" AllowMultiRowSelection="true" OnRowDrop="radGridMembers_RowDrop" AllowFilteringByColumn="True" OnItemCommand="radGridMembers_ItemCommand">
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView ClientDataKeyNames="Id,GroupId,UserId,LoginName,FullName" DataKeyNames="Id,GroupId,UserId,LoginName,FullName" GroupLoadMode="Client"
                            NoMasterRecordsText="Kh&#244;ng c&#243; nh&#243;m n&#224;o.">
                            <Columns>
                                <telerik:GridBoundColumn DataField="LoginName" HeaderText="T&#234;n đăng nhập" UniqueName="LoginName" FilterControlWidth="150px" ShowFilterIcon="false" AutoPostBackOnFilter="true">
                                    <HeaderStyle Font-Bold="True" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FullName" HeaderText="T&#234;n đầy đủ" UniqueName="FullName" FilterControlWidth="150px" ShowFilterIcon="false" AutoPostBackOnFilter="true">
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
                            NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
                    </telerik:RadGrid>
                </div>
                <br class="clear" />
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlAuditTrail" runat="server" CssClass="form-editor-container">
            <uc:AuditTrail id="AuditTrail1" runat="server">
            </uc:AuditTrail>
        </asp:Panel>
    </div>
</asp:Content>
