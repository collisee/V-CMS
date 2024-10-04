using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Petro.Common;

namespace VietNamNet.Websites.Petro.UserControls.News
{
    public partial class VideoPlayer : UserControl
    {
        [Description("ArticleId")]
        [Browsable(true)]
        [DefaultSettingValue("0")]
        public int ArticleId
        {
            get { return Utilities.ParseInt(ViewState[PetroConstants.ViewState.ArticleId]); }
            set { ViewState[PetroConstants.ViewState.ArticleId] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}