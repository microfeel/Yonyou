using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class TransVouch
    {
        public string CTvcode { get; set; }
        public DateTime DTvdate { get; set; }
        public string COwhCode { get; set; }
        public string CIwhCode { get; set; }
        public string COdepCode { get; set; }
        public string CIdepCode { get; set; }
        public string CPersonCode { get; set; }
        public string CIrdCode { get; set; }
        public string COrdCode { get; set; }
        public string CTvmemo { get; set; }
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
        public string CAccounter { get; set; }
        public string CMaker { get; set; }
        public float? INetLock { get; set; }
        public int Id { get; set; }
        public int VtId { get; set; }
        public string CVerifyPerson { get; set; }
        public DateTime? DVerifyDate { get; set; }
        public string CPspcode { get; set; }
        public string CMpoCode { get; set; }
        public double? IQuantity { get; set; }
        public int? BTransFlag { get; set; }
        public string CDefine11 { get; set; }
        public string CDefine12 { get; set; }
        public string CDefine13 { get; set; }
        public string CDefine14 { get; set; }
        public int? CDefine15 { get; set; }
        public double? CDefine16 { get; set; }
        public byte[] Ufts { get; set; }
        public int? Iproorderid { get; set; }
        public string COrderType { get; set; }
        public string CTranRequestCode { get; set; }
        public string CVersion { get; set; }
        public int? BomId { get; set; }
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
        public string CAppTvcode { get; set; }
        public string Csource { get; set; }
        public string Itransflag { get; set; }
        public string CModifyPerson { get; set; }
        public DateTime? DModifyDate { get; set; }
        public DateTime? Dnmaketime { get; set; }
        public DateTime? Dnmodifytime { get; set; }
        public DateTime? Dnverifytime { get; set; }
        public int? Ireturncount { get; set; }
        public int? Iverifystate { get; set; }
        public int? Iswfcontrolled { get; set; }
        public string Cbustype { get; set; }
        public string CSourceCodeLs { get; set; }
        public int? IPrintCount { get; set; }
        public string Csourceguid { get; set; }
        public string Csysbarcode { get; set; }
        public string CCurrentAuditor { get; set; }
        public string Csyssource { get; set; }
        public string Csyssourceid { get; set; }

        public virtual Department CIdepCodeNavigation { get; set; }
        public virtual Warehouse CIwhCodeNavigation { get; set; }
        public virtual Department COdepCodeNavigation { get; set; }
        public virtual Warehouse COwhCodeNavigation { get; set; }
        public virtual Person CPersonCodeNavigation { get; set; }
    }
}
