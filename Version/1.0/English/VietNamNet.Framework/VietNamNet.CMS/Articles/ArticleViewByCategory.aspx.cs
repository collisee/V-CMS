using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Articles
{
    public partial class ArticleViewByCategory : ArticleBasePageView
    {
        #region Member

        protected string strStatus = string.Empty;
        protected int categoryId = 0;

        #endregion

        #region Override Method

        protected override void Initialize()
        {
            base.Initialize();
            ActionName = CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticleByCategory;
        }

        protected override DataTable BindSearchingTable()
        {
            DataTable dtSearch = new DataTable(Constants.Paging.Direction.SearchingTableName);
            dtSearch.Columns.Add(Constants.Paging.Direction.IsSearch, typeof(bool));
            dtSearch.Columns.Add(Constants.Paging.Direction.KeyWords, typeof(string));
            dtSearch.Columns.Add(CMSConstants.Paging.Direction.Status, typeof(string));
            dtSearch.Columns.Add(CMSConstants.Paging.Direction.CategoryId, typeof(int));
            dtSearch.Columns.Add(CMSConstants.Paging.Direction.PublishFromDate, typeof(DateTime));
            dtSearch.Columns.Add(CMSConstants.Paging.Direction.PublishToDate, typeof(DateTime));
            DataRow drSearch = dtSearch.NewRow();
            drSearch[Constants.Paging.Direction.IsSearch] =
                Convert.ToBoolean(ViewState[Constants.Paging.Direction.IsSearch]);
            drSearch[Constants.Paging.Direction.KeyWords] =
                Convert.ToString(ViewState[Constants.Paging.Direction.KeyWords]);
            drSearch[CMSConstants.Paging.Direction.Status] = strStatus;
            drSearch[CMSConstants.Paging.Direction.CategoryId] = categoryId;
            drSearch[CMSConstants.Paging.Direction.PublishFromDate] = GetPublishFromDate();
            drSearch[CMSConstants.Paging.Direction.PublishToDate] = GetPublishToDate();
            dtSearch.Rows.Add(drSearch);
            return dtSearch;
        }
 
        protected override void radGridDefault_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (!Utilities.Event_Handler(source, e)) return;

            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                Utilities.Redirect(CMSConstants.FormNames.CMS.Articles.ArticleDisplay,
                                   e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"].ToString());
            }
            else if (Utilities.StringCompare(e.CommandName, Constants.CommandNames.Delete) && e.Item is GridDataItem)
            {
                ArticleHelper helper = new ArticleHelper(new Article());
                helper.ValueObject.Id =
                    Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                helper.ValueObject.Last_Modified_At = DateTime.Now;
                helper.ValueObject.Last_Modified_By = UserId;
                helper.Delete();

                //load
                FunctionforPageLoad();
            }
        }

        #endregion

        #region Handler Method

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isViewer)
            {
                Utilities.NoRightToAccess();
            }

            //check status
            strStatus = Request.Params[CMSConstants.ParameterName.STATUS];
            switch(strStatus)
            {
                case CMSConstants.ArticleStatus.Draft:
                case CMSConstants.ArticleStatus.Rejected:
                    break;
                case CMSConstants.ArticleStatus.Crawling:
                    break;
                case CMSConstants.ArticleStatus.Submited:
                    if (!isEdit) Utilities.NoRightToAccess();
                    break;
                case CMSConstants.ArticleStatus.Editted:
                    if (!isCorrect) Utilities.NoRightToAccess();
                    break;
                case CMSConstants.ArticleStatus.Corrected:
                case CMSConstants.ArticleStatus.Published:
                case CMSConstants.ArticleStatus.Stopped:
                    if (!isPublish) Utilities.NoRightToAccess();
                    break;
                default:
                    break;
            }

            //check category
            categoryId = Utilities.ParseInt(Request.Params[CMSConstants.ParameterName.CATEGORY_ID]);
            if (categoryId == 0)
            {
                Response.Redirect(CMSConstants.FormNames.CMS.Articles.ArticleViewByManager);
            }

            bool isMyCategory = CMSUtils.GetCategoryPolicy(UserId, categoryId);

            if (!(isCategory && isMyCategory) && !isSystem)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                //logging
                SystemLogging.Info("View Articles", Request.Url.ToString());

                RadToolBarItem radKeyword = radToolBarDefault.FindItemByValue("searchTextBoxButton");
                if (radKeyword != null)
                {
                    RadTextBox txtKw = (RadTextBox)radKeyword.FindControl("txtKeyword");
                    if (txtKw != null)
                    {
                        txtKw.Text = Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.KEYWORD])
                                         ? string.Empty
                                         : Request.Params[Constants.ParameterName.KEYWORD];
                    }
                }

                //Status
                BindDataToStatus(strStatus);

                //Category
                BindDataToCategory(categoryId);

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

                //show hide AddNew button
                radToolBarDefault.Items[0].Visible = radToolBarDefault.Items[0].Enabled = isAddNewer;
                radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = isAddNewer;
                //show hide Delete button
                radGridDefault.Columns[radGridDefault.Columns.Count - 1].Visible = isDeleter;
                radGridDefault.Columns[radGridDefault.Columns.Count - 2].Visible = CMSUtils.GetRoyaltyPolicy(UserId);

                FunctionforPageLoad();
            }
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(CMSConstants.FormNames.CMS.Articles.ArticleEdit);
                    break;
                case Constants.CommandNames.Optimize:
                    //Optimize
                    ArticleCategoryHelper helper = new ArticleCategoryHelper(new ArticleCategory());
                    helper.ValueObject.CategoryId = categoryId;
                    helper.OptimizeArticleCategory();
                    //Rebind
                    FunctionforPageLoad();
                    break;
                case Constants.CommandNames.Search:
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

                    int cateId = GetCategoryId();
                    string url = (cateId > 0)
                                     ? Utilities.SetParamForURL(Request.Url.AbsoluteUri, Constants.ParameterName.KEYWORD, kw)
                                     : Utilities.SetParamForURL(CMSConstants.FormNames.CMS.Articles.ArticleViewByManager, Constants.ParameterName.KEYWORD, kw);
                    url =
                        Utilities.SetParamForURL(url, CMSConstants.ParameterName.STATUS, GetStatus());
                    url =
                        Utilities.SetParamForURL(url, CMSConstants.ParameterName.CATEGORY_ID, cateId);
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

        #endregion

        #region Private Method

        private void BindDataToStatus(string status)
        {
            RadToolBarItem radCategory = radToolBarDefault.FindItemByValue("searchStatusComboBoxButton");
            if (radCategory != null)
            {
                RadComboBox cmbStatus = (RadComboBox)radCategory.FindControl("cmbStatus");
                if (cmbStatus != null)
                {
                    cmbStatus.SelectedValue = status;
                }
            }
        }

        private void BindDataToCategory(int cid)
        {
            RadToolBarItem radCategory = radToolBarDefault.FindItemByValue("searchCategoryComboBoxButton");
            if (radCategory != null)
            {
                RadComboBox cmbCategory = (RadComboBox)radCategory.FindControl("cmbCategory");
                if (cmbCategory != null)
                {
                    CategoryHelper helper = new CategoryHelper(new Category());
                    helper.ValueObject.UserId = UserId;
                    cmbCategory.DataSource = helper.ListAll();
                    cmbCategory.DataBind();
                    cmbCategory.Items.Insert(0, new RadComboBoxItem("Tất cả", "0"));

                    if (cid >= 0) cmbCategory.SelectedValue = cid.ToString();
                }
            }
        }

        private string GetStatus()
        {
            RadToolBarItem radStatus = radToolBarDefault.FindItemByValue("searchStatusComboBoxButton");
            if (radStatus != null)
            {
                RadComboBox cmbStatus = (RadComboBox)radStatus.FindControl("cmbStatus");
                if (cmbStatus != null)
                {
                    return cmbStatus.SelectedValue;
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

        #endregion
    }
}