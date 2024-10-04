<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="PopupVCardDetail.aspx.cs" Inherits="VietNamNet.AddOn.VCard.PopupVCardDetail"  Title="Thông tin VCard"%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
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
            
            function radToolBarDefault_ClientButtonClicked(sender, eventArgs)
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

    <div class="pd05">
        <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnClientButtonClicked="radToolBarDefault_ClientButtonClicked">
                <Items> 
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/MediaIcon/16x16/btn-close.png" CommandName="Cancel"
                        Text="Đóng" AccessKey="C">
                    </telerik:RadToolBarButton>
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        
        <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
            
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
                            <td  width="200"><asp:Label ID="txtFullname" runat="server" onkeyup="txtFullname_keyup(this.value);"></asp:Label></td>                            
                        </tr>
                        <tr>
                            <td><label>Chức danh</label></td>
                            <td><asp:Label ID="txtOrgTitle" runat="server" onkeyup="txtOrgTitle_keyup(this.value);"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Công ty</label></td>
                            <td><asp:Label ID="txtOrgName" runat="server" onkeyup="txtOrgName_keyup(this.value);"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Email</label></td>
                            <td><asp:Label ID="txtOrgEmail1a" runat="server" onkeyup="txtOrgEmail_keyup(this.value);"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>SĐT Cố định</label></td>
                            <td><asp:Label ID="txtOrgPhonea" runat="server"  onkeyup="txtOrgPhone_keyup(this.value);" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>SĐT di động</label></td>
                            <td><asp:Label ID="txtOrgMobilea" runat="server" onkeyup="txtOrgMobile_keyup(this.value);"  ></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Số Fax</label></td>
                            <td><asp:Label ID="txtOrgFaxa" runat="server"   ></asp:Label></td>
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
                            <asp:Label ID="txtNotes" runat="server" TextMode="MultiLine" Width="95%" Rows="5" ></asp:Label>
                        </td>
                     </tr> 
                     <tr>
                        <td><label>Chia sẻ</label></td>
                        <td><asp:Label ID="txtScope" runat="server" ></asp:Label>
                        </td>
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
                            <td  width="200"><asp:Label ID="txtFullnamea" runat="server"  onkeyup="txtFullname_keyup(this.value);" ></asp:Label></td>
                            <td  width="100"><label>SĐT Cố định</label></td>
                            <td  width="200"><asp:Label ID="txtOrgPhone" runat="server" onkeyup="txtOrgPhone_keyup(this.value);"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Chức danh</label></td>
                            <td><asp:Label ID="txtOrgTitlea" runat="server"  onkeyup="txtOrgTitle_keyup(this.value);" ></asp:Label></td>
                            <td><label>SĐT Di động</label></td>
                            <td><asp:Label ID="txtOrgMobile" runat="server"  onkeyup="txtOrgMobile_keyup(this.value);"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Công ty</label></td>
                            <td><asp:Label ID="txtOrgNamea" runat="server"   onkeyup="txtOrgName_keyup(this.value);"></asp:Label></td>
                            <td><label>Số Fax</label></td>
                            <td><asp:Label ID="txtOrgFax" runat="server"  onkeyup="txtOrgFax_keyup(this.value);"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Phòng/ban</label></td>
                            <td><asp:Label ID="txtOrgUnit" runat="server"  ></asp:Label></td>                            
                        </tr>
                        <tr>
                            <td valign="top"><label>Địa chỉ </label></td>
                            <td colspan="3">
                                <asp:Label ID="txtOrgAdr1" runat="server" Width="45%"></asp:Label> &nbsp;
                                <asp:Label ID="txtOrgAdr2" runat="server" Width="45%"></asp:Label></td>
                        </tr>
                        <tr>
                            <td valign="top"><label>Email</label></td>
                            <td colspan="3">
                                <asp:Label ID="txtOrgEmail1" runat="server" Width="45%" onkeyup="txtOrgEmail_keyup(this.value);"></asp:Label> &nbsp;
                                <asp:Label ID="txtOrgEmail2" runat="server" Width="45%"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Website</label></td>
                            <td colspan="3"><asp:Label ID="txtOrgWebsite" runat="server"></asp:Label></td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView3" runat="server">
                    <table cellspacing="2" cellpadding="2">
                        <tr>
                            <td  width="100"><label>Họ tên</label></td>
                            <td  width="200"><asp:Label ID="txtFullnameb" runat="server"  onkeyup="txtFullname_keyup(this.value);"></asp:Label></td>
                            <td  width="100"><label>SĐT nhà riêng</label></td>
                            <td  width="200"><asp:Label ID="txtHomePhone" runat="server" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Giới tính</label></td>
                            <td><asp:Label ID="txtSex" runat="server"></asp:Label></td>
                            <td><label>SĐT Di động</label></td>
                            <td><asp:Label ID="txtHomeMobile" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Ngày sinh</label></td>
                            <td> 
                                <asp:Label ID="txtBirthday" runat="server"></asp:Label>
                            </td>
                            <td><label>Số Fax</label></td>
                            <td><asp:Label ID="txtHomeFax" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td valign="top"><label>Địa chỉ nhà&nbsp;</label></td>
                            <td colspan="3">
                                <asp:Label ID="txtHomeAdr1" runat="server" Width="45%"></asp:Label> &nbsp;
                                <asp:Label ID="txtHomeAdr2" runat="server" Width="45%"></asp:Label></td>
                        </tr>
                        <tr>
                            <td valign="top"><label>Email</label></td>
                            <td colspan="3">
                                <asp:Label ID="txtHomeEmail1" runat="server" Width="45%"></asp:Label> &nbsp;
                                <asp:Label ID="txtHomeEmail2" runat="server" Width="45%"></asp:Label>
                               
                            </td>
                        </tr>
                        <tr>
                            <td><label>Homepage</label></td>
                            <td colspan="3"><asp:Label ID="txtHomepage" runat="server"></asp:Label></td>
                        </tr>
                   </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
            
          <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="red"></asp:Label>
          <asp:Label ID="txtVCardId" runat="server" Visible="false"  ></asp:Label>
      </p>
        </asp:Panel>
    </div>
    
</asp:Content>
