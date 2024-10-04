/************************************************************************/
/* File Name  : PingService.cs                                           */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Tracker của chức năng NetworkTools - PingService       */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 26/10/2010 File Create                                               */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using System.Web;
using VietNamNet.AddOn.Tracker.Components;
using VietNamNet.AddOn.Tracker.NetworkTools;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Tracker.NetworkTools.AJAX
{
    public class PingService : AJAXService
    { 
        #region  Members 

        #endregion
        public override void Execute(AJAXPacket packet)
        {
            PingUtility p = new PingUtility();
            p.IpAddressString = HttpContext.Current.Request.UserHostAddress; 

            packet.Type = AJAXType.JavaScriptObject;
            packet.Value = p.Ping();
            //packet.Type = AJAXType.JavaScriptObject;
            // output ra JSON va bind lai duoi client!
        }
    }
}