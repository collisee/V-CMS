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
    public partial class ViewSurveyByCat : SurveyBasePage
    {
        #region  Members

        private string strCookie;
        private int _catid;
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
            if (Request.Params["catid"] != null && Request.Params["catid"] != "null" && !Utilities.IsNullOrEmpty(Request.Params["catid"]))
            {
                _catid = int.Parse(Request.Params["catid"]);
                 
                SurveysListByCat1.CatId = _catid;
                SurveysListByCat1.Bind(); 
            }
           


        }

        
        #endregion

    }
}
