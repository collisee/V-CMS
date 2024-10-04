using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web.Services;
using VietNamNet.CMS.Common;
using VietNamNet.Framework.Biz;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Services
{
    /// <summary>
    /// Summary description for NewsServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class NewsServices : WebService
    {
        [WebMethod]
        public ArrayList GetTopCrawlingNews(int number)
        {
            WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
            helper.ValueObject.Status = CMSConstants.ArticleStatus.Crawling;
            helper.ValueObject.FirstIndexRecord = 1;
            helper.ValueObject.LastIndexRecord = number;
            DataTable dt = helper.GetArticleByStatus();

            Packet p = new Packet();
            p.RawData.Tables.Clear();
            p.RawData.Tables.Add(dt.Copy());
            object news = PacketUtils.TranslateTo(p, typeof(NewsL));

            if (news != null)
            {
                if (news.GetType().Equals(typeof (NewsL)))
                {
                    ArrayList x = new ArrayList();
                    x.Add(news);
                    return x;
                }
                else if (news.GetType().Equals(typeof (ArrayList)))
                {
                    return (ArrayList) news;
                }
            }

            return new ArrayList();
        }

        [WebMethod]
        public ArrayList GetTopCateCrawlingNews(int number, int cateid)
        {
            WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
            helper.ValueObject.Status = CMSConstants.ArticleStatus.Crawling;
            helper.ValueObject.CategoryId = cateid;
            helper.ValueObject.FirstIndexRecord = 1;
            helper.ValueObject.LastIndexRecord = number;
            DataTable dt = helper.GetArticleByStatusAndCategoryId();

            Packet p = new Packet();
            p.RawData.Tables.Clear();
            p.RawData.Tables.Add(dt.Copy());
            object news = PacketUtils.TranslateTo(p, typeof(NewsL));

            if (news != null)
            {
                if (news.GetType().Equals(typeof (NewsL)))
                {
                    ArrayList x = new ArrayList();
                    x.Add(news);
                    return x;
                }
                else if (news.GetType().Equals(typeof (ArrayList)))
                {
                    return (ArrayList) news;
                }
            }

            return new ArrayList();
        }

        [WebMethod]
        public NewsR GetCrawlingNews(int id)
        {
            WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
            helper.ValueObject.Status = CMSConstants.ArticleStatus.Crawling;
            helper.ValueObject.ArticleId = id;
            DataTable dt = helper.GetArticleByStatusAndId();

            Packet p = new Packet();
            p.RawData.Tables.Clear();
            p.RawData.Tables.Add(dt.Copy());
            NewsR news = PacketUtils.TranslateTo(p, typeof(NewsR)) as NewsR;
            return news;
        }
    }
}