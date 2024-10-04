using System;
using System.Web;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Events
{
    public partial class ArticleEventDisplay : BasePage
    {
        protected string correctAlias = string.Empty;
        protected string editAlias = string.Empty;
        protected bool isCorrect = false;
        protected bool isEdit = false;
        protected bool isPublish = false;
        protected bool isSystem = false;
        protected string publishAlias = string.Empty;
        protected string systemAlias = string.Empty;

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

                    ArticleEventHelper helper = new ArticleEventHelper(new ArticleEvent());
                    helper.ValueObject.Id = docId;
                    helper.LoadEncode();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    //get primary category
                    bool isMyArticleEvent = (UserId == helper.ValueObject.Created_By);

                    //check Status
                    switch (HttpUtility.HtmlDecode(helper.ValueObject.Status))
                    {
                        case CMSConstants.ArticleEventStatus.Draft:
                        case CMSConstants.ArticleEventStatus.Rejected:
                            //check Status -> policy
                            if (!(isMyArticleEvent || isSystem)) // khoong phair nguowif taoj hoawcj Heej thoongs
                            {
                                Utilities.NoRightToAccess();
                            }
                            break;
                        case CMSConstants.ArticleEventStatus.Submited:
                            //check Status -> policy
                            if (!((isMyArticleEvent || isSystem) && (isEdit || isCorrect || isPublish)))
                                // khoong phair quanr lys Heej thoongs
                                // vaf co quyen Bieen taapj hoawcj Soats looix hoawcj Xuaats banr
                            {
                                Utilities.NoRightToAccess();
                            }

                            //Guwir Tin baif
                            radToolBarDefault.Items[2].Enabled = radToolBarDefault.Items[2].Visible = false; //separator
                            radToolBarDefault.Items[3].Enabled = radToolBarDefault.Items[3].Visible = false; //button
                            break;
                        case CMSConstants.ArticleEventStatus.Editted:
                            //check Status -> policy
                            if (!((isMyArticleEvent || isSystem) && (isCorrect || isPublish)))
                                // khoong phair quanr lys Heej thoongs
                                //hoawcj co quyen Soats looix hoawcj Xuaats banr
                            {
                                Utilities.NoRightToAccess();
                            }

                            //Guwir Tin baif
                            radToolBarDefault.Items[2].Enabled = radToolBarDefault.Items[2].Visible = false; //separator
                            radToolBarDefault.Items[3].Enabled = radToolBarDefault.Items[3].Visible = false; //button
                            //Bieen taapj Tin baif
                            radToolBarDefault.Items[4].Enabled = radToolBarDefault.Items[4].Visible = false; //separator
                            radToolBarDefault.Items[5].Enabled = radToolBarDefault.Items[5].Visible = false; //button
                            break;
                        case CMSConstants.ArticleEventStatus.Corrected:
                        case CMSConstants.ArticleEventStatus.Published:
                        case CMSConstants.ArticleEventStatus.Stopped:
                            //check Status -> policy
                            if (!((isMyArticleEvent || isSystem) || isPublish))
                                // khoong phair quanr lys Heej thoongs hoawcj co quyen Xuaats banr
                            {
                                Utilities.NoRightToAccess();
                            }

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
                radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = isUpdater;
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
            }
            else
            {
                lblMessage.Visible = false;
            }
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.CMS.Article.Event";
            viewAlias = "VietNamNet.CMS.Article.Event.View";
            addNewAlias = "VietNamNet.CMS.Article.Event.AddNew";
            updateAlias = "VietNamNet.CMS.Article.Event.Update";
            deleteAlias = "VietNamNet.CMS.Article.Event.Delete";
            editAlias = "VietNamNet.CMS.Article.Event.Edit";
            correctAlias = "VietNamNet.CMS.Article.Event.Correct";
            publishAlias = "VietNamNet.CMS.Article.Event.Publish";
            systemAlias = "VietNamNet.CMS.Article.Event.System";
            ErrorMessage1.ClearMessage();
            ErrorMessage1.Visible = false;
            lblNoteError.Visible = false;
        }

        protected override void GetPolicy()
        {
            base.GetPolicy();

            isEdit = SystemUtils.GetPolicy(UserId, moduleAlias, editAlias);
            isCorrect = SystemUtils.GetPolicy(UserId, moduleAlias, correctAlias);
            isPublish = SystemUtils.GetPolicy(UserId, moduleAlias, publishAlias);
            isSystem = SystemUtils.GetPolicy(UserId, moduleAlias, systemAlias);
        }

        private void BindData(ArticleEvent o)
        {
            #region ArticleEvent info

            lblStatus.Text = o.Status;
            lblTotalView.Text = Utilities.DisplayNumberFormat(o.TotalView);
            lblName.Text = o.Name;
            lblTitle.Text = o.Title;
            lblImageLink.Text = o.ImageLink;
            hidImageLink.Value = o.ImageLink;
            lblLead.Text = HttpUtility.HtmlDecode(o.Lead);
            lblDetail.Text = HttpUtility.HtmlDecode(o.Detail);

            #endregion

            #region Items

            Session[GetArticleEventItemSessionName()] = o.Items;
            pnlArticleEventItem.BindDataToItems();

            #endregion

            #region Publish

            lblPublishDate.Text = Utilities.FormatDisplayDateTime(o.PublishDate);
            Session[GetArticleEventCategoriesSessionName()] = o.Categories;
            pnlArticleEventCategory.BindDataToCategories();

            #endregion

            #region History

            lblHistory.Text = HttpUtility.HtmlDecode(o.History);

            #endregion
        }

        private string GetArticleEventItemSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", CMSConstants.Session.CMSData.ArticleEventItem, docId);
        }

        private string GetArticleEventCategoriesSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", CMSConstants.Session.CMSData.ArticleEventCategories, docId);
        }

        private void DoSave(string status)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            ArticleEventHelper helper = new ArticleEventHelper(new ArticleEvent());
            helper.ValueObject.Id = docId;
            if (docId > 0) helper.Load();

            if (helper.ValueObject == null)
            {
                Utilities.ItemDoesntExist();
            }

            //set status
            helper.ValueObject.Status = (Nulls.IsNullOrEmpty(status))
                                            ? Nulls.IsNullOrEmpty(helper.ValueObject.Status)
                                                  ? CMSConstants.ArticleEventStatus.Draft
                                                  : helper.ValueObject.Status
                                            : status;
            //set history
            switch (status)
            {
                case CMSConstants.ArticleEventStatus.Draft:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventSave),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleEventStatus.Submited:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventSubmit),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleEventStatus.Editted:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventEdit),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleEventStatus.Corrected:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventCorrect),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleEventStatus.Published:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventPublish),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleEventStatus.Rejected:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventReject),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleEventStatus.Stopped:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventStop),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                default:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventSave),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now), txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
            }

            //set Audit trail
            AuditTrail1.Set(helper.ValueObject);

            //Save
            helper.DoSave();

            //Redirect to Diplay page
            Utilities.Redirect(CMSConstants.FormNames.CMS.Events.ArticleEventDisplay, helper.ValueObject.Id.ToString());
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(CMSConstants.FormNames.CMS.Events.ArticleEventEdit);
                    break;
                case Constants.CommandNames.Edit:
                    if (Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.DOC_ID]))
                    {
                        Utilities.ItemDoesntExist();
                    }
                    else
                    {
                        Utilities.Redirect(CMSConstants.FormNames.CMS.Events.ArticleEventEdit,
                                           Request.Params[Constants.ParameterName.DOC_ID]);
                    }
                    break;
                case Constants.CommandNames.Delete:
                    int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

                    ArticleEventHelper helper = new ArticleEventHelper(new ArticleEvent());
                    helper.ValueObject.Id = docId;
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;
                    helper.Delete();

                    //Go to View
                    Utilities.GoBackToView(CMSConstants.FormNames.CMS.Events.ArticleEventView);
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(CMSConstants.FormNames.CMS.Events.ArticleEventView);
                    break;
                case CMSConstants.ArticleEventCommand.Submitted:
                    DoSave(CMSConstants.ArticleEventStatus.Submited);
                    break;
                case CMSConstants.ArticleEventCommand.Editted:
                    DoSave(CMSConstants.ArticleEventStatus.Editted);
                    break;
                case CMSConstants.ArticleEventCommand.Corrected:
                    DoSave(CMSConstants.ArticleEventStatus.Corrected);
                    break;
                case CMSConstants.ArticleEventCommand.Published:
                    DoSave(CMSConstants.ArticleEventStatus.Published);
                    break;
                case CMSConstants.ArticleEventCommand.Rejected:
                    if (Nulls.IsNullOrEmpty(txtNote.Text.Trim())) //Kieemr tra lys do
                    {
                        lblNoteError.Visible = true;
                        ErrorMessage1.Visible = true;
                        ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleEventNoteCantEmpty));
                        RadTabStrip1.Tabs[2].Selected = true;
                        RadMultiPage1.PageViews[2].Selected = true;
                    }
                    else
                    {
                        DoSave(CMSConstants.ArticleEventStatus.Rejected);
                    }
                    break;
                case CMSConstants.ArticleEventCommand.Stopped:
                    DoSave(CMSConstants.ArticleEventStatus.Stopped);
                    break;
                default:
                    break;
            }
        }
    }
}