/************************************************************************/
/* File Name  : ReportByCat.aspx                                        */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Reports                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2009 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Thống kê Tin bài                                       */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 20/09/2010 File Create                                               */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using System;
using System.Data;
using Telerik.Web.UI;
using VietNamNet.AddOn.Report.Core.Common.ValueObject;
using VietNamNet.AddOn.Report.Core.Presentation;
using VietNamNet.AddOn.CMS.Reports.Components;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.CMS.Reports
{
    public partial class ReportByCat : ReportBasePageView
    {
        #region  Members

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        { 
            Initialize();
            //// test only
            //Session[Constants.Session.USER_ID] = 10;
            //Session[Constants.Session.USER_LOGINNAME] = "dnson";
            //Session[Constants.Session.USER_FULLNAME] = "Đỗ Nam Sơn";
            //Session[Constants.Session.USER_EMAIL] = "dnson@vietnamnet.vn";
            //Session[Constants.Session.USER_STATUS] = "Hoạt động";


            base.PageLoad();

            if (!isLogged) Utilities.NoRightToAccess();
            if (!isStatistics) Utilities.NoRightToAccess();

            if (!IsPostBack)
            {
                SetupEnvironment();
            }
        }

        private void Initialize()
        {
        }

        protected void radToolBarDefault_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            try
            { 
                switch (e.Item.Value)
                {
                    case "search":
                        PopularReport();
                        break;
                    case "Cancel":
                        Response.Redirect("Default.aspx"); break;
                }
            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }
        }


        #region Event handlers

        protected void OnFilterChanged(object sender, EventArgs e)
        {
            //PopularRoyaltys(0);
        }


        #endregion

        #region Groups - Event handlers

        protected void rptGroup_PreRender(object sender, EventArgs e)
        {
            //RadGrid rptGroup = (RadGrid) PanelBar.Items[2].Items[0].FindControl("rptGroup");

            //if (rptGroup.EditIndexes.Count > 0 || rptGroup.MasterTableView.IsItemInserted)
            //{
            //    GridColumn col1 = rptGroup.MasterTableView.GetColumn("EditCommandColumn") as GridColumn;
            //    col1.Visible = true;
            //}
            //else
            //{
            //    GridColumn col2 = rptGroup.MasterTableView.GetColumn("EditCommandColumn") as GridColumn;
            //    col2.Visible = false;
            //}
        }
 
        protected void RptGroupItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Preview":
                        //Utilities.Redirect("/CMS/Articles/ArticleViewByCategory.aspx?Keyword=&Status=Đã xuất bản&CId=2&FDate=01/09/2010&TDate=21/09/2010");
                        RadToolBarItem searchItem = radToolBarDefault.FindItemByValue("searchDateButton");
                        DateTime dateFrom = ((RadDatePicker)searchItem.FindControl("txtDateFrom")).SelectedDate == null ? Utilities.GetFirstDayOfMonth() : (DateTime)((RadDatePicker)searchItem.FindControl("txtDateFrom")).SelectedDate;
                        DateTime dateTo = ((RadDatePicker)searchItem.FindControl("txtDateTo")).SelectedDate == null ? Utilities.GetLastDayOfMonth() : (DateTime)((RadDatePicker)searchItem.FindControl("txtDateTo")).SelectedDate; ;


                        string url = Utilities.SetParamForURL(CMSConstants.FormNames.CMS.Articles.ArticleViewByCategory, Constants.ParameterName.KEYWORD, string.Empty);
                        url =
                            Utilities.SetParamForURL(url, CMSConstants.ParameterName.STATUS, CMSConstants.ArticleStatus.Published);
                        url =
                            Utilities.SetParamForURL(url, CMSConstants.ParameterName.CATEGORY_ID, e.CommandArgument);
                        url =
                            Utilities.SetParamForURL(url, CMSConstants.ParameterName.PUBLISH_FROM_DATE,
                                                     Utilities.FormatDisplayDateOnly(dateFrom));
                        url =
                            Utilities.SetParamForURL(url, CMSConstants.ParameterName.PUBLISH_TO_DATE,
                                                     Utilities.FormatDisplayDateOnly(dateTo));
                        Response.Redirect(url);

                        break;
                    case "Cancel":
                        e.Item.Edit = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        #endregion

        #endregion

        #region Private Methods
        private void PopularReport()
          {
              RadToolBarItem radCategory = radToolBarDefault.FindItemByValue("searchCategory");
              RadToolBarItem searchItem = radToolBarDefault.FindItemByValue("searchDateButton");

              ReportHelper helper = new ReportHelper(new ReportSearch());
              helper.ValueObject.UserId = UserId;
              helper.ValueObject.CategoryId = Utilities.ParseInt (((RadComboBox)radCategory.FindControl("cboCategory")) .SelectedValue);
              helper.ValueObject.DateFrom = ((RadDatePicker) searchItem.FindControl("txtDateFrom")).SelectedDate == null ? Utilities.GetFirstDayOfMonth() : (DateTime)((RadDatePicker) searchItem.FindControl("txtDateFrom")).SelectedDate;
              helper.ValueObject.DateTo = ((RadDatePicker)searchItem.FindControl("txtDateTo")).SelectedDate == null ? Utilities.GetLastDayOfMonth() : (DateTime)((RadDatePicker)searchItem.FindControl("txtDateTo")).SelectedDate; ;

              DataTable dt = helper.ReportByCat();
              radGridDefault.DataSource = dt;
              radGridDefault.DataBind();
          }

        private void SetupEnvironment()
        {
            //PublishDate
            RadToolBarItem radPublishDate = radToolBarDefault.FindItemByValue("searchDateButton");
            if (radPublishDate != null)
            {
                RadToolBarItem searchItem = radToolBarDefault.FindItemByValue("searchDateButton");
                ((RadDatePicker)searchItem.FindControl("txtDateFrom")).SelectedDate = Utilities.GetFirstDayOfMonth() ;
                ((RadDatePicker)searchItem.FindControl("txtDateTo")).SelectedDate = Utilities.GetLastDayOfMonth();
            }

            PopularCat();
            PopularReport();
        }

        private void PopularCat(){
            RadToolBarItem radCategory = radToolBarDefault.FindItemByValue("searchCategory");
                      
            if (radCategory != null)
            {
                RadComboBox cboCategory = (RadComboBox)radCategory.FindControl("cboCategory");
                if (cboCategory != null)
                {
                    CategoryHelper helper = new CategoryHelper(new Category());
                    helper.ValueObject.UserId = UserId;
                    cboCategory.DataSource = helper.GetCategoryByUserId();
                    cboCategory.DataBind();
                    cboCategory.Items.Insert(0, new RadComboBoxItem("Tất cả", null));

                    //if (cid >= 0) cmbCategory.SelectedValue = cid.ToString();
                }
            }
        }

        private string FilterBuilder()
        {
            //StringBuilder sbG = new StringBuilder();
            //RadGrid rpt = (RadGrid)PanelBar.Items[2].Items[0].FindControl("rptGroup"); 
            //if (((CheckBox)PanelBar.Items[2].Items[0].FindControl("chkAll")).Checked == false)  
            //    foreach (GridDataItem i in rpt.Items)
            //        if (((CheckBox)i.FindControl("chkGroup")).Checked)
            //        {
            //            sbG.Append(((HiddenField)i.FindControl("txtGroupID")).Value + ";");
            //        }
 

            //// Setup Filter
            //StringBuilder sFilter = new StringBuilder();
            //sFilter.Append(" 1=1 ");
            //RadPanelItem pItem = new RadPanelItem();
            //pItem = PanelBar.Items[1].Items[0];
            //if (((CheckBox)pItem.FindControl("chkScopePrivate")).Checked &&
            //    ((CheckBox)pItem.FindControl("chkScopePublic")).Checked) sFilter.Append(" and 1=1");
            //else if (((CheckBox)pItem.FindControl("chkScopePrivate")).Checked) sFilter.Append(" and Scope=0 ");
            //else if (((CheckBox)pItem.FindControl("chkScopePublic")).Checked) sFilter.Append(" and Scope=1 ");
            //else sFilter.Append(" and 1=0 ");

            //// Filter by Group
            //    if (sbG.ToString().Trim().Length > 0)
            //        sFilter.Append(" and ';" + sbG.ToString() + "' like '%;'+ GroupID +';%' ");
                

            //pItem = PanelBar.Items[0].Items[0];
            //if (((RadTextBox)pItem.FindControl("txtFilterName")).Text.Trim().Length > 0)
            //    sFilter.Append(" and Fullname like '%" + ((RadTextBox)pItem.FindControl("txtFilterName")).Text.Trim() + "%' ");
            //if (((RadTextBox)pItem.FindControl("txtFilterOrgName")).Text.Trim().Length > 0)
            //    sFilter.Append(" and OrgName like '%" + ((RadTextBox)pItem.FindControl("txtFilterOrgName")).Text.Trim() + "%' ");
            //if (((RadTextBox)pItem.FindControl("txtFilterTitle")).Text.Trim().Length > 0)
            //    sFilter.Append(" and OrgTitle like '%" + ((RadTextBox)pItem.FindControl("txtFilterTitle")).Text.Trim() + "%' ");
            //if (((RadTextBox)pItem.FindControl("txtFilterEmail")).Text.Trim().Length > 0)
            //    sFilter.Append(" and (OrgEmail1 like '%" + ((RadTextBox)pItem.FindControl("txtFilterEmail")).Text.Trim() +
            //                   "%' ").Append(" or OrgEmail2 like '%" + ((RadTextBox)pItem.FindControl("txtFilterEmail")).Text.Trim() + "%' ) ");
             


            //return sFilter.ToString();
            return "";
        }

        #endregion

        #region Public Methods
        public Boolean IsEditable(int owner)
        {
            if (owner.Equals(this.UserId))
            {
                return true;
            }
            // Nếu có quyền quản trị return true;

            return false;
        }
        #endregion

    }
}