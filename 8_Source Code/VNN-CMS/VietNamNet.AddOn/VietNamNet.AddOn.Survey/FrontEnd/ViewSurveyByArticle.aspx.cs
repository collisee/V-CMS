using System;
using System.Data;
using System.Web;
using Telerik.Web.UI;
using VietNamNet.AddOn.Survey.Common;
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Survey
{
    public partial class ViewSurveyByArticle : SurveyBasePage
    {
        #region  Members

        private string strCookie;
        private int _articleid;
        private int _surveyPublish;
        #endregion

        #region  Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
           
            if (!IsPostBack)
            {
                
            }
            SetupEnvironment();

        }
         
        #endregion

        #region Private Methods
        private void SetupEnvironment()
        {
            if (Request.Params["articleid"] != null && Request.Params["articleid"] != "null" && !Utilities.IsNullOrEmpty(Request.Params["articleid"]))
            {
                _articleid = int.Parse(Request.Params["articleid"]);

                SurveysListByArticle1.ArticleId = _articleid;
                SurveysListByArticle1.Bind(); 
            }
           


        }

        
        #endregion

    }
}
