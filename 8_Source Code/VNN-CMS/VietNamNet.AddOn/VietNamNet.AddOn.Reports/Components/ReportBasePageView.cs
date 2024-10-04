using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.CMS.Reports.Components
{
    public class ReportBasePageView : BasePageView
    {
        #region Members
        protected bool isSystem = false;
        protected string systemAlias = string.Empty;

        protected bool isStatistics = false;
        protected string statisticsAlias = string.Empty;

        #endregion

        protected override void PageLoad()
        {
            Initialize();
            base.PageLoad();
        }

        public virtual void Initialize()
        {
            moduleAlias = "VietNamNet.CMS.Article";
            statisticsAlias = "VietNamNet.CMS.Article.Statistic";
            systemAlias = "	VietNamNet.CMS.Article.System";
        }

        protected override void GetPolicy()
        {
            base.GetPolicy(); 
             
            isStatistics = SystemUtils.GetPolicy(UserId, moduleAlias, statisticsAlias);

            isSystem = SystemUtils.GetPolicy(UserId, moduleAlias, systemAlias);


            //test only
             
            isStatistics = true;
            isSystem = true;

        }

    }
}
