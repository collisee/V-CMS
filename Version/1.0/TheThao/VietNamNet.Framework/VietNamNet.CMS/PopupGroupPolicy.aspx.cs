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
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.CMS
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

        private static DataTable ProcessCategory(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr[CMSConstants.Entities.CategoryPolicy.FieldName.CategoryPId] =
                    Utilities.ParseInt(dr[CMSConstants.Entities.CategoryPolicy.FieldName.CategoryPId]);
            }

            DataRow drNew = dt.NewRow();
            drNew[CMSConstants.Entities.CategoryPolicy.FieldName.Id] = 0;
            drNew[CMSConstants.Entities.CategoryPolicy.FieldName.CategoryId] = 0;
            drNew[CMSConstants.Entities.CategoryPolicy.FieldName.CategoryPId] = DBNull.Value;
            drNew[CMSConstants.Entities.CategoryPolicy.FieldName.CategoryName] = "Root";
            drNew[CMSConstants.Entities.CategoryPolicy.FieldName.CategoryDisplayName] = "Root";

            dt.Rows.InsertAt(drNew, 0);
            return dt;
        }

        private void BindDataToPolicy(int gid)
        {
            if (gid <= 0) gid = Utilities.ParseInt(radCmbGroup.SelectedValue);

            CategoryPolicyHelper helper = new CategoryPolicyHelper(new CategoryPolicy());
            helper.ValueObject.GroupId = gid;
            radTreeViewPolicy.DataSource = ProcessCategory(helper.GetPolicyByGroup());
            radTreeViewPolicy.DataBind();
            radTreeViewPolicy.ExpandAllNodes();
        }

        private void BindDataToGroup(int GId)
        {
            GroupHelper helper = new GroupHelper(new Group());
            radCmbGroup.DataSource = helper.ListAll();
            radCmbGroup.DataBind();
            if (GId > 0) radCmbGroup.SelectedValue = GId.ToString();
        }

        private DataTable GetData(RadTreeNode node, DataTable source)
        {
            DataRow dr = source.NewRow();
            dr[CMSConstants.Entities.CategoryPolicy.FieldName.Id] = Utilities.ParseInt(node.Value);
            dr[CMSConstants.Entities.CategoryPolicy.FieldName.GroupId] = Utilities.ParseInt(radCmbGroup.SelectedValue);
            dr[CMSConstants.Entities.CategoryPolicy.FieldName.CategoryId] = Utilities.ParseInt(node.ToolTip);
            dr[CMSConstants.Entities.CategoryPolicy.FieldName.Val] = node.Checked ? 1 : 0;
            dr[CMSConstants.Entities.CategoryPolicy.FieldName.Created_At] = DateTime.Now;
            dr[CMSConstants.Entities.CategoryPolicy.FieldName.Created_By] = UserId;
            dr[CMSConstants.Entities.CategoryPolicy.FieldName.Last_Modified_At] = DateTime.Now;
            dr[CMSConstants.Entities.CategoryPolicy.FieldName.Last_Modified_By] = UserId;
            if (Utilities.ParseInt(node.ToolTip) > 0) source.Rows.Add(dr);

            if (node.Nodes != null)
            {
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    source = GetData(node.Nodes[i], source);
                }
            }

            return source;
        }

        private void DoSave()
        {
            DataTable dt = CategoryPolicyDAO.GetTemplateTable();
            try
            {
                for (int i = 0; i < radTreeViewPolicy.Nodes.Count; i++)
                {
                    dt = GetData(radTreeViewPolicy.Nodes[i], dt);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage1.AddMessage(ex.Message);
                ErrorMessage1.Visible = true;
                SystemLogging.Error("CMS-PopupGroupPolicy::DoSave:Error", ex.Message);
                return;
            }

            CategoryPolicyHelper helper = new CategoryPolicyHelper(new CategoryPolicy());
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

        protected void radTreeViewPolicy_NodeDataBound(object sender, RadTreeNodeEventArgs e)
        {
            e.Node.ToolTip = ((DataRowView)e.Node.DataItem)["CategoryId"].ToString();
            e.Node.Checked = Utilities.ParseInt(((DataRowView)e.Node.DataItem)["Val"]) == 1;
        }

        private void SelectNode(RadTreeNode node, bool flag)
        {
            node.Checked = flag;

            if (node.Nodes != null)
            {
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    SelectNode(node.Nodes[i], flag);
                }
            }
        }

        protected void radTreeViewPolicy_NodeCheck(object sender, RadTreeNodeEventArgs e)
        {
            SelectNode(e.Node, e.Node.Checked);
        }
    }
}