using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Advertisement.DBAccess
{
    public class AdvertisementItemDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [AdvertisementItem]" +
                                  "([Name],[TypeId],[Link],[FileLink1],[FileLink2],[FileJS],[CodeJS],[StartTime],[EndTime],[Detail],[ExWidth],[ExHeight],[ExMode],[History],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@Name, @TypeId, @Link, @FileLink1, @FileLink2, @FileJS, @CodeJS, @StartTime, @EndTime, @Detail, @ExWidth, @ExHeight, @ExMode, @History, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@TypeId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Link", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@FileLink1", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@FileLink2", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@FileJS", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@CodeJS", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@ExWidth", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ExHeight", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ExMode", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@History", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@Created_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Created_By", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Flag", SqlDbType.Char, 1, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, insertString, paramArray);
                SetOutputValues(paramArray, dataRow);
            }
            catch (Exception ex)
            {
                throw new Exception("AdvertisementItemDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [AdvertisementItem] Set" +
                                  " [Name] = @Name, [TypeId] = @TypeId, [Link] = @Link, [FileLink1] = @FileLink1, [FileLink2] = @FileLink2, [FileJS] = @FileJS, [CodeJS] = @CodeJS, [StartTime] = @StartTime, [EndTime] = @EndTime, [Detail] = @Detail, [ExWidth] = @ExWidth, [ExHeight] = @ExHeight, [ExMode] = @ExMode, [History] = @History, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@TypeId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Link", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@FileLink1", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@FileLink2", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@FileJS", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@CodeJS", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@ExWidth", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ExHeight", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ExMode", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@History", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@Created_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Created_By", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Flag", SqlDbType.Char, 1, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, updateString, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("AdvertisementItemDAO::Update::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [AdvertisementItem] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, deleteString, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("AdvertisementItemDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [AdvertisementItem] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("AdvertisementItemDAO::SelectOne::Error", ex);
            }
        }

        #region ViewGetAllAdvertisementItem

        public static DataSet ViewGetAllAdvertisementItem(DataSet dataSet)
        {
            return ViewGetAllAdvertisementItem(null, dataSet);
        }

        public static DataSet ViewGetAllAdvertisementItem(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [AdvertisementItem] "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          AdvertisementConstants.Entities.AdvertisementItem.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          AdvertisementConstants.Entities.AdvertisementItem.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT [AdvertisementItem].*, row_number() over(order by [AdvertisementItem].[Name]) RowNum "
                                         + " , [AdvertisementType].[Name] [TypeName] "
                                         + " FROM [AdvertisementItem] "
                                         + " LEFT JOIN [AdvertisementType] "
                                         + " ON [AdvertisementItem].[TypeId] = [AdvertisementType].[Id] "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          AdvertisementConstants.Entities.AdvertisementItem.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          AdvertisementConstants.Entities.AdvertisementItem.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                };
            paramArray[0].Value = "%" +
                                  Convert.ToString(
                                      dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                                          Constants.Paging.Direction.KeyWords]).Replace("\"", "\"\"") + "%";

            //Get PageIndex and PageSize
            int indexOfPage =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.PagingTableName].Rows[0][
                        Constants.Paging.Direction.PageIndex]);
            int pagesize =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.PagingTableName].Rows[0][
                        Constants.Paging.Direction.PageSize]);
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [AdvertisementItem] Where (ISNULL(flag, '') = '') ORDER BY [Name]";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("AdvertisementItemDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("AdvertisementItem");
            table.Columns.Add("Id");
            table.Columns.Add("Name");
            table.Columns.Add("TypeId");
            table.Columns.Add("Link");
            table.Columns.Add("FileLink1");
            table.Columns.Add("FileLink2");
            table.Columns.Add("FileJS");
            table.Columns.Add("CodeJS");
            table.Columns.Add("StartTime");
            table.Columns.Add("EndTime");
            table.Columns.Add("Detail");
            table.Columns.Add("ExWidth");
            table.Columns.Add("ExHeight");
            table.Columns.Add("ExMode");
            table.Columns.Add("History");
            table.Columns.Add("Created_At");
            table.Columns.Add("Created_By");
            table.Columns.Add("Last_Modified_At");
            table.Columns.Add("Last_Modified_By");
            table.Columns.Add("Flag");

            return table;
        }

        public static DataRow GetTemplateRow()
        {
            return GetTemplateTable().NewRow();
        }

        #endregion
    }
}