using System;
using System.Data;
using System.Web;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Articles
{
    public partial class PopupInsertNews : BasePageView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            //if (!isViewer)
            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                RadToolBarItem radKeyword = radToolBarDefault.FindItemByValue("searchTextBoxButton");
                if (radKeyword != null)
                {
                    RadTextBox txtKw = (RadTextBox)radKeyword.FindControl("txtKeyword");
                    if (txtKw != null)
                    {
                        txtKw.Text = Nulls.IsNullOrEmpty(Request.Params[CMSConstants.ParameterName.KEYWORD])
                                         ? string.Empty
                                         : Request.Params[Constants.ParameterName.KEYWORD];
                    }
                }

                RadToolBarItem radPublishDate = radToolBarDefault.FindItemByValue("searchPublishDatePickerButton");
                if (radPublishDate != null)
                {
                    RadDatePicker dpkFromDate = (RadDatePicker)radPublishDate.FindControl("radDpkPublishFromDate");
                    if (dpkFromDate != null)
                    {
                        dpkFromDate.SelectedDate =
                            !Nulls.IsNullOrEmpty(Request.Params[CMSConstants.ParameterName.PUBLISH_FROM_DATE])
                                ? Utilities.ConvertLocaltoGlobalDateTime(
                                      Request.Params[CMSConstants.ParameterName.PUBLISH_FROM_DATE])
                                : Utilities.GetFirstDayOfMonth();
                    }
                    RadDatePicker dpkToDate = (RadDatePicker) radPublishDate.FindControl("radDpkPublishToDate");
                    if (dpkToDate != null)
                    {
                        dpkToDate.SelectedDate =
                            !Nulls.IsNullOrEmpty(Request.Params[CMSConstants.ParameterName.PUBLISH_TO_DATE])
                                ? Utilities.ConvertLocaltoGlobalDateTime(
                                      Request.Params[CMSConstants.ParameterName.PUBLISH_TO_DATE])
                                : DateTime.Now;
                    }
                }

                BindDataToCategory();

                if (Utilities.ParseInt(Request.Params[CMSConstants.ParameterName.CATEGORY_ID]) == 0)
                {
                    Session[CMSConstants.Session.CMSData.ArticleSelected] = null;
                }

                FunctionforPageLoad();
            }
        }

        private void Initialize()
        {
            dynamicLayout = false;
            //moduleAlias = "VietNamNet.CMS.Article";
            //viewAlias = "VietNamNet.CMS.Article.View";
            //addNewAlias = "VietNamNet.CMS.Article.AddNew";
            //updateAlias = "VietNamNet.CMS.Article.Update";
            //deleteAlias = "VietNamNet.CMS.Article.Delete";
            ServiceName = CMSConstants.Services.ArticleManager.Name;
            ActionName = CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticleForPopupInsertNews;
        }

        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }

        protected override DataTable BindSearchingTable()
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
            drSearch[CMSConstants.Paging.Direction.CategoryId] = GetCategoryId();
            drSearch[CMSConstants.Paging.Direction.PublishFromDate] = GetPublishFromDate();
            drSearch[CMSConstants.Paging.Direction.PublishToDate] = GetPublishToDate();
            dtSearch.Rows.Add(drSearch);
            return dtSearch;
        }

        private void BindDataToCategory()
        {
            RadToolBarItem radCategory = radToolBarDefault.FindItemByValue("searchCategoryComboBoxButton");
            if (radCategory != null)
            {
                RadComboBox cmbCategory = (RadComboBox)radCategory.FindControl("cmbCategory");
                if (cmbCategory != null)
                {
                    CategoryHelper helper = new CategoryHelper(new Category());
                    helper.ValueObject.UserId = UserId;
                    cmbCategory.DataSource = helper.GetCategoryByUserId();
                    cmbCategory.DataBind();
                    cmbCategory.Items.Insert(0, new RadComboBoxItem(string.Empty, "0"));

                    int categoryId = Utilities.ParseInt(Request.Params[CMSConstants.ParameterName.CATEGORY_ID]);
                    if (categoryId > 0) cmbCategory.SelectedValue = categoryId.ToString();
                }
            }
        }

        private string GetKeyword()
        {
            RadToolBarItem radKeyword = radToolBarDefault.FindItemByValue("searchTextBoxButton");
            if (radKeyword != null)
            {
                RadTextBox txtKw = (RadTextBox)radKeyword.FindControl("txtKeyword");
                if (txtKw != null)
                {
                    return txtKw.Text.Trim();
                }
            }
            return string.Empty;
        }

        private int GetCategoryId()
        {
            RadToolBarItem radCategory = radToolBarDefault.FindItemByValue("searchCategoryComboBoxButton");
            if (radCategory != null)
            {
                RadComboBox cmbCategory = (RadComboBox)radCategory.FindControl("cmbCategory");
                if (cmbCategory != null)
                {
                    return Utilities.ParseInt(cmbCategory.SelectedValue);
                }
            }

            return 0;
        }

        private DateTime GetPublishFromDate()
        {
            RadToolBarItem radPublishDate = radToolBarDefault.FindItemByValue("searchPublishDatePickerButton");
            if (radPublishDate != null)
            {
                RadDatePicker dpkFromDate = (RadDatePicker)radPublishDate.FindControl("radDpkPublishFromDate");
                if (dpkFromDate != null && dpkFromDate.SelectedDate != null)
                {
                    return (DateTime) dpkFromDate.SelectedDate;
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
                    return (DateTime) dpkToDate.SelectedDate;
                }
            }

            return DateTime.Now;
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case CMSConstants.CommandNames.Insert:
                    break;
                case CMSConstants.CommandNames.Close:
                    break;
                case Constants.CommandNames.Search:
                    string url =
                        Utilities.SetParamForURL(Request.Url.AbsoluteUri, Constants.ParameterName.KEYWORD, GetKeyword());
                    url =
                        Utilities.SetParamForURL(url, CMSConstants.ParameterName.CATEGORY_ID, GetCategoryId());
                    url =
                        Utilities.SetParamForURL(url, CMSConstants.ParameterName.PUBLISH_FROM_DATE,
                                                 Utilities.FormatDisplayDateOnly(GetPublishFromDate()));
                    url =
                        Utilities.SetParamForURL(url, CMSConstants.ParameterName.PUBLISH_TO_DATE,
                                                 Utilities.FormatDisplayDateOnly(GetPublishToDate()));
                    Response.Redirect(url);
                    break;
                default:
                    break;
            }
        }

        private DataTable GetSelectedArticleTableTemplate()
        {
            DataTable table = new DataTable("Article");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Ord", typeof(int));
            table.Columns.Add("Name");
            table.Columns.Add("PublishDate");
            table.Columns.Add("Author");
            table.Columns.Add("CategoryName");
            table.Columns.Add("CategoryAlias");
            table.Columns.Add("Link");

            return table;
        }

        private DataRow GetOrder(DataTable source, int id)
        {
            if (source == null || source.Rows.Count == 0) return null;
            foreach (DataRow row in source.Rows)
            {
                int rowId = Utilities.ParseInt(row[CMSConstants.Entities.ArticleMedia.FieldName.Id]);
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

        protected void radGridSelected_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            radGridSelected.DataSource = Session[CMSConstants.Session.CMSData.ArticleSelected] == null
                                             ? GetSelectedArticleTableTemplate()
                                             : (DataTable) Session[CMSConstants.Session.CMSData.ArticleSelected];
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
                        DataTable dtSelected = (Session[CMSConstants.Session.CMSData.ArticleSelected] == null)
                                                ? GetSelectedArticleTableTemplate()
                                                : (DataTable)Session[CMSConstants.Session.CMSData.ArticleSelected];

                        DataTable dtNewSelect = GetSelectedArticleTableTemplate();

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int articleId = Utilities.ParseInt(draggedItem.GetDataKeyValue("Id"));
                            string articleName = draggedItem.GetDataKeyValue("Name").ToString();
                            string categoryAlias = draggedItem.GetDataKeyValue("CategoryAlias").ToString();

                            //check exist
                            bool blnExist = false;
                            foreach (DataRow row in dtSelected.Rows)
                            {
                                if (Utilities.ParseInt(row["Id"]) == articleId)
                                {
                                    //mask existed
                                    blnExist = true;
                                    break;
                                }
                            }

                            if (blnExist) continue;

                            //add memberOf
                            DataRow drNew = dtNewSelect.NewRow();
                            drNew["Id"] = articleId;
                            drNew["Name"] = articleName;
                            drNew["CategoryAlias"] = categoryAlias;
                            drNew["Link"] = string.Format("/vn/{0}/{1}/{2}.html", categoryAlias, articleId,
                                              Utilities.ConvertToHTMLLink(HttpUtility.HtmlDecode(articleName)));
                            dtNewSelect.Rows.Add(drNew);
                        }

                        //get destinationIndex
                        int destinationIndex = 0;

                        if (e.DestDataItem != null)
                        {
                            DataRow order =
                                GetOrder(dtSelected, Utilities.ParseInt(e.DestDataItem.GetDataKeyValue("Id")));

                            destinationIndex = (order == null) ? 0 : dtSelected.Rows.IndexOf(order);

                            if (e.DropPosition == GridItemDropPosition.Below)
                            {
                                destinationIndex += 1;
                            }
                        }

                        foreach (DataRow row in dtNewSelect.Rows)
                        {
                            dtSelected = AddRow(dtSelected, row, destinationIndex++);
                        }

                        Session[CMSConstants.Session.CMSData.ArticleSelected] = dtSelected;

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
                        DataTable dtSelected = (Session[CMSConstants.Session.CMSData.ArticleSelected] == null)
                                                ? GetSelectedArticleTableTemplate()
                                                : (DataTable)Session[CMSConstants.Session.CMSData.ArticleSelected];

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int articleId = Utilities.ParseInt(draggedItem.GetDataKeyValue("Id"));

                            foreach (DataRow row in dtSelected.Rows)
                            {
                                if (Utilities.ParseInt(row["Id"]) == articleId)
                                {
                                    //remove memberOf
                                    dtSelected.Rows.Remove(row);
                                    //break;
                                    break;
                                }
                            }
                        }

                        Session[CMSConstants.Session.CMSData.ArticleSelected] = dtSelected;

                        radGridSelected.Rebind();
                    }
                    else if (e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridSelected.ClientID)
                    {
                        //reorder items in grid
                        DataTable dtSelected = (Session[CMSConstants.Session.CMSData.ArticleSelected] == null)
                                                ? GetSelectedArticleTableTemplate()
                                                : (DataTable)Session[CMSConstants.Session.CMSData.ArticleSelected];

                        DataTable dtArticleToMove = GetSelectedArticleTableTemplate();
                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            DataRow tmpOrder = GetOrder(dtSelected, Utilities.ParseInt(draggedItem.GetDataKeyValue("Id")));
                            if (tmpOrder != null) //Move from Media to Temp
                            {
                                dtArticleToMove = AddRow(dtArticleToMove, tmpOrder);
                                dtSelected.Rows.Remove(tmpOrder);
                            }
                        }

                        //get destinationIndex
                        DataRow order = GetOrder(dtSelected, Utilities.ParseInt(e.DestDataItem.GetDataKeyValue("Id")));
                        if (order == null) return;

                        int destinationIndex = dtSelected.Rows.IndexOf(order);

                        if (e.DropPosition == GridItemDropPosition.Below)
                        {
                            destinationIndex += 1;
                        }

                        foreach (DataRow orderToMove in dtArticleToMove.Rows) //Move from Temp to Selected
                        {
                            dtSelected = AddRow(dtSelected, orderToMove, destinationIndex++);
                        }

                        Session[CMSConstants.Session.CMSData.ArticleSelected] = dtSelected;

                        radGridSelected.Rebind();
                    }
                }
            }
        }
    }
}