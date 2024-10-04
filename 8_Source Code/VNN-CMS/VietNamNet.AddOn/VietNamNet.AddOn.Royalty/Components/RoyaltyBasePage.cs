using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Royalty.Components
{
    public class RoyaltyBasePage : BasePage
    {
        #region Members
        protected bool isSystem = false;
        protected string systemAlias = string.Empty;

        protected bool isTypesManager = false;
        protected string typesAlias = string.Empty;

        protected bool isFundManager = false;
        protected string fundAlias = string.Empty;

        protected bool isStatistics = false;
        protected string statisticsAlias = string.Empty;

        #endregion

        protected override void PageLoad()
        {
            Initialize();
             base.PageLoad();
        }

        public void Initialize()
        {
            moduleAlias = "VietNamNet.AddOn.Royalty"; 
            typesAlias = "VietNamNet.AddOn.Royalty.Types";
            fundAlias = "VietNamNet.AddOn.Royalty.Fund";
            statisticsAlias = "VietNamNet.AddOn.Royalty.Statistics";

            systemAlias = "VietNamNet.AddOn.Royalty.System";
        }

        protected override void GetPolicy()
        {
            base.GetPolicy();

            isTypesManager = SystemUtils.GetPolicy(UserId, moduleAlias, typesAlias);
            isFundManager = SystemUtils.GetPolicy(UserId, moduleAlias, fundAlias);
            isStatistics = SystemUtils.GetPolicy(UserId, moduleAlias, statisticsAlias);

            isSystem = SystemUtils.GetPolicy(UserId, moduleAlias, systemAlias);



            //test only
            isTypesManager = true;
            isFundManager = true;
            isStatistics = true;
            isSystem = true; 

        }

    }
}
