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
    public partial class ViewSurvey : SurveyBasePage
    {
        #region  Members

        private string strCookie;
        private int _surveyId;
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

        protected void cmdSelect_Click(object sender, EventArgs e)
        {
            if (HasVoted() == false)
            {
                foreach (int i in SurveyDisplay1.SurveyOptionsSeleted)
                {
                    SurveyResult result = new SurveyResult();
                    result.SurveyOptionId = i;
                    result.IsDeleted = false;
                    
                    result.Save();
                }
                SetHasVoted();
                SetupEnvironment();
            }
        }

        #endregion

        #region Private Methods
        private void SetupEnvironment()
        {
            if (Request.Params[SurveyConstants.SurveyId] != null && Request.Params[SurveyConstants.SurveyId] != "null" && !Utilities.IsNullOrEmpty(Request.Params[SurveyConstants.SurveyId]))
            {
                _surveyId = int.Parse(Request.Params[SurveyConstants.SurveyId]);
                txtSurveyId.Text = _surveyId.ToString();

                SurveyModule.DAL.Survey s;
                s = new SurveyModule.DAL.Survey(_surveyId);
                SurveyDisplay1.SurveyInfor = s;
                SurveyDisplay1.Bind();
                strCookie = "Survey_" + s.SurveyId.ToString()  ;
            }
            cmdSelect.Visible = !HasVoted();


        }

        private bool HasVoted()
        {  
            if (Request.Cookies[strCookie] == null)
                return false;
            else
                return true; 
        }
        private void SetHasVoted()
        {
            HttpCookie objCookie = new HttpCookie(strCookie);
            objCookie.Value = "True";
            objCookie.Expires = DateTime.Now.AddDays(1);      // never expires
            Response.AppendCookie(objCookie); 
        }
        #endregion

    }
}
