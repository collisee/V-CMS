using System;
using System.Data;
using System.Web.UI;
using Telerik.Web.UI;
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Survey.UserControls
{
    public partial class ArticlesSearch : BaseUserControls
    {

        #region Members
        private int _selectedArticle;
        public int SelectedArticle
        {
            get {  
                _selectedArticle = int.Parse(txtSelectedArticle.Text.Trim()); 
                return _selectedArticle; }
            set { _selectedArticle = value; }
        }
        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetupEnvironment();
                radDpkPublishFromDate.SelectedDate = Utilities.GetFirstDayOfMonth();
                radDpkPublishToDate.SelectedDate = DateTime.Now;
                BindDataToCategory(0);
                BindDataToArticles();
            }
        }
        private void SetupEnvironment()
        {
            if (_selectedArticle != null) txtSelectedArticle.Text = _selectedArticle.ToString();

          

        }



        #region Paging
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

        #endregion

        #endregion


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
            int pageSize = 5;// Utilities.ParseInt(Utilities.GetConfigKey(Constants.ConfigKey.PageSize));

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

     
        protected void BindDataToArticles()
        {
            if (radDpkPublishFromDate.SelectedDate == null) radDpkPublishFromDate.SelectedDate = Utilities.GetFirstDayOfMonth();
            if (radDpkPublishToDate.SelectedDate == null) radDpkPublishToDate.SelectedDate = DateTime.Now;

            radGridDefault.Rebind();
            BindValueinDropDownList();
            SetLabelForPagingBar();
        }

        #endregion

        protected void radGridDefault_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            radGridDefault.DataSource = GetDataSource();
        } 

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            BindDataToArticles();
        }

        protected void radGridDefault_ItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Select":
                        txtSelectedArticle.Text = (string)e.CommandArgument;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}