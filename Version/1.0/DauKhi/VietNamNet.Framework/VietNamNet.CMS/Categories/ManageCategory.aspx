﻿<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ManageCategory.aspx.cs" Inherits="VietNamNet.CMS.Categories.ManageCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplhContainer" runat="server">
    <telerik:RadScriptBlock runat="server" ID="scriptBlock">

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
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radToolBarDefault">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                    <telerik:AjaxUpdatedControl ControlID="pnlArticles" />
                    <telerik:AjaxUpdatedControl ControlID="pnlSelected" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlGridView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                    <telerik:AjaxUpdatedControl ControlID="pnlSelected" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlGridSelected">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                    <telerik:AjaxUpdatedControl ControlID="pnlGridSelected" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <div class="pd05 pb00">
        <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick"
            CssClass="panel-search-toolbar">
            <Items>
                <telerik:RadToolBarButton Value="searchTextBoxButton" CommandName="searchText">
                    <ItemTemplate>
                        <telerik:RadTextBox runat="server" ID="txtKeyword" EmptyMessage="Tìm kiếm" CssClass="panel-search-textbox"
                            Width="150px" ClientEvents-OnKeyPress="onKeyPress" />
                    </ItemTemplate>
                </telerik:RadToolBarButton>
				<telerik:RadToolBarButton Value="searchPublishDatePickerButton" CommandName="searchPublishDatePicker" runat="server">
				    <ItemTemplate>
                        <asp:Label ID="lblPublishDate" runat="server" Text="Ngày XB: "></asp:Label>
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
                <telerik:RadToolBarButton ImageUrl="~/Images/SmallIcon/75.png" Value="search" CommandName="Search" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/77.png" CommandName="Optimize"
                    Text="Optimize" AccessKey="O">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveitem.gif" CommandName="Save"
                    Text="Lưu" AccessKey="S">
                </telerik:RadToolBarButton>
            </Items>
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </telerik:RadToolBar>
    </div>
    <div class="pd05">
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="blue" Text="" Visible="false"></asp:Label>
        <br />
        <asp:Panel ID="pnlArticles" runat="server" CssClass="pd05 w450 fleft">
            <asp:HiddenField ID="hidPage" runat="server" Value="1" />
            <asp:HiddenField ID="hidTotalPages" runat="server" Value="0" />
            <div style="font-size:16px;font-weight:bold;padding:8px 0;">Danh sách tin bài</div>
            <asp:Panel ID="pnlGridView" runat="server">
                <telerik:RadGrid ID="radGridDefault" runat="server" AutoGenerateColumns="False"
                    GridLines="None" Style="outline: none" AllowMultiRowSelection="true"
                    AllowPaging="False" AllowSorting="False" OnRowDrop="radGridDefault_RowDrop" OnNeedDataSource="radGridDefault_NeedDataSource" OnItemCommand="radGridDefault_ItemCommand">
                    <MasterTableView ClientDataKeyNames="Id,Name,ArticleContentTypeId,PublishDate" DataKeyNames="Id,Name,ArticleContentTypeId,PublishDate" GroupLoadMode="Client"
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
                                <HeaderStyle Font-Bold="True" Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ArticleContentTypeId" HeaderText="Loại" UniqueName="ArticleContentTypeId">
                                <HeaderStyle Font-Bold="True" Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Author" HeaderText="Tác giả" UniqueName="Author" Visible="False">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CategoryAlias" HeaderText="Category Alias" UniqueName="CategoryAlias" Visible="False">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Xem">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <a href="../Articles/ArticlePreview.aspx?DocId=<%#DataBinder.Eval(Container.DataItem, "Id")%>" target="_blank">
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
        </asp:Panel>
        <asp:Panel ID="pnlSelected" runat="server" CssClass="pd05 w450 fleft">
            <div style="font-size:16px;font-weight:bold;padding:8px 0;">Tin bài trong Chuyên mục: 
                <asp:Label ID="lblCategoryName" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="hidUrl" runat="server" Value="0" />
                <asp:HiddenField ID="hidPartitionId" runat="server" Value="0" />
                </div>
            <asp:Panel ID="pnlGridSelected" runat="server">
                <telerik:RadGrid ID="radGridSelected" runat="server" AutoGenerateColumns="False" AllowMultiRowSelection="true"
                    GridLines="None" Style="outline: none" AllowPaging="False" AllowSorting="False" 
                    OnNeedDataSource="radGridSelected_NeedDataSource" OnRowDrop="radGridSelected_RowDrop" OnItemCommand="radGridSelected_ItemCommand">
                    <MasterTableView ClientDataKeyNames="Id,ArticleId" DataKeyNames="Id,ArticleId" GroupLoadMode="Client"
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
                            <telerik:GridBoundColumn DataField="Ord" HeaderText="Thứ tự" UniqueName="Ord" Visible="False">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ArticleName" HeaderText="Tiêu đề" UniqueName="ArticleName">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PublishDate" HeaderText="Ngày xuất bản" UniqueName="PublishDate" DataFormatString="{0:dd/MM/yyyy HH:mm tt}">
                                <HeaderStyle Font-Bold="True" Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ArticleContentTypeId" HeaderText="Loại" UniqueName="ArticleContentTypeId">
                                <HeaderStyle Font-Bold="True" Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Xem">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <a href="../Articles/ArticlePreview.aspx?DocId=<%#DataBinder.Eval(Container.DataItem, "ArticleId")%>" target="_blank">
                                        <img alt="Xem" title="Xem" src="/Images/LargeIcon/zoom.png" />
                                    </a>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="True" Width="50px" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <SortExpressions>
                            <telerik:GridSortExpression FieldName="Ord"></telerik:GridSortExpression>
                        </SortExpressions>
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
        </asp:Panel>
        <br class="clear" />
    </div>
</asp:Content>
