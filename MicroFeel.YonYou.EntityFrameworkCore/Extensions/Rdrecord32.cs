using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class Rdrecord32
    {
        [NotMapped]
        public List<Rdrecords32> Details { get; set; } = new List<Rdrecords32>();
    }
}
