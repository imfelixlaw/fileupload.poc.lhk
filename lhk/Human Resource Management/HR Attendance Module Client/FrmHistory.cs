using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Felix.Library.Common;
using Felix.Library.Common.WinForm;
using Felix.Library.Common.DB;
using Felix.Library.Common.Encryption;
using MySql.Data.MySqlClient;

namespace HR_Attendance_Module_Client
{
    public partial class FrmHistory : Form
    {
        private CommonWinForm CWF = new CommonWinForm();
        private CommonDB COMMONDB = new CommonDB(CoreKernel.GetMySQLConnString());
        private CommonEncryption CE = new CommonEncryption("HRRM");
        private Common COMMON = new Common();

        public FrmHistory(int IDUser)
        {
            InitializeComponent();
            LoadHistory(IDUser);
        }

        private void LoadHistory(int IDUser)
        {
            try
            {
                string sql = string.Format(@"SELECT hac.`IDAttCheck`, hac.`CheckTime`
                    FROM `hr_att_check` AS hac
                    INNER JOIN `hr_att` AS ha ON ha.`IDAtt` = hac.`FKIDAtt`
                    WHERE YEAR(hac.`CheckDate`) = YEAR(NOW())
                    AND MONTH(hac.`CheckDate`) = MONTH(NOW())
                    AND DAY(hac.`CheckDate`) = DAY(NOW())
                    AND ha.`FKIDUser` = {0};", IDUser);
                MySqlDataReader dr = COMMONDB.MySQLExecuteReader(sql);
                while (dr.Read())
                {
                    int i = dataGridViewHistory.Rows.Add();
                    dataGridViewHistory.Rows[i].Cells[0].Value = dr.GetInt32(0);
                    dataGridViewHistory.Rows[i].Cells[1].Value = dr.GetValue(1).ToString();
                }
            }
            catch(Exception ex)
            {
                COMMON.DisplayError(ex.Message);
            }
        }

        private void btnChangeTime_Click(object sender, EventArgs e)
        {

        }
    }
}
