using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.DBAccess;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;

namespace VietNamNet.CMS.Articles.UserControls
{
    public partial class PanelArticleCategory2 : UserControl
    {
        #region Public Properties

        [Description("Edit Option")]
        [Browsable(true)]
        [DefaultSettingValue("1")]
        public int EditOption
        {
            get { return Utilities.ParseInt(ViewState[CMSConstants.ViewState.EditOption]); }
            set { ViewState[CMSConstants.ViewState.EditOption] = value; }
        }

        #endregion

        #region Private Properties

        private const string panelCategoryID = "pnlItem{0}";
        private const string panelCategoryPath = "UserControls/PanelCategory.ascx";

        #endregion

        #region Handler Method

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) LoadCategories();
            
            //if (!IsPostBack)
            //{
            //    BindDataToCategory();
            //}
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            int quantity = Utilities.ParseInt(hidSubCategoryNumber.Value) + 1;
            hidSubCategoryNumber.Value = quantity.ToString();

            LoadCategories();
        }

        #endregion

        #region Public Method

        public void BindDataToCategories()
        {
            BindDataToCategory(cmbPrimaryCategory); //Bind data to PrimaryCategory

            DataTable dtCategories = (Session[GetArticleCategoriesSessionName()] != null)
                        ? (DataTable)Session[GetArticleCategoriesSessionName()]
                        : ArticleCategoryDAO.GetTemplateTable();

            int index = 0;
            foreach (DataRow row in dtCategories.Rows)
            {
                if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.PrimaryCategory]) == 1)
                {
                    cmbPrimaryCategory.SelectedValue =
                        Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.CategoryId]).ToString();
                    txtPrimaryOrd.Value =
                        Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.Ord]);
                }
                else
                {
                    index++;

                    //Load category
                    int cid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.CategoryId]);
                    int ord = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.Ord]);
                    LoadCategory(index, cid, ord);
                }
            }

            if (index > 2)
            {
                hidSubCategoryNumber.Value = index.ToString();
            }
            else
            {
                while (index < 2) LoadCategory(++index, 0, 1);
            }
        }

        public void GetDataCategories()
        {
            DataTable dtCategories = (Session[GetArticleCategoriesSessionName()] != null)
                                         ? (DataTable)Session[GetArticleCategoriesSessionName()]
                                         : ArticleCategoryDAO.GetTemplateTable();

            if (dtCategories != null)
            {
                if (dtCategories.Rows.Count == 0) //addnew all
                {
                    dtCategories = GetCategories();
                }
                else
                {
                    //INSERT - UPDATE - DELETE
                    DataTable dtNewCate = GetCategories();

                    foreach (DataRow oldCategory in dtCategories.Rows) // UPDATE or DELETE
                    {
                        bool blnExist = false;

                        int oldPCategoryId = Utilities.ParseInt(oldCategory[CMSConstants.Entities.ArticleCategory.FieldName.CategoryId]);
                        int oldOrd = Utilities.ParseInt(oldCategory[CMSConstants.Entities.ArticleCategory.FieldName.Ord]);

                        foreach (DataRow newCategory in dtNewCate.Rows)
                        {
                            int newCategoryId = Utilities.ParseInt(newCategory[CMSConstants.Entities.ArticleCategory.FieldName.CategoryId]);
                            int newOrd = Utilities.ParseInt(newCategory[CMSConstants.Entities.ArticleCategory.FieldName.Ord]);
                            if (newCategoryId == oldPCategoryId) //UPDATE
                            {
                                blnExist = true;

                                if (newOrd != oldOrd)
                                {
                                    oldCategory[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] = Constants.CommonStatus.UPDATE;
                                    oldCategory[CMSConstants.Entities.ArticleCategory.FieldName.Ord] = newOrd;
                                    oldCategory[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                                    oldCategory[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                                }

                                break;
                            }
                        }

                        if (!blnExist) //DELETE
                        {
                            oldCategory[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                            oldCategory[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                            oldCategory[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        }
                    }

                    foreach (DataRow newCategory in dtNewCate.Rows) //ADD NEW
                    {
                        bool blnExist = false;

                        int newCategoryId = Utilities.ParseInt(newCategory[CMSConstants.Entities.ArticleCategory.FieldName.CategoryId]);
                        //int newOrd = Utilities.ParseInt(newCategory[CMSConstants.Entities.ArticleCategory.FieldName.Ord]);

                        foreach (DataRow oldCategory in dtCategories.Rows)
                        {
                            int oldPCategoryId = Utilities.ParseInt(oldCategory[CMSConstants.Entities.ArticleCategory.FieldName.CategoryId]);
                            //int oldOrd = Utilities.ParseInt(oldCategory[CMSConstants.Entities.ArticleCategory.FieldName.Ord]);

                            if (newCategoryId == oldPCategoryId)
                            {
                                blnExist = true;
                                break;
                            }
                        }

                        if (!blnExist) //ADD
                        {
                            DataRow category = dtCategories.NewRow();

                            foreach (DataColumn column in dtCategories.Columns)
                            {
                                if (dtNewCate.Columns.Contains(column.ColumnName))
                                {
                                    category[column.ColumnName] = newCategory[column.ColumnName];
                                }
                            }

                            dtCategories.Rows.Add(category);
                        }
                    }

                    //check duplicate
                    for (int i = 0; i < dtCategories.Rows.Count - 1; i++)
                    {
                        int categoryId1 =
                            Utilities.ParseInt(
                                dtCategories.Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.CategoryId]);
                        for (int j = i + 1; j < dtCategories.Rows.Count; j++)
                        {
                            int categoryId2 =
                                Utilities.ParseInt(
                                    dtCategories.Rows[j][CMSConstants.Entities.ArticleCategory.FieldName.CategoryId]);
                            if (categoryId1 == categoryId2)
                            {
                                dtCategories.Rows[j][CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                                dtCategories.Rows[j][CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                                dtCategories.Rows[j][CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                            }
                        }
                    }
                }
            }

            Session[GetArticleCategoriesSessionName()] = dtCategories;
        }

        #endregion

        #region Private Method

        private void LoadCategories()
        {
            int quantity = Utilities.ParseInt(hidSubCategoryNumber.Value);
            if (plhSubCategories.Controls.Count < quantity) //add new control
            {
                for (int i = plhSubCategories.Controls.Count; i < quantity; i++)
                {
                    string controlID = string.Format(panelCategoryID, i + 1);
                    PanelCategory control = (PanelCategory)this.Page.LoadControl(panelCategoryPath);
                    control.ID = controlID;
                    control.ItemNo = i + 1;
                    control.BindData(GetDataCategory());
                    plhSubCategories.Controls.Add(control);
                }
            }
            else //remove control
            {
                while (plhSubCategories.Controls.Count > quantity)
                {
                    plhSubCategories.Controls[plhSubCategories.Controls.Count - 1].Dispose();
                }
            }
        }

        private void LoadCategory(int index, int cid, int ord)
        {
            string controlID = string.Format(panelCategoryID, index);
            PanelCategory control = (PanelCategory)this.Page.LoadControl(panelCategoryPath);
            control.ID = controlID;
            control.ItemNo = index;
            control.BindData(GetDataCategory(), cid, ord);
            plhSubCategories.Controls.Add(control);
        }

        private string GetArticleCategoriesSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", CMSConstants.Session.CMSData.ArticleCategories, docId);
        }

        private DataTable ProcessCategory(DataTable dt)
        {
            DataRow drNew = dt.NewRow();
            drNew[CMSConstants.Entities.Category.FieldName.Id] = 0;
            drNew[CMSConstants.Entities.Category.FieldName.PId] = DBNull.Value;
            drNew[CMSConstants.Entities.Category.FieldName.Name] = string.Empty;
            drNew[CMSConstants.Entities.Category.FieldName.DisplayName] = string.Empty;

            dt.Rows.InsertAt(drNew, 0);
            dt.DefaultView.Sort = "Name ASC";
            return dt;
        }

        private DataTable GetDataCategory()
        {
            if (ViewState[CMSConstants.ViewState.MyCategory] == null)
            {
                CategoryHelper helper = new CategoryHelper(new Category());
                helper.ValueObject.UserId = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                ViewState[CMSConstants.ViewState.MyCategory] = ProcessCategory(helper.GetCategoryByUserId());
            }

            return (DataTable)ViewState[CMSConstants.ViewState.MyCategory];
        }

        private void BindDataToCategory()
        {
            BindDataToCategory(cmbPrimaryCategory);
        }

        private void BindDataToCategory(RadComboBox comboBox)
        {
            comboBox.DataTextField = CMSConstants.Entities.Category.FieldName.Name;
            comboBox.DataValueField = CMSConstants.Entities.Category.FieldName.Id;
            comboBox.DataSource = GetDataCategory();
            comboBox.DataBind();
            return;
        }

        private DataTable AddCategory(DataTable dt, int cid, int ord, int primary)
        {
            if (dt == null || cid <= 0) return dt;

            if (ord <= 0) ord = 1;

            //check cid exist in dt
            foreach (DataRow row in dt.Rows)
            {
                int categoryId = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.CategoryId]);
                if (categoryId == cid) return dt;
            }

            //Add data
            CategoryHelper categoryHelper = new CategoryHelper(new Category());
            categoryHelper.ValueObject.Id = cid;
            categoryHelper.Load();

            if (categoryHelper.ValueObject != null)
            {
                DataRow category = dt.NewRow();
                category[CMSConstants.Entities.ArticleCategory.FieldName.Id] = 0;
                category[CMSConstants.Entities.ArticleCategory.FieldName.ArticleId] = 0;
                category[CMSConstants.Entities.ArticleCategory.FieldName.ArticleContentTypeId] = 0;
                category[CMSConstants.Entities.ArticleCategory.FieldName.CategoryId] = categoryHelper.ValueObject.Id;
                category[CMSConstants.Entities.ArticleCategory.FieldName.PartitionId] = categoryHelper.ValueObject.PartitionId;
                category[CMSConstants.Entities.ArticleCategory.FieldName.Url] = categoryHelper.ValueObject.Url;
                category[CMSConstants.Entities.ArticleCategory.FieldName.OldOrd] = 0;
                category[CMSConstants.Entities.ArticleCategory.FieldName.Ord] = ord;
                category[CMSConstants.Entities.ArticleCategory.FieldName.PrimaryCategory] = primary;
                category[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                category[CMSConstants.Entities.ArticleCategory.FieldName.CategoryName] =
                    categoryHelper.ValueObject.Name;
                category[CMSConstants.Entities.ArticleCategory.FieldName.CategoryAlias] =
                    categoryHelper.ValueObject.Alias;
                category[CMSConstants.Entities.ArticleCategory.FieldName.Created_At] = DateTime.Now;
                category[CMSConstants.Entities.ArticleCategory.FieldName.Created_By] =
                    Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                category[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_At] = DateTime.Now;
                category[CMSConstants.Entities.ArticleCategory.FieldName.Last_Modified_By] =
                    Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                dt.Rows.Add(category);
            }

            return dt;
        }

        private DataTable GetCategories()
        {
            DataTable dtCategories = ArticleCategoryDAO.GetTemplateTable();

            //Primary category
            dtCategories = AddCategory(dtCategories, Utilities.ParseInt(cmbPrimaryCategory.SelectedValue),
                        Utilities.ParseInt(txtPrimaryOrd.Value), 1);

            //Sub category
            for (int index = 1; index <= Utilities.ParseInt(hidSubCategoryNumber.Value); index++)
            {
                string controlID = string.Format(panelCategoryID, index);
                Control control = FindControl(controlID);

                if (control != null && control.GetType().BaseType.Equals(typeof(PanelCategory)))
                {
                    PanelCategory category = (PanelCategory) control;

                    dtCategories = AddCategory(dtCategories, category.GetCategoryId(), category.GetCategoryOrder(), 0);
                }
            }

            return dtCategories;
        }

        #endregion
    }
}