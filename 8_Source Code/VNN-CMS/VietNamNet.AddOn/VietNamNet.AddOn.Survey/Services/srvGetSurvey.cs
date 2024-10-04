using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.MobileControls;
using VietNamNet.AddOn.Survey.Common;
using VietNamNet.AddOn.Survey.Services.Components;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.AddOn.Survey.AJAX
{
    public class srvGetSurvey : ServiceBase
    { 

        public override void Execute(AJAXPacket packet)
        {
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
                string CategoryAlias = packet.Parameters[SurveyConstants.CategoryAlias];
                int cId = 0;
                WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                helper.ValueObject.CategoryAlias = CategoryAlias;
                DataTable dt = helper.GetCategoryByAlias();
                if (dt != null && dt.Rows.Count > 0)
                {
                    cId = int.Parse(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId].ToString());
                }

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
            _surveyInfor.HasVoted = this.HasVoted();

        }

   

    }

    

}
