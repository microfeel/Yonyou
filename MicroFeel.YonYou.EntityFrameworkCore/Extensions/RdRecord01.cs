using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class RdRecord01
    {
        [NotMapped]
        public List<Rdrecords01> Details { get; set; } = new List<Rdrecords01>();
    }
}
