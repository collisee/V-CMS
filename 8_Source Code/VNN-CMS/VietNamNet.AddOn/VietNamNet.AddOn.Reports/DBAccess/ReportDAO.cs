
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using VietNamNet.Framework.DAO.MSSQL;

namespace  VietNamNet.AddOn.Report.Core.DBAccess
{

	public class ReportDAO : BaseDAO
	{
		#region Standard Function
        public static DataTable ReportByGroup(DataRow dr)
        {
            return ReportByGroup(dr, null);
        }
        public static DataTable ReportByGroup(DataRow dr, SqlTransaction sqlTransaction)
        {
            string procedureName = Report.Core.Common.Constants.Services.ReportManager.Actions.ReportByGroup;
            try
            {

                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input), 
                        CreateSqlPrameter("@DateFrom", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@DateTo", SqlDbType.DateTime, 0, ParameterDirection.Input) 
                    };
                SetParameterValues(paramArray, dr);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception("ReportDAO::ReportByGroup::Error" + ex.Message, ex);
            }
        }


        public static DataTable ReportByCat(DataRow dr)
        {
            return ReportByCat(dr, null);
        }
        public static DataTable ReportByCat(DataRow dr, SqlTransaction sqlTransaction)
        {
            string procedureName = Report.Core.Common.Constants.Services.ReportManager.Actions.ReportByCat;
            try
            {

                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@UserId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@DateFrom", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@DateTo", SqlDbType.DateTime, 0, ParameterDirection.Input) 
                    };
                SetParameterValues(paramArray, dr); 

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0]; 

            }
            catch (Exception ex)
            {
                throw new Exception("ReportDAO::ReportByCat::Error" + ex.Message, ex);
            }
        }
		
		public static DataTable GetTemplateTable()
		{
			DataTable table = new DataTable("Report");
            table.Columns.Add("CategoryId");
            table.Columns.Add("Alias");
			table.Columns.Add("DisplayName");
            table.Columns.Add("Total");

			return table;
		}
		
		public static DataRow GetTemplateRow()
		{
			return GetTemplateTable().NewRow();
		}
		#endregion
	}
	
}
