using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class MaterialAppVouchs
    {
        public int AutoId { get; set; }
        public int Id { get; set; }
        public string CInvCode { get; set; }
        public decimal? INum { get; set; }
        public decimal? IQuantity { get; set; }
        public string CBatch { get; set; }
        public string CFree1 { get; set; }
        public string CFree2 { get; set; }
        public DateTime? DDueDate { get; set; }
        public string CBcloser { get; set; }
        public decimal? FOutQuantity { get; set; }
        public decimal? FOutNum { get; set; }
        public DateTime? DVdate { get; set; }
        public string CDefine22 { get; set; }
        public string CDefine23 { get; set; }
        public string CDefine24 { get; set; }
        public string CDefine25 { get; set; }
        public double? CDefine26 { get; set; }
        public double? CDefine27 { get; set; }
        public string CItemClass { get; set; }
        public string CItemCode { get; set; }
        public string CName { get; set; }
        public string CItemCname { get; set; }
        public string CFree3 { get; set; }
        public string CFree4 { get; set; }
        public string CFree5 { get; set; }
        public string CFree6 { get; set; }
        public string CFree7 { get; set; }
        public string CFree8 { get; set; }
        public string CFree9 { get; set; }
        public string CFree10 { get; set; }
        public string CAssUnit { get; set; }
        public DateTime? DMadeDate { get; set; }
        public int? IMassDate { get; set; }
        public string CDefine28 { get; set; }
        public string CDefine29 { get; set; }
        public string CDefine30 { get; set; }
        public string CDefine31 { get; set; }
        public string CDefine32 { get; set; }
        public string CDefine33 { get; set; }
        public int? CDefine34 { get; set; }
        public int? CDefine35 { get; set; }
        public DateTime? CDefine36 { get; set; }
        public DateTime? CDefine37 { get; set; }
        public short? CMassUnit { get; set; }
        public string CWhCode { get; set; }
        public decimal? Iinvexchrate { get; set; }
        public short? IExpiratDateCalcu { get; set; }
        public string CExpirationdate { get; set; }
        public DateTime? DExpirationdate { get; set; }
        public decimal? CBatchProperty1 { get; set; }
        public decimal? CBatchProperty2 { get; set; }
        public decimal? CBatchProperty3 { get; set; }
        public decimal? CBatchProperty4 { get; set; }
        public decimal? CBatchProperty5 { get; set; }
        public string CBatchProperty6 { get; set; }
        public string CBatchProperty7 { get; set; }
        public string CBatchProperty8 { get; set; }
        public string CBatchProperty9 { get; set; }
        public DateTime? CBatchProperty10 { get; set; }
        public string CbMemo { get; set; }
        public int? Irowno { get; set; }
        public long? IMpoIds { get; set; }
        public string CMoLotCode { get; set; }
        public string Cmworkcentercode { get; set; }
        public string Cmocode { get; set; }
        public int? Imoseq { get; set; }
        public string Iopseq { get; set; }
        public string Copdesc { get; set; }
        public int? IOmoDid { get; set; }
        public int? IOmoMid { get; set; }
        public string Comcode { get; set; }
        public string Invcode { get; set; }
        public string Cciqbookcode { get; set; }
        public string Cservicecode { get; set; }
        public byte? Iordertype { get; set; }
        public int? Iorderdid { get; set; }
        public string Iordercode { get; set; }
        public int? Iorderseq { get; set; }
        public byte? Isotype { get; set; }
        public string Isodid { get; set; }
        public string Csocode { get; set; }
        public int? Isoseq { get; set; }
        public string Corufts { get; set; }
        public string Crejectcode { get; set; }
        public string Ipesodid { get; set; }
        public byte? Ipesotype { get; set; }
        public string Cpesocode { get; set; }
        public int? Ipesoseq { get; set; }
        public string Cbsysbarcode { get; set; }
        public decimal? Ipickedquantity { get; set; }
        public decimal? Ipickednum { get; set; }
        public string CSourceMocode { get; set; }
        public int? ISourceModetailsid { get; set; }
        public string Cplanlotcode { get; set; }
        public string Cfactorycode { get; set; }

        public virtual Warehouse CWhCodeNavigation { get; set; }
        public virtual MaterialAppVouch IdNavigation { get; set; }
    }
}
