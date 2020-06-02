using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class PoPomain
    {
        [NotMapped]
        public DateTime MaxArriveDate { get; set; }

        [NotMapped]
        public string SupplierCode { get; set; }


        [NotMapped]
        public List<PoPodetails> Details { get; set; }
    }
}
