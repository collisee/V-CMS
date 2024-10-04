<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelComment.ascx.cs"
  Inherits="VietNamNet.Websites.Petro.UserControls.News.PanelComment" %>
<div class="clear">
  ,</div>
<asp:Panel ID="pnlForm" runat="server">
  <div id="article-feedback">
    <div id="feedback-form" class="row">
      <div class="box-title">
        Ý kiến của bạn</div>
      <asp:Label ID="lblError" runat="server" CssClass="red" Text="Bạn phải nhập Tiêu đề và Nội dung."></asp:Label>
      <table>
        <tr>
          <td>
            <label for="username">
              Họ và tên: <em>(cần phải nhập)</em>
            </label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="&nbsp; Bạn phải nhập <b>Tiêu đề</b><br />"
              Display="Dynamic" ControlToValidate="txtName" ValidationGroup="PostComment"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtName" runat="server" class="ykien-title" MaxLength="255"></asp:TextBox>
          </td>
          <td>
            <label for="address">
              Địa chỉ:</label>
            <asp:TextBox ID="txtAddress" runat="server" class="ykien-title" MaxLength="255"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td>
            <label for="email">
              Email: <em>(không hiện lên trang)</em>
            </label>
            <asp:RegularExpressionValidator ErrorMessage="&nbsp; Bạn nhập <b>Email</b> chưa chính xác<br />"
              Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup="PostComment" ID="RegularExpressionValidator2" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtEmail" runat="server" class="ykien-title" MaxLength="255"></asp:TextBox>
          </td>
          <td>
            <label for="phone">
              Điện thoại: <em>(không hiện lên trang)</em>
            </label>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" ControlToValidate="txtPhone" runat="server" ErrorMessage="&nbsp; Bạn nhập <b>số điện thoại</b> chưa chính xác<br />" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtPhone" runat="server" class="ykien-title" MaxLength="255"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th colspan="2">
            <label for="mycomment">
              Nhận xét của bạn: <em>(gõ tiếng Việt có dấu, không quá 1000 chữ)</em>
            </label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="&nbsp; Bạn phải nhập <b>Nội dung</b><br />"
              Display="Dynamic" ControlToValidate="txtComment" ValidationGroup="PostComment"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="&nbsp; Bạn nhập nội dung quá dài<br />"
              Display="Dynamic" ControlToValidate="txtComment" ValidationGroup="PostComment"
              ValidationExpression="^[\W\w\D\d\t\n\S\s]{1,1000}$" Font-Bold="True"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtComment" runat="server" class="ykien-text" TextMode="MultiLine"
              MaxLength="1000"></asp:TextBox>
          </th>
        </tr>
        <tr>
          <th colspan="2">
            <asp:Button ID="btnSubmit" runat="server" Text="Gửi ý kiến" OnClick="btnSubmit_Click"
              ValidationGroup="PostComment" />
          </th>
        </tr>
      </table>
    </div>
  </div>
</asp:Panel>
<asp:Panel ID="pnlList" runat="server">
  <div id="feedback-list">
    <div id="item-list">
      <div class="box-title">
        Ý kiến của bạn</div>
      <asp:Repeater ID="rptComment" runat="server">
        <ItemTemplate>
          <div id="feedback-item">
            <div class="comment">
              <%#DataBinder.Eval(Container.DataItem, "Detail") %>
            </div>
            <div class="profile">
              <%#DataBinder.Eval(Container.DataItem, "Email") %>
            </div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div id="paging" class="pagy ">
      <asp:HyperLink ID="hplPrev" runat="server">Trang trước</asp:HyperLink>
      <asp:HyperLink ID="hplNext" runat="server">Trang sau</asp:HyperLink>      
    </div>
  </div>
</asp:Panel>