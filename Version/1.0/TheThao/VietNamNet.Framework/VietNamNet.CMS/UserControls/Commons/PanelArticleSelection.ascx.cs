using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Serialization;
using System.ComponentModel;
using Telerik.Web.UI; 
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Components;
using VietNamNet.CMS.DBAccess;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;

namespace VietNamNet.CMS.UserControls.Commons
{
    public partial class PanelArticleSelection : BaseUserControls
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                radDpkPublishFromDate.SelectedDate = Utilities.GetFirstDayOfMonth();
                    radDpkPublishToDate.SelectedDate = DateTime.Now;
                    BindDataToCategory(0);
            }
        }

        private void BindDataToCategory(int categoryId)
        {
            CategoryHelper helper = new CategoryHelper(new Category());
            helper.ValueObject.UserId = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
            cmbCategory.DataSource = helper.GetCategoryByUserId();
            cmbCategory.DataBind();
            cmbCategory.Items.Insert(0, new RadComboBoxItem(string.Empty, "0"));

            if (categoryId > 0) cmbCategory.SelectedValue = categoryId.ToString();
        }

        private string GetArticleEventItemSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", CMSConstants.Session.CMSData.ArticleEventItem, docId);
        }

        public void BindDataToItems()
        {
            BindDataToArticles();
            radGridSelected.DataBind();
        }

        private DataRow GetOrder(DataTable source, int id)
        {
            if (source == null || source.Rows.Count == 0) return null;
            foreach (DataRow row in source.Rows)
            {
                int rowId = Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventItem.FieldName.Id]);
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

        #region GetArticleSearch

        public virtual int ItemIndex()
        {
            return
                Utilities.ParseInt(Utilities.GetConfigKey(Constants.ConfigKey.PageSize)) *
                (Utilities.ParseInt(hidPage.Value) - 1);
        }

        protected DataTable BindSearchingTable()
        {
            DataTable dtSearch = new DataTable(Constants.Paging.Direction.SearchingTableName);
            dtSearch.Columns.Add(Constants.Paging.Direction.IsSearch, typeof(bool));
            dtSearch.Columns.Add(Constants.Paging.Direction.KeyWords, typeof(string));
            dtSearch.Columns.Add(CMSConstants.Paging.Direction.CategoryId, typeof(int));
            dtSearch.Columns.Add(CMSConstants.Paging.Direction.PublishFromDate, typeof(DateTime));
            dtSearch.Columns.Add(CMSConstants.Paging.Direction.PublishToDate, typeof(DateTime));
            DataRow drSearch = dtSearch.NewRow();
            drSearch[Constants.Paging.Direction.IsSearch] = false;
            drSearch[Constants.Paging.Direction.KeyWords] = txtKeyword.Text.Trim();
            drSearch[CMSConstants.Paging.Direction.CategoryId] = Utilities.ParseInt(cmbCategory.SelectedValue);
            drSearch[CMSConstants.Paging.Direction.PublishFromDate] = (radDpkPublishFromDate.SelectedDate != null)
                                                                          ? (DateTime)radDpkPublishFromDate.SelectedDate
                                                                          : Utilities.GetFirstDayOfMonth();
            drSearch[CMSConstants.Paging.Direction.PublishToDate] = (radDpkPublishToDate.SelectedDate != null)
                                                                        ? (DateTime)radDpkPublishToDate.SelectedDate
                                                                        : DateTime.Now;
            dtSearch.Rows.Add(drSearch);
            return dtSearch;
        }

        protected DataTable GetDataSource()
        {
            int pageSize = Utilities.ParseInt(Utilities.GetConfigKey(Constants.ConfigKey.PageSize));
            int page = Utilities.ParseInt(hidPage.Value);
            if (page <= 0) page = 1;

            //Create Packet
            Packet p = new Packet();
            p.ServiceName = CMSConstants.Services.ArticleManager.Name;
            p.Action = CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticleForPopupInsertNews;
            if (Utilities.ParseInt(cmbCategory.SelectedValue) == 0)
            {
                p.Action = CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticleForPopupInsertNewsWithoutCategory;
            }

            //Paging Table
            DataTable dtPaging = new DataTable(Constants.Paging.Direction.PagingTableName);
            dtPaging.Columns.Add(Constants.Paging.Direction.PageIndex, typeof(int));
            dtPaging.Columns.Add(Constants.Paging.Direction.PageSize, typeof(int));
            DataRow drPaging = dtPaging.NewRow();
            drPaging[Constants.Paging.Direction.PageIndex] = page;
            drPaging[Constants.Paging.Direction.PageSize] = pageSize;
            dtPaging.Rows.Add(drPaging);
            p.RawData.Tables.Add(dtPaging);

            //Searching Table
            p.RawData.Tables.Add(BindSearchingTable());

            // Execute
            p = ServiceFacade.Execute(p);
            DataTable t = Utilities.EncodeDatatable(p.RawData.Tables[0]);

            //Get number of page in the paging
            if (p.RawData.Tables.Count < 2) return t;

            int rowCount = Convert.ToInt32(p.RawData.Tables[1].Rows[0][Constants.Paging.Direction.PageCount]);
            int pageCount = rowCount / pageSize;

            if (rowCount % pageSize == 0)
            {
                hidTotalPages.Value = pageCount.ToString();
            }
            else
            {
                hidTotalPages.Value = (pageCount + 1).ToString();
            }

            return t;
        }

        protected void BindValueinDropDownList()
        {
            DataTable dtPageNumber = new DataTable();
            dtPageNumber.Columns.Add(new DataColumn(Constants.Paging.ControlName.ComboBox.ComboText, typeof(string)));
            dtPageNumber.Columns.Add(new DataColumn(Constants.Paging.ControlName.ComboBox.ComboValue, typeof(int)));

            int iCurrentPage = Utilities.ParseInt(hidPage.Value);
            int iTotalPage = Utilities.ParseInt(hidTotalPages.Value);
            if (iTotalPage > 0)
            {
                for (int i = 1; i <= iTotalPage; i++)
                {
                    DataRow dr = dtPageNumber.NewRow();

                    dr[Constants.Paging.ControlName.ComboBox.ComboText] = i.ToString();
                    dr[Constants.Paging.ControlName.ComboBox.ComboValue] = i;

                    dtPageNumber.Rows.Add(dr);
                }

                DataView dvPageNumber = new DataView(dtPageNumber);
                ddlChoiceIndexOfPage.DataSource = dvPageNumber;
                ddlChoiceIndexOfPage.DataTextField = Constants.Paging.ControlName.ComboBox.ComboText;
                ddlChoiceIndexOfPage.DataValueField = Constants.Paging.ControlName.ComboBox.ComboValue;
                ddlChoiceIndexOfPage.DataBind();
                ddlChoiceIndexOfPage.SelectedValue = (iCurrentPage <= iTotalPage)
                                                                  ? iCurrentPage.ToString()
                                                                  : iTotalPage.ToString();
            }
        }

        protected void SetLabelForPagingBar()
        {
            int iCurrentPage = Utilities.ParseInt(hidPage.Value);
            int iTotalPage = Utilities.ParseInt(hidTotalPages.Value);
            // If there is no record to display.
            if (iTotalPage == 0)
            {
                pnlPaging.Visible = false;
            }
            // If there is more than one record to display.
            else
            {
                //Set visible of PagingTable row
                pnlPaging.Visible = true;
                lblCurrentPage.Text = iCurrentPage.ToString();
                lblTotalPage.Text = iTotalPage.ToString();

                lbtnFirst.Visible = ibtnFirst.Visible = lblSeparatorFirst.Visible =
                                                                     lbtnPrev.Visible =
                                                                     ibtnPrev.Visible =
                                                                     lblSeparatorPrev.Visible = (iCurrentPage > 1);

                lbtnNext.Visible = ibtnNext.Visible = lblSeparatorNext.Visible =
                                                                   lbtnLast.Visible =
                                                                   ibtnLast.Visible =
                                                                   lblSeparatorLast.Visible =
                                                                   (iCurrentPage < iTotalPage);
            }
        }

        protected void btnRadFirst_Click(object sender, EventArgs e)
        {
            ViewState[Constants.Paging.Direction.CurrentPage] = 1;

            BindDataToArticles();
        }

        protected void btnRadPrev_Click(object sender, EventArgs e)
        {
            int iCurrentPage = Utilities.ParseInt(hidPage.Value);

            hidPage.Value = (iCurrentPage - 1).ToString();

            BindDataToArticles();
        }

        protected void btnRadNext_Click(object sender, EventArgs e)
        {
            int iCurrentPage = Utilities.ParseInt(hidPage.Value);

            hidPage.Value = (iCurrentPage + 1).ToString();

            BindDataToArticles();
        }

        protected void btnRadLast_Click(object sender, EventArgs e)
        {
            hidPage.Value = hidTotalPages.Value;

            BindDataToArticles();
        }

        protected void btnRadGotoPage_Click(object sender, EventArgs e)
        {
            hidPage.Value = ddlChoiceIndexOfPage.SelectedValue;

            BindDataToArticles();
        }

        protected void BindDataToArticles()
        {
            if (radDpkPublishFromDate.SelectedDate == null) radDpkPublishFromDate.SelectedDate = Utilities.GetFirstDayOfMonth();
            if (radDpkPublishToDate.SelectedDate == null) radDpkPublishToDate.SelectedDate = DateTime.Now;

            radGridDefault.Rebind();
            BindValueinDropDownList();
            SetLabelForPagingBar();
        }

        #endregion

        protected void radGridSelected_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dtItems = (Session[GetArticleEventItemSessionName()] != null)
                                    ? (DataTable)Session[GetArticleEventItemSessionName()]
                                    : ArticleEventItemDAO.GetTemplateTable();
            radGridSelected.DataSource = dtItems.Select("SaveStatus <> 'DELETE'");
        }

        protected void radGridDefault_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            radGridDefault.DataSource = GetDataSource();
        }

        protected void radGridDefault_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (Nulls.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == radGridDefault.ClientID)
                {
                    if ((e.DestDataItem == null)
                        || (e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridSelected.ClientID))
                    {
                        DataTable dtItems = (Session[GetArticleEventItemSessionName()] != null)
                                                ? (DataTable)Session[GetArticleEventItemSessionName()]
                                                : ArticleEventItemDAO.GetTemplateTable();

                        DataTable dtNewSelect = ArticleEventItemDAO.GetTemplateTable();

                        //get id
                        int id = -1;
                        foreach (DataRow row in dtItems.Rows)
                        {
                            int rid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleMedia.FieldName.Id]);
                            if (rid <= id) id = rid - 1;
                        }

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int articleId = Utilities.ParseInt(draggedItem.GetDataKeyValue("Id"));
                            string articleName = draggedItem.GetDataKeyValue("Name").ToString();

                            //check exist
                            bool blnExist = false;
                            foreach (DataRow row in dtItems.Rows)
                            {
                                if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleId]) == articleId)
                                {
                                    //change Status
                                    if (
                                        Utilities.StringCompare(row[CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus],
                                                                Constants.CommonStatus.DELETE))
                                    {
                                        int itemId = Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventItem.FieldName.Id]);
                                        string status = (itemId > 0)
                                                            ? Constants.CommonStatus.UPDATE
                                                            : Constants.CommonStatus.NEW;
                                        row[CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus] = status;
                                        row[CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_At] = DateTime.Now;
                                        row[CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]); ;
                                    }
                                    //mask existed
                                    blnExist = true;
                                    break;
                                }
                            }

                            if (blnExist) continue;

                            //add memberOf
                            DataRow drNew = dtNewSelect.NewRow();
                            drNew[CMSConstants.Entities.ArticleEventItem.FieldName.Id] = id--;
                            drNew[CMSConstants.Entities.ArticleEventItem.FieldName.Ord] = 0;
                            drNew[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleEventId] = 0;
                            drNew[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleId] = articleId;
                            drNew[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleName] = articleName;
                            drNew[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleAuthor] = string.Empty;
                            drNew[CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                            drNew[CMSConstants.Entities.ArticleEventItem.FieldName.Created_At] = DateTime.Now;
                            drNew[CMSConstants.Entities.ArticleEventItem.FieldName.Created_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                            drNew[CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_At] = DateTime.Now;
                            drNew[CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                            dtNewSelect.Rows.Add(drNew);
                        }

                        //get destinationIndex
                        int destinationIndex = 0;

                        if (e.DestDataItem != null)
                        {
                            DataRow order =
                                GetOrder(dtItems, Utilities.ParseInt(e.DestDataItem.GetDataKeyValue("Id")));

                            destinationIndex = (order == null) ? 0 : dtItems.Rows.IndexOf(order);

                            if (e.DropPosition == GridItemDropPosition.Below)
                            {
                                destinationIndex += 1;
                            }
                        }

                        foreach (DataRow row in dtNewSelect.Rows)
                        {
                            dtItems = AddRow(dtItems, row, destinationIndex++);
                        }

                        //Update Media ord
                        for (int i = 0; i < dtItems.Rows.Count; i++)
                        {
                            dtItems.Rows[i][CMSConstants.Entities.ArticleEventItem.FieldName.Ord] = i + 1;
                            if (Nulls.IsNullOrEmpty(dtItems.Rows[i][CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus]))
                            {
                                dtItems.Rows[i][CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus] =
                                    Constants.CommonStatus.UPDATE;
                            }
                            dtItems.Rows[i][CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_At] = DateTime.Now;
                            dtItems.Rows[i][CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        }

                        Session[GetArticleEventItemSessionName()] = dtItems;

                        radGridSelected.Rebind();
                    }
                }
            }
        }

        protected void radGridSelected_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (Nulls.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == radGridSelected.ClientID)
                {
                    //Remove
                    if ((e.DestDataItem == null)
                        || e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridDefault.ClientID)
                    {
                        DataTable dtItems = (Session[GetArticleEventItemSessionName()] != null)
                                                ? (DataTable)Session[GetArticleEventItemSessionName()]
                                                : ArticleEventItemDAO.GetTemplateTable();

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int articleId = Utilities.ParseInt(draggedItem.GetDataKeyValue("ArticleId"));

                            foreach (DataRow row in dtItems.Rows)
                            {
                                if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleId]) == articleId)
                                {
                                    //remove
                                    row[CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                                    row[CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_At] = DateTime.Now;
                                    row[CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                                    //break;
                                    break;
                                }
                            }
                        }

                        Session[GetArticleEventItemSessionName()] = dtItems;

                        radGridSelected.Rebind();
                    }
                    else if (e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridSelected.ClientID)
                    {
                        //reorder items in grid
                        DataTable dtItems = (Session[GetArticleEventItemSessionName()] != null)
                                                ? (DataTable)Session[GetArticleEventItemSessionName()]
                                                : ArticleEventItemDAO.GetTemplateTable();

                        DataTable dtArticleToMove = ArticleEventItemDAO.GetTemplateTable();
                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            DataRow tmpOrder =
                                GetOrder(dtItems, Utilities.ParseInt(draggedItem.GetDataKeyValue("Id")));
                            if (tmpOrder != null) //Move from Media to Temp
                            {
                                dtArticleToMove = AddRow(dtArticleToMove, tmpOrder);
                                dtItems.Rows.Remove(tmpOrder);
                            }
                        }

                        //get destinationIndex
                        DataRow order = GetOrder(dtItems, Utilities.ParseInt(e.DestDataItem.GetDataKeyValue("Id")));
                        if (order == null) return;

                        int destinationIndex = dtItems.Rows.IndexOf(order);

                        if (e.DropPosition == GridItemDropPosition.Below)
                        {
                            destinationIndex += 1;
                        }

                        foreach (DataRow orderToMove in dtArticleToMove.Rows) //Move from Temp to Selected
                        {
                            dtItems = AddRow(dtItems, orderToMove, destinationIndex++);
                        }

                        //Update Media ord
                        for (int i = 0; i < dtItems.Rows.Count; i++)
                        {
                            dtItems.Rows[i][CMSConstants.Entities.ArticleEventItem.FieldName.Ord] = i + 1;
                            if (Nulls.IsNullOrEmpty(dtItems.Rows[i][CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus]))
                            {
                                dtItems.Rows[i][CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus] =
                                    Constants.CommonStatus.UPDATE;
                            }
                            dtItems.Rows[i][CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_At] = DateTime.Now;
                            dtItems.Rows[i][CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        }

                        Session[GetArticleEventItemSessionName()] = dtItems;

                        radGridSelected.Rebind();
                    }
                }
            }
        }

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            BindDataToArticles();
        }

        protected void radGridDefault_ItemCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtItems = (Session[GetArticleEventItemSessionName()] != null)
                                        ? (DataTable)Session[GetArticleEventItemSessionName()]
                                        : ArticleEventItemDAO.GetTemplateTable();

                //get id
                int id = -1;
                foreach (DataRow row in dtItems.Rows)
                {
                    int rid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleMedia.FieldName.Id]);
                    if (rid <= id) id = rid - 1;
                }

                int articleId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                string articleName = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Name"].ToString();

                //check exist
                bool blnExist = false;
                foreach (DataRow row in dtItems.Rows)
                {
                    if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleId]) == articleId)
                    {
                        //change Status
                        if (
                            Utilities.StringCompare(row[CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus],
                                                    Constants.CommonStatus.DELETE))
                        {
                            int itemId = Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventItem.FieldName.Id]);
                            string status = (itemId > 0)
                                                ? Constants.CommonStatus.UPDATE
                                                : Constants.CommonStatus.NEW;
                            row[CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus] = status;
                            row[CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_At] = DateTime.Now;
                            row[CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]); ;
                        }
                        //mask existed
                        blnExist = true;
                        break;
                    }
                }

                if (!blnExist)
                {
                    //add memberOf
                    DataRow drNew = dtItems.NewRow();
                    drNew[CMSConstants.Entities.ArticleEventItem.FieldName.Id] = id;
                    drNew[CMSConstants.Entities.ArticleEventItem.FieldName.Ord] = 0;
                    drNew[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleEventId] = 0;
                    drNew[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleId] = articleId;
                    drNew[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleName] = articleName;
                    drNew[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleAuthor] = string.Empty;
                    drNew[CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                    drNew[CMSConstants.Entities.ArticleEventItem.FieldName.Created_At] = DateTime.Now;
                    drNew[CMSConstants.Entities.ArticleEventItem.FieldName.Created_By] =
                        Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                    drNew[CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_At] = DateTime.Now;
                    drNew[CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_By] =
                        Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                    dtItems.Rows.Add(drNew);
                }

                Session[GetArticleEventItemSessionName()] = dtItems;

                radGridSelected.Rebind();

                e.Canceled = true;
            }
        }

        protected void radGridSelected_ItemCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtItems = (Session[GetArticleEventItemSessionName()] != null)
                                        ? (DataTable)Session[GetArticleEventItemSessionName()]
                                        : ArticleEventItemDAO.GetTemplateTable();

                int articleId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ArticleId"]);

                foreach (DataRow row in dtItems.Rows)
                {
                    if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleId]) == articleId)
                    {
                        //remove
                        row[CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                        row[CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_At] = DateTime.Now;
                        row[CMSConstants.Entities.ArticleEventItem.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        //break;
                        break;
                    }
                }

                Session[GetArticleEventItemSessionName()] = dtItems;

                radGridSelected.Rebind();

                e.Canceled = true;
            }
        }
    }
}