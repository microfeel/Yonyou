using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class PuArrivalVouch
    {
        [NotMapped]
        public ICollection<PuArrivalVouchs> PuArrivalVouchs { get; set; }
    }
}
