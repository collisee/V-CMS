using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.CMS.DBAccess
{
    public class ArticleVersionDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [ArticleVersion]" +
                                  "([ArticleId],[VersionId],[Status],[ArticleTypeId],[ArticleContentTypeId],[Name],[Title],[SubTitle1],[SubTitle2],[SubTitle3],[SubTitle4],[SubTitle5],[SubTitle6],[ImageLink],[ImageLink1],[ImageLink2],[ImageLink3],[ImageLink4],[ImageLink5],[Lead],[Detail],[PublishDate],[Author],[AuthorInfo],[IsMember]," +
                                  "[TotalView],[History],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@ArticleId, @VersionId, @Status, @ArticleTypeId, @ArticleContentTypeId, @Name, @Title, @SubTitle1, @SubTitle2, @SubTitle3, @SubTitle4, @SubTitle5, @SubTitle6, @ImageLink, @ImageLink1, @ImageLink2, @ImageLink3, @ImageLink4, @ImageLink5, @Lead, @Detail, @PublishDate, @Author, @AuthorInfo, @IsMember, " +
                                  "@TotalView, @History, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@VersionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleTypeId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleContentTypeId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Title", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle1", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle2", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle3", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle4", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle5", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle6", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink1", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink2", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink3", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink4", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink5", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Lead", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@PublishDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Author", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@AuthorInfo", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@IsMember", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@TotalView", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("ArticleVersionDAO::Insert::Error", ex);
            }
        }

        public static void InsertNewVersion(DataRow dataRow)
        {
            InsertNewVersion(null, dataRow);
        }

        public static void InsertNewVersion(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "INSERT INTO [ArticleVersion]" +
                                  "([ArticleId],[VersionId],[Status],[ArticleTypeId],[ArticleContentTypeId],[Name],[Title],[SubTitle1],[SubTitle2],[SubTitle3],[SubTitle4],[SubTitle5],[SubTitle6],[ImageLink],[ImageLink1],[ImageLink2],[ImageLink3],[ImageLink4],[ImageLink5],[Lead],[Detail],[PublishDate],[Author],[AuthorInfo],[IsMember]," +
                                  "[TotalView],[History],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  //" VALUES "+
                                  "(SELECT [Id],[VersionId],[Status],[ArticleTypeId],[ArticleContentTypeId],[Name],[Title],[SubTitle1],[SubTitle2],[SubTitle3],[SubTitle4],[SubTitle5],[SubTitle6],[ImageLink],[ImageLink1],[ImageLink2],[ImageLink3],[ImageLink4],[ImageLink5],[Lead],[Detail],[PublishDate],[Author],[AuthorInfo],[IsMember]," +
                                  "[TotalView],[History],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag] FROM [Article] WHERE [Id] = @Id) ";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, insertString, paramArray);
                SetOutputValues(paramArray, dataRow);
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleVersionDAO::InsertNewVersion::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [ArticleVersion] Set" +
                                  " [ArticleId] = @ArticleId, [VersionId] = @VersionId, [Status] = @Status, [ArticleTypeId] = @ArticleTypeId, [ArticleContentTypeId] = @ArticleContentTypeId, [Name] = @Name, [Title] = @Title, [SubTitle1] = @SubTitle1, [SubTitle2] = @SubTitle2, [SubTitle3] = @SubTitle3, [SubTitle4] = @SubTitle4, [SubTitle5] = @SubTitle5, [SubTitle6] = @SubTitle6, [ImageLink] = @ImageLink, [ImageLink1] = @ImageLink1, [ImageLink2] = @ImageLink2, [ImageLink3] = @ImageLink3, [ImageLink4] = @ImageLink4, [ImageLink5] = @ImageLink5, [Lead] = @Lead, [Detail] = @Detail, [PublishDate] = @PublishDate, [Author] = @Author, [AuthorInfo] = @AuthorInfo, " +
                                  "[IsMember] = @IsMember, [TotalView] = @TotalView, [History] = @History, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@VersionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleTypeId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleContentTypeId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Title", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle1", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle2", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle3", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle4", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle5", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle6", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink1", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink2", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink3", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink4", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink5", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Lead", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@PublishDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Author", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@AuthorInfo", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@IsMember", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@TotalView", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("ArticleVersionDAO::Update::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [ArticleVersion] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, deleteString, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleVersionDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [ArticleVersion] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
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
                throw new Exception("ArticleVersionDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable GetArticleVersionsByArticleId(DataRow dataRow)
        {
            return GetArticleVersionsByArticleId(null, dataRow);
        }

        public static DataTable GetArticleVersionsByArticleId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT * FROM [ArticleVersion] WHERE [ArticleId] = @ArticleId AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleVersionDAO::GetArticleVersionsByArticleId::Error", ex);
            }
        }

        public static DataTable SelectVersionsByArticleId(DataRow dataRow)
        {
            return SelectVersionsByArticleId(null, dataRow);
        }

        public static DataTable SelectVersionsByArticleId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT [ArticleVersion].* " +
                                  " , [User].[LoginName] [Last_Modified_By_LoginName] " +
                                  " , [User].[FullName] [Last_Modified_By_FullName] " +
                                  " FROM [ArticleVersion] " +
                                  " LEFT JOIN [User] " +
                                  " ON [ArticleVersion].[Last_Modified_By] = [User].[Id] " +
                                  " WHERE [ArticleId] = @Id " +
                                  " AND (ISNULL([ArticleVersion].flag, '') = '')" +
                                  " ORDER BY [VersionId]";
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
                throw new Exception("ArticleVersionDAO::SelectVersionByArticleId::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [ArticleVersion] Where (ISNULL(flag, '') = '')";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleVersionDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("ArticleVersion");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("ArticleId", typeof(int));
            table.Columns.Add("VersionId", typeof(int));
            table.Columns.Add("Status");
            table.Columns.Add("ArticleTypeId", typeof(int));
            table.Columns.Add("ArticleContentTypeId", typeof(int));
            table.Columns.Add("Name");
            table.Columns.Add("Title");
            table.Columns.Add("SubTitle1");
            table.Columns.Add("SubTitle2");
            table.Columns.Add("SubTitle3");
            table.Columns.Add("SubTitle4");
            table.Columns.Add("SubTitle5");
            table.Columns.Add("SubTitle6");
            table.Columns.Add("ImageLink");
            table.Columns.Add("ImageLink1");
            table.Columns.Add("ImageLink2");
            table.Columns.Add("ImageLink3");
            table.Columns.Add("ImageLink4");
            table.Columns.Add("ImageLink5");
            table.Columns.Add("Lead");
            table.Columns.Add("Detail");
            table.Columns.Add("PublishDate");
            table.Columns.Add("Author");
            table.Columns.Add("AuthorInfo");
            table.Columns.Add("IsMember");
            table.Columns.Add("TotalView");
            table.Columns.Add("History");
            table.Columns.Add("Created_At", typeof(DateTime));
            table.Columns.Add("Created_By", typeof(int));
            table.Columns.Add("Last_Modified_At", typeof(DateTime));
            table.Columns.Add("Last_Modified_By", typeof(int));
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