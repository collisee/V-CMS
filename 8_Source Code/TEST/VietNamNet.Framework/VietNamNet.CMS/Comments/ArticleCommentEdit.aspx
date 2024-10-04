<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="ArticleCommentEdit.aspx.cs" Inherits="VietNamNet.CMS.Comments.ArticleCommentEdit" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <style type="text/css">
        .InsertNews{background-image: url(../Articles/Images/CustomDialog.gif) !important;}
    </style>

    <telerik:RadScriptBlock runat="server" ID="scriptBlock">

        <script type="text/javascript">

            Telerik.Web.UI.Editor.CommandList["InsertNews"] = function(commandName, editor, args)
            {
               var myCallbackFunction = function(sender, args)
               {
                    editor.pasteHtml(args.text);
               }
               editor.showExternalDialog(
                    '../Articles/PopupInsertNews.aspx', {}, 850, 500,
                    myCallbackFunction, null, 'Chọn Tin bài liên quan', true,
                    Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize,
                    false, true);
            };
            
            Telerik.Web.UI.Editor.CommandList["ImageManager"] = function(commandName, editor, args)
            {
               var myCallbackFunction = function(sender, args)
               {
                    var files = args;
                    if (!files || !files.length) return;
                    for (i = 0; i < files.length; i++)
                    {
                        if (files[i].type == 'Image')
                        {
                            var img = '<img alt="" src="' + files[i].file + '" />';
                            editor.pasteHtml(img);
                        }
                    }
               }
               editor.showExternalDialog(
                    '/FileManager.aspx', {}, 680, 550,
                    myCallbackFunction, null, 'Chọn hình ảnh', true,
                    Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Resize,
                    false, true);
            };

        </script>
        
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
                    <telerik:RadTab Text="Thông tin"></telerik:RadTab>
                    <telerik:RadTab Text="Lịch sử"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="rpvArticle" runat="server">
                    <p>
                        <asp:Label ID="lblStatusLabel" runat="server" CssClass="label w150" Text="Trạng thái:"></asp:Label>
                        <asp:Label ID="lblStatus" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <asp:HiddenField ID="hidArticleId" runat="server" />
                        <asp:HiddenField ID="hidPId" runat="server" />
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblArticleLabel" runat="server" CssClass="label w150" Text="Bài viết:"></asp:Label>
                        <asp:HyperLink ID="lnkArticle" runat="server" Target="_blank" Text=""></asp:HyperLink>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblNameLabel" runat="server" CssClass="label w150" Text="Họ tên:"></asp:Label>
                        <telerik:RadTextBox ID="txtName" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <asp:Label ID="lblNameError" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblEmailLabel" runat="server" CssClass="label w150" Text="Email:"></asp:Label>
                        <telerik:RadTextBox ID="txtEmail" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <asp:Label ID="lblEmailError" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblPhoneLabel" runat="server" CssClass="label w150" Text="Điện thoại:"></asp:Label>
                        <telerik:RadTextBox ID="txtPhone" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSubjectLabel" runat="server" CssClass="label w150" Text="Tiêu đề:"></asp:Label>
                        <telerik:RadTextBox ID="txtSubject" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <br class="clear" />
                    </p>
                    
                    <br />
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
                                <telerik:EditorTool Name="InsertNews" />
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
                        <ImageManager MaxUploadFileSize="10240" SearchPatterns="*.gif,*.jpg,*.jpeg,*.jpe,*.tiff,*.tif,*.bmp,*.png,*.zip" />
                        <FlashManager MaxUploadFileSize="10240" />
                        <MediaManager MaxUploadFileSize="10240" />
                        <DocumentManager MaxUploadFileSize="10240" />
                        <TemplateManager MaxUploadFileSize="10240" />
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
                <telerik:RadPageView ID="rpvHistory" runat="server">
                    <p>
                        <asp:Label ID="lblNoteLabel" runat="server" CssClass="label w150" Text="Ghi chú:"></asp:Label>
                        <telerik:RadTextBox ID="txtNote" runat="server" Width="450px" Height="50px" TextMode="MultiLine" MaxLength="4000"></telerik:RadTextBox>
                        <asp:Label ID="lblNoteError" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                    </p>
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
