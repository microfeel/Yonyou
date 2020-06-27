using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class ScmItem
    {
        public ScmItem()
        {
            PartId = 0;
            CFree1 = CFree2 = CFree3 = CFree4 = CFree5 = CFree6 = CFree7 = CFree8 = CFree9 = CFree10 = "";
        }

        public ScmItem(string invCode) : this()
        {
            CInvCode = invCode;
        }
    }
}
