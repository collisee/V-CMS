using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;
using VietNamNet.AddOn.Survey.Common;
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Survey
{
    public partial class ServicesSurveyResult : SurveyBasePage
    {
        #region  Members

        private string strCookie;
        private int _surveyId;
        private int _surveyPublish;
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

                SurveyViewResult1.SurveyId = _surveyId;
                SurveyViewResult1.Bind();



                StringWriter stringWrite = new StringWriter();
                HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                SurveyViewResult1.RenderControl(htmlWrite);



                Response.Clear();
                Response.ContentType = "text/html";
                Response.ContentEncoding = System.Text.Encoding.UTF8;

                Response.Write(stringWrite.ToString());
                Response.End(); 
            } 


        }

      
        #endregion

    }
}
