using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.MediaManager.Common;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Comments
{
    public partial class ArticleCommentEdit : BasePage
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
                EditorSetting();

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
                    helper.Load();

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

                    BindData();
                    AuditTrail1.Get(null);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = 0;
                }
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
            lblNameError.Visible = false;
            lblEmailError.Visible = false;
            lblDetailError.Visible = false;
            lblNoteError.Visible = false;
        }

        private void EditorSetting()
        {
            //Register Image, Flash, Media, Document, Template, Silverlight File Size
            radEditorMsgContent.ImageManager.MaxUploadFileSize = MediaManagerUtils.GetMaxUploadFileZip();
            radEditorMsgContent.FlashManager.MaxUploadFileSize = MediaManagerUtils.GetMaxUploadFileZip();
            radEditorMsgContent.MediaManager.MaxUploadFileSize = MediaManagerUtils.GetMaxUploadFileZip();
            radEditorMsgContent.DocumentManager.MaxUploadFileSize = MediaManagerUtils.GetMaxUploadFileZip();
            radEditorMsgContent.TemplateManager.MaxUploadFileSize = MediaManagerUtils.GetMaxUploadFileZip();
            radEditorMsgContent.SilverlightManager.MaxUploadFileSize = MediaManagerUtils.GetMaxUploadFileZip();

            //Get Media File Manager Policy
            string mediaModuleAlias = "VietNamNet.CMS.MediaManager";
            string mediaViewAlias = "VietNamNet.CMS.MediaManager.View";
            string mediaUploadAlias = "VietNamNet.CMS.MediaManager.Upload";
            string mediaDeleteAlias = "VietNamNet.CMS.MediaManager.Delete";
            string mediaSystemAlias = "VietNamNet.CMS.MediaManager.System";

            bool isMediaView = SystemUtils.GetPolicy(UserId, mediaModuleAlias, mediaViewAlias);
            bool isMediaUpload = SystemUtils.GetPolicy(UserId, mediaModuleAlias, mediaUploadAlias);
            bool isMediaDelete = SystemUtils.GetPolicy(UserId, mediaModuleAlias, mediaDeleteAlias);
            bool isMediaSystem = SystemUtils.GetPolicy(UserId, mediaModuleAlias, mediaSystemAlias);

            //Build Folder access list
            List<string> viewFolders = new List<string>();
            List<string> deleteFolders = new List<string>();
            List<string> uploadFolders = new List<string>();

            string folderByDay = MediaManagerUtils.GetUserFolderByDay();
            Directory.CreateDirectory(Server.MapPath(folderByDay));


            if (isMediaSystem)
            {
                if (isMediaView)
                {
                    viewFolders.Add(folderByDay);
                    viewFolders.Add(MediaManagerUtils.GetSystemFolder());
                }
                if (isMediaUpload) uploadFolders.Add(MediaManagerUtils.GetSystemFolder());
                if (isMediaDelete) deleteFolders.Add(MediaManagerUtils.GetSystemFolder());
            }
            else
            {
                if (isMediaView)
                {
                    viewFolders.Add(folderByDay);
                    viewFolders.Add(MediaManagerUtils.GetUserFolder());
                }
                if (isMediaUpload) uploadFolders.Add(MediaManagerUtils.GetUserFolder());
                if (isMediaDelete) deleteFolders.Add(MediaManagerUtils.GetUserFolder());
            }

            //Set Folder access
            radEditorMsgContent.ImageManager.ViewPaths = viewFolders.ToArray();
            radEditorMsgContent.ImageManager.UploadPaths = uploadFolders.ToArray();
            radEditorMsgContent.ImageManager.DeletePaths = deleteFolders.ToArray();

            radEditorMsgContent.FlashManager.ViewPaths = viewFolders.ToArray();
            radEditorMsgContent.FlashManager.UploadPaths = uploadFolders.ToArray();
            radEditorMsgContent.FlashManager.DeletePaths = deleteFolders.ToArray();

            radEditorMsgContent.MediaManager.ViewPaths = viewFolders.ToArray();
            radEditorMsgContent.MediaManager.UploadPaths = uploadFolders.ToArray();
            radEditorMsgContent.MediaManager.DeletePaths = deleteFolders.ToArray();

            radEditorMsgContent.DocumentManager.ViewPaths = viewFolders.ToArray();
            radEditorMsgContent.DocumentManager.UploadPaths = uploadFolders.ToArray();
            radEditorMsgContent.DocumentManager.DeletePaths = deleteFolders.ToArray();

            radEditorMsgContent.TemplateManager.ViewPaths = viewFolders.ToArray();
            radEditorMsgContent.TemplateManager.UploadPaths = uploadFolders.ToArray();
            radEditorMsgContent.TemplateManager.DeletePaths = deleteFolders.ToArray();

            //Register Zip Upload
            radEditorMsgContent.ImageManager.ContentProviderTypeName =
                typeof (UnzipFileSystemContentProvider).AssemblyQualifiedName;
        }

        private void BindData()
        {
            int articleId = Utilities.ParseInt(Request.Params[CMSConstants.ParameterName.ArticleId]);
            int pId = Utilities.ParseInt(Request.Params[CMSConstants.ParameterName.PARENT_ID]);

            if (articleId <= 0)
            {
                Utilities.NoRightToCreate();
            }

            lblStatus.Text = CMSConstants.ArticleStatus.Draft;
            hidArticleId.Value = articleId.ToString();
            hidPId.Value = pId.ToString();

            //Article
            ArticleHelper helper = new ArticleHelper(new Article());
            helper.ValueObject.Id = articleId;
            helper.LoadSimple();

            if (helper.ValueObject != null)
            {
                lnkArticle.Text = HttpUtility.HtmlEncode(helper.ValueObject.Name);
                lnkArticle.NavigateUrl =
                    string.Format("{0}?{1}={2}", CMSConstants.FormNames.CMS.Articles.ArticlePreview,
                                  Constants.ParameterName.DOC_ID, helper.ValueObject.Id);
            }
        }

        private void BindData(ArticleComment o)
        {
            lblStatus.Text = o.Status;
            hidArticleId.Value = o.ArticleId.ToString();
            hidPId.Value = o.PId.ToString();

            txtName.Text = o.Name;
            txtEmail.Text = o.Email;
            txtPhone.Text = o.Phone;
            txtSubject.Text = o.Subject;

            radEditorMsgContent.Content = o.Detail;

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

            lblHistory.Text = o.History;

            #endregion
        }

        private bool GetData(ArticleComment o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

            #region Valid

            bool flag = true;

            //Name
            if (Nulls.IsNullOrEmpty(txtName.Text.Trim()))
            {
                lblNameError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleCommentNameCantEmpty));
                flag = false;
            }

            //Email
            if (Nulls.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                lblEmailError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleCommentEmailCantEmpty));
                flag = false;
            }

            //MsgContent
            if (Nulls.IsNullOrEmpty(radEditorMsgContent.Content.Trim()))
            {
                lblDetailError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleCommentMsgContentCantEmpty));
                flag = false;
            }

            if (!flag)
            {
                return false;
            }

            #endregion

            #region Get History

            string strHistory = string.Empty;

            if (docId == 0)
            {
                strHistory +=
                    string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCommentCreate),
                                  UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now));
            }
            else //check change
            {
                //ArticleId
                if (Utilities.ParseInt(hidArticleId.Value) != o.ArticleId)
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCommentChange),
                                      UserFullname, lblArticleLabel.Text, o.ArticleId, hidArticleId.Value);
                }

                //PId
                if (Utilities.ParseInt(hidPId.Value) != o.PId)
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCommentChange),
                                      UserFullname, "PId", o.PId, hidPId.Value);
                }

                //Name
                if (!Utilities.StringCompare(o.Name, txtName.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCommentChange),
                                      UserFullname, lblNameLabel.Text, o.Name, txtName.Text.Trim());
                }

                //Email
                if (!Utilities.StringCompare(o.Email, txtEmail.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCommentChange),
                                      UserFullname, lblEmailLabel.Text, o.Email, txtEmail.Text.Trim());
                }

                //Phone
                if (!Utilities.StringCompare(o.Phone, txtPhone.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCommentChange),
                                      UserFullname, lblPhoneLabel.Text, o.Phone, txtPhone.Text.Trim());
                }

                //Subject
                if (!Utilities.StringCompare(o.Subject, txtSubject.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCommentChange),
                                      UserFullname, lblSubjectLabel.Text, o.Subject, txtSubject.Text.Trim());
                }
            }

            #endregion

            #region Get Data

            o.Id = docId;
            //o.Status =

            o.ArticleId = Utilities.ParseInt(hidArticleId.Value);
            o.PId = Utilities.ParseInt(hidPId.Value);
            o.Name = txtName.Text.Trim();
            o.Email = txtEmail.Text.Trim();
            o.Phone = txtPhone.Text.Trim();
            o.Subject = txtSubject.Text.Trim();
            o.Detail = radEditorMsgContent.Content;

            o.History = strHistory + o.History;

            #endregion

            return true;
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

            if (GetData(helper.ValueObject))
            {
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
                Utilities.Redirect(CMSConstants.FormNames.CMS.Comments.ArticleCommentDisplay, helper.ValueObject.Id.ToString(), true);
            }
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.Save:
                    DoSave(string.Empty);
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