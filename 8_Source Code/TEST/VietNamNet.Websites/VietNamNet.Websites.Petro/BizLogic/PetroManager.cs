using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Websites.Petro.Common;
using VietNamNet.Websites.Petro.DBAccess;

namespace VietNamNet.Websites.Petro.BizLogic
{
    /// <summary>
    /// Summary description for PetroManager.
    /// </summary>
    public class PetroManager : Facade
    {
        #region Override Execute

        public override Packet Execute(Packet param)
        {
            switch (param.Action)
            {
                case PetroConstants.Services.PetroManager.Actions.GetCategoryByAlias:
                    GetCategoryByAlias(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.GetCategoryArticleNumber:
                    GetCategoryArticleNumber(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.GetCategoryArticles:
                    GetCategoryArticles(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.GetCategoryArticlesMore:
                    GetCategoryArticlesMore(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.GetArticle:
                    GetArticle(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.GetArticleMedia:
                    GetArticleMedia(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.GetArticleComment:
                    GetArticleComment(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.GetPrimaryCategory:
                    GetPrimaryCategory(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.GetTopArticles:
                    GetTopArticles(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.GetMostReadArticles:
                    GetMostReadArticles(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.GetArticleVNNId:
                    GetArticleVNNId(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.GetTopMedia:
                    GetTopMedia(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.SetTotalView:
                    SetTotalView(param);
                    break;
                case PetroConstants.Services.PetroManager.Actions.GetSearchArticles:
                  GetSearchArticles(param);
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
            DataTable dt = PetroDAO.GetCategoryByAlias(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetCategoryArticleNumber

        private void GetCategoryArticleNumber(Packet param)
        {
            DataTable dt = PetroDAO.GetCategoryArticleNumber(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetCategoryArticles

        private void GetCategoryArticles(Packet param)
        {
            DataTable dt = PetroDAO.GetCategoryArticles(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetCategoryArticlesMore

        private void GetCategoryArticlesMore(Packet param)
        {
            DataTable dt = PetroDAO.GetCategoryArticlesMore(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticle

        private void GetArticle(Packet param)
        {
            DataTable dt = PetroDAO.GetArticle(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticleMedia

        private void GetArticleMedia(Packet param)
        {
            DataTable dt = PetroDAO.GetArticleMedia(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticleComment

        private void GetArticleComment(Packet param)
        {
            DataTable dt = PetroDAO.GetArticleComment(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetPrimaryCategory

        private void GetPrimaryCategory(Packet param)
        {
            DataTable dt = PetroDAO.GetPrimaryCategory(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function SetTotalView

        private void SetTotalView(Packet param)
        {
            PetroDAO.SetTotalView(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function GetTopArticles

        private void GetTopArticles(Packet param)
        {
            DataTable dt = PetroDAO.GetTopArticles(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetMostReadArticles

        private void GetMostReadArticles(Packet param)
        {
            DataTable dt = PetroDAO.GetMostReadArticles(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticleVNNId

        private void GetArticleVNNId(Packet param)
        {
            DataTable dt = PetroDAO.GetArticleVNNId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetTopMedia

        private void GetTopMedia(Packet param)
        {
            DataTable dt = PetroDAO.GetTopMedia(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

      #region Function GetSearchArticles

      private void GetSearchArticles(Packet param)
      {
        DataTable dt = PetroDAO.GetSearchArticles(param.RawData.Tables[0].Rows[0]);
        param.RawData.Tables.Clear();
        param.RawData.Tables.Add(dt.Copy());
      }

      #endregion

        #endregion
    }
}