/************************************************************************/
/* File Name  : PingTrackerConstants.cs                                 */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Khai báo const của các Tracker Ping                    */
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
namespace VietNamNet.AddOn.Tracker.NetworkTools
{
    public class PingTrackerConstants
    {
        public class ParameterName
        {
            public const string StartTime = "startTime";
            public const string EndTime = "endTime";

            public const string PingCommand = "pingCommand";
            public const string IpAddress = "ipAddress";
            public const string ByteSize = "byteSize";

            public const string SentPings = "sentPings";
            public const string ReceivedPings = "receivedPings";
            public const string LostPings = "lostPings";

            public const string MinPingResponse = "minPingResponse";
            public const string MaxPingResponse = "maxPingResponse";

            public const string AverageTimeResponse = "averageTimeResponse";
        }

    }

}
