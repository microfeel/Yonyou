using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class Materialappm
    {
        [NotMapped]
        public List<Materialappd> Details { get; set; }
    }
}
