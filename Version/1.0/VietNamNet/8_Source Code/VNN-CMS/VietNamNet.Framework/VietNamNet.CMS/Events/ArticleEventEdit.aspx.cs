using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.DBAccess;
using VietNamNet.CMS.MediaManager.Common;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Events
{
    public partial class ArticleEventEdit : BasePage
    {
        protected string editAlias = string.Empty;
        protected string correctAlias = string.Empty;
        protected string publishAlias = string.Empty;
        protected string systemAlias = string.Empty;

        protected bool isEdit = false;
        protected bool isCorrect = false;
        protected bool isPublish = false;
        protected bool isSystem = false;

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
                //EditorSetting();

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
                    helper.Load();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    //get primary category
                    bool isMyArticleEvent = (UserId == helper.ValueObject.Created_By);

                    //check Status
                    switch (helper.ValueObject.Status)
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
                            if (!((isMyArticleEvent || isSystem) && (isEdit || isCorrect || isPublish))) // khoong phair quanr lys Heej thoongs
                            // vaf co quyen Bieen taapj hoawcj Soats looix hoawcj Xuaats banr
                            {
                                Utilities.NoRightToAccess();
                            }

                            //check Status -> button
                            //Guwir Tin baif
                            radToolBarDefault.Items[1].Enabled = radToolBarDefault.Items[1].Visible = false; //separator
                            radToolBarDefault.Items[2].Enabled = radToolBarDefault.Items[2].Visible = false; //button
                            break;
                        case CMSConstants.ArticleEventStatus.Editted:
                            //check Status -> policy
                            if (!((isMyArticleEvent || isSystem) && (isCorrect || isPublish))) // khoong phair quanr lys Heej thoongs
                            //hoawcj co quyen Soats looix hoawcj Xuaats banr
                            {
                                Utilities.NoRightToAccess();
                            }

                            //Guwir Tin baif
                            radToolBarDefault.Items[1].Enabled = radToolBarDefault.Items[1].Visible = false; //separator
                            radToolBarDefault.Items[2].Enabled = radToolBarDefault.Items[2].Visible = false; //button
                            //Bieen taapj Tin baif
                            radToolBarDefault.Items[3].Enabled = radToolBarDefault.Items[3].Visible = false; //separator
                            radToolBarDefault.Items[4].Enabled = radToolBarDefault.Items[4].Visible = false; //button
                            break;
                        case CMSConstants.ArticleEventStatus.Corrected:
                        case CMSConstants.ArticleEventStatus.Published:
                        case CMSConstants.ArticleEventStatus.Stopped:
                            //check Status -> policy
                            if (!((isMyArticleEvent || isSystem) || isPublish)) // khoong phair quanr lys Heej thoongs hoawcj co quyen Xuaats banr
                            {
                                Utilities.NoRightToAccess();
                            }

                            //Guwir Tin baif
                            radToolBarDefault.Items[1].Enabled = radToolBarDefault.Items[1].Visible = false; //separator
                            radToolBarDefault.Items[2].Enabled = radToolBarDefault.Items[2].Visible = false; //button
                            //Bieen taapj Tin baif
                            radToolBarDefault.Items[3].Enabled = radToolBarDefault.Items[3].Visible = false; //separator
                            radToolBarDefault.Items[4].Enabled = radToolBarDefault.Items[4].Visible = false; //button
                            //Soats looix Tin baif
                            radToolBarDefault.Items[5].Enabled = radToolBarDefault.Items[5].Visible = false; //separator
                            radToolBarDefault.Items[6].Enabled = radToolBarDefault.Items[6].Visible = false; //button
                            break;
                        default:
                            break;
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

                //check Role -> button
                if (!isEdit) //Bieen taapj
                {
                    radToolBarDefault.Items[3].Enabled = radToolBarDefault.Items[3].Visible = false; //separator
                    radToolBarDefault.Items[4].Enabled = radToolBarDefault.Items[4].Visible = false; //button
                }
                if (!isCorrect) //Soats looix
                {
                    radToolBarDefault.Items[5].Enabled = radToolBarDefault.Items[5].Visible = false; //separator
                    radToolBarDefault.Items[6].Enabled = radToolBarDefault.Items[6].Visible = false; //button
                }
                if (!isPublish) //Xuaats banr
                {
                    radToolBarDefault.Items[7].Enabled = radToolBarDefault.Items[7].Visible = false; //separator
                    radToolBarDefault.Items[8].Enabled = radToolBarDefault.Items[8].Visible = false; //button
                }
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
            lblNameError.Visible = false;
            lblLeadError.Visible = false;
            lblDetailError.Visible = false;
            lblPublishDateError.Visible = false;
            lblCategoriesError.Visible = false;
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
            radEditorLead.ImageManager.ViewPaths = viewFolders.ToArray();
            radEditorLead.ImageManager.UploadPaths = uploadFolders.ToArray();
            radEditorLead.ImageManager.DeletePaths = deleteFolders.ToArray();

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
                typeof(UnzipFileSystemContentProvider).AssemblyQualifiedName;
        }

        private void BindData()
        {
            radDpkPublishDate.SelectedDate = DateTime.Now;

            Session[GetArticleEventItemSessionName()] = null;
            Session[GetArticleEventCategoriesSessionName()] = null;

            pnlArticleEventItem.BindDataToItems();
            pnlArticleEventCategory.BindDataToCategories();
        }

        private void BindData(ArticleEvent o)
        {
            #region ArticleEvent info

            lblStatus.Text = o.Status;
            txtTotalView.Value = o.TotalView;
            txtName.Text = o.Name;
            txtTitle.Text = o.Title;
            txtImageLink.Text = o.ImageLink;
            radEditorLead.Content = o.Lead;
            radEditorMsgContent.Content = o.Detail;

            #endregion

            #region Items

            Session[GetArticleEventItemSessionName()] = o.Items;
            pnlArticleEventItem.BindDataToItems();

            #endregion

            #region Publish

            radDpkPublishDate.SelectedDate = o.PublishDate;
            Session[GetArticleEventCategoriesSessionName()] = o.Categories;
            pnlArticleEventCategory.BindDataToCategories();

            #endregion

            #region History

            lblHistory.Text = o.History;

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

        private bool GetData(ArticleEvent o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            //Items
            DataTable dtItems = (Session[GetArticleEventItemSessionName()] != null)
                                    ? (DataTable)Session[GetArticleEventItemSessionName()]
                                    : ArticleEventItemDAO.GetTemplateTable();
            //Categories
            DataTable dtCategories = (Session[GetArticleEventCategoriesSessionName()] != null)
                                         ? (DataTable)Session[GetArticleEventCategoriesSessionName()]
                                         : ArticleEventCategoryDAO.GetTemplateTable();

            #region Valid

            bool flag = true;
            int tabFocus = 0;

            #region Common info

            //no valid

            #endregion

            #region ArticleEvent info

            //Name
            if (Nulls.IsNullOrEmpty(txtName.Text.Trim()))
            {
                lblNameError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleEventNameCantEmpty));
                flag = false;
                if (tabFocus == 0) tabFocus = 1;
            }

            //Lead
            if (Nulls.IsNullOrEmpty(radEditorLead.Content.Trim()))
            {
                lblLeadError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleEventLeadCantEmpty));
                flag = false;
                if (tabFocus == 0) tabFocus = 1;
            }
            else //valid number of words
            {
                string content = radEditorLead.Text;
                string[] words = content.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                if (words.Length > CMSUtils.GetLeadMaxWords() || content.Length > CMSUtils.GetLeadMaxChars())
                {
                    lblLeadError.Visible = true;
                    ErrorMessage1.Visible = true;
                    ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.LeadLimitedAlert));
                    flag = false;
                    if (tabFocus == 0) tabFocus = 1;
                }
            }

            //MsgContent
            if (Nulls.IsNullOrEmpty(radEditorMsgContent.Content.Trim()))
            {
                lblDetailError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleEventMsgContentCantEmpty));
                flag = false;
                if (tabFocus == 0) tabFocus = 1;
            }

            #endregion

            #region Sub info

            //no valid

            #endregion

            #region Items

            //no valid

            #endregion

            #region Publish

            //PublishDate
            if (radDpkPublishDate.SelectedDate == null)
            {
                lblPublishDateError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleEventPublishDateCantEmpty));
                flag = false;
                if (tabFocus == 0) tabFocus = 2;
            }

            //Categories
            if (dtCategories == null || dtCategories.Rows.Count == 0)
            {
                lblCategoriesError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleEventCategoriesCantEmpty));
                flag = false;
                if (tabFocus == 0) tabFocus = 2;
            }

            #endregion

            if (!flag)
            {
                if (tabFocus > 0)
                {
                    RadTabStrip1.Tabs[tabFocus].Selected = true;
                    RadMultiPage1.PageViews[tabFocus].Selected = true;
                }
                return false;
            }

            #endregion

            #region Get History

            string strHistory = string.Empty;

            if (docId == 0)
            {
                strHistory +=
                    string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventCreate),
                                  UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now));
            }
            else //check change
            {
                #region ArticleEvent info

                //TotalView
                if (Utilities.ParseInt(txtTotalView.Value) != o.TotalView)
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventChange),
                                      UserFullname, lblTotalViewLabel.Text, o.TotalView,
                                      Utilities.ParseInt(txtTotalView.Value));
                }

                //Name
                if (!Utilities.StringCompare(o.Name, txtName.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventChange),
                                      UserFullname, lblNameLabel.Text, o.Name, txtName.Text.Trim());
                }

                //Title
                if (!Utilities.StringCompare(o.Title, txtTitle.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventChange),
                                      UserFullname, lblTitleLabel.Text, o.Title, txtTitle.Text.Trim());
                }

                //ImageLink
                if (!Utilities.StringCompare(o.ImageLink, txtImageLink.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventChange),
                                      UserFullname, lblImageLinkLabel.Text, o.ImageLink, txtImageLink.Text.Trim());
                }

                /*
                //Lead
                if (!Utilities.StringCompare(o.Lead, radEditorLead.Content))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventChange),
                                      UserFullname, lblLeadLabel.Text, o.Lead, radEditorLead.Content);
                }
                
                //Detail
                if (!Utilities.StringCompare(o.Detail, radEditorMsgContent.Content))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventChange),
                                      UserFullname, lblDetailLabel.Text, o.Detail, radEditorMsgContent.Content);
                }
                 * */

                #endregion

                #region Items

                //Item
                foreach (DataRow row in dtItems.Rows)
                {
                    if (Utilities.StringCompare(row[CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus], Constants.CommonStatus.NEW))
                    {
                        strHistory +=
                            string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventItemAddnew),
                                          UserFullname, row[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleName]);
                    }
                    else if (Utilities.StringCompare(row[CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus], Constants.CommonStatus.UPDATE))
                    {
                        strHistory +=
                            string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventItemChange),
                                          UserFullname, row[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleName],
                                          row[CMSConstants.Entities.ArticleEventItem.FieldName.Ord]);
                    }
                    else if (Utilities.StringCompare(row[CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus], Constants.CommonStatus.DELETE))
                    {
                        if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventItem.FieldName.Id]) > 0)
                        {
                            strHistory +=
                                string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventItemDelete),
                                              UserFullname, row[CMSConstants.Entities.ArticleEventItem.FieldName.ArticleName]);
                        }
                    }
                }

                #endregion

                #region Publish

                //PublishDate
                string strPublishDateOld = Utilities.FormatDisplayDateOnly(o.PublishDate);
                string strPublishDateNew = Utilities.FormatDisplayDateOnly((DateTime)radDpkPublishDate.SelectedDate);
                if (!Utilities.StringCompare(strPublishDateNew, strPublishDateOld))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventChange),
                                      UserFullname, lblPublishDateLabel.Text, strPublishDateOld, strPublishDateNew);
                }

                //Categories
                foreach (DataRow row in dtCategories.Rows)
                {
                    if (Utilities.StringCompare(row[CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus], Constants.CommonStatus.NEW))
                    {
                        strHistory +=
                            string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventCategoryAddnew),
                                          UserFullname, row[CMSConstants.Entities.ArticleEventCategory.FieldName.CategoryName]);
                    }
                    else if (Utilities.StringCompare(row[CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus], Constants.CommonStatus.UPDATE))
                    {
                        int oldOrd = Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventCategory.FieldName.OldOrd]);
                        int ord = Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventCategory.FieldName.Ord]);
                        if (oldOrd != ord)
                        {
                            strHistory +=
                                string.Format(
                                    Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventCategoryChangeOrder),
                                    UserFullname, row[CMSConstants.Entities.ArticleEventCategory.FieldName.CategoryName],
                                    row[CMSConstants.Entities.ArticleEventCategory.FieldName.OldOrd],
                                    row[CMSConstants.Entities.ArticleEventCategory.FieldName.Ord]);
                        }
                    }
                    else if (Utilities.StringCompare(row[CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus], Constants.CommonStatus.DELETE))
                    {
                        if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleEventCategory.FieldName.Id]) > 0)
                        {
                            strHistory +=
                                string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleEventCategoryDelete),
                                              UserFullname, row[CMSConstants.Entities.ArticleEventCategory.FieldName.CategoryName]);
                        }
                    }
                }

                #endregion
            }

            #endregion

            #region Get Data

            o.Id = docId;
            //o.Status =

            #region ArticleEvent info

            o.TotalView = Utilities.ParseInt(txtTotalView.Value);
            o.Name = txtName.Text.Trim();
            o.Title = txtTitle.Text.Trim();
            o.ImageLink = txtImageLink.Text.Trim();
            o.Lead = radEditorLead.Content;
            o.Detail = radEditorMsgContent.Content;

            #endregion

            #region Items

            o.Items = dtItems;

            #endregion

            #region Publish

            o.PublishDate = (DateTime)radDpkPublishDate.SelectedDate;
            o.Categories = dtCategories;

            #endregion

            #region History

            o.History = strHistory + o.History;

            #endregion

            #endregion

            return true;
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

            if (GetData(helper.ValueObject))
            {
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
                Utilities.Redirect(CMSConstants.FormNames.CMS.Events.ArticleEventDisplay, helper.ValueObject.Id.ToString(), true);
            }
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.Save:
                    DoSave(string.Empty);
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