using System.Data;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.AddOn.Union.DBAccess;
using VietNamNet.Framework.Biz;

namespace VietNamNet.AddOn.Union.BizLogic
{
    /// <summary>
    /// Summary description for UnionManager.
    /// </summary>
    public class UnionManager : Facade
    {
        #region Override Execute

        public override Packet Execute(Packet param)
        {
            switch (param.Action)
            {
                case UnionConstants.Services.UnionManager.Actions.GetCategoryByAlias:
                    GetCategoryByAlias(param);
                    break;
                case UnionConstants.Services.UnionManager.Actions.GetCategoryArticleNumber:
                    GetCategoryArticleNumber(param);
                    break;
                case UnionConstants.Services.UnionManager.Actions.GetCategoryArticles:
                    GetCategoryArticles(param);
                    break;
                case UnionConstants.Services.UnionManager.Actions.GetCategoryArticlesMore:
                    GetCategoryArticlesMore(param);
                    break;
                case UnionConstants.Services.UnionManager.Actions.GetArticle:
                    GetArticle(param);
                    break;
                case UnionConstants.Services.UnionManager.Actions.GetArticleMedia:
                    GetArticleMedia(param);
                    break;
                case UnionConstants.Services.UnionManager.Actions.GetArticleComment:
                    GetArticleComment(param);
                    break;
                case UnionConstants.Services.UnionManager.Actions.GetTopMedia:
                    GetTopMedia(param);
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
            DataTable dt = UnionDAO.GetCategoryByAlias(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetCategoryArticleNumber

        private void GetCategoryArticleNumber(Packet param)
        {
            DataTable dt = UnionDAO.GetCategoryArticleNumber(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetCategoryArticles

        private void GetCategoryArticles(Packet param)
        {
            DataTable dt = UnionDAO.GetCategoryArticles(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetCategoryArticlesMore

        private void GetCategoryArticlesMore(Packet param)
        {
            DataTable dt = UnionDAO.GetCategoryArticlesMore(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticle

        private void GetArticle(Packet param)
        {
            DataTable dt = UnionDAO.GetArticle(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticleMedia

        private void GetArticleMedia(Packet param)
        {
            DataTable dt = UnionDAO.GetArticleMedia(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticleComment

        private void GetArticleComment(Packet param)
        {
            DataTable dt = UnionDAO.GetArticleComment(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetTopMedia

        private void GetTopMedia(Packet param)
        {
            DataTable dt = UnionDAO.GetTopMedia(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #endregion
    }
}