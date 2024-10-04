<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="SurveyEdit.aspx.cs" Inherits="VietNamNet.AddOn.Survey.SurveyEdit" Title="Cập nhật thông tin Bình chọn" ValidateRequest="false" %>
<%@ Register Src="UserControls/SurveyPublishEdit.ascx" TagName="SurveyPublishEdit"    TagPrefix="vnnSurvey" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
<div>
<telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server" />
     <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="txtSurveyId">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" /> 
                    <telerik:AjaxUpdatedControl ControlID="radToolBarDefault" />
                </UpdatedControls> 
            </telerik:AjaxSetting> 
             <telerik:AjaxSetting AjaxControlID="cmdAddOption">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" /> 
                    <telerik:AjaxUpdatedControl ControlID="grdOptions" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
             
            <telerik:AjaxSetting AjaxControlID="radToolBarDefault">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />  
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
            function GetRadWindow()
            {
               var oWindow = null;
               if (window.radWindow) oWindow = window.radWindow;
               else if (window.frameElement && window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
               return oWindow;
            }

            function closeWin()
            {
                //get a reference to the RadWindow
                var oWnd = GetRadWindow();

                //close the RadWindow            
                if (oWnd) oWnd.close();
                else window.close();
            }
            
            function radToolBarDefault_ClientButtonClicking(sender, eventArgs)
            {
                var cmd = eventArgs.get_item().get_commandName();
                switch (cmd)
                {
                    case 'Delete':
                       if (confirmDelete()) { 
	                    }else{
	                         eventArgs.set_cancel(true);
	                    }		 
                        break; 
                    default:
                        break;
                };
            }
        </script> 
    </telerik:RadScriptBlock>

     <div class="pd05">
     <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" 
                                OnClientButtonClicking="radToolBarDefault_ClientButtonClicking" 
                                OnButtonClick="radToolBarDefault_ButtonClick">
                <Items>  
                    <telerik:RadToolBarButton runat="server"  
                                    CommandName="Update" Value="Update"
                                    Text="Cập nhật (U)" AccessKey="U">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" 
                                    CommandName="Delete" Value="Delete"
                                    Text="Xóa (D)" AccessKey="D"> 
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" 
                                    CommandName="Cancel" Value="Cancel"
                                    Text="Trở lại (C)" AccessKey="C">
                    </telerik:RadToolBarButton>
                   
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        
        <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
            <asp:Label runat="server" ID="lblMessage" ForeColor="red"></asp:Label>
            
          <p class="rpCheckBoxPanel">  
            <telerik:RadTabStrip  ID="RadTabStrip1" runat="server"   MultiPageID="RadMultiPage1"
                SelectedIndex="0" CssClass="tabStrip" CausesValidation="False">
                <Tabs>
                    <telerik:RadTab Text="Th&#244;ng tin Thăm d&#242;" runat="server" ></telerik:RadTab>
                    <telerik:RadTab Text="Thiết lập Hiển thị" runat="server"></telerik:RadTab> 
                </Tabs>
            </telerik:RadTabStrip>

            <telerik:RadMultiPage  ID="RadMultiPage1" runat="server"  SelectedIndex="0" CssClass="multiPage">
                <telerik:RadPageView ID="pwInfo" runat="server"> 
                <table>
                    <tr>
                         <td valign="top" >
                   <table>
                        <tr> 
                            <td  width="100"><label>Câu hỏi</label></td>
                            <td  width="200"><telerik:RadTextBox ID="txtQuestion" runat="server" TextMode="MultiLine"  width="98%"></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td><label>Kiểu chọn</label></td>
                            <td><telerik:RadComboBox ID="cboOptionType" runat="server"  width="98%"  ToolTip="Loại câu hỏi:<br>- 1 lựa chọn (kiểu Radio)<br>- Nhiều lựa chọn (kiểu Check)" >
                                    <Items> 
                                        <telerik:RadComboBoxItem runat="server" Text="1 lựa chọn" Value="R" />
                                        <telerik:RadComboBoxItem runat="server" Text="Nhiều lựa chọn" Value="C" />
                                    </Items>                            
                                </telerik:RadComboBox></td>                             
                        </tr>
                        <tr>
                            <td><label>Mô tả</label></td>
                            <td><telerik:RadTextBox ID="txtNotes" runat="server"  TextMode="MultiLine" width="98%" ></telerik:RadTextBox></td> 
                        </tr>
                       
                        <tr>
                            <td><label>Tags</label></td>
                            <td><telerik:RadTextBox ID="txtTags" runat="server" width="98%" ToolTip="Thông tin nhằm hỗ trợ Tìm kiếm, lựa chọn"></telerik:RadTextBox></td>
                        </tr> 
                   </table> 
                        
                        </td>
                        <td valign="top" >
                   
                   <table>
                         <tr>
                            <td   width="400"><label>Các lựa chọn</label></td> 
                         </tr>
                         <tr>   
                            <td>
                            
    <telerik:RadScriptBlock ID="radScriptBlock1" runat="server">
                            <script type="text/javascript">
                            
            function RowDblClick(sender, eventArgs)
            {
              sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
               eventArgs.set_cancel(true);
            }
            </script>
    </telerik:RadScriptBlock> 
                            
                      <telerik:RadGrid ID="grdOptions" AutoGenerateColumns="False"  GridLines="None"  Style="outline: none" Width="100%" runat="server"   
                                        OnItemCommand="GrdOptionsItemCommand" AllowSorting="true">
                                     <ClientSettings>
                                        <ClientEvents OnRowDblClick="RowDblClick" />
                                    </ClientSettings>
                                    <MasterTableView ClientDataKeyNames="SurveyId" DataKeyNames="SurveyId"  
                                        GroupLoadMode="Client"  EditMode="PopUp"
                                        NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o. "
                                        >
                                         <EditFormSettings CaptionFormatString="Edit ProductID: {0}" CaptionDataField="SurveyId" PopUpSettings-Modal="true" /> 
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="Lựa chọn" >
                                            <ItemTemplate>
                                                <asp:Label ID="txtOptionName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OptionName") %>' ToolTip='<%# DataBinder.Eval(Container.DataItem,"Notes") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn> 
                                        <telerik:GridTemplateColumn HeaderText="Lựa chọn khác" >
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem,"IsCorrect") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn> 
                                        <telerik:GridTemplateColumn HeaderText="Lựa chọn đúng" >
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem,"IsCorrect") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Thứ tự" >
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem,"ViewOrder") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Chức năng" >
                                            <ItemTemplate> 
                                                <asp:LinkButton ID="cmdEdit" runat="server" CommandName="Edit">Sửa</asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns> 
                                    
                    <EditFormSettings  EditFormType="Template" EditColumn-EditFormHeaderTextFormat="abd"  CaptionFormatString="Thông tin Lựa chọn" PopUpSettings-Modal="true" >
                    <FormTemplate>                        
                             <table width="100%"> 
                                <tr> 
                                    <td valign="top" ><label>Lựa chọn</label></td>
                                    <td><telerik:RadTextBox ID="txtOptionName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OptionName") %>' Width="98%"  ></telerik:RadTextBox><br />
                                        <asp:CheckBox ID="chkIsCorrect" runat="server" Text="Đánh dấu là lựa chọn đúng"/><br />
                                        <asp:CheckBox ID="chkIsOtherOption" runat="server" Text="Cho phép sử dụng lựa chọn khác" />
                                        <telerik:RadTextBox ID="txtOldOptionName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OptionName") %>' Visible="false"  ></telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td><label>Chú thích</label></td>
                                    <td><telerik:RadTextBox ID="txtNotes" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Notes") %>' Width="98%"  ></telerik:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="cmdGroupUpdate" CommandName="Update" runat="server" Text="Cập nhật"  />
                                        <asp:Button ID="cmdGroupCancel" CommandName="Cancel" runat="server" Text="Hủy bỏ" />
                                        <telerik:RadTextBox ID="txtSurveyOptionId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SurveyOptionId") %>' Visible="false"/>
                                    </td>
                                </tr>
                             </table>
                    </FormTemplate>
                </EditFormSettings>
                                    </MasterTableView>                                         
                                </telerik:RadGrid>
                            </td>
                         </tr>
                         <tr>
                            <td><asp:LinkButton ID="cmdAddOption" runat="server" OnClick="CmdAddOptionClick">Thêm lựa chọn</asp:LinkButton></td> 
                         </tr>
                         
                   </table>
                        
                        </td>
                    </tr>
                </table>
                
                
                </telerik:RadPageView>
                <telerik:RadPageView ID="pwConfig" runat="server" CssClass="pageViewEducation"> 
    
                     <table cellspacing="2" cellpadding="2">
                        <tr>
                            <td>Danh mục tin:</td>
                            <td>
                                <telerik:RadComboBox ID="cboCategories" runat="server" Height="200px" Width="200px"
                                        DropDownWidth="500px" EmptyMessage="Choose a Category" HighlightTemplatedItems="true"
                                        DataTextField="Name" DataValueField="Id" MarkFirstMatch="true" >
                                        <HeaderTemplate>
                                            <table style="width: 490px" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td style="width: 200px;">
                                                        Display Name</td>
                                                    <td style="width: 175px;">
                                                        Name</td>
                                                    <td style="width: 100px;">
                                                        Alias</td> 
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="width: 495px" cellspacing="0" cellpadding="0" title="<%# DataBinder.Eval(Container, "Attributes['Detail']")%>">
                                                <tr>
                                                    <td style="width: 200px;">
                                                        <%# DataBinder.Eval(Container, "Attributes['Name']")%>
                                                    </td>
                                                    <td style="width: 175px;">
                                                       <label  > <%# DataBinder.Eval(Container, "Attributes['DisplayName']")%></label>
                                                    </td> 
                                                    <td style="width: 100px;">
                                                       <label > <%# DataBinder.Eval(Container, "Attributes['Alias']")%></label>
                                                    </td> 
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                
                            </td>
                        </tr>
                        
                        <tr>
                           <asp:Panel ID="pnSurveyPublishEdit" runat="server" >
                                <vnnSurvey:SurveyPublishEdit ID="SurveyPublishEdit1" runat="server" />
                            </asp:Panel>
                        </tr>
                        
                   </table>
                </telerik:RadPageView> 
            </telerik:RadMultiPage>
            
                   <telerik:RadTextBox ID="txtSurveyId" runat="server" Visible="false"    ></telerik:RadTextBox>
                   <telerik:RadTextBox ID="txtSurveyPublishId" runat="server" Visible="false"    ></telerik:RadTextBox>
          </p> 
          </asp:Panel>
         &nbsp;
     </div>
 
    
</asp:Content>
