using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.Websites.Core.DBAccess
{
    public class SurveyDAO : BaseDAO
    {

        public static DataTable ListByCat(DataRow dataRow)
        {
            return ListByCat(null, dataRow);
        }
        public static DataTable ListByCat(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Survey_ListByCat";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@CategoryAlias", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                    };
                SetParameterValues(paramArray, dataRow);
                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("SurveyDAO::ListByCat::Error", ex);
            }
        }

        public static DataTable ListByArticle(DataRow dataRow)
        {
            return ListByArticle(null, dataRow);
        }
        public static DataTable ListByArticle(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Survey_ListByArticle";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input),
                    };
                SetParameterValues(paramArray, dataRow);
                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("SurveyDAO::ListByArticle::Error", ex);
            }
        }


        public static DataTable GetById(DataRow dataRow)
        {
            return GetById(null, dataRow);
        }
        public static DataTable GetById(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string qry = "select  surveyId, question, optionType from Surveys where SurveyId=@SurveyId";
            //string procedureName = "Survey_GetById";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@SurveyId", SqlDbType.Int, 0, ParameterDirection.Input),
                    };
                SetParameterValues(paramArray, dataRow);
                //return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
                return ExecuteQuery(sqlTransaction, qry, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("SurveyDAO::Survey_GetById::Error", ex);
            }
        }


        public static DataTable ResultsGetBySurvey(DataRow dataRow)
        {
            return ResultsGetBySurvey(null, dataRow);
        }
        public static DataTable ResultsGetBySurvey(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "SurveyResultsGet";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@SurveyId", SqlDbType.Int, 0, ParameterDirection.Input),
                    };
                SetParameterValues(paramArray, dataRow);
                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("SurveyDAO::ResultsGetBySurvey::Error", ex);
            }
        }


    }
}