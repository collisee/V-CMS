<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="ArticleDisplay.aspx.cs" Inherits="VietNamNet.CMS.Articles.ArticleDisplay" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelArticleMedia.ascx" TagName="PanelArticleMedia" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelArticleCategory.ascx" TagName="PanelArticleCategory" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelArticleEventItem.ascx" TagName="PanelArticleEventItem" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">

    <telerik:RadScriptBlock runat="server" ID="scriptBlock">

        <script type="text/javascript">
                
            function previewImageLink()
            {
                var hidden = $get('<%=hidImageLink.ClientID %>');
                if (hidden && hidden.value) window.open(hidden.value);
            }

            function previewImageLink1()
            {
                var hidden = $get('<%=hidImageLink1.ClientID %>');
                if (hidden && hidden.value) window.open(hidden.value);
            }

            function previewImageLink2()
            {
                var hidden = $get('<%=hidImageLink2.ClientID %>');
                if (hidden && hidden.value) window.open(hidden.value);
            }

            function previewImageLink3()
            {
                var hidden = $get('<%=hidImageLink3.ClientID %>');
                if (hidden && hidden.value) window.open(hidden.value);
            }

            function previewImageLink4()
            {
                var hidden = $get('<%=hidImageLink4.ClientID %>');
                if (hidden && hidden.value) window.open(hidden.value);
            }

            function previewImageLink5()
            {
                var hidden = $get('<%=hidImageLink5.ClientID %>');
                if (hidden && hidden.value) window.open(hidden.value);
            }

        </script>
        
    </telerik:RadScriptBlock>
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
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="pd05">
        <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick" OnClientButtonClicking="radToolBarDefault_ClientButtonClicking">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/newitem.gif" CommandName="AddNew"
                        Text="Tạo mới" AccessKey="N">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/edititem.gif" CommandName="Edit"
                        Text="Sửa" AccessKey="E">
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
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/delete.gif" CommandName="Delete"
                        Text="Xóa" AccessKey="D">
                    </telerik:RadToolBarButton>
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
            <asp:Label ID="lblMessage" runat="server" CssClass="blue" Text="" Visible="false"></asp:Label>
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
                        <asp:Label ID="lblArticleType" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblArticleContentTypeLabel" runat="server" CssClass="label w150" Text="Kiểu bài viết:"></asp:Label>
                        <asp:Label ID="lblArticleContentType" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblTotalViewLabel" runat="server" CssClass="label w150" Text="Số lượt xem:"></asp:Label>
                        <asp:Label ID="lblTotalView" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblIsMemberLabel" runat="server" CssClass="label w150" Text="Tác giả:"></asp:Label>
                        <asp:Label ID="lblIsMember0" runat="server" CssClass="label w450" Text="Cộng tác viên"></asp:Label>
                        <asp:Label ID="lblIsMember1" runat="server" CssClass="label w450" Text="Phóng viên"></asp:Label>
                        <br class="clear" />
                    </p>
                    <asp:Panel ID="pnlAuthor" runat="server">
                        <asp:PlaceHolder ID="plhMember" runat="server">
                            <p>
                                <asp:Label ID="lblUserLabel" runat="server" CssClass="label w150" Text="Tên tác giả:"></asp:Label>
                                <asp:Label ID="lblUser" runat="server" CssClass="label w450" Text=""></asp:Label>
                                <br class="clear" />
                            </p>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="plhNotMember" runat="server">
                            <p>
                                <asp:Label ID="lblCollaboratorLabel" runat="server" CssClass="label w150" Text="Tên tác giả:"></asp:Label>
                                <asp:Label ID="lblCollaborator" runat="server" CssClass="label w450" Text=""></asp:Label>
                                <br class="clear" />
                            </p>
                            <p>
                                <asp:Label ID="lblAuthorInfoLabel" runat="server" CssClass="label w150" Text="Thông tin tác giả:"></asp:Label>
                                <asp:Label ID="lblAuthorInfo" runat="server" CssClass="label w450" Text=""></asp:Label>
                                <br class="clear" />
                            </p>
                        </asp:PlaceHolder>
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvArticle" runat="server">
                    <p>
                        <asp:Label ID="lblNameLabel" runat="server" CssClass="label w150" Text="Tiêu đề:"></asp:Label>
                        <asp:Label ID="lblName" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblTitleLabel" runat="server" CssClass="label w150" Text="Tiêu đề phụ:"></asp:Label>
                        <asp:Label ID="lblTitle" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblImageLinkLabel" runat="server" CssClass="label w150" Text="Hình ảnh đại diện:"></asp:Label>
                        <asp:Label ID="lblImageLink" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <asp:HiddenField ID="hidImageLink" runat="server"></asp:HiddenField>
                        <img alt="Xem Hình ảnh đại diện" title="Xem Hình ảnh đại diện" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewImageLink()" />
                        <br class="clear" />
                    </p>
                    
                    <br />
                    <p>
                        <asp:Label ID="lblLeadLabel" runat="server" Text="Trích dẫn:"></asp:Label>
                        <br class="clear" />
                    </p>
                    <asp:Label ID="lblLead" runat="server" Text=""></asp:Label>
                    <p>
                        <asp:Label ID="lblDetailLabel" runat="server" Text="Nội dung:"></asp:Label>
                        <br class="clear" />
                    </p>
                    <asp:Label ID="lblDetail" runat="server" Text=""></asp:Label>
                    <br class="clear" />
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvPublish" runat="server">
                    <p>
                        <asp:Label ID="lblPublishDateLabel" runat="server" CssClass="label w150" Text="Ngày giờ xuất bản:"></asp:Label>
                        <asp:Label ID="lblPublishDate" runat="server" CssClass="label w450" Text=""></asp:Label>
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
                        <uc:PanelArticleCategory ID="pnlArticleCategory" runat="server" EditOption="0" />
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvMedia" runat="server">
                    <asp:Panel ID="pnlMedia" runat="server">
                        <uc:PanelArticleMedia ID="pnlArticleMedia" runat="server" EditOption="0" />
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvEvent" runat="server">
                    <asp:Panel ID="pnlEvent" runat="server">
                        <uc:PanelArticleEventItem ID="pnlArticleEventItem" runat="server" EditOption="0" />
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvSubInfo" runat="server">
                    <p>
                        <asp:Label ID="lblSubTitle1Label" runat="server" CssClass="label w150" Text="Tiêu đề phụ 1:"></asp:Label>
                        <asp:Label ID="lblSubTitle1" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSubTitle2Label" runat="server" CssClass="label w150" Text="Tiêu đề phụ 2:"></asp:Label>
                        <asp:Label ID="lblSubTitle2" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSubTitle3Label" runat="server" CssClass="label w150" Text="Tiêu đề phụ 3:"></asp:Label>
                        <asp:Label ID="lblSubTitle3" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSubTitle4Label" runat="server" CssClass="label w150" Text="Tiêu đề phụ 4:"></asp:Label>
                        <asp:Label ID="lblSubTitle4" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSubTitle5Label" runat="server" CssClass="label w150" Text="Tiêu đề phụ 5:"></asp:Label>
                        <asp:Label ID="lblSubTitle5" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblSubTitle6Label" runat="server" CssClass="label w150" Text="Tiêu đề phụ 6:"></asp:Label>
                        <asp:Label ID="lblSubTitle6" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblImageLink1Label" runat="server" CssClass="label w150" Text="Hình ảnh phụ 1:"></asp:Label>
                        <asp:Label ID="lblImageLink1" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <asp:HiddenField ID="hidImageLink5" runat="server"></asp:HiddenField>
                        <img alt="Xem Hình ảnh phụ 1" title="Xem Hình ảnh phụ 1" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewImageLink1()" />
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblImageLink2Label" runat="server" CssClass="label w150" Text="Hình ảnh phụ 2:"></asp:Label>
                        <asp:Label ID="lblImageLink2" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <asp:HiddenField ID="hidImageLink2" runat="server"></asp:HiddenField>
                        <img alt="Xem Hình ảnh phụ 2" title="Xem Hình ảnh phụ 2" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewImageLink2()" />
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblImageLink3Label" runat="server" CssClass="label w150" Text="Hình ảnh phụ 3:"></asp:Label>
                        <asp:Label ID="lblImageLink3" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <asp:HiddenField ID="hidImageLink3" runat="server"></asp:HiddenField>
                        <img alt="Xem Hình ảnh phụ 3" title="Xem Hình ảnh phụ 3" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewImageLink3()" />
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblImageLink4Label" runat="server" CssClass="label w150" Text="Hình ảnh phụ 4:"></asp:Label>
                        <asp:Label ID="lblImageLink4" runat="server" CssClass="label w450" Text=""></asp:Label>
                        <asp:HiddenField ID="hidImageLink4" runat="server"></asp:HiddenField>
                        <img alt="Xem Hình ảnh phụ 4" title="Xem Hình ảnh phụ 4" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewImageLink4()" />
                        <br class="clear" />
                    </p>
                    <p>
                        <asp:Label ID="lblImageLink5Label" runat="server" CssClass="label w150" Text="Hình ảnh phụ 5:"></asp:Label>
                        <asp:HiddenField ID="hidImageLink1" runat="server"></asp:HiddenField>
                        <asp:Label ID="lblImageLink5" runat="server" CssClass="label w450" Text=""></asp:Label>
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
