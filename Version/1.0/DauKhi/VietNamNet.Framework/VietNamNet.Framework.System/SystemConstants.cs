using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System
{
    public class SystemConstants
    {
        #region Entities

        public class Entities : BaseEntities
        {
            #region Configuration

            public class Configuration
            {
                public const string Name = "Configuration";
                public static string[] SearchColumns = { "Name", "Detail" };

                public class FieldName : BaseFieldName
                {
                    public const string Name = "Name";
                    public const string Val = "Val";
                    public const string Detail = "Detail";
                }
            }

            #endregion

            #region Function

            public class Function
            {
                public const string Name = "Function";
                public static string[] SearchColumns = { "Name", "Alias", "Detail" };
                public static string[] SearchColumnsInModule = { "Name" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Alias = "Alias";
                    public const string Detail = "Detail";
                    public const string ModuleId = "ModuleId";
                    public const string Name = "Name";
                    public const string Ord = "Ord";
                }

                #endregion
            }

            #endregion

            #region Group

            public class Group
            {
                public const string Name = "Group";
                public const string Members = "Members";
                public static string[] SearchColumns = { "Name", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Detail = "Detail";
                    public const string Name = "Name";
                }

                #endregion
            }

            #endregion

            #region GroupMember

            public class GroupMember
            {
                public const string Name = "GroupMember";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string GroupId = "GroupId";
                    public const string UserId = "UserId";
                    public const string LoginName = "LoginName";
                    public const string FullName = "FullName";
                    public const string GroupName = "GroupName";
                    public const string SaveStatus = "SaveStatus";
                }

                #endregion
            }

            #endregion

            #region Logging

            public class Logging
            {
                public const string Name = "Logging";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Action = "Action";
                    public const string Detail = "Detail";
                    public const string IP = "IP";
                    public const string LogLevel = "LogLevel";
                    public const string LogTime = "LogTime";
                    public const string UId = "UId";
                    public const string UserFullName = "UserFullName";
                }

                #endregion
            }

            #endregion

            #region Menu

            public class Menu
            {
                public const string Name = "Menu";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Access = "Access";
                    public const string DisplayName = "DisplayName";
                    public const string Link = "Link";
                    public const string ModuleId = "ModuleId";
                    public const string Name = "Name";
                    public const string Ord = "Ord";
                    public const string PId = "PId";
                }

                #endregion
            }

            #endregion

            #region Module

            public class Module
            {
                public const string Name = "Module";
                public static string[] SearchColumns = { "Name", "Alias", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Alias = "Alias";
                    public const string Detail = "Detail";
                    public const string Name = "Name";
                }

                #endregion
            }

            #endregion

            #region Policy

            public class Policy
            {
                public const string Name = "Policy";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string GroupId = "GroupId";
                    public const string ModuleId = "ModuleId";
                    public const string Val = "Val";
                }

                #endregion
            }

            #endregion

            #region User

            public class User
            {
                public const string Name = "User";
                public const string MemberOf = "MemberOf";
                public static string[] SearchColumns = { "Status", "LoginName", "Email", "Sex", "FullName", "Phone", "Mobile" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Address = "Address";
                    public const string Avatar = "Avatar";
                    public const string Birthday = "Birthday";
                    public const string Email = "Email";
                    public const string FullName = "FullName";
                    public const string LastLogin = "LastLogin";
                    public const string LoginName = "LoginName";
                    public const string Name = "Name";
                    public const string Mobile = "Mobile";
                    public const string Password = "Password";
                    public const string Phone = "Phone";
                    public const string Sex = "Sex";
                    public const string Status = "Status";
                    public const string Skin = "Skin";
                    public const string Skype = "Skype";
                    public const string Yahoo = "Yahoo";
                    public const string Facebook = "Facebook";
                    public const string Detail = "Detail";
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region Services

        public class Services : BaseServices
        {
            #region ConfigurationManager

            public class ConfigurationManager
            {
                public const string Name = "ConfigurationManager";

                public class Actions : CommonActions
                {
                    public const string GetConfiguration = "GetConfiguration";
                    public const string SetConfiguration = "SetConfiguration";
                    public const string ViewGetAllConfiguration = "ViewGetAllConfiguration";
                }
            }

            #endregion

            #region FunctionManager

            public class FunctionManager
            {
                public const string Name = "FunctionManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllFunction = "ViewGetAllFunction";
                    public const string GetFunctionByAlias = "GetFunctionByAlias";
                    public const string GetFunctionByModuleId = "GetFunctionByModuleId";
                }

                #endregion
            }

            #endregion

            #region GroupManager

            public class GroupManager
            {
                public const string Name = "GroupManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllGroup = "ViewGetAllGroup";
                }

                #endregion
            }

            #endregion

            #region GroupMemberManager

            public class GroupMemberManager
            {
                public const string Name = "GroupMemberManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                }

                #endregion
            }

            #endregion

            #region LoggingManager

            public class LoggingManager
            {
                public const string Name = "LoggingManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string GetLogging = "GetLogging";
                }

                #endregion
            }

            #endregion

            #region MenuManager

            public class MenuManager
            {
                public const string Name = "MenuManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string GetMenuByUserId = "GetMenuByUserId";
                    public const string UpdateMenuPIdAndOrder = "UpdateMenuPIdAndOrder";
                    public const string OptimizeMenu = "OptimizeMenu";
                }

                #endregion
            }

            #endregion

            #region ModuleManager

            public class ModuleManager
            {
                public const string Name = "ModuleManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllModule = "ViewGetAllModule";
                    public const string GetModuleByAlias = "GetModuleByAlias";
                }

                #endregion
            }

            #endregion

            #region PolicyManager

            public class PolicyManager
            {
                public const string Name = "PolicyManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string GetPolicy = "GetPolicy";
                    public const string GetPolicyByGroup = "GetPolicyByGroup";
                    public const string SavePolicyByGroup = "SavePolicyByGroup";
                    public const string GetPolicyByModule = "GetPolicyByModule";
                    public const string SavePolicyByModule = "SavePolicyByModule";
                }

                #endregion
            }

            #endregion

            #region UserManager

            public class UserManager
            {
                public const string Name = "UserManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllUser = "ViewGetAllUser";
                    public const string ViewGetAllUserFilterByGroup = "ViewGetAllUserFilterByGroup";
                    public const string ViewGetAllUserByGroup = "ViewGetAllUserByGroup";
                    public const string ViewGetAllUserByStatus = "ViewGetAllUserByStatus";
                    public const string ChangePassword = "ChangePassword";
                    public const string UpdateUserLastLogin = "UpdateUserLastLogin";
                    public const string GetUser = "GetUser";
                    public const string GetUserByEmail = "GetUserByEmail";
                    public const string GetUserByLoginName = "GetUserByLoginName";
                    public const string GetUserByGroup = "GetUserByGroup";
                    public const string GetBirthday = "GetBirthday";
                  public const string GetBirthdayNext = "GetBirthdayNext";
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region ConfigKey

        public class ConfigKey : ModuleConstants.ConfigKey
        {
        }

        #endregion

        #region Message

        public class Message : ModuleConstants.Message
        {
            public const string PasswordAndRetypeError = "PasswordAndRetypeError";
            public const string WrongPassword = "WrongPassword";
            public const string ChangePasswordSuccess = "ChangePasswordSuccess";
            public const string LoginNameExisted = "LoginNameExisted";
            public const string EmailCantEmpty = "EmailCantEmpty";
            public const string EmailExisted = "EmailExisted";
            public const string DateOfBirthCantEmpty = "DateOfBirthCantEmpty";
            public const string SaveSuccess = "SaveSuccess";
            public const string MenuParentError = "MenuParentError";
            public const string NameCantEmpty = "NameCantEmpty";
            public const string DisplayNameCantEmpty = "DisplayNameCantEmpty";
            public const string AliasExisted = "AliasExisted";
            public const string NameExisted = "NameExisted";

            #region Nested type: EmailSubject

            public class EmailSubject
            {
                public const string ChangePassword = "ChangePassword";
                public const string NewPassword = "NewPassword";
            }

            #endregion
        }

        #endregion

        #region FormNames

        public class FormNames : ModuleConstants.FormNames
        {
            #region Nested type: Administrator

            public class Administrator
            {
                public const string BlackListView = "~/Administrator/BlackListView.aspx";
                public const string CacheManager = "~/Administrator/CacheManager.aspx";
                public const string ChangePassword = "~/Administrator/ChangePassword.aspx";
                public const string CtrlPanel = "~/Administrator/CtrlPanel.aspx";
                public const string Default = "~/Administrator/Default.aspx";
                public const string Error = "~/Administrator/Error.aspx";
                public const string GroupDisplay = "~/Administrator/GroupDisplay.aspx";
                public const string GroupEdit = "~/Administrator/GroupEdit.aspx";
                public const string GroupView = "~/Administrator/GroupView.aspx";
                public const string Logging = "~/Administrator/Logging.aspx";
                public const string Login = "~/Administrator/Login.aspx";
                public const string MenuDisplay = "~/Administrator/MenuDisplay.aspx";
                public const string MenuEdit = "~/Administrator/MenuEdit.aspx";
                public const string MenuView = "~/Administrator/MenuView.aspx";
                public const string ModuleDisplay = "~/Administrator/ModuleDisplay.aspx";
                public const string ModuleEdit = "~/Administrator/ModuleEdit.aspx";
                public const string ModuleView = "~/Administrator/ModuleView.aspx";
                public const string ConfigurationDisplay = "~/Administrator/ConfigurationDisplay.aspx";
                public const string ConfigurationEdit = "~/Administrator/ConfigurationEdit.aspx";
                public const string ConfigurationView = "~/Administrator/ConfigurationView.aspx";
                public const string FunctionDisplay = "~/Administrator/FunctionDisplay.aspx";
                public const string FunctionEdit = "~/Administrator/FunctionEdit.aspx";
                public const string FunctionView = "~/Administrator/FunctionView.aspx";
                public const string PolicyByGroup = "~/Administrator/PolicyByGroup.aspx";
                public const string PolicyDisplay = "~/Administrator/PolicyDisplay.aspx";
                public const string PolicyEdit = "~/Administrator/PolicyEdit.aspx";
                public const string PolicyView = "~/Administrator/PolicyView.aspx";
                public const string UserDisplay = "~/Administrator/UserDisplay.aspx";
                public const string UserEdit = "~/Administrator/UserEdit.aspx";
                public const string UserView = "~/Administrator/UserView.aspx";
                public const string UserViewByStatus = "~/Administrator/UserViewByStatus.aspx";
                public const string UserViewByGroup = "~/Administrator/UserViewByGroup.aspx";
            }

            #endregion
        }

        #endregion

        #region ParameterName

        public class ParameterName : ModuleConstants.ParameterName
        {
            public const string MODULE_ID = "MId";
            public const string GROUPS = "Groups";
        }

        #endregion

        #region Session

        public class Session : ModuleConstants.Session
        {
            public class SystemData
            {
                public const string MemberOf = "MemberOf";
                public const string NotMemberOf = "NotMemberOf";
                public const string Members = "Members";
                public const string NotMembers = "NotMembers";
            }
        }

        #endregion

        #region ViewState

        public class ViewState : ModuleConstants.ViewState
        {
            public const string ModuleId = "ModuleId";
            public const string Values = "Values";

            public class SystemData
            {
                public const string MemberOf = "MemberOf";
                public const string NotMemberOf = "NotMemberOf";
                public const string Members = "Members";
                public const string NotMembers = "NotMembers";
            }
        }

        #endregion

        #region Policies

        public abstract class Policies
        {
            public const string Delete = "Xóa";
            public const string Edit = "Sửa";
            public const string None = "Không quyền";
            public const string Special = "Có quyền";
            public const string View = "Xem";

            #region Nested type: ControlNames

            public class ControlNames
            {
                public const string PanelPolicy = "pnlPolicy";
                public const string DropdownListPolicy = "ddlPolicy";
                public const string HiddenFieldCId = "hidCId";
                public const string HiddenFieldFId = "hidFId";
                public const string HiddenFieldGId = "hidGId";
                public const string HiddenFieldId = "hidId";
                public const string HiddenFieldMId = "hidMId";
            }

            #endregion
        }

        #endregion

        #region UserStatus

        public class UserStatus
        {
            public const string Active = "Hoạt động";
            public const string Inactive = "Chưa kích hoạt";
            public const string Locked = "Khóa";
            public const string BlackList = "Danh sách đen";
            public const string RedList = "Danh sách đỏ";
            public const string WhiteList = "Danh sách trắng";
        }

        #endregion
    }
}