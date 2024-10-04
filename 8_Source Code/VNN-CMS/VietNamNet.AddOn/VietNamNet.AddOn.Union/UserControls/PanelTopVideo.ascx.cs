using System;
using System.Data;
using System.Web.UI;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.AddOn.Union.Common.ValueObject;
using VietNamNet.AddOn.Union.Presentation;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Union.UserControls
{
    public partial class PanelTopVideo : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnionHelper helper = new UnionHelper(new UnionObject());
                helper.ValueObject.CategoryAlias = hidCategoryAlias.Value;
                DataTable dt = helper.GetCategoryByAlias();

                if (dt != null && dt.Rows.Count > 0)
                {
                    int categoryId =
                        Utilities.ParseInt(dt.Rows[0][UnionConstants.Entity.UnionObject.FieldName.CategoryId]);
                    int partitionId =
                        Utilities.ParseInt(dt.Rows[0][UnionConstants.Entity.UnionObject.FieldName.PartitionId]);

                    //Get Article
                    UnionHelper helperArticles = new UnionHelper(new UnionObject());
                    helperArticles.ValueObject.PartitionId = partitionId;
                    helperArticles.ValueObject.CategoryId = categoryId;
                    helperArticles.ValueObject.FirstIndexRecord = 1;
                    helperArticles.ValueObject.LastIndexRecord = 3;
                    DataTable dtArticles = helperArticles.GetCategoryArticles();
                    rptMore.DataSource = dtArticles;
                    rptMore.DataBind();
                }
            }
        }
    }
}