using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class DispatchList
    {
        [NotMapped]
        public ICollection<DispatchLists>  DispatchLists { get; set; }
    }
}
