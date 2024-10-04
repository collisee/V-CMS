<%@ Page MasterPageFile="~/Default.Master"  Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VietNamNet.AddOn.VCard._Default" EnableEventValidation="false" %>

<asp:Content ContentPlaceHolderID="cplhContainer" ID="Content1" runat="server">
    
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server" />
     <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="PanelBar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="PanelBar" />
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                    <telerik:AjaxUpdatedControl ControlID="grdView" />
                    <telerik:AjaxUpdatedControl ControlID="txtCheckedGroupID" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmdRefesh">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                    <telerik:AjaxUpdatedControl ControlID="grdView" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="mnuGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptGroup" />
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                    <telerik:AjaxUpdatedControl ControlID="mnuGroup" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdView" />
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" /> 
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
     </telerik:RadAjaxManager>
     
    <telerik:RadScriptBlock runat="server" ID="RadScriptBlock2">

        <script type="text/javascript">

			var toolbar;
			var searchButton;

			 

			function onKeyPress(sender, args) {
				if (args.get_keyCode() == 13) {
					args.get_domEvent().stopPropagation();
					args.get_domEvent().preventDefault();
					searchButton.click();
					return;
				}
			}
            
            function ViewVCardDetail(vid)
            {
                var oWnd = radopen("PopupVCardDetail.aspx?vcardid=" + vid);
                oWnd.setSize(640, 330);
            }
            function ViewVCardEdit(vid)
            {
                var oWnd = radopen("PopupVCardEdit.aspx?vcardid=" + vid);
                oWnd.setSize(640, 350);
                oWnd.add_close(closeRadWindow);
            }
            function ImportCsv()
            {
                var oWnd = radopen("PopupImportCsv.aspx");
                oWnd.setSize(780, 500);
                oWnd.add_close(closeRadWindow);
            }
            function closeRadWindow(wnd, args)
            {
                var refresh = $get('<%=cmdRefesh.ClientID %>');
                if (refresh) refresh.click();                
            }
        </script>

    </telerik:RadScriptBlock>
    <telerik:RadWindowManager ID="radWindowManager" runat="server" Behaviors="Maximize,Move,Reload,Resize,Close"
        VisibleStatusbar="False">
    </telerik:RadWindowManager>
    


<table width="100%">
    <tr>
        <td valign="top">
        
        
        
  <div class="w220 pd05">
    <div class="pb10">
        
        <telerik:RadPanelBar runat="server" ID="PanelBar" Width="230px">
            <Items>
                <telerik:RadPanelItem runat="server"  TabIndex="0" Text="Lọc" Expanded="true">
                    <Items>
                        <telerik:RadPanelItem runat="server">
                            <ItemTemplate>
                                <div class="rpCheckBoxPanel">
                                    <table>
                                        <tr>
                                            <td><label>Tên:</label></td>
                                            <td><telerik:RadTextBox ID="txtFilterName" runat="server" AutoPostBack="true" OnTextChanged="OnFilterChanged" /></td>
                                        </tr>
                                        <tr>
                                            <td><label>Cty/Tchức:</label></td>
                                            <td><telerik:RadTextBox ID="txtFilterOrgName" runat="server"  AutoPostBack="true" OnTextChanged="OnFilterChanged"/></td>
                                        </tr>
                                        <tr>
                                            <td><label>Chức vụ:</label></td>
                                            <td><telerik:RadTextBox ID="txtFilterTitle" runat="server"  AutoPostBack="true" OnTextChanged="OnFilterChanged"/></td>
                                        </tr>
                                        <tr>
                                            <td><label>Email:</label></td>
                                            <td><telerik:RadTextBox ID="txtFilterEmail" runat="server"  AutoPostBack="true" OnTextChanged="OnFilterChanged"/></td>
                                        </tr>
                                    </table>             
                                </div>
                            </ItemTemplate>
                        </telerik:RadPanelItem>
                    </Items>
                </telerik:RadPanelItem>
            
                <telerik:RadPanelItem runat="server" TabIndex="1"  Text="Phạm vi hiển thị" Expanded="true" >
                    <Items>
                        <telerik:RadPanelItem runat="server">
                            <ItemTemplate>
                                <div class="rpCheckBoxPanel">
                                    <asp:CheckBox ID="chkScopePrivate"  Text="Cá nhân" runat="server" Checked="true" OnCheckedChanged="OnFilterChanged" AutoPostBack="true" /><br />
                                    <asp:CheckBox ID="chkScopePublic" Text="Công cộng" runat="server" Checked="true" OnCheckedChanged="OnFilterChanged" AutoPostBack="true" />
                                </div>
                            </ItemTemplate>
                        </telerik:RadPanelItem>
                    </Items>
                </telerik:RadPanelItem>
                
                <telerik:RadPanelItem Expanded="true" runat="server" TabIndex="2"  Text="Nhóm VCard">
                    <Items>
                        <telerik:RadPanelItem runat="server">
                            <ItemTemplate>
                                <div class="rpCheckBoxPanel"> 
                                    <asp:LinkButton ID="cmdAddNewRecord" runat="server" OnClick="CmdAddNewRecordClick" Visible="false">Thêm một nhóm mới</asp:LinkButton>
                                    <asp:CheckBox ID="chkAll" runat="server"    
                                        ToolTip='Toàn bộ các nhóm'                   
                                        Text='Toàn bộ các nhóm' 
                                        Checked="true"   OnCheckedChanged="OnFilterChanged" AutoPostBack="true" />
            <telerik:RadGrid ID="rptGroup" runat="server" Width="100%"
                ShowHeader="false" ShowFooter="false" ShowStatusBar="false"   GridLines="None"  
                AllowAutomaticDeletes="true" AllowAutomaticInserts="true" AutoGenerateColumns="false" AllowAutomaticUpdates="true" 
                OnPreRender="rptGroup_PreRender" OnItemCommand="RptGroupItemCommand">
                <MasterTableView AllowSorting="False" PageSize="10" AllowPaging="True" Width="100%" 
                        ClientDataKeyNames="GroupId" DataKeyNames="GroupId"  EditMode="PopUp"
                        NoMasterRecordsText=""> 
                   <Columns>
                        <telerik:GridTemplateColumn> 
                            <ItemTemplate>
                                <asp:CheckBox ID="chkGroup" runat="server"    
                                        ToolTip='<%# DataBinder.Eval(Container.DataItem,"Description") %>'                   
                                        Text='<%# DataBinder.Eval(Container.DataItem,"GroupName") %>' 
                                        Checked="true"   OnCheckedChanged="OnFilterChanged" AutoPostBack="true" />
                                <asp:HiddenField ID="txtGroupID" runat="server"  Value='<%# DataBinder.Eval(Container.DataItem,"GroupId") %>'/>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                         
                    </Columns>
                    <EditFormSettings  EditFormType="Template"  CaptionFormatString="Thông tin nhóm" PopUpSettings-Modal="true" >
                    <FormTemplate>                        
                             <table> 
                                <tr>
                                    <td>Tên nhóm</td>
                                    <td><telerik:RadTextBox ID="txtGroupName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"GroupName") %>'/></td>
                                </tr>
                                <tr>
                                    <td>Mô tả:</td>
                                    <td><telerik:RadTextBox ID="txtDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'/></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="cmdGroupUpdate" CommandName="Update" runat="server" Text="Cập nhật" />
                                        <asp:Button ID="cmdGroupCancel" CommandName="Cancel" runat="server" Text="Hủy bỏ" />
                                        <telerik:RadTextBox ID="txtGroupId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"GroupId") %>' Visible="false"/>
                                    </td>
                                </tr>
                             </table>
                    </FormTemplate>
                </EditFormSettings>
                </MasterTableView>
                <ClientSettings>
                    <ClientEvents OnRowContextMenu="showGroupMenu"></ClientEvents>
                    <Selecting AllowRowSelect="true" />
                </ClientSettings>
            </telerik:RadGrid>
            
                                
                                <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" /> 
                                <input type="hidden" id="radGridClickedRowId" name="radGridClickedRowId" /> 
         

                                </div>
                            </ItemTemplate>
                        </telerik:RadPanelItem>
                    </Items>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Chức năng" Expanded="true">
                    <Items>
                        <telerik:RadPanelItem runat="server">
                            <ItemTemplate>
                                <div class="rpCheckBoxPanel">
                                    <asp:LinkButton ID="cmdReset" runat="server" OnClick="CmdResetClick" style="padding-left:10px">Làm mới bộ lọc</asp:LinkButton><br />
                                    <a href="#" onclick="ViewVCardEdit(null);"  style="padding-left:10px">Thêm mới VCard</a><br />
                                    <%--&nbsp;&nbsp;<a>Gửi VCard</a><br />--%>
                                    <a href="ExportVCard.aspx?vcardid=MyVCard" style="padding-left:10px">VCard của tôi</a><br />                                    
                                    <a href="#" onclick="ImportCsv();" style="padding-left:10px">Tải VCard từ file</a>
                                </div>
                            </ItemTemplate>
                        </telerik:RadPanelItem>
                    </Items>
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelBar>
        <div style="display:none"><asp:Button ID="cmdRefesh" runat="server" Text="Button" OnClick="OnFilterChanged" /></div>
    </div>    
  </div> 
        
            <asp:Label ID="lblMessage" runat="server" ForeColor="red" Text=""></asp:Label>
        
        </td>
        <td valign="top">


<div class="pd05">
                <telerik:RadGrid ID="grdView" runat="server" AutoGenerateColumns="False"
                        GridLines="None"  Style="outline: none"  AllowSorting="False" 
                        AllowPaging="true"    OnPageIndexChanged="GrdViewPageIndexChanged"  
                        OnPageSizeChanged="GrdViewPageSizeChanged"
                        OnItemCommand="GrdViewItemCommand" 
                         >
                <MasterTableView ClientDataKeyNames="ContactId" DataKeyNames="ContactId"  
                        GroupLoadMode="Client"  
                        NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o. ">
                    <Columns>
                        
                        <telerik:GridTemplateColumn HeaderText="Họ tên<br>   (Chức danh)" >
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem,"Fullname") %>
                                <%# Convert.IsDBNull(DataBinder.Eval(Container.DataItem, "OrgTitle")) ? "" : DataBinder.Eval(Container.DataItem, "OrgTitle") == "" ? "": "<br />(" + DataBinder.Eval(Container.DataItem, "OrgTitle") + ")"%>
                                <%# Convert.IsDBNull(DataBinder.Eval(Container.DataItem, "GroupName")) ? "" : "<br />Nhóm: " + DataBinder.Eval(Container.DataItem, "GroupName").ToString()%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Công ty / tổ chức" >
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem,"OrgName") %><br />
                               
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Phone" ItemStyle-Width="110" >
                            <ItemTemplate>
                                Phone: <%# DataBinder.Eval(Container.DataItem, "OrgPhone")%><br />
                                Mobile: <%# DataBinder.Eval(Container.DataItem, "OrgMobile")%><br />
                                Fax: <%# DataBinder.Eval(Container.DataItem, "OrgFax")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Email" >
                            <ItemTemplate>
                                <a href="mailto: <%# DataBinder.Eval(Container.DataItem,"OrgEmail1") %>;" ><%# DataBinder.Eval(Container.DataItem,"OrgEmail1") %></a>
                                <br />
                                <a href="mailto: <%# DataBinder.Eval(Container.DataItem,"OrgEmail2") %>;" ><%# DataBinder.Eval(Container.DataItem,"OrgEmail2") %></a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Chức năng" ItemStyle-Width="60">
                             <ItemTemplate>
                                <a href="#" onclick="ViewVCardDetail('<%# DataBinder.Eval(Container.DataItem, "ContactId")%>')">Xem</a>
                                <a href="ExportVCard.aspx?vcardid=<%# DataBinder.Eval(Container.DataItem, "ContactId")%>">Export</a>
                                <asp:TextBox runat="server" ID="txtContactId" Text='<%# DataBinder.Eval(Container.DataItem, "ContactId")%>' Visible="false"/>
                                <asp:Panel  runat="server" id="allowEdit"
                                            Visible='<%# IsEditable(int.Parse(DataBinder.Eval(Container.DataItem, "Owner").ToString()))%>'>                                    
                                    <a href="#" onclick="ViewVCardEdit('<%# DataBinder.Eval(Container.DataItem, "ContactId")%>')">Sửa</a>
                                    <asp:LinkButton runat="server" id="cmdDelete" Text="Xóa" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ContactId")%>' OnClientClick="return confirmDelete();"/>
                                 </asp:Panel> 
                             </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns> 
                </MasterTableView>  
                 <ClientSettings  AllowColumnsReorder="true" ReorderColumnsOnClient="true" >
                    <Resizing  EnableRealTimeResize="True" AllowColumnResize="true" ></Resizing>
                 </ClientSettings>
                <PagerStyle Mode="NextPrevAndNumeric" Position="TopAndBottom" />
            </telerik:RadGrid>
</div>


        </td>
    </tr>
</table>

    <telerik:RadTextBox ID="txtCheckedGroupID" runat="server" Visible="false"  ></telerik:RadTextBox>
    
    <div>
    <!-- Groups Menus start-->  
    <telerik:RadScriptBlock runat="server" ID="RadScriptBlock6">

            <script type="text/javascript">
            function showGroupMenu2(){
                var menu = $find("<%=mnuGroup.ClientID %>"); 
                menu.show();
            }
            function showGroupMenu(sender, eventArgs)
            { 
                var menu = $find("<%=mnuGroup.ClientID %>"); 
                var evt = eventArgs.get_domEvent();
                
                if(evt.target.tagName == "INPUT" || evt.target.tagName == "A")
                {
                  return;
                }
                
                var id = eventArgs.getDataKeyValue('GroupId');
                document.getElementById("radGridClickedRowId").value = id;
                var index = eventArgs.get_itemIndexHierarchical();
                document.getElementById("radGridClickedRowIndex").value = index;
                
               // sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);
                
                menu.show(evt);
                
                evt.cancelBubble = true;
                evt.returnValue = false;

                if (evt.stopPropagation)
                {
                   evt.stopPropagation();
                   evt.preventDefault();
                }
            }            
	function onMenuClicking(sender, eventArgs) 
	{ 
		var item = eventArgs.get_item().get_value(); 
		if (item=='Delete')	{ 
	        if (confirmDelete()) {
	            
	        }else{
	             eventArgs.set_cancel(true);
	        }		 
		}
	} 
            
            </script>

        </telerik:RadScriptBlock>  
        <telerik:RadContextMenu ID="mnuGroup" runat="server"  OnItemClick="MnuGroupItemClick" OnClientItemClicking="onMenuClicking"  >
            <Items>
                <telerik:RadMenuItem Text="Thêm mới" Value="Add" />
                <telerik:RadMenuItem Text="Sửa"  Value="Edit"/>
                <telerik:RadMenuItem Text="Xóa"  Value="Delete"/>
            </Items>
        </telerik:RadContextMenu>
        <!-- Groups Menus end-->
    
    </div>
    
</asp:Content>
