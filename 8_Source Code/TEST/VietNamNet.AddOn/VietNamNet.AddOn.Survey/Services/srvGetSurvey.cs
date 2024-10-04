using System.Collections.Generic;
using System.Web.UI.MobileControls;
using VietNamNet.AddOn.Survey.Common;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Survey.AJAX
{
    public class srvGetSurvey : AJAXService
    {
        #region  Members
        private string strCookie;
        private int _surveyId;
        private SurveyOutput _surveyInfor = null;

        #endregion


        public override void Execute(AJAXPacket packet)
        {
            //if packet.Action = "" ;

            if (packet.Parameters[SurveyConstants.ArticleId] != null && packet.Parameters[SurveyConstants.ArticleId] != "null" && !Utilities.IsNullOrEmpty(packet.Parameters[SurveyConstants.ArticleId]))
            {
                int aId = int.Parse(packet.Parameters[SurveyConstants.ArticleId].ToString());

                // Get Survey by Artile
                SubSonic.StoredProcedure sproc = SPs.SurveyListByArticle(aId);
                List<SurveyPublish> p = sproc.ExecuteTypedList<SurveyPublish>();

                if (p.Count > 0)
                {
                    _surveyId = p[0].SurveyId;
                    GetData();
                }

            }
            else if (packet.Parameters[SurveyConstants.CategoryAlias] != null && packet.Parameters[SurveyConstants.CategoryAlias] != "null" && !Utilities.IsNullOrEmpty(packet.Parameters[SurveyConstants.CategoryAlias]))
            {
                int cId = 0;

                // Get Survey by Cat
                SubSonic.StoredProcedure sproc = SPs.SurveyListByCat(cId);
                List<SurveyPublish> p = sproc.ExecuteTypedList<SurveyPublish>();

                if (p.Count > 0)
                {
                    _surveyId = p[0].SurveyId;
                    GetData();
                }

            }
            else if (packet.Parameters[SurveyConstants.SurveyId] != null && packet.Parameters[SurveyConstants.SurveyId] != "null" && !Utilities.IsNullOrEmpty(packet.Parameters[SurveyConstants.SurveyId]))
            {
                _surveyId = int.Parse(packet.Parameters[SurveyConstants.SurveyId]);
                GetData();
            }

            packet.Type = AJAXType.JavaScriptObject;
            packet.Value = _surveyInfor;
        }

      
        private void GetData()
        {
            _surveyInfor = new SurveyOutput(_surveyId);


        }

        private bool HasVoted()
        {
            strCookie = "Survey_" + _surveyId.ToString();

            //AJAXPacket packet;
            //packet.Action

            //if (packet.Cookies[strCookie] == null)
            //    return false;
            //else
            //    return true;

            return false;
        }

    }

    public class SurveyOutput
    {
       private int surveyId;
        private string question;

        private string optionType;
        private List<SurveyOptionOutput> surveyOption;

        public int SurveyId
        {
            get { return surveyId; }
            set { surveyId = value; }
        }
        public string Question
        {
            get { return question; }
            set { question = value; }
        }
        public string OptionType
        {
            get { return optionType; }
            set { optionType = value; }
        }
        public List<SurveyOptionOutput> SurveyOption
        {
            get { return surveyOption; }
            set { surveyOption = value; }
        }

        public SurveyOutput(int surveyId, string question, string optionType, List<SurveyOptionOutput> surveyOption)
        {
            this.surveyId = surveyId;
            this.question = question;
            this.optionType = optionType;
            this.surveyOption = surveyOption;
        }

        public SurveyOutput(SurveyModule.DAL.Survey s)
           {
               this.surveyId = s.SurveyId;
               this.question = s.Question;
               this.optionType = s.OptionType;

               SurveyOptionCollection soCol = s.SurveyOptions();
           // surveyOption = new List<SurveyOptionOutput>();
               if (soCol.Count>0)
                   foreach (SurveyOption so in soCol)
                   {
                       //SurveyOptionOutput soOut = new SurveyOptionOutput(so.SurveyId, so.OptionName);
                       //this.surveyOption.Add(soOut);
                       surveyOption.Add(new SurveyOptionOutput(so.SurveyId, so.SurveyOptionId ,  so.OptionName)); 
                   }
           }
        public SurveyOutput(int _surveyId)
        {
           SurveyModule.DAL.Survey s = new SurveyModule.DAL.Survey(_surveyId);

           this.surveyId = s.SurveyId;
           this.question = s.Question;
           this.optionType = s.OptionType;

           SurveyOptionCollection soCol = s.SurveyOptions();

           List<SurveyOptionOutput>  soOut = new List<SurveyOptionOutput>();
           foreach (SurveyOption so in soCol)
           {
               //soOut = new SurveyOptionOutput(so.SurveyId, so.OptionName);
               soOut.Add(new SurveyOptionOutput(so.SurveyId, so.SurveyOptionId, so.OptionName));
           }

            SurveyOption = soOut;
        }

    }
    public class SurveyOptionOutput
    {
        private int surveyId;
        private int surveyOptionId;
        private string optionName;

        public int SurveyOptionId
        {
            get { return surveyOptionId; }
            set { surveyOptionId = value; }
        }

        public int SurveyId
        {
            get { return surveyId; }
            set { surveyId = value; }
        }

        public string OptionName
        {
            get { return optionName; }
            set { optionName = value; }
        }

        public SurveyOptionOutput(int surveyId, int surveyOptionId, string optionName)
        {
            this.surveyId = surveyId;
            this.surveyOptionId = surveyOptionId;
            this.optionName = optionName;
        }
    }

}
