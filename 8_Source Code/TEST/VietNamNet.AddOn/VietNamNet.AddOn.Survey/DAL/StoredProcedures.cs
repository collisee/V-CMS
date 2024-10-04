using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;
namespace VietNamNet.AddOn.SurveyModule.DAL
{
    public partial class SPs
    {

        /// <summary>
        /// Creates an object wrapper for the ArticleListBySurvey Procedure
        /// </summary>
        public static StoredProcedure ArticleListBySurvey(int? SurveyId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ArticleListBySurvey", DataService.GetInstance("VietNamNet_Surveys"), "dbo");

            sp.Command.AddParameter("@SurveyId", SurveyId, DbType.Int32, 0, 10);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the CatListBySurvey Procedure
        /// </summary>
        public static StoredProcedure CatListBySurvey(int? SurveyId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CatListBySurvey", DataService.GetInstance("VietNamNet_Surveys"), "dbo");

            sp.Command.AddParameter("@SurveyId", SurveyId, DbType.Int32, 0, 10);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the Survey_ListByArticle Procedure
        /// </summary>
        public static StoredProcedure SurveyListByArticle(int? ArticleId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Survey_ListByArticle", DataService.GetInstance("VietNamNet_Surveys"), "dbo");

            sp.Command.AddParameter("@ArticleId", ArticleId, DbType.Int32, 0, 10);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the Survey_ListByCat Procedure
        /// </summary>
        public static StoredProcedure SurveyListByCat(int? CatId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Survey_ListByCat", DataService.GetInstance("VietNamNet_Surveys"), "dbo");

            sp.Command.AddParameter("@CatId", CatId, DbType.Int32, 0, 10);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the SurveyOptions_ListBySurvey Procedure
        /// </summary>
        public static StoredProcedure SurveyOptionsListBySurvey(int? SurveyId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SurveyOptions_ListBySurvey", DataService.GetInstance("VietNamNet_Surveys"), "dbo");

            sp.Command.AddParameter("@SurveyId", SurveyId, DbType.Int32, 0, 10);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the SurveyPublishListBySurvey Procedure
        /// </summary>
        public static StoredProcedure SurveyPublishListBySurvey(int? SurveyId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SurveyPublishListBySurvey", DataService.GetInstance("VietNamNet_Surveys"), "dbo");

            sp.Command.AddParameter("@SurveyId", SurveyId, DbType.Int32, 0, 10);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the SurveyResults_ListBySurvey Procedure
        /// </summary>
        public static StoredProcedure SurveyResultsListBySurvey(int? SurveyId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SurveyResults_ListBySurvey", DataService.GetInstance("VietNamNet_Surveys"), "dbo");

            sp.Command.AddParameter("@SurveyId", SurveyId, DbType.Int32, 0, 10);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the SurveyResultsGet Procedure
        /// </summary>
        public static StoredProcedure SurveyResultsGet(int? SurveyId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SurveyResultsGet", DataService.GetInstance("VietNamNet_Surveys"), "dbo");

            sp.Command.AddParameter("@SurveyId", SurveyId, DbType.Int32, 0, 10);

            return sp;
        }

    }

}
