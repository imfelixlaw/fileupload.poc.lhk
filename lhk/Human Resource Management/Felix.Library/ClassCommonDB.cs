/* Function List
 * ==============
 * Felix.Library.Common.DB
 *      CommonDB(string connstr, string ip, bool boolPing);
 *      TryConnection();
 *      MySQLClose();
 *      MySQLExecuteReader(String SQL);
 *      MySQLExecuteNonQuery(string SQL);
 *      MySQLNumRows(string SQL);
 *      SafeSQL(string var);
 *      ProcessSQLFile(string filename);
 */

using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using Felix.Library.Common.Network;

namespace Felix.Library.Common.DB
{
    public class CommonDB : CommonNetwork
    {
        private bool LHKDB = false, _PingOnConnect = false;
        //private CommonNetwork COMMONNETWORK = new CommonNetwork();
        private static MySqlConnection _conn = null;
        private static MySqlCommand _cmd = null;
        private string _ip = null;
        //private MySqlDataReader DataReader = null; // Remove due to protection
        private MySqlScript ms = null;

        /// <summary>
        /// create object
        /// </summary>
        /// <param name="connstr">connection string</param>
        /// <param name="ip">ip</param>
        /// <param name="boolPing">ping ip</param>
        public CommonDB(string connstr, string ip = null, bool boolPing = false)
        {
            try
            {
                _PingOnConnect = boolPing;
                _ip = ip;
                if (_PingOnConnect && _ip != null) { if (!PingTest(_ip)) { throw new Exception("MySQL Error(s) :: DB _connection Error"); } }
                if (string.IsNullOrEmpty(connstr)) { throw new Exception("MySQL Error(s) :: Connection string is empty..."); }
                _conn = new MySqlConnection(connstr);
                _cmd = new MySqlCommand();
                _cmd = _conn.CreateCommand(); // create sql _conn cmd
                _cmd.CommandTimeout = 0;
                LHKDB = true; // init this class is success
            }
            catch (Exception ex) { throw new Exception("MySQL Error(s) :: " + ex.Message); } // operation fail
        }

        /// <summary>
        /// try connect
        /// </summary>
        public bool TryConnection()
        {
            try
            {
                if (!LHKDB) { throw new Exception("MySQL Error(s) :: Class not initialized"); }
                if (_conn.State == ConnectionState.Open) { MySQLClose(); } // Dispose the _connection
                _conn.Open();
                _conn.Close();
                return true;
            }
            catch { return false; } // operation fail
        
        }

        /// <summary>
        /// Close MySQL _connection
        /// </summary>
        public void MySQLClose()
        {
            try
            {
                if (!LHKDB) { throw new Exception("Class not initialized"); }
                if (_conn.State == ConnectionState.Open) { _conn.Close(); _conn.Dispose(); } // validate _connection
            }
            catch (Exception ex) { throw new Exception("MySQL Error(s) :: " + ex.Message); } // operation fail
        }

        /// <summary>
        /// Execute MySQL Command with Reader return
        /// </summary>
        /// <param name="SQL">SQL Query</param>
        /// <returns>Reader results</returns>
        public MySqlDataReader MySQLExecuteReader(String SQL)
        {
            try
            {
                if (!LHKDB) { throw new Exception("MySQL Error(s) :: Class not initialized"); }
                if (_PingOnConnect && _ip != null) { if (!PingTest(_ip)) { throw new Exception("MySQL Error(s) :: DB Connection Error"); } }
                if (_conn.State == ConnectionState.Open) { MySQLClose(); } // Dispose the _connection
                _conn.Open(); // open again
                _cmd.CommandText = SQL; // store sql query
                return _cmd.ExecuteReader(); // execute and return result
            }
            catch (Exception ex) { throw new Exception("MySQL Error(s) :: " + ex.Message); } // operation fail
        }

        /// <summary>
        /// Execute MySQL Command
        /// </summary>
        /// <param name="SQL">SQL Query</param>
        /// <returns>true = success, false = fail or no field affected</returns>
        public bool MySQLExecuteNonQuery(string SQL)
        {
            try
            {
                if (!LHKDB) { return false; } // operation fail
                if (_PingOnConnect && _ip != null) { if (!PingTest(_ip)) { throw new Exception("MySQL Error(s) :: DB Connection Error"); } }
                if (_conn.State == ConnectionState.Open) { MySQLClose(); }// Dispose the _connection
                _conn.Open(); // open again
                _cmd.CommandText = SQL; // store sql query
                return (_cmd.ExecuteNonQuery() > 0) ? true : false; // execute query
            }
            catch { return false; } // operation fail
        }

        /// <summary>
        /// number of row
        /// </summary>
        /// <param name="SQL">sql string</param>
        /// <param name="_SafeSQL">sql filter</param>
        /// <returns></returns>
        public int MySQLNumRows(string SQL)
        {
            try
            {
                if (!LHKDB) { throw new Exception("MySQL Error(s) :: Class not initialized"); }
                if (_PingOnConnect && _ip != null) { if (!PingTest(_ip)) { throw new Exception("MySQL Error(s) :: DB Connection Error"); } }
                if (_conn.State == ConnectionState.Open) { MySQLClose(); } // Dispose the _connection
                int numRows = 0;
                _conn.Open(); // open again
                _cmd.CommandText = SQL; // store sql query
                while (_cmd.ExecuteReader().Read()) { numRows++; }
                MySQLClose();
                return numRows;
            }
            catch { return 0; }
        }

        /// <summary>
        /// Protect from Injection
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        public string SafeSQL(string var)
        {
            var = var.Replace("'", "");
            var = var.Replace("\"", "");
            var = var.Replace("\'", "");
            var = var.Replace("/*", "");
            var = var.Replace("*/", "");
            var = var.Replace("--", ""); // did not using --
            var = var.Replace("[", "");
            var = var.Replace("]", "");
            var = var.Replace("%", "");
            var = var.Replace(" OR ", " "); // did not using OR
            var = var.Replace(" SET ", " "); // did not using OR
            var = var.Replace(" DROP ", " "); // did not using DROP;
            return var;
        }

        /// <summary>
        /// parse sql file
        /// </summary>
        /// <param name="filename">sql filename</param>
        public void ProcessSQLFile(string filename)
        {
            try
            {
                if (!LHKDB) { throw new Exception("MySQL Error(s) :: Class not initialized"); }
                if (_conn.State == ConnectionState.Open) { _conn.Close(); _conn.Dispose(); } // validate _connection
                if (string.IsNullOrEmpty(filename)) { throw new Exception("MySQL Error(s) :: SQL File not specific"); }
                ms = new MySqlScript(_conn, File.ReadAllText(filename));
                ms.Delimiter = ";";
                ms.Execute();
            }
            catch (Exception ex) { throw new Exception("MySQL Error(s) :: " + ex.Message); }
        }
    }
}
