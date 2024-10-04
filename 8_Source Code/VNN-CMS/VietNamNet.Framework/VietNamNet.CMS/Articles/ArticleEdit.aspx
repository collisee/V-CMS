<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="ArticleEdit.aspx.cs" Inherits="VietNamNet.CMS.Articles.ArticleEdit" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelArticleMedia.ascx" TagName="PanelArticleMedia" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelArticleCategory.ascx" TagName="PanelArticleCategory" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelArticleCategory2.ascx" TagName="PanelArticleCategory2" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelArticleEventItem.ascx" TagName="PanelArticleEventItem" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <style type="text/css">
        .InsertNews{background-image: url(/Images/SmallIcon/89.png) !important;}
        .InsertLogo{background-image: url(/Images/SmallIcon/14.png) !important;}
        .InsertSurvey{background-image: url(/Images/SmallIcon/53.png) !important;}
        .Rolo{background-image: url(/Images/rolo.gif) !important;}
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

            function selectImageLink1()
            {
                OpenFileExplorerDialog('<%=txtImageLink1.ClientID %>');
            }

            function previewImageLink1()
            {
                var textbox = $find('<%=txtImageLink1.ClientID %>');
                if (textbox && textbox.get_value) window.open(textbox.get_value());
            }

            function selectImageLink2()
            {
                OpenFileExplorerDialog('<%=txtImageLink2.ClientID %>');
            }

            function previewImageLink2()
            {
                var textbox = $find('<%=txtImageLink2.ClientID %>');
                if (textbox && textbox.get_value) window.open(textbox.get_value());
            }

            function selectImageLink3()
            {
                OpenFileExplorerDialog('<%=txtImageLink3.ClientID %>');
            }

            function previewImageLink3()
            {
                var textbox = $find('<%=txtImageLink3.ClientID %>');
                if (textbox && textbox.get_value) window.open(textbox.get_value());
            }

            function selectImageLink4()
            {
                OpenFileExplorerDialog('<%=txtImageLink4.ClientID %>');
            }

            function previewImageLink4()
            {
                var textbox = $find('<%=txtImageLink4.ClientID %>');
                if (textbox && textbox.get_value) window.open(textbox.get_value());
            }

            function selectImageLink5()
            {
                OpenFileExplorerDialog('<%=txtImageLink5.ClientID %>');
            }

            function previewImageLink5()
            {
                var textbox = $find('<%=txtImageLink5.ClientID %>');
                if (textbox && textbox.get_value) window.open(textbox.get_value());
            }

        </script>
        
        <script type="text/javascript">
            
            function setRoloNews(news){
                //set title
                var title = $find('<%=txtName.ClientID %>');
                if (title && title.set_value) title.set_value(news.title);
                
                //set image
                var image = $find('<%=txtImageLink.ClientID %>');
                if (image && image.set_value) image.set_value(news.image);
                
                //set source
                var source = $find('<%=txtTitle.ClientID %>');
                if (source && source.set_value) source.set_value(news.source);
                
                //set lead
                var lead = $find('<%=radEditorLead.ClientID %>');
                if (lead && lead.pasteHtml) lead.set_html(news.lead);
                
                //set content
                var content = $find('<%=radEditorMsgContent.ClientID %>');
                if (content && content.pasteHtml){
                    var html = '';
                    if (news.image) html = '<img align="left" style="margin:0 10px 10px 0;" src="' + news.image +'" />';
                    content.set_html(html + news.content);
                }
                
                //check lead
                checkWords(lead, '#counter');
            }
        </script>

        <script type="text/javascript" src="Scripts/article.js"></script>
        
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
            <telerik:AjaxSetting AjaxControlID="cmbIsMember">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlAuthor" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbUser" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlMedia">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlMedia" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlCategory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlCategory" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlEvent">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlEvent" />
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
                            <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/9.png" Text="Bi&#234;n tập" CommandName="Editted">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/73.png" Text="Từ chối bi&#234;n tập" CommandName="Rejected">
                            </telerik:RadToolBarButton>
                        </Buttons>
                    </telerik:RadToolBarDropDown>
                    <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    <telerik:RadToolBarDropDown runat="server" Text="Tr&#236;nh b&#224;y - So&#225;t lỗi">
                        <Buttons>
                            <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/9.png" Text="Tr&#236;nh b&#224;y so&#225;t lỗi" CommandName="Corrected">
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
                            <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/10.png" Text="Xuất bản và Chấm nhuận bút" CommandName="PublishedAndRoyalty">
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
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" SelectedIndex="1">
                <Tabs>
                    <telerik:RadTab Text="Thông tin chung"></telerik:RadTab>
                    <telerik:RadTab Text="Nội dung tin bài"></telerik:RadTab>
                    <telerik:RadTab Text="Thông tin xuất bản"></telerik:RadTab>
                    <telerik:RadTab Text="Các file media"></telerik:RadTab>
                    <telerik:RadTab Text="Tin sự kiện"></telerik:RadTab>
                    <telerik:RadTab Text="Thông tin phụ"></telerik:RadTab>
                    <telerik:RadTab Text="Các phiên bản bài viết"></telerik:RadTab>
                    <telerik:RadTab Text="Lịch sử bài viết"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="1">
                <telerik:RadPageView ID="rpvCommonInfo" runat="server">
                    <p>
                        <asp:Label ID="lblStatusLabel" runat="server" CssClass="label w150" Text="Trạng thái:"></asp:Label>
                        <asp:Label ID="lblStatus" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblArticleTypeLabel" runat="server" CssClass="label w150" Text="Loại bài viết:"></asp:Label>
                        <telerik:RadComboBox ID="cmbArticleType" runat="server" Width="454px" DataTextField="Name" DataValueField="Id">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                        </telerik:RadComboBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblArticleContentTypeLabel" runat="server" CssClass="label w150" Text="Kiểu bài viết:"></asp:Label>
                        <telerik:RadComboBox ID="cmbArticleContentType" runat="server" Width="454px" DataTextField="Name" DataValueField="Id">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                        </telerik:RadComboBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblTotalViewLabel" runat="server" CssClass="label w150" Text="Số lượt xem:"></asp:Label>
                        <telerik:RadNumericTextBox ID="txtTotalView" runat="server" MinValue="0" Value="0" Width="450px" CssClass="right">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblShowCommentLabel" runat="server" CssClass="label w150" Text="Phản hồi trong bài:"></asp:Label>
                        <telerik:RadComboBox ID="cmbShowComment" runat="server" Width="454px">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                            <Items>
                                <telerik:RadComboBoxItem Text="Hiển thị phản hồi" Value="1" runat="server" />
                                <telerik:RadComboBoxItem Text="Ẩn phản hồi" Value="0" runat="server" />
                            </Items>
                        </telerik:RadComboBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblIsMemberLabel" runat="server" CssClass="label w150" Text="Tác giả:"></asp:Label>
                        <telerik:RadComboBox ID="cmbIsMember" runat="server" Width="454px" AutoPostBack="True" OnSelectedIndexChanged="cmbIsMember_SelectedIndexChanged">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                            <Items>
                                <telerik:RadComboBoxItem Text="Ph&#243;ng vi&#234;n" Value="1" runat="server" />
                                <telerik:RadComboBoxItem Text="Cộng t&#225;c vi&#234;n" Value="0" runat="server" />
                            </Items>
                        </telerik:RadComboBox>
                        <br class="clear" />
                    </p>
                    <asp:Panel ID="pnlAuthor" runat="server">
                        <asp:PlaceHolder ID="plhMember" runat="server">
                            <p>
                                <asp:Label ID="lblGroupLabel" runat="server" CssClass="label w150" Text="Nhóm tác giả:"></asp:Label>
                                <telerik:RadComboBox ID="cmbGroup" runat="server" Width="454px" DataTextField="Name" DataValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="cmbGroup_SelectedIndexChanged">
                                    <CollapseAnimation Duration="200" Type="OutQuint" />
                                </telerik:RadComboBox>
                                <br class="clear" />
                            </p>
                            <p>
                                <asp:Label ID="lblUserLabel" runat="server" CssClass="label w150" Text="Tên tác giả:"></asp:Label>
                                <telerik:RadComboBox ID="cmbUser" runat="server" Width="454px" DataTextField="Name" DataValueField="Id">
                                    <CollapseAnimation Duration="200" Type="OutQuint" />
                                </telerik:RadComboBox>
                                <br class="clear" />
                            </p>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="plhNotMember" runat="server">
                            <p>
                                <asp:Label ID="lblCollaboratorLabel" runat="server" CssClass="label w150" Text="Tên tác giả:"></asp:Label>
                                <telerik:RadComboBox ID="cmbCollaborator" runat="server" Width="454px" DataTextField="Name" DataValueField="Id"
                                    AllowCustomText="True" EmptyMessage="Nhập tên hoặc lựa chọn Cộng tác viên...">
                                    <CollapseAnimation Duration="200" Type="OutQuint" />
                                </telerik:RadComboBox>
                                <br class="clear" />
                            </p>
                            <p>
                                <asp:Label ID="lblAuthorInfoLabel" runat="server" CssClass="label w150" Text="Thông tin tác giả:"></asp:Label>
                                <telerik:RadTextBox ID="txtAuthorInfo" runat="server" Width="450px" Height="100px" TextMode="MultiLine" MaxLength="4000"></telerik:RadTextBox>
                                <br class="clear" />
                            </p>
                        </asp:PlaceHolder>
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvArticle" runat="server">
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
                    
                    <br />
                    <p>
                        <asp:Label ID="lblLeadLabel" runat="server" Text="Trích dẫn:"></asp:Label>
                        <asp:Label ID="lblLeadError" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                        <span id="counter" class="red" style="display:none;">Trích dẫn không được vượt quá 50 từ hoặc 250 ký tự!</span>
                    </p>
                    <telerik:RadEditor ID="radEditorLead" runat="server" EditModes="All"
                        Height="250px" Width="725px" Font-Names="Arial" Font-Size="12px"
                        OnClientLoad="OnClientLoad" OnClientCommandExecuted="OnClientCommandExecuted" StripFormattingOnPaste="All">
                      <Modules>
                            <telerik:EditorModule Name="RadEditorStatistics" ScriptFile="" />
                            <telerik:EditorModule Name ="RadEditorDomInspector" ScriptFile="" />
                        </Modules> 
                        <Tools>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="InsertNews" Text="Ch&#232;n tin b&#224;i li&#234;n quan" />
                                <telerik:EditorTool Name="InsertLogo" Text="Ch&#232;n logo" />
                                <telerik:EditorTool Name="Rolo" Text="Tin Rolo" />
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
                        <Content>
</Content>
                    </telerik:RadEditor>
                    <p>
                        <asp:Label ID="lblDetailLabel" runat="server" Text="Nội dung:"></asp:Label>
                        <asp:Label ID="lblDetailError" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <br class="clear" />
                    </p>
                    <telerik:RadEditor ID="radEditorMsgContent" runat="server" EditModes="All"
                        Height="500px" Width="725px" Font-Names="Arial" Font-Size="11px">
                      <Modules>
                            <telerik:EditorModule Name="RadEditorStatistics" ScriptFile="" />
                            <telerik:EditorModule Name ="RadEditorDomInspector" ScriptFile="" />
                            <telerik:EditorModule Name="RadEditorNodeInspector" ScriptFile="" />
                        </Modules> 
                        <Tools>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="InsertNews" Text="Ch&#232;n tin b&#224;i li&#234;n quan" />
                                <telerik:EditorTool Name="InsertLogo" Text="Ch&#232;n logo" />
                                <telerik:EditorTool Name="InsertSurvey" Text="Ch&#232;n thăm d&#242;" />
                                <telerik:EditorTool Name="Rolo" Text="Tin Rolo" />
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
                                <telerik:EditorTool Name="ForeColor" />
                                <telerik:EditorTool Name="BackColor" />
                                <telerik:EditorTool Name="ApplyClass" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="FontName" />
                                <telerik:EditorTool Name="RealFontSize" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="InsertTable" />
                                <telerik:EditorTool Name="InsertSymbol" />
                                <telerik:EditorSeparator />
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
                        <CssFiles>
                            <telerik:EditorCssFile Value="Styles/article.css" />
                        </CssFiles>
                        <Content>
</Content>
                    </telerik:RadEditor>
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
                        <asp:Button ID="btnReject" runat="server" Text="Từ chối" Visible="false" OnClick="btnReject_Click" />
                        <br class="clear" />
                    </p>
                    <hr />
                    <asp:Panel ID="pnlCategory" runat="server">
                        <asp:Label ID="lblCategoriesError" runat="server" Text="*" CssClass="red" Visible="false"></asp:Label>
                        <uc:PanelArticleCategory ID="pnlArticleCategory" runat="server" EditOption="1" />
                        <uc:PanelArticleCategory2 ID="pnlArticleCategory2" runat="server" EditOption="1" />
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvMedia" runat="server">
                    <asp:Panel ID="pnlMedia" runat="server">
                        <uc:PanelArticleMedia ID="pnlArticleMedia" runat="server" EditOption="1" />
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvEvent" runat="server">
                    <asp:Panel ID="pnlEvent" runat="server">
                        <uc:PanelArticleEventItem ID="pnlArticleEventItem" runat="server" EditOption="1" />
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvSubInfo" runat="server">
                    <p>
                        <asp:Label ID="lblSubTitle1Label" runat="server" CssClass="label w150" Text="Tiêu đề phụ 1:"></asp:Label>
                        <telerik:RadTextBox ID="txtSubTitle1" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSubTitle2Label" runat="server" CssClass="label w150" Text="Tiêu đề phụ 2:"></asp:Label>
                        <telerik:RadTextBox ID="txtSubTitle2" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSubTitle3Label" runat="server" CssClass="label w150" Text="Tiêu đề phụ 3:"></asp:Label>
                        <telerik:RadTextBox ID="txtSubTitle3" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSubTitle4Label" runat="server" CssClass="label w150" Text="Tiêu đề phụ 4:"></asp:Label>
                        <telerik:RadTextBox ID="txtSubTitle4" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSubTitle5Label" runat="server" CssClass="label w150" Text="Tiêu đề phụ 5:"></asp:Label>
                        <telerik:RadTextBox ID="txtSubTitle5" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSubTitle6Label" runat="server" CssClass="label w150" Text="Tiêu đề phụ 6:"></asp:Label>
                        <telerik:RadTextBox ID="txtSubTitle6" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblImageLink1Label" runat="server" CssClass="label w150" Text="Hình ảnh phụ 1:"></asp:Label>
                        <telerik:RadTextBox ID="txtImageLink1" runat="server" Width="450px" MaxLength="255">
                        </telerik:RadTextBox>
                        <img alt="Chọn Hình ảnh phụ 1" title="Chọn Hình ảnh phụ 1" class="cpointer" src="/Images/SmallIcon/40.png" onclick="selectImageLink1()" />
                        <img alt="Xem Hình ảnh phụ 1" title="Xem Hình ảnh phụ 1" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewImageLink1()" />
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblImageLink2Label" runat="server" CssClass="label w150" Text="Hình ảnh phụ 2:"></asp:Label>
                        <telerik:RadTextBox ID="txtImageLink2" runat="server" Width="450px" MaxLength="255">
                        </telerik:RadTextBox>
                        <img alt="Chọn Hình ảnh phụ 2" title="Chọn Hình ảnh phụ 2" class="cpointer" src="/Images/SmallIcon/40.png" onclick="selectImageLink2()" />
                        <img alt="Xem Hình ảnh phụ 2" title="Xem Hình ảnh phụ 2" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewImageLink2()" />
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblImageLink3Label" runat="server" CssClass="label w150" Text="Hình ảnh phụ 3:"></asp:Label>
                        <telerik:RadTextBox ID="txtImageLink3" runat="server" Width="450px" MaxLength="255">
                        </telerik:RadTextBox>
                        <img alt="Chọn Hình ảnh phụ 3" title="Chọn Hình ảnh phụ 3" class="cpointer" src="/Images/SmallIcon/40.png" onclick="selectImageLink3()" />
                        <img alt="Xem Hình ảnh phụ 3" title="Xem Hình ảnh phụ 3" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewImageLink3()" />
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblImageLink4Label" runat="server" CssClass="label w150" Text="Hình ảnh phụ 4:"></asp:Label>
                        <telerik:RadTextBox ID="txtImageLink4" runat="server" Width="450px" MaxLength="255">
                        </telerik:RadTextBox>
                        <img alt="Chọn Hình ảnh phụ 4" title="Chọn Hình ảnh phụ 4" class="cpointer" src="/Images/SmallIcon/40.png" onclick="selectImageLink4()" />
                        <img alt="Xem Hình ảnh phụ 4" title="Xem Hình ảnh phụ 4" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewImageLink4()" />
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblImageLink5Label" runat="server" CssClass="label w150" Text="Hình ảnh phụ 5:"></asp:Label>
                        <telerik:RadTextBox ID="txtImageLink5" runat="server" Width="450px" MaxLength="255">
                        </telerik:RadTextBox>
                        <img alt="Chọn Hình ảnh phụ 5" title="Chọn Hình ảnh phụ 5" class="cpointer" src="/Images/SmallIcon/40.png" onclick="selectImageLink5()" />
                        <img alt="Xem Hình ảnh phụ 5" title="Xem Hình ảnh phụ 5" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewImageLink5()" />
                        <br class="clear" />
                    </p>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvVersions" runat="server">
                    <br />
                    <telerik:RadGrid ID="radGriVersions" runat="server" AllowCustomPaging="False" AutoGenerateColumns="False" GridLines="None">
                        <MasterTableView ClientDataKeyNames="Id" DataKeyNames="Id" GroupLoadMode="Client" NoMasterRecordsText="Kh&#244;ng c&#243; phiên bản n&#224;o.">
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn>
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="STT">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <%#Container.ItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" Width="40px" Font-Bold="True" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="VersionId" HeaderText="Phiên bản" UniqueName="VersionId">
                                    <HeaderStyle Font-Bold="True" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Name" HeaderText="Tiêu đề" UniqueName="Name">
                                    <HeaderStyle Font-Bold="True" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Last_Modified_By_FullName" HeaderText="Người tạo" UniqueName="Last_Modified_By_FullName">
                                    <HeaderStyle Font-Bold="True" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Last_Modified_At" HeaderText="Ngày tạo" UniqueName="Last_Modified_At">
                                    <HeaderStyle Font-Bold="True" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Xem">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <a href="ArticleVersionDisplay.aspx?DocId=<%#DataBinder.Eval(Container.DataItem, "Id")%>" target="_blank">
                                            <img alt="Xem" title="Xem" src="/Images/LargeIcon/zoom.png" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="120px" Font-Bold="True" />
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="true">
                            <Resizing AllowColumnResize="True" />
                        </ClientSettings>
                        <FilterMenu EnableTheming="True">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                        </FilterMenu>
                    </telerik:RadGrid>
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
