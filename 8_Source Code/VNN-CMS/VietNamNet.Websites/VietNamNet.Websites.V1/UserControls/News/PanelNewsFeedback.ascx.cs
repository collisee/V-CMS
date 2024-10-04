using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.UserControls.News
{
  public partial class PanelNewsFeedback : UserControl
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

    [Description("Page")]
    [Browsable(true)]
    [DefaultSettingValue("1")]
    public int PageNumber
    {
      get { return Utilities.ParseInt(ViewState[WebsitesConstants.ViewState.PageNumber]); }
      set { ViewState[WebsitesConstants.ViewState.PageNumber] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SetupEnvironment();
    }


    private void SetupEnvironment()
    {
      ////Registe poll js
      //if (!this.Page.ClientScript.IsClientScriptBlockRegistered("feedback.js"))
      //{
      //    this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "feedback.js",
      //                                                   "<script src=\"" + this.Page.ResolveUrl("/js/feedback.js") +
      //                                                   "\"></script>");
      //}
    }
  }
}