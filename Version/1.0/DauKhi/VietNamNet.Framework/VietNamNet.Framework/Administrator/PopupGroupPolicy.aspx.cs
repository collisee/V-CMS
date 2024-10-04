using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.Framework.Administrator.UserControls;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.DBAccess;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.Administrator
{
    public partial class PopupGroupPolicy : BasePage
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
                int gId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
                BindDataToGroup(gId);
                BindDataToPolicy(gId);

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

        private void BindDataToPolicy(int gid)
        {
            PolicyHelper helper = new PolicyHelper(new Policy());
            helper.ValueObject.GroupId = gid;
            radGridDefault.DataSource = helper.GetPolicyByGroup();
            radGridDefault.DataBind();
        }

        private void BindDataToGroup(int GId)
        {
            GroupHelper helper = new GroupHelper(new Group());
            radCmbGroup.DataSource = helper.ListAll();
            radCmbGroup.DataBind();
            if (GId > 0) radCmbGroup.SelectedValue = GId.ToString();
        }

        private void DoSave()
        {
            PanelPolicy pnlPolicy;
            HiddenField id;
            HiddenField gid;
            HiddenField mid;

            DataTable dt = PolicyDAO.GetTemplateTable();
            for (int i = 0; i < radGridDefault.Items.Count; i++)
            {
                try
                {
                    pnlPolicy =
                        (PanelPolicy)
                        radGridDefault.Items[i].FindControl(SystemConstants.Policies.ControlNames.PanelPolicy);
                    id =
                        (HiddenField)
                        radGridDefault.Items[i].FindControl(SystemConstants.Policies.ControlNames.HiddenFieldId);
                    gid =
                        (HiddenField)
                        radGridDefault.Items[i].FindControl(SystemConstants.Policies.ControlNames.HiddenFieldGId);
                    mid =
                        (HiddenField)
                        radGridDefault.Items[i].FindControl(SystemConstants.Policies.ControlNames.HiddenFieldMId);

                    DataRow dr = dt.NewRow();
                    dr[SystemConstants.Entities.Policy.FieldName.Id] = Utilities.ParseInt(id.Value);
                    dr[SystemConstants.Entities.Policy.FieldName.GroupId] = Utilities.ParseInt(gid.Value);
                    dr[SystemConstants.Entities.Policy.FieldName.ModuleId] = Utilities.ParseInt(mid.Value);
                    dr[SystemConstants.Entities.Policy.FieldName.Val] = Utilities.ParseInt(pnlPolicy.GetValues());
                    dr[SystemConstants.Entities.Policy.FieldName.Created_At] = DateTime.Now;
                    dr[SystemConstants.Entities.Policy.FieldName.Created_By] = UserId;
                    dr[SystemConstants.Entities.Policy.FieldName.Last_Modified_At] = DateTime.Now;
                    dr[SystemConstants.Entities.Policy.FieldName.Last_Modified_By] = UserId;
                    dt.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                    ErrorMessage1.AddMessage(ex.Message);
                    ErrorMessage1.Visible = true;
                    SystemLogging.Error("PopupGroupPolicy::DoSave:Error", ex.Message);
                    return;
                }
            }

            PolicyHelper helper = new PolicyHelper(new Policy());
            helper.SavePolicyByGroup(dt);

            lblMessage.Visible = true;
            lblMessage.Text = Utilities.GetConfigKey(SystemConstants.Message.SaveSuccess);

            //rebind data
            int gId = Utilities.ParseInt(radCmbGroup.SelectedValue);
            BindDataToPolicy(gId);
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
                GridGroupHeaderItem item = (GridGroupHeaderItem)e.Item;
                item.DataCell.Text = item.DataCell.Text.Replace(":", string.Empty).Trim();
                if (Nulls.IsNullOrEmpty(item.DataCell.Text))
                {
                    item.DataCell.Text = "&nbsp;";
                }
            }
        }

        protected void radCmbGroup_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int gId = Utilities.ParseInt(radCmbGroup.SelectedValue);
            BindDataToPolicy(gId);
        }
 
        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }
    }
}