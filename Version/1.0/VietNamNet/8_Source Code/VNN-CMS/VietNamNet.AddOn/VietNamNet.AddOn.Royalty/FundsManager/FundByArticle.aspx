<%@ Page Language="C#" MasterPageFile="~/Popup.Master" AutoEventWireup="true" CodeBehind="FundByArticle.aspx.cs" Inherits="VietNamNet.AddOn.Royalty.FundsManager.FundByArticle" Title="Thông tin Chấm Nhuận bút" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplhContainer" runat="server">
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
                    ViewTypeEdit( eventArgs.getDataKeyValue('Fund_Id') );
                }
            function onFilterChange(sender, args) { 
					args.get_domEvent().stopPropagation();
					args.get_domEvent().preventDefault();
					searchButton.click();
					return; 
			} 
            function ViewTypeEdit(id){
                    var oWnd = radopen("FundByArticle.aspx?DocId=" + id);
                    oWnd.setSize(550, 300);
                    oWnd.add_close(closeRadWindow);
                }
                
              function GetRadWindow()
            {
               var oWindow = null;
               if (window.radWindow) oWindow = window.radWindow;
               else if (window.frameElement && window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
               return oWindow;
            }

            function closeWin()
            {
                var oWnd = GetRadWindow();
                if (oWnd) oWnd.close();
                else window.close();
            }
            function radToolBarDefault_ClientButtonClicking(sender, eventArgs)
            {
                var cmd = eventArgs.get_item().get_commandName();
                switch (cmd)
                {
                    case 'Cancel':
                        closeWin();
                        break;
                    default:
                        break;
                };
            }
            </script>
        </telerik:RadScriptBlock>
        
<telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" RelativeTo="Element"
            Position="BottomCenter" AutoTooltipify="true" ContentScrolling="Default"
            Width="200" Height="10">
        </telerik:RadToolTipManager>

    <telerik:RadWindowManager ID="radWindowManager" runat="server" Behaviors="Maximize,Move,Reload,Resize,Close"
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
                                    CommandName="AddNew" Value="AddNew"
                                    Text="Chấm mới" AccessKey="N" />
                   <telerik:RadToolBarButton runat="server" Visible="false"
                                    CommandName="AddPlus" Value="AddPlus"
                                    Text="Điều chỉnh thêm" AccessKey="N"/>
                   <telerik:RadToolBarButton runat="server"  Visible="false"
                                    CommandName="AddSub" Value="AddSub"
                                    Text="Điều chỉnh bớt" AccessKey="N"/>
                   <telerik:RadToolBarButton runat="server"  Visible="false"
                                    CommandName="AddMore" Value="AddMore"
                                    Text="Bổ sung" AccessKey="N"/> 
                   <telerik:RadToolBarButton runat="server" 
                                    CommandName="Cancel" Value="Cancel"
                                    Text="Đóng (C)" AccessKey="C"/>
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        
        
    <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
                <span id="OutPut" style="font-weight: bold; color: navy;"></span>
         
           <fieldset> 
                            <legend>Tin bài: <asp:Literal runat="server" ID="txtName" /> </legend>
            <asp:Literal runat="server" ID="lblArticleInfo" /> 
            
           <telerik:RadPanelBar ID="RadPanelBar1" runat="server"  Width="100%" >
            <Items>
                <telerik:RadPanelItem  Text="Lịch sử bài viết" runat="server" Expanded="false">
                    <Items>
                        <telerik:RadPanelItem runat="server" Text="Feel comfortable gambling with Golden"  >
                        </telerik:RadPanelItem>
                    </Items>
                </telerik:RadPanelItem> 
            </Items>
            <CollapseAnimation Duration="100" Type="None" />
            <ExpandAnimation Duration="100" Type="None" />
        </telerik:RadPanelBar>
             
                 <asp:Literal runat="server" ID="lblArticleHistory" />
            <telerik:RadTextBox  ID="txtArticleId" runat="server" Visible="false"   />
            </fieldset>
         <p>      
        <telerik:RadGrid ID="radGridDefault" runat="server" AutoGenerateColumns="False" 
                        GridLines="None"  Style="outline: none"  AllowSorting="False" AllowPaging="true"    
                        OnPageIndexChanged="GrdViewPageIndexChanged"   
                        OnItemCommand="GrdViewItemCommand"  >
                <MasterTableView ClientDataKeyNames="Fund_Id" DataKeyNames="Fund_Id"  
                        GroupLoadMode="Client"  
                        NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o. ">
                    <Columns>    
                        <telerik:GridTemplateColumn HeaderText="Tác giả" HeaderStyle-Width="15%" >
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Author_Name")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Người chấm" HeaderStyle-Width="15%"  >
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Setter_Name")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                         <telerik:GridTemplateColumn HeaderText="Tiền" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="right" >
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "TotalFund")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Loại" HeaderStyle-Width="25%" >
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Type_Title")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Kiểu chấm"  HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <%# Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "Set_Type").ToString()) == 0 ? "Chấm mới" :
                                    Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "Set_Type").ToString()) == 1 ? "Điều chỉnh thêm" : 
                                    Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "Set_Type").ToString()) == 2 ? "Điều chỉnh bớt" :                                 
                                    Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "Set_Type").ToString()) == 3 ? "Bổ sung" : ""  %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Ngày chấm" HeaderStyle-Width="15%">
                            <ItemTemplate>
                                <%# String.Format("{0:dd/MM/yyyy hh:mm}", DataBinder.Eval(Container.DataItem, "Created_At"))%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>  
                        <telerik:GridTemplateColumn HeaderText="Chức năng" HeaderStyle-Width="10%" >
                            <ItemTemplate>
                                <asp:LinkButton ID="cmdEdit" runat="server" ToolTip="Sửa Nhuận bút" Enabled="True"  
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Fund_Id")%>' CommandName="Edit"  > <img width="16" src="/Images/LargeIcon/document_edit.png"  > </asp:LinkButton>  
                                <asp:LinkButton ID="cmdDelete" runat="server" ToolTip="Xóa" Enabled="True"  
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Fund_Id")%>' CommandName="Delete" OnClientClick="return confirm('Bạn có chắc chắn muốn Xóa mục này?');" > <img width="16" src="/Images/LargeIcon/document_delete.png"  > </asp:LinkButton>  
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        
                    </Columns>
                </MasterTableView>
                <GroupingSettings CollapseTooltip="Đ&#243;ng" ExpandTooltip="Mở" GroupSplitFormat="" />
                <ClientSettings  AllowColumnsReorder="true" ReorderColumnsOnClient="true" >
                    <Resizing  EnableRealTimeResize="True" AllowColumnResize="true"></Resizing>
                    <ClientEvents OnRowDblClick="RowDblClick"  />
                 </ClientSettings> 
                <PagerStyle Mode="NextPrevAndNumeric" Position="TopAndBottom"  FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang tiếp"
                    NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
         </telerik:RadGrid>    
         </p> 
         
            <asp:Label runat="server" ID="lblMessage" ForeColor="red"></asp:Label>
    </asp:Panel>
 </div>

</asp:Content>
