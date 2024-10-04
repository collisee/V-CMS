<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="PopupVCardEdit.aspx.cs" Inherits="VietNamNet.AddOn.VCard.PopupVCardEdit" Title="Cập nhật thông tin VCard" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
 <telerik:RadInputManager  ID="RadInputManager1" runat="server">
                                <telerik:RegExpTextBoxSetting  BehaviorID="bhvEmail"
                                    ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorMessage="Invalid Email">
                                    <TargetControls>
                                        <telerik:TargetInput ControlID="txtOrgEmail1" /> 
                                        <telerik:TargetInput ControlID="txtOrgEmail2" />
                                        <telerik:TargetInput ControlID="txtOrgEmail1a" />
                                        <telerik:TargetInput ControlID="txtHomeEmail1" />
                                        <telerik:TargetInput ControlID="txtHomeEmail2" />
                                    </TargetControls>
                                    <Validation IsRequired="false" />
                                </telerik:RegExpTextBoxSetting>
                                <telerik:RegExpTextBoxSetting  BehaviorID="bhvWebsite"
                                    ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorMessage="Invalid Email">
                                    <TargetControls>  
                                    </TargetControls>
                                    <Validation IsRequired="false" />
                                </telerik:RegExpTextBoxSetting>
</telerik:RadInputManager>
     <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="txtVCardId">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" /> 
                    <telerik:AjaxUpdatedControl ControlID="radToolBarDefault" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
             <telerik:AjaxSetting AjaxControlID="radToolBarDefault">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" /> 
                    <telerik:AjaxUpdatedControl ControlID="txtVCardId" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
        </AjaxSettings>
     </telerik:RadAjaxManager>
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
                    case 'Cancel':
                        closeWin();
                        break;
                    default:
                        break;
                };
            }
        </script>

        <script type="text/javascript">
            function txtFullname_keyup2(v){           
               $find("<%=txtFullname.ClientID %>").set_value(v);
               $find("<%=txtFullnamea.ClientID %>").set_value(v);
               $find("<%=txtFullnameb.ClientID %>").set_value(v); 
            }
            function txtOrgTitle_keyup(v){  
               $find("<%=txtOrgTitle.ClientID %>").set_value(v);
               $find("<%=txtOrgTitlea.ClientID %>").set_value(v);
            }
            function txtOrgName_keyup(v) {  
               $find("<%=txtOrgName.ClientID %>").set_value(v);
               $find("<%=txtOrgNamea.ClientID %>").set_value(v);
            }
            function txtOrgEmail_keyup(v) {  
               $find("<%=txtOrgEmail1.ClientID %>").set_value(v);
               $find("<%=txtOrgEmail1a.ClientID %>").set_value(v);
            }
            function txtOrgPhone_keyup(v) {  
               $find("<%=txtOrgPhone.ClientID %>").set_value(v);
               $find("<%=txtOrgPhonea.ClientID %>").set_value(v);
            }
            function txtOrgMobile_keyup(v) {  
               $find("<%=txtOrgMobile.ClientID %>").set_value(v);
               $find("<%=txtOrgMobilea.ClientID %>").set_value(v);
            }
            function txtOrgFax_keyup(v) {  
               $find("<%=txtOrgFax.ClientID %>").set_value(v);
               $find("<%=txtOrgFaxa.ClientID %>").set_value(v);
            }
            function txtFullname_keyup(v) {
                //v = e.get_newValue();
                $find('<%=txtFullname.ClientID %>').set_value(v); 
                $find('<%=txtFullnamea.ClientID %>').set_value(v); 
                $find('<%=txtFullnameb.ClientID %>').set_value(v); 
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
                                    CommandName="Export" Value="Export"
                                    Text="Xuất VCard (E)" AccessKey="E">
                    </telerik:RadToolBarButton>
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
                                    Text="Đóng (C)" AccessKey="C">
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
                    <telerik:RadTab Text="General"></telerik:RadTab>
                    <telerik:RadTab Text="Bussiness"></telerik:RadTab>
                    <telerik:RadTab Text="Personal"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            
            <telerik:RadMultiPage  ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="multiPage">
                <telerik:RadPageView ID="RadPageView1" runat="server">
                    <table>
                        <tr>
                            <td valign="top">
                   <table>
                        <tr> 
                            <td  width="100"><label>Họ tên</label></td>
                            <td  width="200"><telerik:RadTextBox ID="txtFullname" runat="server" onchange="txtFullname_keyup(this.value);" onkeyup="txtFullname_keyup(this.value);"></telerik:RadTextBox></td>                            
                        </tr>
                        <tr>
                            <td><label>Chức danh</label></td>
                            <td><telerik:RadTextBox ID="txtOrgTitle" runat="server" onchange="txtOrgTitle_keyup(this.value);" onkeyup="txtOrgTitle_keyup(this.value);"></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td><label>Công ty</label></td>
                            <td><telerik:RadTextBox ID="txtOrgName" runat="server" onchange="txtOrgName_keyup(this.value);" onkeyup="txtOrgName_keyup(this.value);"  ></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td><label>Email</label></td>
                            <td><telerik:RadTextBox ID="txtOrgEmail1a" runat="server" onchange="txtOrgEmail_keyup(this.value);" onkeyup="txtOrgEmail_keyup(this.value);"></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td><label>SĐT Cố định</label></td>
                            <td><telerik:RadTextBox ID="txtOrgPhonea" runat="server" onchange="txtOrgPhone_keyup(this.value);" onkeyup="txtOrgPhone_keyup(this.value);" ></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td><label>SĐT di động</label></td>
                            <td><telerik:RadTextBox ID="txtOrgMobilea" runat="server" onchange="txtOrgMobile_keyup(this.value);" onkeyup="txtOrgMobile_keyup(this.value);"  ></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td><label>Số Fax</label></td>
                            <td><telerik:RadTextBox ID="txtOrgFaxa" runat="server" onchange="txtOrgFax_keyup(this.value);" onkeyup="txtOrgFax_keyup(this.value);"  ></telerik:RadTextBox></td>
                        </tr>
                   </table>
                            </td>
                            <td valign="top">
                   <table>
                     <tr>
                        <td colspan="2"><label>Mô tả</label> </td>
                     </tr>
                     <tr>
                        <td colspan="2">
                            <telerik:RadTextBox ID="txtNotes" runat="server" TextMode="MultiLine" Width="95%" Rows="5" ></telerik:RadTextBox>
                        </td>
                     </tr>
                     <tr>
                        <td width="75"><label>Nhóm</label></td>
                        <td width="200"><telerik:RadComboBox ID="cboGroups" runat="server">
                            </telerik:RadComboBox></td>
                     </tr>
                     <tr>
                        <td><label>Chia sẻ</label></td>
                        <td><telerik:RadComboBox ID="cboScope" runat="server">
                            </telerik:RadComboBox></td>
                     </tr>
                   </table>         
                            </td>
                        </tr>
                    </table>
                
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView2" runat="server" CssClass="pageViewEducation">
                    <table cellspacing="2" cellpadding="2">
                        <tr>
                            <td  width="100"><label>Họ tên</label></td>
                            <td  width="200"><telerik:RadTextBox ID="txtFullnamea" runat="server" onchange="txtFullname_keyup(this.value);" onkeyup="txtFullname_keyup(this.value);" ></telerik:RadTextBox></td>
                            <td  width="100"><label>SĐT Cố định</label></td>
                            <td  width="200"><telerik:RadTextBox ID="txtOrgPhone" runat="server" onchange="txtOrgPhone_keyup(this.value);" onkeyup="txtOrgPhone_keyup(this.value);"></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td><label>Chức danh</label></td>
                            <td><telerik:RadTextBox ID="txtOrgTitlea" runat="server" onchange="txtOrgTitle_keyup(this.value);" onkeyup="txtOrgTitle_keyup(this.value);" ></telerik:RadTextBox></td>
                            <td><label>SĐT Di động</label></td>
                            <td><telerik:RadTextBox ID="txtOrgMobile" runat="server" onchange="txtOrgMobile_keyup(this.value);" onkeyup="txtOrgMobile_keyup(this.value);"></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td><label>Công ty</label></td>
                            <td><telerik:RadTextBox ID="txtOrgNamea" runat="server"  onchange="txtOrgName_keyup(this.value);" onkeyup="txtOrgName_keyup(this.value);"></telerik:RadTextBox></td>
                            <td><label>Số Fax</label></td>
                            <td><telerik:RadTextBox ID="txtOrgFax" runat="server" onchange="txtOrgFax_keyup(this.value);" onkeyup="txtOrgFax_keyup(this.value);"></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td><label>Phòng/ban</label></td>
                            <td><telerik:RadTextBox ID="txtOrgUnit" runat="server"  ></telerik:RadTextBox></td>                            
                        </tr>
                        <tr>
                            <td valign="top"><label>Địa chỉ </label></td>
                            <td colspan="3">
                                <telerik:RadTextBox ID="txtOrgAdr1" runat="server" Width="45%"></telerik:RadTextBox> &nbsp;
                                <telerik:RadTextBox ID="txtOrgAdr2" runat="server" Width="45%"></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td valign="top"><label>Email</label></td>
                            <td colspan="3">
                                <telerik:RadTextBox ID="txtOrgEmail1" runat="server" Width="45%" onchange="txtOrgEmail_keyup(this.value);" onkeyup="txtOrgEmail_keyup(this.value);"></telerik:RadTextBox> &nbsp;
                                <telerik:RadTextBox ID="txtOrgEmail2" runat="server" Width="45%"></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td><label>Website</label></td>
                            <td colspan="3"><telerik:RadTextBox ID="txtOrgWebsite" runat="server"></telerik:RadTextBox></td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView3" runat="server">
                    <table cellspacing="2" cellpadding="2">
                        <tr>
                            <td  width="100"><label>Họ tên</label></td>
                            <td  width="200"><telerik:RadTextBox ID="txtFullnameb" runat="server" onchange="txtFullname_keyup(this.value);" onkeyup="txtFullname_keyup(this.value);"></telerik:RadTextBox></td>
                            <td  width="100"><label>SĐT nhà riêng</label></td>
                            <td  width="200"><telerik:RadTextBox ID="txtHomePhone" runat="server" ></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td><label>Giới tính</label></td>
                            <td><telerik:RadComboBox ID="cboSex" runat="server"></telerik:RadComboBox></td>
                            <td><label>SĐT Di động</label></td>
                            <td><telerik:RadTextBox ID="txtHomeMobile" runat="server"></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td><label>Ngày sinh</label></td>
                            <td> 
                                <telerik:RadDatePicker  ID="txtBirthday" runat="server"   Culture="Vietnamese (Vietnam)"    >
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                            <td><label>Số Fax</label></td>
                            <td><telerik:RadTextBox ID="txtHomeFax" runat="server"></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td valign="top"><label>Địa chỉ nhà&nbsp;</label></td>
                            <td colspan="3">
                                <telerik:RadTextBox ID="txtHomeAdr1" runat="server" Width="45%"></telerik:RadTextBox> &nbsp;
                                <telerik:RadTextBox ID="txtHomeAdr2" runat="server" Width="45%"></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td valign="top"><label>Email</label></td>
                            <td colspan="3">
                                <telerik:RadTextBox ID="txtHomeEmail1" runat="server" Width="45%"></telerik:RadTextBox> &nbsp;
                                <telerik:RadTextBox ID="txtHomeEmail2" runat="server" Width="45%"></telerik:RadTextBox>
                               
                            </td>
                        </tr>
                        <tr>
                            <td><label>Homepage</label></td>
                            <td colspan="3"><telerik:RadTextBox ID="txtHomepage" runat="server"></telerik:RadTextBox></td>
                        </tr>
                   </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
            
                   <telerik:RadTextBox ID="txtVCardId" runat="server" Visible="false" OnTextChanged="TxtVCardIdTextChanged"   ></telerik:RadTextBox>
          </p>
          <asp:Panel  class="rpCheckBoxPanel" runat="server" ID="pnUpload">
            <label>Đọc thông tin từ file VCard:</label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="cmdRead" runat="server" Text="Đọc" OnClick="CmdReadClick" />          

          </asp:Panel>
          </asp:Panel>
     </div>
 
    
</asp:Content>
