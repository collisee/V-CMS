using System;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;

namespace VietNamNet.Framework.Administrator
{
    public partial class ConfigurationEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                //Load Data
                int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
                if (docId > 0) //update
                {
                    if (!isUpdater)
                    {
                        Utilities.NoRightToAccess();
                    }

                    ConfigurationHelper helper = new ConfigurationHelper(new System.ValueObject.Configuration());
                    helper.ValueObject.Id = docId;
                    helper.Load();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    BindData(helper.ValueObject);
                    AuditTrail1.Get(helper.ValueObject);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = helper.ValueObject.Id;
                }
                else //add new
                {
                    if (!isAddNewer)
                    {
                        Utilities.NoRightToCreate();
                    }

                    AuditTrail1.Get(null);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = 0;
                }

                //Focus
                txtName.Focus();
            }
        }

        private void Initialize()
        {
            moduleAlias = "System.Configuration";
            viewAlias = "System.Configuration.View";
            addNewAlias = "System.Configuration.AddNew";
            updateAlias = "System.Configuration.Update";
            deleteAlias = "System.Configuration.Delete";
            ErrorMessage1.ClearMessage();
            ErrorMessage1.Visible = false;
        }

        private void BindData(System.ValueObject.Configuration o)
        {
            txtName.Text = o.Name;
            txtVal.Text = o.Val;
            txtDetail.Text = o.Detail;
        }

        private bool GetData(System.ValueObject.Configuration o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

            ConfigurationHelper helper = new ConfigurationHelper(new System.ValueObject.Configuration());
            helper.ValueObject.Id = docId;
            helper.ValueObject.Name = txtName.Text.Trim();
            helper.GetConfiguration();

            if (helper.ValueObject != null && helper.ValueObject.Id != docId)
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.NameExisted));
                ErrorMessage1.Visible = true;
                return false;
            }

            o.Id = docId;
            o.Name = txtName.Text.Trim();
            o.Val = txtVal.Text.Trim();
            o.Detail = txtDetail.Text.Trim();

            return true;
        }

        private void DoSave()
        {
            ConfigurationHelper helper = new ConfigurationHelper(new System.ValueObject.Configuration());
            if (GetData(helper.ValueObject))
            {
                AuditTrail1.Set(helper.ValueObject);
                helper.DoSave();

                //Redirect to Diplay page
                Utilities.Redirect(SystemConstants.FormNames.Administrator.ConfigurationDisplay,
                                   helper.ValueObject.Id.ToString(), true);
            }
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.Save:
                    DoSave();
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(SystemConstants.FormNames.Administrator.ConfigurationView);
                    break;
                default:
                    break;
            }
        }
    }
}