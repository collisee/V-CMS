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
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using log4net;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Tracker.Components
{
    [Serializable()]
    [XmlRoot("obj")]
    [XmlInclude(typeof(ArticleMessageObj))]
    [XmlInclude(typeof(SurveyMessageObj))]
    public class TrackerObject
    {
        #region Members

        private string _servieName;
        private string _ip;
        private string _domain;
        private string _user;
        private string _visit;

        private object _message;
        private DateTime _createAt;
        protected ILog iLog;
        #endregion

        #region Public Properties

        [XmlAttribute("sn")]
        public string ServieName
        {
            get { return _servieName; }
            set { _servieName = value; }
        }

        [XmlAttribute("ip")]
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        [XmlAttribute]
        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }

        [XmlAttribute]
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        [XmlAttribute]
        public string Visit
        {
            get { return _visit; }
            set { _visit = value; }
        }

        [XmlElement("msg")]
        public object Message
        {
            get { return _message; }
            set { _message = value; }
        }

        [XmlAttribute]
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }

        #endregion

        #region Contructor

        //public TrackerObject()
        //{
             
        //}

        //public TrackerObject(string servieName, string ip, string domain, string user, string visit, string message)
        //{
        //    ServieName = servieName;
        //    Ip = ip;
        //    Domain = domain;
        //    User = user;
        //    Visit = visit;
        //    Message = message;
        //}

        #endregion

        #region Public Methods

        public void TrachkerWrite()
        {
            iLog = LogManager.GetLogger(this.ServieName);
            iLog.Info(ToString(this));
        }
          
        #endregion




        public static string ToString(object xmlObject)
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(xmlObject.GetType());
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                xs.Serialize(xmlTextWriter, xmlObject, namespaces);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch (Exception ex)
            {
            }

            return string.Empty;
        }

        public static String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();

            String constructedString = encoding.GetString(characters);

            return (constructedString);
        }

        public static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();

            Byte[] byteArray = encoding.GetBytes(pXmlString);

            return byteArray;
        }


    }
}
