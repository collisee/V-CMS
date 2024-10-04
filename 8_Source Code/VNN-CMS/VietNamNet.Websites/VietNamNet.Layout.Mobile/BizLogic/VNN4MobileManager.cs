using System;
using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Layout.Mobile.Common;
using VietNamNet.Layout.Mobile.DBAccess;

namespace VietNamNet.Layout.Mobile.BizLogic
{
    /// <summary>
    /// Summary description for VNN4MobileManager.
    /// </summary>
    public class VNN4MobileManager : Facade
    {
        #region Override Execute

        public override Packet Execute(Packet param)
        {
            switch (param.Action)
            {
                case VNN4MobileConstants.Services.VNN4MobileManager.Actions.GetCategoryByAlias:
                    GetCategoryByAlias(param);
                    break;
                case VNN4MobileConstants.Services.VNN4MobileManager.Actions.GetCategoryArticleNumber:
                    GetCategoryArticleNumber(param);
                    break;
                case VNN4MobileConstants.Services.VNN4MobileManager.Actions.GetCategoryArticles:
                    GetCategoryArticles(param);
                    break;
                case VNN4MobileConstants.Services.VNN4MobileManager.Actions.GetCategoryArticlesMore:
                    GetCategoryArticlesMore(param);
                    break;
                case VNN4MobileConstants.Services.VNN4MobileManager.Actions.GetArticle:
                    GetArticle(param);
                    break;
                case VNN4MobileConstants.Services.VNN4MobileManager.Actions.GetTopArticle:
                    GetTopArticle(param);
                    break;
                default:
                    break;
            }
            return param;
        }

        #endregion

        #region Execute Actions

        #region Function GetCategoryByAlias

        private void GetCategoryByAlias(Packet param)
        {
            DataTable dt = VNN4MobileDAO.GetCategoryByAlias(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetCategoryArticleNumber

        private void GetCategoryArticleNumber(Packet param)
        {
            DataTable dt = VNN4MobileDAO.GetCategoryArticleNumber(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetCategoryArticles

        private void GetCategoryArticles(Packet param)
        {
            DataTable dt = VNN4MobileDAO.GetCategoryArticles(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetCategoryArticlesMore

        private void GetCategoryArticlesMore(Packet param)
        {
            DataTable dt = VNN4MobileDAO.GetCategoryArticlesMore(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticle

        private void GetArticle(Packet param)
        {
            DataTable dt = VNN4MobileDAO.GetArticle(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetTopArticle

        private void GetTopArticle(Packet param)
        {
            DataTable dt = VNN4MobileDAO.GetTopArticle(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #endregion
    }
}