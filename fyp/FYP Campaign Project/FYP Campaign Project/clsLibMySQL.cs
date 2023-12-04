using System;
using MySql.Data.MySqlClient;

namespace ClassLibMySQL
{
    /// <summary>
    /// Simplified the sql process
    /// Guide from msdn library and mysql community
    /// MySQL Function - 2012-01-05
    /// Revision: 1.0
    /// Build: 41 - 2012-01-30
    /// </summary>
    class ClassMySQL
    {
        private static MySqlConnection conn = null;
        private static MySqlCommand cmd = null;
        private bool MySQL_init = false;

        /// <summary>
        /// Close MySQL Connection
        /// </summary>
        public void MySQLClose()
        {
            if (!MySQL_init) { throw new Exception("Class not initialized"); }
            try
            {
                if (conn != null) // validate connection
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // operation fail
        }

        /// <summary>
        /// Setting connection string
        /// </summary>
        /// <param name="ConnStr">connection string</param>
        public void SetMySQLConnString(string ConnStr)
        {
            try
            {
                if (conn != null) { MySQLClose(); } // Dispose the connection
                conn = new MySqlConnection(ConnStr); // init mysql conn
                cmd = conn.CreateCommand(); // create sql conn cmd
                MySQL_init = true; // init this class is success
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // operation fail
        }

        /// <summary>
        /// Execute MySQL Command with Reader return
        /// </summary>
        /// <param name="SQL">SQL Query</param>
        /// <returns>Reader results</returns>
        public MySqlDataReader MySQLExecuteReader(String SQL)
        {
            if (!MySQL_init) { throw new Exception("Class not initialized"); }
            try
            {
                if (conn != null) { MySQLClose(); } // Dispose the connection
                conn.Open(); // open again
                cmd.CommandText = SQL; // store sql query
                return cmd.ExecuteReader(); // execute and return result
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // operation fail
        }

        /// <summary>
        /// Execute MySQL Command
        /// </summary>
        /// <param name="SQL">SQL Query</param>
        /// <returns>true = success, false = fail</returns>
        public bool MySQLExecuteNonQuery(string SQL)
        {
            if (!MySQL_init) { throw new Exception("Class not initialized"); }
            try
            {
                if (conn != null) { MySQLClose(); }// Dispose the connection
                conn.Open(); // open again
                cmd.CommandText = SQL; // store sql query
                cmd.ExecuteNonQuery(); // execute query
                return true; // operation success
            }
            catch { return false; } // operation fail
        }
    }
}
