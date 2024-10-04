using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;
using LumiSoft.Net.POP3.Client;
using VietNamNet.Framework.Common.Cryptography;
using VietNamNet.Framework.Common.Encryption;
using Yogesh.ExcelXml;

namespace VietNamNet.Framework.Common
{
    public class Utilities
    {
        #region Reflection

        public static string GetProperty(object objectToGet, string propertyName)
        {
            Type objectType = objectToGet.GetType();
            PropertyInfo propertyInfo = objectType.GetProperty(propertyName);
            if ((propertyInfo != null) && (propertyInfo.CanRead))
            {
                object propertyValue = propertyInfo.GetValue(objectToGet, null);
                if (propertyValue != null) return propertyValue.ToString();
            }
            return string.Empty;
        }

        public static void SetProperty(object objectToSet, string propertyName, object propertyValue)
        {
            Type objectType = objectToSet.GetType();
            PropertyInfo propertyInfo = objectType.GetProperty(propertyName);

            if ((propertyInfo != null) && (propertyInfo.CanWrite))
                propertyInfo.SetValue(objectToSet, propertyValue, null);
        }

        public static void RunMethod(object objectToRun, string methodName)
        {
            Type objectType = objectToRun.GetType();
            MethodInfo methodInfo = objectType.GetMethod(methodName);

            if (methodInfo != null && methodInfo.IsPublic)
            {
                methodInfo.Invoke(objectToRun, null);
            }
        }

        public static void RunMethod(object objectToRun, string methodName, object[] parameters)
        {
            Type objectType = objectToRun.GetType();
            MethodInfo methodInfo = objectType.GetMethod(methodName);

            if (methodInfo != null && methodInfo.IsPublic)
            {
                methodInfo.Invoke(objectToRun, parameters);
            }
        }

        #endregion

        #region Parse

        public static int ParseInt(string s)
        {
            try
            {
                return Int32.Parse(s);
            }
            catch
            {
                return 0;
            }
        }

        public static int ParseInt(object s)
        {
            try
            {
                return Int32.Parse(s.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public static decimal ParseDecimal(string s)
        {
            try
            {
                return Decimal.Parse(s);
            }
            catch
            {
                return 0;
            }
        }

        public static decimal ParseDecimal(object s)
        {
            try
            {
                return Decimal.Parse(s.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public static double ParseDouble(string s)
        {
            try
            {
                return Double.Parse(s);
            }
            catch
            {
                return 0;
            }
        }

        public static double ParseDouble(object s)
        {
            try
            {
                return Double.Parse(s.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public static long ParseLong(string s)
        {
            try
            {
                return long.Parse(s);
            }
            catch
            {
                return 0;
            }
        }

        public static long ParseLong(object s)
        {
            try
            {
                return long.Parse(s.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public static string ParseDateTime(DateTime dateTime)
        {
            return ParseDateTime(dateTime, null);
        }

        public static string ParseDateTime(DateTime dateTime, string format)
        {
            try
            {
                if (IsNullOrEmpty(format))
                    return dateTime.ToString();
                return dateTime.ToString(format);
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion

        #region Misc

        private static readonly string[] VietnameseSigns = new string[]

            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };

        public static string GetConfigKey(string msgConstantKey)
        {
            string msg;
            try
            {
                msg = ConfigurationManager.AppSettings[msgConstantKey];
            }
            catch
            {
                msg = string.Empty;
                //throw new Exception(msgConstantKey + " not found!!!");
            }
            return msg;
        }

        public static int GetPageSize()
        {
            int p = ParseInt(GetConfigKey("PageSize"));
            if (p <= 0) p = 30; //Default = 30
            return p;
        }

      public static int GetCommentPageSize()
      {
        int p = ParseInt(GetConfigKey("CommentPageSize"));
        if (p <= 0) p = 30; //Default = 30
        return p;
      }

        public static bool IsNullOrEmpty(object s)
        {
            return Nulls.IsNullOrEmpty(s);
        }

        public static bool StringCompare(string s1, string s2)
        {
            if (s1 == null || s2 == null) return false;
            else return s1.ToLower().Equals(s2.ToLower());
        }

        public static bool StringCompare(object s1, object s2)
        {
            if (s1 == null || s2 == null) return false;
            else return s1.ToString().ToLower().Equals(s2.ToString().ToLower());
        }

        public static string RemoveVietNamChar(string s)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    s = s.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }

            return s;
        }

        public static string RemoveSpaceAndToLower(string s)
        {
            string e = string.Empty;
            return Nulls.IsNullOrEmpty(s) ? string.Empty : s.ToLower().Replace(" ", e).Replace("\r", e).Replace("\n", e);
        }

        public static string ConvertToHTMLLink(string source)
        {
            string[] rep =
                new string[]
                    {
                        " ", "\r\n", "\r", "\n", "<", ">", "&lt;", "&ft;", "&", ";", "?", "%", "~", "!", "@", "#", "$", "*", 
                        "(", ")", "{", "}", "[", "]", "+", "=", "/", "\\", "^", "|", "\"", "'", ",", ".", "“", "”"
                    };
            return ConvertToHTMLLink(source, rep);
        }

        public static string ConvertToHTMLLink(string source, string[] map)
        {
            string e = "-";
            string ret = Nulls.IsNullOrEmpty(source)
                             ? string.Empty
                             : RemoveVietNamChar(source).ToLower();
            foreach (string s in map)
            {
                ret = ret.Replace(s, e);
            }

            string ret2 = string.Empty;
            for (int i = 0; i < ret.Length; i++ )
            {
                char c = ret[i];
                if (!(c >= 'a' && c <= 'z') && !(c >= 'A' && c <= 'Z') && !(c >= '0' && c <= '9') && (c != '-'))
                {
                    ret2 += '-';
                }
                else
                {
                    ret2 += c;
                }
            }

            return ret2;
        }

        #endregion

        #region Date Time

        public static DateTime ConvertLocaltoGlobalDateTime(string strLocalDate)
        {
            try
            {
                CultureInfo MyCultureInfo = new CultureInfo(GetConfigKey("CultureInfo"));
                DateTime date = DateTime.Parse(strLocalDate, MyCultureInfo);
                return date;
            }
            catch
            {
                //return Convert.ToDateTime(strLocalDate);
                return Nulls.DateTime;
            }
        }

        public static DateTime ConvertLocaltoGlobalDateTime(string strLocalDate, DateTime defaultLocalDate)
        {
            try
            {
                CultureInfo MyCultureInfo = new CultureInfo(GetConfigKey("CultureInfo"));
                DateTime date = DateTime.Parse(strLocalDate, MyCultureInfo);
                return date;
            }
            catch
            {
                return defaultLocalDate;
            }
        }

        public static DateTime GetMinDate()
        {
            return ConvertLocaltoGlobalDateTime(GetConfigKey(Constants.ConfigKey.MinDate));
        }

        public static string FormatDisplayDateOnly(DateTime d)
        {
            if (Nulls.IsNullOrEmpty(d)) return string.Empty;
            string result = string.Empty;
            try
            {
                result = d.ToString(GetConfigKey(Constants.ConfigKey.DisplayDateFormat));
            }
            catch
            {
                result = string.Empty;
            }
            finally
            {
                if (d.Equals(DateTime.MinValue))
                {
                    result = string.Empty;
                }
                else
                    result = result.Equals(GetConfigKey(Constants.ConfigKey.MinDate)) ? null : result;
            }
            return result;
        }

        public static string FormatDisplayDateTime(DateTime d)
        {
            if (Nulls.IsNullOrEmpty(d)) return string.Empty;
            string result = string.Empty;
            try
            {
                result = d.ToString(GetConfigKey(Constants.ConfigKey.DisplayDateTimeFormat));
            }
            catch
            {
                result = string.Empty;
            }
            finally
            {
                if (d.Equals(DateTime.MinValue))
                {
                    result = string.Empty;
                }
                else
                    result = result.Equals(GetConfigKey(Constants.ConfigKey.MinDate)) ? null : result;
            }
            return result;
        }

        public static DateTime GetFirstDayOfWeek(DateTime date)
        {
            return date.AddDays(1 - (int) date.DayOfWeek);
        }

        public static DateTime GetFirstDayOfWeek()
        {
            return GetFirstDayOfWeek(DateTime.Now);
        }

        public static DateTime GetFirstDayOfMonth(DateTime date)
        {
            return date.AddDays(1 - date.Day);
        }

        public static DateTime GetFirstDayOfMonth()
        {
            return GetFirstDayOfMonth(DateTime.Now);
        }

        public static DateTime GetFirstDayOfQuarter(DateTime date)
        {
            while (date.Month%3 != 1) date = date.AddMonths(-1);
            return date.AddDays(1 - date.Day);
        }

        public static DateTime GetFirstDayOfQuarter()
        {
            return GetFirstDayOfQuarter(DateTime.Now);
        }

        public static DateTime GetFirstDayOfYear(DateTime date)
        {
            return date.AddDays(1 - date.DayOfYear);
        }

        public static DateTime GetFirstDayOfYear()
        {
            return GetFirstDayOfYear(DateTime.Now);
        }

        public static DateTime GetLastDayOfWeek(DateTime date)
        {
            return date.AddDays(7 - (int) date.DayOfWeek);
        }

        public static DateTime GetLastDayOfWeek()
        {
            return GetLastDayOfWeek(DateTime.Now);
        }

        public static DateTime GetLastDayOfMonth(DateTime date)
        {
            date = date.AddMonths(1);
            return date.AddDays(0 - date.Day);
        }

        public static DateTime GetLastDayOfMonth()
        {
            return GetLastDayOfMonth(DateTime.Now);
        }

        public static DateTime GetLastDayOfQuarter(DateTime date)
        {
            while (date.Month%3 != 0) date = date.AddMonths(1);
            date = date.AddMonths(1);
            return date.AddDays(0 - date.Day);
        }

        public static DateTime GetLastDayOfQuarter()
        {
            return GetLastDayOfQuarter(DateTime.Now);
        }

        public static DateTime GetLastDayOfYear(DateTime date)
        {
            date = date.AddYears(1);
            return date.AddDays(0 - date.DayOfYear);
        }

        public static DateTime GetLastDayOfYear()
        {
            return GetLastDayOfYear(DateTime.Now);
        }

        #endregion

        #region Encrypt/Decrypt

        public static string KeyGenerator()
        {
            Guid g = Guid.NewGuid();
            return g.ToString();
        }

        public static string Encrypt(string data, string key)
        {
            AES encryptor = new AES(AES.KeySize.Bits256, key);
            return encryptor.Encrypt(data);
        }

        public static string Decrypt(string data, string key)
        {
            AES encryptor = new AES(AES.KeySize.Bits256, key);
            return encryptor.Decrypt(data);
        }

        #endregion

        #region HTML Encode

        public static DataTable EndodeMultiLine(DataTable dt)
        {
            //Check if table contain data
            if (dt.Rows.Count > 0)
            {
                //Loop rows
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Loop columns
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        //Check if cell have value
                        if (!dt.Rows[i][j].Equals(DBNull.Value))
                        {
                            //Call HtmlEncode to encode data
                            dt.Rows[i][j] = dt.Rows[i][j].ToString().Replace("\r\n", "<br>");
                        }
                    }
                }
            }
            return dt;
        }

        public static DataTable EncodeSelectedsColumns(DataTable dt, string strColumnsCollection)
        {
            //Get collection of selecteds columns 
            string[] columns = strColumnsCollection.Split(',');

            //Check if datatable have data
            if (dt.Rows.Count > 0)
            {
                //Loop columns
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    //Loop selecteds columns
                    for (int j = 0; j < columns.Length; j++)
                    {
                        //Check if column name of current value in loop equal selected columns
                        if (dt.Columns[i].ColumnName.Equals(columns[j]))
                        {
                            if (!dt.Rows[0][i].Equals(DBNull.Value))
                            {
                                //Encode cell
                                dt.Rows[0][i] = HttpUtility.HtmlEncode(dt.Rows[0][i].ToString());
                                break;
                            }
                        }
                    }
                }
            }
            return dt;
        }

        public static DataTable EncodeDatatable(DataTable dt)
        {
            //Check if table contain data
            if (dt.Rows.Count > 0)
            {
                //Loop rows
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Loop columns
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        //Check if cell have value
                        if (!dt.Rows[i][j].Equals(DBNull.Value))
                        {
                            //Call HtmlEncode to encode data
                            dt.Rows[i][j] = HttpUtility.HtmlEncode(dt.Rows[i][j].ToString());
                        }
                    }
                }
            }
            return dt;
        }

        public static DataTable DecodeDatatable(DataTable dt)
        {
            //Check if table contain data
            if (dt.Rows.Count > 0)
            {
                //Loop rows
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Loop columns
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        //Check if cell have value
                        if (!dt.Rows[i][j].Equals(DBNull.Value))
                        {
                            //Call HtmlEncode to encode data
                            dt.Rows[i][j] = HttpUtility.HtmlDecode(dt.Rows[i][j].ToString());
                        }
                    }
                }
            }
            return dt;
        }

        public static DataSet EndodeDataSet(DataSet ds)
        {
            //Check if table contain data
            DataTable dt;
            if (ds.Tables.Count > 0)
            {
                for (int a = 0; a < ds.Tables.Count; a++)
                {
                    dt = ds.Tables[a];
                    if (dt.Rows.Count > 0)
                    {
                        //Loop rows
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //Loop columns
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                //Check if cell have value
                                if (!dt.Rows[i][j].Equals(DBNull.Value))
                                {
                                    //Call HtmlEncode to encode data
                                    dt.Rows[i][j] = HttpUtility.HtmlEncode(dt.Rows[i][j].ToString());
                                }
                            }
                        }
                    }
                }
            }

            return ds;
        }

        public static DataSet EncodeDataSetExceptSelectedColumns(DataSet ds, string strColumnsCollection)
        {
            //Get collection of selecteds columns 
            string[] columns = strColumnsCollection.Split(',');
            DataTable dt;

            if (ds.Tables.Count > 0)
            {
                for (int a = 0; a < ds.Tables.Count; a++)
                {
                    dt = ds.Tables[a];
                    //Check if datatable have data
                    if (dt.Rows.Count > 0)
                    {
                        //Loop columns
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            //Loop selecteds columns
                            for (int j = 0; j < columns.Length; j++)
                            {
                                //Check if column name of current value in loop equal selected columns
                                if (!dt.Columns[i].ColumnName.ToLower().Equals(columns[j].ToLower()))
                                {
                                    if (!dt.Rows[a][i].Equals(DBNull.Value))
                                    {
                                        //Encode cell
                                        dt.Rows[a][i] = HttpUtility.HtmlEncode(dt.Rows[a][i].ToString());
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return ds;
        }

        public static DataTable EncodeDataSetExceptSelectedColumns(DataTable table, string strColumnsCollection)
        {
            //Get collection of selecteds columns 
            string[] columns = strColumnsCollection.Split(',');
            DataTable dt = table;

            //Check if datatable have data
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                //Loop columns
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    //Loop selecteds columns
                    for (int j = 0; j < columns.Length; j++)
                    {
                        //Check if column name of current value in loop equal selected columns
                        if (!dt.Columns[i].ColumnName.ToLower().Equals(columns[j].ToLower()))
                        {
                            if (!dt.Rows[a][i].Equals(DBNull.Value))
                            {
                                //Encode cell
                                dt.Rows[a][i] = HttpUtility.HtmlEncode(dt.Rows[a][i].ToString());
                                break;
                            }
                        }
                    }
                }
            }
            return dt;
        }

        public static DataSet EncodeDataSetSelectedColumns(DataSet ds, string strColumnsCollection)
        {
            //Get collection of selecteds columns 
            string[] columns = strColumnsCollection.Split(',');
            DataTable dt;

            if (ds.Tables.Count > 0)
            {
                for (int a = 0; a < ds.Tables.Count; a++)
                {
                    dt = ds.Tables[a];
                    //Check if datatable have data
                    if (dt.Rows.Count > 0)
                    {
                        //Loop columns
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            //Loop selecteds columns
                            for (int j = 0; j < columns.Length; j++)
                            {
                                //Check if column name of current value in loop equal selected columns
                                if (dt.Columns[i].ColumnName.Equals(columns[j]))
                                {
                                    if (!dt.Rows[0][i].Equals(DBNull.Value))
                                    {
                                        //Encode cell
                                        dt.Rows[0][i] = HttpUtility.HtmlEncode(dt.Rows[0][i].ToString());
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return ds;
        }

        public static string EncodeMutilineTextForDisplay(string strMutilineText)
        {
            if (!IsNullOrEmpty(strMutilineText))
            {
                string strEncode = strMutilineText.Replace("\r\n", "<br>");
                strEncode = strEncode.Replace("  ", " &nbsp;");
                strEncode = strEncode.Replace("&nbsp; ", "&nbsp;&nbsp;");
                return strEncode;
            }
            else
                return string.Empty;
        }

        #endregion

        #region Export to Excel

        public static void ExportToExcel(DataTable table)
        {
            ExportToExcel(table, table.TableName);
        }

        public static void ExportToExcel(DataTable table, ArrayList exportColumns)
        {
            ExportToExcel(table, table.TableName, exportColumns);
        }

        public static void ExportToExcel(DataTable table, string tableName)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = " + tableName + ".xls");

            ExcelXmlWorkbook book = ExcelXmlWorkbook.DataSetToWorkbook(table.DataSet);
            book.Properties.Author = "VietNamNet.Framework"; // The author of the document
            book.Properties.Company = "VietNamNet";

            book.Export(HttpContext.Current.Response.OutputStream);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public static void ExportToExcel(DataTable table, string tableName, ArrayList exportColumns)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = " + tableName + ".xls");

            ExcelXmlWorkbook book = new ExcelXmlWorkbook();
            book.Properties.Author = "VietNamNet.Framework"; // The author of the document
            book.Properties.Company = "VietNamNet";

            Worksheet sheet = book[0];
            sheet.Name = tableName;
            sheet.FreezeTopRows = 1;

            //Header
            int col = 0;
            for (int j = 0; j < table.Columns.Count; j++)
            {
                if (exportColumns.Contains(table.Columns[j].ColumnName))
                {
                    sheet[col++, 0].Value = table.Columns[j].ColumnName;
                }
            }

            //Content
            for (int i = 0; i < table.Rows.Count; i++)
            {
                col = 0;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (exportColumns.Contains(table.Columns[j].ColumnName))
                    {
                        sheet[col++, i + 1].Value = table.Rows[i][j];
                    }
                }
            }

            book.Export(HttpContext.Current.Response.OutputStream);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        #endregion

        #region URL Utilities

        public static string SetParamForURL(string URL, string ParamName, object ParamValue)
        {
            if (Nulls.IsNullOrEmpty(ParamValue))
            {
                return URL;
            }

            return SetParamForURL(URL, ParamName, ParamValue.ToString());
        }

        public static string SetParamForURL(string URL, string ParamName, string ParamValue)
        {
            /*The URL will be like this:
             * http://www.vietnamnet.vn/show.aspx?SearchKeyword=trongtb&page=3
             * param may exist or not.
             * if not then add param
             * else update param
`			*/
            //Case no param
            if (URL.IndexOf("?") == -1) return URL + "?" + ParamName + "=" + ParamValue;

            //from now on just cut off URL from ? to the end
            string strBaseURL = URL.Substring(0, URL.IndexOf("?"));
            string strURLParams = URL.Remove(0, URL.LastIndexOf("?") + 1);

            string strCurrentParamInURL;
            string strCurrentValueInURL;

            //have one param only
            if (strURLParams.IndexOf("&") == -1)
            {
                //Get param name
                if (strURLParams.IndexOf("=") == -1) return string.Empty;

                strCurrentParamInURL = strURLParams.Substring(0, strURLParams.IndexOf("="));

                if (URL.IndexOf("=") == strURLParams.Length) return strBaseURL + "?" + ParamName + "=" + ParamValue;

                strCurrentValueInURL =
                    strURLParams.Substring(strURLParams.IndexOf("=") + 1,
                                           strURLParams.Length - strURLParams.IndexOf("=") - 1);

                //Check if this is the param looking for
                if (ParamName.ToLower().Equals(strCurrentParamInURL.ToLower()))
                {
                    return strBaseURL + "?" + ParamName + "=" + ParamValue;
                }
                else
                {
                    return URL + "&" + ParamName + "=" + ParamValue;
                }
            }
            else //Have more than one param
            {
                string[] strParams = strURLParams.Split('&');
                bool isExisted = false;
                for (int i = 0; i < strParams.Length; i++)
                {
                    strCurrentParamInURL = strParams[i].IndexOf("=") > -1
                                               ? strParams[i].Substring(0, strParams[i].IndexOf("="))
                                               : string.Empty;
                    strCurrentValueInURL = strParams[i].IndexOf("=") > -1
                                               ? strParams[i].Remove(0, strParams[i].IndexOf("=") + 1)
                                               : string.Empty;
                    //check for pass in param
                    if (ParamName.ToLower().Equals(strCurrentParamInURL.ToLower()))
                    {
                        strParams[i] = ParamName + "=" + ParamValue;
                        isExisted = true;
                    }
                }
                if (isExisted)
                {
                    URL = strBaseURL + "?";
                    foreach (string param in strParams)
                    {
                        URL += param + "&";
                    }
                    URL = URL.Remove(URL.Length - 1, 1);
                }
                else
                {
                    URL += "&" + ParamName + "=" + ParamValue;
                }
                return URL;
            }
            //return string.Empty;
        }

        #endregion

        #region Security

        public static bool Event_Handler(object sender, EventArgs e)
        {
            return ((WebControl) sender).Visible && ((WebControl) sender).Enabled;
        }

        public static bool Pop3Authen(string user, string password)
        {
            string server = GetConfigKey(Constants.ConfigKey.POP3MailServer);
            int port = ParseInt(GetConfigKey(Constants.ConfigKey.POP3MailServerPort));
            bool ssl = StringCompare(GetConfigKey(Constants.ConfigKey.POP3MailServerSecure), Constants.CommonStatus.Yes);

            return Pop3Authen(server, port, ssl, user, password);
        }

        public static bool Pop3Authen(string server, int port, bool ssl, string user, string password)
        {
            bool ret = true;
            POP3_Client pop3 = new POP3_Client();
            try
            {
                pop3.Connect(server, port, ssl);
                pop3.Authenticate(user, password, true);
            }
            catch //(Exception ex)
            {
                ret = false;
            }
            finally
            {
                pop3.Disconnect();
                pop3.Dispose();
            }

            return ret;
        }

        #endregion

        #region Number Format

        public static string DisplayDecimalFormat(decimal d)
        {
            return d.ToString(GetConfigKey("DisplayDecimalFormat"));
        }

        public static string DisplayDecimalFormat(double d)
        {
            return d.ToString(GetConfigKey("DisplayDecimalFormat"));
        }

        public static string DisplayNumberFormat(int i)
        {
            return i.ToString(GetConfigKey("DisplayNumberFormat"));
        }

        public static string DisplayNumberFormat(long l)
        {
            return l.ToString(GetConfigKey("DisplayNumberFormat"));
        }

        #endregion

        #region Redirect Page

        public static void Redirect(string strFormNames, string paramName, string paramValue, bool goback, bool save)
        {
            string url = Nulls.IsNullOrEmpty(HttpContext.Current.Request.QueryString[Constants.ParameterName.GOBACK])
                             ? HttpUtility.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery)
                             : HttpUtility.UrlEncode(HttpContext.Current.Request.QueryString[Constants.ParameterName.GOBACK]);

            string strRedirect = strFormNames;

            if (!Nulls.IsNullOrEmpty(paramValue))
            {
                strRedirect = SetParamForURL(strRedirect, paramName, paramValue);
            }
            if (goback)
            {
                strRedirect = SetParamForURL(strRedirect, Constants.ParameterName.GOBACK, url);
            }
            if (save)
            {
                strRedirect = SetParamForURL(strRedirect, Constants.ParameterName.SAVE_SUCCESS, 1);
            }
            HttpContext.Current.Response.Redirect(strRedirect);
        }

        public static void Redirect(string strFormNames, string paramName, string paramValue)
        {
            Redirect(strFormNames, paramName, paramValue, true, false);
        }

        public static void Redirect(string strFormNames, string docId, bool goback, bool save)
        {
            Redirect(strFormNames, Constants.ParameterName.DOC_ID, docId, goback, save);
        }

        public static void Redirect(string strFormNames, string docId, bool save)
        {
            Redirect(strFormNames, Constants.ParameterName.DOC_ID, docId, true, save);
        }

        public static void Redirect(string strFormNames, string docId)
        {
            Redirect(strFormNames, docId, true, false);
        }

        public static void Redirect(string strFormNames)
        {
            Redirect(strFormNames, string.Empty, true, false);
        }

        public static void GotoErrorPage(string strError)
        {
            HttpContext.Current.Response.Redirect(
                SetParamForURL(Constants.FormNames.Error, Constants.ParameterName.MESSAGE,
                               strError));
        }

        public static void RedirectToLoginPage()
        {
            string strRedirect =
                string.Format("{0}?{1}={2}", Constants.FormNames.Login, Constants.ParameterName.LASTURL,
                              HttpUtility.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery));
            HttpContext.Current.Response.Redirect(strRedirect);
        }

        public static void RedirectToLoginPage(string msg)
        {
            string strRedirect =
                string.Format("{0}?{1}={2}&{3}={4}", Constants.FormNames.Login, Constants.ParameterName.MESSAGE, msg,
                              Constants.ParameterName.LASTURL,
                              HttpUtility.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery));
            HttpContext.Current.Response.Redirect(strRedirect);
        }

        public static void GoBackToView()
        {
            GoBackToView(Constants.FormNames.Default);
        }

        public static void GoBackToView(string urlDefault)
        {
            string url = HttpContext.Current.Request.QueryString[Constants.ParameterName.GOBACK];
            if (url == null) url = urlDefault;
            HttpContext.Current.Response.Redirect(url);
        }

        public static void GoBackToLastUrl()
        {
            GoBackToLastUrl(Constants.FormNames.Default);
        }

        public static void GoBackToLastUrl(string urlDefault)
        {
            string url = HttpContext.Current.Request.QueryString[Constants.ParameterName.LASTURL];
            if (url == null) url = urlDefault;
            HttpContext.Current.Response.Redirect(url);
        }

        public static void ItemDoesntExist()
        {
            GotoErrorPage(Constants.Message.ItemDoesntExist);
        }

        public static void NoRightToAccess()
        {
            RedirectToLoginPage(Constants.Message.NoRightToAccess);
        }

        public static void NoRightToCreate()
        {
            RedirectToLoginPage(Constants.Message.NoRightToCreate);
        }

        public static void NoRightToDelete()
        {
            RedirectToLoginPage(Constants.Message.NoRightToDelete);
        }

        #endregion

        #region Misc

        public static int GetUsersOnline()
        {
            return ParseInt(HttpContext.Current.Application[Constants.Session.USERS_ONLINE]);
        }

        public static int GetUsersVisit()
        {
            return ParseInt(HttpContext.Current.Application[Constants.Session.USERS_VISIT]);
        }

        public static string GetCurrency()
        {
            return GetConfigKey(Constants.ConfigKey.Currency);
        }

        public static string GetRandomPassword()
        {
            return RandomText.GenerateNewPassword();
        }

        public static DataTable RemoveDuplicates(DataTable t1, DataTable t2, string columnKey)
        {
            DataTable tempTable = t1.Copy();
            tempTable.Merge(t2, false);

            foreach (DataRow dr in t1.Rows)
                foreach (DataRow dr2 in t2.Rows)
                {
                    if (StringCompare(dr[columnKey], dr2[columnKey]))
                    {
                        DataRow findRow = tempTable.Rows.Find(dr[columnKey]);
                        if (findRow != null)
                            tempTable.Rows.Remove(findRow);
                        break;
                    }
                }
            return tempTable;
        }

        public static int GetTimeCaching()
        {
            return ParseInt(GetConfigKey(Constants.ConfigKey.TimeCaching));
        }

        public static string GetThumbnail(string fileName)
        {
            return
                string.Format("/thumb/view.html?{0}={1}", Constants.ParameterName.FILEPATH,
                              HttpUtility.UrlEncode(fileName));
        }

        public static string GetThumbnailWithRND(string fileName)
        {
            return
                string.Format("/thumb/view.html?{0}={1}&rnd={2}", Constants.ParameterName.FILEPATH,
                              HttpUtility.UrlEncode(fileName), RNG.Next(int.MaxValue));
        }

        public static int GetUserGroupId()
        {
            return ParseInt(GetConfigKey(Constants.ConfigKey.UserGroupID));
        }

        public static int GetAdminGroupId()
        {
            return ParseInt(GetConfigKey(Constants.ConfigKey.AdminGroupID));
        }

        #endregion

        #region FileSystem

        public class FileSystem
        {
            public static bool FileExists(string path)
            {
                return File.Exists(HttpContext.Current.Server.MapPath(path));
            }

            public static string GetFilePathNotDulicate(string path, string name)
            {
                //build path
                if (Nulls.IsNullOrEmpty(path)) path = "/";
                if (path[path.Length - 1] != '/') path += "/";

                string filePath = Path.Combine(path, name);

                if (FileExists(filePath))
                {
                    string extension = string.Empty;
                    string newName = name;
                    if (name.IndexOf(".") >= 0)
                    {
                        extension = name.Substring(name.LastIndexOf("."));
                        newName = name.Substring(0, name.LastIndexOf("."));
                    }
                    int fileNumber = 0;
                    while (FileExists(filePath))
                    {
                        filePath = string.Format("{0}{1} [{2}]{3}", path, newName, ++fileNumber, extension);
                    }
                }

                return filePath;
            }

            public static void DeleteEmptyDirectoriesAfterZip(string mapFolder)
            {
                foreach (string Dir in Directory.GetDirectories(mapFolder))
                {
                    DeleteEmptyDirectoriesAfterZip(Dir);
                    if (Directory.GetFiles(Dir).Length == 0 & Directory.GetDirectories(Dir).Length == 0)
                    {
                        Directory.Delete(Dir);
                    }
                }
            }

            public static bool IsValidFileTypeAfterUnZip(string fileName, string[] filters)
            {
                if (Nulls.IsNullOrEmpty(fileName)) return false;

                string strExt = fileName.Substring(fileName.LastIndexOf("."),
                                       fileName.Length - fileName.LastIndexOf("."));
                if (strExt == ".zip")
                {
                    return false;
                }
                else
                {
                    foreach (string s in filters)
                    {
                        string sExt = s.Substring(s.LastIndexOf("."), s.Length - s.LastIndexOf("."));
                        if (sExt == strExt) return true;
                    }
                }
                return false;
            }
        }

        #endregion
    }
}