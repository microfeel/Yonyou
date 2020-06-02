using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class ScmItem
    {
        public string CInvCode { get; set; }
        public string CFree1 { get; set; }
        public string CFree2 { get; set; }
        public string CFree3 { get; set; }
        public string CFree4 { get; set; }
        public string CFree5 { get; set; }
        public string CFree6 { get; set; }
        public string CFree7 { get; set; }
        public string CFree8 { get; set; }
        public string CFree9 { get; set; }
        public string CFree10 { get; set; }
        public byte[] Ufts { get; set; }
        public int Id { get; set; }
        public int? PartId { get; set; }
    }
}
