<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelAdvBlock.ascx.cs" Inherits="VietNamNet.AddOn.Advertisement.PanelAdvBlock" %>
<telerik:RadScriptBlock runat="server" ID="scriptZone">

    <script type="text/javascript">
        
        function onRowDropping(sender, args) {
            if(sender.get_id()=="<%=radGridAdvertisementBlocks.ClientID %>") {
                var node = args.get_destinationHtmlElement();
                if(!isChildOf('<%=radGridZoneBlock.ClientID %>', node)) {
                    args.set_cancel(true);
                }
            }
            if(sender.get_id()=="<%=radGridZoneBlock.ClientID %>") {
                var node = args.get_destinationHtmlElement();
                if(!isChildOf('<%=radGridAdvertisementBlocks.ClientID %>', node) && !isChildOf('<%=radGridZoneBlock.ClientID %>', node)) {
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

<div>
    <asp:Panel ID="pnlAdvertisementBlocks" runat="server" CssClass="fleft pd10">
        <div style="font-size:16px;font-weight:bold;padding:8px 0;">Danh sách Block</div>
        <telerik:RadGrid ID="radGridAdvertisementBlocks" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
            Width="350px" GridLines="None" OnNeedDataSource="radGridAdvertisementBlocks_NeedDataSource" AllowMultiRowSelection="true" 
            OnRowDrop="radGridAdvertisementBlocks_RowDrop" AllowFilteringByColumn="True" OnItemCommand="radGridAdvertisementBlocks_BlockCommand">
            <GroupingSettings CaseSensitive="false" />
            <MasterTableView ClientDataKeyNames="Id,Name" DataKeyNames="Id,Name" GroupLoadMode="Client"
                NoMasterRecordsText="Kh&#244;ng c&#243; block n&#224;o.">
                <Columns>
                    <telerik:GridBoundColumn DataField="Name" HeaderText="T&#234;n Block" UniqueName="Name" FilterControlWidth="150px" ShowFilterIcon="false" AutoPostBackOnFilter="true">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="Xem" AllowFiltering="false">
                        <ItemStyle CssClass="center" />
                        <ItemTemplate>
                            <a target="_blank" href='AdvertisementBlockDisplay.aspx?DocId=<%#DataBinder.Eval(Container.DataItem, "Id")%>'>
                                <img alt="Xem thông tin chi tiết" title="Xem thông tin chi tiết" width="16" src="/Images/LargeIcon/zoom.png" />
                            </a>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="120px" Font-Bold="True" />
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings AllowRowsDragDrop="True" EnableRowHoverStyle="True">
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"/>
                <Resizing AllowColumnResize="True" />
                <ClientEvents OnRowDblClick="RowDblClick" OnRowDropping="onRowDropping" />
            </ClientSettings>
            <FilterMenu EnableTheming="True">
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </FilterMenu>
            <GroupingSettings CollapseTooltip="Đ&#243;ng" ExpandTooltip="Mở" GroupSplitFormat="" />
            <PagerStyle FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang tiếp"
                NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
        </telerik:RadGrid>
    </asp:Panel>
    <asp:Panel ID="pnlZoneBlock" runat="server" CssClass="fleft pd10">
        <div style="font-size:16px;font-weight:bold;padding:8px 0;">Block trong Zone</div>
        <telerik:RadGrid ID="radGridZoneBlock" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
            Width="350px" GridLines="None" OnNeedDataSource="radGridZoneBlock_NeedDataSource" AllowMultiRowSelection="true" 
            OnRowDrop="radGridZoneBlock_RowDrop" AllowFilteringByColumn="True" OnItemCommand="radGridZoneBlock_BlockCommand">
            <GroupingSettings CaseSensitive="false" />
            <MasterTableView ClientDataKeyNames="Id,ZoneId,BlockId,BlockName" DataKeyNames="Id,ZoneId,BlockId,BlockName" GroupLoadMode="Client"
                NoMasterRecordsText="Kh&#244;ng c&#243; block n&#224;o.">
                <Columns>
                    <telerik:GridBoundColumn DataField="BlockName" HeaderText="T&#234;n Block" UniqueName="BlockName" FilterControlWidth="150px" ShowFilterIcon="false" AutoPostBackOnFilter="true">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SaveStatus" HeaderText="SaveStatus" UniqueName="SaveStatus" Visible="False">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="Xem" AllowFiltering="false">
                        <ItemStyle CssClass="center" />
                        <ItemTemplate>
                            <a target="_blank" href='AdvertisementBlockDisplay.aspx?DocId=<%#DataBinder.Eval(Container.DataItem, "BlockId")%>'>
                                <img alt="Xem thông tin chi tiết" title="Xem thông tin chi tiết" width="16" src="/Images/LargeIcon/zoom.png" />
                            </a>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="120px" Font-Bold="True" />
                    </telerik:GridTemplateColumn>
                </Columns>
                <SortExpressions>
                    <telerik:GridSortExpression FieldName="Ord"></telerik:GridSortExpression>
                </SortExpressions>
            </MasterTableView>
            <ClientSettings AllowRowsDragDrop="True" EnableRowHoverStyle="True">
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"/>
                <Resizing AllowColumnResize="True" />
                <ClientEvents OnRowDblClick="RowDblClick" OnRowDropping="onRowDropping" />
            </ClientSettings>
            <FilterMenu EnableTheming="True">
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </FilterMenu>
            <GroupingSettings CollapseTooltip="Đ&#243;ng" ExpandTooltip="Mở" GroupSplitFormat="" />
            <PagerStyle FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang tiếp"
                NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
        </telerik:RadGrid>
    </asp:Panel>
    <br class="clear" />
</div>
