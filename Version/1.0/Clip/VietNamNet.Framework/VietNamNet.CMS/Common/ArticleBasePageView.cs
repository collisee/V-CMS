using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Common
{
    public class ArticleBasePageView : BasePageView
    {
        #region Member

        protected string editAlias = string.Empty;
        protected string correctAlias = string.Empty;
        protected string publishAlias = string.Empty;
        protected string categoryAlias = string.Empty;
        protected string systemAlias = string.Empty;
        protected string statisticAlias = string.Empty;

        protected bool isEdit = false;
        protected bool isCorrect = false;
        protected bool isPublish = false;
        protected bool isCategory = false;
        protected bool isSystem = false;
        protected bool isStatistic = false;

        #endregion

        #region Override Method

        protected override void GetPolicy()
        {
            base.GetPolicy();

            isEdit = SystemUtils.GetPolicy(UserId, moduleAlias, editAlias);
            isCorrect = SystemUtils.GetPolicy(UserId, moduleAlias, correctAlias);
            isPublish = SystemUtils.GetPolicy(UserId, moduleAlias, publishAlias);
            isCategory = SystemUtils.GetPolicy(UserId, moduleAlias, categoryAlias);
            isSystem = SystemUtils.GetPolicy(UserId, moduleAlias, systemAlias);
            isStatistic = SystemUtils.GetPolicy(UserId, moduleAlias, statisticAlias);
        }

        #endregion

        #region Protected Method

        protected virtual void Initialize()
        {
            moduleAlias = "VietNamNet.CMS.Article";
            viewAlias = "VietNamNet.CMS.Article.View";
            addNewAlias = "VietNamNet.CMS.Article.AddNew";
            updateAlias = "VietNamNet.CMS.Article.Update";
            deleteAlias = "VietNamNet.CMS.Article.Delete";
            editAlias = "VietNamNet.CMS.Article.Edit";
            correctAlias = "VietNamNet.CMS.Article.Correct";
            publishAlias = "VietNamNet.CMS.Article.Publish";
            categoryAlias = "VietNamNet.CMS.Article.Category";
            systemAlias = "VietNamNet.CMS.Article.System";
            statisticAlias = "VietNamNet.CMS.Article.Statistic";
            ServiceName = CMSConstants.Services.ArticleManager.Name;
            //ActionName = CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticle;
        }

        #endregion

    }
}