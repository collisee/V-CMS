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
/* 26/10/2010 File Create                                               */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;

namespace VietNamNet.AddOn.Tracker.NetworkTools
{
    /// <summary>
    /// Summary description for PingUtility
    /// </summary>
    public class PingUtility
    {

        #region Members
        private int _pingTimeout = 1000;
        private string _ipAddressString = "google.com.vn";
        private int _numberOfPings = 4;
        #endregion

        #region Public Properties

        public int PingTimeout
        {
            get { return _pingTimeout; }
            set { _pingTimeout = value; }
        }

        public string IpAddressString
        {
            get { return _ipAddressString; }
            set { _ipAddressString = value; }
        }

        public int NumberOfPings
        {
            get { return _numberOfPings; }
            set { _numberOfPings = value; }
        }

        #endregion

        #region Contructor
        public PingUtility()
        {

        }

        #endregion

        #region Public Methods

        public PingObject Ping()
        {
            using (Ping pingSender = new Ping())
            {
                PingOptions pingOptions = null;
                StringBuilder pingResults = null;
                PingReply pingReply = null;
                IPAddress ipAddress = null;
                
                
                int byteSize = 32;
                byte[] buffer = new byte[byteSize];
                int sentPings = 0;
                int receivedPings = 0;
                int lostPings = 0;
                long minPingResponse = 0;
                long maxPingResponse = 0;
                long averageTimeResponse = 0;

                long totalTimeResponse = 0;

                pingOptions = new PingOptions();
                //pingOptions.DontFragment = true;
                //pingOptions.Ttl = 128;

                ipAddress = IPAddress.Parse(IpAddressString);

                pingResults = new StringBuilder();
                pingResults.AppendLine(string.Format("Pinging {0} with {1} bytes of data:", ipAddress, byteSize));
                pingResults.AppendLine();

#region Ping
                for (int i = 0; i < NumberOfPings; i++)
                {
                    sentPings++;

                    pingReply = pingSender.Send(ipAddress, PingTimeout, buffer, pingOptions);

                    if (pingReply.Status == IPStatus.Success)
                    {
                        pingResults.AppendLine(string.Format("Reply from {0}: bytes={1} time={2}ms TTL={3}", ipAddress, byteSize, pingReply.RoundtripTime, pingReply.Options.Ttl));

                        if (minPingResponse == 0)
                        {
                            minPingResponse = pingReply.RoundtripTime;
                            maxPingResponse = minPingResponse;
                        }
                        else if (pingReply.RoundtripTime < minPingResponse)
                        {
                            minPingResponse = pingReply.RoundtripTime;
                        }
                        else if (pingReply.RoundtripTime > maxPingResponse)
                        {
                            maxPingResponse = pingReply.RoundtripTime;
                        }

                        receivedPings++;
                        totalTimeResponse += pingReply.RoundtripTime;
                    }
                    else
                    {
                        pingResults.AppendLine(pingReply.Status.ToString());
                        lostPings++;
                    }
                }
                averageTimeResponse = totalTimeResponse/NumberOfPings;
#endregion

                pingResults.AppendLine();
                pingResults.AppendLine(string.Format("Ping statistics for {0}:", ipAddress));
                pingResults.AppendLine(string.Format("\tPackets: Sent = {0}, Received = {1}, Lost = {2}", sentPings, receivedPings, lostPings));
                pingResults.AppendLine("Approximate round trip times in milli-seconds:");
                pingResults.AppendLine(string.Format("\tMinimum = {0}ms, Maximum = {1}ms", minPingResponse, maxPingResponse));



                PingObject obj = new PingObject(pingResults.ToString(),IpAddressString,byteSize,
                                                sentPings,receivedPings, lostPings,
                                                minPingResponse, maxPingResponse, averageTimeResponse);
                return obj;
            }
        }


        public string Traceroute(string ipAddressOrHostName)
        {


            IPAddress ipAddress = Dns.GetHostEntry(ipAddressOrHostName).AddressList[0];
            StringBuilder traceResults = new StringBuilder();

            using (Ping pingSender = new Ping())
            {
                PingOptions pingOptions = new PingOptions();
                Stopwatch stopWatch = new Stopwatch();
                byte[] bytes = new byte[32];
                pingOptions.DontFragment = true;
                pingOptions.Ttl = 1;
                int maxHops = 30;
                traceResults.AppendLine(
                    string.Format(
                        "Tracing route to {0} over a maximum of {1} hops:",
                        ipAddress,
                        maxHops));
                traceResults.AppendLine();
                for (int i = 1; i < maxHops + 1; i++)
                {
                    stopWatch.Reset();
                    stopWatch.Start();
                    PingReply pingReply = pingSender.Send(
                        ipAddress,
                        5000,
                        new byte[32], pingOptions);
                    stopWatch.Stop();
                    traceResults.AppendLine(
                        string.Format("{0}\t{1} ms\t{2}", i, stopWatch.ElapsedMilliseconds, pingReply.Address));
                    if (pingReply.Status == IPStatus.Success)
                    {
                        traceResults.AppendLine();
                        traceResults.AppendLine("Trace complete."); break;
                    }
                    pingOptions.Ttl++;


                }



            }





            return traceResults.ToString();


        }

        #endregion

    }
}
