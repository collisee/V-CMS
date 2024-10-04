namespace VietNamNet.Framework.Common
{
    public abstract class Constants
    {
        #region CommandNames

        public abstract class CommandNames
        {
            public const string AddNew = "AddNew";
            public const string Approve = "Approve";
            public const string Accept = "Accept";
            public const string BlackList = "BlackList";
            public const string Cancel = "Cancel";
            public const string Clear = "Clear";
            public const string Collapse = "Expand/Collapse";
            public const string Copy = "Copy";
            public const string Delete = "Delete";
            public const string Edit = "Edit";
            public const string ExportToDoc = "ExportToDoc";
            public const string ExportToExcel = "ExportToExcel";
            public const string ExportToPdf = "ExportToPdf";
            public const string Finish = "Finish";
            public const string Find = "Find";
            public const string GoBacktoView = "GoBacktoView";
            public const string Optimize = "Optimize";
            public const string Preview = "Preview";
            public const string Publish = "Publish";
            public const string Reject = "Reject";
            public const string Remove = "Remove";
            public const string RowClick = "RowClick";
            public const string RowDblClick = "RowDblClick";
            public const string Save = "Save";
            public const string Search = "Search";
            public const string Stop = "Stop";
            public const string Submit = "Submit";
            public const string Upload = "Upload";
        }

        #endregion

        #region ConfigKey

        public class ConfigKey
        {
            public const string SqlConnectionString = "SqlConnectionString";
            public const string AdminGroupID = "AdminGroupID";
            public const string Captcha = "Captcha";
            public const string CaptchaKey = "CaptchaKey";
            public const string CaptchaSalt = "CaptchaSalt";
            public const string Currency = "Currency";
            public const string DisplayDateFormat = "DisplayDateFormat";
            public const string DisplayDateTimeFormat = "DisplayDateTimeFormat";
            public const string DisplayDecimalFormat = "DisplayDecimalFormat";
            public const string DisplayNumberFormat = "DisplayNumberFormat";
            public const string LogLevel = "LogLevel";
            public const string MinDate = "MinDate";
            public const string PageSize = "PageSize";
            public const string PageViewSize = "PageViewSize";
            public const string Security = "Security";
            public const string SystemLayout = "System.Layout";
            public const string SystemLayoutFile = "System.Layout.File";
            public const string SMTPMailServer = "SMTPMailServer";
            public const string SMTPMailServerPort = "SMTPMailServerPort";
            public const string SMTPMailServerSecure = "SMTPMailServerSecure";
            public const string POP3MailServer = "POP3MailServer";
            public const string POP3MailServerPort = "POP3MailServerPort";
            public const string POP3MailServerSecure = "POP3MailServerSecure";
            public const string SystemEmail = "SystemEmail";
            public const string SystemEmailAlias = "SystemEmailAlias";
            public const string SystemEmailLoginname = "SystemEmailLoginname";
            public const string SystemEmailPasword = "SystemEmailPasword";
            public const string TimeCaching = "TimeCaching";
            public const string ThumbnailWidth = "ThumbnailWidth";
            public const string ThumbnailHeight = "ThumbnailHeight";
            public const string UserGroupID = "UserGroupID";
            public const string PoweredLink = "PoweredLink";
            public const string PoweredName = "PoweredName";
            public const string CopyrightLink = "CopyrightLink";
            public const string CopyrightName = "CopyrightName";
        }

        #endregion

        #region CommonStatus

        public class CommonStatus
        {
            public const string ACCEPTED = "ACCEPTED";
            public const string APPROVED = "APPROVED";
            public const string DELETE = "DELETE";
            public const string DELETED = "DELETED";
            public const string DRAFT = "DRAFT";
            public const string NEW = "NEW";
            public const string No = "No";
            public const string NOTAPPROVE = "NOTAPPROVE";
            public const string PUBLISHED = "PUBLISHED";
            public const string REJECTED = "REJECTED";
            public const string STOP = "STOP";
            public const string UPDATE = "UPDATE";
            public const string WAITINGPROCESS = "WAITINGPROCESS";
            public const string Yes = "Yes";
        }

        #endregion

        #region UserStatus

        public class UserStatus
        {
            public const string Locked = "Khóa";
            public const string Active = "Hoạt động";
            public const string Unactive = "Chưa kích hoạt";
        }

        #endregion

        #region Paging

        public class Paging
        {
            #region Nested type: Action

            public class Action
            {
                public static string First = "First";
                public static string GotoPage = "GotoPage";
                public static string Last = "Last";
                public static string Next = "Next";
                public static string Prev = "Prev";
            }

            #endregion

            #region Nested type: ControlName

            public class ControlName
            {
                public const string ContentPlaceHolderContainer = "cplhContainer";
                public const string DropDownListChoiceIndexOfPage = "ddlChoiceIndexOfPage";
                public const string FormDefault = "frmDefault";
                public const string GridViewDefault = "grdViewDefault";
                public const string ImageButtonFirst = "ibtnFirst";
                public const string ImageButtonLast = "ibtnLast";
                public const string ImageButtonNext = "ibtnNext";
                public const string ImageButtonPrev = "ibtnPrev";
                public const string LabelCurrentPage = "lblCurrentPage";
                public const string LabelSeparatorFirst = "lblSeparatorFirst";
                public const string LabelSeparatorLast = "lblSeparatorLast";
                public const string LabelSeparatorNext = "lblSeparatorNext";
                public const string LabelSeparatorPage = "lblSeparatorPage";
                public const string LabelSeparatorPrev = "lblSeparatorPrev";
                public const string LabelTotalPage = "lblTotalPage";
                public const string LinkButtonFirst = "lbtnFirst";
                public const string LinkButtonGotoPage = "lbtnGotoPage";
                public const string LinkButtonLast = "lbtnLast";
                public const string LinkButtonNext = "lbtnNext";
                public const string LinkButtonPrev = "lbtnPrev";
                public const string PanelPaging = "pnlPaging";
                public const string PanelToolbar = "pnlToolbar";
                public const string RadGridDefault = "radGridDefault";
                public const string RepeaterView = "repeaterView";

                #region Nested type: ComboBox

                public class ComboBox
                {
                    public const string ComboText = "ComboText";
                    public const string ComboValue = "ComboValue";
                }

                #endregion
            }

            #endregion

            #region Nested type: Direction

            public class Direction
            {
                public const string CategoryId = "CategoryId";
                public const string CertificateTypeId = "CertificateTypeId";
                public const string CId = "CId";
                public const string CurrentPage = "CurrentPage";
                public const string FirstPage = "1";
                public const string GId = "GId";
                public const string IsSearch = "IsSearch";
                public const string KeyWords = "KeyWords";
                public const string ManuId = "ManuId";
                public const string NextPage = "NextPage";
                public const string NoPage = "0";
                public const string NotSearching = "false";
                public const string OnePage = "1";
                public const string PageCount = "PageCount";
                public const string PageIndex = "PageIndex";
                public const string PageSize = "PageSize";
                public const string PagingTableName = "PagingTable";
                public const string PreviousPage = "PreviousPage";
                public const string RootId = "RootId";
                public const string Searching = "true";
                public const string SearchingTableName = "SearchTable";
                public const string Status = "Status";
                public const string UId = "UId";
            }

            #endregion
        }

        #endregion

        #region ParameterName

        public abstract class ParameterName
        {
            public const string COPY_ID = "CopyId";
            public const string DOC_ID = "DocId";
            public const string FILE = "File";
            public const string FILEPATH = "FilePath";
            public const string GOBACK = "Goback";
            public const string PARENT_ID = "PId";
            public const string GROUP_ID = "GId";
            public const string HEIGHT = "Height";
            public const string KEY = "Key";
            public const string KEYWORD = "Keyword";
            public const string LASTURL = "LastUrl";
            public const string MESSAGE = "Msg";
            public const string PAGE = "Page";
            public const string REDIRECT = "redi";
            public const string RETURN_URL = "ReturnUrl";
            public const string RETURN_VIEW = "ReturnView";
            public const string STATUS = "Status";
            public const string SAVE_SUCCESS = "Save";
            public const string WIDTH = "Width";
        }

        #endregion

        #region Session

        public abstract class Session
        {
            public const string LOGGING_FROM_DATE = "LOGGING_FROM_DATE";
            public const string LOGGING_LEVEL = "LOGGING_LEVEL";
            public const string LOGGING_TO_DATE = "LOGGING_TO_DATE";
            public const string LOGGING_USER = "LOGGING_USER";
            public const string SYSTEM_LAYOUT = "SYSTEM_LAYOUT";
            public const string SKIN = "Skin";
            public const string MENU = "MENU";
            public const string SYSTEM_LAYOUT_DATA = "SYSTEM_LAYOUT_DATA";
            public const string SOURCE_URL = "SOURCE_URL";
            public const string USER = "USER";
            public const string USER_AVATAR = "USER_AVATAR";
            public const string USER_EMAIL = "USER_EMAIL";
            public const string USER_FULLNAME = "USER_FULLNAME";
            public const string USER_GROUP = "USER_GROUP";
            public const string USER_ID = "USER_ID";
            public const string USER_LASTLOGIN = "USER_LASTLOGIN";
            public const string USER_LOGINNAME = "USER_LOGINNAME";
            public const string USER_PASSWORD = "USER_PASSWORD";
            public const string USER_STATUS = "USER_STATUS";
            public const string USER_POLICY = "USER_POLICY";
            public const string USERS_ONLINE = "USERS_ONLINE";
            public const string USERS_VISIT = "USERS_VISIT";

            public class Data
            {
                public const string GetLogging = "GetLogging";
                public const string USERS = "USERS";
            }
        }

        #endregion

        #region ViewState

        public abstract class ViewState
        {
            public const string USER_POLICY = "USER_POLICY";
        }

        #endregion

        #region Security

        public enum Security
        {
            ON,
            OFF
        }

        #endregion

        #region LogLevel

        public enum LogLevel
        {
            All,
            Info,
            Error,
            System,
            None
        }

        #endregion

        #region PolicyRight

        public class PolicyRight
        {
            public static int[] Special = {   0x0000,
                                              0x0001, 0x0002, 0x0004, 0x0008,
                                              0x0010, 0x0020, 0x0040, 0x0080,
                                              0x0100, 0x0200, 0x0400, 0x0800,
                                              0x1000, 0x2000, 0x4000, 0x8000
                                          };
            public static int All = 0xFFFF;
        }

        #endregion

        #region Message

        public abstract class Message
        {
            public const string CantNotCreateThumb = "CantNotCreateThumb";
            public const string CantSendEmail = "CantSendEmail";
            public const string InvalidText = "InvalidText";
            public const string ItemDoesntExist = "ItemDoesntExist";
            public const string NoRightToAccess = "NoRightToAccess";
            public const string NoRightToCreate = "NoRightToCreate";
            public const string NoRightToDelete = "NoRightToDelete";
            public const string UserDoesntLogin = "UserDoesntLogin";
            public const string UserDoesntExist = "UserDoesntExist";
            public const string UserLoginFailed = "UserLoginFailed";
            public const string UserLoginSuccess = "UserLoginSuccess";
            public const string UserLogoutFailed = "UserLogoutFailed";
            public const string UserLogoutSuccess = "UserLogoutSuccess";
            public const string UserLocked = "UserLocked";
            public const string UserTryLocked = "UserTryLocked";
        }

        #endregion

        #region FormNames

        public abstract class FormNames
        {
            public const string ChangePassword = "~/ChangePassword.aspx";
            public const string FindPassword = "~/FindPassword.aspx";
            public const string CtrlPanel = "~/CtrlPanel.aspx";
            public const string Default = "~/Default.aspx";
            public const string Root = "~/";
            public const string Error = "~/Error.aspx";
            public const string Help = "~/Help.aspx";
            public const string Login = "~/Login.aspx";
            public const string Logout = "~/Logout.aspx";
            public const string SystemInfo = "~/SystemInfo.aspx";
            public const string UserInfo = "~/UserInfo.aspx";
        }

        #endregion

        #region EmailTemplates

        public abstract class EmailTemplates
        {
            public const string ChangePassword = @"~\EmailTemplates\TemplateChangePassword.xslt";
            public const string NewPassword = @"~\EmailTemplates\TemplateNewPassword.xslt";
        }

        #endregion

        #region Connector String SQL

        public abstract class ConnectorString
        {
            public const string AND_STRING = " AND ";
            public const string HAVING_STRING = " HAVING ";
            public const string OR_STRING = " OR ";
            public const string WHERE_STRING = " WHERE ";
        }

        #endregion
    }
}