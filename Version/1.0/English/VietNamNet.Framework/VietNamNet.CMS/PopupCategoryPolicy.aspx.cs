using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.DBAccess;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS
{
    public partial class PopupCategoryPolicy : BasePage
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
                int mId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
                BindDataToCategory(mId);
                BindDataToCategoryPolicy(mId);

                //show hide Save button
                radToolBarDefault.Items[0].Visible = radToolBarDefault.Items[0].Enabled = isUpdater;
            }
        }

        private void Initialize()
        {
            dynamicLayout = false;
            moduleAlias = "System.Policy";
            viewAlias = "System.Policy.View";
            updateAlias = "System.Policy.Edit";
            lblMessage.Visible = false;
            ErrorMessage1.Visible = false;
            ErrorMessage1.ClearMessage();
        }

        private void BindDataToCategoryPolicy(int mid)
        {
            CategoryPolicyHelper helper = new CategoryPolicyHelper(new CategoryPolicy());
            helper.ValueObject.CategoryId = mid;
            radGridDefault.DataSource = helper.GetPolicyByCategory();
            radGridDefault.DataBind();
        }

        private void BindDataToCategory(int GId)
        {
            CategoryHelper helper = new CategoryHelper(new Category());
            radCmbCategory.DataSource = helper.ListAll();
            radCmbCategory.DataBind();
            if (GId > 0) radCmbCategory.SelectedValue = GId.ToString();
        }

        private void DoSave()
        {
            CheckBox chkPolicy;
            HiddenField id;
            HiddenField gid;
            HiddenField cid;

            DataTable dt = CategoryPolicyDAO.GetTemplateTable();
            for (int i = 0; i < radGridDefault.Items.Count; i++)
            {
                try
                {
                    chkPolicy = (CheckBox)radGridDefault.Items[i].FindControl(CMSConstants.Policies.ControlNames.CheckboxPolicy);
                    id = (HiddenField)radGridDefault.Items[i].FindControl(CMSConstants.Policies.ControlNames.HiddenFieldId);
                    gid = (HiddenField)radGridDefault.Items[i].FindControl(CMSConstants.Policies.ControlNames.HiddenFieldGId);
                    cid = (HiddenField)radGridDefault.Items[i].FindControl(CMSConstants.Policies.ControlNames.HiddenFieldCId);

                    DataRow dr = dt.NewRow();
                    dr[CMSConstants.Entities.CategoryPolicy.FieldName.Id] = Utilities.ParseInt(id.Value);
                    dr[CMSConstants.Entities.CategoryPolicy.FieldName.GroupId] = Utilities.ParseInt(gid.Value);
                    dr[CMSConstants.Entities.CategoryPolicy.FieldName.CategoryId] = Utilities.ParseInt(cid.Value);
                    dr[CMSConstants.Entities.CategoryPolicy.FieldName.Val] = chkPolicy.Checked ? 1 : 0;
                    dr[CMSConstants.Entities.CategoryPolicy.FieldName.Created_At] = DateTime.Now;
                    dr[CMSConstants.Entities.CategoryPolicy.FieldName.Created_By] = UserId;
                    dr[CMSConstants.Entities.CategoryPolicy.FieldName.Last_Modified_At] = DateTime.Now;
                    dr[CMSConstants.Entities.CategoryPolicy.FieldName.Last_Modified_By] = UserId;
                    dt.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                    ErrorMessage1.AddMessage(ex.Message);
                    ErrorMessage1.Visible = true;
                    SystemLogging.Error("CMS-PopupCategoryPolicy::DoSave:Error", ex.Message);
                    return;
                }
            }

            CategoryPolicyHelper helper = new CategoryPolicyHelper(new CategoryPolicy());
            helper.SavePolicyByCategory(dt);

            lblMessage.Visible = true;
            lblMessage.Text = Utilities.GetConfigKey(SystemConstants.Message.SaveSuccess);

            //rebind data
            int mId = Utilities.ParseInt(radCmbCategory.SelectedValue);
            BindDataToCategoryPolicy(mId);
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
                    Utilities.GoBackToView(Constants.FormNames.Default);
                    break;
                default:
                    break;
            }
        }

        protected void radGridDefault_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridGroupHeaderItem)
            {
                GridGroupHeaderItem item = (GridGroupHeaderItem) e.Item;
                item.DataCell.Text = item.DataCell.Text.Replace(":", string.Empty).Trim();
                if (Nulls.IsNullOrEmpty(item.DataCell.Text))
                {
                    item.DataCell.Text = "&nbsp;";
                }
            }
        }

        protected void radCmbCategory_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int mId = Utilities.ParseInt(radCmbCategory.SelectedValue);
            BindDataToCategoryPolicy(mId);
        }

        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }
    }
}