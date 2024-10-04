using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Xml;
using SubSonic;
using Telerik.Web.UI;
using VietNamNet.AddOn.Survey.Common;
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Survey
{
    public partial class ServicesSurveyPost : SurveyBasePage
    {
        #region  Members

        private string strCookie;
        private int _surveyId;
        private int _surveyPublish;
        #endregion

        #region  Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("itemId=" + Request);
            if (Request.Params["pollId"] != null &&  Request.Params["randId"] != null && Request.Params["itemId"] != null)
            {//Update 
                 _surveyId = int.Parse(Request.Params["pollId"]);
                strCookie = "Survey_" +_surveyId;
                
                if (HasVoted() == false)
                {
                    foreach (String i in Request.Params["itemId"].ToString().Split(','))
                    {
                        SurveyResult result = new SurveyResult();
                        result.SurveyOptionId = int.Parse(i) ;
                        result.IsDeleted = false;

                        result.Save();
                    }
                    SetHasVoted();
                }
                PopularItem(true);
            }
            else
            {
                PopularItem(false );
            }
        }

        private void PopularItem(Boolean Status)
        {  
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
                // Create an XML document. Write our specific values into the document.
                XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.UTF8);

                // Write the XML document header.
                xmlWriter.WriteStartDocument();

                // Write Survey header.
                xmlWriter.WriteElementString("Status", Status.ToString());  

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

    
        #endregion

        #region Private Methods 
         
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
