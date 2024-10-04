using System.ComponentModel;
using System.Data;
using System.Web.Services;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Services
{
    /// <summary>
    /// Summary description for ArticleServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class ArticleServices : WebService
    {
        [WebMethod]
        public string GetTopHotArticles(int number)
        {
            string strArticles = string.Empty;

            WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
            helper.ValueObject.CategoryAlias = "moi-nong";
            DataTable dt = helper.GetCategoryByAlias();

            if (dt != null && dt.Rows.Count > 0)
            {
                int categoryId =
                    Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
                int partitionId =
                    Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

                //Get Article
                WebsitesHelper helperArticles = new WebsitesHelper(new WebsitesObject());
                helperArticles.ValueObject.PartitionId = partitionId;
                helperArticles.ValueObject.CategoryId = categoryId;
                helperArticles.ValueObject.FirstIndexRecord = 1;
                helperArticles.ValueObject.LastIndexRecord = number;
                DataTable dtArticles = helperArticles.GetCategoryArticles();

                if (dtArticles != null && dtArticles.Rows.Count > 0)
                {
                    for (int i = 0; i < dtArticles.Rows.Count; i++)
                    {
                        DataRow row = dtArticles.Rows[i];
                        string strArticle =
                            string.Format("{0}. {1}\r\n", i + 1,
                                          Utilities.RemoveVietNamChar(
                                              row[WebsitesConstants.Entity.WebsitesObject.FieldName.Name].ToString()));
                        //if (strArticles.Length + strArticle.Length > 134)
                        //{
                        //    break;
                        //}

                        strArticles += strArticle;
                    }
                }
            }

            return strArticles;
        }
    }
}