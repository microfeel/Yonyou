using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class RdRecord08
    {
        [NotMapped]
        public string WhName { get; set; }
        [NotMapped]
        public List<Rdrecords08> Details { get; set; } = new List<Rdrecords08>();
    }
}
