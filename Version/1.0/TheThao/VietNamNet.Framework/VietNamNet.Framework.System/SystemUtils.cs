using System;
using System.Data;
using System.Web;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common.Encryption;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.System
{
    public class SystemUtils
    {
        #region Security

        public static int GetPolicy(int userId, string moduleAlias)
        {
            if (userId <= 0 || Nulls.IsNullOrEmpty(moduleAlias)) return 0;

            string policyName = string.Format("{0}_{1}_{2}", Constants.Session.USER_POLICY, userId, moduleAlias);
            if (HttpContext.Current.Session[policyName] != null)
            {
                return Utilities.ParseInt(HttpContext.Current.Session[policyName]);
            }

            PolicyHelper helper = new PolicyHelper(new Policy());
            helper.ValueObject.UserId = userId;
            helper.ValueObject.ModuleAlias = moduleAlias;
            DataTable dt = helper.GetPolicy();

            if (dt != null && dt.Rows.Count > 0)
            {
                int values = 0;

                foreach (DataRow row in dt.Rows)
                {
                    int v = Utilities.ParseInt(row[SystemConstants.Entities.Policy.FieldName.Val]);
                    values |= v;
                }

                HttpContext.Current.Session[policyName] = values;
                return values;
            }

            HttpContext.Current.Session.Remove(policyName);
            return 0;
        }

        public static bool GetPolicy(int userId, string moduleAlias, string functionAlias)
        {
            if (userId <= 0 || Nulls.IsNullOrEmpty(moduleAlias) || Nulls.IsNullOrEmpty(functionAlias)) return false;

            int values = GetPolicy(userId, moduleAlias);

            if (values <= 0) return false;

            string policyName = string.Format("{0}_{1}_{2}_{3}", Constants.Session.USER_POLICY, userId, moduleAlias, functionAlias);
            if (HttpContext.Current.Session[policyName] != null)
            {
                return Utilities.ParseInt(HttpContext.Current.Session[policyName]) == 1;
            }

            FunctionHelper helper = new FunctionHelper(new Function());
            helper.ValueObject.Alias = functionAlias;
            helper.GetFunctionByAlias();

            if (helper.ValueObject != null)
            {
                int v = (helper.ValueObject.Ord > 0)
                            ? 1 << (helper.ValueObject.Ord - 1)
                            : 0;
                bool blnPolicy = (values & v) == v;
                HttpContext.Current.Session[policyName] = blnPolicy ? 1 : 0;
                return blnPolicy;
            }

            HttpContext.Current.Session.Remove(policyName);
            return false;
        }

        public static int GetPolicyRight(int userId)
        {
            return GetPolicy(userId, "System.Policy");
        }

        public static bool GetPolicyViewRight(int userId)
        {
            return GetPolicy(userId, "System.Policy", "System.Policy.View");
        }

        public static bool GetPolicyEditRight(int userId)
        {
            return GetPolicy(userId, "System.Policy", "System.Policy.Edit");
        }

        public static bool Pop3Authen(string user, string password)
        {
            return Utilities.Pop3Authen(user, password);
        }

        private static void StoreSessionLogin(User user)
        {
            //Clear Session
            HttpContext.Current.Session.Clear();

            //Store Session
            HttpContext.Current.Session[Constants.Session.USER_ID] = user.Id;
            //Session[Constants.Session.USER_GROUP] = user.GroupId;
            HttpContext.Current.Session[Constants.Session.USER_AVATAR] = user.Avatar;
            HttpContext.Current.Session[Constants.Session.USER_LOGINNAME] = HttpUtility.HtmlEncode(user.LoginName);
            HttpContext.Current.Session[Constants.Session.USER_FULLNAME] = HttpUtility.HtmlEncode(user.FullName);
            HttpContext.Current.Session[Constants.Session.USER_EMAIL] = HttpUtility.HtmlEncode(user.Email);
            HttpContext.Current.Session[Constants.Session.USER_LASTLOGIN] = user.LastLogin;
            HttpContext.Current.Session[Constants.Session.SKIN] = user.Skin;
            HttpContext.Current.Session[Constants.Session.USER_STATUS] = user.Status;
            HttpContext.Current.Session[Constants.Session.USER_PASSWORD] = !Nulls.IsNullOrEmpty(user.Password);
        }

        public static string UserLogin(string user, string password)
        {
            //email login
            string strEmail = string.Format("{0}@{1}", user, Utilities.GetConfigKey(Constants.ConfigKey.POP3Domain));
            if (Pop3Authen(strEmail, password))
            {
                UserHelper helper = new UserHelper(new User());
                helper.ValueObject.Email = strEmail;
                helper.GetUserByEmail();

                if (helper.ValueObject != null)
                {
                    //check status
                    if (Utilities.StringCompare(helper.ValueObject.Status, Constants.UserStatus.Locked))
                    {
                        return Utilities.GetConfigKey(Constants.Message.UserLocked);
                    }

                    StoreSessionLogin(helper.ValueObject);

                    SystemLogging.System("Login by Email!");
                    helper.UpdateUserLastLogin();
                }
                else
                {
                    return Utilities.GetConfigKey(Constants.Message.UserDoesntExist);
                }
            }
            else //normal login
            {
                UserHelper helper = new UserHelper(new User());
                helper.ValueObject.LoginName = user;
                helper.ValueObject.Password = MD5Encrypt.Encrypt(password.Trim());
                helper.GetUser();

                if (helper.ValueObject != null)
                {
                    //check status
                    if (Utilities.StringCompare(helper.ValueObject.Status, Constants.UserStatus.Locked))
                    {
                        return Utilities.GetConfigKey(Constants.Message.UserLocked);
                    }

                    StoreSessionLogin(helper.ValueObject);

                    SystemLogging.System("Login!");
                    helper.UpdateUserLastLogin();
                }
                else
                {
                    return Utilities.GetConfigKey(Constants.Message.UserLoginFailed);
                }
            }

            return string.Empty;
        }

        #endregion

        #region Configuration

        public static string GetConfiguration(string name)
        {
            ConfigurationHelper helper = new ConfigurationHelper(new Configuration());
            helper.ValueObject.Name = name;
            helper.GetConfiguration();

            return (helper.ValueObject == null) ? string.Empty : helper.ValueObject.Val;
        }

        public static void SetConfiguration(string name, object value)
        {
            ConfigurationHelper helper = new ConfigurationHelper(new Configuration());
            helper.ValueObject.Name = name;
            helper.GetConfiguration();

            if (helper.ValueObject == null)
            {
                ConfigurationHelper addHelper = new ConfigurationHelper(new Configuration());
                addHelper.ValueObject.Id = 0;
                addHelper.ValueObject.Name = name;
                addHelper.ValueObject.Val = Nulls.IsNullOrEmpty(value) ? string.Empty : value.ToString();
                addHelper.ValueObject.Detail = string.Empty;
                addHelper.ValueObject.Created_At = DateTime.Now;
                addHelper.ValueObject.Created_By = 0;
                addHelper.ValueObject.Last_Modified_At = DateTime.Now;
                addHelper.ValueObject.Last_Modified_By = 0;
                addHelper.DoSave();
            }
            else
            {
                helper.ValueObject.Val = Nulls.IsNullOrEmpty(value) ? string.Empty : value.ToString();
                helper.ValueObject.Last_Modified_At = DateTime.Now;
                helper.ValueObject.Last_Modified_By = 0;
                helper.DoSave();
            }
        }

        #endregion
    }
}