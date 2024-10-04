using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
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