/************************************************************************/
/* File Name  : ReportsByGroup.aspx                                            */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Royalty                     */
/* Product Version : 1.0                                                */
/* Copyright(C) 2009 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Thống kê chấm Nhuận bút Tin bài                        */
/*               theo thời gian chấm                                                       */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 14/09/2010 File Create                                               */
/*                                 */
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
    public partial class ReportsByGroup : RoyaltyBasePageView
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
                        RadComboBox cmbUser = (RadComboBox)radToolBarDefault.FindItemByValue("searchAuthor").FindControl("cboUser");

                        RoyaltySearch s = new RoyaltySearch();
                        s.UserId = Utilities.ParseInt(cmbUser.SelectedValue);
                        s.DateFrom = (DateTime)((RadDatePicker)radToolBarDefault.FindItemByValue("searchDateButton").FindControl("txtDateFrom")).SelectedDate;
                        s.DateTo = (DateTime)((RadDatePicker)radToolBarDefault.FindItemByValue("searchDateButton").FindControl("txtDateTo")).SelectedDate;

                         
                        PopularReports(s);
                        break;
                    default:
                        break;
                }
            }catch (Exception ex)
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
        private void  SetupEnvironment()
           {
            RadToolBarItem searchItem = radToolBarDefault.FindItemByValue("searchDateButton");
            ((RadDatePicker)searchItem.FindControl("txtDateFrom")).SelectedDate = DateTime.Now.AddDays(-7);
            ((RadDatePicker)searchItem.FindControl("txtDateTo")).SelectedDate = DateTime.Now;
            RadComboBox cmbUser = (RadComboBox)radToolBarDefault.FindItemByValue("searchAuthor").FindControl("cboUser");
 

            RoyaltySearch s = new RoyaltySearch();
            s.UserId = Utilities.ParseInt( cmbUser.SelectedValue );
            s.DateFrom = (DateTime)((RadDatePicker)radToolBarDefault.FindItemByValue("searchDateButton").FindControl("txtDateFrom")).SelectedDate;
            s.DateTo = (DateTime)((RadDatePicker)radToolBarDefault.FindItemByValue("searchDateButton").FindControl("txtDateTo")).SelectedDate;

            PopularUser();


            PopularReports(s);
           }
        private void PopularUser()
        {
             RadComboBox cmbUser = (RadComboBox)radToolBarDefault.FindItemByValue("searchAuthor").FindControl("cboUser");
            System.Web.UI.WebControls.Label lblAuthor = (System.Web.UI.WebControls.Label)radToolBarDefault.FindItemByValue("searchAuthor").FindControl("lblAuthor");
 
                lblAuthor.Visible = true;
                cmbUser.Visible = true;
                cmbUser.Items.Clear();

                UserHelper helper = new UserHelper(new User());
                cmbUser.DataSource = helper.ListAll();
                cmbUser.DataBind();
                cmbUser.Items.Insert(0, new RadComboBoxItem("Tất cả", "0"));

                if (cmbUser.SelectedIndex < 0)
                    cmbUser.SelectedIndex = 0;

        }

        private void PopularReports(RoyaltySearch search)
        {
            RoyaltyFundHelper helper = new RoyaltyFundHelper(new RoyaltySearch());
            helper.SearchObject.UserId = search.UserId ;
            helper.SearchObject.DateFrom = search.DateFrom;
            helper.SearchObject.DateTo = search.DateTo;
            DataTable dt = helper.Reports21B();

            radGridDefault.DataSource = dt;
            radGridDefault.DataBind();
 
        }

        #endregion


        #region Public Methods

        #endregion
   
   }
}
