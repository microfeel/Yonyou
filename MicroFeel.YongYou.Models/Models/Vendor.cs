﻿using System;
using System.Collections.Generic;

namespace MicroFeel.YongYou.Models.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            PoPomain = new HashSet<PoPomain>();
            PuArrivalVouch = new HashSet<PuArrivalVouch>();
        }

        public string CVenCode { get; set; }
        public string CVenName { get; set; }
        public string CVenAbbName { get; set; }
        public string CVccode { get; set; }
        public string CDccode { get; set; }
        public string CTrade { get; set; }
        public string CVenAddress { get; set; }
        public string CVenPostCode { get; set; }
        public string CVenRegCode { get; set; }
        public string CVenBank { get; set; }
        public string CVenAccount { get; set; }
        public DateTime? DVenDevDate { get; set; }
        public string CVenLperson { get; set; }
        public string CVenPhone { get; set; }
        public string CVenFax { get; set; }
        public string CVenEmail { get; set; }
        public string CVenPerson { get; set; }
        public string CVenBp { get; set; }
        public string CVenHand { get; set; }
        public string CVenPperson { get; set; }
        public double? IVenDisRate { get; set; }
        public string IVenCreGrade { get; set; }
        public double? IVenCreLine { get; set; }
        public int? IVenCreDate { get; set; }
        public string CVenPayCond { get; set; }
        public string CVenIaddress { get; set; }
        public string CVenItype { get; set; }
        public string CVenHeadCode { get; set; }
        public string CVenWhCode { get; set; }
        public string CVenDepart { get; set; }
        public double? IApmoney { get; set; }
        public DateTime? DLastDate { get; set; }
        public double? ILastMoney { get; set; }
        public DateTime? DLrdate { get; set; }
        public double? ILrmoney { get; set; }
        public DateTime? DEndDate { get; set; }
        public int? IFrequency { get; set; }
        public bool? BVenTax { get; set; }
        public string CVenDefine1 { get; set; }
        public string CVenDefine2 { get; set; }
        public string CVenDefine3 { get; set; }
        public string CCreatePerson { get; set; }
        public string CModifyPerson { get; set; }
        public DateTime? DModifyDate { get; set; }
        public string CRelCustomer { get; set; }
        public int? IId { get; set; }
        public string CBarCode { get; set; }
        public string CVenDefine4 { get; set; }
        public string CVenDefine5 { get; set; }
        public string CVenDefine6 { get; set; }
        public string CVenDefine7 { get; set; }
        public string CVenDefine8 { get; set; }
        public string CVenDefine9 { get; set; }
        public string CVenDefine10 { get; set; }
        public int? CVenDefine11 { get; set; }
        public int? CVenDefine12 { get; set; }
        public double? CVenDefine13 { get; set; }
        public double? CVenDefine14 { get; set; }
        public DateTime? CVenDefine15 { get; set; }
        public DateTime? CVenDefine16 { get; set; }
        public byte[] Pubufts { get; set; }
        public double? FRegistFund { get; set; }
        public int? IEmployeeNum { get; set; }
        public short? IGradeAbc { get; set; }
        public string CMemo { get; set; }
        public bool? BLicenceDate { get; set; }
        public DateTime? DLicenceSdate { get; set; }
        public DateTime? DLicenceEdate { get; set; }
        public int? ILicenceAdays { get; set; }
        public bool? BBusinessDate { get; set; }
        public DateTime? DBusinessSdate { get; set; }
        public DateTime? DBusinessEdate { get; set; }
        public int? IBusinessAdays { get; set; }
        public bool? BProxyDate { get; set; }
        public DateTime? DProxySdate { get; set; }
        public DateTime? DProxyEdate { get; set; }
        public int? IProxyAdays { get; set; }
        public bool? BPassGmp { get; set; }
        public bool? BVenCargo { get; set; }
        public bool? BProxyForeign { get; set; }
        public bool? BVenService { get; set; }
        public string CVenTradeCcode { get; set; }
        public string CVenBankCode { get; set; }
        public string CVenExchName { get; set; }
        public short IVenGsptype { get; set; }
        public short? IVenGspauth { get; set; }
        public string CVenGspauthNo { get; set; }
        public string CVenBusinessNo { get; set; }
        public string CVenLicenceNo { get; set; }
        public bool? BVenOverseas { get; set; }
        public bool? BVenAccPeriodMng { get; set; }
        public string CVenPuomprotocol { get; set; }
        public string CVenOtherProtocol { get; set; }
        public string CVenCountryCode { get; set; }
        public string CVenEnName { get; set; }
        public string CVenEnAddr1 { get; set; }
        public string CVenEnAddr2 { get; set; }
        public string CVenEnAddr3 { get; set; }
        public string CVenEnAddr4 { get; set; }
        public string CVenPortCode { get; set; }
        public string CVenPrimaryVen { get; set; }
        public double? FVenCommisionRate { get; set; }
        public double? FVenInsueRate { get; set; }
        public bool? BVenHomeBranch { get; set; }
        public string CVenBranchAddr { get; set; }
        public string CVenBranchPhone { get; set; }
        public string CVenBranchPerson { get; set; }
        public string CVenSscode { get; set; }
        public string COmwhCode { get; set; }
        public string CVenCmprotocol { get; set; }
        public string CVenImprotocol { get; set; }
        public double? IVenTaxRate { get; set; }
        public DateTime DVenCreateDatetime { get; set; }
        public string CVenMnemCode { get; set; }
        public Guid? CVenContactCode { get; set; }
        public string Cvenbankall { get; set; }
        public bool? BIsVenAttachFile { get; set; }
        public string CLicenceRange { get; set; }
        public string CBusinessRange { get; set; }
        public string CVenGsprange { get; set; }
        public DateTime? DVenGspedate { get; set; }
        public DateTime? DVenGspsdate { get; set; }
        public int? IVenGspadays { get; set; }
        public bool? BRetail { get; set; }

        public virtual Department CVenDepartNavigation { get; set; }
        public virtual ICollection<PoPomain> PoPomain { get; set; }
        public virtual ICollection<PuArrivalVouch> PuArrivalVouch { get; set; }
    }
}
