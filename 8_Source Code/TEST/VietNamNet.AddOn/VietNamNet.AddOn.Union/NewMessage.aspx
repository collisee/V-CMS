<%@ Page Language="C#" MasterPageFile="Forum.Master" AutoEventWireup="true" Codebehind="NewMessage.aspx.cs"
  Inherits="VietNamNet.AddOn.Union.NewMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplhContainer" runat="server">
  <table id="Table1" width="100%" border="0">
    <tr>
      <td>
        &nbsp;
      </td>
      <td>
        <asp:Label ID="lblStatus" runat="server" Font-Bold="True">Tạo chủ đề mới</asp:Label>
      </td>
    </tr>
    <tr>
      <td>
        &nbsp;
      </td>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        &nbsp;
      </td>
      <td>
        <table id="Table2" height="370" width="100%" border="0" cellspacing="1">
          <%--<tr>
            <td colspan="2">
              <font face="arial" size="3"><b>Create New Comment</b>
                <hr>
                <font face="Arial"><font size="2"><font color="maroon"></font></font></font></font>
            </td>
          </tr>--%>
          <tr valign="middle">
            <td valign="middle" nowrap align="left" width="10%">
              <font face="Arial" size="2">Loại chủ đề:</font></td>
            <td valign="top">
              <font face="Arial" size="2">
                <input type="radio" name="MsgType" id="MsgType_4" value="4" runat="server">
                <label for="MsgType_4">
                  <img title='Question' align="absMiddle" src='images/question.gif'>
                  Question &nbsp;&nbsp;</label>
                <input type="radio" name="MsgType" id="MsgType_1" value="1" checked runat="server">
                <label for="MsgType_1">
                  <img title='General Comment' align="absMiddle" src='images/general.gif'>
                  General &nbsp;&nbsp;</label>
                <input type="radio" name="MsgType" id="MsgType_2" value="2" runat="server">
                <label for="MsgType_2">
                  <img title='News' align="absMiddle" src='images/info.gif'>
                  News &nbsp;&nbsp;</label>
                <!--<input type="radio" name="MsgType" ID="MsgType_3" value="3" runat="server">
										<Label for="MsgType_8"><img title='Answer' align="absMiddle" src='images/answer.gif'>
											Answer &nbsp;&nbsp;</Label> -->
                <input type="radio" name="MsgType" id="MsgType_5" value="5" runat="server" onserverchange="MsgType_5_ServerChange">
                <label for="MsgType_16">
                  <img title='Joke / Game' align="absMiddle" src='images/game.gif'>
                  Joke/Game&nbsp;&nbsp;&nbsp;</label></font></td>
          </tr>
          <tr>
            <td width="10%" align="left">
              <font face="Arial" size="2">Tiêu đề</font></td>
            <td>
              <asp:TextBox ID="txtsubject" runat="server" Width="500px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" Font-Names="Arial"
                Font-Size="10pt" ControlToValidate="txtsubject" ErrorMessage="Subject Required"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td valign="top" align="left">
              <font face="Arial" size="2">Nội dung:</font></td>
            <td>
              <font face="Arial">
                <asp:TextBox ID="txtcomment" runat="server" Font-Size="10pt" Height="244px" Width="500px"
                  TextMode="MultiLine" Font-Names="Arial"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="Comment required" ControlToValidate="txtcomment"
                    Font-Size="10pt"></asp:RequiredFieldValidator></font></td>
          </tr>
          <%--<tr>
            <td align="left">
              <font face="Arial" size="2">Name:</font></td>
            <td>
              <font face="Arial">
                <asp:TextBox ID="txtname" runat="server" Width="500px"></asp:TextBox><asp:RequiredFieldValidator
                  ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name required" ControlToValidate="txtname"
                  Font-Size="10pt"></asp:RequiredFieldValidator></font></td>
          </tr>
          <tr>
            <td align="left">
              <font face="Arial" size="2">Email:</font></td>
            <td>
              <font face="Arial">
                <asp:TextBox ID="txtemail" runat="server" Width="500px"></asp:TextBox><asp:RequiredFieldValidator
                  ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email required" ControlToValidate="txtemail"
                  Font-Size="10pt"></asp:RequiredFieldValidator></font></td>
          </tr>
          <tr>
            <td align="left">
              <font face="Arial" size="2">User Profile/URL</font></td>
            <td>
              <asp:TextBox ID="txtProfile" runat="server" Width="500px" OnTextChanged="txtProfile_TextChanged">http://codeproject.com</asp:TextBox></td>
          </tr>--%>
          <tr>
            <td align="left">
              &nbsp;</td>
            <td>
              &nbsp;</td>
          </tr>
          <tr>
            <td align="left">
            </td>
            <td>
              <font size="5"><font face="Arial"><font size="2"><font color="maroon">
                <asp:Button ID="Button1" runat="server" Height="24" Width="90" Text="Cập nhật" OnClick="Button1_Click">
                </asp:Button>&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Width="90px" Height="24px" Text="Quay lại" CausesValidation="False"
                  OnClick="Button2_Click"></asp:Button></font></font></font></font></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>

  <script language="JavaScript1.2" defer>
						editor_generate('txtcomment');
  </script>

</asp:Content>
