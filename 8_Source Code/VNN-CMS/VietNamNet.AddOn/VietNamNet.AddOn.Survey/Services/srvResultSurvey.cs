/************************************************************************/
/* File Name  : srvResultSurvey.cs                                      */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Survey                              */
/* Product Version : 1.0                                                */
/* Copyright(C) 2009 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/*                                                                      */
/* File history                                                         */
/* 14/09/2010 File Create, creat base function                          */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/


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
    public class srvResultSurvey : AJAXService
    {
        #region  Members
        private string strCookie;
        private int _surveyId;
        private SurveyOutput _surveyInfor = null;

        #endregion

        public override void Execute(AJAXPacket packet)
        {
            if (Utilities.StringCompare(packet.Action,"result"))
            {
                if (packet.Parameters[SurveyConstants.SurveyId] != null && packet.Parameters[SurveyConstants.SurveyId] != "null" && !Utilities.IsNullOrEmpty(packet.Parameters[SurveyConstants.SurveyId]))
                {
                    _surveyId = int.Parse(packet.Parameters[SurveyConstants.SurveyId]);


                    packet.Type = AJAXType.JavaScriptObject;
                    packet.Value = "action";

                    return;
                }  

               
            } 

                packet.Type = AJAXType.HTML;
                packet.Value = "Could not find result! "; 
             
        }

      
        private void GetData()
        {
            _surveyInfor = new SurveyOutput(_surveyId);


        }
         
    }

 
}
