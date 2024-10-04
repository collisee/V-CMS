using System;
using System.Web.UI;

namespace VietNamNet.Websites.English.UserControls
{
    public partial class PanelHeader : UserControl
    {
        public string strNow = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] days =
                    new string[] {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};
                string[] months =
                    new string[]
                        {
                            "January", "February", "March", "April", "May", "June", "July", "August", "September",
                            "October", "November", "December"
                        };

                strNow = string.Format("{0}, {1} {2} {3}, {4}", days[(int) DateTime.Now.DayOfWeek], DateTime.Now.Day
                                       , months[DateTime.Now.Month - 1], DateTime.Now.Year,
                                       DateTime.Now.ToString("HH:mm:ss tt"));
            }
        }
    }
}