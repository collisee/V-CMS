using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System.DBAccess
{
    public class UserDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [User]" +
                                  "([Status],[LoginName],[Email],[Avatar],[Birthday],[Sex],[FullName],[Password],[Address],[Phone],[Mobile],[Yahoo],[Skype],[Facebook],[Detail],[Skin],[LastLogin],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@Status, @LoginName, @Email, @Avatar, @Birthday, @Sex, @FullName, @Password, @Address, @Phone, @Mobile, @Yahoo, @Skype, @Facebook, @Detail, @Skin, @LastLogin, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@LoginName", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Email", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Avatar", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Birthday", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Sex", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                        CreateSqlPrameter("@FullName", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Password", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Address", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Phone", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Mobile", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Yahoo", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Skype", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Facebook", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@Skin", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@LastLogin", SqlDbType.DateTime, 0, ParameterDirection.Input),
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
                throw new Exception("UserDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [User] Set" +
                                  " [Status] = @Status, [LoginName] = @LoginName, [Email] = @Email, [Avatar] = @Avatar, [Birthday] = @Birthday, [Sex] = @Sex, [FullName] = @FullName, [Password] = @Password, [Address] = @Address, [Phone] = @Phone, [Mobile] = @Mobile, " +
                                  " [Yahoo] = @Yahoo, [Skype] = @Skype, [Facebook] = @Facebook, [Detail] = @Detail, [Skin] = @Skin, " +
                                  " [LastLogin] = @LastLogin, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@LoginName", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Email", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Avatar", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Birthday", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Sex", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                        CreateSqlPrameter("@FullName", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Password", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Address", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Phone", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Mobile", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Yahoo", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Skype", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Facebook", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@Skin", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@LastLogin", SqlDbType.DateTime, 0, ParameterDirection.Input),
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
                throw new Exception("UserDAO::Update::Error", ex);
            }
        }

        public static void UpdateUserLastLogin(DataRow dataRow)
        {
            UpdateUserLastLogin(null, dataRow);
        }

        public static void UpdateUserLastLogin(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"UPDATE [User] SET" +
                                  "[LastLogin] = getdate() " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, updateString, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("UserDAO::UpdateUserLastLogin::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [User] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
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
                throw new Exception("UserDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [User] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
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
                throw new Exception("UserDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable GetUser(DataRow dataRow)
        {
            return GetUser(null, dataRow);
        }

        public static DataTable GetUser(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString =
                @"Select * From [User] Where [LoginName] = @LoginName AND [Password] = @Password AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@LoginName", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Password", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("UserDAO::GetUser::Error", ex);
            }
        }

        public static DataTable GetUserByGroup(DataRow dataRow)
        {
            return GetUserByGroup(null, dataRow);
        }

        public static DataTable GetUserByGroup(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT [User].* " +
                                  " , ([User].[LoginName] + ' - ' + [User].[FullName]) AS [Name] " +
                                  " FROM [User] " +
                                  " LEFT JOIN [GroupMember] " +
                                  " ON [GroupMember].[UserId] = [User].[Id] " +
                                  " WHERE [GroupMember].[GroupId] = @GroupId " +
                                  " AND (ISNULL([User].flag, '') = '')" +
                                  " AND (ISNULL([GroupMember].flag, '') = '')" + 
                                  " ORDER BY [LoginName]";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("UserDAO::GetUserByGroup::Error", ex);
            }
        }

        public static DataTable GetUserByEmail(DataRow dataRow)
        {
            return GetUserByEmail(null, dataRow);
        }

        public static DataTable GetUserByEmail(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select TOP 1 * From [User] Where [Email] = @Email AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Email", SqlDbType.NVarChar, 255, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("UserDAO::GetUserByEmail::Error", ex);
            }
        }

        public static DataTable GetUserByLoginName(DataRow dataRow)
        {
            return GetUserByLoginName(null, dataRow);
        }

        public static DataTable GetUserByLoginName(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select TOP 1 * From [User] Where [LoginName] = @LoginName AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@LoginName", SqlDbType.NVarChar, 255, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("UserDAO::GetUserByLoginName::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "SELECT * " +
                                     " , ([LoginName] + ' - ' + [FullName]) AS [Name] " +
                                     " FROM [User] WHERE (ISNULL(flag, '') = '') " +
                                     " ORDER BY [LoginName]";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("UserDAO::SelectAll::Error", ex);
            }
        }

      public static DataTable GetBirthday()
        {
          return GetBirthday(null);
        }

      public static DataTable GetBirthday(SqlTransaction sqlTransaction)
        {
            string selectAllString = "SELECT * " +
                                     " , ([LoginName] + ' - ' + [FullName]) AS [Name] " +
                                     " FROM [User] " +
                                     " WHERE (MONTH(Birthday) = MONTH(GETDATE())) AND (DAY(Birthday) = DAY(GETDATE())) " +
                                     " AND (ISNULL(flag, '') = '') " +
                                     " ORDER BY [LoginName]";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
              throw new Exception("UserDAO::GetBirthday::Error", ex);
            }
        }

        public static DataTable GetBirthdayNext()
        {
          return GetBirthdayNext(null);
        }

        public static DataTable GetBirthdayNext(SqlTransaction sqlTransaction)
        {
          string selectAllString = "SELECT TOP 10 * " +
                                   " , ([LoginName] + ' - ' + [FullName]) AS [Name] " +
                                   " FROM [User] " +
                                   " WHERE DATEDIFF(dd, DATEADD(yy, DATEDIFF(yy, [Birthday], getdate()), [Birthday]), getdate()) >= -30 " +
                                   " AND DATEDIFF(dd, DATEADD(yy, DATEDIFF(yy, [Birthday], getdate()), [Birthday]), getdate()) < 0 " +
                                   " AND (ISNULL(flag, '') = '') " +
                                   " ORDER BY DATEADD(yy, DATEDIFF(yy, [Birthday], getdate()), [Birthday])";
          try
          {
            return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
          }
          catch (Exception ex)
          {
            throw new Exception("UserDAO::GetBirthdayNext::Error", ex);
          }
        }

        #region ViewGetAllUser

        public static DataSet ViewGetAllUser(DataSet dataSet)
        {
            return ViewGetAllUser(null, dataSet);
        }

        public static DataSet ViewGetAllUser(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [User] "
                                           +
                                           CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          SystemConstants.Entities.User.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          SystemConstants.Entities.User.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT *, row_number() over(order by [LoginName]) RowNum FROM [User] "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          SystemConstants.Entities.User.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          SystemConstants.Entities.User.Name)
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

        #region ViewGetAllUserByGroup

        public static DataSet ViewGetAllUserByGroup(DataSet dataSet)
        {
            return ViewGetAllUserByGroup(null, dataSet);
        }

        public static DataSet ViewGetAllUserByGroup(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [User] "
                                           + " LEFT JOIN [GroupMember] "
                                           + " ON [GroupMember].[UserId] = [User].[Id] "
                                           + " WHERE [GroupMember].[GroupId] = @GroupId "
                                           + " AND ISNULL([GroupMember].flag, '') = '' "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          SystemConstants.Entities.User.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          SystemConstants.Entities.User.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT [User].*, row_number() over(order by [User].[LoginName]) RowNum "
                                         + " , [Group].[Name] [GroupName] "
                                         + " FROM [User] "
                                         + " LEFT JOIN [GroupMember] "
                                         + " ON [GroupMember].[UserId] = [User].[Id] "
                                         + " LEFT JOIN [Group] "
                                         + " ON [GroupMember].[GroupId] = [Group].[Id] "
                                         + " WHERE [GroupMember].[GroupId] = @GroupId "
                                         + " AND ISNULL([GroupMember].flag, '') = '' "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          SystemConstants.Entities.User.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          SystemConstants.Entities.User.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input)
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
            int gid =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                        Constants.Paging.Direction.GId]);
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = gid;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        #region ViewGetAllUserFilterByGroup

        public static DataSet ViewGetAllUserFilterByGroup(DataSet dataSet)
        {
            return ViewGetAllUserFilterByGroup(null, dataSet);
        }

        public static DataSet ViewGetAllUserFilterByGroup(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM ( "
                                           + " 	    SELECT [UserId] "
                                           + " 	    FROM [GroupMember] "
                                           + " 	    WHERE [GroupId] IN (SELECT retval FROM fn_ConvertStringToArray(@Group, ',')) "
                                           + " 	    AND ISNULL(flag, '') = '' "
                                           + " 	    GROUP BY ([UserId]) HAVING COUNT(*) >= @GroupQuantity "
                                           + " 	  ) [GroupMember] "
                                           + " LEFT JOIN [User] "
                                           + " ON [User].[Id] = [GroupMember].[UserId] "
                                           +
                                           CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          SystemConstants.Entities.User.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          SystemConstants.Entities.User.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT [User].*, row_number() over(order by [User].[LoginName]) RowNum "
                                         + " FROM ( "
                                         + " 	    SELECT [UserId] "
                                         + " 	    FROM [GroupMember] "
                                         + " 	    WHERE [GroupId] IN (SELECT retval FROM fn_ConvertStringToArray(@Group, ',')) "
                                         + " 	    AND ISNULL(flag, '') = '' "
                                         + " 	    GROUP BY ([UserId]) HAVING COUNT(*) >= @GroupQuantity "
                                         + " 	  ) [GroupMember] "
                                         + " LEFT JOIN [User] "
                                         + " ON [User].[Id] = [GroupMember].[UserId] "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          SystemConstants.Entities.User.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          SystemConstants.Entities.User.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@Group", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@GroupQuantity", SqlDbType.Int, 0, ParameterDirection.Input)
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
            string group =
                    dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0]["Group"].ToString();
            int groupQuantity =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0]["GroupQuantity"]);
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = group;
            paramArray[4].Value = groupQuantity;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("User");
            table.Columns.Add("Id");
            table.Columns.Add("Status");
            table.Columns.Add("LoginName");
            table.Columns.Add("Email");
            table.Columns.Add("FullName");
            table.Columns.Add("Password");
            table.Columns.Add("Address");
            table.Columns.Add("Phone");
            table.Columns.Add("Mobile");
            table.Columns.Add("LastLogin");
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