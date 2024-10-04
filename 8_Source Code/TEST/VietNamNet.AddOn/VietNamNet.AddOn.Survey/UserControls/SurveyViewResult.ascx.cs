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
    public partial class SurveyViewResult : UserControl
    {
        #region Members
        private String _dialogName;
        public int sumResult;

        private int _surveyId = 0;
        public int SurveyId
        {
            get { return _surveyId; }
            set { _surveyId = value; }
        }

        private VietNamNet.AddOn.SurveyModule.DAL.Survey _surveyInfor = new VietNamNet.AddOn.SurveyModule.DAL.Survey();
        public VietNamNet.AddOn.SurveyModule.DAL.Survey SurveyInfor
        {
            get
            {
                return _surveyInfor;
            }
            set { _surveyInfor = value; }
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
        #endregion

        #region Public Members
        public void Bind()
        {
            SetupEnvironment();
        }
        #endregion

        #region Private Members

        private void SetupEnvironment()
        {

            if (_surveyId != null && _surveyId != 0)
            {
                _dialogName = "digResult_" + _surveyId.ToString();
                lblMessages.Text = "_surveyId=" + _surveyId;
                _surveyInfor = new VietNamNet.AddOn.SurveyModule.DAL.Survey(_surveyId);
                lblQuestion.Text = _surveyInfor.Question;

                StoredProcedure spResult = SPs.SurveyResultsGet(_surveyId);
                DataSet ds = spResult.GetDataSet();

                sumResult = 0;
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    sumResult += int.Parse(r["Result"].ToString());
                }

                rptView.DataSource = ds;
                rptView.DataBind();
            }
            else
            {
                lblMessages.Text = "_surveyId=none";
            }

        }

        public String DialogName()
        {
            return _dialogName;
        }
        #endregion
    }
}