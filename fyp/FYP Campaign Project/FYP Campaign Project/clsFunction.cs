/*
 * Ver 1.0 Build 11
 * This Class is use to fix some C# weakness
 */
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace FYP_Campaign_Project
{
    public class classFunction
    {
        // get external ip
        public string GetExternalIP()
        {
            try
            {
                WebClient wc = new WebClient();
                return wc.DownloadString("http://www.uniqueone.com.my/cutegirl88/getip.php"); // fetch and decode the php
            }
            catch (WebException we)
            {
                throw new Exception(we.ToString());
            }
        }

        // check if already run
        public Process PriorProcess()
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs) if ((p.Id != curr.Id) && (p.MainModule.FileName == curr.MainModule.FileName)) return p;
            return null;
        }

        // Ping some IP address need this
        public bool ping(string IP)
        {
            Ping x = new Ping();
            PingReply reply = x.Send(IPAddress.Parse(IP));
            if (reply.Status == IPStatus.Success) return true; // if replied ping return true
            throw new Exception("Check network connection, cannot found server with this IP."); // if not then throw it away
        }

        // Convert to Upper Case
        public string StringToUpper(string str)
        {
            if (str.Length == 0) throw new Exception("Cannot convert empty string"); // Empty then throw it away
            string newstr = null;
            for (int i=0; i < str.Length; i++) newstr += Char.ToUpper(str[i]);
            return newstr;
        }

        // Convert to Lower Case
        public string StringToLower(string str)
        {
            if (str.Length == 0) throw new Exception("Cannot convert empty string"); // Empty then throw it away
            string newstr = null;
            for (int i=0; i < str.Length; i++) newstr += Char.ToLower(str[i]);
            return newstr;
        }
    }
}
