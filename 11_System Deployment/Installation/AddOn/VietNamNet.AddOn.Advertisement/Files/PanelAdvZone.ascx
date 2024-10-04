<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelAdvZone.ascx.cs" Inherits="VietNamNet.AddOn.Advertisement.PanelAdvZone" %>
<telerik:RadScriptBlock runat="server" ID="scriptBlock">

    <script type="text/javascript">
        
        function onRowDropping(sender, args) {
            if(sender.get_id()=="<%=radGridAdvertisementZones.ClientID %>") {
                var node = args.get_destinationHtmlElement();
                if(!isChildOf('<%=radGridLayoutZone.ClientID %>', node)) {
                    args.set_cancel(true);
                }
            }
            if(sender.get_id()=="<%=radGridLayoutZone.ClientID %>") {
                var node = args.get_destinationHtmlElement();
                if(!isChildOf('<%=radGridAdvertisementZones.ClientID %>', node)) {
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
    <asp:Panel ID="pnlAdvertisementZones" runat="server" CssClass="fleft pd10">
        <div style="font-size:16px;font-weight:bold;padding:8px 0;">Danh sách Zone</div>
        <telerik:RadGrid ID="radGridAdvertisementZones" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
            Width="350px" GridLines="None" OnNeedDataSource="radGridAdvertisementZones_NeedDataSource" AllowMultiRowSelection="true" 
            OnRowDrop="radGridAdvertisementZones_RowDrop" AllowFilteringByColumn="True" OnItemCommand="radGridAdvertisementZones_ItemCommand">
            <GroupingSettings CaseSensitive="false" />
            <MasterTableView ClientDataKeyNames="Id,Name" DataKeyNames="Id,Name" GroupLoadMode="Client"
                NoMasterRecordsText="Kh&#244;ng c&#243; zone n&#224;o.">
                <Columns>
                    <telerik:GridBoundColumn DataField="Name" HeaderText="T&#234;n Zone" UniqueName="Name" FilterControlWidth="150px" ShowFilterIcon="false" AutoPostBackOnFilter="true">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="Xem" AllowFiltering="false">
                        <ItemStyle CssClass="center" />
                        <ItemTemplate>
                            <a target="_blank" href='AdvertisementZoneDisplay.aspx?DocId=<%#DataBinder.Eval(Container.DataItem, "Id")%>'>
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
    <asp:Panel ID="pnlLayoutZone" runat="server" CssClass="fleft pd10">
        <div style="font-size:16px;font-weight:bold;padding:8px 0;">Zone trong Layout</div>
        <telerik:RadGrid ID="radGridLayoutZone" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
            Width="350px" GridLines="None" OnNeedDataSource="radGridLayoutZone_NeedDataSource" AllowMultiRowSelection="true" 
            OnRowDrop="radGridLayoutZone_RowDrop" AllowFilteringByColumn="True" OnItemCommand="radGridLayoutZone_ItemCommand">
            <GroupingSettings CaseSensitive="false" />
            <MasterTableView ClientDataKeyNames="Id,LayoutId,ZoneId,ZoneName" DataKeyNames="Id,LayoutId,ZoneId,ZoneName" GroupLoadMode="Client"
                NoMasterRecordsText="Kh&#244;ng c&#243; zone n&#224;o.">
                <Columns>
                    <telerik:GridBoundColumn DataField="ZoneName" HeaderText="T&#234;n Zone" UniqueName="ZoneName" FilterControlWidth="150px" ShowFilterIcon="false" AutoPostBackOnFilter="true">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="Xem" AllowFiltering="false">
                        <ItemStyle CssClass="center" />
                        <ItemTemplate>
                            <a target="_blank" href='AdvertisementZoneDisplay.aspx?DocId=<%#DataBinder.Eval(Container.DataItem, "ZoneId")%>'>
                                <img alt="Xem thông tin chi tiết" title="Xem thông tin chi tiết" width="16" src="/Images/LargeIcon/zoom.png" />
                            </a>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="120px" Font-Bold="True" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="SaveStatus" HeaderText="SaveStatus" UniqueName="SaveStatus" Visible="False">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
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
    <br class="clear" />
</div>
