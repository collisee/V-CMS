<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="TypesEdit.aspx.cs" Inherits="VietNamNet.AddOn.Royalty.TypesEdit" Title="Cập nhật Loại nhuận bút" ValidateRequest="false" %>
<asp:Content ContentPlaceHolderID="cplhContainer" ID="Content1" runat="server">
<div>
<telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server" />
     <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>             
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
                //bind data return
                var args = {id:0,text: ''};
                args.id = $find("<%= cboParentType.ClientID %>").get_selectedItem().get_value();
                args.text = $find("<%= cboParentType.ClientID %>").get_selectedItem().get_text();
                
                
                var oWnd = GetRadWindow();
                if (oWnd) oWnd.close(args);
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
            
</div>
    <div class="pd05">
     <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server"  
                                OnClientButtonClicked="radToolBarDefault_ClientButtonClicked"
                                OnButtonClick="radToolBarDefault_ButtonClick">
                <Items>  
                    <telerik:RadToolBarButton runat="server"  
                                    CommandName="Update" Value="Update"
                                    Text="Cập nhật (U)" AccessKey="U">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" Visible="false"
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
            <asp:Label runat="server" ID="lblMessage" ForeColor="red"></asp:Label>
        </asp:Panel>
    <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
        <table width="90%">
             <tr> 
                <td class="w100"><label>Tiêu đề:</label> </td>
                <td><telerik:RadTextBox ID="txtTitle" runat="server"  width="98%"></telerik:RadTextBox></td>
             </tr>   
             <tr> 
                <td><label >Mô tả:</label> </td>
                <td><telerik:RadTextBox ID="txtDescription" runat="server"  TextMode="MultiLine"  width="98%" ></telerik:RadTextBox> </td>
             </tr>
             <tr> 
                <td><label >Nhóm:</label> </td>
                 <td><telerik:RadComboBox ID="cboParentType" runat="server" ></telerik:RadComboBox> </td>
             </tr>
             <tr> 
                <td><label >Giá trị:</label> </td>
                 <td><label >Thấp nhất:</label> <telerik:RadNumericTextBox ID="txtMinValue" runat="server" CssClass="right" Value="0" Type="Currency" Culture="Vietnamese (Vietnam)" NumberFormat-DecimalDigits="0" /><br />
                     <label >Cao nhất :</label> <telerik:RadNumericTextBox ID="txtMaxValue" runat="server" CssClass="right" Value="0" Type="Currency" Culture="Vietnamese (Vietnam)" NumberFormat-DecimalDigits="0"/>
                 </td>
             </tr>
        </table>
        <telerik:RadTextBox ID="txtTypeId" runat="server" Text="0" Visible="false" />
            
    </asp:Panel>
 </div>
    
</asp:Content>
