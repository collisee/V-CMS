/************************************************************************/
/* File Name  : PingTracker.cs                                           */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Tracker của chức năng NetworkTools - PingTracker       */
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
    public class PingTracker : TrackingService
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
                if (packet.Parameters[PingTrackerConstants.ParameterName.PingCommand] == null ||
                    packet.Parameters[PingTrackerConstants.ParameterName.IpAddress] == null ||
                    packet.Parameters[PingTrackerConstants.ParameterName.ByteSize] == null ||

                    packet.Parameters[PingTrackerConstants.ParameterName.SentPings] == null ||
                    packet.Parameters[PingTrackerConstants.ParameterName.ReceivedPings] == null ||
                    packet.Parameters[PingTrackerConstants.ParameterName.LostPings] == null ||

                    packet.Parameters[PingTrackerConstants.ParameterName.MinPingResponse] == null ||
                    packet.Parameters[PingTrackerConstants.ParameterName.MaxPingResponse] == null ||
                    packet.Parameters[PingTrackerConstants.ParameterName.AverageTimeResponse] == null  )
                { return; }
            }
            else
            {
                return;
            }

            CookieController cCtrl = new CookieController(Constants.ServiceName.Ping);
            
            
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
            if (packet.Parameters[PingTrackerConstants.ParameterName.PingCommand] == null ||
                packet.Parameters[PingTrackerConstants.ParameterName.IpAddress] == null ||
                packet.Parameters[PingTrackerConstants.ParameterName.ByteSize] == null ||

                packet.Parameters[PingTrackerConstants.ParameterName.SentPings] == null ||
                packet.Parameters[PingTrackerConstants.ParameterName.ReceivedPings] == null ||
                packet.Parameters[PingTrackerConstants.ParameterName.LostPings] == null ||

                packet.Parameters[PingTrackerConstants.ParameterName.MinPingResponse] == null ||
                packet.Parameters[PingTrackerConstants.ParameterName.MaxPingResponse] == null ||
                packet.Parameters[PingTrackerConstants.ParameterName.AverageTimeResponse] == null  )

                    sb.Append(string.Format("[StartTime=={0}]", packet.Parameters[PingTrackerConstants.ParameterName.StartTime]));
                    sb.Append(string.Format("[EndTime=={0}]", packet.Parameters[PingTrackerConstants.ParameterName.EndTime]));

                    
                    sb.Append(string.Format("[PingCommand={0}]", packet.Parameters[PingTrackerConstants.ParameterName.PingCommand]));
                    sb.Append(string.Format("[IpAddress=={0}]", packet.Parameters[PingTrackerConstants.ParameterName.IpAddress]));
                    sb.Append(string.Format("[ByteSize=={0}]", packet.Parameters[PingTrackerConstants.ParameterName.ByteSize]));

                    sb.Append(string.Format("[SentPings=={0}]", packet.Parameters[PingTrackerConstants.ParameterName.SentPings]));
                    sb.Append(string.Format("[ReceivedPings=={0}]", packet.Parameters[PingTrackerConstants.ParameterName.ReceivedPings]));
                    sb.Append(string.Format("[LostPings=={0}]", packet.Parameters[PingTrackerConstants.ParameterName.LostPings]));

                    sb.Append(string.Format("[MinPingResponse=={0}]", packet.Parameters[PingTrackerConstants.ParameterName.MinPingResponse]));
                    sb.Append(string.Format("[MaxPingResponse=={0}]", packet.Parameters[PingTrackerConstants.ParameterName.MaxPingResponse]));
                    sb.Append(string.Format("[AverageTimeResponse=={0}]", packet.Parameters[PingTrackerConstants.ParameterName.AverageTimeResponse]));
           

                o.Message = sb.ToString();
                o.ServieName = Constants.ServiceName.Ping;
                o.TrachkerWrite();

                cCtrl.SetCookie(Constants.ServiceName.Ping, DateTime.Now.AddMinutes(2)); 
            }
           

        }


 } 
