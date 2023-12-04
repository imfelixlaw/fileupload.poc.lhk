using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace ClassLibGenericFunction
{   
    /// <summary>
    /// Generic Function - 2011-01-21 - This class is use to enhance some C# weakness
    /// reference from msdn library
    /// Revision: 1.0
    /// Build: 31 - 2012-02-01
    /// </summary>
    public class classFunction
    {
        /// <summary>
        /// checking the form instance
        /// </summary>
        /// <param name="MDI">Mdi parent</param>
        /// <param name="me">the form who wanna check</param>
        /// <returns>true = already open, false = nothing found</returns>
        private bool SingleInstanceForm(Form Parent, Form me)
        {
            Form[] f = Parent.MdiChildren; // get all of the MDI children in an array 
            if (f.Length == 0) { return false; } // no child form is opened
            else      // child forms are opened
            {
                // if return true mean one instance of the form is already opened
                foreach (Form ch in f) { if (ch.Name == me.Name) { return true; } }
                return false; // i think is no found
            }
        }

        /// <summary>
        /// test the remote url file exist or not
        /// </summary>
        /// <param name="url">url of the request</param>
        /// <returns>True if the file exits, False if file not exists</returns>
        private bool RemoteFileExists(string url)
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
        /// </summary>
        /// <returns>ip</returns>
        public string GetExternalIP()
        {
            try
            {
                WebClient wc = new WebClient();
                return wc.DownloadString("http://www.uniqueone.com.my/cutegirl88/getip.php"); // fetch and decode the php
            }
            catch (WebException we) { throw new Exception(we.ToString()); } // operation fail
        }

        /// <summary>
        /// check if already run
        /// </summary>
        /// <returns>True if the exits, False if not exists</returns>
        public bool MultipleInstanceExist()
        {
            try
            {
                Process c = Process.GetCurrentProcess(); // Current Process
                Process[] pl = Process.GetProcessesByName(c.ProcessName); // List of Process
                foreach (Process p in pl) { if ((p.Id != c.Id) && (p.MainModule.FileName == c.MainModule.FileName)) { return true; } } // found it
                return false; // Cannot found
            }
            catch { return false; } // any exception will returns false.
        }

        /// <summary>
        /// Ping some IP address
        /// </summary>
        /// <param name="IP">ip address</param>
        /// <returns>True if the ip valid, False if not valid or error</returns>
        public bool ping(string IP)
        {
            try
            {
                Ping p = new Ping();
                PingReply r = p.Send(IPAddress.Parse(IP));
                return (r.Status == IPStatus.Success); // if replied ping return true, if not found or any error return false
            }
            catch { return false; } // any exception will returns false.
        }

        // Convert to Upper Case
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

        // Convert to Lower Case
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
}
