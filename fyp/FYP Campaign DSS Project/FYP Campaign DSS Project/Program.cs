using System;
using System.Windows.Forms;
using FYP.Library.Config;
using FYP.Library.Common;

namespace FYP_Campaign_DSS_Project
{
    static class Program
    {
        static CommonFunction CF = new CommonFunction();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string _CONST_INIFile = "config.ini";
                CommonWinForm __CWF = new CommonWinForm();
                ProgramAddtional __PA = new ProgramAddtional();
                CommonFileOperation __CFO = new CommonFileOperation();
                if (__CFO.FileExist(_CONST_INIFile))
                {
                    string _Log_Enable = __PA.ReadConfig(_CONST_INIFile, "log", "enable");
                }
                if (__CWF.MultipleInstanceApplication()) { throw new Exception("Another instance is running."); }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMDIMain());
                //Application.Run(new frmLogin());
            }
            catch(Exception ex)
            {
                CF.DisplayError(ex.Message); // OMG there is some error!!!
            }
        }
    }

    public class ProgramAddtional
    {
        public string ReadConfig(string file, string sec, string key)
        {
            try
            {
                INIConfig __ICfg = new INIConfig(file);
                __ICfg.Read();
                return __ICfg.Get(sec, key); // log enable?
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
