using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class InventoryClass
    {
        public InventoryClass()
        {
            Inventory = new HashSet<Inventory>();
        }

        public string CInvCcode { get; set; }
        public string CInvCname { get; set; }
        public byte IInvCgrade { get; set; }
        public bool? BInvCend { get; set; }
        public string CEcoCode { get; set; }
        public string CBarCode { get; set; }
        public byte[] Pubufts { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
