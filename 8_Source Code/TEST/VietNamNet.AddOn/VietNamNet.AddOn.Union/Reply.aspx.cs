using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Union
{
  public partial class Reply : BasePage
  {
    private int articleid = 1;
    private int myindent = 0;
    private int commentid = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
      PageLoad();

      if (!isLogged)
      {
        Response.Redirect("Forum.aspx");
      }
      // Put user code to initialize the page here
      LoadComment();
    }

    private void LoadComment()
    {
      if (Request.QueryString["id"] != null)
        articleid = Convert.ToInt32(Request.QueryString["id"]);

      if (Request.QueryString["CId"] != null)
        commentid = Convert.ToInt32(Request.QueryString["CId"]);

      SqlConnection myC = new SqlConnection();
      myC.ConnectionString = Utilities.GetConfigKey("SqlConnectionString");//"workstation id=RAJ;packet size=4096;integrated security=SSPI;data source=RAJ;persist security info=False;initial catalog=iLakshmi";
      string myQuery = "";

      myQuery = "SELECT * FROM " + Utilities.GetConfigKey("CommentTable") + " WHERE ID=@commentid and ArticleID=@articleid";

      myC.Open();
      SqlCommand myCommand = new SqlCommand(myQuery, myC);

      //truyen cac para
      SqlParameter paracommentid = new SqlParameter("@commentid", SqlDbType.Int, 0);
      paracommentid.Direction = ParameterDirection.Input;
      paracommentid.Value = commentid;
      myCommand.Parameters.Add(paracommentid);

      SqlParameter paraarticleid = new SqlParameter("@articleid", SqlDbType.Int, 0);
      paraarticleid.Direction = ParameterDirection.Input;
      paraarticleid.Value = articleid;
      myCommand.Parameters.Add(paraarticleid);
      //

      SqlDataReader myReader = myCommand.ExecuteReader();
      if (myReader.HasRows)
      {
        while (myReader.Read())
        {
          lblname.Text = myReader["Username"].ToString();
          lblemail.Text = myReader["UserEmail"].ToString();
          lbltitle.Text = myReader["Title"].ToString();
          txtsubject.Text = "Re: " + lbltitle.Text;
          lblComment.Text = myReader["Description"].ToString();
          lblDate.Text = myReader["DateAdded"].ToString() + " Indent:" + myReader["Indent"].ToString();
          myindent = Convert.ToInt32(myReader["Indent"].ToString()) + 1;
        }
      }
      myReader.Close();
    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
      int mParentId = commentid;
      int mArticleId = articleid;
      int mIndent = myindent;
      
      try
      {
        string mTitle = txtsubject.Text;
        string mUserName = Session[Constants.Session.USER_LOGINNAME].ToString();
        string mUserEmail = Session[Constants.Session.USER_EMAIL].ToString();
        string mDescription = txtcomment.Text;
        string mProfile = Session[Constants.Session.USER_AVATAR].ToString(); ;

        int mCommentType = 1;

        if (MsgType_2.Checked)
          mCommentType = 2;
        if (MsgType_3.Checked)
          mCommentType = 3;
        if (MsgType_4.Checked)
          mCommentType = 4;
        if (MsgType_5.Checked)
          mCommentType = 5;

        if (IsValid)
        {
          SqlConnection myC = new SqlConnection();
          myC.ConnectionString = Utilities.GetConfigKey("SqlConnectionString");
          string sqlQuery = "INSERT into " + Utilities.GetConfigKey("CommentTable") + "(ParentId,ArticleId,Title,UserName,UserEmail,Description,Indent,UserProfile,CommentType) VALUES (@mParentId,@mArticleId,@mTitle,@mUserName,@mUserEmail,@mDescription,@mIndent,@mProfile,@mCommentType)";
          myC.Open();
          SqlCommand myCommand = new SqlCommand();

          //truyen cac para
          SqlParameter paraParentId = new SqlParameter("@mParentId", SqlDbType.Int, 0);
          paraParentId.Direction = ParameterDirection.Input;
          paraParentId.Value = mParentId;
          myCommand.Parameters.Add(paraParentId);

          SqlParameter paraArticleId = new SqlParameter("@mArticleId", SqlDbType.Int, 0);
          paraArticleId.Direction = ParameterDirection.Input;
          paraArticleId.Value = mArticleId;
          myCommand.Parameters.Add(paraArticleId);

          SqlParameter paraTitle = new SqlParameter("@mTitle", SqlDbType.NVarChar, 250);
          paraTitle.Direction = ParameterDirection.Input;
          paraTitle.Value = mTitle;
          myCommand.Parameters.Add(paraTitle);

          SqlParameter paraUserName = new SqlParameter("@mUserName", SqlDbType.NVarChar, 50);
          paraUserName.Direction = ParameterDirection.Input;
          paraUserName.Value = mUserName;
          myCommand.Parameters.Add(paraUserName);

          SqlParameter paraUserEmail = new SqlParameter("@mUserEmail", SqlDbType.NVarChar, 50);
          paraUserEmail.Direction = ParameterDirection.Input;
          paraUserEmail.Value = mUserEmail;
          myCommand.Parameters.Add(paraUserEmail);

          SqlParameter paraDescription = new SqlParameter("@mDescription", SqlDbType.NVarChar, 2000);
          paraDescription.Direction = ParameterDirection.Input;
          paraDescription.Value = mDescription;
          myCommand.Parameters.Add(paraDescription);

          SqlParameter paraIndent = new SqlParameter("@mIndent", SqlDbType.Int, 0);
          paraIndent.Direction = ParameterDirection.Input;
          paraIndent.Value = mIndent;
          myCommand.Parameters.Add(paraIndent);

          SqlParameter paraProfile = new SqlParameter("@mProfile", SqlDbType.NVarChar, 100);
          paraProfile.Direction = ParameterDirection.Input;
          paraProfile.Value = mProfile;
          myCommand.Parameters.Add(paraProfile);

          SqlParameter paraCommentType = new SqlParameter("@mCommentType", SqlDbType.Int, 0);
          paraCommentType.Direction = ParameterDirection.Input;
          paraCommentType.Value = mCommentType;
          myCommand.Parameters.Add(paraCommentType);
          //

          myCommand.CommandText = sqlQuery;
          myCommand.Connection = myC;
          int i = myCommand.ExecuteNonQuery();
          myC.Close();
          lblStatus.ForeColor = Color.Green;
          lblStatus.Text = "Cập nhật thành công";
          Response.Redirect("Forum.aspx?id=" + articleid);

        }
      }
      catch (Exception ex)
      {
        lblStatus.ForeColor = Color.Red;
        lblStatus.Text = "Có lỗi trong quá trình cập nhật";

        if (ex.InnerException != null)
        {
          SystemLogging.Error("Forum::Reply::Error - " + ex.Message,
                              ex.InnerException.Message);
        }
        else
        {
          SystemLogging.Error("Forum::Reply::Error", ex.Message);
        }
      }
    }

    protected void Button2_Click(object sender, System.EventArgs e)
    {
      Response.Redirect("Forum.aspx?id=" + articleid);
    }

    protected static void txtProfile_TextChanged(object sender, System.EventArgs e)
    {

    }

    protected void MsgType_5_ServerChange(object sender, System.EventArgs e)
    {

    }

    protected void MsgType_2_ServerChange(object sender, System.EventArgs e)
    {

    }

    protected void MsgType_3_ServerChange(object sender, System.EventArgs e)
    {

    }
  }
}
