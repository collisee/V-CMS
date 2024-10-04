using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.UserControls.LayoutClassical
{
    public partial class Header : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataToLayout();
            }
        }

        private void BindDataToLayout()
        {
            if (Session[Constants.Session.SYSTEM_LAYOUT_DATA] == null)
            {
                DataTable dt = new DataTable("SYSTEM_LAYOUT_DATA");
                dt.Columns.Add("Name");
                dt.Columns.Add("File");

                string[] systemLayouts =
                    Utilities.GetConfigKey(Constants.ConfigKey.SystemLayout).Split(new char[] {',', ';'},
                                                                                   StringSplitOptions.RemoveEmptyEntries);
                string[] systemLayoutFiles =
                    Utilities.GetConfigKey(Constants.ConfigKey.SystemLayoutFile).Split(new char[] {',', ';'},
                                                                                       StringSplitOptions.
                                                                                           RemoveEmptyEntries);
                for (int i = 0; i < systemLayouts.Length; i++)
                {
                    string layoutName = systemLayouts[i];
                    string layoutFile = (i < systemLayoutFiles.Length) ? systemLayoutFiles[i] : string.Empty;
                    dt.Rows.Add(new object[] {layoutName, layoutFile});
                }

                Session[Constants.Session.SYSTEM_LAYOUT_DATA] = dt;
            }

            cmbLayout.DataSource = Session[Constants.Session.SYSTEM_LAYOUT_DATA];
            cmbLayout.DataBind();
            if (Session[Constants.Session.SYSTEM_LAYOUT] != null)
                cmbLayout.SelectedValue = Session[Constants.Session.SYSTEM_LAYOUT].ToString();
        }

        protected void cmbLayout_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Session[Constants.Session.SYSTEM_LAYOUT] = cmbLayout.SelectedValue;

            string url = Request.Url.ToString();
            Response.Redirect(url);
        }

        protected void RadSkinManager1_SkinChanged(object sender, Telerik.Web.UI.SkinChangedEventArgs e)
        {
            int id = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
            if (id <= 0) return;

            UserHelper helper = new UserHelper(new User());
            helper.ValueObject.Id = id;
            helper.Load();
            if (helper.ValueObject != null)
            {
                helper.ValueObject.Skin = RadSkinManager1.Skin;
                helper.DoSave();
            }
        }
    }
}