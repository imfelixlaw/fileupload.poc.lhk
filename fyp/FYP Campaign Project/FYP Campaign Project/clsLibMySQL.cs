using System;
using MySql.Data.MySqlClient;

namespace ClassMySQLFunction
{
    /// <summary>
    /// MySQL Function - 2012-01-05
    /// Revision: 1.0
    /// Build: 38 - 2012-01-30
    /// </summary>
    class ClassMySQL
    {
        private static MySqlConnection myConnection;
        private static MySqlCommand myCommand;
        private bool MySQL_init = false;

        /// <summary>
        /// Close MySQL Connection
        /// </summary>
        public void MySQLClose()
        {
            if (MySQL_init)
            {
                try
                {
                    myConnection.Close();
                    myConnection.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else throw new Exception("Class not initialized");
        }

        /// <summary>
        /// Setting connection string
        /// </summary>
        /// <param name="ConnStr">connection string</param>
        public void SetMySQLConnString(string ConnStr)
        {
            try
            {
                if (myConnection != null) MySQLClose(); // Dispose the connection
                myConnection = new MySqlConnection(ConnStr); // init mysql conn
                myCommand = myConnection.CreateCommand(); // create sql conn cmd
                MySQL_init = true; // init this class is success
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Execute MySQL Command with Reader return
        /// </summary>
        /// <param name="SQL">SQL Query</param>
        /// <returns>Reader results</returns>
        public MySqlDataReader MySQLExecuteReader(String SQL)
        {
            if (MySQL_init)
            {
                try
                {
                    if (myConnection != null) MySQLClose(); // Dispose the connection
                    myConnection.Open(); // open again
                    myCommand.CommandText = SQL; // store sql query
                    return myCommand.ExecuteReader(); // execute and return result
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else throw new Exception("Class not initialized");
        }

        /// <summary>
        /// Execute MySQL Command
        /// </summary>
        /// <param name="SQL">SQL Query</param>
        public void MySQLExecuteNonQuery(string SQL)
        {
            if (MySQL_init)
            {
                try
                {
                    if (myConnection != null) MySQLClose(); // Dispose the connection
                    myConnection.Open(); // open again
                    myCommand.CommandText = SQL; // store sql query
                    myCommand.ExecuteNonQuery(); // execute query
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else throw new Exception("Class not initialized");
        }
    }
}
