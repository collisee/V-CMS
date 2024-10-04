using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.WebSites.Clip
{
    public partial class VNNNewsDetail : Page
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
                    DataTable dt = articleHelper.GetArticleVNNId();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //redirect
                        Response.Redirect(
                            string.Format("/vn/{0}/{1}/{2}.html",
                                          dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.Url],
                                          dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.Id],
                                          WebsitesUtils.BuildLink(
                                              dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.Name].
                                                  ToString())));
                    }
                    else
                    {
                        Response.Redirect("/vn/index.html");
                    }
                }
                else
                {
                    Response.Redirect("/vn/index.html");
                }
            }
            else
            {
                Response.Redirect("/vn/index.html");
            }
        }
    }
}