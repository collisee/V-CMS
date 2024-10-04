using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.AddOn.Union.Common.ValueObject;
using VietNamNet.AddOn.Union.Presentation;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Union.UserControls.News
{
    public partial class PanelNewsComment : UserControl
    {
        [Description("ArticleId")]
        [Browsable(true)]
        [DefaultSettingValue("0")]
        public int ArticleId
        {
            get { return Utilities.ParseInt(ViewState[UnionConstants.ViewState.ArticleId]); }
            set { ViewState[UnionConstants.ViewState.ArticleId] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            pnlForm.Visible = Session[Constants.Session.USER_ID] != null;
            if (!IsPostBack)
            {
                UnionHelper helper = new UnionHelper(new UnionObject());
                helper.ValueObject.ArticleId = ArticleId;
                DataTable dt = helper.GetArticleComment();
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptComment.DataSource = dt;
                    rptComment.DataBind();
                }
                else
                {
                    pnlList.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session[Constants.Session.USER_ID] == null)
            {
                return;
            }

            if (Nulls.IsNullOrEmpty(txtTitle.Text.Trim()) || Nulls.IsNullOrEmpty(txtComment.Text.Trim()))
            {
                lblError.Visible = true;
                return;
            }

            int UserId = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
            string Name = HttpUtility.HtmlDecode(Session[Constants.Session.USER_FULLNAME].ToString());
            string Email = HttpUtility.HtmlDecode(Session[Constants.Session.USER_EMAIL].ToString());
            string Subject = txtTitle.Text.Trim();
            string Detail = txtComment.Text.Trim();

            ArticleCommentHelper helper = new ArticleCommentHelper(new ArticleComment());
            helper.ValueObject.Id = 0;
            helper.ValueObject.Status = CMSConstants.ArticleStatus.Published;
            helper.ValueObject.ArticleId = ArticleId;
            helper.ValueObject.Detail = Detail;
            helper.ValueObject.Email = Email;
            helper.ValueObject.History = string.Empty;
            helper.ValueObject.Name = Name;
            helper.ValueObject.Phone = string.Empty;
            helper.ValueObject.Subject = Subject;
            helper.ValueObject.PId = 0;
            helper.ValueObject.Created_At = DateTime.Now;
            helper.ValueObject.Created_By = UserId;
            helper.ValueObject.Last_Modified_At = DateTime.Now;
            helper.ValueObject.Last_Modified_By = UserId;
            helper.DoSave();

            //Rebind
            UnionHelper helper1 = new UnionHelper(new UnionObject());
            helper1.ValueObject.ArticleId = ArticleId;
            rptComment.DataSource = helper1.GetArticleComment();
            rptComment.DataBind();

            //clear text
            //pnlForm.Visible = false;
            txtTitle.Text = string.Empty;
            txtComment.Text = string.Empty;

            //show comment
            pnlList.Visible = true;
        }
    }
}