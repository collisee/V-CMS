/************************************************************************/
/* File Name  : Constants.cs                                            */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Khai báo const của các Tracker                         */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 17/09/2010 File Create                                               */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
namespace VietNamNet.AddOn.Tracker.Components
{
    public class Constants
    { 

        public class ServiceName
        {
            public const string Comment = "VietNamNet.Framework.Tracking.Comment";
            public const string Article = "VietNamNet.Framework.Tracking.Article";
            public const string Rating = "VietNamNet.Framework.Tracking.Rating";
            public const string Survey = "VietNamNet.Framework.Tracking.Survey";

            // Network Tools Services
            public const string SpeedTest = "VietNamNet.AddOn.Tracker.NetworkTools.SpeedTracker";
            public const string Ping = "VietNamNet.AddOn.Tracker.NetworkTools.PingTracker";
            public const string Tracert = "VietNamNet.AddOn.Tracker.NetworkTools.TracertTracker";
            
        }
        public class ParameterName
        {
            
            public const string Article = "VietNamNet.Framework.Tracking.Article";
            public const string Rating = "VietNamNet.Framework.Tracking.Rating";

        }

    }
}
