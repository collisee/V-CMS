<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="PopupSurveyAdd2Cat.aspx.cs" Inherits="VietNamNet.AddOn.Survey.PopupSurveyAdd2Cat" Title="Đưa Bình chọn vào Danh mục tin"  ValidateRequest="false"%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
<div>
 <telerik:RadInputManager  ID="RadInputManager1" runat="server">
                                <telerik:RegExpTextBoxSetting  BehaviorID="bhvEmail"
                                    ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorMessage="Invalid Email">
                                    <TargetControls>
                                        <telerik:TargetInput ControlID="txtOrgEmail1" />  
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
                    case 'Cancel':
                        closeWin();
                        break;
                    default:
                        break;
                };
            }
            
            
            function selectTab(tabValue)
            {
                var tabStrip = $find("<%= RadTabStrip1.ClientID %>"); 
                var tab = tabStrip.findTabByValue(tabValue);
                if (!tab)
                {
                    alert("There is no tab with text ");
                    return true;
                }
                
                tab.set_selected(true); //The same as tab.select();
                return true;
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
                SelectedIndex="1" CssClass="tabStrip" CausesValidation="False">
                <Tabs>
                    <telerik:RadTab Text="Thông tin thăm dò" runat="server" Value="tSureyInfo" ></telerik:RadTab>
                    <telerik:RadTab Text="Thông tin Danh mục tin" runat="server"  Value="tSearchInfo"></telerik:RadTab>
                    <telerik:RadTab Text="Thiết lập hiển thị" runat="server"  Value="tConfig"></telerik:RadTab> 
                </Tabs>
            </telerik:RadTabStrip>

            <telerik:RadMultiPage  ID="RadMultiPage1" runat="server"  SelectedIndex="1" CssClass="multiPage">
                <telerik:RadPageView ID="pwSurveyInfo" runat="server" CssClass="pageViewEducation"> 
                                        
                </telerik:RadPageView>
                <telerik:RadPageView ID="pwCatInfo" runat="server" CssClass="pageViewEducation"> 
                                        
                </telerik:RadPageView>
                <telerik:RadPageView ID="pwConfig" runat="server" CssClass="pageViewEducation"> 
    
                     
                </telerik:RadPageView> 
            </telerik:RadMultiPage>
            
                   <telerik:RadTextBox ID="txtSurveyId" runat="server" Visible="false"    ></telerik:RadTextBox>
          </p> 
          </asp:Panel>
         &nbsp;
     </div>
 
     
</asp:Content>
