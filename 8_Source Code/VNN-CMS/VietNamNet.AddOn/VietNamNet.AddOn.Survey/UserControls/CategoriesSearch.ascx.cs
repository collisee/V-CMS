using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Serialization;
using System.ComponentModel;
using Telerik.Web.UI;
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Survey.UserControls
{
    public partial class CategoriesSearch : BaseUserControls
    {
        #region Members
         
        private int _selectedCat;
        public int SelectedCat
        {
            get{ _selectedCat = int.Parse(txtSelectedCategory.Text.Trim()); return _selectedCat; }
            set { _selectedCat = value;  }
        }

        #endregion 

        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
           
            if (! Page.IsPostBack )
            {
                SetupEnvironment();
            }
        }

        protected void OnFilterChanged(object sender, EventArgs e)
        {
            PopularCategories(0);
        } 
        protected void GrdViewPageIndexChanged(object source, GridPageChangedEventArgs e)
        {
            PopularCategories(e.NewPageIndex);
        }
        protected void GrdViewItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Select": 
                        txtSelectedCategory.Text = (string) e.CommandArgument; 
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion

        #region Public Members
        public void Bind()
        {
            SetupEnvironment();
            txtSelectedCategory.Text = _selectedCat.ToString();
        }
        #endregion

        #region Private Members

         private void SetupEnvironment()
         {
            if (_selectedCat != null) txtSelectedCategory.Text = _selectedCat.ToString(); 

             PopularCategories(0);
             
        }


        private void PopularCategories(int PageIndex)
        {
            DataTable dt = Cats_GetDataSource();
            
            StringBuilder filter = new StringBuilder();
            if (txtSearch.Text.Trim().Length > 0)
                filter.Append(" Name like '%" + txtSearch.Text.Trim() + "%'");

                dt.DefaultView.RowFilter = filter.ToString();
           
            grdView.DataSource = dt.DefaultView;
            grdView.CurrentPageIndex = PageIndex;
            grdView.DataBind();
        }

       

        private  DataTable Cats_GetDataSource()
        {
           // this.GetUserInfo();
            CategoryHelper helper = new CategoryHelper(new Category());
            helper.ValueObject.UserId = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
            DataTable dt = helper.GetCategoryByUserId();
            
            //if (isSystem)
            //{
            //    DataRow r = dt.NewRow();
            //    r[CMSConstants.Entities.Category.FieldName.Id] =0;
            //    r[CMSConstants.Entities.Category.FieldName.Name] = "Trang chủ";
            //    r[CMSConstants.Entities.Category.FieldName.Alias] = "trang-chu";
            //    r[CMSConstants.Entities.Category.FieldName.DisplayName] = "Trang chủ";

            //    dt.Rows.Add(r);
            //}
            return dt;
        }

        private void Initialize()
        {
           
        }

        #endregion


    }
}