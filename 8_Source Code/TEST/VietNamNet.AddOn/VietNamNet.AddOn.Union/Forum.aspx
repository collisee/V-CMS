<%@ Page Language="C#" MasterPageFile="Forum.Master" AutoEventWireup="true" CodeBehind="Forum.aspx.cs" Inherits="VietNamNet.AddOn.Union.Forum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplhContainer" runat="server">
<script language="javascript" type="text/javascript">
if (top != self) top.location.href = location.href;
  </script>

  <script language="JavaScript" type="text/javascript">
		onerror = report;
var Selected = 1;


function OnOffPost(e)
{

   if ( !e ) e = window.event;
   var target = e.target ? e.target : e.srcElement;
   

if (!target) return;
   
 while (target.id.indexOf('LinkTrigger')<0)
 {
	//alert(target.id + target.id.indexOf('LinkTrigger')+target.parentNode);
	
     target = target.parentNode;
     if (target.id ==null) return;
     }
  if ( target.id.indexOf('LinkTrigger')<0 )
   return;
   

   if (Selected)
   {
      var body = document.getElementById(Selected + "ON");
      if (body)
         body.style.display = 'none';
      var head = document.getElementById(Selected + "OFF");
      if (head)
         head.bgColor = '#faa9a9';
   }

   if (Selected == target.name) // just collapse
      Selected="";
   else
   {
      Selected = target.name;
      var body = document.getElementById(Selected + "ON");
      if (body)
      {
         if (body.style.display=='none')
            body.style.display='';
         else
            body.style.display = 'none';
      }
      var head = document.getElementById(Selected + "OFF");
      if (head)
         head.bgColor = '#feeeee';

      if ( body && head && body.style.display != 'none' )
      {
         document.body.scrollTop = FindPosition(head, "Top") - document.body.clientHeight/10;
         OpenMessage(target.name, true);
      }
   }

   if ( e.preventDefault )
      e.preventDefault();
   else
      e.returnValue = false;
   return false;
}

// does its best to make a message visible on-screen (vs. scrolled off somewhere).
function OpenMessage(msgID, bShowTop) {
   var msgHeader = document.getElementById(msgID + "OFF");
   var msgBody = document.getElementById(msgID + "ON");

   // determine scroll position of top and bottom
   var MyBody = document.body;
   var top = FindPosition(msgHeader, 'Top');
   var bottom = FindPosition(msgBody, 'Top') + msgBody.offsetHeight;

   // if not already visible, scroll to make it so
   if ( MyBody.scrollTop > top && !bShowTop)
      MyBody.scrollTop = top - document.body.clientHeight/10;
   if ( MyBody.scrollTop+MyBody.clientHeight < bottom )
      MyBody.scrollTop = bottom-MyBody.clientHeight;
   if ( MyBody.scrollTop > top && bShowTop)
      MyBody.scrollTop = top - document.body.clientHeight/10;
}

// utility
function FindPosition(i,which)
{
   iPos = 0
   while (i!=null)
   {
      iPos += i["offset" + which];
      i = i.offsetParent;
   }
   return iPos
}

function report(message,url,line) {
    alert('Error : ' + message + ' at line ' + line + ' in ' + url);
}

// cause an <B style="COLOR: black; BACKGROUND-COLOR: #ffff66">error</B>:
  </script>

  <table cellspacing="0" cellpadding="0" width="100%" border="0">
    <tbody>
      <tr valign="top">
        <td class="ContentPane">
          <!-- Main Page Contents Start -->
          <div onclick="OnOffPost(event)">
            <table cellspacing="0" cellpadding="0" width="100%" bgcolor="#1d8a0f" border="0">
              <tbody>
                <tr>
                  <td width="100%">
                    <%--<form name="myform" id="myform" runat="server">--%>
                      <table id="ForumTable" cellspacing="1" cellpadding="0" width="100%" bgcolor="#1d8a0f"
                        border="0">
                        <tbody>
                          <tr>
                            <td align="left">
                              <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                  <td align="left" class="fr_title">
                                    <a href="Forum.aspx?id=2">Buôn chuyện</a> &nbsp;||&nbsp; 
                                    <a href="Forum.aspx?id=3">Cười</a> &nbsp;||&nbsp; 
                                    <a href="Forum.aspx?id=4">Cuộc thi</a> &nbsp;||&nbsp; 
                                    <a href="Forum.aspx?id=5">Góc chia sẻ</a></td>
                                  <td align="right">
                                    <font color="#ffffff">Số bài hiển thị</font>&nbsp;
                                    <asp:DropDownList ID="txtpagesize" runat="server" OnSelectedIndexChanged="txtpageSize_SelectedIndexChanged">
                                      <asp:ListItem Value="5">5</asp:ListItem>
                                      <asp:ListItem Value="10">10</asp:ListItem>
                                      <asp:ListItem Value="20" Selected="True">20</asp:ListItem>
                                      <asp:ListItem Value="30">30</asp:ListItem>
                                      <asp:ListItem Value="40">40</asp:ListItem>
                                      <asp:ListItem Value="50">50</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="btnsetpaging" runat="server" Text="Cập nhật" OnClick="btnsetpaging_Click">
                                    </asp:Button></td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                          <tr bgcolor="#ececec">
                            <td>
                              <a name="xx0xx"></a>
                              <table cellpadding="2" width="100%" bgcolor="#fce2e3" border="0">
                                <tr>
                                  <td>
                                    <img height="16" alt="screen" src="/images/forum_newmsg.gif" width="16" align="top"
                                      border="0">&nbsp;
                                    <asp:Label ID="lblnewmessage" ForeColor="Green" runat="server"></asp:Label></td>
                                  <td>
                                    <font face="Arial" size="2"></font>
                                  </td>
                                  <td nowrap align="right">
                                    <%--<font><a href="http://www.codeproject.com"><font face="arial" size="2">Jumpy 
																						Forum - inspired by Code Project&nbsp;</font> </a></font>--%>
                                  </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                          <tr bgcolor="white">
                            <td>
                              <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                  <tr>
                                    <td width="100%">
                                      <table cellspacing="0" cellpadding="2" bgcolor="orange" border="0">
                                        <tr>
                                          <td width="100%">
                                            <font face="Arial" size="2">Tiều đề&nbsp;</font></td>
                                          <td nowrap width="140">
                                            <font face="Arial" size="2">Người tạo&nbsp;</font></td>
                                          <td nowrap align="right" width="144">
                                            <font><font face="Arial" size="2">Thời gian</font>&nbsp;</font></td>
                                        </tr>
                                      </table>
                                    </td>
                                  </tr>
                                  <tr>
                                    <td colspan="1">
                                      <img height="5" src="/script//images/t.gif" width="1" border="0" alt="">
                                    </td>
                                  </tr>
                                  <asp:Literal ID="ltlPost" runat="server" OnInit="ltlPost_Init"></asp:Literal>
                                  <tr>
                                    <td colspan="1">
                                      <img height="5" src="/script//images/t.gif" width="1" border="0" alt=""></td>
                                  </tr>
                                </tbody>
                              </table>
                            </td>
                          </tr>
                          <tr bgcolor="orange">
                            <td>
                              <table cellpadding="0" width="100%" border="0">
                                <tr>
                                  <td align="left">
                                    <asp:Label ID="lbldate" runat="server" Font-Names="Arial" Font-Size="Smaller"></asp:Label></td>
                                  <td valign="middle" align="right" width="40%">
                                    <font face="Arial" size="2">
                                      <asp:Label ID="lblPaging" runat="server"></asp:Label></font></td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    <%--</form>--%>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </td>
      </tr>
    </tbody>
  </table>
</asp:Content>
