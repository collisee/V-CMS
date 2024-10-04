<%@ Page MasterPageFile="~/Default.Master"  Language="C#" AutoEventWireup="true" CodeBehind="ReportByCat.aspx.cs" Inherits="VietNamNet.AddOn.CMS.Reports.ReportByCat" EnableEventValidation="false" %>

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
  <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" RelativeTo="Element"
            Position="MiddleRight" AutoTooltipify="true" ContentScrolling="Default"
            Width="200" Height="10">
        </telerik:RadToolTipManager>
    
</div>


    <div class="pd05">
    <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick"
            CssClass="panel-search-toolbar">
            <Items> 
                <telerik:RadToolBarButton Value="searchCategory" CommandName="searchCategoryComboBox">
				    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text="Danh mục: "></asp:Label>
                        <telerik:RadComboBox ID="cboCategory" runat="server" DataValueField="Id" DataTextField="Name" 
                                    EmptyMessage="Tất cả" Width="200px">
                        </telerik:RadComboBox>
				    </ItemTemplate>
				</telerik:RadToolBarButton>
				<telerik:RadToolBarButton Value="searchDateButton" CommandName="searchPublishDatePicker" runat="server">
				    <ItemTemplate>
                        <asp:Label ID="lblPublishDate" runat="server" Text="Ngày XB: "></asp:Label>
                        <telerik:RadDatePicker ID="txtDateFrom" runat="server" Width="90px" Culture="Vietnamese (Vietnam)" MinDate="01/01/1753">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                            </Calendar>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
                        <asp:Label ID="lblSep" runat="server" Text="->"></asp:Label>
                        <telerik:RadDatePicker ID="txtDateTo" runat="server" Width="90px" Culture="Vietnamese (Vietnam)" MinDate="01/01/1753" >
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                            </Calendar>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
				    </ItemTemplate>
				</telerik:RadToolBarButton>
                <telerik:RadToolBarButton ImageUrl="~/Images/SmallIcon/75.png" Value="search" CommandName="Search" runat="server" />
            </Items>
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </telerik:RadToolBar>
    
</div>

<div class="pd05">

<asp:Label runat="server" ID="lblMessage" ForeColor="red"></asp:Label>

    <telerik:RadGrid ID="radGridDefault" runat="server" AutoGenerateColumns="False"  
                GridLines="None"   Style="outline: none"  
                AllowPaging="False" AllowSorting="False" OnItemCommand="RptGroupItemCommand">
            <MasterTableView ClientDataKeyNames="CategoryId" DataKeyNames="CategoryId" GroupLoadMode="Client"
                             NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o.">
            <Columns> 
                 <telerik:GridTemplateColumn HeaderText="Chuyên mục" >
                    <ItemTemplate> 
                     <%# DataBinder.Eval(Container.DataItem, "Name")%> 
                    </ItemTemplate> 
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Tên hiển thị (Alias)" >
                    <ItemTemplate> 
                        <%# DataBinder.Eval(Container.DataItem, "DisplayName")%> 
                     (<%# DataBinder.Eval(Container.DataItem, "Alias")%>)
                    </ItemTemplate> 
                </telerik:GridTemplateColumn>  
                <telerik:GridBoundColumn DataField="Total" HeaderText="Số lượng" ItemStyle-HorizontalAlign="right" ></telerik:GridBoundColumn>     
                 <telerik:GridTemplateColumn HeaderText="Chức năng" >
                    <ItemTemplate> 
                        <asp:LinkButton runat="server" ID="cmdPreview"  CommandName="Preview" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CategoryId")%> ' ToolTip="Xem bài viết Chuyên mục này"> 
                            <img src="/Images/LargeIcon/paste.png" />
                        </asp:LinkButton>
                    </ItemTemplate> 
                </telerik:GridTemplateColumn>  
                     
            </Columns>
            </MasterTableView>
    </telerik:RadGrid>
</div>
</asp:Content>
