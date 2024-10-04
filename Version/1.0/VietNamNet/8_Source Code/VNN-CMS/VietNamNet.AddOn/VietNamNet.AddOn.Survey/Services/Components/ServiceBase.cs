/************************************************************************/
/* File Name  : ServiceBase.cs                                          */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Survey                              */
/* Product Version : 1.0                                                */
/* Copyright(C) 2009 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/*                                                                      */
/* File history                                                         */
/* 19/09/2010 File Create, creat base function                          */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/

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
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.AJAX;

namespace VietNamNet.AddOn.Survey.Services.Components
{
    public class ServiceBase : AJAXService
    {
        #region  Members
        public string strCookie;
        public int _surveyId;
        public SurveyOutput _surveyInfor = null;

        #endregion

        #region Public Methods

        public override void Execute(AJAXPacket packet)
        {
            
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

        public void SetHasVoted()
        {
            strCookie = "Survey_" + _surveyId.ToString(); 
            
            HttpCookie objCookie = new HttpCookie(strCookie);
            objCookie.Value = "True";
            objCookie.Expires = DateTime.Now.AddDays(1);      // never expires
            HttpContext.Current.Response.AppendCookie(objCookie);
        }

        #endregion
    }
 
}
