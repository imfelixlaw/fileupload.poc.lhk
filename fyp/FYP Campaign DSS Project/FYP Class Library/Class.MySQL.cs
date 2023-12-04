using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace FYP.Library.MySQL
{
    class LibMySQL
    {
        private MySqlConnection conn = null;
        private bool MySQL_init = false;
        public MySqlDataReader MySQLDR = null;

        /// <summary>
        /// Close MySQL Connection
        /// </summary>
        public void MySQLClose()
        {
            if (!MySQL_init) { throw new Exception("Class not initialized"); }
            try
            {
                if (conn.State == ConnectionState.Open) // validate connection
                {
                    conn.Close(); // Dispose the connection
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
                if (conn.State == ConnectionState.Open) { MySQLClose(); } // Dispose the connection
                conn = new MySqlConnection(ConnStr); // init mysql conn
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
                if (conn.State == ConnectionState.Open) { MySQLClose(); } // Dispose the connection
                conn.Open(); // open again
                MySqlCommand cmd = conn.CreateCommand(); // create sql conn cmd
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
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
                if (conn.State == ConnectionState.Open) { MySQLClose(); }// Dispose the connection
                conn.Open(); // open again
                MySqlCommand cmd = conn.CreateCommand(); // create sql conn cmd
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                cmd.CommandText = SQL; // store sql query
                cmd.ExecuteNonQuery(); // execute query
                return true; // operation success
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // operation fail
        }

        /// <summary>
        /// Protect from Injection
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        public string SafeSQL(string var)
        {
            try
            {
                if (!MySQL_init) { throw new Exception("Class not initialized"); }
                string[] match = { "'", "\"", "\'", "/*", "*/", "--", "[", "]", "%", "OR", "SET", "DROP" };
                foreach (string m in match)
                {
                    var = var.Replace(m, string.Empty);
                }
                return var;
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // operation fail
        }
    }
}
