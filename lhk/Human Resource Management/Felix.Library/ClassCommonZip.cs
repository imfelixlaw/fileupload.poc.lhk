using System;
using System.IO;
using Ionic.Zip;
using Felix.Library.Common.IO;

namespace Felix.Library.Common.Zip
{    
    /// <summary>
    /// IonicZip Function
    /// Currently Support Extract Only
    /// </summary>
    class CommonZip
    {
        private CommonIO COMMONIO = new CommonIO();
        private static string TargetDirectory = null, TargetFile = null;
        private static bool Init = false;

        /// <summary>
        /// create object
        /// </summary>
        /// <param name="Path">path to file</param>
        /// <param name="File">filename</param>
        public CommonZip(string Path, string File)
        {
            try
            {
                if (!COMMONIO.ExistDirectory(Path)) { throw new Exception("IonicZip :: Path Not Found"); }
                if (string.IsNullOrEmpty(File)) { throw new Exception("IonicZip :: Invalid File"); }
                TargetDirectory = Path;
                TargetFile = File;
                Init = true;
            }
            catch (Exception ex) { throw new Exception("IonicZip :: " + ex.Message); }
        }

        /// <summary>
        /// extract
        /// </summary>
        /// <param name="Target">target folder</param>
        /// <param name="OverwriteExist">true = overwrite</param>
        /// <returns>true = success, false = fail</returns>
        public bool Extract(string Target, bool OverwriteExist = true) // true => overwrite existing files
        {
            try
            {
                if (!Init) { throw new Exception("IonicZip :: Class not initialized"); }
                if (!File.Exists(TargetDirectory + TargetFile)) { throw new Exception("IonicZip :: Zip File Not Found"); }
                using (ZipFile zip = ZipFile.Read(TargetDirectory + TargetFile)) { foreach (ZipEntry e in zip) { e.Extract(Target, OverwriteExist); } }
                return true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
