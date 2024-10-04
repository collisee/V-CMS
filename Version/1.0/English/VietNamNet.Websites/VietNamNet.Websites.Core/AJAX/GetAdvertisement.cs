using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Core.AJAX
{
    public class GetAdvertisement : AJAXService
    {
        public override void Execute(AJAXPacket packet)
        {
            int id = Utilities.ParseInt(packet.Parameters[WebsitesConstants.ParameterName.DOC_ID]);
            string categoryAlias = packet.Parameters[WebsitesConstants.ParameterName.CATEGORY_ALIAS];

            switch(packet.Action)
            {
                case WebsitesConstants.AJAXServices.GetAdvertisement.Actions.getItems:
                    packet.Type = AJAXType.JavaScriptObject;
                    packet.Value = GetItems(id);
                    break;
                case WebsitesConstants.AJAXServices.GetAdvertisement.Actions.getBlocks:
                    packet.Type = AJAXType.JavaScriptObject;
                    packet.Value = GetBlocks(id);
                    break;
                case WebsitesConstants.AJAXServices.GetAdvertisement.Actions.getZones:
                    packet.Type = AJAXType.JavaScriptObject;
                    packet.Value = GetZones(id);
                    break;
                case WebsitesConstants.AJAXServices.GetAdvertisement.Actions.getLayout:
                    packet.Type = AJAXType.JavaScriptObject;
                    packet.Value = GetData(id);
                    break;
                default:
                    WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                    helper.ValueObject.CategoryAlias = categoryAlias;
                    DataTable dt = helper.GetCategoryByAlias();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int categoryId = Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
                        packet.Type = AJAXType.JavaScriptObject;
                        packet.Value = GetData(categoryId);
                    }
                    else
                    {
                        packet.Type = AJAXType.JavaScriptObject;
                        packet.Value = null;
                    }
                    break;
            }
        }

        private static object GetData(int id)
        {
            AdvertisementHelper helper = new AdvertisementHelper(new AdvertisementObject());
            helper.ValueObject.CategoryId = id;
            DataTable dt = helper.GetLayoutByCategoryId();

            Packet p = new Packet();
            p.RawData.Tables.Add(dt.Copy());
            AdvLayout layout = PacketUtils.TranslateTo(p, typeof(AdvLayout)) as AdvLayout;

            if (layout != null)
            {
                layout.zones = GetZones(layout.id);
            }

            return layout;
        }

        private static List<AdvZone> GetZones(int id)
        {
            AdvertisementHelper helper = new AdvertisementHelper(new AdvertisementObject());
            helper.ValueObject.LayoutId = id;
            DataTable dt = helper.GetZonesByLayoutId();

            Packet p = new Packet();
            p.RawData.Tables.Add(dt.Copy());
            object zones = PacketUtils.TranslateTo(p, typeof(AdvZone));

            if (zones == null) return null;

            List<AdvZone> list = new List<AdvZone>();

            if (zones.GetType().Equals(typeof(AdvZone)))
            {
                AdvZone zone = (AdvZone) zones;
                zone.blocks = GetBlocks(zone.id);
                list.Add(zone);
            }
            else
            {
                foreach (object obj in (ArrayList)zones)
                {
                    AdvZone zone = (AdvZone)obj;
                    zone.blocks = GetBlocks(zone.id);
                    list.Add(zone);
                }
            }

            return list;
        }

        private static List<AdvBlock> GetBlocks(int id)
        {
            AdvertisementHelper helper = new AdvertisementHelper(new AdvertisementObject());
            helper.ValueObject.ZoneId = id;
            DataTable dt = helper.GetBlocksByZoneId();

            Packet p = new Packet();
            p.RawData.Tables.Add(dt.Copy());
            object blocks = PacketUtils.TranslateTo(p, typeof(AdvBlock));

            if (blocks == null) return null;

            List<AdvBlock> list = new List<AdvBlock>();

            if (blocks.GetType().Equals(typeof(AdvBlock)))
            {
                AdvBlock block = (AdvBlock) blocks;
                block.items = GetItems(block.id);
                list.Add(block);
            }
            else
            {
                foreach (object obj in (ArrayList)blocks)
                {
                    AdvBlock block = (AdvBlock)obj;
                    block.items = GetItems(block.id);
                    list.Add(block);
                }
            }

            return list;
        }

        private static List<AdvItem> GetItems(int id)
        {
            AdvertisementHelper helper = new AdvertisementHelper(new AdvertisementObject());
            helper.ValueObject.BlockId = id;
            DataTable dt = helper.GetItemsByBlockId();

            Packet p = new Packet();
            p.RawData.Tables.Add(dt.Copy());
            object items = PacketUtils.TranslateTo(p, typeof(AdvItem));

            if (items == null) return null;

            List<AdvItem> list = new List<AdvItem>();

            if (items.GetType().Equals(typeof(AdvItem)))
            {
                AdvItem item = (AdvItem) items;
                list.Add(item);
            }
            else
            {
                foreach (object obj in (ArrayList)items)
                {
                    AdvItem item = (AdvItem)obj;
                    list.Add(item);
                }
            }

            return list;
        }
    }
}