using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Union.Common
{
    public class UnionConstants
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
            #region UnionObject

            public class UnionObject
            {
                public const string Name = "UnionObject";
                public static string[] SearchColumns = {"Name", "Title"};

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    //ArticleCategory
                    public const string ArticleCategoryOrd = "ArticleCategoryOrd";
                    //Category
                    //Article
                    public const string ArticleContentTypeId = "ArticleContentTypeId";
                    public const string ArticleTypeId = "ArticleTypeId";
                    public const string Author = "Author";
                    public const string AuthorInfo = "AuthorInfo";
                    public const string CategoryAlias = "CategoryAlias";
                    public const string CategoryDisplayName = "CategoryDisplayName";
                    public const string CategoryId = "CategoryId";
                    public const string CategoryName = "CategoryName";
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
        }

        #endregion

        #region Nested type: ParameterName

        public class ParameterName : ModuleConstants.ParameterName
        {
            public const string CATEGORY_ALIAS = "CateAlias";
            public const string MediaType = "MediaType";
        }

        #endregion

        #region Nested type: Services

        public class Services : BaseServices
        {
            #region UnionManager

            public class UnionManager
            {
                public const string Name = "UnionManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string GetArticle = "GetArticle";
                    public const string GetArticleComment = "GetArticleComment";
                    public const string GetArticleMedia = "GetArticleMedia";
                    public const string GetCategoryArticleNumber = "GetCategoryArticleNumber";
                    public const string GetCategoryArticles = "GetCategoryArticles";
                    public const string GetCategoryArticlesMore = "GetCategoryArticlesMore";
                    public const string GetCategoryByAlias = "GetCategoryByAlias";
                    public const string GetTopMedia = "GetTopMedia";
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
            public const string CategoryAlias = "CategoryAlias";
            public const string PageNumber = "PageNumber";
            public const string RSSUrl = "RSSUrl";
        }

        #endregion
    }
}