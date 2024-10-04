using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.UserControls
{
    public partial class PanelAdvertisement : UserControl
    {
        [Description("Category Alias")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string CategoryAlias
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.CategoryAlias])
                        ? string.Empty
                        : ViewState[WebsitesConstants.ViewState.CategoryAlias].ToString();
            }
            set { ViewState[WebsitesConstants.ViewState.CategoryAlias] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}