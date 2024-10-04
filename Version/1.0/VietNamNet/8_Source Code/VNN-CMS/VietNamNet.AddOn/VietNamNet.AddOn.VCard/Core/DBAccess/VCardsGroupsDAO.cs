
using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.AddOn.VCard.Core.DBAccess
{

	public class VCardsGroupsDAO : BaseDAO
	{
		#region Standard Function

		public static void Insert(DataRow dataRow)
		{
			Insert(null, dataRow);
		}

		public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
		{
			string insertString = "Insert Into [VCardsGroups]" + 
						"([GroupName],[Description],[Owner],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " + 
					"Values(@GroupName, @Description, @Owner, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " + 
					"SELECT @GroupId = SCOPE_IDENTITY()";
			try {
				SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Output),
					CreateSqlPrameter("@GroupName", SqlDbType.NVarChar, 100, ParameterDirection.Input),
					CreateSqlPrameter("@Description", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@Owner", SqlDbType.Int, 0, ParameterDirection.Input),
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
				throw new Exception("VCardsGroupsDAO::Insert::Error",ex);
			}
		}

		public static void Update(DataRow dataRow)
		{
			Update(null, dataRow);
		}

		public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
		{
			string updateString = @"Update [VCardsGroups] Set" +
						" [GroupName] = @GroupName, [Description] = @Description, [Owner] = @Owner, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
					" Where [GroupId] = @GroupId AND (ISNULL(flag, '') = '')";
			try
			{
				SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@GroupName", SqlDbType.NVarChar, 100, ParameterDirection.Input),
					CreateSqlPrameter("@Description", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@Owner", SqlDbType.Int, 0, ParameterDirection.Input),
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
				throw new Exception("VCardsGroupsDAO::Update::Error",ex);
			}
		}

		public static void Delete(DataRow dataRow)
		{
			Delete(null, dataRow);
		}
		
		public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
		{
			string deleteString = @"UPDATE [VCardsGroups] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [GroupId] = @GroupId";
			try
			{	
				SqlParameter[] paramArray = new SqlParameter[] {
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input)
				};
				SetParameterValues(paramArray, dataRow);
				
				ExecuteNonQuery(sqlTransaction, deleteString, paramArray);
			}
			catch (Exception ex)
			{
                throw new Exception("VCardsGroupsDAO::Delete::Error" + ex.Message, ex);
			}
		}

		public static DataTable SelectOne(DataRow dataRow)
		{
			return SelectOne(null, dataRow);
		}
		
		public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
		{
			string selectString = @"Select * From [VCardsGroups] Where [GroupId] = @GroupId AND (ISNULL(flag, '') = '')";
			try
			{
				SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input)
				};
				SetParameterValues(paramArray, dataRow);
				
				return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
			}
			catch (Exception ex)
			{
				throw new Exception("VCardsGroupsDAO::SelectOne::Error" ,ex);
			}
		}
		
		public static DataTable SelectAll()
		{
			return SelectAll(null);
		}
		
		public static DataTable SelectAll(SqlTransaction sqlTransaction)
		{
			string selectAllString = "SELECT * FROM [VCardsGroups] Where (ISNULL(flag, '') = '')";
			try
			{			
				return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
			}
			catch (Exception ex)
			{
				throw new Exception("VCardsGroupsDAO::SelectAll::Error",ex);
			}
		}

        public static DataTable SelectAllByUser(DataRow dataRow)
        {
            return SelectAllByUser(null,dataRow);
        }

        public static DataTable SelectAllByUser(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectAllString = "SELECT * FROM [VCardsGroups] WHERE (ISNULL(flag, '') = '') And Owner=@Owner";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@Owner", SqlDbType.Int, 0, ParameterDirection.Input)
				};
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectAllString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("VCardsGroupsDAO::SelectAllByUser::Error", ex);
            }
        }
		
		public static DataTable GetTemplateTable()
		{
			DataTable table = new DataTable("VCardsGroups");
			table.Columns.Add("GroupId");
			table.Columns.Add("GroupName");
			table.Columns.Add("Description");
			table.Columns.Add("Owner");
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
