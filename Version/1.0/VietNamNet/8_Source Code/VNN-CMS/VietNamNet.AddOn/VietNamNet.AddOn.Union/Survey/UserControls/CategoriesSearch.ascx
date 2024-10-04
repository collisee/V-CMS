<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoriesSearch.ascx.cs" Inherits="VietNamNet.AddOn.Survey.UserControls.CategoriesSearch" %>

     <telerik:RadAjaxManager ID="radAjaxManager1" runat="server" DefaultLoadingPanelID="radAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ibtnSearch">
                <UpdatedControls> 
                    <telerik:AjaxUpdatedControl ControlID="grdView" />
                </UpdatedControls> 
            </telerik:AjaxSetting> 
             <telerik:AjaxSetting AjaxControlID="grdView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdView" />  
                    <telerik:AjaxUpdatedControl ControlID="txtSelectedCategory" />  
                </UpdatedControls>
            </telerik:AjaxSetting>   
        </AjaxSettings>
     </telerik:RadAjaxManager>
<asp:Panel ID="pnlSearch" runat="server" CssClass="pd05 pb00">

    <telerik:RadTextBox ID="txtSearch" runat="server" CssClass="label w450" Text=""></telerik:RadTextBox> 
    <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/Images/SmallIcon/75.png" CssClass="cpointer" OnClick="OnFilterChanged" />

    <br class="clear" />
</asp:Panel>
<p>
     <telerik:RadGrid ID="grdView" runat="server" AutoGenerateColumns="False"
                        GridLines="None"  Style="outline: none"  AllowSorting="False" AllowPaging="true"   
                        OnPageIndexChanged="GrdViewPageIndexChanged"  
                        OnItemCommand="GrdViewItemCommand" >
                <MasterTableView ClientDataKeyNames="Id" DataKeyNames="Id"  
                        GroupLoadMode="Client"  
                        NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o. ">
                    <Columns>    
                        <telerik:GridTemplateColumn HeaderText="#" HeaderStyle-Width="50px"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="cmdSelect" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' CommandName="Select" OnClientClick="selectTab('tConfig');" ToolTip="Chọn danh mục" ><img src="/Images/LargeIcon/add.png" width="16px" /></asp:LinkButton>&nbsp;&nbsp;
                            </ItemTemplate> 
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Tên danh mục"  ItemStyle-Width="300">
                            <ItemTemplate> 
                                <label><%# DataBinder.Eval(Container.DataItem,"Name") %></label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Tên hiển thị (Alias)"  ItemStyle-Width="300">
                           <ItemTemplate>
                                <label><%# DataBinder.Eval(Container.DataItem,"DisplayName") %> (<%# DataBinder.Eval(Container.DataItem,"Alias") %>)</label>                            
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns> 
                </MasterTableView>  
                 <ClientSettings AllowRowsDragDrop="False" EnableRowHoverStyle="False">
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"/>
                    <Resizing AllowColumnResize="True" />
                    <%--<ClientEvents OnRowDblClick="RowDblClick" OnRowDropping="onRowDropping" />--%>
                </ClientSettings>
                <PagerStyle Mode="NextPrevAndNumeric" Position="TopAndBottom" />
            </telerik:RadGrid>
</p> 
<asp:TextBox ID="txtSelectedCategory" runat="server" Visible="false"  />