using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.Framework.Module
{
    public class CommonDAO : BaseDAO
    {
        #region GenerateSearchingQuery

        public static string SearchingQuery(DataTable dtSearch, string[] strSearchColumns, string strCondition, string strTable)
        {
            string strSearchString = "";
            string strConn = strCondition;

            if (Convert.ToBoolean(dtSearch.Rows[0][Constants.Paging.Direction.IsSearch]))
            {
                string KeyWords = Convert.ToString(dtSearch.Rows[0][Constants.Paging.Direction.KeyWords]);
                if (!string.Empty.Equals(KeyWords))
                {
                    strSearchString = strCondition + "( ";
                    int i = 1;

                    foreach (string column in strSearchColumns)
                    {
                        if (i == strSearchColumns.Length)
                        {
                            strSearchString += " ([" + strTable + "].[" + column + "] LIKE @KeyWords)";
                        }
                        else
                        {
                            strSearchString += " ([" + strTable + "].[" + column + "] LIKE @KeyWords ) OR ";
                        }
                        i++;
                    }
                    strSearchString += ")";
                    strConn = Constants.ConnectorString.AND_STRING;
                }
            }
            strSearchString += " " + strConn;
            strSearchString += " (ISNULL([" + strTable + "].[flag], '') = '')";

            return strSearchString;
        }

        #endregion

        #region ExecuteManualPagingQuery

        public static DataSet ExecuteManualPagingQuery(SqlTransaction sqlTransaction, string strQueryCountRecord,
                                                       string strQueryGetRecord, SqlParameter[] paramArray)
        {
            try
            {
                DataSet ds = new DataSet();

                //Execute ManualPagingQuery to get the specific records
                ds = ExecuteQuery(sqlTransaction, strQueryGetRecord, paramArray);

                //Get count of returned records
                if (strQueryCountRecord != null)
                {
                    DataTable dtpageCount = new DataTable(Constants.Paging.Direction.PagingTableName);
                    dtpageCount.Columns.Add(Constants.Paging.Direction.PageCount, typeof (int));
                    ds.Tables.Add(dtpageCount);

                    DataRow drpageCount = dtpageCount.NewRow();
                    drpageCount[Constants.Paging.Direction.PageCount] =
                        ExecuteQuery(sqlTransaction, strQueryCountRecord, paramArray).Tables[0].Rows[0][0];
                    dtpageCount.Rows.Add(drpageCount);
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("CommonDAO::ExecuteManualPagingQuery::Error", ex);
            }
        }

        /// <summary>
        /// Get Data from SQL Store Procedure
        /// </summary>
        /// <param name="sqlTransaction"></param>
        /// <param name="strProcedureCountRecord"></param>
        /// <param name="strProcedureGetRecord"></param>
        /// <param name="paramArray"></param>
        /// <returns></returns>
        public static DataSet ExecuteManualPagingProcedure(SqlTransaction sqlTransaction, string strProcedureCountRecord,
                                                    string strProcedureGetRecord, SqlParameter[] paramArray)
        {
            try
            {
                DataSet ds = new DataSet();

                //Execute ManualPagingQuery to get the specific records
                ds = ExecuteProcedure(sqlTransaction, strProcedureGetRecord, paramArray);

                //Get count of returned records
                if (strProcedureCountRecord != null)
                {
                    DataTable dtpageCount = new DataTable(Constants.Paging.Direction.PagingTableName);
                    dtpageCount.Columns.Add(Constants.Paging.Direction.PageCount, typeof(int));
                    ds.Tables.Add(dtpageCount);

                    DataRow drpageCount = dtpageCount.NewRow();
                    drpageCount[Constants.Paging.Direction.PageCount] =
                        ExecuteProcedure(sqlTransaction, strProcedureCountRecord, paramArray).Tables[0].Rows[0][0];
                    dtpageCount.Rows.Add(drpageCount);
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("CommonDAO::ExecuteManualPagingProcedure::Error", ex);
            }
        }
        #endregion
    }
}