<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="PopupImportCsv.aspx.cs" Inherits="VietNamNet.AddOn.VCard.PopupImportCsv" Title="Tải thông tin VCard từ file" %>
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
                {   case 'Cancel':
                        closeWin();
                        break;
                    default:
                        break;
                };
            }
        </script>

    </telerik:RadScriptBlock>

     <div class="pd05">
     <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" 
                                OnClientButtonClicking="radToolBarDefault_ClientButtonClicking" 
                                OnButtonClick="radToolBarDefault_ButtonClick">
                <Items> 
                     <telerik:RadToolBarButton runat="server"
                                    CommandName="Read" Value="Read"
                                    Text="Xem trước (R)" AccessKey="R">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server"
                                    CommandName="Update" Value="Update"
                                    Text="Cập nhật (U)" AccessKey="U">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" 
                                    CommandName="Cancel" Value="Cancel"
                                    Text="Đóng (C)" AccessKey="C">
                    </telerik:RadToolBarButton>
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        
        <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
            <asp:Label runat="server" ID="lblMessage" ForeColor="red"></asp:Label>
            
          <asp:Panel  class="rpCheckBoxPanel" runat="server" ID="pnUpload">
            <label>Đọc thông tin từ file VCard:</label>
            <asp:FileUpload ID="FileUpload1" runat="server" />  
          </asp:Panel>
          
          
<div class="pd05">
                <telerik:RadGrid ID="grdView" runat="server" AutoGenerateColumns="False"
                        GridLines="None"  Style="outline: none"  AllowSorting="False" 
                        AllowPaging="false"    
                         > 
                         <MasterTableView ClientDataKeyNames="ContactId" DataKeyNames="ContactId"  
                        GroupLoadMode="Client"  
                        NoMasterRecordsText="Kh&#244;ng c&#243; bản ghi n&#224;o. ">
                    <Columns>
                        
                        <telerik:GridTemplateColumn HeaderText="Họ tên<br>   (Chức danh)" >
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem,"Fullname") %><br />
                                <%# DataBinder.Eval(Container.DataItem, "OrgTitle") == null ? "" : "(" + DataBinder.Eval(Container.DataItem, "OrgTitle") + ")"%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Công ty / tổ chức" >
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem,"OrgName") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Phone" ItemStyle-Width="110" >
                            <ItemTemplate>
                                Phone: <%# DataBinder.Eval(Container.DataItem, "OrgPhone")%><br />
                                Mobile: <%# DataBinder.Eval(Container.DataItem, "OrgMobile")%><br />
                                Fax: <%# DataBinder.Eval(Container.DataItem, "OrgFax")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Email" >
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem,"OrgEmail1") %><br />
                                <%# DataBinder.Eval(Container.DataItem,"OrgEmail2") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn> 
                    </Columns> 
                </MasterTableView>  
                 <ClientSettings  AllowColumnsReorder="true" ReorderColumnsOnClient="true" >
                    <Resizing  EnableRealTimeResize="True" AllowColumnResize="true" ></Resizing>
                 </ClientSettings>
                <PagerStyle Mode="NextPrevAndNumeric" Position="TopAndBottom" />
            </telerik:RadGrid>
</div>
          </asp:Panel>
     </div>
 
    
</asp:Content>

