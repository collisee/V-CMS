using System;
using System.Data;
using System.Web.UI;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.DBAccess;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Categories
{
    public partial class ManageCategory : ArticleBasePage
    {
        #region Handler Method

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isPublish)
            {
                Utilities.NoRightToAccess();
            }

            //check category
            int categoryId = Utilities.ParseInt(Request.Params[CMSConstants.ParameterName.CATEGORY_ID]);
            if (categoryId == 0)
            {
                Response.Redirect(CMSConstants.FormNames.CMS.Categories.SelectCategory);
            }

            bool isMyCategory = CMSUtils.GetCategoryPolicy(UserId, categoryId);

            if (!(isCategory && isMyCategory) && !isSystem)
            {
                Utilities.NoRightToAccess();
            }
            
            if (!IsPostBack)
            {
                //PublishDate
                RadToolBarItem radPublishDate = radToolBarDefault.FindItemByValue("searchPublishDatePickerButton");
                if (radPublishDate != null)
                {
                    RadDatePicker dpkFromDate = (RadDatePicker)radPublishDate.FindControl("radDpkPublishFromDate");
                    if (dpkFromDate != null)
                    {
                        dpkFromDate.SelectedDate =
                            !Nulls.IsNullOrEmpty(Request.Params[CMSConstants.ParameterName.PUBLISH_FROM_DATE])
                                ? Utilities.ConvertLocaltoGlobalDateTime(
                                      Request.Params[CMSConstants.ParameterName.PUBLISH_FROM_DATE], Utilities.GetFirstDayOfMonth())
                                : Utilities.GetFirstDayOfMonth();
                    }
                    RadDatePicker dpkToDate = (RadDatePicker)radPublishDate.FindControl("radDpkPublishToDate");
                    if (dpkToDate != null)
                    {
                        dpkToDate.SelectedDate =
                            !Nulls.IsNullOrEmpty(Request.Params[CMSConstants.ParameterName.PUBLISH_TO_DATE])
                                ? Utilities.ConvertLocaltoGlobalDateTime(
                                      Request.Params[CMSConstants.ParameterName.PUBLISH_TO_DATE], DateTime.Now)
                                : DateTime.Now;
                    }
                }

                //CategoryName
                GetCategoryInfo(categoryId);
                Session[GetArticleCategoryItemsSessionName()] = GetArticlesByCategoryId(categoryId);

                //Bind data to articles
                BindDataToArticles();
                radGridSelected.DataBind();

                //logging
                SystemLogging.Info("Manage Category", string.Format("{0} - {1}", categoryId, lblCategoryName.Text));
            }
            else
            {
                lblMessage.Visible = false;
            }
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            int categoryId = Utilities.ParseInt(Request.Params[CMSConstants.ParameterName.CATEGORY_ID]);

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.Search:
                    BindDataToArticles();
                    break;
                case Constants.CommandNames.Optimize:
                    //logging
                    SystemLogging.Info("Optimize Category", string.Format("{0} - {1}", categoryId, lblCategoryName.Text));

                    //Optimize
                    ArticleCategoryHelper helper = new ArticleCategoryHelper(new ArticleCategory());
                    helper.ValueObject.CategoryId = categoryId;
                    helper.OptimizeArticleCategory();
                    //Rebind
                    Session[GetArticleCategoryItemsSessionName()] = GetArticlesByCategoryId(categoryId);
                    radGridSelected.Rebind();
                    break;
                case Constants.CommandNames.Save:
                    //logging
                    SystemLogging.Info("Save Category", string.Format("{0} - {1}", categoryId, lblCategoryName.Text));

                    DoSave();
                    break;
                default:
                    break;
            }
        }

        protected void radGridSelected_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dtItems = (Session[GetArticleCategoryItemsSessionName()] != null)
                                    ? (DataTable)Session[GetArticleCategoryItemsSessionName()]
                                    : ArticleCategoryDAO.GetTemplateTable();
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
                        int categoryId = Utilities.ParseInt(Request.Params[CMSConstants.ParameterName.CATEGORY_ID]);
                        string url = hidUrl.Value;
                        int partitionId = Utilities.ParseInt(hidPartitionId.Value);

                        DataTable dtItems = (Session[GetArticleCategoryItemsSessionName()] != null)
                                                ? (DataTable)Session[GetArticleCategoryItemsSessionName()]
                                                : ArticleCategoryDAO.GetTemplateTable();

                        DataTable dtNewSelect = ArticleCategoryDAO.GetTemplateTable();

                        //get id
                        int id = -1;
                        foreach (DataRow row in dtItems.Rows)
                        {
                            int rid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.Id]);
                            if (rid <= id) id = rid - 1;
                        }

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int articleId = Utilities.ParseInt(draggedItem.GetDataKeyValue("Id"));
                            string articleName = draggedItem.GetDataKeyValue("Name").ToString();
                            int articleContentTypeId = Utilities.ParseInt(draggedItem.GetDataKeyValue("ArticleContentTypeId"));
                            DateTime publishDate = (DateTime)draggedItem.GetDataKeyValue("PublishDate");

                            //check exist
                            bool blnExist = false;
                            foreach (DataRow row in dtItems.Rows)
                            {
                                if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.ArticleId]) == articleId)
                                {
                                    //change Status
                                    if (
                                        Utilities.StringCompare(row[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus],
                                                                Constants.CommonStatus.DELETE))
                                    {
                                        int itemId = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.Id]);
                                        string status = (itemId > 0)
                                                            ? Constants.CommonStatus.UPDATE
                                                            : Constants.CommonStatus.NEW;
                                        row[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] = status;
                                        row[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                                        row[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] = UserId;
                                    }
                                    //addrow
                                    dtNewSelect = AddRow(dtNewSelect, row);
                                    dtItems.Rows.Remove(row);
                                    //mask existed
                                    blnExist = true;
                                    break;
                                }
                            }

                            if (blnExist) continue;

                            //add memberOf
                            DataRow drNew = dtNewSelect.NewRow();
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.Id] = id--;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.Ord] = 0;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.OldOrd] = 0;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.CategoryId] = categoryId;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.PartitionId] = partitionId;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.Url] = url;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.PrimaryCategory] = 0;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.ArticleId] = articleId;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.ArticleContentTypeId] = articleContentTypeId;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.PublishDate] = publishDate;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.ArticleName] = articleName;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.Created_At] = DateTime.Now;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.Created_By] = UserId;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                            drNew[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] = UserId;
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
                            dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.Ord] = i + 1;
                            if (Nulls.IsNullOrEmpty(dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus]))
                            {
                                dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] =
                                    Constants.CommonStatus.UPDATE;
                            }
                            dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                            dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] = UserId;
                        }

                        Session[GetArticleCategoryItemsSessionName()] = dtItems;

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
                        DataTable dtItems = (Session[GetArticleCategoryItemsSessionName()] != null)
                                                ? (DataTable)Session[GetArticleCategoryItemsSessionName()]
                                                : ArticleCategoryDAO.GetTemplateTable();

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int id = Utilities.ParseInt(draggedItem.GetDataKeyValue("Id"));

                            foreach (DataRow row in dtItems.Rows)
                            {
                                if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.Id]) == id)
                                {
                                    //remove
                                    row[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                                    row[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                                    row[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] = UserId;
                                    //break;
                                    break;
                                }
                            }
                        }

                        Session[GetArticleCategoryItemsSessionName()] = dtItems;

                        radGridSelected.Rebind();
                    }
                    else if (e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridSelected.ClientID)
                    {
                        //reorder items in grid
                        DataTable dtItems = (Session[GetArticleCategoryItemsSessionName()] != null)
                                                ? (DataTable)Session[GetArticleCategoryItemsSessionName()]
                                                : ArticleCategoryDAO.GetTemplateTable();

                        DataTable dtArticleToMove = ArticleCategoryDAO.GetTemplateTable();
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
                            dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.Ord] = i + 1;
                            if (Nulls.IsNullOrEmpty(dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus]))
                            {
                                dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] =
                                    Constants.CommonStatus.UPDATE;
                            }
                            dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                            dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] = UserId;
                        }

                        Session[GetArticleCategoryItemsSessionName()] = dtItems;

                        radGridSelected.Rebind();
                    }
                }
            }
        }

        protected void radGridDefault_ItemCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                int categoryId = Utilities.ParseInt(Request.Params[CMSConstants.ParameterName.CATEGORY_ID]);
                string url = hidUrl.Value;
                int partitionId = Utilities.ParseInt(hidPartitionId.Value);
                
                DataTable dtItems = (Session[GetArticleCategoryItemsSessionName()] != null)
                                        ? (DataTable)Session[GetArticleCategoryItemsSessionName()]
                                        : ArticleCategoryDAO.GetTemplateTable();

                //get id
                int id = -1;
                foreach (DataRow row in dtItems.Rows)
                {
                    int rid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.Id]);
                    if (rid <= id) id = rid - 1;
                }

                int articleId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                string articleName = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Name"].ToString();
                int articleContentTypeId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ArticleContentTypeId"]);
                DateTime publishDate = (DateTime)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PublishDate"];

                //check exist
                bool blnExist = false;
                foreach (DataRow row in dtItems.Rows)
                {
                    if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.ArticleId]) == articleId)
                    {
                        //change Status
                        if (
                            Utilities.StringCompare(row[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus],
                                                    Constants.CommonStatus.DELETE))
                        {
                            int itemId = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.Id]);
                            string status = (itemId > 0)
                                                ? Constants.CommonStatus.UPDATE
                                                : Constants.CommonStatus.NEW;
                            row[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] = status;
                            row[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                            row[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] = UserId;
                        }
                        //addrow
                        DataTable dtNew = dtItems.Clone();
                        dtNew = AddRow(dtNew, row);
                        dtItems.Rows.Remove(row);
                        dtItems = AddRow(dtItems, dtNew.Rows[0], 0);
                        //mask existed
                        blnExist = true;
                        break;
                    }
                }

                if (!blnExist)
                {
                    //add memberOf
                    DataRow drNew = dtItems.NewRow();
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.Id] = id;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.Ord] = 0;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.OldOrd] = 0;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.CategoryId] = categoryId;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.PartitionId] = partitionId;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.Url] = url;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.PrimaryCategory] = 0;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.ArticleId] = articleId;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.ArticleContentTypeId] = articleContentTypeId;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.PublishDate] = publishDate;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.ArticleName] = articleName;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.Created_At] = DateTime.Now;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.Created_By] = UserId;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                    drNew[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] = UserId;
                    dtItems.Rows.InsertAt(drNew, 0);
                }

                //Update Media ord
                for (int i = 0; i < dtItems.Rows.Count; i++)
                {
                    dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.Ord] = i + 1;
                    if (Nulls.IsNullOrEmpty(dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus]))
                    {
                        dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] =
                            Constants.CommonStatus.UPDATE;
                    }
                    dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                    dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] = UserId;
                }

                Session[GetArticleCategoryItemsSessionName()] = dtItems;

                radGridSelected.Rebind();

                e.Canceled = true;
            }
        }

        protected void radGridSelected_ItemCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtItems = (Session[GetArticleCategoryItemsSessionName()] != null)
                                        ? (DataTable)Session[GetArticleCategoryItemsSessionName()]
                                        : ArticleCategoryDAO.GetTemplateTable();

                int id = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);

                foreach (DataRow row in dtItems.Rows)
                {
                    if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.Id]) == id)
                    {
                        //remove
                        row[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                        row[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                        row[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] = UserId;
                        //break;
                        break;
                    }
                }

                Session[GetArticleCategoryItemsSessionName()] = dtItems;

                radGridSelected.Rebind();

                e.Canceled = true;
            }
        }

        #endregion

        #region Private Method

        private void GetCategoryInfo(int cid)
        {
            CategoryHelper helper = new CategoryHelper(new Category());
            helper.ValueObject.Id = cid;
            helper.LoadEncode();
            if (helper.ValueObject != null)
            {
                hidUrl.Value = helper.ValueObject.Url;
                hidPartitionId.Value = helper.ValueObject.PartitionId.ToString();
                lblCategoryName.Text = helper.ValueObject.Name;
            }
        }

        private DataTable GetArticlesByCategoryId(int cid)
        {
            ArticleCategoryHelper helper = new ArticleCategoryHelper(new ArticleCategory());
            helper.ValueObject.CategoryId = cid;
            return helper.GetArticlesByCategoryId();
        }

        private string GetArticleCategoryItemsSessionName()
        {
            int categoryId = Utilities.ParseInt(Request.Params[CMSConstants.ParameterName.CATEGORY_ID]);
            return string.Format("{0}_{1}", CMSConstants.Session.CMSData.ArticleCategoryItem, categoryId);
        }

        private string GetKeyword()
        {
            string kw = string.Empty;
            RadToolBarItem radKeyword = radToolBarDefault.FindItemByValue("searchTextBoxButton");
            if (radKeyword != null)
            {
                RadTextBox txtKw = (RadTextBox)radKeyword.FindControl("txtKeyword");
                if (txtKw != null)
                {
                    kw = txtKw.Text.Trim();
                }
            }

            return kw;
        }

        private DateTime GetPublishFromDate()
        {
            RadToolBarItem radPublishDate = radToolBarDefault.FindItemByValue("searchPublishDatePickerButton");
            if (radPublishDate != null)
            {
                RadDatePicker dpkFromDate = (RadDatePicker)radPublishDate.FindControl("radDpkPublishFromDate");
                if (dpkFromDate != null && dpkFromDate.SelectedDate != null)
                {
                    return (DateTime)dpkFromDate.SelectedDate;
                }
            }

            return Utilities.GetFirstDayOfMonth();
        }

        private DateTime GetPublishToDate()
        {
            RadToolBarItem radPublishDate = radToolBarDefault.FindItemByValue("searchPublishDatePickerButton");
            if (radPublishDate != null)
            {
                RadDatePicker dpkToDate = (RadDatePicker)radPublishDate.FindControl("radDpkPublishToDate");
                if (dpkToDate != null && dpkToDate.SelectedDate != null)
                {
                    return (DateTime)dpkToDate.SelectedDate;
                }
            }

            return DateTime.Now;
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
            drSearch[Constants.Paging.Direction.KeyWords] = GetKeyword();
            drSearch[CMSConstants.Paging.Direction.CategoryId] = 0;
            drSearch[CMSConstants.Paging.Direction.PublishFromDate] = GetPublishFromDate();
            drSearch[CMSConstants.Paging.Direction.PublishToDate] = GetPublishToDate();
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
            p.Action = CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticleForPopupInsertNewsWithoutCategory;
            //p.Action = CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticleForPopupInsertNews;
            //if (Utilities.ParseInt(cmbCategory.SelectedValue) == 0)
            //{
            //    p.Action =
            //        CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticleForPopupInsertNewsWithoutCategory;
            //}

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
            radGridDefault.Rebind();
            BindValueinDropDownList();
            SetLabelForPagingBar();
        }

        #endregion

        private DataRow GetOrder(DataTable source, int id)
        {
            if (source == null || source.Rows.Count == 0) return null;
            foreach (DataRow row in source.Rows)
            {
                int rowId = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.Id]);
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

        private void DoSave()
        {
            DataTable dtItems = (Session[GetArticleCategoryItemsSessionName()] != null)
                                    ? (DataTable)Session[GetArticleCategoryItemsSessionName()]
                                    : ArticleCategoryDAO.GetTemplateTable();
            
            if (dtItems != null && dtItems.Rows.Count > 0)
            {
                int ord = 1;
                for (int i = 0; i< dtItems.Rows.Count; i++)
                {
                    if (!Utilities.StringCompare(dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus],
                                                Constants.CommonStatus.DELETE))
                    {
                        dtItems.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.Ord] = ord;
                        if (ord <= 100) ord++;
                    }
                }

                ArticleCategoryHelper helper = new ArticleCategoryHelper(new ArticleCategory());
                helper.SaveCategory(dtItems);

                lblMessage.Visible = true;
                lblMessage.Text = Utilities.GetConfigKey(SystemConstants.Message.SaveSuccess);
            }
        }

        #endregion
    }
}