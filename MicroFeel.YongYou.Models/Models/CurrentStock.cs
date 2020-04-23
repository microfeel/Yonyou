using System;
using System.Collections.Generic;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class CurrentStock
    {
        public int AutoId { get; set; }
        public string CWhCode { get; set; }
        public string CInvCode { get; set; }
        public int ItemId { get; set; }
        public string CBatch { get; set; }
        public string CVmivenCode { get; set; }
        public int ISoType { get; set; }
        public string ISodid { get; set; }
        public decimal? IQuantity { get; set; }
        public decimal? INum { get; set; }
        public string CFree1 { get; set; }
        public string CFree2 { get; set; }
        public decimal? FOutQuantity { get; set; }
        public decimal? FOutNum { get; set; }
        public decimal? FInQuantity { get; set; }
        public decimal? FInNum { get; set; }
        public string CFree3 { get; set; }
        public string CFree4 { get; set; }
        public string CFree5 { get; set; }
        public string CFree6 { get; set; }
        public string CFree7 { get; set; }
        public string CFree8 { get; set; }
        public string CFree9 { get; set; }
        public string CFree10 { get; set; }
        public DateTime? DVdate { get; set; }
        public bool? BStopFlag { get; set; }
        public decimal? FTransInQuantity { get; set; }
        public DateTime? DMdate { get; set; }
        public decimal? FTransInNum { get; set; }
        public decimal? FTransOutQuantity { get; set; }
        public decimal? FTransOutNum { get; set; }
        public decimal? FPlanQuantity { get; set; }
        public decimal? FPlanNum { get; set; }
        public decimal? FDisableQuantity { get; set; }
        public decimal? FDisableNum { get; set; }
        public decimal? FAvaQuantity { get; set; }
        public decimal? FAvaNum { get; set; }
        public byte[] Ufts { get; set; }
        public int? IMassDate { get; set; }
        public bool? Bgspstop { get; set; }
        public short? CMassUnit { get; set; }
        public decimal? FStopQuantity { get; set; }
        public decimal? FStopNum { get; set; }
        public DateTime? DLastCheckDate { get; set; }
        public string CCheckState { get; set; }
        public DateTime? DLastYearCheckDate { get; set; }
        public short? IExpiratDateCalcu { get; set; }
        public string CExpirationdate { get; set; }
        public DateTime? DExpirationdate { get; set; }
        public decimal Ipeqty { get; set; }
        public decimal Ipenum { get; set; }
    }
}
