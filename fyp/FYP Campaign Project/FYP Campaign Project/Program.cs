using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using ClassLibEncryption; // Encryption Lib
using ClassLibLog; // Log Lib
using ClassLibGenericFunction; // Generic Function Lib
using MySql.Data.MySqlClient; // MySQL Lib
using ClassLibMySQL; // Self define MySQL Lib
using classLibIniParser; // ini file parser

namespace FYP_Campaign_Project
{
    static class Program
    {
        // constant -- start
        public const int _CONST_MinAuthenticationChar = 5, // Minimal username / password length
            _CONST_DISABLED = 0, // Disable
            _CONST_Permission_ADMIN = 127, // Permission ADMIN
            _CONST_Permission_OWNER = 2, // Permission OWNER
            _CONST_Permission_READWRITE = 1, // Permission READWRITE
            _CONST_Permission_READ = 0, // Permission READ
            _CONST_Permission_DISABLED = 0; // Permission DISABLED
        public const string _CONST_UserStatus_ACTIVE = "Y", // Active User
            _CONST_UserStatus_DEACTIVE = "N"; // Deactive User
        // constant -- end

        // variable -- start
        public static int _LoginFailLimit = 3, // login fail limit, default is 3, read from config file later
            _LoginFailBlock = 15, // login fail block time
            __UserID = _CONST_DISABLED, // default id
            __UserPermission = _CONST_Permission_DISABLED; // default user id 0 is mean disabled users

        private static string[] args = Environment.GetCommandLineArgs(); // program arguement, use if in-case of

        public static string __UserStatus = "N", // default user status is not accessible
            _log_WritePath = "Logs"; // default Log Path

        private static bool _log_Enable = false, // enable logfile
            _log_DebugMode = false, // debug mode is here
            _log_ErrorMode = false,
            _log_WriteFile = false,// error mode is here
            _arg_is_set = false, // set if arg is set
            _arg_load_extra = false, // -l arguement, load extra project
            _arg_crypt = false; // crypt arguement
        
        public static MySqlDataReader myReader; // MySQL Reader
        public static ClassMySQL _MySQL = new ClassMySQL(); // new MySQL function
        public static LogFunction _WriteToLog; // Log function, init later.
        public static classFunction _Func = new classFunction(); // generic function
        public static ProtectionMethod _Crypto = new ProtectionMethod("this_is_cutegal88_project"); // set the encryption salt value 
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
                bool confUpdate = false; // update file or not in-case config.ini missing
                IniReader conf = new IniReader("config.ini"),
                        newConf = new IniReader("config.ini"); // in-case config.ini missing
                conf.Read();

                string logOn = conf.Get("log", "enable"); // log enable?
                if (string.IsNullOrEmpty(logOn)) { newConf.Write("log", "enable", _log_Enable.ToString().ToLower()); confUpdate = true; } else { _log_Enable = conf.DetermineBool(logOn); }

                string logDebug = conf.Get("log", "debug"); // debug message or not?
                if (string.IsNullOrEmpty(logDebug)) { newConf.Write("log", "debug", _log_DebugMode.ToString().ToLower()); confUpdate = true; } else { _log_DebugMode = conf.DetermineBool(logDebug); }

                string logError = conf.Get("log", "error"); // error message or not?
                if (string.IsNullOrEmpty(logDebug)) { newConf.Write("log", "error", _log_ErrorMode.ToString().ToLower()); confUpdate = true; } else { _log_ErrorMode = conf.DetermineBool(logError); }

                string logToFile = conf.Get("log", "writefile"); // write to log file or not?
                if (string.IsNullOrEmpty(logToFile)) { newConf.Write("log", "writefile", _log_WriteFile.ToString().ToLower()); confUpdate = true; } else { _log_WriteFile = conf.DetermineBool(logToFile); }
                
                string logToPath = conf.Get("log", "writepath"); // log file path?
                if (string.IsNullOrEmpty(logToPath)) { newConf.Write("log", "writepath", _log_WritePath); confUpdate = true; } else { _log_WritePath = logToPath; }

                string loginLimit = conf.Get("login", "limit"); // login limit?
                if (string.IsNullOrEmpty(loginLimit)) { newConf.Write("login", "limit", _LoginFailLimit.ToString()); confUpdate = true; } else { _LoginFailLimit = (conf.DetermineNumeric(loginLimit)) ? Convert.ToInt32(loginLimit) : 3; } // if is valid, give the var, or give 3 as default

                string loginBlock = conf.Get("login", "block"); // login limit?
                if (string.IsNullOrEmpty(loginBlock)) { newConf.Write("login", "block", _LoginFailBlock.ToString()); confUpdate = true; } else { _LoginFailBlock = (conf.DetermineNumeric(loginBlock)) ? Convert.ToInt32(loginBlock) : 15; } // if is valid, give the var, or give 15 as default
                if (_LoginFailBlock < 15 || _LoginFailBlock > 60) { _LoginFailBlock = 15; } // time block (in minutes) if exceed fail login limit, minimal value = 15, maximun value = 60, exceed the limit will default as 15

                if (confUpdate) { newConf.Save(); } // in-case config.ini missing
                

                // Log Function -- Start | with error on, debug off, write file on, self define log folder, log on/off
                _WriteToLog = new LogFunction(_log_ErrorMode, _log_DebugMode, _log_WriteFile, _log_WritePath, _log_Enable);
                
                // -- validate app.config
                // Check if already run if ady run throw it away
                if (_Func.MultipleInstanceExist()) { throw new Exception("Another instance is already running."); }
                if (!File.Exists(Process.GetCurrentProcess().ProcessName + ".exe.config")) { throw new Exception("Configuration file is missing, please reinstall this application."); }
                // Log Function -- End
                // Read the mode from config -- end

                foreach (string arg in args) // fetch the arguement
                {
                    switch (_Func.StringToLower(arg))
                    {
                        // core arguement
                        case "-l": case "-load": _arg_load_extra = true; break; // got load extra ady
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
                    if (_Func.ping(_Crypto.Decrypt(Properties.Settings.Default.MySQL_Host)))
                    {
                        // Only Create Command when connection OK
                        _WriteToLog.Log("MySQL Server Ping OK", LogFunction.Debug);
                        //MySQL connection string -- start
                        MessageBox.Show(_Crypto.Decrypt(Properties.Settings.Default.MySQL_Password));
                        _MySQL.SetMySQLConnString(string.Format("SERVER={0}; DATABASE={1}; UID={2}; PASSWORD={3}; respect binary flags=false;", _Crypto.Decrypt(Properties.Settings.Default.MySQL_Host), Properties.Settings.Default.MySQL_Table, _Crypto.Decrypt(Properties.Settings.Default.MySQL_Username), _Crypto.Decrypt(Properties.Settings.Default.MySQL_Password)));
                        // MySQL connection string -- end
                        // Only Working if Connection is OK
                        Application.Run(new frmLogin());
                    }
                    else { throw new Exception("Please checking the configuration file"); } // I'm sorry, cannot proceed anymore
                }
                else
                {
                    if (_arg_crypt) { Application.Run(new frmCrypt()); } // I need the Crypt Form
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
        static void OnProcessExit(object sender, EventArgs e)
        {
            try
            {
                _MySQL.MySQLClose();
                _WriteToLog.Log("Application thread shutdown", LogFunction.Debug);
            }
            catch (Exception ex) { _WriteToLog.Log(ex.Message, LogFunction.Error); } // exit operation will fail also? maybe
        }
    }
}
