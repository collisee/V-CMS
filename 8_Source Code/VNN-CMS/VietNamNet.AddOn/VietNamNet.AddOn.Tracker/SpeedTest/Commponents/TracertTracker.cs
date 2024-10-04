/************************************************************************/
/* File Name  : TracertTracker.cs                                           */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Tracker của chức năng NetworkTools - TracertTracker       */
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
using System;
using System.Text;
using System.Web;
using VietNamNet.AddOn.Tracker.Components;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Tracking;
using Constants = VietNamNet.AddOn.Tracker.Components.Constants;

namespace VietNamNet.AddOn.Tracker.NetworkTools
{
    public class TracertTracker : TrackingService
    {
        #region  Members
        public string strCookie;
        public int _surveyId;

        #endregion

        public override void Execute(TrackingPacket packet)
        {
            //if (packet.Parameters != null && !HasVoted())
            if (packet.Parameters != null)
            {
                if (packet.Parameters[TracertTrackerConstants.ParameterName.TraceResponse] == null)
                { return; }
            }
            else
            {
                return;
            }

            CookieController cCtrl = new CookieController(Constants.ServiceName.Tracert);
            
            
            // Nếu đã có Cookie thì trả về
            if (!Utilities.IsNullOrEmpty(cCtrl.CheckCookie())) return;

                       

            // Nếu chưa có Cookie thì cho phép ghi

            TrackerObject o = new TrackerObject();

            o.Ip = HttpContext.Current.Request.UserHostAddress;
            o.Domain = packet.Parameters[TrackingConstants.ParameterName.Domain];
            o.User = packet.Parameters[TrackingConstants.ParameterName.User];
            o.Visit = packet.Parameters[TrackingConstants.ParameterName.Visit];
            //o.Message = "QueryString: " + HttpContext.Current.Request.QueryString.ToString() +" _comment";

            StringBuilder sb = new StringBuilder();
            if (packet.Parameters[TracertTrackerConstants.ParameterName.TraceResponse] != null )
            {
                sb.Append(string.Format("[StartTime=={0}]", packet.Parameters[TracertTrackerConstants.ParameterName.StartTime]));
                sb.Append(string.Format("[EndTime=={0}]", packet.Parameters[TracertTrackerConstants.ParameterName.EndTime]));

                sb.Append(string.Format("[TraceResponse=={0}]", packet.Parameters[TracertTrackerConstants.ParameterName.TraceResponse])); 

                //o.Message = sb.ToString();
                o.ServieName = Constants.ServiceName.Tracert;
                //o.TrachkerWrite();

                cCtrl.SetCookie(Constants.ServiceName.Tracert, DateTime.Now.AddMinutes(2)); 
            }
           

        }


    }
}
