/************************************************************************/
/* File Name  : PingService.cs                                           */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Tracker của chức năng NetworkTools - PingService       */
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
using VietNamNet.Framework.AJAX;

namespace VietNamNet.AddOn.Tracker.NetworkTools.AJAX
{
    public class TracertService : AJAXService
    { 
        #region  Members  

        private string a ="";
        #endregion

        public override void Execute(AJAXPacket packet)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            //p.IpAddressString = HttpContext.Current.Request.UserHostAddress;

            p.StartInfo.FileName = "c:\\windows\\system32\\tracert.exe";
            p.StartInfo.Arguments = HttpContext.Current.Request.UserHostAddress + " -d " + " -w 5000 ";
            //p.StartInfo.Arguments = "google.com.vn";
            //p.p
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            p.PriorityClass = System.Diagnostics.ProcessPriorityClass.Normal;

            string strTemp = "";
            StringBuilder sbReturn = new StringBuilder();


            while (strTemp != null && !p.HasExited)
            {
                strTemp = p.StandardOutput.ReadLine();
                if (strTemp!=null)
                    if (strTemp.Length > 3) 
                        sbReturn.AppendLine(strTemp + "\n"); 
                //Page.Response.Flush();
                if (!HttpContext.Current.Response.IsClientConnected)
                {
                    p.Kill();
                    break;
                }
               
            }
 

            packet.Type = AJAXType.HTML;
            //packet.Value = sbReturn.ToString();
            packet.Value = sbReturn.ToString();
            //packet.Type = AJAXType.JavaScriptObject;
            // output ra JSON va bind lai duoi client!

        }
         
    }
}