using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class DispatchLists
    {
        [NotMapped]
        public bool? BInvBatch { get; set; }
        [NotMapped]
        public string CComUnitName { get; set; }
        [NotMapped]
        public string CInvStd { get; set; }

    }
}
