using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Serialization;
using System.ComponentModel;
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.AddOn.SurveyModule.DAL;
using SubSonic;


namespace VietNamNet.AddOn.Survey.UserControls
{
    public partial class SurveysListByArticle : UserControl
    {
        #region Members
        private int _articleId = 0;
        private string strCookie;
        public int ArticleId
        {
            get { return _articleId; }
            set { _articleId = value; }
        }
        #endregion

        #region Properties

        #endregion

        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }
        protected void RptViewItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            SurveyDisplay d = (SurveyDisplay)e.Item.FindControl("SurveyDisplay1");
            d.SurveyInfor = (SurveyModule.DAL.Survey)e.Item.DataItem;
            d.Bind();
        }

        protected void cmdSelect_Click(object sender, EventArgs e)
        {
            if (HasVoted() == false)
            {
                SurveyResultCollection resultCollection = new SurveyResultCollection();
                foreach (RepeaterItem r in rptView.Items)
                {
                    cmdResult.Text = "SurveyDisplay1";
                    if (r.FindControl("SurveyDisplay1") != null)
                    {
                        SurveyDisplay sd = (SurveyDisplay)r.FindControl("SurveyDisplay1");
                        foreach (int i in sd.SurveyOptionsSeleted)
                        {
                            SurveyResult result = new SurveyResult();
                            result.SurveyOptionId = i;
                            result.IsDeleted = false;
                            //result.Save();
                            resultCollection.Add(result);
                        }
                    }
                }
                resultCollection.SaveAll();

                SetHasVoted();
                SetupEnvironment();
            }
        }
        #endregion

        #region Public Members
        public void Bind()
        {
            SetupEnvironment();
        }
        #endregion

        #region Private Methods

        private void SetupEnvironment()
        {
            if (ArticleId != null && ArticleId != 0)
            {
                List<SurveyModule.DAL.Survey> sCol = SPs.SurveyListByArticle(ArticleId).ExecuteTypedList<SurveyModule.DAL.Survey>();
                rptView.DataSource = sCol;
                rptView.DataBind();

                strCookie = "Survey_Article" + ArticleId;
                cmdSelect.Visible = true;
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