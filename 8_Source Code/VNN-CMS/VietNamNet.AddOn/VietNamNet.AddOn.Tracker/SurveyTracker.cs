/************************************************************************/
/* File Name  : CommentTracker.cs                                       */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Tracker của chức năng Comment                          */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 17/09/2010 File Create                                               */
/* 08/11/2010 Edit for thethao.vietnamnet.vn                            */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using System;
using System.Text;
using System.Web;
using VietNamNet.AddOn.Tracker.Components;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Tracking;
using Constants = VietNamNet.AddOn.Tracker.Components.Constants;

namespace VietNamNet.AddOn.Tracker
{
    public class SurveyTracker : TrackingService
    {
        #region  Members
        public string strCookie;
        public int _surveyId; 

        #endregion

        public override void Execute(TrackingPacket packet)
        {
            if (packet.Parameters[SurveyConstants.ParameterName.SurveyId] != null){
                _surveyId = Utilities.ParseInt(packet.Parameters[SurveyConstants.ParameterName.SurveyId]);
            }
            else {
                return; }
 

            if (packet.Parameters != null )
            {
                CookieController cCtrl = new CookieController();
                cCtrl.CookieName = Constants.ServiceName.Survey + "_" + packet.Parameters[SurveyConstants.ParameterName.SurveyId];


                // Nếu đã có Cookie thì trả về
                if (!Utilities.IsNullOrEmpty(cCtrl.CheckCookie()))
                { 
                        return;
                }


                // Nếu chưa có Cookie thì cho phép ghi

                TrackerObject o = new TrackerObject();

                o.Ip = HttpContext.Current.Request.UserHostAddress;
                o.Domain = packet.Parameters[TrackingConstants.ParameterName.Domain];
                o.User = packet.Parameters[TrackingConstants.ParameterName.User];
                o.Visit = packet.Parameters[TrackingConstants.ParameterName.Visit];
                //o.Message = "QueryString: " + HttpContext.Current.Request.QueryString.ToString() +" _comment";

                StringBuilder sb = new StringBuilder();
                if (packet.Parameters[SurveyConstants.ParameterName.SurveyId] != null &&
                    packet.Parameters[SurveyConstants.ParameterName.RandId] != null &&
                    packet.Parameters[SurveyConstants.ParameterName.ItemId] != null)
                {

                    SurveyMessageObj oMes = new SurveyMessageObj();
                    oMes.SurveyId = packet.Parameters[SurveyConstants.ParameterName.SurveyId];
                    oMes.ItemId = packet.Parameters[SurveyConstants.ParameterName.ItemId];
                    oMes.RandId = packet.Parameters[SurveyConstants.ParameterName.RandId];

                    //object obj = new object();
                    //string xml = Convertor.ToString(obj);

                    //string xmlEncode = Base64(xml)

                    //object obj2 = Convertor.ToObject(typeof (SurveyResult), xml);



                   // sb.Append(string.Format("<{0}>{1}</{0}>",SurveyConstants.ParameterName.SurveyId, packet.Parameters[SurveyConstants.ParameterName.SurveyId]));
                   // sb.Append(string.Format("<{0}>{1}</{0}>", SurveyConstants.ParameterName.ItemId,packet.Parameters[SurveyConstants.ParameterName.ItemId]));

                    // tracking for Survey game in Thethao.vietnamnet.vn
                    if (packet.Parameters[SurveyConstants.ParameterName.Name] != null &&
                           packet.Parameters[SurveyConstants.ParameterName.IdentityCard] != null &&
                           packet.Parameters[SurveyConstants.ParameterName.Phone] != null &&
                           packet.Parameters[SurveyConstants.ParameterName.Address] != null &&
                           packet.Parameters[SurveyConstants.ParameterName.Email] != null)
                    {
                        oMes.Name = packet.Parameters[SurveyConstants.ParameterName.Name];
                        oMes.IdentityCard = packet.Parameters[SurveyConstants.ParameterName.IdentityCard];
                        oMes.Phone = packet.Parameters[SurveyConstants.ParameterName.Phone];
                        oMes.Address = packet.Parameters[SurveyConstants.ParameterName.Address];
                        oMes.Email = packet.Parameters[SurveyConstants.ParameterName.Email];


                        //sb.Append(string.Format("<{0}>{1}</{0}>", SurveyConstants.ParameterName.Name, packet.Parameters[SurveyConstants.ParameterName.Name]));
                        //sb.Append(string.Format("<{0}>{1}</{0}>", SurveyConstants.ParameterName.IdentityCard, packet.Parameters[SurveyConstants.ParameterName.IdentityCard]));
                        //sb.Append(string.Format("<{0}>{1}</{0}>", SurveyConstants.ParameterName.Address, packet.Parameters[SurveyConstants.ParameterName.Address]));
                        //sb.Append(string.Format("<{0}>{1}</{0}>", SurveyConstants.ParameterName.Email, packet.Parameters[SurveyConstants.ParameterName.Email]));
                    }


                    //o.Message = Convertor.ToString(oMes); //o.Message = sb.ToString();
                    o.ServieName = Constants.ServiceName.Survey;
                    //o.TrachkerWrite();

                    cCtrl.ExpiresTime = DateTime.Now.AddMinutes(15);
                    cCtrl.SetCookie();
                }
               
 
            }
        } 
    }
}