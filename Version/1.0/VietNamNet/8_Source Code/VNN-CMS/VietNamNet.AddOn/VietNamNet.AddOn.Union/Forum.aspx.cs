using System;
using System.Data.SqlClient;
using System.Text;
using VietNamNet.AddOn.Union.DBAccess;
using VietNamNet.Framework.System;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Union
{
  public partial class Forum : BasePage
  {
    private int articleId = 0;
    private int currentCount = 1;
    //private int pagesize= 20;

    public int PageSize
    {
      get
      {
        object o = ViewState["PageSize"];
        if ((o == null))
        {
          return 20;
        }
        return int.Parse(o.ToString());
      }
      set
      {
        ViewState["PageSize"] = value;
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      PageLoad();

      if (!isLogged)
      {
        Response.Redirect("~/");
      }

      // Put user code to initialize the page here

      if (Page.IsPostBack)
      {
        PageSize = Convert.ToInt32(txtpagesize.SelectedItem.Text);
        //Response.Write ("<h1>" +txtpagesize.SelectedItem.Text + "::" + PageSize +"</h1>");
      }
      else
      {
        if (Request.QueryString["pagesize"] != null)
        {
          this.PageSize = Convert.ToInt32(Request.QueryString["pagesize"]);
        }
      }

      txtpagesize.ClearSelection();
      txtpagesize.Items.FindByText(this.PageSize.ToString()).Selected = true;

      //Response.Write ("<h1>" +PageSize +"</h1>");

      LoadData();
    }

    private void LoadData()
    {
      DateTime lastVisit = DateTime.Now;
      string asd = Utilities.FormatDisplayDateTime(lastVisit);
      StringBuilder sb = new StringBuilder();
      //string myQuery ="";

      if (Request.QueryString["id"] != null)
        articleId = Convert.ToInt32(Request.QueryString["id"]);
      else
        articleId = 1;
      //Response.Write ("<hr>" + myQuery + "<hr>");

      if (isLogged)
      {
        lblnewmessage.Text = "<A title='Tạo một chủ đề mới' href='newmessage.aspx?id=" + articleId + "'><b><FONT face='Arial' size='2'>Tạo chủ đề</FONT></b></A>";
      }
      else
      {
        lblnewmessage.Visible = false;
      }

      //lblnewmessage.Text = "<A title='Tạo một chủ đề mới' href='newmessage.aspx?id=" + articleId + "'><b><FONT face='Arial' size='2'>Tạo chủ đề</FONT></b></A>";

      clsDataAccess myclass = new clsDataAccess();
      myclass.openConnection();

      SqlDataReader myReader = myclass.getForumData(articleId);

      int mycount = 1;



      while (myReader.Read())
      {

        DateTime dt1 = DateTime.Now;
        DateTime dt2 = Convert.ToDateTime(myReader["DateAdded"].ToString());
        if (mycount == 1)
          lastVisit = Convert.ToDateTime(myReader["DateAdded"].ToString());
        else
        {
          if (DateTime.Compare(lastVisit, dt2) < 0)
            lastVisit = dt2;
        }

        TimeSpan ts = dt1.Subtract(dt2);

        string mytimeago = "";
        if (Convert.ToInt32(ts.TotalDays) != 0)
          mytimeago = "" + Math.Abs(Convert.ToInt32(ts.TotalDays)) + " ngày trước";
        else
        {
          if ((Convert.ToInt32(ts.TotalMinutes) < 5) && (Convert.ToInt32(ts.TotalHours) == 0))
          {
            mytimeago = "Vừa nhập";
          }
          else if ((Convert.ToInt32(ts.TotalMinutes) > 5) && (Convert.ToInt32(ts.TotalHours) == 0))
          {
            mytimeago = Convert.ToInt32(ts.TotalMinutes) % 60 + " phút trước";
          }
          else if (Convert.ToInt32(ts.TotalHours) != 0)
          {
            mytimeago = "" + Convert.ToInt32(ts.TotalHours) + " giờ " + Convert.ToInt32(ts.TotalMinutes) % 60 + " phút trước";
          }
          else
          {
            mytimeago = Convert.ToInt32(ts.TotalMinutes) % 60 + " phút trước";
          }
        }

        string newimg = "";
        if (String.Compare(mytimeago, "Vừa nhập") == 0)
          newimg = "<img src='/images/new.gif' border='0' alt=''>";


        //if(mycount==1)
        //sb.Append("<tr bgcolor='#b7dfd5' id='K1745932k" + mycount + "kOFF'>");
        //else

        if (Request.QueryString["current"] != null)
          currentCount = Convert.ToInt32(Request.QueryString["current"]);
        else
          currentCount = 1;

        int myMaxCount = currentCount + Convert.ToInt32(this.PageSize);
        int myStartCount = currentCount;

        if (currentCount == -1)
        {
          myStartCount = 0;
          myMaxCount = 999;
        }



        if (mycount < myMaxCount && mycount >= myStartCount)
        {
          sb.Append("<tr bgcolor='#feeeee' id='K1745932k" + mycount + "kOFF'>");

          sb.Append("<td width='100%' colspan='1'>");
          sb.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%'>");
          sb.Append("<tr>");

          int myindent = 4;
          if (Convert.ToInt32(myReader["Indent"]) <= 4)
            myindent = 16 * Convert.ToInt32(myReader["Indent"]);
          else if (Convert.ToInt32(myReader["Indent"]) <= 8)
            myindent = 15 * Convert.ToInt32(myReader["Indent"]);
          else if (Convert.ToInt32(myReader["Indent"]) <= 16)
            myindent = 14 * Convert.ToInt32(myReader["Indent"]);
          else if (Convert.ToInt32(myReader["Indent"]) <= 20)
            myindent = Convert.ToInt32(13.5 * Convert.ToDouble(myReader["Indent"]));
          else if (Convert.ToInt32(myReader["Indent"]) <= 24)
            myindent = 13 * Convert.ToInt32(myReader["Indent"]);
          else if (Convert.ToInt32(myReader["Indent"]) <= 28)
            myindent = Convert.ToInt32(12.7 * Convert.ToDouble(myReader["Indent"]));
          else if (Convert.ToInt32(myReader["Indent"]) <= 32)
            myindent = Convert.ToInt32(12.4 * Convert.ToDouble(myReader["Indent"]));

          sb.Append("<td bgcolor='white'><a name='xxK1745932k" + mycount + "kxx'></a><img height='1' width='" + myindent + "' src='/images/ind.gif' alt=''>");

          if (Convert.ToInt32(myReader["CommentType"].ToString()) == 1)
            sb.Append("<img align='middle' src='/images/general.gif' alt=''></td>");
          if (Convert.ToInt32(myReader["CommentType"].ToString()) == 2)
            sb.Append("<img align='middle' src='/images/info.gif' alt=''>&nbsp;</td>");
          if (Convert.ToInt32(myReader["CommentType"].ToString()) == 3)
            sb.Append("<img align='middle' src='/images/answer.gif' alt=''>&nbsp;</td>");
          if (Convert.ToInt32(myReader["CommentType"].ToString()) == 4)
            sb.Append("<img align='middle' src='/images/question.gif' alt=''>&nbsp;</td>");
          if (Convert.ToInt32(myReader["CommentType"].ToString()) == 5)
            sb.Append("<img align='middle' src='/images/game.gif' alt=''>&nbsp;</td>");

          sb.Append("<td width='100%' ><a class='comment_title' id='LinkTrigger" + mycount + "' name='K1745932k" + mycount + "k' href='K1745932#xxK1745932k" + mycount + "kxx'>");

          if (Convert.ToInt32(myReader["Indent"]) == 0)
            sb.Append("<b><FONT face='Arial' size='2'>&nbsp;" + myReader["Title"].ToString() + "</FONT></b></a>" + newimg + "</td>");
          else
            sb.Append("<FONT face='Arial' size='2'>&nbsp;" + myReader["Title"].ToString() + "<!-- : " + myindent + "::" + Convert.ToInt32(myReader["Indent"]) + "--></FONT></a>" + newimg + "</td>");

          //DateTime dt = DateTime.Now.CompareTo(Convert.ToDateTime(myReader["DateAdded"].ToString()));

          sb.Append("<td valign='bottom' nowrap><a href='" + myReader["UserProfile"].ToString() + "'> <img src='/images/userinfo.gif'  alt='' title='Click for User Profile' border='0' width='14' height='15'></a>&nbsp;</td>");
          sb.Append("<td width='140' nowrap><font class='comment_user'>" + myReader["UserName"].ToString() + "&nbsp;</font></td>");
          sb.Append("<td nowrap align='right' width='144'><font class='comment_user'>" + mytimeago);
          sb.Append("&nbsp;</font></td>");
          sb.Append("</tr>");
          sb.Append("</table>");
          sb.Append("</td>");
          sb.Append("</tr>");

          sb.Append("<tr id='K1745932k" + mycount + "kON' style='DISPLAY:none'>");

          sb.Append("<td colspan='1' width='100%'>");
          sb.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%'>");
          sb.Append("<tr>");
          sb.Append("<td><img height='1' width='" + myindent + "' src='/images/ind.gif' alt=''><img align='middle' src='/images/blank.gif' height='30' width='28' alt=''>&nbsp;</td>");
          sb.Append("<td bgcolor='#fdefef' width='100%'><table border='0' cellspacing='5' cellpadding='0' width='100%'>");
          sb.Append("<tr>");
          sb.Append("<td>");
          sb.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%'>");
          sb.Append("<tr>");
          sb.Append("<td colspan='2'>");
          sb.Append("<font face = 'arial' size='2'>" + myReader["Description"].ToString() + "</font>");//" Time Now:" + dt1 + " DBTime:" +  dt2 +"
          sb.Append("<br>");
          sb.Append("&nbsp;</td>");
          sb.Append("</tr>");
          sb.Append("<tr valign='top'>");
          if (isLogged)
          {
            sb.Append("<td >[<a href='Reply.aspx?id=" + articleId + "&amp;CID=" + myReader["ID"].ToString() + "' title='Trả lời chủ đề này'><font face = arial size=2>Trả lời</font></a>]");
            sb.Append("</td>");
          }
          else
          {
            sb.Append("<td >");
            sb.Append("</td>");
          }
          //sb.Append("<td >[<a href='Reply.aspx?id=" + articleId + "&amp;CID=" + myReader["ID"].ToString() + "' title='Trả lời chủ đề này'><font face = arial size=2>Trả lời</font></a>]");
          ////sb.Append("[<a href='Reply.aspx?Test=true&amp;id=" + articleId + "&amp;CID=" + myReader["ID"].ToString() + "' title='Test Reply for this current thread'><font face = arial size=2>Test Reply</font></a>]");
          //sb.Append("</td>");
          if ((isLogged) && (UserGroupId == 1))
          {
            sb.Append("<td align='right' >[<a href='Delete.aspx?id=" + articleId + "&amp;CID=" + myReader["ID"].ToString() + "' ");
            sb.Append("title='Xóa bài'><font face = arial size=2>Xóa</font></a>]");
            sb.Append("</td>");
          }
          else
          {
            sb.Append("<td>");
            sb.Append("</td>");
          }
          //sb.Append("<td align='right' >[<a href='Delete.aspx?id=" + articleId + "&amp;CID=" + myReader["ID"].ToString() + "' ");
          //sb.Append("title='Xóa bài'><font face = arial size=2>Xóa</font></a>]");
          //sb.Append("</td>");
          sb.Append("</tr>");
          sb.Append("</table>");
          sb.Append("</td>");
          sb.Append("</tr>");
          sb.Append("</table>");
          sb.Append("</td>");
          sb.Append("</tr>");
          sb.Append("</table>");
          sb.Append("</td>");
          sb.Append("</tr>");
          sb.Append("<tr>");
          sb.Append("<td colspan='1'><img src='/images/t.gif' border='0' width='1' height='6' alt=''></td>");
          sb.Append("</tr>");
        }
        mycount++;
      }
      myReader.Close();
      myclass.closeConnection();

      if (currentCount == -1)
      {
        lblPaging.Text = "<a title ='" + this.PageSize + " bài đầu' href='Forum.aspx?id=" + articleId + "&amp;current=" + 1 + "&amp;pagesize=" + this.PageSize + "'><<</a>&nbsp;&nbsp;<&nbsp;&nbsp;<a title='Hiển thị tất cả' href='Forum.aspx?id=" + articleId + "&amp;current=-1" + "&amp;pagesize=" + this.PageSize + "'><b>" + (mycount - 1) + "</b> bài</a>&nbsp;&nbsp;>&nbsp;&nbsp;<a href='Forum.aspx?id=" + articleId + "&amp;current=" + (mycount - Convert.ToInt32(this.PageSize)) + "&amp;pagesize=" + this.PageSize + "' title ='" + this.PageSize + " bài cuối' >>></a>&nbsp;&nbsp;";
      }
      else if (currentCount == 1)
      {
        lblPaging.Text = "<<&nbsp;&nbsp;<&nbsp;&nbsp;<a title='Hiển thị tất cả' href='Forum.aspx?id=" + articleId + "&amp;current=-1&amp;pagesize=" + this.PageSize + "'><b>" + (mycount - 1) + "</b> bài</a>&nbsp;&nbsp;<a href='Forum.aspx?id=" + articleId + "&amp;current=" + (Convert.ToInt32(this.PageSize) + 1) + "&amp;pagesize=" + this.PageSize + "' title ='" + this.PageSize + " bài tiếp'>></a>&nbsp;&nbsp;<a href='Forum.aspx?id=" + articleId + "&amp;current=" + (mycount - Convert.ToInt32(this.PageSize)) + "&amp;pagesize=" + this.PageSize + "' title ='" + this.PageSize + " bài cuối'>>></a>&nbsp;&nbsp;";
      }
      else if (currentCount == (mycount - Convert.ToInt32(this.PageSize)))
      {
        lblPaging.Text = "<a title ='" + this.PageSize + " bài đầu' href='Forum.aspx?id=" + articleId + "&amp;current=" + 1 + "&amp;pagesize=" + this.PageSize + "'><<</a>&nbsp;&nbsp;<a href='Forum.aspx?&amp;pagesize=" + this.PageSize + "' title ='" + this.PageSize + " bài trước'><</a>&nbsp;&nbsp;<a title='Hiển thị tất cả' href='Forum.aspx?id=" + articleId + "&amp;current=-1&amp;pagesize=" + this.PageSize + "'><b>" + (mycount - 1) + "</b> bài</a>&nbsp;&nbsp;>&nbsp;&nbsp;>>&nbsp;&nbsp;";
      }
      else
      {
        if (mycount > (Convert.ToInt32(this.PageSize) + currentCount))
        {
          if (currentCount - Convert.ToInt32(this.PageSize) < 0)
          {
            lblPaging.Text = "<a  title ='" + this.PageSize + " bài đầu' href='Forum.aspx?id=" + articleId + "&amp;current=" + 1 + "&amp;pagesize=" + this.PageSize + "'><<</a>&nbsp;&nbsp;<&nbsp;&nbsp;<a title='Hiển thị tất cả' href='Forum.aspx?id=" + articleId + "&amp;current=-1&amp;pagesize=" + this.PageSize + "'><b>" + (mycount - 1) + "</b> bài</a>&nbsp;&nbsp;<a href='Forum.aspx?id=" + articleId + "&amp;current=" + (Convert.ToInt32(this.PageSize) + currentCount) + "&amp;pagesize=" + this.PageSize + "' title ='" + this.PageSize + " bài tiếp'>></a>&nbsp;&nbsp;<a href='Forum.aspx?id=" + articleId + "&amp;current=" + (mycount - Convert.ToInt32(this.PageSize)) + "&amp;pagesize=" + this.PageSize + "' title ='" + this.PageSize + " bài cuối'>>></a>&nbsp;&nbsp;";
          }
          else
          {
            lblPaging.Text = "<a  title ='" + this.PageSize + " bài đầu' href='Forum.aspx?id=" + articleId + "&amp;current=" + 1 + "&amp;pagesize=" + this.PageSize + "'><<</a>&nbsp;&nbsp;<a href='Forum.aspx?id=" + articleId + "&amp;pagesize=" + this.PageSize + "&amp;current=" + (currentCount - Convert.ToInt32(this.PageSize)) + "' title ='" + this.PageSize + " bài trước'><</a>&nbsp;&nbsp;<a title='Hiển thị tất cả' href='Forum.aspx?id=" + articleId + "&amp;current=-1&amp;pagesize=" + this.PageSize + "'><b>" + (mycount - 1) + "</b> bài</a>&nbsp;&nbsp;<a href='Forum.aspx?id=" + articleId + "&amp;current=" + (Convert.ToInt32(this.PageSize) + currentCount) + "&amp;pagesize=" + this.PageSize + "'  title ='" + this.PageSize + " bài tiếp'>></a>&nbsp;&nbsp;<a href='Forum.aspx?id=" + articleId + "&amp;current=" + (mycount - Convert.ToInt32(this.PageSize)) + "&amp;pagesize=" + this.PageSize + "' title ='" + this.PageSize + " bài cuối'>>></a>&nbsp;&nbsp;";
          }
        }
        else
        {
          if (currentCount - Convert.ToInt32(this.PageSize) < 0)
          {
            lblPaging.Text = "<a  title ='" + this.PageSize + " bài đầu' href='Forum.aspx?id=" + articleId + "&amp;current=" + 1 + "&amp;pagesize=" + this.PageSize + "'><<</a>&nbsp;&nbsp;<&nbsp;&nbsp;<a title='Hiển thị tất cả' href='Forum.aspx?id=" + articleId + "&amp;current=-1&amp;pagesize=" + this.PageSize + "'><b>" + (mycount - 1) + "</b> bài</a>&nbsp;&nbsp;>&nbsp;&nbsp;<a href='Forum.aspx?id=" + articleId + "&amp;current=" + (mycount - Convert.ToInt32(this.PageSize)) + "&amp;pagesize=" + this.PageSize + "' title ='" + this.PageSize + " bài cuối'>>></a>&nbsp;&nbsp;";
          }
          else
          {
            lblPaging.Text = "<a  title ='" + this.PageSize + " bài đầu' href='Forum.aspx?id=" + articleId + "&amp;current=" + 1 + "&amp;pagesize=" + this.PageSize + "'><<</a>&nbsp;&nbsp;<a href='Forum.aspx?id=" + articleId + "&amp;pagesize=" + this.PageSize + "&amp;current=" + (currentCount - Convert.ToInt32(this.PageSize)) + "' title ='" + this.PageSize + " bài trước'><<</a>&nbsp;&nbsp;<a title='Hiển thị tất cả' href='Forum.aspx?id=" + articleId + "&amp;current=-1&amp;pagesize=" + this.PageSize + "'><b>" + (mycount - 1) + "</b> bài</a>&nbsp;&nbsp;>&nbsp;&nbsp;<a href='Forum.aspx?id=" + articleId + "&amp;current=" + (mycount - Convert.ToInt32(this.PageSize)) + "&amp;pagesize=" + this.PageSize + "' title ='" + this.PageSize + " bài cuối'>>></a>&nbsp;&nbsp;";
          }
        }
      }

      ltlPost.Text = sb.ToString();

      //lbldate.Text = "Lần tham gia gần nhất: " + lastVisit.ToLongTimeString() + ",  " + lastVisit.ToLongDateString(); 
      lbldate.Text = "Lần tham gia gần nhất: " + asd;
    }

    protected void ltlPost_Init(object sender, System.EventArgs e)
    {

    }

    protected void btnsetpaging_Click(object sender, System.EventArgs e)
    {

    }

    protected void txtpageSize_SelectedIndexChanged(object sender, System.EventArgs e)
    {

    }
  }
}
