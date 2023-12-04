using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;

namespace FYP.Library.Common
{
    public class CommonFunction
    {
        /// <summary>
        /// Showing Error Dialogbox (standard)
        /// </summary>
        /// <param name="Message">message want to display</param>
        public void DisplayError(string Message)
        {
            MessageBox.Show(Message, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// get the application path
        /// </summary>
        /// <returns>path</returns>
        public string AppPath()
        {
            return Application.StartupPath;
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

    public class CommonWinForm
    {
        /// <summary>
        /// check if already run
        /// </summary>
        /// <returns>True if the exists, False if not exists</returns>
        public bool MultipleInstanceApplication()
        {
            try
            {
                using (Process c = Process.GetCurrentProcess()) // Current Process
                {
                    foreach (Process p in Process.GetProcessesByName(c.ProcessName))
                    {
                        if ((p.Id != c.Id) && (p.MainModule.FileName == c.MainModule.FileName))
                        {
                            return true; // found it
                        }
                    }
                }
                return false; // Cannot found
            }
            catch
            {
                // any exception will returns false.
                return false;
            }
        }

        /// <summary>
        /// checking the form instance
        /// </summary>
        /// <param name="MDI">Mdi parent</param>
        /// <param name="me">the form who wanna check</param>
        /// <returns>true = already open, false = nothing found</returns>
        public bool FormSingleInstance(Form Parent, Form me)
        {
            try
            {
                if (Parent == null || me == null)
                {
                    throw new Exception("Method incorrect");
                }

                Form[] f = Parent.MdiChildren; // get all of the MDI children in an array 
                if (f.Length == 0)
                {
                    return false;
                }
                else
                {
                    foreach (Form ch in f)
                    {
                        if (ch.Name == me.Name)
                        {
                            // true = child forms are opened
                            return true;
                        }
                    }
                    // false = no child form is opened
                    return false;
                } 
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// active the mdi child
        /// </summary>
        /// <param name="Parent">mdi parent</param>
        /// <param name="Child">mdi child</param>
        /// <returns>true = success, false = fail</returns>
        public bool FormActiveMdiChild(Form Parent, Form Child)
        {
            try
            {
                if (Parent == null || Child == null)
                {
                    throw new Exception("Method incorrect");
                }

                foreach (Form ch in Parent.MdiChildren)
                {
                    if (ch.Name == Child.Name)
                    {
                        FormCenterToParent(Parent, ch); 
                        ch.Activate();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// close all mdi child
        /// </summary>
        /// <param name="Parent">mdi parent</param>
        public void FormCloseAllMDIChild(Form Parent)
        {
            try
            {
                if (Parent == null)
                {
                    throw new Exception("Method incorrect");
                }
                // search all the form in Parent
                foreach (Form ch in Parent.MdiChildren)
                {
                    // Close the form
                    ch.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// center the form to parent
        /// </summary>
        /// <param name="Parent">parent form</param>
        /// <param name="Child">child form</param>
        public void FormCenterToParent(Form Parent, Form Child)
        {
            try
            {
                if (Parent == null || Child == null)
                {
                    throw new Exception("Method incorrect");
                }
                // center to the point of parent
                Child.Location = new Point((Parent.Width - Child.Width) / 2, (Parent.Height - Child.Height) / 2);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Open an Mdi Child
        /// </summary>
        /// <param name="Parent">Mdi Parent</param>
        /// <param name="Child">Mdi Child</param>
        /// <param name="SingleInstanceOnly">SingleInstance Only?</param>
        public void FormOpenAsMDIChild(Form Parent, Form Child, bool SingleInstanceOnly = true, bool dialogMode = false)
        {
            try
            {
                // method is wrong
                if (Parent == null || Child == null) 
                {
                    throw new Exception("Method incorrect");
                }
                bool found = false; // initial set to false if the form is not found
                if (SingleInstanceOnly) { if (FormSingleInstance(Parent, Child)) { found = FormActiveMdiChild(Parent, Child); } }
                if (!found)
                {
                    if (!dialogMode) { Child.MdiParent = Parent; Child.Show(); } else { Child.ShowDialog(); }
                    FormCenterToParent(Parent, Child);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }

    public class CommonNetwork
    {
        /// <summary>
        /// Ping some IP address
        /// </summary>
        /// <param name="IP">ip address</param>
        /// <returns>True if the ip valid, False if not valid or error</returns>
        public bool Ping(string IP)
        {
            try
            {
                using (Ping p = new Ping())
                {
                    PingReply r = p.Send(IPAddress.Parse(IP));
                    // if replied ping return true, if not found or any error return false
                    return (r.Status == IPStatus.Success); 
                }
            }
            catch { return false; } // any exception will returns false.
        }

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
        /// get external ip -- required "http://www.uniqueone.com.my/cutegirl88/getip.php" to be work properly to function
        /// auto displose webclient after using, fetch and decode the php
        /// </summary>
        /// <returns>ip</returns>
        public string GetExternalIP()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    return wc.DownloadString("http://www.uniqueone.com.my/cutegirl88/getip.php");
                }
            }
            catch (WebException we) { throw new Exception(we.ToString()); } // operation fail
        }
    }

    public class CommonString
    {
        /// <summary>
        /// Convert to Upper Case
        /// </summary>
        /// <param name="s">string to convert</param>
        /// <returns>result of convert</returns>
        public string StringToUpper(string s)
        {
            try
            {
                if (s.Length == 0) { throw new Exception("Cannot convert empty string"); } // Empty then throw it away
                string ns = null;
                for (int i = 0; i < s.Length; i++) { ns += Char.ToUpper(s[i]); }
                return ns;
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // operation fail
        }

        /// <summary>
        /// Convert to Lower Case
        /// </summary>
        /// <param name="s">string to convert</param>
        /// <returns>result of convert</returns>
        public string StringToLower(string s)
        {
            try
            {
                if (s.Length == 0) { throw new Exception("Cannot convert empty string"); }// Empty then throw it away
                string ns = null;
                for (int i = 0; i < s.Length; i++) { ns += Char.ToLower(s[i]); }
                return ns;
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // operation fail
        }
    }

    public class CommonOSInfo
    {
        /// <summary>
        /// get os info
        /// </summary>
        /// <returns>os info</returns>
        public string getWindowsArchitecture()
        {
            try
            {
                return (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") == "AMD64" || Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432") == "AMD64") ? " 64-bit" : " 32-bit";
            }
            catch { return null; }
        }
        public string getServicePackInfo()
        {
            try
            {
                OperatingSystem os = Environment.OSVersion; // Get Operating system information.
                return (!string.IsNullOrEmpty(os.ServicePack)) ? os.ServicePack : "";
            }
            catch { return null; }
        }

        public string getWindowsInfo()
        {
            try
            {
                OperatingSystem os = Environment.OSVersion; // Get Operating system information.
                Version vs = os.Version; // Get version information about the os.
                string strOS = null; // Variable to hold our return value
                if (os.Platform == PlatformID.Win32Windows) // pre-NT version of Windows 9x, non supported running dotnetfx4
                {
                    switch (vs.Minor)
                    {
                        case 0:
                            // windows 95
                            strOS = "95";
                            break;
                        case 10:
                            // windows 98
                            strOS = (vs.Revision.ToString() == "2222A") ? "98SE" : "98";
                            break;
                        case 90:
                            // windows me
                            strOS = "Me";
                            break;
                    }
                }
                else if (os.Platform == PlatformID.Win32NT) // NT Platform version of Windows
                {
                    switch (vs.Major)
                    {
                        case 3:
                            // windows nt 3.51
                            strOS = "NT 3.51";
                            break;
                        case 4:
                            // windows nt 4
                            strOS = "NT 4.0";
                            break;
                        case 5:
                            // Windows 2000?XP?2003?
                            strOS = (vs.Minor == 0) ? "2000" : ((vs.Minor == 1) ? "XP" : ((vs.Minor == 2) ? "Server 2003" : null));
                            break;
                        case 6:
                            // Windows Vista?7?8?
                            strOS = (vs.Minor == 0) ? "Vista" : ((vs.Minor == 1) ? "7" : ((vs.Minor == 2) ? "8" : null));
                            break;
                    }
                }
                return "Windows " + strOS;
            }
            catch { return null; }
        }

        public string getOSInfo()
        {
            try
            {
                return getWindowsInfo() + " " + getServicePackInfo() + " " + getWindowsArchitecture(); // Return the information we've gathered.
            }
            catch { return null; } // operation fail
        }
    }

    public class CommonDataType
    {
        public bool DetermineBool(string b)
        {
            if (b.ToLower() == "true") { return true; }
            return false;
        }

        public bool DetermineNumeric(string text)
        {
            try
            {
                Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
                return regex.IsMatch(text);
            }
            catch { return false; } // just dismiss errors but return false
        }
    }

    public class CommonFileOperation
    {
        public bool FileExist(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName)) { return false; }
                if (File.Exists(fileName))
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public bool FolderExist(string folderName)
        {
            try
            {
                if (string.IsNullOrEmpty(folderName)) { throw new Exception("Folder name missing"); }
                if (Directory.Exists(folderName)) { return true; }
                return false;
            }
            catch { return false; }
        }

        public void CreateTextFile(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName)) { throw new Exception("File name missing"); }
                // new file with unicode
                if (this.FileExist(fileName)) { throw new Exception("Same file exist"); }
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Unicode))
                {
                    sw.Write(""); // writing header
                    sw.Close(); // close it
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // the operation is fail
        }

        public void CreateFolder(string folderName)
        {
            try
            {
                if (string.IsNullOrEmpty(folderName)) { throw new Exception("Folder name missing"); }
                if (!this.FolderExist(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }// check folder exists, if not create new folder
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // the operation is fail
        }

        public void TextFileWriter(string fileName, string fileString, bool createIfNotExist = false)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName)) { throw new Exception("File name missing"); }
                // check file exist, if not create new file in condition createIfNotExist = true
                if (createIfNotExist && !this.FileExist(fileName))
                {
                    this.CreateTextFile(fileName);
                }

                if (!this.FileExist(fileName)) { throw new Exception("File not found"); }
                // only will append text, no exist will error
                using (StreamWriter FileWriter = File.AppendText(fileName))
                {
                    FileWriter.Write(fileString); // write to file
                    FileWriter.Close(); // close file
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); } // disable write to file when LogWriter having error
        }
    }
}
