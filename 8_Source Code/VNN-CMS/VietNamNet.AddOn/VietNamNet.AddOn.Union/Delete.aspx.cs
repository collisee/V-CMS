using System;
using VietNamNet.AddOn.Union.DBAccess;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.AddOn.Union
{
  public partial class Delete : BasePage
  {
    private int articleid = 0;
    private int commentid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
      PageLoad();

      if (!isLogged)
      {
        Response.Redirect("~/");
        //Response.Redirect("Forum.aspx");
      }

      // Put user code to initialize the page here
      if (Request.QueryString["id"] != null)
        articleid = Convert.ToInt32(Request.QueryString["id"]);

      if (Request.QueryString["CId"] != null)
        commentid = Convert.ToInt32(Request.QueryString["CId"]);
      try
      {
        clsDataAccess myclass = new clsDataAccess();
        myclass.openConnection();
        Boolean myReturn = myclass.DeleteForumData(articleid, commentid);
        myclass.closeConnection();
        Response.Redirect("Forum.aspx?id=" + articleid);
      }
      catch (Exception)
      {
        Response.Write("<h2>Lỗi trong quá trình xóa</h2>");
      }
    }
  }
}
