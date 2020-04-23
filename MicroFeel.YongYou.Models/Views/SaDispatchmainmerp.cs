using System;
using System.Collections.Generic;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class SaDispatchmainmerp
    {
        public int Dlid { get; set; }
        public string CDlcode { get; set; }
        public string Ccusname { get; set; }
        public string Ccusabbname { get; set; }
        public decimal? Amount { get; set; }
        public DateTime Date { get; set; }
        public string CPersonName { get; set; }
        public string CexchName { get; set; }
        public string CMemo { get; set; }
        public double Iexchrate { get; set; }
        public string CDepName { get; set; }
        public string CBusType { get; set; }
        public string CShipAddress { get; set; }
        public string CSccode { get; set; }
    }
}
