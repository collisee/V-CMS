<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="PopupSurveyListApproved.aspx.cs" Inherits="VietNamNet.AddOn.Survey.PopupSurveyListApproved" Title="C?p nh?t thông tin Bình ch?n" ValidateRequest="false" %>
<%@ Register Src="UserControls/SurveyPublishEdit.ascx" TagName="SurveyPublishEdit"    TagPrefix="vnnSurvey" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
<div>
<telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server" />
     <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>              
            <telerik:AjaxSetting AjaxControlID="radToolBarDefault">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />  
                     <telerik:AjaxUpdatedControl ControlID="grdView"/>  
                </UpdatedControls>
            </telerik:AjaxSetting> 
        </AjaxSettings>
     </telerik:RadAjaxManager>
<telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" RelativeTo="Element"
            Position="MiddleRight" AutoTooltipify="true" ContentScrolling="Default"
            Width="200" Height="10">
        </telerik:RadToolTipManager>
            
</div>
    <telerik:RadScriptBlock ID="radScriptBlockManager" runat="server">

        <script type="text/javascript">   
           var toolbar;
			var searchButton;

			function pageLoad() {
				toolbar = $find("<%= radToolBarDefault.ClientID %>");
				searchButton = toolbar.findButtonByCommandName("Search");
			} 
            
           function onKeyPress(sender, args) {
				if (args.get_keyCode() == 13) {
					onFilterChange(sender, args);
					return;
				}
			} 
			function onFilterChange(sender, args) { 
					args.get_domEvent().stopPropagation();
					args.get_domEvent().preventDefault();
					searchButton.click();
					return; 
			}  
        </script> 
    </telerik:RadScriptBlock>

     <div class="pd05">
     <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
             <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="RadToolBarDefaultButtonClick" CssClass="panel-search-toolbar">
            <Items>
                
                <telerik:RadToolBarButton IsSeparator="True" runat="server" />
                <telerik:RadToolBarButton Value="searchTextBoxButton" CommandName="searchText" runat="server" >
                    <ItemTemplate>
                        <telerik:RadTextBox runat="server" ID="txtKeyword" EmptyMessage="Tìm kiếm" CssClass="panel-search-textbox"
                            Width="200px"   ><ClientEvents OnKeyPress="onKeyPress" OnValueChanged="onFilterChange" /></telerik:RadTextBox>
                        <label>Kiểu lựa chọn:</label>
                        <telerik:RadComboBox ID="cboOptionTypes" runat="server" OnClientSelectedIndexChanged="onFilterChange" OnClientTextChange="onFilterChange">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Toàn bộ" Value="" />
                                <telerik:RadComboBoxItem runat="server" Text="1 lựa chọn" Value="R" />
                                <telerik:RadComboBoxItem runat="server" Text="Nhiều lựa chọn" Value="C" />                                
                            </Items>                            
                        </telerik:RadComboBox> 
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="T&#236;m kiếm" Value="search" CommandName="Search" runat="server" />
                <telerik:RadToolBarButton ImageUrl="~/Images/SmallIcon/75.png" Value="search" CommandName="Search" runat="server" />
            </Items>
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </telerik:RadToolBar>
        </asp:Panel>
        
        <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
            <asp:Label runat="server" ID="lblMessage" ForeColor="red"></asp:Label>
            
                  <telerik:RadGrid ID="grdView" runat="server" AutoGenerateColumns="False" PageSize="5"
                        GridLines="None"  Style="outline: none"  AllowSorting="False" AllowPaging="true"    
                        OnPageIndexChanged="GrdViewPageIndexChanged"  
                        OnPageSizeChanged="GrdViewPageSizeChanged"
                        OnItemCommand="GrdViewItemCommand" >
                <MasterTableView ClientDataKeyNames="SurveyId" DataKeyNames="SurveyId"  
                        GroupLoadMode="Client"  
                        NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o. ">
                    <Columns>                        
                        <telerik:GridTemplateColumn HeaderText="Câu hỏi lựa chọn"  HeaderStyle-Width="300">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem,"Question") %>
                                <%# Convert.IsDBNull(DataBinder.Eval(Container.DataItem, "Tags")) ? "" : DataBinder.Eval(Container.DataItem, "Tags") == "" ? "" : "<br />(" + DataBinder.Eval(Container.DataItem, "Tags") + ")"%>
                                <br /><i><label>Ngày tạo:</label> <label><%# DataBinder.Eval(Container.DataItem, "CreatedOn")%></label></i>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>  
                        <telerik:GridTemplateColumn HeaderText="Chức năng" HeaderStyle-Width="200">
                             <ItemTemplate>  
                                <a>Sử dụng Bình chọn này</a>
                                <a>Xem chi tiết</a>
                                
                             </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns> 
                </MasterTableView>  
                 <ClientSettings  AllowColumnsReorder="true" ReorderColumnsOnClient="true" >
                    <Resizing  EnableRealTimeResize="True" AllowColumnResize="true"></Resizing>
                 </ClientSettings>
                <PagerStyle Mode="NextPrevAndNumeric" Position="TopAndBottom" />
            </telerik:RadGrid>
          </asp:Panel> 
     </div>
 
    
</asp:Content>
