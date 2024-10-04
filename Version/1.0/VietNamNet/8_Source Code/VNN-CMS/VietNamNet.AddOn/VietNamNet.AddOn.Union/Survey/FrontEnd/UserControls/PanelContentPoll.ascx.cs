using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.Common;

namespace VietNamNet.Websites.V1.UserControls.News
{
  public partial class PanelContentPoll : System.Web.UI.UserControl
  {
      private int _articleId;
      private string _categoryAlias;

    [Description("ArticleId")]
    [Browsable(true)]
    [DefaultSettingValue("0")]
    public int ArticleId
    {
      get { return _articleId; }
      set { _articleId = value; }
    }

    [Description("Category Alias")]
    [Browsable(true)]
    [DefaultSettingValue("")]
    public string CategoryAlias
    {
      get
      {
          return _categoryAlias;
      }
      set { _categoryAlias = value; }
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
        SetupEnvironment();
        lblItem.Text = "<div id=\"Survey_" + CategoryAlias + ArticleId.ToString() + "\"></div><script>showPoll('" + CategoryAlias + "','"+ArticleId+"','Survey_" + CategoryAlias + ArticleId + "');</script> ";

    }
  }
}