using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace HeaderStuffcs
{
    public partial class HeaderStuffcs_ribbon
    {
        private void btnOption_Click(object sender, RibbonControlEventArgs e)
        {
            new frmOptions().ShowDialog();
        }

        private void btnAbout_Click(object sender, RibbonControlEventArgs e)
        {
            new About().ShowDialog();
        }
    }
}
