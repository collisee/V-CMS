using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.UserControls.Survey
{
    public partial class PaneGame : System.Web.UI.UserControl
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
                SetupEnvironment();
            PopularItem();

        }

    }
    private void SetupEnvironment()
    {
        ////Registe poll js
        //if (!this.Page.ClientScript.IsClientScriptBlockRegistered("poll.js"))
        //{
        //    this.Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "poll.js",
        //                 "<script src=\"" + Page.ResolveUrl("/Scripts/poll.js") + "\"></script>");
        //}
    }
    private void PopularItem()
    {
      
       

    }
  }
}