using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class RdRecord09
    {
        [NotMapped]
        public string Brand { get; set; }
        [NotMapped]
        public string TargetBrand { get; set; }

        [NotMapped]
        public string OutWhName { get; set; }
        [NotMapped]
        public string InWhName { get; set; }

        [NotMapped]
        public List<Rdrecords09> Details { get; set; } = new List<Rdrecords09>();
    }
}
