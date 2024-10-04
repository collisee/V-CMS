using System.Data;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.DBAccess;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;

namespace VietNamNet.CMS.BizLogic
{
    /// <summary>
    /// Summary description for ArticleCommentManager.
    /// </summary>
    public class ArticleCommentManager : Facade
    {
        #region Override Execute

        public override Packet Execute(Packet param)
        {
            switch (param.Action)
            {
                case CMSConstants.Services.CommonActions.SAVE:
                    DoSave(param);
                    break;
                case CMSConstants.Services.CommonActions.DELETE:
                    DoDelete(param);
                    break;
                case CMSConstants.Services.CommonActions.LOAD:
                    DoLoad(param);
                    break;
                case CMSConstants.Services.CommonActions.LOAD_ENCODE:
                    DoLoadEncode(param);
                    break;
                case CMSConstants.Services.CommonActions.LISTALL:
                    ListAll(param);
                    break;
                case CMSConstants.Services.ArticleCommentManager.Actions.ViewGetAllArticleComment:
                    ViewGetAllArticleComment(param);
                    break;
                case CMSConstants.Services.ArticleCommentManager.Actions.ViewGetAllArticleCommentByStatus:
                    ViewGetAllArticleCommentByStatus(param);
                    break;
                case CMSConstants.Services.ArticleCommentManager.Actions.ViewGetAllArticleCommentByArticleId:
                    ViewGetAllArticleCommentByArticleId(param);
                    break;
                default:
                    break;
            }
            return param;
        }

        #endregion

        #region Execute Actions

        #region Function DoSave

        private void DoSave(Packet param)
        {
            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleComment.FieldName.Id]) == 0)
            {
                ArticleCommentDAO.Insert(param.RawData.Tables[0].Rows[0]);
            }
            else
            {
                ArticleCommentDAO.Update(param.RawData.Tables[0].Rows[0]);
            }
        }

        #endregion

        #region Function DoDelete

        private void DoDelete(Packet param)
        {
            ArticleCommentDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = ArticleCommentDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = ArticleCommentDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = ArticleCommentDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllArticleComment

        private void ViewGetAllArticleComment(Packet param)
        {
            param.RawData = ArticleCommentDAO.ViewGetAllArticleComment(param.RawData);
        }

        #endregion

        #region Function ViewGetAllArticleCommentByStatus

        private void ViewGetAllArticleCommentByStatus(Packet param)
        {
            param.RawData = ArticleCommentDAO.ViewGetAllArticleCommentByStatus(param.RawData);
        }

        #endregion

        #region Function ViewGetAllArticleCommentByArticleId

        private void ViewGetAllArticleCommentByArticleId(Packet param)
        {
            param.RawData = ArticleCommentDAO.ViewGetAllArticleCommentByArticleId(param.RawData);
        }

        #endregion

        #endregion
    }
}