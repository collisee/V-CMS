using System;
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
    public partial class SurveyInfo : BaseUserControls
    {
        #region Members
        private int _surveyId;
        public int SurveyId
        {
            get { return _surveyId; }
            set { _surveyId = value; }
        }

        private SurveyModule.DAL.Survey _surveyInfor = new SurveyModule.DAL.Survey(); 
        public SurveyModule.DAL.Survey SurveyInfor
        {
            get {
                _surveyInfor.SurveyId = int.Parse(lblSurveyId.Text);
                return _surveyInfor; }
            set { _surveyInfor = value; }
        }

        #endregion

        #region Properties

        #endregion

        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            if (! Page.IsPostBack )
            {
                //SetupEnvironment();
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

            if (_surveyInfor!=null)
            {}
            else if(_surveyId !=null) 
            {
                _surveyInfor = new Select().From<SurveyModule.DAL.Survey>().
                    Where(SurveyModule.DAL.Survey.Columns.SurveyId).IsEqualTo(_surveyId).ExecuteSingle<SurveyModule.DAL.Survey>();
            }
            else
            {
                _surveyInfor= new SurveyModule.DAL.Survey();
            }

            lblQuestion.Text = _surveyInfor.Question;
            lblOptionType.Text = _surveyInfor.OptionType == "R" ? "Một lựa chọn" : " Nhiều lựa chọn";
            lblNotes.Text = _surveyInfor.Notes;
            lblTags.Text = _surveyInfor.Tags;
            lblSurveyId.Text = _surveyInfor.SurveyId.ToString( );
            StringBuilder str = new StringBuilder();
            foreach (SurveyOption so in _surveyInfor.SurveyOptions())
            {
                str.Append(so.OptionName + "<br>");
            }
            lblSurveyOptions.Text = str.ToString();
            //grdOptions.DataSource = _surveyInfor.SurveyOptions();
            //grdOptions.DataBind();
        }
        #endregion

    }
}