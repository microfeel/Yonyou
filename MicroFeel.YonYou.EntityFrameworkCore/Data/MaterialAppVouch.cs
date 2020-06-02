using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class MaterialAppVouch
    {
        public MaterialAppVouch()
        {
            MaterialAppVouchs = new HashSet<MaterialAppVouchs>();
        }

        public int Id { get; set; }
        public DateTime DDate { get; set; }
        public string CCode { get; set; }
        public string CRdCode { get; set; }
        public string CDepCode { get; set; }
        public string CPersonCode { get; set; }
        public string CItemClass { get; set; }
        public string CItemCode { get; set; }
        public string CName { get; set; }
        public string CItemCname { get; set; }
        public string CHandler { get; set; }
        public string CMemo { get; set; }
        public string CCloser { get; set; }
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
        public DateTime? DVeriDate { get; set; }
        public int? VtId { get; set; }
        public string CDefine11 { get; set; }
        public string CDefine12 { get; set; }
        public string CDefine13 { get; set; }
        public string CDefine14 { get; set; }
        public int? CDefine15 { get; set; }
        public double? CDefine16 { get; set; }
        public byte[] Ufts { get; set; }
        public int? Ireturncount { get; set; }
        public int? Iverifystate { get; set; }
        public int? Iswfcontrolled { get; set; }
        public string CModifyPerson { get; set; }
        public DateTime? DModifyDate { get; set; }
        public DateTime? Dnmaketime { get; set; }
        public DateTime? Dnmodifytime { get; set; }
        public DateTime? Dnverifytime { get; set; }
        public int? IPrintCount { get; set; }
        public string CSource { get; set; }
        public string Cvencode { get; set; }
        public decimal? Imquantity { get; set; }
        public string Csysbarcode { get; set; }
        public string CCurrentAuditor { get; set; }
        public string CChanger { get; set; }

        public virtual Department CDepCodeNavigation { get; set; }
        public virtual Person CPersonCodeNavigation { get; set; }
        public virtual ICollection<MaterialAppVouchs> MaterialAppVouchs { get; set; }
    }
}
