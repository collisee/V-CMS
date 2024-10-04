using System.Data;
using VietNamNet.AddOn.Survey.Services.Components;
using VietNamNet.Framework.Biz; 
using VietNamNet.Websites.Core.Common.Survey;

namespace VietNamNet.Survey.Core.Presentation
{
    public class SurveyHelper
    {
        #region Members
        private SurveyParamObject o;

        #region SurveyHelper(SurveyParamObject o)

        public SurveyHelper(SurveyParamObject o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public SurveyParamObject ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = SurveyConstants.Services.SurveyManager.Name;
            return p;
        }

        #endregion
        #endregion

        #region Public Function

        public DataTable ListByCat()
        {
            Packet p = GetPacket();
            p.Action = SurveyConstants.Services.SurveyManager.Actions.ListByCat;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        } 
        public DataTable ListByArticle()
        {
            Packet p = GetPacket();
            p.Action = SurveyConstants.Services.SurveyManager.Actions.ListByArticle;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }
        public DataTable GetById()
        {
            Packet p = GetPacket();
            p.Action = SurveyConstants.Services.SurveyManager.Actions.GetById;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        public DataTable ResultsGetBySurvey()
        {
            Packet p = GetPacket();
            p.Action = SurveyConstants.Services.SurveyManager.Actions.ResultsGetBySurvey;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        } 
        #endregion

    }
}