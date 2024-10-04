﻿<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="ReportsByUser.aspx.cs" Inherits="VietNamNet.AddOn.Royalty.ReportsByUser" Title="Danh sách Tin bài" ValidateRequest="false" %>
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
                    <telerik:AjaxUpdatedControl ControlID="radToolBarDefault" />
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
<div class="pd05 pb00">
    <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnButtonClick="radToolBarDefault_ButtonClick"
            CssClass="panel-search-toolbar">
            <Items> 
                <telerik:RadToolBarButton Value="searchAuthor" CommandName="searchPublishDatePicker" runat="server">
				    <ItemTemplate>
                        <asp:Label ID="lblAuthorGroup" runat="server" Text="Loại tác giả: "></asp:Label>
                            <telerik:RadComboBox ID="cboIsMember" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="cboIsMember_SelectedIndexChanged">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
                                <Items>
                                    <telerik:RadComboBoxItem Text="- Toàn bộ -" Value="-1" runat="server" />
                                    <telerik:RadComboBoxItem Text="Ph&#243;ng vi&#234;n" Value="1" runat="server" />
                                    <telerik:RadComboBoxItem Text="Cộng t&#225;c vi&#234;n" Value="0" runat="server" />
                                </Items>
                            </telerik:RadComboBox>
                        <asp:Label ID="lblAuthor" runat="server" Text="Tác giả: "></asp:Label>
                            <telerik:RadComboBox ID="cboUser" runat="server"  DataTextField="Name" DataValueField="Id" Text="Tác giả:">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
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
                GridLines="None"   Style="outline: none" ShowFooter="True" 
                OnItemDataBound="radGridDefault_ItemDataBound" AllowPaging="False" AllowSorting="False">
            <MasterTableView ClientDataKeyNames="Fund_Id" DataKeyNames="Fund_Id" GroupLoadMode="Client"
                             NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o." 
                             ShowGroupFooter="true">
            <Columns> 
                     <telerik:GridBoundColumn HeaderText="Tác giả"  DataField="AuthorName" 
                                              FooterText="TG:" Aggregate="Custom"  />
                    <telerik:GridBoundColumn HeaderText="Chuyên mục"  DataField="DisplayName" 
                                              FooterText=" " Aggregate="Custom"   />
                    <telerik:GridTemplateColumn HeaderText="Tiêu đề" HeaderStyle-Width="100">
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "Name")%>  <br />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn> 
                     <telerik:GridTemplateColumn HeaderText="URL" HeaderStyle-Width="100">
                        <ItemTemplate>
                            <a title="xem chi tiết" href="<%#Utilities.GetConfigKey("WebsiteLink") + Utilities.GetArticleUrl(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"), DataBinder.Eval(Container.DataItem, "Name")) %>" target="_blank" title="Xem trước bài viết">
                               <%#Utilities.GetConfigKey("WebsiteLink") + Utilities.GetArticleUrl(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"), DataBinder.Eval(Container.DataItem, "Name")) %>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridBoundColumn HeaderText="Ngày XB"  DataField="PublishDate" ItemStyle-HorizontalAlign="center" DataFormatString="{0:dd/MM/yyyy hh:mm}" />
                     <telerik:GridBoundColumn HeaderText="Lượng truy cập"  DataField="NumberOfVisited" ItemStyle-HorizontalAlign="right"  DataFormatString="{0:#,##0}"  />
                     <telerik:GridBoundColumn HeaderText="Ngày chấm"  DataField="Pay_Date" ItemStyle-HorizontalAlign="center" DataFormatString="{0:dd/MM/yyyy hh:mm}"/>
                     <telerik:GridTemplateColumn HeaderText="Nhuận bút" ItemStyle-HorizontalAlign="Right"  >
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "Text_Fund").ToString().Trim() == "0" ? "" : DataBinder.Eval(Container.DataItem, "Text_Fund").ToString().Trim() == "" ? "" : "Nhuận bút: " + DataBinder.Eval(Container.DataItem, "Text_Fund") + " <br />"%>
                            <%#  DataBinder.Eval(Container.DataItem, "Image_Fund").ToString().Trim() == "0" ? "" : DataBinder.Eval(Container.DataItem, "Image_Fund").ToString().Trim() == "" ? "" : "Nhuận ảnh: " + DataBinder.Eval(Container.DataItem, "Image_Fund") + " <br />"%>
                            <%#  DataBinder.Eval(Container.DataItem, "Audio_Fund").ToString().Trim() == "0" ? "" : DataBinder.Eval(Container.DataItem, "Audio_Fund").ToString().Trim() == "" ? "" : "Nhuận Audio: " + DataBinder.Eval(Container.DataItem, "Audio_Fund") + " <br />"%>
                            <%# DataBinder.Eval(Container.DataItem, "Video_Fund").ToString().Trim() == "0" ? "" : DataBinder.Eval(Container.DataItem, "Video_Fund").ToString().Trim() == "" ? "" : "Nhuận Video: " + DataBinder.Eval(Container.DataItem, "Video_Fund") + " <br />"%>
                            <%#  DataBinder.Eval(Container.DataItem, "Other_Fund").ToString().Trim() == "0" ? "" : DataBinder.Eval(Container.DataItem, "Other_Fund").ToString().Trim() == "" ? "" : "Nhuận bút khác: " + DataBinder.Eval(Container.DataItem, "Other_Fund") + " <br />"%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn HeaderText="Tổng cộng"  DataField="TotalFund" ItemStyle-HorizontalAlign="Right"
                                            FooterText="TC:" Aggregate="Sum"/>
                     <telerik:GridBoundColumn HeaderText="Nguồn tin"  DataField="TypeName" />
                     <telerik:GridBoundColumn HeaderText="Ghi chú"  DataField="Notes" />
                     
 
            </Columns>
             <GroupByExpressions>
                     <telerik:GridGroupByExpression>
                        <GroupByFields>
                            <telerik:GridGroupByField FieldName="AuthorName" />
                        </GroupByFields>
                        <SelectFields>
                            <telerik:GridGroupByField FieldName="AuthorName" HeaderText="Tác giả: " />
                        </SelectFields>
                    </telerik:GridGroupByExpression> 
                </GroupByExpressions>
            </MasterTableView>
    </telerik:RadGrid>
</div>
</asp:Content>
