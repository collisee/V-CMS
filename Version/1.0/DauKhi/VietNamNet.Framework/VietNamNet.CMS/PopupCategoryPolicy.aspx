<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="PopupCategoryPolicy.aspx.cs" Inherits="VietNamNet.CMS.PopupCategoryPolicy" Title="Phân quyền" %>
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
                    <asp:Label ID="lblCategoryLabel" runat="server" CssClass="label w150" Text="Category:"></asp:Label>
                    <telerik:RadComboBox ID="radCmbCategory" runat="server" Width="400px" AutoPostBack="True"
                        OnSelectedIndexChanged="radCmbCategory_SelectedIndexChanged" DataTextField="Name" DataValueField="Id">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                    </telerik:RadComboBox>
                    <br class="clear" />
                </p>
                <br class="clear" />
                <telerik:RadGrid ID="radGridDefault" runat="server" AllowCustomPaging="True" AutoGenerateColumns="False"
                    GridLines="None" OnItemDataBound="radGridDefault_ItemDataBound">
                    <MasterTableView ClientDataKeyNames="Id" DataKeyNames="Id" GroupLoadMode="Client"
                        NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o.">
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
                                    <%# Container.ItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Right" Width="32px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="GroupName" HeaderText="Nhóm người dùng" UniqueName="GroupName">
                                <HeaderStyle Font-Bold="True" Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Val" HeaderText="Access" UniqueName="Val" Visible="false">
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Quyền">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkPolicy" runat="server" Checked='<%# Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "Val")) == 1%>' />
                                    <asp:HiddenField ID="hidId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                                    <asp:HiddenField ID="hidGId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "GroupId")%>' />
                                    <asp:HiddenField ID="hidCId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CategoryId")%>' />
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings>
                        <Resizing AllowColumnResize="True" />
                    </ClientSettings>
                    <FilterMenu EnableTheming="True">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                    </FilterMenu>
                </telerik:RadGrid>
            </asp:Panel>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>
