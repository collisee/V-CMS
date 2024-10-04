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
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.CMS.Articles
{
    public partial class ArticleEdit : BasePage
    {
        protected string editAlias = string.Empty;
        protected string correctAlias = string.Empty;
        protected string publishAlias = string.Empty;
        protected string categoryAlias = string.Empty;
        protected string systemAlias = string.Empty;

        protected bool isEdit = false;
        protected bool isCorrect = false;
        protected bool isPublish = false;
        protected bool isCategory = false;
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

                    ArticleHelper helper = new ArticleHelper(new Article());
                    helper.ValueObject.Id = docId;
                    helper.Load();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    //get primary category
                    int primaryCategoryId = GetPrimaryCategory(helper.ValueObject);
                    bool isMyArticle = (UserId == helper.ValueObject.Created_By);
                    bool isMyCategory = (primaryCategoryId == 0 && isSystem) || CMSUtils.GetCategoryPolicy(UserId, primaryCategoryId);

                    //check Status -> policy
                    switch(helper.ValueObject.Status)
                    {
                        case CMSConstants.ArticleStatus.Draft:
                        case CMSConstants.ArticleStatus.Rejected:
                        default:
                            break;
                    }

                    //check Status
                    switch (helper.ValueObject.Status)
                    {
                        case CMSConstants.ArticleStatus.Crawling:
                        case CMSConstants.ArticleStatus.Draft:
                        case CMSConstants.ArticleStatus.Rejected:
                            //check Status -> policy
                            if (!(isMyArticle || isMyCategory || isSystem)) // khoong phair nguowif taoj hoawjc quanr lys Danh mucj hoawcj Heej thoongs
                            {
                                Utilities.NoRightToAccess();
                            }
                            break;
                        case CMSConstants.ArticleStatus.Submited:
                            //check Status -> policy
                            if (!((isMyArticle || isMyCategory || isSystem) && (isEdit || isCorrect || isPublish))) // khoong phair quanr lys Danh mucj hoawcj Heej thoongs
                                                                                                      // vaf co quyen Bieen taapj hoawcj Soats looix hoawcj Xuaats banr
                            {
                                Utilities.NoRightToAccess();
                            }

                            //check Status -> button
                            //Guwir Tin baif
                            radToolBarDefault.Items[1].Enabled = radToolBarDefault.Items[1].Visible = false; //separator
                            radToolBarDefault.Items[2].Enabled = radToolBarDefault.Items[2].Visible = false; //button
                            break;
                        case CMSConstants.ArticleStatus.Editted:
                            //check Status -> policy
                            if (!((isMyArticle || isMyCategory || isSystem) && (isCorrect || isPublish))) // khoong phair quanr lys Danh mucj hoawcj Heej thoongs
                                                                                            // vaf co quyen Soats looix hoawcj Xuaats banr
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
                        case CMSConstants.ArticleStatus.Corrected:
                        case CMSConstants.ArticleStatus.Published:
                        case CMSConstants.ArticleStatus.Stopped:
                            //check Status -> policy
                            if (!((isMyArticle || isMyCategory || isSystem) && (isPublish))) // khoong phair quanr lys Danh mucj hoawcj Heej thoongs
                                                                               // vaf co quyen Xuaats banr
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
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.CMS.Article";
            viewAlias = "VietNamNet.CMS.Article.View";
            addNewAlias = "VietNamNet.CMS.Article.AddNew";
            updateAlias = "VietNamNet.CMS.Article.Update";
            deleteAlias = "VietNamNet.CMS.Article.Delete";
            editAlias = "VietNamNet.CMS.Article.Edit";
            correctAlias = "VietNamNet.CMS.Article.Correct";
            publishAlias = "VietNamNet.CMS.Article.Publish";
            categoryAlias = "VietNamNet.CMS.Article.Category";
            systemAlias = "VietNamNet.CMS.Article.System";
            ErrorMessage1.ClearMessage();
            ErrorMessage1.Visible = false;
            lblNameError.Visible = false;
            lblLeadError.Visible = false;
            lblDetailError.Visible = false;
            lblPublishDateError.Visible = false;
            lblCategoriesError.Visible = false;
            lblNoteError.Visible = false;
            btnReject.Visible = false;
        }

        protected override void GetPolicy()
        {
            base.GetPolicy();

            isEdit = SystemUtils.GetPolicy(UserId, moduleAlias, editAlias);
            isCorrect = SystemUtils.GetPolicy(UserId, moduleAlias, correctAlias);
            isPublish = SystemUtils.GetPolicy(UserId, moduleAlias, publishAlias);
            isCategory = SystemUtils.GetPolicy(UserId, moduleAlias, categoryAlias);
            isSystem = SystemUtils.GetPolicy(UserId, moduleAlias, systemAlias);
        }

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
                typeof (UnzipFileSystemContentProvider).AssemblyQualifiedName;
        }

        private void BindDataToArticleType(int tid)
        {
            ArticleTypeHelper helper = new ArticleTypeHelper(new ArticleType());
            cmbArticleType.DataSource = helper.ListAll();
            cmbArticleType.DataBind();
            if (tid > 0) cmbArticleType.SelectedValue = tid.ToString();
        }

        private void BindDataToArticleContentType(int tid)
        {
            ArticleContentTypeHelper helper = new ArticleContentTypeHelper(new ArticleContentType());
            cmbArticleContentType.DataSource = helper.ListAll();
            cmbArticleContentType.DataBind();
            if (tid > 0) cmbArticleContentType.SelectedValue = tid.ToString();
        }

        private void BindDataToGroup(int gid)
        {
            GroupHelper helper = new GroupHelper(new Group());
            cmbGroup.DataSource = helper.ListAll();
            cmbGroup.DataBind();
            cmbGroup.Items.Insert(0, new RadComboBoxItem("Tất cả", "0"));
            if (gid > 0) cmbGroup.SelectedValue = gid.ToString();
        }

        private void BindDataToUser(int gid, int uid)
        {
            UserHelper helper = new UserHelper(new User());
            if (gid > 0)
            {
                helper.ValueObject.GroupId = gid;
                cmbUser.DataSource = helper.GetUserByGroup();
            }
            else
            {
                cmbUser.DataSource = helper.ListAll();
            }

            cmbUser.DataBind();
            if (uid > 0) cmbUser.SelectedValue = uid.ToString();
        }

        private void BindDataToCollaborator(int cid)
        {
            CollaboratorHelper helper = new CollaboratorHelper(new Collaborator());
            cmbCollaborator.DataSource = helper.ListAll();
            cmbCollaborator.DataBind();
            if (cid > 0) cmbCollaborator.SelectedValue = cid.ToString();
        }

        private void BindData()
        {
            BindDataToArticleType(0);
            BindDataToArticleContentType(0);
            BindDataToGroup(0);
            BindDataToUser(0, UserId);
            BindDataToCollaborator(0);

            plhNotMember.Visible = false;
            radDpkPublishDate.SelectedDate = DateTime.Now;

            Session[GetArticleMediaSessionName()] = null;
            Session[GetArticleCategoriesSessionName()] = null;

            radGriVersions.DataSource = ArticleVersionDAO.GetTemplateTable();
            radGriVersions.DataBind();

            pnlArticleMedia.BindDataToMedia();
            pnlArticleCategory.BindDataToCategories();
        }

        private void BindData(Article o)
        {
            #region Common info

            lblStatus.Text = o.Status;

            BindDataToArticleType(o.ArticleTypeId);
            BindDataToArticleContentType(o.ArticleContentTypeId);
            BindDataToGroup(0);
            BindDataToUser(0, UserId);
            BindDataToCollaborator(0);

            txtTotalView.Value = o.TotalView;
            cmbIsMember.SelectedValue = o.IsMember.ToString();
            if (o.IsMember == 1) //Phongs vieen
            {
                plhNotMember.Visible = false;
                foreach (RadComboBoxItem item in cmbUser.Items)
                {
                    if (Utilities.StringCompare(item.Text, o.Author))
                    {
                        item.Selected = true;
                    }
                }
            }
            else //Coongj tacs vieen
            {
                plhMember.Visible = false;
                foreach (RadComboBoxItem item in cmbCollaborator.Items)
                {
                    if (Utilities.StringCompare(item.Text, o.Author))
                    {
                        item.Selected = true;
                    }
                }
                txtAuthorInfo.Text = o.AuthorInfo;
            }

            #endregion

            #region Article info

            txtName.Text = o.Name;
            txtTitle.Text = o.Title;
            txtImageLink.Text = o.ImageLink;
            radEditorLead.Content = o.Lead;
            radEditorMsgContent.Content = o.Detail;

            #endregion

            #region Sub info

            txtSubTitle1.Text = o.SubTitle1;
            txtSubTitle2.Text = o.SubTitle2;
            txtSubTitle3.Text = o.SubTitle3;
            txtSubTitle4.Text = o.SubTitle4;
            txtSubTitle5.Text = o.SubTitle5;
            txtSubTitle6.Text = o.SubTitle6;
            txtImageLink1.Text = o.ImageLink1;
            txtImageLink2.Text = o.ImageLink2;
            txtImageLink3.Text = o.ImageLink3;
            txtImageLink4.Text = o.ImageLink4;
            txtImageLink5.Text = o.ImageLink5;

            #endregion

            #region Media

            Session[GetArticleMediaSessionName()] = o.Media;
            pnlArticleMedia.BindDataToMedia();

            #endregion

            #region Publish

            radDpkPublishDate.SelectedDate = o.PublishDate;
            Session[GetArticleCategoriesSessionName()] = o.Categories;
            pnlArticleCategory.BindDataToCategories();

            #endregion

            #region Versions

            radGriVersions.DataSource = o.Versions;
            radGriVersions.DataBind();

            #endregion

            #region History

            lblHistory.Text = o.History;

            #endregion
        }

        private void AddNewCollaborator(string name, string detail)
        {
            CollaboratorHelper helper = new CollaboratorHelper(new Collaborator());
            helper.ValueObject.Id = 0;
            helper.ValueObject.Name = name;
            helper.ValueObject.Detail = detail;
            helper.ValueObject.Created_At = DateTime.Now;
            helper.ValueObject.Created_By = UserId;
            helper.ValueObject.Last_Modified_At = DateTime.Now;
            helper.ValueObject.Last_Modified_By = UserId;
            helper.DoSave();
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

        private bool GetData(Article o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            //Media
            DataTable dtMedia = (Session[GetArticleMediaSessionName()] != null)
                                    ? (DataTable) Session[GetArticleMediaSessionName()]
                                    : ArticleMediaDAO.GetTemplateTable();
            //Categories
            DataTable dtCategories = (Session[GetArticleCategoriesSessionName()] != null)
                                         ? (DataTable) Session[GetArticleCategoriesSessionName()]
                                         : ArticleCategoryDAO.GetTemplateTable();

            #region Valid

            bool flag = true;
            int tabFocus = 0;

            #region Common info

            //no valid

            #endregion

            #region Article info

            //Name
            if (Nulls.IsNullOrEmpty(txtName.Text.Trim()))
            {
                lblNameError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleNameCantEmpty));
                flag = false;
                if (tabFocus == 0) tabFocus = 1;
            }

            //Lead
            if (Nulls.IsNullOrEmpty(radEditorLead.Content.Trim()))
            {
                lblLeadError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleLeadCantEmpty));
                flag = false;
                if (tabFocus == 0) tabFocus = 1;
            }
            else //valid number of words
            {
                string content = radEditorLead.Text;
                string[] words = content.Split(new char[] {' ', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);

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
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleMsgContentCantEmpty));
                flag = false;
                if (tabFocus == 0) tabFocus = 1;
            }

            #endregion

            #region Sub info

            //no valid

            #endregion

            #region Media

            //no valid

            #endregion

            #region Publish

            //PublishDate
            if (radDpkPublishDate.SelectedDate == null)
            {
                lblPublishDateError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticlePublishDateCantEmpty));
                flag = false;
                if (tabFocus == 0) tabFocus = 2;
            }

            //Categories
            if (dtCategories == null || dtCategories.Rows.Count == 0)
            {
                lblCategoriesError.Visible = true;
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleCategoriesCantEmpty));
                flag = false;
                if (tabFocus == 0) tabFocus = 2;
            }
            else
            {
                bool blnPrimary = false;
                foreach (DataRow row in dtCategories.Rows)
                {
                    if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.PrimaryCategory]) == 1)
                    {
                        blnPrimary = true;
                        break;
                    }
                }

                if (!blnPrimary)
                {
                    lblCategoriesError.Visible = true;
                    ErrorMessage1.Visible = true;
                    ErrorMessage1.AddMessage(Utilities.GetConfigKey(CMSConstants.Message.ArticleCategoriesMissPrimary));
                    flag = false;
                    if (tabFocus == 0) tabFocus = 2;
                }
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
                    string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCreate),
                                  UserFullname, Utilities.FormatDisplayDateTime(DateTime.Now));
            }
            else //check change
            {
                #region Common info

                //ArticleType
                if (Utilities.ParseInt(cmbArticleType.SelectedValue) != o.ArticleTypeId)
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblArticleTypeLabel.Text, GetArticleTypeName(o.ArticleTypeId),
                                      GetArticleTypeName(Utilities.ParseInt(cmbArticleType.SelectedValue)));
                }

                //ArticleContentType
                if (Utilities.ParseInt(cmbArticleContentType.SelectedValue) != o.ArticleContentTypeId)
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblArticleContentTypeLabel.Text, GetArticleContentTypeName(o.ArticleContentTypeId),
                                      GetArticleContentTypeName(Utilities.ParseInt(cmbArticleContentType.SelectedValue)));
                }

                //TotalView
                if (Utilities.ParseInt(txtTotalView.Value) != o.TotalView)
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblTotalViewLabel.Text, o.TotalView,
                                      Utilities.ParseInt(txtTotalView.Value));
                }

                //IsMember
                if (Utilities.ParseInt(cmbIsMember.SelectedValue) != o.IsMember)
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblIsMemberLabel.Text, cmbIsMember.Items[o.IsMember].Text,
                                      cmbIsMember.SelectedItem.Text);
                }

                if (Utilities.ParseInt(cmbIsMember.SelectedValue) == 1) //Phongs vieen
                {
                    //Author
                    if (!Utilities.StringCompare(o.Author, cmbUser.Text))
                    {
                        strHistory +=
                            string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                          UserFullname, lblUserLabel.Text, o.Author, cmbUser.Text);
                    }
                }
                else //Coongj tacs vieen
                {
                    //Author
                    if (!Utilities.StringCompare(o.Author, cmbCollaborator.Text))
                    {
                        strHistory +=
                            string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                          UserFullname, lblCollaboratorLabel.Text, o.Author, cmbCollaborator.Text);
                    }

                    //AuthorInfo
                    if (!Utilities.StringCompare(o.AuthorInfo, txtAuthorInfo.Text.Trim()))
                    {
                        strHistory +=
                            string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                          UserFullname, lblAuthorInfoLabel.Text, o.AuthorInfo, txtAuthorInfo.Text.Trim());
                    }
                }

                #endregion

                #region Article info

                //Name
                if (!Utilities.StringCompare(o.Name, txtName.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblNameLabel.Text, o.Name, txtName.Text.Trim());
                }
                
                //Title
                if (!Utilities.StringCompare(o.Title, txtTitle.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblTitleLabel.Text, o.Title, txtTitle.Text.Trim());
                }
                
                //ImageLink
                if (!Utilities.StringCompare(o.ImageLink, txtImageLink.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblImageLinkLabel.Text, o.ImageLink, txtImageLink.Text.Trim());
                }
                
                /*
                //Lead
                if (!Utilities.StringCompare(o.Lead, radEditorLead.Content))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblLeadLabel.Text, o.Lead, radEditorLead.Content);
                }
                
                //Detail
                if (!Utilities.StringCompare(o.Detail, radEditorMsgContent.Content))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblDetailLabel.Text, o.Detail, radEditorMsgContent.Content);
                }
                 * */

                #endregion

                #region Sub info

                //SubTitle1
                if (!Utilities.StringCompare(o.SubTitle1, txtSubTitle1.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblSubTitle1Label.Text, o.SubTitle1, txtSubTitle1.Text.Trim());
                }
                
                //SubTitle2
                if (!Utilities.StringCompare(o.SubTitle2, txtSubTitle2.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblSubTitle2Label.Text, o.SubTitle2, txtSubTitle2.Text.Trim());
                }
                
                //SubTitle3
                if (!Utilities.StringCompare(o.SubTitle3, txtSubTitle3.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblSubTitle3Label.Text, o.SubTitle3, txtSubTitle3.Text.Trim());
                }
                
                //SubTitle4
                if (!Utilities.StringCompare(o.SubTitle4, txtSubTitle4.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblSubTitle4Label.Text, o.SubTitle4, txtSubTitle4.Text.Trim());
                }
                
                //SubTitle5
                if (!Utilities.StringCompare(o.SubTitle5, txtSubTitle5.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblSubTitle5Label.Text, o.SubTitle5, txtSubTitle5.Text.Trim());
                }
                
                //SubTitle6
                if (!Utilities.StringCompare(o.SubTitle6, txtSubTitle6.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblSubTitle6Label.Text, o.SubTitle6, txtSubTitle6.Text.Trim());
                }

                //ImageLink1
                if (!Utilities.StringCompare(o.ImageLink1, txtImageLink1.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblImageLink1Label.Text, o.ImageLink1, txtImageLink1.Text.Trim());
                }

                //ImageLink2
                if (!Utilities.StringCompare(o.ImageLink2, txtImageLink2.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblImageLink2Label.Text, o.ImageLink2, txtImageLink2.Text.Trim());
                }

                //ImageLink3
                if (!Utilities.StringCompare(o.ImageLink3, txtImageLink3.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblImageLink3Label.Text, o.ImageLink3, txtImageLink3.Text.Trim());
                }

                //ImageLink4
                if (!Utilities.StringCompare(o.ImageLink4, txtImageLink4.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblImageLink4Label.Text, o.ImageLink4, txtImageLink4.Text.Trim());
                }

                //ImageLink5
                if (!Utilities.StringCompare(o.ImageLink5, txtImageLink5.Text.Trim()))
                {
                    strHistory +=
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblImageLink5Label.Text, o.ImageLink5, txtImageLink5.Text.Trim());
                }

                #endregion

                #region Media

                //Media
                foreach (DataRow row in dtMedia.Rows)
                {
                    if (Utilities.StringCompare(row[CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus], Constants.CommonStatus.NEW))
                    {
                        strHistory +=
                            string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleMediaAddnew),
                                          UserFullname, row[CMSConstants.Entities.ArticleMedia.FieldName.FileLink]);
                    }
                    else if (Utilities.StringCompare(row[CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus], Constants.CommonStatus.UPDATE))
                    {
                        strHistory +=
                            string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleMediaChange),
                                          UserFullname, row[CMSConstants.Entities.ArticleMedia.FieldName.FileLink],
                                          row[CMSConstants.Entities.ArticleMedia.FieldName.Ord],
                                          row[CMSConstants.Entities.ArticleMedia.FieldName.Detail]);
                    }
                    else if (Utilities.StringCompare(row[CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus], Constants.CommonStatus.DELETE))
                    {
                        if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleMedia.FieldName.Id]) > 0)
                        {
                            strHistory +=
                                string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleMediaDelete),
                                              UserFullname, row[CMSConstants.Entities.ArticleMedia.FieldName.FileLink]);
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
                        string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleChange),
                                      UserFullname, lblPublishDateLabel.Text, strPublishDateOld, strPublishDateNew);
                }

                //Categories
                foreach (DataRow row in dtCategories.Rows)
                {
                    if (Utilities.StringCompare(row[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus], Constants.CommonStatus.NEW))
                    {
                        strHistory +=
                            string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCategoryAddnew),
                                          UserFullname, row[CMSConstants.Entities.ArticleCategory.FieldName.CategoryName]);
                    }
                    else if (Utilities.StringCompare(row[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus], Constants.CommonStatus.UPDATE))
                    {
                        int oldOrd = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.OldOrd]);
                        int ord = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.Ord]);
                        int primary = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.PrimaryCategory]);
                        if (oldOrd != ord)
                        {
                            strHistory +=
                                string.Format(
                                    Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCategoryChangeOrder),
                                    UserFullname, row[CMSConstants.Entities.ArticleCategory.FieldName.CategoryName],
                                    row[CMSConstants.Entities.ArticleCategory.FieldName.OldOrd],
                                    row[CMSConstants.Entities.ArticleCategory.FieldName.Ord]);
                        }
                        if (primary == 1)
                        {
                            strHistory +=
                                string.Format(
                                    Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCategoryChangePrimary),
                                    UserFullname, row[CMSConstants.Entities.ArticleCategory.FieldName.CategoryName]);
                        }
                    }
                    else if (Utilities.StringCompare(row[CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus], Constants.CommonStatus.DELETE))
                    {
                        if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.Id]) > 0)
                        {
                            strHistory +=
                                string.Format(Utilities.GetConfigKey(CMSConstants.Message.History.ArticleCategoryDelete),
                                              UserFullname, row[CMSConstants.Entities.ArticleCategory.FieldName.CategoryName]);
                        }
                    }
                }

                #endregion
            }

            #endregion

            #region Get Data

            o.Id = docId;
            //o.VersionId =
            //o.Status =

            #region Common info

            o.ArticleTypeId = Utilities.ParseInt(cmbArticleType.SelectedValue);
            o.ArticleContentTypeId = Utilities.ParseInt(cmbArticleContentType.SelectedValue);
            o.TotalView = Utilities.ParseInt(txtTotalView.Value);
            o.IsMember = Utilities.ParseInt(cmbIsMember.SelectedValue);
            if (o.IsMember == 1) //Phongs vieen
            {
                o.Author = cmbUser.Text;
                o.AuthorInfo = string.Empty;
            }
            else //Coongj tacs vieen
            {
                //check Collaborator
                int collaboratorId = Utilities.ParseInt(cmbCollaborator.SelectedValue);
                if (collaboratorId == 0)
                {
                    AddNewCollaborator(cmbCollaborator.Text, txtAuthorInfo.Text.Trim());
                }

                //get data
                o.Author = cmbCollaborator.Text;
                o.AuthorInfo = txtAuthorInfo.Text.Trim();
            }

            #endregion

            #region Article info

            o.Name = txtName.Text.Trim();
            o.Title = txtTitle.Text.Trim();
            o.ImageLink = txtImageLink.Text.Trim();
            o.Lead = radEditorLead.Content;
            o.Detail = radEditorMsgContent.Content;

            #endregion

            #region Sub info

            o.SubTitle1 = txtSubTitle1.Text.Trim();
            o.SubTitle2 = txtSubTitle2.Text.Trim();
            o.SubTitle3 = txtSubTitle3.Text.Trim();
            o.SubTitle4 = txtSubTitle4.Text.Trim();
            o.SubTitle5 = txtSubTitle5.Text.Trim();
            o.SubTitle6 = txtSubTitle6.Text.Trim();
            o.ImageLink1 = txtImageLink1.Text.Trim();
            o.ImageLink2 = txtImageLink2.Text.Trim();
            o.ImageLink3 = txtImageLink3.Text.Trim();
            o.ImageLink4 = txtImageLink4.Text.Trim();
            o.ImageLink5 = txtImageLink5.Text.Trim();

            #endregion

            #region Media

            o.Media = dtMedia;

            #endregion

            #region Publish

            o.PublishDate = (DateTime) radDpkPublishDate.SelectedDate;
            o.Categories = dtCategories;

            foreach (DataRow row in dtCategories.Rows)
            {
                if (Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.PrimaryCategory]) == 1)
                {
                    o.Url = row[CMSConstants.Entities.ArticleCategory.FieldName.Url].ToString();
                    o.CategoryId = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.CategoryId]);
                    o.PartitionId = Utilities.ParseInt(row[CMSConstants.Entities.ArticleCategory.FieldName.PartitionId]);
                    break;
                }
            }

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
            ArticleHelper helper = new ArticleHelper(new Article());
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
                Utilities.Redirect(CMSConstants.FormNames.CMS.Articles.ArticleDisplay, helper.ValueObject.Id.ToString(), true);
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
                    Utilities.GoBackToView(CMSConstants.FormNames.CMS.Articles.ArticleView);
                    break;
                case CMSConstants.ArticleCommand.Submitted:
                    DoSave(CMSConstants.ArticleStatus.Submited);
                    break;
                case CMSConstants.ArticleCommand.Editted:
                    DoSave(CMSConstants.ArticleStatus.Editted);
                    break;
                case CMSConstants.ArticleCommand.Corrected:
                    DoSave(CMSConstants.ArticleStatus.Corrected);
                    break;
                case CMSConstants.ArticleCommand.Published:
                    DoSave(CMSConstants.ArticleStatus.Published);
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

        protected void cmbIsMember_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!Utilities.Event_Handler(o, e)) return;

            int isMember = Utilities.ParseInt(cmbIsMember.SelectedValue);
            plhMember.Visible = isMember == 1;
            plhNotMember.Visible = isMember == 0;
        }

        protected void cmbGroup_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!Utilities.Event_Handler(o, e)) return;

            BindDataToUser(Utilities.ParseInt(cmbGroup.SelectedValue), 0);
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
                DoSave(CMSConstants.ArticleStatus.Rejected);
            }
        }
    }
}