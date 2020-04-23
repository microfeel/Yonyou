using System;
using System.Collections.Generic;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class PoPomain
    {
        public string CPoid { get; set; }
        public DateTime DPodate { get; set; }
        public string CVenCode { get; set; }
        public string CDepCode { get; set; }
        public string CPersonCode { get; set; }
        public string CPtcode { get; set; }
        public string CArrivalPlace { get; set; }
        public string CSccode { get; set; }
        public string CexchName { get; set; }
        public double? Nflat { get; set; }
        public double? ITaxRate { get; set; }
        public string CPayCode { get; set; }
        public decimal? ICost { get; set; }
        public decimal? IBargain { get; set; }
        public string CMemo { get; set; }
        public byte? CState { get; set; }
        public string CPeriod { get; set; }
        public string CMaker { get; set; }
        public string CVerifier { get; set; }
        public string CCloser { get; set; }
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
        public int Poid { get; set; }
        public int IVtid { get; set; }
        public byte[] Ufts { get; set; }
        public string CChanger { get; set; }
        public string CBusType { get; set; }
        public string CDefine11 { get; set; }
        public string CDefine12 { get; set; }
        public string CDefine13 { get; set; }
        public string CDefine14 { get; set; }
        public int? CDefine15 { get; set; }
        public double? CDefine16 { get; set; }
        public string CLocker { get; set; }
        public byte? IDiscountTaxType { get; set; }
        public int? Iverifystateex { get; set; }
        public int? Ireturncount { get; set; }
        public bool? IsWfControlled { get; set; }
        public DateTime? Cmaketime { get; set; }
        public DateTime? CModifyTime { get; set; }
        public DateTime? CAuditTime { get; set; }
        public DateTime? CAuditDate { get; set; }
        public DateTime? CModifyDate { get; set; }
        public string CReviser { get; set; }
        public string CVenPuomprotocol { get; set; }
        public string CChangVerifier { get; set; }
        public DateTime? CChangAuditTime { get; set; }
        public DateTime? CChangAuditDate { get; set; }
        public short? IBgOverFlag { get; set; }
        public string CBgAuditor { get; set; }
        public string CBgAuditTime { get; set; }
        public short? ControlResult { get; set; }
        public int? Iflowid { get; set; }
        public int? IPrintCount { get; set; }
        public DateTime? DCloseDate { get; set; }
        public DateTime? DCloseTime { get; set; }
        public string Ccleanver { get; set; }
        public string CContactCode { get; set; }
        public string CVenPerson { get; set; }
        public string CVenBank { get; set; }
        public string CVenAccount { get; set; }
        public string Cappcode { get; set; }
        public string Csysbarcode { get; set; }
        public string CCurrentAuditor { get; set; }
        public string CGcrouteCode { get; set; }
        public bool? BGctransforming { get; set; }
        public string YycRespStatus { get; set; }
        public string YycReason { get; set; }
        public string Csyssource { get; set; }
        public string Csyssourceid { get; set; }
        public string Clshwhcode { get; set; }

        public virtual Department CDepCodeNavigation { get; set; }
        public virtual Person CPersonCodeNavigation { get; set; }
        public virtual Vendor CVenCodeNavigation { get; set; }
    }
}
