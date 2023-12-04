using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

// Encryption Lib
using ClassLibEncryption;
// Log Lib
using ClassLogFunction;
// MySQL
using MySql.Data.MySqlClient;
using ClassMySQLFunction;

namespace FYP_Campaign_Project
{
    static class Program
    {
        // constant -- start
        public const int
            _CONST_MinAuthenticationChar = 5, // Minimal username / password length
            _CONST_Permission_ADMIN = 127, // Permission ADMIN
            _CONST_Permission_OWNER = 2, // Permission OWNER
            _CONST_Permission_READWRITE = 1, // Permission READWRITE
            _CONST_Permission_READ = 0, // Permission READ
            _CONST_DISABLED = 0,
            _CONST_Permission_DISABLED = 0;
        public const string
            _CONST_UserStatus_ACTIVE = "Y",
            _CONST_UserStatus_DEACTIVE = "N";
        // constant -- end

        // variable -- start
        public static int
            _LoginFailLimit = 3, // login fail limit, default is 3, read from config file later
            __UserID = _CONST_Permission_READ,
            __UserPermission = _CONST_Permission_DISABLED; // default user id 0 is mean disabled users

        private static string[] args = Environment.GetCommandLineArgs(); // program arguement, use if in-case of

        public static string
            __UserStatus = "N"; // default user status is not accessible

        public static bool
            _debugMode = false, // debug mode is here
            _errorMode = false, // error mode is here
            _arg_is_set = false, // set if arg is set
            _arg_load_extra = false, // -l arguement, load extra project
            _arg_crypt = false; // crypt arguement

        public static ClassMySQL _MySQL = new ClassMySQL(); // new mysql function
        public static MySqlDataReader myReader;
        public static LogFunction _WriteToLog; // Log function
        public static classFunction _Func = new classFunction(); // generic function
        // variable -- end

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // default application init -- start
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit); // Anything will run on application exit?
                // default application init -- end
                
                // Read the mode from config -- start
                // -- validate app.config
                // Check if already run if ady run throw it away
                if (_Func.PriorProcess() != null) throw new Exception("Another instance is already running.");
                if (!File.Exists(Process.GetCurrentProcess().ProcessName + ".exe.config")) throw new Exception("Configuration file is missing, please reinstall this application.");
                _LoginFailLimit = Properties.Settings.Default.LoginFailLimit;
                ProtectionMethod.PasswordSalt = "this_is_cutegal88_project"; // set the encryption salt value
                // Log Function -- Start | with error on, debug off, write file on, self define log folder
                _WriteToLog = new LogFunction(Properties.Settings.Default.ErrorMode, // Show Error?
                                    Properties.Settings.Default.DebugMode, // Debug?
                                    Properties.Settings.Default.WriteLogFile, // Write to file?
                                    Properties.Settings.Default.LogFilePath); // Log Path
                // Log Function -- End
                // Read the mode from config -- end

                foreach (string arg in args) // fetch the arguement
                {
                    switch (_Func.StringToLower(arg))
                    {
                        // core arguement
                        case "-l": case "-load":
                            _arg_load_extra = true; // got load extra ady
                            break;
                        // 2nd level arguement
                        case "crypt":
                            if (_arg_load_extra)
                            {
                                _arg_crypt = true; // gonna show crypt form
                                _arg_is_set = true; // got arg ady
                            }
                            break;
                    }
                }

                if (!_arg_is_set)
                {
                    // Test ping the Mysql Server IP
                    if (_Func.ping(ProtectionMethod.Decrypt(Properties.Settings.Default.MySQL_Host)))
                    {
                        // Only Create Command when connection OK
                        _WriteToLog.Log("MySQL Server Ping OK", LogFunction.Debug);
                        //MySQL connection string -- start
                        _MySQL.SetMySQLConnString(string.Format("SERVER={0}; DATABASE={1}; UID={2}; PASSWORD={3}; respect binary flags=false;",
                                                    ProtectionMethod.Decrypt(Properties.Settings.Default.MySQL_Host),
                                                    Properties.Settings.Default.MySQL_Table,
                                                    ProtectionMethod.Decrypt(Properties.Settings.Default.MySQL_Username),
                                                    ProtectionMethod.Decrypt(Properties.Settings.Default.MySQL_Password)));
                        // MySQL connection string -- end
                        // Only Working if Connection is OK
                        Application.Run(new frmLogin());
                    }
                    else // I'm sorry, cannot proceed anymore
                        throw new Exception("Please checking the configuration file");
                }
                else
                {
                    if (_arg_crypt) Application.Run(new frmCrypt()); // I need the Crypt Form
                }
            }
            catch (Exception ex)
            {
                _WriteToLog.Log(ex.Message, LogFunction.Error);
                MessageBox.Show(ex.Message);
                Application.Exit(); // Exit this since got error
            }
        }

        /// <summary>
        /// I'm exit, so I need do something before I exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void OnProcessExit(object sender, EventArgs e)
        {
            try
            {
                _MySQL.MySQLClose();
                _WriteToLog.Log("Application thread shutdown", LogFunction.Debug);
            }
            catch (Exception ex)
            {
                _WriteToLog.Log(ex.Message, LogFunction.Error);
            }
        }
    }
}
