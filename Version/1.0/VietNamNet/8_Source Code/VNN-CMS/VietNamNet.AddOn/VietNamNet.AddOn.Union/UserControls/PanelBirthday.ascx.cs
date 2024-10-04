using System;
using System.Web.UI;
using System.Data;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.AddOn.Union.UserControls
{
  public partial class PanelBirthday : UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //ds cac SN sap toi
      UserHelper helperBirthday = new UserHelper(new User());
      DataTable dtBirthday = helperBirthday.GetBirthday();

      if (dtBirthday != null && dtBirthday.Rows.Count > 0)
      {
        Label1.Visible = true;
        Label2.Visible = true;

        rptBirthday.DataSource = dtBirthday;
        rptBirthday.DataBind();
      }

      //ds cac SN sap toi
      UserHelper helperBirthdayNext = new UserHelper(new User());
      DataTable dtBirthdayNext = helperBirthdayNext.GetBirthdayNext();

      if (dtBirthdayNext != null && dtBirthdayNext.Rows.Count > 0)
      {
        rptBirthdayNext.DataSource = dtBirthdayNext;
        rptBirthdayNext.DataBind();
      }
    }
  }
}