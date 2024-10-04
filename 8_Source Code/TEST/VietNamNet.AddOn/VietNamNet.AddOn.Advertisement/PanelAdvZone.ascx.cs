using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using Telerik.Web.UI;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.AddOn.Advertisement.DBAccess;
using VietNamNet.AddOn.Advertisement.Presentation;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Advertisement
{
    public partial class PanelAdvZone : UserControl
    {
        [Description("Edit Option")]
        [Browsable(true)]
        [DefaultSettingValue("1")]
        public int EditOption
        {
            get { return Utilities.ParseInt(ViewState[AdvertisementConstants.ViewState.EditOption]); }
            set { ViewState[AdvertisementConstants.ViewState.EditOption] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataToAdvertisementZones();

                if (EditOption == 0)
                {
                    pnlAdvertisementZones.Visible = false;
                    pnlLayoutZone.CssClass = "pd10";
                    radGridLayoutZone.ClientSettings.AllowRowsDragDrop = false;
                    radGridLayoutZone.ClientSettings.ClientEvents.OnRowDropping = string.Empty;
                    radGridLayoutZone.ClientSettings.ClientEvents.OnRowDblClick = string.Empty;
                }
            }
        }

        private string GetLayoutZoneSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", AdvertisementConstants.Session.AdvertisementData.Zones, docId);
        }

        private void BindDataToAdvertisementZones()
        {
            AdvertisementZoneHelper helper = new AdvertisementZoneHelper(new AdvertisementZone());
            Session[AdvertisementConstants.Session.AdvertisementData.NotLayoutZone] = Utilities.EncodeDatatable(helper.ListAll());
        }

        protected void radGridAdvertisementZones_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            radGridAdvertisementZones.DataSource = Session[AdvertisementConstants.Session.AdvertisementData.NotLayoutZone];
        }

        protected void radGridLayoutZone_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dtLayoutZone = (Session[GetLayoutZoneSessionName()] != null)
                                      ? (DataTable)Session[GetLayoutZoneSessionName()]
                                      : AdvertisementLayoutZoneDAO.GetTemplateTable();
            radGridLayoutZone.DataSource = dtLayoutZone.Select("SaveStatus <> 'DELETE'");
        }

        protected void radGridAdvertisementZones_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (Nulls.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == radGridAdvertisementZones.ClientID)
                {
                    //if ((e.DestDataItem == null && checkDataTableEmpty(Session[GetLayoutZoneSessionName()])) 
                    if ((e.DestDataItem == null)
                        || e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridLayoutZone.ClientID)
                    {
                        DataTable dtLayoutZone = (Session[GetLayoutZoneSessionName()] == null)
                                                  ? AdvertisementLayoutZoneDAO.GetTemplateTable()
                                                  : (DataTable)Session[GetLayoutZoneSessionName()];

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int zoneId = Utilities.ParseInt(draggedItem.GetDataKeyValue("Id"));
                            string zoneName = draggedItem.GetDataKeyValue("Name").ToString();

                            //check exist
                            bool blnExist = false;
                            foreach (DataRow row in dtLayoutZone.Rows)
                            {
                                if (Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.ZoneId]) ==
                                    zoneId)
                                {
                                    //change Status
                                    if (
                                        Utilities.StringCompare(
                                            row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.SaveStatus],
                                            Constants.CommonStatus.DELETE))
                                    {
                                        int id =
                                            Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Id]);
                                        string status = (id > 0)
                                                            ? Constants.CommonStatus.UPDATE
                                                            : Constants.CommonStatus.NEW;
                                        row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.SaveStatus] = status;
                                        row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Last_Modified_At] =
                                            DateTime.Now;
                                        row[
                                            AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Last_Modified_By] =
                                            Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                                    }
                                    //mask existed
                                    blnExist = true;
                                    break;
                                }
                            }

                            if (blnExist) continue;

                            //add zone
                            DataRow drNew = dtLayoutZone.NewRow();
                            drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Id] = 0;
                            drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.LayoutId] = 0;
                            drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.ZoneId] = zoneId;
                            drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.ZoneName] = zoneName;
                            drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Created_At] = DateTime.Now;
                            drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Created_By] =
                                Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                            drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Last_Modified_At] = DateTime.Now;
                            drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Last_Modified_By] =
                                Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                            drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.SaveStatus] =
                                Constants.CommonStatus.NEW;
                            dtLayoutZone.Rows.Add(drNew);
                        }

                        Session[GetLayoutZoneSessionName()] = dtLayoutZone;

                        radGridLayoutZone.Rebind();
                    }
                }
            }
        }

        protected void radGridLayoutZone_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (Nulls.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == radGridLayoutZone.ClientID)
                {
                    //if ((e.DestDataItem == null && checkDataTableEmpty(ViewState[AdvertisementConstants.ViewState.SystemData.NotLayoutZone]))
                    if ((e.DestDataItem == null)
                        || e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridAdvertisementZones.ClientID)
                    {
                        DataTable dtLayoutZone = (Session[GetLayoutZoneSessionName()] == null)
                                                  ? AdvertisementLayoutZoneDAO.GetTemplateTable()
                                                  : (DataTable)Session[GetLayoutZoneSessionName()];

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int zoneId = Utilities.ParseInt(draggedItem.GetDataKeyValue("ZoneId"));

                            foreach (DataRow row in dtLayoutZone.Rows)
                            {
                                if (Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.ZoneId]) ==
                                    zoneId)
                                {
                                    //remove zone
                                    row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.SaveStatus] =
                                        Constants.CommonStatus.DELETE;
                                    //break;
                                    break;
                                }
                            }
                        }

                        Session[GetLayoutZoneSessionName()] = dtLayoutZone;

                        radGridLayoutZone.Rebind();
                    }
                }
            }
        }

        protected void radGridLayoutZone_ItemCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtLayoutZone = (Session[GetLayoutZoneSessionName()] == null)
                                          ? AdvertisementLayoutZoneDAO.GetTemplateTable()
                                          : (DataTable)Session[GetLayoutZoneSessionName()];

                int zoneId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ZoneId"]);

                foreach (DataRow row in dtLayoutZone.Rows)
                {
                    if (Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.ZoneId]) == zoneId)
                    {
                        //remove zone
                        row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                        //break;
                        break;
                    }
                }

                Session[GetLayoutZoneSessionName()] = dtLayoutZone;

                radGridLayoutZone.Rebind();

                e.Canceled = true;
            }
        }

        protected void radGridAdvertisementZones_ItemCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtLayoutZone = (Session[GetLayoutZoneSessionName()] == null)
                                          ? AdvertisementLayoutZoneDAO.GetTemplateTable()
                                          : (DataTable)Session[GetLayoutZoneSessionName()];

                int zoneId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                string zoneName = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Name"].ToString();

                //check exist
                bool blnExist = false;
                foreach (DataRow row in dtLayoutZone.Rows)
                {
                    if (Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.ZoneId]) == zoneId)
                    {
                        //change Status
                        if (
                            Utilities.StringCompare(row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.SaveStatus],
                                                    Constants.CommonStatus.DELETE))
                        {
                            int id = Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Id]);
                            string status = (id > 0)
                                                ? Constants.CommonStatus.UPDATE
                                                : Constants.CommonStatus.NEW;
                            row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.SaveStatus] = status;
                            row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Last_Modified_At] = DateTime.Now;
                            row[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Last_Modified_By] =
                                Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        }
                        //mask existed
                        blnExist = true;
                        break;
                    }
                }

                if (!blnExist)
                {
                    //add zone
                    DataRow drNew = dtLayoutZone.NewRow();
                    drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Id] = 0;
                    drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.LayoutId] = 0;
                    drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.ZoneId] = zoneId;
                    drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.ZoneName] = zoneName;
                    drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Created_At] = DateTime.Now;
                    drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Created_By] =
                        Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                    drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Last_Modified_At] = DateTime.Now;
                    drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.Last_Modified_By] =
                        Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                    drNew[AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                    dtLayoutZone.Rows.Add(drNew);
                }

                Session[GetLayoutZoneSessionName()] = dtLayoutZone;

                radGridLayoutZone.Rebind();

                e.Canceled = true;
            }
        }
    }
}