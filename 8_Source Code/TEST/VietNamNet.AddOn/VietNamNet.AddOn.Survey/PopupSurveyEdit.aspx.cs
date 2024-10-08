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
    public partial class PopupSurveyEdit : SurveyBasePage
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
               
                PageLoad();

                if (!isAddNewer)
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
              
        #region "Surveys - Event handlers"
              

        protected void radToolBarDefault_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            try
            { 
                switch (e.Item.Value)
                { 
                    case "Update":
                        UpdateSurvey(); break;
                    case "Delete":
                        DeteleSurvey(); break; 
                }
               }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }


        }


        #endregion

        #region "SurveyOptions - Event handlers"

        protected void GrdOptionsItemCommand(object source, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    e.Item.Edit = true;
                    PopularOptions();
                    break;
                case "Update":
                    SurveyOptionCollection soCol = (SurveyOptionCollection)ViewState["surveyoptions"];
                    if (((RadTextBox)e.Item.FindControl("txtSurveyOptionId")).Text.Trim() != "")
                    {//update
                        foreach (SurveyOption so in soCol)
                        {
                            if (so.SurveyOptionId.ToString() == ((RadTextBox)e.Item.FindControl("txtSurveyOptionId")).Text.Trim())
                            {

                                if (((RadTextBox)e.Item.FindControl("txtOldOptionName")).Text.Trim() == so.OptionName)
                                {
                                    so.OptionName = ((RadTextBox)e.Item.FindControl("txtOptionName")).Text.Trim();
                                    so.ViewOrder = 0;
                                    so.Notes = ((RadTextBox)e.Item.FindControl("txtNotes")).Text.Trim();
                                    so.IsCorrect = ((CheckBox)e.Item.FindControl("chkIsCorrect")).Checked;
                                    so.IsOther = ((CheckBox)e.Item.FindControl("chkIsOtherOption")).Checked;
                                }
                            }
                        }
                    }
                    else
                    {//insert
                        SurveyOption so = new SurveyOption();
                        so.OptionName = ((RadTextBox)e.Item.FindControl("txtOptionName")).Text.Trim();
                        so.ViewOrder = 0;
                        so.Notes = ((RadTextBox)e.Item.FindControl("txtNotes")).Text.Trim();
                        so.IsCorrect = ((CheckBox)e.Item.FindControl("chkIsCorrect")).Checked;
                        so.IsOther = ((CheckBox)e.Item.FindControl("chkIsOtherOption")).Checked;
                        so.SurveyId = int.Parse(txtSurveyId.Text.Trim());
                        soCol.Add(so);
                    }


                    ViewState["surveyoptions"] = soCol;
                    e.Item.Edit = false;
                    PopularOptions();
                    break;
                case "Cancel":
                    e.Item.Edit = false;
                    PopularOptions();
                    break;
            }
        }

        protected void CmdAddOptionClick(object sender, EventArgs e)
        {
            try
            {
                grdOptions.MasterTableView.IsItemInserted = true;
                PopularOptions();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }
        #endregion
        
        #region "Config - Event Handlers"
       

        #endregion

        #endregion

        #region "Private Methods"
        private void SetupEnvironment()
        {
            Cats_PopularList();

            if (Request.Params["surveyid"] == null || Request.Params["surveyid"] == "null" || Utilities.IsNullOrEmpty(Request.Params["surveyid"]))
            {
                txtSurveyId.Text = Utilities.ParseInt(0).ToString();
                SurveyModule.DAL.SurveyOptionCollection soCol = new SurveyOptionCollection();
                ViewState["surveyoptions"] = soCol;
                PopularOptions();
            } else
            {
                try
                {
                    _surveyId = int.Parse(Request.Params["surveyid"].ToString());
                    SurveyHelper sHelper = new SurveyHelper();
                    SurveyObject s = sHelper.GetById(_surveyId);
                    if (s != null) PopularItem(s);
                }
                catch (Exception ex)
                {
                    txtSurveyId.Text = Utilities.ParseInt(0).ToString();
                    lblMessage.Text = ex.Message;
                }
            }
             
           
        } 

       #region "Surveys - Event handlers"
       private void PopularItem(SurveyObject obj)
       {
           if (obj == null)
           {
               Utilities.ItemDoesntExist();
           }
           //Store view states
           ViewState["surveyid"] = obj.SurveyId;


           txtSurveyId.Text = obj.SurveyId.ToString();
           txtQuestion.Text = obj.Question.ToString();
           txtNotes.Text = obj.Notes.ToString();

           txtTags.Text = obj.Tags.ToString();
           cboOptionType.FindItemByValue(obj.OptionType).Selected = true;

           ViewState["SurveyPublish"] = obj.SurveyPublishs() ;
           ViewState["surveyoptions"] = obj.Options;
          
           PopularOptions();
           PopularPublishs();
       }

        private void PopularPublishs()
        {
            SurveyPublishCollection spCol = (SurveyPublishCollection)ViewState["SurveyPublish"];
            //lblMessage.Text = lblMessage.Text + spCol.Count + "<br>";
            if (spCol.Count >=1 )
            {
                SurveyPublish sp = spCol[spCol.Count - 1];
                txtSurveyPublishId.Text = sp.SurveyPublishId.ToString();
               // lblMessage.Text = lblMessage.Text + "ExpireDate=" + sp.ExpireDate + "<br>";
                SurveyPublishEdit1.SurveyPublish1 = sp;
                SurveyPublishEdit1.Bind();
               
            }

        }

       private void PopularOptions()
       {
           grdOptions.DataSource = ViewState["surveyoptions"];
           grdOptions.DataBind();
       }
               

        private String CheckValidation() 
        {
            StringBuilder sb = new StringBuilder();
            if (txtQuestion.Text.Trim() == "") sb.Append("Câu hỏi của Bình chọn không được trống! Hãy nhập Câu hỏi!<br>");
            if (((SurveyOptionCollection)ViewState["surveyoptions"]).Count <= 1) sb.Append("Phải có ít nhất 2 Lựa chọn! Hãy nhập thêm Lựa chọn!<br>");
            //if (DateTime.Parse(txtStartDate.SelectedDate.ToString()) < Utilities.GetMinDate()) sb.Append("Định dạng Ngày bắt đầu không hợp lệ! Hãy chọn lại Ngày bắt đầu!<br>");
            //if (DateTime.Parse(txtExpireDate.SelectedDate.ToString()) < Utilities.GetMinDate()) sb.Append("Định dạng Ngày kết thúc không hợp lệ! Hãy chọn lại Ngày kết thúc!<br>");


            return sb.ToString();
        }

       private void UpdateSurvey()
       {
           String m = CheckValidation().Trim();
           if (m.Length >=5)
           {
               throw new Exception(m);
           }


           //Set Survey update
           SurveyModule.DAL.Survey s;
           if (txtSurveyId.Text.Trim() == "")
           {
               s = new SurveyModule.DAL.Survey();
           }
           else if (int.Parse(txtSurveyId.Text.Trim()) != 0)
           {
               s = new SurveyModule.DAL.Survey(int.Parse(txtSurveyId.Text.Trim()));
           }
           else
           {
               s = new SurveyModule.DAL.Survey();
           }

           s.Question = txtQuestion.Text.ToString().Trim();
           s.Notes = txtNotes.Text.ToString().Trim();
           s.Tags = txtTags.Text.ToString().Trim();
           s.OptionType = cboOptionType.SelectedValue;
           s.Status = 0; s.IsActive = true;
           s.CreatedBy = this.UserId.ToString();
           //s.ModifiedBy = this.UserId.ToString();
           s.ModifiOn = DateTime.Now;

           //Set Survey Option update
           SurveyModule.DAL.SurveyOptionCollection soCol = new SurveyOptionCollection();
           soCol = (SurveyOptionCollection)ViewState["surveyoptions"];
           

           //Set Survey Pushlish update
           SurveyPublishCollection pCol = new SurveyPublishCollection();
           SurveyPublish sp;
           if (txtSurveyPublishId.Text.Trim() == "")
           {
                 sp= new SurveyPublish();
           }
           else
           {
               sp = new SurveyPublish(txtSurveyPublishId.Text.Trim());
           }
           
           sp = SurveyPublishEdit1.SurveyPublish1;
           sp.CategoryId = int.Parse(cboCategories.SelectedValue);
           pCol.Add(sp);

           // Update to DB
           SurveyHelper surveyHelper = new SurveyHelper(); 
           surveyHelper.save(s, soCol,pCol);

           lblMessage.Text = "Thông tin Survey đã được cập nhật ";

       }

       private void DeteleSurvey()
       {
           int surveyId = int.Parse(txtSurveyId.Text.Trim());
           SurveyHelper sHelper = new SurveyHelper();
           sHelper.Delete(surveyId);

           lblMessage.Text = "Thông tin Survey đã được xóa";
       }
       #endregion

       #region "Display - Event handlers" 

        private void Cats_PopularList()
        {
            DataTable dt = Cats_GetDataSource();

            foreach (DataRow dataRow in dt.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow[CMSConstants.Entities.Category.FieldName.DisplayName];
                item.Value = dataRow[CMSConstants.Entities.Category.FieldName.Id].ToString();
 
                item.Attributes.Add(CMSConstants.Entities.Category.FieldName.Name, dataRow[CMSConstants.Entities.Category.FieldName.Name].ToString());
                item.Attributes.Add(CMSConstants.Entities.Category.FieldName.Alias, dataRow[CMSConstants.Entities.Category.FieldName.Alias].ToString());
                item.Attributes.Add(CMSConstants.Entities.Category.FieldName.DisplayName, dataRow[CMSConstants.Entities.Category.FieldName.DisplayName].ToString());
                item.Attributes.Add(CMSConstants.Entities.Category.FieldName.Detail, dataRow[CMSConstants.Entities.Category.FieldName.Detail].ToString());
 

                cboCategories.Items.Add(item);

                item.DataBind();
            }
            //cboCategories.DataSource = dt; 
            //cboCategories.DataBind();


        }
        protected virtual DataTable Cats_GetDataSource()
        {
            CategoryHelper helper = new CategoryHelper(new Category());
            helper.ValueObject.UserId = UserId;

            return helper.GetCategoryByUserId();
        }

       #endregion

        #endregion

       #region "Public Methods"
       #endregion

   }
}
