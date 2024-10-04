using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.Framework.UserControls.LayoutClassical
{
    public partial class PanelTop : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] arrDayName = {
                                      "Ch&#7911; nh&#7853;t", "Th&#7913; hai", "Th&#7913; ba", "Th&#7913; t&#432;",
                                      "Th&#7913; n&#259;m", "Th&#7913; s&#225;u", "Th&#7913; b&#7843;y"
                                  };
            if (!IsPostBack)
            {
                DateTime today = DateTime.Now;
                string strDateTime = arrDayName[(int)today.DayOfWeek];
                strDateTime += ", " + Utilities.FormatDisplayDateTime(today);
                lblDateTime.Text = strDateTime;

                lbtnUser.Text = Nulls.IsNullOrEmpty(Session[Constants.Session.USER_FULLNAME])
                                    ? string.Empty
                                    : Session[Constants.Session.USER_FULLNAME].ToString();

                lbtnLogin.Visible =
                    lbtnFindPassword.Visible =
                    Label3.Visible = Nulls.IsNullOrEmpty(Session[Constants.Session.USER_ID]);
                lbtnUser.Visible =
                    lbtnLogout.Visible =
                    lbtnChangePass.Visible =
                    Label1.Visible =
                    Label2.Visible = !Nulls.IsNullOrEmpty(Session[Constants.Session.USER_ID]);
                if (lbtnChangePass.Visible && Session[Constants.Session.USER_PASSWORD] != null)
                {
                    Label1.Visible =
                    lbtnChangePass.Visible = (bool)Session[Constants.Session.USER_PASSWORD];
                }
            }
        }

        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;
            
            Utilities.RedirectToLoginPage();
        }

        protected void lbtnUser_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            //Save Url
            Session[Constants.Session.SOURCE_URL] = Request.Url.ToString();

            //
            Response.Redirect(Constants.FormNames.CtrlPanel);
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            //Save Url
            Session[Constants.Session.SOURCE_URL] = Request.Url.ToString();

            //
            Response.Redirect(Constants.FormNames.Logout);
        }

        protected void lbtnChangePass_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            //Save Url
            Session[Constants.Session.SOURCE_URL] = Request.Url.ToString();

            //
            Response.Redirect(Constants.FormNames.ChangePassword);
        }

        protected void lbtnFindPassword_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            Response.Redirect(Constants.FormNames.FindPassword);
        }
    }
}