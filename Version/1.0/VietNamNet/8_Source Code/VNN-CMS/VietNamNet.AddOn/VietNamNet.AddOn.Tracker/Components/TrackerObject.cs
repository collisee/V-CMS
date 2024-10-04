/************************************************************************/
/* File Name  : TrackerObject.cs                                        */
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
using System;
using System.Text;
using log4net;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Tracker.Components
{
    public class TrackerObject
    {
        #region Members

        private string _servieName;
        private string _ip;
        private string _domain;
        private string _user;
        private string _visit;

        private string _message;

        protected ILog iLog;
        #endregion

        #region Public Properties

        public string ServieName
        {
            get { return _servieName; }
            set { _servieName = value; }
        }

        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        public string Visit
        {
            get { return _visit; }
            set { _visit = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        #endregion

        #region Contructor

        public TrackerObject()
        {
             
        }

        public TrackerObject(string servieName, string ip, string domain, string user, string visit, string message)
        {
            ServieName = servieName;
            Ip = ip;
            Domain = domain;
            User = user;
            Visit = visit;
            Message = message;
        }

        #endregion

        #region Public Methods

        public void TrachkerWrite()
        {
            //StringBuilder sb = new StringBuilder();
 
            //sb.Append("[Domain:" + this.Domain + "]");
            //sb.Append("[User:" + this.User + "]");
            //sb.Append("[Visit:" + this.Visit + "]");
            //sb.Append("[Ip:" + this.Ip + "]");
            //sb.Append("[Message:" + this.Message + "]");

            iLog = LogManager.GetLogger(this.ServieName);
            iLog.Info(Convertor.ToString(this) );
        }
          
        #endregion

    }
}
