using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;
using Menu=VietNamNet.Framework.System.ValueObject.Menu;

namespace VietNamNet.Framework.Administrator
{
    public partial class MenuEdit : BasePage
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

                    MenuHelper helper = new MenuHelper(new Menu());
                    helper.ValueObject.Id = docId;
                    helper.Load();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    BindDataToMenuParent();
                    BindDataToModule();
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

                    int copyId = Utilities.ParseInt(Request.Params[Constants.ParameterName.COPY_ID]);
                    if (copyId > 0)
                    {
                        MenuHelper helper = new MenuHelper(new Menu());
                        helper.ValueObject.Id = copyId;
                        helper.Load();

                        if (helper.ValueObject == null)
                        {
                            Utilities.ItemDoesntExist();
                        }

                        BindDataToMenuParent();
                        BindDataToModule();
                        helper.ValueObject.Ord += 1;
                        BindData(helper.ValueObject);
                    }
                    else
                    {
                        BindDataToMenuParent();
                        BindDataToModule();
                        int pId = Utilities.ParseInt(Request.Params[Constants.ParameterName.PARENT_ID]);
                        SetMenuParent(pId);
                        BindDataToFunction(0, 0);
                        hidAccess.Value = "0";
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
            ErrorMessage1.Visible = false;
            ErrorMessage1.ClearMessage();
        }

        private void SetMenuParent(int id)
        {
            MenuHelper helper = new MenuHelper(new Menu());
            helper.ValueObject.Id = id;
            helper.Load();

            if (helper.ValueObject != null)
            {
                SetMenuParentValue(helper.ValueObject.Id);
                SetModuleValue(helper.ValueObject.ModuleId);
                BindDataToFunction(helper.ValueObject.ModuleId, helper.ValueObject.Access);
                hidAccess.Value = helper.ValueObject.Access.ToString();
            }
            else
            {
                SetMenuParentValue(id);
            }
        }

        private static DataTable ProcessMenu(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr[SystemConstants.Entities.Menu.FieldName.PId] =
                    Utilities.ParseInt(dr[SystemConstants.Entities.Menu.FieldName.PId]);
            }

            DataRow drNew = dt.NewRow();
            drNew[SystemConstants.Entities.Menu.FieldName.Id] = 0;
            drNew[SystemConstants.Entities.Menu.FieldName.PId] = DBNull.Value;
            drNew[SystemConstants.Entities.Menu.FieldName.Name] = "Root";
            drNew[SystemConstants.Entities.Menu.FieldName.DisplayName] = "Root";

            dt.Rows.InsertAt(drNew, 0);
            return dt;
        }

        private void BindDataToMenuParent()
        {
            RadTreeView radTreeViewMenu = (RadTreeView) radCmbParent.Items[0].FindControl("radTreeViewMenu");
            radTreeViewMenu.DataFieldID = SystemConstants.Entities.Menu.FieldName.Id;
            radTreeViewMenu.DataFieldParentID = SystemConstants.Entities.Menu.FieldName.PId;
            radTreeViewMenu.DataTextField = SystemConstants.Entities.Menu.FieldName.DisplayName;
            radTreeViewMenu.DataValueField = SystemConstants.Entities.Menu.FieldName.Id;
            //radTreeViewMenu.OnClientNodeClicking = "nodeClicking";

            MenuHelper helper = new MenuHelper(new Menu());
            radTreeViewMenu.DataSource = ProcessMenu(helper.ListAll());
            radTreeViewMenu.DataBind();
        }

        private void SetMenuParentValue(int PId)
        {
            //if (PId < 0) return;
            RadTreeView radTreeViewMenu = (RadTreeView) radCmbParent.Items[0].FindControl("radTreeViewMenu");
            if (radTreeViewMenu != null)
            {
                RadTreeNode selectedNode = radTreeViewMenu.FindNodeByValue(PId.ToString());
                if (selectedNode != null)
                {
                    selectedNode.Selected = true;
                    selectedNode.Expanded = true;
                    while (selectedNode.ParentNode != null)
                    {
                        selectedNode.ParentNode.Expanded = true;
                        selectedNode = selectedNode.ParentNode;
                    }
                }
            }
        }

        private int GetMenuParentValue()
        {
            RadTreeView radTreeViewMenu = (RadTreeView) radCmbParent.Items[0].FindControl("radTreeViewMenu");
            return (radTreeViewMenu != null) ? Utilities.ParseInt(radTreeViewMenu.SelectedValue) : 0;
        }

        private void BindDataToFunction(int mid, int values)
        {
            FunctionHelper helper = new FunctionHelper(new Function());
            helper.ValueObject.ModuleId = (mid > 0) ? mid : Utilities.ParseInt(radCmbModule.SelectedValue);
            cblFunctions.DataSource = helper.GetFunctionByModuleId();
            cblFunctions.DataBind();

            if (values > 0)
            {
                foreach (ListItem item in cblFunctions.Items)
                {
                    int ord = Utilities.ParseInt(item.Value);
                    int value = 1 << (ord - 1);
                    item.Selected = (values & value) == value;
                }
            }
        }

        private void BindDataToModule()
        {
            ModuleHelper helper = new ModuleHelper(new System.ValueObject.Module());
            radCmbModule.DataSource = helper.ListAll();
            radCmbModule.DataTextField = SystemConstants.Entities.Module.FieldName.Name;
            radCmbModule.DataValueField = SystemConstants.Entities.Module.FieldName.Id;
            radCmbModule.DataBind();
        }

        private void SetModuleValue(int MId)
        {
            if (MId <= 0) return;
            radCmbModule.SelectedValue = MId.ToString();
        }

        private void BindData(Menu o)
        {
            SetMenuParentValue(o.PId);
            txtOrder.Text = o.Ord.ToString();
            hidOldOrd.Value = o.Ord.ToString();
            txtName.Text = o.Name;
            txtDisplayName.Text = o.DisplayName;
            txtLink.Text = o.Link;
            SetModuleValue(o.ModuleId);
            BindDataToFunction(o.ModuleId, o.Access);
            hidAccess.Value = o.Access.ToString();
        }

        private bool GetData(Menu o)
        {
            bool ret = true;
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            int pid = GetMenuParentValue();

            //Check Menu Parent
            if (docId > 0 && docId == pid)
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.MenuParentError));
                ret = false;
            }

            //Check Name
            if (Nulls.IsNullOrEmpty(txtName.Text))
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.NameCantEmpty));
                ret = false;
            }

            //Check DisplayName
            if (Nulls.IsNullOrEmpty(txtDisplayName.Text))
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.DisplayNameCantEmpty));
                ret = false;
            }

            o.Id = docId;
            o.PId = pid;
            o.Ord = Utilities.ParseInt(txtOrder.Text);
            o.OldOrd = Utilities.ParseInt(hidOldOrd.Value);
            o.Name = txtName.Text.Trim();
            o.DisplayName = txtDisplayName.Text.Trim();
            o.Link = txtLink.Text.Trim();
            o.ModuleId = Utilities.ParseInt(radCmbModule.SelectedValue);

            //get access
            int access = 0;
            foreach (ListItem item in cblFunctions.Items)
            {
                if (item.Selected)
                {
                    int ord = Utilities.ParseInt(item.Value);
                    access |= 1 << (ord - 1);
                }
            }

            o.Access = access;

            return ret;
        }

        private void DoSave()
        {
            MenuHelper helper = new MenuHelper(new Menu());
            if (!GetData(helper.ValueObject))
            {
                return;
            }
            AuditTrail1.Set(helper.ValueObject);
            helper.DoSave();

            //Redirect to Diplay page
            Utilities.Redirect(SystemConstants.FormNames.Administrator.MenuDisplay, helper.ValueObject.Id.ToString(), true);
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
                    Utilities.GoBackToView(SystemConstants.FormNames.Administrator.MenuView);
                    break;
                default:
                    break;
            }
        }

        protected void radCmbModule_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int access = Utilities.ParseInt(hidAccess.Value);
            BindDataToFunction(0, access);
        }
    }
}