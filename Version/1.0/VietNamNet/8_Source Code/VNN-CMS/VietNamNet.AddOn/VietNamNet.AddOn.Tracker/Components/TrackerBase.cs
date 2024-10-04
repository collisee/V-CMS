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
/* 17/09/2010 Cancel using this file                                    */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using VietNamNet.Framework.Tracking;
using log4net;

namespace VietNamNet.AddOn.Tracker
{
    public class TrackerBase : TrackingService
    {
        #region Members
        protected static readonly ILog LogInfo = LogManager.GetLogger("testApp.Logging");
        protected  ILog iLog;


        #endregion

        #region Public Methods

        public override void Execute(TrackingPacket packet)
        {

        }
         

        #region Methods
            
            
            
        #endregion

        #endregion


    }
}