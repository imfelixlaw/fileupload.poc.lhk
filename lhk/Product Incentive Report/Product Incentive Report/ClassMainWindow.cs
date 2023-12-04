using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Product_Incentive_Report
{
    public class ClassMainWindow
    {
        public string GetMonthName(int year, int month)
        {
            DateTime date = new DateTime(year, month, 1);
            return date.ToString("MMMM");
        }
        /// <summary>
        /// Getting Last Day of Selected Month
        /// </summary>
        /// <param name="iMonth">Month</param>
        /// <param name="iYear">Year</param>
        /// <returns>Last Day of Month (28/29/30/31)</returns>
        public int LastDayOfMonth(int iMonth, int iYear)
        {
            int iLastDay = 0;
            switch (iMonth)
            {
                case 2:
                    if (DateTime.IsLeapYear(iYear))
                    {
                        iLastDay = 29; // Leap Year Feb got 29 day
                    }
                    else
                    {
                        iLastDay = 28;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    iLastDay = 30;
                    break;
                default:
                    iLastDay = 31;
                    break;

            }
            return iLastDay;
        }

        /// <summary>
        /// Report File Name
        /// </summary>
        /// <returns>File name and path</returns>
        public string SaveFilename(int Year, int Month, int FKIDBranch, string BranchCode)
        {
            try
            {
                string sFileName = string.Empty;
                SaveFileDialog sFD = new SaveFileDialog();
                sFD.Title = "Incentive Report for " + BranchCode;
                sFD.AddExtension = true;
                sFD.DefaultExt = "xls";
                sFD.Filter = "Excel files |*.xls|All files (*.*)|*.*";
                sFD.FilterIndex = 1;
                sFD.RestoreDirectory = true;
                sFD.FileName = Year.ToString() + "-" + Month.ToString() + "-" + BranchCode + "-IncentiveReport.xls"; // put default file name here
                if (sFD.ShowDialog() == true) // Getting if ShowDialog Save is Press
                {
                    sFileName = sFD.FileName; // then return the FileName
                }
                else
                {
                    sFileName = string.Empty; // or return string.Empty
                }
                return sFileName;
            }
            catch // Dismiss Error
            {
                return string.Empty;
            }
        }
    }
}
