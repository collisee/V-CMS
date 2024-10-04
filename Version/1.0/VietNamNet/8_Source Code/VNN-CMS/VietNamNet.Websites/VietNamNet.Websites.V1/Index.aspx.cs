using System;
using System.Web.UI;
using VietNamNet.Framework.Common.Cryptography;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("/vn/index.html");
            return;
            string[] cateAliases = new string[] { "xa-hoi", "giao-duc", "chinh-tri", "phong-su-dieu-tra", "kinh-te", "van-hoa", "khoa-hoc", "cong-nghe-thong-tin-vien-thong", "ban-doc-phap-luat" };
            int iCateId = RNG.Next(cateAliases.Length);
            int iArticleId = RNG.Next(1, 306);
            while (iArticleId == 20 || iArticleId == 25 || iArticleId == 73 || iArticleId == 140) iArticleId = RNG.Next(1, 306);

            int rnd = RNG.Next(10);
            if (rnd <= 3) //homepage
            {
                Response.Redirect("/vn/index.html");
            }
            else if (rnd <= 5) //category
            {
                string url = string.Format("/vn/{0}/index.html", cateAliases[iCateId]);
                Response.Redirect(url);
            }
            else //article
            {
                string url = string.Format("/vn/{0}/{1}/article.html", cateAliases[iCateId], iArticleId);
                Response.Redirect(url);
            }
        }
    }
}