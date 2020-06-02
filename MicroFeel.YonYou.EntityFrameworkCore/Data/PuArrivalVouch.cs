using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class PuArrivalVouch
    {
        public int IVtid { get; set; }
        public byte[] Ufts { get; set; }
        public int Id { get; set; }
        public string CCode { get; set; }
        public string CPtcode { get; set; }
        public DateTime DDate { get; set; }
        public string CVenCode { get; set; }
        public string CDepCode { get; set; }
        public string CPersonCode { get; set; }
        public string CPayCode { get; set; }
        public string CSccode { get; set; }
        public string CexchName { get; set; }
        public double? IExchRate { get; set; }
        public decimal? ITaxRate { get; set; }
        public string CMemo { get; set; }
        public string CBusType { get; set; }
        public string CMaker { get; set; }
        public int BNegative { get; set; }
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
        public string CDefine11 { get; set; }
        public string CDefine12 { get; set; }
        public string CDefine13 { get; set; }
        public string CDefine14 { get; set; }
        public int? CDefine15 { get; set; }
        public double? CDefine16 { get; set; }
        public string Ccloser { get; set; }
        public byte? IDiscountTaxType { get; set; }
        public byte IBillType { get; set; }
        public string Cvouchtype { get; set; }
        public string Cgeneralordercode { get; set; }
        public string Ctmcode { get; set; }
        public string Cincotermcode { get; set; }
        public string Ctransordercode { get; set; }
        public DateTime? Dportdate { get; set; }
        public string Csportcode { get; set; }
        public string Caportcode { get; set; }
        public string Csvencode { get; set; }
        public string Carrivalplace { get; set; }
        public DateTime? Dclosedate { get; set; }
        public int? Idec { get; set; }
        public bool? Bcal { get; set; }
        public string Guid { get; set; }
        public DateTime? CMakeTime { get; set; }
        public DateTime? CModifyTime { get; set; }
        public DateTime? CModifyDate { get; set; }
        public string CReviser { get; set; }
        public int? Iverifystate { get; set; }
        public DateTime? CAuditDate { get; set; }
        public DateTime? Caudittime { get; set; }
        public string Cverifier { get; set; }
        public int? Iverifystateex { get; set; }
        public int? Ireturncount { get; set; }
        public bool? IsWfControlled { get; set; }
        public string CVenPuomprotocol { get; set; }
        public string Cchanger { get; set; }
        public int? Iflowid { get; set; }
        public int? IPrintCount { get; set; }
        public string Ccleanver { get; set; }
        public string Cpocode { get; set; }
        public string Csysbarcode { get; set; }
        public string CCurrentAuditor { get; set; }

        public virtual Department CDepCodeNavigation { get; set; }
        public virtual Person CPersonCodeNavigation { get; set; }
        public virtual Vendor CVenCodeNavigation { get; set; }
    }
}
