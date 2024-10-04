using System.Data;
using System.Diagnostics;
using log4net;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.Survey;
using VietNamNet.Websites.Core.DBAccess;

namespace VietNamNet.Websites.Core.BizLogic
{
    /// <summary>
    /// Summary description for SurveyManager.
    /// </summary>
    public class SurveyManager : Facade
    {

        #region Override Execute
        private readonly ILog iLog = LogManager.GetLogger( SurveyConstants.Services.SurveyManager.Name);

        public override Packet Execute(Packet param)
        {
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            switch (param.Action)
            {
                case SurveyConstants.Services.SurveyManager.Actions.ListByCat:
                    ListByCat(param);
                    break;
                case SurveyConstants.Services.SurveyManager.Actions.ListByArticle:
                    ListByArticle(param);
                    break;
                case SurveyConstants.Services.SurveyManager.Actions.GetById:
                    GetById(param);
                    break;
                case SurveyConstants.Services.SurveyManager.Actions.ResultsGetBySurvey:
                    ResultsGetBySurvey(param);
                    break; 
                default:
                    break;
            }
            //Log timer
            timer.Stop();

            string msg = string.Format("ServiceName::{0};Action::{1};Timer::{2} ms",
                param.ServiceName,
                param.Action,
                Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds));
            iLog.Info(msg); 

            return param;
        }

        #endregion

        #region Execute Actions


        private void ListByCat(Packet param)
        {
            DataTable dt = SurveyDAO.ListByCat(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }
        private void ListByArticle(Packet param)
        {
            DataTable dt = SurveyDAO.ListByArticle(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }
        private void GetById(Packet param)
        {
            DataTable dt = SurveyDAO.GetById(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }
        private void ResultsGetBySurvey(Packet param)
        {
            DataTable dt = SurveyDAO.ResultsGetBySurvey(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }
        #endregion
    }
}