using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class SoSomain
    {
        public string CStcode { get; set; }
        public DateTime DDate { get; set; }
        public string CSocode { get; set; }
        public string CCusCode { get; set; }
        public string CDepCode { get; set; }
        public string CPersonCode { get; set; }
        public string CSccode { get; set; }
        public string CCusOaddress { get; set; }
        public string CPayCode { get; set; }
        public string CexchName { get; set; }
        public double? IExchRate { get; set; }
        public double? ITaxRate { get; set; }
        public decimal? IMoney { get; set; }
        public string CMemo { get; set; }
        public byte? IStatus { get; set; }
        public string CMaker { get; set; }
        public string CVerifier { get; set; }
        public string CCloser { get; set; }
        public bool? BDisFlag { get; set; }
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
        public bool? BReturnFlag { get; set; }
        public string CCusName { get; set; }
        public bool? BOrder { get; set; }
        public int Id { get; set; }
        public int IVtid { get; set; }
        public byte[] Ufts { get; set; }
        public string CChanger { get; set; }
        public string CBusType { get; set; }
        public string CCreChpName { get; set; }
        public string CDefine11 { get; set; }
        public string CDefine12 { get; set; }
        public string CDefine13 { get; set; }
        public string CDefine14 { get; set; }
        public int? CDefine15 { get; set; }
        public double? CDefine16 { get; set; }
        public string Coppcode { get; set; }
        public string CLocker { get; set; }
        public DateTime? DPreMoDateBt { get; set; }
        public DateTime? DPreDateBt { get; set; }
        public string Cgatheringplan { get; set; }
        public string Caddcode { get; set; }
        public int? Iverifystate { get; set; }
        public byte? Ireturncount { get; set; }
        public byte? Iswfcontrolled { get; set; }
        public string Icreditstate { get; set; }
        public string Cmodifier { get; set; }
        public DateTime? Dmoddate { get; set; }
        public DateTime? Dverifydate { get; set; }
        public string Ccusperson { get; set; }
        public DateTime? Dcreatesystime { get; set; }
        public DateTime? Dverifysystime { get; set; }
        public DateTime? Dmodifysystime { get; set; }
        public int? Iflowid { get; set; }
        public bool? Bcashsale { get; set; }
        public string Cgathingcode { get; set; }
        public string CChangeVerifier { get; set; }
        public DateTime? DChangeVerifyDate { get; set; }
        public DateTime? DChangeVerifyTime { get; set; }
        public Guid? Outid { get; set; }
        public string Ccuspersoncode { get; set; }
        public DateTime? Dclosedate { get; set; }
        public DateTime? Dclosesystime { get; set; }
        public double? IPrintCount { get; set; }
        public double? Fbookratio { get; set; }
        public bool? Bmustbook { get; set; }
        public decimal? Fbooksum { get; set; }
        public decimal? Fbooknatsum { get; set; }
        public decimal? Fgbooksum { get; set; }
        public decimal? Fgbooknatsum { get; set; }
        public string Csvouchtype { get; set; }
        public string CCrmPersonCode { get; set; }
        public string CCrmPersonName { get; set; }
        public string CMainPersonCode { get; set; }
        public string CSysBarCode { get; set; }
        public int? Ioppid { get; set; }
        public string OptntyName { get; set; }
        public string CCurrentAuditor { get; set; }
        public short? ContractStatus { get; set; }
        public string Csscode { get; set; }
        public string Cinvoicecompany { get; set; }
        public string CAttachment { get; set; }
        public string CEbtrnumber { get; set; }
        public string CEbbuyer { get; set; }
        public string CEbbuyerNote { get; set; }
        public string Ccontactname { get; set; }
        public string CEbprovince { get; set; }
        public string CEbcity { get; set; }
        public string CEbdistrict { get; set; }
        public string Cmobilephone { get; set; }
        public string CInvoiceCusName { get; set; }
        public string CGcrouteCode { get; set; }
        public string Cbcode { get; set; }

        public virtual Department CDepCodeNavigation { get; set; }
        public virtual Person CPersonCodeNavigation { get; set; }
    }
}
