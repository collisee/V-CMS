<%@ Page Language="C#" MasterPageFile="Forum.Master" AutoEventWireup="true" Codebehind="Reply.aspx.cs"
  Inherits="VietNamNet.AddOn.Union.Reply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplhContainer" runat="server">
  <table id="Table1" border="0" width="100%">
    <tr>
      <td>
      </td>
      <td>
        <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Names="Arial">Tham gia thảo luận</asp:Label></td>
    </tr>
    <tr>
      <td>
        &nbsp;
      </td>
      <td valign="top">
        <table width="100%" border="0">
          <%--<tr>
            <td colspan="2">
              <font face="arial" size="2"><b>View comment</b>
                <hr>
                <font face="Arial"><font size="2"><font color="maroon"></font></font></font></font>
            </td>
          </tr>--%>
          <tr>
            <td width="15%">
              <font face="Arial" size="2">Tiêu đề:</font></td>
            <td>
              <asp:Label ID="lbltitle" runat="server" Font-Names="Arial">Label</asp:Label><font
                face="Arial"></font></td>
          </tr>
          <tr>
            <td width="15%">
              <font face="Arial" size="2">Nội dung:</font></td>
            <td>
              <asp:Label ID="lblComment" runat="server" Font-Names="Arial">Label</asp:Label><font
                face="Arial"></font></td>
          </tr>
          <tr>
            <td width="15%">
              <font face="Arial" size="2">Tên thành viên:</font></td>
            <td>
              <asp:Label ID="lblname" runat="server" Font-Names="Arial">Label</asp:Label><font
                face="Arial"></font></td>
          </tr>
          <tr>
            <td width="15%">
              <font face="Arial" size="2">Email:</font></td>
            <td>
              <asp:Label ID="lblemail" runat="server" Font-Names="Arial">Label</asp:Label><font
                face="Arial"></font></td>
          </tr>
          <tr>
            <td width="15%">
              <font face="Arial" size="2">Thời gian:</font></td>
            <td>
              <asp:Label ID="lblDate" runat="server" Font-Names="Arial">Label</asp:Label><font
                face="Arial"></font></td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td>      
      </td>
    </tr>
    <tr>
      <td>
        &nbsp;
      </td>
      <td>
        <table id="Table2" width="100%" border="0">
          <%--<tr>
            <td colspan="2">
              <font face="arial" size="2"><b>Reply to&nbsp;Comment</b>
                <hr>
                <font face="Arial"><font size="2"><font color="maroon"></font></font></font></font>
            </td>
          </tr>--%>
          <tr valign="middle">
            <td valign="middle" nowrap align="left" width="10%">
              <font face="Arial" size="2">Loại bài:</font></td>
            <td valign="top">
              <font face="Arial" size="2">
                <input type="radio" name="MsgType" id="MsgType_4" value="4" runat="server">
                <label for="MsgType_4">
                  <img title='Question' align="absMiddle" src='images/question.gif'>
                  Question &nbsp;&nbsp;</label>
                <input type="radio" name="MsgType" id="MsgType_1" value="1" runat="server">
                <label for="MsgType_1">
                  <img title='General Comment' align="absMiddle" src='images/general.gif'>
                  General &nbsp;&nbsp;</label>
                <input type="radio" name="MsgType" id="MsgType_2" value="2" runat="server" onserverchange="MsgType_2_ServerChange">
                <label for="MsgType_2">
                  <img title='News' align="absMiddle" src='images/info.gif'>
                  News &nbsp;&nbsp;</label>
                <input type="radio" name="MsgType" id="MsgType_3" checked value="3" runat="server" onserverchange="MsgType_3_ServerChange">
                <label for="MsgType_8">
                  <img title='Answer' align="absMiddle" src='images/answer.gif'>
                  Answer &nbsp;&nbsp;</label>
                <input type="radio" name="MsgType" id="MsgType_5" value="5" runat="server" onserverchange="MsgType_5_ServerChange">
                <label for="MsgType_16">
                  <img title='Joke / Game' align="absMiddle" src='images/game.gif'>
                  Joke/Game&nbsp;&nbsp;&nbsp;</label></font></td>
          </tr>
          <tr>
            <td width="15%">
              <font face="Arial" size="2">Title</font></td>
            <td>
              <asp:TextBox ID="txtsubject" Width="500px" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" Font-Names="Arial"
                Font-Size="10pt" ControlToValidate="txtsubject" ErrorMessage="Subject Required"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td valign="top" width="10%">
              <font face="Arial" size="2">Reply:</font></td>
            <td>
              <font face="Arial">
                <asp:TextBox ID="txtcomment" runat="server" Font-Names="Arial" Font-Size="10pt" TextMode="MultiLine"
                  Width="500px" Height="104px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Font-Size="10pt"
                  ControlToValidate="txtcomment" ErrorMessage="Comment required"></asp:RequiredFieldValidator></font></td>
          </tr>
          <%--<tr>
            <td width="15%">
              <font face="Arial" size="2">Name:</font></td>
            <td>
              <font face="Arial">
                <asp:TextBox ID="txtname" Width="500px" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Font-Size="10pt"
                  ControlToValidate="txtname" ErrorMessage="Name required"></asp:RequiredFieldValidator></font></td>
          </tr>
          <tr>
            <td width="15%">
              <font face="Arial" size="2">Email:</font></td>
            <td>
              <font face="Arial">
                <asp:TextBox ID="txtemail" Width="500px" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Font-Size="10pt"
                  ControlToValidate="txtemail" ErrorMessage="Email required"></asp:RequiredFieldValidator></font></td>
          </tr>
          <tr>
            <td width="15%">
              <font face="Arial" size="2">User Profile/URL</font>
            </td>
            <td>
              <asp:TextBox ID="txtProfile" runat="server" Width="500px" OnTextChanged="txtProfile_TextChanged">http://codeproject.com</asp:TextBox></td>
          </tr>--%>
          <tr>
            <td width="15%">
              &nbsp;</td>
            <td>
              &nbsp;</td>
          </tr>
          <tr>
            <td width="15%">
            </td>
            <td>
              <font size="5"><font face="Arial"><font size="2"><font color="maroon">
                <asp:Button ID="Button1" runat="server" Width="90" Height="24" Text="Trả lời" OnClick="Button1_Click">
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
