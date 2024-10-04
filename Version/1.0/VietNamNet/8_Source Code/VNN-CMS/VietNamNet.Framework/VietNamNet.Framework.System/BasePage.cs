using System;
using System.Web.UI;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.System
{
    public abstract class BasePage : Page
    {
        protected bool dynamicLayout = true;
        protected int iModule = 0;
        protected string moduleAlias = string.Empty;

        protected bool isCheckSecurity =
            Utilities.StringCompare(Utilities.GetConfigKey(Constants.ConfigKey.Security),
                                    Constants.Security.ON.ToString());

        protected bool isAddNewer = false;
        protected bool isAllRight = false;
        protected bool isDeleter = false;
        protected bool isLogged = false;
        protected bool isUpdater = false;
        protected bool isViewer = false;
        protected bool isExporter = false;
        protected bool isImporter = false;
        protected string addNewAlias = string.Empty;
        protected string deleteAlias = string.Empty;
        protected string updateAlias = string.Empty;
        protected string viewAlias = string.Empty;
        protected string exportAlias = string.Empty;
        protected string importAlias = string.Empty;

        protected bool[] isSpecial =
            new bool[17]
                {   false, 
                    false, false, false, false, 
                    false, false, false, false, 
                    false, false, false, false, 
                    false, false, false, false
                };
        protected string UserEmail = string.Empty;
        protected string UserFullname = string.Empty;
        protected int UserGroupId = 0;
        protected int UserId = 0;
        protected string UserLoginName = string.Empty;
        protected string UserStatus = string.Empty;
        protected DateTime UserLastLogin = DateTime.Now;

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
                                : (DateTime) Session[Constants.Session.USER_LASTLOGIN];

            if (UserId > 0)
            {
                isLogged = true;
            }
        }

        protected virtual void GetPolicy()
        {
            int iPolicy = SystemUtils.GetPolicy(UserId, moduleAlias);
            isViewer = SystemUtils.GetPolicy(UserId, moduleAlias, viewAlias);
            isAddNewer = SystemUtils.GetPolicy(UserId, moduleAlias, addNewAlias);
            isUpdater = SystemUtils.GetPolicy(UserId, moduleAlias, updateAlias);
            isDeleter = SystemUtils.GetPolicy(UserId, moduleAlias, deleteAlias);
            isExporter = SystemUtils.GetPolicy(UserId, moduleAlias, exportAlias);
            isImporter = SystemUtils.GetPolicy(UserId, moduleAlias, importAlias);
            for (int i = 0; i < isSpecial.Length; i++)
            {
                isSpecial[i] = (iPolicy & Constants.PolicyRight.Special[i]) == Constants.PolicyRight.Special[i];
            }
            isAllRight = (iPolicy & Constants.PolicyRight.All) == Constants.PolicyRight.All;
        }

        protected virtual void TurnOffSecurity()
        {
            isViewer = true;
            isAddNewer = true;
            isUpdater = true;
            isDeleter = true;
            for (int i = 0; i < isSpecial.Length; i++)
            {
                isSpecial[i] = true;
            }
            isAllRight = true;
        }

        protected virtual void PageLoad()
        {
            if (isCheckSecurity)
            {
                GetUserInfo();
                GetPolicy();
            }
            else
            {
                GetUserInfo();
                TurnOffSecurity();
            }
        }

        protected virtual Control ContainerControl
        {
            get
            {
                if (Master == null) return Page.FindControl(Constants.Paging.ControlName.ContentPlaceHolderContainer);

                Control formDefault = Master.FindControl(Constants.Paging.ControlName.FormDefault);
                Control contentMain = formDefault.FindControl(Constants.Paging.ControlName.ContentPlaceHolderContainer);
                return contentMain;
            }
        }

        protected virtual Control FindPageControl(string strControlId)
        {
            if (Master == null) return Page.FindControl(strControlId);

            Control formDefault = Master.FindControl(Constants.Paging.ControlName.FormDefault);
            Control contentMain = formDefault.FindControl(Constants.Paging.ControlName.ContentPlaceHolderContainer);
            return contentMain.FindControl(strControlId);
        }

        protected override void OnPreInit(EventArgs e)
        {
            if (dynamicLayout && !Nulls.IsNullOrEmpty(Session[Constants.Session.SYSTEM_LAYOUT]))
            {
                this.MasterPageFile = Session[Constants.Session.SYSTEM_LAYOUT].ToString();
            }

            base.OnPreInit(e);
        }
    }
}