using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class Rdrecord11
    {
        [NotMapped]
        public List<Rdrecords11> Details { get; set; }
    }
}
