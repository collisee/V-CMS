<%@ Page Language="C#" MasterPageFile="Default.Master" AutoEventWireup="true" Codebehind="UserInfo.aspx.cs"
  Inherits="VietNamNet.AddOn.Union.UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplhContainer" runat="server">
  <telerik:RadScriptBlock runat="server" ID="scriptBlock">

    <script type="text/javascript">
                
            var controlId = '';
            
            function OpenFileExplorerDialog(ctrlId, text)
            {
                controlId = ctrlId;
                var wnd = $find('<%= FileExplorerWindow.ClientID %>');
                //add the name of the function to be executed when RadWindow is closed
                wnd.add_close(OnFileSelected);
                wnd.show();
            }

            //This function is called from the FileExplorer.aspx page
            function OnFileSelected(wnd, args)
            {
                var textbox = $find(controlId);
                //if (textbox && textbox.set_value) textbox.set_value(args.get_argument().fileSelected);
                if (textbox && textbox.set_value)
                {
                    var files = args.get_argument();
                    if (!files || !files.length) return;
                    var v = '';
                    for (i = 0; i < files.length; i++)
                    {
                        if (v) v += ',';
                        v += files[i].file;
                    }
                    textbox.set_value(v);
                }
            }

            function selectAvatar()
            {
                OpenFileExplorerDialog('<%=txtAvatar.ClientID %>');
            }

            function previewAvatar()
            {
                var textbox = $find('<%=txtAvatar.ClientID %>');
                if (textbox && textbox.get_value) window.open(textbox.get_value());
            }

    </script>

  </telerik:RadScriptBlock>
  <telerik:RadWindow runat="server" Width="680px" Height="550px" VisibleStatusbar="false"
    Behaviors="Close,Move" NavigateUrl="/FileManager.aspx" ID="FileExplorerWindow"
    Modal="True">
  </telerik:RadWindow>
  <div id="container">
    <div class="bg-title1">
      <div class="bg-title2">
        <div class="bg-title3">
          <a href="#" class="title">Thông tin cá nhân</a>
        </div>
      </div>
    </div>
    <div class="block-body">
      <asp:Label ID="lblInfoLabel" runat="server" Text="Thay đổi thông tin thành công!" CssClass="blue"></asp:Label>
      <table width="100%">
        <tr>
          <td>
            <asp:Label ID="lblFullNameLabel" runat="server" CssClass="label w150" Text="Tên đầy đủ:"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txtFullName" runat="server" MaxLength="255"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lblEmailLabel" runat="server" Text="Email:" CssClass="label w150"></asp:Label>
          </td>
          <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
              ErrorMessage="Bạn phải nhập <b>Email</b><br />" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
              ErrorMessage="Sai định dạng <b>Email</b><br />" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="255"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lblAvatarLabel" runat="server" CssClass="label w150" Text="Hình ảnh đại diện:"></asp:Label>
          </td>
          <td>
            <telerik:RadTextBox ID="txtAvatar" runat="server" Width="250px" MaxLength="255">
            </telerik:RadTextBox>
            <img alt="Chọn Hình ảnh đại diện" title="Chọn Hình ảnh đại diện" class="cpointer"
              src="/Images/SmallIcon/40.png" onclick="selectAvatar()" />
            <img alt="Xem Hình ảnh đại diện" title="Xem Hình ảnh đại diện" class="cpointer" src="/Images/SmallIcon/75.png"
              onclick="previewAvatar()" />
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lblSexLabel" runat="server" Text="Giới tính:" CssClass="label w150"></asp:Label>
          </td>
          <td>
            <telerik:RadComboBox ID="cmbSex" runat="server" Width="150px" MarkFirstMatch="True">
              <CollapseAnimation Duration="200" Type="OutQuint" />
              <Items>
                <telerik:RadComboBoxItem runat="server" Text="Nam" Value="Nam" />
                <telerik:RadComboBoxItem runat="server" Text="Nữ" Value="Nữ" />
              </Items>
            </telerik:RadComboBox>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lblBirthdayLabel" runat="server" Text="Ngày sinh:" CssClass="label w150"></asp:Label>
          </td>
          <td>
            <telerik:RadDatePicker ID="radDpkBirthday" runat="server" Culture="Vietnamese (Vietnam)"
              Width="90px" MinDate="1900-01-01">
              <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
              </Calendar>
              <DatePopupButton HoverImageUrl="" ImageUrl="" />
            </telerik:RadDatePicker>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lblAddressLabel" runat="server" Text="Địa chỉ:" CssClass="label w150"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txtAddress" runat="server" MaxLength="255"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lblPhoneLabel" runat="server" Text="Điện thoại:" CssClass="label w150"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txtPhone" runat="server" MaxLength="255"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lblMobileLabel" runat="server" Text="Di động:" CssClass="label w150"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txtMobile" runat="server" MaxLength="255"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td><asp:Label ID="lblYahooLabel" runat="server" Text="Yahoo:" CssClass="label w150"></asp:Label>
          </td>
          <td><asp:TextBox ID="txtYahoo" runat="server" MaxLength="255"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td><asp:Label ID="lblSkypeLabel" runat="server" Text="Skype:" CssClass="label w150"></asp:Label>
          </td>
          <td><asp:TextBox ID="txtSkype" runat="server" MaxLength="255"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td><asp:Label ID="lblFacebook" runat="server" Text="Facebook:" CssClass="label w150"></asp:Label>
          </td>
          <td><asp:TextBox ID="txtFacebook" runat="server" MaxLength="255"></asp:TextBox>
          </td>
        </tr>        
        <tr>
          <td colspan="2" align="center">
            <asp:Button ID="btnSubmit" runat="server" Text="Cập nhật" OnClick="btnSubmit_Click" /></td>
        </tr>
      </table>
    </div>
    <div class="bg-bgtitle1">
      <div class="bg-bgtitle2">
        <div class="bg-bgtitle3">
          &nbsp;
        </div>
      </div>
    </div>
  </div>
</asp:Content>
