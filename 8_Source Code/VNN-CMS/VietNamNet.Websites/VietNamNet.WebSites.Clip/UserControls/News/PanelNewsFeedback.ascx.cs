﻿using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Clip.UserControls.News
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
      if (!IsPostBack)
      {
        ////Get PageNumber
        //int pageSize = Utilities.GetPageSize();
        //if (PageNumber <= 0) PageNumber = 1;

        //if (PageNumber <= 1) hplPrev.Visible = false;
        //hplPrev.NavigateUrl = string.Format("/vn/{0}/page/{1}/index.html", CategoryAlias, PageNumber - 1);
        //hplNext.NavigateUrl = string.Format("/vn/{0}/page/{1}/index.html", CategoryAlias, PageNumber + 1);

        //WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
        //helper.ValueObject.ArticleId = ArticleId;
        //helper.ValueObject.FirstIndexRecord = (PageNumber - 1) * pageSize + 1;
        //helper.ValueObject.LastIndexRecord = PageNumber * pageSize;

        //DataTable dt = helper.GetArticleComment();
        //if (dt != null && dt.Rows.Count > 0)
        //{
        //  rptComment.DataSource = dt;
        //  rptComment.DataBind();
        //}
        //else
        //{
        //  pnlList.Visible = false;
        //}
      }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (Nulls.IsNullOrEmpty(txtName.Text.Trim()) || Nulls.IsNullOrEmpty(txtComment.Text.Trim()))
      {
        //lblError.Visible = true;
        return;
      }

      string Name = txtName.Text.Trim();
      string Email = txtEmail.Text.Trim();
      string Phone = txtPhone.Text.Trim();
      string Detail = txtComment.Text.Trim();

      ArticleCommentHelper helper = new ArticleCommentHelper(new ArticleComment());
      helper.ValueObject.Id = 0;
      helper.ValueObject.Status = CMSConstants.ArticleStatus.Draft;
      helper.ValueObject.ArticleId = ArticleId;
      helper.ValueObject.Detail = Detail;
      helper.ValueObject.Email = Email;
      helper.ValueObject.History = string.Empty;
      helper.ValueObject.Name = Name;
      helper.ValueObject.Phone = Phone;
      helper.ValueObject.Subject = string.Empty;
      helper.ValueObject.PId = 0;
      helper.ValueObject.Created_At = DateTime.Now;
      helper.ValueObject.Created_By = 0;
      helper.ValueObject.Last_Modified_At = DateTime.Now;
      helper.ValueObject.Last_Modified_By = 0;
      helper.DoSave();

      ////Rebind
      //WebsitesHelper helper1 = new WebsitesHelper(new WebsitesObject());
      //helper1.ValueObject.ArticleId = ArticleId;
      //rptComment.DataSource = helper1.GetArticleComment();
      //rptComment.DataBind();

      lblError.Text = "Cám ơn bạn đã gửi ý kiến.";

      //invisible form comment
      pnlForm.Visible = false;
    }

    private void SetupEnvironment()
    {
      //Registe poll js
      if (!this.Page.ClientScript.IsClientScriptBlockRegistered("poll.js"))
      {
        this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "poll.js",
                                                         "<script src=\"" + this.Page.ResolveUrl("/js/poll.js") +
                                                         "\"></script>");
      }
    }
  }
}