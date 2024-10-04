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
    public partial class PanelAdvBlock : UserControl
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
                BindDataToAdvertisementBlocks();

                if (EditOption == 0)
                {
                    pnlAdvertisementBlocks.Visible = false;
                    pnlZoneBlock.CssClass = "pd10";
                    radGridZoneBlock.ClientSettings.AllowRowsDragDrop = false;
                    radGridZoneBlock.ClientSettings.ClientEvents.OnRowDropping = string.Empty;
                    radGridZoneBlock.ClientSettings.ClientEvents.OnRowDblClick = string.Empty;
                }
            }
        }

        private string GetZoneBlockSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", AdvertisementConstants.Session.AdvertisementData.Blocks, docId);
        }

        private void BindDataToAdvertisementBlocks()
        {
            AdvertisementBlockHelper helper = new AdvertisementBlockHelper(new AdvertisementBlock());
            Session[AdvertisementConstants.Session.AdvertisementData.NotZoneBlock] = Utilities.EncodeDatatable(helper.ListAll());
        }

        private DataRow GetOrder(DataTable source, int id)
        {
            if (source == null || source.Rows.Count == 0) return null;
            foreach (DataRow row in source.Rows)
            {
                int rowId = Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Id]);
                if (rowId == id) return row;
            }
            return null;
        }

        private DataTable AddRow(DataTable source, DataRow row)
        {
            if (source == null || row == null) return source;
            DataRow newRow = source.NewRow();
            foreach (DataColumn col in source.Columns)
            {
                if (row.Table.Columns.Contains(col.ColumnName))
                {
                    newRow[col.ColumnName] = row[col.ColumnName];
                }
            }
            source.Rows.Add(newRow);

            return source;
        }

        private DataTable AddRow(DataTable source, DataRow row, int pos)
        {
            if (source == null || row == null) return source;
            DataRow newRow = source.NewRow();
            foreach (DataColumn col in source.Columns)
            {
                if (row.Table.Columns.Contains(col.ColumnName))
                {
                    newRow[col.ColumnName] = row[col.ColumnName];
                }
            }
            source.Rows.InsertAt(newRow, (pos < 0) ? 0 : pos);

            return source;
        }

        protected void radGridAdvertisementBlocks_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            radGridAdvertisementBlocks.DataSource = Session[AdvertisementConstants.Session.AdvertisementData.NotZoneBlock];
        }

        protected void radGridZoneBlock_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dtZoneBlock = (Session[GetZoneBlockSessionName()] != null)
                                      ? (DataTable)Session[GetZoneBlockSessionName()]
                                      : AdvertisementZoneBlockDAO.GetTemplateTable();
            radGridZoneBlock.DataSource = dtZoneBlock.Select("SaveStatus <> 'DELETE'");
        }

        protected void radGridAdvertisementBlocks_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (Nulls.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == radGridAdvertisementBlocks.ClientID)
                {
                    //if ((e.DestDataItem == null && checkDataTableEmpty(Session[GetZoneBlockSessionName()])) 
                    if ((e.DestDataItem == null)
                        || e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridZoneBlock.ClientID)
                    {
                        DataTable dtZoneBlock = (Session[GetZoneBlockSessionName()] == null)
                                                  ? AdvertisementZoneBlockDAO.GetTemplateTable()
                                                  : (DataTable)Session[GetZoneBlockSessionName()];


                        DataTable dtNewSelect = AdvertisementZoneBlockDAO.GetTemplateTable();

                        //get id
                        int id = -1;
                        foreach (DataRow row in dtZoneBlock.Rows)
                        {
                            int rid = Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Id]);
                            if (rid <= id) id = rid - 1;
                        }

                        foreach (GridDataItem draggedBlock in e.DraggedItems)
                        {
                            int blockId = Utilities.ParseInt(draggedBlock.GetDataKeyValue("Id"));
                            string blockName = draggedBlock.GetDataKeyValue("Name").ToString();

                            //check exist
                            bool blnExist = false;
                            foreach (DataRow row in dtZoneBlock.Rows)
                            {
                                if (Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.BlockId]) ==
                                    blockId)
                                {
                                    //change Status
                                    if (
                                        Utilities.StringCompare(
                                            row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus],
                                            Constants.CommonStatus.DELETE))
                                    {
                                        int itemId =
                                            Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Id]);
                                        string status = (itemId > 0)
                                                            ? Constants.CommonStatus.UPDATE
                                                            : Constants.CommonStatus.NEW;
                                        row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus] = status;
                                        row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Last_Modified_At] =
                                            DateTime.Now;
                                        row[
                                            AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Last_Modified_By] =
                                            Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                                    }
                                    //mask existed
                                    blnExist = true;
                                    break;
                                }
                            }

                            if (blnExist) continue;

                            //add item
                            DataRow drNew = dtNewSelect.NewRow();
                            drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Id] = id--;
                            drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Ord] = 0;
                            drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.ZoneId] = 0;
                            drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.BlockId] = blockId;
                            drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.BlockName] = blockName;
                            drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Created_At] = DateTime.Now;
                            drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Created_By] =
                                Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                            drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Last_Modified_At] = DateTime.Now;
                            drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Last_Modified_By] =
                                Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                            drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus] =
                                Constants.CommonStatus.NEW;
                            dtNewSelect.Rows.Add(drNew);
                        }

                        //get destinationIndex
                        int destinationIndex = 0;

                        if (e.DestDataItem != null)
                        {
                            DataRow order =
                                GetOrder(dtZoneBlock, Utilities.ParseInt(e.DestDataItem.GetDataKeyValue("Id")));

                            destinationIndex = (order == null) ? 0 : dtZoneBlock.Rows.IndexOf(order);

                            if (e.DropPosition == GridItemDropPosition.Below)
                            {
                                destinationIndex += 1;
                            }
                        }

                        foreach (DataRow row in dtNewSelect.Rows)
                        {
                            dtZoneBlock = AddRow(dtZoneBlock, row, destinationIndex++);
                        }

                        //Update Block ord
                        for (int i = 0; i < dtZoneBlock.Rows.Count; i++)
                        {
                            dtZoneBlock.Rows[i][AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Ord] = i + 1;
                            if (Nulls.IsNullOrEmpty(dtZoneBlock.Rows[i][AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus]))
                            {
                                dtZoneBlock.Rows[i][AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus] =
                                    Constants.CommonStatus.UPDATE;
                            }
                            dtZoneBlock.Rows[i][AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Last_Modified_At] = DateTime.Now;
                            dtZoneBlock.Rows[i][AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        }

                        Session[GetZoneBlockSessionName()] = dtZoneBlock;

                        radGridZoneBlock.Rebind();
                    }
                }
            }
        }

        protected void radGridZoneBlock_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (Nulls.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == radGridZoneBlock.ClientID)
                {
                    //if ((e.DestDataItem == null && checkDataTableEmpty(ViewState[AdvertisementConstants.ViewState.SystemData.NotZoneBlock]))
                    if ((e.DestDataItem == null)
                        || e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridAdvertisementBlocks.ClientID)
                    {
                        DataTable dtZoneBlock = (Session[GetZoneBlockSessionName()] == null)
                                                    ? AdvertisementZoneBlockDAO.GetTemplateTable()
                                                    : (DataTable)Session[GetZoneBlockSessionName()];

                        foreach (GridDataItem draggedBlock in e.DraggedItems)
                        {
                            int blockId = Utilities.ParseInt(draggedBlock.GetDataKeyValue("BlockId"));

                            foreach (DataRow row in dtZoneBlock.Rows)
                            {
                                if (
                                    Utilities.ParseInt(
                                        row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.BlockId]) ==
                                    blockId)
                                {
                                    //remove item
                                    row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus] =
                                        Constants.CommonStatus.DELETE;
                                    //break;
                                    break;
                                }
                            }
                        }

                        Session[GetZoneBlockSessionName()] = dtZoneBlock;

                        radGridZoneBlock.Rebind();
                    }
                    else if (e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridZoneBlock.ClientID)
                    {
                        //reorder items in grid
                        DataTable dtZoneBlock = (Session[GetZoneBlockSessionName()] == null)
                                                    ? AdvertisementZoneBlockDAO.GetTemplateTable()
                                                    : (DataTable)Session[GetZoneBlockSessionName()];

                        DataTable dtBlockToMove = AdvertisementZoneBlockDAO.GetTemplateTable();
                        foreach (GridDataItem draggedBlock in e.DraggedItems)
                        {
                            DataRow tmpOrder =
                                GetOrder(dtZoneBlock, Utilities.ParseInt(draggedBlock.GetDataKeyValue("Id")));
                            if (tmpOrder != null) //Move from Block to Temp
                            {
                                dtBlockToMove = AddRow(dtBlockToMove, tmpOrder);
                                dtZoneBlock.Rows.Remove(tmpOrder);
                            }
                        }

                        //get destinationIndex
                        DataRow order = GetOrder(dtZoneBlock, Utilities.ParseInt(e.DestDataItem.GetDataKeyValue("Id")));
                        if (order == null) return;

                        int destinationIndex = dtZoneBlock.Rows.IndexOf(order);

                        if (e.DropPosition == GridItemDropPosition.Below)
                        {
                            destinationIndex += 1;
                        }

                        foreach (DataRow orderToMove in dtBlockToMove.Rows) //Move from Temp to Selected
                        {
                            dtZoneBlock = AddRow(dtZoneBlock, orderToMove, destinationIndex++);
                        }

                        //Update Block ord
                        for (int i = 0; i < dtZoneBlock.Rows.Count; i++)
                        {
                            dtZoneBlock.Rows[i][AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Ord] = i + 1;
                            if (
                                Nulls.IsNullOrEmpty(
                                    dtZoneBlock.Rows[i][AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus]))
                            {
                                dtZoneBlock.Rows[i][AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus] =
                                    Constants.CommonStatus.UPDATE;
                            }
                            dtZoneBlock.Rows[i][AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Last_Modified_At] =
                                DateTime.Now;
                            dtZoneBlock.Rows[i][AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Last_Modified_By] =
                                Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        }

                        Session[GetZoneBlockSessionName()] = dtZoneBlock;

                        radGridZoneBlock.Rebind();
                    }
                }
            }
        }

        protected void radGridZoneBlock_BlockCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtZoneBlock = (Session[GetZoneBlockSessionName()] == null)
                                          ? AdvertisementZoneBlockDAO.GetTemplateTable()
                                          : (DataTable)Session[GetZoneBlockSessionName()];

                int blockId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["BlockId"]);

                foreach (DataRow row in dtZoneBlock.Rows)
                {
                    if (Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.BlockId]) == blockId)
                    {
                        //remove item
                        row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                        //break;
                        break;
                    }
                }

                Session[GetZoneBlockSessionName()] = dtZoneBlock;

                radGridZoneBlock.Rebind();

                e.Canceled = true;
            }
        }

        protected void radGridAdvertisementBlocks_BlockCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtZoneBlock = (Session[GetZoneBlockSessionName()] == null)
                                          ? AdvertisementZoneBlockDAO.GetTemplateTable()
                                          : (DataTable)Session[GetZoneBlockSessionName()];

                //get id
                int id = -1;
                foreach (DataRow row in dtZoneBlock.Rows)
                {
                    int rid = Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Id]);
                    if (rid <= id) id = rid - 1;
                }

                int blockId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                string blockName = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Name"].ToString();

                //check exist
                bool blnExist = false;
                foreach (DataRow row in dtZoneBlock.Rows)
                {
                    if (Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.BlockId]) == blockId)
                    {
                        //change Status
                        if (
                            Utilities.StringCompare(row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus],
                                                    Constants.CommonStatus.DELETE))
                        {
                            int itemId = Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Id]);
                            string status = (itemId > 0)
                                                ? Constants.CommonStatus.UPDATE
                                                : Constants.CommonStatus.NEW;
                            row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus] = status;
                            row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Last_Modified_At] = DateTime.Now;
                            row[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Last_Modified_By] =
                                Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        }
                        //mask existed
                        blnExist = true;
                        break;
                    }
                }

                if (!blnExist)
                {
                    //add item
                    DataRow drNew = dtZoneBlock.NewRow();
                    drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Id] = id;
                    drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Ord] = dtZoneBlock.Rows.Count + 1;
                    drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.ZoneId] = 0;
                    drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.BlockId] = blockId;
                    drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.BlockName] = blockName;
                    drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Created_At] = DateTime.Now;
                    drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Created_By] =
                        Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                    drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Last_Modified_At] = DateTime.Now;
                    drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.Last_Modified_By] =
                        Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                    drNew[AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                    dtZoneBlock.Rows.Add(drNew);
                }

                Session[GetZoneBlockSessionName()] = dtZoneBlock;

                radGridZoneBlock.Rebind();

                e.Canceled = true;
            }
        }
    }
}