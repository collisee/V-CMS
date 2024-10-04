using System.Data;
using System.Diagnostics;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.DBAccess;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

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
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

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

            //Log timer
            timer.Stop();
            string strAction = string.Format("{0}::{1}::Timer", param.ServiceName, param.Action);
            string strTimer = string.Format("{0} ms", Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds));
            SystemLogging.Info(strAction, strTimer);

            //return
            return param;
        }

        #endregion

        #region Execute Actions

        #region Function DoSave

        private void DoSave(Packet param)
        {
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleComment.FieldName.Id]) == 0)
            {
                ArticleCommentDAO.Insert(param.RawData.Tables[0].Rows[0]);
            }
            else
            {
                ArticleCommentDAO.Update(param.RawData.Tables[0].Rows[0]);
            }

            //Log timer
            timer.Stop();
            SystemLogging.Info("ArticleCommentManager::DoSave::Timer", string.Format("{0} ms", Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds)));
        }

        #endregion

        #region Function DoDelete

        private void DoDelete(Packet param)
        {
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            ArticleCommentDAO.Delete(param.RawData.Tables[0].Rows[0]);

            //Log timer
            timer.Stop();
            SystemLogging.Info("ArticleCommentManager::DoDelete::Timer", string.Format("{0} ms", Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds)));
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            DataTable dt = ArticleCommentDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());

            //Log timer
            timer.Stop();
            SystemLogging.Info("ArticleCommentManager::DoLoad::Timer", string.Format("{0} ms", Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds)));
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            DataTable dt = ArticleCommentDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));

            //Log timer
            timer.Stop();
            SystemLogging.Info("ArticleCommentManager::DoLoadEncode::Timer", string.Format("{0} ms", Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds)));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            DataTable dt = ArticleCommentDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());

            //Log timer
            timer.Stop();
            SystemLogging.Info("ArticleCommentManager::ListAll::Timer", string.Format("{0} ms", Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds)));
        }

        #endregion

        #region Function ViewGetAllArticleComment

        private void ViewGetAllArticleComment(Packet param)
        {
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            param.RawData = ArticleCommentDAO.ViewGetAllArticleComment(param.RawData);

            //Log timer
            timer.Stop();
            SystemLogging.Info("ArticleCommentManager::ViewGetAllArticleComment::Timer", string.Format("{0} ms", Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds)));
        }

        #endregion

        #region Function ViewGetAllArticleCommentByStatus

        private void ViewGetAllArticleCommentByStatus(Packet param)
        {
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            param.RawData = ArticleCommentDAO.ViewGetAllArticleCommentByStatus(param.RawData);

            //Log timer
            timer.Stop();
            SystemLogging.Info("ArticleCommentManager::ViewGetAllArticleCommentByStatus::Timer", string.Format("{0} ms", Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds)));
        }

        #endregion

        #region Function ViewGetAllArticleCommentByArticleId

        private void ViewGetAllArticleCommentByArticleId(Packet param)
        {
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            param.RawData = ArticleCommentDAO.ViewGetAllArticleCommentByArticleId(param.RawData);

            //Log timer
            timer.Stop();
            SystemLogging.Info("ArticleCommentManager::ViewGetAllArticleCommentByArticleId::Timer", string.Format("{0} ms", Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds)));
        }

        #endregion

        #endregion
    }
}