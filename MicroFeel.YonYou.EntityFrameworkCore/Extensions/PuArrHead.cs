using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    partial class PuArrHead
    {
        /// <summary>
        /// 入库单号
        /// </summary>
        [NotMapped]
        public string RdRecordNo { get; set; }

        /// <summary>
        /// 委外发货单号
        /// </summary>
        [NotMapped]
        public string SendOrderNo { get; set; }

        [NotMapped]
        public List<PuArrbody> Details { get; set; }
    }
}
