/************************************************************************/
/* File Name  : WebsitesManager                                         */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.Websites.Core                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Khai bao truy xuat DAO Manager                         */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 27/09/2010 Sondn: coding convention & RSS functions                  */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using System.Data;
using System.Diagnostics;
using log4net;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.DBAccess;

namespace VietNamNet.Websites.Core.BizLogic
{
    /// <summary>
    /// Summary description for WebsitesManager.
    /// </summary>
    public class WebsitesManager : Facade
    {

        #region Override Execute
        private readonly ILog iLog = LogManager.GetLogger(WebsitesConstants.Services.WebsitesManager.Name);

        public override Packet Execute(Packet param)
        {
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            switch (param.Action)
            {
                case WebsitesConstants.Services.WebsitesManager.Actions.GetCategoryByAlias:
                    GetCategoryByAlias(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetSubCategory:
                    GetSubCategory(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetCategoryArticleNumber:
                    GetCategoryArticleNumber(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetCategoryArticles:
                    GetCategoryArticles(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetCategoryArticlesMore:
                    GetCategoryArticlesMore(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetArticle:
                    GetArticle(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetArticleMedia:
                    GetArticleMedia(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetArticleComment:
                    GetArticleComment(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetPrimaryCategory:
                    GetPrimaryCategory(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetTopArticles:
                    GetTopArticles(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetMostReadArticles:
                    GetMostReadArticles(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetArticleVNNId:
                    GetArticleVNNId(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetTopMedia:
                    GetTopMedia(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetSearchArticles:
                    GetSearchArticles(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.SearchArticleByKeyword:
                    SearchArticleByKeyword(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetArticleByStatus:
                    GetArticleByStatus(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetArticleByStatusAndId:
                    GetArticleByStatusAndId(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetArticleByStatusAndCategoryId:
                    GetArticleByStatusAndCategoryId(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetRSSHome:
                    GetRSSHome(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetRSSByCategory:
                    GetRSSByCategory(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetArticlesTopRead:
                    GetArticlesTopRead(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetArticlesTopComment:
                    GetArticlesTopComment(param);
                    break;
                default:
                    break;
            }
 
            //Log timer
            timer.Stop();

            string msg = string.Format("ServiceName::{0};Action::{1};Timer::{2} ms", 
                param.ServiceName, 
                param.Action,
                Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds));
            iLog.Info(msg); 

            return param;
        }

        #endregion

        #region Execute Actions

        #region Categories

        #region Function GetCategoryByAlias

        private void GetCategoryByAlias(Packet param)
        {
            DataTable dt = WebsitesDAO.GetCategoryByAlias(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetSubCategory

        private void GetSubCategory(Packet param)
        {
            DataTable dt = WebsitesDAO.GetSubCategory(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #endregion

        #region Articles

        #region Function GetCategoryArticleNumber

        private void GetCategoryArticleNumber(Packet param)
        {
            DataTable dt = WebsitesDAO.GetCategoryArticleNumber(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetCategoryArticles

        private void GetCategoryArticles(Packet param)
        {
            DataTable dt = WebsitesDAO.GetCategoryArticles(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetCategoryArticlesMore

        private void GetCategoryArticlesMore(Packet param)
        {
            DataTable dt = WebsitesDAO.GetCategoryArticlesMore(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticle

        private void GetArticle(Packet param)
        {
            DataTable dt = WebsitesDAO.GetArticle(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticleMedia

        private void GetArticleMedia(Packet param)
        {
            DataTable dt = WebsitesDAO.GetArticleMedia(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticleComment

        private void GetArticleComment(Packet param)
        {
            DataTable dt = WebsitesDAO.GetArticleComment(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetPrimaryCategory

        private void GetPrimaryCategory(Packet param)
        {
            DataTable dt = WebsitesDAO.GetPrimaryCategory(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetTopArticles

        private void GetTopArticles(Packet param)
        {
            DataTable dt = WebsitesDAO.GetTopArticles(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetMostReadArticles

        private void GetMostReadArticles(Packet param)
        {
            DataTable dt = WebsitesDAO.GetMostReadArticles(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticlesTopRead

        private void GetArticlesTopRead(Packet param)
        {
            DataTable dt = WebsitesDAO.GetArticlesTopRead(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticlesTopComment

        private void GetArticlesTopComment(Packet param)
        {
            DataTable dt = WebsitesDAO.GetArticlesTopComment(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticleVNNId

        private void GetArticleVNNId(Packet param)
        {
            DataTable dt = WebsitesDAO.GetArticleVNNId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetTopMedia

        private void GetTopMedia(Packet param)
        {
            DataTable dt = WebsitesDAO.GetTopMedia(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetSearchArticles

        private void GetSearchArticles(Packet param)
        {
            DataTable dt = WebsitesDAO.GetSearchArticles(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function SearchArticleByKeyword

        private void SearchArticleByKeyword(Packet param)
        {
            DataTable dt = WebsitesDAO.Search(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticleByStatus

        private void GetArticleByStatus(Packet param)
        {
            DataTable dt = WebsitesDAO.GetArticleByStatus(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticleByStatusAndId

        private void GetArticleByStatusAndId(Packet param)
        {
            DataTable dt = WebsitesDAO.GetArticleByStatusAndId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticleByStatusAndCategoryId

        private void GetArticleByStatusAndCategoryId(Packet param)
        {
            DataTable dt = WebsitesDAO.GetArticleByStatusAndCategoryId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #endregion

        #region Search

        #endregion

        #region RSS

        private void GetRSSHome(Packet param)
        {
            DataTable dt = WebsitesDAO.GetRSSHome(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        private void GetRSSByCategory(Packet param)
        {
            DataTable dt = WebsitesDAO.GetRSSByCategory(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #endregion
    }
}