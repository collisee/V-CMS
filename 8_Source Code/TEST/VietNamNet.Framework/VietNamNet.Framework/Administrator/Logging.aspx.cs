using System;
using VietNamNet.Framework.Common;
using Telerik.Web.UI;
using VietNamNet.Framework.System.ValueObject;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;

namespace VietNamNet.Framework.Administrator
{
    public partial class Logging : BasePageView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isViewer)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                DateTime fromDate = (Session[Constants.Session.LOGGING_FROM_DATE] == null)
                                        ? Utilities.GetFirstDayOfMonth()
                                        : (DateTime)Session[Constants.Session.LOGGING_FROM_DATE];
                DateTime toDate = (Session[Constants.Session.LOGGING_TO_DATE] == null)
                                      ? Utilities.GetLastDayOfMonth()
                                      : (DateTime)Session[Constants.Session.LOGGING_TO_DATE];

                Session[Constants.Session.LOGGING_FROM_DATE] = fromDate;
                Session[Constants.Session.LOGGING_TO_DATE] = toDate;

                radDpkLoggingFromDate.SelectedDate = fromDate;
                radDpkLoggingToDate.SelectedDate = toDate;

                Session[Constants.Session.Data.GetLogging] = null;
                Session[Constants.Session.Data.USERS] = null;

                Session[Constants.Session.LOGGING_LEVEL] = -1;
                Session[Constants.Session.LOGGING_USER] = UserId;

                BindDataToUser();

                radRadToolBarExport.Visible = isExporter;
            }
        }

        private void Initialize()
        {
            moduleAlias = "System.Logging";
            viewAlias = "System.Logging.View";
            exportAlias = "System.Logging.Export";
            ActionName = SystemConstants.Services.LoggingManager.Actions.GetLogging;
        }

        private void BindDataToUser()
        {
            if (Session[Constants.Session.Data.USERS] == null)
            {
                UserHelper helper = new UserHelper(new User());
                Session[Constants.Session.Data.USERS] = helper.ListAll();
            }

            radCmbUser.DataSource = Session[Constants.Session.Data.USERS];
            radCmbUser.DataBind();
            radCmbUser.Items.Insert(0, new RadComboBoxItem("Process", "0"));
            radCmbUser.Items.Insert(0, new RadComboBoxItem("Tất cả", "-1"));

            radCmbUser.SelectedValue = UserId.ToString();
        }

        protected void radGridDefault_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            int logLevel = Utilities.ParseInt(Session[Constants.Session.LOGGING_LEVEL]);
            int logUser = Utilities.ParseInt(Session[Constants.Session.LOGGING_USER]);
            DateTime fromDate = (Session[Constants.Session.LOGGING_FROM_DATE] == null)
                                    ? Utilities.GetFirstDayOfMonth()
                                    : (DateTime)Session[Constants.Session.LOGGING_FROM_DATE];
            DateTime toDate = (Session[Constants.Session.LOGGING_TO_DATE] == null)
                                  ? Utilities.GetLastDayOfMonth()
                                  : (DateTime)Session[Constants.Session.LOGGING_TO_DATE];

            if (Session[Constants.Session.Data.GetLogging] == null)
            {
                LoggingHelper helper = new LoggingHelper(new System.ValueObject.Logging());
                helper.ValueObject.LoggingFromDate = fromDate;
                helper.ValueObject.LoggingToDate = toDate;
                helper.ValueObject.LogLevel = logLevel;
                helper.ValueObject.LogUser = logUser;
                Session[Constants.Session.Data.GetLogging] = helper.GetLogging();
            }

            radGridDefault.DataSource = Session[Constants.Session.Data.GetLogging];
        }

        private void ReBindDataToGrid()
        {
            Session[Constants.Session.Data.GetLogging] = null;

            radGridDefault.CurrentPageIndex = 0;
            radGridDefault.Rebind();
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            DateTime fromDate = Utilities.GetFirstDayOfMonth();
            DateTime toDate = Utilities.GetLastDayOfMonth();

            fromDate = (radDpkLoggingFromDate.SelectedDate == null)
                           ? fromDate
                           : (DateTime)radDpkLoggingFromDate.SelectedDate;
            toDate = (radDpkLoggingToDate.SelectedDate == null)
                         ? toDate
                         : (DateTime)radDpkLoggingToDate.SelectedDate;

            Session[Constants.Session.LOGGING_FROM_DATE] = fromDate;
            Session[Constants.Session.LOGGING_TO_DATE] = toDate;

            radDpkLoggingFromDate.SelectedDate = fromDate;
            radDpkLoggingToDate.SelectedDate = toDate;

            ReBindDataToGrid();
        }

        protected void radRadToolBarExport_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.ExportToDoc:
                    radGridDefault.MasterTableView.ExportToWord();
                    break;
                case Constants.CommandNames.ExportToExcel:
                    radGridDefault.MasterTableView.ExportToExcel();
                    break;
                case Constants.CommandNames.ExportToPdf:
                    radGridDefault.MasterTableView.ExportToPdf();
                    break;
                default:
                    break;
            }
        }

        protected void radCmbLogLevel_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!Utilities.Event_Handler(o, e)) return;

            Session[Constants.Session.LOGGING_LEVEL] = radCmbLogLevel.SelectedValue;

            ReBindDataToGrid();
        }

        protected void radCmbUser_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!Utilities.Event_Handler(o, e)) return;

            Session[Constants.Session.LOGGING_USER] = radCmbUser.SelectedValue;

            ReBindDataToGrid();
        }
    }
}