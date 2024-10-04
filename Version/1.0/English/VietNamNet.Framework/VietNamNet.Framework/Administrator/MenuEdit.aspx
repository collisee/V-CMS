<%@ Page MasterPageFile="~/Default.Master"Language="C#" AutoEventWireup="true" CodeBehind="MenuEdit.aspx.cs" Inherits="VietNamNet.Framework.Administrator.MenuEdit" %>
<%@ Register Src="~/UserControls/AuditTrail.ascx" TagName="AuditTrail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <telerik:RadScriptBlock ID="RadScriptBlockMenu" runat="server">

        <script type="text/javascript">        
            function comboLoad(sender, eventArgs)
            {
                var tree = sender.get_items().getItem(0).findControl("radTreeViewMenu");
                if (tree)
                {
                    var selectedNode = tree.get_selectedNode();
                    if (selectedNode != null) {
                        sender.set_text(selectedNode.get_text());
                        sender.get_items().getItem(0).set_value(selectedNode.get_value());
                    }
                }
            }

            function nodeClicking(sender, args)
            {
                var comboBox = $find("<%= radCmbParent.ClientID %>");

                var node = args.get_node()

                comboBox.set_text(node.get_text());

                comboBox.trackChanges();
                comboBox.get_items().getItem(0).set_value(node.get_value());
                comboBox.commitChanges();

                comboBox.hideDropDown();
            }

            function StopPropagation(e)
            {
                if(!e)
                {
                    e = window.event;
                }

                e.cancelBubble = true;
            }
            
            function OnClientDropDownOpenedHandler(sender, eventArgs)
            {
                var tree = sender.get_items().getItem(0).findControl("radTreeViewMenu");
                if (tree)
                {
                    var selectedNode = tree.get_selectedNode();
                    if (selectedNode)
                    {
                        selectedNode.scrollIntoView();
                    }
                }
            }
        </script>

    </telerik:RadScriptBlock>
    <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radCmbModule">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cblFunctions" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div class="pd05">
        <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveitem.gif" CommandName="Save"
                        Text="Lưu" AccessKey="S">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/goback1.gif" CommandName="GoBacktoView"
                        Text="Quay lại" AccessKey="G">
                    </telerik:RadToolBarButton>
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
            <uc:ErrorMessage ID="ErrorMessage1" runat="server" Visible="false" />
            <p>
                <asp:Label ID="lblParentLabel" runat="server" CssClass="label w150" Text="Menu cha:"></asp:Label>
                <telerik:RadComboBox ID="radCmbParent" runat="server" Height="300px"
                    Width="450px" OnClientLoad="comboLoad" OnClientDropDownOpened="OnClientDropDownOpenedHandler">
                    <ItemTemplate>
                        <div id="div1" onclick="StopPropagation(event)">
                            <telerik:RadTreeView runat="server" ID="radTreeViewMenu" OnClientNodeClicking="nodeClicking"
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
                <asp:Label ID="lblOrderLabel" runat="server" CssClass="label w150" Text="Thứ tự:"></asp:Label>
                <telerik:RadNumericTextBox ID="txtOrder" runat="server" MinValue="1" MaxValue="1000" Width="450px" ShowButton="False" Value="1" CssClass="right">
                    <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>
                <asp:HiddenField ID="hidOldOrd" runat="server" />
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblNameLabel" runat="server" CssClass="label w150" Text="Tên Menu:"></asp:Label>
                <telerik:RadTextBox ID="txtName" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                <asp:Label ID="Label1" runat="server" CssClass="red" Text="*"></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblDisplayNameLabel" runat="server" CssClass="label w150" Text="Tên hiển thị:"></asp:Label>
                <telerik:RadTextBox ID="txtDisplayName" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                <asp:Label ID="Label2" runat="server" CssClass="red" Text="*"></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblLinkLabel" runat="server" CssClass="label w150" Text="Link:"></asp:Label>
                <telerik:RadTextBox ID="txtLink" runat="server" Width="450px" MaxLength="255"></telerik:RadTextBox>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblModuleLabel" runat="server" CssClass="label w150" Text="Module:"></asp:Label>
                <telerik:RadComboBox ID="radCmbModule" runat="server" Width="450px" AutoPostBack="True" OnSelectedIndexChanged="radCmbModule_SelectedIndexChanged">
                    <CollapseAnimation Duration="200" Type="OutQuint" />
                </telerik:RadComboBox>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblAccessLabel" runat="server" CssClass="label w150" Text="Truy cập:"></asp:Label>
                <asp:CheckBoxList ID="cblFunctions" runat="server" DataTextField="Name" DataValueField="Ord" RepeatDirection="Horizontal" RepeatLayout="Flow">
                </asp:CheckBoxList>
                <asp:HiddenField ID="hidAccess" runat="server" />
                <br class="clear" />
            </p>
        </asp:Panel>
        <asp:Panel ID="pnlAuditTrail" runat="server" CssClass="form-editor-container">
            <uc:AuditTrail ID="AuditTrail1" runat="server"></uc:AuditTrail>
        </asp:Panel>
    </div>
</asp:Content>