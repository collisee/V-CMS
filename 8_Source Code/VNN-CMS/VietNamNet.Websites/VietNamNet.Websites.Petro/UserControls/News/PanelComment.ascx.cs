using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Petro.Common;
using VietNamNet.Websites.Petro.Common.ValueObject;
using VietNamNet.Websites.Petro.Presentation;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;

namespace VietNamNet.Websites.Petro.UserControls.News
{
  public partial class PanelComment : UserControl
  {
    [Description("ArticleId")]
    [Browsable(true)]
    [DefaultSettingValue("0")]
    public int ArticleId
    {
      get { return Utilities.ParseInt(ViewState[PetroConstants.ViewState.ArticleId]); }
      set { ViewState[PetroConstants.ViewState.ArticleId] = value; }
    }

    [Description("Page")]
    [Browsable(true)]
    [DefaultSettingValue("1")]
    public int PageNumber
    {
      get { return Utilities.ParseInt(ViewState[PetroConstants.ViewState.PageNumber]); }
      set { ViewState[PetroConstants.ViewState.PageNumber] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      lblError.Visible = false;
      
      if (!IsPostBack)
      {
        //Get PageNumber
        int pageSize = Utilities.GetPageSize();
        if (PageNumber <= 0) PageNumber = 1;

        if (PageNumber <= 1) hplPrev.Visible = false;
        hplPrev.NavigateUrl = string.Format("/vn/{0}/page/index.html", PageNumber - 1);
        hplNext.NavigateUrl = string.Format("/vn/{0}/page/index.html", PageNumber + 1);
        //hplPrev.NavigateUrl = string.Format("/vn/{0}/page/{1}/index.html", CategoryAlias, PageNumber - 1);
        //hplNext.NavigateUrl = string.Format("/vn/{0}/page/{1}/index.html", CategoryAlias, PageNumber + 1);

        PetroHelper helper = new PetroHelper(new PetroObject());
        helper.ValueObject.ArticleId = ArticleId;
        helper.ValueObject.FirstIndexRecord = (PageNumber - 1) * pageSize + 1;
        helper.ValueObject.LastIndexRecord = (PageNumber - 1) * pageSize + 1;

        DataTable dt = helper.GetArticleComment();
        if (dt != null && dt.Rows.Count > 0)
        {
          rptComment.DataSource = dt;
          rptComment.DataBind();
        }
        else
        {
          pnlList.Visible = false;
        }
      }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (Nulls.IsNullOrEmpty(txtName.Text.Trim()) || Nulls.IsNullOrEmpty(txtComment.Text.Trim()))
      {
        lblError.Visible = true;
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

      //Rebind
      PetroHelper helper1 = new PetroHelper(new PetroObject());
      helper1.ValueObject.ArticleId = ArticleId;
      rptComment.DataSource = helper1.GetArticleComment();
      rptComment.DataBind();

      //invisible form comment
      pnlForm.Visible = false;

      //clear text
      //txtName.Text = string.Empty;
      //txtAddress.Text = string.Empty;
      //txtEmail.Text = string.Empty;
      //txtPhone.Text = string.Empty;
      //txtComment.Text = string.Empty;

      //show comment
      //pnlList.Visible = true;
    }
  }
}