using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Calendar;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Calendar
{
    public partial class _Default : BasePage
    {
        protected bool isSystem = false;
        protected string systemAlias = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isViewer)
            {
                Utilities.NoRightToAccess();
            }

            //Connection String
            sdsAppointment.ConnectionString = Utilities.GetConfigKey(Constants.ConfigKey.SqlConnectionString);
            sdsAppointmentType.ConnectionString = Utilities.GetConfigKey(Constants.ConfigKey.SqlConnectionString);

            //Default Parameter Value
            sdsAppointment.SelectParameters[0].DefaultValue = UserId.ToString();
            sdsAppointment.InsertParameters[0].DefaultValue = UserId.ToString();
            sdsAppointment.InsertParameters[1].DefaultValue = UserId.ToString();
            sdsAppointment.UpdateParameters[0].DefaultValue = UserId.ToString();
            sdsAppointment.DeleteParameters[0].DefaultValue = UserId.ToString();

            //Add New
            radScheduler1.AllowInsert = isAddNewer;
            SchedulerTimeSlotContextMenu.Enabled = isAddNewer;

            if (!IsPostBack)
            {
                radScheduler1.SelectedDate = DateTime.Today;
                radCalendarSelectedDate.SelectedDate = DateTime.Today;
            }
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.AddOn.Calendar";
            viewAlias = "VietNamNet.AddOn.Calendar.View";
            addNewAlias = "VietNamNet.AddOn.Calendar.AddNew";
            updateAlias = "VietNamNet.AddOn.Calendar.Update";
            deleteAlias = "VietNamNet.AddOn.Calendar.Delete";
            systemAlias = "VietNamNet.AddOn.Calendar.System";
        }

        protected override void GetPolicy()
        {
            base.GetPolicy();

            isSystem = SystemUtils.GetPolicy(UserId, moduleAlias, systemAlias);
        }

        protected void chklAppointmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            radScheduler1.Rebind();
        }

        protected void chklAppointmentType_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (ListItem item in ((CheckBoxList) sender).Items)
                {
                    item.Selected = true;
                }
            }
        }

        protected void radCalendarSelectedDate_SelectionChanged(object sender, SelectedDatesEventArgs e)
        {
            if (radCalendarSelectedDate.SelectedDates.Count > 0)
            {
                radScheduler1.SelectedDate = radCalendarSelectedDate.SelectedDate;
                radScheduler1.SelectedView = SchedulerViewType.DayView;
            }
        }

        protected void radScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
        {
            e.Appointment.Visible = false;

            Resource userRes = e.Appointment.Resources.GetResourceByType("Lịch làm việc");
            if (userRes != null)
            {
                CheckBoxList chklAppointmentType =
                    PanelBar.Items[0].Items[0].FindControl("chklAppointmentType") as CheckBoxList;
                if (chklAppointmentType != null)
                {
                    ListItem item = chklAppointmentType.Items.FindByValue(userRes.Key.ToString());
                    e.Appointment.Visible = (item != null && item.Selected);
                }

                //Policy
                if (Utilities.ParseInt(userRes.Key) == 2) //Tòa soạn
                {
                    e.Appointment.AllowEdit = isSystem && isUpdater;
                    e.Appointment.AllowDelete = isSystem && isDeleter;
                }
                else //Cá nhân
                {
                    e.Appointment.AllowEdit = isUpdater;
                    e.Appointment.AllowDelete = isDeleter;
                }
            }
        }

        protected void radScheduler1_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
        {
            if (!radScheduler1.AllowInsert)
            {
                e.Cancel = true;
            }
        }

        protected void radScheduler1_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
        {
            if (!e.Appointment.AllowDelete)
            {
                e.Cancel = true;
            }
        }

        protected void radScheduler1_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
        {
            if (!e.Appointment.AllowEdit)
            {
                e.Cancel = true;
            }
        }
    }
}