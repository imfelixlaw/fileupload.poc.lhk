/* Function List
 * ==============
 * 
 * Felix.Library.Common -> Common
 *      GetTwelveCycleHour();
 *      StartService(string serviceName);
 *      StopService(string serviceName);
 *      RestartService(string serviceName);
 *      DisplayError(string strMessage);
 *      AcrobatReader();
 * Felix.Library.Common.Data -> CommonData
 *      StringToUpper(string s);
 *      StringToLower(string s);
 *      IsNumeric(string text);
 *      TrimLastCharacter(string str);
 *      TrimFirstCharacter(string str);
 *      LastCharacter(string str);
 *      FirstCharacter(string str);
 * Felix.Library.Common.IO -> CommonIO
 *      ExistDirectory(string Path);
 *      CreateFolder(string FolderName);
 * Felix.Library.Common.Network -> CommonNetwork
 *      RemoteFileExists(string url);
 *      PingTest(string strIP);
 * Felix.Library.Common.OSInfo - > CommonOSInfo
 *      getOSVersion();
 *      getOSBit();
 *      getOSServicePack();
 *      getOSInfo();
 * Felix.Library.Common.WinForm -> CommonWinForm
 *      MultipleInstanceApplication();
 *      SingleInstanceForm(Form Parent, Form me);
 *      ActiveChild(Form Parent, Form Child);
 *      CloseAllChild(Form Parent);
 *      CenterFormToParent(Form Parent, Form Child);
 *      OpenForm(Form Parent, Form Child, bool SingleInstanceOnly, bool DialogMode);
 */

using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Felix.Library.Common
{
    public class Common
    {
        /// <summary>
        /// get 12 hour time
        /// </summary>
        /// <param name="dateTime">dateTime</param>
        /// <returns>eg, 1400, will return 2</returns>
        public static int GetTwelveCycleHour(DateTime dateTime)
        {
            if (dateTime.Hour > 12)
            {
                return dateTime.Hour - 12;
            }
            return dateTime.Hour;
        }

        /// <summary>
        /// start service
        /// </summary>
        /// <param name="serviceName">name</param>
        public void StartService(string serviceName)
        {
            try
            {
                ServiceController service = new ServiceController(serviceName);
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(5000));
            }
            catch { throw new Exception("Service start fail"); }
        }

        /// <summary>
        /// stop service
        /// </summary>
        /// <param name="serviceName">name</param>
        public void StopService(string serviceName)
        {
            try
            {
                ServiceController service = new ServiceController(serviceName);
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(5000));
            }
            catch { throw new Exception("Service stop fail"); }
        }

        /// <summary>
        /// restart service
        /// </summary>
        /// <param name="serviceName">name</param>
        public void RestartService(string serviceName)
        {
            try
            {
                StopService(serviceName);
                StartService(serviceName);
            }
            catch { throw new Exception("Service restart fail"); }
        }

        /// <summary>
        /// Showing Error Dialogbox (standard)
        /// </summary>
        /// <param name="strMessage">message want to display</param>
        public void DisplayError(string strMessage)
        {
            MessageBox.Show(strMessage, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// check pdf reader
        /// </summary>
        /// <returns>true = installed, false = no installed</returns>
        public bool AcrobatReader()
        {
            RegistryKey adobe = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Adobe");
            if (adobe != null)
            {
                RegistryKey acroRead = adobe.OpenSubKey("Acrobat Reader");
                if (acroRead == null || acroRead.GetSubKeyNames() == null) { return false; }
                return true;
            }
            return false;
        }
    }
}

namespace Felix.Library.Common.Data
{
    public class CommonData
    {
        /// <summary>
        /// Convert to Upper Case
        /// </summary>
        /// <param name="s">string to convert</param>
        /// <returns>result of convert</returns>
        public string StringToUpper(string str)
        {
            try
            {
                if (str.Length == 0) { throw new Exception("Cannot convert empty string"); } // Empty then throw it away
                string ns = null;
                for (int i = 0; i < str.Length; i++) { ns += Char.ToUpper(str[i]); }
                return ns;
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // operation fail
        }

        /// <summary>
        /// Convert to Lower Case
        /// </summary>
        /// <param name="s">string to convert</param>
        /// <returns>result of convert</returns>
        public string StringToLower(string str)
        {
            try
            {
                if (str.Length == 0) { throw new Exception("Cannot convert empty string"); }// Empty then throw it away
                string ns = null;
                for (int i = 0; i < str.Length; i++) { ns += Char.ToLower(str[i]); }
                return ns;
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // operation fail
        }

        /// <summary>
        /// check if is numeric
        /// </summary>
        /// <param name="text">text need to parse</param>
        /// <returns>true = numeric, false = not numeric</returns>
        public bool IsNumeric(string str)
        {

            try { Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$"); return regex.IsMatch(str); }
            catch { return false; } // just dismiss errors but return false
        }

        /// <summary>
        /// remove last char
        /// </summary>
        /// <param name="str">text need to parse</param>
        /// <returns>text after remove last char</returns>
        public string TrimLastCharacter(string str)
        {
            try { return (string.IsNullOrEmpty(str)) ? str : str.TrimEnd(str[str.Length - 1]); }
            catch { throw new Exception("Empty string on TrimLastCharacter();"); }
        }

        /// <summary>
        /// remove first char
        /// </summary>
        /// <param name="str">text need to parse</param>
        /// <returns>text after remove first char</returns>
        public string TrimFirstCharacter(string str)
        {
            try { return str.Substring(1); }
            catch { throw new Exception("Empty string on TrimFirstCharacter();"); }
        }

        /// <summary>
        /// get last char
        /// </summary>
        /// <param name="str">text need to parse</param>
        /// <returns>last char</returns>
        public string LastCharacter(string str)
        {
            try { return str.Substring(str.Length - 1, 1); }
            catch { throw new Exception("Empty string on LastCharacter();"); }
        }

        /// <summary>
        /// get first char
        /// </summary>
        /// <param name="str">text need to parse</param>
        /// <returns>first char</returns>
        public string FirstCharacter(string str)
        {
            try { return str.Substring(0, 1); }
            catch { throw new Exception("Empty string on FirstCharacter();"); }
        }
    }
}

namespace Felix.Library.Common.IO
{
    public class CommonIO
    {
        /// <summary>
        /// check directory exist
        /// </summary>
        /// <param name="Path">path to check</param>
        /// <returns>true = exist, false = not or error</returns>
        public bool ExistDirectory(string Path)
        {
            try { return Directory.Exists(Path); }
            catch { return false; }
        }

        /// <summary>
        /// create folder
        /// </summary>
        /// <param name="FolderName">folder name</param>
        /// <returns>true = done, false = fail</returns>
        public bool CreateFolder(string FolderName) // check folder exists, if not create new folder
        {
            try { if (!Directory.Exists(FolderName)) { Directory.CreateDirectory(FolderName); } return true; }
            catch { return false; }
        }
    }
}

namespace Felix.Library.Common.Network
{
    public class CommonNetwork
    {

        /// <summary>
        /// test the remote url file exist or not
        /// </summary>
        /// <param name="url">url of the request</param>
        /// <returns>True if the file exits, False if file not exists</returns>
        public bool RemoteFileExists(string url)
        {
            try
            {
                HttpWebRequest wr = WebRequest.Create(url) as HttpWebRequest; //Creating the HttpWebRequest
                wr.Method = "HEAD"; //Setting the Request method HEAD, you can also use GET too.
                HttpWebResponse res = wr.GetResponse() as HttpWebResponse; //Getting the Web Response.
                return (res.StatusCode == HttpStatusCode.OK); //Returns true if the Status code == 200
            }
            catch { return false; } // any exception will returns false.
        }

        /// <summary>
        /// Ping some IP address
        /// </summary>
        /// <param name="strIP">ip address</param>
        /// <returns>True if the ip valid, False if not valid or error</returns>
        public bool PingTest(string strIP)
        {
            try
            {
                using (Ping p = new Ping())
                {
                    PingReply r = p.Send(IPAddress.Parse(strIP));
                    return (r.Status == IPStatus.Success); // if replied ping return true, if not found or any error return false
                }
            }
            catch { return false; } // any exception will returns false.
        }
    }
}

namespace Felix.Library.Common.OSInfo
{
    public class CommonOSInfo
    {
        private static OperatingSystem os = Environment.OSVersion; // Get Operating system information.
        private static Version vs = os.Version; // Get version information about the os.

        /// <summary>
        /// get os version
        /// </summary>
        /// <returns>windows version ex., windows xp</returns>
        public string getOSVersion()
        {
            try
            {
                string strOS = null; // Variable to hold our return value
                if (os.Platform == PlatformID.Win32Windows) // pre-NT version of Windows 9x, non supported running dotnetfx4
                {
                    switch (vs.Minor)
                    {
                        case 0: strOS = "95"; break; // windows 95
                        case 10: strOS = (vs.Revision.ToString() == "2222A") ? "98SE" : "98"; break; // windows 98
                        case 90: strOS = "Me"; break; // windows me
                    }
                }
                else if (os.Platform == PlatformID.Win32NT) // NT Platform version of Windows
                {
                    switch (vs.Major)
                    {
                        case 3: strOS = "NT 3.51"; break; // windows nt 3.51
                        case 4: strOS = "NT 4.0"; break; // windows nt 4
                        case 5: strOS = (vs.Minor == 0) ? "2000" : ((vs.Minor == 1) ? "XP" : ((vs.Minor == 2) ? "Server 2003" : null)); break; // Windows 2000?XP?2003?
                        case 6: strOS = (vs.Minor == 0) ? "Vista" : ((vs.Minor == 1) ? "7" : ((vs.Minor == 2) ? "8" : null)); break; // Windows Vista?7?8?
                    }
                }
                return strOS;
            }
            catch { return null; }
        }

        /// <summary>
        /// get os bit
        /// </summary>
        /// <returns>os bit, eg., 64bit, 32bit</returns>
        public string getOSBit()
        {
            try
            {
                return (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") == "AMD64" || Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432") == "AMD64") ? " 64-bit" : " 32-bit";
            }
            catch { return null; }
        }

        /// <summary>
        /// get os service pack
        /// </summary>
        /// <returns>service pack, e.g., service pack 1</returns>
        public string getOSServicePack()
        {
            try
            {
                return ((!string.IsNullOrEmpty(os.ServicePack)) ? os.ServicePack : "");
            }
            catch { return null; }
        }

        /// <summary>
        /// get os full string
        /// </summary>
        /// <returns>eg. windows xp professional service pack 2 64bit</returns>
        public string getOSInfo()
        {
            try
            {
                string strOS = getOSVersion(); // Variable to hold our return value
                // Make sure we actually got something in our OS check, we don't want to just return " Service Pack 2" that information is useless without the OS version.
                // prepend "Windows" and get more info and check service pack and check windows's bit, append it to the OS name.
                if (!string.IsNullOrEmpty(strOS)) { strOS = "Windows " + strOS + " " + getOSServicePack() + getOSBit(); }
                return strOS; // Return the information we've gathered.
            }
            catch { return null; } // operation fail
        }
    }
}

namespace Felix.Library.Common.WinForm
{
    public class CommonWinForm
    {
        /// <summary>
        /// check if already run
        /// </summary>
        /// <returns>True if the exits, False if not exists</returns>
        public bool MultipleInstanceApplication()
        {
            try
            {
                using (Process c = Process.GetCurrentProcess())// Current Process
                {
                    foreach (Process p in Process.GetProcessesByName(c.ProcessName)) { if ((p.Id != c.Id) && (p.MainModule.FileName == c.MainModule.FileName)) { return true; } } // found it
                    return false; // Cannot found
                }
            }
            catch { return false; } // any exception will returns false.
        }
        /// <summary>
        /// checking the form instance
        /// </summary>
        /// <param name="MDI">Mdi parent</param>
        /// <param name="me">the form who wanna check</param>
        /// <returns>true = already open, false = nothing found</returns>
        public bool SingleInstanceForm(Form Parent, Form me)
        {
            try
            {
                Form[] f = Parent.MdiChildren; // get all of the MDI children in an array 
                if (f.Length == 0) { return false; } else { foreach (Form ch in f) { if (ch.Name == me.Name) { return true; } } return false; } // false = no child form is opened, true = child forms are opened
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// active the mdi child
        /// </summary>
        /// <param name="Parent">mdi parent</param>
        /// <param name="Child">mdi child</param>
        /// <returns>true = success, false = fail</returns>
        public bool ActiveChild(Form Parent, Form Child)
        {
            try { foreach (Form ch in Parent.MdiChildren) { if (ch.Name == Child.Name) { CenterFormToParent(Parent, ch); ch.Activate(); return true; } } return false; }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// close all mdi child
        /// </summary>
        /// <param name="Parent">mdi parent</param>
        public void CloseAllChild(Form Parent)
        {
            try { foreach (Form ch in Parent.MdiChildren) { ch.Close(); } }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// center the form to parent
        /// </summary>
        /// <param name="Parent">parent form</param>
        /// <param name="Child">child form</param>
        public void CenterFormToParent(Form Parent, Form Child)
        {
            try { Child.Location = new Point((Parent.Width - Child.Width) / 2, (Parent.Height - Child.Height) / 2); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Open an Mdi Child
        /// </summary>
        /// <param name="Parent">Mdi Parent</param>
        /// <param name="Child">Mdi Child</param>
        /// <param name="SingleInstanceOnly">SingleInstance Only?</param>
        public void OpenForm(Form Parent, Form Child, bool SingleInstanceOnly, bool DialogMode)
        {
            try
            {
                if (Parent == null || Child == null) { throw new Exception("OpenMDIForm Method incorrect"); }
                bool Found = false; // initial set to false if the form is not found
                if (SingleInstanceOnly) { if (SingleInstanceForm(Parent, Child)) { Found = ActiveChild(Parent, Child); } }
                if (!Found)
                {
                    if (!DialogMode) { Child.MdiParent = Parent; Child.Show(); } else { Child.ShowDialog(); }
                    CenterFormToParent(Parent, Child);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
