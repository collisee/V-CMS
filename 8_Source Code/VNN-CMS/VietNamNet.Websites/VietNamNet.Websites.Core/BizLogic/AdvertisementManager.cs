using System.Data;
using System.Diagnostics;
using log4net;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.DBAccess;

namespace VietNamNet.Websites.Core.BizLogic
{
    /// <summary>
    /// Summary description for AdvertisementManager.
    /// </summary>
    public class AdvertisementManager : Facade
    {
        #region Override Execute
        private readonly ILog iLog = LogManager.GetLogger(WebsitesConstants.Services.AdvertisementManager.Name);

        public override Packet Execute(Packet param)
        {
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            switch (param.Action)
            {
                case WebsitesConstants.Services.AdvertisementManager.Actions.GetLayoutByCategoryId:
                    GetLayoutByCategoryId(param);
                    break;
                case WebsitesConstants.Services.AdvertisementManager.Actions.GetZonesByLayoutId:
                    GetZonesByLayoutId(param);
                    break;
                case WebsitesConstants.Services.AdvertisementManager.Actions.GetBlocksByZoneId:
                    GetBlocksByZoneId(param);
                    break;
                case WebsitesConstants.Services.AdvertisementManager.Actions.GetItemsByBlockId:
                    GetItemsByBlockId(param);
                    break;
                default:
                    break;
            }

            //Log timer
            timer.Stop();

            string msg = string.Format("ServiceName::{0};Action::{1};Timer::{2} ms",
                param.ServiceName,
                param.Action,
                Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds));
            iLog.Info(msg); 

            return param;
        }

        #endregion

        #region Execute Actions

        #region Function GetLayoutByCategoryId

        private void GetLayoutByCategoryId(Packet param)
        {
            DataTable dt = AdvertisementDAO.GetLayoutByCategoryId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetZonesByLayoutId

        private void GetZonesByLayoutId(Packet param)
        {
            DataTable dt = AdvertisementDAO.GetZonesByLayoutId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetBlocksByZoneId

        private void GetBlocksByZoneId(Packet param)
        {
            DataTable dt = AdvertisementDAO.GetBlocksByZoneId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetItemsByBlockId

        private void GetItemsByBlockId(Packet param)
        {
            DataTable dt = AdvertisementDAO.GetItemsByBlockId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #endregion
    }
}