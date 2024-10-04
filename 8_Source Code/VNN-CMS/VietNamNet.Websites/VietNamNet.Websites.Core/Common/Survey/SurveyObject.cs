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
using VietNamNet.Framework.Common;
using VietNamNet.Survey.Core.Presentation;

namespace VietNamNet.AddOn.Survey.Services.Components
{
    public class SurveyObject
    {
        #region Members
        private int _surveyId;
        private string _question;

        private string _optionType;
        private bool _hasVoted;

        private int _sumResult;
        private List<SurveyOptionObject> _surveyOption;

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

        public List<SurveyOptionObject> SurveyOption
        {
            get { return _surveyOption; }
            set { _surveyOption = value; }
        }

        #endregion

        #region Contructor
        public SurveyObject(int surveyId, string question, string optionType, bool hasVoted, List<SurveyOptionObject> surveyOption)
        {
            this._surveyId = surveyId;
            this._question = question;
            this._optionType = optionType;
            this._surveyOption = surveyOption;
            this.HasVoted = hasVoted;
        }

         public SurveyObject(int _surveyId)
         {
             SurveyHelper helper = new SurveyHelper(new SurveyParamObject());
             helper.ValueObject.SurveyId = _surveyId;
             DataTable dt2 = helper.GetById();

            if (dt2.Rows.Count > 0)
            { 
                this.SurveyId = Utilities.ParseInt(dt2.Rows[0]["SurveyId"]);
                this.Question = dt2.Rows[0]["Question"].ToString();
                this.OptionType = dt2.Rows[0]["OptionType"].ToString();


                helper = new SurveyHelper(new SurveyParamObject());
                helper.ValueObject.SurveyId = _surveyId;
                DataTable dtResult = helper.ResultsGetBySurvey();

                int sumResult = 0;
                List<SurveyOptionObject> soOut = new List<SurveyOptionObject>();
                foreach (DataRow r in dtResult.Rows)
                {
                    sumResult += Utilities.ParseInt(r["Result"].ToString());
                }
                string percent;
                foreach (DataRow r in dtResult.Rows)
                {
                    percent = "0%";
                    if (sumResult > 0) percent = Utilities.ParseInt((Utilities.ParseInt(r["Result"]) * 100 / sumResult)).ToString() + "%";
                    soOut.Add(new SurveyOptionObject(Utilities.ParseInt(r["SurveyId"]), Utilities.ParseInt(r["SurveyOptionId"]), r["OptionName"].ToString(), Utilities.ParseInt(r["Result"]), percent));
                }
                this.SumResult = sumResult;
                this.SurveyOption = soOut;
            }
        }

        #endregion
    }

     public class SurveyParamObject
     {
        #region Members
         private int _articleId;
         private string _categoryAlias;
         private int _surveyId;
        #endregion

        #region Public Properties

         public int ArticleId
         {
             get { return _articleId; }
             set { _articleId = value; }
         }

         public string CategoryAlias
         {
             get { return _categoryAlias; }
             set { _categoryAlias = value; }
         }

         public int SurveyId
         {
             get { return _surveyId; }
             set { _surveyId = value; }
         }

         #endregion
     }
}
