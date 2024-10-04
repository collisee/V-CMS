using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Calendar;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Calendar
{
    public partial class RoomBooking : BasePage
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
            sdsRoomBooking.ConnectionString = Utilities.GetConfigKey(Constants.ConfigKey.SqlConnectionString);
            sdsRoom.ConnectionString = Utilities.GetConfigKey(Constants.ConfigKey.SqlConnectionString);

            //Default Parameter Value
            sdsRoomBooking.SelectParameters[0].DefaultValue = UserId.ToString();
            sdsRoomBooking.InsertParameters[0].DefaultValue = UserId.ToString();
            sdsRoomBooking.InsertParameters[1].DefaultValue = UserId.ToString();
            sdsRoomBooking.UpdateParameters[0].DefaultValue = UserId.ToString();
            sdsRoomBooking.DeleteParameters[0].DefaultValue = UserId.ToString();

            //Add New
            radScheduler1.AllowInsert = isAddNewer;
            SchedulerTimeSlotContextMenu.Enabled = isAddNewer;

            if (!IsPostBack)
            {
                radScheduler1.SelectedDate = DateTime.Today;
                radCalendarSelectedDate.SelectedDate = DateTime.Today;

                SchedulerAppointmentContextMenu.FindItemByText("Sửa").Enabled = isUpdater;
                SchedulerAppointmentContextMenu.FindItemByText("Xóa").Enabled = isSystem && isDeleter;
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

        protected void chklRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            radScheduler1.Rebind();
        }

        protected void chklRoom_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (ListItem item in ((CheckBoxList)sender).Items)
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
                radScheduler1.SelectedView = SchedulerViewType.WeekView;
            }
        }

        protected void radScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
        {
            e.Appointment.Visible = false;

            Resource userRes = e.Appointment.Resources.GetResourceByType("Phòng họp");
            if (userRes != null)
            {
                CheckBoxList chklRoom =
                    PanelBar.Items[0].Items[0].FindControl("chklRoom") as CheckBoxList;
                if (chklRoom != null)
                {
                    ListItem item = chklRoom.Items.FindByValue(userRes.Key.ToString());
                    e.Appointment.Visible = (item != null && item.Selected);
                }

                //Policy
                e.Appointment.AllowEdit = isUpdater;
                e.Appointment.AllowDelete = isSystem && isDeleter;
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

        private string GroupByExpression
        {
            get
            {
                CheckBox GroupByRoomCheckBox =
                    PanelBar.Items[1].Items[0].FindControl("GroupByRoomCheckBox") as CheckBox;
                CheckBox GroupByDateCheckBox =
                    PanelBar.Items[1].Items[0].FindControl("GroupByDateCheckBox") as CheckBox;
                if (GroupByRoomCheckBox == null || !GroupByRoomCheckBox.Checked)
                    return string.Empty;
                return (GroupByDateCheckBox != null && GroupByDateCheckBox.Checked) ? "Date, Phòng họp" : "Phòng họp";
            }
        }

        private string GroupingDirection
        {
            get
            {
                RadComboBox GroupingDirectionComboBox =
                    PanelBar.Items[1].Items[0].FindControl("GroupingDirectionComboBox") as RadComboBox;
                return (GroupingDirectionComboBox == null) ? string.Empty : GroupingDirectionComboBox.SelectedValue;
            }
        }

        private void UpdateScheduler()
        {
            radScheduler1.GroupBy = GroupByExpression;
            radScheduler1.GroupingDirection =
                (GroupingDirection)Enum.Parse(typeof(GroupingDirection), GroupingDirection);

            radScheduler1.Rebind();
        }

        protected void GroupByRoomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox GroupByRoomCheckBox =
                PanelBar.Items[1].Items[0].FindControl("GroupByRoomCheckBox") as CheckBox;
            CheckBox GroupByDateCheckBox =
                PanelBar.Items[1].Items[0].FindControl("GroupByDateCheckBox") as CheckBox;
            RadComboBox GroupingDirectionComboBox =
                PanelBar.Items[1].Items[0].FindControl("GroupingDirectionComboBox") as RadComboBox;
            if (GroupByRoomCheckBox != null && GroupByDateCheckBox != null && GroupingDirectionComboBox != null)
            {
                GroupByDateCheckBox.Enabled = GroupByRoomCheckBox.Checked;
                GroupingDirectionComboBox.Enabled = GroupByRoomCheckBox.Checked;
            }
            UpdateScheduler();
        }

        protected void GroupByDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScheduler();
        }

        protected void GroupingDirectionComboBox_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            UpdateScheduler();
        }
    }
}