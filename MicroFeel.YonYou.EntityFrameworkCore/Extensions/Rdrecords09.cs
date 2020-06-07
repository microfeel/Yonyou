using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class Rdrecords09
    {
        [NotMapped]
        public DateTime CreateTime { get; set; }
        [NotMapped]
        public string OrderNo { get; set; }
        [NotMapped]
        public string ProductModel { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
        [NotMapped]
        public string ProductNumbers { get; set; }
        [NotMapped]
        public decimal Numbers { get; set; }
        [NotMapped]
        public string UnitName { get; set; }
        [NotMapped]
        public string Brand { get; set; }
        [NotMapped]
        public string Remark { get; set; }
    }
}
