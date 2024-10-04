<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="PopupGroupPolicy.aspx.cs" Inherits="VietNamNet.CMS.PopupGroupPolicy" Title="Phân quyền" %>
<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Register Src="~/UserControls/ErrorMessage.ascx" TagName="ErrorMessage" TagPrefix="uc" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <telerik:RadScriptBlock ID="radScriptBlockManager" runat="server">

        <script type="text/javascript">
            function GetRadWindow()
            {
               var oWindow = null;
               if (window.radWindow) oWindow = window.radWindow;
               else if (window.frameElement && window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
               return oWindow;
            }

            function closeWin()
            {
                //get a reference to the RadWindow
                var oWnd = GetRadWindow();

                //close the RadWindow            
                if (oWnd) oWnd.close();
                else window.close();
            }
            
            function radToolBarDefault_ClientButtonClicking(sender, eventArgs)
            {
                var cmd = eventArgs.get_item().get_commandName();
                switch (cmd)
                {
                    case 'Cancel':
                        eventArgs.set_cancel(true);
                        closeWin();
                        break;
                    case 'Save':
                        eventArgs.set_cancel(false);
                        break;
                    default:
                        break;
                };
            }
            
            function radToolBarDefault_ClientButtonClicked(sender, eventArgs)
            {
                var cmd = eventArgs.get_item().get_commandName();
                switch (cmd)
                {
                    case 'Cancel':
                        closeWin();
                        break;
                    default:
                        break;
                };
            }
        </script>

    </telerik:RadScriptBlock>
    <telerik:RadAjaxLoadingPanel ID="radAjaxLoadingPanel" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div class="pd05">
        <telerik:RadAjaxPanel ID="radAjaxPanelView" runat="server" LoadingPanelID="radAjaxLoadingPanel">
            <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
                <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnClientButtonClicked="radToolBarDefault_ClientButtonClicked"
                    OnButtonClick="radToolBarDefault_ButtonClick" OnClientButtonClicking="radToolBarDefault_ClientButtonClicking">
                    <Items>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveitem.gif" CommandName="Save"
                            Text="Lưu Policy" AccessKey="S">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/goback1.gif" CommandName="Cancel"
                            Text="Đóng" AccessKey="C">
                        </telerik:RadToolBarButton>
                    </Items>
                    <CollapseAnimation Duration="200" Type="OutQuint" />
                </telerik:RadToolBar>
            </asp:Panel>
            <asp:Panel ID="pnlRadGrid" runat="server" CssClass="radgrid">
                <uc:ErrorMessage ID="ErrorMessage1" runat="server" Visible="false" />
                <p>
                    <asp:Label ID="lblMessage" runat="server" CssClass="blue" Text="" Visible="false"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="lblGroupLabel" runat="server" CssClass="label w150" Text="Nhóm:"></asp:Label>
                    <telerik:RadComboBox ID="radCmbGroup" runat="server" Width="400px" AutoPostBack="True"
                        OnSelectedIndexChanged="radCmbGroup_SelectedIndexChanged" DataTextField="Name" DataValueField="Id">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                    </telerik:RadComboBox>
                    <br class="clear" />
                </p>
                <br class="clear" />
                <telerik:RadTreeView runat="server" ID="radTreeViewPolicy" DataValueField="Id" DataFieldId="CategoryId"
                    DataFieldParentID="CategoryPId" DataTextField="CategoryDisplayName" CheckBoxes="True" OnNodeDataBound="radTreeViewPolicy_NodeDataBound" OnNodeCheck="radTreeViewPolicy_NodeCheck">
                    <CollapseAnimation Type="OutQuint" Duration="100"></CollapseAnimation>
                    <ExpandAnimation Duration="100"></ExpandAnimation>
                </telerik:RadTreeView>
            </asp:Panel>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>