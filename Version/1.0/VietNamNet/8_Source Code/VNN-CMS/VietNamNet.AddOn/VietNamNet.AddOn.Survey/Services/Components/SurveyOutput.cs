using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SubSonic;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Survey.Services.Components
{
    public class SurveyOutput
    {
        #region Members
        private int _surveyId;
        private string _question;

        private string _optionType;
        private bool _hasVoted;

        private int _sumResult;
        private List<SurveyOptionOutput> _surveyOption;

        #endregion

        #region Public Properties
        public int SurveyId
        {
            get { return _surveyId; }
            set { _surveyId = value; }
        }
        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }
        public string OptionType
        {
            get { return _optionType; }
            set { _optionType = value; }
        }
        public bool HasVoted
        {
            get { return _hasVoted; }
            set { _hasVoted = value; }
        }
        public int SumResult
        {
            get { return _sumResult; }
            set { _sumResult = value; }
        }

        public List<SurveyOptionOutput> SurveyOption
        {
            get { return _surveyOption; }
            set { _surveyOption = value; }
        }

        #endregion

        #region Contructor
        public SurveyOutput(int surveyId, string question, string optionType, bool hasVoted, List<SurveyOptionOutput> surveyOption)
        {
            this._surveyId = surveyId;
            this._question = question;
            this._optionType = optionType;
            this._surveyOption = surveyOption;
            this.HasVoted = hasVoted;
        }

        public SurveyOutput(SurveyModule.DAL.Survey s)
        {
            this._surveyId = s.SurveyId;
            this._question = s.Question;
            this._optionType = s.OptionType;

            SurveyOptionCollection soCol = s.SurveyOptions();
            // surveyOption = new List<SurveyOptionOutput>();
            if (soCol.Count > 0)
                foreach (SurveyOption so in soCol)
                {
                    //SurveyOptionOutput soOut = new SurveyOptionOutput(so.SurveyId, so.OptionName);
                    //this.surveyOption.Add(soOut);
                    _surveyOption.Add(new SurveyOptionOutput(so.SurveyId, so.SurveyOptionId, so.OptionName));
                }
        }
        public SurveyOutput(int _surveyId)
        {
            SurveyModule.DAL.Survey s = new SurveyModule.DAL.Survey(_surveyId);

            this.SurveyId = s.SurveyId;
            this.Question = s.Question;
            this.OptionType = s.OptionType;

            //// Get Survery Options
            //SurveyOptionCollection soCol = s.SurveyOptions();
            //List<SurveyOptionOutput> soOut = new List<SurveyOptionOutput>();
            //foreach (SurveyOption so in soCol)
            //{
            //    soOut.Add(new SurveyOptionOutput(so.SurveyId, so.SurveyOptionId, so.OptionName));
            //}
            //SurveyOption = soOut;

            // Get Survery Result
            StoredProcedure spResult = SPs.SurveyResultsGet(_surveyId);
            DataSet ds = spResult.GetDataSet();

            int sumResult = 0;
            List<SurveyOptionOutput> soOut = new List<SurveyOptionOutput>();
            foreach (DataRow r in ds.Tables[0].Rows)
            { 
                sumResult += Utilities.ParseInt(r["Result"].ToString());
            }
            string percent;
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                percent = "0%";
                if (sumResult>0) percent = Utilities.ParseInt((Utilities.ParseInt(r["Result"]) * 100 / sumResult)).ToString() + "%";
                soOut.Add(new SurveyOptionOutput(Utilities.ParseInt(r["SurveyId"]), Utilities.ParseInt(r["SurveyOptionId"]), r["OptionName"].ToString(), Utilities.ParseInt(r["Result"]), percent));
            }
            this.SumResult = sumResult;
            this.SurveyOption = soOut;

        }

        #endregion
    }
}
