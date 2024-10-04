using System;
using System.Collections.Generic;
using System.Data;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.V1.UserControls.Homepage
{
  public partial class PanelPoll : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (! IsPostBack)
      {
          PopularItem();

      }
      
    }
      private void SetupEnvironment()
      {
          //Registe poll js
          if (!this.Page.ClientScript.IsClientScriptBlockRegistered("poll.js"))
          {
              this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "poll.js",
                           "<script src=\"" + this.Page.ResolveUrl("/js/poll.js") + "\"></script>");
          }
      }
      private void PopularItem()
      {
          //ID cate trang chu la 23
          int CategoryId = 0;
          WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
          helper.ValueObject.CategoryAlias = "trang-chu";
          DataTable dt = helper.GetCategoryByAlias();
          if (dt != null && dt.Rows.Count > 0)
          {
              CategoryId = int.Parse(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId].ToString());
          }


          // Get Survey by CatId
          SubSonic.StoredProcedure sproc = SPs.SurveyListByCat(CategoryId);
          List<SurveyPublish> p = sproc.ExecuteTypedList<SurveyPublish>();
          if (p.Count > 0)
          {
              SetupEnvironment();
              lblItem.Text = "<div id=\"Survey_" + p[0].SurveyPublishId + "\"></div><script>showPoll('" + p[0].SurveyId + "','Survey_" + p[0].SurveyPublishId + "');</script> ";
          }

      }
  }
}