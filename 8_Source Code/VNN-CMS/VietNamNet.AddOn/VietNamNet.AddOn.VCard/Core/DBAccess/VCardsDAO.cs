
using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.AddOn.VCard.Core.DBAccess
{

    public class VCardsDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [VCards]" +
                        "([Fullname],[OrgTitle],[OrgName],[OrgUnit],[OrgPhone],[OrgMobile],[OrgFax],[OrgAdr1],[OrgAdr2],[OrgEmail1],[OrgEmail2],[OrgWebsite],[Sex],[Bday],[HomePhone],[HomeMobile],[HomeFax],[HomeAdr1],[HomeAdr2],[HomeEmail1],[HomeEmail2],[Homepage],[Notes],[Owner],[GroupID]," +
                         "[Scope],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag] " + ",Nickname,Paper,Nationality, HomeCountry, OrgCountry, OrgDescription, OrgOffice" + ") " +
                    "Values(@Fullname, @OrgTitle, @OrgName, @OrgUnit, @OrgPhone, @OrgMobile, @OrgFax, @OrgAdr1, @OrgAdr2, @OrgEmail1, @OrgEmail2, @OrgWebsite, @Sex, @Bday, @HomePhone, @HomeMobile, @HomeFax, @HomeAdr1, @HomeAdr2, @HomeEmail1, @HomeEmail2, @Homepage, @Notes, @Owner, @GroupID, " +
                         "@Scope, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag,@Nickname,@Paper,@Nationality, @HomeCountry, @OrgCountry, @OrgDescription, @OrgOffice) " +
                    "SELECT @ContactId = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@ContactId", SqlDbType.Int, 0, ParameterDirection.Output),
					CreateSqlPrameter("@Fullname", SqlDbType.NVarChar, 100, ParameterDirection.Input),
					CreateSqlPrameter("@OrgTitle", SqlDbType.NVarChar, 25, ParameterDirection.Input),
					CreateSqlPrameter("@OrgName", SqlDbType.NVarChar, 100, ParameterDirection.Input),
					CreateSqlPrameter("@OrgUnit", SqlDbType.NVarChar, 100, ParameterDirection.Input),
					CreateSqlPrameter("@OrgPhone", SqlDbType.NVarChar, 20, ParameterDirection.Input),
					CreateSqlPrameter("@OrgMobile", SqlDbType.NVarChar, 20, ParameterDirection.Input),
					CreateSqlPrameter("@OrgFax", SqlDbType.NVarChar, 20, ParameterDirection.Input),
					CreateSqlPrameter("@OrgAdr1", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@OrgAdr2", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@OrgEmail1", SqlDbType.VarChar, 50, ParameterDirection.Input),
					CreateSqlPrameter("@OrgEmail2", SqlDbType.VarChar, 50, ParameterDirection.Input),
					CreateSqlPrameter("@OrgWebsite", SqlDbType.VarChar, 50, ParameterDirection.Input),
					CreateSqlPrameter("@Sex", SqlDbType.TinyInt, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Bday", SqlDbType.DateTime, 0, ParameterDirection.Input),
					CreateSqlPrameter("@HomePhone", SqlDbType.NVarChar, 20, ParameterDirection.Input),
					CreateSqlPrameter("@HomeMobile", SqlDbType.NVarChar, 20, ParameterDirection.Input),
					CreateSqlPrameter("@HomeFax", SqlDbType.NVarChar, 20, ParameterDirection.Input),
					CreateSqlPrameter("@HomeAdr1", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@HomeAdr2", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@HomeEmail1", SqlDbType.VarChar, 50, ParameterDirection.Input),
					CreateSqlPrameter("@HomeEmail2", SqlDbType.VarChar, 50, ParameterDirection.Input),
					CreateSqlPrameter("@Homepage", SqlDbType.VarChar, 50, ParameterDirection.Input),
					CreateSqlPrameter("@Notes", SqlDbType.NVarChar, 1000, ParameterDirection.Input),
					CreateSqlPrameter("@Owner", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@GroupID", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Scope", SqlDbType.TinyInt, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Created_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Created_By", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Flag", SqlDbType.Char, 1, ParameterDirection.Input),

                    CreateSqlPrameter("@Nickname", SqlDbType.VarChar, 100, ParameterDirection.Input),
                    CreateSqlPrameter("@Paper", SqlDbType.VarChar, 50, ParameterDirection.Input),
                      CreateSqlPrameter("@Nationality", SqlDbType.NVarChar, 100, ParameterDirection.Input),
                      CreateSqlPrameter("@HomeCountry", SqlDbType.NVarChar, 100, ParameterDirection.Input),
                      CreateSqlPrameter("@OrgCountry", SqlDbType.NVarChar, 100, ParameterDirection.Input),
                      CreateSqlPrameter("@OrgDescription", SqlDbType.NVarChar, 100, ParameterDirection.Input),
                    CreateSqlPrameter("@OrgOffice", SqlDbType.NVarChar, 100, ParameterDirection.Input) 
				};
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, insertString, paramArray);
                SetOutputValues(paramArray, dataRow);
            }
            catch (Exception ex)
            {
                throw new Exception("VCardsDAO::Insert::Error::" + ex.Message, ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [VCards] Set" +
                        " [Fullname] = @Fullname, [OrgTitle] = @OrgTitle, [OrgName] = @OrgName, [OrgUnit] = @OrgUnit, [OrgPhone] = @OrgPhone, [OrgMobile] = @OrgMobile, [OrgFax] = @OrgFax, [OrgAdr1] = @OrgAdr1, [OrgAdr2] = @OrgAdr2, [OrgEmail1] = @OrgEmail1, [OrgEmail2] = @OrgEmail2, [OrgWebsite] = @OrgWebsite, [Sex] = @Sex, [Bday] = @Bday, [HomePhone] = @HomePhone, [HomeMobile] = @HomeMobile, [HomeFax] = @HomeFax, [HomeAdr1] = @HomeAdr1, [HomeAdr2] = @HomeAdr2, [HomeEmail1] = @HomeEmail1, [HomeEmail2] = @HomeEmail2, [Homepage] = @Homepage, [Notes] = @Notes, [Owner] = @Owner, [GroupID] = @GroupID, " +
                        "[Scope] = @Scope,   [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                        ",Nickname=@Nickname,Paper=@Paper,Nationality=@Nationality, HomeCountry=@HomeCountry, OrgCountry=@OrgCountry, OrgDescription=@OrgDescription, OrgOffice=@OrgOffice" +
                    " Where [ContactId] = @ContactId AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@ContactId", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Fullname", SqlDbType.NVarChar, 100, ParameterDirection.Input),
					CreateSqlPrameter("@OrgTitle", SqlDbType.NVarChar, 25, ParameterDirection.Input),
					CreateSqlPrameter("@OrgName", SqlDbType.NVarChar, 100, ParameterDirection.Input),
					CreateSqlPrameter("@OrgUnit", SqlDbType.NVarChar, 100, ParameterDirection.Input),
					CreateSqlPrameter("@OrgPhone", SqlDbType.NVarChar, 20, ParameterDirection.Input),
					CreateSqlPrameter("@OrgMobile", SqlDbType.NVarChar, 20, ParameterDirection.Input),
					CreateSqlPrameter("@OrgFax", SqlDbType.NVarChar, 20, ParameterDirection.Input),
					CreateSqlPrameter("@OrgAdr1", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@OrgAdr2", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@OrgEmail1", SqlDbType.VarChar, 50, ParameterDirection.Input),
					CreateSqlPrameter("@OrgEmail2", SqlDbType.VarChar, 50, ParameterDirection.Input),
					CreateSqlPrameter("@OrgWebsite", SqlDbType.VarChar, 50, ParameterDirection.Input),
					CreateSqlPrameter("@Sex", SqlDbType.TinyInt, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Bday", SqlDbType.DateTime, 0, ParameterDirection.Input),
					CreateSqlPrameter("@HomePhone", SqlDbType.NVarChar, 20, ParameterDirection.Input),
					CreateSqlPrameter("@HomeMobile", SqlDbType.NVarChar, 20, ParameterDirection.Input),
					CreateSqlPrameter("@HomeFax", SqlDbType.NVarChar, 20, ParameterDirection.Input),
					CreateSqlPrameter("@HomeAdr1", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@HomeAdr2", SqlDbType.NVarChar, 500, ParameterDirection.Input),
					CreateSqlPrameter("@HomeEmail1", SqlDbType.VarChar, 50, ParameterDirection.Input),
					CreateSqlPrameter("@HomeEmail2", SqlDbType.VarChar, 50, ParameterDirection.Input),
					CreateSqlPrameter("@Homepage", SqlDbType.VarChar, 50, ParameterDirection.Input),
					CreateSqlPrameter("@Notes", SqlDbType.NVarChar, 1000, ParameterDirection.Input),
					CreateSqlPrameter("@Owner", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@GroupID", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Scope", SqlDbType.TinyInt, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@Flag", SqlDbType.Char, 1, ParameterDirection.Input),
                    
                     CreateSqlPrameter("@Nickname", SqlDbType.VarChar, 100, ParameterDirection.Input),
                    CreateSqlPrameter("@Paper", SqlDbType.VarChar, 50, ParameterDirection.Input),
                      CreateSqlPrameter("@Nationality", SqlDbType.NVarChar, 100, ParameterDirection.Input),
                      CreateSqlPrameter("@HomeCountry", SqlDbType.NVarChar, 100, ParameterDirection.Input),
                      CreateSqlPrameter("@OrgCountry", SqlDbType.NVarChar, 100, ParameterDirection.Input),
                      CreateSqlPrameter("@OrgDescription", SqlDbType.NVarChar, 100, ParameterDirection.Input),
                    CreateSqlPrameter("@OrgOffice", SqlDbType.NVarChar, 100, ParameterDirection.Input) 
				};
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, updateString, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("VCardsDAO::Update::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString = @"UPDATE [VCards] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [ContactId] = @ContactId";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[] {
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
					CreateSqlPrameter("@ContactId", SqlDbType.Int, 0, ParameterDirection.Input)
				};
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, deleteString, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("VCardsDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [VCards] Where [ContactId] = @ContactId AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[] {
					CreateSqlPrameter("@ContactId", SqlDbType.Int, 0, ParameterDirection.Input)
				};
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("VCardsDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select u.loginname OwnerLoginName,u.fullname OwnerFullName,u.email OwnerEmail,vc.* " +
                                    " ,(select GroupName from VCardsGroups g where g.GroupId=vc.GroupId) as [GroupName] " +
                                    "From [VCards]  vc " +
                                    "LEFT JOIN [User] u ON u.Id=vc.Owner "+
                                    "Where (ISNULL(vc.flag, '') = '')";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("VCardsDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable SelectAllByUser(DataRow dataRow)
        {
            return SelectAllByUser(null, dataRow);
        }

        public static DataTable SelectAllByUser(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            //string selectAllString = "Select * From [VCards] Where (ISNULL(flag, '') = '') And ([Owner]=@Owner or [Scope]=1) ORDER BY Fullname ";
            string selectAllString = "Select u.loginname OwnerLoginName,u.fullname OwnerFullName,u.email OwnerEmail,vc.* " +
                                    " ,(select GroupName from VCardsGroups g where g.GroupId=vc.GroupId) as [GroupName] " +
                                   "From [VCards]  vc " +
                                   "LEFT JOIN [User] u ON u.Id=vc.Owner " +
                                   "Where (ISNULL(vc.flag, '') = '') And ([Owner]=@Owner or vc.[Scope]=1) ORDER BY vc.Fullname ";
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
                throw new Exception("VCardsDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("VCards");
            table.Columns.Add("ContactId");
            table.Columns.Add("Fullname");
            table.Columns.Add("OrgTitle");
            table.Columns.Add("OrgName");
            table.Columns.Add("OrgUnit");
            table.Columns.Add("OrgPhone");
            table.Columns.Add("OrgMobile");
            table.Columns.Add("OrgFax");
            table.Columns.Add("OrgAdr1");
            table.Columns.Add("OrgAdr2");
            table.Columns.Add("OrgEmail1");
            table.Columns.Add("OrgEmail2");
            table.Columns.Add("OrgWebsite");
            table.Columns.Add("Sex");
            table.Columns.Add("Bday");
            table.Columns.Add("HomePhone");
            table.Columns.Add("HomeMobile");
            table.Columns.Add("HomeFax");
            table.Columns.Add("HomeAdr1");
            table.Columns.Add("HomeAdr2");
            table.Columns.Add("HomeEmail1");
            table.Columns.Add("HomeEmail2");
            table.Columns.Add("Homepage");
            table.Columns.Add("Notes");
            table.Columns.Add("Owner");
            table.Columns.Add("OwnerLoginName");
            table.Columns.Add("OwnerFullName");
            table.Columns.Add("OwnerEmail");
            table.Columns.Add("GroupID");
            table.Columns.Add("Scope");
            table.Columns.Add("Created_At");
            table.Columns.Add("Created_By");
            table.Columns.Add("Last_Modified_At");
            table.Columns.Add("Last_Modified_By");
            table.Columns.Add("Flag");
            table.Columns.Add("GroupName");

            table.Columns.Add("Nickname");
            table.Columns.Add("Paper");
            table.Columns.Add("Nationality");
            table.Columns.Add("HomeCountry");
            table.Columns.Add("OrgCountry");
            table.Columns.Add("OrgDescription");
            table.Columns.Add("OrgOffice");
            return table;
        }

        public static DataRow GetTemplateRow()
        {
            return GetTemplateTable().NewRow();
        }
        #endregion
    }

}
