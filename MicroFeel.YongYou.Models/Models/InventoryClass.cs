using System;
using System.Collections.Generic;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class InventoryClass
    {
        public string CInvCcode { get; set; }
        public string CInvCname { get; set; }
        public byte IInvCgrade { get; set; }
        public bool? BInvCend { get; set; }
        public string CEcoCode { get; set; }
        public string CBarCode { get; set; }
        public byte[] Pubufts { get; set; }
    }
}
