using System.Collections;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.Common
{
    public class EmailPacket
    {
        #region Member

        private string strBcc = string.Empty;
        private string strBody = string.Empty;
        private string strCc = string.Empty;
        private string strEmailTemplate = string.Empty;
        private string strFrom = string.Empty;
        private string strFromAlias = string.Empty;
        private string strSubject = string.Empty;
        private string strTo = string.Empty;

        #endregion

        #region Properties

        public string Subject
        {
            get { return strSubject; }
            set { strSubject = value; }
        }

        public string Body
        {
            get { return strBody; }
            set { strBody = value; }
        }

        public string From
        {
            get { return strFrom; }
            set { strFrom = value; }
        }

        public string FromAlias
        {
            get { return strFromAlias; }
            set { strFromAlias = value; }
        }

        public string To
        {
            get { return strTo; }
            set { strTo = value; }
        }

        public string Bcc
        {
            get { return strBcc; }
            set { strBcc = value; }
        }

        public string Cc
        {
            get { return strCc; }
            set { strCc = value; }
        }

        public string EmailTemplate
        {
            get { return strEmailTemplate; }
            set { strEmailTemplate = value; }
        }

        #endregion

        #region Method

        public bool SendEmail(IDictionary objDictionary)
        {
            //XslTransform objXslt = new XslTransform();
            XslCompiledTransform objXslt = new XslCompiledTransform();
            objXslt.Load(strEmailTemplate);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.AppendChild(xmlDoc.CreateElement("EmailMessage"));
            XPathNavigator xpathNav = xmlDoc.CreateNavigator();

            XsltArgumentList xslArg = new XsltArgumentList();
            if (objDictionary != null)
            {
                foreach (DictionaryEntry entry in objDictionary)
                {
                    xslArg.AddParam(entry.Key.ToString(), "", entry.Value);
                }
            }

            StringBuilder emailBuilder = new StringBuilder();
            XmlTextWriter xmlWriter = new XmlTextWriter(new StringWriter(emailBuilder));

            //objXslt.Transform(xpathNav, xslArg, xmlWriter, null);
            objXslt.Transform(xpathNav, xslArg, xmlWriter);

            string bodyText;

            XmlDocument emailDoc = new XmlDocument();
            emailDoc.LoadXml(emailBuilder.ToString());
            XmlNode bodyNode = emailDoc.SelectSingleNode("//html");
            bodyText = HttpUtility.HtmlDecode(bodyNode.InnerXml);
            //bodyText = bodyNode.InnerXml;

            return SendEmail(strSubject, bodyText);
        }

        private bool SendEmail(string subjectText, string bodyText)
        {
            //Builed The MSG
            MailMessage msg = new MailMessage();
            msg.To.Add(To);
            if (!Nulls.IsNullOrEmpty(Cc)) msg.CC.Add(Cc);
            if (!Nulls.IsNullOrEmpty(Bcc)) msg.Bcc.Add(Bcc);
            msg.From =
                new MailAddress(Utilities.GetConfigKey(Constants.ConfigKey.SystemEmail),
                                Utilities.GetConfigKey(Constants.ConfigKey.SystemEmailAlias), Encoding.UTF8);
            msg.Subject = subjectText;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Body = bodyText;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;

            //Add the Creddentials
            SmtpClient client = new SmtpClient();
            client.Credentials =
                new NetworkCredential(Utilities.GetConfigKey(Constants.ConfigKey.SystemEmailLoginname),
                                      Utilities.GetConfigKey(Constants.ConfigKey.SystemEmailPasword));
            client.Port = Utilities.ParseInt(Utilities.GetConfigKey(Constants.ConfigKey.SMTPMailServerPort));

            client.Host = Utilities.GetConfigKey(Constants.ConfigKey.SMTPMailServer);
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl =
                Utilities.StringCompare(Utilities.GetConfigKey(Constants.ConfigKey.SMTPMailServerSecure),
                                        Constants.CommonStatus.Yes);
            //object userState = msg;
            try
            {
                client.Send(msg);
                //client.SendAsync(msg, userState);
            }
            catch (SmtpException ex)
            {
                return false;
            }
            return true;
        }

        public void SendEmail()
        {
            SendEmail(Subject, Body);
        }

        #endregion
    }
}