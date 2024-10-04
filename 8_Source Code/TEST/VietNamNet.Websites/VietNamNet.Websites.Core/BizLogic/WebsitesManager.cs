using System.Data;
using VietNamNet.Framework.Biz;
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

        public override Packet Execute(Packet param)
        {
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
                case WebsitesConstants.Services.WebsitesManager.Actions.SetTotalView:
                    SetTotalView(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.GetSearchArticles:
                  GetSearchArticles(param);
                    break;
                case WebsitesConstants.Services.WebsitesManager.Actions.SearchArticleByKeyword:
                    SearchArticleByKeyword(param);
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

        #region Function SetTotalView

        private void SetTotalView(Packet param)
        {
            WebsitesDAO.SetTotalView(param.RawData.Tables[0].Rows[0]);
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

        #endregion
    }
}