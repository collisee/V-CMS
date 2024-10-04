using VietNamNet.Framework.Module;

namespace VietNamNet.Layout.Mobile.Common
{
    public class VNN4MobileConstants
    {
        public class Entity : BaseEntities
        {
            #region VNN4MobileObject

            public class VNN4MobileObject
            {
                public const string Name = "VNN4MobileObject";
                public static string[] SearchColumns = { "Name", "Title" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    //ArticleCategory
                    public const string ArticleCategoryOrd = "ArticleCategoryOrd";
                    //Category
                    public const string CategoryAlias = "CategoryAlias";
                    public const string CategoryDisplayName = "CategoryDisplayName";
                    public const string CategoryName = "CategoryName";
                    public const string PartitionId = "PartitionId";
                    public const string CategoryId = "CategoryId";
                    //Article
                    public const string ArticleContentTypeId = "ArticleContentTypeId";
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
        }

        public class Services : BaseServices
        {

            #region VNN4MobileManager

            public class VNN4MobileManager
            {
                public const string Name = "VNN4MobileManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string GetCategoryByAlias = "GetCategoryByAlias";
                    public const string GetCategoryArticleNumber = "GetCategoryArticleNumber";
                    public const string GetCategoryArticles = "GetCategoryArticles";
                    public const string GetCategoryArticlesMore = "GetCategoryArticlesMore";
                    public const string GetArticle = "GetArticle";
                    public const string GetTopArticle = "GetTopArticle";
                }

                #endregion
            }

            #endregion
        }

        public class ViewState
        {
            public const string CategoryAlias = "CategoryAlias";
            public const string PageNumber = "PageNumber";
            public const string ArticleId = "ArticleId";
            public const string ArticleName = "ArticleName";
            public const string FirstIndexRecord = "FirstIndexRecord";
            public const string LastIndexRecord = "LastIndexRecord";
        }

        public class ParameterName
        {
            public const string DOC_ID = "DocId";
            public const string PAGE = "Page";
            public const string CATEGORY_ALIAS = "CateAlias";
        }

        public class ConfigKey : ModuleConstants.ConfigKey
        {
            public const string MobileDomain = "MobileDomain";
            public const string MobilePort = "MobilePort";
            public const string WebDomain = "WebDomain";
            public const string WebPort = "WebPort";
            public const string ValidImageWidth = "ValidImageWidth";
            public const string ValidImageheight = "ValidImageheight";
        }
    }
}