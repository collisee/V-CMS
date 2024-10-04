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

namespace VietNamNet.Websites.Sport.UserControls.News
{
  public partial class PanelNewsFeedback : System.Web.UI.UserControl
  {
      #region Members

      [Description("ArticleId")]
      [Browsable(true)]
      [DefaultSettingValue("0")]
      public int ArticleId
      {
          get { return Utilities.ParseInt(ViewState[WebsitesConstants.ViewState.ArticleId]); }
          set { ViewState[WebsitesConstants.ViewState.ArticleId] = value; }
      }
      
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


      #endregion

      
      protected void Page_Load(object sender, EventArgs e)
    {

    }
  }
}