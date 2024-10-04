using System;
using System.Data;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Presentation;
using VietNamNet.Websites.Core.Common.ValueObject;

namespace VietNamNet.Websites.Sport.UserControls.Categories
{
  public partial class PanelMostRead : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
      //helper.ValueObject.CategoryAlias = "the-thao";
      //DataTable dt = helper.GetCategoryByAlias();

      //if (dt != null && dt.Rows.Count > 0)
      //{
      //  int categoryId = Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
      //  int partitionId = Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

      //  //Get Article
      //  WebsitesHelper helperArticles2 = new WebsitesHelper(new WebsitesObject());
      //  helperArticles2.ValueObject.PartitionId = partitionId;
      //  helperArticles2.ValueObject.CategoryId = categoryId;
      //  helperArticles2.ValueObject.FirstIndexRecord = 1;
      //  helperArticles2.ValueObject.LastIndexRecord = 10;
      //  DataTable dtArticles2 = helperArticles2.GetCategoryArticles();
      //  rptMostRead.DataSource = dtArticles2;
      //  rptMostRead.DataBind();

      //  //Get Article
      //  WebsitesHelper helperArticles = new WebsitesHelper(new WebsitesObject());
      //  helperArticles.ValueObject.PartitionId = partitionId;
      //  helperArticles.ValueObject.CategoryId = categoryId;
      //  helperArticles.ValueObject.FirstIndexRecord = 1;
      //  helperArticles.ValueObject.LastIndexRecord = 10;
      //  DataTable dtArticles = helperArticles.GetCategoryArticles();
      //  rptMostFb.DataSource = dtArticles;
      //  rptMostFb.DataBind();
      //}

      rptMostRead.DataSource = WebsitesUtils.GetArtilesTopRead();
      rptMostRead.DataBind();
      rptMostFb.DataSource = WebsitesUtils.GetArtilesTopComment();
      rptMostFb.DataBind();
    }
  }
}