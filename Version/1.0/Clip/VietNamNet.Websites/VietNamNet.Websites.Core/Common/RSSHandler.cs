/************************************************************************/
/* File Name  : RSSHandler.cs                                           */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.Websites.Core                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Khai báo const của các Tracker                         */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 24/09/2010 Sondn File Create                                         */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/

using System.Data;
using System.Web;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common.RSS;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Core.Common
{
    public class RSSHandler : IHttpHandler
    {
        #region Implement Method

        public void ProcessRequest(HttpContext context)
        {
            //Set Output XML
            context.Response.ContentType = "text/xml";

            string[] arrSegments = context.Request.Url.Segments;

            //Segments: /, rss/, cate.rss
            if (arrSegments.Length == 3)
            {
                string strCategoryAlias = arrSegments[2].Substring(0, arrSegments[2].LastIndexOf('.'));

                if (Nulls.IsNullOrEmpty(strCategoryAlias)) return;

                DataTable source = null;

                if (Utilities.StringCompare(strCategoryAlias, "home") || Utilities.StringCompare(strCategoryAlias, "trang-chu"))
                {
                    WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                    source = helper.GetRSSHome();
                }
                else
                {
                    //WebsiteHelper 
                    WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                    helper.ValueObject.CategoryAlias = strCategoryAlias;
                    source = helper.GetRSSByCategory();
                }

                if (source != null)
                {

                    //TODO: RSS Generator
                    string strTitle = Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteTitle);
                    string strLink = Utilities.StringCompare(strCategoryAlias, "home")
                                         ? Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) + "en/index.html"
                                         : Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) + "en/" +
                                           strCategoryAlias + "/index.html";
                    string strDesc = Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteDesc);
                    string strCopy = Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteCopy);

                    string tempLink = Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink);
                    // 0:URL; 1:id; 2:Name; 
                    foreach (DataRow r in source.Rows)
                    {
                        //r["Link"] = string.Format(tempLink, r["Link"], r["Id"], WebsitesUtils.BuildLink(r["Title"].ToString()));
                        r["Link"] = tempLink + Utilities.GetArticleUrl(r["Link"], r["Id"], r["Title"]);
                    }



                    string strRSS = Generator.FromDataTable(source, strTitle, strLink, strDesc, strCopy);

                    context.Response.Write(strRSS);
                    context.Response.Flush();
                }
            }
        }

        public bool IsReusable
        {
            get { return true; }
        }

        #endregion

        #region Private Method

        #endregion
    }
}