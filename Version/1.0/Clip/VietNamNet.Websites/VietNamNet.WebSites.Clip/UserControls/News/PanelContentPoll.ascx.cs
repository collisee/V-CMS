using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Clip.UserControls.News
{
  public partial class PanelContentPoll : System.Web.UI.UserControl
  {
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopularItem();

        }

    }
    private void SetupEnvironment()
    {
        //Registe poll js
        if (!this.Page.ClientScript.IsClientScriptBlockRegistered("poll.js"))
        {
            this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "poll.js",
                         "<script src=\"" + this.Page.ResolveUrl("/js/poll.js") + "\"></script>");
        }

        ////Registe jQuery js
        //if (!this.Page.ClientScript.IsClientScriptBlockRegistered("jquery-1.4.2.min.js"))
        //{
        //    this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "jquery-1.4.2.min.js",
        //                 "<script src=\"" + this.Page.ResolveUrl("/js/jquery-1.4.2.min.js") + "\"></script>");
        //}
        ////Registe jQueryUI js
        //if (!this.Page.ClientScript.IsClientScriptBlockRegistered("jquery-ui-1.8.1.custom.min.js"))
        //{
        //    this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "jquery-ui-1.8.1.custom.min.js",
        //                 "<script src=\"" + this.Page.ResolveUrl("/js/jquery-ui-1.8.1.custom.min.js") + "\"></script>");
        //}

    }
    private void PopularItem()
    {
         
        // Get Survey by Artile
        SubSonic.StoredProcedure sproc = SPs.SurveyListByArticle(ArticleId);
        List<SurveyPublish> p = sproc.ExecuteTypedList<SurveyPublish>();
        if (p.Count > 0)
        {
            SetupEnvironment();
            lblItem.Text = "<div id=\"Survey_" + p[0].SurveyPublishId + "\"></div><script>showPoll('" + p[0].SurveyId + "','Survey_" + p[0].SurveyPublishId + "');</script> ";
        }

    }
  }
}