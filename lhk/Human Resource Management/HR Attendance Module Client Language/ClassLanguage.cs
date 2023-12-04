using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Language.Client
{
    public class ClientLanguage
    {
        private struct LangNode
        {
            public string Form;
            public string Element;
            public int LangID;
            public string Lang;
        }

        private string[] StrArraySupportedLanguage = { "English", "简体中文" };

        private string strForm = null;

        private List<LangNode> Lang = new List<LangNode>();

        public ClientLanguage(string Form)
        {
            try
            {
                if (string.IsNullOrEmpty(Form)) { throw new Exception("Missing Required Form Object..."); }
                strForm = Form;
                Lang.Clear();
                //frmMain
                Lang.Add(new LangNode { Form = "FrmMain", Element = "FrmMain", LangID = 0, Lang = "HR Attendance Client" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "FrmMain", LangID = 1, Lang = "HR Attendance 客户端" });
                
                Lang.Add(new LangNode { Form = "FrmMain", Element = "groupBoxBranch", LangID = 0, Lang = "Select your branch" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "groupBoxBranch", LangID = 1, Lang = "选择您的分店" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "groupBoxUser", LangID = 0, Lang = "Select your name" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "groupBoxUser", LangID = 1, Lang = "选择您的名字" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "groupBoxPassword", LangID = 0, Lang = "Enter your password" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "groupBoxPassword", LangID = 1, Lang = "输入您的密码" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "groupBoxAction", LangID = 0, Lang = "Actions" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "groupBoxAction", LangID = 1, Lang = "行动" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "groupBoxLanguage", LangID = 0, Lang = "Language" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "groupBoxLanguage", LangID = 1, Lang = "语言" });

                Lang.Add(new LangNode { Form = "FrmMain", Element = "labelPasswordRequired", LangID = 0, Lang = "Password is required" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "labelPasswordRequired", LangID = 1, Lang = "需要密码" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "labelLastAttendance", LangID = 0, Lang = "Last Attendance" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "labelLastAttendance", LangID = 1, Lang = "上次记录" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "labelSystemMessage", LangID = 0, Lang = "System Message" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "labelSystemMessage", LangID = 1, Lang = "系统信息" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "labelOfflineMode", LangID = 0, Lang = "Offline Mode" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "labelOfflineMode", LangID = 1, Lang = "离线模式" });
                
                Lang.Add(new LangNode { Form = "FrmMain", Element = "buttonAuthentication", LangID = 0, Lang = "Authentication" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "buttonAuthentication", LangID = 1, Lang = "认证" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "buttonPunchAttendance", LangID = 0, Lang = "Punch Attendance" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "buttonPunchAttendance", LangID = 1, Lang = "登记时间" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "buttonClose", LangID = 0, Lang = "Close" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "buttonClose", LangID = 1, Lang = "关闭" });

                Lang.Add(new LangNode { Form = "FrmMain", Element = "checkBoxUnmaskPassword", LangID = 0, Lang = "Unmask Password" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "checkBoxUnmaskPassword", LangID = 1, Lang = "显示密码" });


                Lang.Add(new LangNode { Form = "FrmMain", Element = "ErrMsgNoBranchData", LangID = 0, Lang = "There is something wrong, no branch data is found..." });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "ErrMsgNoBranchData", LangID = 1, Lang = "发现错误，没有分店资料..." });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "ErrMsgNoUserData", LangID = 0, Lang = "There is something wrong, no user data is found..." });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "ErrMsgNoUserData", LangID = 1, Lang = "发现错误，没有员工资料..." });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "ErrMsgPasswordEmpty", LangID = 0, Lang = "Password cannot be empty" });
                Lang.Add(new LangNode { Form = "FrmMain", Element = "ErrMsgPasswordEmpty", LangID = 1, Lang = "密码不能为空" });
                
            
            
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public string[] SupportedLanguage()
        {
            return StrArraySupportedLanguage;
        }

        public string GetLang(string Element, int LangID)
        {
            try
            {
                var ValueQuery = (from L in Lang where (string.Compare(L.Form, strForm, true) == 0 && string.Compare(L.Element, Element, true) == 0 && L.LangID == LangID) select L.Lang).ToArray();
                return ValueQuery[0];
            }
            catch { return null; }
        }
    }
}
