using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class PuArrivalVouch
    {
        [NotMapped]
        public List<PuArrivalVouchs> Details { get; set; } = new List<PuArrivalVouchs>();
    }
}
