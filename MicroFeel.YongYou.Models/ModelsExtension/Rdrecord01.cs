using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class RdRecord01
    {
        [NotMapped]
        public ICollection<Rdrecords01> Rdrecords01s { get; set; }
    }
}
