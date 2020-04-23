using System;
using System.Collections.Generic;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class OmMomain
    {
        public OmMomain()
        {
            OmModetails = new HashSet<OmModetails>();
        }

        public int Moid { get; set; }
        public string CCode { get; set; }
        public DateTime DDate { get; set; }
        public string CVenCode { get; set; }
        public string CDepCode { get; set; }
        public string CPersonCode { get; set; }
        public string CPtcode { get; set; }
        public string CArrivalPlace { get; set; }
        public string CSccode { get; set; }
        public string CexchName { get; set; }
        public decimal? Nflat { get; set; }
        public double? ITaxRate { get; set; }
        public string CPayCode { get; set; }
        public decimal? ICost { get; set; }
        public decimal? IBargain { get; set; }
        public string CMemo { get; set; }
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
        public byte CState { get; set; }
        public int IReturnCount { get; set; }
        public int IVerifyStateNew { get; set; }
        public int IsWfControlled { get; set; }
        public string CModifier { get; set; }
        public DateTime? DCreateTime { get; set; }
        public DateTime? DModifyDate { get; set; }
        public DateTime? DModifyTime { get; set; }
        public DateTime? DVerifyDate { get; set; }
        public DateTime? DVerifyTime { get; set; }
        public DateTime? DAlterTime { get; set; }
        public string CChangeVerifier { get; set; }
        public DateTime? DChangeVerifyDate { get; set; }
        public DateTime? DChangeVerifyTime { get; set; }
        public string CVenPuomprotocol { get; set; }
        public int? IPrintCount { get; set; }
        public DateTime? DCloseDate { get; set; }
        public DateTime? DCloseTime { get; set; }
        public string Ccleanver { get; set; }
        public string CContactCode { get; set; }
        public string CVenPerson { get; set; }
        public string CVenBank { get; set; }
        public string CVenAccount { get; set; }
        public string Csrccode { get; set; }
        public string Csysbarcode { get; set; }
        public string CCurrentAuditor { get; set; }
        public byte? IOrderType { get; set; }
        public byte? BRework { get; set; }

        public virtual ICollection<OmModetails> OmModetails { get; set; }
    }
}
