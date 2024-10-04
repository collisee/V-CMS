using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VietNamNet.Framework.DAO.MSSQL
{
    public class BaseDAO
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.AppSettings["SqlConnectionString"]);
        }

        public static SqlConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        private static void OpenConnection(ref SqlConnection conn)
        {
            if (conn == null)
            {
                conn = GetConnection();
            }
            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception exception)
                {
                    throw new Exception("Cannot open a connection", exception);
                }
            }
        }

        private static SqlConnection OpenConnection(SqlTransaction sqlTransaction)
        {
            SqlConnection connection;
            if (sqlTransaction != null)
            {
                if (sqlTransaction.Connection == null)
                {
                    throw new ArgumentNullException("sqlTransaction");
                }
                connection = sqlTransaction.Connection;
            }
            else
            {
                connection = GetConnection();
            }
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception exception)
                {
                    throw new Exception("Cannot open a connection", exception);
                }
            }
            return connection;
        }

        private static void AttachParameters(SqlCommand command, SqlParameter[] sqlParameters)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (sqlParameters != null)
            {
                foreach (SqlParameter parameter in sqlParameters)
                {
                    if (parameter != null)
                    {
                        if (((parameter.Direction == ParameterDirection.InputOutput) || (parameter.Direction == ParameterDirection.Input)) && (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        command.Parameters.Add(parameter);
                    }
                }
            }
        }

        private static SqlCommand PrepareCommand(string commandText, SqlParameter[] sqlParameters)
        {
            if ((commandText == null) || (commandText.Length == 0))
            {
                throw new ArgumentNullException("commandText");
            }
            SqlCommand command = new SqlCommand(commandText);
            AttachParameters(command, sqlParameters);
            return command;
        }

        private static SqlCommand PrepareProcedure(string procedureName, SqlParameter[] sqlParameters)
        {
            if ((procedureName == null) || (procedureName.Length == 0))
            {
                throw new ArgumentNullException("procedureName");
            }
            SqlCommand command = new SqlCommand(procedureName);
            command.CommandType = CommandType.StoredProcedure;
            AttachParameters(command, sqlParameters);
            return command;
        }

        protected static void SetOutputValues(SqlParameter[] sqlParameters, DataRow dataRow)
        {
            if ((sqlParameters != null) && (dataRow != null))
            {
                foreach (SqlParameter param in sqlParameters)
                {
                    if ((param.ParameterName == null) || (param.ParameterName.Length <= 1))
                    {
                        throw new Exception("Please provide all valid parameter name");
                    }
                    if ((dataRow.Table.Columns.IndexOf(param.ParameterName.Substring(1)) != -1) && (param.Direction == ParameterDirection.Output))
                    {
                        dataRow[param.ParameterName.Substring(1)] = param.Value;
                    }
                }
            }
        }

        protected static void SetParameterValues(SqlParameter[] sqlParameters, DataRow dataRow)
        {
            if ((sqlParameters != null) && (dataRow != null))
            {
                foreach (SqlParameter param in sqlParameters)
                {
                    if ((param.ParameterName == null) || (param.ParameterName.Length <= 1))
                    {
                        throw new Exception("Please provide all valid parameter name");
                    }
                    if (dataRow.Table.Columns.IndexOf(param.ParameterName.Substring(1)) != -1)
                    {
                        param.Value = dataRow[param.ParameterName.Substring(1)];
                    }
                }
            }
        }

        protected static SqlParameter CreateSqlPrameter(string parameterName, SqlDbType dbType, int size, ParameterDirection direction)
        {
            SqlParameter parameter = new SqlParameter(parameterName, dbType, size);
            parameter.Direction = direction;
            return parameter;
        }

        protected static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery((SqlConnection)null, commandText, null);
        }

        protected static int ExecuteNonQuery(SqlTransaction sqlTransaction, string commandText)
        {
            return ExecuteNonQuery(sqlTransaction, commandText, null);
        }

        protected static int ExecuteNonQuery(string commandText, SqlParameter[] sqlParameters)
        {
            return ExecuteNonQuery((SqlConnection)null, commandText, sqlParameters);
        }

        protected static int ExecuteNonQuery(SqlConnection conn, string commandText, SqlParameter[] sqlParameters)
        {
            int num;
            SqlCommand command = PrepareCommand(commandText, sqlParameters);
            bool flag = conn == null;
            try
            {
                OpenConnection(ref conn);
                command.Connection = conn;
                num = command.ExecuteNonQuery();
            }
            finally
            {
                command.Parameters.Clear();
                if (command != null)
                {
                    command.Dispose();
                }
                if ((flag && (conn != null)) && (conn.State != ConnectionState.Closed))
                {
                    conn.Close();
                }
            }
            return num;
        }

        protected static int ExecuteNonQuery(SqlTransaction sqlTransaction, string commandText, SqlParameter[] sqlParameters)
        {
            SqlConnection openConnection = null;
            int num;
            SqlCommand command = PrepareCommand(commandText, sqlParameters);
            bool flag = sqlTransaction == null;
            try
            {
                openConnection = OpenConnection(sqlTransaction);
                command.Connection = openConnection;
                if (!flag)
                {
                    command.Transaction = sqlTransaction;
                }
                num = command.ExecuteNonQuery();
            }
            finally
            {
                command.Parameters.Clear();
                if (command != null)
                {
                    command.Dispose();
                }
                if ((flag && (openConnection != null)) && (openConnection.State != ConnectionState.Closed))
                {
                    openConnection.Close();
                }
            }
            return num;
        }

        protected static DataSet ExecuteQuery(string commandText)
        {
            return ExecuteQuery((SqlConnection)null, commandText, null);
        }

        protected static DataSet ExecuteQuery(SqlTransaction mySqlTransaction, string commandText)
        {
            return ExecuteQuery(mySqlTransaction, commandText, null);
        }

        protected static DataSet ExecuteQuery(string commandText, SqlParameter[] mySqlParameters)
        {
            return ExecuteQuery((SqlConnection)null, commandText, mySqlParameters);
        }

        protected static DataSet ExecuteQuery(SqlConnection conn, string commandText, SqlParameter[] sqlParameters)
        {
            DataSet ds;
            SqlCommand command = PrepareCommand(commandText, sqlParameters);
            bool flag = conn == null;
            try
            {
                OpenConnection(ref conn);
                command.Connection = conn;
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }
                ds = dataSet;
            }
            finally
            {
                command.Parameters.Clear();
                if (command != null)
                {
                    command.Dispose();
                }
                if ((flag && (conn != null)) && (conn.State != ConnectionState.Closed))
                {
                    conn.Close();
                }
            }
            return ds;
        }

        protected static DataSet ExecuteQuery(SqlTransaction sqlTransaction, string commandText, SqlParameter[] sqlParameters)
        {
            SqlConnection openConnection = null;
            DataSet ds;
            SqlCommand command = PrepareCommand(commandText, sqlParameters);
            bool flag = sqlTransaction == null;
            try
            {
                openConnection = OpenConnection(sqlTransaction);
                command.Connection = openConnection;
                if (!flag)
                {
                    command.Transaction = sqlTransaction;
                }
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }
                ds = dataSet;
            }
            finally
            {
                command.Parameters.Clear();
                if (command != null)
                {
                    command.Dispose();
                }
                if ((flag && (openConnection != null)) && (openConnection.State != ConnectionState.Closed))
                {
                    openConnection.Close();
                }
            }
            return ds;
        }

        protected static DataSet ExecuteProcedure(string procedureName)
        {
            return ExecuteProcedure((SqlConnection)null, procedureName, null);
        }

        protected static DataSet ExecuteProcedure(SqlTransaction mySqlTransaction, string procedureName)
        {
            return ExecuteProcedure(mySqlTransaction, procedureName, null);
        }

        protected static DataSet ExecuteProcedure(string procedureName, SqlParameter[] mySqlParameters)
        {
            return ExecuteProcedure((SqlConnection)null, procedureName, mySqlParameters);
        }

        protected static DataSet ExecuteProcedure(SqlConnection conn, string procedureName, SqlParameter[] sqlParameters)
        {
            DataSet ds;
            SqlCommand procedureCommand = PrepareProcedure(procedureName, sqlParameters);
            bool flag = conn == null;
            try
            {
                OpenConnection(ref conn);
                procedureCommand.Connection = conn;
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(procedureCommand))
                {
                    adapter.Fill(dataSet);
                }
                ds = dataSet;
            }
            finally
            {
                procedureCommand.Parameters.Clear();
                if (procedureCommand != null)
                {
                    procedureCommand.Dispose();
                }
                if ((flag && (conn != null)) && (conn.State != ConnectionState.Closed))
                {
                    conn.Close();
                }
            }
            return ds;
        }

        protected static DataSet ExecuteProcedure(SqlTransaction sqlTransaction, string procedureName, SqlParameter[] sqlParameters)
        {
            SqlConnection openConnection = null;
            DataSet ds;
            SqlCommand command = PrepareProcedure(procedureName, sqlParameters);
            bool flag = sqlTransaction == null;
            try
            {
                openConnection = OpenConnection(sqlTransaction);
                command.Connection = openConnection;
                if (!flag)
                {
                    command.Transaction = sqlTransaction;
                }
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }
                ds = dataSet;
            }
            finally
            {
                command.Parameters.Clear();
                if (command != null)
                {
                    command.Dispose();
                }
                if ((flag && (openConnection != null)) && (openConnection.State != ConnectionState.Closed))
                {
                    openConnection.Close();
                }
            }
            return ds;
        }

        protected static int ExecuteProcedureNonQuery(string procedureName)
        {
            return ExecuteProcedureNonQuery((SqlConnection)null, procedureName, null);
        }

        protected static int ExecuteProcedureNonQuery(SqlTransaction sqlTransaction, string procedureName)
        {
            return ExecuteProcedureNonQuery(sqlTransaction, procedureName, null);
        }

        protected static int ExecuteProcedureNonQuery(string procedureName, SqlParameter[] sqlParameters)
        {
            return ExecuteProcedureNonQuery((SqlConnection)null, procedureName, sqlParameters);
        }

        protected static int ExecuteProcedureNonQuery(SqlConnection conn, string procedureName, SqlParameter[] sqlParameters)
        {
            int num;
            SqlCommand procedureCommand = PrepareProcedure(procedureName, sqlParameters);
            bool flag = conn == null;
            try
            {
                OpenConnection(ref conn);
                procedureCommand.Connection = conn;
                num = procedureCommand.ExecuteNonQuery();
            }
            finally
            {
                procedureCommand.Parameters.Clear();
                if (procedureCommand != null)
                {
                    procedureCommand.Dispose();
                }
                if ((flag && (conn != null)) && (conn.State != ConnectionState.Closed))
                {
                    conn.Close();
                }
            }
            return num;
        }

        protected static int ExecuteProcedureNonQuery(SqlTransaction sqlTransaction, string procedureName, SqlParameter[] sqlParameters)
        {
            SqlConnection openConnection = null;
            int num;
            SqlCommand procedureCommand = PrepareProcedure(procedureName, sqlParameters);
            bool flag = sqlTransaction == null;
            try
            {
                openConnection = OpenConnection(sqlTransaction);
                procedureCommand.Connection = openConnection;
                if (!flag)
                {
                    procedureCommand.Transaction = sqlTransaction;
                }
                num = procedureCommand.ExecuteNonQuery();
            }
            finally
            {
                procedureCommand.Parameters.Clear();
                if (procedureCommand != null)
                {
                    procedureCommand.Dispose();
                }
                if ((flag && (openConnection != null)) && (openConnection.State != ConnectionState.Closed))
                {
                    openConnection.Close();
                }
            }
            return num;
        }
    }
}