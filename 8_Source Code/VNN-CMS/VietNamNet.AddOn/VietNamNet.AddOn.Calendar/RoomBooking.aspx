<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="RoomBooking.aspx.cs" Inherits="VietNamNet.AddOn.Calendar.RoomBooking" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <telerik:RadScriptBlock runat="server" ID="RadScriptBlock1">

        <script type="text/javascript">
            var selectedAppointment = null;
            var contextMenuSlot = null;
            
            //Called when the user right-clicks an appointment
            function appointmentContextMenu(sender, eventArgs)
            {
                var menu = $find("<%= SchedulerAppointmentContextMenu.ClientID %>");
                selectedAppointment = eventArgs.get_appointment();
                menu.show(eventArgs.get_domEvent());
            }

            //Called when the user clicks an item from the appointment context menu
            function appointmentContextMenuItemClicked(sender, eventArgs)
            {
                if (!selectedAppointment)
                    return;
                
                sender.hide();
                
                var clickedItem = eventArgs.get_item();
                var text = clickedItem.get_text();
                var scheduler = $find("<%= radScheduler1.ClientID %>");
                
                if (text == 'Xóa')// && selectedAppointment.get_allowEdit())
                {
                    scheduler.deleteAppointment(selectedAppointment, true);
                }
                else if (text == 'Sửa')// && selectedAppointment.get_allowDelete())
                {
                    scheduler.showAdvancedEditForm(selectedAppointment);
                }
            }
            
            //Called when the user right-clicks empty time slot
            function timeSlotContextMenu(sender, eventArgs)
            {
                var menu = $find("<%= SchedulerTimeSlotContextMenu.ClientID %>");
                contextMenuSlot = eventArgs.get_targetSlot();
                menu.show(eventArgs.get_domEvent());
            }
            
            //Called when the user clicks an item from the time slot context menu
            function timeSlotContextMenuItemClicked(sender, eventArgs)
            {
                sender.hide();
                
                var text = eventArgs.get_item().get_text();
                var scheduler = $find("<%= radScheduler1.ClientID %>");
                
                scheduler.showInsertFormAt(contextMenuSlot);
            }
            
        </script>

    </telerik:RadScriptBlock>
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radCalendarSelectedDate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radScheduler1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="PanelBar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="PanelBar" />
                    <telerik:AjaxUpdatedControl ControlID="radScheduler1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="radScheduler1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radScheduler1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <table width="100%">
        <tr>
            <td valign="top">
    <div class="w220 pd05">
        <div class="pb10">
            <telerik:RadCalendar runat="server" ID="radCalendarSelectedDate" AutoPostBack="true"
                EnableMultiSelect="false" DayNameFormat="FirstTwoLetters" EnableNavigation="true"
                EnableMonthYearFastNavigation="false" OnSelectionChanged="radCalendarSelectedDate_SelectionChanged">
            </telerik:RadCalendar>
        </div>
        <telerik:RadPanelBar runat="server" ID="PanelBar" Width="220px">
            <Items>
                <telerik:RadPanelItem runat="server" Text="Phòng họp" Expanded="true">
                    <Items>
                        <telerik:RadPanelItem runat="server">
                            <ItemTemplate>
                                <div class="rpCheckBoxPanel">
                                    <asp:CheckBoxList ID="chklRoom" runat="server" AutoPostBack="True" DataSourceID="sdsRoom"
                                        DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="chklRoom_SelectedIndexChanged"
                                        OnDataBound="chklRoom_DataBound">
                                    </asp:CheckBoxList>
                                </div>
                            </ItemTemplate>
                        </telerik:RadPanelItem>
                    </Items>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Sắp xếp" Expanded="true">
                    <Items>
                        <telerik:RadPanelItem runat="server">
                            <ItemTemplate>
                                <div class="rpCheckBoxPanel">
                                    <asp:CheckBox runat="server" Text="Nhóm theo phòng họp" Checked="true" AutoPostBack="true" ID="GroupByRoomCheckBox" OnCheckedChanged="GroupByRoomCheckBox_CheckedChanged" />
                                    <asp:CheckBox runat="server" Text="Nhóm theo ngày" AutoPostBack="true" ID="GroupByDateCheckBox" OnCheckedChanged="GroupByDateCheckBox_CheckedChanged" />
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="&nbsp; Xếp theo: "></asp:Label>
                                    <telerik:RadComboBox runat="Server" ID="GroupingDirectionComboBox" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="GroupingDirectionComboBox_SelectedIndexChanged">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Chiều dọc" Value="Horizontal" />
                                            <telerik:RadComboBoxItem Text="Chiều ngang" Value="Vertical" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                            </ItemTemplate>
                        </telerik:RadPanelItem>
                    </Items>
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelBar>
    </div>
            </td>
            <td valign="top">
    <div class="pd05">
        <telerik:RadScheduler runat="server" ID="radScheduler1" SelectedDate="2010-02-26"
            TimeZoneOffset="07:00:00" Height="100%" Width="100%" TimelineView-UserSelectable="false"
            FirstDayOfWeek="Monday" LastDayOfWeek="Sunday" AdvancedForm-Modal="true" DataEndField="EndTime"
            DataKeyField="Id" DataRecurrenceField="RecurrenceRule" DataRecurrenceParentKeyField="RecurrenceParentId"
            DataStartField="StartTime" DataSubjectField="Subject" Culture="Vietnamese (Vietnam)"
            OnClientAppointmentContextMenu="appointmentContextMenu" OnClientTimeSlotContextMenu="timeSlotContextMenu"
            ValidationGroup="" HoursPanelTimeFormat="htt" EditFormDateFormat="dd/MM/yyyy" DataSourceID="sdsRoomBooking" 
            SelectedView="WeekView" OverflowBehavior="Expand"
            OnAppointmentDataBound="radScheduler1_AppointmentDataBound" 
            OnAppointmentDelete="radScheduler1_AppointmentDelete" 
            OnAppointmentInsert="radScheduler1_AppointmentInsert" 
            OnAppointmentUpdate="radScheduler1_AppointmentUpdate" GroupBy="Phòng họp" ShowAllDayRow="False">
            <Localization AdvancedAllDayEvent="Cả ng&#224;y" />
            <AdvancedForm DateFormat="dd/MM/yyyy" Modal="True" TimeFormat="h:mm tt" />
            <TimelineView UserSelectable="False" />
            <ResourceTypes>
                <telerik:ResourceType DataSourceID="sdsRoom" ForeignKeyField="RoomId"
                    KeyField="Id" Name="Ph&#242;ng họp" TextField="Name" />
            </ResourceTypes>
            <ResourceStyles>
                <telerik:ResourceStyleMapping Type="Ph&#242;ng họp" ApplyCssClass="rsCategoryBlue" Key="1" Text="" />
                <telerik:ResourceStyleMapping Type="Ph&#242;ng họp" ApplyCssClass="rsCategoryGreen" Key="2" Text="" />
                <telerik:ResourceStyleMapping Type="Ph&#242;ng họp" ApplyCssClass="rsCategoryOrange" Key="3" Text="" />
                <telerik:ResourceStyleMapping Type="Ph&#242;ng họp" ApplyCssClass="rsCategoryRed" Key="4" Text="" />
                <telerik:ResourceStyleMapping Type="Ph&#242;ng họp" ApplyCssClass="rsCategoryYellow" Key="5" Text="" />
            </ResourceStyles>
        </telerik:RadScheduler>
    </div>
            </td>
        </tr>
    </table>
    <div>
        <telerik:RadContextMenu runat="server" ID="SchedulerAppointmentContextMenu" OnClientItemClicked="appointmentContextMenuItemClicked">
            <Items>
                <telerik:RadMenuItem Text="Sửa" />
                <telerik:RadMenuItem Text="Xóa" ImageUrl="~/Images/delete.gif" />
            </Items>
        </telerik:RadContextMenu>
        <telerik:RadContextMenu runat="server" ID="SchedulerTimeSlotContextMenu" OnClientItemClicked="timeSlotContextMenuItemClicked">
            <CollapseAnimation Type="none" />
            <Items>
                <telerik:RadMenuItem Text="Đặt phòng họp" ImageUrl="~/Images/SmallIcon/21.png" />
            </Items>
        </telerik:RadContextMenu>
    </div>
    <div>
        <asp:SqlDataSource ID="sdsRoomBooking" runat="server"
            ProviderName="System.Data.SqlClient"
            SelectCommand="SELECT * FROM [RoomBooking] WHERE ISNULL(flag, '') = '' " 
            InsertCommand="INSERT INTO [RoomBooking] ([Subject], [StartTime], [EndTime], [RecurrenceRule], [RecurrenceParentId], [RoomId], [Created_At], [Created_By], [Last_Modified_At], [Last_Modified_By]) VALUES (@Subject, @StartTime, @EndTime, @RecurrenceRule, @RecurrenceParentId, @RoomId, getdate(), @Created_By, getdate(), @Last_Modified_By)"
            UpdateCommand="UPDATE [RoomBooking] SET [Subject] = @Subject, [StartTime] = @StartTime, [EndTime] = @EndTime, [RecurrenceRule] = @RecurrenceRule, [RecurrenceParentId] = @RecurrenceParentId, [RoomId] = @RoomId, [Last_Modified_At] = getdate(), [Last_Modified_By] = @Last_Modified_By WHERE (Id = @Id)"
            DeleteCommand="UPDATE [RoomBooking] SET flag='D', [Last_Modified_At] = getdate(), [Last_Modified_By] = @Last_Modified_By WHERE [Id] = @Id">
            <SelectParameters>
                <asp:Parameter Name="Created_By" Type="Int32" DefaultValue="0" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Created_By" Type="Int32" DefaultValue="0" />
                <asp:Parameter Name="Last_Modified_By" Type="Int32" DefaultValue="0" />
                <asp:Parameter Name="Subject" Type="String" />
                <asp:Parameter Name="StartTime" Type="DateTime" />
                <asp:Parameter Name="EndTime" Type="DateTime" />
                <asp:Parameter Name="RecurrenceRule" Type="String" />
                <asp:Parameter Name="RecurrenceParentId" Type="Int32" />
                <asp:Parameter Name="RoomId" Type="Int32" DefaultValue="1" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Last_Modified_By" Type="Int32" DefaultValue="0" />
                <asp:Parameter Name="Id" Type="Int32" />
                <asp:Parameter Name="Subject" Type="String" />
                <asp:Parameter Name="StartTime" Type="DateTime" />
                <asp:Parameter Name="EndTime" Type="DateTime" />
                <asp:Parameter Name="RecurrenceRule" Type="String" />
                <asp:Parameter Name="RecurrenceParentId" Type="Int32" />
                <asp:Parameter Name="RoomId" Type="Int32" DefaultValue="1" />
            </UpdateParameters>
            <DeleteParameters>
                <asp:Parameter Name="Last_Modified_By" Type="Int32" DefaultValue="0" />
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsRoom" runat="server" ProviderName="System.Data.SqlClient"
            SelectCommand="SELECT * FROM [Room]"></asp:SqlDataSource>
    </div>
    <br class="clear" />
</asp:Content>
