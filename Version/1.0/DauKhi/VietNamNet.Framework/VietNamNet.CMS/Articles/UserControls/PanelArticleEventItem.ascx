<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelArticleEventItem.ascx.cs" Inherits="VietNamNet.CMS.Articles.UserControls.PanelArticleEventItem" %>
<telerik:RadScriptBlock runat="server" ID="scriptBlock">

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
<asp:Panel ID="pnlSearch" runat="server" CssClass="pd05 pb00">
    <telerik:RadTextBox runat="server" ID="txtKeyword" EmptyMessage="Tìm kiếm" CssClass="panel-search-textbox"
        Width="200px" ClientEvents-OnKeyPress="onKeyPress" />
    <asp:Label ID="lblPublishDate" runat="server" Text=" Ngày XB: "></asp:Label>
    <telerik:RadDatePicker ID="radDpkPublishFromDate" runat="server" Width="90px" Culture="Vietnamese (Vietnam)" MinDate="01/01/1753">
        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
        </Calendar>
        <DatePopupButton HoverImageUrl="" ImageUrl="" />
    </telerik:RadDatePicker>
    <asp:Label ID="lblSep2" runat="server" Text="->"></asp:Label>
    <telerik:RadDatePicker ID="radDpkPublishToDate" runat="server" Width="90px" Culture="Vietnamese (Vietnam)" MinDate="01/01/1753">
        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
        </Calendar>
        <DatePopupButton HoverImageUrl="" ImageUrl="" />
    </telerik:RadDatePicker>
    <asp:HiddenField ID="hidPage" runat="server" Value="1" />
    <asp:HiddenField ID="hidTotalPages" runat="server" Value="0" />
    <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/Images/SmallIcon/75.png" CssClass="cpointer" OnClick="ibtnSearch_Click" />
</asp:Panel>
<div class="pd05">
    <asp:Panel ID="pnlArticles" runat="server" CssClass="pd05 w450 fleft">
        <div style="font-size:16px;font-weight:bold;padding:8px 0;">Danh sách tin bài</div>
        <asp:Panel ID="pnlGridView" runat="server">
            <telerik:RadGrid ID="radGridDefault" runat="server" AutoGenerateColumns="False"
                GridLines="None" Style="outline: none" AllowMultiRowSelection="true"
                AllowPaging="False" AllowSorting="False" OnRowDrop="radGridDefault_RowDrop" OnNeedDataSource="radGridDefault_NeedDataSource" OnItemCommand="radGridDefault_ItemCommand">
                <MasterTableView ClientDataKeyNames="Id,Name" DataKeyNames="Id,Name" GroupLoadMode="Client"
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
        <div style="font-size:16px;font-weight:bold;padding:8px 0;">Tin bài liên quan</div>
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
                        <telerik:GridBoundColumn DataField="Ord" HeaderText="Thứ tự" UniqueName="Ord" Visible="false">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ArticleName" HeaderText="Tiêu đề" UniqueName="ArticleName">
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
