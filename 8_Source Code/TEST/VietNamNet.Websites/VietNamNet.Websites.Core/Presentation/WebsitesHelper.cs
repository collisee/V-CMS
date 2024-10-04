using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;

namespace VietNamNet.Websites.Core.Presentation
{
    public class WebsitesHelper
    {
        private WebsitesObject o;

        #region WebsitesHelper(WebsitesObject o)

        public WebsitesHelper(WebsitesObject o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public WebsitesObject ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = WebsitesConstants.Services.WebsitesManager.Name;
            return p;
        }

        #endregion

        #region GetCategoryByAlias

        public DataTable GetCategoryByAlias()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetCategoryByAlias;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

      #region GetSubCategory

      public DataTable GetSubCategory()
      {
        Packet p = GetPacket();
        p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetSubCategory;
        ServiceFacade.Execute(p);
        return p.RawData.Tables[0];
      }

      #endregion

        #region GetCategoryArticleNumber

        public DataTable GetCategoryArticleNumber()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetCategoryArticleNumber;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetCategoryArticles

        public DataTable GetCategoryArticles()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetCategoryArticles;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetTopArticles

        public DataTable GetTopArticles()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetTopArticles;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetMostReadArticles

        public DataTable GetMostReadArticles()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetMostReadArticles;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetPrimaryCategory

        public DataTable GetPrimaryCategory()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetPrimaryCategory;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetCategoryArticlesMore

        public DataTable GetCategoryArticlesMore()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetCategoryArticlesMore;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetArticle

        public DataTable GetArticle()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetArticle;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetArticleVNNId

        public DataTable GetArticleVNNId()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetArticleVNNId;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetArticleMedia

        public DataTable GetArticleMedia()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetArticleMedia;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetTopMedia

        public DataTable GetTopMedia()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetTopMedia;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetArticleComment

        public DataTable GetArticleComment()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetArticleComment;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region SetTotalView

        public void SetTotalView()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.SetTotalView;
            ServiceFacade.Execute(p);
        }

        #endregion

      #region GetSearchArticles

      public DataTable GetSearchArticles()
      {
        Packet p = GetPacket();
        p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetSearchArticles;
        ServiceFacade.Execute(p);
        return p.RawData.Tables[0];
      }

      #endregion

        #region Search

        public DataTable Search()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.SearchArticleByKeyword;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

    }
}