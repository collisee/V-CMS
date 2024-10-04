using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VietNamNet.Framework.Common;

namespace VietNamNet.CMS.Components
{
    public class BaseUserControls : System.Web.UI.UserControl
    {

        #region Members
        protected bool isLogged = false;
        protected string UserEmail = string.Empty;
        protected string UserFullname = string.Empty;
        protected int UserGroupId = 0;
        protected int UserId = 0;
        protected string UserLoginName = string.Empty;
        protected string UserStatus = string.Empty;
        protected DateTime UserLastLogin = DateTime.Now;
        #endregion

        #region Properties
         

        protected virtual void clearSession()
        {
            Session.Remove(Constants.Session.USER_ID);
            Session.Remove(Constants.Session.USER_GROUP);
            Session.Remove(Constants.Session.USER_LOGINNAME);
            Session.Remove(Constants.Session.USER_FULLNAME);
            Session.Remove(Constants.Session.USER_EMAIL);
            Session.Remove(Constants.Session.USER_LASTLOGIN);
            Session.Remove(Constants.Session.USER_STATUS);
        }

        protected virtual void GetUserInfo()
        {
            UserId = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
            UserGroupId = Utilities.ParseInt(Session[Constants.Session.USER_GROUP]);
            UserLoginName = Nulls.IsNullOrEmpty(Session[Constants.Session.USER_LOGINNAME])
                                ? string.Empty
                                : Session[Constants.Session.USER_LOGINNAME].ToString();
            UserStatus = Nulls.IsNullOrEmpty(Session[Constants.Session.USER_STATUS])
                                ? string.Empty
                                : Session[Constants.Session.USER_STATUS].ToString();
            UserFullname = Nulls.IsNullOrEmpty(Session[Constants.Session.USER_FULLNAME])
                               ? string.Empty
                               : Session[Constants.Session.USER_FULLNAME].ToString();
            UserEmail = Nulls.IsNullOrEmpty(Session[Constants.Session.USER_EMAIL])
                            ? string.Empty
                            : Session[Constants.Session.USER_EMAIL].ToString();
            UserLastLogin = Nulls.IsNullOrEmpty(Session[Constants.Session.USER_LASTLOGIN])
                                ? DateTime.Now
                                : (DateTime)Session[Constants.Session.USER_LASTLOGIN];

            if (UserId > 0)
            {
                isLogged = true;
            }
        }
        #endregion

        #region Event Handlers 
        #endregion

    }
}
