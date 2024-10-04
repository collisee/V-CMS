using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Petro.Common;

namespace VietNamNet.Websites.Petro.UserControls.Homepage
{
    public partial class SubPanelTopImages : UserControl
    {
        [Description("Category Alias")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string CategoryAlias
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[PetroConstants.ViewState.CategoryAlias])
                        ? string.Empty
                        : ViewState[PetroConstants.ViewState.CategoryAlias].ToString();
            }
            set { ViewState[PetroConstants.ViewState.CategoryAlias] = value; }
        }

        [Description("Article Name")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string ArticleName
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[PetroConstants.ViewState.ArticleName])
                        ? string.Empty
                        : ViewState[PetroConstants.ViewState.ArticleName].ToString();
            }
            set { ViewState[PetroConstants.ViewState.ArticleName] = value; }
        }

        [Description("Image Link")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string ImageLink
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[PetroConstants.ViewState.ImageLink])
                        ? string.Empty
                        : ViewState[PetroConstants.ViewState.ImageLink].ToString();
            }
            set { ViewState[PetroConstants.ViewState.ImageLink] = value; }
        }

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