using System;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.UserControls.Search
{
    public partial class PanelTitle : System.Web.UI.UserControl
    {
        [Description("Title")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string Title
        {
            get
            {
                return
                  Title.ToString();
            }
            set { ViewState[WebsitesConstants.ViewState.CategoryAlias] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}