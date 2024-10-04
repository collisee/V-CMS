using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.AddOn.Union.Common.ValueObject;
using VietNamNet.AddOn.Union.Presentation;

namespace VietNamNet.AddOn.Union.UserControls.News
{
  public partial class PanelNewsDetail : UserControl
  {
    [Description("ArticleId")]
    [Browsable(true)]
    [DefaultSettingValue("0")]
    public int ArticleId
    {
      get { return Utilities.ParseInt(ViewState[UnionConstants.ViewState.ArticleId]); }
      set { ViewState[UnionConstants.ViewState.ArticleId] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        UnionHelper helper = new UnionHelper(new UnionObject());
        helper.ValueObject.ArticleId = ArticleId;
        DataTable dtArticle = helper.GetArticle();
        if (dtArticle != null && dtArticle.Rows.Count > 0)
        {
            rptNewsDetail.DataSource = dtArticle;
            rptNewsDetail.DataBind();

            int aticleContentType =
                Utilities.ParseInt(
                    dtArticle.Rows[0][UnionConstants.Entity.UnionObject.FieldName.ArticleContentTypeId]);
            //Photo
            if (aticleContentType == 2)
            {
                PanelNewsPhoto1.ArticleId = ArticleId;
            }
            else
            {
                PanelNewsPhoto1.Visible = false;
            }

            //Video
            if (aticleContentType == 3)
            {
                PanelNewsVideo1.ArticleId = ArticleId;
            }
            else
            {
                PanelNewsVideo1.Visible = false;
            }

            //Update TotalView
            //UnionHelper updateHelper = new UnionHelper(new UnionObject());
            //updateHelper.ValueObject.ArticleId = ArticleId;
            //updateHelper.SetTotalView();
        }
    }
    }
  }
}