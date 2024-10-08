/************************************************************************/
/* File Name  : ReportsByGroup.aspx                                     */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Royalty                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2009 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Thống kê chấm Nhuận bút Tin bài                        */
/*               theo thời gian xuất bản                                */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 16/09/2010 File Create                                               */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/


using System;
using System.Data;
using Telerik.Web.UI;
using VietNamNet.AddOn.Royalty.Components;
using VietNamNet.AddOn.Royalty.Core.Common.ValueObject;
using VietNamNet.AddOn.Royalty.Core.Presentation;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.AddOn.Royalty
{
    public partial class ReportsByUser : RoyaltyBasePageView
    {
        #region Members

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {  
            base.PageLoad();

            if (!isStatistics)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                SetupEnvironment();
            }
        }
        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            try
            {
                switch (((RadToolBarButton)e.Item).CommandName)
                {
                    case VietNamNet.Framework.Common.Constants.CommandNames.Search:
                        RadComboBox cboIsMember = (RadComboBox)radToolBarDefault.FindItemByValue("searchAuthor").FindControl("cboIsMember");
                        RadComboBox cmbUser = (RadComboBox)radToolBarDefault.FindItemByValue("searchAuthor").FindControl("cboUser");

                        RoyaltySearch s = new RoyaltySearch();
                        s.DateFrom = (DateTime)((RadDatePicker)radToolBarDefault.FindItemByValue("searchDateButton").FindControl("txtDateFrom")).SelectedDate;
                        s.DateTo = (DateTime)((RadDatePicker)radToolBarDefault.FindItemByValue("searchDateButton").FindControl("txtDateTo")).SelectedDate;
                                             
                        s.IsMember = Utilities.ParseInt(cboIsMember.SelectedValue);
                        s.UserId = Utilities.ParseInt(cmbUser.SelectedValue);

                        PopularReports(s);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                //lblMessage.Text = ex.Message;
            }


        }
        protected void cboIsMember_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            PopularUser();
        }
        #endregion


        #region Private Methods
        private void SetupEnvironment()
        {
            RadToolBarItem searchItem = radToolBarDefault.FindItemByValue("searchDateButton");
            ((RadDatePicker)searchItem.FindControl("txtDateFrom")).SelectedDate = DateTime.Now.AddDays(-7);
            ((RadDatePicker)searchItem.FindControl("txtDateTo")).SelectedDate = DateTime.Now;

            PopularUser();

            RoyaltySearch s = new RoyaltySearch();
            s.DateFrom = (DateTime)((RadDatePicker)radToolBarDefault.FindItemByValue("searchDateButton").FindControl("txtDateFrom")).SelectedDate;
            s.DateTo = (DateTime)((RadDatePicker)radToolBarDefault.FindItemByValue("searchDateButton").FindControl("txtDateTo")).SelectedDate;

            RadComboBox cboIsMember = (RadComboBox)radToolBarDefault.FindItemByValue("searchAuthor").FindControl("cboIsMember");
           RadComboBox cmbUser = (RadComboBox)radToolBarDefault.FindItemByValue("searchAuthor").FindControl("cboUser");

           s.IsMember =Utilities.ParseInt( cboIsMember.SelectedValue);
           s.UserId =Utilities.ParseInt( cmbUser.SelectedValue);


           PopularReports(s);
        }

        private void PopularUser()
        {
            RadComboBox cboIsMember = (RadComboBox) radToolBarDefault.FindItemByValue("searchAuthor").FindControl("cboIsMember");

            RadComboBox cmbUser = (RadComboBox)radToolBarDefault.FindItemByValue("searchAuthor").FindControl("cboUser");
            System.Web.UI.WebControls.Label lblAuthor = (System.Web.UI.WebControls.Label)radToolBarDefault.FindItemByValue("searchAuthor").FindControl("lblAuthor");

            if (cboIsMember.SelectedValue == "1")
            {
                lblAuthor.Visible = true;
                cmbUser.Visible = true;
                cmbUser.Items.Clear();
               
                UserHelper helper = new UserHelper(new User());
                cmbUser.DataSource = helper.ListAll();
                cmbUser.DataBind();
                cmbUser.Items.Insert(0, new RadComboBoxItem("Tất cả", "0"));
            }
            else {
                lblAuthor.Visible = false;
                cmbUser.Visible = false;
            }
          

        }

        private void PopularReports(RoyaltySearch search)
        { 

            RoyaltyFundHelper helper = new RoyaltyFundHelper(new RoyaltySearch());
            helper.SearchObject.IsMember = search.IsMember;
            helper.SearchObject.UserId = search.UserId;
            helper.SearchObject.DateFrom = search.DateFrom;
            helper.SearchObject.DateTo = search.DateTo;
            DataTable dt = helper.Reports21A();

            radGridDefault.DataSource = dt;
            radGridDefault.DataBind();

        }

        #endregion


        #region Public Methods

        #endregion
   
   }
}
