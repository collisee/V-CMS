<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelPersonInfo.ascx.cs"
    Inherits="VietNamNet.AddOn.Union.UserControls.PanelPersonInfo" %>
<div>
    <div class="bg-title1">
        <div class="bg-title2">
            <div class="bg-title3">
                <a href="#" class="title">Góc riêng tư</a>
            </div>
        </div>
    </div>
    <asp:Panel ID="PanelLogin" runat="server">
        <div class="block-body">
            <div class="div-login div-login1">
                <div>
                    <p class="center pm0">
                        <asp:Label ID="lblError" runat="server" Text="" CssClass="red"></asp:Label>
                    </p>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Login"
                        ErrorMessage="Bạn phải nhập <b>Tên đăng nhập</b><br />" Display="Dynamic" ControlToValidate="txtLoginName"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblLoginName" runat="server" Text="Người dùng"></asp:Label>
                    <asp:TextBox ID="txtLoginName" runat="server" ValidationGroup="Login" class="login-form">
                    </asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Login"
                        ErrorMessage="Bạn phải nhập <b>Mật khẩu</b><br />" Display="Dynamic" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblPassword" runat="server" Text="Mật khẩu"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ValidationGroup="Login"
                        class="login-form">
                    </asp:TextBox>
                </div>
                <div>
                    <asp:ImageButton ID="ibtnSubmit" runat="server" OnClick="btnSubmit_Click" ImageUrl="~/data/login.gif" Width="71px" Height="16px" ValidationGroup="Login" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelUserInfo" runat="server">
        <div class="block-body">
            <div class="pri_item1">
                Xin chào : <font class="acc"><em>
                    <asp:Label runat="server" ID="lblUsersOnline" a Text="Label"></asp:Label></em></font>
            </div>
            <div class="pri_item2">
                <a href="/Union/Userinfo.aspx">Thông tin cá nhân</a>
            </div>
            <div class="pri_item2">
                <a href="/Messages/MessageView.aspx">Tin nhắn của bạn (<asp:Label ID="lblMessagesNumber"
                    runat="server" Text="0" CssClass="bold"></asp:Label>
                    tin)</a>
            </div>
            <div class="pri_item2">
                <a href="/Default.aspx">Trang quản trị</a>
            </div>
            <div class="pri_item2">
                <a href="/Logout.aspx">Thoát</a>
            </div>
            <div class="acc_title">
                Ảnh đại diện
            </div>
            <div class="acc_img">
                <asp:Image ID="imgAvatar" runat="server" CssClass="avata" Width="150px" Height="150px"
                    ImageUrl="/Styles/data/demo_l.jpg" />
                <div class="acc_text">
                    <a href="/Union/UserInfo.aspx"><i>Thay đổi ảnh đại diện</i></a></div>
            </div>
        </div>
    </asp:Panel>
    <div class="bg-bgtitle1">
        <div class="bg-bgtitle2">
            <div class="bg-bgtitle3">
                &nbsp;
            </div>
        </div>
    </div>
</div>
