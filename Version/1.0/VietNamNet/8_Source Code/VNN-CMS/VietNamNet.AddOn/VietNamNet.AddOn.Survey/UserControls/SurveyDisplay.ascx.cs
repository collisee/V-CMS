using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using VietNamNet.AddOn.SurveyModule.DAL;


namespace VietNamNet.AddOn.Survey.UserControls
{
    public partial class SurveyDisplay : UserControl
    {

        #region Members

        private String _formName;
        private String sampleItem = "<div class=\"vote_item\">INPUT_TYPE ITEM_DESCRIPTION</div>";

        private string strCookie;
        private string _divId;
        public string DivId
        {
            get { return _divId; }
            set { _divId = value; }
        }

        private int _surveyId = 0;
        public int SurveyId
        {
            get { return _surveyId; }
            set { _surveyId = value; }
        }

        private VietNamNet.AddOn.SurveyModule.DAL.Survey _surveyInfor = null;
        public VietNamNet.AddOn.SurveyModule.DAL.Survey SurveyInfor
        {
            get
            {
                return _surveyInfor;
            }
            set { _surveyInfor = value; }
        }

        private List<int> _surveyOptionsSeleted;
        public List<int> SurveyOptionsSeleted
        {
            get
            {
                _surveyOptionsSeleted = new List<int>();
                if (this.FindControl("rSurvey") != null)
                {
                    RadioButtonList rad = (RadioButtonList)this.FindControl("rSurvey");
                    _surveyOptionsSeleted.Add(int.Parse(rad.SelectedValue));
                }
                if (this.FindControl("cSurvey") != null)
                {
                    CheckBoxList chk = (CheckBoxList)this.FindControl("cSurvey");
                    for (int i = 0; i <= chk.Items.Count - 1; i++)
                    {
                        if (chk.Items[i].Selected == true) _surveyOptionsSeleted.Add(int.Parse(chk.Items[i].Value));
                    }

                }

                return _surveyOptionsSeleted;
            }
        }

        #endregion

        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region Public Methods
        public void Bind()
        {
            SetupEnvironment();
        }
        #endregion

        #region Private Methods

        private void SetupEnvironment()
        {

            if (_surveyInfor != null)
            { }
            else if (_surveyId != null && _surveyId != 0)
            {
                _surveyInfor = new VietNamNet.AddOn.SurveyModule.DAL.Survey(_surveyId);
            }
            else
            {
                _surveyInfor = new VietNamNet.AddOn.SurveyModule.DAL.Survey();
            }


            lblQuestion.Text = _surveyInfor.Question;
            // hidden show
            string sHidden = "<input  id=\"SURVEY_ID\" name=\"SURVEY_NAME\" value=\"SURVEY_VALUE\"  type=\"hidden\"><input name=\"RAND_ID\" value=\"RAND_VALUE\" type=\"hidden\"><input id=\"DIV_ID\" name=\"DIV_NAME\" value=\"DIV_VALUE\" type=\"hidden\">";
            lblHidden.Text = sHidden
                                .Replace("SURVEY_ID", "survey" + this.ClientID + _surveyInfor.SurveyId.ToString())
                                .Replace("SURVEY_NAME", "survey" + this.ClientID + _surveyInfor.SurveyId.ToString())
                                .Replace("SURVEY_VALUE", _surveyInfor.SurveyId.ToString())
                                .Replace("RAND_ID", "rndsurvey_" + _surveyInfor.SurveyId.ToString())
                                .Replace("RAND_VALUE", new Random().Next(100000, 900000).ToString())
                                .Replace("DIV_ID", "divsurvey" + this.ClientID + _surveyInfor.SurveyId.ToString())
                                .Replace("DIV_NAME", "divsurvey" + this.ClientID + _surveyInfor.SurveyId.ToString())
                                .Replace("DIV_VALUE", DivId);


            StringBuilder sb = new StringBuilder();

            String inputType;
            if (SurveyInfor.OptionType == "R") inputType = "radio";
            else inputType = "checkbox";


            if (HasVoted())
            {
                foreach (SurveyOption o in _surveyInfor.SurveyOptions())
                {
                    sb.Append(sampleItem
                        .Replace("INPUT_TYPE", "<input type=\"" + inputType + "\" id=\"input_" + o.SurveyOptionId + "\" name=\"itemId\" value=\"" + o.SurveyOptionId + "\"  disabled=\"disabled\">")
                        .Replace("ITEM_DESCRIPTION", "<label for=\"input_" + o.SurveyOptionId + "\" >" + o.OptionName + "</label>"));
                }
                //StoredProcedure spResult = SPs.SurveyResultsGet(_surveyId);
                //DataSet ds = spResult.GetDataSet();
                //int sumResult = 0; 
                //foreach (DataRow r in ds.Tables[0].Rows)
                //{sumResult += int.Parse(r["Result"].ToString());
                //}

                //foreach (DataRow r in ds.Tables[0].Rows)
                //{
                //    sb.Append(sampleItem
                //      .Replace("INPUT_TYPE", "&nbsp;&nbsp;&nbsp;")
                //      .Replace("ITEM_DESCRIPTION", "<label class=\"label \" >" + r["OptionName"] + "</label>" + "<label>" + r["Result"] + "/" + sumResult.ToString() + "</label>"));
                //}
            }
            else
            {
                foreach (SurveyOption o in _surveyInfor.SurveyOptions())
                {
                    sb.Append(sampleItem
                        .Replace("INPUT_TYPE", "<input type=\"" + inputType + "\" id=\"input_" + o.SurveyOptionId + "\" name=\"itemId\" value=\"" + o.SurveyOptionId + "\">")
                        .Replace("ITEM_DESCRIPTION", "<label for=\"input_" + o.SurveyOptionId + "\" >" + o.OptionName + "</label>"));
                }
            }


            lblOptions.Text = sb.ToString();

            // stringWrite.Write("_surveyId=" + _surveyId);
            _formName = "frmSurvey_" + _surveyId.ToString();


            string sButton = "<a href=\"#\" id=\"LINK_ID\"  onclick=\"LINK_EVENT\">LINK_TEXT</a>";
            if (HasVoted())
            {//View result
                //"<a href=\"#\" id=\"viewresult" + _surveyInfor.SurveyId + "\" onclick=\"showresult('" + "survey" + this.ID + _surveyInfor.SurveyId.ToString() + "');\" >Xem kết quả</a>";
                string d = "<div class=\"jqmWindow\" id=\"DIALOG_ID\">Bạn hãy chờ giây lát... <img src=\"/Images/busy.gif\" alt=\"loading\" /></div> ";
                string d2 = "<div class=\"jqmWindow\" id=\"message\">Cám ơn bạn đã Bình chọn! <a href=\"#\" class=\"jqmClose\"></a> </div> ";
                lblButton.Text = sButton.Replace("LINK_ID", "viewresult" + _surveyInfor.SurveyId.ToString())
                    //.Replace("LINK_EVENT", "showresult('SURVEY_ID');".Replace("SURVEY_ID", "survey" + this.ClientID + _surveyInfor.SurveyId.ToString()))
                                    .Replace("LINK_EVENT", "return viewresult('SURVEY_ID','#DIALOG_ID');".Replace("SURVEY_ID", "survey" + this.ClientID + _surveyInfor.SurveyId.ToString())
                                                                                                    .Replace("DIALOG_ID", "dia" + this.ClientID + _surveyInfor.SurveyId.ToString()))
                                    .Replace("LINK_TEXT", "Xem kết quả")
                                  + d2 + d.Replace("DIALOG_ID", "dia" + this.ClientID + _surveyInfor.SurveyId);
            }
            else
            {//Post 

                lblButton.Text = sButton.Replace("LINK_ID", "pollpost" + _surveyInfor.SurveyId)
                                    .Replace("LINK_EVENT", "return validateSubmit('SURVEY_ID','DIV_ID');".Replace("SURVEY_ID", "survey" + this.ClientID + _surveyInfor.SurveyId.ToString()).Replace("DIV_ID", "divsurvey" + this.ClientID + _surveyInfor.SurveyId.ToString()))
                                    .Replace("LINK_TEXT", "Bình chọn"); ;
            }
        }

        private bool HasVoted()
        { strCookie = "Survey_" + _surveyId.ToString();

            if (Request.Params["v"] != null)//Voted or not
            {
                if (Request.Params["v"].ToString().IndexOf(strCookie)>=0)
                    return true;
            }

            if (Request.Cookies[strCookie] != null)
                return true;
            else
                return false;
        }

        public String FormName()
        {
            return _formName;
        }

        #endregion

    }
}