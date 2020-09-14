using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class OmMomaterialsbody
    {
        [NotMapped]
        ///可退货数量
        public decimal AllowReturnQty { get; set; } = 0;
    }
}
 