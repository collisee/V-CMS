using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Petro.Common;
using VietNamNet.Websites.Petro.Common.ValueObject;
using VietNamNet.Websites.Petro.Presentation;

namespace VietNamNet.Websites.Petro
{
    public partial class VNNNewsDetail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int docId = Utilities.ParseInt(Request.Params[PetroConstants.ParameterName.DOC_ID]);

                //Article
                if (docId > 0)
                {
                    PetroHelper articleHelper = new PetroHelper(new PetroObject());
                    articleHelper.ValueObject.ArticleId = docId;
                    DataTable dt = articleHelper.GetArticleVNNId();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //redirect
                        Response.Redirect(
                            string.Format("/vn/tin-top/{0}/{1}.html",
                                          dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.Id],
                                          PetroUtils.BuildLink(
                                              dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.Name].ToString())));
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