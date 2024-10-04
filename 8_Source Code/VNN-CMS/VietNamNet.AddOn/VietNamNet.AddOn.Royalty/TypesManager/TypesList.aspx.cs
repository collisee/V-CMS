using System;
using System.Data;
using Telerik.Web.UI;
using VietNamNet.AddOn.Royalty.Components;
using VietNamNet.AddOn.Royalty.Core.Common.ValueObject;
using VietNamNet.AddOn.Royalty.Core.Presentation;
using VietNamNet.Framework.Common;
using Constants = VietNamNet.AddOn.Royalty.Core.Common.Constants;

namespace VietNamNet.AddOn.Royalty
{
    public partial class TypesList : RoyaltyBasePageView
    {
        #region  "Members" 
        private int _RoyaltyId ;
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
                }
              
            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }

        }

        protected void RadToolBarDefaultButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {try
                {
             switch (e.Item.Value)
             {
                 case "search":
                     PopularType(0);
                     break;
                    case "Update":
                       Utilities.Redirect(VietNamNet.AddOn.Royalty.Core.Common.Constants.FormNames.TYPE_EDIT);
                       break;
                  
                    case "Cancel":
                        Response.Redirect("Default.aspx"); break;
                }
            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }
        }



        #endregion

        protected void OnFilterChanged(object sender, EventArgs e)
        {
            PopularType(0);
        }

        protected void GrdViewPageIndexChanged(object source, GridPageChangedEventArgs e)
        {
            PopularType(e.NewPageIndex);
        }

        protected void GrdViewPageSizeChanged(object source, GridPageSizeChangedEventArgs e)
        {

        }

        protected void GrdViewItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case Constants.CommandNames.DELETE:
                        RoyaltyTypesHelper tHelper = new RoyaltyTypesHelper(new RoyaltyTypes());
                        tHelper.ValueObject.Type_Id = int.Parse(e.CommandArgument.ToString());
                        tHelper.ValueObject.Last_Modified_At = DateTime.Now;
                        tHelper.ValueObject.Last_Modified_By = this.UserId;

                        tHelper.Delete();
                        PopularType(radGridDefault.CurrentPageIndex);

                        break;
                    //case Constants.CommandNames.Edit:
                    //    Utilities.Redirect(Core.Common.Constants.FormNames.TYPE_EDIT, Core.Common.Constants.ParameterName.TYPE_ID, e.CommandArgument.ToString());
                    //    break;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + e.CommandArgument;
            }
        }


        #endregion
 
        #region "Private Methods"
        private void SetupEnvironment()
        {
            PopularParentType();

            PopularType(0);
             
           
        } 

        private void PopularType(int pageIndex)
        {
            RadComboBox cboParentType =
                (RadComboBox)radToolBarDefault.Items.FindItemByValue("searchTextBoxButton").FindControl("cboParent");
           // lblMessage.Text = "SelectedValue: " + cboParentType.SelectedValue;
            RoyaltyTypesHelper helper = new RoyaltyTypesHelper(new RoyaltyTypes());
            DataTable dt;
            if (cboParentType.SelectedValue == "x")
            {
                dt = helper.ListAll();
            }
            else
            {
                helper.ValueObject.Parent_Id = int.Parse( cboParentType.SelectedValue );
                dt = helper.ListByParent();
            }
            

            radGridDefault.CurrentPageIndex = pageIndex;
            radGridDefault.DataSource = dt;
            radGridDefault.DataBind();

        }

        private void PopularParentType()
        {
            RadComboBox cboParentType =
                (RadComboBox) radToolBarDefault.Items.FindItemByValue("searchTextBoxButton").FindControl("cboParent");

            RoyaltyTypesHelper helper = new RoyaltyTypesHelper(new RoyaltyTypes());
            helper.ValueObject.Parent_Id = 0;
            DataTable dt = helper.ListByParent();

            cboParentType.DataTextField = "Title";
            cboParentType.DataValueField = "Type_Id";
            cboParentType.DataSource = dt;
            cboParentType.DataBind();

            cboParentType.Items.Insert(0, new RadComboBoxItem("- Toàn bộ -", "x"));
            cboParentType.Items.Insert(1, new RadComboBoxItem("/", "0"));
            
        }   
        #endregion

       #region "Public Methods"
       #endregion

   }
}
