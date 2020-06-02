using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            DispatchLists = new HashSet<DispatchLists>();
            MaterialAppVouchs = new HashSet<MaterialAppVouchs>();
            PuArrivalVouchs = new HashSet<PuArrivalVouchs>();
            TransVouchCIwhCodeNavigation = new HashSet<TransVouch>();
            TransVouchCOwhCodeNavigation = new HashSet<TransVouch>();
            Vendor = new HashSet<Vendor>();
        }

        public string CWhCode { get; set; }
        public string CWhName { get; set; }
        public string CDepCode { get; set; }
        public string CWhAddress { get; set; }
        public string CWhPhone { get; set; }
        public string CWhPerson { get; set; }
        public string CWhValueStyle { get; set; }
        public bool BWhPos { get; set; }
        public double? IWhFundQuota { get; set; }
        public string CMonth { get; set; }
        public string CWhMemo { get; set; }
        public bool? BFreeze { get; set; }
        public string CBarCode { get; set; }
        public bool? BMrp { get; set; }
        public byte[] Pubufts { get; set; }
        public bool? BRop { get; set; }
        public short? IFrequency { get; set; }
        public string CFrequency { get; set; }
        public short? IDays { get; set; }
        public DateTime? DLastDate { get; set; }
        public short IWhproperty { get; set; }
        public bool? BShop { get; set; }
        public bool? BControlSerial { get; set; }
        public bool? BInCost { get; set; }
        public bool? BInAvailCalcu { get; set; }
        public bool? BProxyWh { get; set; }
        public short ISaconMode { get; set; }
        public short IExconMode { get; set; }
        public short IStconMode { get; set; }
        public bool? BBondedWh { get; set; }
        public bool? BWhAsset { get; set; }
        public double? FWhQuota { get; set; }
        public DateTime? DWhEndDate { get; set; }
        public bool? BCheckSubitemCost { get; set; }
        public string CPickPos { get; set; }
        public bool? BEb { get; set; }
        public DateTime? DModifyDate { get; set; }
        public string CWareGroupCode { get; set; }
        public string CProvince { get; set; }
        public string CCity { get; set; }
        public string CCounty { get; set; }
        public string CFactoryCode { get; set; }

        public virtual Department CDepCodeNavigation { get; set; }
        public virtual ICollection<DispatchLists> DispatchLists { get; set; }
        public virtual ICollection<MaterialAppVouchs> MaterialAppVouchs { get; set; }
        public virtual ICollection<PuArrivalVouchs> PuArrivalVouchs { get; set; }
        public virtual ICollection<TransVouch> TransVouchCIwhCodeNavigation { get; set; }
        public virtual ICollection<TransVouch> TransVouchCOwhCodeNavigation { get; set; }
        public virtual ICollection<Vendor> Vendor { get; set; }
    }
}
