using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Sports.Mobile
{
    public partial class NewsVNN : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int docId = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.DOC_ID]);

                //Article
                if (docId > 0)
                {
                    WebsitesHelper articleHelper = new WebsitesHelper(new WebsitesObject());
                    articleHelper.ValueObject.ArticleId = docId;
                    DataTable dtArticle = articleHelper.GetArticleVNNId();

                    if (dtArticle != null && dtArticle.Rows.Count == 1)
                    {
                        string url = Utilities.GetArticleUrl(
                                dtArticle.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.Url]
                                , dtArticle.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.Id]
                                , dtArticle.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.Name]);

                        Response.Redirect(url);
                    }
                    else
                    {
                        Response.Redirect(WebsitesUtils.GetHomepage());
                    }
                }
                else
                {
                    Response.Redirect(WebsitesUtils.GetHomepage());
                }
            }
        }
    }
}