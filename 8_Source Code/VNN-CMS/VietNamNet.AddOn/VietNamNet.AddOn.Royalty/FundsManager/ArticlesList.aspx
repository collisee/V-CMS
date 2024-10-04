<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="ArticlesList.aspx.cs" Inherits="VietNamNet.AddOn.Royalty.ArticlesList" Title="Danh sách Tin bài" ValidateRequest="false" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<asp:Content ContentPlaceHolderID="cplhContainer" ID="Content1" runat="server">
<div>
<telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server" />
     <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>             
            <telerik:AjaxSetting AjaxControlID="radToolBarDefault">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />  
                    <telerik:AjaxUpdatedControl ControlID="radGridDefault" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
             <telerik:AjaxSetting AjaxControlID="radGridDefault">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMessage" />  
                    <telerik:AjaxUpdatedControl ControlID="radGridDefault" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
        </AjaxSettings>
     </telerik:RadAjaxManager>
        <telerik:RadScriptBlock runat="server" ID="RadScriptBlock2">
            <script type="text/javascript">
            var toolbar;
			var searchButton;

			function pageLoad() {
				toolbar = $find("<%= radToolBarDefault.ClientID %>");
				searchButton = toolbar.findButtonByCommandName("Search");
			}
            function RowDblClick(sender, eventArgs)
                {
                    ViewFund( eventArgs.getDataKeyValue('Id') );
                }
            function onFilterChange(sender, args) { 
					args.get_domEvent().stopPropagation();
					args.get_domEvent().preventDefault();
					searchButton.click();
					return; 
			} 
            function ViewFund(id){
                    var oWnd = radopen("FundByArticle.aspx?DocId=" + id);
                    oWnd.setSize(780, 450);
                    oWnd.add_close(closeRadWindow);
                }
            function closeRadWindow(wnd, args){
                    //searchButton.click();
            }
            
            function radToolBarDefault_ClientButtonClicking(sender, eventArgs)
            {
                var cmd = eventArgs.get_item().get_commandName();
                switch (cmd)
                {
                    default:
                        break;
                };
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
        </telerik:RadScriptBlock>
        
<telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" RelativeTo="Element"
            Position="BottomCenter" AutoTooltipify="true" ContentScrolling="Default"
            Height="10">
        </telerik:RadToolTipManager>

    <telerik:RadWindowManager ID="radWindowManager" runat="server" Behaviors="Maximize,Move,Reload,Resize,Close"
        VisibleStatusbar="False">
    </telerik:RadWindowManager>
            
</div>
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
				<telerik:RadToolBarButton Value="searchStatusComboBoxButton" CommandName="searchStatusComboBox">
				    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text="Trạng thái: "></asp:Label>
                        <telerik:RadComboBox ID="cmbStatus" runat="server" EmptyMessage="Tất cả" Width="100px">
                            <Items>
                                <telerik:RadComboBoxItem Value="0" Text="Tất cả" />
                               <telerik:RadComboBoxItem Value="1" Text="Đã chấm nhuận bút" />
                               <telerik:RadComboBoxItem Value="2" Text="Chưa chấm nhuận bút" />
                            </Items>
                        </telerik:RadComboBox>
				    </ItemTemplate>
				</telerik:RadToolBarButton>
				<telerik:RadToolBarButton Value="searchCategoryComboBoxButton" CommandName="searchCategoryComboBox">
				    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text="Danh mục: "></asp:Label>
                        <telerik:RadComboBox ID="cmbCategory" runat="server" DataValueField="Id" DataTextField="Name" 
                            EmptyMessage="Tất cả" Width="200px">
                        </telerik:RadComboBox>
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
            </Items>
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </telerik:RadToolBar>
    </div>
 
    <div class="pd05">
        <telerik:RadAjaxPanel ID="radAjaxPanelView" runat="server" LoadingPanelID="radAjaxLoadingPanel1">
            <telerik:RadGrid ID="radGridDefault" runat="server" AutoGenerateColumns="False"
                GridLines="None" OnItemCommand="radGridDefault_ItemCommand" Style="outline: none"
                AllowPaging="False" AllowSorting="False">
                <MasterTableView ClientDataKeyNames="Id" DataKeyNames="Id" GroupLoadMode="Client"
                    NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o.">
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="#">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <%# ItemIndex() + Container.ItemIndex + 1%>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Right" Width="25px" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Tiêu đề" HeaderStyle-Width="250">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Name")%> 
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                         <telerik:GridTemplateColumn HeaderText="Người xuất bản" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Author")%> 
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                         <telerik:GridTemplateColumn HeaderText="Nhuận bút" HeaderStyle-Width="75" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Total_Fund")%> 
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>                    
                        <telerik:GridTemplateColumn HeaderText=" Ngày xuất bản" HeaderStyle-Width="75">
                            <ItemTemplate><%# String.Format("{0:dd/MM/yyyy hh:mm}", DataBinder.Eval(Container.DataItem, "PublishDate"))%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                       
                        <telerik:GridTemplateColumn HeaderText="Chức năng" HeaderStyle-Width="75">
                            <ItemTemplate>
                                <a href="#" onclick="ViewFund('<%# DataBinder.Eval(Container.DataItem, "Id")%>')"  title="Thông tin chấm nhuận bút"><img src="/Images/LargeIcon/paste.png" alt="FundInfo"></a>
                                <a title="xem chi tiết" href="<%#Utilities.GetConfigKey("WebsiteLink") + Utilities.GetArticleUrl(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"), DataBinder.Eval(Container.DataItem, "Name")) %>" target="_blank" title="Xem trước bài viết"><img src="/Images/LargeIcon/zoom.png" alt="Preview"></a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="True">
                    <Resizing AllowColumnResize="True" />
                    <ClientEvents OnRowDblClick="RowDblClick" />
                </ClientSettings>
                <FilterMenu EnableTheming="True">
                    <CollapseAnimation Duration="200" Type="OutQuint" />
                </FilterMenu>
                <GroupingSettings CollapseTooltip="Đ&#243;ng" ExpandTooltip="Mở" GroupSplitFormat="" />
                <PagerStyle FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang tiếp"
                    NextPageToolTip="Trang tiếp" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
            </telerik:RadGrid>
            <asp:Panel ID="pnlPaging" runat="server" CssClass="paging right">
                <asp:ImageButton ID="ibtnFirst" runat="server" ImageUrl="~/Images/first.gif" OnClick="btnRadFirst_Click" />
                <asp:LinkButton ID="lbtnFirst" runat="server" OnClick="btnRadFirst_Click">Đầu tiên</asp:LinkButton>
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
                <asp:LinkButton ID="lbtnLast" runat="server" OnClick="btnRadLast_Click">Cuối cùng</asp:LinkButton>
                <asp:ImageButton ID="ibtnLast" runat="server" ImageUrl="~/Images/last.gif" OnClick="btnRadLast_Click" />
                <asp:Label ID="lblSeparatorLast" runat="server">|</asp:Label>
                <asp:LinkButton ID="lbtnGotoPage" runat="server" OnClick="btnRadGotoPage_Click">Chuyển đến: </asp:LinkButton>
                <asp:DropDownList ID="ddlChoiceIndexOfPage" runat="server" CssClass="center w50"
                    OnSelectedIndexChanged="btnRadGotoPage_Click" AutoPostBack="True">
                </asp:DropDownList>
            </asp:Panel>
        </telerik:RadAjaxPanel>
    </div>
                <asp:Label runat="server" ID="lblMessage" ForeColor="red"></asp:Label>

</asp:Content>
