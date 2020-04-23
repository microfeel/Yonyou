using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class Rdrecord11
    {
        [NotMapped]
        public ICollection<Rdrecords11> Rdrecords11s { get; set; }
    }
}
