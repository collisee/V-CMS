using System;
using System.Web.UI;
using Telerik.Web.UI.Calendar;

namespace VietNamNet.AddOn.Union.UserControls
{
    public partial class PanelCalendar : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                radCalendarSelectedDate.SelectedDate = DateTime.Today;
            }
        }

        protected void radCalendarSelectedDate_SelectionChanged(object sender, SelectedDatesEventArgs e)
        {
            if (radCalendarSelectedDate.SelectedDates.Count > 0)
            {
                Response.Redirect("~/Calendar/Default.aspx");
            }
        }
    }
}