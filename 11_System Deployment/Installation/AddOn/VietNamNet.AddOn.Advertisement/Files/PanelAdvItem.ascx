<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelAdvItem.ascx.cs" Inherits="VietNamNet.AddOn.Advertisement.PanelAdvItem" %>
<telerik:RadScriptBlock runat="server" ID="scriptBlock">

    <script type="text/javascript">
        
        function onRowDropping(sender, args) {
            if(sender.get_id()=="<%=radGridAdvertisementItems.ClientID %>") {
                var node = args.get_destinationHtmlElement();
                if(!isChildOf('<%=radGridBlockItem.ClientID %>', node)) {
                    args.set_cancel(true);
                }
            }
            if(sender.get_id()=="<%=radGridBlockItem.ClientID %>") {
                var node = args.get_destinationHtmlElement();
                if(!isChildOf('<%=radGridAdvertisementItems.ClientID %>', node) && !isChildOf('<%=radGridBlockItem.ClientID %>', node)) {
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
    <asp:Panel ID="pnlAdvertisementItems" runat="server" CssClass="fleft pd10">
        <div style="font-size:16px;font-weight:bold;padding:8px 0;">Danh sách Item</div>
        <telerik:RadGrid ID="radGridAdvertisementItems" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
            Width="350px" GridLines="None" OnNeedDataSource="radGridAdvertisementItems_NeedDataSource" AllowMultiRowSelection="true" 
            OnRowDrop="radGridAdvertisementItems_RowDrop" AllowFilteringByColumn="True" OnItemCommand="radGridAdvertisementItems_ItemCommand">
            <GroupingSettings CaseSensitive="false" />
            <MasterTableView ClientDataKeyNames="Id,Name" DataKeyNames="Id,Name" GroupLoadMode="Client"
                NoMasterRecordsText="Kh&#244;ng c&#243; item n&#224;o.">
                <Columns>
                    <telerik:GridBoundColumn DataField="Name" HeaderText="T&#234;n Item" UniqueName="Name" FilterControlWidth="150px" ShowFilterIcon="false" AutoPostBackOnFilter="true">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="Xem" AllowFiltering="false">
                        <ItemStyle CssClass="center" />
                        <ItemTemplate>
                            <a target="_blank" href='AdvertisementItemDisplay.aspx?DocId=<%#DataBinder.Eval(Container.DataItem, "Id")%>'>
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
    <asp:Panel ID="pnlBlockItem" runat="server" CssClass="fleft pd10">
        <div style="font-size:16px;font-weight:bold;padding:8px 0;">Item trong Block</div>
        <telerik:RadGrid ID="radGridBlockItem" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
            Width="350px" GridLines="None" OnNeedDataSource="radGridBlockItem_NeedDataSource" AllowMultiRowSelection="true" 
            OnRowDrop="radGridBlockItem_RowDrop" AllowFilteringByColumn="True" OnItemCommand="radGridBlockItem_ItemCommand">
            <GroupingSettings CaseSensitive="false" />
            <MasterTableView ClientDataKeyNames="Id,BlockId,ItemId,ItemName" DataKeyNames="Id,BlockId,ItemId,ItemName" GroupLoadMode="Client"
                NoMasterRecordsText="Kh&#244;ng c&#243; item n&#224;o.">
                <Columns>
                    <telerik:GridBoundColumn DataField="ItemName" HeaderText="T&#234;n Item" UniqueName="ItemName" FilterControlWidth="150px" ShowFilterIcon="false" AutoPostBackOnFilter="true">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SaveStatus" HeaderText="SaveStatus" UniqueName="SaveStatus" Visible="False">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="Xem" AllowFiltering="false">
                        <ItemStyle CssClass="center" />
                        <ItemTemplate>
                            <a target="_blank" href='AdvertisementItemDisplay.aspx?DocId=<%#DataBinder.Eval(Container.DataItem, "ItemId")%>'>
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
