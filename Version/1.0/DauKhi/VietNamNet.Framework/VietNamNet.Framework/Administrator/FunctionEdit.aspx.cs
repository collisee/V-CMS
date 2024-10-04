using System;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.Administrator
{
    public partial class FunctionEdit : BasePage
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
                if (docId > 0) // update
                {
                    if (!isUpdater)
                    {
                        Utilities.NoRightToAccess();
                    }

                    FunctionHelper helper = new FunctionHelper(new Function());
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
                else // add new
                {
                    if (!isAddNewer)
                    {
                        Utilities.NoRightToCreate();
                    }


                    int copyId = Utilities.ParseInt(Request.Params[Constants.ParameterName.COPY_ID]);
                    if (copyId > 0)
                    {
                        FunctionHelper helper = new FunctionHelper(new Function());
                        helper.ValueObject.Id = copyId;
                        helper.Load();

                        if (helper.ValueObject == null)
                        {
                            Utilities.ItemDoesntExist();
                        }

                        BindData(helper.ValueObject);
                        //AuditTrail1.Get(helper.ValueObject);
                    }
                    else
                    {
                        int mid = Utilities.ParseInt(Request[SystemConstants.ParameterName.MODULE_ID]);
                        BindDataToModule(mid);
                        txtAlias.Text = GetModuleAlias(Utilities.ParseInt(cmbModule.SelectedValue));
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

        private string GetModuleAlias(int mid)
        {
            ModuleHelper helper = new ModuleHelper(new System.ValueObject.Module());
            helper.ValueObject.Id = mid;
            helper.Load();

            return helper.ValueObject != null ? helper.ValueObject.Alias : string.Empty;
        }

        private void BindDataToModule(int mid)
        {
            ModuleHelper helper = new ModuleHelper(new System.ValueObject.Module());
            cmbModule.DataSource = helper.ListAll();
            cmbModule.DataBind();
            if (mid > 0) cmbModule.SelectedValue = mid.ToString();
        }

        private void BindData(Function o)
        {
            BindDataToModule(o.ModuleId);
            txtOrd.Value = o.Ord;
            hidOldOrd.Value = o.Ord.ToString();
            txtName.Text = o.Name;
            txtAlias.Text = o.Alias;
            txtDetail.Text = o.Detail;
        }

        private bool GetData(Function o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

            FunctionHelper helper = new FunctionHelper(new Function());
            helper.ValueObject.Id = docId;
            helper.ValueObject.Alias = txtAlias.Text.Trim();
            helper.GetFunctionByAlias();

            if (helper.ValueObject != null)
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.AliasExisted));
                ErrorMessage1.Visible = true;
                return false;
            }

            o.Id = docId;
            o.ModuleId = Utilities.ParseInt(cmbModule.SelectedValue);
            o.Ord = Utilities.ParseInt(txtOrd.Value);
            o.OldOrd = Utilities.ParseInt(hidOldOrd.Value);
            o.Name = txtName.Text.Trim();
            o.Alias = txtAlias.Text.Trim();
            o.Detail = txtDetail.Text.Trim();

            return true;
        }

        private void DoSave()
        {
            FunctionHelper helper = new FunctionHelper(new Function());
            if (GetData(helper.ValueObject))
            {
                AuditTrail1.Set(helper.ValueObject);
                helper.DoSave();

                //Redirect to Diplay page
                Utilities.Redirect(SystemConstants.FormNames.Administrator.FunctionDisplay,
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
                    Utilities.GoBackToView(SystemConstants.FormNames.Administrator.FunctionView);
                    break;
                default:
                    break;
            }
        }

        protected void cmbModule_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            txtAlias.Text = GetModuleAlias(Utilities.ParseInt(cmbModule.SelectedValue));
        }
    }
}