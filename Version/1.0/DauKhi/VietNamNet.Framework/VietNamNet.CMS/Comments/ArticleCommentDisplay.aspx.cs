using System;
using System.Web;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Comments
{
    public partial class ArticleCommentDisplay : BasePage
    {
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

                    ArticleCommentHelper helper = new ArticleCommentHelper(new ArticleComment());
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

                    //check save success
                    if (Utilities.ParseInt(Request.Params[Constants.ParameterName.SAVE_SUCCESS]) == 1)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = Utilities.GetConfigKey(SystemConstants.Message.SaveSuccess);
                    }
                }
                else //add new
                {
                    Utilities.ItemDoesntExist();
                }

                //show hide AddNew button
                radToolBarDefault.Items[0].Visible = radToolBarDefault.Items[0].Enabled = isAddNewer;
                radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = isUpdater;
                radToolBarDefault.Items[5].Visible = radToolBarDefault.Items[5].Enabled = isDeleter;
                radToolBarDefault.Items[6].Visible = radToolBarDefault.Items[6].Enabled = isDeleter;
            }
            else
            {
                lblMessage.Visible = false;
            }
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.CMS.Article.Comment";
            viewAlias = "VietNamNet.CMS.Article.Comment.View";
            addNewAlias = "VietNamNet.CMS.Article.Comment.AddNew";
            updateAlias = "VietNamNet.CMS.Article.Comment.Update";
            deleteAlias = "VietNamNet.CMS.Article.Comment.Delete";
            ErrorMessage1.ClearMessage();
            ErrorMessage1.Visible = false;
            lblNoteError.Visible = false;
        }

        private void BindData(ArticleComment o)
        {
            lblStatus.Text = o.Status;
            hidArticleId.Value = o.ArticleId.ToString();
            hidPId.Value = o.PId.ToString();

            lblName.Text = o.Name;
            lblEmail.Text = o.Email;
            lblPhone.Text = o.Phone;
            lblSubject.Text = o.Subject;

            lblDetail.Text = HttpUtility.HtmlDecode(o.Detail);

            //Article
            ArticleHelper helper = new ArticleHelper(new Article());
            helper.ValueObject.Id = o.ArticleId;
            helper.LoadSimple();

            if (helper.ValueObject != null)
            {
                lnkArticle.Text = HttpUtility.HtmlEncode(helper.ValueObject.Name);
                lnkArticle.NavigateUrl =
                    string.Format("{0}?{1}={2}", CMSConstants.FormNames.CMS.Articles.ArticlePreview,
                                  Constants.ParameterName.DOC_ID, helper.ValueObject.Id);
            }

            #region History

            lblHistory.Text = HttpUtility.HtmlDecode(o.History);

            #endregion

            //logging
            SystemLogging.Info("Display Comment", string.Format("{0} - {1}", o.Id, HttpUtility.HtmlDecode(o.Subject)));
        }

        private void DoSave(string status)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            ArticleCommentHelper helper = new ArticleCommentHelper(new ArticleComment());
            helper.ValueObject.Id = docId;
            if (docId > 0) helper.Load();

            if (helper.ValueObject == null)
            {
                Utilities.ItemDoesntExist();
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
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCommentSave),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now),
                                      txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleStatus.Published:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCommentPublish),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now),
                                      txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleStatus.Rejected:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCommentReject),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now),
                                      txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                case CMSConstants.ArticleStatus.Stopped:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCommentStop),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now),
                                      txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
                default:
                    helper.ValueObject.History =
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCommentSave),
                                      UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now),
                                      txtNote.Text.Trim()) +
                        helper.ValueObject.History;
                    break;
            }
            //set Audit trail
            AuditTrail1.Set(helper.ValueObject);

            //Save
            helper.DoSave();

            //Redirect to Diplay page
            Utilities.Redirect(CMSConstants.FormNames.CMS.Comments.ArticleCommentDisplay,
                               helper.ValueObject.Id.ToString());
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(CMSConstants.FormNames.CMS.Comments.ArticleCommentEdit);
                    break;
                case Constants.CommandNames.Edit:
                    if (Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.DOC_ID]))
                    {
                        Utilities.ItemDoesntExist();
                    }
                    else
                    {
                        Utilities.Redirect(CMSConstants.FormNames.CMS.Comments.ArticleCommentEdit,
                                           Request.Params[Constants.ParameterName.DOC_ID]);
                    }
                    break;
                case Constants.CommandNames.Delete:
                    int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

                    ArticleCommentHelper helper = new ArticleCommentHelper(new ArticleComment());
                    helper.ValueObject.Id = docId;
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;
                    helper.Delete();

                    //Go to View
                    Utilities.GoBackToView(CMSConstants.FormNames.CMS.Comments.ArticleCommentView);
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(CMSConstants.FormNames.CMS.Comments.ArticleCommentView);
                    break;
                case CMSConstants.ArticleCommand.Published:
                    DoSave(CMSConstants.ArticleStatus.Published);
                    break;
                case CMSConstants.ArticleCommand.Rejected:
                    if (Nulls.IsNullOrEmpty(txtNote.Text.Trim())) //Kieemr tra lys do
                    {
                        lblNoteError.Visible = true;
                        ErrorMessage1.Visible = true;
                        ErrorMessage1.AddMessage(
                            Utilities.GetConfigKey(CMSConstants.Message.ArticleCommentNoteCantEmpty));
                        RadTabStrip1.Tabs[1].Selected = true;
                        RadMultiPage1.PageViews[1].Selected = true;
                    }
                    else
                    {
                        DoSave(CMSConstants.ArticleStatus.Rejected);
                    }
                    break;
                case CMSConstants.ArticleCommand.Stopped:
                    DoSave(CMSConstants.ArticleStatus.Stopped);
                    break;
                default:
                    break;
            }
        }
    }
}