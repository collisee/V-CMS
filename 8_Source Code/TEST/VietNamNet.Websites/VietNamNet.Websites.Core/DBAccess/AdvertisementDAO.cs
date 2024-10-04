using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.Websites.Core.DBAccess
{
    public class AdvertisementDAO : BaseDAO
    {
        #region GetLayoutByCategoryId

        public static DataTable GetLayoutByCategoryId(DataRow dataRow)
        {
            return GetLayoutByCategoryId(null, dataRow);
        }

        public static DataTable GetLayoutByCategoryId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT TOP 1 [AdvertisementLayout].[Id] [id] " +
                                  "	    , [AdvertisementLayout].[Name] [name] " +
                                  " FROM [AdvertisementLayoutCategory] " +
                                  " LEFT JOIN [AdvertisementLayout] " +
                                  " ON [AdvertisementLayout].[Id] = [AdvertisementLayoutCategory].[LayoutId] " +
                                  " WHERE [AdvertisementLayoutCategory].[CategoryId] = @CategoryId " +
                                  " AND ISNULL([AdvertisementLayoutCategory].flag, '') = '' " +
                                  " AND ISNULL([AdvertisementLayout].flag, '') = '' " +
                                  " ORDER BY [AdvertisementLayout].[Name]";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("AdvertisementDAO::GetLayoutByCategoryId::Error", ex);
            }
        }

        #endregion

        #region GetZonesByLayoutId

        public static DataTable GetZonesByLayoutId(DataRow dataRow)
        {
            return GetZonesByLayoutId(null, dataRow);
        }

        public static DataTable GetZonesByLayoutId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT [AdvertisementZone].[Id] [id] " +
                                  "	    , [AdvertisementZone].[Name] [name] " +
                                  "	    , [AdvertisementZone].[HolderId] [holderId] " +
                                  "	    , [AdvertisementZone].[Direction] [direction] " +
                                  "	    , [AdvertisementZone].[Mode] [mode] " +
                                  "	    , [AdvertisementZone].[Width] [width] " +
                                  "	    , [AdvertisementZone].[Height] [height] " +
                                  " FROM [AdvertisementLayoutZone] " +
                                  " LEFT JOIN [AdvertisementZone] " +
                                  " ON [AdvertisementZone].[Id] = [AdvertisementLayoutZone].[ZoneId] " +
                                  " WHERE [AdvertisementLayoutZone].[LayoutId] = @LayoutId " +
                                  " AND ISNULL([AdvertisementLayoutZone].flag, '') = '' " +
                                  " AND ISNULL([AdvertisementZone].flag, '') = '' " +
                                  " ORDER BY [AdvertisementZone].[Name] ";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@LayoutId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("AdvertisementDAO::GetZonesByLayoutId::Error", ex);
            }
        }

        #endregion

        #region GetBlocksByZoneId

        public static DataTable GetBlocksByZoneId(DataRow dataRow)
        {
            return GetBlocksByZoneId(null, dataRow);
        }

        public static DataTable GetBlocksByZoneId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT [AdvertisementBlock].[Id] [id] " +
                                  "	    , [AdvertisementBlock].[Name] [name] " +
                                  "	    , [AdvertisementBlock].[Mode] [mode] " +
                                  "	    , [AdvertisementBlock].[TimeDelay] [timeDelay] " +
                                  "	    , [AdvertisementBlock].[Width] [width] " +
                                  "	    , [AdvertisementBlock].[Height] [height] " +
                                  " FROM [AdvertisementZoneBlock] " +
                                  " LEFT JOIN [AdvertisementBlock] " +
                                  " ON [AdvertisementBlock].[Id] = [AdvertisementZoneBlock].[BlockId] " +
                                  " WHERE [AdvertisementZoneBlock].[ZoneId] = @ZoneId " +
                                  " AND ISNULL([AdvertisementZoneBlock].flag, '') = '' " +
                                  " AND ISNULL([AdvertisementBlock].flag, '') = '' " +
                                  " ORDER BY [AdvertisementBlock].[Name]";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@ZoneId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("AdvertisementDAO::GetBlocksByZoneId::Error", ex);
            }
        }

        #endregion

        #region GetItemsByBlockId

        public static DataTable GetItemsByBlockId(DataRow dataRow)
        {
            return GetItemsByBlockId(null, dataRow);
        }

        public static DataTable GetItemsByBlockId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT [AdvertisementItem].[Id] [id] " +
                                  "	    , [AdvertisementItem].[Name] [name] " +
                                  "	    , [AdvertisementItem].[Link] [link] " +
                                  "	    , [AdvertisementItem].[FileLink1] [fileLink1] " +
                                  "	    , [AdvertisementItem].[FileLink2] [fileLink2] " +
                                  "	    , [AdvertisementItem].[FileJS] [fileJS] " +
                                  "	    , [AdvertisementItem].[CodeJS] [codeJS] " +
                                  "	    , [AdvertisementItem].[StartTime] [startTime] " +
                                  "	    , [AdvertisementItem].[EndTime] [endTime] " +
                                  "	    , [AdvertisementItem].[ExMode] [exMode] " +
                                  "	    , [AdvertisementItem].[ExWidth] [exWidth] " +
                                  "	    , [AdvertisementItem].[ExHeight] [exHeight] " +
                                  "	    , [AdvertisementItem].[TypeId] [typeId] " +
                                  "	    , [AdvertisementType].[Alias] [typeAlias] " +
                                  " FROM [AdvertisementBlockItem] " +
                                  " LEFT JOIN [AdvertisementItem] " +
                                  " ON [AdvertisementItem].[Id] = [AdvertisementBlockItem].[ItemId] " +
                                  " LEFT JOIN [AdvertisementType] " +
                                  " ON [AdvertisementType].[Id] = [AdvertisementItem].[TypeId] " +
                                  " WHERE [AdvertisementBlockItem].[BlockId] = @BlockId " +
                                  " AND DATEDIFF(mi, [AdvertisementItem].[StartTime], getdate()) >= 0 " +
                                  " AND DATEDIFF(mi, [AdvertisementItem].[EndTime], getdate()) <= 0 " +
                                  " AND ISNULL([AdvertisementBlockItem].flag, '') = '' " +
                                  " AND ISNULL([AdvertisementItem].flag, '') = '' " +
                                  " ORDER BY [AdvertisementItem].[Name]";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@BlockId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("AdvertisementDAO::GetItemsByBlockId::Error", ex);
            }
        }

        #endregion
    }
}