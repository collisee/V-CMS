using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Presentation;
using VietNamNet.Websites.Core.Common.ValueObject;

namespace VietNamNet.Websites.V1.UserControls.News
{
  public partial class PanelNewsDetail : UserControl
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

          string title = dtArticle.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.Name].ToString().Replace("\"", string.Empty);
          Page.Title = string.Format("VietNamNet - {0} | {1}", title, Utilities.RemoveVietNamChar(title));

          //int aticleContentType =
          //  Utilities.ParseInt(
          //    dtArticle.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.ArticleContentTypeId]);
          ////Photo
          //if (aticleContentType == 2)
          //{
          //  PanelNewsPhoto1.ArticleId = ArticleId;
          //}
          //else
          //{
          //  PanelNewsPhoto1.Visible = false;
          //}

          ////Video
          //if (aticleContentType == 3)
          //{
          //  PanelNewsVideo1.ArticleId = ArticleId;
          //}
          //else
          //{
          //  PanelNewsVideo1.Visible = false;
          //}
            SetupEnvironment();
        }
      }
  }

    #region Private Methods
        private void SetupEnvironment()
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ArticleSendEmail",
                             "$().ready(function() {$('#digSendEmail').jqm({trigger: 'a.mail'});});", true);

        }
    #endregion
}
}