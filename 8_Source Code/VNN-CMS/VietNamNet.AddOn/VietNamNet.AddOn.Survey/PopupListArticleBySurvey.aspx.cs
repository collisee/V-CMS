using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.AddOn.Survey.UserControls;
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
    public partial class PopupListArticleBySurvey : SurveyBasePage
    {
        #region  "Members"

        private int _surveyId;
        private int _surveyPublish;
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
            PageLoad();

            if (!isPublisher)
            {
                Utilities.NoRightToAccess();
            }

            Initialize();

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

       

        #endregion



        protected void radToolBarDefault_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            try
            {
                _surveyPublish = int.Parse(txtSurveyPublishId.Text);
                SurveyPublish sp;

                switch (e.Item.Value)
                {
                    case "AddNew":

                        sp = new SurveyPublish();
                        sp.SurveyId = int.Parse(txtSurveyId.Text);

                        SurveyPublishEdit1.SurveyPublish1 = sp;
                        SurveyPublishEdit1.Bind();


                        //move to Update mode
                        SurveyPublishEdit1.Visible = true;
                        radToolBarDefault.Items.FindItemByValue("Update").Visible = true;
                        //radToolBarDefault.Items.FindItemByValue("AddNew").Visible = false;
                        break;
                    case "Refresh":
                        SurveyPublishEdit1.SurveyPublish1 = new SurveyPublish(_surveyPublish);
                        SurveyPublishEdit1.Bind();

                        //move to Update mode
                        SurveyPublishEdit1.Visible = true;
                        radToolBarDefault.Items.FindItemByValue("Update").Visible = true;
                        // radToolBarDefault.Items.FindItemByValue("AddNew").Visible = false;

                        break;




                    case "Update":
                        sp = SurveyPublishEdit1.SurveyPublish1;
                        sp.Save();

                        // move to Normal mode
                        SurveyPublishArticleList1.Bind();
                        SurveyPublishEdit1.Visible = false;
                        // radToolBarDefault.Items.FindItemByValue("AddNew").Visible = true;
                        radToolBarDefault.Items.FindItemByValue("Update").Visible = false;

                        break;

                    case "Delete":
                        break;
                }

            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }


        }

        #endregion

        #region "Private Methods"
        private void SetupEnvironment()
        {
            if (Request.Params["surveyid"] != null && Request.Params["surveyid"] != "null" && !Utilities.IsNullOrEmpty(Request.Params["surveyid"]))
            {
                _surveyId = int.Parse(Request.Params["surveyid"]);

                txtSurveyId.Text = _surveyId.ToString();
                SurveyModule.DAL.Survey s = new Select().From<SurveyModule.DAL.Survey>().
                    Where(SurveyModule.DAL.Survey.Columns.SurveyId).IsEqualTo(_surveyId).ExecuteSingle<SurveyModule.DAL.Survey>();

                SurveyInfo1.SurveyInfor = s;
                SurveyPublishArticleList1.SurveyU = s;
                SurveyPublishArticleList1.DisplayType = SurveyPublishArticleList.eDisplayType.Category;
            }

            SurveyInfo1.Bind();
            SurveyPublishArticleList1.Bind();
        }

        #endregion

        #region "Public Methods"
        #endregion

   }
}
