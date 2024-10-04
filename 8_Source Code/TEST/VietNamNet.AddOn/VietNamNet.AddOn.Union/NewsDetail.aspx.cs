using System;
using System.Data;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.AddOn.Union.Common.ValueObject;
using VietNamNet.AddOn.Union.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Websites.V1.UserControls.News;

namespace VietNamNet.AddOn.Union
{
    public partial class NewsDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();
            if (!isLogged)
            {
                Response.Redirect("~/");
            }

            if (!IsPostBack)
            {
                string categoryAlias = Request.Params[UnionConstants.ParameterName.CATEGORY_ALIAS];
                int docId = Utilities.ParseInt(Request.Params[UnionConstants.ParameterName.DOC_ID]);

                UnionHelper helper = new UnionHelper(new UnionObject());
                helper.ValueObject.CategoryAlias = categoryAlias;
                DataTable dt = helper.GetCategoryByAlias();
                if (dt != null && dt.Rows.Count == 1)
                {
                    hplCate.Text =
                        dt.Rows[0][UnionConstants.Entity.UnionObject.FieldName.CategoryDisplayName].ToString();
                    hplCate.NavigateUrl = string.Format("/vn/{0}/index.html", categoryAlias);
                }

                PanelNewsDetail1.ArticleId = docId;
 
                PanelContentPoll1.ArticleId = docId;
                 PanelContentPoll1.CategoryAlias = categoryAlias;

                PanelNewsComment1.ArticleId = docId;

                PanelNewsMore1.CategoryAlias = categoryAlias;
                PanelNewsMore1.ArticleId = docId;
            }
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.AddOn.Union";
            viewAlias = "VietNamNet.AddOn.Union.View";
            addNewAlias = "VietNamNet.AddOn.Union.AddNew";
            updateAlias = "VietNamNet.AddOn.Union.Update";
            deleteAlias = "VietNamNet.AddOn.Union.Delete";
        }

        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }
    }
}