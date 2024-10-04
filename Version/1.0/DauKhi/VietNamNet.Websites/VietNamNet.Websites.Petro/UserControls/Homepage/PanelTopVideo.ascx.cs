using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Petro.Common;
using VietNamNet.Websites.Petro.Common.ValueObject;
using VietNamNet.Websites.Petro.Presentation;

namespace VietNamNet.Websites.Petro.UserControls.Homepage
{
    public partial class PanelTopVideo : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PetroHelper helper = new PetroHelper(new PetroObject());
                helper.ValueObject.CategoryAlias = hidCategoryAlias.Value;
                DataTable dt = helper.GetCategoryByAlias();

                if (dt != null && dt.Rows.Count > 0)
                {
                    int categoryId =
                        Utilities.ParseInt(dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.CategoryId]);
                    int partitionId =
                        Utilities.ParseInt(dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.PartitionId]);

                    //Get Article
                    PetroHelper helperArticles = new PetroHelper(new PetroObject());
                    helperArticles.ValueObject.PartitionId = partitionId;
                    helperArticles.ValueObject.CategoryId = categoryId;
                    helperArticles.ValueObject.FirstIndexRecord = 1;
                    helperArticles.ValueObject.LastIndexRecord = 3;
                    DataTable dtArticles = helperArticles.GetCategoryArticles();
                    rptCate.DataSource = dtArticles;
                    rptCate.DataBind();
                }
            }
        }
    }
}