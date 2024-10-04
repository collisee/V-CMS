<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="PopupListCatBySurvey.aspx.cs" Inherits="VietNamNet.AddOn.Survey.PopupListCatBySurvey" Title="Danh sách Danh mục tin của Binh chọn" validateRequest="false"%>

<%@ Register Src="UserControls/SurveyPublishEdit.ascx" TagName="SurveyPublishEdit"    TagPrefix="vnnSurvey" %>
<%@ Register Src="UserControls/SurveyPublishList.ascx" TagName="SurveyPublishList"    TagPrefix="vnnSurvey" %>
<%@ Register Src="UserControls/SurveyInfo.ascx" TagName="SurveyInfo" TagPrefix="vnnSurvey" %> 
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
<div> 

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
            <telerik:AjaxSetting AjaxControlID="pnSurveyPublishList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnSurveyPublishList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="radToolBarDefault">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnSurveyPublishList" />
                    <telerik:AjaxUpdatedControl ControlID="pnSurveyPublishEdit" />
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
                var toolbar; var searchButton;
                toolbar = $find("<%= radToolBarDefault.ClientID %>");
				refreshButton = toolbar.findButtonByCommandName("Refresh"); refreshButton.click();


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
            
             function editSurveyPublish(surveyPublishId)
            {
                 $find("<%= txtSurveyPublishId.ClientID %>").set_value(surveyPublishId);

                var tabStrip = $find("<%= RadTabStrip1.ClientID %>"); 
                var tab = tabStrip.findTabByValue('tConfig');
				
                tab.set_selected(true); //The same as tab.select();
                
                var toolbar; var searchButton;
                toolbar = $find("<%= radToolBarDefault.ClientID %>");
				refreshButton = toolbar.findButtonByCommandName("Refresh"); refreshButton.click();
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
                   
                     <telerik:RadToolBarButton runat="server" Visible="False"
                                    CommandName="Update" Value="Update"
                                    Text="Cập nhật (U)" AccessKey="U" onclick="selectTab('tSearchInfo');">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" 
                                    CommandName="Cancel" Value="Cancel"
                                    Text="Đóng (C)" AccessKey="C">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server"    style="display:none;"
                                    CommandName="Refresh" Value="Refresh"
                                    Text="Làm tươi (R)" AccessKey="R">
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
                    <telerik:RadTab Text="Thông tin Bình chọn" runat="server" Value="tSureyInfo" ></telerik:RadTab>
                    <telerik:RadTab Text="Danh sách Danh mục" runat="server"  Value="tSearchInfo"></telerik:RadTab> 
                    <telerik:RadTab Text="Cấu hình hiển thị" runat="server"  Value="tConfig"></telerik:RadTab> 
                </Tabs>
            </telerik:RadTabStrip>

            <telerik:RadMultiPage  ID="RadMultiPage1" runat="server"  SelectedIndex="1" CssClass="multiPage">
                <telerik:RadPageView ID="pwSurveyInfo" runat="server" CssClass="pageViewEducation">  
                    <vnnSurvey:SurveyInfo ID="SurveyInfo1" runat="server" />
                    
                </telerik:RadPageView>
                <telerik:RadPageView ID="pwSearchInfo" runat="server" CssClass="pageViewEducation"> 
                    <asp:Panel runat="server" ID="pnSurveyPublishList" >
                    <vnnSurvey:SurveyPublishList ID="SurveyPublishList1" runat="server" />
                    
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="pwConfig" runat="server" CssClass="pageViewEducation" >
                    <asp:Panel ID="pnSurveyPublishEdit" runat="server" >
                        <vnnSurvey:SurveyPublishEdit ID="SurveyPublishEdit1" runat="server" Visible="false"/>
                    </asp:Panel>
                    
                </telerik:RadPageView> 
            </telerik:RadMultiPage>
            
                   <telerik:RadTextBox ID="txtSurveyId" runat="server"   style="display:none;"    ></telerik:RadTextBox>
                   <telerik:RadTextBox ID="txtSurveyPublishId" runat="server" Visible="true"   style="display:none;" ></telerik:RadTextBox>
          </p> 
          </asp:Panel> 
     </div> 
    
</asp:Content>

