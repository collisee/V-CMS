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
/*                                                                      */
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
    public class CommentTracker : TrackingService
    {  
        #region  Members
        public string strCookie;
        public int _surveyId;

        #endregion

        public override void Execute(TrackingPacket packet)
        {
            
       if (packet.Parameters != null){
            if (packet.Parameters[CommentConstants.ParameterName.ArticleId] != null &&
               packet.Parameters[CommentConstants.ParameterName.Mail] != null &&
               packet.Parameters[CommentConstants.ParameterName.Phone] != null &&
               packet.Parameters[CommentConstants.ParameterName.Subject] != null &&
               packet.Parameters[CommentConstants.ParameterName.Message] != null &&
               packet.Parameters[CommentConstants.ParameterName.Name] != null)
            {
                CookieController cCtrl = new CookieController(Constants.ServiceName.Comment + packet.Parameters[CommentConstants.ParameterName.ArticleId]);

                // Nếu đã có Cookie thì trả về
                if (!Utilities.IsNullOrEmpty(cCtrl.CheckCookie())) return;


                // Nếu chưa có Cookie thì cho phép ghi
            TrackerObject o = new TrackerObject();
            
            o.Ip = HttpContext.Current.Request.UserHostAddress;
            o.Domain = packet.Parameters[TrackingConstants.ParameterName.Domain];
            o.User = packet.Parameters[TrackingConstants.ParameterName.User];
            o.Visit = packet.Parameters[TrackingConstants.ParameterName.Visit];
            //o.Message = "QueryString: " + HttpContext.Current.Request.QueryString.ToString() +" _comment";
            StringBuilder sb = new StringBuilder();
           
                sb.Append(string.Format("[article" + ":{0}]", packet.Parameters[CommentConstants.ParameterName.ArticleId]));

                sb.Append(string.Format("[mail" + ":{0}]", packet.Parameters[CommentConstants.ParameterName.Mail]));
                sb.Append(string.Format("[phone" + ":{0}]", packet.Parameters[CommentConstants.ParameterName.Phone]));
                sb.Append(string.Format("[subject" + ":{0}]", packet.Parameters[CommentConstants.ParameterName.Subject]));
                sb.Append(string.Format("[message" + ":{0}]", packet.Parameters[CommentConstants.ParameterName.Message]));

                sb.Append(string.Format("[name"    + ":{0}]", packet.Parameters[CommentConstants.ParameterName.Name]));
               // sb.Append(string.Format("[comment" + ":{0}]", packet.Parameters[CommentConstants.ParameterName.Comment]));
            

            o.Message = sb.ToString();
            o.ServieName = Constants.ServiceName.Comment;
            o.TrachkerWrite();



            cCtrl.SetCookie(Constants.ServiceName.Comment + packet.Parameters[CommentConstants.ParameterName.ArticleId], DateTime.Now.AddHours(1)); 
        }
        }
        } 
    }
}