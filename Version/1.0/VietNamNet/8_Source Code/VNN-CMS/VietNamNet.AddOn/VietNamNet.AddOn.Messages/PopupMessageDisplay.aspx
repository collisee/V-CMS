<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="PopupMessageDisplay.aspx.cs" Inherits="VietNamNet.AddOn.Messages.PopupMessageDisplay" Title="Tin nhắn"%>
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

            function closeWin(receiverId, subject)
            {
                var arg = {receiverId: receiverId, subject: subject};
                //get a reference to the RadWindow
                var oWnd = GetRadWindow();

                //close the RadWindow            
                if (oWnd) oWnd.close(arg);
                else window.close(arg);
            }
            
            function radToolBarDefault_ClientButtonClicked(sender, eventArgs)
            {
                var cmd = eventArgs.get_item().get_commandName();
                switch (cmd)
                {
                    case 'Cancel':
                        closeWin();
                        break;
                    case 'Reply':
                        closeWin($get('<%=hidUserId.ClientID %>').value, $get('<%=hidSubject.ClientID %>').value);
                        break;
                    default:
                        break;
                };
            }
        </script>

    </telerik:RadScriptBlock>

    <div class="pd05">
        <asp:Panel ID="pnlToolbar" runat="server" CssClass="radtoolbar">
            <telerik:RadToolBar ID="radToolBarDefault" runat="server" OnClientButtonClicked="radToolBarDefault_ClientButtonClicked">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/goback1.gif" CommandName="Reply"
                        Text="Trả lời" AccessKey="A">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/MediaIcon/16x16/btn-close.png" CommandName="Cancel"
                        Text="Đóng" AccessKey="C">
                    </telerik:RadToolBarButton>
                </Items>
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </telerik:RadToolBar>
        </asp:Panel>
        <asp:Panel ID="pnlForm" runat="server" CssClass="form-editor-container">
            <asp:HiddenField ID="hidUserId" runat="server" />
            <asp:HiddenField ID="hidSubject" runat="server" />
            <p>
                <asp:Label ID="lblUserNameLabel" runat="server" CssClass="label w150" Text="Người gửi:"></asp:Label>
                <asp:Label ID="lblUserName" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblDateTimeLabel" runat="server" CssClass="label w150" Text="Giờ gửi:"></asp:Label>
                <asp:Label ID="lblDateTime" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblSubjectLabel" runat="server" CssClass="label w150" Text="Tiêu đề:"></asp:Label>
                <asp:Label ID="lblSubject" runat="server" CssClass="label w450" Text=""></asp:Label>
                <br class="clear" />
            </p>
            <p>
                <asp:Label ID="lblDetailLabel" runat="server" CssClass="label w150" Text="Nội dung:"></asp:Label>
                <asp:Label ID="lblDetail" runat="server" CssClass="label w450"></asp:Label>
                <br class="clear" />
            </p>
        </asp:Panel>
    </div>
</asp:Content>
