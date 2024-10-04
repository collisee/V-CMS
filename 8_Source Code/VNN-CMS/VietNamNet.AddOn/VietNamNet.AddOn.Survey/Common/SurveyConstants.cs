using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Survey.Common
{
    public class SurveyConstants
    {
        public const string SurveyId = "surveyid";
        public const string ArticleId = "articleid";
        public const string CategoryAlias = "categorysalias";

        #region FormNames
        public class FormNames : ModuleConstants.FormNames
        {
            public const string SurveyEdit = "SurveyEdit.aspx";
        }
        #endregion

    }
    public class SurveyPublishConstants
    {
        public const string SurveyPublishId = "surveypublishid";

    }

  
}
