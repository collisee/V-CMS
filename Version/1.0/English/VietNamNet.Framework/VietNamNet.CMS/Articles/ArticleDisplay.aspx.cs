using System;
using System.Data;
using System.Web;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Articles
{
    public partial class ArticleDisplay : ArticleBasePage
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

                    ArticleHelper helper = new ArticleHelper(new Article());
                    helper.ValueObject.Id = docId;
                    helper.LoadEncode();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    //get primary category
                    int primaryCategoryId = GetPrimaryCategory(helper.ValueObject);
                    bool isMyArticle = (UserId == helper.ValueObject.Created_By);
                    bool isMyCategory = (primaryCategoryId == 0 && isSystem) || CMSUtils.GetCategoryPolicy(UserId, primaryCategoryId);

                    //check Status
                    switch (HttpUtility.HtmlDecode(helper.ValueObject.Status))
                    {
                        case CMSConstants.ArticleStatus.Crawling:
                        case CMSConstants.ArticleStatus.Draft:
                        case CMSConstants.ArticleStatus.Rejected:
                            //check Status -> policy
                            if (!(isMyArticle || isMyCategory || isSystem))
                                // khoong phair nguowif taoj hoawjc quanr lys Danh mucj hoawcj Heej thoongs
                            {
                                Utilities.NoRightToAccess();
                            }
                            break;
                        case CMSConstants.ArticleStatus.Submited:
                            //check Status -> policy
                            if (!isMyArticle && !((isMyCategory || isSystem) && (isEdit || isCorrect || isPublish)))
                                // khoong phair quanr lys Danh mucj hoawcj Heej thoongs
                                // vaf co quyen Bieen taapj hoawcj Soats looix hoawcj Xuaats banr
                            {
                                Utilities.NoRightToAccess();
                            }

                            //check Status -> button
                            //Sua Tin bai
                            radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = ((isMyCategory || isSystem) && (isEdit || isCorrect || isPublish));
                            //Guwir Tin baif
                            radToolBarDefault.Items[2].Enabled = radToolBarDefault.Items[2].Visible = false; //separator
                            radToolBarDefault.Items[3].Enabled = radToolBarDefault.Items[3].Visible = false; //button
                            break;
                        case CMSConstants.ArticleStatus.Editted:
                            //check Status -> policy
                            if (!isMyArticle && !((isMyCategory || isSystem) && (isCorrect || isPublish)))
                                // khoong phair quanr lys Danh mucj hoawcj Heej thoongs
                                // vaf co quyen Soats looix hoawcj Xuaats banr
                            {
                                Utilities.NoRightToAccess();
                            }

                            //check Status -> button
                            //Sua Tin bai
                            radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = ((isMyCategory || isSystem) && (isCorrect || isPublish));
                            //Guwir Tin baif
                            radToolBarDefault.Items[2].Enabled = radToolBarDefault.Items[2].Visible = false; //separator
                            radToolBarDefault.Items[3].Enabled = radToolBarDefault.Items[3].Visible = false; //button
                            //Bieen taapj Tin baif
                            radToolBarDefault.Items[4].Enabled = radToolBarDefault.Items[4].Visible = false; //separator
                            radToolBarDefault.Items[5].Enabled = radToolBarDefault.Items[5].Visible = false; //button
                            break;
                        case CMSConstants.ArticleStatus.Corrected:
                        case CMSConstants.ArticleStatus.Published:
                        case CMSConstants.ArticleStatus.Stopped:
                            //check Status -> policy
                            if (!isMyArticle && !((isMyCategory || isSystem) && (isPublish)))
                                // khoong phair quanr lys Danh mucj hoawcj Heej thoongs
                                // vaf co quyen Xuaats banr
                            {
                                Utilities.NoRightToAccess();
                            }

                            //check Status -> button
                            //Sua Tin bai
                            radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = ((isMyCategory || isSystem) && (isPublish));
                            //Guwir Tin baif
                            radToolBarDefault.Items[2].Enabled = radToolBarDefault.Items[2].Visible = false; //separator
                            radToolBarDefault.Items[3].Enabled = radToolBarDefault.Items[3].Visible = false; //button
                            //Bieen taapj Tin baif
                            radToolBarDefault.Items[4].Enabled = radToolBarDefault.Items[4].Visible = false; //separator
                            radToolBarDefault.Items[5].Enabled = radToolBarDefault.Items[5].Visible = false; //button
                            //Soats looix Tin baif
                            radToolBarDefault.Items[6].Enabled = radToolBarDefault.Items[6].Visible = false; //separator
                            radToolBarDefault.Items[7].Enabled = radToolBarDefault.Items[7].Visible = false; //button
                            break;
                        default:
                            break;
                    }

                    BindData(helper.ValueObject);
                    AuditTrail1.Get(helper.ValueObject);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = helper.ValueObject.Id;

                    //check save success
                    if (Utilities.ParseInt(Request.Params[Constants.ParameterName.SAVE_SUCCESS]) == 1)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = Utilities.GetConfigKey(SystemConstants.Message.SaveSuccess);
                    }
                }
                else
                {
                    Utilities.ItemDoesntExist();
                }

                //show hide AddNew button
                radToolBarDefault.Items[0].Visible = radToolBarDefault.Items[0].Enabled = isAddNewer;
                if (!isUpdater) radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = false;
                //show hide Delete button
                radToolBarDefault.Items[10].Visible = radToolBarDefault.Items[10].Enabled = isDeleter;
                radToolBarDefault.Items[11].Visible = radToolBarDefault.Items[11].Enabled = isDeleter;

                //check Role -> button
                if (!isEdit) //Bieen taapj
                {
                    radToolBarDefault.Items[4].Enabled = radToolBarDefault.Items[4].Visible = false; //separator
                    radToolBarDefault.Items[5].Enabled = radToolBarDefault.Items[5].Visible = false; //button
                }
                if (!isCorrect) //Soats looix
                {
                    radToolBarDefault.Items[6].Enabled = radToolBarDefault.Items[6].Visible = false; //separator
                    radToolBarDefault.Items[7].Enabled = radToolBarDefault.Items[7].Visible = false; //button
                }
                if (!isPublish) //Xuaats banr
                {
                    radToolBarDefault.Items[8].Enabled = radToolBarDefault.Items[8].Visible = false; //separator
                    radToolBarDefault.Items[9].Enabled = radToolBarDefault.Items[9].Visible = false; //button
                }
                
                //show hide Royalty button
                ((RadToolBarDropDown)radToolBarDefault.Items[9]).Buttons[1].Visible =
                    ((RadToolBarDropDown)radToolBarDefault.Items[9]).Buttons[1].Enabled = CMSUtils.GetRoyaltyPolicy(UserId);
            }
            else
            {
                lblMessage.Visible = false;
            }
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(CMSConstants.FormNames.CMS.Articles.ArticleEdit);
                    break;
                case Constants.CommandNames.Edit:
                    if (Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.DOC_ID]))
                    {
                        Utilities.ItemDoesntExist();
                    }
                    else
                    {
                        Utilities.Redirect(CMSConstants.FormNames.CMS.Articles.ArticleEdit,
                                           Request.Params[Constants.ParameterName.DOC_ID]);
                    }
                    break;
                case Constants.CommandNames.Delete:
                    int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

                    ArticleHelper helper = new ArticleHelper(new Article());
                    helper.ValueObject.Id = docId;
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;
                    helper.Delete();

                    //Go to View
                    Utilities.GoBackToView(CMSConstants.FormNames.CMS.Articles.ArticleView);
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(CMSConstants.FormNames.CMS.Articles.ArticleView);
                    break;
                case CMSConstants.ArticleCommand.Submitted:
                    DoSave(CMSConstants.ArticleStatus.Submited, false);
                    break;
                case CMSConstants.ArticleCommand.Editted:
                    DoSave(CMSConstants.ArticleStatus.Editted, false);
                    break;
                case CMSConstants.ArticleCommand.Corrected:
                    DoSave(CMSConstants.ArticleStatus.Corrected, false);
                    break;
                case CMSConstants.ArticleCommand.Published:
                    DoSave(CMSConstants.ArticleStatus.Published, false);
                    break;
                case CMSConstants.ArticleCommand.PublishedAndRoyalty:
                    DoSave(CMSConstants.ArticleStatus.Published, true);
                    break;
                case CMSConstants.ArticleCommand.Rejected:
                    if (Nulls.IsNullOrEmpty(txtNote.Text.Trim())) //Kieemr tra lys do
                    {
                        lblNoteError.Visible = true;
                        ErrorMessage1.Visible = true;
                        ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleNoteCantEmpty));
                        btnReject.Visible = true;
                        RadTabStrip1.Tabs[4].Selected = true;
                        RadMultiPage1.PageViews[4].Selected = true;
                    }
                    else
                    {
                        DoSave(CMSConstants.ArticleStatus.Rejected, false);
                    }
                    break;
                case CMSConstants.ArticleCommand.Stopped:
                    DoSave(CMSConstants.ArticleStatus.Stopped, false);
                    break;
                default:
                    break;
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (Nulls.IsNullOrEmpty(txtNote.Text.Trim())) //Kieemr tra lys do
            {
                lblNoteError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleNoteCantEmpty));
                btnReject.Visible = true;
                RadTabStrip1.Tabs[4].Selected = true;
                RadMultiPage1.PageViews[4].Selected = true;
            }
            else
            {
                DoSave(CMSConstants.ArticleStatus.Rejected, false);
            }
        }

        #endregion

        #region Private Method

        private int GetPrimaryCategory(Article obj)
        {
            if (obj == null) return 0;

            DataTable dtCategories = obj.Categories;

            if (dtCategories != null && dtCategories.Rows.Count > 0)
            {
                foreach (DataRow row in dtCategories.Rows)
                {
                    if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.PrimaryCategory]) == 1)
                    {
                        return Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.CategoryId]);
                    }
                }
            }

            return 0;
        }

        private void BindData(Article o)
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

            #region Media

            Session[GetArticleMediaSessionName()] = o.Media;
            pnlArticleMedia.BindDataToMedia();

            #endregion

            #region Publish

            lblPublishDate.Text = Utilities.FormatDisplayDateTime(o.PublishDate);
            Session[GetArticleCategoriesSessionName()] = o.Categories;
            pnlArticleCategory.BindDataToCategories();

            #endregion

            #region Versions

            radGriVersions.DataSource = o.Versions;
            radGriVersions.DataBind();

            #endregion

            #region History

            lblHistory.Text = HttpUtility.HtmlDecode(o.History);

            #endregion

            #region Event Items

            Session[GetArticleEventItemSessionName()] = o.EventItems;
            pnlArticleEventItem.BindDataToItems();

            #endregion

            //logging
            SystemLogging.Info("Display Article", string.Format("{0} - {1}", o.Id, HttpUtility.HtmlDecode(o.Name)));
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

        private string GetArticleMediaSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", CMSConstants.Session.CMSData.ArticleMedia, docId);
        }

        private string GetArticleCategoriesSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", CMSConstants.Session.CMSData.ArticleCategories, docId);
        }

        private string GetArticleEventItemSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", CMSConstants.Session.CMSData.ArticleEventItem, docId);
        }

        private void DoSave(string status, bool royalty)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            ArticleHelper helper = new ArticleHelper(new Article());
            helper.ValueObject.Id = docId;
            if (docId > 0) helper.Load();

            if (helper.ValueObject == null)
            {
                Utilities.ItemDoesntExist();
            }

            //set update categories if not re-publish, adn saveStatus is null
            if (!Utilities.StringCompare(helper.ValueObject.Status, CMSConstants.ArticleStatus.Published))
            {
                foreach (DataRow row in helper.ValueObject.Categories.Rows)
                {
                    if (Nulls.IsNullOrEmpty(row[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus]))
                    {
                        row[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus] = Constants.CommonStatus.UPDATE;
                    }
                }
            }

            //set status
            helper.ValueObject.Status = (Nulls.IsNullOrEmpty(status))
                                            ? Nulls.IsNullOrEmpty(helper.ValueObject.Status)
                                                  ? CMSConstants.ArticleStatus.Draft
                                                  : helper.ValueObject.Status
                                            : status;
            //set history
            switch (status)
            {
                case CMSConstants.ArticleStatus.Draft:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleSave),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleStatus.Submited:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleSubmit),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleStatus.Editted:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEdit),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleStatus.Corrected:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCorrect),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleStatus.Published:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticlePublish),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleStatus.Rejected:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleReject),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleStatus.Stopped:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleStop),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                default:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleSave),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
            }

            //set Audit trail
            AuditTrail1.Set(helper.ValueObject);

            //Save
            helper.DoSave();

            //Redirect to Diplay page
            if (royalty)
            {
                string url =
                    Utilities.SetParamForURL(CMSUtils.GetRoyaltyPage(), Constants.ParameterName.DOC_ID,
                                             helper.ValueObject.Id);
                Response.Redirect(url);
            }
            else
            {
                Utilities.Redirect(CMSConstants.FormNames.CMS.Articles.ArticleDisplay, helper.ValueObject.Id.ToString());
            }
        }

        #endregion
    }
}