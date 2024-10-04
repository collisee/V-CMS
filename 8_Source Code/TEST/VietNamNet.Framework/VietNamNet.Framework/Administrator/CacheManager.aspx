<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="CacheManager.aspx.cs" Inherits="VietNamNet.Framework.Administrator.CacheManager" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <telerik:RadScriptBlock ID="radScriptBlockMySite" runat="server">

        <script type="text/javascript">
          
        function viewCache(key)
        {
            var oWnd = radopen("PopupViewCache.aspx?Key=" + key);
            oWnd.setSize(640,520);
        }
        
        function CacheManagerRowDblClick(sender, eventArgs)
        {
            var key = eventArgs.getDataKeyValue('Key');
            var code = eventArgs.getDataKeyValue('Code');
            if (code && code == 1) viewCache(key);
        }
    
        </script>

    </telerik:RadScriptBlock>
    <telerik:RadWindowManager ID="radWindowCacheManager" runat="server"
        Behaviors="Maximize,Move,Reload,Resize,Close" VisibleStatusbar="False" DestroyOnClose="True">
    </telerik:RadWindowManager>
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="radAjaxPanelView" runat="server" LoadingPanelID="radAjaxLoadingPanel" CssClass="pd05">
        <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar none">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/delete.gif" CommandName="Clear"
                        Text="Xóa hết Cache" AccessKey="C">
                    </telerik:RadToolBarButton>
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        <asp:Panel ID="pnlRadGrid" runat="server" CssClass="radgrid">
            <telerik:RadGrid ID="radGridDefault" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                GridLines="None" AllowPaging="True" OnNeedDataSource="radGridDefault_NeedDataSource" OnDeleteCommand="radGridDefault_DeleteCommand">
                <MasterTableView ClientDataKeyNames="Key,Code" DataKeyNames="Key,Code"
                    GroupLoadMode="Client" NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o.">
                    <RowIndicatorColumn>
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn>
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="#">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <%# Container.ItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Right" Width="50px" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="Key" HeaderText="Cache Key" UniqueName="Key">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ObjectType" HeaderText="Object Type" UniqueName="ObjectType">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Length" HeaderText="Length" UniqueName="Length" DataFormatString="{0:#,##0}">
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                            <HeaderStyle HorizontalAlign="Right" Font-Bold="True" Width="100px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Note" HeaderText="Note" UniqueName="Note">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                            ConfirmText="Bạn c&#243; chắc chắn muốn X&#243;a Cache n&#224;y?" ConfirmTitle="X&#243;a"
                            HeaderText="X&#243;a" Text="X&#243;a" UniqueName="Delete">
                            <ItemStyle CssClass="center" Width="32px" />
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="True" Width="32px" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="True">
                    <Resizing AllowColumnResize="True" />
                    <ClientEvents OnRowDblClick="CacheManagerRowDblClick" />
                </ClientSettings>
                <FilterMenu EnableTheming="True">
                    <CollapseAnimation Duration="200" Type="OutQuint" />
                </FilterMenu>
                <GroupingSettings CollapseTooltip="Đ&#243;ng" ExpandTooltip="Mở" GroupSplitFormat="" />
                <PagerStyle FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang tiếp"
                    NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
            </telerik:RadGrid>
        </asp:Panel>
    </telerik:RadAjaxPanel>
</asp:Content>