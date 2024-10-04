
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using VietNamNet.Framework.DAO.MSSQL;

namespace  VietNamNet.AddOn.Royalty.Core.DBAccess
{

	public class RoyaltyTypesDAO : BaseDAO
	{
		#region Standard Function

		public static void Insert(DataRow dataRow)
		{
			Insert(null, dataRow);
		}

		public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
		{
			string insertString = "Insert Into [RoyaltyTypes]" + 
						"([Title],[Description],[Parent_Id],[MIN_VAL],[MAX_VAL],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " + 
					"Values(@Title, @Description, @Parent_Id, @MIN_VAL, @MAX_VAL, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " + 
					"SELECT @Type_Id = SCOPE_IDENTITY()";
			try {
				SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@Type_Id", SqlDbType.Int, 0, ParameterDirection.Output),
					CreateSqlPrameter("@Title", SqlDbType.NVarChar, 255, ParameterDirection.Input),
					CreateSqlPrameter("@Description", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@Parent_Id", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@MIN_VAL", SqlDbType.Decimal, 0, ParameterDirection.Input),
					CreateSqlPrameter("@MAX_VAL", SqlDbType.Decimal, 0, ParameterDirection.Input),
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
				throw new Exception("RoyaltyTypesDAO::Insert::Error",ex);
			}
		}

		public static void Update(DataRow dataRow)
		{
			Update(null, dataRow);
		}

		public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
		{
			string updateString = @"Update [RoyaltyTypes] Set" +
						" [Title] = @Title, [Description] = @Description, [Parent_Id] = @Parent_Id, [MIN_VAL] = @MIN_VAL, [MAX_VAL] = @MAX_VAL, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
					" Where [Type_Id] = @Type_Id AND (ISNULL(flag, '') = '')";
			try
			{
				SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@Type_Id", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Title", SqlDbType.NVarChar, 255, ParameterDirection.Input),
					CreateSqlPrameter("@Description", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@Parent_Id", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@MIN_VAL", SqlDbType.Decimal, 0, ParameterDirection.Input),
					CreateSqlPrameter("@MAX_VAL", SqlDbType.Decimal, 0, ParameterDirection.Input),
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
				throw new Exception("RoyaltyTypesDAO::Update::Error",ex);
			}
		}

		public static void Delete(DataRow dataRow)
		{
			Delete(null, dataRow);
		}
		
		public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
		{
			string deleteString = @"UPDATE [RoyaltyTypes] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Type_Id] = @Type_Id";
			try
			{	
				SqlParameter[] paramArray = new SqlParameter[] {
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Type_Id", SqlDbType.Int, 0, ParameterDirection.Input)
				};
				SetParameterValues(paramArray, dataRow);
				
				ExecuteNonQuery(sqlTransaction, deleteString, paramArray);
			}
			catch (Exception ex)
			{
				throw new Exception("RoyaltyTypesDAO::Delete::Error",ex);
			}
		}

		public static DataTable SelectOne(DataRow dataRow)
		{
			return SelectOne(null, dataRow);
		}
		
		public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
		{
			string selectString = @"Select * From [RoyaltyTypes] Where [Type_Id] = @Type_Id AND (ISNULL(flag, '') = '')";
			try
			{
				SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@Type_Id", SqlDbType.Int, 0, ParameterDirection.Input)
				};
				SetParameterValues(paramArray, dataRow);
				
				return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
			}
			catch (Exception ex)
			{
				throw new Exception("RoyaltyTypesDAO::SelectOne::Error",ex);
			}
		}
		
		public static DataTable SelectAll()
		{
			return SelectAll(null);
		}
		
		public static DataTable SelectAll(SqlTransaction sqlTransaction)
		{
			string selectAllString = "Select c.*, p.Title as Parent_Title From [RoyaltyTypes] c left join  [RoyaltyTypes] p on c.Parent_Id = p.Type_Id Where (ISNULL(c.flag, '') = '')";
			try
			{			
				return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
			}
			catch (Exception ex)
			{
				throw new Exception("RoyaltyTypesDAO::SelectAll::Error",ex);
			}
		}
        public static DataTable SelectByParent(DataRow dataRow)
        {
            return SelectByParent(dataRow,null);
        }

        public static DataTable SelectByParent(DataRow dataRow, SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select c.*, p.Title as Parent_Title From [RoyaltyTypes] c left join  [RoyaltyTypes] p on c.Parent_Id = p.Type_Id Where (ISNULL(c.flag, '') = '') And c.Parent_Id=@Parent_Id ";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@Parent_Id", SqlDbType.Int, 0, ParameterDirection.Input)
				};
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectAllString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("RoyaltyTypesDAO::SelectByParent::Error", ex);
            }
        }
		
		public static DataTable GetTemplateTable()
		{
			DataTable table = new DataTable("RoyaltyTypes");
			table.Columns.Add("Type_Id");
			table.Columns.Add("Title");
			table.Columns.Add("Description");
			table.Columns.Add("Parent_Id");
			table.Columns.Add("MIN_VAL");
			table.Columns.Add("MAX_VAL");
			table.Columns.Add("Created_At");
			table.Columns.Add("Created_By");
			table.Columns.Add("Last_Modified_At");
			table.Columns.Add("Last_Modified_By");
			table.Columns.Add("Flag");
            table.Columns.Add("Parent_Title");
			
			return table;
		}
		
		public static DataRow GetTemplateRow()
		{
			return GetTemplateTable().NewRow();
		}
		#endregion
	}
	
}
