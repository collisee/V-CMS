
using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.CMS.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;
using log4net;

namespace  VietNamNet.AddOn.Royalty.Core.DBAccess
{

	public class RoyaltyFundDAO : BaseDAO
    {
        private static readonly ILog iLog = LogManager.GetLogger("VietNamNet.AddOn.Royalty.Log");

		#region Standard Function

		public static void Insert(DataRow dataRow)
		{
			Insert(null, dataRow);
		}

		public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
		{
			string insertString = "Insert Into [RoyaltyFund]" +
                        "([Article_Id],[Text_Fund],[Image_Fund],[Audio_Fund],[Video_Fund],[Other_Fund],[Notes],[Author_Id],[Author_IsMember],[Setter_Id],[Type_Id],[Set_Type],[Pay_Date],[Pay_Status],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                    "Values(@Article_Id, @Text_Fund, @Image_Fund, @Audio_Fund, @Video_Fund, @Other_Fund, @Notes, @Author_Id,@Author_IsMember, @Setter_Id, @Type_Id, @Set_Type, @Pay_Date, @Pay_Status, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " + 
					"SELECT @Fund_Id = SCOPE_IDENTITY()";
			try {
				SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@Fund_Id", SqlDbType.Int, 0, ParameterDirection.Output),
					CreateSqlPrameter("@Article_Id", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Text_Fund", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Image_Fund", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Audio_Fund", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Video_Fund", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Other_Fund", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Notes", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@Author_Id", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@Author_IsMember", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Setter_Id", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Type_Id", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Set_Type", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@Pay_Date", SqlDbType.DateTime, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Pay_Status", SqlDbType.Int, 0, ParameterDirection.Input),
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
                VietNamNet.Framework.System.SystemLogging.Error("RoyaltyFundDAO::Insert::Error=" + ex);
                iLog.Error("RoyaltyFundDAO::Insert::Error=" + ex);
                throw new Exception("RoyaltyFundDAO::Insert::Error" + ex, ex);                
			}
		}

		public static void Update(DataRow dataRow)
		{
			Update(null, dataRow);
		}

		public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
		{
			string updateString = @"Update [RoyaltyFund] Set" +
						"  [Article_Id] = @Article_Id, [Text_Fund] = @Text_Fund, [Image_Fund] = @Image_Fund, " + 
                        "[Audio_Fund] = @Audio_Fund, [Video_Fund] = @Video_Fund, [Other_Fund] = @Other_Fund, [Notes] = @Notes, " +
                        "[Author_Id] = @Author_Id, [Author_IsMember] = @Author_IsMember,[Setter_Id] = @Setter_Id, [Type_Id] = @Type_Id, [Set_Type] = @Set_Type, [Pay_Date] = @Pay_Date, [Pay_Status] = @Pay_Status, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                    " Where [Fund_Id] = @Fund_Id AND (ISNULL(flag, '') = '')";
			try
			{
				SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@Fund_Id", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Article_Id", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Text_Fund", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Image_Fund", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Audio_Fund", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Video_Fund", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Other_Fund", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Notes", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@Author_Id", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@Author_IsMember", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Setter_Id", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Type_Id", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Set_Type", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@Pay_Date", SqlDbType.DateTime, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Pay_Status", SqlDbType.Int, 0, ParameterDirection.Input),
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
                iLog.Error("RoyaltyFundDAO::Update::Error=" + ex);
				throw new Exception("RoyaltyFundDAO::Update::Error",ex);
			}
		}

		public static void Delete(DataRow dataRow)
		{
			Delete(null, dataRow);
		}
		
		public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
		{
            string deleteString = @"UPDATE [RoyaltyFund] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Fund_Id] = @Fund_Id ";
			try
			{	
				SqlParameter[] paramArray = new SqlParameter[] {
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@Fund_Id", SqlDbType.Int, 0, ParameterDirection.Input),

				};
				SetParameterValues(paramArray, dataRow);
				
				ExecuteNonQuery(sqlTransaction, deleteString, paramArray);
			}
			catch (Exception ex)
            {
                iLog.Error("RoyaltyFundDAO::Delete::Error=" + ex);
				throw new Exception("RoyaltyFundDAO::Delete::Error" +ex.Message,ex);
			}
		}

		public static DataTable SelectOne(DataRow dataRow)
		{
			return SelectOne(null, dataRow);
		}
		
		public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
		{
            string selectString = @"Select * From [RoyaltyFund] Where [Fund_Id] = @Fund_Id AND (ISNULL(flag, '') = '')";
			try
			{
				SqlParameter[] paramArray = new SqlParameter[] {
                    CreateSqlPrameter("@Fund_id", SqlDbType.Int, 0, ParameterDirection.Input)
				};
				SetParameterValues(paramArray, dataRow);
				
				return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
			}
			catch (Exception ex)
            {
                iLog.Error("RoyaltyFundDAO::SelectOne::Error=" + ex);
				throw new Exception("RoyaltyFundDAO::SelectOne::Error",ex);
			}
		}
		
		public static DataTable SelectAll()
		{
			return SelectAll(null);
		}
		
		public static DataTable SelectAll(SqlTransaction sqlTransaction)
		{
			string selectAllString = "Select * From [RoyaltyFund] Where (ISNULL(flag, '') = '')";
			try
			{			
				return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
			}
			catch (Exception ex)
            {
                iLog.Error("RoyaltyFundDAO::SelectAll::Error=" + ex);
				throw new Exception("RoyaltyFundDAO::SelectAll::Error",ex);
			}
		}

        public static DataTable SelectByArticle(DataRow dataRow)
        {
            return SelectByArticle(dataRow,null);
        }
        public static DataTable SelectByArticle(DataRow dataRow,SqlTransaction sqlTransaction)
        {
            //string strQuery = "Select * From [RoyaltyFund] Where (ISNULL(flag, '') = '') and Article_Id=@Article_Id";
            const string strProcedure = "Royalty_FundListByArticle";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[] {
                     CreateSqlPrameter("@Article_Id", SqlDbType.Int, 0, ParameterDirection.Input),
				};
                SetParameterValues(paramArray, dataRow);

                //return ExecuteQuery(sqlTransaction, strQuery, paramArray).Tables[0];
                return ExecuteProcedure(sqlTransaction, strProcedure, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                iLog.Error("RoyaltyFundDAO::SelectByArticle::Error=" + ex);
                throw new Exception("RoyaltyFundDAO::SelectByArticle::Error", ex);
            }
        }

	    public static DataTable GetTemplateTable()
		{
			DataTable table = new DataTable("RoyaltyFund");
			table.Columns.Add("Fund_Id");
			table.Columns.Add("Article_Id");
			table.Columns.Add("Text_Fund");
			table.Columns.Add("Image_Fund");
			table.Columns.Add("Audio_Fund");
			table.Columns.Add("Video_Fund");
			table.Columns.Add("Other_Fund");
			table.Columns.Add("Notes");
			table.Columns.Add("Author_Id");
            table.Columns.Add("Author_IsMember");
			table.Columns.Add("Setter_Id");
			table.Columns.Add("Type_Id");
			table.Columns.Add("Set_Type");
			table.Columns.Add("Pay_Date");
			table.Columns.Add("Pay_Status");
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

        #region "Searching"

        public static DataTable Reports21B(DataRow dr)
         {
             return Reports21B(dr, null); 
         }
        public static DataTable Reports21B(DataRow dr, SqlTransaction sqlTransaction)
        {
            string procedureName = Royalty.Core.Common.Constants.Services.RoyaltyFundManager.Actions.Reports21B;
            try
            {
               
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@UserId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@DateFrom", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@DateTo", SqlDbType.DateTime, 0, ParameterDirection.Input) 
                    };
                SetParameterValues(paramArray, dr);
                //paramArray[0].Value = dr["DateFrom"];
                //paramArray[1].Value = dr["DateTo"];


                return ExecuteProcedure(sqlTransaction, procedureName, paramArray) .Tables[0] ;



            }
            catch (Exception ex)
            {
                iLog.Error("RoyaltyFundDAO::Reports21B::Error=" + ex);
                throw new Exception("RoyaltyFundDAO::Reports21B::Error" + ex.Message, ex);
            }
        }

        public static DataTable Reports21A(DataRow dr)
        {
            return Reports21A(dr, null);
        }
        public static DataTable Reports21A(DataRow dr, SqlTransaction sqlTransaction)
        {
            string procedureName = Royalty.Core.Common.Constants.Services.RoyaltyFundManager.Actions.Reports21A;
            try
            {

                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@IsMember", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@UserId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@DateFrom", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@DateTo", SqlDbType.DateTime, 0, ParameterDirection.Input) 
                    };
                SetParameterValues(paramArray, dr);
                //paramArray[0].Value = dr["DateFrom"];
                //paramArray[1].Value = dr["DateTo"];


                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];



            }
            catch (Exception ex)
            {
                
                iLog.Error("RoyaltyFundDAO::Reports21A::Error=" + ex);
                throw new Exception("RoyaltyFundDAO::Reports21A::Error" + ex.Message, ex);
            }
        }
 
        #endregion

        #region ViewGetAllArticleList

        public static DataSet ViewGetAllArticleList(DataSet dataSet)
        {
            return ViewGetAllArticleList(null, dataSet);
        }

        public static DataSet ViewGetAllArticleList(SqlTransaction sqlTransaction, DataSet dataSet)
        { 
            string qryFundStatus = " 1=1 ";
            string status = dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
               CMSConstants.Paging.Direction.Status].ToString();

            switch  (status)
            {case "1":
                    qryFundStatus = " Total_Fund >0 ";break;
                case "2":
                    qryFundStatus = " Total_Fund is null or Total_Fund<=0 "; break; 
            }

            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + "  FROM ( "
                                           + "  SELECT * FROM ( "
                                           + " 		SELECT DISTINCT([ArticleId]) "
                                           + " 		FROM [ArticleCategory] "
                                           + " 		WHERE [PartitionId] IN (SELECT [PartitionId] FROM fn_GetPartitionsByUserId(@UId)) "
                                           + "      AND DATEDIFF(DD, [PublishDate], @PublishFromDate) <= 0 "
                                           + "      AND DATEDIFF(DD, [PublishDate], @PublishToDate) >= 0 "
                                           + " 		AND [CategoryId] IN (SELECT [Id] FROM fn_GetCategoriesByUserId(@UId)) "
                                           + " 		AND ISNULL(flag, '') = '' "
                                           + " 	) [ArticleCategory] "
                                           + "  LEFT JOIN [Article] "
                                           + " 	ON [ArticleCategory].[ArticleId] = [Article].[Id] "
                                           + " 	WHERE (ISNULL(Status, '') = '' OR [Article].[Status] = N'Đã xuất bản') "
                                           + "  AND DATEDIFF(DD, [Article].[PublishDate], @PublishFromDate) <= 0 "
                                           + "  AND DATEDIFF(DD, [Article].[PublishDate], @PublishToDate) >= 0 "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.Article.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.Article.Name)
                                            + " ) A " 
                                            + " LEFT JOIN "
                                            + " 	( select Article_Id,  "
                                            + " 			sum(Text_Fund) + sum(Image_Fund) +  "
                                            + " 			sum(Audio_Fund) + sum(Video_Fund) + sum(Other_Fund)  "
                                            + " 			as Total_Fund "
                                            + " 		from RoyaltyFund group by Article_Id "
                                            + " ) F ON A.[Id]=F.Article_Id "
                                            + " WHERE " + qryFundStatus;

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( " 
                                         + " SELECT [Article].[Id] "
                                         + "    , [Article].[Status] "
                                         + "    , [Article].[PublishDate] "
                                         + "    , [Article].[Name] "
                                         + "    , [Article].[Title] "
                                         + "    , [Article].[Author] "
                                         + "    , [Article].[Url] "
                                         + "    , [Article].[TotalView] "
                                         + "    , [Article].[ArticleContentTypeId] "
                                         + "    , row_number() over(order by [Article].[Id] DESC) RowNum "
                                         + "    FROM ( "
                                         + " 		SELECT DISTINCT([ArticleId])   "
                                         + " 		FROM [ArticleCategory] "
                                         + " 		WHERE [PartitionId] IN (SELECT [PartitionId] FROM fn_GetPartitionsByUserId(@UId)) "
                                         + "        AND DATEDIFF(DD, [PublishDate], @PublishFromDate) <= 0 "
                                         + "        AND DATEDIFF(DD, [PublishDate], @PublishToDate) >= 0 "
                                         + " 		AND [CategoryId] IN (SELECT [Id] FROM fn_GetCategoriesByUserId(@UId)) "
                                         + " 		AND ISNULL(flag, '') = '' "
                                         + " 	) [ArticleCategory] "
                                         + "    LEFT JOIN [Article] "
                                         + " 	ON [ArticleCategory].[ArticleId] = [Article].[Id] "
                                         + "    WHERE (ISNULL(Status, '') = '' OR [Article].[Status] = N'Đã xuất bản') "
                                         + "    AND DATEDIFF(DD, [Article].[PublishDate], @PublishFromDate) <= 0 "
                                         + "    AND DATEDIFF(DD, [Article].[PublishDate], @PublishToDate) >= 0 "
                                         + CommonDAO.SearchingQuery(
                                             dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                             CMSConstants.Entities.Article.SearchColumns,
                                             ModuleConstants.ConnectorString.AND_STRING,
                                             CMSConstants.Entities.Article.Name)
                                         + " ) A " 
                                         + " LEFT JOIN "
                                        + " 	( select Article_Id,  "
                                        + " 			sum(Text_Fund) + sum(Image_Fund) +  "
                                        + " 			sum(Audio_Fund) + sum(Video_Fund) + sum(Other_Fund)  "
                                        + " 			as Total_Fund "
                                        + " 		from RoyaltyFund group by Article_Id "
                                        + " 	) F ON A.[Id]=F.Article_Id "
                                         + " WHERE " + qryFundStatus +  " AND RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@UId", SqlDbType.Int, 0, ParameterDirection.Input),
                    //CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                    CreateSqlPrameter("@PublishFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@PublishToDate", SqlDbType.DateTime, 0, ParameterDirection.Input)
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
            int uid =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                        CMSConstants.Paging.Direction.UId]);
           
            DateTime publishFromDate = Convert.ToDateTime(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.PublishFromDate]);
            DateTime publishToDate = Convert.ToDateTime(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.PublishToDate]);
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = uid;
            //paramArray[4].Value = status;
            paramArray[4].Value = publishFromDate;
            paramArray[5].Value = publishToDate;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

	}
	
}
