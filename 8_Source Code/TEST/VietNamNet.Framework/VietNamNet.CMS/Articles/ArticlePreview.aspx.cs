using System;
using System.Web;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Articles
{
    public partial class ArticlePreview : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                //Load Data
                int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
                if (docId > 0) //update
                {
                    ArticleHelper helper = new ArticleHelper(new Article());
                    helper.ValueObject.Id = docId;
                    helper.LoadSimple();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    BindData(helper.ValueObject);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = helper.ValueObject.Id;
                }
                else
                {
                    Utilities.ItemDoesntExist();
                }
            }
        }

        private void Initialize()
        {
        }

        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }

        private void BindData(Article o)
        {
            lblName.Text = HttpUtility.HtmlEncode(o.Name);
            lblPublishDate.Text = Utilities.FormatDisplayDateTime(o.PublishDate);
            lblDetail.Text = o.Detail;
        }
    }
}