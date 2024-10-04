using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VietNamNet.AddOn.Survey.Common;
using VietNamNet.Framework.Common;

namespace VietNamNet.Websites.V1.Survey 
{
    public partial class ServicesSurveyGet2 : System.Web.UI.Page
    {
        #region  Members
        private string strCookie;
        private int _surveyId; 
        #endregion

        #region  Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            SetupEnvironment();
        }
        #endregion

        #region Private Methods

        private void SetupEnvironment()
        {
            if (Request.Params[SurveyConstants.SurveyId] != null && Request.Params[SurveyConstants.SurveyId] != "null" && !Utilities.IsNullOrEmpty(Request.Params[SurveyConstants.SurveyId]))
            {
                _surveyId = int.Parse(Request.Params[SurveyConstants.SurveyId]);

                SurveyDisplay1.SurveyId = _surveyId;
                SurveyDisplay1.DivId = Request.Params["divId"];
                SurveyDisplay1.Bind();

                if (HasVoted())
                {
                    SurveyViewResult1.SurveyId = _surveyId;
                    SurveyViewResult1.Bind();
                   // SurveyViewResult1.Visible = true;
                }else
                {
                    SurveyViewResult1.Visible = false;
                }

                StringWriter stringWrite = new StringWriter();
                HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                SurveyDisplay1.RenderControl(htmlWrite);
                SurveyViewResult1.RenderControl(htmlWrite);
               
                Response.Clear();
                Response.ContentType = "text/html";
                Response.ContentEncoding = System.Text.Encoding.UTF8;

                Response.Write(stringWrite.ToString());
                Response.End();
            }


        }

        private bool HasVoted()
        {
            strCookie = "Survey_" + _surveyId.ToString();

            if (Request.Cookies[strCookie] == null)
                return false;
            else
                return true;
        }
        #endregion

    }
}
