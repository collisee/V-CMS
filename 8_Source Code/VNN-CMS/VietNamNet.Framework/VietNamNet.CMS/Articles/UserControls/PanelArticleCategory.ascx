<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelArticleCategory.ascx.cs" Inherits="VietNamNet.CMS.Articles.UserControls.PanelArticleCategory" %>

<telerik:RadScriptBlock ID="RadScriptBlockMenu" runat="server">

    <script type="text/javascript">

        function nodeSelect(node, check)
        {
            return; //turn off select child
            node.set_checked(check);
            for (var i = 0; i < node.get_nodes().get_count(); i++)  
            {
                var subNode = node.get_nodes().getNode(i);
                nodeSelect(subNode, check);
            }
        }
        
        function getCheckedNodes(node)
        {
            var res = {text: '', 
                       value: ''};
            if (node.get_checked())
            {
                res.text = node.get_text() + ',';
                res.value = node.get_value() + ',';
            }
            
            for (var i = 0; i < node.get_nodes().get_count(); i++)  
            {
                var subNode = node.get_nodes().getNode(i);
                var subRes = getCheckedNodes(subNode);
                if (subRes.text) res.text += subRes.text;
                if (subRes.value) res.value += subRes.value;
            }
            return res;
        }
        
        function bindData(node){
            var tree = node.get_treeView();
            tree.trackChanges();

            var categories = {text: '', value: ''};
            for (var i = 0; i < tree.get_nodes().get_count(); i++)  
            {
                var node = tree.get_nodes().getNode(i);
                var res = getCheckedNodes(node);
                categories.text += res.text;
                categories.value += res.value;
            }
            categories.text = categories.text.substring(0, categories.text.length - 1);
            categories.value = categories.value.substring(0, categories.value.length - 1);
            tree.commitChanges();

            var comboBox = $find("<%= cmbCategory.ClientID %>");
            comboBox.trackChanges();
            comboBox.set_text(categories.text);
            comboBox.get_items().getItem(0).set_value(categories.value);
            comboBox.commitChanges();
        }
        
        function nodeClicking(sender, args)
        {
            var node = args.get_node();
            nodeSelect(node, !node.get_checked());
            bindData(node);
        }
        
        function nodeChecked(sender, args)
        {
            var node = args.get_node();
            
            for (var i = 0; i < node.get_nodes().get_count(); i++)  
            {
                var subNode = node.get_nodes().getNode(i);
                nodeSelect(subNode, node.get_checked());
            }
            
            bindData(node);
        }

        function StopPropagation(e)
        {
            if(!e)
            {
                e = window.event;
            }

            e.cancelBubble = true;
        }
        
        function onClientDropDownOpening(sender, eventArgs)
        {
            var comboBox = sender;
            comboBox.trackChanges();
            comboBox.set_text('Chọn danh mục...');
            comboBox.get_items().getItem(0).set_value('');
            comboBox.commitChanges();

            var tree = sender.get_items().getItem(0).findControl("radTreeViewCategory");
            if (tree)
            {
                for (var i = 0; i < tree.get_nodes().get_count(); i++)  
                {
                    var node = tree.get_nodes().getNode(i);
                    nodeSelect(node, false);
                }
            }
        }
        
        function OnClientDropDownOpenedHandler(sender, eventArgs)
        {
            var comboBox = sender;
            comboBox.trackChanges();
            if (comboBox.get_text() == 'Chọn danh mục...' || comboBox.get_value() == '')
            {
                comboBox.set_text('');
                comboBox.get_items().getItem(0).set_value('');
            }
            comboBox.commitChanges();

            var tree = sender.get_items().getItem(0).findControl("radTreeViewCategory");
            if (tree)
            {
                var selectedNode = tree.get_selectedNode();
                if (selectedNode)
                {
                    selectedNode.set_selected(false);
                }
            }
        }
    </script>

    <script type="text/javascript">

        function selectAllCheckbox(chk){
            $telerik.$(':input[type=checkbox]', $telerik.$('#<%=radGridCategories.ClientID %> *[class=flagDeleteCheckBox]'))
            .each(function(){
                this.checked = chk;
            });
        }

    </script>

</telerik:RadScriptBlock>

<div>
    <asp:Panel ID="pnlEdit" runat="server">
        <p>
            <asp:Label ID="lblCategoryLabel" runat="server" CssClass="label w150" Text="Danh mục:"></asp:Label>
            <telerik:RadComboBox ID="cmbCategory" runat="server" Height="300px" EmptyMessage="Chọn danh mục..."
                Width="454px" OnClientDropDownOpened="OnClientDropDownOpenedHandler" OnClientDropDownOpening="onClientDropDownOpening">
                <ItemTemplate>
                    <div id="div1" onclick="StopPropagation(event)">
                        <telerik:RadTreeView runat="server" ID="radTreeViewCategory" OnClientNodeClicking="nodeClicking"
                            OnClientNodeChecked="nodeChecked" CheckBoxes="True"
                            DataFieldID="Id" DataFieldParentID="PId" DataTextField="DisplayName">
                        </telerik:RadTreeView>
                    </div>
                </ItemTemplate>
                <Items>
                    <telerik:RadComboBoxItem Text="" />
                </Items>
                <CollapseAnimation Type="None" />
                <ExpandAnimation Type="None" />
            </telerik:RadComboBox>
            <br class="clear" />
        </p>
        <p>
            <asp:Label ID="lblOrdLabel" runat="server" CssClass="label w150" Text="Thứ tự:"></asp:Label>
            <telerik:RadNumericTextBox ID="txtOrd" runat="server" MinValue="1" Value="1" Width="450px" CssClass="right">
                <NumberFormat DecimalDigits="0" />
            </telerik:RadNumericTextBox>
            <br class="clear" />
        </p>
        <asp:Button ID="btnAddCategory" runat="server" Text="Thêm Danh mục" Width="150px" OnClick="btnAddCategory_Click" />
    </asp:Panel>
    <br />
    <br />
    <telerik:RadGrid ID="radGridCategories" runat="server" AllowCustomPaging="False" AutoGenerateColumns="False" GridLines="None" OnNeedDataSource="radGridCategories_NeedDataSource" OnItemCommand="radGridCategories_ItemCommand">
        <MasterTableView ClientDataKeyNames="Id" DataKeyNames="Id" GroupLoadMode="Client" NoMasterRecordsText="Kh&#244;ng c&#243; danh mục n&#224;o.">
            <RowIndicatorColumn>
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="<input type='checkbox' onclick='selectAllCheckbox(this.checked)' />">
                    <HeaderStyle HorizontalAlign="Center" Width="40px" Font-Bold="True" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelected" runat="server" CssClass="flagDeleteCheckBox" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="STT">
                    <HeaderStyle HorizontalAlign="Right" Width="40px" Font-Bold="True" />
                    <ItemTemplate>
                        <%#Container.ItemIndex + 1%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="Id" HeaderText="Id" UniqueName="Id" Visible="False">
                    <HeaderStyle Font-Bold="True" />
                    <ItemStyle HorizontalAlign="Right" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="CategoryName" HeaderText="Danh Mục" UniqueName="CategoryName">
                    <HeaderStyle Font-Bold="True" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="CategoryAlias" HeaderText="Alias" UniqueName="CategoryAlias">
                    <HeaderStyle Font-Bold="True" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn DataField="PrimaryCategory" HeaderText="Danh Mục chính" UniqueName="PrimaryCategoryView" Visible="False">
                    <HeaderStyle Font-Bold="True" Width="120px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:CheckBox ID="rbtnPrimaryCategory" runat="server" Checked='<%#Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "PrimaryCategory")) == 1%>'
                            Visible='<%#Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "PrimaryCategory")) == 1%>' />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="PrimaryCategory" HeaderText="Danh Mục chính" UniqueName="PrimaryCategorySelect">
                    <HeaderStyle Font-Bold="True" Width="120px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:CheckBox ID="rbtnPrimaryCategoryView" runat="server" AutoPostBack="true" OnCheckedChanged="rbtnPrimaryCategory_CheckedChanged"
                            Checked='<%#Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "PrimaryCategory")) == 1%>' />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="OldOrd" HeaderText="Thứ tự cũ" UniqueName="OldOrd">
                    <HeaderStyle Font-Bold="True" HorizontalAlign="Right" Width="100px" />
                    <ItemStyle HorizontalAlign="Right" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Thứ tự" UniqueName="Ord">
                    <HeaderStyle Font-Bold="True" HorizontalAlign="Right" Width="70px" />
                    <ItemTemplate>
                        <telerik:RadNumericTextBox ID="txtOrd" runat="server" MinValue="1" Text='<%#DataBinder.Eval(Container.DataItem, "Ord")%>' 
                            Width="30px" CssClass="right" AutoPostBack="true" OnTextChanged="txtOrd_TextChanged">
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </telerik:GridTemplateColumn>
                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                    ConfirmText="Bạn c&#243; chắc chắn muốn X&#243;a Danh mục n&#224;y?" ConfirmTitle="X&#243;a"
                    HeaderText="X&#243;a" Text="X&#243;a" UniqueName="Delete">
                    <HeaderStyle HorizontalAlign="Center" Width="32px" Font-Bold="True" />
                    <ItemStyle HorizontalAlign="Center" Width="32px" />
                </telerik:GridButtonColumn>
            </Columns>
            <%--<SortExpressions>
                <telerik:GridSortExpression FieldName="CategoryName"></telerik:GridSortExpression>
            </SortExpressions>--%>
        </MasterTableView>
        <ClientSettings EnableRowHoverStyle="true">
            <Resizing AllowColumnResize="True" />
        </ClientSettings>
        <FilterMenu EnableTheming="True">
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </FilterMenu>
    </telerik:RadGrid>
    <br />
    <asp:Button ID="btnDelCategories" runat="server" Text="Xóa Danh mục đã chọn" Width="150px" OnClick="btnDelCategories_Click" />
    <br />
</div>
