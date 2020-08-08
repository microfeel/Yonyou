using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class Rdrecord32
    {
        public Rdrecord32()
        {
            BRdFlag = 0;
            CVouchType = "32";
            CBusType = "普通销售";
            CSource = "发货单";
            BTransFlag = false;
            VtId = 87;
            Dnmaketime = DateTime.Now;
            Bredvouch = 0;
            Details = new List<Rdrecords32>();
            DDate = DateTime.Today;
            BOmfirst = false;
        }

        [NotMapped]
        public List<Rdrecords32> Details { get; set; } = new List<Rdrecords32>();
    }
}
