using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class Inventory
    {
        [NotMapped]
        public string UnitName { get; set; }
        [NotMapped]
        public string InvClassName { get; set; }

        [NotMapped]
        public List<CurrentStock> Stock { get; set; }
    }
}
