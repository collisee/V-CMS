using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Xml;
using SubSonic;
using VietNamNet.AddOn.Survey.Common;
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.Common; 

namespace VietNamNet.Websites.V1.Survey
{
    public partial class ServicesSurveyGet : SurveyBasePage
    {
        #region  Members

        private string strCookie;
        private int _surveyId;
        private int _surveyPublish;
        #endregion

        #region  Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params[SurveyConstants.SurveyId] != null && Request.Params[SurveyConstants.SurveyId] != "null" && !Utilities.IsNullOrEmpty(Request.Params[SurveyConstants.SurveyId]))
            {
                _surveyId = int.Parse(Request.Params[SurveyConstants.SurveyId]);
                txtSurveyId.Text = _surveyId.ToString();
                strCookie = "Survey_" + _surveyId.ToString();

                PopularItem(_surveyId);
            }
            //else if (Request.Params["pollId"] != null &&  Request.Params["randId"] != null && Request.Params["itemId"] != null)
            //{//Update 
            //     _surveyId = int.Parse(Request.Params["pollId"]);
            //    strCookie = "Survey_" +_surveyId;
            //    Response.Write("itemId=" + Request.Params["itemId"]);
                
            //    if (HasVoted() == false)
            //    {
            //        foreach (String i in Request.Params["itemId"].ToString().Split(','))
            //        {
            //            SurveyResult result = new SurveyResult();
            //            result.SurveyOptionId = int.Parse(i) ;
            //            result.IsDeleted = false;

            //            result.Save();
            //        }
            //        //SetHasVoted();
            //        PopularItem(_surveyId);
            //    }
            //}
        }

        private void PopularItem(int iSurveyId)
        {
            VietNamNet.AddOn.SurveyModule.DAL.Survey s;
            s = new VietNamNet.AddOn.SurveyModule.DAL.Survey(iSurveyId);


            System.IO.MemoryStream stream = new System.IO.MemoryStream();
                // Create an XML document. Write our specific values into the document.
                XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.UTF8);

                // Write the XML document header.
                xmlWriter.WriteStartDocument();

                // Write Survey header.
                xmlWriter.WriteStartElement("Survey");

                // Write an element representing a single web application object.
                xmlWriter.WriteElementString("process", 1.ToString());
                xmlWriter.WriteElementString("HasVoted", HasVoted().ToString());
                xmlWriter.WriteElementString("Title", s.Question);
                xmlWriter.WriteElementString("Type", s.OptionType);

                // Begin the element Options
                xmlWriter.WriteStartElement("Options");

                foreach (SurveyOption o in s.SurveyOptions().Where(SurveyOption.Columns.IsDeleted, Comparison.Equals, false))
                {
                    xmlWriter.WriteStartElement("Option");

                    // Write child element data for our web application object.
                    xmlWriter.WriteElementString("OptionId", o.SurveyOptionId.ToString());
                    xmlWriter.WriteElementString("OptionName", o.OptionName);

                    xmlWriter.WriteEndElement();
                }

                // End the element Options
                xmlWriter.WriteEndElement();

                // End the element Survey
                xmlWriter.WriteEndElement();

                // Finilize the XML document by writing any required closing tag.
                xmlWriter.WriteEndDocument();


                // To be safe, flush the document to the memory stream.
                 xmlWriter.Flush();


                 Response.Clear();
                 Response.ContentType = "text/xml";
                 Response.ContentEncoding = System.Text.Encoding.UTF8;
                 System.IO.StreamReader reader;
                 stream.Position = 0;

                 reader = new System.IO.StreamReader(stream);

                 byte[] bytes = System.Text.Encoding.UTF8.GetBytes(reader.ReadToEnd());

                 //write to response stream
                 Response.BinaryWrite(bytes);

                 Response.End();
            //// Convert the memory stream to an array of bytes.
                //byte[] byteArray = stream.ToArray();

                //// Send the XML file to the web browser for download.  
                //Response.Clear();
                //Response.ContentType = "text/xml";
                //Response.ContentEncoding = System.Text.Encoding.UTF8;
                //Response.AppendHeader("Content-Length", byteArray.Length.ToString()); 
                //Response.BinaryWrite(byteArray);
                //xmlWriter.Close();
 
        }

        protected void cmdSelect_Click(object sender, EventArgs e)
        {
            if (HasVoted() == false)
            {
                foreach (int i in SurveyDisplay1.SurveyOptionsSeleted)
                {
                    SurveyResult result = new SurveyResult();
                    result.SurveyOptionId = i;
                    result.IsDeleted = false;
                    
                    result.Save();
                }
                SetHasVoted();
                //SetupEnvironment();
            }
        }

        #endregion

        #region Private Methods
        private void test()
        {
            ////string fileName = @"..\..\phone.xml";
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml("<?xml version='1.0'?> <Survey></Survey>");
            //XmlElement eTitle, eType, eOptions, eOption, eOptionId, eOptionName, eHasVoted;

            //eTitle = xmlDoc.CreateElement("Title"); eTitle.InnerText = s.Question;
            //xmlDoc.DocumentElement.AppendChild(eTitle);

            //eType = xmlDoc.CreateElement("Type"); eType.InnerText = s.OptionType;
            //xmlDoc.DocumentElement.AppendChild(eType);

            //eOptions = xmlDoc.CreateElement("Options");

            //foreach (SurveyOption o in s.SurveyOptions().Where(SurveyOption.Columns.IsDeleted, Comparison.Equals, false))
            //{
            //    eOption = xmlDoc.CreateElement("Option");

            //    eOptionId = xmlDoc.CreateElement("OptionId"); eOptionId.InnerText = o.SurveyOptionId.ToString();
            //    eOption.AppendChild(eOptionId);
            //    eOptionName = xmlDoc.CreateElement("Name"); eOptionName.InnerText = o.OptionName.ToString();
            //    eOption.AppendChild(eOptionName);

            //    eOptions.AppendChild(eOption);
            //}
            //xmlDoc.DocumentElement.AppendChild(eOptions);

            //eHasVoted = xmlDoc.CreateElement("HasVoted"); eHasVoted.InnerText = HasVoted().ToString();
            //xmlDoc.DocumentElement.AppendChild(eHasVoted);

             
            
        }

        private void SetupEnvironment2()
        {
            if (Request.Params[SurveyConstants.SurveyId] != null && Request.Params[SurveyConstants.SurveyId] != "null" && !Utilities.IsNullOrEmpty(Request.Params[SurveyConstants.SurveyId]))
            {
                _surveyId = int.Parse(Request.Params[SurveyConstants.SurveyId]);
                txtSurveyId.Text = _surveyId.ToString();

                VietNamNet.AddOn.SurveyModule.DAL.Survey s;
                s = new VietNamNet.AddOn.SurveyModule.DAL.Survey(_surveyId);
                SurveyDisplay1.SurveyInfor = s;
                SurveyDisplay1.Bind();
                strCookie = "Survey_" + s.SurveyId.ToString()  ;
            }
            cmdSelect.Visible = !HasVoted();


        }

        private bool HasVoted()
        {  
            if (Request.Cookies[strCookie] == null)
                return false;
            else
                return true; 
        }
        private void SetHasVoted()
        {
            HttpCookie objCookie = new HttpCookie(strCookie);
            objCookie.Value = "True";
            objCookie.Expires = DateTime.Now.AddDays(1);      // never expires
            Response.AppendCookie(objCookie); 
        }
        #endregion

    }
}
