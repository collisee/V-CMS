/************************************************************************/
/* File Name  : PingUtility.cs                                          */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Ghi và đọc các thông tin của Traker PingUtility        */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 27/10/2010 File Create                                               */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using System.Net;

namespace VietNamNet.AddOn.Tracker.NetworkTools
{
    public class PingObject
    {

        #region Members

        private string _pingCommand;
        private string _ipAddress;
        private int _byteSize;
        private int _sentPings;
        private int _receivedPings;
        private int _lostPings;
        
        private long  _minPingResponse;
        private long _maxPingResponse;

        private long _averageTimeResponse;
        
        #endregion

        #region Public Properties

        public string PingCommand
        {
            get { return _pingCommand; }
            set { _pingCommand = value; }
        }

        public string IpAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }

        public int ByteSize
        {
            get { return _byteSize; }
            set { _byteSize = value; }
        }

        public int SentPings
        {
            get { return _sentPings; }
            set { _sentPings = value; }
        }

        public int ReceivedPings
        {
            get { return _receivedPings; }
            set { _receivedPings = value; }
        }

        public int LostPings
        {
            get { return _lostPings; }
            set { _lostPings = value; }
        }

        public long MinPingResponse
        {
            get { return _minPingResponse; }
            set { _minPingResponse = value; }
        }

        public long MaxPingResponse
        {
            get { return _maxPingResponse; }
            set { _maxPingResponse = value; }
        }

        public long AverageTimeResponse
        {
            get { return _averageTimeResponse; }
            set { _averageTimeResponse = value; }
        }

        #endregion

        #region Contructor

        public PingObject(string pingCommand, string ipAddress, int byteSize, int sentPings, int receivedPings, int lostPings, long minPingResponse, long maxPingResponse, long averageTimeResponse)
        {
            _pingCommand = pingCommand;
            _ipAddress = ipAddress;
            _byteSize = byteSize;
            _sentPings = sentPings;
            _receivedPings = receivedPings;
            _lostPings = lostPings;
            _minPingResponse = minPingResponse;
            _maxPingResponse = maxPingResponse;
            _averageTimeResponse = averageTimeResponse;
        }

        #endregion

    }
}
