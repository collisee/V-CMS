using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.DBAccess;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Events.UserControls
{
    public partial class PanelArticleEventCategory : UserControl
    {
        [Description("Edit Option")]
        [Browsable(true)]
        [DefaultSettingValue("1")]
        public int EditOption
        {
            get { return Utilities.ParseInt(ViewState[CMSConstants.ViewState.EditOption]); }
            set { ViewState[CMSConstants.ViewState.EditOption] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataToCategory();

                if (EditOption == 0)
                {
                    pnlEdit.Visible = false;
                    radGridCategories.Columns[0].Visible = false;
                    radGridCategories.Columns[radGridCategories.Columns.Count - 1].Visible = false;
                    radGridCategories.Columns[radGridCategories.Columns.Count - 2].Visible = false;
                    radGridCategories.Columns[radGridCategories.Columns.Count - 3].HeaderText =
                        radGridCategories.Columns[radGridCategories.Columns.Count - 2].HeaderText;
                    btnDelCategories.Enabled = btnDelCategories.Visible = false;
                }
            }
        }

        private string GetArticleEventCategoriesSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", CMSConstants.Session.CMSData.ArticleEventCategories, docId);
        }

        protected override void OnPreRender(EventArgs e)
        {
            //Init
            txtOrd.Value = 1;
            InitTreeView();

            base.OnPreRender(e);
        }

        private static DataTable ProcessCategory(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int pid = Utilities.ParseInt(dr[CMSConstants.Entities.Category.FieldName.PId]);
                bool flag = false;
                //find parent id
                if (pid > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (i != j)
                        {
                            DataRow drParent = dt.Rows[j];
                            int parentId = Utilities.ParseInt(drParent[CMSConstants.Entities.Category.FieldName.Id]);
                            if (parentId == pid)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }

                if (!flag && pid != 0)
                {
                    pid = 0;
                    dr[CMSConstants.Entities.Category.FieldName.DisplayName] = dr[CMSConstants.Entities.Category.FieldName.Name];
                }

                dr[CMSConstants.Entities.Category.FieldName.PId] = pid;
            }

            DataRow drNew = dt.NewRow();
            drNew[CMSConstants.Entities.Category.FieldName.Id] = 0;
            drNew[CMSConstants.Entities.Category.FieldName.PId] = DBNull.Value;
            drNew[CMSConstants.Entities.Category.FieldName.Name] = "Root";
            drNew[CMSConstants.Entities.Category.FieldName.DisplayName] = "Root";

            dt.Rows.InsertAt(drNew, 0);
            return dt;
        }

        private void BindDataToCategory()
        {
            RadTreeView radTreeViewCategory = (RadTreeView)cmbCategory.Items[0].FindControl("radTreeViewCategory");
            radTreeViewCategory.DataFieldID = CMSConstants.Entities.Category.FieldName.Id;
            radTreeViewCategory.DataFieldParentID = CMSConstants.Entities.Category.FieldName.PId;
            radTreeViewCategory.DataTextField = CMSConstants.Entities.Category.FieldName.DisplayName;
            radTreeViewCategory.DataValueField = CMSConstants.Entities.Category.FieldName.Id;

            CategoryHelper helper = new CategoryHelper(new Category());
            helper.ValueObject.UserId = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
            radTreeViewCategory.DataSource = ProcessCategory(helper.GetCategoryByUserId());
            radTreeViewCategory.DataBind();
        }

        private string[] GetCategoryValue()
        {
            return cmbCategory.SelectedValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void SetCategoryValue(string value)
        {
            if (cmbCategory.Items.Count > 0) cmbCategory.Items[0].Value = value;
        }

        private void InitTreeView()
        {
            RadTreeView radTreeViewCategory = (RadTreeView)cmbCategory.Items[0].FindControl("radTreeViewCategory");
            if (radTreeViewCategory != null)
            {
                radTreeViewCategory.ClearSelectedNodes();
                radTreeViewCategory.Nodes[0].Expanded = true;
            }
        }

        public void BindDataToCategories()
        {
            radGridCategories.DataBind();
        }

        protected void radGridCategories_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dtCategories = (Session[GetArticleEventCategoriesSessionName()] != null)
                        ? (DataTable)Session[GetArticleEventCategoriesSessionName()]
                        : ArticleEventCategoryDAO.GetTemplateTable();
            radGridCategories.DataSource = dtCategories.Select("SaveStatus <> 'DELETE'");
        }

        protected void radGridCategories_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (!Utilities.Event_Handler(source, e)) return;

            if (Utilities.StringCompare(e.CommandName, Constants.CommandNames.Delete) && e.Item is GridDataItem)
            {
                DataTable dtCategories = (Session[GetArticleEventCategoriesSessionName()] != null)
                                        ? (DataTable)Session[GetArticleEventCategoriesSessionName()]
                                        : ArticleEventCategoryDAO.GetTemplateTable();
                int id = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                foreach (DataRow row in dtCategories.Rows)
                {
                    int rid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventCategory.FieldName.Id]);
                    if (rid == id)
                    {
                        row[CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                        row[CMSConstants.Entities.ArticleEventCategory.FieldName.Last_Modified_At] = DateTime.Now;
                        row[CMSConstants.Entities.ArticleEventCategory.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        break;
                    }
                }

                Session[GetArticleEventCategoriesSessionName()] = dtCategories;

                radGridCategories.Rebind();
            }
        }

        protected void txtOrd_TextChanged(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            if (EditOption == 0) return;

            try
            {
                RadNumericTextBox txtCategoryOrd = sender as RadNumericTextBox;

                GridTableCell myPanel = txtCategoryOrd.Parent as GridTableCell;

                GridDataItem dataItem = myPanel.Parent as GridDataItem;

                int id = Utilities.ParseInt(dataItem["Id"].Text);

                DataTable dtCategories = (Session[GetArticleEventCategoriesSessionName()] != null)
                                        ? (DataTable)Session[GetArticleEventCategoriesSessionName()]
                                        : ArticleEventCategoryDAO.GetTemplateTable();
                foreach (DataRow row in dtCategories.Rows)
                {
                    int rid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventCategory.FieldName.Id]);
                    if (rid == id)
                    {
                        row[CMSConstants.Entities.ArticleEventCategory.FieldName.Ord] = Utilities.ParseInt(txtCategoryOrd.Value);
                        if (Nulls.IsNullOrEmpty(row[CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus]))
                        {
                            row[CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus] = Constants.CommonStatus.UPDATE;
                        }
                        row[CMSConstants.Entities.ArticleEventCategory.FieldName.Last_Modified_At] = DateTime.Now;
                        row[CMSConstants.Entities.ArticleEventCategory.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        break;
                    }
                }

                Session[GetArticleEventCategoriesSessionName()] = dtCategories;
            }
            catch (Exception ex)
            {
                SystemLogging.Error("Article::PanelArticleEventCategory::ChangeOrder::Error", ex.Message);
            }
            finally
            {
                //radGridCategories.Rebind();
            }
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            DataTable dtCategories = (Session[GetArticleEventCategoriesSessionName()] != null)
                                         ? (DataTable)Session[GetArticleEventCategoriesSessionName()]
                                         : ArticleEventCategoryDAO.GetTemplateTable();

            //get first id
            int id = -1;
            foreach (DataRow row in dtCategories.Rows)
            {
                int rid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventCategory.FieldName.Id]);
                if (rid <= id) id = rid - 1;
            }

            //get categories
            string[] categories = GetCategoryValue();
            foreach (string s in categories)
            {
                int categoryId = Utilities.ParseInt(s);

                //check exist
                bool blnExist = false;
                foreach (DataRow row in dtCategories.Rows)
                {
                    int cid =
                        Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventCategory.FieldName.CategoryId]);
                    if (cid == categoryId)
                    {
                        blnExist = true;
                        break;
                    }
                }
                if (blnExist) continue;
                
                //Add data
                CategoryHelper categoryHelper = new CategoryHelper(new Category());
                categoryHelper.ValueObject.Id = categoryId;
                categoryHelper.Load();

                if (categoryHelper.ValueObject != null)
                {
                    DataRow category = dtCategories.NewRow();
                    category[CMSConstants.Entities.ArticleEventCategory.FieldName.Id] = id--;
                    category[CMSConstants.Entities.ArticleEventCategory.FieldName.ArticleEventId] = 0;
                    category[CMSConstants.Entities.ArticleEventCategory.FieldName.CategoryId] = categoryHelper.ValueObject.Id;
                    category[CMSConstants.Entities.ArticleEventCategory.FieldName.OldOrd] = 0;
                    category[CMSConstants.Entities.ArticleEventCategory.FieldName.Ord] = Utilities.ParseInt(txtOrd.Value);
                    category[CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                    category[CMSConstants.Entities.ArticleEventCategory.FieldName.CategoryName] =
                        categoryHelper.ValueObject.Name;
                    category[CMSConstants.Entities.ArticleEventCategory.FieldName.CategoryAlias] =
                        categoryHelper.ValueObject.Alias;
                    category[CMSConstants.Entities.ArticleEventCategory.FieldName.Created_At] = DateTime.Now;
                    category[CMSConstants.Entities.ArticleEventCategory.FieldName.Created_By] =
                        Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                    category[CMSConstants.Entities.ArticleEventCategory.FieldName.Last_Modified_At] = DateTime.Now;
                    category[CMSConstants.Entities.ArticleEventCategory.FieldName.Last_Modified_By] =
                        Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                    dtCategories.Rows.Add(category);
                }
            }

            Session[GetArticleEventCategoriesSessionName()] = dtCategories;

            radGridCategories.Rebind();

            SetCategoryValue(string.Empty);
        }

        protected void btnDelCategories_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            DataTable dtCategories = (Session[GetArticleEventCategoriesSessionName()] != null)
                                         ? (DataTable)Session[GetArticleEventCategoriesSessionName()]
                                         : ArticleEventCategoryDAO.GetTemplateTable();

            for (int i = 0; i < radGridCategories.Items.Count; i++)
            {
                GridDataItem dataItem = radGridCategories.Items[i];

                CheckBox chkSelected = (CheckBox)dataItem.FindControl("chkSelected");

                if (chkSelected != null && chkSelected.Checked)
                {
                    int id = Utilities.ParseInt(dataItem["Id"].Text);

                    foreach (DataRow row in dtCategories.Rows)
                    {
                        int rid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventCategory.FieldName.Id]);
                        if (rid == id)
                        {
                            row[CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                            row[CMSConstants.Entities.ArticleEventCategory.FieldName.Last_Modified_At] = DateTime.Now;
                            row[CMSConstants.Entities.ArticleEventCategory.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                            break;
                        }
                    }
                }
            }

            Session[GetArticleEventCategoriesSessionName()] = dtCategories;

            radGridCategories.Rebind();
        }
    }
}