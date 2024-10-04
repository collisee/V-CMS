using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Petro.Common;
using VietNamNet.Websites.Petro.Common.ValueObject;
using VietNamNet.Websites.Petro.Presentation;

namespace VietNamNet.Websites.Petro.UserControls
{
    public partial class PanelHotNews : UserControl
    {
        public string commentCounter = "0";

        [Description("Category Alias")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string CategoryAlias
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[PetroConstants.ViewState.CategoryAlias])
                        ? string.Empty
                        : ViewState[PetroConstants.ViewState.CategoryAlias].ToString();
            }
            set { ViewState[PetroConstants.ViewState.CategoryAlias] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSearchkeyword.Attributes["onkeydown"] = "onKeyPress(event, function(){search('" + btnSearch.ClientID +
                                         "')})";
                txtSearchkeyword.Text = Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.KEYWORD])
                                          ? string.Empty
                                          : Request.Params[Constants.ParameterName.KEYWORD].ToString();
                
                PetroHelper helper = new PetroHelper(new PetroObject());
                helper.ValueObject.CategoryAlias = CategoryAlias;
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
                    rptHotNews.DataSource = dtArticles;
                    rptHotNews.DataBind();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/vn/tim-kiem/index.html?keyword=" + txtSearchkeyword.Text.Trim());
        }
    }
}