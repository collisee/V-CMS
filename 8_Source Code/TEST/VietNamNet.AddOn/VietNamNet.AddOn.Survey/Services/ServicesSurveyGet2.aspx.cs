using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using VietNamNet.AddOn.Survey.Common;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Survey.Services
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
            if (Request.Params[SurveyConstants.ArticleId] != null && Request.Params[SurveyConstants.ArticleId] != "null" && !Utilities.IsNullOrEmpty(Request.Params[SurveyConstants.ArticleId]))
            {
                int aId = int.Parse( Request.Params[SurveyConstants.ArticleId].ToString());

                // Get Survey by Artile
                SubSonic.StoredProcedure sproc = SPs.SurveyListByArticle(aId);
                List<SurveyPublish> p = sproc.ExecuteTypedList<SurveyPublish>();

                if (p.Count > 0)
                {
                    _surveyId = p[0].SurveyId;
                    PopularItem();
                }

            }
            else if (Request.Params[SurveyConstants.CategoryAlias] != null && Request.Params[SurveyConstants.CategoryAlias] != "null" && !Utilities.IsNullOrEmpty(Request.Params[SurveyConstants.CategoryAlias]))
            {
                int cId = 0;

                // Get Survey by Cat
                SubSonic.StoredProcedure sproc = SPs.SurveyListByCat(cId);
                List<SurveyPublish> p = sproc.ExecuteTypedList<SurveyPublish>();

                if (p.Count > 0)
                {
                    _surveyId = p[0].SurveyId;
                    PopularItem();
                }
              
            }
            else if (Request.Params[SurveyConstants.SurveyId] != null && Request.Params[SurveyConstants.SurveyId] != "null" && !Utilities.IsNullOrEmpty(Request.Params[SurveyConstants.SurveyId]))
            {
                _surveyId = int.Parse(Request.Params[SurveyConstants.SurveyId]);
                PopularItem();
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

        private void PopularItem()
        {
            SurveyDisplay1.Visible = true;
            SurveyDisplay1.SurveyId = _surveyId;
            SurveyDisplay1.DivId = Request.Params["divId"];
            SurveyDisplay1.Bind();

            if (HasVoted())
            {
                SurveyViewResult1.SurveyId = _surveyId;
                SurveyViewResult1.Bind();
                //SurveyViewResult1.Visible = true;
            }
            else
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

        #endregion

    }
}
