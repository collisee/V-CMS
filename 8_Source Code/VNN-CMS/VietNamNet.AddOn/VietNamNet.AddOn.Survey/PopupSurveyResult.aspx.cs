using System;
using System.Data;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Survey
{
    public partial class PopupSurveyResult : BasePage
    {
        #region  "Controls"

        #endregion

        #region "Event Handlers"
        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
         
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
 

        protected void txtSurveyIdTextChanged(object sender, EventArgs e)
        {
            IsUpdate();
        }
               
        #region "Button event handlers"


        protected void CmdReadClick(object sender, EventArgs e)
        {
            byte[] byt;
            if (FileUpload1.HasFile)
            {
                //'lblMessage.Text = "ContentType:" + FileUpload1.PostedFile.ContentType;
                if (FileUpload1.PostedFile.ContentType.ToString().IndexOf("text/x-Survey")< 0)
                    lblMessage.Text = "File tải lên không đúng định dạng! Hãy tải lên file Survey: (*.vcf)";
                byt = FileUpload1.FileBytes;
            }
            else
            {
                //lblMessage.Text = "No File";
                return;
            }
            string str = System.Text.Encoding.UTF8.GetString(byt);

            //char keyEnter = (char)13;
            //lblMessage.Text = str.Replace(keyEnter.ToString(), "<br>");

            //Surveys vNew = new Surveys();
            //vNew.ReadFromString(str);

            //PopularSurvey(vNew);
        }
 
        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            UpdateSurvey();
        }

        protected void cmdDelete_Click(object sender, EventArgs e)
        {
            DeteleSurvey();
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {

        }

        protected void radToolBarDefault_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            try
            {
                switch (e.Item.Value)
                {
                    case "Export":
                        Response.Redirect("ExportSurvey.aspx?Surveyid=" + txtSurveyId.Text.Trim());
                        break;
                    case "Update":
                        UpdateSurvey(); break;
                    case "Delete":
                        DeteleSurvey(); break;
                        break;
                }
            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }


        }

        #endregion

        #endregion

        #region "Private Methods"
        private void SetupEnvironment()
        {

            PopularScope();
            PopularSex();
            //PopularGroup();

            if (Request.Params["Surveyid"] != null)
            {

                try
                {
                    //SurveysHelper vHelper = new SurveysHelper(new Surveys());
                    //vHelper.ValueObject.ContactId = Utilities.ParseInt(Request.Params["Surveyid"]);
                    //vHelper.Load();

                    //if (vHelper.ValueObject == null)
                    //{
                    //    Utilities.ItemDoesntExist();
                    //}

                    //PopularSurvey(vHelper.ValueObject);

                    ////Store view states
                    //if (vHelper.ValueObject != null) ViewState["Surveyid"] = vHelper.ValueObject.ContactId;  
                }
                catch (Exception ex)
                { txtSurveyId.Text = Utilities.ParseInt(0).ToString();
                }
            } else
            {
                txtSurveyId.Text = Utilities.ParseInt( 0 ).ToString(); 
            }

            IsUpdate();
           
        }
        private void PopularScope()
        {
            cboScope.Items.Clear();
            cboScope.Items.Add(new RadComboBoxItem("Cá nhân", "0"));
            cboScope.Items.Add(new RadComboBoxItem("Công cộng", "1"));
        }
        private void PopularSex()
        {
            cboSex.Items.Clear();
            cboSex.Items.Add(new RadComboBoxItem("Nam", "0"));
            cboSex.Items.Add(new RadComboBoxItem("Nữ", "1"));
        }
        
        private void PopularSurvey()
        {
            //txtSurveyId.Text = obj.ContactId.ToString();

            //txtFullname.Text = obj.Fullname; txtFullnamea.Text = obj.Fullname; txtFullnameb.Text = obj.Fullname;
            //txtOrgTitle.Text = obj.OrgTitle; txtOrgTitlea.Text = obj.OrgTitle;
            //txtOrgName.Text = obj.OrgName; txtOrgNamea.Text = obj.OrgName;
            //txtOrgUnit.Text = obj.OrgUnit;
            //txtOrgPhone.Text = obj.OrgPhone; txtOrgPhonea.Text = obj.OrgPhone;
            //txtOrgMobile.Text = obj.OrgMobile; txtOrgMobilea.Text = obj.OrgMobile;
            //txtOrgFax.Text = obj.OrgFax; txtOrgFaxa.Text = obj.OrgFax;
            //txtOrgAdr1.Text = obj.OrgAdr1 ;
            //txtOrgAdr2.Text = obj.OrgAdr2 ;
            //txtOrgEmail1.Text = obj.OrgEmail1; txtOrgEmail1a.Text = obj.OrgEmail1;
            //txtOrgEmail2.Text = obj.OrgEmail2;
            //txtOrgWebsite.Text = obj.OrgWebsite ;
            //cboSex.Items.FindItemByValue(obj.Sex.ToString()).Selected = true;
            //if (Utilities.IsNullOrEmpty(obj.Bday)) txtBirthday.SelectedDate = obj.Bday;
            
            
            //txtHomePhone.Text =obj.HomePhone;
            //txtHomeMobile.Text = obj.HomeMobile ;
            //txtHomeFax.Text = obj.HomeFax ;
            //txtHomeAdr1.Text = obj.HomeAdr1 ;
            //txtHomeAdr2.Text = obj.HomeAdr2 ;
            //txtHomeEmail1.Text = obj.HomeEmail1 ;
            //txtHomeEmail2.Text = obj.HomeEmail2 ;
            //txtHomepage.Text = obj.Homepage ;

            //txtNotes.Text = obj.Notes ;

            //if (cboGroups.Items.FindItemByValue(obj.GroupID.ToString()) != null) cboGroups.Items.FindItemByValue(obj.GroupID.ToString()).Selected = true;
            //cboScope.Items.FindItemByValue(obj.Scope.ToString()).Selected = true;

            //IsUpdate();
        }

        private void UpdateSurvey()
        {
            //SurveysHelper vHelper = new SurveysHelper(new Surveys());
            //vHelper.ValueObject.ContactId = Convert.ToInt32(txtSurveyId.Text.Trim());
            //if (txtFullname.Text.Trim().Length<=0)
            //    throw new Exception("Họ tên không có, hãy nhập họ tên!");
            //else
            //    vHelper.ValueObject.Fullname = txtFullname.Text.Trim();

            //vHelper.ValueObject.OrgTitle = txtOrgTitle.Text.Trim();
            //vHelper.ValueObject.OrgName = txtOrgName.Text.Trim();
            //vHelper.ValueObject.OrgUnit = txtOrgUnit.Text.Trim();
            //vHelper.ValueObject.OrgPhone = txtOrgPhone.Text.Trim();
            //vHelper.ValueObject.OrgMobile = txtOrgMobile.Text.Trim();
            //vHelper.ValueObject.OrgFax = txtOrgFax.Text.Trim();
            //vHelper.ValueObject.OrgAdr1 = txtOrgAdr1.Text.Trim();
            //vHelper.ValueObject.OrgAdr2 = txtOrgAdr2.Text.Trim();
            //vHelper.ValueObject.OrgEmail1 = txtOrgEmail1.Text.Trim();
            //vHelper.ValueObject.OrgEmail2 = txtOrgEmail2.Text.Trim();
            //vHelper.ValueObject.OrgWebsite = txtOrgWebsite.Text.Trim();
            //vHelper.ValueObject.Sex = Convert.ToByte(cboSex.SelectedValue);
            //if (txtBirthday.SelectedDate != null) vHelper.ValueObject.Bday = (DateTime)txtBirthday.SelectedDate.Value;

            //vHelper.ValueObject.HomePhone = txtHomePhone.Text.Trim();
            //vHelper.ValueObject.HomeMobile = txtHomeMobile.Text.Trim();
            //vHelper.ValueObject.HomeFax = txtHomeFax.Text.Trim();
            //vHelper.ValueObject.HomeAdr1 = txtHomeAdr1.Text.Trim();
            //vHelper.ValueObject.HomeAdr2 = txtHomeAdr2.Text.Trim();
            //vHelper.ValueObject.HomeEmail1 = txtHomeEmail1.Text.Trim();
            //vHelper.ValueObject.HomeEmail2 = txtHomeEmail2.Text.Trim();
            //vHelper.ValueObject.Homepage = txtHomepage.Text.Trim();

            //vHelper.ValueObject.Notes = txtNotes.Text.Trim();
            //vHelper.ValueObject.Owner = this.UserId;

            //if (cboGroups.SelectedValue != string.Empty) 
            //    vHelper.ValueObject.GroupID = Convert.ToInt32(cboGroups.SelectedValue);
            //vHelper.ValueObject.Scope = Convert.ToByte(cboScope.SelectedValue);

            //vHelper.ValueObject.Created_At = DateTime.Now;
            //vHelper.ValueObject.Created_By = this.UserId;
            //vHelper.ValueObject.Last_Modified_At = DateTime.Now;
            //vHelper.ValueObject.Last_Modified_By = this.UserId;
            //vHelper.DoSave();

            //lblMessage.Text = "Thông tin Survey đã được cập nhật";
            //txtSurveyId.Text = vHelper.ValueObject.ContactId.ToString();
            //IsUpdate();
        }

        private void DeteleSurvey()
        {
            //SurveysHelper vHelper = new SurveysHelper(new Surveys());
            //vHelper.ValueObject.ContactId = Convert.ToInt32(txtSurveyId.Text.Trim());
            //vHelper.Load();
            //vHelper.Delete();
            //txtSurveyId.Text = "0"; IsUpdate();
            //lblMessage.Text = "Thông tin Survey đã được xóa";
        }

       private void IsUpdate()
       {
           if (txtSurveyId.Text == (0).ToString()) // New mode
           {
               radToolBarDefault.Items.FindItemByValue("Delete").Visible = false;
               radToolBarDefault.Items.FindItemByValue("Export").Visible = false;
               pnUpload.Visible = true;
           }
           else // Update mode
           {
               pnUpload.Visible = false;
           }
       }

        #endregion

        #region "Public Methods"
        #endregion

    }
}
