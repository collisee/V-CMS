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
    public partial class PanelAdvItem : UserControl
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
                BindDataToAdvertisementItems();

                if (EditOption == 0)
                {
                    pnlAdvertisementItems.Visible = false;
                    pnlBlockItem.CssClass = "pd10";
                    radGridBlockItem.ClientSettings.AllowRowsDragDrop = false;
                    radGridBlockItem.ClientSettings.ClientEvents.OnRowDropping = string.Empty;
                    radGridBlockItem.ClientSettings.ClientEvents.OnRowDblClick = string.Empty;
                }
            }
        }

        private string GetBlockItemSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", AdvertisementConstants.Session.AdvertisementData.Items, docId);
        }

        private void BindDataToAdvertisementItems()
        {
            AdvertisementItemHelper helper = new AdvertisementItemHelper(new AdvertisementItem());
            Session[AdvertisementConstants.Session.AdvertisementData.NotBlockItem] = Utilities.EncodeDatatable(helper.ListAll());
        }

        private DataRow GetOrder(DataTable source, int id)
        {
            if (source == null || source.Rows.Count == 0) return null;
            foreach (DataRow row in source.Rows)
            {
                int rowId = Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Id]);
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

        protected void radGridAdvertisementItems_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            radGridAdvertisementItems.DataSource = Session[AdvertisementConstants.Session.AdvertisementData.NotBlockItem];
        }

        protected void radGridBlockItem_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dtBlockItem = (Session[GetBlockItemSessionName()] != null)
                                      ? (DataTable)Session[GetBlockItemSessionName()]
                                      : AdvertisementBlockItemDAO.GetTemplateTable();
            radGridBlockItem.DataSource = dtBlockItem.Select("SaveStatus <> 'DELETE'");
        }

        protected void radGridAdvertisementItems_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (Nulls.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == radGridAdvertisementItems.ClientID)
                {
                    //if ((e.DestDataItem == null && checkDataTableEmpty(Session[GetBlockItemSessionName()])) 
                    if ((e.DestDataItem == null)
                        || e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridBlockItem.ClientID)
                    {
                        DataTable dtBlockItem = (Session[GetBlockItemSessionName()] == null)
                                                  ? AdvertisementBlockItemDAO.GetTemplateTable()
                                                  : (DataTable)Session[GetBlockItemSessionName()];


                        DataTable dtNewSelect = AdvertisementBlockItemDAO.GetTemplateTable();

                        //get id
                        int id = -1;
                        foreach (DataRow row in dtBlockItem.Rows)
                        {
                            int rid = Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Id]);
                            if (rid <= id) id = rid - 1;
                        }
                        
                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int itmId = Utilities.ParseInt(draggedItem.GetDataKeyValue("Id"));
                            string itmName = draggedItem.GetDataKeyValue("Name").ToString();

                            //check exist
                            bool blnExist = false;
                            foreach (DataRow row in dtBlockItem.Rows)
                            {
                                if (Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.ItemId]) ==
                                    itmId)
                                {
                                    //change Status
                                    if (
                                        Utilities.StringCompare(
                                            row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus],
                                            Constants.CommonStatus.DELETE))
                                    {
                                        int itemId =
                                            Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Id]);
                                        string status = (itemId > 0)
                                                            ? Constants.CommonStatus.UPDATE
                                                            : Constants.CommonStatus.NEW;
                                        row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus] = status;
                                        row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Last_Modified_At] =
                                            DateTime.Now;
                                        row[
                                            AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Last_Modified_By] =
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
                            drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Id] = id--;
                            drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Ord] = 0;
                            drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.BlockId] = 0;
                            drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.ItemId] = itmId;
                            drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.ItemName] = itmName;
                            drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Created_At] = DateTime.Now;
                            drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Created_By] =
                                Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                            drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Last_Modified_At] = DateTime.Now;
                            drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Last_Modified_By] =
                                Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                            drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus] =
                                Constants.CommonStatus.NEW;
                            dtNewSelect.Rows.Add(drNew);
                        }

                        //get destinationIndex
                        int destinationIndex = 0;

                        if (e.DestDataItem != null)
                        {
                            DataRow order =
                                GetOrder(dtBlockItem, Utilities.ParseInt(e.DestDataItem.GetDataKeyValue("Id")));

                            destinationIndex = (order == null) ? 0 : dtBlockItem.Rows.IndexOf(order);

                            if (e.DropPosition == GridItemDropPosition.Below)
                            {
                                destinationIndex += 1;
                            }
                        }

                        foreach (DataRow row in dtNewSelect.Rows)
                        {
                            dtBlockItem = AddRow(dtBlockItem, row, destinationIndex++);
                        }

                        //Update Item ord
                        for (int i = 0; i < dtBlockItem.Rows.Count; i++)
                        {
                            dtBlockItem.Rows[i][AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Ord] = i + 1;
                            if (Nulls.IsNullOrEmpty(dtBlockItem.Rows[i][AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus]))
                            {
                                dtBlockItem.Rows[i][AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus] =
                                    Constants.CommonStatus.UPDATE;
                            }
                            dtBlockItem.Rows[i][AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Last_Modified_At] = DateTime.Now;
                            dtBlockItem.Rows[i][AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        }

                        Session[GetBlockItemSessionName()] = dtBlockItem;

                        radGridBlockItem.Rebind();
                    }
                }
            }
        }

        protected void radGridBlockItem_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (Nulls.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == radGridBlockItem.ClientID)
                {
                    //if ((e.DestDataItem == null && checkDataTableEmpty(ViewState[AdvertisementConstants.ViewState.SystemData.NotBlockItem]))
                    if ((e.DestDataItem == null)
                        || e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridAdvertisementItems.ClientID)
                    {
                        DataTable dtBlockItem = (Session[GetBlockItemSessionName()] == null)
                                                    ? AdvertisementBlockItemDAO.GetTemplateTable()
                                                    : (DataTable) Session[GetBlockItemSessionName()];

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int itmId = Utilities.ParseInt(draggedItem.GetDataKeyValue("ItemId"));

                            foreach (DataRow row in dtBlockItem.Rows)
                            {
                                if (
                                    Utilities.ParseInt(
                                        row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.ItemId]) ==
                                    itmId)
                                {
                                    //remove item
                                    row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus] =
                                        Constants.CommonStatus.DELETE;
                                    //break;
                                    break;
                                }
                            }
                        }

                        Session[GetBlockItemSessionName()] = dtBlockItem;

                        radGridBlockItem.Rebind();
                    }
                    else if (e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridBlockItem.ClientID)
                    {
                        //reorder items in grid
                        DataTable dtBlockItem = (Session[GetBlockItemSessionName()] == null)
                                                    ? AdvertisementBlockItemDAO.GetTemplateTable()
                                                    : (DataTable) Session[GetBlockItemSessionName()];

                        DataTable dtItemToMove = AdvertisementBlockItemDAO.GetTemplateTable();
                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            DataRow tmpOrder =
                                GetOrder(dtBlockItem, Utilities.ParseInt(draggedItem.GetDataKeyValue("Id")));
                            if (tmpOrder != null) //Move from Item to Temp
                            {
                                dtItemToMove = AddRow(dtItemToMove, tmpOrder);
                                dtBlockItem.Rows.Remove(tmpOrder);
                            }
                        }

                        //get destinationIndex
                        DataRow order = GetOrder(dtBlockItem, Utilities.ParseInt(e.DestDataItem.GetDataKeyValue("Id")));
                        if (order == null) return;

                        int destinationIndex = dtBlockItem.Rows.IndexOf(order);

                        if (e.DropPosition == GridItemDropPosition.Below)
                        {
                            destinationIndex += 1;
                        }

                        foreach (DataRow orderToMove in dtItemToMove.Rows) //Move from Temp to Selected
                        {
                            dtBlockItem = AddRow(dtBlockItem, orderToMove, destinationIndex++);
                        }

                        //Update Item ord
                        for (int i = 0; i < dtBlockItem.Rows.Count; i++)
                        {
                            dtBlockItem.Rows[i][AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Ord] = i + 1;
                            if (
                                Nulls.IsNullOrEmpty(
                                    dtBlockItem.Rows[i][AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus]))
                            {
                                dtBlockItem.Rows[i][AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus] =
                                    Constants.CommonStatus.UPDATE;
                            }
                            dtBlockItem.Rows[i][AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Last_Modified_At] =
                                DateTime.Now;
                            dtBlockItem.Rows[i][AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Last_Modified_By] =
                                Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        }

                        Session[GetBlockItemSessionName()] = dtBlockItem;

                        radGridBlockItem.Rebind();
                    }
                }
            }
        }

        protected void radGridBlockItem_ItemCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtBlockItem = (Session[GetBlockItemSessionName()] == null)
                                          ? AdvertisementBlockItemDAO.GetTemplateTable()
                                          : (DataTable)Session[GetBlockItemSessionName()];

                int itmId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ItemId"]);

                foreach (DataRow row in dtBlockItem.Rows)
                {
                    if (Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.ItemId]) == itmId)
                    {
                        //remove item
                        row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                        //break;
                        break;
                    }
                }

                Session[GetBlockItemSessionName()] = dtBlockItem;

                radGridBlockItem.Rebind();

                e.Canceled = true;
            }
        }

        protected void radGridAdvertisementItems_ItemCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtBlockItem = (Session[GetBlockItemSessionName()] == null)
                                          ? AdvertisementBlockItemDAO.GetTemplateTable()
                                          : (DataTable)Session[GetBlockItemSessionName()];

                //get id
                int id = -1;
                foreach (DataRow row in dtBlockItem.Rows)
                {
                    int rid = Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Id]);
                    if (rid <= id) id = rid - 1;
                }

                int itmId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                string itmName = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Name"].ToString();

                //check exist
                bool blnExist = false;
                foreach (DataRow row in dtBlockItem.Rows)
                {
                    if (Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.ItemId]) == itmId)
                    {
                        //change Status
                        if (
                            Utilities.StringCompare(row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus],
                                                    Constants.CommonStatus.DELETE))
                        {
                            int itemId = Utilities.ParseInt(row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Id]);
                            string status = (itemId > 0)
                                                ? Constants.CommonStatus.UPDATE
                                                : Constants.CommonStatus.NEW;
                            row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus] = status;
                            row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Last_Modified_At] = DateTime.Now;
                            row[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Last_Modified_By] =
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
                    DataRow drNew = dtBlockItem.NewRow();
                    drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Id] = id;
                    drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Ord] = dtBlockItem.Rows.Count + 1;
                    drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.BlockId] = 0;
                    drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.ItemId] = itmId;
                    drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.ItemName] = itmName;
                    drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Created_At] = DateTime.Now;
                    drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Created_By] =
                        Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                    drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Last_Modified_At] = DateTime.Now;
                    drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.Last_Modified_By] =
                        Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                    drNew[AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                    dtBlockItem.Rows.Add(drNew);
                }

                Session[GetBlockItemSessionName()] = dtBlockItem;

                radGridBlockItem.Rebind();

                e.Canceled = true;
            }
        }
    }
}