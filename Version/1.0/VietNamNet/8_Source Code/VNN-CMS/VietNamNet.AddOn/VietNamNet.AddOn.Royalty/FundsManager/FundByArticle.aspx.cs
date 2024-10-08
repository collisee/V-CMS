using System;
using System.Data;
using Telerik.Web.UI;
using VietNamNet.AddOn.Royalty.Components;
using VietNamNet.AddOn.Royalty.Core.Common.ValueObject;
using VietNamNet.AddOn.Royalty.Core.Presentation;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Royalty.FundsManager
{
    public partial class FundByArticle : RoyaltyBasePage
    {
        #region  "Members"
        private int _RoyaltyId;
        private int _ArticleId =0;
        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        { 
            base.PageLoad();


            if (!isFundManager)
            {
                Utilities.NoRightToAccess();
            }

            if (Request.Params["DocId"] != null)
            {
                _ArticleId = Utilities.ParseInt(Request.Params["DocId"]);
            }
            else
            {
                Utilities.ItemDoesntExist();
            }

            if (!IsPostBack)
            {
                SetupEnvironment();
            }

        }

        protected void RadToolBarDefaultButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            try
            {
                switch (e.Item.Value)
                {
                    case "AddNew":
                        Response.Redirect(VietNamNet.AddOn.Royalty.Core.Common.Constants.FormNames.FUND_EDIT
                                        + "?settype=0&DocId=" + _ArticleId.ToString());
                        break;
                    case "AddPlus":
                        Response.Redirect(VietNamNet.AddOn.Royalty.Core.Common.Constants.FormNames.FUND_EDIT
                                        + "?settype=1&DocId=" + _ArticleId.ToString());
                        break;
                    case "AddSub":
                        Response.Redirect(VietNamNet.AddOn.Royalty.Core.Common.Constants.FormNames.FUND_EDIT
                                        + "?settype=2&DocId=" + _ArticleId.ToString());
                        break;
                    case "AddMore":
                        Response.Redirect(VietNamNet.AddOn.Royalty.Core.Common.Constants.FormNames.FUND_EDIT
                                        + "?settype=3&DocId=" + _ArticleId.ToString());
                        break;
                    case "Update":
                        Utilities.Redirect(VietNamNet.AddOn.Royalty.Core.Common.Constants.FormNames.FUND_EDIT, _ArticleId.ToString());
                        break;

                    case "Cancel":
                        Response.Redirect("Default.aspx"); 
                        break;
                }
            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }
        }

        protected void GrdViewPageIndexChanged(object source, GridPageChangedEventArgs e)
        {
            //PopularType(e.NewPageIndex);
        }

        protected void GrdViewPageSizeChanged(object source, GridPageSizeChangedEventArgs e)
        {

        }

        protected void GrdViewItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Edit":
                        Utilities.Redirect(VietNamNet.AddOn.Royalty.Core.Common.Constants.FormNames.FUND_EDIT
                                + "?DocId=" + txtArticleId.Text 
                                + "&" + VietNamNet.AddOn.Royalty.Core.Common.Constants.ParameterName.FUND_ID + "=" + e.CommandArgument);
                        break;
                    case "Delete":
                        DeleteItem(Utilities.ParseInt(e.CommandArgument));
                        PopularFund(Utilities.ParseInt(txtArticleId.Text));
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        #endregion

        #region Private Methods
        private void SetupEnvironment()
        {
            PopularArticleInfo(_ArticleId);
            PopularFund(_ArticleId);
        }
        private void PopularFund(int articleId)
        {

            RoyaltyFundHelper helper = new RoyaltyFundHelper(new RoyaltyFund());
            helper.ValueObject.Article_Id = articleId;
            DataTable dt = helper.ListByArticle();

            radGridDefault.DataSource = dt;
            radGridDefault.DataBind();

            if (dt.Rows.Count > 0)
            {
                radToolBarDefault.Items.FindItemByValue("AddPlus").Visible = true;
                radToolBarDefault.Items.FindItemByValue("AddSub").Visible = true;
                radToolBarDefault.Items.FindItemByValue("AddMore").Visible = true;
            }
        }

        private void PopularArticleInfo(int ArticleId)
        {
            txtArticleId.Text = ArticleId.ToString();
            ArticleHelper helper = new ArticleHelper(new Article());
            helper.ValueObject.Id = ArticleId;
            helper.Load();

            if (helper.ValueObject == null) Utilities.ItemDoesntExist();

            //check Status -> policy
            txtName.Text = "<a target='_blank' href='/CMS/Articles/ArticlePreview.aspx?DocId=" + ArticleId.ToString() + "'>" + helper.ValueObject.Name + "</a>";

            lblArticleInfo.Text =   "<label class=\"label w100\">Trạng thái: </label>" + helper.ValueObject.Status +
                                    "<br> <label class=\"label w100\">Tác giả: </label>" +  (helper.ValueObject.IsMember == 1 ? "Phóng viên":"Cộng tác viên") +
                                    "<br> <label class=\"label w100\">Tên tác giả: </label>" + helper.ValueObject.Author +
                                    "<br> <label class=\"label w100\">Ngày XB: </label>" + String.Format("{0:dd/MM/yyyy HH:mm}", helper.ValueObject.PublishDate) + "";
            //lblArticleHistory.Text = helper.ValueObject.History;

            RadPanelBar1.Items[0].Items[0].Text = helper.ValueObject.History;
            //cmbIsMember.Items.FindItemByValue(helper.ValueObject.IsMember.ToString()).Selected = true;
            //if (cmbUser.Items.FindItemByValue(helper.ValueObject.AuthorId.ToString()) != null) cmbUser.Items.FindItemByValue(helper.ValueObject.AuthorId.ToString()).Selected = true;
            //if (cmbCollaborator.Items.FindItemByValue(helper.ValueObject.AuthorId.ToString()) != null) cmbCollaborator.Items.FindItemByValue(helper.ValueObject.AuthorId.ToString()).Selected = true;

        }

        private void DeleteItem(int fundId)
        {
            RoyaltyFundHelper helper = new RoyaltyFundHelper(new RoyaltyFund());
            helper.ValueObject.Fund_Id = fundId;
            helper.ValueObject.Last_Modified_At = DateTime.Now;
            helper.ValueObject.Last_Modified_By = UserId;

            helper.Delete();

        }
        #endregion

        #region Public Methods
        #endregion

    }
}
