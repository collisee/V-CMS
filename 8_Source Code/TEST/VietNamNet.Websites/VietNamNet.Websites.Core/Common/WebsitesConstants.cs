using VietNamNet.Framework.Module;

namespace VietNamNet.Websites.Core.Common
{
    public class WebsitesConstants
    {
        #region Nested type: ConfigKey

        public class ConfigKey : ModuleConstants.ConfigKey
        {
            public const string MobileDomain = "MobileDomain";
            public const string MobilePort = "MobilePort";
        }

        #endregion

        #region Nested type: Entity

        public class Entity : BaseEntities
        {
            #region WebsitesObject

            public class WebsitesObject
            {
                public const string Name = "WebsitesObject";
                public static string[] SearchColumns = {"Name", "Title"};

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Alias = "Alias";
                    public const string ArticleCategoryOrd = "ArticleCategoryOrd";
                    public const string ArticleContentTypeId = "ArticleContentTypeId";
                    public const string ArticleTypeId = "ArticleTypeId";
                    public const string Author = "Author";
                    public const string AuthorInfo = "AuthorInfo";
                    public const string CategoryAlias = "CategoryAlias";
                    public const string CategoryDisplayName = "CategoryDisplayName";
                    public const string CategoryUrl = "CategoryUrl";
                    public const string CategoryId = "CategoryId";
                    public const string CategoryName = "CategoryName";
                    public const string Detail = "Detail";
                    public const string DisplayName = "DisplayName";
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
                    public const string PartitionId = "PartitionId";
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

            #region Nested type: AdvertisementObject

            public class AdvertisementObject
            {
                public const string Name = "AdvertisementObject";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string CategoryAlias = "CategoryAlias";
                    public const string CategoryId = "CategoryId";
                    public const string LayoutId = "LayoutId";
                    public const string ZoneId = "ZoneId";
                    public const string BlockId = "BlockId";
                    public const string ItemId = "ItemId";
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region Nested type: ParameterName

        public class ParameterName : ModuleConstants.ParameterName
        {
            public const string CATEGORY_ALIAS = "CateAlias";
            public const string MediaType = "MediaType";
            public const string Items = "Items";
        
}

        #endregion

        #region Nested type: Services

        public class Services : BaseServices
        {
            #region WebsitesManager

            public class WebsitesManager
            {
                public const string Name = "WebsitesManager";

              public const string Procedure_Prefix = "Layout_";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string GetArticle = "GetArticle";
                    public const string GetArticleComment = "GetArticleComment";
                    public const string GetArticleMedia = "GetArticleMedia";
                    public const string GetArticleVNNId = "GetArticleVNNId";
                    public const string GetCategoryArticleNumber = "GetCategoryArticleNumber";
                    public const string GetCategoryArticles = "GetCategoryArticles";
                    public const string GetCategoryArticlesMore = "GetCategoryArticlesMore";
                    public const string GetCategoryByAlias = "GetCategoryByAlias";
                    public const string GetMostReadArticles = "GetMostReadArticles";
                    public const string GetPrimaryCategory = "GetPrimaryCategory";
                    public const string GetSearchArticles = "GetSearchArticles";
                    public const string GetSubCategory = "GetSubCategory";
                    public const string GetTopArticles = "GetTopArticles";
                    public const string GetTopMedia = "GetTopMedia";
                    public const string SetTotalView = "SetTotalView";

                    public const string SearchArticleByKeyword = "SearchArticle";
                    public const string SearchArticleByKeywordCount = "SearchArticleByKeywordCount";  
                }

                #endregion
            }

            #endregion

            #region AdvertisementManager

            public class AdvertisementManager
            {
                public const string Name = "AdvertisementManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string GetLayoutByCategoryId = "GetLayoutByCategoryId";
                    public const string GetZonesByLayoutId = "GetZonesByLayoutId";
                    public const string GetBlocksByZoneId = "GetBlocksByZoneId";
                    public const string GetItemsByBlockId = "GetItemsByBlockId";
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region EmailTemplates

        public abstract class EmailTemplates
        {
            public const string SendEmailArticle = @"~\Templates\TemplateSendEmailArticle.xslt";
             
        }

        #endregion

        #region Nested type: AJAX Services

        public class AJAXServices
        {
            #region GetAdvertisement

            public class GetAdvertisement
            {
                public const string Name = "GetAdvertisement";

                #region Nested type: Actions

                public class Actions
                {
                    public const string getLayout = "getLayout";
                    public const string getZones  = "getZones";
                    public const string getBlocks = "getBlocks";
                    public const string getItems = "getItems";
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region Nested type: ViewState

        public class ViewState
        {
            public const string ArticleId = "ArticleId";
            public const string ArticleName = "ArticleName";
            public const string CategoryAlias = "CategoryAlias";
            public const string FirstIndexRecord = "FirstIndexRecord";
            public const string ImageLink = "ImageLink";
            public const string LastIndexRecord = "LastIndexRecord";
            public const string PageNumber = "PageNumber";
            public const string RSSUrl = "RSSUrl";
            public const string SearchKeyword = "SearchKeyword";
            public const string SubCategoryLink = "SubCategoryLink";
            public const string SubCategoryName = "SubCategoryName";
        }

        #endregion
    }
}