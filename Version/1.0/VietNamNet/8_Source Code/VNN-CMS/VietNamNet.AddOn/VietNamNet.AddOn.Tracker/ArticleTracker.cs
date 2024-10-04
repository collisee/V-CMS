/************************************************************************/
/* File Name  : ArticleTracker.cs                                       */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Tracker của chức năng Article                          */
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
    public class ArticleTracker : TrackingService
    {
        #region  Members
        public string strCookie;
        public int _ArticleId; 

        #endregion

        public override void Execute(TrackingPacket packet)
        {
            if (packet.Parameters[ArticleConstants.ParameterName.ArticleId] != null){
                _ArticleId = Utilities.ParseInt(packet.Parameters[ArticleConstants.ParameterName.ArticleId]);
            }
            else {
                return; }

            //if (packet.Parameters != null && !HasVoted())
            if (packet.Parameters != null )
            {
                CookieController cCtrl = new CookieController(Constants.ServiceName.Article);

                // Nếu đã có Cookie thì trả về
                if (!Utilities.IsNullOrEmpty(cCtrl.CheckCookie()))
                {
                    if (cCtrl.CheckCookie() == packet.Parameters[ArticleConstants.ParameterName.ArticleId]) 
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
                if (packet.Parameters[ArticleConstants.ParameterName.ArticleId] != null)
                {
                    sb.Append(string.Format("[articleId={0}]", packet.Parameters[ArticleConstants.ParameterName.ArticleId]));
                    sb.Append(string.Format("[categoryAlias={0}]", packet.Parameters[ArticleConstants.ParameterName.CategoryAlias]));
                    sb.Append(string.Format("[createdAt={0}]", DateTime.Now.Ticks.ToString()));
                }
                //o.Message = string.Format("Article" + ":{0}", packet.Parameters[VietNamNet.AddOn.Tracker.Components.Constants.ParameterName.Comment]);
                               
                o.Message = sb.ToString();
                o.ServieName = Constants.ServiceName.Article;
                o.TrachkerWrite();

                cCtrl.CookieName = Constants.ServiceName.Article;
                cCtrl.CookieValue = packet.Parameters[ArticleConstants.ParameterName.ArticleId];
                cCtrl.ExpiresTime = DateTime.Now.AddMinutes(1);
                cCtrl.SetCookie();

            }
        }
 
    }
}