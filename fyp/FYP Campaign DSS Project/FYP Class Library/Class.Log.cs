using System;
using FYP.Library.Common;

namespace FYP.Library.Log
{
    class LibLog
    {
        // Variable -- start
        private CommonFunction CF = new CommonFunction();
        // Please don't change this section if you not sure what is it, TQ.
        private string LogFilePath = null; // Log file Path
        private bool ClassInit = false, // if this class had been initialized
            DebugMode = false, // if is debug mode on
            ErrorMode = false, // if is error mode on
            WriteToFile = false; // if enable to writing log file

        public static int Error { get { return 1; } } // error code
        public static int Debug { get { return 2; } } // debug code

        // User changable section, change only if you know what it mean
        private string LogEntry = "[" + DateTime.Now.ToString() + "] {0}{1}..." + Environment.NewLine, // Log Format
            LogFileName = "Log-" + DateTime.Now.ToString("yyyyMMdd") + ".txt"; // Log file Name
        // Variable -- end

        /// <summary>
        /// Log Initialization
        /// </summary>
        /// <param name="_error">Error Mode On?</param>
        /// <param name="_debug">Debug Mode On?</param>
        /// <param name="_writeFile">Write to log file?</param>
        /// <param name="_logPath">set log folder</param>
        public LibLog(bool _error, bool _debug, bool _writeFile, string _logPath = null, bool enable = true)
        {
            try
            {
                if (!enable) { return; } // if the LogFunction is not enabled
                this.DebugMode = _debug; // set debug mode
                this.ErrorMode = _error; // set error mode
                this.WriteToFile = _writeFile; // set write to file mode
                this.ClassInit = true; // initialize this class
                this.LogFilePath = (!string.IsNullOrEmpty(_logPath)) ? CF.AppPath() + "\\" + _logPath + "\\" : CF.AppPath() + "\\Logs\\"; // setting the log folder if provided
                this.Message("Log Function is initialized", Debug); // initialize messege
                // return running environment data
                this.Message(@"Environment checking", Debug);
                this.Message("Machine name : " + Environment.MachineName, Debug);
                this.Message("Domain name : " + Environment.UserDomainName, Debug);
                this.Message("User name : " + Environment.UserName, Debug);
                this.Message("Operating System : " + new CommonOSInfo().getOSInfo(), Debug);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

                /// <summary>
        /// Log class
        /// </summary>
        /// <param name="log">log message</param>
        /// <param name="mode">log mode</param>
        /// <returns>formatted log message</returns>
        public string Message(string log, int mode = 0)
        {
            try
            {
                if (!ClassInit) { throw new Exception("Class not initialized"); } // if class is not initialize
                string Formatted = null;
                switch (mode)
                {
                    case 1:
                        // select error mode, if error mode off, error message will be drop
                        Formatted = (ErrorMode) ? string.Format(this.LogEntry, "[Error] ", log) : null;
                        break;
                    case 2:
                        // select debug mode, if debug mode off, debug message will be drop
                        Formatted = (DebugMode) ? string.Format(this.LogEntry, "[Debug] ", log) : null;
                        break;
                    default:
                        // normal message
                        Formatted = string.Format(this.LogEntry, null, log);
                        break;
                }
                if (this.WriteToFile && !string.IsNullOrEmpty(Formatted)) // if write to file is on and formatted log is not null, write to log file
                {
                    this.LogWriter(Formatted);

                }
                return Formatted;
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // operation fail
        }

        /// <summary>
        /// log writer to file
        /// </summary>
        /// <param name="LogEntry">Formatted log</param>
        private void LogWriter(string LogEntry)
        {
            try
            {
                if (!ClassInit) { throw new Exception("Class not initialized"); }
                CommonFileOperation FO = new CommonFileOperation();
                if (!FO.FolderExist(this.LogFileDirectory())) // check folder exists, if not create new folder
                {
                    FO.CreateFolder(this.LogFileDirectory());
                }
                if (!FO.FileExist(this.LogFile())) // check file exist if not exist create new file
                {
                    FO.CreateTextFile(this.LogFile());
                } 
                FO.TextFileWriter(this.LogFile(), LogEntry, true);
            }
            catch (Exception ex) { this.WriteToFile = false; throw new Exception(ex.Message); } // disable write to file when LogWriter having error
        }

        /// <summary>
        /// Get Log File Path
        /// </summary>
        /// <returns>if class is initialize return Log File Path or throw exception</returns>
        /// 
        private string LogFileDirectory()
        {
            try
            {
                if (!ClassInit) { throw new Exception("Class not initialized"); }
                return this.LogFilePath;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Get Log File Path and Name
        /// </summary>
        /// <returns>if class is initialize return Log File Path and Log File Name or throw exception</returns>
        private string LogFile()
        {
            try
            {
                if (!ClassInit) { throw new Exception("Class not initialized"); }
                return this.LogFilePath + this.LogFileName;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
