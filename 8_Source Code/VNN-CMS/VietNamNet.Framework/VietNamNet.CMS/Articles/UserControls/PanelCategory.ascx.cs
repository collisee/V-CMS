using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.Framework.Common;

namespace VietNamNet.CMS.Articles.UserControls
{
    public partial class PanelCategory : UserControl
    {
        #region Public Properties

        [Description("Item Id")]
        [Browsable(true)]
        [DefaultSettingValue("0")]
        public int ItemNo
        {
            get { return Utilities.ParseInt(ViewState[CMSConstants.ViewState.ItemNo]); }
            set { ViewState[CMSConstants.ViewState.ItemNo] = value; }
        }

        #endregion

        #region Handler Method

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Public Method

        public void BindData(DataTable source)
        {
            cmbSubCategory.DataSource = source;
            cmbSubCategory.DataBind();
        }

        public void BindData(DataTable source, int cid, int ord)
        {
            cmbSubCategory.DataSource = source;
            cmbSubCategory.DataBind();

            if (cid > 0) cmbSubCategory.SelectedValue = cid.ToString();
            if (ord > 1) txtSubOrd.Value = ord;
        }

        public int GetCategoryId()
        {
            return Utilities.ParseInt(cmbSubCategory.SelectedValue);
        }

        public int GetCategoryOrder()
        {
            return Utilities.ParseInt(txtSubOrd.Value);
        }

        #endregion
    }
}