using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class Person
    {
        public Person()
        {
            MaterialAppVouch = new HashSet<MaterialAppVouch>();
            PoPomain = new HashSet<PoPomain>();
            PuArrivalVouch = new HashSet<PuArrivalVouch>();
            SoSomain = new HashSet<SoSomain>();
            TransVouch = new HashSet<TransVouch>();
        }

        public string CPersonCode { get; set; }
        public string CPersonName { get; set; }
        public string CDepCode { get; set; }
        public string CPersonProp { get; set; }
        public double? FCreditQuantity { get; set; }
        public int? ICreDate { get; set; }
        public string CCreGrade { get; set; }
        public double? ILowRate { get; set; }
        public string COfferGrade { get; set; }
        public double? IOfferRate { get; set; }
        public byte[] Pubufts { get; set; }
        public string CPersonEmail { get; set; }
        public string CPersonPhone { get; set; }
        public DateTime? DPvalidDate { get; set; }
        public DateTime? DPinValidDate { get; set; }

        public virtual Department CDepCodeNavigation { get; set; }
        public virtual ICollection<MaterialAppVouch> MaterialAppVouch { get; set; }
        public virtual ICollection<PoPomain> PoPomain { get; set; }
        public virtual ICollection<PuArrivalVouch> PuArrivalVouch { get; set; }
        public virtual ICollection<SoSomain> SoSomain { get; set; }
        public virtual ICollection<TransVouch> TransVouch { get; set; }
    }
}
