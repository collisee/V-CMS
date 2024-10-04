<%@ Page MasterPageFile="~/Default.Master"Language="C#" AutoEventWireup="true" CodeBehind="Logging.aspx.cs" Inherits="VietNamNet.Framework.Administrator.Logging" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
	<telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radCmbLogLevel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radGridDefault" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="radCmbUser">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radGridDefault" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnApply">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radGridDefault" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="radGridDefault">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radGridDefault" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
	<telerik:RadAjaxLoadingPanel runat="server" ID="radAjaxLoadingPanel1">
	</telerik:RadAjaxLoadingPanel>
	<div>
        <div class="fleft pd05 pb00">
            <telerik:RadComboBox ID="radCmbLogLevel" runat="server" AutoPostBack="True" Style="float:left;" OnSelectedIndexChanged="radCmbLogLevel_SelectedIndexChanged">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="Tất cả" Value="-1" />
                    <telerik:RadComboBoxItem runat="server" Text="1 - Info" Value="1" />
                    <telerik:RadComboBoxItem runat="server" Text="2 - Error" Value="2" />
                    <telerik:RadComboBoxItem runat="server" Text="3 - System" Value="3" />
                </Items>
            </telerik:RadComboBox>
            <telerik:RadComboBox ID="radCmbUser" runat="server" DataTextField="FullName" DataValueField="Id" AutoPostBack="True" Style="float:left;" OnSelectedIndexChanged="radCmbUser_SelectedIndexChanged">
            </telerik:RadComboBox>
        </div>
        <div class="fright pd05 pb00">
            <telerik:RadDatePicker ID="radDpkLoggingFromDate" runat="server" Culture="Vietnamese (Vietnam)" Width="90px" Style="float:left;">
                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                </Calendar>
                <DatePopupButton HoverImageUrl="" ImageUrl="" />
            </telerik:RadDatePicker>
            <asp:Label ID="lblReportToDate" runat="server" Text=" ->&nbsp; " Style="float:left;"></asp:Label>
            <telerik:RadDatePicker ID="radDpkLoggingToDate" runat="server" Culture="Vietnamese (Vietnam)" Width="90px" Style="float:left;">
                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                </Calendar>
                <DatePopupButton HoverImageUrl="" ImageUrl="" />
            </telerik:RadDatePicker>
            <asp:Button ID="btnApply" runat="server" Text="Thay đổi" OnClick="btnApply_Click" />
        </div>
        <br class="clear" />
	</div>
    <div class="pd05 pb00">
        <telerik:RadToolBar runat="Server" ID="radRadToolBarExport" OnButtonClick="radRadToolBarExport_ButtonClick" Width="100%">
            <Items>
                <telerik:RadToolBarDropDown runat="server" Text="Export...">
                    <Buttons>
                        <telerik:RadToolBarButton runat="server" CommandName="ExportToDoc" Text="to Doc">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" CommandName="ExportToExcel" Text="to Excel">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" CommandName="ExportToPdf" Text="to Pdf">
                        </telerik:RadToolBarButton>
                    </Buttons>
                </telerik:RadToolBarDropDown>
            </Items>
        </telerik:RadToolBar>
	</div>
    <div class="pd05">
        <telerik:RadGrid ID="radGridDefault" runat="server" AutoGenerateColumns="False"
            GridLines="None" OnItemCommand="radGridDefault_ItemCommand"
            Style="outline: none" OnItemDataBound="radGridDefault_ItemDataBound" OnNeedDataSource="radGridDefault_NeedDataSource" AllowPaging="True" AllowSorting="True">
            <MasterTableView ClientDataKeyNames="Id" DataKeyNames="Id"
            GroupLoadMode="Client" NoMasterRecordsText="Kh&#244;ng c&#243; log n&#224;o.">
                <Columns>
                    <telerik:GridBoundColumn DataField="LogTime" HeaderText="Thời gian" UniqueName="LogTime" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}">
                        <HeaderStyle Width="150px" Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LogLevel" HeaderText="Level" UniqueName="LogLevel">
                        <HeaderStyle Width="50px" Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="IP" HeaderText="IP" UniqueName="IP">
                        <HeaderStyle Width="100px" Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UId" HeaderText="UserId" UniqueName="UId">
                        <HeaderStyle Width="50px" Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UserFullName" HeaderText="Họ t&#234;n" UniqueName="UserFullName">
                        <HeaderStyle Width="150px" Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Action" HeaderText="H&#224;nh động" UniqueName="Action">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Detail" HeaderText="Chi tiết" UniqueName="Detail">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                </Columns>
                <SortExpressions>
                    <telerik:GridSortExpression FieldName="LogTime" SortOrder="Descending" />
                </SortExpressions>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="True">
                <Resizing AllowColumnResize="True" />
            </ClientSettings>
            <FilterMenu EnableTheming="True">
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </FilterMenu>
            <ExportSettings ExportOnlyData="True" FileName="Logging" IgnorePaging="True" OpenInNewWindow="True">
                <Excel Format="ExcelML" />
            </ExportSettings>
            <GroupingSettings CollapseTooltip="Đ&#243;ng" ExpandTooltip="Mở" GroupSplitFormat="" />
            <PagerStyle FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang tiếp"
                NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
        </telerik:RadGrid>
	</div>
</asp:Content>
