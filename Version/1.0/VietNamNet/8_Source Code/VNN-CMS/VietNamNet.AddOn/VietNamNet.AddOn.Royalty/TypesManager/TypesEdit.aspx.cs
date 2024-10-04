using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.AddOn.Royalty.Components;
using VietNamNet.AddOn.Royalty.Core.Common.ValueObject;
using VietNamNet.AddOn.Royalty.Core.Presentation;
using VietNamNet.Framework.Common;
using Constants = VietNamNet.AddOn.Royalty.Core.Common.Constants;

namespace VietNamNet.AddOn.Royalty
{
    public partial class TypesEdit : RoyaltyBasePage
    {
        #region  "Members" 
        private int _TypeId ;
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
            
               base.PageLoad();

               if (!isTypesManager)
               {
                   Utilities.NoRightToAccess();
               }

                if (!IsPostBack)
                {
                    SetupEnvironment();

                    if (Request.Params[Constants.ParameterName.TYPE_ID] != null && int.TryParse(Request.Params[Constants.ParameterName.TYPE_ID],out _TypeId ))
                    {
                        _TypeId = int.Parse(Request.Params[Constants.ParameterName.TYPE_ID]);
                        PopularItem(_TypeId);
                    }
                }
               
            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }

        }

        protected void radToolBarDefault_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
             switch (e.Item.Value)
                {
                    case "Update":
                        UpdateItem(); break;
                    case "Delete":
                        DeleteItem(); break;
                    case "Cancel":
                        Response.Redirect("Default.aspx"); break;
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

        #endregion
 
        #region "Private Methods"
        private void SetupEnvironment()
        {
            PopularParentType();
             
           
        } 

        private void PopularParentType()
        {

            RoyaltyTypesHelper helper = new RoyaltyTypesHelper(new RoyaltyTypes());
            helper.ValueObject.Parent_Id = 0;
            DataTable dt = helper.ListByParent();

            cboParentType.DataTextField = "Title";
            cboParentType.DataValueField = "Type_Id";
            cboParentType.DataSource = dt;
            cboParentType.DataBind();

            cboParentType.Items.Insert(0, new RadComboBoxItem("/", "0"));
        }   

        private void PopularItem(int TypeId)
        {
            RoyaltyTypesHelper helper = new RoyaltyTypesHelper(new RoyaltyTypes());
            helper.ValueObject.Type_Id = TypeId;
            helper.Load();

            if (helper.ValueObject == null)
            {
                Utilities.ItemDoesntExist();
            }else
            {
                ((RadToolBarButton) radToolBarDefault.Items.FindItemByValue("Delete")).Visible = true;

                RoyaltyTypes obj = helper.ValueObject;

                txtTypeId.Text = obj.Type_Id.ToString();
                txtTitle.Text = obj.Title ;
                txtDescription.Text = obj.Description;
                txtMinValue.Text = obj.MIN_VAL.ToString();
                txtMaxValue.Text = obj.MAX_VAL.ToString();

                if (cboParentType.Items.FindItemByValue(obj.Parent_Id.ToString()) != null)
                {
                    cboParentType.Items.FindItemByValue(obj.Parent_Id.ToString()).Selected = true;
                }
            }
             
        }

        private void UpdateItem()
        {
            // Valid
            if (txtTitle.Text.Trim().Length <= 5)
                throw new Exception("Hãy nhập thông tin tiêu đề!");


            // Do save
            RoyaltyTypesHelper tHelper = new RoyaltyTypesHelper(new RoyaltyTypes());
            tHelper.ValueObject.Type_Id = int.Parse(txtTypeId.Text.Trim());
            
            tHelper.ValueObject.Title = txtTitle.Text.Trim();
            tHelper.ValueObject.Description = txtDescription.Text.Trim();
            tHelper.ValueObject.Parent_Id = int.Parse(cboParentType.SelectedValue);
            tHelper.ValueObject.MIN_VAL = int.Parse(txtMinValue.Value.ToString());
            tHelper.ValueObject.MAX_VAL = int.Parse(txtMaxValue.Value.ToString());
             
           // if (txtBirthday.SelectedDate != null) tHelper.ValueObject.Bday = (DateTime)txtBirthday.SelectedDate.Value;

            tHelper.ValueObject.Created_At = DateTime.Now;
            tHelper.ValueObject.Created_By = this.UserId;
            tHelper.ValueObject.Last_Modified_At = DateTime.Now;
            tHelper.ValueObject.Last_Modified_By = this.UserId;
            tHelper.DoSave();

            lblMessage.Text = Utilities.GetConfigKey(Constants.Message.RoyaltyTypesUpdated);
            
        }
      
        private void DeleteItem()
        {
            if (int.Parse(txtTypeId.Text.Trim()) != 0)
            {
                RoyaltyTypesHelper tHelper = new RoyaltyTypesHelper(new RoyaltyTypes());
                tHelper.ValueObject.Type_Id = int.Parse(txtTypeId.Text.Trim());
                tHelper.ValueObject.Last_Modified_At = DateTime.Now;
                tHelper.ValueObject.Last_Modified_By = this.UserId;

                tHelper.Delete();

                lblMessage.Text = Utilities.GetConfigKey(Constants.Message.RoyaltyTypesDeleted);
            }
        }
        #endregion

        #region "Public Methods"
       #endregion

   }
}
