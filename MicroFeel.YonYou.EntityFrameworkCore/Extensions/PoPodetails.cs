using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class PoPodetails
    {
        [NotMapped]
        public string ProductName { get; set; }
        [NotMapped]
        public string ProductModel { get; set; }
        [NotMapped]
        public string ProductNumbers { get; set; }
        [NotMapped]
        public string UnitName { get; set; }
    }
}
