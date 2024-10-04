using System;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Royalty.Components
{
    public class BaseUserControls : System.Web.UI.UserControl
    {

        #region Members
        protected bool isCheckSecurity =
           Utilities.StringCompare(Utilities.GetConfigKey(Constants.ConfigKey.Security),
                                   Constants.Security.ON.ToString());

        protected string moduleAlias = string.Empty;


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

        protected bool isSystem = false;
        protected string systemAlias = string.Empty;

        protected bool isTypesManager = false;
        protected string typesAlias = string.Empty;

        protected string UserEmail = string.Empty;
        protected string UserFullname = string.Empty;
        protected int UserGroupId = 0;
        protected int UserId = 0;
        protected string UserLoginName = string.Empty;
        protected string UserStatus = string.Empty;
        protected DateTime UserLastLogin = DateTime.Now;
        #endregion

        #region Properties
        protected   void PageLoad()
        {
            Initialize();

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
        public void Initialize()
        {
            moduleAlias = "VietNamNet.AddOn.Royalty";
            viewAlias = "VietNamNet.AddOn.Royalty.View";
            addNewAlias = "VietNamNet.AddOn.Royalty.AddNew";
            updateAlias = "VietNamNet.AddOn.Royalty.Update";
            deleteAlias = "VietNamNet.AddOn.Royalty.Delete";
            typesAlias = "VietNamNet.AddOn.Royalty.Types";
            systemAlias = "VietNamNet.AddOn.Royalty.System";
        }

        protected   void GetPolicy()
        {
            int iPolicy = SystemUtils.GetPolicy(UserId, moduleAlias);
            isViewer = SystemUtils.GetPolicy(UserId, moduleAlias, viewAlias);
            isAddNewer = SystemUtils.GetPolicy(UserId, moduleAlias, addNewAlias);
            isUpdater = SystemUtils.GetPolicy(UserId, moduleAlias, updateAlias);
            isDeleter = SystemUtils.GetPolicy(UserId, moduleAlias, deleteAlias);
            isExporter = SystemUtils.GetPolicy(UserId, moduleAlias, exportAlias);
            isImporter = SystemUtils.GetPolicy(UserId, moduleAlias, importAlias); 
            isAllRight = (iPolicy & Constants.PolicyRight.All) == Constants.PolicyRight.All;

            isTypesManager = SystemUtils.GetPolicy(UserId, moduleAlias, typesAlias);
            isSystem = SystemUtils.GetPolicy(UserId, moduleAlias, systemAlias);


            ////test only
            //isViewer = true;
            //isAddNewer = true;
            //isUpdater = true;
            //isDeleter = true;
            //isTypesManager = true;

        }
        protected virtual void TurnOffSecurity()
        {
            isViewer = true;
            isAddNewer = true;
            isUpdater = true;
            isDeleter = true; 
            isAllRight = true;

            isTypesManager = true;
            isSystem = true;
        }
        #endregion

    }
}
