using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class CurrentStock
    {
        public CurrentStock()
        {
            CBatch = "";
            CVmivenCode = "";
            ISoType = 0;
            ISodid = "";
            INum = 0;
            CFree1 = CFree2 = CFree3 = CFree4 = CFree5 = CFree6 = CFree7 = CFree8 = CFree9 = CFree10 = "";
            FInQuantity = FOutQuantity = FInNum = FOutNum = FTransInNum = FTransInQuantity = 0;
            FTransOutNum = FTransOutQuantity = 0;
            FPlanNum = FPlanQuantity = 0;
            FDisableNum = FDisableQuantity = 0;
            FAvaNum = FAvaQuantity = 0;
            FStopNum = FStopQuantity = 0;
            Ipeqty = Ipenum = 0;
            BStopFlag = false;
            Bgspstop = false;
            CCheckState = "";
        }

        [NotMapped]
        public string WhName { get; set; }
    }
}
