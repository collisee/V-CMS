using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.AddOn.Advertisement.DBAccess
{
    public class AdvertisementLayoutCategoryDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [AdvertisementLayoutCategory]" +
                                  "([LayoutId],[CategoryId],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@LayoutId, @CategoryId, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@LayoutId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("AdvertisementLayoutCategoryDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [AdvertisementLayoutCategory] Set" +
                                  " [LayoutId] = @LayoutId, [CategoryId] = @CategoryId, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@LayoutId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("AdvertisementLayoutCategoryDAO::Update::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [AdvertisementLayoutCategory] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
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
                throw new Exception("AdvertisementLayoutCategoryDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString =
                @"Select * From [AdvertisementLayoutCategory] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
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
                throw new Exception("AdvertisementLayoutCategoryDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable SelectCategoriesByLayoutId(DataRow dataRow)
        {
            return SelectCategoriesByLayoutId(null, dataRow);
        }

        public static DataTable SelectCategoriesByLayoutId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT [AdvertisementLayoutCategory].* " +
                                  " , [Category].[Name] [CategoryName] " +
                                  " , [Category].[Alias] [CategoryAlias] " +
                                  " , '' [SaveStatus] " +
                                  " FROM [AdvertisementLayoutCategory] " +
                                  " LEFT JOIN [Category] " +
                                  " ON [AdvertisementLayoutCategory].[CategoryId] = [Category].[Id] " +
                                  " WHERE [AdvertisementLayoutCategory].[LayoutId] = @Id " +
                                  " AND (ISNULL([AdvertisementLayoutCategory].flag, '') = '')" +
                                  " AND (ISNULL([Category].flag, '') = '')" +
                                  " ORDER BY [Category].[Name]";
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
                throw new Exception("AdvertisementLayoutCategoryDAO::SelectCategoriesByLayoutId::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [AdvertisementLayoutCategory] Where (ISNULL(flag, '') = '')";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("AdvertisementLayoutCategoryDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("AdvertisementLayoutCategory");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("LayoutId", typeof(int));
            table.Columns.Add("CategoryId", typeof(int));
            table.Columns.Add("Created_At", typeof(DateTime));
            table.Columns.Add("Created_By", typeof(int));
            table.Columns.Add("Last_Modified_At", typeof(DateTime));
            table.Columns.Add("Last_Modified_By", typeof(int));
            table.Columns.Add("Flag");
            table.Columns.Add("SaveStatus");
            table.Columns.Add("CategoryName");
            table.Columns.Add("CategoryAlias");

            return table;
        }

        public static DataRow GetTemplateRow()
        {
            return GetTemplateTable().NewRow();
        }

        #endregion
    }
}