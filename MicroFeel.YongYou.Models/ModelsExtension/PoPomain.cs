using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class PoPomain
    {
        [NotMapped]
        public List<PoPodetails> Podetails { get; set; }
    }
}
