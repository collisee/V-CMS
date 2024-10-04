using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.MobileControls;
using VietNamNet.AddOn.Survey.Common;
using VietNamNet.AddOn.Survey.Services.Components;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Survey.AJAX
{
    public class srvPostSurvey : ServiceBase
    {
      
        public override void Execute(AJAXPacket packet)
        {
            if (Utilities.StringCompare(packet.Action,"post"))
            {
                // do action post
                if (packet.Parameters["surveyId"] != null && packet.Parameters["randId"] != null && packet.Parameters["itemId"] != null)
                {//Update 
                    _surveyId = int.Parse(packet.Parameters["surveyId"]);
                    strCookie = "Survey_" + _surveyId;

                    if (HasVoted() == false)
                    {
                        foreach (String i in packet.Parameters["itemId"].ToString().Split(','))
                        {
                            SurveyResult result = new SurveyResult();
                            result.SurveyOptionId = int.Parse(i);
                            result.IsDeleted = false;

                            if (HttpContext.Current.Session[VietNamNet.Framework.Common.Constants.Session.USER_ID]!= null &&
                                HttpContext.Current.Session[VietNamNet.Framework.Common.Constants.Session.USER_ID].ToString() != "")
                            {
                                result.CreatedBy = HttpContext.Current.Session[VietNamNet.Framework.Common.Constants.Session.USER_ID].ToString();
                                result.ModifiedBy = HttpContext.Current.Session[VietNamNet.Framework.Common.Constants.Session.USER_ID].ToString();
                            }

                            result.Save();
                        }
                        SetHasVoted();
                    }
                }
                packet.Type = AJAXType.HTML;
                packet.Value = "true";
            }
            else
            {

                packet.Type = AJAXType.HTML;
                packet.Value = "false";
            }
           

        }
        

    }
 

}
