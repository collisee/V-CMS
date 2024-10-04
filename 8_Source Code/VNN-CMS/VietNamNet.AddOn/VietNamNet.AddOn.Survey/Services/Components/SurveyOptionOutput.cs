using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace VietNamNet.AddOn.Survey.Services.Components
{
    public class SurveyOptionOutput
    {
        #region Members
        private int _surveyId;
        private int _surveyOptionId;
        private string _optionName;
        private int _result;
        private string _resultPercent;
        #endregion

        #region Public Properties
        public int SurveyOptionId
        {
            get { return _surveyOptionId; }
            set { _surveyOptionId = value; }
        }
        public int SurveyId
        {
            get { return _surveyId; }
            set { _surveyId = value; }
        }
        public string OptionName
        {
            get { return _optionName; }
            set { _optionName = value; }
        }
        public int Result
        {
            get { return _result; }
            set { _result = value; }
        }
        public string ResultPercent
        {
            get { return _resultPercent; }
            set { _resultPercent = value; }
        }
             #endregion

           #region Contructor
        public SurveyOptionOutput(int surveyId, int surveyOptionId, string optionName)
        {
            this._surveyId = surveyId;
            this._surveyOptionId = surveyOptionId;
            this._optionName = optionName;
        }
        public SurveyOptionOutput(int surveyId, int surveyOptionId, string optionName, int result, string resultPercent)
        {
            SurveyId = surveyId;
            SurveyOptionId = surveyOptionId;
            OptionName = optionName;
            Result = result;
            ResultPercent = resultPercent;
        }

             #endregion
    }
}
