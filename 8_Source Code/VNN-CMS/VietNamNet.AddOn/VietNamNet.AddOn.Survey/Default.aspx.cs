using System;
using SubSonic;
using VietNamNet.AddOn.Survey.Common;
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.AddOn.SurveyModule.DAL ;
using Telerik.Web.UI;
using VietNamNet.AddOn.Survey.BizLogic;
using VietNamNet.CMS.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Survey
{
    public partial class _Default : SurveyBasePage
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            //// test only
            //Session[Constants.Session.USER_ID] = 18;
            //Session[Constants.Session.USER_LOGINNAME] = "dnson";
            //Session[Constants.Session.USER_FULLNAME] = "Đỗ Nam Sơn";
            //Session[Constants.Session.USER_EMAIL] = "dnson@vietnamnet.vn";
            //Session[Constants.Session.USER_STATUS] = "Hoạt động";

            PageLoad();

            if (!isViewer)
            {
                Utilities.NoRightToAccess();
            }
            
            if (!IsPostBack)
            {
                SetupEnvironment();
            }
            try
            {
               

            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }
           
        }

        protected void RadToolBarDefaultButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
          
            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(SurveyConstants.FormNames.SurveyEdit);
                    break;
                case Constants.CommandNames.Search:
                    PopularSurveys(0);
                    break;
                default:
                    break;
            }
        }

        protected void OnFilterChanged(object sender, EventArgs e)
        {
             
        }

        protected void GrdViewPageIndexChanged(object source, GridPageChangedEventArgs e)
        {
            PopularSurveys(e.NewPageIndex);
        }

        protected void GrdViewPageSizeChanged(object source, GridPageSizeChangedEventArgs e)
        {
             
        }

        protected void GrdViewItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                SurveyModule.DAL.Survey s;
                switch (e.CommandName)
                {
                    case "Approve":
                        s = new SurveyModule.DAL.Survey(e.CommandArgument);

                        s.Status = byte.Parse((s.Status == 1 ? 0 : 1).ToString());
                        s.Save(UserId);

                        SurveyPublishCollection spCol = s.SurveyPublishs();
                        foreach(SurveyPublish sp in spCol)
                        {
                            sp.Status = 1;
                            sp.Save();
                        }
                        PopularSurveys(grdView.CurrentPageIndex);
                        break;
                    case "Delete":
                        s = new SurveyModule.DAL.Survey(e.CommandArgument);
                        s.IsDeleted = true;
                        s.Save(UserId);
                        PopularSurveys(grdView.CurrentPageIndex);
                        break;
                    case "Edit":
                        Response.Redirect("SurveyEdit.aspx?" + SurveyConstants.SurveyId + "=" + e.CommandArgument.ToString());
                        break;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + e.CommandArgument;
            }
        }
        #endregion

        #region Private Methods
        private void PopularSurveys(int pageIndex)
        {
            //Filter Builder 
            SqlQuery  q = new Select().From<SurveyModule.DAL.Survey>()
                                .Where(SurveyModule.DAL.Survey.Columns.IsDeleted).IsEqualTo(false);

            RadComboBox cboOptionTypes = (RadComboBox)radToolBarDefault.Items.FindItemByValue("searchTextBoxButton").FindControl("cboOptionTypes");
            if (cboOptionTypes.SelectedValue != "") q.AndExpression(SurveyModule.DAL.Survey.Columns.OptionType).IsEqualTo(cboOptionTypes.SelectedValue);

            RadComboBox cboStatus = (RadComboBox)radToolBarDefault.Items.FindItemByValue("searchTextBoxButton").FindControl("cboStatus");
            if (cboStatus.SelectedValue != "") q.AndExpression(SurveyModule.DAL.Survey.Columns.Status).IsEqualTo(cboStatus.SelectedValue);

            String strKeyword = ((RadTextBox)radToolBarDefault.Items.FindItemByValue("searchTextBoxButton").FindControl("txtKeyword") ).Text ;
            if (strKeyword.Trim() != "") { 
                // WHERE (FirstName LIKE '%michael%' OR LastName LIKE '%michael%')
                q.AndExpression(SurveyModule.DAL.Survey.Columns.Question).Like("%" + strKeyword.Trim() + "%")
                    .Or(SurveyModule.DAL.Survey.Columns.Notes).Like("%" + strKeyword.Trim() + "%")
                    .Or(SurveyModule.DAL.Survey.Columns.Tags).Like("%" + strKeyword.Trim() + "%");
                }

                q.OrderDesc(SurveyModule.DAL.Survey.Columns.CreatedOn);

            //Bind Data
            SurveyCollection sCol = q.ExecuteAsCollection<SurveyCollection>();

            grdView.DataSource = sCol;
            grdView.CurrentPageIndex = pageIndex;
            grdView.DataBind(); 
        }


        private void SetupEnvironment()
        {
            radToolBarDefault.Items.FindItemByValue("AddNew").Visible = isAddNewer;

            PopularSurveys(0);
        }
      

        #endregion

        #region Public Methods
        public bool IsApproved(int status)
        {
            return status ==1; 
        }

        #endregion


    }
}