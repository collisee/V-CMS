using VietNamNet.Framework.Common;
using VietNamNet.Framework.Module;

/// <summary>
/// Constants of VietNamNet.CMS
/// </summary>
namespace VietNamNet.CMS.Common
{
    public class CMSConstants
    {
        #region Entities

        public class Entities : BaseEntities
        {
            #region Article

            public class Article
            {
                public const string Name = "Article";
                public const string Categories = "Categories";
                public const string Media = "Media";
                public const string Versions = "Versions";
                public const string EventItems = "EventItems";
                public static string[] SearchColumns = { "Name", "Status", "Author", "Title" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string ArticleContentTypeId = "ArticleContentTypeId";
                    public const string ArticleTypeId = "ArticleTypeId";
                    public const string Author = "Author";
                    public const string AuthorId = "AuthorId";
                    public const string AuthorInfo = "AuthorInfo";
                    public const string Detail = "Detail";
                    public const string History = "History";
                    public const string ImageLink = "ImageLink";
                    public const string ImageLink1 = "ImageLink1";
                    public const string ImageLink2 = "ImageLink2";
                    public const string ImageLink3 = "ImageLink3";
                    public const string ImageLink4 = "ImageLink4";
                    public const string ImageLink5 = "ImageLink5";
                    public const string IsMember = "IsMember";
                    public const string Lead = "Lead";
                    public const string Name = "Name";
                    public const string PublishDate = "PublishDate";
                    public const string ShowComment = "ShowComment";
                    public const string Status = "Status";
                    public const string SubTitle1 = "SubTitle1";
                    public const string SubTitle2 = "SubTitle2";
                    public const string SubTitle3 = "SubTitle3";
                    public const string SubTitle4 = "SubTitle4";
                    public const string SubTitle5 = "SubTitle5";
                    public const string SubTitle6 = "SubTitle6";
                    public const string Title = "Title";
                    public const string TotalView = "TotalView";
                    public const string VersionId = "VersionId";
                    public const string Url = "Url";
                    public const string CategoryId = "CategoryId";
                    public const string PartitionId = "PartitionId";
                }

                #endregion
            }

            #endregion

            #region ArticleCategory

            public class ArticleCategory
            {
                public const string Name = "ArticleCategory";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string ArticleContentTypeId = "ArticleContentTypeId";
                    public const string ArticleId = "ArticleId";
                    public const string CategoryId = "CategoryId";
                    public const string Ord = "Ord";
                    public const string PartitionId = "PartitionId";
                    public const string PrimaryCategory = "PrimaryCategory";
                    public const string OldOrd = "OldOrd";
                    public const string SaveStatus = "SaveStatus";
                    public const string CategoryName = "CategoryName";
                    public const string CategoryAlias = "CategoryAlias";
                    public const string Url = "Url";
                    public const string PublishDate = "PublishDate";
                    public const string ArticleName = "ArticleName";
                }

                #endregion
            }

            #endregion

            #region ArticleComment

            public class ArticleComment
            {
                public const string Name = "ArticleComment";
                public static string[] SearchColumns = { "Name", "Status", "Email", "Phone", "Subject" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string ArticleId = "ArticleId";
                    public const string Detail = "Detail";
                    public const string Email = "Email";
                    public const string History = "History";
                    public const string Name = "Name";
                    public const string Phone = "Phone";
                    public const string PId = "PId";
                    public const string Status = "Status";
                    public const string Subject = "Subject";
                }

                #endregion
            }

            #endregion

            #region ArticleContentType

            public class ArticleContentType
            {
                public const string Name = "ArticleContentType";
                public static string[] SearchColumns = { "Name", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Detail = "Detail";
                    public const string Name = "Name";
                }

                #endregion
            }

            #endregion

            #region ArticleEvent

            public class ArticleEvent
            {
                public const string Name = "ArticleEvent";
                public const string Categories = "Categories";
                public const string Items = "Items";
                public static string[] SearchColumns = { "Name", "Title", "Lead" };

                public class FieldName : BaseFieldName
                {
                    public const string Status = "Status";
                    public const string Name = "Name";
                    public const string Title = "Title";
                    public const string ImageLink = "ImageLink";
                    public const string Lead = "Lead";
                    public const string Detail = "Detail";
                    public const string PublishDate = "PublishDate";
                    public const string TotalView = "TotalView";
                    public const string History = "History";
                }
            }

            #endregion

            #region ArticleEventCategory

            public class ArticleEventCategory
            {
                public const string Name = "ArticleEventCategory";

                public class FieldName : BaseFieldName
                {
                    public const string ArticleEventId = "ArticleEventId";
                    public const string CategoryId = "CategoryId";
                    public const string OldOrd = "OldOrd";
                    public const string Ord = "Ord";
                    public const string SaveStatus = "SaveStatus";
                    public const string CategoryName = "CategoryName";
                    public const string CategoryAlias = "CategoryAlias";
                }
            }

            #endregion

            #region ArticleEventItem

            public class ArticleEventItem
            {
                public const string Name = "ArticleEventItem";

                public class FieldName : BaseFieldName
                {
                    public const string ArticleEventId = "ArticleEventId";
                    public const string ArticleId = "ArticleId";
                    public const string Ord = "Ord";
                    public const string SaveStatus = "SaveStatus";
                    public const string ArticleName = "ArticleName";
                    public const string ArticleAuthor = "ArticleAuthor";
                }
            }

            #endregion

            #region ArticleType

            public class ArticleType
            {
                public const string Name = "ArticleType";
                public static string[] SearchColumns = { "Name", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Detail = "Detail";
                    public const string Name = "Name";
                }

                #endregion
            }

            #endregion

            #region ArticleMedia

            public class ArticleMedia
            {
                public const string Name = "ArticleMedia";
                public static string[] SearchColumns = { "MediaType", "FileLink", "Thumbnail", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string ArticleId = "ArticleId";
                    public const string Detail = "Detail";
                    public const string FileLink = "FileLink";
                    public const string MediaType = "MediaType";
                    public const string Ord = "Ord";
                    public const string Thumbnail = "Thumbnail";
                    public const string SaveStatus = "SaveStatus";
                }

                #endregion
            }

            #endregion

            #region ArticleVersion

            public class ArticleVersion
            {
                public const string Name = "ArticleVersion";
                public static string[] SearchColumns = { "Name", "Status", "Author", "Title" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string ArticleContentTypeId = "ArticleContentTypeId";
                    public const string ArticleId = "ArticleId";
                    public const string ArticleTypeId = "ArticleTypeId";
                    public const string Author = "Author";
                    public const string AuthorInfo = "AuthorInfo";
                    public const string Detail = "Detail";
                    public const string History = "History";
                    public const string ImageLink = "ImageLink";
                    public const string ImageLink1 = "ImageLink1";
                    public const string ImageLink2 = "ImageLink2";
                    public const string ImageLink3 = "ImageLink3";
                    public const string ImageLink4 = "ImageLink4";
                    public const string ImageLink5 = "ImageLink5";
                    public const string IsMember = "IsMember";
                    public const string Lead = "Lead";
                    public const string Name = "Name";
                    public const string PublishDate = "PublishDate";
                    public const string Status = "Status";
                    public const string SubTitle1 = "SubTitle1";
                    public const string SubTitle2 = "SubTitle2";
                    public const string SubTitle3 = "SubTitle3";
                    public const string SubTitle4 = "SubTitle4";
                    public const string SubTitle5 = "SubTitle5";
                    public const string SubTitle6 = "SubTitle6";
                    public const string Title = "Title";
                    public const string TotalView = "TotalView";
                    public const string VersionId = "VersionId";
                }

                #endregion
            }

            #endregion

            #region Category

            public class Category
            {
                public const string Name = "Category";
                public static string[] SearchColumns = { "Name", "Url", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Alias = "Alias";
                    public const string Detail = "Detail";
                    public const string DisplayName = "DisplayName";
                    public const string Url = "Url";
                    public const string Name = "Name";
                    public const string Ord = "Ord";
                    public const string PartitionId = "PartitionId";
                    public const string PId = "PId";
                    public const string UserId = "UserId";
                }

                #endregion
            }

            #endregion

            #region CategoryPolicy

            public class CategoryPolicy
            {
                public const string Name = "CategoryPolicy";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string CategoryId = "CategoryId";
                    public const string GroupId = "GroupId";
                    public const string Val = "Val";
                    public const string CategoryPId = "CategoryPId";
                    public const string CategoryName = "CategoryName";
                    public const string CategoryDisplayName = "CategoryDisplayName";
                }

                #endregion
            }

            #endregion

            #region Collaborator

            public class Collaborator
            {
                public const string Name = "Collaborator";
                public static string[] SearchColumns = { "Name", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Detail = "Detail";
                    public const string Name = "Name";
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region Services

        public class Services : BaseServices
        {
            #region ArticleManager

            public class ArticleManager
            {
                public const string Name = "ArticleManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string LoadSimple = "LoadSimple";
                    public const string ViewGetAllArticle = "ViewGetAllArticle";
                    public const string ViewGetAllArticleByCategory = "ViewGetAllArticleByCategory";
                    public const string ViewGetAllArticleForPopupInsertNews = "ViewGetAllArticleForPopupInsertNews";
                    public const string ViewGetAllArticleForPopupInsertNewsWithoutCategory = "ViewGetAllArticleForPopupInsertNewsWithoutCategory";
                    public const string ViewGetAllArticleByManager = "ViewGetAllArticleByManager";

                    public const string SearchArticleByKeyword = "SearchArticleByKeyword";
                    public const string SearchArticleByKeywordCount = "SearchArticleByKeywordCount";  
                }

                #endregion
            }

            #endregion

            #region ArticleCategoryManager

            public class ArticleCategoryManager
            {
                public const string Name = "ArticleCategoryManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string OptimizeArticleCategory = "OptimizeArticleCategory";
                    public const string GetArticlesByCategoryId = "GetArticlesByCategoryId";
                    public const string SaveCategory = "SaveCategory";
                }

                #endregion
            }

            #endregion

            #region ArticleCommentManager

            public class ArticleCommentManager
            {
                public const string Name = "ArticleCommentManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllArticleComment = "ViewGetAllArticleComment";
                    public const string ViewGetAllArticleCommentByCategory = "ViewGetAllArticleCommentByCategory";
                    public const string ViewGetAllArticleCommentByStatus = "ViewGetAllArticleCommentByStatus";
                    public const string ViewGetAllArticleCommentByArticleId = "ViewGetAllArticleCommentByArticleId";
                }

                #endregion
            }

            #endregion

            #region ArticleContentTypeManager

            public class ArticleContentTypeManager
            {
                public const string Name = "ArticleContentTypeManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllArticleContentType = "ViewGetAllArticleContentType";
                }

                #endregion
            }

            #endregion

            #region ArticleEventManager

            public class ArticleEventManager
            {
                public const string Name = "ArticleEventManager";

                public class Actions : CommonActions
                {
                    public const string LoadSimple = "LoadSimple";
                    public const string ViewGetAllArticleEvent = "ViewGetAllArticleEvent";
                    public const string ViewGetAllArticleEventByCategory = "ViewGetAllArticleEventByCategory";
                    public const string ViewGetAllArticleEventByManager = "ViewGetAllArticleEventByManager";
                }
            }

            #endregion

            #region ArticleEventCategoryManager

            public class ArticleEventCategoryManager
            {
                public const string Name = "ArticleEventCategoryManager";

                public class Actions : CommonActions
                {
                    public const string OptimizeArticleEventCategory = "OptimizeArticleEventCategory";
                }
            }

            #endregion

            #region ArticleEventItemManager

            public class ArticleEventItemManager
            {
                public const string Name = "ArticleEventItemManager";

                public class Actions : CommonActions
                {
                }
            }

            #endregion

            #region ArticleTypeManager

            public class ArticleTypeManager
            {
                public const string Name = "ArticleTypeManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllArticleType = "ViewGetAllArticleType";
                }

                #endregion
            }

            #endregion

            #region ArticleMediaManager

            public class ArticleMediaManager
            {
                public const string Name = "ArticleMediaManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                }

                #endregion
            }

            #endregion

            #region ArticleVersionManager

            public class ArticleVersionManager
            {
                public const string Name = "ArticleVersionManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string GetArticleVersionsByArticleId = "GetArticleVersionsByArticleId";
                }

                #endregion
            }

            #endregion

            #region CategoryManager

            public class CategoryManager
            {
                public const string Name = "CategoryManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllCategory = "ViewGetAllCategory";
                    public const string ViewGetAllMyCategory = "ViewGetAllMyCategory";
                    public const string GetCategoryByAlias = "GetCategoryByAlias";
                    public const string UpdateCategoryPIdAndOrder = "UpdateCategoryPIdAndOrder";
                    public const string OptimizeCategory = "OptimizeCategory";
                    public const string GetCategoryByUserId = "GetCategoryByUserId";
                }

                #endregion
            }

            #endregion

            #region CategoryPolicyManager

            public class CategoryPolicyManager
            {
                public const string Name = "CategoryPolicyManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string GetPolicyByUserIdAndCategoryAlias = "GetPolicyByUserIdAndCategoryAlias";
                    public const string GetPolicyByUserIdAndCategoryId = "GetPolicyByUserIdAndCategoryId";
                    public const string GetPolicyByGroup = "GetPolicyByGroup";
                    public const string SavePolicyByGroup = "SavePolicyByGroup";
                    public const string GetPolicyByCategory = "GetPolicyByCategory";
                    public const string SavePolicyByCategory = "SavePolicyByCategory";
                }

                #endregion
            }

            #endregion

            #region CollaboratorManager

            public class CollaboratorManager
            {
                public const string Name = "CollaboratorManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllCollaborator = "ViewGetAllCollaborator";
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region FormNames

        public class FormNames : ModuleConstants.FormNames
        {
            #region Nested type: CMS

            public class CMS
            {
                public const string PopupCategoryPolicy = "~/CMS/PopupCategoryPolicy.aspx";
                public const string PopupGroupPolicy = "~/CMS/PopupGroupPolicy.aspx";
                public const string CategoryDisplay = "~/CMS/CategoryDisplay.aspx";
                public const string CategoryEdit = "~/CMS/CategoryEdit.aspx";
                public const string CategoryView = "~/CMS/CategoryView.aspx";
                public const string CategoryTreeView = "~/CMS/CategoryTreeView.aspx";
                public const string ArticleContentTypeDisplay = "~/CMS/ArticleContentTypeDisplay.aspx";
                public const string ArticleContentTypeEdit = "~/CMS/ArticleContentTypeEdit.aspx";
                public const string ArticleContentTypeView = "~/CMS/ArticleContentTypeView.aspx";
                public const string ArticleTypeDisplay = "~/CMS/ArticleTypeDisplay.aspx";
                public const string ArticleTypeEdit = "~/CMS/ArticleTypeEdit.aspx";
                public const string ArticleTypeView = "~/CMS/ArticleTypeView.aspx";
                public const string CollaboratorDisplay = "~/CMS/CollaboratorDisplay.aspx";
                public const string CollaboratorEdit = "~/CMS/CollaboratorEdit.aspx";
                public const string CollaboratorView = "~/CMS/CollaboratorView.aspx";

                public class Articles
                {
                    public const string ArticleVersionDisplay = "~/CMS/Articles/ArticleVersionDisplay.aspx";
                    public const string ArticleDisplay = "~/CMS/Articles/ArticleDisplay.aspx";
                    public const string ArticleEdit = "~/CMS/Articles/ArticleEdit.aspx";
                    public const string ArticleView = "~/CMS/Articles/ArticleView.aspx";
                    public const string ArticlePreview = "~/CMS/Articles/ArticlePreview.aspx";
                    public const string ArticleViewByCategory = "~/CMS/Articles/ArticleViewByCategory.aspx";
                    public const string ArticleViewByManager = "~/CMS/Articles/ArticleViewByManager.aspx";
                    public const string PopupInsertNews = "~/CMS/Articles/PopupInsertNews.aspx";
                }

                public class Categories
                {
                    public const string ManageCategory = "~/CMS/Categories/ManageCategory.aspx";
                    public const string SelectCategory = "~/CMS/Categories/SelectCategory.aspx";
                }

                public class Comments
                {
                    public const string ArticleCommentDisplay = "~/CMS/Comments/ArticleCommentDisplay.aspx";
                    public const string ArticleCommentEdit = "~/CMS/Comments/ArticleCommentEdit.aspx";
                    public const string ArticleCommentView = "~/CMS/Comments/ArticleCommentView.aspx";
                    public const string ArticleCommentViewByCategory = "~/CMS/Comments/ArticleCommentViewByCategory.aspx";
                    public const string ArticleCommentViewByStatus = "~/CMS/Comments/ArticleCommentViewByStatus.aspx";
                    public const string ArticleCommentViewByArticleId = "~/CMS/Comments/ArticleCommentViewByArticleId.aspx";
                }

                public class Events
                {
                    public const string ArticleEventDisplay = "~/CMS/Events/ArticleEventDisplay.aspx";
                    public const string ArticleEventEdit = "~/CMS/Events/ArticleEventEdit.aspx";
                    public const string ArticleEventView = "~/CMS/Events/ArticleEventView.aspx";
                    public const string ArticleEventPreview = "~/CMS/Events/ArticleEventPreview.aspx";
                    public const string ArticleEventViewByCategory = "~/CMS/Events/ArticleEventViewByCategory.aspx";
                    public const string ArticleEventViewByManager = "~/CMS/Events/ArticleEventViewByManager.aspx";
                }
            }

            #endregion
        }

        #endregion

        #region ParameterName

        public class ParameterName : ModuleConstants.ParameterName
        {
            public const string CATEGORY_ID = "CId";
            public const string PUBLISH_FROM_DATE = "FDate";
            public const string PUBLISH_TO_DATE = "TDate";
            public const string ArticleId = "AId";
            public const string SYSTEM = "System";
        }

        #endregion

        #region Policies

        public abstract class Policies
        {
            public const string Delete = "Xóa";
            public const string Edit = "Sửa";
            public const string None = "Không quyền";
            public const string Special = "Có quyền";
            public const string View = "Xem";

            #region Nested type: ControlNames

            public class ControlNames
            {
                public const string CheckboxPolicy = "chkPolicy";
                public const string PanelPolicy = "pnlPolicy";
                public const string DropdownListPolicy = "ddlPolicy";
                public const string HiddenFieldCId = "hidCId";
                public const string HiddenFieldFId = "hidFId";
                public const string HiddenFieldGId = "hidGId";
                public const string HiddenFieldId = "hidId";
                public const string HiddenFieldMId = "hidMId";
            }

            #endregion
        }

        #endregion

        #region Session

        public class Session : ModuleConstants.Session
        {
            public const string USER_CATEGORY_POLICY = "USER_CATEGORY_POLICY";

            public class CMSData
            {
                public const string ArticleMedia = "ArticleMedia";
                public const string ArticleCategories = "ArticleCategories";
                public const string ArticleSelected = "ArticleSelected";
                public const string ArticleCategoryItem = "ArticleCategoryItem";
                public const string ArticleEventItem = "ArticleEventItem";
                public const string ArticleEventCategories = "ArticleEventCategories";
            }
        }

        #endregion

        #region ViewState

        public class ViewState : ModuleConstants.ViewState
        {
            public const string EditOption = "EditOption";
            public const string MyCategory = "MyCategory";
            public const string ItemNo = "ItemNo";
        }

        #endregion

        #region ConfigKey

        public class ConfigKey : ModuleConstants.ConfigKey
        {
            public const string ImageFileType = "ImageFileType";
            public const string FlashFileType = "FlashFileType";
            public const string AudioFileType = "AudioFileType";
            public const string VideoFileType = "VideoFileType";
            public const string LeadMaxWords = "LeadMaxWords";
            public const string LeadMaxChars = "LeadMaxChars";
        }

        #endregion

        #region MediaType

        public class MediaType
        {
            public const string Image = "Image";
            public const string Flash = "Flash";
            public const string Audio = "Audio";
            public const string Video = "Video";
        }

        #endregion

        #region Message

        public class Message : ModuleConstants.Message
        {
            public const string CategoryParentError = "CategoryParentError";
            public const string ArticleNameCantEmpty = "ArticleNameCantEmpty";
            public const string ArticleLeadCantEmpty = "ArticleLeadCantEmpty";
            public const string ArticleMsgContentCantEmpty = "ArticleMsgContentCantEmpty";
            public const string ArticlePublishDateCantEmpty = "ArticlePublishDateCantEmpty";
            public const string ArticleCategoriesCantEmpty = "ArticleCategoriesCantEmpty";
            public const string ArticleCategoriesMissPrimary = "ArticleCategoriesMissPrimary";
            public const string ArticleNoteCantEmpty = "ArticleNoteCantEmpty";
            public const string ArticleCommentNameCantEmpty = "ArticleCommentNameCantEmpty";
            public const string ArticleCommentEmailCantEmpty = "ArticleCommentEmailCantEmpty";
            public const string ArticleCommentNoteCantEmpty = "ArticleNoteCantEmpty";
            public const string ArticleCommentMsgContentCantEmpty = "ArticleCommentMsgContentCantEmpty";
            public const string ArticleEventNameCantEmpty = "ArticleEventNameCantEmpty";
            public const string ArticleEventLeadCantEmpty = "ArticleEventLeadCantEmpty";
            public const string ArticleEventMsgContentCantEmpty = "ArticleEventMsgContentCantEmpty";
            public const string ArticleEventPublishDateCantEmpty = "ArticleEventPublishDateCantEmpty";
            public const string ArticleEventCategoriesCantEmpty = "ArticleEventCategoriesCantEmpty";
            public const string ArticleEventNoteCantEmpty = "ArticleEventNoteCantEmpty";
            public const string LeadLimitedAlert = "LeadLimitedAlert";
            public const string UrlCantEmpty = "UrlCantEmpty";

            public class History
            {
                public const string ArticleCommentCreate = "ArticleCommentCreate";
                public const string ArticleCommentSave = "ArticleCommentSave";
                public const string ArticleCommentChange = "ArticleCommentChange";
                public const string ArticleCommentPublish = "ArticleCommentPublish";
                public const string ArticleCommentReject = "ArticleCommentReject";
                public const string ArticleCommentStop = "ArticleCommentStop";
                public const string ArticleCreate = "ArticleCreate";
                public const string ArticleSave = "ArticleSave";
                public const string ArticleChange = "ArticleChange";
                public const string ArticleSubmit = "ArticleSubmit";
                public const string ArticleEdit = "ArticleEdit";
                public const string ArticleCorrect = "ArticleCorrect";
                public const string ArticlePublish = "ArticlePublish";
                public const string ArticleReject = "ArticleReject";
                public const string ArticleStop = "ArticleStop";
                public const string ArticleCategoryChangeOrder = "ArticleCategoryChangeOrder";
                public const string ArticleCategoryChangePrimary = "ArticleCategoryChangePrimary";
                public const string ArticleCategoryAddnew = "ArticleCategoryAddnew";
                public const string ArticleCategoryDelete = "ArticleCategoryDelete";
                public const string ArticleMediaChange = "ArticleMediaChange";
                public const string ArticleMediaAddnew = "ArticleMediaAddnew";
                public const string ArticleMediaDelete = "ArticleMediaDelete";
                public const string ArticleEventCreate = "ArticleEventCreate";
                public const string ArticleEventSave = "ArticleEventSave";
                public const string ArticleEventChange = "ArticleEventChange";
                public const string ArticleEventSubmit = "ArticleEventSubmit";
                public const string ArticleEventEdit = "ArticleEventEdit";
                public const string ArticleEventCorrect = "ArticleEventCorrect";
                public const string ArticleEventPublish = "ArticleEventPublish";
                public const string ArticleEventReject = "ArticleEventReject";
                public const string ArticleEventStop = "ArticleEventStop";
                public const string ArticleEventCategoryChangeOrder = "ArticleEventCategoryChangeOrder";
                public const string ArticleEventCategoryChangePrimary = "ArticleEventCategoryChangePrimary";
                public const string ArticleEventCategoryAddnew = "ArticleEventCategoryAddnew";
                public const string ArticleEventCategoryDelete = "ArticleEventCategoryDelete";
                public const string ArticleEventItemChange = "ArticleEventItemChange";
                public const string ArticleEventItemAddnew = "ArticleEventItemAddnew";
                public const string ArticleEventItemDelete = "ArticleEventItemDelete";
            }
        }

        #endregion

        #region ArticleStatus

        public class ArticleStatus
        {
            public const string Crawling = "Lấy tự động";
            public const string Draft = "Bản nháp";
            public const string Submited = "Chờ biên tập";
            public const string Editted = "Chờ soát lỗi";
            public const string Corrected = "Chờ xuất bản";
            public const string Published = "Đã xuất bản";
            public const string Rejected = "Trả lại";
            public const string Stopped = "Hạ xuống";
        }

        #endregion

        #region ArticleEventStatus

        public class ArticleEventStatus : ArticleStatus
        {
        }

        #endregion

        #region ArticleCommand

        public class ArticleCommand
        {
            public const string Submitted = "Submitted";
            public const string Editted = "Editted";
            public const string Corrected = "Corrected";
            public const string Published = "Published";
            public const string PublishedAndRoyalty = "PublishedAndRoyalty";
            public const string Rejected = "Rejected";
            public const string Stopped = "Stopped";
        }

        #endregion

        #region ArticleEventCommand

        public class ArticleEventCommand : ArticleCommand
        {
        }

        #endregion

        #region Paging

        public class Paging
        {
            public class Direction : Constants.Paging.Direction
            {
                public const string ArticleId = "ArticleId";
                public const string CategoriesId = "CategoriesId";
                public const string PartitionId = "PartitionId";
                public const string PublishFromDate = "PublishFromDate";
                public const string PublishToDate = "PublishToDate";
            }
        }

        #endregion

        #region CommandNames

        public class CommandNames : ModuleConstants.CommandNames
        {
            public const string Insert = "Insert";
            public const string Close = "Close";
        }

        #endregion
    }
}