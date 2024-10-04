/************************************************************************/
/* File Name  : WebsitesHelper                                          */
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
/* 27/09/2010 Sondn: coding convention                                  */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;

namespace VietNamNet.Websites.Core.Presentation
{
    public class WebsitesHelper
    {
        #region Members
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
        #endregion

        #region Categories

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

        #endregion

        #region Articles

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

        #region GetArticlesTopRead

        public DataTable GetArticlesTopRead()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetArticlesTopRead;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetArticlesTopComment

        public DataTable GetArticlesTopComment()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetArticlesTopComment;
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

        #region GetSearchArticles

        public DataTable GetSearchArticles()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetSearchArticles;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetArticleByStatus

        public DataTable GetArticleByStatus()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetArticleByStatus;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetArticleByStatusAndId

        public DataTable GetArticleByStatusAndId()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetArticleByStatusAndId;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetArticleByStatusAndCategoryId

        public DataTable GetArticleByStatusAndCategoryId()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetArticleByStatusAndCategoryId;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

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

        #region RSS
        public DataTable GetRSSHome()   
        {// Lấy top 30 bài mới nhất
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetRSSHome;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }
        public DataTable GetRSSByCategory()
        {// lấy top 10 bài mới nhất

            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.WebsitesManager.Actions.GetRSSByCategory;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }


        #endregion
    }
}