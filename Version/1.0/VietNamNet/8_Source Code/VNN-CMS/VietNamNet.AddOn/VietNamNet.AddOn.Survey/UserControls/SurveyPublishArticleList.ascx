<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyPublishArticleList.ascx.cs" Inherits="VietNamNet.AddOn.Survey.UserControls.SurveyPublishArticleList" %>
   <telerik:RadGrid ID="grdView" runat="server" AutoGenerateColumns="False"
                        GridLines="None"  Style="outline: none"  AllowSorting="False" AllowPaging="true"   
                        OnPageIndexChanged="GrdViewPageIndexChanged"  
                        OnItemCommand="GrdViewItemCommand" >
                <MasterTableView ClientDataKeyNames="SurveyPublishId" DataKeyNames="SurveyPublishId"  
                        GroupLoadMode="Client"  
                        NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o. ">
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="Tiêu đề"  HeaderStyle-Width="300">
                            <ItemTemplate> 
                                <label><%# DataBinder.Eval(Container.DataItem,"Name") %></label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Ngày Bắt Đầu -> Ngày Kết thúc"  HeaderStyle-Width="300">
                           <ItemTemplate>
                                <label><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "StartDate").ToString()).ToString("dd/MM/yyy") %></label> -->
                                <label><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "ExpireDate").ToString()).ToString("dd/MM/yyy") %></label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Chức năng"  HeaderStyle-Width="300">
                           <ItemTemplate>
                                <asp:LinkButton ID="cmdExpire" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"SurveyPublishId") %>' CommandName="Expire"  ToolTip="Kết thúc Bình chọn này" ><img src="/Images/SmallIcon/30.png" /></asp:LinkButton> 
                                <a href="#" onclick="editSurveyPublish('<%# DataBinder.Eval(Container.DataItem,"SurveyPublishId") %>');"  ToolTip="Câu hình hiển thị Bình chọn này"><img src="/Images/SmallIcon/29.png" /></a>
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
<asp:TextBox ID="txtSurveyId" runat="server" Visible="false" ></asp:TextBox>
<asp:TextBox ID="txtSurveyPublishId" runat="server" Visible="false" ></asp:TextBox>
<asp:Label runat="server" ID="lblMessages" ></asp:Label>
