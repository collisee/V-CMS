<%@ Page MasterPageFile="~/Default.Master"  Language="C#" AutoEventWireup="true" CodeBehind="ReportByGroup.aspx.cs" Inherits="VietNamNet.AddOn.CMS.Reports.ReportByGroup" EnableEventValidation="false" %>

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
                <telerik:RadToolBarButton Value="searchGroup" CommandName="searchGroupComboBox">
				    <ItemTemplate>
                        <asp:Label ID="lblGroup" runat="server" Text="Nhóm: "></asp:Label>
                        <telerik:RadComboBox ID="cboGroup" runat="server" DataValueField="GroupId" DataTextField="GroupName" 
                                    EmptyMessage="Tất cả" Width="200px">
                        </telerik:RadComboBox>
                        <asp:CheckBox runat="server" Text="Hiển thị Những người dùng không có bài" ID="chkAllUser" TextAlign="Left" />
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

    <telerik:RadGrid ID="radGridDefault" runat="server" AutoGenerateColumns="false"  
                GridLines="None"   Style="outline: none"  
                AllowPaging="False" AllowSorting="False" OnItemCommand="RptGroupItemCommand">
            <MasterTableView   GroupLoadMode="Client" ShowGroupFooter="true"
                             NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o.">
            <Columns>  
                <telerik:GridTemplateColumn HeaderText="Trạng thái" >
                    <ItemTemplate> 
                        <%# DataBinder.Eval(Container.DataItem, "Status")%>  
                    </ItemTemplate> 
                </telerik:GridTemplateColumn>  
                <telerik:GridTemplateColumn HeaderText="Tên truy cập" >
                    <ItemTemplate> 
                        <%# DataBinder.Eval(Container.DataItem, "LoginName")%>  
                    </ItemTemplate> 
                </telerik:GridTemplateColumn>  
                 <telerik:GridTemplateColumn HeaderText="Tên đầy đủ" >
                    <ItemTemplate> 
                        <%# DataBinder.Eval(Container.DataItem, "FullName")%>  
                    </ItemTemplate> 
                </telerik:GridTemplateColumn>  
                <telerik:GridBoundColumn DataField="Total" HeaderText="Số lượng" ItemStyle-HorizontalAlign="right" 
                                         FooterText="Tổng cộng theo nhóm:" Aggregate="Sum"   ></telerik:GridBoundColumn>     
                 <telerik:GridTemplateColumn HeaderText="ID_NS" >
                    <ItemTemplate> 
                        <%# DataBinder.Eval(Container.DataItem, "ID_NS")%>  
                    </ItemTemplate> 
                </telerik:GridTemplateColumn>                    
                 <telerik:GridTemplateColumn HeaderText="Chức năng" >
                    <ItemTemplate> 
                        <asp:LinkButton runat="server" ID="cmdPreview"  CommandName="Preview" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%> ' ToolTip="Xem bài viết User này"> 
                            <img src="/Images/LargeIcon/paste.png" />
                        </asp:LinkButton>
                    </ItemTemplate> 
                </telerik:GridTemplateColumn>  
            </Columns>
            <GroupByExpressions>
                    <telerik:GridGroupByExpression>
                        <GroupByFields>
                            <telerik:GridGroupByField FieldName="GroupName" />
                        </GroupByFields>
                        <SelectFields>
                            <telerik:GridGroupByField FieldName="GroupName" HeaderText="Nhóm" />
                        </SelectFields>
                    </telerik:GridGroupByExpression> 
                </GroupByExpressions>
            </MasterTableView>
    </telerik:RadGrid>
</div>
</asp:Content>
