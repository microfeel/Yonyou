using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    /// <summary>
    /// 材料出库单
    /// </summary>
    partial class Rdrecord11
    {
        public Rdrecord11()
        {
            BRdFlag = 0;
            IDiscountTaxType = 0;
            Bredvouch = Ireturncount = 0;
            BTransFlag = Bpufirst = Biafirst = BIsStqc = BOmfirst = BFromPreYear = false;
            BIsComplement = 0;
            Iverifystate = 0;
            CVouchType = "11";
            VtId = 65;
            DDate = DateTime.Now.Date;
            DArvdate = DateTime.Now.Date;
            Dnmaketime = DateTime.Now;
        }



        [NotMapped]
        public List<Rdrecords11> Details { get; set; }
    }
}
