<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="UserView.aspx.cs" Inherits="VietNamNet.Framework.UserView" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
	<telerik:RadScriptBlock runat="server" ID="RadScriptBlock1">

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
            
            function StopPropagation(e)
            {
                //cancel bubbling
                e.cancelBubble = true;
                if (e.stopPropagation)
                {
                    e.stopPropagation();
                }
            }
            
            function getComboBoxGroup()
            {
                var comboButton = toolbar.findButtonByCommandName('searchGroupComboBox');
                var combo = $find(toolbar.get_id() + '_i' + comboButton.get_index() + '_cmbGroup');
                return combo;
            }

            function onCheckBoxClick(chk)
            {
                var combo = getComboBoxGroup();
                //holds the text of all checked items
                var text = '';
                //holds the values of all checked items
                var values = '';
                //get the collection of all items
                var items = combo.get_items();
                //enumerate all items
                for (var i = 0; i < items.get_count(); i++)
                {
                    var item = items.getItem(i);
                    //get the checkbox element of the current item
                    var chk1 = $get(combo.get_id() + '_i' + i + '_chk1');
                    if (chk1.checked)
                    {
                        text += item.get_text() + ',' ;
                        values += item.get_value() + ',';
                    }
                }
                //remove the last comma from the string
                text = removeLastComma(text);
                values = removeLastComma(values);
            
                if (text.length > 0)
                {
                    //set the text of the combobox
                    combo.set_text(text);
                }
                else
                {
                    //all checkboxes are unchecked
                    //so reset the controls
                    combo.set_text('');
                }
            }

            //this method removes the ending comma from a string
            function removeLastComma(str)
            {
                return str.replace(/,$/,'');
            }

        </script>

    </telerik:RadScriptBlock>
    <telerik:RadWindowManager ID="radWindowManager" runat="server"
        Behaviors="Maximize,Move,Reload,Resize,Close" VisibleStatusbar="False" DestroyOnClose="True">
    </telerik:RadWindowManager>
	<telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" DefaultLoadingPanelID="radAjaxLoadingPanel1">
	</telerik:RadAjaxManager>
	<telerik:RadAjaxLoadingPanel runat="server" ID="radAjaxLoadingPanel1">
	</telerik:RadAjaxLoadingPanel>
    <div class="pd05 pb00">
        <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick" CssClass="panel-search-toolbar">
            <Items>
				<telerik:RadToolBarButton Value="searchTextBoxButton" CommandName="searchText">
					<ItemTemplate>
						<telerik:RadTextBox
							runat="server" ID="txtKeyword"
							EmptyMessage="Tìm kiếm"
							CssClass="panel-search-textbox" Width="200px"
							ClientEvents-OnKeyPress="onKeyPress" />
					</ItemTemplate>
				</telerik:RadToolBarButton>
				<telerik:RadToolBarButton Value="searchGroupComboBoxButton" CommandName="searchGroupComboBox">
				    <ItemTemplate>
                        <telerik:RadComboBox ID="cmbGroup" runat="server"
                            DataValueField="Id" DataTextField="Name" EmptyMessage="Chọn nhóm..." HighlightTemplatedItems="true"
                            AllowCustomText="true" Width="240px">
                            <ItemTemplate>
                                <div onclick="StopPropagation(event)" class="combo-item-template">
                                    <asp:CheckBox runat="server" ID="chk1" onclick="onCheckBoxClick(this)" />
                                    <asp:Label runat="server" ID="Label1" AssociatedControlID="chk1">
                                        <%# Eval("Name") %>
                                    </asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:RadComboBox>
				    </ItemTemplate>
				</telerik:RadToolBarButton>
				<telerik:RadToolBarButton ImageUrl="~/Images/SmallIcon/75.png" Value="search" CommandName="Search" />
            </Items>
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </telerik:RadToolBar>
    </div>
    <div class="pd05">
        <telerik:RadAjaxPanel ID="radAjaxPanelView" runat="server" LoadingPanelID="radAjaxLoadingPanel1">
            <telerik:RadGrid ID="radGridDefault" runat="server" AllowCustomPaging="True" AutoGenerateColumns="False"
                GridLines="None" OnItemCommand="radGridDefault_ItemCommand"
                OnItemDataBound="radGridDefault_ItemDataBound">
                <MasterTableView ClientDataKeyNames="Id" DataKeyNames="Id" GroupLoadMode="Client" NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o.">
                    <RowIndicatorColumn>
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn>
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="#">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <%# ItemIndex() + Container.ItemIndex + 1%>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Right" Width="50px" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="Status" HeaderText="Trạng thái" UniqueName="Status">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LoginName" HeaderText="T&#234;n đăng nhập" UniqueName="LoginName">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FullName" HeaderText="T&#234;n đầy đủ" UniqueName="FullName">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Birthday" HeaderText="Ngày sinh" UniqueName="Birthday" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Email" HeaderText="Email" UniqueName="Email" Visible="False">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Email">
                            <ItemStyle Wrap="False" />
                            <ItemTemplate>
                                <a href='mailto:<%#DataBinder.Eval(Container.DataItem, "Email")%>'>
                                    <%#DataBinder.Eval(Container.DataItem, "Email")%>
                                </a>
                                <a href='mailto:<%#DataBinder.Eval(Container.DataItem, "Email")%>'>
                                    <img alt="gửi email" title="gửi email" width="16" src="/Images/SmallIcon/47.png" />
                                </a>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="Sex" HeaderText="Giới tính" UniqueName="Sex">
                            <HeaderStyle Font-Bold="True" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Phone" HeaderText="Điện thoại" UniqueName="Phone">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Mobile" HeaderText="Di động" UniqueName="Mobile">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Yahoo" HeaderText="Yahoo" UniqueName="Yahoo">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Skype" HeaderText="Skype" UniqueName="Skype">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                    <Resizing AllowColumnResize="True" />
                    <ClientEvents OnRowDblClick="RowDblClick" />
                </ClientSettings>
                <FilterMenu EnableTheming="True">
                    <CollapseAnimation Duration="200" Type="OutQuint" />
                </FilterMenu>
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
</asp:Content>