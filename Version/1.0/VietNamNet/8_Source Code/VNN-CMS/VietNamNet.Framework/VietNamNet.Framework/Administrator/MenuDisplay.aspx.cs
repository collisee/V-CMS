using System;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;
using Menu=VietNamNet.Framework.System.ValueObject.Menu;

namespace VietNamNet.Framework.Administrator
{
    public partial class MenuDisplay : BasePage
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
                    MenuHelper helper = new MenuHelper(new Menu());
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
            moduleAlias = "System.Configuration";
            viewAlias = "System.Configuration.View";
            addNewAlias = "System.Configuration.AddNew";
            updateAlias = "System.Configuration.Update";
            deleteAlias = "System.Configuration.Delete";
        }

        private void BindDataToFunction(int mid, int values)
        {
            FunctionHelper helper = new FunctionHelper(new Function());
            helper.ValueObject.ModuleId = mid;
            cblFunctions.DataSource = helper.GetFunctionByModuleId();
            cblFunctions.DataBind();

            foreach (ListItem item in cblFunctions.Items)
            {
                int ord = Utilities.ParseInt(item.Value);
                int value = 1 << (ord - 1);
                item.Selected = (values & value) == value;
            }
        }

        private void BindData(Menu o)
        {
            lblParentName.Text = Nulls.IsNullOrEmpty(o.ParentDisplayName) ? "Root" : o.ParentDisplayName;
            lblOrder.Text = Utilities.DisplayNumberFormat(o.Ord);
            lblName.Text = o.Name;
            lblDisplayName.Text = o.DisplayName;
            lblLink.Text = o.Link;
            lblModuleName.Text = o.ModuleName;
            BindDataToFunction(o.ModuleId, o.Access);
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            string goback = Request.Params[Constants.ParameterName.GOBACK];

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(SystemConstants.FormNames.Administrator.MenuEdit);
                    break;
                case Constants.CommandNames.Edit:
                    if (Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.DOC_ID]))
                    {
                        Utilities.ItemDoesntExist();
                    }
                    else
                    {
                        Utilities.Redirect(SystemConstants.FormNames.Administrator.MenuEdit,
                                           Request.Params[Constants.ParameterName.DOC_ID]);
                    }
                    break;
                case Constants.CommandNames.Delete:

                    MenuHelper helper = new MenuHelper(new Menu());
                    helper.ValueObject.Id = docId;
                    helper.Delete();

                    //Go to View
                    Utilities.GoBackToView(SystemConstants.FormNames.Administrator.MenuView);
                    break;
                case Constants.CommandNames.Copy:
                    string strCopy =
                        string.Format("{0}?{1}={2}&{3}={4}", SystemConstants.FormNames.Administrator.MenuEdit,
                                      Constants.ParameterName.COPY_ID, docId,
                                      Constants.ParameterName.GOBACK, goback);
                    Response.Redirect(strCopy);
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(SystemConstants.FormNames.Administrator.MenuView);
                    break;
                default:
                    break;
            }
        }
    }
}