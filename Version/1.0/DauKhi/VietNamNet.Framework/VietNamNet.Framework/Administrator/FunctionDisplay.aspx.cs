using System;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;

namespace VietNamNet.Framework.Administrator
{
    public partial class FunctionDisplay : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isViewer)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                //Load Data
                int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
                if (docId > 0)
                {
                    FunctionHelper helper = new FunctionHelper(new System.ValueObject.Function());
                    helper.ValueObject.Id = docId;
                    helper.LoadEncode();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    BindData(helper.ValueObject);
                    AuditTrail1.Get(helper.ValueObject);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = helper.ValueObject.Id;

                    //check save success
                    if (Utilities.ParseInt(Request.Params[Constants.ParameterName.SAVE_SUCCESS]) == 1)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = Utilities.GetConfigKey(SystemConstants.Message.SaveSuccess);
                    }
                }
                else
                {
                    Utilities.ItemDoesntExist();
                }
            }
            else
            {
                lblMessage.Visible = false;
            }

            //show hide AddNew button
            radToolBarDefault.Items[0].Visible = radToolBarDefault.Items[0].Enabled = isAddNewer;
            radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = isUpdater;
            radToolBarDefault.Items[2].Visible = radToolBarDefault.Items[2].Enabled = isDeleter;
            radToolBarDefault.Items[3].Visible = radToolBarDefault.Items[3].Enabled = isAddNewer;
        }

        private void Initialize()
        {
            moduleAlias = "System.Module";
            viewAlias = "System.Module.View";
            addNewAlias = "System.Module.AddNew";
            updateAlias = "System.Module.Update";
            deleteAlias = "System.Module.Delete";
        }

        private string GetModuleName(int mid)
        {
            ModuleHelper helper = new ModuleHelper(new System.ValueObject.Module());
            helper.ValueObject.Id = mid;
            helper.LoadEncode();

            return (helper.ValueObject != null) ? helper.ValueObject.Name : string.Empty;
        }

        private void BindData(System.ValueObject.Function o)
        {
            lblModule.Text = GetModuleName(o.ModuleId);
            lblOrd.Text = Utilities.DisplayNumberFormat(o.Ord);
            lblName.Text = o.Name;
            lblAlias.Text = o.Alias;
            lblDetail.Text = o.Detail;
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            string goback = Request.Params[Constants.ParameterName.GOBACK];

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(SystemConstants.FormNames.Administrator.FunctionEdit);
                    break;
                case Constants.CommandNames.Edit:
                    if (Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.DOC_ID]))
                    {
                        Utilities.ItemDoesntExist();
                    }
                    else
                    {
                        Utilities.Redirect(SystemConstants.FormNames.Administrator.FunctionEdit,
                                             Request.Params[Constants.ParameterName.DOC_ID]);
                    }
                    break;
                case Constants.CommandNames.Delete:

                    FunctionHelper helper = new FunctionHelper(new System.ValueObject.Function());
                    helper.ValueObject.Id = docId;
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;
                    helper.Delete();

                    //Go to View
                    Utilities.GoBackToView(SystemConstants.FormNames.Administrator.FunctionView);
                    break;
                case Constants.CommandNames.Copy:
                    string strCopy =
                        string.Format("{0}?{1}={2}&{3}={4}", SystemConstants.FormNames.Administrator.FunctionEdit,
                                      Constants.ParameterName.COPY_ID, docId,
                                      Constants.ParameterName.GOBACK, goback);
                    Response.Redirect(strCopy);
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(SystemConstants.FormNames.Administrator.FunctionView);
                    break;
                default:
                    break;
            }
        }
    }
}