using System;
using System.Data;
using Telerik.Web.UI;
using VietNamNet.AddOn.Royalty.Components;
using VietNamNet.AddOn.Royalty.Core.Common.ValueObject;
using VietNamNet.AddOn.Royalty.Core.Presentation;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using Constants = VietNamNet.AddOn.Royalty.Core.Common.Constants;

namespace VietNamNet.AddOn.Royalty
{
    public partial class ArticlesList : BasePageView
    { 

        #region Members
        protected string editAlias = string.Empty;
        protected string correctAlias = string.Empty;
        protected string publishAlias = string.Empty;
        protected string categoryAlias = string.Empty;
        protected string systemAlias = string.Empty;

        protected bool isEdit = false;
        protected bool isCorrect = false;
        protected bool isPublish = false;
        protected bool isCategory = false;
        protected bool isSystem = false;

        protected string strStatus = string.Empty;
        protected int categoryId = 0;



        protected bool isTypesManager = false;
        protected string typesAlias = string.Empty;

        protected bool isFundManager = false;
        protected string fundAlias = string.Empty;

        protected bool isStatistics = false;
        protected string statisticsAlias = string.Empty;

        #endregion

        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            //// test only
            //Session[VietNamNet.Framework.Common.Constants.Session.USER_ID] = 10;
            //Session[VietNamNet.Framework.Common.Constants.Session.USER_LOGINNAME] = "dnson";
            //Session[VietNamNet.Framework.Common.Constants.Session.USER_FULLNAME] = "Đỗ Nam Sơn";
            //Session[VietNamNet.Framework.Common.Constants.Session.USER_EMAIL] = "dnson@vietnamnet.vn";
            //Session[VietNamNet.Framework.Common.Constants.Session.USER_STATUS] = "Hoạt động";
            
            Initialize();
            PageLoad();

            if (!isFundManager)
            {
                Utilities.NoRightToAccess();
            }

            strStatus = Request.Params[CMSConstants.ParameterName.STATUS];
            categoryId = Utilities.ParseInt(Request.Params[CMSConstants.ParameterName.CATEGORY_ID]);

            //check category
            if (categoryId > 0)
            {
                string url =
                    Utilities.SetParamForURL(CMSConstants.FormNames.CMS.Articles.ArticleViewByCategory,
                                             CMSConstants.ParameterName.CATEGORY_ID, categoryId);
                Response.Redirect(url);
            }

            //if (!isCategory && !isSystem)
            //{
            //    Utilities.NoRightToAccess();
            //}

            if (!IsPostBack)
            {
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


                FunctionforPageLoad();
            }
        }

     protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                
                case VietNamNet.Framework.Common.Constants.CommandNames.Search:
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
                    string url = (cateId == 0)
                        ? Utilities.SetParamForURL(Request.Url.AbsoluteUri, Constants.ParameterName.KEYWORD, kw)
                        : Utilities.SetParamForURL(CMSConstants.FormNames.CMS.Articles.ArticleViewByCategory, Constants.ParameterName.KEYWORD, kw);
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

        protected override void radGridDefault_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (!Utilities.Event_Handler(source, e)) return;

            if ((Utilities.StringCompare(e.CommandName, VietNamNet.Framework.Common.Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, VietNamNet.Framework.Common.Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {// Redirect to Edit Royalty

                //Utilities.Redirect(CMSConstants.FormNames.CMS.Articles.ArticleDisplay,
                //                   e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"].ToString());
            }
           
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {

            moduleAlias = "VietNamNet.AddOn.Royalty";
            typesAlias = "VietNamNet.AddOn.Royalty.Types";
            fundAlias = "VietNamNet.AddOn.Royalty.Fund";
            statisticsAlias = "VietNamNet.AddOn.Royalty.Statistics";
            
            ServiceName = Constants.Services.RoyaltyFundManager.Name;
            ActionName = Constants.Services.RoyaltyFundManager.Actions.ViewGetAllArticleList;
        }

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
                    cmbCategory.DataSource = helper.GetCategoryByUserId();
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

        #region Public Methods
   protected override void GetPolicy()
        {
            base.GetPolicy();

            isTypesManager = SystemUtils.GetPolicy(UserId, moduleAlias, typesAlias);
            isFundManager = SystemUtils.GetPolicy(UserId, moduleAlias, fundAlias);
            isStatistics = SystemUtils.GetPolicy(UserId, moduleAlias, statisticsAlias);

            isSystem = SystemUtils.GetPolicy(UserId, moduleAlias, systemAlias);
        }

        protected override DataTable BindSearchingTable()
        {
            DataTable dtSearch = new DataTable(VietNamNet.Framework.Common.Constants.Paging.Direction.SearchingTableName);
            dtSearch.Columns.Add(VietNamNet.Framework.Common.Constants.Paging.Direction.IsSearch, typeof(bool));
            dtSearch.Columns.Add(VietNamNet.Framework.Common.Constants.Paging.Direction.KeyWords, typeof(string));
            dtSearch.Columns.Add(CMSConstants.Paging.Direction.UId, typeof(int));
            dtSearch.Columns.Add(CMSConstants.Paging.Direction.Status, typeof(string));
            dtSearch.Columns.Add(CMSConstants.Paging.Direction.PublishFromDate, typeof(DateTime));
            dtSearch.Columns.Add(CMSConstants.Paging.Direction.PublishToDate, typeof(DateTime));
            DataRow drSearch = dtSearch.NewRow();
            drSearch[VietNamNet.Framework.Common.Constants.Paging.Direction.IsSearch] =
                Convert.ToBoolean(ViewState[VietNamNet.Framework.Common.Constants.Paging.Direction.IsSearch]);
            drSearch[VietNamNet.Framework.Common.Constants.Paging.Direction.KeyWords] =
                Convert.ToString(ViewState[VietNamNet.Framework.Common.Constants.Paging.Direction.KeyWords]);
            drSearch[CMSConstants.Paging.Direction.UId] = UserId;
            drSearch[CMSConstants.Paging.Direction.Status] = strStatus;
            drSearch[CMSConstants.Paging.Direction.PublishFromDate] = GetPublishFromDate();
            drSearch[CMSConstants.Paging.Direction.PublishToDate] = GetPublishToDate();
            dtSearch.Rows.Add(drSearch);
            return dtSearch;
        }

        #endregion
   
   }
}
