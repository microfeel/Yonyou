using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class Rdrecord32
    {
        [NotMapped]
        public ICollection<Rdrecords32>   Rdrecords32s { get; set; }
    }
}
