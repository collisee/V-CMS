using System;
using System.Data;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS
{
    public partial class CategoryEdit : BasePage
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

                    CategoryHelper helper = new CategoryHelper(new Category());
                    helper.ValueObject.Id = docId;
                    helper.Load();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    BindDataToCategoryParent();
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
                        CategoryHelper helper = new CategoryHelper(new Category());
                        helper.ValueObject.Id = copyId;
                        helper.Load();

                        if (helper.ValueObject == null)
                        {
                            Utilities.ItemDoesntExist();
                        }

                        BindDataToCategoryParent();
                        helper.ValueObject.Ord += 1;
                        BindData(helper.ValueObject);
                    }
                    else
                    {
                        BindDataToCategoryParent();
                        int pId = Utilities.ParseInt(Request.Params[Constants.ParameterName.PARENT_ID]);
                        SetCategoryParentValue(pId);
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
            moduleAlias = "VietNamNet.CMS.Category";
            viewAlias = "VietNamNet.CMS.Category.View";
            addNewAlias = "VietNamNet.CMS.Category.AddNew";
            updateAlias = "VietNamNet.CMS.Category.Update";
            deleteAlias = "VietNamNet.CMS.Category.Delete";
            ErrorMessage1.ClearMessage();
            ErrorMessage1.Visible = false;
        }

        private static DataTable ProcessCategory(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr[CMSConstants.Entities.Category.FieldName.PId] =
                    Utilities.ParseInt(dr[CMSConstants.Entities.Category.FieldName.PId]);
            }

            DataRow drNew = dt.NewRow();
            drNew[CMSConstants.Entities.Category.FieldName.Id] = 0;
            drNew[CMSConstants.Entities.Category.FieldName.PId] = DBNull.Value;
            drNew[CMSConstants.Entities.Category.FieldName.Name] = "Root";
            drNew[CMSConstants.Entities.Category.FieldName.DisplayName] = "Root";

            dt.Rows.InsertAt(drNew, 0);
            return dt;
        }

        private void BindDataToCategoryParent()
        {
            RadTreeView radTreeViewCategory = (RadTreeView)cmbParent.Items[0].FindControl("radTreeViewCategory");
            radTreeViewCategory.DataFieldID = CMSConstants.Entities.Category.FieldName.Id;
            radTreeViewCategory.DataFieldParentID = CMSConstants.Entities.Category.FieldName.PId;
            radTreeViewCategory.DataTextField = CMSConstants.Entities.Category.FieldName.DisplayName;
            radTreeViewCategory.DataValueField = CMSConstants.Entities.Category.FieldName.Id;

            CategoryHelper helper = new CategoryHelper(new Category());
            radTreeViewCategory.DataSource = ProcessCategory(helper.ListAll());
            radTreeViewCategory.DataBind();
        }

        private void SetCategoryParentValue(int PId)
        {
            if (PId < 0) return;
            RadTreeView radTreeViewCategory = (RadTreeView)cmbParent.Items[0].FindControl("radTreeViewCategory");
            if (radTreeViewCategory != null)
            {
                RadTreeNode selectedNode = radTreeViewCategory.FindNodeByValue(PId.ToString());
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

        private int GetCategoryParentValue()
        {
            RadTreeView radTreeViewCategory = (RadTreeView)cmbParent.Items[0].FindControl("radTreeViewCategory");
            return (radTreeViewCategory != null) ? Utilities.ParseInt(radTreeViewCategory.SelectedValue) : 0;
        }

        private void BindData(Category o)
        {
            txtPartitionId.Value = o.PartitionId;
            SetCategoryParentValue(o.PId);
            txtOrd.Value = o.Ord;
            hidOldOrd.Value = o.Ord.ToString();
            txtName.Text = o.Name;
            txtAlias.Text = o.Alias;
            txtDisplayName.Text = o.DisplayName;
            txtUrl.Text = o.Url;
            txtDetail.Text = o.Detail;
        }

        private bool GetData(Category o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            int pid = GetCategoryParentValue();

            bool flag = true;

            //Check Menu Parent
            if (docId > 0 && docId == pid)
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.CategoryParentError));
                flag = false;
            }

            //Check Name
            if (Nulls.IsNullOrEmpty(txtName.Text))
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.NameCantEmpty));
                flag = false;
            }

            //Check DisplayName
            if (Nulls.IsNullOrEmpty(txtDisplayName.Text))
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.DisplayNameCantEmpty));
                flag = false;
            }

            //Check Url
            if (Nulls.IsNullOrEmpty(txtUrl.Text))
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.UrlCantEmpty));
                flag = false;
            }

            //Alias
            CategoryHelper helper = new CategoryHelper(new Category());
            helper.ValueObject.Id = docId;
            helper.ValueObject.Alias = txtAlias.Text.Trim();
            helper.GetCategoryByAlias();

            if (helper.ValueObject != null)
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.AliasExisted));
                ErrorMessage1.Visible = true;
                flag = false;
            }

            if (!flag) return false;

            o.Id = docId;
            o.PartitionId = Utilities.ParseInt(txtPartitionId.Value);
            o.PId = pid;
            o.Ord = Utilities.ParseInt(txtOrd.Value);
            o.OldOrd = Utilities.ParseInt(hidOldOrd.Value);
            o.Name = txtName.Text.Trim();
            o.Alias = txtAlias.Text.Trim();
            o.DisplayName = txtDisplayName.Text.Trim();
            o.Url = txtUrl.Text.Trim();
            o.Detail = txtDetail.Text.Trim();

            return true;
        }

        private void DoSave()
        {
            CategoryHelper helper = new CategoryHelper(new Category());
            if (GetData(helper.ValueObject))
            {
                AuditTrail1.Set(helper.ValueObject);
                helper.DoSave();

                //Redirect to Diplay page
                Utilities.Redirect(CMSConstants.FormNames.CMS.CategoryDisplay,
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
                    Utilities.GoBackToView(CMSConstants.FormNames.CMS.CategoryView);
                    break;
                default:
                    break;
            }
        }
    }
}