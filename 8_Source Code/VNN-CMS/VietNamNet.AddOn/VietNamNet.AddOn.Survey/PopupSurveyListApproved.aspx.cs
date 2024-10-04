using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.AddOn.Survey.BizLogic;
using SubSonic;
namespace VietNamNet.AddOn.Survey
{
    public partial class PopupSurveyListApproved : SurveyBasePage
    {
        #region  "Members" 
        private int _surveyId ;
        #endregion

        #region "Event Handlers"

        #region "Page - Event Handlers"

        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                //// test only
                //Session[Constants.Session.USER_ID] = 7;
                //Session[Constants.Session.USER_LOGINNAME] = "dnson";
                //Session[Constants.Session.USER_FULLNAME] = "Đỗ Nam Sơn";
                //Session[Constants.Session.USER_EMAIL] = "dnson@vietnamnet.vn";
                //Session[Constants.Session.USER_STATUS] = "Hoạt động";

                PageLoad();

                if (!isLogged)
                {
                    Utilities.NoRightToAccess();
                }

                if (!IsPostBack)
                {
                    SetupEnvironment();
                }
            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }

        }
         
        #endregion

        protected void RadToolBarDefaultButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    //Utilities.Redirect(CMSConstants.FormNames.CMS.CategoryEdit);
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
            PopularSurveys(0);
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
                        foreach (SurveyPublish sp in spCol)
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
            SqlQuery q = new Select().From<SurveyModule.DAL.Survey>()
                                .Where(SurveyModule.DAL.Survey.Columns.IsDeleted).IsEqualTo(false)
                                .And(SurveyModule.DAL.Survey.Columns.Status).IsEqualTo(1);

            RadComboBox cboOptionTypes = (RadComboBox)radToolBarDefault.Items.FindItemByValue("searchTextBoxButton").FindControl("cboOptionTypes");
            if (cboOptionTypes.SelectedValue != "") q.AndExpression(SurveyModule.DAL.Survey.Columns.OptionType).IsEqualTo(cboOptionTypes.SelectedValue);

            String strKeyword = ((RadTextBox)radToolBarDefault.Items.FindItemByValue("searchTextBoxButton").FindControl("txtKeyword")).Text;
            if (strKeyword.Trim() != "")
            { 
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
            PopularSurveys(0);
        }


        #endregion

       #region "Public Methods"
       #endregion

   }
}
