<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="ReportsByGroup.aspx.cs" Inherits="VietNamNet.AddOn.Royalty.ReportsByGroup" Title="Danh sách Tin bài" ValidateRequest="false" %>
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
                        <asp:Label ID="lblAuthor" runat="server" Text="Tác giả: "></asp:Label>
                            <telerik:RadComboBox ID="cboUser" runat="server"  DataTextField="Name" DataValueField="Id" Text="Tác giả:">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
                            </telerik:RadComboBox>
				    </ItemTemplate>
				</telerik:RadToolBarButton>
				<telerik:RadToolBarButton Value="searchDateButton" CommandName="searchPublishDatePicker" runat="server">
				    <ItemTemplate>
                        <asp:Label ID="lblPublishDate" runat="server" Text="Ngày chấm: "></asp:Label>
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
                OnItemDataBound="radGridDefault_ItemDataBound" AllowPaging="False" AllowSorting="False">
            <MasterTableView ClientDataKeyNames="Fund_Id" DataKeyNames="Fund_Id" GroupLoadMode="Client"
                             NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o.">
            <Columns> 
                 <telerik:GridTemplateColumn HeaderText="Nhóm" >
                        <ItemTemplate> 
                           <i> <%# DataBinder.Eval(Container.DataItem, "Author_Group")%>: </i>
                             <%# DataBinder.Eval(Container.DataItem, "ID_NS") == "" ? "" : "[IDNS:" + DataBinder.Eval(Container.DataItem, "ID_NS") + "]"%> 
                             <%# DataBinder.Eval(Container.DataItem, "Author_Name")%>  
                        </ItemTemplate> 
                    </telerik:GridTemplateColumn> 
                   <telerik:GridTemplateColumn HeaderText="Tiêu đề" HeaderStyle-Width="75">
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "[Name]")%>  
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="URL" HeaderStyle-Width="150">
                        <ItemTemplate>
                             <a title="xem chi tiết" href="<%#Utilities.GetConfigKey("WebsiteLink") + Utilities.GetArticleUrl(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Article_Id"), DataBinder.Eval(Container.DataItem, "Name")) %>" target="_blank" title="Xem trước bài viết">
                                   <%#Utilities.GetConfigKey("WebsiteLink") + Utilities.GetArticleUrl(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Article_Id"), DataBinder.Eval(Container.DataItem, "Name")) %>
                             </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridBoundColumn HeaderText="Ngày XB"  DataField="PublishDate" DataFormatString="{0:dd/MM/yyyy hh:mm}" />
                     <telerik:GridBoundColumn HeaderText="Lượng truy cập"  DataField="NumberOfVisited" ItemStyle-HorizontalAlign="right" DataFormatString="{0:#,##0}"  />

                     <telerik:GridBoundColumn HeaderText="Ngày chấm"  DataField="Pay_Date" DataFormatString="{0:dd/MM/yyyy hh:mm}"/>
                   <telerik:GridTemplateColumn HeaderText="Nhuận bút"  >
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "Text_Fund").ToString().Trim() == "0" ? "" : DataBinder.Eval(Container.DataItem, "Text_Fund").ToString().Trim() == "" ? "" : "Nhuận bút: " + DataBinder.Eval(Container.DataItem, "Text_Fund") + " <br />"%>
                            <%#  DataBinder.Eval(Container.DataItem, "Image_Fund").ToString().Trim() == "0" ? "" : DataBinder.Eval(Container.DataItem, "Image_Fund").ToString().Trim() == "" ? "" : "Nhuận ảnh: " + DataBinder.Eval(Container.DataItem, "Image_Fund") + " <br />"%>
                            <%#  DataBinder.Eval(Container.DataItem, "Audio_Fund").ToString().Trim() == "0" ? "" : DataBinder.Eval(Container.DataItem, "Audio_Fund").ToString().Trim() == "" ? "" : "Nhuận Audio: " + DataBinder.Eval(Container.DataItem, "Audio_Fund") + " <br />"%>
                            <%# DataBinder.Eval(Container.DataItem, "Video_Fund").ToString().Trim() == "0" ? "" : DataBinder.Eval(Container.DataItem, "Video_Fund").ToString().Trim() == "" ? "" : "Nhuận Video: " + DataBinder.Eval(Container.DataItem, "Video_Fund") + " <br />"%>
                            <%#  DataBinder.Eval(Container.DataItem, "Other_Fund").ToString().Trim() == "0" ? "" : DataBinder.Eval(Container.DataItem, "Other_Fund").ToString().Trim() == "" ? "" : "Nhuận bút khác: " + DataBinder.Eval(Container.DataItem, "Other_Fund") + " <br />"%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                     <telerik:GridBoundColumn HeaderText="Tổng cộng"  DataField="TotalFund" ItemStyle-HorizontalAlign="Right"/>
                     <telerik:GridTemplateColumn HeaderText="Lượng truy cập"  >
                        <ItemTemplate>
                            <%#  DataBinder.Eval(Container.DataItem, "NumberOfVisited").ToString()%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridBoundColumn HeaderText="Nguồn tin"  DataField="Type_Name" />
                     <telerik:GridBoundColumn HeaderText="Ghi chú"  DataField="Notes" />
                     
                     
            </Columns>
            </MasterTableView>
    </telerik:RadGrid>
</div>
</asp:Content>
