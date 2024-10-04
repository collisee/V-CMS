<%@ Page Language="C#" MasterPageFile="~/Popup.Master" AutoEventWireup="true" CodeBehind="EditFund.aspx.cs" Inherits="VietNamNet.AddOn.Royalty.FundsManager.EditFund" Title="Cập nhật Thông tin Chấm Nhuận bút" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplhContainer" runat="server">
<div>
<telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server" />
     <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>             
            <telerik:AjaxSetting AjaxControlID="radToolBarDefault">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />  
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="cboTypeParent">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />  
                    <telerik:AjaxUpdatedControl ControlID="cboType" />  
                    <telerik:AjaxUpdatedControl ControlID="lblTypeDescription" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="cboType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />  
                    <telerik:AjaxUpdatedControl ControlID="lblTypeDescription" />  
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="cmbIsMember">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlAuthor" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
     </telerik:RadAjaxManager>
<telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" RelativeTo="Element"
            Position="BottomCenter" AutoTooltipify="true" ContentScrolling="Default"
            Width="200" Height="10">
        </telerik:RadToolTipManager>
 
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
                var oWnd = GetRadWindow();
                if (oWnd) oWnd.close();
                else window.close();
            }
            
            function radToolBarDefault_ClientButtonClicking(sender, eventArgs)
            {
                var cmd = eventArgs.get_item().get_commandName();
                switch (cmd)
                {
                    case 'Delete':
                        if (!confirm('Bạn có chắc chắn muốn Xóa mục này?')){
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

    </telerik:RadScriptBlock>
            
</div>
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
                    <telerik:RadToolBarButton runat="server" Visible="false"
                                    CommandName="Delete" Value="Delete"
                                    Text="Xóa (D)" AccessKey="D" > 
                    </telerik:RadToolBarButton>
                     <telerik:RadToolBarButton runat="server" 
                                    CommandName="GoBack" Value="GoBack"
                                    Text="Quay lại (B)" AccessKey="B">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" 
                                    CommandName="Cancel" Value="Cancel"
                                    Text="Đóng (C)" AccessKey="C">
                    </telerik:RadToolBarButton>
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
            <asp:Label runat="server" ID="lblMessage" ForeColor="red"></asp:Label>
        </asp:Panel>

<table cellpadding="5px;">
    <tr>
        <td colspan="2">
            <asp:Literal runat="server" ID="lblArticleInfo"></asp:Literal>
            <telerik:RadTextBox  ID="txtArticleId" runat="server" Visible="false"   />
            <telerik:RadTextBox  ID="txtFundId" runat="server" Visible="false"   />
        </td>
    </tr>
    <tr>
     <td  class="w400" valign="top">
        <table>
             <tr>
                <td class="w100"><label>Kiểu chấm: </label></td>
                <td><asp:Literal runat="server" ID="lblFundStatus"></asp:Literal>
                    <telerik:RadTextBox  ID="txtSetType" runat="server"  Text="0" Visible="false"    />
                </td>
            </tr>
            <tr>
                 <td  class="w75"><label>Chữ: </label></td>
                 <td><telerik:RadNumericTextBox ID="txtTextFund" runat="server" CssClass="right" Value="0" Type="Currency" Culture="Vietnamese (Vietnam)" NumberFormat-DecimalDigits="0" /></td>
            </tr>
            <tr>
                 <td><label>Ảnh: </label></td>
                 <td><telerik:RadNumericTextBox ID="txtImageFund" runat="server" CssClass="right" Value="0" Type="Currency" Culture="Vietnamese (Vietnam)" NumberFormat-DecimalDigits="0" /></td>
            </tr>
            <tr>
                 <td><label>Nhạc: </label></td>
                 <td><telerik:RadNumericTextBox ID="txtAudioFund" runat="server" CssClass="right" Value="0" Type="Currency" Culture="Vietnamese (Vietnam)" NumberFormat-DecimalDigits="0" /></td>
            </tr>
            <tr>
                 <td><label>Video: </label></td>
                 <td><telerik:RadNumericTextBox ID="txtVideoFund" runat="server" CssClass="right" Value="0" Type="Currency" Culture="Vietnamese (Vietnam)" NumberFormat-DecimalDigits="0" /></td>
            </tr>
            <tr>
                 <td><label>Khác: </label></td>
                 <td><telerik:RadNumericTextBox ID="txtOtherFund" runat="server" CssClass="right" Value="0" Type="Currency" Culture="Vietnamese (Vietnam)" NumberFormat-DecimalDigits="0" /></td>
            </tr>
            <tr>
                 <td><label>Ghi chú: </label></td>
                 <td><telerik:RadTextBox  ID="txtNotes" runat="server" TextMode="MultiLine" width="98%" /></td>
            </tr>
        </table>
     </td>
    
     <td class="w350" valign="top" >
            <table>
                <tr>
                    <td colspan="2"> 
                        <fieldset>
                            <legend>Tác giả: </legend>
                     <asp:Label ID="lblIsMemberLabel" runat="server" CssClass="label w100" Text="Loại:"></asp:Label>
                                <telerik:RadComboBox ID="cmbIsMember" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="cmbIsMember_SelectedIndexChanged">
                                    <CollapseAnimation Duration="200" Type="OutQuint" />
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Ph&#243;ng vi&#234;n" Value="1" runat="server" />
                                        <telerik:RadComboBoxItem Text="Cộng t&#225;c vi&#234;n" Value="0" runat="server" />
                                    </Items>
                                </telerik:RadComboBox>
                                <br class="clear" />  
                    <asp:Panel ID="pnlAuthor" runat="server">
                        <asp:PlaceHolder ID="plhMember" runat="server"  Visible="false">                            
                                <asp:Label ID="lblGroupLabel" runat="server" CssClass="label w100" Text="Nhóm tác giả:"></asp:Label>
                                <telerik:RadComboBox ID="cmbGroup" runat="server"  DataTextField="Name" DataValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="cmbGroup_SelectedIndexChanged">
                                    <CollapseAnimation Duration="200" Type="OutQuint" />
                                </telerik:RadComboBox>
                                <br class="clear" /> 
                                <asp:Label ID="lblUserLabel" runat="server" CssClass="label w100" Text="Tên tác giả:" ></asp:Label>
                                <telerik:RadComboBox ID="cmbUser" runat="server"   DataTextField="Name" DataValueField="Id"  DropDownWidth="300px">
                                    <CollapseAnimation Duration="200" Type="OutQuint" />
                                </telerik:RadComboBox>
                                <br class="clear" /> 
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="plhNotMember" runat="server" Visible="false"> 
                                <asp:Label ID="lblCollaboratorLabel" runat="server" CssClass="label w100" Text="Tên tác giả:"></asp:Label>
                                <telerik:RadComboBox ID="cmbCollaborator" runat="server"  DataTextField="Name" DataValueField="Id"
                                      EmptyMessage="Lựa chọn Cộng tác viên..."  DropDownWidth="300px">
                                    <CollapseAnimation Duration="200" Type="OutQuint" />
                                </telerik:RadComboBox>
                                <br class="clear" /> 
                        </asp:PlaceHolder>
                    </asp:Panel>
                        </fieldset>
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                          <fieldset>
                            <legend>Loại Nhuận bút: </legend>
                                <label class="label w100">Nhóm: </label>
                                <telerik:RadComboBox runat="server" ID="cboTypeParent" AutoPostBack="true" DropDownWidth="300px"
                                                        OnSelectedIndexChanged="cboTypeParent_SelectedIndexChanged" ></telerik:RadComboBox>
                                <br class="clear" /> 
                                
                                <label class="label w100">Loại: </label>
                                <telerik:RadComboBox runat="server" ID="cboType" AutoPostBack="true" DropDownWidth="300px" 
                                                        OnSelectedIndexChanged="cboType_SelectedIndexChanged"></telerik:RadComboBox>
                                <br class="clear" /> 
                                
                                <label class="label w100">Mô tả: </label>
                                <asp:Literal runat="server" ID="lblTypeDescription"></asp:Literal>
                          </fieldset>
                    </td>
                </tr> 
            </table>
        </td>
    </tr>
</table>
</div>
</asp:Content>
