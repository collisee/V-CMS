 

using VietNamNet.Framework.Module;

namespace VietNamNet.Websites.Core.Common.Survey
{ 
        public class SurveyConstants
        {
            public class Services
            {
                public class SurveyManager
                {
                    public const string Name = "SurveyManager";

                    public class Actions
                    {
                        public const string ListByCat = "listByCat";
                        public const string ListByArticle = "listByArticle";
                        public const string GetById = "getById";

                        public const string ResultsGetBySurvey = "resultsGetBySurvey";
                    }
                }
                 
            }

            public class Param
            {
                public const string SurveyId = "surveyid";
                public const string ArticleId = "articleid";
                public const string CategoryAlias = "categorysalias"; 
            }
          

        }
        public class SurveyPublishConstants
        {
            public const string SurveyPublishId = "surveypublishid";

        } 
}