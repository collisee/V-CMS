using System;
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.AddOn.Survey.UserControls;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using SubSonic;
namespace VietNamNet.AddOn.Survey
{
    public partial class PopupListCatBySurvey : SurveyBasePage
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
                        sp.SurveyId = int.Parse( txtSurveyId.Text  );

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
                        SurveyPublishList1.Bind();
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
                lblMessage.Text =   exc.Message ;
            }


        }
  
        #endregion

        #region "Private Methods"
        private void SetupEnvironment()
        {
          if (Request.Params["surveyid"] != null && Request.Params["surveyid"] != "null" && !Utilities.IsNullOrEmpty(Request.Params["surveyid"]))
            {
                _surveyId = int.Parse(Request.Params["surveyid"]);

                txtSurveyId.Text  = _surveyId.ToString( );
                SurveyModule.DAL.Survey s = new Select().From<SurveyModule.DAL.Survey>().
                    Where(SurveyModule.DAL.Survey.Columns.SurveyId).IsEqualTo(_surveyId).ExecuteSingle<SurveyModule.DAL.Survey>();

                SurveyInfo1.SurveyInfor = s;
                SurveyPublishList1.SurveyU = s;
                SurveyPublishList1.DisplayType = SurveyPublishList.eDisplayType.Category;
            }

            SurveyInfo1.Bind();
            SurveyPublishList1.Bind();
        } 

        #endregion

       #region "Public Methods"
       #endregion

   }
}
