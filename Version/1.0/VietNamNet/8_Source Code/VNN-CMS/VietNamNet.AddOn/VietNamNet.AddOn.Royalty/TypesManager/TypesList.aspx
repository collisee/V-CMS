<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="TypesList.aspx.cs" Inherits="VietNamNet.AddOn.Royalty.TypesList" Title="Danh mục Loại nhuận bút" ValidateRequest="false" %>
<asp:Content ContentPlaceHolderID="cplhContainer" ID="Content1" runat="server">
<div>
<telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server" />
     <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>             
            <telerik:AjaxSetting AjaxControlID="radToolBarDefault">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />  
                    <telerik:AjaxUpdatedControl ControlID="radGridDefault" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
             <telerik:AjaxSetting AjaxControlID="radGridDefault">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />  
                    <telerik:AjaxUpdatedControl ControlID="radGridDefault" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
        </AjaxSettings>
     </telerik:RadAjaxManager>
        <telerik:RadScriptBlock runat="server" ID="RadScriptBlock2">
            <script type="text/javascript">
            var toolbar;
			var searchButton;

			function pageLoad() {
				toolbar = $find("<%= radToolBarDefault.ClientID %>");
				searchButton = toolbar.findButtonByCommandName("Search");
			}
            function RowDblClick(sender, eventArgs)
                {
                    ViewTypeEdit( eventArgs.getDataKeyValue('Type_Id') );
                }
            function onFilterChange(sender, args) { 
                if(args && args.get_domEvent()){
					args.get_domEvent().stopPropagation();
					args.get_domEvent().preventDefault();
					
					searchButton.click();} 
			} 
            function ViewTypeEdit(id){
                    var oWnd = radopen("TypesEdit.aspx?typeid=" + id);
                    oWnd.setSize(550, 300);
                    oWnd.add_close(closeRadWindow);
                }
                
            
            function closeRadWindow(wnd, args){
                if (!args) return;     
                var a=args.get_argument();           
                if (!a) return;     
                var combo = toolbar.findButtonByCommandName("searchText").findControl("cboParent");
                combo.findItemByValue(a.id).select();
                                  
                searchButton.click();
            }
            
            function radToolBarDefault_ClientButtonClicking(sender, eventArgs)
            {
                var cmd = eventArgs.get_item().get_commandName();
                switch (cmd)
                {
                    case 'Update':
                        ViewTypeEdit();    
                        eventArgs.set_cancel(true);                 
                        break;
                    default:
                        break;
                };
            }
            </script>
        </telerik:RadScriptBlock>
        
<telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" RelativeTo="Element"
            Position="MiddleRight" AutoTooltipify="true" ContentScrolling="Default"
            Width="200" Height="10">
        </telerik:RadToolTipManager>

    <telerik:RadWindowManager ID="radWindowManager" runat="server" Behaviors="Maximize,Move,Reload,Resize"
        VisibleStatusbar="False">
    </telerik:RadWindowManager>
            
</div>
    <div class="pd05">
     <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" 
                                OnClientButtonClicking="radToolBarDefault_ClientButtonClicking" 
                                OnButtonClick="RadToolBarDefaultButtonClick">
                <Items>  
                    <telerik:RadToolBarButton runat="server"  
                                    CommandName="Update" Value="Update"
                                    Text="Thêm mới (N)" AccessKey="N">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Value="searchTextBoxButton" CommandName="searchText" runat="server" >
                        <ItemTemplate>
                            <label title="Nhóm loại tin">Nhóm:</label>
                            <telerik:RadComboBox ID="cboParent" runat="server" OnClientSelectedIndexChanged="onFilterChange" OnClientTextChange="onFilterChange"></telerik:RadComboBox>
                        </ItemTemplate>
                    </telerik:RadToolBarButton>      
                <telerik:RadToolBarButton Text="T&#236;m kiếm" Value="search" CommandName="Search" runat="server" />             
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        
        
    <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
                <span id="OutPut" style="font-weight: bold; color: navy;"></span>
        <telerik:RadGrid ID="radGridDefault" runat="server" AutoGenerateColumns="False" 
                        GridLines="None"  Style="outline: none"  AllowSorting="False" AllowPaging="true"    
                        OnPageIndexChanged="GrdViewPageIndexChanged"   
                        OnItemCommand="GrdViewItemCommand" 
                        OnItemDataBound="radGridDefault_ItemDataBound">
                <MasterTableView ClientDataKeyNames="Type_Id" DataKeyNames="Type_Id"  
                        GroupLoadMode="Client"  
                        NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o. ">
                    <Columns>    
                        <telerik:GridTemplateColumn HeaderText="Kiểu lựa chọn" >
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Title")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Mô tả"  >
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Description")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Giá thấp nhất" HeaderStyle-Width="100" ItemStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "MIN_VAL")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Giá cao nhất" HeaderStyle-Width="100" ItemStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "MAX_VAL")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Chức năng" HeaderStyle-Width="100" >
                            <ItemTemplate>
                                <a href="#" onclick="ViewTypeEdit('<%# DataBinder.Eval(Container.DataItem, "Type_Id")%>')" title="Sửa"> <img width="16" src="/Images/LargeIcon/document_edit.png"  > </a>
                                    <asp:LinkButton ID="cmdDelete" runat="server" ToolTip="Xóa" Enabled="True"  
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Type_Id")%>' CommandName="Delete" OnClientClick="return confirmDelete();" > <img width="16" src="/Images/LargeIcon/document_delete.png"  > </asp:LinkButton>  
                             
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        
                    </Columns>
                    <GroupByExpressions>
                    <telerik:GridGroupByExpression>
                        <GroupByFields>
                            <telerik:GridGroupByField  FieldName="Parent_Id" />
                        </GroupByFields>
                        <SelectFields>
                            <telerik:GridGroupByField   FieldName="Parent_Title" HeaderText=" " />
                        </SelectFields>
                    </telerik:GridGroupByExpression>
                </GroupByExpressions>
                </MasterTableView>
                <GroupingSettings CollapseTooltip="Đ&#243;ng" ExpandTooltip="Mở" GroupSplitFormat="" />
                <ClientSettings  AllowColumnsReorder="true" ReorderColumnsOnClient="true" >
                    <Resizing  EnableRealTimeResize="True" AllowColumnResize="true"></Resizing>
                    <ClientEvents OnRowDblClick="RowDblClick"  />
                 </ClientSettings> 
                <PagerStyle Mode="NextPrevAndNumeric" Position="TopAndBottom"  FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang tiếp"
                    NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
         </telerik:RadGrid>    
         
         
            <div style="display:none"><asp:Button ID="cmdRefesh" runat="server" Text="Button" OnClick="OnFilterChanged" /></div>
            <asp:Label runat="server" ID="lblMessage" ForeColor="red"></asp:Label>
    </asp:Panel>
 </div>
    
</asp:Content>
