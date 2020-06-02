using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class OmMomain
    {
        [NotMapped]
        public string ProductModel { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
        [NotMapped]
        public List<OmModetails> Details { get; set; } = new List<OmModetails>();
    }
}
