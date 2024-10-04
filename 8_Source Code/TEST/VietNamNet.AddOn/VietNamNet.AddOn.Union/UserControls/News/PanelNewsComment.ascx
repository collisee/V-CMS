<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelNewsComment.ascx.cs"
  Inherits="VietNamNet.AddOn.Union.UserControls.News.PanelNewsComment" %>
<div class="article">
  <asp:Panel ID="pnlList" runat="server">
    <div class="feedback">
      <div class="cm-title">
        Bình Luận</div>
      <asp:Repeater ID="rptComment" runat="server">
        <ItemTemplate>
          <div class="fb-item row">
            <div class="fb-item-title">
              <%#DataBinder.Eval(Container.DataItem, "Name") %>
              <font class="fb-profile">
                <%#DataBinder.Eval(Container.DataItem, "Email") %>
              </font>
            </div>
            <div class="fb-item-text">
              <div class="fb-img">
                <img src="<%#DataBinder.Eval(Container.DataItem, "Avatar") %>" width="50px" height="50px;" />
              </div>
              <b>
                <%#DataBinder.Eval(Container.DataItem, "Subject") %>
              </b>
              <br />
              <%#DataBinder.Eval(Container.DataItem, "Detail") %>
            </div>
            <div class="clear">
              '</div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
  </asp:Panel>
  <asp:Panel ID="pnlForm" runat="server">
    <div class="content-ykien">
      <div class="cm-title">
        Bình luận</div>
      <asp:Label ID="lblError" runat="server" CssClass="red" Text="Bạn phải nhập Tiêu đề và Nội dung."></asp:Label>
      <table cellpadding="0" cellspacing="0" width="100%" border="0">
        <tr>
          <td>
          </td>
          <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="&nbsp; Bạn phải nhập <b>Tiêu đề</b><br />"
              Display="Dynamic" ControlToValidate="txtTitle" ValidationGroup="PostComment"></asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>
          <td width="20%" align="right" valign="top" class="ykien-table">
            <asp:Label ID="Label1" runat="server" CssClass="red" Text="*"></asp:Label>
            Tiêu Đề :
          </td>
          <td width="80%" align="left" valign="top" class="ykien-table">
            <asp:TextBox ID="txtTitle" runat="server" class="ykien-title" MaxLength="255"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td>
          </td>
          <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="&nbsp; Bạn phải nhập <b>Nội dung</b><br />"
              Display="Dynamic" ControlToValidate="txtComment" ValidationGroup="PostComment"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="&nbsp; Bạn nhập nội dung quá dài<br />"
              Display="Dynamic" ControlToValidate="txtComment" ValidationGroup="PostComment"
              ValidationExpression="^[\W\w\D\d\t\n\S\s]{1,4000}$"></asp:RegularExpressionValidator>
          </td>
        </tr>
        <tr>
          <td valign="top" align="right" class="ykien-table">
            <asp:Label ID="Label2" runat="server" CssClass="red" Text="*"></asp:Label>
            Nội dung :
          </td>
          <td align="left" valign="top" class="ykien-table">
            <asp:TextBox ID="txtComment" runat="server" class="ykien-text" TextMode="MultiLine"
              MaxLength="4000"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td colspan="2" class="ykien-table" align="center">
            <asp:Button ID="btnSubmit" runat="server" Text="Gửi bình luận" OnClick="btnSubmit_Click"
              Width="70px" ValidationGroup="PostComment" /></td>
        </tr>
      </table>
    </div>
  </asp:Panel>
</div>

