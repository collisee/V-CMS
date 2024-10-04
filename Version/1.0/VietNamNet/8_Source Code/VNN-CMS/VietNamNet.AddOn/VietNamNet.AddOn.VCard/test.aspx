<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="VietNamNet.AddOn.VCard.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager  ID="ScriptManagerABC" runat="server" />
     
       <telerik:RadInputManager  ID="RadInputManager1" runat="server">
                                <telerik:RegExpTextBoxSetting  BehaviorID="RagExpBehavior1" Validation-IsRequired="true"
                                    ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorMessage="Invalid Email">
                                    <TargetControls>
                                        <telerik:TargetInput ControlID="TextBox26" />
                                        <telerik:TargetInput ControlID="TextBox27" />
                                    </TargetControls>
                                </telerik:RegExpTextBoxSetting>
                                </telerik:RadInputManager>
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

      <p class="rpCheckBoxPanel">
            
            <telerik:RadTabStrip  ID="RadTabStrip1" runat="server"   MultiPageID="RadMultiPage1"
                SelectedIndex="0" CssClass="tabStrip">
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
                            <td  width="200"><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>                            
                        </tr>
                        <tr>
                            <td><label>Chức danh</label></td>
                            <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>Công ty</label></td>
                            <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>Email</label></td>
                            <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>Cố định</label></td>
                            <td><asp:TextBox ID="TextBox5" runat="server"  ></asp:TextBox></td>
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
                            <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                     </tr>
                     <tr>
                        <td width="100"><label>Nhóm</label></td>
                        <td width="200"><asp:DropDownList ID="cboGroups" runat="server">
                            </asp:DropDownList></td>
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
                            <td  width="200"><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
                            <td  width="100"><label>SĐT Cố định</label></td>
                            <td  width="200"><asp:TextBox ID="TextBox12" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>Chức danh</label></td>
                            <td><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
                            <td><label>SĐT Di động</label></td>
                            <td><asp:TextBox ID="TextBox13" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>Công ty</label></td>
                            <td><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td>
                            <td><label>Số Fax</label></td>
                            <td><asp:TextBox ID="TextBox14" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="top"><label>Địa chỉ </label></td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox10" runat="server" Width="45%"></asp:TextBox> &nbsp;
                                <asp:TextBox ID="TextBox15" runat="server" Width="45%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="top"><label>Email</label></td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox11" runat="server" Width="45%"></asp:TextBox> &nbsp;
                                <asp:TextBox ID="TextBox16" runat="server" Width="45%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>Website</label></td>
                            <td colspan="3"><asp:TextBox ID="TextBox17" runat="server"></asp:TextBox></td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView3" runat="server">
                    <table cellspacing="2" cellpadding="2">
                        <tr>
                            <td  width="100"><label>Họ tên</label></td>
                            <td  width="200"><asp:TextBox ID="TextBox18" runat="server"></asp:TextBox></td>
                            <td  width="100"><label>SĐT Cố định</label></td>
                            <td  width="200"><asp:TextBox ID="TextBox19" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>Giới tính</label></td>
                            <td><asp:DropDownList ID="cboSex" runat="server"></asp:DropDownList></td>
                            <td><label>SĐT Di động</label></td>
                            <td><asp:TextBox ID="TextBox21" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>Ngày sinh</label></td>
                            <td> 
                                <telerik:RadDatePicker  ID="RadDatePicker1" runat="server" DateInput-DateFormat="dd/MM/yyyy"    />
                            </td>
                            <td><label>Số Fax</label></td>
                            <td><asp:TextBox ID="TextBox23" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="top"><label>Địa chỉ </label></td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox24" runat="server" Width="45%"></asp:TextBox> &nbsp;
                                <asp:TextBox ID="TextBox25" runat="server" Width="45%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="top"><label>Email</label></td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox26" runat="server" Width="45%"></asp:TextBox> &nbsp;
                                <asp:TextBox ID="TextBox27" runat="server" Width="45%"></asp:TextBox>
                               
                            </td>
                        </tr>
                        <tr>
                            <td><label>Homepage</label></td>
                            <td colspan="3"><asp:TextBox ID="TextBox28" runat="server"></asp:TextBox></td>
                        </tr>
                   </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
            
      </p>
      
      <p>
          <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="red"></asp:Label>
          <asp:Button ID="Button1" runat="server" Text="Cập nhật" />
          <asp:Button ID="Button2" runat="server" Text="Hủy" />
      </p>
      
    </div>
    </form>
</body>
</html>
