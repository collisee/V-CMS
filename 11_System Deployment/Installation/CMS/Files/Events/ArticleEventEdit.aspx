<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="ArticleEventEdit.aspx.cs" Inherits="VietNamNet.CMS.Events.ArticleEventEdit" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelArticleEventItem.ascx" TagName="PanelArticleEventItem" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelArticleEventCategory.ascx" TagName="PanelArticleEventCategory" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <style type="text/css">
        .InsertNews{background-image: url(/Images/SmallIcon/89.png) !important;}
        .InsertLogo{background-image: url(/Images/SmallIcon/14.png) !important;}
        .InsertSurvey{background-image: url(/Images/SmallIcon/53.png) !important;}
    </style>

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

            function selectImageLink()
            {
                OpenFileExplorerDialog('<%=txtImageLink.ClientID %>');
            }

            function previewImageLink()
            {
                var textbox = $find('<%=txtImageLink.ClientID %>');
                if (textbox && textbox.get_value) window.open(textbox.get_value());
            }

        </script>

        <script type="text/javascript" src="../Articles/Scripts/article.js"></script>
        
    </telerik:RadScriptBlock>
    <telerik:RadWindow runat="server" Width="680px" Height="550px" VisibleStatusbar="false"
        Behaviors="Close,Move" NavigateUrl="/FileManager.aspx" ID="FileExplorerWindow" Modal="True">
    </telerik:RadWindow>
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="pnlToolbar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlToolbar" />
                    <telerik:AjaxUpdatedControl ControlID="pnlForm" />
                    <telerik:AjaxUpdatedControl ControlID="pnlAuditTrail" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlItems">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlItems" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlCategory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlCategory" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="pd05">
        <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveitem.gif" CommandName="Save"
                        Text="Lưu" AccessKey="S">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" Text="Gửi bi&#234;n tập" CommandName="Submitted">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    <telerik:RadToolBarDropDown runat="server" Text="Bi&#234;n tập">
                        <Buttons>
                            <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/9.png" Text="Đ&#227; bi&#234;n tập" CommandName="Editted">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/73.png" Text="Từ chối bi&#234;n tập" CommandName="Rejected">
                            </telerik:RadToolBarButton>
                        </Buttons>
                    </telerik:RadToolBarDropDown>
                    <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    <telerik:RadToolBarDropDown runat="server" Text="Tr&#236;nh b&#224;y - So&#225;t lỗi">
                        <Buttons>
                            <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/9.png" Text="Đ&#227; tr&#236;nh b&#224;y so&#225;t lỗi" CommandName="Corrected">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/73.png" Text="Từ chối tr&#236;nh b&#224;y so&#225;t lỗi" CommandName="Rejected">
                            </telerik:RadToolBarButton>
                        </Buttons>
                    </telerik:RadToolBarDropDown>
                    <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    <telerik:RadToolBarDropDown runat="server" Text="Xuất bản">
                        <Buttons>
                            <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/10.png" Text="Xuất bản" CommandName="Published">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/12.png" Text="Dừng xuất bản" CommandName="Stopped">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/73.png" Text="Từ chối xuất bản" CommandName="Rejected">
                            </telerik:RadToolBarButton>
                        </Buttons>
                    </telerik:RadToolBarDropDown>
                    <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/goback1.gif" CommandName="GoBacktoView"
                        Text="Quay lại" AccessKey="G">
                    </telerik:RadToolBarButton>
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
            <uc:ErrorMessage ID="ErrorMessage1" runat="server" Visible="false" />
            <br />
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" SelectedIndex="0">
                <Tabs>
                    <telerik:RadTab Text="Nội dung sự kiện"></telerik:RadTab>
                    <telerik:RadTab Text="Các bài viết liên quan"></telerik:RadTab>
                    <telerik:RadTab Text="Thông tin xuất bản"></telerik:RadTab>
                    <telerik:RadTab Text="Lịch sử sự kiện"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="rpvArticleEvent" runat="server">
                    <p>
                        <asp:Label ID="lblStatusLabel" runat="server" CssClass="label w150" Text="Trạng thái:"></asp:Label>
                        <asp:Label ID="lblStatus" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblNameLabel" runat="server" CssClass="label w150" Text="Tiêu đề:"></asp:Label>
                        <telerik:RadTextBox ID="txtName" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <asp:Label ID="lblNameError" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblTitleLabel" runat="server" CssClass="label w150" Text="Tiêu đề phụ:"></asp:Label>
                        <telerik:RadTextBox ID="txtTitle" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblImageLinkLabel" runat="server" CssClass="label w150" Text="Hình ảnh đại diện:"></asp:Label>
                        <telerik:RadTextBox ID="txtImageLink" runat="server" Width="450px" MaxLength="255">
                        </telerik:RadTextBox>
                        <img alt="Chọn Hình ảnh đại diện" title="Chọn Hình ảnh đại diện" class="cpointer" src="/Images/SmallIcon/40.png" onclick="selectImageLink()" />
                        <img alt="Xem Hình ảnh đại diện" title="Xem Hình ảnh đại diện" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewImageLink()" />
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblTotalViewLabel" runat="server" CssClass="label w150" Text="Số lượt xem:"></asp:Label>
                        <telerik:RadNumericTextBox ID="txtTotalView" runat="server" MinValue="0" Value="0" Width="450px" CssClass="right">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        <br class="clear" />
                    </p>
                    
                    <br />
                    <p>
                        <asp:Label ID="lblLeadLabel" runat="server" Text="Trích dẫn:"></asp:Label>
                        <asp:Label ID="lblLeadError" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                        <span id="counter" class="red" style="display:none;">Trích dẫn không được vượt quá 50 từ hoặc 250 ký tự!</span>
                    </p>
                    <telerik:RadEditor ID="radEditorLead" runat="server" EditModes="All"
                        Height="250px" Width="725px" Font-Names="Arial" Font-Size="12pt"
                        OnClientLoad="OnClientLoad" OnClientCommandExecuted="OnClientCommandExecuted">
                      <Modules>
                            <telerik:EditorModule Name="RadEditorStatistics" ScriptFile="" />
                            <telerik:EditorModule Name ="RadEditorDomInspector" ScriptFile="" />
                        </Modules> 
                        <Tools>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="InsertNews" Text="Chèn tin bài liên quan" />
                                <telerik:EditorTool Name="InsertLogo" Text="Chèn logo" />
                                <telerik:EditorTool Name="Print" />
                                <telerik:EditorTool Name="FindAndReplace" />
                                <telerik:EditorTool Name="Cut" />
                                <telerik:EditorTool Name="Copy" />
                                <telerik:EditorTool Name="Paste" />
                                <telerik:EditorTool Name="PastePlainText" />
                                <telerik:EditorTool Name="FormatStripper" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="Undo" ShortCut="CTRL+Z" />
                                <telerik:EditorTool Name="Redo" ShortCut="CTRL+Y" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="ImageManager" ShortCut="CTRL+M" Text="ImageManager with ImageEditor" />
                                <telerik:EditorTool Name="LinkManager" />
                                <telerik:EditorTool Name="Unlink" Text="Remove link" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="Bold" />
                                <telerik:EditorTool Name="Italic" />
                                <telerik:EditorTool Name="Underline" />
                                <telerik:EditorTool Name="JustifyCenter" />
                                <telerik:EditorTool Name="JustifyFull" />
                                <telerik:EditorTool Name="JustifyLeft" />
                                <telerik:EditorTool Name="JustifyNone" />
                                <telerik:EditorTool Name="JustifyRight" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="Indent" />
                                <telerik:EditorTool Name="Outdent" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="InsertOrderedList" />
                                <telerik:EditorTool Name="InsertUnorderedList" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="ConvertToLower" ShortCut="CTRL+SHIFT+L" />
                                <telerik:EditorTool Name="ConvertToUpper" ShortCut="CTRL+SHIFT+U" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="InsertSymbol" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="ForeColor" />
                                <telerik:EditorTool Name="BackColor" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="FontName" />
                                <telerik:EditorTool Name="RealFontSize" />
                            </telerik:EditorToolGroup>
                        </Tools>
                        <ImageManager MaxUploadFileSize="10240" SearchPatterns="*.gif,*.jpg,*.jpeg,*.jpe,*.tiff,*.tif,*.bmp,*.png,*.zip" />
                        <DocumentManager ViewPaths="~/Documents/" MaxUploadFileSize="10240" SearchPatterns="*.*" />
                        <ContextMenus>
                            <telerik:EditorContextMenu TagName="IMG">
                                <telerik:EditorTool Name="Cut" />
                                <telerik:EditorTool Name="Copy" />
                                <telerik:EditorTool Name="Paste" />
                            </telerik:EditorContextMenu>
                            <telerik:EditorContextMenu TagName="P">
                                <telerik:EditorTool Name="JustifyLeft" />
                                <telerik:EditorTool Name="JustifyCenter" />
                                <telerik:EditorTool Name="JustifyRight" />
                                <telerik:EditorTool Name="JustifyFull" />
                            </telerik:EditorContextMenu>
                        </ContextMenus>
                        <Content></Content>
                    </telerik:RadEditor>
                    <p>
                        <asp:Label ID="lblDetailLabel" runat="server" Text="Nội dung:"></asp:Label>
                        <asp:Label ID="lblDetailError" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                    </p>
                    <telerik:RadEditor ID="radEditorMsgContent" runat="server" EditModes="All"
                        Height="500px" Width="725px" Font-Names="Arial"
                        Font-Size="12pt">
                      <Modules>
                            <telerik:EditorModule Name="RadEditorStatistics" ScriptFile="" />
                            <telerik:EditorModule Name ="RadEditorDomInspector" ScriptFile="" />
                            <telerik:EditorModule Name="RadEditorNodeInspector" ScriptFile="" />
                        </Modules> 
                        <Tools>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="InsertNews" Text="Chèn tin bài liên quan" />
                                <telerik:EditorTool Name="InsertLogo" Text="Chèn logo" />
                                <telerik:EditorTool Name="InsertSurvey" Text="Chèn thăm dò" />
                                <telerik:EditorTool Name="Print" />
                                <telerik:EditorTool Name="FindAndReplace" />
                                <telerik:EditorTool Name="Cut" />
                                <telerik:EditorTool Name="Copy" />
                                <telerik:EditorTool Name="Paste" />
                                <telerik:EditorTool Name="PastePlainText" />
                                <telerik:EditorTool Name="PasteFromWord" />
                                <telerik:EditorTool Name="PasteAsHtml" />
                                <telerik:EditorTool Name="FormatStripper" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="Undo" ShortCut="CTRL+Z" />
                                <telerik:EditorTool Name="Redo" ShortCut="CTRL+Y" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="ImageManager" ShortCut="CTRL+M" Text="ImageManager with ImageEditor" />
                                <telerik:EditorTool Name="FlashManager" />
                                <telerik:EditorTool Name="MediaManager" />
                                <telerik:EditorTool Name="DocumentManager" />
                                <telerik:EditorTool Name="TemplateManager" />
                                <telerik:EditorTool Name="LinkManager" />
                                <telerik:EditorTool Name="Unlink" Text="Remove link" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="Bold" />
                                <telerik:EditorTool Name="Italic" />
                                <telerik:EditorTool Name="Underline" />
                                <telerik:EditorTool Name="JustifyCenter" />
                                <telerik:EditorTool Name="JustifyFull" />
                                <telerik:EditorTool Name="JustifyLeft" />
                                <telerik:EditorTool Name="JustifyNone" />
                                <telerik:EditorTool Name="JustifyRight" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="Indent" />
                                <telerik:EditorTool Name="Outdent" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="InsertOrderedList" />
                                <telerik:EditorTool Name="InsertUnorderedList" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="ConvertToLower" ShortCut="CTRL+SHIFT+L" />
                                <telerik:EditorTool Name="ConvertToUpper" ShortCut="CTRL+SHIFT+U" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="InsertTable" />
                                <telerik:EditorTool Name="InsertSymbol" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="ForeColor" />
                                <telerik:EditorTool Name="BackColor" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="FontName" />
                                <telerik:EditorTool Name="RealFontSize" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="Subscript" Text="Subscript" />
                                <telerik:EditorTool Name="Superscript" Text="Superscript" />
                                <telerik:EditorTool Name="InsertParagraph" Text="InsertParagraph" />
                                <telerik:EditorTool Name="InsertGroupbox" Text="InsertGroupbox" />
                                <telerik:EditorTool Name="InsertHorizontalRule" Text="InsertHorizontalRule" />
                                <telerik:EditorTool Name="InsertDate" Text="InsertDate" />
                                <telerik:EditorTool Name="InsertTime" Text="InsertTime" />
                                <telerik:EditorTool Name="SetImageProperties" />
                                <telerik:EditorTool Name="ImageMapDialog" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="FindAndReplace" />
                                <telerik:EditorTool Name="TableWizard" />
                                <telerik:EditorTool Name="LinkManager" />
                                <telerik:EditorTool Name="PageProperties" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="RepeatLastCommand" />
                                <telerik:EditorTool Name="Zoom" />                    
                                <telerik:EditorTool Name="ToggleScreenMode" />
                            </telerik:EditorToolGroup>
                        </Tools>
                        <ImageManager MaxUploadFileSize="102400" SearchPatterns="*.gif,*.jpg,*.jpeg,*.jpe,*.tiff,*.tif,*.bmp,*.png,*.zip" />
                        <FlashManager MaxUploadFileSize="102400" />
                        <MediaManager MaxUploadFileSize="102400" />
                        <DocumentManager ViewPaths="~/Documents/" MaxUploadFileSize="10240" SearchPatterns="*.*" />
                        <TemplateManager MaxUploadFileSize="102400" ViewPaths="~/Resources/Templates/" UploadPaths="~/Resources/Templates/" />
                        <ContextMenus>
                            <telerik:EditorContextMenu TagName="IMG">
                                <telerik:EditorTool Name="Cut" />
                                <telerik:EditorTool Name="Copy" />
                                <telerik:EditorTool Name="Paste" />
                            </telerik:EditorContextMenu>
                            <telerik:EditorContextMenu TagName="P">
                                <telerik:EditorTool Name="JustifyLeft" />
                                <telerik:EditorTool Name="JustifyCenter" />
                                <telerik:EditorTool Name="JustifyRight" />
                                <telerik:EditorTool Name="JustifyFull" />
                            </telerik:EditorContextMenu>
                        </ContextMenus>
                        <Content></Content>
                    </telerik:RadEditor>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvItems" runat="server">
                    <asp:Panel ID="pnlItems" runat="server">
                        <uc:PanelArticleEventItem ID="pnlArticleEventItem" runat="server" EditOption="1" />
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvPublish" runat="server">
                    <p>
                        <asp:Label ID="lblPublishDateLabel" runat="server" CssClass="label w150" Text="Ngày giờ xuất bản:"></asp:Label>
                        <telerik:RadDateTimePicker ID="radDpkPublishDate" runat="server" Width="200px" Culture="Vietnamese (Vietnam)" MinDate="1753-01-01">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                            </Calendar>
                            <TimeView CellSpacing="-1" Culture="Vietnamese (Vietnam)">
                            </TimeView>
                            <TimePopupButton HoverImageUrl="" ImageUrl="" />
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDateTimePicker>
                        <asp:Label ID="lblPublishDateError" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblNoteLabel" runat="server" CssClass="label w150" Text="Ghi chú:"></asp:Label>
                        <telerik:RadTextBox ID="txtNote" runat="server" Width="450px" Height="50px" TextMode="MultiLine" MaxLength="4000"></telerik:RadTextBox>
                        <asp:Label ID="lblNoteError" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                    </p>
                    <hr />
                    <asp:Panel ID="pnlCategory" runat="server">
                        <asp:Label ID="lblCategoriesError" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <uc:PanelArticleEventCategory ID="pnlArticleEventCategory" runat="server" EditOption="1" />
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvHistory" runat="server">
                    <div style="min-height: 200px;">
                        <asp:Label ID="lblHistory" runat="server"></asp:Label>
                        <br class="clear" />
                    </div>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </asp:Panel>
        <asp:Panel ID="pnlAuditTrail" runat="server" CssClass="form-editor-container">
            <uc:AuditTrail id="AuditTrail1" runat="server">
            </uc:AuditTrail>
        </asp:Panel>
    </div>
</asp:Content>
