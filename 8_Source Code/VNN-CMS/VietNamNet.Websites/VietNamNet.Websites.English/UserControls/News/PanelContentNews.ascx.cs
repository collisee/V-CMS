using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.English.UserControls.News
{
  public partial class PanelContentNews : UserControl
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
          rptContent.DataSource = dtArticle;
          rptContent.DataBind();

          string title =
            dtArticle.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.Name].ToString().Replace("\"",
                                                                                                         string.Empty);
          Page.Title = string.Format("VietNamNet - {0} | {1}", title, Utilities.RemoveVietNamChar(title));

          int aticleContentType =
            Utilities.ParseInt(
              dtArticle.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.ArticleContentTypeId]);
          //Photo
          if (aticleContentType == 2)
          {
            PanelContentPhoto1.ArticleId = ArticleId;
          }
          else
          {
            PanelContentPhoto1.Visible = false;
          }

          //Video
          if (aticleContentType == 3)
          {
            PanelContentVideo1.ArticleId = ArticleId;
          }
          else
          {
            PanelContentVideo1.Visible = false;
          }

          SetupEnvironment();
        }
      }
    }

    #region Private Methods

    private void SetupEnvironment()
    {
      Page.ClientScript.RegisterClientScriptBlock(GetType(), "ArticleSendEmail",
                                                  "$().ready(function() {$('#digSendEmail').jqm({trigger: 'a.mail'});});",
                                                  true);
    }

    #endregion
  }
}