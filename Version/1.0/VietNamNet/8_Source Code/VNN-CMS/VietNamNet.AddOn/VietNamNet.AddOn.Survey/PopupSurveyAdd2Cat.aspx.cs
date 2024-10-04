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
    public partial class PopupSurveyAdd2Cat : SurveyBasePage
    {
        #region  "Members" 

        private int _surveyPublishId;
        private int _surveyId; 

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
           
                //// test only
                //Session[Constants.Session.USER_ID] = 7;
                //Session[Constants.Session.USER_LOGINNAME] = "dnson";
                //Session[Constants.Session.USER_FULLNAME] = "Đỗ Nam Sơn";
                //Session[Constants.Session.USER_EMAIL] = "dnson@vietnamnet.vn";
                //Session[Constants.Session.USER_STATUS] = "Hoạt động";

                

                PageLoad();

                if (!isPublisher)
                {
                    Utilities.NoRightToAccess();
                }

                Initialize2();
               
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

        private void Initialize2()
        {
                //Load control 
                // Load SurveyInfo
                SurveyInfo surveyInfo = (SurveyInfo)this.LoadControl("UserControls/SurveyInfo.ascx");
                surveyInfo.ID = System.IO.Path.GetFileNameWithoutExtension("UserControls/SurveyInfo.ascx");
                pwSurveyInfo.Controls.Add(surveyInfo);
 

                // Load Cats Search
                CategoriesSearch categoriesSearch = (CategoriesSearch)this.LoadControl("UserControls/CategoriesSearch.ascx");
                categoriesSearch.ID = System.IO.Path.GetFileNameWithoutExtension("UserControls/CategoriesSearch.ascx");
                pwCatInfo.Controls.Add(categoriesSearch);


                // Load Config publish
                SurveyPublishEdit surveyPublishEdit = (SurveyPublishEdit)this.LoadControl("UserControls/SurveyPublishEdit.ascx");
                surveyPublishEdit.ID = System.IO.Path.GetFileNameWithoutExtension("UserControls/SurveyPublishEdit.ascx");
                pwConfig.Controls.Add(surveyPublishEdit);

             

        }

        #endregion
               
              

        protected void radToolBarDefault_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
        
                switch (e.Item.Value)
                { 
                    case "Update":
                        SurveyInfo surveyInfo = (SurveyInfo)pwSurveyInfo.FindControl("SurveyInfo");
                        CategoriesSearch categoriesSearch = (CategoriesSearch)pwCatInfo.FindControl("CategoriesSearch");
                        SurveyPublishEdit surveyPublishEdit = (SurveyPublishEdit)pwConfig.FindControl("SurveyPublishEdit");

                        if (Request.Params["surveypublishid"] != null && Request.Params["surveypublishid"] != "null" && !Utilities.IsNullOrEmpty(Request.Params["surveypublishid"]))
                        {
                            _surveyPublishId = int.Parse(Request.Params["surveypublishid"]);
                            SurveyPublish p = new Select().From<SurveyPublish>().
                                        Where(SurveyPublish.Columns.SurveyPublishId).IsEqualTo(_surveyPublishId).ExecuteSingle<SurveyPublish>();


                            
                            
                            p = surveyPublishEdit.SurveyPublish1;
                            p.SurveyId = surveyInfo.SurveyInfor.SurveyId;
                            p.CategoryId = categoriesSearch.SelectedCat;
                           
                            p.Save();
                        }
                        else if (Request.Params["surveyid"] != null && Request.Params["surveyid"] != "null" && !Utilities.IsNullOrEmpty(Request.Params["surveyid"]))
                        {
                            _surveyId = int.Parse(Request.Params["surveyid"]);
                            

                            SurveyPublish p = new SurveyPublish();
                            p = surveyPublishEdit.SurveyPublish1;
                            p.SurveyId = surveyInfo.SurveyInfor.SurveyId;
                            p.CategoryId = categoriesSearch.SelectedCat;

                            SurveyPublish a = new SurveyPublish();
                            a.SurveyId = _surveyId;
                            a.CategoryId = p.CategoryId;
                            a.StartDate = p.StartDate;
                            a.ExpireDate = p.ExpireDate;
                            a.Security = p.Security;
                            a.Status = p.Status;
                            a.IsActive = true;
                            a.CreatedBy = UserId.ToString();
                            a.Save();
                        }
                        lblMessage.Text = "Thông tin Bình chọn đã được Cập nhật.";
                        
                       break;
                    case "Delete":
                        break;
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

        #region "Private Methods"
        private void SetupEnvironment()
        { 
            SurveyInfo surveyInfo = (SurveyInfo)pwSurveyInfo.FindControl("SurveyInfo");
            CategoriesSearch categoriesSearch = (CategoriesSearch)pwCatInfo.FindControl("CategoriesSearch");
            SurveyPublishEdit surveyPublishEdit = (SurveyPublishEdit)pwConfig.FindControl("SurveyPublishEdit");

            if (Request.Params["surveypublishid"] != null && Request.Params["surveypublishid"] != "null" && !Utilities.IsNullOrEmpty(Request.Params["surveypublishid"]))
            {
                //throw new Exception("surveypublishid");
                _surveyPublishId = int.Parse(Request.Params["surveypublishid"]);
                SurveyPublish spTemp = new Select().From<SurveyPublish>().
                            Where(SurveyPublish.Columns.SurveyPublishId).IsEqualTo(_surveyPublishId).ExecuteSingle<SurveyPublish>();
                surveyPublishEdit.SurveyPublish1 = spTemp;

                if (spTemp.CategoryId != null) categoriesSearch.SelectedCat = (int)spTemp.CategoryId;

                _surveyId = spTemp.SurveyId;
                SurveyModule.DAL.Survey sTemp = spTemp.Survey;
                surveyInfo.SurveyInfor = sTemp;
                 
            }
            else if (Request.Params["surveyid"] != null && Request.Params["surveyid"] != "null" && !Utilities.IsNullOrEmpty(Request.Params["surveyid"]))
            {
              
                _surveyId = int.Parse(Request.Params["surveyid"]);
                SurveyModule.DAL.Survey sTemp = new Select().From<SurveyModule.DAL.Survey>().
                            Where(SurveyModule.DAL.Survey.Columns.SurveyId).IsEqualTo(_surveyId).ExecuteSingle<SurveyModule.DAL.Survey>();
                surveyInfo.SurveyInfor = sTemp;

                SurveyPublishCollection spCol = sTemp.SurveyPublishs();
                if (spCol.Count > 1)
                {
                    SurveyPublish sp = spCol[spCol.Count - 1];
                    if (sp.CategoryId != null)
                        categoriesSearch.SelectedCat = (int)sp.CategoryId;
                    surveyPublishEdit.SurveyPublish1 = sp;
                }
            }
            else
            {
                //throw new Exception("nothing");
                categoriesSearch.SelectedCat = 0;
                surveyPublishEdit.SurveyPublish1 = new SurveyPublish();
                surveyInfo.SurveyInfor = new SurveyModule.DAL.Survey();
            }

            surveyInfo.Bind();
            categoriesSearch.Bind();
            surveyPublishEdit.Bind();
    
        } 

        #endregion

       #region "Public Methods"
       #endregion

   }
}
