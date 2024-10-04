using System;
using System.Web;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Articles
{
    public partial class ArticleVersionDisplay : ArticleBasePage
    {
        #region Handler Method

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                //Load Data
                int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
                if (docId > 0) //update
                {
                    if (!isUpdater)
                    {
                        Utilities.NoRightToAccess();
                    }

                    ArticleVersionHelper helper = new ArticleVersionHelper(new ArticleVersion());
                    helper.ValueObject.Id = docId;
                    helper.LoadEncode();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    BindData(helper.ValueObject);
                    AuditTrail1.Get(helper.ValueObject);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = helper.ValueObject.Id;
                }
                else //add new
                {
                    if (!isAddNewer)
                    {
                        Utilities.NoRightToCreate();
                    }

                    AuditTrail1.Get(null);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = 0;
                }
            }
        }

        #endregion

        #region Private Method

        private void BindData(ArticleVersion o)
        {
            #region Common info

            lblStatus.Text = o.Status;

            lblArticleType.Text = GetArticleTypeName(o.ArticleTypeId);
            lblArticleContentType.Text = GetArticleContentTypeName(o.ArticleContentTypeId);

            lblTotalView.Text = Utilities.DisplayNumberFormat(o.TotalView);
            if (o.IsMember == 1) //Phongs vieen
            {
                plhNotMember.Visible = false;
                lblIsMember0.Visible = false;
                lblUser.Text = o.Author;
            }
            else //Coongj tacs vieen
            {
                plhMember.Visible = false;
                lblIsMember1.Visible = false;
                lblCollaborator.Text = o.Author;
                lblAuthorInfo.Text = o.AuthorInfo;
            }

            #endregion

            #region Article info

            lblName.Text = o.Name;
            lblTitle.Text = o.Title;
            lblImageLink.Text = o.ImageLink;
            hidImageLink.Value = o.ImageLink;
            lblLead.Text = HttpUtility.HtmlDecode(o.Lead);
            lblDetail.Text = HttpUtility.HtmlDecode(o.Detail);

            #endregion

            #region Sub info

            lblSubTitle1.Text = o.SubTitle1;
            lblSubTitle2.Text = o.SubTitle2;
            lblSubTitle3.Text = o.SubTitle3;
            lblSubTitle4.Text = o.SubTitle4;
            lblSubTitle5.Text = o.SubTitle5;
            lblSubTitle6.Text = o.SubTitle6;
            lblImageLink1.Text = o.ImageLink1;
            lblImageLink2.Text = o.ImageLink2;
            lblImageLink3.Text = o.ImageLink3;
            lblImageLink4.Text = o.ImageLink4;
            lblImageLink5.Text = o.ImageLink5;
            hidImageLink1.Value = o.ImageLink1;
            hidImageLink2.Value = o.ImageLink2;
            hidImageLink3.Value = o.ImageLink3;
            hidImageLink4.Value = o.ImageLink4;
            hidImageLink5.Value = o.ImageLink5;

            #endregion

            #region Publish

            lblPublishDate.Text = Utilities.FormatDisplayDateTime(o.PublishDate);

            #endregion

            #region History

            lblHistory.Text = HttpUtility.HtmlDecode(o.History);

            #endregion
        }

        private string GetArticleTypeName(int id)
        {
            ArticleTypeHelper helper = new ArticleTypeHelper(new ArticleType());
            helper.ValueObject.Id = id;
            helper.LoadEncode();

            return (helper.ValueObject == null) ? string.Empty : helper.ValueObject.Name;
        }

        private string GetArticleContentTypeName(int id)
        {
            ArticleContentTypeHelper helper = new ArticleContentTypeHelper(new ArticleContentType());
            helper.ValueObject.Id = id;
            helper.LoadEncode();

            return (helper.ValueObject == null) ? string.Empty : helper.ValueObject.Name;
        }

        #endregion
    }
}