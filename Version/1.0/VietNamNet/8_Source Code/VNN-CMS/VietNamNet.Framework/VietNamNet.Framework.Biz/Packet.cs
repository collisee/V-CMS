using System;
using System.Data;

namespace VietNamNet.Framework.Biz
{
    public class Packet
    {
        private string action;
        private DataSet ds;
        private string serviceName;
        private Type type;

        public Packet()
        {
            ds = new DataSet();
            action = null;
            type = null;
        }

        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        public DataSet RawData
        {
            get { return ds; }
            set { ds = value; }
        }

        public Type Type
        {
            get { return type; }
            set { type = value; }
        }

        public object GetData(string columnName)
        {
            object obj = null;
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Contains(columnName))
            {
                obj = ds.Tables[0].Rows[0][columnName];
                if (obj == DBNull.Value)
                {
                    obj = null;
                }
            }
            return obj;
        }

        public object GetData(string columnName, int row)
        {
            object obj = null;
            if (ds.Tables[0].Rows.Count > row && ds.Tables[0].Columns.Contains(columnName))
            {
                obj = ds.Tables[0].Rows[row][columnName];
                if (obj == DBNull.Value)
                {
                    obj = null;
                }
            }
            return obj;
        }

        public object GetData(string tableName, string columnName)
        {
            return GetData(tableName, columnName, 0);
        }

        public object GetData(string tableName, string columnName, int row)
        {
            if (tableName == null)
            {
                return GetData(columnName, row);
            }
            object obj = null;
            if (ds.Tables[tableName].Rows.Count > row && ds.Tables[tableName].Columns.Contains(columnName))
            {
                obj = ds.Tables[tableName].Rows[row][columnName];
                if (obj == DBNull.Value)
                {
                    obj = null;
                }
            }
            return obj;
        }

        public void SetData(string columnName, int row, object data)
        {
            if (ds.Tables.Count == 0)
            {
                ds.Tables.Add();
                ds.Tables[0].Columns.Add(columnName);
            }
            else if (ds.Tables[0].Columns[columnName] == null)
            {
                ds.Tables[0].Columns.Add(columnName);
            }

            if (row >= ds.Tables[0].Rows.Count)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[columnName] = data;
                if (row == 0)
                {
                    ds.Tables[0].Rows.Add(dr);
                }
                else
                {
                    ds.Tables[0].Rows.InsertAt(dr, row);
                }
            }
            else
            {
                ds.Tables[0].Rows[row][columnName] = data;
            }
        }

        public void SetData(string tableName, string columnName, int row, object data)
        {
            if (tableName == null)
            {
                SetData(columnName, row, data);
            }
            else
            {
                if (ds.Tables[tableName] == null)
                {
                    ds.Tables.Add(tableName);
                    ds.Tables[tableName].Columns.Add(columnName);
                }
                else if (ds.Tables[tableName].Columns[columnName] == null)
                {
                    ds.Tables[tableName].Columns.Add(columnName);
                }
                if (row >= ds.Tables[tableName].Rows.Count)
                {
                    DataRow dr = ds.Tables[tableName].NewRow();
                    dr[columnName] = data;
                    if (row == 0)
                    {
                        ds.Tables[tableName].Rows.Add(dr);
                    }
                    else
                    {
                        ds.Tables[tableName].Rows.InsertAt(dr, row);
                    }
                }
                else
                {
                    ds.Tables[tableName].Rows[row][columnName] = data;
                }
            }
        }
    }
}