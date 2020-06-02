using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class ComputationUnit
    {
        public string CComunitCode { get; set; }
        public string CComUnitName { get; set; }
        public string CGroupCode { get; set; }
        public string CBarCode { get; set; }
        public bool? BMainUnit { get; set; }
        public decimal? IChangRate { get; set; }
        public double? IProportion { get; set; }
        public short? INumber { get; set; }
        public byte[] Pubufts { get; set; }
        public string CEnSingular { get; set; }
        public string CEnPlural { get; set; }
        public string CUnitRefInvCode { get; set; }
    }
}
