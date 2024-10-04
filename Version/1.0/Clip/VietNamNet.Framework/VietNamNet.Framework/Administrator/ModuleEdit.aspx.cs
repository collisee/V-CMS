using System;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;

namespace VietNamNet.Framework.Administrator
{
    public partial class ModuleEdit : BasePage
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

                    ModuleHelper helper = new ModuleHelper(new System.ValueObject.Module());
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
            moduleAlias = "System.Module";
            viewAlias = "System.Module.View";
            addNewAlias = "System.Module.AddNew";
            updateAlias = "System.Module.Update";
            deleteAlias = "System.Module.Delete";
            ErrorMessage1.ClearMessage();
            ErrorMessage1.Visible = false;
        }

        private void BindData(System.ValueObject.Module o)
        {
            txtName.Text = o.Name;
            txtAlias.Text = o.Alias;
            txtDetail.Text = o.Detail;
        }

        private bool GetData(System.ValueObject.Module o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

            ModuleHelper helper = new ModuleHelper(new System.ValueObject.Module());
            helper.ValueObject.Id = docId;
            helper.ValueObject.Alias = txtAlias.Text.Trim();
            helper.GetModuleByAlias();

            if (helper.ValueObject != null)
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.AliasExisted));
                ErrorMessage1.Visible = true;
                return false;
            }

            o.Id = docId;
            o.Name = txtName.Text.Trim();
            o.Alias = txtAlias.Text.Trim();
            o.Detail = txtDetail.Text.Trim();

            return true;
        }

        private void DoSave()
        {
            ModuleHelper helper = new ModuleHelper(new System.ValueObject.Module());
            if (GetData(helper.ValueObject))
            {
                AuditTrail1.Set(helper.ValueObject);
                helper.DoSave();

                //Redirect to Diplay page
                Utilities.Redirect(SystemConstants.FormNames.Administrator.ModuleDisplay,
                                   helper.ValueObject.Id.ToString(), true);
            }
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.Save:
                    DoSave();
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(SystemConstants.FormNames.Administrator.ModuleView);
                    break;
                default:
                    break;
            }
        }
    }
}