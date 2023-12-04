using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;

namespace HR.Authentication
{
    public class Authentication
    {
        public string ReturnUserPwd(string EncryptedPassword)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    return wc.DownloadString(string.Format("http://10.8.10.8/misupdate/crypto.php?password={0}", EncryptedPassword));
                }
            }
            catch (WebException we) { throw new Exception(we.ToString()); } // operation fail
        }
    }
}
