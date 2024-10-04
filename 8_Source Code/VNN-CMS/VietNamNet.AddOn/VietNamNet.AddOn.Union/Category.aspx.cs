using System;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Union
{
    public partial class Category : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isLogged)
            {
              Response.Redirect("~/");
            }

            if (!IsPostBack)
            {
                int pageNumber = Utilities.ParseInt(Request.Params[UnionConstants.ParameterName.PAGE]);
                string categoryAlias = Request.Params[UnionConstants.ParameterName.CATEGORY_ALIAS];

                PanelCategory1.CategoryAlias = categoryAlias;
                PanelCategory1.PageNumber = pageNumber;
            }
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.AddOn.Union";
            viewAlias = "VietNamNet.AddOn.Union.View";
            addNewAlias = "VietNamNet.AddOn.Union.AddNew";
            updateAlias = "VietNamNet.AddOn.Union.Update";
            deleteAlias = "VietNamNet.AddOn.Union.Delete";
        }

        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }
    }
}