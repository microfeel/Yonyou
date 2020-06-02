using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class DispatchList
    {
        [NotMapped]
        public string Receiver { get; set; }
        [NotMapped]
        public string ReceiveTel { get; set; }
        [NotMapped]
        public string RecevieAddress { get; set; }
        [NotMapped]
        public List<DispatchLists> Details { get; set; }
    }
}
