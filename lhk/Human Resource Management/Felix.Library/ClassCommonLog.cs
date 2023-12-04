using System;
using System.IO;
using System.Configuration;
using Felix.Library.Common;
using Felix.Library.Common.OSInfo;

namespace Felix.Library.Common.Log
{
    public class CommonLog : CommonOSInfo
    {
        // Variable -- start
        // Please don't change this section if you not sure what is it, TQ.
        private StreamWriter LogFileWriter = null; // Log File
        private string LogFilePath = null; // Log file Path
        private bool ClassInit = false, // if this class had been initialized
            DebugMode = false, // if is debug mode on
            ErrorMode = false, // if is error mode on
            WriteToFile = false; // if enable to writing log file
        private string NormalHeader { get { return null; } } // Error Header
        private string ErrorHeader { get { return "[Error] "; } } // Error Header
        private string DebugHeader { get { return "[Debug] "; } } // Debug Header
        private static int Error { get { return 1; } } // error code
        private static int Debug { get { return 2; } } // debug code

        // User changable section, change only if you know what it mean
        private bool EnvironmentData = true; // store environment data if on
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
        public CommonLog(bool _error, bool _debug, bool _writeFile, string _logPath = null)
        {
            this.DebugMode = _debug; // set debug mode
            this.ErrorMode = _error; // set error mode
            this.WriteToFile = _writeFile; // set write to file mode
            this.ClassInit = true; // initialize this class
            this.LogFilePath = (!string.IsNullOrEmpty(_logPath)) ? Directory.GetCurrentDirectory() + "\\" + _logPath + "\\" : Directory.GetCurrentDirectory() + "\\Logs\\"; // setting the log folder if provided
            this.Log("Log Function is initialized", Debug); // initialize messege
            if (EnvironmentData)
            {
                this.Log(@"Environment checking", Debug);
                this.Log(@"Machine name : " + Environment.MachineName, Debug);
                this.Log(@"Domain name : " + Environment.UserDomainName, Debug);
                this.Log(@"User name : " + Environment.UserName, Debug);
                this.Log(@"Operating System : " + getOSInfo(), Debug);
            } // return running environment data
        }

        /// <summary>
        /// Log class
        /// </summary>
        /// <param name="log">log message</param>
        /// <param name="mode">log mode</param>
        /// <returns>formatted log message</returns>
        public string Log(string log, int mode = 0)
        {
            if (!ClassInit) { return null; } // if class is not initialize
            try
            {
                string FormattedLog = null;
                switch (mode)
                {
                    case 1: if (ErrorMode) { FormattedLog = string.Format(this.LogEntry, this.ErrorHeader, log); } break; // select error mode, if error mode off, error message will be drop
                    case 2: if (DebugMode) { FormattedLog = string.Format(this.LogEntry, this.DebugHeader, log); } break; // select debug mode, if debug mode off, debug message will be drop
                    default: FormattedLog = string.Format(this.LogEntry, this.NormalHeader, log); break; // normal message
                }
                if (this.WriteToFile && !string.IsNullOrEmpty(FormattedLog)) { this.LogWriter(FormattedLog); } // if write to file is on and formatted log is not null, write to log file
                return FormattedLog;
            }
            catch { return null; } // operation fail
        }

        /// <summary>
        /// log writer to file
        /// </summary>
        /// <param name="LogEntry">Formatted log</param>
        private void LogWriter(string LogEntry)
        {
            try
            {
                if (!Directory.Exists(this.LogFilePath)) { Directory.CreateDirectory(this.LogFilePath); } // check folder exists, if not create new folder
                this.LogFileWriter = (!File.Exists(this.LogFile())) ? new StreamWriter(this.LogFile()) : File.AppendText(this.LogFile()); // check file exist, if no create new file, if yes append to file
                LogFileWriter.Write(LogEntry); // write to file
                LogFileWriter.Close(); // close file
            }
            catch { this.WriteToFile = false; } // disable write to file when LogWriter having error
        }

        /// <summary>
        /// Get Log File Path
        /// </summary>
        /// <returns>if class is initialize return Log File Path or throw exception</returns>
        private string LogFileDirectory() { if (ClassInit) { return this.LogFilePath; } else { throw new Exception("Class had not been initialized"); } }

        /// <summary>
        /// Get Log File Path and Name
        /// </summary>
        /// <returns>if class is initialize return Log File Path and Log File Name or throw exception</returns>
        private string LogFile() { if (ClassInit) { return this.LogFilePath + this.LogFileName; } else { throw new Exception("Class had not been initialized"); } }
    }
}
