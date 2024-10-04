<%@ Page MasterPageFile="~/Default.Master"  Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VietNamNet.AddOn.Survey._Default" EnableEventValidation="false"  ValidateRequest="false" %>

<asp:Content ContentPlaceHolderID="cplhContainer" ID="Content1" runat="server">
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server" />
    <telerik:RadWindowManager ID="radWindowManager" runat="server" Behaviors="Maximize,Move,Reload,Resize,Close"
        VisibleStatusbar="False">
    </telerik:RadWindowManager>
    
    
    <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radToolBarDefault">
                <UpdatedControls> 
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                    <telerik:AjaxUpdatedControl ControlID="grdView" /> 
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="grdView">
                <UpdatedControls> 
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                    <telerik:AjaxUpdatedControl ControlID="grdView" /> 
                </UpdatedControls>
            </telerik:AjaxSetting> 
        </AjaxSettings>
     </telerik:RadAjaxManager>
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" RelativeTo="Element"
            Position="BottomCenter" AutoTooltipify="true" ContentScrolling="Default"
            Width="200" Height="10">
        </telerik:RadToolTipManager>
    <telerik:RadScriptBlock runat="server" ID="RadScriptBlock1">

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
            
            function RadToolBarDefaultClientClick(sender, args)
            {
                 if (args.get_item().get_value()=="AddNew"){ 
                    ViewSurveyEdit(null);
                    args.set_cancel(true);
                    }
            }
            
            
            
            function ViewSurveyEdit(sid){
                var oWnd = "SurveyEdit.aspx?surveyid=" + sid;
                window.location = oWnd;
//                var oWnd = radopen("PopupSurveyEdit.aspx?surveyid=" + sid);
//                oWnd.setSize(840,450);
//                oWnd.add_close(closeRadWindow);
            }
            
            function AddSurvey2Cat(sid)            {
                var oWnd = radopen("PopupSurveyAdd2Cat.aspx?surveyid=" + sid);
                oWnd.setSize(840,450);
                oWnd.add_close(closeRadWindow);
            }
            function AddSurvey2Article(sid){
                var oWnd = radopen("PopupSurveyAdd2Article.aspx?surveyid=" + sid);
                oWnd.setSize(840,450);
                oWnd.add_close(closeRadWindow);
            }
            function ViewListCatBySurvey(sid){
                var oWnd = radopen("PopupListCatBySurvey.aspx?surveyid=" + sid);
                oWnd.setSize(840,450);
                oWnd.add_close(closeRadWindow);
            }
            function ViewListArticleBySurvey(sid){
                var oWnd = radopen("PopupListArticleBySurvey.aspx?surveyid=" + sid);
                oWnd.setSize(840,450);
                oWnd.add_close(closeRadWindow);
            }
            
            function ViewResult(sid){
                var oWnd = radopen("ViewResult.aspx?surveyid=" + sid);
                oWnd.setSize(840,450);
                oWnd.add_close(closeRadWindow);
            }
            
            function closeRadWindow(wnd, args)
            {
                //var refresh = $get('<%=cmdRefesh.ClientID %>');
                //if (refresh) refresh.click();                
            }
        </script>

    </telerik:RadScriptBlock>
<!-- Begin Filter -->
 <div class="pd05 pb00"> 
        <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="RadToolBarDefaultButtonClick" OnClientButtonClicking="RadToolBarDefaultClientClick"
            CssClass="panel-search-toolbar">
            <Items>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/21.png" CommandName="AddNew" 
                                            Text="Tạo mới Survey" Value="AddNew" AccessKey="N">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="True" runat="server" />
                <telerik:RadToolBarButton Value="searchTextBoxButton" CommandName="searchText" runat="server" >
                    <ItemTemplate>
                        <telerik:RadTextBox runat="server" ID="txtKeyword" EmptyMessage="Tìm kiếm" CssClass="panel-search-textbox"
                            Width="200px"   ><ClientEvents OnKeyPress="onKeyPress" OnValueChanged="onKeyPress" /></telerik:RadTextBox>
                        <label>Kiểu lựa chọn:</label>
                        <telerik:RadComboBox ID="cboOptionTypes" runat="server" OnClientSelectedIndexChanged="onFilterChange" OnClientTextChange="onFilterChange">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Toàn bộ" Value="" />
                                <telerik:RadComboBoxItem runat="server" Text="1 lựa chọn" Value="R" />
                                <telerik:RadComboBoxItem runat="server" Text="Nhiều lựa chọn" Value="C" />                                
                            </Items>                            
                        </telerik:RadComboBox>
                        <label title="Trạng thái của Survey">Trạng thái:</label>
                        <telerik:RadComboBox ID="cboStatus" runat="server" OnClientSelectedIndexChanged="onFilterChange" OnClientTextChange="onFilterChange">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Toàn bộ" Value="" />
                                <telerik:RadComboBoxItem runat="server" Text="Chưa xuất bản" Value="0" />
                                <telerik:RadComboBoxItem runat="server" Text="Đã xuất bản" Value="1" />                                
                            </Items>                            
                        </telerik:RadComboBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="T&#236;m kiếm" Value="search" CommandName="Search" runat="server" />
                <telerik:RadToolBarButton ImageUrl="~/Images/SmallIcon/75.png" Value="search" CommandName="Search" runat="server" />
            </Items>
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </telerik:RadToolBar>
        
      </div> 
  <!-- End Filter --> 
   
 <!-- Begin Display List  -->  

<div class="pd05">
<asp:Label ID="lblMessage" runat="server" ForeColor="red" Text=""></asp:Label>
                <telerik:RadGrid ID="grdView" runat="server" AutoGenerateColumns="False" PageSize="10"
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
                        <telerik:GridTemplateColumn HeaderText="Kiểu lựa chọn" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <%# Convert.IsDBNull(DataBinder.Eval(Container.DataItem, "OptionType")) ? "" : DataBinder.Eval(Container.DataItem, "OptionType").ToString() == "R" ? "1 Lựa chọn" : "Nhiều lựa chọn"%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Trạng thái" HeaderStyle-Width="100">
                            <ItemTemplate><!-- IsPublisher -->
                                <asp:LinkButton ID="cmdApprove" runat="server" ToolTip="Chuyển trạng thái xuất bản Bình chọn này" Enabled='<%# isPublisher %>'
                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "SurveyId")%>' CommandName="Approve"  ><%# Convert.IsDBNull(DataBinder.Eval(Container.DataItem, "Status")) ? "Chưa xuất bản" : DataBinder.Eval(Container.DataItem, "Status").ToString() == "1" ? "Đã xuất bản" : "Chưa xuất bản"%></asp:LinkButton>  <br />

                                
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Chức năng" HeaderStyle-Width="100">
                             <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Sửa thông tin Bình chọn" Enabled="True" Visible='<%# isUpdater %>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "SurveyId")%>' CommandName="Edit"  > <img width="16" src="/Images/LargeIcon/document_edit.png"  > </asp:LinkButton>  
                             
                               <asp:LinkButton ID="cmdDelete" runat="server" ToolTip="Xóa Bình chọn này" Enabled="True" Visible='<%# isDeleter %>'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "SurveyId")%>' CommandName="Delete"  ><img width="16" src="/Images/LargeIcon/close.png"  ></asp:LinkButton>   
                               
                               <asp:PlaceHolder runat="server" ID="pnApproved" Visible='<%#IsApproved(int.Parse(DataBinder.Eval(Container.DataItem, "Status").ToString())) %>'>
                                   &nbsp;&nbsp; <!-- IsPublisher -->
                                    <a href="#" onclick="ViewResult('<%# DataBinder.Eval(Container.DataItem, "SurveyId")%>')" title="Xem Kết quả của Bình chọn này"><img width="16" src="/Images/LargeIcon/report.png"  ></a>
                                    <a href="#" onclick="AddSurvey2Cat('<%# DataBinder.Eval(Container.DataItem, "SurveyId")%>')" title="Thêm Bình chọn vào Danh mục nhóm tin"><img width="16" src="/Images/LargeIcon/folder_add.png"  ></a>
                                    <a href="#" onclick="AddSurvey2Article('<%# DataBinder.Eval(Container.DataItem, "SurveyId")%>')" title="Thêm Bình chọn vào Tin bài"><img width="16" src="/Images/LargeIcon/document_add.png"  ></a> 
                                    <a href="#" onclick="ViewListCatBySurvey('<%# DataBinder.Eval(Container.DataItem, "SurveyId")%>')" title="Danh sách Nhóm tin đã có trong Bình chọn này"><img src="/Images/SmallIcon/27.png" width="16"></a>
                                    <a href="#" onclick="ViewListArticleBySurvey('<%# DataBinder.Eval(Container.DataItem, "SurveyId")%>')" title="Danh sách Tin bài đã có trong Bình chọn này"><img src="/Images/SmallIcon/26.png" width="16"></a><br /> 
                                </asp:PlaceHolder>
                             </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns> 
                </MasterTableView>  
                 <ClientSettings  AllowColumnsReorder="true" ReorderColumnsOnClient="true" >
                    <Resizing  EnableRealTimeResize="True" AllowColumnResize="true"></Resizing>
                 </ClientSettings>
                <PagerStyle Mode="NextPrevAndNumeric" Position="TopAndBottom" />
            </telerik:RadGrid>
</div>        
        
 <!-- End Display List  -->
 
 
 <div style="display:none"><asp:Button ID="cmdRefesh" runat="server" Text="Button" OnClick="OnFilterChanged" /></div>


</asp:Content>
