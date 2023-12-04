using System;
using System.IO;
using System.Configuration;

namespace ClassLogFunction
{
    /// <summary>
    /// Log Function - 2011-01-11
    /// Revision: 2.0
    /// Build: 80 - 2012-01-29
    /// </summary>
    public class LogFunction
    {
        // Variable -- start
        // Please don't change this section if you not sure what is it, TQ.
        private StreamWriter LogFileWriter; // Log File
        private string
            ErrorHeader = "[Error] ", // Error Header
            DebugHeader = "[Debug] ", // Debug Header
            NormalHeader = null, // Normal Header
            LogFilePath = null; // Log file Path
        private bool
            ClassInit = false, // if this class had been initialized
            DebugMode = false, // if is debug mode on
            ErrorMode = false, // if is error mode on
            WriteToFile = false; // if enable to writing log file
        public const int
            Error = 1, // error code, don't modified this value!
            Debug = 2; // debug code, don't modified this value!
        
        // User changable section, change only if you know what it mean
        public bool EnvironmentData = true; // store environment data if on
        private string
            LogEntry = "[" + DateTime.Now.ToString() + "] {0}{1}..." + Environment.NewLine, // Log Format
            LogFileName = "Log-" + DateTime.Now.ToString("yyyyMMdd") + ".txt"; // Log file Name
        // Variable -- end

        /// <summary>
        /// Log Initialization
        /// </summary>
        /// <param name="_error">Error Mode On?</param>
        /// <param name="_debug">Debug Mode On?</param>
        /// <param name="_writeFile">Write to log file?</param>
        /// <param name="_logPath">set log folder</param>
        public LogFunction(bool _error, bool _debug, bool _writeFile, string _logPath = null)
        {
            // set debug mode
            this.DebugMode = _debug;
            // set error mode
            this.ErrorMode = _error;
            // set write to file mode
            this.WriteToFile = _writeFile;
            // initialize this class
            this.ClassInit = true;
            // setting the log folder if provided
            this.LogFilePath = (!string.IsNullOrEmpty(_logPath)) ? Directory.GetCurrentDirectory() + "\\" + _logPath + "\\" : this.LogFilePath = Directory.GetCurrentDirectory() + "\\Logs\\";
            // initialize messege
            this.Log("Log Function is initialized", Debug);
            if (EnvironmentData)
            {
                this.Log("Environment checking", Debug);
                this.Log("Machine name : " + Environment.MachineName, Debug);
                this.Log("Domain name : " + Environment.UserDomainName, Debug);
                this.Log("User name : " + Environment.UserName, Debug);
                this.Log("Operating System : " + this.getOSInfo(), Debug);
            }
        }

        /// <summary>
        /// Get the OS information
        /// </summary>
        /// <returns>OS Name, version, update pack and architecture</returns>
        private string getOSInfo()
        {
            // Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            // Get version information about the os.
            Version vs = os.Version;
            // Variable to hold our return value
            string strOS = null;
            // windows 9x, non supported running dotnetfx4
            if (os.Platform == PlatformID.Win32Windows)
            {
                // pre-NT version of Windows
                switch (vs.Minor)
                {
                    // windows 95
                    case 0:
                        strOS = "95";
                        break;
                    // windows 98
                    case 10:
                        strOS = (vs.Revision.ToString() == "2222A") ? "98SE" : "98";
                        break;
                    // windows me
                    case 90:
                        strOS = "Me";
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                // NT Platform version of Windows
                switch (vs.Major)
                {
                    // windows nt 3.51
                    case 3:
                        strOS = "NT 3.51";
                        break;
                    // windows nt 4
                    case 4:
                        strOS = "NT 4.0";
                        break;
                    // windows nt 5
                    case 5:
                        // windows 2000
                        if (vs.Minor == 0)
                            strOS = "2000";
                        // windows xp
                        else if (vs.Minor == 1)
                            strOS = "XP";
                        // windows server 2003
                        else if (vs.Minor == 2)
                            strOS = "Server 2003";
                        break;
                    case 6:
                        // windows vista
                        if (vs.Minor == 0)
                            strOS = "Vista";
                        // windows 7
                        else if (vs.Minor == 1)
                            strOS = "7";
                        // windows 8
                        else if (vs.Minor == 2)
                            strOS = "8";
                        break;
                }
            }

            // Make sure we actually got something in our OS check, we don't want to just return " Service Pack 2" that information is useless without the OS version.
            // prepend "Windows" and get more info and check service pack and check windows's bit, append it to the OS name.
            if (!string.IsNullOrEmpty(strOS)) strOS = "Windows " + strOS + " " + ((!string.IsNullOrEmpty(os.ServicePack)) ? os.ServicePack : "") + ((Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") == "AMD64" || Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432") == "AMD64") ? " 64-bit" : " 32-bit");
            // Return the information we've gathered.
            return strOS;
        }

        /// <summary>
        /// Get Log File Path
        /// </summary>
        /// <returns>Log File Path</returns>
        /// 
        private string LogFileDirectory()
        {
            // if class is initialize
            if (ClassInit)
                return this.LogFilePath;
            else
                throw new Exception("Class had not been initialized");
        }

        /// <summary>
        /// Get Log File Path and Name
        /// </summary>
        /// <returns>Log File Path and Log File Name</returns>
        private string LogFile()
        {
            // if class is initialize
            if (ClassInit)
                return this.LogFilePath + this.LogFileName;
            else
                throw new Exception("Class had not been initialized");
        }

        /// <summary>
        /// Log class
        /// </summary>
        /// <param name="log">log message</param>
        /// <param name="mode">log mode</param>
        /// <returns>formatted log message</returns>
        public string Log(string log, int mode = 0)
        {
            // if class is initialize
            if (ClassInit)
            {
                string
                    FormattedLog = null;
                switch (mode)
                {
                    case 1:
                        // select error mode, if error mode off, error message will be drop
                        if (ErrorMode)
                            FormattedLog = string.Format(this.LogEntry, this.ErrorHeader, log);
                        break;
                    case 2:
                        // select debug mode, if debug mode off, debug message will be drop
                        if (DebugMode)
                            FormattedLog = string.Format(this.LogEntry, this.DebugHeader, log);
                        break;
                    default:
                        // normal message
                        FormattedLog = string.Format(this.LogEntry, this.NormalHeader, log);
                        break;
                }
                // if write to file is on and formatted log is not null, write to log file
                if (this.WriteToFile && !string.IsNullOrEmpty(FormattedLog)) this.LogWriter(FormattedLog);
                return FormattedLog;
            }
            else
                throw new Exception("Class had not been initialized");
        }

        /// <summary>
        /// log writer to file
        /// </summary>
        /// <param name="LogEntry">Formatted log</param>
        private void LogWriter(string LogEntry)
        {
            try
            {
                // if class is initialize
                if (ClassInit)
                {
                    // check folder exists, if not create new folder
                    if (!Directory.Exists(this.LogFilePath)) Directory.CreateDirectory(this.LogFilePath);
                    // check file exist, if no create new file, if yes append to file
                    this.LogFileWriter = (!File.Exists(this.LogFile())) ? (new StreamWriter(this.LogFile())): (File.AppendText(this.LogFile()));
                    // write to file
                    LogFileWriter.Write(LogEntry);
                    // close file
                    LogFileWriter.Close();
                }
                else
                    throw new Exception("Class had not been initialized");
            }
            catch (Exception ex)
            {
                // disable write to file when LogWriter having error
                this.WriteToFile = false;
                this.Log(ex.Message);
            }
        }
    }
}
