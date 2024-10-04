using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Union.UserControls.News
{
    public partial class PanelNewsVideo : UserControl
    {
        [Description("ArticleId")]
        [Browsable(true)]
        [DefaultSettingValue("0")]
        public int ArticleId
        {
            get { return Utilities.ParseInt(ViewState[UnionConstants.ViewState.ArticleId]); }
            set { ViewState[UnionConstants.ViewState.ArticleId] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}