using System;
using System.Collections.Generic;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class Department
    {
        public Department()
        {
            Person = new HashSet<Person>();
            PoPomain = new HashSet<PoPomain>();
            PuArrivalVouch = new HashSet<PuArrivalVouch>();
            SoSomain = new HashSet<SoSomain>();
            Vendor = new HashSet<Vendor>();
        }

        public string CDepCode { get; set; }
        public bool? BDepEnd { get; set; }
        public string CDepName { get; set; }
        public byte IDepGrade { get; set; }
        public string CDepPerson { get; set; }
        public string CDepProp { get; set; }
        public string CDepPhone { get; set; }
        public string CDepAddress { get; set; }
        public string CDepMemo { get; set; }
        public double? ICreLine { get; set; }
        public string CCreGrade { get; set; }
        public int? ICreDate { get; set; }
        public string COfferGrade { get; set; }
        public double? IOfferRate { get; set; }
        public byte[] Pubufts { get; set; }
        public bool? BShop { get; set; }
        public Guid CDepGuid { get; set; }
        public DateTime? DDepBeginDate { get; set; }
        public DateTime? DDepEndDate { get; set; }
        public string VAuthorizeDoc { get; set; }
        public string VAuthorizeUnit { get; set; }
        public string CDepFax { get; set; }
        public string CDepPostCode { get; set; }
        public string CDepEmail { get; set; }
        public string CDepType { get; set; }
        public int? BInheritDutyBasic { get; set; }
        public int? BInheritWorkCalendar { get; set; }
        public string CDutyCode { get; set; }
        public string CRestCode { get; set; }
        public bool? BIm { get; set; }
        public string CDepNameEn { get; set; }
        public bool? BRetail { get; set; }
        public string CDepFullName { get; set; }
        public int? IDepOrder { get; set; }
        public string CDepLeader { get; set; }
        public DateTime? DModifyDate { get; set; }
        public string CEspaceMembId { get; set; }

        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<PoPomain> PoPomain { get; set; }
        public virtual ICollection<PuArrivalVouch> PuArrivalVouch { get; set; }
        public virtual ICollection<SoSomain> SoSomain { get; set; }
        public virtual ICollection<Vendor> Vendor { get; set; }
    }
}
