using System;
using System.Data;
using System.Web.UI;
using System.ComponentModel;
using System.Configuration;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Presentation;
using VietNamNet.Websites.Core.Common.ValueObject;

namespace VietNamNet.Websites.Clip.ui._3g
{
  public partial class PanelArticlePlaylist : UserControl
  {
    [Description("ArticleId")]
    [Browsable(true)]
    [DefaultSettingValue("0")]
    public int ArticleId
    {
      get { return Utilities.ParseInt(ViewState[WebsitesConstants.ViewState.ArticleId]); }
      set { ViewState[WebsitesConstants.ViewState.ArticleId] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
        helper.ValueObject.ArticleId = ArticleId;
        DataTable dtArticle = helper.GetArticle();
        if (dtArticle != null && dtArticle.Rows.Count > 0)
        {
          rptNewsDetail.DataSource = dtArticle;
          rptNewsDetail.DataBind();

          SetupEnvironment();
        }
      }
    }

    #region Private Methods

    private void SetupEnvironment()
    {
      Page.ClientScript.RegisterClientScriptBlock(GetType(), "ArticleSendEmail",
                                                  "$().ready(function() {$('#digSendEmail').jqm({trigger: 'a.sentmail_link'});});",
                                                  true);
    }

    #endregion
  }
}