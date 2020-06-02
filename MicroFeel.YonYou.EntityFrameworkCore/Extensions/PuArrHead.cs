using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class PuArrHead
    {
        [NotMapped]
        public List<PuArrbody> Details { get; set; }
    }
}
