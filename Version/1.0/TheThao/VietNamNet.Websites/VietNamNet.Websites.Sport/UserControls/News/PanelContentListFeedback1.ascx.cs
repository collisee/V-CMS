/***
 * 
 * 
 * 
 * */

using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Sport.UserControls.News
{
    public partial class PanelContentListFeedback1 : UserControl
    {
        [Description("ArticleId")]
        [Browsable(true)]
        [DefaultSettingValue("0")]
        public int ArticleId
        {
            get { return Utilities.ParseInt(ViewState[WebsitesConstants.ViewState.ArticleId]); }
            set { ViewState[WebsitesConstants.ViewState.ArticleId] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Get PageNumber
                int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
                int pageSize = Utilities.GetCommentPageSize();
                if (pageNumber <= 0) pageNumber = 1;
                
                WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                helper.ValueObject.ArticleId = ArticleId;
                helper.ValueObject.FirstIndexRecord = (pageNumber - 1) * pageSize + 1;
                helper.ValueObject.LastIndexRecord = pageNumber * pageSize;
                DataTable dt = helper.GetArticleComment();

                if (dt != null && dt.Rows.Count > 0)
                {
                    rptComment.DataSource = dt;
                    rptComment.DataBind();

                    //bind link
                    hlnkPrev.NavigateUrl =
                        Utilities.SetParamForURL(Request.Url.AbsolutePath, WebsitesConstants.ParameterName.PAGE,
                                                 pageNumber - 1) + "#feedBackList";
                    hlnkNext.NavigateUrl =
                        Utilities.SetParamForURL(Request.Url.AbsolutePath, WebsitesConstants.ParameterName.PAGE,
                                                 pageNumber + 1) + "#feedBackList";

                    //hidden link
                    if (pageNumber <= 1) hlnkPrev.Visible = false;
                    if (dt.Rows.Count < pageSize) hlnkNext.Visible = false;
                }
                else
                {
                    this.Visible = false;
                }
            }
        }
    }
}