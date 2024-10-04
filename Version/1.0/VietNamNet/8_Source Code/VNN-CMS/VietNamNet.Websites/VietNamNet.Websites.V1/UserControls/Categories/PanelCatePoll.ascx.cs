using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.CMS.BizLogic;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.V1.UserControls.Categories
{
  public partial class PanelCatePoll : System.Web.UI.UserControl
  {
      #region Members
      [Description("Category Alias")]
      [Browsable(true)]
      [DefaultSettingValue("")]
      public string CategoryAlias
      {
          get
          {
              return
                Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.CategoryAlias])
                  ? string.Empty
                  : ViewState[WebsitesConstants.ViewState.CategoryAlias].ToString();
          }
          set { ViewState[WebsitesConstants.ViewState.CategoryAlias] = value; }
      }
      #endregion

      #region Public Methods

      protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopularItem();

        }
    }
      #endregion

    #region Private Methods

      private void SetupEnvironment()
      {
          //Registe poll js
          if (!this.Page.ClientScript.IsClientScriptBlockRegistered("poll.js"))
          {
              this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "poll.js",
                           "<script src=\"" + this.Page.ResolveUrl("/js/poll.js") + "\"></script>");
          }

          ////Registe jQuery js
          //if (!this.Page.ClientScript.IsClientScriptBlockRegistered("jquery-1.4.2.min.js"))
          //{
          //    this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "jquery-1.4.2.min.js",
          //                 "<script src=\"" + this.Page.ResolveUrl("/js/jquery-1.4.2.min.js") + "\"></script>");
          //}
          ////Registe jQueryUI js
          //if (!this.Page.ClientScript.IsClientScriptBlockRegistered("jquery-ui-1.8.1.custom.min.js"))
          //{
          //    this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "jquery-ui-1.8.1.custom.min.js",
          //                 "<script src=\"" + this.Page.ResolveUrl("/js/jquery-ui-1.8.1.custom.min.js") + "\"></script>");
          //}
      }

      private void PopularItem()
      {
          //// Get CategoryId
          //ID cate trang chu la 23
        int categoryId = 23;
        WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
        helper.ValueObject.CategoryAlias = CategoryAlias;
        DataTable dt = helper.GetCategoryByAlias();
        if (dt != null && dt.Rows.Count > 0)
        {
          categoryId = int.Parse(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId].ToString());
        }

        // Get Survey by CatId
        SubSonic.StoredProcedure sproc = SPs.SurveyListByCat(categoryId);
          List<SurveyPublish> p = sproc.ExecuteTypedList<SurveyPublish>();
          if (p.Count > 0)
          {
              SetupEnvironment();
              lblItem.Text = "<div id=\"Survey_" + this.ID + p[0].SurveyPublishId + "\"></div><script>showPoll('" + p[0].SurveyId + "','Survey_" + this.ID + p[0].SurveyPublishId + "');</script> ";
          }

      }
    #endregion
}
}