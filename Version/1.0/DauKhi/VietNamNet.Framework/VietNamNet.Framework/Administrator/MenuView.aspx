<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="MenuView.aspx.cs" Inherits="VietNamNet.Framework.Administrator.MenuView" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
	<telerik:RadScriptBlock runat="server" ID="RadScriptBlock1">
	
        <script type="text/javascript">
            //<!--
                function onClientContextMenuShowing(sender, args)
                {
                    var treeNode = args.get_node();
                    treeNode.set_selected(true);
                    //enable/disable menu items
                    setMenuItemsState(args.get_menu().get_items(), treeNode);
                }
                
                function onClientContextMenuItemClicking(sender, args)
                {
                    var menuItem = args.get_menuItem();
                    var treeNode = args.get_node();
                    menuItem.get_menu().hide();
                    
                    switch(menuItem.get_value())
                    {
                        case "AddNew":
                            break;
                        case "View":
                            break;
                        case "Edit":
                            break;
                        case "Copy":
                            break;
                        case "Rename":
                            treeNode.startEdit();
                            break;
                        case "Delete":
                            var result = confirm("Bạn có chắc chắn muốn xóa menu này: " + treeNode.get_text());
                            args.set_cancel(!result);
                            break;                            
                    }
                }
                
                //this method disables the appropriate context menu items
                function setMenuItemsState(menuItems, treeNode)
                {
                    for (var i=0; i<menuItems.get_count(); i++)
                    {
                        var menuItem = menuItems.getItem(i);
                        switch(menuItem.get_value())
                        {
                            case "AddNew":
                                break;
                            case "View":
                                formatMenuItem(menuItem, treeNode, 'Xem "{0}"');
                                break;
                            case "Edit":
                                formatMenuItem(menuItem, treeNode, 'Chỉnh sửa "{0}"');
                                break;
                            case "Copy":
                                formatMenuItem(menuItem, treeNode, 'Copy "{0}"');
                                break;
                            case "Rename":
                                formatMenuItem(menuItem, treeNode, 'Đổi tên "{0}"');
                                break;
                            case "Delete":
                                formatMenuItem(menuItem, treeNode, 'Xóa "{0}"');
                                break;                                
                        }
                    }
                }
                
                //formats the Text of the menu item
                function formatMenuItem(menuItem, treeNode, formatString)
                {
                    var nodeValue = treeNode.get_value();
                    if (nodeValue && nodeValue.indexOf("_Private_") == 0)
                    {
                        menuItem.set_enabled(false);
                    }
                    else
                    {
                        menuItem.set_enabled(true);
                    }
                    var newText = String.format(formatString, extractTitleWithoutMails(treeNode));
                    menuItem.set_text(newText);
                }
                
                //removes the brackets with the numbers,e.g. Inbox (30)
                function extractTitleWithoutMails(treeNode)
                {
                    return treeNode.get_text().replace(/\s*\([\d]+\)\s*/ig, "");
                }                                                
            //-->
        </script>
	
    </telerik:RadScriptBlock>
	<telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radTreeViewMenu">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radTreeViewMenu" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
	<telerik:RadAjaxLoadingPanel runat="server" ID="radAjaxLoadingPanel1">
	</telerik:RadAjaxLoadingPanel>
    <div class="pd05 pb00">
        <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick">
            <Items>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/21.png" CommandName="AddNew"
                    Text="Tạo mới" AccessKey="N">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SmallIcon/77.png" CommandName="Optimize"
                    Text="Optimize" AccessKey="O">
                </telerik:RadToolBarButton>
            </Items>
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </telerik:RadToolBar>
    </div>
    <div class="pd05">
	    <telerik:RadTreeView ID="radTreeViewMenu" Runat="server" DataFieldID="Id" DataFieldParentID="PId" DataTextField="DisplayName" DataValueField="Id"
	     AllowNodeEditing="true" OnClientContextMenuItemClicking="onClientContextMenuItemClicking"
            OnClientContextMenuShowing="onClientContextMenuShowing" OnContextMenuItemClick="radTreeViewMenu_ContextMenuItemClick" OnNodeEdit="radTreeViewMenu_NodeEdit"
            EnableDragAndDrop="True" EnableDragAndDropBetweenNodes="true" OnNodeDrop="radTreeViewMenu_NodeDrop">
            <ContextMenus>
                <telerik:RadTreeViewContextMenu ID="MainContextMenu" runat="server">
                    <Items>
                        <telerik:RadMenuItem Value="AddNew" Text="Thêm menu con" ImageUrl="~/Images/SmallIcon/21.png">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Value="View" Text="Xem menu" ImageUrl="~/Images/SmallIcon/22.png">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Value="Edit" Text="Chỉnh sửa menu" ImageUrl="~/Images/SmallIcon/24.png">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem IsSeparator="true">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Value="Copy" Text="Copy ..." ImageUrl="~/Images/10.gif">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Value="Rename" Text="Đổi tên ..." Enabled="false" ImageUrl="~/Images/rename.gif" PostBack="false">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Value="Delete" Text="Xóa menu" ImageUrl="~/Images/7.gif">
                        </telerik:RadMenuItem>
                    </Items>
                    <CollapseAnimation Type="none" />
                </telerik:RadTreeViewContextMenu>
            </ContextMenus>
        </telerik:RadTreeView>
    </div>
</asp:Content>