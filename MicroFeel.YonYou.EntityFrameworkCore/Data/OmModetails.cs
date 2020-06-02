﻿using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class OmModetails
    {
        public OmModetails()
        {
            OmMomaterials = new HashSet<OmMomaterials>();
        }

        public int ModetailsId { get; set; }
        public int Moid { get; set; }
        public string CInvCode { get; set; }
        public decimal? IQuantity { get; set; }
        public decimal? INum { get; set; }
        public decimal? IQuotedPrice { get; set; }
        public decimal? IUnitPrice { get; set; }
        public decimal? IMoney { get; set; }
        public decimal? ITax { get; set; }
        public decimal? ISum { get; set; }
        public decimal? IDisCount { get; set; }
        public decimal? INatUnitPrice { get; set; }
        public decimal? INatMoney { get; set; }
        public decimal? INatTax { get; set; }
        public decimal? INatSum { get; set; }
        public decimal? INatDisCount { get; set; }
        public DateTime? DStartDate { get; set; }
        public DateTime? DArriveDate { get; set; }
        public decimal? IReceivedQty { get; set; }
        public decimal? IReceivedNum { get; set; }
        public decimal? IReceivedMoney { get; set; }
        public decimal? IInvQty { get; set; }
        public decimal? IInvNum { get; set; }
        public decimal? IInvMoney { get; set; }
        public string CFree1 { get; set; }
        public string CFree2 { get; set; }
        public decimal? INatInvMoney { get; set; }
        public decimal? IOriTotal { get; set; }
        public decimal? ITotal { get; set; }
        public decimal? IPerTaxRate { get; set; }
        public string CDefine22 { get; set; }
        public string CDefine23 { get; set; }
        public string CDefine24 { get; set; }
        public string CDefine25 { get; set; }
        public double? CDefine26 { get; set; }
        public double? CDefine27 { get; set; }
        public byte? Iflag { get; set; }
        public string CItemCode { get; set; }
        public string CItemClass { get; set; }
        public string CItemName { get; set; }
        public string CFree3 { get; set; }
        public string CFree4 { get; set; }
        public string CFree5 { get; set; }
        public string CFree6 { get; set; }
        public string CFree7 { get; set; }
        public string CFree8 { get; set; }
        public string CFree9 { get; set; }
        public string CFree10 { get; set; }
        public byte? BGsp { get; set; }
        public string CUnitId { get; set; }
        public decimal? ITaxPrice { get; set; }
        public decimal? IArrQty { get; set; }
        public decimal? IArrNum { get; set; }
        public decimal? IArrMoney { get; set; }
        public decimal? INatArrMoney { get; set; }
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
        public bool? BTaxCost { get; set; }
        public string CSource { get; set; }
        public string CbCloser { get; set; }
        public byte? Sotype { get; set; }
        public string Sodid { get; set; }
        public int? BomId { get; set; }
        public int? MrpdetailsId { get; set; }
        public decimal? FParentScrp { get; set; }
        public decimal? IMaterialSendQty { get; set; }
        public decimal? Tbaseqtyd { get; set; }
        public byte[] DUfts { get; set; }
        public int? IVtids { get; set; }
        public string Cupsocode { get; set; }
        public int? Cupsoids { get; set; }
        public int? Isosid { get; set; }
        public string Cdemandcode { get; set; }
        public string Cdetailsdemandmemo { get; set; }
        public DateTime? DbCloseDate { get; set; }
        public DateTime? DbCloseTime { get; set; }
        public int? IVouchRowNo { get; set; }
        public decimal? Freceivedqty { get; set; }
        public decimal? Freceivednum { get; set; }
        public string CbMemo { get; set; }
        public int? ICusBomId { get; set; }
        public string Cbsysbarcode { get; set; }
        public string Csocode { get; set; }
        public int? Irowno { get; set; }
        public byte? BomType { get; set; }
        public string ISourceMocode { get; set; }
        public int? ISourceModetailsId { get; set; }
        public decimal? Imrpqty { get; set; }
        public decimal? Freworkquantity { get; set; }
        public decimal? Freworknum { get; set; }
        public byte? IProductType { get; set; }
        public int? IMainMoDetailsId { get; set; }
        public int? IMainMoMaterialsId { get; set; }
        public string CMainInvCode { get; set; }
        public byte? Isoordertype { get; set; }
        public int? Iorderdid { get; set; }
        public string Csoordercode { get; set; }
        public int? Iorderseq { get; set; }
        public string CPlanLotNumber { get; set; }
        public string CFactoryCode { get; set; }

        public virtual OmMomain Mo { get; set; }
        public virtual ICollection<OmMomaterials> OmMomaterials { get; set; }
    }
}
