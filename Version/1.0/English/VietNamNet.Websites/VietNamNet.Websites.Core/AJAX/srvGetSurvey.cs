using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using VietNamNet.AddOn.Survey.Services.Components;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Survey.Core.Presentation;
using VietNamNet.Websites.Core.Common.Survey;

namespace VietNamNet.Survey.Core.AJAX
{
    public class srvGetSurvey : AJAXService
    { 
        #region  Members
        public string strCookie;
        public int _surveyId;
        public SurveyObject _surveyInfor = null;

        #endregion
        public override void Execute(AJAXPacket packet)
        {
            if (packet.Parameters[SurveyConstants.Param.ArticleId] != null && 
                    packet.Parameters[SurveyConstants.Param.ArticleId] != "null" && 
                    !Utilities.IsNullOrEmpty(packet.Parameters[SurveyConstants.Param.ArticleId]))
            {
                int aId = int.Parse(packet.Parameters[SurveyConstants.Param.ArticleId].ToString());

                // Get Survey by Artile
                SurveyHelper helper = new SurveyHelper(new SurveyParamObject());
                helper.ValueObject.ArticleId = aId;
                DataTable dt = helper.ListByArticle();

                //SubSonic.StoredProcedure sproc = SPs.SurveyListByArticle(aId);
                //List<SurveyPublish> p = sproc.ExecuteTypedList<SurveyPublish>();

                if (dt.Rows.Count > 0)
                {
                    _surveyId = Utilities.ParseInt(dt.Rows[0]["SurveyId"]);
                    GetData();
                }

            }
            else if (packet.Parameters[SurveyConstants.Param.CategoryAlias] != null && packet.Parameters[SurveyConstants.Param.CategoryAlias] != "null" && !Utilities.IsNullOrEmpty(packet.Parameters[SurveyConstants.Param.CategoryAlias]))
            {
                string CategoryAlias = packet.Parameters[SurveyConstants.Param.CategoryAlias];
                int cId = 0;
                SurveyHelper helper = new SurveyHelper(new SurveyParamObject());
                helper.ValueObject.CategoryAlias = CategoryAlias;
                DataTable dt = helper.ListByCat();
 

                //// Get Survey by Cat
                //SubSonic.StoredProcedure sproc = SPs.SurveyListByCat(cId);
                //List<SurveyPublish> p = sproc.ExecuteTypedList<SurveyPublish>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    _surveyId = Utilities.ParseInt(dt.Rows[0]["SurveyId"]);
                    GetData();
                }

            }
            else if (packet.Parameters[SurveyConstants.Param.SurveyId] != null && packet.Parameters[SurveyConstants.Param.SurveyId] != "null" && !Utilities.IsNullOrEmpty(packet.Parameters[SurveyConstants.Param.SurveyId]))
            {
                _surveyId = int.Parse(packet.Parameters[SurveyConstants.Param.SurveyId]);
                GetData();
            }

            packet.Type = AJAXType.JavaScriptObject;
            packet.Value = _surveyInfor;
        }


        private void GetData()
        {
            
            _surveyInfor = new SurveyObject(_surveyId);
            _surveyInfor.HasVoted = this.HasVoted();

        }

        public bool HasVoted()
        {
            strCookie = "Survey_" + _surveyId.ToString();

            if (HttpContext.Current.Request.Cookies[strCookie] == null)
                return false;
            else
                return true;

            return false;
        }

    }
}