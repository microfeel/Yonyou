using System;
using System.Collections.Generic;

namespace MicroFeel.YongYou.Models.Models
{
    /// <summary>
    /// 销售出库单主表
    /// </summary>
    public partial class Rdrecord32
    {
        public long Id { get; set; }
        public byte BRdFlag { get; set; }
        public string CVouchType { get; set; }
        public string CBusType { get; set; }
        public string CSource { get; set; }
        public string CBusCode { get; set; }
        public string CWhCode { get; set; }
        public DateTime DDate { get; set; }
        public string CCode { get; set; }
        public string CRdCode { get; set; }
        public string CDepCode { get; set; }
        public string CPersonCode { get; set; }
        public string CPtcode { get; set; }
        public string CStcode { get; set; }
        public string CCusCode { get; set; }
        public string CVenCode { get; set; }
        public string COrderCode { get; set; }
        public string CArvcode { get; set; }
        public long? CBillCode { get; set; }
        public long? CDlcode { get; set; }
        public string CProBatch { get; set; }
        public string CHandler { get; set; }
        public string CMemo { get; set; }
        public bool? BTransFlag { get; set; }
        public string CAccounter { get; set; }
        public string CMaker { get; set; }
        public string CDefine1 { get; set; }
        public string CDefine2 { get; set; }
        public string CDefine3 { get; set; }
        public DateTime? CDefine4 { get; set; }
        public int? CDefine5 { get; set; }
        public DateTime? CDefine6 { get; set; }
        public double? CDefine7 { get; set; }
        public string CDefine8 { get; set; }
        public string CDefine9 { get; set; }
        public string CDefine10 { get; set; }
        public string DKeepDate { get; set; }
        public DateTime? DVeriDate { get; set; }
        public bool? Bpufirst { get; set; }
        public bool? Biafirst { get; set; }
        public double? IMquantity { get; set; }
        public DateTime? DArvdate { get; set; }
        public string CChkCode { get; set; }
        public DateTime? DChkDate { get; set; }
        public string CChkPerson { get; set; }
        public int? VtId { get; set; }
        public bool? BIsStqc { get; set; }
        public string CDefine11 { get; set; }
        public string CDefine12 { get; set; }
        public string CDefine13 { get; set; }
        public string CDefine14 { get; set; }
        public int? CDefine15 { get; set; }
        public double? CDefine16 { get; set; }
        public string Gspcheck { get; set; }
        public string Isalebillid { get; set; }
        public byte[] Ufts { get; set; }
        public double? IExchRate { get; set; }
        public string CExchName { get; set; }
        public string CShipAddress { get; set; }
        public string Caddcode { get; set; }
        public bool? BOmfirst { get; set; }
        public bool? BFromPreYear { get; set; }
        public bool? BIsLsQuery { get; set; }
        public short? BIsComplement { get; set; }
        public byte? IDiscountTaxType { get; set; }
        public int? Ireturncount { get; set; }
        public int? Iverifystate { get; set; }
        public int? Iswfcontrolled { get; set; }
        public string CModifyPerson { get; set; }
        public DateTime? DModifyDate { get; set; }
        public DateTime? Dnmaketime { get; set; }
        public DateTime? Dnmodifytime { get; set; }
        public DateTime? Dnverifytime { get; set; }
        public int? Bredvouch { get; set; }
        public int? IFlowId { get; set; }
        public string CPzid { get; set; }
        public string CSourceLs { get; set; }
        public string CSourceCodeLs { get; set; }
        public int? IPrintCount { get; set; }
        public string Csysbarcode { get; set; }
        public string CCurrentAuditor { get; set; }
        public string Cinvoicecompany { get; set; }
        public decimal? FEbweight { get; set; }
        public string CEbweightUnit { get; set; }
        public string CEbexpressCode { get; set; }
        public byte? BScanExpress { get; set; }
        public string Cinspector { get; set; }
        public DateTime? Dinspecttime { get; set; }
        public string Cweighter { get; set; }
        public DateTime? Dweighttime { get; set; }
        public byte? BUpLoaded { get; set; }
        public Guid? Outid { get; set; }
        public byte? IsMddispatch { get; set; }
        public string CCheckSignFlag { get; set; }
        public string CGcrouteCode { get; set; }
    }
}
