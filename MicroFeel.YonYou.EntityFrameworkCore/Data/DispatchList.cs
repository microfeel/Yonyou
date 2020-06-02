﻿using System;
using System.Collections.Generic;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class DispatchList
    {
        public int Dlid { get; set; }
        public string CDlcode { get; set; }
        public string CVouchType { get; set; }
        public string CStcode { get; set; }
        public DateTime DDate { get; set; }
        public string CRdCode { get; set; }
        public string CDepCode { get; set; }
        public string CPersonCode { get; set; }
        public int? Sbvid { get; set; }
        public string CSbvcode { get; set; }
        public string CSocode { get; set; }
        public string CCusCode { get; set; }
        public string CPayCode { get; set; }
        public string CSccode { get; set; }
        public string CShipAddress { get; set; }
        public string CexchName { get; set; }
        public double IExchRate { get; set; }
        public double? ITaxRate { get; set; }
        public bool BFirst { get; set; }
        public bool BReturnFlag { get; set; }
        public bool BSettleAll { get; set; }
        public string CMemo { get; set; }
        public string CSaleOut { get; set; }
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
        public string CVerifier { get; set; }
        public string CMaker { get; set; }
        public float? INetLock { get; set; }
        public short? ISale { get; set; }
        public string CCusName { get; set; }
        public int IVtid { get; set; }
        public byte[] Ufts { get; set; }
        public string CBusType { get; set; }
        public string CCloser { get; set; }
        public string CAccounter { get; set; }
        public string CCreChpName { get; set; }
        public string CDefine11 { get; set; }
        public string CDefine12 { get; set; }
        public string CDefine13 { get; set; }
        public string CDefine14 { get; set; }
        public int? CDefine15 { get; set; }
        public double? CDefine16 { get; set; }
        public bool? BIafirst { get; set; }
        public int? Ioutgolden { get; set; }
        public string Cgatheringplan { get; set; }
        public DateTime? DCreditStart { get; set; }
        public DateTime? DGatheringDate { get; set; }
        public int? Icreditdays { get; set; }
        public bool? BCredit { get; set; }
        public string Caddcode { get; set; }
        public int? Iverifystate { get; set; }
        public byte? Ireturncount { get; set; }
        public byte? Iswfcontrolled { get; set; }
        public string Icreditstate { get; set; }
        public bool? BArfirst { get; set; }
        public string Cmodifier { get; set; }
        public DateTime? Dmoddate { get; set; }
        public DateTime? Dverifydate { get; set; }
        public string Ccusperson { get; set; }
        public DateTime? Dcreatesystime { get; set; }
        public DateTime? Dverifysystime { get; set; }
        public DateTime? Dmodifysystime { get; set; }
        public string Csvouchtype { get; set; }
        public int? Iflowid { get; set; }
        public bool? Bsigncreate { get; set; }
        public bool? Bcashsale { get; set; }
        public string Cgathingcode { get; set; }
        public string CChanger { get; set; }
        public string CChangeMemo { get; set; }
        public string Outid { get; set; }
        public bool? Bmustbook { get; set; }
        public string CBookDepcode { get; set; }
        public string CBookType { get; set; }
        public bool? BSaUsed { get; set; }
        public bool? Bneedbill { get; set; }
        public bool? Baccswitchflag { get; set; }
        public int? IPrintCount { get; set; }
        public string Ccuspersoncode { get; set; }
        public string CSourceCode { get; set; }
        public bool? Bsaleoutcreatebill { get; set; }
        public string CSysBarCode { get; set; }
        public string CCurrentAuditor { get; set; }
        public string Csscode { get; set; }
        public string Cinvoicecompany { get; set; }
        public decimal? FEbweight { get; set; }
        public string CEbweightUnit { get; set; }
        public string CEbexpressCode { get; set; }
        public long? IEbexpressCoId { get; set; }
        public int? SeparateId { get; set; }
        public byte? BNotToGoldTax { get; set; }
        public string CEbtrnumber { get; set; }
        public string CEbbuyer { get; set; }
        public string CEbbuyerNote { get; set; }
        public string Ccontactname { get; set; }
        public string CEbprovince { get; set; }
        public string CEbcity { get; set; }
        public string CEbdistrict { get; set; }
        public string Cmobilephone { get; set; }
        public string CInvoiceCusName { get; set; }
        public string Cweighter { get; set; }
        public DateTime? Dweighttime { get; set; }
        public string CPickVouchCode { get; set; }
        public string CGcrouteCode { get; set; }
        public string Cbcode { get; set; }

        public virtual Department CDepCodeNavigation { get; set; }
        public virtual Person CPersonCodeNavigation { get; set; }
    }
}
