<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="PopupInsertNews.aspx.cs" Inherits="VietNamNet.CMS.Articles.PopupInsertNews" Title="Chọn tin liên quan" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
        
    <telerik:RadScriptBlock runat="server" ID="scriptBlock">

        <script type="text/javascript">

            function getRadWindow()
            {
                if (window.radWindow) return window.radWindow;
                if (window.frameElement && window.frameElement.radWindow) return window.frameElement.radWindow;
                return null;
            }
            
            function getData()
            {
                var grid = $find("<%=radGridSelected.ClientID %>");
                if (!grid) return '';
                
                var table = grid.get_masterTableView();
                if (!table) return '';
                
                var items = table.get_dataItems();
                if (!items) return '';
                
                var v = '';
                for (var i = 0; i < items.length; i++)
                {
                    var articleId = items[i].getDataKeyValue('Id');
                    var articleName = items[i].getDataKeyValue('Name');
                    var link = items[i].getDataKeyValue('Link');
                    v += '<a href="' + link + '">' + articleName + '</a>' + '<br />\r\n';
                }
                
                return '<div>' + v + '</div>';
            }
            
            function insertNews(){
                //bind data return
                var arg = {text: ''};
                
                //getData
                arg.text = getData();
                
                //return data to parent
                var wnd = getRadWindow();
                if (wnd) wnd.close(arg); //use the close function of the getRadWindow to close the dialog 
                                         //and pass the arguments from the dialog to the callback function on the main page.
                else window.close();
            }

            function closeWin()
            {
                //bind data return
                var arg = {text: ''};
                //get a reference to the RadWindow
                var wnd = getRadWindow();

                //close the RadWindow            
                if (wnd) wnd.close(arg);
                else window.close();
            }
            
            function radToolBarDefault_ClientButtonClicking(sender, eventArgs)
            {
                var cmd = eventArgs.get_item().get_commandName();
                switch (cmd)
                {
                    case 'Insert':
                        eventArgs.set_cancel(true);
                        insertNews();
                        break;
                    case 'Close':
                        eventArgs.set_cancel(true);
                        closeWin();
                        break;
                    default:
                        break;
                };
            }
        
        </script>

        <script type="text/javascript">

			var toolbar;
			var searchButton;

			function pageLoad() {
				toolbar = $find("<%= radToolBarDefault.ClientID %>");
				searchButton = toolbar.findButtonByCommandName("Search");
			}

			function onKeyPress(sender, args) {
				if (args.get_keyCode() == 13) {
					args.get_domEvent().stopPropagation();
					args.get_domEvent().preventDefault();
					searchButton.click();
					return;
				}
			}
            
        </script>

        <script type="text/javascript">
            
            function onRowDropping(sender, args) {
                if(sender.get_id()=="<%=radGridDefault.ClientID %>") {
                    var node = args.get_destinationHtmlElement();
                    if(!isChildOf('<%=radGridSelected.ClientID %>', node)) {
                        args.set_cancel(true);
                    }
                }
                if(sender.get_id()=="<%=radGridSelected.ClientID %>") {
                    var node = args.get_destinationHtmlElement();
                    if(!isChildOf('<%=radGridDefault.ClientID %>', node) && !isChildOf('<%=radGridSelected.ClientID %>', node)) {
                        args.set_cancel(true);
                    }
                }
            }

            function isChildOf(parentId, element) {
                while(element) {
                    if(element.id && element.id.indexOf(parentId) > -1) {
                        return true;
                    }
                    element = element.parentNode;
                }
                return false;
            }
            
        </script>

    </telerik:RadScriptBlock>
    <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="pnlGridView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlGridView" />
                    <telerik:AjaxUpdatedControl ControlID="pnlPaging" />
                    <telerik:AjaxUpdatedControl ControlID="pnlGridSelected" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlPaging">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlGridView" />
                    <telerik:AjaxUpdatedControl ControlID="pnlPaging" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlGridSelected">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlGridView" />
                    <telerik:AjaxUpdatedControl ControlID="pnlPaging" />
                    <telerik:AjaxUpdatedControl ControlID="pnlGridSelected" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>    
    <telerik:RadAjaxLoadingPanel runat="server" ID="radAjaxLoadingPanel1">
    </telerik:RadAjaxLoadingPanel>
    <div class="pd05 pb00">
        <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick" CssClass="panel-search-toolbar"
             OnClientButtonClicking="radToolBarDefault_ClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/43.png" CommandName="Insert"
                    Text="Th&#234;m tin" AccessKey="I">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/MediaIcon/16x16/btn-close.png" CommandName="Close"
                    Text="Đóng" AccessKey="C">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="True" runat="server" />
                <telerik:RadToolBarButton Value="searchTextBoxButton" CommandName="searchText" runat="server">
                    <ItemTemplate>
                        <telerik:RadTextBox runat="server" ID="txtKeyword" EmptyMessage="Tìm kiếm" CssClass="panel-search-textbox"
                            Width="200px" ClientEvents-OnKeyPress="onKeyPress" />
                    </ItemTemplate>
                </telerik:RadToolBarButton>
				<telerik:RadToolBarButton Value="searchCategoryComboBoxButton" CommandName="searchCategoryComboBox" runat="server">
				    <ItemTemplate>
                        <telerik:RadComboBox ID="cmbCategory" runat="server" DataValueField="Id" DataTextField="Name" 
                            EmptyMessage="Chọn danh mục..." Width="200px">
                        </telerik:RadComboBox>
				    </ItemTemplate>
				</telerik:RadToolBarButton>
				<telerik:RadToolBarButton Value="searchPublishDatePickerButton" CommandName="searchPublishDatePicker" runat="server">
				    <ItemTemplate>
                        <telerik:RadDatePicker ID="radDpkPublishFromDate" runat="server" Width="90px" Culture="Vietnamese (Vietnam)" MinDate="01/01/1753">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                            </Calendar>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
                        <asp:Label ID="lblSep" runat="server" Text="->"></asp:Label>
                        <telerik:RadDatePicker ID="radDpkPublishToDate" runat="server" Width="90px" Culture="Vietnamese (Vietnam)" MinDate="01/01/1753">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                            </Calendar>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
				    </ItemTemplate>
				</telerik:RadToolBarButton>
                <telerik:RadToolBarButton ImageUrl="~/Images/SmallIcon/75.png" Value="search" CommandName="Search" runat="server" />
            </Items>
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </telerik:RadToolBar>
    </div>
    <div class="pd05">
        <div class="pd05 w450 fleft">
            <div style="font-size:16px;font-weight:bold;padding:8px 0;">Danh sách tin bài</div>
            <asp:Panel ID="pnlGridView" runat="server">
                <telerik:RadGrid ID="radGridDefault" runat="server" AutoGenerateColumns="False"
                    GridLines="None" OnItemCommand="radGridDefault_ItemCommand" Style="outline: none" AllowMultiRowSelection="true"
                    OnItemDataBound="radGridDefault_ItemDataBound" AllowPaging="False" AllowSorting="False" OnRowDrop="radGridDefault_RowDrop">
                    <MasterTableView ClientDataKeyNames="Id,Url,Name" DataKeyNames="Id,Url,Name" GroupLoadMode="Client"
                        NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o.">
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="#">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <%# ItemIndex() + Container.ItemIndex + 1%>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Right" Width="30px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Id" HeaderText="Id" UniqueName="Id" Visible="False">
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Right" Width="50px" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Name" HeaderText="Tiêu đề" UniqueName="Name">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PublishDate" HeaderText="Ngày xuất bản" UniqueName="PublishDate" DataFormatString="{0:dd/MM/yyyy HH:mm tt}">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Author" HeaderText="Tác giả" UniqueName="Author" Visible="False">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Url" HeaderText="Category Url" UniqueName="Url" Visible="False">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Xem">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <a href="ArticlePreview.aspx?DocId=<%#DataBinder.Eval(Container.DataItem, "Id")%>" target="_blank">
                                        <img alt="Xem" title="Xem" src="/Images/LargeIcon/zoom.png" />
                                    </a>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="True" Width="50px" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings AllowRowsDragDrop="True" EnableRowHoverStyle="True">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"/>
                        <Resizing AllowColumnResize="True" />
                        <ClientEvents OnRowDblClick="RowDblClick" OnRowDropping="onRowDropping" />
                    </ClientSettings>
                    <FilterMenu EnableTheming="True">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                    </FilterMenu>
                    <GroupingSettings CollapseTooltip="Đ&#243;ng" ExpandTooltip="Mở" GroupSplitFormat="" />
                    <PagerStyle FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang tiếp"
                        NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
                </telerik:RadGrid>
            </asp:Panel>
            <asp:Panel ID="pnlPaging" runat="server" CssClass="paging right">
                <asp:ImageButton ID="ibtnFirst" runat="server" ImageUrl="~/Images/first.gif" OnClick="btnRadFirst_Click" />
                <asp:LinkButton ID="lbtnFirst" runat="server" OnClick="btnRadFirst_Click">Đầu</asp:LinkButton>
                <asp:Label ID="lblSeparatorFirst" runat="server">|</asp:Label>
                <asp:ImageButton ID="ibtnPrev" runat="server" ImageUrl="~/Images/prev.gif" OnClick="btnRadPrev_Click" />
                <asp:LinkButton ID="lbtnPrev" runat="server" OnClick="btnRadPrev_Click">Trước</asp:LinkButton>
                <asp:Label ID="lblSeparatorPrev" runat="server">|</asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Trang"></asp:Label>
                <asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="/"></asp:Label>
                <asp:Label ID="lblTotalPage" runat="server" Text="10"></asp:Label>
                <asp:Label ID="lblSeparatorPage" runat="server">|</asp:Label>
                <asp:LinkButton ID="lbtnNext" runat="server" OnClick="btnRadNext_Click">Sau</asp:LinkButton>
                <asp:ImageButton ID="ibtnNext" runat="server" ImageUrl="~/Images/next.gif" OnClick="btnRadNext_Click" />
                <asp:Label ID="lblSeparatorNext" runat="server">|</asp:Label>
                <asp:LinkButton ID="lbtnLast" runat="server" OnClick="btnRadLast_Click">Cuối</asp:LinkButton>
                <asp:ImageButton ID="ibtnLast" runat="server" ImageUrl="~/Images/last.gif" OnClick="btnRadLast_Click" />
                <asp:Label ID="lblSeparatorLast" runat="server">|</asp:Label>
                <asp:LinkButton ID="lbtnGotoPage" runat="server" OnClick="btnRadGotoPage_Click">Chuyển: </asp:LinkButton>
                <asp:DropDownList ID="ddlChoiceIndexOfPage" runat="server" CssClass="center w50"
                    OnSelectedIndexChanged="btnRadGotoPage_Click" AutoPostBack="True">
                </asp:DropDownList>
            </asp:Panel>
        </div>
        <div class="pd05 w300 fright">
            <div style="font-size:16px;font-weight:bold;padding:8px 0;">Tin bài liên quan</div>
            <asp:Panel ID="pnlGridSelected" runat="server">
                <telerik:RadGrid ID="radGridSelected" runat="server" AutoGenerateColumns="False" AllowMultiRowSelection="true"
                    GridLines="None" Style="outline: none" AllowPaging="False" AllowSorting="False" OnItemCommand="radGridSelected_ItemCommand" 
                    OnNeedDataSource="radGridSelected_NeedDataSource" OnRowDrop="radGridSelected_RowDrop">
                    <MasterTableView ClientDataKeyNames="Id,Name,Link" DataKeyNames="Id,Name,Link" GroupLoadMode="Client"
                        NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o.">
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="#">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <%# Container.ItemIndex + 1%>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Right" Width="30px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Id" HeaderText="Id" UniqueName="Id" Visible="False">
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Right" Width="50px" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Name" HeaderText="Tiêu đề" UniqueName="Name">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Author" HeaderText="Tác giả" UniqueName="Author" Visible="False">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Link" HeaderText="Link" UniqueName="Link" Visible="False">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Url" HeaderText="Category Url" UniqueName="Url" Visible="False">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Xem">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <a href="ArticlePreview.aspx?DocId=<%#DataBinder.Eval(Container.DataItem, "Id")%>" target="_blank">
                                        <img alt="Xem" title="Xem" src="/Images/LargeIcon/zoom.png" />
                                    </a>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="True" Width="50px" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings AllowRowsDragDrop="True" EnableRowHoverStyle="True">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"/>
                        <Resizing AllowColumnResize="True" />
                        <ClientEvents OnRowDblClick="RowDblClick" OnRowDropping="onRowDropping" />
                    </ClientSettings>
                    <FilterMenu EnableTheming="True">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                    </FilterMenu>
                    <GroupingSettings CollapseTooltip="Đ&#243;ng" ExpandTooltip="Mở" GroupSplitFormat="" />
                    <PagerStyle FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang tiếp"
                        NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
                </telerik:RadGrid>
            </asp:Panel>
        </div>
        <br class="clear" />
    </div>
</asp:Content>
