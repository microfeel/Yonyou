using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class VoucherNumber
    {
        public string AppName { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public int ISize { get; set; }
        public DateTime? DStartDate { get; set; }
        public bool? BAllowHandWork { get; set; }
        public bool? BRepeatReDo { get; set; }
        public bool? BRdFlag { get; set; }
        public int IStartNumber { get; set; }
        public int IIsRdVoucher { get; set; }
        public string Prefix1 { get; set; }
        public int Prefix1Len { get; set; }
        public string Prefix1Rule { get; set; }
        public string Prefix2 { get; set; }
        public int Prefix2Len { get; set; }
        public string Prefix2Rule { get; set; }
        public string Prefix3 { get; set; }
        public int Prefix3Len { get; set; }
        public string Prefix3Rule { get; set; }
        public string Glide { get; set; }
        public int GlideLen { get; set; }
        public string GlideRule { get; set; }
        public string CSubId { get; set; }
        public bool? BGlideByContraCode { get; set; }
        public int IGlideStep { get; set; }
        public bool? BUnfixLen { get; set; }
    }
}
