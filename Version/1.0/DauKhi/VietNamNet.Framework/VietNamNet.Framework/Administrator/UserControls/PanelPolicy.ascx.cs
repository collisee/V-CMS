using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.Administrator.UserControls
{
    public partial class PanelPolicy : UserControl
    {
        [Description("Module Id")]
        [Browsable(true)]
        [DefaultSettingValue("0")]
        public int ModuleId
        {
            get { return Utilities.ParseInt(ViewState[SystemConstants.ViewState.ModuleId]); }
            set { ViewState[SystemConstants.ViewState.ModuleId] = value; }
        }

        [Description("Values")]
        [Browsable(true)]
        [DefaultSettingValue("0")]
        public int Values
        {
            get { return Utilities.ParseInt(ViewState[SystemConstants.ViewState.Values]); }
            set { ViewState[SystemConstants.ViewState.Values] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            BindDataToFunction(ModuleId, Values);
            base.OnPreRender(e);
        }

        public void BindDataToFunction(int mid, int values)
        {
            if (mid <= 0) return;
            FunctionHelper helper = new FunctionHelper(new Function());
            helper.ValueObject.ModuleId = mid;
            cblFunctions.DataSource = helper.GetFunctionByModuleId();
            cblFunctions.DataBind();

            if (values > 0)
            {
                foreach (ListItem item in cblFunctions.Items)
                {
                    int ord = Utilities.ParseInt(item.Value);
                    int value = 1 << (ord - 1);
                    item.Selected = (values & value) == value;
                }
            }
        }

        public int GetValues()
        {
            //get access
            int access = 0;
            foreach (ListItem item in cblFunctions.Items)
            {
                if (item.Selected)
                {
                    int ord = Utilities.ParseInt(item.Value);
                    access |= 1 << (ord - 1);
                }
            }

            return access;
        }
    }
}