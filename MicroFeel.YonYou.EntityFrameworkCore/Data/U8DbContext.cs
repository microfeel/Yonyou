using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MicroFeel.YonYou.EntityFrameworkCore.Data
{
    public partial class U8DbContext : DbContext
    {
        public U8DbContext()
        {
        }

        public U8DbContext(DbContextOptions<U8DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ComputationUnit> ComputationUnit { get; set; }
        public virtual DbSet<CurrentStock> CurrentStock { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DispatchList> DispatchList { get; set; }
        public virtual DbSet<DispatchLists> DispatchLists { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryClass> InventoryClass { get; set; }
        public virtual DbSet<MaterialAppVouch> MaterialAppVouch { get; set; }
        public virtual DbSet<MaterialAppVouchs> MaterialAppVouchs { get; set; }
        public virtual DbSet<Materialappd> Materialappd { get; set; }
        public virtual DbSet<Materialappm> Materialappm { get; set; }
        public virtual DbSet<OmModetails> OmModetails { get; set; }
        public virtual DbSet<OmMomain> OmMomain { get; set; }
        public virtual DbSet<OmMomaterials> OmMomaterials { get; set; }
        public virtual DbSet<OmMomaterialsbody> OmMomaterialsbody { get; set; }
        public virtual DbSet<OmMomaterialshead> OmMomaterialshead { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PoPodetails> PoPodetails { get; set; }
        public virtual DbSet<PoPomain> PoPomain { get; set; }
        public virtual DbSet<PuArrHead> PuArrHead { get; set; }
        public virtual DbSet<PuArrbody> PuArrbody { get; set; }
        public virtual DbSet<PuArrivalVouch> PuArrivalVouch { get; set; }
        public virtual DbSet<PuArrivalVouchs> PuArrivalVouchs { get; set; }
        public virtual DbSet<RdRecord01> RdRecord01 { get; set; }
        public virtual DbSet<RdRecord08> RdRecord08 { get; set; }
        public virtual DbSet<RdRecord09> RdRecord09 { get; set; }
        public virtual DbSet<Rdrecord11> Rdrecord11 { get; set; }
        public virtual DbSet<Rdrecord32> Rdrecord32 { get; set; }
        public virtual DbSet<Rdrecord34> Rdrecord34 { get; set; }
        public virtual DbSet<Rdrecords01> Rdrecords01 { get; set; }
        public virtual DbSet<Rdrecords08> Rdrecords08 { get; set; }
        public virtual DbSet<Rdrecords09> Rdrecords09 { get; set; }
        public virtual DbSet<Rdrecords11> Rdrecords11 { get; set; }
        public virtual DbSet<Rdrecords32> Rdrecords32 { get; set; }
        public virtual DbSet<Rdrecords34> Rdrecords34 { get; set; }
        public virtual DbSet<SaDispatchdetailmerp> SaDispatchdetailmerp { get; set; }
        public virtual DbSet<SaDispatchlist> SaDispatchlist { get; set; }
        public virtual DbSet<SaDispatchmainmerp> SaDispatchmainmerp { get; set; }
        public virtual DbSet<SaleOrderSq> SaleOrderSq { get; set; }
        public virtual DbSet<ScmItem> ScmItem { get; set; }
        public virtual DbSet<SoSodetails> SoSodetails { get; set; }
        public virtual DbSet<SoSomain> SoSomain { get; set; }
        public virtual DbSet<TransVouch> TransVouch { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<Zpurpotail> Zpurpotail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=192.168.12.19;database=UFDATA_999_2019;user id=microfeel;password=123.com");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComputationUnit>(entity =>
            {
                entity.HasKey(e => e.CComunitCode);

                entity.HasIndex(e => new { e.CComunitCode, e.CComUnitName, e.CGroupCode })
                    .HasName("IX_MX_comcode_name_gcode");

                entity.Property(e => e.CComunitCode)
                    .HasColumnName("cComunitCode")
                    .HasMaxLength(35);

                entity.Property(e => e.BMainUnit)
                    .IsRequired()
                    .HasColumnName("bMainUnit")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CBarCode)
                    .HasColumnName("cBarCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CComUnitName)
                    .IsRequired()
                    .HasColumnName("cComUnitName")
                    .HasMaxLength(20);

                entity.Property(e => e.CEnPlural)
                    .HasColumnName("cEnPlural")
                    .HasMaxLength(60);

                entity.Property(e => e.CEnSingular)
                    .HasColumnName("cEnSingular")
                    .HasMaxLength(60);

                entity.Property(e => e.CGroupCode)
                    .HasColumnName("cGroupCode")
                    .HasMaxLength(35);

                entity.Property(e => e.CUnitRefInvCode)
                    .HasColumnName("cUnitRefInvCode")
                    .HasMaxLength(20);

                entity.Property(e => e.IChangRate)
                    .HasColumnName("iChangRate")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.INumber).HasColumnName("iNumber");

                entity.Property(e => e.IProportion).HasColumnName("iProportion");

                entity.Property(e => e.Pubufts)
                    .HasColumnName("pubufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<CurrentStock>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.CWhCode, e.CInvCode })
                    .HasName("UnionKey");

                entity.HasIndex(e => new { e.CWhCode, e.CInvCode, e.ItemId, e.CBatch, e.CVmivenCode, e.ISoType, e.ISodid })
                    .HasName("PK_CURRENTSTOCK")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.CInvCode, e.CFree1, e.CFree2, e.CFree3, e.CFree4, e.CFree5, e.CFree6, e.CFree7, e.CFree8, e.CFree9, e.CFree10 })
                    .HasName("ix_currentstock_cinvcode");

                entity.Property(e => e.AutoId)
                    .HasColumnName("AutoID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BStopFlag)
                    .IsRequired()
                    .HasColumnName("bStopFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bgspstop)
                    .IsRequired()
                    .HasColumnName("BGSPSTOP")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CBatch)
                    .IsRequired()
                    .HasColumnName("cBatch")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CCheckState)
                    .IsRequired()
                    .HasColumnName("cCheckState")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CExpirationdate)
                    .HasColumnName("cExpirationdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CInvCode)
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CMassUnit).HasColumnName("cMassUnit");

                entity.Property(e => e.CVmivenCode)
                    .IsRequired()
                    .HasColumnName("cVMIVenCode")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CWhCode)
                    .IsRequired()
                    .HasColumnName("cWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.DExpirationdate)
                    .HasColumnName("dExpirationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLastCheckDate)
                    .HasColumnName("dLastCheckDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLastYearCheckDate)
                    .HasColumnName("dLastYearCheckDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DMdate)
                    .HasColumnName("dMdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVdate)
                    .HasColumnName("dVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FAvaNum)
                    .HasColumnName("fAvaNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FAvaQuantity)
                    .HasColumnName("fAvaQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FDisableNum)
                    .HasColumnName("fDisableNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FDisableQuantity)
                    .HasColumnName("fDisableQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FInNum)
                    .HasColumnName("fInNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FInQuantity)
                    .HasColumnName("fInQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FOutNum)
                    .HasColumnName("fOutNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FOutQuantity)
                    .HasColumnName("fOutQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FPlanNum)
                    .HasColumnName("fPlanNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FPlanQuantity)
                    .HasColumnName("fPlanQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FStopNum)
                    .HasColumnName("fStopNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FStopQuantity)
                    .HasColumnName("fStopQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FTransInNum)
                    .HasColumnName("fTransInNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FTransInQuantity)
                    .HasColumnName("fTransInQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FTransOutNum)
                    .HasColumnName("fTransOutNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FTransOutQuantity)
                    .HasColumnName("fTransOutQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IExpiratDateCalcu).HasColumnName("iExpiratDateCalcu");

                entity.Property(e => e.IMassDate).HasColumnName("iMassDate");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.ISoType)
                    .HasColumnName("iSoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ISodid)
                    .HasColumnName("iSodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Ipenum)
                    .HasColumnName("ipenum")
                    .HasColumnType("decimal(38, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ipeqty)
                    .HasColumnName("ipeqty")
                    .HasColumnType("decimal(38, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CCusCode)
                    .HasName("aaaaaCustomer_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CCccode)
                    .HasName("CustomerClassCustomer");

                entity.HasIndex(e => e.CCusAbbName)
                    .HasName("cCusAbbName")
                    .IsUnique();

                entity.HasIndex(e => e.CCusCode)
                    .HasName("PK_Customer_cCusCode_Clustered_Index")
                    .IsClustered();

                entity.HasIndex(e => e.CCusName)
                    .HasName("cCusName");

                entity.HasIndex(e => e.CDccode)
                    .HasName("DistrictClassCustomer");

                entity.HasIndex(e => e.CPrimaryVen)
                    .HasName("customer_cPrimaryVen_Idx");

                entity.HasIndex(e => e.CRelVendor)
                    .HasName("IX_customer_cRelVendor");

                entity.HasIndex(e => e.DModifyDate);

                entity.HasIndex(e => e.Pubufts)
                    .HasName("Index_Customer_pubufts");

                entity.HasIndex(e => new { e.CCusCode, e.CCusAbbName })
                    .HasName("IX_MX_11_Code_AddName");

                entity.HasIndex(e => new { e.CCusMnemCode, e.CCusCode })
                    .HasName("IX_Customer_cCusCode_cCusMnemCode");

                entity.Property(e => e.CCusCode)
                    .HasColumnName("cCusCode")
                    .HasMaxLength(20);

                entity.Property(e => e.AccountType)
                    .HasColumnName("account_type")
                    .HasColumnType("numeric(22, 0)");

                entity.Property(e => e.AlloctDeptTime)
                    .HasColumnName("alloct_dept_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.AllotUserTime)
                    .HasColumnName("allot_user_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.BBusinessDate)
                    .IsRequired()
                    .HasColumnName("bBusinessDate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCredit)
                    .IsRequired()
                    .HasColumnName("bCredit")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCreditByHead)
                    .IsRequired()
                    .HasColumnName("bCreditByHead")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCreditDate)
                    .IsRequired()
                    .HasColumnName("bCreditDate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCusDomestic)
                    .IsRequired()
                    .HasColumnName("bCusDomestic")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.BCusOverseas)
                    .IsRequired()
                    .HasColumnName("bCusOverseas")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCusState)
                    .IsRequired()
                    .HasColumnName("bCusState")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BHomeBranch)
                    .IsRequired()
                    .HasColumnName("bHomeBranch")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsCusAttachFile).HasColumnName("bIsCusAttachFile");

                entity.Property(e => e.BLicenceDate)
                    .IsRequired()
                    .HasColumnName("bLicenceDate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BLimitSale)
                    .IsRequired()
                    .HasColumnName("bLimitSale")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BOnGpinStore)
                    .HasColumnName("bOnGPinStore")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BProxy)
                    .IsRequired()
                    .HasColumnName("bProxy")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BRequestSign)
                    .IsRequired()
                    .HasColumnName("bRequestSign")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BServiceAttribute)
                    .IsRequired()
                    .HasColumnName("bServiceAttribute")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BShop)
                    .HasColumnName("bShop")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BTransFlag).HasColumnName("bTransFlag");

                entity.Property(e => e.CAddCode)
                    .HasColumnName("cAddCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBranchAddr)
                    .HasColumnName("cBranchAddr")
                    .HasMaxLength(255);

                entity.Property(e => e.CBranchPerson)
                    .HasColumnName("cBranchPerson")
                    .HasMaxLength(50);

                entity.Property(e => e.CBranchPhone)
                    .HasColumnName("cBranchPhone")
                    .HasMaxLength(100);

                entity.Property(e => e.CCccode)
                    .HasColumnName("cCCCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CCity)
                    .HasColumnName("cCity")
                    .HasMaxLength(255);

                entity.Property(e => e.CCounty)
                    .HasColumnName("cCounty")
                    .HasMaxLength(255);

                entity.Property(e => e.CCreatePerson)
                    .HasColumnName("cCreatePerson")
                    .HasMaxLength(20);

                entity.Property(e => e.CCreditAddCode)
                    .HasColumnName("cCreditAddCode")
                    .HasMaxLength(64);

                entity.Property(e => e.CCusAbbName)
                    .IsRequired()
                    .HasColumnName("cCusAbbName")
                    .HasMaxLength(60);

                entity.Property(e => e.CCusAccount)
                    .HasColumnName("cCusAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.CCusAddress)
                    .HasColumnName("cCusAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CCusAddressGuid).HasColumnName("cCusAddressGUID");

                entity.Property(e => e.CCusAppDocNo)
                    .HasColumnName("cCusAppDocNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CCusBank)
                    .HasColumnName("cCusBank")
                    .HasMaxLength(100);

                entity.Property(e => e.CCusBankCode)
                    .HasColumnName("cCusBankCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CCusBp)
                    .HasColumnName("cCusBP")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusBusinessNo)
                    .HasColumnName("cCusBusinessNo")
                    .HasMaxLength(120);

                entity.Property(e => e.CCusBusinessRange)
                    .HasColumnName("cCusBusinessRange")
                    .HasMaxLength(255);

                entity.Property(e => e.CCusCmprotocol)
                    .HasColumnName("cCusCMProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusContactCode).HasColumnName("cCusContactCode");

                entity.Property(e => e.CCusCountryCode)
                    .HasColumnName("cCusCountryCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CCusCreGrade)
                    .HasColumnName("cCusCreGrade")
                    .HasMaxLength(6);

                entity.Property(e => e.CCusCreditCompany)
                    .HasColumnName("cCusCreditCompany")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusDefine1)
                    .HasColumnName("cCusDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusDefine10)
                    .HasColumnName("cCusDefine10")
                    .HasMaxLength(120);

                entity.Property(e => e.CCusDefine11).HasColumnName("cCusDefine11");

                entity.Property(e => e.CCusDefine12).HasColumnName("cCusDefine12");

                entity.Property(e => e.CCusDefine13).HasColumnName("cCusDefine13");

                entity.Property(e => e.CCusDefine14).HasColumnName("cCusDefine14");

                entity.Property(e => e.CCusDefine15)
                    .HasColumnName("cCusDefine15")
                    .HasColumnType("datetime");

                entity.Property(e => e.CCusDefine16)
                    .HasColumnName("cCusDefine16")
                    .HasColumnType("datetime");

                entity.Property(e => e.CCusDefine2)
                    .HasColumnName("cCusDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusDefine3)
                    .HasColumnName("cCusDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusDefine4)
                    .HasColumnName("cCusDefine4")
                    .HasMaxLength(60);

                entity.Property(e => e.CCusDefine5)
                    .HasColumnName("cCusDefine5")
                    .HasMaxLength(60);

                entity.Property(e => e.CCusDefine6)
                    .HasColumnName("cCusDefine6")
                    .HasMaxLength(60);

                entity.Property(e => e.CCusDefine7)
                    .HasColumnName("cCusDefine7")
                    .HasMaxLength(120);

                entity.Property(e => e.CCusDefine8)
                    .HasColumnName("cCusDefine8")
                    .HasMaxLength(120);

                entity.Property(e => e.CCusDefine9)
                    .HasColumnName("cCusDefine9")
                    .HasMaxLength(120);

                entity.Property(e => e.CCusDepart)
                    .HasColumnName("cCusDepart")
                    .HasMaxLength(12);

                entity.Property(e => e.CCusEmail)
                    .HasColumnName("cCusEmail")
                    .HasMaxLength(100);

                entity.Property(e => e.CCusEnAddr1)
                    .HasColumnName("cCusEnAddr1")
                    .HasMaxLength(255);

                entity.Property(e => e.CCusEnAddr2)
                    .HasColumnName("cCusEnAddr2")
                    .HasMaxLength(255);

                entity.Property(e => e.CCusEnAddr3)
                    .HasColumnName("cCusEnAddr3")
                    .HasMaxLength(255);

                entity.Property(e => e.CCusEnAddr4)
                    .HasColumnName("cCusEnAddr4")
                    .HasMaxLength(255);

                entity.Property(e => e.CCusEnName)
                    .HasColumnName("cCusEnName")
                    .HasMaxLength(100);

                entity.Property(e => e.CCusExProtocol)
                    .HasColumnName("cCusExProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusExchName)
                    .HasColumnName("cCusExch_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CCusFax)
                    .HasColumnName("cCusFax")
                    .HasMaxLength(100);

                entity.Property(e => e.CCusGspauthNo)
                    .HasColumnName("cCusGSPAuthNo")
                    .HasMaxLength(120);

                entity.Property(e => e.CCusGspauthRange)
                    .HasColumnName("cCusGSPAuthRange")
                    .HasMaxLength(255);

                entity.Property(e => e.CCusHand)
                    .HasColumnName("cCusHand")
                    .HasMaxLength(100);

                entity.Property(e => e.CCusHeadCode)
                    .HasColumnName("cCusHeadCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusImAgentProtocol)
                    .HasColumnName("cCusImAgentProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusLicenceNo)
                    .HasColumnName("cCusLicenceNo")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusLperson)
                    .HasColumnName("cCusLPerson")
                    .HasMaxLength(100);

                entity.Property(e => e.CCusMnemCode)
                    .HasColumnName("cCusMnemCode")
                    .HasMaxLength(98);

                entity.Property(e => e.CCusMngTypeCode)
                    .HasColumnName("cCusMngTypeCode")
                    .HasMaxLength(32);

                entity.Property(e => e.CCusName)
                    .HasColumnName("cCusName")
                    .HasMaxLength(98);

                entity.Property(e => e.CCusOaddress)
                    .HasColumnName("cCusOAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CCusOtherProtocol)
                    .HasColumnName("cCusOtherProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusOtype)
                    .HasColumnName("cCusOType")
                    .HasMaxLength(10);

                entity.Property(e => e.CCusPayCond)
                    .HasColumnName("cCusPayCond")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusPerson)
                    .HasColumnName("cCusPerson")
                    .HasMaxLength(50);

                entity.Property(e => e.CCusPhone)
                    .HasColumnName("cCusPhone")
                    .HasMaxLength(100);

                entity.Property(e => e.CCusPortCode)
                    .HasColumnName("cCusPortCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CCusPostCode)
                    .HasColumnName("cCusPostCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusPperson)
                    .HasColumnName("cCusPPerson")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusRegCode)
                    .HasColumnName("cCusRegCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CCusSaprotocol)
                    .HasColumnName("cCusSAProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusSscode)
                    .HasColumnName("cCusSSCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusTradeCcode)
                    .HasColumnName("cCusTradeCCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CCusWhCode)
                    .HasColumnName("cCusWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CDccode)
                    .HasColumnName("cDCCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CInvoiceCompany)
                    .HasColumnName("cInvoiceCompany")
                    .HasMaxLength(60);

                entity.Property(e => e.CLicenceNo)
                    .HasColumnName("cLicenceNo")
                    .HasMaxLength(120);

                entity.Property(e => e.CLicenceRange)
                    .HasColumnName("cLicenceRange")
                    .HasMaxLength(255);

                entity.Property(e => e.CLocationSite)
                    .HasColumnName("cLocationSite")
                    .HasMaxLength(128);

                entity.Property(e => e.CLtcCustomerCode)
                    .HasColumnName("cLtcCustomerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.CLtcPerson)
                    .HasColumnName("cLtcPerson")
                    .HasMaxLength(40);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(1000);

                entity.Property(e => e.CModifyPerson)
                    .HasColumnName("cModifyPerson")
                    .HasMaxLength(20);

                entity.Property(e => e.COfferGrade)
                    .HasColumnName("cOfferGrade")
                    .HasMaxLength(20);

                entity.Property(e => e.CPriceGroup)
                    .HasColumnName("cPriceGroup")
                    .HasMaxLength(20);

                entity.Property(e => e.CPrimaryVen)
                    .HasColumnName("cPrimaryVen")
                    .HasMaxLength(20);

                entity.Property(e => e.CProvince)
                    .HasColumnName("cProvince")
                    .HasMaxLength(255);

                entity.Property(e => e.CRegCash)
                    .HasColumnName("cRegCash")
                    .HasMaxLength(60);

                entity.Property(e => e.CRelVendor)
                    .HasColumnName("cRelVendor")
                    .HasMaxLength(20);

                entity.Property(e => e.CTrade)
                    .HasColumnName("cTrade")
                    .HasMaxLength(50);

                entity.Property(e => e.CUrl)
                    .HasColumnName("cURL")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerKcode)
                    .HasColumnName("CustomerKCode")
                    .HasMaxLength(4);

                entity.Property(e => e.DBusinessEdate)
                    .HasColumnName("dBusinessEDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DBusinessSdate)
                    .HasColumnName("dBusinessSDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DCusCreateDatetime)
                    .HasColumnName("dCusCreateDatetime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DCusDevDate)
                    .HasColumnName("dCusDevDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DCusGspedate)
                    .HasColumnName("dCusGSPEDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DCusGspsdate)
                    .HasColumnName("dCusGSPSDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDepBeginDate)
                    .HasColumnName("dDepBeginDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DEndDate)
                    .HasColumnName("dEndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLastDate)
                    .HasColumnName("dLastDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLicenceEdate)
                    .HasColumnName("dLicenceEDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLicenceSdate)
                    .HasColumnName("dLicenceSDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLrdate)
                    .HasColumnName("dLRDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLtcDate)
                    .HasColumnName("dLtcDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DProxyEdate)
                    .HasColumnName("dProxyEDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DProxySdate)
                    .HasColumnName("dProxySDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DRecentContractDate)
                    .HasColumnName("dRecentContractDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DRecentDeliveryDate)
                    .HasColumnName("dRecentDeliveryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DRecentOutboundDate)
                    .HasColumnName("dRecentOutboundDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DRecentlyActivityTime)
                    .HasColumnName("dRecentlyActivityTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DRecentlyChanceTime)
                    .HasColumnName("dRecentlyChanceTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DRecentlyContractTime)
                    .HasColumnName("dRecentlyContractTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DRecentlyInvoiceTime)
                    .HasColumnName("dRecentlyInvoiceTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DRecentlyQuoteTime)
                    .HasColumnName("dRecentlyQuoteTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DTouchedTime)
                    .HasColumnName("dTouchedTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FAdvancePaymentRatio).HasColumnName("fAdvancePaymentRatio");

                entity.Property(e => e.FApprovedExpense).HasColumnName("fApprovedExpense");

                entity.Property(e => e.FCommisionRate).HasColumnName("fCommisionRate");

                entity.Property(e => e.FCusDiscountRate).HasColumnName("fCusDiscountRate");

                entity.Property(e => e.FExpense).HasColumnName("fExpense");

                entity.Property(e => e.FInsueRate).HasColumnName("fInsueRate");

                entity.Property(e => e.IArmoney).HasColumnName("iARMoney");

                entity.Property(e => e.IBusinessAdays).HasColumnName("iBusinessADays");

                entity.Property(e => e.ICostGrade)
                    .HasColumnName("iCostGrade")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ICusCreDate).HasColumnName("iCusCreDate");

                entity.Property(e => e.ICusCreLine).HasColumnName("iCusCreLine");

                entity.Property(e => e.ICusDisRate).HasColumnName("iCusDisRate");

                entity.Property(e => e.ICusGspadays).HasColumnName("iCusGSPADays");

                entity.Property(e => e.ICusGspauth).HasColumnName("iCusGSPAuth");

                entity.Property(e => e.ICusGsptype)
                    .HasColumnName("iCusGSPType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ICusTaxRate).HasColumnName("iCusTaxRate");

                entity.Property(e => e.IEmployeeNum).HasColumnName("iEmployeeNum");

                entity.Property(e => e.IFrequency).HasColumnName("iFrequency");

                entity.Property(e => e.IId)
                    .HasColumnName("iId")
                    .HasMaxLength(40);

                entity.Property(e => e.ILastMoney).HasColumnName("iLastMoney");

                entity.Property(e => e.ILicenceAdays).HasColumnName("iLicenceADays");

                entity.Property(e => e.ILrmoney).HasColumnName("iLRMoney");

                entity.Property(e => e.IOfferRate).HasColumnName("iOfferRate");

                entity.Property(e => e.IProxyAdays).HasColumnName("iProxyADays");

                entity.Property(e => e.ISourceId)
                    .HasColumnName("iSourceId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ISourceType).HasColumnName("iSourceType");

                entity.Property(e => e.PictureGuid).HasColumnName("PictureGUID");

                entity.Property(e => e.Pubufts)
                    .HasColumnName("pubufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.RecyleDeptTime)
                    .HasColumnName("recyle_dept_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecylePubTime)
                    .HasColumnName("recyle_pub_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.CDepCode)
                    .HasName("aaaaaDepartment_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CDepCode)
                    .HasName("Department_cDepCode_Idx");

                entity.HasIndex(e => e.DModifyDate)
                    .HasName("IX_department_dModifyDate");

                entity.Property(e => e.CDepCode)
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.BDepEnd).HasColumnName("bDepEnd");

                entity.Property(e => e.BIm)
                    .HasColumnName("bIM")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.BInheritDutyBasic)
                    .HasColumnName("bInheritDutyBasic")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.BInheritWorkCalendar)
                    .HasColumnName("bInheritWorkCalendar")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.BRetail)
                    .HasColumnName("bRetail")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BShop)
                    .IsRequired()
                    .HasColumnName("bShop")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CCreGrade)
                    .HasColumnName("cCreGrade")
                    .HasMaxLength(20);

                entity.Property(e => e.CDepAddress)
                    .HasColumnName("cDepAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CDepEmail)
                    .HasColumnName("cDepEmail")
                    .HasMaxLength(100);

                entity.Property(e => e.CDepFax)
                    .HasColumnName("cDepFax")
                    .HasMaxLength(20);

                entity.Property(e => e.CDepFullName)
                    .HasColumnName("cDepFullName")
                    .HasMaxLength(800);

                entity.Property(e => e.CDepGuid)
                    .HasColumnName("cDepGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CDepLeader)
                    .HasColumnName("cDepLeader")
                    .HasMaxLength(20);

                entity.Property(e => e.CDepMemo)
                    .HasColumnName("cDepMemo")
                    .HasMaxLength(20);

                entity.Property(e => e.CDepName)
                    .IsRequired()
                    .HasColumnName("cDepName")
                    .HasMaxLength(255);

                entity.Property(e => e.CDepNameEn)
                    .HasColumnName("cDepNameEn")
                    .HasMaxLength(255);

                entity.Property(e => e.CDepPerson)
                    .HasColumnName("cDepPerson")
                    .HasMaxLength(20);

                entity.Property(e => e.CDepPhone)
                    .HasColumnName("cDepPhone")
                    .HasMaxLength(100);

                entity.Property(e => e.CDepPostCode)
                    .HasColumnName("cDepPostCode")
                    .HasMaxLength(6);

                entity.Property(e => e.CDepProp)
                    .HasColumnName("cDepProp")
                    .HasMaxLength(10);

                entity.Property(e => e.CDepType)
                    .HasColumnName("cDepType")
                    .HasMaxLength(20);

                entity.Property(e => e.CDutyCode)
                    .HasColumnName("cDutyCode")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CEspaceMembId)
                    .HasColumnName("cESpaceMembID")
                    .HasMaxLength(50);

                entity.Property(e => e.COfferGrade)
                    .HasColumnName("cOfferGrade")
                    .HasMaxLength(20);

                entity.Property(e => e.CRestCode)
                    .HasColumnName("cRestCode")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DDepBeginDate)
                    .HasColumnName("dDepBeginDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DDepEndDate)
                    .HasColumnName("dDepEndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICreDate).HasColumnName("iCreDate");

                entity.Property(e => e.ICreLine).HasColumnName("iCreLine");

                entity.Property(e => e.IDepGrade).HasColumnName("iDepGrade");

                entity.Property(e => e.IDepOrder).HasColumnName("iDepOrder");

                entity.Property(e => e.IOfferRate).HasColumnName("iOfferRate");

                entity.Property(e => e.Pubufts)
                    .HasColumnName("pubufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.VAuthorizeDoc)
                    .HasColumnName("vAuthorizeDoc")
                    .HasMaxLength(50);

                entity.Property(e => e.VAuthorizeUnit)
                    .HasColumnName("vAuthorizeUnit")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DispatchList>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.BSaUsed)
                    .HasName("idx_bSaUsed");

                entity.HasIndex(e => e.CCusCode)
                    .HasName("CustomerDispatchList");

                entity.HasIndex(e => e.CDepCode)
                    .HasName("DepartmentDispatchList");

                entity.HasIndex(e => e.CDlcode)
                    .HasName("cDLCode");

                entity.HasIndex(e => e.CEbexpressCode)
                    .HasName("idx_DispatchList_cebexpresscode");

                entity.HasIndex(e => e.CPayCode)
                    .HasName("PayConditionDispatchList");

                entity.HasIndex(e => e.CPersonCode)
                    .HasName("PersonDispatchList");

                entity.HasIndex(e => e.CRdCode)
                    .HasName("Rd_StyleDispatchList");

                entity.HasIndex(e => e.CSccode)
                    .HasName("ShippingChoiceDispatchList");

                entity.HasIndex(e => e.CStcode)
                    .HasName("SaleTypeDispatchList");

                entity.HasIndex(e => e.CSysBarCode)
                    .HasName("idx_DispatchList_csysbarcode");

                entity.HasIndex(e => e.CexchName)
                    .HasName("foreigncurrencyDispatchList");

                entity.HasIndex(e => e.Csvouchtype)
                    .HasName("idx_DispatchList_csvouchtype");

                entity.HasIndex(e => e.DDate)
                    .HasName("Idx_dispatchlist_ddate");

                entity.HasIndex(e => e.Dlid)
                    .HasName("aaaaaDispatchList_PK")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => e.Outid)
                    .HasName("idxoutid_dispatchlist");

                entity.HasIndex(e => e.Sbvid)
                    .HasName("SBVID");

                entity.HasIndex(e => new { e.CDlcode, e.CVouchType })
                    .HasName("IX_Code")
                    .IsUnique();

                entity.HasIndex(e => new { e.CSysBarCode, e.CEbexpressCode })
                    .HasName("idx_DispatchList_barandexpresscode");

                entity.HasIndex(e => new { e.CVerifier, e.Bneedbill })
                    .HasName("idx_bneedbill");

                entity.HasIndex(e => new { e.Csvouchtype, e.CEbexpressCode })
                    .HasName("idx_ebcode");

                entity.HasIndex(e => new { e.CCusCode, e.CGcrouteCode, e.CVouchType, e.BFirst, e.DDate })
                    .HasName("idx_listfor");

                entity.HasIndex(e => new { e.CEbexpressCode, e.Csvouchtype, e.Dlid, e.CDlcode, e.Cweighter, e.FEbweight })
                    .HasName("ix_dispatchlist_cExpressCodefh");

                entity.Property(e => e.BArfirst)
                    .HasColumnName("bARFirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCredit).HasColumnName("bCredit");

                entity.Property(e => e.BFirst).HasColumnName("bFirst");

                entity.Property(e => e.BIafirst)
                    .HasColumnName("bIAFirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BNotToGoldTax).HasColumnName("bNotToGoldTax");

                entity.Property(e => e.BReturnFlag).HasColumnName("bReturnFlag");

                entity.Property(e => e.BSaUsed).HasColumnName("bSaUsed");

                entity.Property(e => e.BSettleAll).HasColumnName("bSettleAll");

                entity.Property(e => e.Baccswitchflag).HasColumnName("baccswitchflag");

                entity.Property(e => e.Bcashsale).HasColumnName("bcashsale");

                entity.Property(e => e.Bmustbook).HasColumnName("bmustbook");

                entity.Property(e => e.Bneedbill).HasColumnName("bneedbill");

                entity.Property(e => e.Bsaleoutcreatebill).HasColumnName("bsaleoutcreatebill");

                entity.Property(e => e.Bsigncreate).HasColumnName("bsigncreate");

                entity.Property(e => e.CAccounter)
                    .HasColumnName("cAccounter")
                    .HasMaxLength(20);

                entity.Property(e => e.CBookDepcode)
                    .HasColumnName("cBookDepcode")
                    .HasMaxLength(12);

                entity.Property(e => e.CBookType)
                    .HasColumnName("cBookType")
                    .HasMaxLength(10);

                entity.Property(e => e.CBusType)
                    .HasColumnName("cBusType")
                    .HasMaxLength(8);

                entity.Property(e => e.CChangeMemo)
                    .HasColumnName("cChangeMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CChanger)
                    .HasColumnName("cChanger")
                    .HasMaxLength(20);

                entity.Property(e => e.CCloser)
                    .HasColumnName("cCloser")
                    .HasMaxLength(20);

                entity.Property(e => e.CCreChpName)
                    .HasColumnName("cCreChpName")
                    .HasMaxLength(20);

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.CCusCode)
                    .HasColumnName("cCusCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusName)
                    .HasColumnName("cCusName")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7).HasColumnName("cDefine7");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepCode)
                    .IsRequired()
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CDlcode)
                    .HasColumnName("cDLCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CEbbuyer)
                    .HasColumnName("cEBBuyer")
                    .HasMaxLength(2000);

                entity.Property(e => e.CEbbuyerNote)
                    .HasColumnName("cEBBuyerNote")
                    .HasMaxLength(4000);

                entity.Property(e => e.CEbcity)
                    .HasColumnName("cEBcity")
                    .HasMaxLength(20);

                entity.Property(e => e.CEbdistrict)
                    .HasColumnName("cEBdistrict")
                    .HasMaxLength(60);

                entity.Property(e => e.CEbexpressCode)
                    .HasColumnName("cEBExpressCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CEbprovince)
                    .HasColumnName("cEBprovince")
                    .HasMaxLength(20);

                entity.Property(e => e.CEbtrnumber)
                    .HasColumnName("cEBTrnumber")
                    .HasMaxLength(80);

                entity.Property(e => e.CEbweightUnit)
                    .HasColumnName("cEBweightUnit")
                    .HasMaxLength(50);

                entity.Property(e => e.CGcrouteCode)
                    .HasColumnName("cGCRouteCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CInvoiceCusName)
                    .HasColumnName("cInvoiceCusName")
                    .HasMaxLength(255);

                entity.Property(e => e.CMaker)
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CPayCode)
                    .HasColumnName("cPayCode")
                    .HasMaxLength(3);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CPickVouchCode)
                    .HasColumnName("cPickVouchCode")
                    .HasMaxLength(255);

                entity.Property(e => e.CRdCode)
                    .HasColumnName("cRdCode")
                    .HasMaxLength(5);

                entity.Property(e => e.CSaleOut)
                    .HasColumnName("cSaleOut")
                    .HasMaxLength(255);

                entity.Property(e => e.CSbvcode)
                    .HasColumnName("cSBVCode")
                    .HasMaxLength(255);

                entity.Property(e => e.CSccode)
                    .HasColumnName("cSCCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CShipAddress)
                    .HasColumnName("cShipAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CSocode)
                    .HasColumnName("cSOCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CSourceCode)
                    .HasColumnName("cSourceCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CStcode)
                    .IsRequired()
                    .HasColumnName("cSTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CSysBarCode)
                    .HasColumnName("cSysBarCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CVerifier)
                    .HasColumnName("cVerifier")
                    .HasMaxLength(20);

                entity.Property(e => e.CVouchType)
                    .IsRequired()
                    .HasColumnName("cVouchType")
                    .HasMaxLength(2);

                entity.Property(e => e.Caddcode)
                    .HasColumnName("caddcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cbcode)
                    .HasColumnName("cbcode")
                    .HasMaxLength(3);

                entity.Property(e => e.Ccontactname)
                    .HasColumnName("ccontactname")
                    .HasMaxLength(255);

                entity.Property(e => e.Ccusperson)
                    .HasColumnName("ccusperson")
                    .HasMaxLength(100);

                entity.Property(e => e.Ccuspersoncode)
                    .HasColumnName("ccuspersoncode")
                    .HasMaxLength(30);

                entity.Property(e => e.CexchName)
                    .IsRequired()
                    .HasColumnName("cexch_name")
                    .HasMaxLength(8);

                entity.Property(e => e.Cgatheringplan)
                    .HasColumnName("cgatheringplan")
                    .HasMaxLength(20);

                entity.Property(e => e.Cgathingcode)
                    .HasColumnName("cgathingcode")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvoicecompany)
                    .HasColumnName("cinvoicecompany")
                    .HasMaxLength(20);

                entity.Property(e => e.Cmobilephone)
                    .HasColumnName("cmobilephone")
                    .HasMaxLength(50);

                entity.Property(e => e.Cmodifier)
                    .HasColumnName("cmodifier")
                    .HasMaxLength(20);

                entity.Property(e => e.Csscode)
                    .HasColumnName("csscode")
                    .HasMaxLength(3);

                entity.Property(e => e.Csvouchtype)
                    .HasColumnName("csvouchtype")
                    .HasMaxLength(10);

                entity.Property(e => e.Cweighter)
                    .HasColumnName("cweighter")
                    .HasMaxLength(40);

                entity.Property(e => e.DCreditStart)
                    .HasColumnName("dCreditStart")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDate)
                    .HasColumnName("dDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DGatheringDate)
                    .HasColumnName("dGatheringDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dcreatesystime)
                    .HasColumnName("dcreatesystime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dlid).HasColumnName("DLID");

                entity.Property(e => e.Dmoddate)
                    .HasColumnName("dmoddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dmodifysystime)
                    .HasColumnName("dmodifysystime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dverifydate)
                    .HasColumnName("dverifydate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dverifysystime)
                    .HasColumnName("dverifysystime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dweighttime)
                    .HasColumnName("dweighttime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FEbweight)
                    .HasColumnName("fEBweight")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.IEbexpressCoId).HasColumnName("iEBExpressCoID");

                entity.Property(e => e.IExchRate).HasColumnName("iExchRate");

                entity.Property(e => e.INetLock).HasColumnName("iNetLock");

                entity.Property(e => e.IPrintCount).HasColumnName("iPrintCount");

                entity.Property(e => e.ISale)
                    .HasColumnName("iSale")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ITaxRate).HasColumnName("iTaxRate");

                entity.Property(e => e.IVtid)
                    .HasColumnName("iVTid")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Icreditdays).HasColumnName("icreditdays");

                entity.Property(e => e.Icreditstate)
                    .HasColumnName("icreditstate")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Iflowid).HasColumnName("iflowid");

                entity.Property(e => e.Ioutgolden)
                    .HasColumnName("ioutgolden")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ireturncount)
                    .HasColumnName("ireturncount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iswfcontrolled)
                    .HasColumnName("iswfcontrolled")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iverifystate)
                    .HasColumnName("iverifystate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Outid)
                    .HasColumnName("outid")
                    .HasMaxLength(50);

                entity.Property(e => e.Sbvid).HasColumnName("SBVID");

                entity.Property(e => e.SeparateId).HasColumnName("SeparateID");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CDepCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CDepCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DispatchL__cDepC__2A61254E");

                entity.HasOne(d => d.CPersonCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CPersonCode)
                    .HasConstraintName("FK__DispatchL__cPers__0C9BB83D");
            });

            modelBuilder.Entity<DispatchLists>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaaDispatchLists_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CChildCode)
                    .HasName("IX_dispatchlists_cChildCode");

                entity.HasIndex(e => e.CInvCode)
                    .HasName("InventoryDispatchLists");

                entity.HasIndex(e => e.CParentCode)
                    .HasName("IX_SA_dispatchlists_cParentCode");

                entity.HasIndex(e => e.CWhCode)
                    .HasName("WarehouseDispatchLists");

                entity.HasIndex(e => e.Cbaccounter)
                    .HasName("IX_Dispatchlists_cBaccounter_IA");

                entity.HasIndex(e => e.Dlid)
                    .HasName("DispatchListDispatchLists");

                entity.HasIndex(e => e.ICorId)
                    .HasName("iCorID");

                entity.HasIndex(e => e.IDlsId)
                    .HasName("ix_DispatchLists_iDLsID")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => e.ISosId)
                    .HasName("Disp_iSOsID");

                entity.HasIndex(e => e.ITb)
                    .HasName("idx_itb_dispatchlists");

                entity.HasIndex(e => e.Isaleoutid)
                    .HasName("Idx_dispatchlists_isaleoutid");

                entity.HasIndex(e => new { e.CContractId, e.CContractTagCode })
                    .HasName("idx_contract");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.BGsp)
                    .HasColumnName("bGsp")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIacreatebill).HasColumnName("bIAcreatebill");

                entity.Property(e => e.BIsStqc)
                    .HasColumnName("bIsSTQc")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BQachecked)
                    .IsRequired()
                    .HasColumnName("bQAChecked")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BQachecking)
                    .IsRequired()
                    .HasColumnName("bQAChecking")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BQaneedCheck)
                    .IsRequired()
                    .HasColumnName("bQANeedCheck")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BQaurgency)
                    .IsRequired()
                    .HasColumnName("bQAUrgency")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BSettleAll).HasColumnName("bSettleAll");

                entity.Property(e => e.Bcosting)
                    .IsRequired()
                    .HasColumnName("bcosting")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Bgift).HasColumnName("bgift");

                entity.Property(e => e.Bmpforderclosed).HasColumnName("bmpforderclosed");

                entity.Property(e => e.Bneedloss).HasColumnName("bneedloss");

                entity.Property(e => e.Bneedsign).HasColumnName("bneedsign");

                entity.Property(e => e.BodyOutid)
                    .HasColumnName("body_outid")
                    .HasMaxLength(50);

                entity.Property(e => e.Bsaleprice).HasColumnName("bsaleprice");

                entity.Property(e => e.Bsignover).HasColumnName("bsignover");

                entity.Property(e => e.CBatch)
                    .HasColumnName("cBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CBookWhcode)
                    .HasColumnName("cBookWhcode")
                    .HasMaxLength(10);

                entity.Property(e => e.CChildCode)
                    .HasColumnName("cChildCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CCode)
                    .HasColumnName("cCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CConfirmer)
                    .HasColumnName("cConfirmer")
                    .HasMaxLength(60);

                entity.Property(e => e.CContractId)
                    .HasColumnName("cContractID")
                    .HasMaxLength(64);

                entity.Property(e => e.CContractRowGuid).HasColumnName("cContractRowGuid");

                entity.Property(e => e.CContractTagCode)
                    .HasColumnName("cContractTagCode")
                    .HasMaxLength(150);

                entity.Property(e => e.CCorCode)
                    .HasColumnName("cCorCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCusInvCode)
                    .HasColumnName("cCusInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CCusInvName)
                    .HasColumnName("cCusInvName")
                    .HasMaxLength(100);

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26).HasColumnName("cDefine26");

                entity.Property(e => e.CDefine27).HasColumnName("cDefine27");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CExpirationdate)
                    .HasColumnName("cExpirationdate")
                    .HasMaxLength(20);

                entity.Property(e => e.CFactoryCode)
                    .HasColumnName("cFactoryCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CGspState)
                    .HasColumnName("cGspState")
                    .HasMaxLength(20);

                entity.Property(e => e.CInVouchType)
                    .HasColumnName("cInVouchType")
                    .HasMaxLength(2);

                entity.Property(e => e.CInvCode)
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CInvName)
                    .HasColumnName("cInvName")
                    .HasMaxLength(255);

                entity.Property(e => e.CInvSn)
                    .HasColumnName("cInvSN")
                    .HasMaxLength(200);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CItemCname)
                    .HasColumnName("cItem_CName")
                    .HasMaxLength(20);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemName)
                    .HasColumnName("cItemName")
                    .HasMaxLength(255);

                entity.Property(e => e.CLossMaker)
                    .HasColumnName("cLossMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMassUnit).HasColumnName("cMassUnit");

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CParentCode)
                    .HasColumnName("cParentCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CPosition)
                    .HasColumnName("cPosition")
                    .HasMaxLength(20);

                entity.Property(e => e.CReasonCode)
                    .HasColumnName("cReasonCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CScloser)
                    .HasColumnName("cSCloser")
                    .HasMaxLength(20);

                entity.Property(e => e.CSoCode)
                    .HasColumnName("cSoCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CUnitId)
                    .HasColumnName("cUnitID")
                    .HasMaxLength(35);

                entity.Property(e => e.CVenAbbName)
                    .HasColumnName("cVenAbbName")
                    .HasMaxLength(60);

                entity.Property(e => e.CWhCode)
                    .HasColumnName("cWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CbSysBarCode)
                    .HasColumnName("cbSysBarCode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cbaccounter)
                    .HasColumnName("cbaccounter")
                    .HasMaxLength(30);

                entity.Property(e => e.Cbatchproperty1)
                    .HasColumnName("cbatchproperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty10)
                    .HasColumnName("cbatchproperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cbatchproperty2)
                    .HasColumnName("cbatchproperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty3)
                    .HasColumnName("cbatchproperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty4)
                    .HasColumnName("cbatchproperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty5)
                    .HasColumnName("cbatchproperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty6)
                    .HasColumnName("cbatchproperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbatchproperty7)
                    .HasColumnName("cbatchproperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbatchproperty8)
                    .HasColumnName("cbatchproperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbatchproperty9)
                    .HasColumnName("cbatchproperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdemandcode)
                    .HasColumnName("cdemandcode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cdemandid)
                    .HasColumnName("cdemandid")
                    .HasMaxLength(30);

                entity.Property(e => e.Cdemandmemo)
                    .HasColumnName("cdemandmemo")
                    .HasMaxLength(300);

                entity.Property(e => e.Cordercode)
                    .HasColumnName("cordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Crelacuscode)
                    .HasColumnName("crelacuscode")
                    .HasMaxLength(20);

                entity.Property(e => e.Crtnappcode)
                    .HasColumnName("crtnappcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cvencode)
                    .HasColumnName("cvencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cvmivencode)
                    .HasColumnName("cvmivencode")
                    .HasMaxLength(20);

                entity.Property(e => e.DConfirmDate)
                    .HasColumnName("dConfirmDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DExpirationdate)
                    .HasColumnName("dExpirationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLossDate)
                    .HasColumnName("dLossDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLossTime)
                    .HasColumnName("dLossTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DMdate)
                    .HasColumnName("dMDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DblPreExchMomey)
                    .HasColumnName("dblPreExchMomey")
                    .HasColumnType("decimal(29, 6)");

                entity.Property(e => e.DblPreMomey)
                    .HasColumnName("dblPreMomey")
                    .HasColumnType("decimal(29, 6)");

                entity.Property(e => e.Dkeepdate)
                    .HasColumnName("dkeepdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dlid).HasColumnName("DLID");

                entity.Property(e => e.DvDate)
                    .HasColumnName("dvDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FEnSettleQuan)
                    .HasColumnName("fEnSettleQuan")
                    .HasColumnType("decimal(28, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FEnSettleSum)
                    .HasColumnName("fEnSettleSum")
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FLastSettleQty)
                    .HasColumnName("fLastSettleQty")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.FLastSettleSum)
                    .HasColumnName("fLastSettleSum")
                    .HasColumnType("money");

                entity.Property(e => e.FOutNum)
                    .HasColumnName("fOutNum")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FOutQuantity)
                    .HasColumnName("fOutQuantity")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FSaleCost)
                    .HasColumnName("fSaleCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.FSalePrice)
                    .HasColumnName("fSalePrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.FVeriBillQty)
                    .HasColumnName("fVeriBillQty")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.FVeriBillSum)
                    .HasColumnName("fVeriBillSum")
                    .HasColumnType("money");

                entity.Property(e => e.FVeriRetQty)
                    .HasColumnName("fVeriRetQty")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.FVeriRetSum)
                    .HasColumnName("fVeriRetSum")
                    .HasColumnType("money");

                entity.Property(e => e.Fappretwkpqty)
                    .HasColumnName("fappretwkpqty")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fappretwkpsum)
                    .HasColumnName("fappretwkpsum")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fappretwkptbqty)
                    .HasColumnName("fappretwkptbqty")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fappretykpqty)
                    .HasColumnName("fappretykpqty")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fappretykpsum)
                    .HasColumnName("fappretykpsum")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fappretykptbqty)
                    .HasColumnName("fappretykptbqty")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fchildqty)
                    .HasColumnName("fchildqty")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fchildrate)
                    .HasColumnName("fchildrate")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fcusminprice)
                    .HasColumnName("fcusminprice")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Flossrate)
                    .HasColumnName("flossrate")
                    .HasColumnType("decimal(29, 6)");

                entity.Property(e => e.Fretailrealamount)
                    .HasColumnName("fretailrealamount")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Fretailsettleamount)
                    .HasColumnName("fretailsettleamount")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Fretoutqty)
                    .HasColumnName("fretoutqty")
                    .HasColumnType("decimal(29, 6)");

                entity.Property(e => e.Fretqtywkp)
                    .HasColumnName("fretqtywkp")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Fretqtyykp)
                    .HasColumnName("fretqtyykp")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Fretsum)
                    .HasColumnName("fretsum")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Fretsumykp)
                    .HasColumnName("fretsumykp")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Frettbqtyykp)
                    .HasColumnName("frettbqtyykp")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Frettbquantity)
                    .HasColumnName("frettbquantity")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Frlossqty)
                    .HasColumnName("frlossqty")
                    .HasColumnType("decimal(29, 6)");

                entity.Property(e => e.Fsumsignnum)
                    .HasColumnName("fsumsignnum")
                    .HasColumnType("decimal(26, 9)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Fsumsignquantity)
                    .HasColumnName("fsumsignquantity")
                    .HasColumnType("decimal(26, 9)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Fulossqty)
                    .HasColumnName("fulossqty")
                    .HasColumnType("decimal(29, 6)");

                entity.Property(e => e.Fxjnum).HasColumnName("fxjnum");

                entity.Property(e => e.Fxjquantity).HasColumnName("fxjquantity");

                entity.Property(e => e.GcsourceId).HasColumnName("GCSourceId");

                entity.Property(e => e.GcsourceIds).HasColumnName("GCSourceIds");

                entity.Property(e => e.IBatch).HasColumnName("iBatch");

                entity.Property(e => e.ICalcType).HasColumnName("iCalcType");

                entity.Property(e => e.ICorId).HasColumnName("iCorID");

                entity.Property(e => e.IDisCount)
                    .HasColumnName("iDisCount")
                    .HasColumnType("money");

                entity.Property(e => e.IDlsId)
                    .HasColumnName("iDLsID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IExpiratDateCalcu).HasColumnName("iExpiratDateCalcu");

                entity.Property(e => e.IInvExchRate)
                    .HasColumnName("iInvExchRate")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IInvSncount).HasColumnName("iInvSNCount");

                entity.Property(e => e.IMassDate).HasColumnName("iMassDate");

                entity.Property(e => e.IMoney)
                    .HasColumnName("iMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INatDisCount)
                    .HasColumnName("iNatDisCount")
                    .HasColumnType("money");

                entity.Property(e => e.INatMoney)
                    .HasColumnName("iNatMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INatSum)
                    .HasColumnName("iNatSum")
                    .HasColumnType("money");

                entity.Property(e => e.INatTax)
                    .HasColumnName("iNatTax")
                    .HasColumnType("money");

                entity.Property(e => e.INatUnitPrice)
                    .HasColumnName("iNatUnitPrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IPpartId).HasColumnName("iPPartID");

                entity.Property(e => e.IPpartQty)
                    .HasColumnName("iPPartQty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IPpartSeqId).HasColumnName("iPPartSeqID");

                entity.Property(e => e.IQanum)
                    .HasColumnName("iQANum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IQaquantity)
                    .HasColumnName("iQAQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IQuotedPrice)
                    .HasColumnName("iQuotedPrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IRetQuantity)
                    .HasColumnName("iRetQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.ISettleNum)
                    .HasColumnName("iSettleNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISettlePrice)
                    .HasColumnName("iSettlePrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISettleQuantity)
                    .HasColumnName("iSettleQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISosId)
                    .HasColumnName("iSOsID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ISum)
                    .HasColumnName("iSum")
                    .HasColumnType("money");

                entity.Property(e => e.ITax)
                    .HasColumnName("iTax")
                    .HasColumnType("money");

                entity.Property(e => e.ITaxRate)
                    .HasColumnName("iTaxRate")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ITaxUnitPrice)
                    .HasColumnName("iTaxUnitPrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ITb)
                    .HasColumnName("iTB")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IUnitPrice)
                    .HasColumnName("iUnitPrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Icoridlsid).HasColumnName("icoridlsid");

                entity.Property(e => e.Icostquantity)
                    .HasColumnName("icostquantity")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Icostsum)
                    .HasColumnName("icostsum")
                    .HasColumnType("money");

                entity.Property(e => e.Idemandseq).HasColumnName("idemandseq");

                entity.Property(e => e.Idemandtype).HasColumnName("idemandtype");

                entity.Property(e => e.Iexchsum)
                    .HasColumnName("iexchsum")
                    .HasColumnType("money");

                entity.Property(e => e.Imoneysum)
                    .HasColumnName("imoneysum")
                    .HasColumnType("money");

                entity.Property(e => e.Iorderrowno).HasColumnName("iorderrowno");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Irtnappid).HasColumnName("irtnappid");

                entity.Property(e => e.Isaleoutid).HasColumnName("isaleoutid");

                entity.Property(e => e.Isettletype).HasColumnName("isettletype");

                entity.Property(e => e.Ispecialtype).HasColumnName("ispecialtype");

                entity.Property(e => e.Kl)
                    .HasColumnName("KL")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Kl2)
                    .HasColumnName("KL2")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Tbnum)
                    .HasColumnName("TBNum")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Tbquantity)
                    .HasColumnName("TBQuantity")
                    .HasColumnType("decimal(26, 9)");

                entity.HasOne(d => d.CWhCodeNavigation)
                    .WithMany(p => p.DispatchLists)
                    .HasForeignKey(d => d.CWhCode)
                    .HasConstraintName("FK__DispatchL__cWhCo__785FB566");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.CInvCode)
                    .HasName("aaaaaInventory_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.BAtomodel)
                    .HasName("ix_inventory_bAtoModel");

                entity.HasIndex(e => e.BMps)
                    .HasName("idx_inventory_bmps");

                entity.HasIndex(e => e.CBarCode)
                    .HasName("Index_Inventory_cbarcode");

                entity.HasIndex(e => e.CInvAddCode)
                    .HasName("cInvAddCode");

                entity.HasIndex(e => e.CInvCcode)
                    .HasName("InventoryClassInventory");

                entity.HasIndex(e => e.CInvCode)
                    .HasName("PK_Inventory_cInvCode_Clustered_Index")
                    .IsClustered();

                entity.HasIndex(e => e.CInvName)
                    .HasName("cInvName");

                entity.HasIndex(e => e.CVenCode)
                    .HasName("Inventory_CVenCode_Idx");

                entity.HasIndex(e => e.DModifyDate);

                entity.HasIndex(e => e.IId1)
                    .HasName("Index871_Inventory_iId");

                entity.HasIndex(e => e.Pubufts)
                    .HasName("idx_inventory_pubufts");

                entity.HasIndex(e => new { e.CInvCode, e.IId1 })
                    .HasName("Index_Inventory_cInvcode_iid");

                entity.HasIndex(e => new { e.CInvMnemCode, e.CInvCode })
                    .HasName("IX_Inventory_cInvCode_cInvMnemCode");

                entity.HasIndex(e => new { e.CSrpolicy, e.CInvCode })
                    .HasName("Index_inventory_csrpolicy_cinvcode");

                entity.HasIndex(e => new { e.CInvCode, e.CInvName, e.BPiece })
                    .HasName("IX_Inventory_PR");

                entity.Property(e => e.CInvCode)
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.BAccessary).HasColumnName("bAccessary");

                entity.Property(e => e.BAtomodel)
                    .IsRequired()
                    .HasColumnName("bATOModel")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BBackInvDt)
                    .IsRequired()
                    .HasColumnName("bBackInvDT")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BBarCode)
                    .IsRequired()
                    .HasColumnName("bBarCode")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BBillUnite)
                    .IsRequired()
                    .HasColumnName("bBillUnite")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BBomMain)
                    .IsRequired()
                    .HasColumnName("bBomMain")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BBomSub)
                    .IsRequired()
                    .HasColumnName("bBomSub")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckBatch)
                    .IsRequired()
                    .HasColumnName("bCheckBatch")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckBsatp)
                    .IsRequired()
                    .HasColumnName("bCheckBSATP")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckFree1)
                    .IsRequired()
                    .HasColumnName("bCheckFree1")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckFree10)
                    .IsRequired()
                    .HasColumnName("bCheckFree10")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckFree2)
                    .IsRequired()
                    .HasColumnName("bCheckFree2")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckFree3)
                    .IsRequired()
                    .HasColumnName("bCheckFree3")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckFree4)
                    .IsRequired()
                    .HasColumnName("bCheckFree4")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckFree5)
                    .IsRequired()
                    .HasColumnName("bCheckFree5")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckFree6)
                    .IsRequired()
                    .HasColumnName("bCheckFree6")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckFree7)
                    .IsRequired()
                    .HasColumnName("bCheckFree7")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckFree8)
                    .IsRequired()
                    .HasColumnName("bCheckFree8")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckFree9)
                    .IsRequired()
                    .HasColumnName("bCheckFree9")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckItem)
                    .IsRequired()
                    .HasColumnName("bCheckItem")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BComsume).HasColumnName("bComsume");

                entity.Property(e => e.BConfigFree1)
                    .IsRequired()
                    .HasColumnName("bConfigFree1")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BConfigFree10)
                    .IsRequired()
                    .HasColumnName("bConfigFree10")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BConfigFree2)
                    .IsRequired()
                    .HasColumnName("bConfigFree2")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BConfigFree3)
                    .IsRequired()
                    .HasColumnName("bConfigFree3")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BConfigFree4)
                    .IsRequired()
                    .HasColumnName("bConfigFree4")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BConfigFree5)
                    .IsRequired()
                    .HasColumnName("bConfigFree5")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BConfigFree6)
                    .IsRequired()
                    .HasColumnName("bConfigFree6")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BConfigFree7)
                    .IsRequired()
                    .HasColumnName("bConfigFree7")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BConfigFree8)
                    .IsRequired()
                    .HasColumnName("bConfigFree8")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BConfigFree9)
                    .IsRequired()
                    .HasColumnName("bConfigFree9")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCutMantissa)
                    .IsRequired()
                    .HasColumnName("bCutMantissa")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BDtwarnInv).HasColumnName("bDTWarnInv");

                entity.Property(e => e.BEquipment)
                    .IsRequired()
                    .HasColumnName("bEquipment")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BExpSale)
                    .IsRequired()
                    .HasColumnName("bExpSale")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BFirstBusiMedicine)
                    .IsRequired()
                    .HasColumnName("bFirstBusiMedicine")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BFixExch)
                    .IsRequired()
                    .HasColumnName("bFixExch")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BForeExpland)
                    .IsRequired()
                    .HasColumnName("bForeExpland")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BFree1).HasColumnName("bFree1");

                entity.Property(e => e.BFree10)
                    .IsRequired()
                    .HasColumnName("bFree10")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BFree2).HasColumnName("bFree2");

                entity.Property(e => e.BFree3)
                    .IsRequired()
                    .HasColumnName("bFree3")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BFree4)
                    .IsRequired()
                    .HasColumnName("bFree4")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BFree5)
                    .IsRequired()
                    .HasColumnName("bFree5")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BFree6)
                    .IsRequired()
                    .HasColumnName("bFree6")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BFree7)
                    .IsRequired()
                    .HasColumnName("bFree7")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BFree8)
                    .IsRequired()
                    .HasColumnName("bFree8")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BFree9)
                    .IsRequired()
                    .HasColumnName("bFree9")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BImportMedicine)
                    .IsRequired()
                    .HasColumnName("bImportMedicine")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BInTotalCost)
                    .IsRequired()
                    .HasColumnName("bInTotalCost")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BInvBatch).HasColumnName("bInvBatch");

                entity.Property(e => e.BInvEntrust).HasColumnName("bInvEntrust");

                entity.Property(e => e.BInvModel)
                    .IsRequired()
                    .HasColumnName("bInvModel")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BInvOverStock).HasColumnName("bInvOverStock");

                entity.Property(e => e.BInvQuality).HasColumnName("bInvQuality");

                entity.Property(e => e.BInvType).HasColumnName("bInvType");

                entity.Property(e => e.BKccutMantissa)
                    .IsRequired()
                    .HasColumnName("bKCCutMantissa")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BMngOldpart)
                    .IsRequired()
                    .HasColumnName("bMngOldpart")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BMps)
                    .IsRequired()
                    .HasColumnName("bMPS")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BOutInvDt)
                    .IsRequired()
                    .HasColumnName("bOutInvDT")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BPeriodDt)
                    .IsRequired()
                    .HasColumnName("bPeriodDT")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BPiece)
                    .IsRequired()
                    .HasColumnName("bPiece")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BPlanInv)
                    .IsRequired()
                    .HasColumnName("bPlanInv")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BProducing).HasColumnName("bProducing");

                entity.Property(e => e.BProductBill)
                    .IsRequired()
                    .HasColumnName("bProductBill")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BPromotSales)
                    .IsRequired()
                    .HasColumnName("bPromotSales")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BPropertyCheck)
                    .IsRequired()
                    .HasColumnName("bPropertyCheck")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BProxyForeign)
                    .IsRequired()
                    .HasColumnName("bProxyForeign")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BPtomodel)
                    .IsRequired()
                    .HasColumnName("bPTOModel")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BPurchase).HasColumnName("bPurchase");

                entity.Property(e => e.BRePlan)
                    .IsRequired()
                    .HasColumnName("bRePlan")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BReceiptByDt)
                    .IsRequired()
                    .HasColumnName("bReceiptByDT")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BRop)
                    .IsRequired()
                    .HasColumnName("bROP")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BSale).HasColumnName("bSale");

                entity.Property(e => e.BSelf).HasColumnName("bSelf");

                entity.Property(e => e.BSerial)
                    .IsRequired()
                    .HasColumnName("bSerial")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BService).HasColumnName("bService");

                entity.Property(e => e.BSolitude)
                    .IsRequired()
                    .HasColumnName("bSolitude")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BSpecialOrder)
                    .IsRequired()
                    .HasColumnName("bSpecialOrder")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BSpecialties)
                    .IsRequired()
                    .HasColumnName("bSpecialties")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BSrvFittings)
                    .IsRequired()
                    .HasColumnName("bSrvFittings")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BSrvItem)
                    .IsRequired()
                    .HasColumnName("bSrvItem")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BTrack)
                    .IsRequired()
                    .HasColumnName("bTrack")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BTrackSaleBill)
                    .IsRequired()
                    .HasColumnName("bTrackSaleBill")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CAddress)
                    .HasColumnName("cAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CAssComUnitCode)
                    .HasColumnName("cAssComUnitCode")
                    .HasMaxLength(35);

                entity.Property(e => e.CBarCode)
                    .HasColumnName("cBarCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCacomUnitCode)
                    .HasColumnName("cCAComUnitCode")
                    .HasMaxLength(35);

                entity.Property(e => e.CCheckOut)
                    .HasColumnName("cCheckOut")
                    .HasMaxLength(30);

                entity.Property(e => e.CCiqcode)
                    .HasColumnName("cCIQCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CComUnitCode)
                    .HasColumnName("cComUnitCode")
                    .HasMaxLength(35);

                entity.Property(e => e.CCommodity)
                    .HasColumnName("cCommodity")
                    .HasMaxLength(60);

                entity.Property(e => e.CCreatePerson)
                    .HasColumnName("cCreatePerson")
                    .HasMaxLength(20);

                entity.Property(e => e.CCurrencyName)
                    .HasColumnName("cCurrencyName")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefWareHouse)
                    .HasColumnName("cDefWareHouse")
                    .HasMaxLength(10);

                entity.Property(e => e.CDtaql)
                    .HasColumnName("cDTAQL")
                    .HasMaxLength(20);

                entity.Property(e => e.CDtperiod)
                    .HasColumnName("cDTPeriod")
                    .HasMaxLength(30);

                entity.Property(e => e.CDtunit)
                    .HasColumnName("cDTUnit")
                    .HasMaxLength(35);

                entity.Property(e => e.CEngineerFigNo)
                    .HasColumnName("cEngineerFigNo")
                    .HasMaxLength(60);

                entity.Property(e => e.CEnglishName)
                    .HasColumnName("cEnglishName")
                    .HasMaxLength(100);

                entity.Property(e => e.CEnterNo)
                    .HasColumnName("cEnterNo")
                    .HasMaxLength(60);

                entity.Property(e => e.CEnterprise)
                    .HasColumnName("cEnterprise")
                    .HasMaxLength(100);

                entity.Property(e => e.CFile)
                    .HasColumnName("cFile")
                    .HasMaxLength(40);

                entity.Property(e => e.CFrequency)
                    .HasColumnName("cFrequency")
                    .HasMaxLength(10);

                entity.Property(e => e.CGroupCode)
                    .HasColumnName("cGroupCode")
                    .HasMaxLength(35);

                entity.Property(e => e.CInvAbc)
                    .HasColumnName("cInvABC")
                    .HasMaxLength(1);

                entity.Property(e => e.CInvAddCode)
                    .HasColumnName("cInvAddCode")
                    .HasMaxLength(255);

                entity.Property(e => e.CInvCcode)
                    .HasColumnName("cInvCCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CInvDefine1)
                    .HasColumnName("cInvDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvDefine10)
                    .HasColumnName("cInvDefine10")
                    .HasMaxLength(120);

                entity.Property(e => e.CInvDefine11).HasColumnName("cInvDefine11");

                entity.Property(e => e.CInvDefine12).HasColumnName("cInvDefine12");

                entity.Property(e => e.CInvDefine13).HasColumnName("cInvDefine13");

                entity.Property(e => e.CInvDefine14).HasColumnName("cInvDefine14");

                entity.Property(e => e.CInvDefine15)
                    .HasColumnName("cInvDefine15")
                    .HasColumnType("datetime");

                entity.Property(e => e.CInvDefine16)
                    .HasColumnName("cInvDefine16")
                    .HasColumnType("datetime");

                entity.Property(e => e.CInvDefine2)
                    .HasColumnName("cInvDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvDefine3)
                    .HasColumnName("cInvDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvDefine4)
                    .HasColumnName("cInvDefine4")
                    .HasMaxLength(60);

                entity.Property(e => e.CInvDefine5)
                    .HasColumnName("cInvDefine5")
                    .HasMaxLength(60);

                entity.Property(e => e.CInvDefine6)
                    .HasColumnName("cInvDefine6")
                    .HasMaxLength(60);

                entity.Property(e => e.CInvDefine7)
                    .HasColumnName("cInvDefine7")
                    .HasMaxLength(120);

                entity.Property(e => e.CInvDefine8)
                    .HasColumnName("cInvDefine8")
                    .HasMaxLength(120);

                entity.Property(e => e.CInvDefine9)
                    .HasColumnName("cInvDefine9")
                    .HasMaxLength(120);

                entity.Property(e => e.CInvDepCode)
                    .HasColumnName("cInvDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CInvMnemCode)
                    .HasColumnName("cInvMnemCode")
                    .HasMaxLength(40);

                entity.Property(e => e.CInvName)
                    .HasColumnName("cInvName")
                    .HasMaxLength(255);

                entity.Property(e => e.CInvPersonCode)
                    .HasColumnName("cInvPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvPlanCode)
                    .HasColumnName("cInvPlanCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvProjectCode)
                    .HasColumnName("cInvProjectCode")
                    .HasMaxLength(16);

                entity.Property(e => e.CInvStd)
                    .HasColumnName("cInvStd")
                    .HasMaxLength(255);

                entity.Property(e => e.CLabel)
                    .HasColumnName("cLabel")
                    .HasMaxLength(30);

                entity.Property(e => e.CLicence)
                    .HasColumnName("cLicence")
                    .HasMaxLength(30);

                entity.Property(e => e.CMassUnit)
                    .HasColumnName("cMassUnit")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CModifyPerson)
                    .HasColumnName("cModifyPerson")
                    .HasMaxLength(20);

                entity.Property(e => e.CMonth)
                    .HasColumnName("cMonth")
                    .HasMaxLength(6);

                entity.Property(e => e.CNotPatentName)
                    .HasColumnName("cNotPatentName")
                    .HasMaxLength(30);

                entity.Property(e => e.COfferGrade)
                    .HasColumnName("cOfferGrade")
                    .HasMaxLength(20);

                entity.Property(e => e.CPackingType)
                    .HasColumnName("cPackingType")
                    .HasMaxLength(60);

                entity.Property(e => e.CPlanMethod)
                    .HasColumnName("cPlanMethod")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('R')");

                entity.Property(e => e.CPosition)
                    .HasColumnName("cPosition")
                    .HasMaxLength(20);

                entity.Property(e => e.CPreparationType)
                    .HasColumnName("cPreparationType")
                    .HasMaxLength(30);

                entity.Property(e => e.CPriceGroup)
                    .HasColumnName("cPriceGroup")
                    .HasMaxLength(20);

                entity.Property(e => e.CProduceAddress)
                    .HasColumnName("cProduceAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CProduceNation)
                    .HasColumnName("cProduceNation")
                    .HasMaxLength(60);

                entity.Property(e => e.CProductUnit)
                    .HasColumnName("cProductUnit")
                    .HasMaxLength(35);

                entity.Property(e => e.CPucomUnitCode)
                    .HasColumnName("cPUComUnitCode")
                    .HasMaxLength(35);

                entity.Property(e => e.CPurPersonCode)
                    .HasColumnName("cPurPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CQuality)
                    .HasColumnName("cQuality")
                    .HasMaxLength(100);

                entity.Property(e => e.CRegisterNo)
                    .HasColumnName("cRegisterNo")
                    .HasMaxLength(60);

                entity.Property(e => e.CReplaceItem)
                    .HasColumnName("cReplaceItem")
                    .HasMaxLength(60);

                entity.Property(e => e.CRetailDefReturnWh)
                    .HasColumnName("cRetailDefReturnWH")
                    .HasMaxLength(10);

                entity.Property(e => e.CRuleCode)
                    .HasColumnName("cRuleCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CSacomUnitCode)
                    .HasColumnName("cSAComUnitCode")
                    .HasMaxLength(35);

                entity.Property(e => e.CShopUnit)
                    .HasColumnName("cShopUnit")
                    .HasMaxLength(35);

                entity.Property(e => e.CSrpolicy)
                    .HasColumnName("cSRPolicy")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('PE')");

                entity.Property(e => e.CStcomUnitCode)
                    .HasColumnName("cSTComUnitCode")
                    .HasMaxLength(35);

                entity.Property(e => e.CValueType)
                    .HasColumnName("cValueType")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenCode)
                    .HasColumnName("cVenCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVgroupCode)
                    .HasColumnName("cVGroupCode")
                    .HasMaxLength(35);

                entity.Property(e => e.CVunit)
                    .HasColumnName("cVUnit")
                    .HasMaxLength(35);

                entity.Property(e => e.CWgroupCode)
                    .HasColumnName("cWGroupCode")
                    .HasMaxLength(35);

                entity.Property(e => e.CWunit)
                    .HasColumnName("cWUnit")
                    .HasMaxLength(35);

                entity.Property(e => e.DEdate)
                    .HasColumnName("dEDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLastDate)
                    .HasColumnName("dLastDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DReplaceDate)
                    .HasColumnName("dReplaceDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DSdate)
                    .HasColumnName("dSDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FAlterBaseNum).HasColumnName("fAlterBaseNum");

                entity.Property(e => e.FBackTaxRate).HasColumnName("fBackTaxRate");

                entity.Property(e => e.FBatchIncrement).HasColumnName("fBatchIncrement");

                entity.Property(e => e.FConvertRate)
                    .HasColumnName("fConvertRate")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.FDtnum).HasColumnName("fDTNum");

                entity.Property(e => e.FDtrate).HasColumnName("fDTRate");

                entity.Property(e => e.FExpensesExch).HasColumnName("fExpensesExch");

                entity.Property(e => e.FGrossW).HasColumnName("fGrossW");

                entity.Property(e => e.FHeight).HasColumnName("fHeight");

                entity.Property(e => e.FInExcess).HasColumnName("fInExcess");

                entity.Property(e => e.FLength).HasColumnName("fLength");

                entity.Property(e => e.FMaxSupply).HasColumnName("fMaxSupply");

                entity.Property(e => e.FMinSplit).HasColumnName("fMinSplit");

                entity.Property(e => e.FMinSupply).HasColumnName("fMinSupply");

                entity.Property(e => e.FOrderUpLimit).HasColumnName("fOrderUpLimit");

                entity.Property(e => e.FOutExcess).HasColumnName("fOutExcess");

                entity.Property(e => e.FRetailPrice).HasColumnName("fRetailPrice");

                entity.Property(e => e.FSubscribePoint).HasColumnName("fSubscribePoint");

                entity.Property(e => e.FSupplyMulti).HasColumnName("fSupplyMulti");

                entity.Property(e => e.FVagQuantity).HasColumnName("fVagQuantity");

                entity.Property(e => e.FWidth).HasColumnName("fWidth");

                entity.Property(e => e.IAdvanceDate).HasColumnName("iAdvanceDate");

                entity.Property(e => e.IAllocatePrintDgt).HasColumnName("iAllocatePrintDgt");

                entity.Property(e => e.IAlterAdvance).HasColumnName("iAlterAdvance");

                entity.Property(e => e.IAssureProvideDays).HasColumnName("iAssureProvideDays");

                entity.Property(e => e.IBatchCounter).HasColumnName("iBatchCounter");

                entity.Property(e => e.IBatchRule).HasColumnName("iBatchRule");

                entity.Property(e => e.IBigDay).HasColumnName("iBigDay");

                entity.Property(e => e.IBigMonth).HasColumnName("iBigMonth");

                entity.Property(e => e.ICheckAtp)
                    .HasColumnName("iCheckATP")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IDays).HasColumnName("iDays");

                entity.Property(e => e.IDrawBatch).HasColumnName("iDrawBatch");

                entity.Property(e => e.IDtdcounter).HasColumnName("iDTDCounter");

                entity.Property(e => e.IDtlevel).HasColumnName("iDTLevel");

                entity.Property(e => e.IDtmethod).HasColumnName("iDTMethod");

                entity.Property(e => e.IDtstyle).HasColumnName("iDTStyle");

                entity.Property(e => e.IDtucounter).HasColumnName("iDTUCounter");

                entity.Property(e => e.IEndDtstyle).HasColumnName("iEndDTStyle");

                entity.Property(e => e.IExpSaleRate).HasColumnName("iExpSaleRate");

                entity.Property(e => e.IExpTaxRate).HasColumnName("iExpTaxRate");

                entity.Property(e => e.IFrequency).HasColumnName("iFrequency");

                entity.Property(e => e.IGroupType)
                    .HasColumnName("iGroupType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IHighPrice).HasColumnName("iHighPrice");

                entity.Property(e => e.IId)
                    .HasColumnName("I_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IId1).HasColumnName("iId");

                entity.Property(e => e.IImpTaxRate).HasColumnName("iImpTaxRate");

                entity.Property(e => e.IInvAdvance).HasColumnName("iInvAdvance");

                entity.Property(e => e.IInvAtpid).HasColumnName("iInvATPId");

                entity.Property(e => e.IInvBatch).HasColumnName("iInvBatch");

                entity.Property(e => e.IInvLscost).HasColumnName("iInvLSCost");

                entity.Property(e => e.IInvMpcost).HasColumnName("iInvMPCost");

                entity.Property(e => e.IInvNcost).HasColumnName("iInvNCost");

                entity.Property(e => e.IInvRcost).HasColumnName("iInvRCost");

                entity.Property(e => e.IInvSaleCost).HasColumnName("iInvSaleCost");

                entity.Property(e => e.IInvScost).HasColumnName("iInvSCost");

                entity.Property(e => e.IInvScost1).HasColumnName("iInvSCost1");

                entity.Property(e => e.IInvScost2).HasColumnName("iInvSCost2");

                entity.Property(e => e.IInvScost3).HasColumnName("iInvSCost3");

                entity.Property(e => e.IInvSprice).HasColumnName("iInvSPrice");

                entity.Property(e => e.IInvTfId).HasColumnName("iInvTfId");

                entity.Property(e => e.IInvWeight).HasColumnName("iInvWeight");

                entity.Property(e => e.ILowSum).HasColumnName("iLowSum");

                entity.Property(e => e.IMassDate).HasColumnName("iMassDate");

                entity.Property(e => e.IOfferRate).HasColumnName("iOfferRate");

                entity.Property(e => e.IOldpartMngRule).HasColumnName("iOldpartMngRule");

                entity.Property(e => e.IOverStock).HasColumnName("iOverStock");

                entity.Property(e => e.IOverlapDay).HasColumnName("iOverlapDay");

                entity.Property(e => e.IPfbatchQty).HasColumnName("iPFBatchQty");

                entity.Property(e => e.IPlanDefault).HasColumnName("iPlanDefault");

                entity.Property(e => e.IPlanPolicy).HasColumnName("iPlanPolicy");

                entity.Property(e => e.IPlanTfDay).HasColumnName("iPlanTfDay");

                entity.Property(e => e.IQtmethod).HasColumnName("iQTMethod");

                entity.Property(e => e.IRecipeBatch)
                    .HasColumnName("iRecipeBatch")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IRopmethod).HasColumnName("iROPMethod");

                entity.Property(e => e.ISafeNum).HasColumnName("iSafeNum");

                entity.Property(e => e.ISmallDay).HasColumnName("iSmallDay");

                entity.Property(e => e.ISmallMonth).HasColumnName("iSmallMonth");

                entity.Property(e => e.ISupplyDay).HasColumnName("iSupplyDay");

                entity.Property(e => e.ISupplyType)
                    .HasColumnName("iSupplyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ITaxRate).HasColumnName("iTaxRate");

                entity.Property(e => e.ITestRule).HasColumnName("iTestRule");

                entity.Property(e => e.ITestStyle).HasColumnName("iTestStyle");

                entity.Property(e => e.ITopSum).HasColumnName("iTopSum");

                entity.Property(e => e.IVolume).HasColumnName("iVolume");

                entity.Property(e => e.IWarnDays).HasColumnName("iWarnDays");

                entity.Property(e => e.IWastage).HasColumnName("iWastage");

                entity.Property(e => e.PictureGuid).HasColumnName("PictureGUID");

                entity.Property(e => e.Pubufts)
                    .HasColumnName("pubufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CInvCcodeNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.CInvCcode)
                    .HasConstraintName("FK__Inventory__cInvC__6399A2AA");
            });

            modelBuilder.Entity<InventoryClass>(entity =>
            {
                entity.HasKey(e => e.CInvCcode)
                    .HasName("aaaaaInventoryClass_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CInvCname)
                    .HasName("cInvCName");

                entity.HasIndex(e => new { e.CInvCcode, e.CInvCname })
                    .HasName("IX_InventoryClass_cInvcCode_cInvcName");

                entity.Property(e => e.CInvCcode)
                    .HasColumnName("cInvCCode")
                    .HasMaxLength(12);

                entity.Property(e => e.BInvCend).HasColumnName("bInvCEnd");

                entity.Property(e => e.CBarCode)
                    .HasColumnName("cBarCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CEcoCode)
                    .HasColumnName("cEcoCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CInvCname)
                    .HasColumnName("cInvCName")
                    .HasMaxLength(100);

                entity.Property(e => e.IInvCgrade).HasColumnName("iInvCGrade");

                entity.Property(e => e.Pubufts)
                    .HasColumnName("pubufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<MaterialAppVouch>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("aaaaaMaterialAppVouch_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CCode)
                    .HasName("cCode");

                entity.HasIndex(e => e.CDepCode)
                    .HasName("DepartmentMaterialAppVouch");

                entity.HasIndex(e => e.CPersonCode)
                    .HasName("PersonMaterialAppVouch");

                entity.HasIndex(e => e.CRdCode)
                    .HasName("Rd_StyleMaterialAppVouch");

                entity.HasIndex(e => e.DDate)
                    .HasName("dDate");

                entity.HasIndex(e => e.Id)
                    .HasName("aaMaterialAppVouch_PK")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CChanger)
                    .HasColumnName("cChanger")
                    .HasMaxLength(20);

                entity.Property(e => e.CCloser)
                    .HasColumnName("cCloser")
                    .HasMaxLength(20);

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasColumnName("cCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7).HasColumnName("cDefine7");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepCode)
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CHandler)
                    .HasColumnName("cHandler")
                    .HasMaxLength(20);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CItemCname)
                    .HasColumnName("cItemCName")
                    .HasMaxLength(20);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CMaker)
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CModifyPerson)
                    .HasColumnName("cModifyPerson")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(60);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CRdCode)
                    .HasColumnName("cRdCode")
                    .HasMaxLength(5);

                entity.Property(e => e.CSource)
                    .HasColumnName("cSource")
                    .HasMaxLength(50);

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cvencode)
                    .HasColumnName("cvencode")
                    .HasMaxLength(20);

                entity.Property(e => e.DDate)
                    .HasColumnName("dDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVeriDate)
                    .HasColumnName("dVeriDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmaketime)
                    .HasColumnName("dnmaketime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmodifytime)
                    .HasColumnName("dnmodifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnverifytime)
                    .HasColumnName("dnverifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IPrintCount)
                    .HasColumnName("iPrintCount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Imquantity)
                    .HasColumnName("imquantity")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Ireturncount)
                    .HasColumnName("ireturncount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iswfcontrolled)
                    .HasColumnName("iswfcontrolled")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iverifystate)
                    .HasColumnName("iverifystate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.VtId).HasColumnName("VT_ID");

                entity.HasOne(d => d.CDepCodeNavigation)
                    .WithMany(p => p.MaterialAppVouch)
                    .HasForeignKey(d => d.CDepCode)
                    .HasConstraintName("FK__MaterialAppVouch__cDepCo__38AF44A5");

                entity.HasOne(d => d.CPersonCodeNavigation)
                    .WithMany(p => p.MaterialAppVouch)
                    .HasForeignKey(d => d.CPersonCode)
                    .HasConstraintName("FK__MaterialAppVouch__cPerso__16252277");
            });

            modelBuilder.Entity<MaterialAppVouchs>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaaMaterialAppVouchs_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.AutoId)
                    .HasName("aaMaterialAppVouchs_PK")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => e.CInvCode)
                    .HasName("InventoryMaterialAppVouchs");

                entity.HasIndex(e => e.CWhCode)
                    .HasName("WarehouseMaterialAppVouchs");

                entity.HasIndex(e => e.Cfactorycode)
                    .HasName("idx_materialappvouchs_cfactorycode");

                entity.HasIndex(e => e.Id)
                    .HasName("MaterialAppVouchMaterialAppVouchs");

                entity.Property(e => e.AutoId)
                    .HasColumnName("AutoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CAssUnit)
                    .HasColumnName("cAssUnit")
                    .HasMaxLength(35);

                entity.Property(e => e.CBatch)
                    .HasColumnName("cBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CBatchProperty1)
                    .HasColumnName("cBatchProperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty10)
                    .HasColumnName("cBatchProperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.CBatchProperty2)
                    .HasColumnName("cBatchProperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty3)
                    .HasColumnName("cBatchProperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty4)
                    .HasColumnName("cBatchProperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty5)
                    .HasColumnName("cBatchProperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty6)
                    .HasColumnName("cBatchProperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty7)
                    .HasColumnName("cBatchProperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty8)
                    .HasColumnName("cBatchProperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty9)
                    .HasColumnName("cBatchProperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.CBcloser)
                    .HasColumnName("cBCloser")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26).HasColumnName("cDefine26");

                entity.Property(e => e.CDefine27).HasColumnName("cDefine27");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CExpirationdate)
                    .HasColumnName("cExpirationdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvCode)
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CItemCname)
                    .HasColumnName("cItemCName")
                    .HasMaxLength(20);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CMassUnit).HasColumnName("cMassUnit");

                entity.Property(e => e.CMoLotCode)
                    .HasColumnName("cMoLotCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(255);

                entity.Property(e => e.CSourceMocode)
                    .HasColumnName("cSourceMOCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CWhCode)
                    .HasColumnName("cWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CbMemo)
                    .HasColumnName("cbMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cciqbookcode)
                    .HasColumnName("cciqbookcode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfactorycode)
                    .HasColumnName("cfactorycode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cmocode)
                    .HasColumnName("cmocode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cmworkcentercode)
                    .HasColumnName("cmworkcentercode")
                    .HasMaxLength(8);

                entity.Property(e => e.Comcode)
                    .HasColumnName("comcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Copdesc)
                    .HasColumnName("copdesc")
                    .HasMaxLength(10);

                entity.Property(e => e.Corufts)
                    .HasColumnName("corufts")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cpesocode)
                    .HasColumnName("cpesocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cplanlotcode)
                    .HasColumnName("cplanlotcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Crejectcode)
                    .HasColumnName("crejectcode")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cservicecode)
                    .HasColumnName("cservicecode")
                    .HasMaxLength(30);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(40);

                entity.Property(e => e.DDueDate)
                    .HasColumnName("dDueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DExpirationdate)
                    .HasColumnName("dExpirationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DMadeDate)
                    .HasColumnName("dMadeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVdate)
                    .HasColumnName("dVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FOutNum)
                    .HasColumnName("fOutNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.FOutQuantity)
                    .HasColumnName("fOutQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IExpiratDateCalcu).HasColumnName("iExpiratDateCalcu");

                entity.Property(e => e.IMassDate).HasColumnName("iMassDate");

                entity.Property(e => e.IMpoIds).HasColumnName("iMPoIds");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IOmoDid).HasColumnName("iOMoDID");

                entity.Property(e => e.IOmoMid).HasColumnName("iOMoMID");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISourceModetailsid).HasColumnName("iSourceMODetailsid");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(38, 8)")
                    .HasDefaultValueSql("(null)");

                entity.Property(e => e.Imoseq).HasColumnName("imoseq");

                entity.Property(e => e.Invcode)
                    .HasColumnName("invcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Iopseq)
                    .HasColumnName("iopseq")
                    .HasMaxLength(10);

                entity.Property(e => e.Iordercode)
                    .HasColumnName("iordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype)
                    .HasColumnName("iordertype")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ipesodid)
                    .HasColumnName("ipesodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Ipesoseq).HasColumnName("ipesoseq");

                entity.Property(e => e.Ipesotype).HasColumnName("ipesotype");

                entity.Property(e => e.Ipickednum)
                    .HasColumnName("ipickednum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ipickedquantity)
                    .HasColumnName("ipickedquantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isodid)
                    .HasColumnName("isodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Isoseq).HasColumnName("isoseq");

                entity.Property(e => e.Isotype).HasColumnName("isotype");

                entity.HasOne(d => d.CWhCodeNavigation)
                    .WithMany(p => p.MaterialAppVouchs)
                    .HasForeignKey(d => d.CWhCode)
                    .HasConstraintName("FK__MaterialAppVouch__cWhCod__00F4FB67");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.MaterialAppVouchs)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MaterialAppVouchs__ID__48B0A244");
            });

            modelBuilder.Entity<Materialappd>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("materialappd");

                entity.Property(e => e.Autoid).HasColumnName("autoid");

                entity.Property(e => e.Cassunit)
                    .HasColumnName("cassunit")
                    .HasMaxLength(35);

                entity.Property(e => e.Cbatch)
                    .HasColumnName("cbatch")
                    .HasMaxLength(60);

                entity.Property(e => e.Cbatchproperty1)
                    .HasColumnName("cbatchproperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty10)
                    .HasColumnName("cbatchproperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cbatchproperty2)
                    .HasColumnName("cbatchproperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty3)
                    .HasColumnName("cbatchproperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty4)
                    .HasColumnName("cbatchproperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty5)
                    .HasColumnName("cbatchproperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty6)
                    .HasColumnName("cbatchproperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbatchproperty7)
                    .HasColumnName("cbatchproperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbatchproperty8)
                    .HasColumnName("cbatchproperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbatchproperty9)
                    .HasColumnName("cbatchproperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbcloser)
                    .HasColumnName("cbcloser")
                    .HasMaxLength(20);

                entity.Property(e => e.Cbmemo)
                    .HasColumnName("cbmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cciqbookcode)
                    .HasColumnName("cciqbookcode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cdefine22)
                    .HasColumnName("cdefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine23)
                    .HasColumnName("cdefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine24)
                    .HasColumnName("cdefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine25)
                    .HasColumnName("cdefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine26).HasColumnName("cdefine26");

                entity.Property(e => e.Cdefine27).HasColumnName("cdefine27");

                entity.Property(e => e.Cdefine28)
                    .HasColumnName("cdefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine29)
                    .HasColumnName("cdefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine30)
                    .HasColumnName("cdefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine31)
                    .HasColumnName("cdefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine32)
                    .HasColumnName("cdefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine33)
                    .HasColumnName("cdefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine34).HasColumnName("cdefine34");

                entity.Property(e => e.Cdefine35).HasColumnName("cdefine35");

                entity.Property(e => e.Cdefine36)
                    .HasColumnName("cdefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdefine37)
                    .HasColumnName("cdefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdemandmemo)
                    .IsRequired()
                    .HasColumnName("cdemandmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cexpirationdate)
                    .HasColumnName("cexpirationdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cfactorycode)
                    .HasColumnName("cfactorycode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cfactoryname)
                    .HasColumnName("cfactoryname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cfree1)
                    .HasColumnName("cfree1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree10)
                    .HasColumnName("cfree10")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree2)
                    .HasColumnName("cfree2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree3)
                    .HasColumnName("cfree3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree4)
                    .HasColumnName("cfree4")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree5)
                    .HasColumnName("cfree5")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree6)
                    .HasColumnName("cfree6")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree7)
                    .HasColumnName("cfree7")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree8)
                    .HasColumnName("cfree8")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree9)
                    .HasColumnName("cfree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CinvaUnit)
                    .HasColumnName("cinva_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvaddcode)
                    .HasColumnName("cinvaddcode")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvccode)
                    .HasColumnName("cinvccode")
                    .HasMaxLength(12);

                entity.Property(e => e.Cinvcode)
                    .HasColumnName("cinvcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine1)
                    .HasColumnName("cinvdefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine10)
                    .HasColumnName("cinvdefine10")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine11).HasColumnName("cinvdefine11");

                entity.Property(e => e.Cinvdefine12).HasColumnName("cinvdefine12");

                entity.Property(e => e.Cinvdefine13).HasColumnName("cinvdefine13");

                entity.Property(e => e.Cinvdefine14).HasColumnName("cinvdefine14");

                entity.Property(e => e.Cinvdefine15)
                    .HasColumnName("cinvdefine15")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cinvdefine16)
                    .HasColumnName("cinvdefine16")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cinvdefine2)
                    .HasColumnName("cinvdefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine3)
                    .HasColumnName("cinvdefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine4)
                    .HasColumnName("cinvdefine4")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine5)
                    .HasColumnName("cinvdefine5")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine6)
                    .HasColumnName("cinvdefine6")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine7)
                    .HasColumnName("cinvdefine7")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine8)
                    .HasColumnName("cinvdefine8")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine9)
                    .HasColumnName("cinvdefine9")
                    .HasMaxLength(120);

                entity.Property(e => e.CinvmUnit)
                    .HasColumnName("cinvm_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvname)
                    .HasColumnName("cinvname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvstd)
                    .HasColumnName("cinvstd")
                    .HasMaxLength(255);

                entity.Property(e => e.CitemClass)
                    .HasColumnName("citem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.Citemcname)
                    .HasColumnName("citemcname")
                    .HasMaxLength(20);

                entity.Property(e => e.Citemcode)
                    .HasColumnName("citemcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cmassunit)
                    .HasColumnName("cmassunit")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Cmocode)
                    .HasColumnName("cmocode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cmolotcode)
                    .HasColumnName("cmolotcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cmworkcenter)
                    .HasColumnName("cmworkcenter")
                    .HasMaxLength(60);

                entity.Property(e => e.Cmworkcentercode)
                    .HasColumnName("cmworkcentercode")
                    .HasMaxLength(8);

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(255);

                entity.Property(e => e.Comcode)
                    .HasColumnName("comcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Copdesc)
                    .HasColumnName("copdesc")
                    .HasMaxLength(10);

                entity.Property(e => e.Corufts)
                    .HasColumnName("corufts")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cpesocode)
                    .HasColumnName("cpesocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cplanlotcode)
                    .HasColumnName("cplanlotcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Crejectcode)
                    .HasColumnName("crejectcode")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Creplaceitem)
                    .HasColumnName("creplaceitem")
                    .HasMaxLength(60);

                entity.Property(e => e.Cservicecode)
                    .HasColumnName("cservicecode")
                    .HasMaxLength(30);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Csourcemocode)
                    .HasColumnName("csourcemocode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cwhcode)
                    .HasColumnName("cwhcode")
                    .HasMaxLength(10);

                entity.Property(e => e.Cwhname)
                    .HasColumnName("cwhname")
                    .HasMaxLength(20);

                entity.Property(e => e.Dduedate)
                    .HasColumnName("dduedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dexpirationdate)
                    .HasColumnName("dexpirationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dmadedate)
                    .HasColumnName("dmadedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dvdate)
                    .HasColumnName("dvdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Foutnum)
                    .HasColumnName("foutnum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Foutquantity)
                    .HasColumnName("foutquantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Iavanum)
                    .HasColumnName("iavanum")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Iavaquantity)
                    .HasColumnName("iavaquantity")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Iexpiratdatecalcu).HasColumnName("iexpiratdatecalcu");

                entity.Property(e => e.Igrouptype).HasColumnName("igrouptype");

                entity.Property(e => e.Iid).HasColumnName("iid");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Imassdate).HasColumnName("imassdate");

                entity.Property(e => e.Imoseq).HasColumnName("imoseq");

                entity.Property(e => e.Impoids).HasColumnName("impoids");

                entity.Property(e => e.Inum)
                    .HasColumnName("inum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Invcode)
                    .HasColumnName("invcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Invname)
                    .HasColumnName("invname")
                    .HasMaxLength(255);

                entity.Property(e => e.Invstd)
                    .HasColumnName("invstd")
                    .HasMaxLength(255);

                entity.Property(e => e.Iomodid).HasColumnName("iomodid");

                entity.Property(e => e.Iomomid).HasColumnName("iomomid");

                entity.Property(e => e.Iopseq)
                    .HasColumnName("iopseq")
                    .HasMaxLength(10);

                entity.Property(e => e.Iordercode)
                    .HasColumnName("iordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype).HasColumnName("iordertype");

                entity.Property(e => e.Ipesodid)
                    .HasColumnName("ipesodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Ipesoseq).HasColumnName("ipesoseq");

                entity.Property(e => e.Ipesotype).HasColumnName("ipesotype");

                entity.Property(e => e.Ipickednum)
                    .HasColumnName("ipickednum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ipickedquantity)
                    .HasColumnName("ipickedquantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ipresent)
                    .HasColumnName("ipresent")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Ipresentnum)
                    .HasColumnName("ipresentnum")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Iquantity)
                    .HasColumnName("iquantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isodid)
                    .HasColumnName("isodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Isoseq).HasColumnName("isoseq");

                entity.Property(e => e.Isotype).HasColumnName("isotype");

                entity.Property(e => e.Isourcemodetailsid).HasColumnName("isourcemodetailsid");
            });

            modelBuilder.Entity<Materialappm>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("materialappm");

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.Cchanger)
                    .HasColumnName("cchanger")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccloser)
                    .HasColumnName("ccloser")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccode)
                    .IsRequired()
                    .HasColumnName("ccode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cdefine1)
                    .HasColumnName("cdefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cdefine10)
                    .HasColumnName("cdefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine11)
                    .HasColumnName("cdefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine12)
                    .HasColumnName("cdefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine13)
                    .HasColumnName("cdefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine14)
                    .HasColumnName("cdefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine15).HasColumnName("cdefine15");

                entity.Property(e => e.Cdefine16).HasColumnName("cdefine16");

                entity.Property(e => e.Cdefine2)
                    .HasColumnName("cdefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cdefine3)
                    .HasColumnName("cdefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cdefine4)
                    .HasColumnName("cdefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdefine5).HasColumnName("cdefine5");

                entity.Property(e => e.Cdefine6)
                    .HasColumnName("cdefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdefine7).HasColumnName("cdefine7");

                entity.Property(e => e.Cdefine8)
                    .HasColumnName("cdefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.Cdefine9)
                    .HasColumnName("cdefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.Cdepcode)
                    .HasColumnName("cdepcode")
                    .HasMaxLength(12);

                entity.Property(e => e.Cdepname)
                    .HasColumnName("cdepname")
                    .HasMaxLength(255);

                entity.Property(e => e.Chandler)
                    .HasColumnName("chandler")
                    .HasMaxLength(20);

                entity.Property(e => e.CitemClass)
                    .HasColumnName("citem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.Citemcname)
                    .HasColumnName("citemcname")
                    .HasMaxLength(20);

                entity.Property(e => e.Citemcode)
                    .HasColumnName("citemcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cmaker)
                    .HasColumnName("cmaker")
                    .HasMaxLength(20);

                entity.Property(e => e.Cmemo)
                    .HasColumnName("cmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cmodifyperson)
                    .HasColumnName("cmodifyperson")
                    .HasMaxLength(50);

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(60);

                entity.Property(e => e.Cpersoncode)
                    .HasColumnName("cpersoncode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cpersonname)
                    .HasColumnName("cpersonname")
                    .HasMaxLength(40);

                entity.Property(e => e.Crdcode)
                    .HasColumnName("crdcode")
                    .HasMaxLength(5);

                entity.Property(e => e.Crdname)
                    .HasColumnName("crdname")
                    .HasMaxLength(12);

                entity.Property(e => e.Csource)
                    .HasColumnName("csource")
                    .HasMaxLength(50);

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cvenabbname)
                    .HasColumnName("cvenabbname")
                    .HasMaxLength(60);

                entity.Property(e => e.Cvencode)
                    .HasColumnName("cvencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Ddate)
                    .HasColumnName("ddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dmodifydate)
                    .HasColumnName("dmodifydate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmaketime)
                    .HasColumnName("dnmaketime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmodifytime)
                    .HasColumnName("dnmodifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnverifytime)
                    .HasColumnName("dnverifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dveridate)
                    .HasColumnName("dveridate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IPrintCount).HasColumnName("iPrintCount");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Imquantity)
                    .HasColumnName("imquantity")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Ireturncount).HasColumnName("ireturncount");

                entity.Property(e => e.Iswfcontrolled).HasColumnName("iswfcontrolled");

                entity.Property(e => e.Iverifystate).HasColumnName("iverifystate");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VtId).HasColumnName("vt_id");
            });

            modelBuilder.Entity<OmModetails>(entity =>
            {
                entity.HasKey(e => e.ModetailsId);

                entity.ToTable("OM_MODetails");

                entity.HasIndex(e => e.CInvCode)
                    .HasName("Inventory_MODetails");

                entity.HasIndex(e => e.DUfts)
                    .HasName("idx_OM_MODetails_ufts");

                entity.HasIndex(e => e.Moid)
                    .HasName("MOID_MODetails");

                entity.HasIndex(e => e.MrpdetailsId)
                    .HasName("idx_OM_MODetails_mrpdetailsID");

                entity.Property(e => e.ModetailsId)
                    .HasColumnName("MODetailsID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BGsp)
                    .HasColumnName("bGsp")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BTaxCost)
                    .HasColumnName("bTaxCost")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BomId).HasColumnName("BomID");

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26)
                    .HasColumnName("cDefine26")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CDefine27)
                    .HasColumnName("cDefine27")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CFactoryCode)
                    .HasColumnName("cFactoryCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvCode)
                    .IsRequired()
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemName)
                    .HasColumnName("cItemName")
                    .HasMaxLength(255);

                entity.Property(e => e.CMainInvCode)
                    .HasColumnName("cMainInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CPlanLotNumber)
                    .HasColumnName("cPlanLotNumber")
                    .HasMaxLength(40);

                entity.Property(e => e.CSource)
                    .HasColumnName("cSource")
                    .HasMaxLength(10);

                entity.Property(e => e.CUnitId)
                    .HasColumnName("cUnitID")
                    .HasMaxLength(70);

                entity.Property(e => e.CbCloser)
                    .HasColumnName("cbCloser")
                    .HasMaxLength(20);

                entity.Property(e => e.CbMemo)
                    .HasColumnName("cbMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cdemandcode)
                    .HasColumnName("cdemandcode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cdetailsdemandmemo)
                    .HasColumnName("cdetailsdemandmemo")
                    .HasMaxLength(300);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Csoordercode)
                    .HasColumnName("csoordercode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cupsocode)
                    .HasColumnName("cupsocode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cupsoids).HasColumnName("cupsoids");

                entity.Property(e => e.DArriveDate)
                    .HasColumnName("dArriveDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DStartDate)
                    .HasColumnName("dStartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DUfts)
                    .HasColumnName("dUfts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.DbCloseDate)
                    .HasColumnName("dbCloseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DbCloseTime)
                    .HasColumnName("dbCloseTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FParentScrp)
                    .HasColumnName("fParentScrp")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Freceivednum)
                    .HasColumnName("freceivednum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Freceivedqty)
                    .HasColumnName("freceivedqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Freworknum)
                    .HasColumnName("freworknum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Freworkquantity)
                    .HasColumnName("freworkquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IArrMoney)
                    .HasColumnName("iArrMoney")
                    .HasColumnType("money");

                entity.Property(e => e.IArrNum)
                    .HasColumnName("iArrNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IArrQty)
                    .HasColumnName("iArrQTY")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.ICusBomId).HasColumnName("iCusBomID");

                entity.Property(e => e.IDisCount)
                    .HasColumnName("iDisCount")
                    .HasColumnType("money");

                entity.Property(e => e.IInvMoney)
                    .HasColumnName("iInvMoney")
                    .HasColumnType("money");

                entity.Property(e => e.IInvNum)
                    .HasColumnName("iInvNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IInvQty)
                    .HasColumnName("iInvQTY")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IMainMoDetailsId).HasColumnName("iMainMoDetailsID");

                entity.Property(e => e.IMainMoMaterialsId).HasColumnName("iMainMoMaterialsID");

                entity.Property(e => e.IMaterialSendQty)
                    .HasColumnName("iMaterialSendQty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IMoney)
                    .HasColumnName("iMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INatArrMoney)
                    .HasColumnName("iNatArrMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INatDisCount)
                    .HasColumnName("iNatDisCount")
                    .HasColumnType("money");

                entity.Property(e => e.INatInvMoney)
                    .HasColumnName("iNatInvMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INatMoney)
                    .HasColumnName("iNatMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INatSum)
                    .HasColumnName("iNatSum")
                    .HasColumnType("money");

                entity.Property(e => e.INatTax)
                    .HasColumnName("iNatTax")
                    .HasColumnType("money");

                entity.Property(e => e.INatUnitPrice)
                    .HasColumnName("iNatUnitPrice")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IOriTotal)
                    .HasColumnName("iOriTotal")
                    .HasColumnType("money");

                entity.Property(e => e.IPerTaxRate)
                    .HasColumnName("iPerTaxRate")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IProductType).HasColumnName("iProductType");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IQuotedPrice)
                    .HasColumnName("iQuotedPrice")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IReceivedMoney)
                    .HasColumnName("iReceivedMoney")
                    .HasColumnType("money");

                entity.Property(e => e.IReceivedNum)
                    .HasColumnName("iReceivedNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IReceivedQty)
                    .HasColumnName("iReceivedQTY")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.ISourceMocode)
                    .HasColumnName("iSourceMOCode")
                    .HasMaxLength(60);

                entity.Property(e => e.ISourceModetailsId).HasColumnName("iSourceMODetailsID");

                entity.Property(e => e.ISum)
                    .HasColumnName("iSum")
                    .HasColumnType("money");

                entity.Property(e => e.ITax)
                    .HasColumnName("iTax")
                    .HasColumnType("money");

                entity.Property(e => e.ITaxPrice)
                    .HasColumnName("iTaxPrice")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.ITotal)
                    .HasColumnName("iTotal")
                    .HasColumnType("money");

                entity.Property(e => e.IUnitPrice)
                    .HasColumnName("iUnitPrice")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IVouchRowNo).HasColumnName("iVouchRowNo");

                entity.Property(e => e.IVtids).HasColumnName("iVTids");

                entity.Property(e => e.Iflag).HasColumnName("iflag");

                entity.Property(e => e.Imrpqty)
                    .HasColumnName("imrpqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isoordertype).HasColumnName("isoordertype");

                entity.Property(e => e.Isosid).HasColumnName("isosid");

                entity.Property(e => e.Moid).HasColumnName("MOID");

                entity.Property(e => e.MrpdetailsId).HasColumnName("mrpdetailsID");

                entity.Property(e => e.Sodid)
                    .HasColumnName("SODID")
                    .HasMaxLength(50);

                entity.Property(e => e.Sotype).HasColumnName("SOType");

                entity.Property(e => e.Tbaseqtyd).HasColumnType("decimal(20, 6)");

                entity.HasOne(d => d.Mo)
                    .WithMany(p => p.OmModetails)
                    .HasForeignKey(d => d.Moid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OM_MODET_REFERENCE_OM_MOMAI");
            });

            modelBuilder.Entity<OmMomain>(entity =>
            {
                entity.HasKey(e => e.Moid);

                entity.ToTable("OM_MOMain");

                entity.HasIndex(e => e.CCode)
                    .HasName("cCode_MOMain")
                    .IsUnique();

                entity.HasIndex(e => e.CDepCode)
                    .HasName("Department_MOMain");

                entity.HasIndex(e => e.CPayCode)
                    .HasName("PayCondition_MOMain");

                entity.HasIndex(e => e.CPersonCode)
                    .HasName("Person_MOMain");

                entity.HasIndex(e => e.CPtcode)
                    .HasName("PurchaseType_MOmain");

                entity.HasIndex(e => e.CSccode)
                    .HasName("ShippingChoice_MOMain");

                entity.HasIndex(e => e.CVenCode)
                    .HasName("Vendor_MOMain");

                entity.HasIndex(e => e.CexchName)
                    .HasName("foreigncurrency_MOMain");

                entity.HasIndex(e => e.Ufts)
                    .HasName("ufts_MOMain");

                entity.Property(e => e.Moid)
                    .HasColumnName("MOID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BRework).HasColumnName("bRework");

                entity.Property(e => e.CArrivalPlace)
                    .HasColumnName("cArrivalPlace")
                    .HasMaxLength(255);

                entity.Property(e => e.CBusType)
                    .HasColumnName("cBusType")
                    .HasMaxLength(8);

                entity.Property(e => e.CChangeVerifier)
                    .HasColumnName("cChangeVerifier")
                    .HasMaxLength(40);

                entity.Property(e => e.CChanger)
                    .HasColumnName("cChanger")
                    .HasMaxLength(20);

                entity.Property(e => e.CCloser)
                    .HasColumnName("cCloser")
                    .HasMaxLength(20);

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasColumnName("cCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CContactCode)
                    .HasColumnName("cContactCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7)
                    .HasColumnName("cDefine7")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepCode)
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CLocker)
                    .HasColumnName("cLocker")
                    .HasMaxLength(40);

                entity.Property(e => e.CMaker)
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CModifier)
                    .HasColumnName("cModifier")
                    .HasMaxLength(40);

                entity.Property(e => e.CPayCode)
                    .HasColumnName("cPayCode")
                    .HasMaxLength(3);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CPtcode)
                    .HasColumnName("cPTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CSccode)
                    .HasColumnName("cSCCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CState)
                    .HasColumnName("cState")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CVenAccount)
                    .HasColumnName("cVenAccount")
                    .HasMaxLength(100);

                entity.Property(e => e.CVenBank)
                    .HasColumnName("cVenBank")
                    .HasMaxLength(200);

                entity.Property(e => e.CVenCode)
                    .IsRequired()
                    .HasColumnName("cVenCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenPerson)
                    .HasColumnName("cVenPerson")
                    .HasMaxLength(100);

                entity.Property(e => e.CVenPuomprotocol)
                    .HasColumnName("cVenPUOMProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.CVerifier)
                    .HasColumnName("cVerifier")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccleanver)
                    .HasColumnName("ccleanver")
                    .HasMaxLength(50);

                entity.Property(e => e.CexchName)
                    .IsRequired()
                    .HasColumnName("cexch_name")
                    .HasMaxLength(8);

                entity.Property(e => e.Csrccode)
                    .HasColumnName("csrccode")
                    .HasMaxLength(64);

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.DAlterTime)
                    .HasColumnName("dAlterTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DChangeVerifyDate)
                    .HasColumnName("dChangeVerifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DChangeVerifyTime)
                    .HasColumnName("dChangeVerifyTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DCloseDate)
                    .HasColumnName("dCloseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DCloseTime)
                    .HasColumnName("dCloseTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DCreateTime)
                    .HasColumnName("dCreateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DDate)
                    .HasColumnName("dDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DModifyTime)
                    .HasColumnName("dModifyTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVerifyDate)
                    .HasColumnName("dVerifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVerifyTime)
                    .HasColumnName("dVerifyTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IBargain)
                    .HasColumnName("iBargain")
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ICost)
                    .HasColumnName("iCost")
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IOrderType).HasColumnName("iOrderType");

                entity.Property(e => e.IPrintCount)
                    .HasColumnName("iPrintCount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IReturnCount)
                    .HasColumnName("iReturnCount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ITaxRate)
                    .HasColumnName("iTaxRate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IVerifyStateNew)
                    .HasColumnName("iVerifyStateNew")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IVtid).HasColumnName("iVTid");

                entity.Property(e => e.IsWfControlled).HasDefaultValueSql("(0)");

                entity.Property(e => e.Nflat)
                    .HasColumnName("nflat")
                    .HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<OmMomaterials>(entity =>
            {
                entity.HasKey(e => e.MomaterialsId);

                entity.ToTable("OM_MOMaterials");

                entity.HasIndex(e => e.CInvCode)
                    .HasName("Inventory_MOMaterials");

                entity.HasIndex(e => e.DUfts)
                    .HasName("idx_OM_MOMaterials_ufts");

                entity.HasIndex(e => e.MoDetailsId)
                    .HasName("MODetailsID_MOMaterials");

                entity.HasIndex(e => e.Moid)
                    .HasName("MOID_MOMaterials");

                entity.Property(e => e.MomaterialsId)
                    .HasColumnName("MOMaterialsID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BFvqty).HasColumnName("bFVQty");

                entity.Property(e => e.CBatch)
                    .HasColumnName("cBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CBatchProperty1)
                    .HasColumnName("cBatchProperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty10)
                    .HasColumnName("cBatchProperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.CBatchProperty2)
                    .HasColumnName("cBatchProperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty3)
                    .HasColumnName("cBatchProperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty4)
                    .HasColumnName("cBatchProperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty5)
                    .HasColumnName("cBatchProperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty6)
                    .HasColumnName("cBatchProperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty7)
                    .HasColumnName("cBatchProperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty8)
                    .HasColumnName("cBatchProperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty9)
                    .HasColumnName("cBatchProperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26).HasColumnName("cDefine26");

                entity.Property(e => e.CDefine27).HasColumnName("cDefine27");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CFactoryCode)
                    .HasColumnName("cFactoryCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvCode)
                    .IsRequired()
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CUnitId)
                    .HasColumnName("cUnitID")
                    .HasMaxLength(70);

                entity.Property(e => e.CWhCode)
                    .HasColumnName("cWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CbMemo)
                    .HasColumnName("cbMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cdemandmemo)
                    .HasColumnName("cdemandmemo")
                    .HasMaxLength(300);

                entity.Property(e => e.Cdetailsdemandcode)
                    .HasColumnName("cdetailsdemandcode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cdetailsdemandmemo)
                    .HasColumnName("cdetailsdemandmemo")
                    .HasMaxLength(300);

                entity.Property(e => e.Csendtype)
                    .HasColumnName("csendtype")
                    .HasMaxLength(20);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(50);

                entity.Property(e => e.Csubsysbarcode)
                    .HasColumnName("csubsysbarcode")
                    .HasMaxLength(100);

                entity.Property(e => e.DRequiredDate)
                    .HasColumnName("dRequiredDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DUfts)
                    .HasColumnName("dUfts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.FBaseQtyD)
                    .HasColumnName("fBaseQtyD")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FBaseQtyN)
                    .HasColumnName("fBaseQtyN")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FCompScrp)
                    .HasColumnName("fCompScrp")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FTransQty)
                    .HasColumnName("fTransQty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fapplynum)
                    .HasColumnName("fapplynum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fapplyqty)
                    .HasColumnName("fapplyqty")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fbasenumn)
                    .HasColumnName("fbasenumn")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fsendapplynum)
                    .HasColumnName("fsendapplynum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fsendapplyqty)
                    .HasColumnName("fsendapplyqty")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.IComplementNum)
                    .HasColumnName("iComplementNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IComplementQty)
                    .HasColumnName("iComplementQty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IPickNum)
                    .HasColumnName("iPickNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IPickQty)
                    .HasColumnName("iPickQty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IProductType).HasColumnName("iProductType");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.ISendNum)
                    .HasColumnName("iSendNum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.ISendQty)
                    .HasColumnName("iSendQTY")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IUnitNum)
                    .HasColumnName("iUnitNum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.IUnitQuantity)
                    .HasColumnName("iUnitQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IWiptype).HasColumnName("iWIPtype");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.MoDetailsId).HasColumnName("MoDetailsID");

                entity.Property(e => e.Moid).HasColumnName("MOID");

                entity.Property(e => e.Sodid)
                    .HasColumnName("sodid")
                    .HasMaxLength(50);

                entity.Property(e => e.Sotype).HasColumnName("sotype");

                entity.Property(e => e.SubFlag).HasDefaultValueSql("(0)");

                entity.HasOne(d => d.MoDetails)
                    .WithMany(p => p.OmMomaterials)
                    .HasForeignKey(d => d.MoDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OM_MOMAT_REFERENCE_OM_MODET");

                entity.HasOne(d => d.Mo)
                    .WithMany(p => p.OmMomaterials)
                    .HasForeignKey(d => d.Moid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OM_MOMAT_REFERENCE_OM_MOMAI");
            });

            modelBuilder.Entity<OmMomaterialsbody>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("om_momaterialsbody");

                entity.Property(e => e.Bcomsumeom).HasColumnName("bcomsumeom");

                entity.Property(e => e.Bfvqty).HasColumnName("bfvqty");

                entity.Property(e => e.Binvbatch).HasColumnName("binvbatch");

                entity.Property(e => e.Binvquality).HasColumnName("binvquality");

                entity.Property(e => e.Bspecialorder).HasColumnName("bspecialorder");

                entity.Property(e => e.Cassunit)
                    .HasColumnName("cassunit")
                    .HasMaxLength(70);

                entity.Property(e => e.Cbatch)
                    .HasColumnName("cbatch")
                    .HasMaxLength(60);

                entity.Property(e => e.Cbatchproperty1)
                    .HasColumnName("cbatchproperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty10)
                    .HasColumnName("cbatchproperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cbatchproperty2)
                    .HasColumnName("cbatchproperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty3)
                    .HasColumnName("cbatchproperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty4)
                    .HasColumnName("cbatchproperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty5)
                    .HasColumnName("cbatchproperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty6)
                    .HasColumnName("cbatchproperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbatchproperty7)
                    .HasColumnName("cbatchproperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbatchproperty8)
                    .HasColumnName("cbatchproperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbatchproperty9)
                    .HasColumnName("cbatchproperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbmemo)
                    .HasColumnName("cbmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Ccheckatp)
                    .IsRequired()
                    .HasColumnName("ccheckatp")
                    .HasMaxLength(1);

                entity.Property(e => e.Ccomunitcode)
                    .HasColumnName("ccomunitcode")
                    .HasMaxLength(35);

                entity.Property(e => e.Cdefine22)
                    .HasColumnName("cdefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine23)
                    .HasColumnName("cdefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine24)
                    .HasColumnName("cdefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine25)
                    .HasColumnName("cdefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine26).HasColumnName("cdefine26");

                entity.Property(e => e.Cdefine27).HasColumnName("cdefine27");

                entity.Property(e => e.Cdefine28)
                    .HasColumnName("cdefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine29)
                    .HasColumnName("cdefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine30)
                    .HasColumnName("cdefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine31)
                    .HasColumnName("cdefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine32)
                    .HasColumnName("cdefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine33)
                    .HasColumnName("cdefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine34).HasColumnName("cdefine34");

                entity.Property(e => e.Cdefine35).HasColumnName("cdefine35");

                entity.Property(e => e.Cdefine36)
                    .HasColumnName("cdefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdefine37)
                    .HasColumnName("cdefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdemandmemo)
                    .HasColumnName("cdemandmemo")
                    .HasMaxLength(300);

                entity.Property(e => e.Cdetailsdemandcode)
                    .HasColumnName("cdetailsdemandcode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cdetailsdemandmemo)
                    .HasColumnName("cdetailsdemandmemo")
                    .HasMaxLength(300);

                entity.Property(e => e.Cfactorycode)
                    .HasColumnName("cfactorycode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cfactoryname)
                    .HasColumnName("cfactoryname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cfree1)
                    .HasColumnName("cfree1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree10)
                    .HasColumnName("cfree10")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree2)
                    .HasColumnName("cfree2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree3)
                    .HasColumnName("cfree3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree4)
                    .HasColumnName("cfree4")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree5)
                    .HasColumnName("cfree5")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree6)
                    .HasColumnName("cfree6")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree7)
                    .HasColumnName("cfree7")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree8)
                    .HasColumnName("cfree8")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree9)
                    .HasColumnName("cfree9")
                    .HasMaxLength(20);

                entity.Property(e => e.Cgroupcode)
                    .HasColumnName("cgroupcode")
                    .HasMaxLength(35);

                entity.Property(e => e.CinvaUnit)
                    .HasColumnName("cinva_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvaddcode)
                    .HasColumnName("cinvaddcode")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvcode)
                    .IsRequired()
                    .HasColumnName("cinvcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine1)
                    .HasColumnName("cinvdefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine10)
                    .HasColumnName("cinvdefine10")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine11).HasColumnName("cinvdefine11");

                entity.Property(e => e.Cinvdefine12).HasColumnName("cinvdefine12");

                entity.Property(e => e.Cinvdefine13).HasColumnName("cinvdefine13");

                entity.Property(e => e.Cinvdefine14).HasColumnName("cinvdefine14");

                entity.Property(e => e.Cinvdefine15)
                    .HasColumnName("cinvdefine15")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cinvdefine16)
                    .HasColumnName("cinvdefine16")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cinvdefine2)
                    .HasColumnName("cinvdefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine3)
                    .HasColumnName("cinvdefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine4)
                    .HasColumnName("cinvdefine4")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine5)
                    .HasColumnName("cinvdefine5")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine6)
                    .HasColumnName("cinvdefine6")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine7)
                    .HasColumnName("cinvdefine7")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine8)
                    .HasColumnName("cinvdefine8")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine9)
                    .HasColumnName("cinvdefine9")
                    .HasMaxLength(120);

                entity.Property(e => e.CinvmUnit)
                    .HasColumnName("cinvm_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvname)
                    .HasColumnName("cinvname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvstd)
                    .HasColumnName("cinvstd")
                    .HasMaxLength(255);

                entity.Property(e => e.Cmassunit).HasColumnName("cmassunit");

                entity.Property(e => e.Csendtype)
                    .HasColumnName("csendtype")
                    .HasMaxLength(20);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(50);

                entity.Property(e => e.Csrpolicy)
                    .HasColumnName("csrpolicy")
                    .HasMaxLength(2);

                entity.Property(e => e.Csubsysbarcode)
                    .HasColumnName("csubsysbarcode")
                    .HasMaxLength(100);

                entity.Property(e => e.Cunitid)
                    .HasColumnName("cunitid")
                    .HasMaxLength(70);

                entity.Property(e => e.Cwhcode)
                    .HasColumnName("cwhcode")
                    .HasMaxLength(10);

                entity.Property(e => e.Cwhname)
                    .HasColumnName("cwhname")
                    .HasMaxLength(20);

                entity.Property(e => e.Drequireddate)
                    .HasColumnName("drequireddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dufts)
                    .HasColumnName("dufts")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fapplynum)
                    .HasColumnName("fapplynum")
                    .HasColumnType("decimal(38, 18)");

                entity.Property(e => e.Fapplyqty)
                    .HasColumnName("fapplyqty")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fbasenumn)
                    .HasColumnName("fbasenumn")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fbaseqtyd)
                    .HasColumnName("fbaseqtyd")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fbaseqtyn)
                    .HasColumnName("fbaseqtyn")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fcompscrp)
                    .HasColumnName("fcompscrp")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fnosendnum)
                    .HasColumnName("fnosendnum")
                    .HasColumnType("decimal(38, 7)");

                entity.Property(e => e.Fnosendqty)
                    .HasColumnName("fnosendqty")
                    .HasColumnType("decimal(31, 6)");

                entity.Property(e => e.Fsendapplynum)
                    .HasColumnName("fsendapplynum")
                    .HasColumnType("decimal(38, 18)");

                entity.Property(e => e.Fsendapplyqty)
                    .HasColumnName("fsendapplyqty")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Ftransnum)
                    .HasColumnName("ftransnum")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Ftransqty)
                    .HasColumnName("ftransqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Funtransnum)
                    .HasColumnName("funtransnum")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Funtransqty)
                    .HasColumnName("funtransqty")
                    .HasColumnType("decimal(29, 6)");

                entity.Property(e => e.Iatpqty).HasColumnName("iatpqty");

                entity.Property(e => e.Icomplementnum)
                    .HasColumnName("icomplementnum")
                    .HasColumnType("decimal(38, 10)");

                entity.Property(e => e.Icomplementqty)
                    .HasColumnName("icomplementqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iexpiratdatecalcu).HasColumnName("iexpiratdatecalcu");

                entity.Property(e => e.Igrouptype).HasColumnName("igrouptype");

                entity.Property(e => e.Iinvauthid).HasColumnName("iinvauthid");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(38, 10)");

                entity.Property(e => e.Imassdate).HasColumnName("imassdate");

                entity.Property(e => e.Inum)
                    .HasColumnName("inum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Ipicknum)
                    .HasColumnName("ipicknum")
                    .HasColumnType("decimal(38, 10)");

                entity.Property(e => e.Ipickqty)
                    .HasColumnName("ipickqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Ipresentb)
                    .HasColumnName("ipresentb")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Iproducttype).HasColumnName("iproducttype");

                entity.Property(e => e.Iquantity)
                    .HasColumnName("iquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isendnum)
                    .HasColumnName("isendnum")
                    .HasColumnType("decimal(38, 10)");

                entity.Property(e => e.Isendqty)
                    .HasColumnName("isendqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Isnum)
                    .HasColumnName("isnum")
                    .HasColumnType("decimal(38, 9)");

                entity.Property(e => e.Istsodid)
                    .HasColumnName("istsodid")
                    .HasMaxLength(50);

                entity.Property(e => e.Istsotype).HasColumnName("istsotype");

                entity.Property(e => e.Itnum)
                    .HasColumnName("itnum")
                    .HasColumnType("decimal(38, 10)");

                entity.Property(e => e.Iunitnum)
                    .HasColumnName("iunitnum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Iunitquantity)
                    .HasColumnName("iunitquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iunnum)
                    .HasColumnName("iunnum")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Iwiptype).HasColumnName("iwiptype");

                entity.Property(e => e.Matufts)
                    .HasColumnName("matufts")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Modetailsid).HasColumnName("modetailsid");

                entity.Property(e => e.Moid).HasColumnName("moid");

                entity.Property(e => e.Momaterialsid).HasColumnName("momaterialsid");

                entity.Property(e => e.Opcomponentid).HasColumnName("opcomponentid");

                entity.Property(e => e.Sodid)
                    .HasColumnName("sodid")
                    .HasMaxLength(50);

                entity.Property(e => e.Sotype).HasColumnName("sotype");

                entity.Property(e => e.Subflag)
                    .IsRequired()
                    .HasColumnName("subflag")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<OmMomaterialshead>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("om_momaterialshead");

                entity.Property(e => e.Bgsp).HasColumnName("bgsp");

                entity.Property(e => e.Bomid).HasColumnName("bomid");

                entity.Property(e => e.Bomtype).HasColumnName("bomtype");

                entity.Property(e => e.Brework).HasColumnName("brework");

                entity.Property(e => e.Btaxcost).HasColumnName("btaxcost");

                entity.Property(e => e.Cbcloser)
                    .IsRequired()
                    .HasColumnName("cbcloser")
                    .HasMaxLength(20);

                entity.Property(e => e.Cbmemo)
                    .HasColumnName("cbmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cchanger)
                    .HasColumnName("cchanger")
                    .HasMaxLength(20);

                entity.Property(e => e.Cchangeverifier)
                    .HasColumnName("cchangeverifier")
                    .HasMaxLength(40);

                entity.Property(e => e.Ccloser)
                    .HasColumnName("ccloser")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccode)
                    .HasColumnName("ccode")
                    .HasMaxLength(30);

                entity.Property(e => e.Ccomunitcode)
                    .HasColumnName("ccomunitcode")
                    .HasMaxLength(35);

                entity.Property(e => e.Cdefine22)
                    .HasColumnName("cdefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine23)
                    .HasColumnName("cdefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine24)
                    .HasColumnName("cdefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine25)
                    .HasColumnName("cdefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine26).HasColumnName("cdefine26");

                entity.Property(e => e.Cdefine27).HasColumnName("cdefine27");

                entity.Property(e => e.Cdefine28)
                    .HasColumnName("cdefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine29)
                    .HasColumnName("cdefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine30)
                    .HasColumnName("cdefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine31)
                    .HasColumnName("cdefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine32)
                    .HasColumnName("cdefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine33)
                    .HasColumnName("cdefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine34).HasColumnName("cdefine34");

                entity.Property(e => e.Cdefine35).HasColumnName("cdefine35");

                entity.Property(e => e.Cdefine36)
                    .HasColumnName("cdefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdefine37)
                    .HasColumnName("cdefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdemandcode)
                    .HasColumnName("cdemandcode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cdemandmemo)
                    .HasColumnName("cdemandmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cdetailsdemandmemo)
                    .HasColumnName("cdetailsdemandmemo")
                    .HasMaxLength(300);

                entity.Property(e => e.Cfactorycode)
                    .HasColumnName("cfactorycode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cfactoryname)
                    .HasColumnName("cfactoryname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cfree1)
                    .HasColumnName("cfree1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree10)
                    .HasColumnName("cfree10")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree2)
                    .HasColumnName("cfree2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree3)
                    .HasColumnName("cfree3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree4)
                    .HasColumnName("cfree4")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree5)
                    .HasColumnName("cfree5")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree6)
                    .HasColumnName("cfree6")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree7)
                    .HasColumnName("cfree7")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree8)
                    .HasColumnName("cfree8")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree9)
                    .HasColumnName("cfree9")
                    .HasMaxLength(20);

                entity.Property(e => e.Cgroupcode)
                    .HasColumnName("cgroupcode")
                    .HasMaxLength(35);

                entity.Property(e => e.CinvaUnit)
                    .HasColumnName("cinva_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvaddcode)
                    .HasColumnName("cinvaddcode")
                    .HasMaxLength(255);

                entity.Property(e => e.CinvaddcodeT)
                    .HasColumnName("cinvaddcodeT")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvauthid).HasColumnName("cinvauthid");

                entity.Property(e => e.Cinvcode)
                    .IsRequired()
                    .HasColumnName("cinvcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine1)
                    .HasColumnName("cinvdefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine10)
                    .HasColumnName("cinvdefine10")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine11).HasColumnName("cinvdefine11");

                entity.Property(e => e.Cinvdefine12).HasColumnName("cinvdefine12");

                entity.Property(e => e.Cinvdefine13).HasColumnName("cinvdefine13");

                entity.Property(e => e.Cinvdefine14).HasColumnName("cinvdefine14");

                entity.Property(e => e.Cinvdefine15)
                    .HasColumnName("cinvdefine15")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cinvdefine16)
                    .HasColumnName("cinvdefine16")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cinvdefine2)
                    .HasColumnName("cinvdefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine3)
                    .HasColumnName("cinvdefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine4)
                    .HasColumnName("cinvdefine4")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine5)
                    .HasColumnName("cinvdefine5")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine6)
                    .HasColumnName("cinvdefine6")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine7)
                    .HasColumnName("cinvdefine7")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine8)
                    .HasColumnName("cinvdefine8")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine9)
                    .HasColumnName("cinvdefine9")
                    .HasMaxLength(120);

                entity.Property(e => e.CinvmUnit)
                    .HasColumnName("cinvm_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvname)
                    .HasColumnName("cinvname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvstd)
                    .HasColumnName("cinvstd")
                    .HasMaxLength(255);

                entity.Property(e => e.CinvstdT)
                    .HasColumnName("cinvstdT")
                    .HasMaxLength(255);

                entity.Property(e => e.CitemClass)
                    .HasColumnName("citem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CitemName1)
                    .HasColumnName("citem_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Citemcode)
                    .HasColumnName("citemcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Citemname)
                    .HasColumnName("citemname")
                    .HasMaxLength(255);

                entity.Property(e => e.Clocker)
                    .HasColumnName("clocker")
                    .HasMaxLength(40);

                entity.Property(e => e.Cmaininvcode)
                    .HasColumnName("cmaininvcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cmaker)
                    .HasColumnName("cmaker")
                    .HasMaxLength(20);

                entity.Property(e => e.Cmassunit).HasColumnName("cmassunit");

                entity.Property(e => e.Corufts)
                    .HasColumnName("corufts")
                    .HasMaxLength(60);

                entity.Property(e => e.Cplanlotnumber)
                    .HasColumnName("cplanlotnumber")
                    .HasMaxLength(40);

                entity.Property(e => e.Cplanmethod)
                    .HasColumnName("cplanmethod")
                    .HasMaxLength(1);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Csoordercode)
                    .HasColumnName("csoordercode")
                    .HasMaxLength(50);

                entity.Property(e => e.Csource)
                    .HasColumnName("csource")
                    .HasMaxLength(10);

                entity.Property(e => e.Csrpolicy)
                    .HasColumnName("csrpolicy")
                    .HasMaxLength(2);

                entity.Property(e => e.Cstate).HasColumnName("cstate");

                entity.Property(e => e.Cunitid)
                    .HasColumnName("cunitid")
                    .HasMaxLength(70);

                entity.Property(e => e.Cupsocode)
                    .HasColumnName("cupsocode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cupsoids).HasColumnName("cupsoids");

                entity.Property(e => e.Cvenabbname)
                    .HasColumnName("cvenabbname")
                    .HasMaxLength(60);

                entity.Property(e => e.Cvencode)
                    .HasColumnName("cvencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cveninvcode)
                    .HasColumnName("cveninvcode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cveninvname)
                    .HasColumnName("cveninvname")
                    .HasMaxLength(100);

                entity.Property(e => e.Cverifier)
                    .HasColumnName("cverifier")
                    .HasMaxLength(20);

                entity.Property(e => e.Darrivedate)
                    .HasColumnName("darrivedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dbclosedate)
                    .HasColumnName("dbclosedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dbclosetime)
                    .HasColumnName("dbclosetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ddate)
                    .HasColumnName("ddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dstartdate)
                    .HasColumnName("dstartdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dverifydate)
                    .HasColumnName("dverifydate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fparentscrp)
                    .HasColumnName("fparentscrp")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Freworknum)
                    .HasColumnName("freworknum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Freworkquantity)
                    .HasColumnName("freworkquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iarrmoney)
                    .HasColumnName("iarrmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Iarrnum)
                    .HasColumnName("iarrnum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iarrqty)
                    .HasColumnName("iarrqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Icopyid)
                    .HasColumnName("icopyid")
                    .HasMaxLength(60);

                entity.Property(e => e.Icusbomid).HasColumnName("icusbomid");

                entity.Property(e => e.Identcode)
                    .HasColumnName("identcode")
                    .HasMaxLength(20);

                entity.Property(e => e.Identdesc)
                    .HasColumnName("identdesc")
                    .HasMaxLength(60);

                entity.Property(e => e.Idiscount)
                    .HasColumnName("idiscount")
                    .HasColumnType("money");

                entity.Property(e => e.Iexpiratdatecalcu).HasColumnName("iexpiratdatecalcu");

                entity.Property(e => e.Igrouptype).HasColumnName("igrouptype");

                entity.Property(e => e.Iinvauthid).HasColumnName("iinvauthid");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(38, 10)");

                entity.Property(e => e.Iinvmoney)
                    .HasColumnName("iinvmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Iinvnum)
                    .HasColumnName("iinvnum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iinvqty)
                    .HasColumnName("iinvqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Imainid)
                    .HasColumnName("imainid")
                    .HasMaxLength(60);

                entity.Property(e => e.Imainmodetailsid).HasColumnName("imainmodetailsid");

                entity.Property(e => e.Imainmomaterialsid).HasColumnName("imainmomaterialsid");

                entity.Property(e => e.Imassdate).HasColumnName("imassdate");

                entity.Property(e => e.Imaterialsendqty)
                    .HasColumnName("imaterialsendqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Imoney)
                    .HasColumnName("imoney")
                    .HasColumnType("money");

                entity.Property(e => e.Imrpqty)
                    .HasColumnName("imrpqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Inatarrmoney)
                    .HasColumnName("inatarrmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Inatdiscount)
                    .HasColumnName("inatdiscount")
                    .HasColumnType("money");

                entity.Property(e => e.Inatinvmoney)
                    .HasColumnName("inatinvmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Inatmoney)
                    .HasColumnName("inatmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Inatsum)
                    .HasColumnName("inatsum")
                    .HasColumnType("money");

                entity.Property(e => e.Inattax)
                    .HasColumnName("inattax")
                    .HasColumnType("money");

                entity.Property(e => e.Inatunitprice)
                    .HasColumnName("inatunitprice")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Inum)
                    .HasColumnName("inum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype).HasColumnName("iordertype");

                entity.Property(e => e.Ioritotal)
                    .HasColumnName("ioritotal")
                    .HasColumnType("money");

                entity.Property(e => e.Ipertaxrate)
                    .HasColumnName("ipertaxrate")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iproducttype).HasColumnName("iproducttype");

                entity.Property(e => e.Iquantity)
                    .HasColumnName("iquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iquotedprice)
                    .HasColumnName("iquotedprice")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Ireceivedmoney)
                    .HasColumnName("ireceivedmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Ireceivednum)
                    .HasColumnName("ireceivednum")
                    .HasColumnType("decimal(38, 9)");

                entity.Property(e => e.Ireceivedqty)
                    .HasColumnName("ireceivedqty")
                    .HasColumnType("decimal(29, 6)");

                entity.Property(e => e.Irequiretrackstyle).HasColumnName("irequiretrackstyle");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isoordertype).HasColumnName("isoordertype");

                entity.Property(e => e.Isosid).HasColumnName("isosid");

                entity.Property(e => e.Isourcemocode)
                    .HasColumnName("isourcemocode")
                    .HasMaxLength(60);

                entity.Property(e => e.Isourcemodetailsid).HasColumnName("isourcemodetailsid");

                entity.Property(e => e.Isum)
                    .HasColumnName("isum")
                    .HasColumnType("money");

                entity.Property(e => e.Iswfcontrolled).HasColumnName("iswfcontrolled");

                entity.Property(e => e.Itax)
                    .HasColumnName("itax")
                    .HasColumnType("money");

                entity.Property(e => e.Itaxprice)
                    .HasColumnName("itaxprice")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Itotal)
                    .HasColumnName("itotal")
                    .HasColumnType("money");

                entity.Property(e => e.Iunitprice)
                    .HasColumnName("iunitprice")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iverifystatenew).HasColumnName("iverifystatenew");

                entity.Property(e => e.Ivouchrowno).HasColumnName("ivouchrowno");

                entity.Property(e => e.Ivtids).HasColumnName("ivtids");

                entity.Property(e => e.Modetailsid).HasColumnName("modetailsid");

                entity.Property(e => e.Moid).HasColumnName("moid");

                entity.Property(e => e.Mrpdetailsid).HasColumnName("mrpdetailsid");

                entity.Property(e => e.Sodid)
                    .HasColumnName("sodid")
                    .HasMaxLength(50);

                entity.Property(e => e.Sotype).HasColumnName("sotype");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Version).HasColumnName("version");

                entity.Property(e => e.Versiondesc)
                    .HasColumnName("versiondesc")
                    .HasMaxLength(60);

                entity.Property(e => e.Versioneffdate)
                    .HasColumnName("versioneffdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Versionenddate)
                    .HasColumnName("versionenddate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.CPersonCode)
                    .HasName("aaaaaPerson_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CDepCode)
                    .HasName("DepartmentPerson");

                entity.HasIndex(e => e.CPersonName)
                    .HasName("cPersonName");

                entity.HasIndex(e => new { e.CPersonCode, e.CPersonName })
                    .HasName("ix_PersonSCodeName");

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCreGrade)
                    .HasColumnName("cCreGrade")
                    .HasMaxLength(6);

                entity.Property(e => e.CDepCode)
                    .IsRequired()
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.COfferGrade)
                    .HasColumnName("cOfferGrade")
                    .HasMaxLength(20);

                entity.Property(e => e.CPersonEmail)
                    .HasColumnName("cPersonEmail")
                    .HasMaxLength(100);

                entity.Property(e => e.CPersonName)
                    .HasColumnName("cPersonName")
                    .HasMaxLength(40);

                entity.Property(e => e.CPersonPhone)
                    .HasColumnName("cPersonPhone")
                    .HasMaxLength(100);

                entity.Property(e => e.CPersonProp)
                    .HasColumnName("cPersonProp")
                    .HasMaxLength(20);

                entity.Property(e => e.DPinValidDate)
                    .HasColumnName("dPInValidDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DPvalidDate)
                    .HasColumnName("dPValidDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FCreditQuantity).HasColumnName("fCreditQuantity");

                entity.Property(e => e.ICreDate).HasColumnName("iCreDate");

                entity.Property(e => e.ILowRate).HasColumnName("iLowRate");

                entity.Property(e => e.IOfferRate).HasColumnName("iOfferRate");

                entity.Property(e => e.Pubufts)
                    .HasColumnName("pubufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CDepCodeNavigation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.CDepCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__cDepCode__35D2D7FA");
            });

            modelBuilder.Entity<PoPodetails>(entity =>
            {
                entity.ToTable("PO_Podetails");

                entity.HasIndex(e => e.CInvCode)
                    .HasName("InventoryPO_PODetails");

                entity.HasIndex(e => e.DUfts)
                    .HasName("idx_Po_Podetails_ufts");

                entity.HasIndex(e => e.IInvNum)
                    .HasName("iReceivedNum1");

                entity.HasIndex(e => e.IReceivedNum)
                    .HasName("iReceivedNum");

                entity.HasIndex(e => e.ISosId)
                    .HasName("isosidforia");

                entity.HasIndex(e => e.Poid)
                    .HasName("PODetails_POID");

                entity.HasIndex(e => e.Ppcids)
                    .HasName("idx_po_podetails_PPCIds");

                entity.HasIndex(e => e.SoDid)
                    .HasName("IX_MX_sodid");

                entity.HasIndex(e => new { e.SoType, e.SoDid })
                    .HasName("IX_MX_001");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BGsp)
                    .HasColumnName("bGsp")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BTaxCost)
                    .HasColumnName("bTaxCost")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bgift)
                    .HasColumnName("bgift")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CBgAuditopinion)
                    .HasColumnName("cBG_Auditopinion")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberCode1)
                    .HasColumnName("cBG_CaliberCode1")
                    .HasMaxLength(90)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberCode2)
                    .HasColumnName("cBG_CaliberCode2")
                    .HasMaxLength(90)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberCode3)
                    .HasColumnName("cBG_CaliberCode3")
                    .HasMaxLength(90)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberCode4)
                    .HasColumnName("cBG_CaliberCode4")
                    .HasMaxLength(90)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberCode5)
                    .HasColumnName("cBG_CaliberCode5")
                    .HasMaxLength(90)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberCode6)
                    .HasColumnName("cBG_CaliberCode6")
                    .HasMaxLength(90)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberKey1)
                    .HasColumnName("cBG_CaliberKey1")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberKey2)
                    .HasColumnName("cBG_CaliberKey2")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberKey3)
                    .HasColumnName("cBG_CaliberKey3")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberKey4)
                    .HasColumnName("cBG_CaliberKey4")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberKey5)
                    .HasColumnName("cBG_CaliberKey5")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberKey6)
                    .HasColumnName("cBG_CaliberKey6")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberKeyName1)
                    .HasColumnName("cBG_CaliberKeyName1")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberKeyName2)
                    .HasColumnName("cBG_CaliberKeyName2")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberKeyName3)
                    .HasColumnName("cBG_CaliberKeyName3")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberKeyName4)
                    .HasColumnName("cBG_CaliberKeyName4")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberKeyName5)
                    .HasColumnName("cBG_CaliberKeyName5")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberKeyName6)
                    .HasColumnName("cBG_CaliberKeyName6")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberName1)
                    .HasColumnName("cBG_CaliberName1")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberName2)
                    .HasColumnName("cBG_CaliberName2")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberName3)
                    .HasColumnName("cBG_CaliberName3")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberName4)
                    .HasColumnName("cBG_CaliberName4")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberName5)
                    .HasColumnName("cBG_CaliberName5")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgCaliberName6)
                    .HasColumnName("cBG_CaliberName6")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgItemCode)
                    .HasColumnName("cBG_ItemCode")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgItemName)
                    .HasColumnName("cBG_ItemName")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26)
                    .HasColumnName("cDefine26")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CDefine27)
                    .HasColumnName("cDefine27")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CFactoryCode)
                    .HasColumnName("cFactoryCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvCode)
                    .IsRequired()
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemName)
                    .HasColumnName("cItemName")
                    .HasMaxLength(255);

                entity.Property(e => e.CPoid)
                    .HasColumnName("cPOID")
                    .HasMaxLength(30);

                entity.Property(e => e.CSource)
                    .HasColumnName("cSource")
                    .HasMaxLength(10);

                entity.Property(e => e.CUnitId)
                    .HasColumnName("cUnitID")
                    .HasMaxLength(35);

                entity.Property(e => e.CbCloseDate)
                    .HasColumnName("cbCloseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CbCloseTime)
                    .HasColumnName("cbCloseTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CbCloser)
                    .HasColumnName("cbCloser")
                    .HasMaxLength(20);

                entity.Property(e => e.CbMemo)
                    .HasColumnName("cbMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Clsbwhcode)
                    .HasColumnName("clsbwhcode")
                    .HasMaxLength(10);

                entity.Property(e => e.ContractCode).HasMaxLength(128);

                entity.Property(e => e.ContractRowGuid).HasColumnName("ContractRowGUID");

                entity.Property(e => e.ContractRowNo).HasMaxLength(150);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Csoordercode)
                    .HasColumnName("csoordercode")
                    .HasMaxLength(50);

                entity.Property(e => e.Csyssourceautoid)
                    .HasColumnName("csyssourceautoid")
                    .HasMaxLength(50);

                entity.Property(e => e.Cupsocode)
                    .HasColumnName("cupsocode")
                    .HasMaxLength(64);

                entity.Property(e => e.Cxjspdids)
                    .HasColumnName("cxjspdids")
                    .HasMaxLength(60);

                entity.Property(e => e.DArriveDate)
                    .HasColumnName("dArriveDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DUfts)
                    .HasColumnName("dUfts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.FPoArrNum)
                    .HasColumnName("fPoArrNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FPoArrQuantity)
                    .HasColumnName("fPoArrQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FPoRefuseNum)
                    .HasColumnName("fPoRefuseNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FPoRefuseQuantity)
                    .HasColumnName("fPoRefuseQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FPoRetNum)
                    .HasColumnName("fPoRetNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FPoRetQuantity)
                    .HasColumnName("fPoRetQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FPoValidNum)
                    .HasColumnName("fPoValidNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FPoValidQuantity)
                    .HasColumnName("fPoValidQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fexnum)
                    .HasColumnName("fexnum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fexquantity)
                    .HasColumnName("fexquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Freceivednum)
                    .HasColumnName("freceivednum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Freceivedqty)
                    .HasColumnName("freceivedqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.GcsourceId).HasColumnName("GCSourceId");

                entity.Property(e => e.GcsourceIds).HasColumnName("GCSourceIds");

                entity.Property(e => e.GcupCardNum)
                    .HasColumnName("GCUpCardNum")
                    .HasMaxLength(100);

                entity.Property(e => e.GcupId).HasColumnName("GCUpId");

                entity.Property(e => e.GcupIds).HasColumnName("GCUpIds");

                entity.Property(e => e.IAppIds).HasColumnName("iAppIds");

                entity.Property(e => e.IArrMoney)
                    .HasColumnName("iArrMoney")
                    .HasColumnType("money");

                entity.Property(e => e.IArrNum)
                    .HasColumnName("iArrNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IArrQty)
                    .HasColumnName("iArrQTY")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IBgCtrl)
                    .HasColumnName("iBG_Ctrl")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IDisCount)
                    .HasColumnName("iDisCount")
                    .HasColumnType("money");

                entity.Property(e => e.IInvMoney)
                    .HasColumnName("iInvMoney")
                    .HasColumnType("money");

                entity.Property(e => e.IInvMpcost)
                    .HasColumnName("iInvMPCost")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.IInvNum)
                    .HasColumnName("iInvNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IInvQty)
                    .HasColumnName("iInvQTY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IMoney)
                    .HasColumnName("iMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INatArrMoney)
                    .HasColumnName("iNatArrMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INatDisCount)
                    .HasColumnName("iNatDisCount")
                    .HasColumnType("money");

                entity.Property(e => e.INatInvMoney)
                    .HasColumnName("iNatInvMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INatMoney)
                    .HasColumnName("iNatMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INatSum)
                    .HasColumnName("iNatSum")
                    .HasColumnType("money");

                entity.Property(e => e.INatTax)
                    .HasColumnName("iNatTax")
                    .HasColumnType("money");

                entity.Property(e => e.INatUnitPrice)
                    .HasColumnName("iNatUnitPrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IOriTotal)
                    .HasColumnName("iOriTotal")
                    .HasColumnType("money");

                entity.Property(e => e.IPerTaxRate)
                    .HasColumnName("iPerTaxRate")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IPpartId).HasColumnName("iPPartId");

                entity.Property(e => e.IPquantity)
                    .HasColumnName("iPQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IPtoseq).HasColumnName("iPTOSeq");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IQuotedPrice)
                    .HasColumnName("iQuotedPrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IReceivedMoney)
                    .HasColumnName("iReceivedMoney")
                    .HasColumnType("money");

                entity.Property(e => e.IReceivedNum)
                    .HasColumnName("iReceivedNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IReceivedQty)
                    .HasColumnName("iReceivedQTY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISosId).HasColumnName("iSOsID");

                entity.Property(e => e.ISum)
                    .HasColumnName("iSum")
                    .HasColumnType("money");

                entity.Property(e => e.ITax)
                    .HasColumnName("iTax")
                    .HasColumnType("money");

                entity.Property(e => e.ITaxPrice)
                    .HasColumnName("iTaxPrice")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.ITotal)
                    .HasColumnName("iTotal")
                    .HasColumnType("money");

                entity.Property(e => e.IUnitPrice)
                    .HasColumnName("iUnitPrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Iflag).HasColumnName("iflag");

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype).HasColumnName("iordertype");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Ivouchrowno).HasColumnName("ivouchrowno");

                entity.Property(e => e.Planlotnumber)
                    .HasColumnName("planlotnumber")
                    .HasMaxLength(40);

                entity.Property(e => e.Poid).HasColumnName("POID");

                entity.Property(e => e.Ppcids).HasColumnName("PPCIds");

                entity.Property(e => e.SoDid)
                    .HasColumnName("SoDId")
                    .HasMaxLength(50);

                entity.Property(e => e.YycInvname)
                    .HasColumnName("YYC_INVName")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<PoPomain>(entity =>
            {
                entity.HasKey(e => e.Poid)
                    .HasName("PK_PO_POMain");

                entity.ToTable("PO_Pomain");

                entity.HasIndex(e => e.CDepCode)
                    .HasName("DepartmentPO_POMain");

                entity.HasIndex(e => e.CPayCode)
                    .HasName("PayConditionPO_POMain");

                entity.HasIndex(e => e.CPersonCode)
                    .HasName("PersonPO_POMain");

                entity.HasIndex(e => e.CPoid)
                    .HasName("cPOID")
                    .IsUnique();

                entity.HasIndex(e => e.CPtcode)
                    .HasName("PurchaseTypePO_POmain");

                entity.HasIndex(e => e.CSccode)
                    .HasName("ShippingChoicePO_POMain");

                entity.HasIndex(e => e.CVenCode)
                    .HasName("VendorPO_POMain");

                entity.HasIndex(e => e.CexchName)
                    .HasName("foreigncurrencyPO_POMain");

                entity.HasIndex(e => e.Ufts)
                    .HasName("UftsPo_Pomain");

                entity.Property(e => e.Poid)
                    .HasColumnName("POID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BGctransforming)
                    .HasColumnName("bGCTransforming")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CArrivalPlace)
                    .HasColumnName("cArrivalPlace")
                    .HasMaxLength(255);

                entity.Property(e => e.CAuditDate)
                    .HasColumnName("cAuditDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CAuditTime)
                    .HasColumnName("cAuditTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CBgAuditTime)
                    .HasColumnName("cBG_AuditTime")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgAuditor)
                    .HasColumnName("cBG_Auditor")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBusType)
                    .HasColumnName("cBusType")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("('普通采购')");

                entity.Property(e => e.CChangAuditDate)
                    .HasColumnName("cChangAuditDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CChangAuditTime)
                    .HasColumnName("cChangAuditTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CChangVerifier)
                    .HasColumnName("cChangVerifier")
                    .HasMaxLength(40);

                entity.Property(e => e.CChanger)
                    .HasColumnName("cChanger")
                    .HasMaxLength(20);

                entity.Property(e => e.CCloser)
                    .HasColumnName("cCloser")
                    .HasMaxLength(20);

                entity.Property(e => e.CContactCode)
                    .HasColumnName("cContactCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7).HasColumnName("cDefine7");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepCode)
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CGcrouteCode)
                    .HasColumnName("cGCRouteCode")
                    .HasMaxLength(40);

                entity.Property(e => e.CLocker)
                    .HasColumnName("cLocker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMaker)
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CModifyDate)
                    .HasColumnName("cModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CModifyTime)
                    .HasColumnName("cModifyTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CPayCode)
                    .HasColumnName("cPayCode")
                    .HasMaxLength(3);

                entity.Property(e => e.CPeriod)
                    .HasColumnName("cPeriod")
                    .HasMaxLength(12);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CPoid)
                    .HasColumnName("cPOID")
                    .HasMaxLength(30);

                entity.Property(e => e.CPtcode)
                    .HasColumnName("cPTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CReviser)
                    .HasColumnName("cReviser")
                    .HasMaxLength(40);

                entity.Property(e => e.CSccode)
                    .HasColumnName("cSCCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CState).HasColumnName("cState");

                entity.Property(e => e.CVenAccount)
                    .HasColumnName("cVenAccount")
                    .HasMaxLength(100);

                entity.Property(e => e.CVenBank)
                    .HasColumnName("cVenBank")
                    .HasMaxLength(200);

                entity.Property(e => e.CVenCode)
                    .HasColumnName("cVenCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenPerson)
                    .HasColumnName("cVenPerson")
                    .HasMaxLength(100);

                entity.Property(e => e.CVenPuomprotocol)
                    .HasColumnName("cVenPUOMProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.CVerifier)
                    .HasColumnName("cVerifier")
                    .HasMaxLength(20);

                entity.Property(e => e.Cappcode)
                    .HasColumnName("cappcode")
                    .HasMaxLength(64);

                entity.Property(e => e.Ccleanver)
                    .HasColumnName("ccleanver")
                    .HasMaxLength(50);

                entity.Property(e => e.CexchName)
                    .HasColumnName("cexch_name")
                    .HasMaxLength(8);

                entity.Property(e => e.Clshwhcode)
                    .HasColumnName("clshwhcode")
                    .HasMaxLength(10);

                entity.Property(e => e.Cmaketime)
                    .HasColumnName("cmaketime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Csyssource)
                    .HasColumnName("csyssource")
                    .HasMaxLength(10);

                entity.Property(e => e.Csyssourceid)
                    .HasColumnName("csyssourceid")
                    .HasMaxLength(50);

                entity.Property(e => e.DCloseDate)
                    .HasColumnName("dCloseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DCloseTime)
                    .HasColumnName("dCloseTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DPodate)
                    .HasColumnName("dPODate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IBargain)
                    .HasColumnName("iBargain")
                    .HasColumnType("money");

                entity.Property(e => e.IBgOverFlag)
                    .HasColumnName("iBG_OverFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ICost)
                    .HasColumnName("iCost")
                    .HasColumnType("money");

                entity.Property(e => e.IDiscountTaxType)
                    .HasColumnName("iDiscountTaxType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IPrintCount)
                    .HasColumnName("iPrintCount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ITaxRate).HasColumnName("iTaxRate");

                entity.Property(e => e.IVtid)
                    .HasColumnName("iVTid")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iflowid).HasColumnName("iflowid");

                entity.Property(e => e.Ireturncount).HasColumnName("ireturncount");

                entity.Property(e => e.IsWfControlled).HasDefaultValueSql("(0)");

                entity.Property(e => e.Iverifystateex).HasColumnName("iverifystateex");

                entity.Property(e => e.Nflat).HasColumnName("nflat");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.YycReason)
                    .HasColumnName("YYC_Reason")
                    .HasMaxLength(255);

                entity.Property(e => e.YycRespStatus)
                    .HasColumnName("YYC_RespStatus")
                    .HasMaxLength(20);

                entity.HasOne(d => d.CDepCodeNavigation)
                    .WithMany(p => p.PoPomain)
                    .HasForeignKey(d => d.CDepCode)
                    .HasConstraintName("FK__PO_Pomain__cDepC__36C6FC33");

                entity.HasOne(d => d.CPersonCodeNavigation)
                    .WithMany(p => p.PoPomain)
                    .HasForeignKey(d => d.CPersonCode)
                    .HasConstraintName("FK__PO_Pomain__cPers__143CDA05");

                entity.HasOne(d => d.CVenCodeNavigation)
                    .WithMany(p => p.PoPomain)
                    .HasForeignKey(d => d.CVenCode)
                    .HasConstraintName("FK__PO_Pomain__cVenC__5F94079C");
            });

            modelBuilder.Entity<PuArrHead>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("pu_ArrHead");

                entity.Property(e => e.Bflowprocess).HasColumnName("bflowprocess");

                entity.Property(e => e.Bnegative).HasColumnName("bnegative");

                entity.Property(e => e.Bstoragearrivalorder).HasColumnName("bstoragearrivalorder");

                entity.Property(e => e.Cauditdate)
                    .HasColumnName("cauditdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Caudittime)
                    .HasColumnName("caudittime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cauthid).HasColumnName("cauthid");

                entity.Property(e => e.Cbustype)
                    .IsRequired()
                    .HasColumnName("cbustype")
                    .HasMaxLength(8);

                entity.Property(e => e.Cchanger)
                    .HasColumnName("cchanger")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccloser)
                    .HasColumnName("ccloser")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccode)
                    .IsRequired()
                    .HasColumnName("ccode")
                    .HasMaxLength(30);

                entity.Property(e => e.Ccurrentauditor)
                    .HasColumnName("ccurrentauditor")
                    .HasMaxLength(200);

                entity.Property(e => e.Cdefine1)
                    .HasColumnName("cdefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cdefine10)
                    .HasColumnName("cdefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine11)
                    .HasColumnName("cdefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine12)
                    .HasColumnName("cdefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine13)
                    .HasColumnName("cdefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine14)
                    .HasColumnName("cdefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine15).HasColumnName("cdefine15");

                entity.Property(e => e.Cdefine16).HasColumnName("cdefine16");

                entity.Property(e => e.Cdefine2)
                    .HasColumnName("cdefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cdefine3)
                    .HasColumnName("cdefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cdefine4)
                    .HasColumnName("cdefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdefine5).HasColumnName("cdefine5");

                entity.Property(e => e.Cdefine6)
                    .HasColumnName("cdefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdefine7).HasColumnName("cdefine7");

                entity.Property(e => e.Cdefine8)
                    .HasColumnName("cdefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.Cdefine9)
                    .HasColumnName("cdefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.Cdepcode)
                    .HasColumnName("cdepcode")
                    .HasMaxLength(12);

                entity.Property(e => e.Cdepname)
                    .HasColumnName("cdepname")
                    .HasMaxLength(255);

                entity.Property(e => e.CexchCode)
                    .HasColumnName("cexch_code")
                    .HasMaxLength(4);

                entity.Property(e => e.CexchName)
                    .IsRequired()
                    .HasColumnName("cexch_name")
                    .HasMaxLength(8);

                entity.Property(e => e.Cflowname)
                    .HasColumnName("cflowname")
                    .HasMaxLength(40);

                entity.Property(e => e.Cmaker)
                    .IsRequired()
                    .HasColumnName("cmaker")
                    .HasMaxLength(20);

                entity.Property(e => e.Cmaketime)
                    .HasColumnName("cmaketime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cmemo)
                    .HasColumnName("cmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cmodifydate)
                    .HasColumnName("cmodifydate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cmodifytime)
                    .HasColumnName("cmodifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cpaycode)
                    .HasColumnName("cpaycode")
                    .HasMaxLength(3);

                entity.Property(e => e.Cpayname)
                    .HasColumnName("cpayname")
                    .HasMaxLength(60);

                entity.Property(e => e.Cpersoncode)
                    .HasColumnName("cpersoncode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cpersonname)
                    .HasColumnName("cpersonname")
                    .HasMaxLength(40);

                entity.Property(e => e.Cpocode)
                    .HasColumnName("cpocode")
                    .HasMaxLength(64);

                entity.Property(e => e.Cptcode)
                    .HasColumnName("cptcode")
                    .HasMaxLength(2);

                entity.Property(e => e.Cptname)
                    .HasColumnName("cptname")
                    .HasMaxLength(20);

                entity.Property(e => e.Creviser)
                    .HasColumnName("creviser")
                    .HasMaxLength(40);

                entity.Property(e => e.Csccode)
                    .HasColumnName("csccode")
                    .HasMaxLength(2);

                entity.Property(e => e.Cscname)
                    .HasColumnName("cscname")
                    .HasMaxLength(20);

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cvenabbname)
                    .HasColumnName("cvenabbname")
                    .HasMaxLength(60);

                entity.Property(e => e.Cvencode)
                    .IsRequired()
                    .HasColumnName("cvencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cvendefine1)
                    .HasColumnName("cvendefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cvendefine10)
                    .HasColumnName("cvendefine10")
                    .HasMaxLength(120);

                entity.Property(e => e.Cvendefine11).HasColumnName("cvendefine11");

                entity.Property(e => e.Cvendefine12).HasColumnName("cvendefine12");

                entity.Property(e => e.Cvendefine13).HasColumnName("cvendefine13");

                entity.Property(e => e.Cvendefine14).HasColumnName("cvendefine14");

                entity.Property(e => e.Cvendefine15)
                    .HasColumnName("cvendefine15")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cvendefine16)
                    .HasColumnName("cvendefine16")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cvendefine2)
                    .HasColumnName("cvendefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cvendefine3)
                    .HasColumnName("cvendefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cvendefine4)
                    .HasColumnName("cvendefine4")
                    .HasMaxLength(60);

                entity.Property(e => e.Cvendefine5)
                    .HasColumnName("cvendefine5")
                    .HasMaxLength(60);

                entity.Property(e => e.Cvendefine6)
                    .HasColumnName("cvendefine6")
                    .HasMaxLength(60);

                entity.Property(e => e.Cvendefine7)
                    .HasColumnName("cvendefine7")
                    .HasMaxLength(120);

                entity.Property(e => e.Cvendefine8)
                    .HasColumnName("cvendefine8")
                    .HasMaxLength(120);

                entity.Property(e => e.Cvendefine9)
                    .HasColumnName("cvendefine9")
                    .HasMaxLength(120);

                entity.Property(e => e.Cvenname)
                    .HasColumnName("cvenname")
                    .HasMaxLength(98);

                entity.Property(e => e.Cvenpuomprotocol)
                    .HasColumnName("cvenpuomprotocol")
                    .HasMaxLength(20);

                entity.Property(e => e.Cvenpuomprotocolname)
                    .HasColumnName("cvenpuomprotocolname")
                    .HasMaxLength(60);

                entity.Property(e => e.Cverifier)
                    .HasColumnName("cverifier")
                    .HasMaxLength(20);

                entity.Property(e => e.Cvoucherstate)
                    .HasColumnName("cvoucherstate")
                    .HasMaxLength(3);

                entity.Property(e => e.Cvouchtype)
                    .HasColumnName("cvouchtype")
                    .HasMaxLength(10);

                entity.Property(e => e.Dclosedate)
                    .HasColumnName("dclosedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ddate)
                    .HasColumnName("ddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ibilltype).HasColumnName("ibilltype");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idiscounttaxtype).HasColumnName("idiscounttaxtype");

                entity.Property(e => e.Iexchrate).HasColumnName("iexchrate");

                entity.Property(e => e.Iflowid).HasColumnName("iflowid");

                entity.Property(e => e.Iprintcount).HasColumnName("iprintcount");

                entity.Property(e => e.Ireturncount).HasColumnName("ireturncount");

                entity.Property(e => e.Iswfcontrolled).HasColumnName("iswfcontrolled");

                entity.Property(e => e.Itaxrate)
                    .HasColumnName("itaxrate")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Iverifystateex).HasColumnName("iverifystateex");

                entity.Property(e => e.Ivtid).HasColumnName("ivtid");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PuArrbody>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("pu_arrbody");

                entity.Property(e => e.Autoid).HasColumnName("autoid");

                entity.Property(e => e.Bexigency).HasColumnName("bexigency");

                entity.Property(e => e.Bgift).HasColumnName("bgift");

                entity.Property(e => e.Bgsp).HasColumnName("bgsp");

                entity.Property(e => e.Binspect).HasColumnName("binspect");

                entity.Property(e => e.Binvbatch).HasColumnName("binvbatch");

                entity.Property(e => e.Bservice).HasColumnName("bservice");

                entity.Property(e => e.Btaxcost).HasColumnName("btaxcost");

                entity.Property(e => e.Carrivalcode)
                    .HasColumnName("carrivalcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cbatch)
                    .HasColumnName("cbatch")
                    .HasMaxLength(60);

                entity.Property(e => e.Cbatchproperty1)
                    .HasColumnName("cbatchproperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty10)
                    .HasColumnName("cbatchproperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cbatchproperty2)
                    .HasColumnName("cbatchproperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty3)
                    .HasColumnName("cbatchproperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty4)
                    .HasColumnName("cbatchproperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty5)
                    .HasColumnName("cbatchproperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Cbatchproperty6)
                    .HasColumnName("cbatchproperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbatchproperty7)
                    .HasColumnName("cbatchproperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbatchproperty8)
                    .HasColumnName("cbatchproperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbatchproperty9)
                    .HasColumnName("cbatchproperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.Cbcloser)
                    .IsRequired()
                    .HasColumnName("cbcloser")
                    .HasMaxLength(20);

                entity.Property(e => e.Cbmemo)
                    .HasColumnName("cbmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Ccloser)
                    .HasColumnName("ccloser")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccomunitcode)
                    .HasColumnName("ccomunitcode")
                    .HasMaxLength(35);

                entity.Property(e => e.Cdefine22)
                    .HasColumnName("cdefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine23)
                    .HasColumnName("cdefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine24)
                    .HasColumnName("cdefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine25)
                    .HasColumnName("cdefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine26).HasColumnName("cdefine26");

                entity.Property(e => e.Cdefine27).HasColumnName("cdefine27");

                entity.Property(e => e.Cdefine28)
                    .HasColumnName("cdefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine29)
                    .HasColumnName("cdefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine30)
                    .HasColumnName("cdefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine31)
                    .HasColumnName("cdefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine32)
                    .HasColumnName("cdefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine33)
                    .HasColumnName("cdefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine34).HasColumnName("cdefine34");

                entity.Property(e => e.Cdefine35).HasColumnName("cdefine35");

                entity.Property(e => e.Cdefine36)
                    .HasColumnName("cdefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdefine37)
                    .HasColumnName("cdefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdemandmemo)
                    .HasColumnName("cdemandmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cexpirationdate)
                    .HasColumnName("cexpirationdate")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfactorycode)
                    .HasColumnName("cfactorycode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cfactoryname)
                    .HasColumnName("cfactoryname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cfree1)
                    .HasColumnName("cfree1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree10)
                    .HasColumnName("cfree10")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree2)
                    .HasColumnName("cfree2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree3)
                    .HasColumnName("cfree3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree4)
                    .HasColumnName("cfree4")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree5)
                    .HasColumnName("cfree5")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree6)
                    .HasColumnName("cfree6")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree7)
                    .HasColumnName("cfree7")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree8)
                    .HasColumnName("cfree8")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree9)
                    .HasColumnName("cfree9")
                    .HasMaxLength(20);

                entity.Property(e => e.Cgroupcode)
                    .HasColumnName("cgroupcode")
                    .HasMaxLength(35);

                entity.Property(e => e.Cgspstate)
                    .HasColumnName("cgspstate")
                    .HasMaxLength(20);

                entity.Property(e => e.CinvaUnit)
                    .HasColumnName("cinva_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvaddcode)
                    .HasColumnName("cinvaddcode")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvauthid).HasColumnName("cinvauthid");

                entity.Property(e => e.Cinvccode)
                    .HasColumnName("cinvccode")
                    .HasMaxLength(12);

                entity.Property(e => e.Cinvcode)
                    .IsRequired()
                    .HasColumnName("cinvcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine1)
                    .HasColumnName("cinvdefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine10)
                    .HasColumnName("cinvdefine10")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine11).HasColumnName("cinvdefine11");

                entity.Property(e => e.Cinvdefine12).HasColumnName("cinvdefine12");

                entity.Property(e => e.Cinvdefine13).HasColumnName("cinvdefine13");

                entity.Property(e => e.Cinvdefine14).HasColumnName("cinvdefine14");

                entity.Property(e => e.Cinvdefine15)
                    .HasColumnName("cinvdefine15")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cinvdefine16)
                    .HasColumnName("cinvdefine16")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cinvdefine2)
                    .HasColumnName("cinvdefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine3)
                    .HasColumnName("cinvdefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine4)
                    .HasColumnName("cinvdefine4")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine5)
                    .HasColumnName("cinvdefine5")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine6)
                    .HasColumnName("cinvdefine6")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine7)
                    .HasColumnName("cinvdefine7")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine8)
                    .HasColumnName("cinvdefine8")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine9)
                    .HasColumnName("cinvdefine9")
                    .HasMaxLength(120);

                entity.Property(e => e.CinvmUnit)
                    .HasColumnName("cinvm_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvname)
                    .HasColumnName("cinvname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvstd)
                    .HasColumnName("cinvstd")
                    .HasMaxLength(255);

                entity.Property(e => e.CitemClass)
                    .HasColumnName("citem_class")
                    .HasMaxLength(2);

                entity.Property(e => e.CitemName1)
                    .HasColumnName("citem_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Citemcode)
                    .HasColumnName("citemcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Citemname)
                    .HasColumnName("citemname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cmaininvcode)
                    .HasColumnName("cmaininvcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cmassunit).HasColumnName("cmassunit");

                entity.Property(e => e.Contractcode)
                    .HasColumnName("contractcode")
                    .HasMaxLength(128);

                entity.Property(e => e.Contractrowguid).HasColumnName("contractrowguid");

                entity.Property(e => e.Contractrowno)
                    .HasColumnName("contractrowno")
                    .HasMaxLength(150);

                entity.Property(e => e.Cordercode)
                    .HasColumnName("cordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(50);

                entity.Property(e => e.Csoordercode)
                    .HasColumnName("csoordercode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cunitid)
                    .HasColumnName("cunitid")
                    .HasMaxLength(50);

                entity.Property(e => e.Cupsocode)
                    .HasColumnName("cupsocode")
                    .HasMaxLength(120);

                entity.Property(e => e.Cveninvcode)
                    .HasColumnName("cveninvcode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cveninvname)
                    .HasColumnName("cveninvname")
                    .HasMaxLength(100);

                entity.Property(e => e.Cwhcode)
                    .HasColumnName("cwhcode")
                    .HasMaxLength(10);

                entity.Property(e => e.Cwhname)
                    .HasColumnName("cwhname")
                    .HasMaxLength(20);

                entity.Property(e => e.DValidateDate)
                    .HasColumnName("dValidateDate")
                    .HasMaxLength(7);

                entity.Property(e => e.Dexpirationdate)
                    .HasColumnName("dexpirationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dlineclosedate)
                    .HasColumnName("dlineclosedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dpdate)
                    .HasColumnName("dpdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dvdate)
                    .HasColumnName("dvdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fdtquantity)
                    .HasColumnName("fdtquantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fininnum)
                    .HasColumnName("fininnum")
                    .HasColumnType("decimal(38, 14)");

                entity.Property(e => e.Fininquantity)
                    .HasColumnName("fininquantity")
                    .HasColumnType("decimal(23, 6)");

                entity.Property(e => e.Finspectnum)
                    .HasColumnName("finspectnum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Finspectquantity)
                    .HasColumnName("finspectquantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Finvalidinnum)
                    .HasColumnName("finvalidinnum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Finvalidinquan)
                    .HasColumnName("finvalidinquan")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Finvalidnum)
                    .HasColumnName("finvalidnum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Finvalidquantity)
                    .HasColumnName("finvalidquantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fkpquantity)
                    .HasColumnName("fkpquantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Frealnum)
                    .HasColumnName("frealnum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Frealquantity)
                    .HasColumnName("frealquantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Frefusenum)
                    .HasColumnName("frefusenum")
                    .HasColumnType("decimal(38, 18)");

                entity.Property(e => e.Frefusequantity)
                    .HasColumnName("frefusequantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fretnum)
                    .HasColumnName("fretnum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fretquantity)
                    .HasColumnName("fretquantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Freworknum)
                    .HasColumnName("freworknum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Freworkquantity)
                    .HasColumnName("freworkquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fsumrefusenum)
                    .HasColumnName("fsumrefusenum")
                    .HasColumnType("decimal(38, 18)");

                entity.Property(e => e.Fsumrefusequantity)
                    .HasColumnName("fsumrefusequantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fsumreworknum)
                    .HasColumnName("fsumreworknum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fsumreworkquantity)
                    .HasColumnName("fsumreworkquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fvalidinnum)
                    .HasColumnName("fvalidinnum")
                    .HasColumnType("decimal(38, 16)");

                entity.Property(e => e.Fvalidinquan)
                    .HasColumnName("fvalidinquan")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fvalidnum)
                    .HasColumnName("fvalidnum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fvalidquantity)
                    .HasColumnName("fvalidquantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Icorid).HasColumnName("icorid");

                entity.Property(e => e.Icost)
                    .HasColumnName("icost")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Iexpiratdatecalcu).HasColumnName("iexpiratdatecalcu");

                entity.Property(e => e.Igrouptype).HasColumnName("igrouptype");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(38, 16)");

                entity.Property(e => e.Iinvmpcost)
                    .HasColumnName("iinvmpcost")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Imainmodetailsid).HasColumnName("imainmodetailsid");

                entity.Property(e => e.Imassdate).HasColumnName("imassdate");

                entity.Property(e => e.Imoney)
                    .HasColumnName("imoney")
                    .HasColumnType("money");

                entity.Property(e => e.Inspecexchrate)
                    .HasColumnName("inspecexchrate")
                    .HasColumnType("decimal(38, 16)");

                entity.Property(e => e.Inum)
                    .HasColumnName("inum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype).HasColumnName("iordertype");

                entity.Property(e => e.Ioricost)
                    .HasColumnName("ioricost")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Iorimoney)
                    .HasColumnName("iorimoney")
                    .HasColumnType("money");

                entity.Property(e => e.Iorisum)
                    .HasColumnName("iorisum")
                    .HasColumnType("money");

                entity.Property(e => e.Ioritaxcost)
                    .HasColumnName("ioritaxcost")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Ioritaxprice)
                    .HasColumnName("ioritaxprice")
                    .HasColumnType("money");

                entity.Property(e => e.Iposid).HasColumnName("iposid");

                entity.Property(e => e.Ippartid).HasColumnName("ippartid");

                entity.Property(e => e.Ipquantity)
                    .HasColumnName("ipquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iproducttype).HasColumnName("iproducttype");

                entity.Property(e => e.Iptoseq).HasColumnName("iptoseq");

                entity.Property(e => e.Iquantity)
                    .HasColumnName("iquantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Irejectautoid).HasColumnName("irejectautoid");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isourcemocode)
                    .HasColumnName("isourcemocode")
                    .HasMaxLength(60);

                entity.Property(e => e.Isourcemodetailsid).HasColumnName("isourcemodetailsid");

                entity.Property(e => e.Isum)
                    .HasColumnName("isum")
                    .HasColumnType("money");

                entity.Property(e => e.Itaxprice)
                    .HasColumnName("itaxprice")
                    .HasColumnType("money");

                entity.Property(e => e.Itaxrate)
                    .HasColumnName("itaxrate")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Ivouchrowno).HasColumnName("ivouchrowno");

                entity.Property(e => e.Planlotnumber)
                    .HasColumnName("planlotnumber")
                    .HasMaxLength(40);

                entity.Property(e => e.Rejectsource).HasColumnName("rejectsource");

                entity.Property(e => e.Sodid)
                    .HasColumnName("sodid")
                    .HasMaxLength(50);

                entity.Property(e => e.Sotype).HasColumnName("sotype");

                entity.Property(e => e.Vouchstate).HasColumnName("vouchstate");
            });

            modelBuilder.Entity<PuArrivalVouch>(entity =>
            {
                entity.ToTable("PU_ArrivalVouch");

                entity.HasIndex(e => e.CBusType)
                    .HasName("PK_PU_ArrivalVouch_cBusType");

                entity.HasIndex(e => e.CVenCode)
                    .HasName("PK_PU_ArrivalVouch_cVenCode");

                entity.HasIndex(e => e.Cvouchtype)
                    .HasName("IX_PU_ArrivalVouch_VouchTyep");

                entity.HasIndex(e => new { e.CCode, e.Cvouchtype })
                    .HasName("IX_Code")
                    .IsUnique();

                entity.HasIndex(e => new { e.CCode, e.Cvouchtype, e.Id })
                    .HasName("idx_vouchtypecodeid");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BNegative)
                    .HasColumnName("bNegative")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bcal).HasColumnName("bcal");

                entity.Property(e => e.CAuditDate)
                    .HasColumnName("cAuditDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CBusType)
                    .IsRequired()
                    .HasColumnName("cBusType")
                    .HasMaxLength(8);

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasColumnName("cCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7).HasColumnName("cDefine7");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepCode)
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CMakeTime)
                    .HasColumnName("cMakeTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CMaker)
                    .IsRequired()
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CModifyDate)
                    .HasColumnName("cModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CModifyTime)
                    .HasColumnName("cModifyTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CPayCode)
                    .HasColumnName("cPayCode")
                    .HasMaxLength(3);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CPtcode)
                    .HasColumnName("cPTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CReviser)
                    .HasColumnName("cReviser")
                    .HasMaxLength(40);

                entity.Property(e => e.CSccode)
                    .HasColumnName("cSCCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CVenCode)
                    .IsRequired()
                    .HasColumnName("cVenCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenPuomprotocol)
                    .HasColumnName("cVenPUOMProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.Caportcode)
                    .HasColumnName("caportcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Carrivalplace)
                    .HasColumnName("carrivalplace")
                    .HasMaxLength(100);

                entity.Property(e => e.Caudittime)
                    .HasColumnName("caudittime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cchanger)
                    .HasColumnName("cchanger")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccleanver)
                    .HasColumnName("ccleanver")
                    .HasMaxLength(50);

                entity.Property(e => e.Ccloser)
                    .HasColumnName("ccloser")
                    .HasMaxLength(20);

                entity.Property(e => e.CexchName)
                    .IsRequired()
                    .HasColumnName("cexch_name")
                    .HasMaxLength(8);

                entity.Property(e => e.Cgeneralordercode)
                    .HasColumnName("cgeneralordercode")
                    .HasMaxLength(300);

                entity.Property(e => e.Cincotermcode)
                    .HasColumnName("cincotermcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cpocode)
                    .HasColumnName("cpocode")
                    .HasMaxLength(64);

                entity.Property(e => e.Csportcode)
                    .HasColumnName("csportcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Csvencode)
                    .HasColumnName("csvencode")
                    .HasMaxLength(30);

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Ctmcode)
                    .HasColumnName("ctmcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Ctransordercode)
                    .HasColumnName("ctransordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cverifier)
                    .HasColumnName("cverifier")
                    .HasMaxLength(20);

                entity.Property(e => e.Cvouchtype)
                    .HasColumnName("cvouchtype")
                    .HasMaxLength(10);

                entity.Property(e => e.DDate)
                    .HasColumnName("dDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dclosedate)
                    .HasColumnName("dclosedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dportdate)
                    .HasColumnName("dportdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasMaxLength(50);

                entity.Property(e => e.IBillType)
                    .HasColumnName("iBillType")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IDiscountTaxType)
                    .HasColumnName("iDiscountTaxType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IExchRate).HasColumnName("iExchRate");

                entity.Property(e => e.IPrintCount)
                    .HasColumnName("iPrintCount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ITaxRate)
                    .HasColumnName("iTaxRate")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.IVtid).HasColumnName("iVTid");

                entity.Property(e => e.Idec).HasColumnName("idec");

                entity.Property(e => e.Iflowid).HasColumnName("iflowid");

                entity.Property(e => e.Ireturncount).HasColumnName("ireturncount");

                entity.Property(e => e.IsWfControlled).HasDefaultValueSql("(0)");

                entity.Property(e => e.Iverifystate).HasColumnName("iverifystate");

                entity.Property(e => e.Iverifystateex).HasColumnName("iverifystateex");

                entity.Property(e => e.Ufts)
                    .IsRequired()
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CDepCodeNavigation)
                    .WithMany(p => p.PuArrivalVouch)
                    .HasForeignKey(d => d.CDepCode)
                    .HasConstraintName("PuArrival_Department");

                entity.HasOne(d => d.CPersonCodeNavigation)
                    .WithMany(p => p.PuArrivalVouch)
                    .HasForeignKey(d => d.CPersonCode)
                    .HasConstraintName("PuArrival_Person");

                entity.HasOne(d => d.CVenCodeNavigation)
                    .WithMany(p => p.PuArrivalVouch)
                    .HasForeignKey(d => d.CVenCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PuArrival_Vendor");
            });

            modelBuilder.Entity<PuArrivalVouchs>(entity =>
            {
                entity.HasKey(e => e.Autoid);

                entity.ToTable("PU_ArrivalVouchs");

                entity.HasIndex(e => e.CInvCode)
                    .HasName("PK_PU_ArrivalVouchs_cInvCode");

                entity.HasIndex(e => e.CItemClass)
                    .HasName("PK_PU_ArrivalVouchs_cItem_class");

                entity.HasIndex(e => e.CUnitId)
                    .HasName("PK_PU_ArrivalVouchs_cUnitID");

                entity.HasIndex(e => e.CWhCode)
                    .HasName("PK_PU_ArrivalVouchs_cWhCode");

                entity.HasIndex(e => e.ContractRowGuid)
                    .HasName("PK_PU_ArrivalVouchs_ContractRowGUID");

                entity.HasIndex(e => e.IPosId)
                    .HasName("IX_ArrivalVouches_iPOsID");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_PU_ArrivalVouchs_ID");

                entity.HasIndex(e => e.SoType)
                    .HasName("PK_PU_ArrivalVouchs_SoType");

                entity.HasIndex(e => new { e.ContractCode, e.ContractRowNo })
                    .HasName("IX_PU_ArrivalVouchs_Contract");

                entity.HasIndex(e => new { e.IPosId, e.FValidInQuan, e.FValidInNum })
                    .HasName("idx_pu_arr_rdsave");

                entity.Property(e => e.Autoid).ValueGeneratedNever();

                entity.Property(e => e.AutoidSource).HasColumnName("autoid_source");

                entity.Property(e => e.BGsp)
                    .HasColumnName("bGsp")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BInspect).HasColumnName("bInspect");

                entity.Property(e => e.BTaxCost)
                    .HasColumnName("bTaxCost")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bexigency)
                    .HasColumnName("bexigency")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bgift)
                    .HasColumnName("bgift")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CBatch)
                    .HasColumnName("cBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CBatchProperty1)
                    .HasColumnName("cBatchProperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty10)
                    .HasColumnName("cBatchProperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.CBatchProperty2)
                    .HasColumnName("cBatchProperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty3)
                    .HasColumnName("cBatchProperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty4)
                    .HasColumnName("cBatchProperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty5)
                    .HasColumnName("cBatchProperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty6)
                    .HasColumnName("cBatchProperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty7)
                    .HasColumnName("cBatchProperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty8)
                    .HasColumnName("cBatchProperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty9)
                    .HasColumnName("cBatchProperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.CCloser)
                    .HasColumnName("cCloser")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26).HasColumnName("cDefine26");

                entity.Property(e => e.CDefine27).HasColumnName("cDefine27");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CExpirationdate)
                    .HasColumnName("cExpirationdate")
                    .HasMaxLength(20);

                entity.Property(e => e.CFactoryCode)
                    .HasColumnName("cFactoryCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CGspState)
                    .HasColumnName("cGspState")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvCode)
                    .IsRequired()
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(2);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemName)
                    .HasColumnName("cItemName")
                    .HasMaxLength(255);

                entity.Property(e => e.CMainInvCode)
                    .HasColumnName("cMainInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CUnitId)
                    .HasColumnName("cUnitID")
                    .HasMaxLength(50);

                entity.Property(e => e.CWhCode)
                    .HasColumnName("cWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.Carrivalcode)
                    .HasColumnName("carrivalcode")
                    .HasMaxLength(80);

                entity.Property(e => e.CbMemo)
                    .HasColumnName("cbMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbcloser)
                    .HasColumnName("cbcloser")
                    .HasMaxLength(20);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cciqbookcode)
                    .HasColumnName("cciqbookcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cciqcode)
                    .HasColumnName("cciqcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cmassunit).HasColumnName("cmassunit");

                entity.Property(e => e.ContractCode).HasMaxLength(128);

                entity.Property(e => e.ContractRowGuid).HasColumnName("ContractRowGUID");

                entity.Property(e => e.ContractRowNo).HasMaxLength(150);

                entity.Property(e => e.Cordercode)
                    .HasColumnName("cordercode")
                    .HasMaxLength(50);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(50);

                entity.Property(e => e.Csoordercode)
                    .HasColumnName("csoordercode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cupsocode)
                    .HasColumnName("cupsocode")
                    .HasMaxLength(120);

                entity.Property(e => e.DExpirationdate)
                    .HasColumnName("dExpirationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DPdate)
                    .HasColumnName("dPDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVdate)
                    .HasColumnName("dVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dlineclosedate)
                    .HasColumnName("dlineclosedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FDegradeInNum)
                    .HasColumnName("fDegradeInNum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.FDegradeInQuantity)
                    .HasColumnName("fDegradeInQuantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.FDegradeNum)
                    .HasColumnName("fDegradeNum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.FDegradeQuantity)
                    .HasColumnName("fDegradeQuantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.FDtquantity)
                    .HasColumnName("fDTQuantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.FInValidInQuan)
                    .HasColumnName("fInValidInQuan")
                    .HasColumnType("decimal(20, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FInValidNum)
                    .HasColumnName("fInValidNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FInspectNum)
                    .HasColumnName("fInspectNum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.FInspectQuantity)
                    .HasColumnName("fInspectQuantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.FInvalidInNum)
                    .HasColumnName("fInvalidInNum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.FKpquantity)
                    .HasColumnName("fKPQuantity")
                    .HasColumnType("decimal(20, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FRealNum)
                    .HasColumnName("fRealNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FRealQuantity)
                    .HasColumnName("fRealQuantity")
                    .HasColumnType("decimal(20, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FRefuseNum)
                    .HasColumnName("fRefuseNum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.FRefuseQuantity)
                    .HasColumnName("fRefuseQuantity")
                    .HasColumnType("decimal(20, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FRetNum)
                    .HasColumnName("fRetNum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.FRetQuantity)
                    .HasColumnName("fRetQuantity")
                    .HasColumnType("decimal(20, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FSumRefuseQuantity)
                    .HasColumnName("fSumRefuseQuantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.FValidInNum)
                    .HasColumnName("fValidInNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FValidInQuan)
                    .HasColumnName("fValidInQuan")
                    .HasColumnType("decimal(20, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FValidNum)
                    .HasColumnName("fValidNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FValidQuantity)
                    .HasColumnName("fValidQuantity")
                    .HasColumnType("decimal(20, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Fciqchangrate)
                    .HasColumnName("fciqchangrate")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.FinValidQuantity)
                    .HasColumnName("finValidQuantity")
                    .HasColumnType("decimal(20, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Freworknum)
                    .HasColumnName("freworknum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Freworkquantity)
                    .HasColumnName("freworkquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.FsumRefuseNum)
                    .HasColumnName("FSumRefuseNum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Fsumreworknum)
                    .HasColumnName("fsumreworknum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fsumreworkquantity)
                    .HasColumnName("fsumreworkquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Guids)
                    .HasColumnName("guids")
                    .HasMaxLength(50);

                entity.Property(e => e.ICorId).HasColumnName("iCorId");

                entity.Property(e => e.ICost)
                    .HasColumnName("iCost")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.IExpiratDateCalcu).HasColumnName("iExpiratDateCalcu");

                entity.Property(e => e.IInvMpcost)
                    .HasColumnName("iInvMPCost")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.IMainMoDetailsId).HasColumnName("iMainMoDetailsID");

                entity.Property(e => e.IMoney)
                    .HasColumnName("iMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.IOriCost)
                    .HasColumnName("iOriCost")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.IOriMoney)
                    .HasColumnName("iOriMoney")
                    .HasColumnType("money");

                entity.Property(e => e.IOriSum)
                    .HasColumnName("iOriSum")
                    .HasColumnType("money");

                entity.Property(e => e.IOriTaxCost)
                    .HasColumnName("iOriTaxCost")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.IOriTaxPrice)
                    .HasColumnName("iOriTaxPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IPosId).HasColumnName("iPOsID");

                entity.Property(e => e.IPpartId).HasColumnName("iPPartId");

                entity.Property(e => e.IPquantity)
                    .HasColumnName("iPQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IProductType).HasColumnName("iProductType");

                entity.Property(e => e.IPtoseq).HasColumnName("iPTOSeq");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.ISourceMocode)
                    .HasColumnName("iSourceMOCode")
                    .HasMaxLength(60);

                entity.Property(e => e.ISourceModetailsId).HasColumnName("iSourceMODetailsID");

                entity.Property(e => e.ISum)
                    .HasColumnName("iSum")
                    .HasColumnType("money");

                entity.Property(e => e.ITaxPrice)
                    .HasColumnName("iTaxPrice")
                    .HasColumnType("money");

                entity.Property(e => e.ITaxRate)
                    .HasColumnName("iTaxRate")
                    .HasColumnType("decimal(20, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iciqbookid).HasColumnName("iciqbookid");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(28, 8)");

                entity.Property(e => e.Imassdate).HasColumnName("imassdate");

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderid).HasColumnName("iorderid");

                entity.Property(e => e.Iorderrowno).HasColumnName("iorderrowno");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype).HasColumnName("iordertype");

                entity.Property(e => e.Ipickednum).HasColumnName("ipickednum");

                entity.Property(e => e.Ipickedquantity).HasColumnName("ipickedquantity");

                entity.Property(e => e.Irejectautoid).HasColumnName("irejectautoid");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.IrownoSource).HasColumnName("irowno_source");

                entity.Property(e => e.Isorowno).HasColumnName("isorowno");

                entity.Property(e => e.Ivouchrowno).HasColumnName("ivouchrowno");

                entity.Property(e => e.ObjectidSource)
                    .HasColumnName("objectid_source")
                    .HasMaxLength(30);

                entity.Property(e => e.PlanLotNumber).HasMaxLength(40);

                entity.Property(e => e.RejectSource).HasDefaultValueSql("(0)");

                entity.Property(e => e.SoDid)
                    .HasColumnName("SoDId")
                    .HasMaxLength(50);

                entity.Property(e => e.UftsSource)
                    .HasColumnName("ufts_source")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CWhCodeNavigation)
                    .WithMany(p => p.PuArrivalVouchs)
                    .HasForeignKey(d => d.CWhCode)
                    .HasConstraintName("PuArrivals_warehouse");
            });

            modelBuilder.Entity<RdRecord01>(entity =>
            {
                entity.HasIndex(e => e.CBusCode)
                    .HasName("ix_rdecord01_cbuscode");

                entity.HasIndex(e => e.CCode)
                    .HasName("ix_rdecord01_ccode");

                entity.HasIndex(e => e.CGcrouteCode)
                    .HasName("idx_rdrecord01_RouteCode");

                entity.HasIndex(e => e.CRdCode)
                    .HasName("ix_rdecord01_crdcode");

                entity.HasIndex(e => e.CVenCode)
                    .HasName("ix_RdRecord01_cvencode");

                entity.HasIndex(e => e.CWhCode)
                    .HasName("ix_rdecord01_cwhcode");

                entity.HasIndex(e => new { e.DDate, e.BIsStqc, e.Bpufirst, e.Biafirst, e.BOmfirst, e.CBusType, e.CVouchType, e.Id })
                    .HasName("ix_rdecord01_date");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BCredit).HasColumnName("bCredit");

                entity.Property(e => e.BFromPreYear)
                    .HasColumnName("bFromPreYear")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsComplement)
                    .HasColumnName("bIsComplement")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsLsQuery).HasColumnName("bIsLsQuery");

                entity.Property(e => e.BIsStqc)
                    .IsRequired()
                    .HasColumnName("bIsSTQc")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BOmfirst).HasColumnName("bOMFirst");

                entity.Property(e => e.BRdFlag).HasColumnName("bRdFlag");

                entity.Property(e => e.BTransFlag)
                    .IsRequired()
                    .HasColumnName("bTransFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Biafirst)
                    .HasColumnName("biafirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bpufirst)
                    .HasColumnName("bpufirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bredvouch)
                    .HasColumnName("bredvouch")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CAccounter)
                    .HasColumnName("cAccounter")
                    .HasMaxLength(20);

                entity.Property(e => e.CArvcode)
                    .HasColumnName("cARVCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBillCode).HasColumnName("cBillCode");

                entity.Property(e => e.CBusCode)
                    .HasColumnName("cBusCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBusType)
                    .HasColumnName("cBusType")
                    .HasMaxLength(12);

                entity.Property(e => e.CCheckSignFlag)
                    .HasColumnName("cCheckSignFlag")
                    .HasMaxLength(36);

                entity.Property(e => e.CChkCode)
                    .HasColumnName("cChkCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CChkPerson)
                    .HasColumnName("cChkPerson")
                    .HasMaxLength(40);

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasColumnName("cCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.CCusCode)
                    .HasColumnName("cCusCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7).HasColumnName("cDefine7");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepCode)
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CDlcode).HasColumnName("cDLCode");

                entity.Property(e => e.CExchName)
                    .HasColumnName("cExch_Name")
                    .HasMaxLength(8);

                entity.Property(e => e.CGcrouteCode)
                    .HasColumnName("cGCRouteCode")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CHandler)
                    .HasColumnName("cHandler")
                    .HasMaxLength(20);

                entity.Property(e => e.CMaker)
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CModifyPerson)
                    .HasColumnName("cModifyPerson")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.COrderCode)
                    .HasColumnName("cOrderCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CProBatch)
                    .HasColumnName("cProBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CPtcode)
                    .HasColumnName("cPTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CPzid)
                    .HasColumnName("cPZID")
                    .HasMaxLength(30);

                entity.Property(e => e.CRdCode)
                    .HasColumnName("cRdCode")
                    .HasMaxLength(5);

                entity.Property(e => e.CSource)
                    .IsRequired()
                    .HasColumnName("cSource")
                    .HasMaxLength(50);

                entity.Property(e => e.CSourceCodeLs)
                    .HasColumnName("cSourceCodeLs")
                    .HasMaxLength(20);

                entity.Property(e => e.CSourceLs)
                    .HasColumnName("cSourceLs")
                    .HasMaxLength(4);

                entity.Property(e => e.CStcode)
                    .HasColumnName("cSTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CVenCode)
                    .HasColumnName("cVenCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenPuomprotocol)
                    .HasColumnName("cVenPUOMProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.CVouchType)
                    .IsRequired()
                    .HasColumnName("cVouchType")
                    .HasMaxLength(2);

                entity.Property(e => e.CWhCode)
                    .IsRequired()
                    .HasColumnName("cWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Csyssource)
                    .HasColumnName("csyssource")
                    .HasMaxLength(10);

                entity.Property(e => e.Csyssourceid)
                    .HasColumnName("csyssourceid")
                    .HasMaxLength(50);

                entity.Property(e => e.DArvdate)
                    .HasColumnName("dARVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DChkDate)
                    .HasColumnName("dChkDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DCreditStart)
                    .HasColumnName("dCreditStart")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDate)
                    .HasColumnName("dDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DGatheringDate)
                    .HasColumnName("dGatheringDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DKeepDate)
                    .HasColumnName("dKeepDate")
                    .HasMaxLength(5);

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVeriDate)
                    .HasColumnName("dVeriDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmaketime)
                    .HasColumnName("dnmaketime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmodifytime)
                    .HasColumnName("dnmodifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnverifytime)
                    .HasColumnName("dnverifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gspcheck)
                    .HasColumnName("gspcheck")
                    .HasMaxLength(10);

                entity.Property(e => e.ICreditPeriod).HasColumnName("iCreditPeriod");

                entity.Property(e => e.IDiscountTaxType)
                    .HasColumnName("iDiscountTaxType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IExchRate).HasColumnName("iExchRate");

                entity.Property(e => e.IFlowId).HasColumnName("iFlowId");

                entity.Property(e => e.IMquantity).HasColumnName("iMQuantity");

                entity.Property(e => e.IPrintCount)
                    .HasColumnName("iPrintCount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ITaxRate)
                    .HasColumnName("iTaxRate")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Iarriveid)
                    .HasColumnName("iarriveid")
                    .HasMaxLength(30);

                entity.Property(e => e.Ipurarriveid).HasColumnName("ipurarriveid");

                entity.Property(e => e.Ipurorderid).HasColumnName("ipurorderid");

                entity.Property(e => e.Ireturncount)
                    .HasColumnName("ireturncount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Isalebillid)
                    .HasColumnName("isalebillid")
                    .HasMaxLength(30);

                entity.Property(e => e.Iswfcontrolled)
                    .HasColumnName("iswfcontrolled")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iverifystate)
                    .HasColumnName("iverifystate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.VtId).HasColumnName("VT_ID");
            });

            modelBuilder.Entity<RdRecord08>(entity =>
            {
                entity.HasIndex(e => e.CBusCode)
                    .HasName("ix_rdecord08_cbuscode");

                entity.HasIndex(e => e.CCode)
                    .HasName("ix_rdecord08_ccode");

                entity.HasIndex(e => e.CRdCode)
                    .HasName("ix_rdecord08_crdcode");

                entity.HasIndex(e => e.CVenCode)
                    .HasName("ix_RdRecord08_cvencode");

                entity.HasIndex(e => e.CWhCode)
                    .HasName("ix_rdecord08_cwhcode");

                entity.HasIndex(e => new { e.DDate, e.BIsStqc, e.Bpufirst, e.Biafirst, e.BOmfirst, e.CBusType, e.CVouchType, e.Id })
                    .HasName("ix_rdecord08_date");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BFromPreYear)
                    .HasColumnName("bFromPreYear")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsComplement)
                    .HasColumnName("bIsComplement")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsLsQuery).HasColumnName("bIsLsQuery");

                entity.Property(e => e.BIsStqc)
                    .IsRequired()
                    .HasColumnName("bIsSTQc")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BOmfirst).HasColumnName("bOMFirst");

                entity.Property(e => e.BRdFlag).HasColumnName("bRdFlag");

                entity.Property(e => e.BTransFlag)
                    .IsRequired()
                    .HasColumnName("bTransFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Biafirst)
                    .HasColumnName("biafirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bpufirst)
                    .HasColumnName("bpufirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bredvouch)
                    .HasColumnName("bredvouch")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CAccounter)
                    .HasColumnName("cAccounter")
                    .HasMaxLength(20);

                entity.Property(e => e.CArvcode)
                    .HasColumnName("cARVCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBillCode).HasColumnName("cBillCode");

                entity.Property(e => e.CBusCode)
                    .HasColumnName("cBusCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBusType)
                    .HasColumnName("cBusType")
                    .HasMaxLength(12);

                entity.Property(e => e.CCheckSignFlag)
                    .HasColumnName("cCheckSignFlag")
                    .HasMaxLength(36);

                entity.Property(e => e.CChkCode)
                    .HasColumnName("cChkCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CChkPerson)
                    .HasColumnName("cChkPerson")
                    .HasMaxLength(40);

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasColumnName("cCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.CCusCode)
                    .HasColumnName("cCusCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7).HasColumnName("cDefine7");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepCode)
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CDlcode).HasColumnName("cDLCode");

                entity.Property(e => e.CExchName)
                    .HasColumnName("cExch_Name")
                    .HasMaxLength(8);

                entity.Property(e => e.CHandler)
                    .HasColumnName("cHandler")
                    .HasMaxLength(20);

                entity.Property(e => e.CMaker)
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CModifyPerson)
                    .HasColumnName("cModifyPerson")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.COrderCode)
                    .HasColumnName("cOrderCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CProBatch)
                    .HasColumnName("cProBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CPtcode)
                    .HasColumnName("cPTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CPzid)
                    .HasColumnName("cPZID")
                    .HasMaxLength(30);

                entity.Property(e => e.CRdCode)
                    .HasColumnName("cRdCode")
                    .HasMaxLength(5);

                entity.Property(e => e.CSource)
                    .IsRequired()
                    .HasColumnName("cSource")
                    .HasMaxLength(50);

                entity.Property(e => e.CSourceCodeLs)
                    .HasColumnName("cSourceCodeLs")
                    .HasMaxLength(20);

                entity.Property(e => e.CSourceLs)
                    .HasColumnName("cSourceLs")
                    .HasMaxLength(4);

                entity.Property(e => e.CStcode)
                    .HasColumnName("cSTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CVenCode)
                    .HasColumnName("cVenCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVouchType)
                    .IsRequired()
                    .HasColumnName("cVouchType")
                    .HasMaxLength(2);

                entity.Property(e => e.CWhCode)
                    .IsRequired()
                    .HasColumnName("cWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Csyssource)
                    .HasColumnName("csyssource")
                    .HasMaxLength(10);

                entity.Property(e => e.Csyssourceid)
                    .HasColumnName("csyssourceid")
                    .HasMaxLength(50);

                entity.Property(e => e.Ctransflag)
                    .HasColumnName("ctransflag")
                    .HasMaxLength(2);

                entity.Property(e => e.DArvdate)
                    .HasColumnName("dARVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DChkDate)
                    .HasColumnName("dChkDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDate)
                    .HasColumnName("dDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DKeepDate)
                    .HasColumnName("dKeepDate")
                    .HasMaxLength(5);

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVeriDate)
                    .HasColumnName("dVeriDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmaketime)
                    .HasColumnName("dnmaketime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmodifytime)
                    .HasColumnName("dnmodifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnverifytime)
                    .HasColumnName("dnverifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gspcheck)
                    .HasColumnName("gspcheck")
                    .HasMaxLength(10);

                entity.Property(e => e.IDiscountTaxType)
                    .HasColumnName("iDiscountTaxType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IExchRate).HasColumnName("iExchRate");

                entity.Property(e => e.IFlowId).HasColumnName("iFlowId");

                entity.Property(e => e.IMquantity).HasColumnName("iMQuantity");

                entity.Property(e => e.IPrintCount)
                    .HasColumnName("iPrintCount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ireturncount)
                    .HasColumnName("ireturncount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iswfcontrolled)
                    .HasColumnName("iswfcontrolled")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iverifystate)
                    .HasColumnName("iverifystate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.VtId).HasColumnName("VT_ID");
            });

            modelBuilder.Entity<RdRecord09>(entity =>
            {
                entity.HasIndex(e => e.CBusCode)
                    .HasName("ix_rdecord09_cbuscode");

                entity.HasIndex(e => e.CCode)
                    .HasName("ix_rdecord09_ccode");

                entity.HasIndex(e => e.CRdCode)
                    .HasName("ix_rdecord09_crdcode");

                entity.HasIndex(e => e.CVenCode)
                    .HasName("ix_RdRecord09_cvencode");

                entity.HasIndex(e => e.CWhCode)
                    .HasName("ix_rdecord09_cwhcode");

                entity.HasIndex(e => new { e.DDate, e.BIsStqc, e.Bpufirst, e.Biafirst, e.BOmfirst, e.CBusType, e.CVouchType, e.Id })
                    .HasName("ix_rdecord09_date");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BFromPreYear)
                    .HasColumnName("bFromPreYear")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsComplement)
                    .HasColumnName("bIsComplement")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsLsQuery).HasColumnName("bIsLsQuery");

                entity.Property(e => e.BIsStqc)
                    .IsRequired()
                    .HasColumnName("bIsSTQc")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BOmfirst).HasColumnName("bOMFirst");

                entity.Property(e => e.BRdFlag).HasColumnName("bRdFlag");

                entity.Property(e => e.BTransFlag)
                    .IsRequired()
                    .HasColumnName("bTransFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Biafirst)
                    .HasColumnName("biafirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bpufirst)
                    .HasColumnName("bpufirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bredvouch)
                    .HasColumnName("bredvouch")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CAccounter)
                    .HasColumnName("cAccounter")
                    .HasMaxLength(20);

                entity.Property(e => e.CArvcode)
                    .HasColumnName("cARVCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBgAuditTime)
                    .HasColumnName("cBG_AuditTime")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBgAuditor)
                    .HasColumnName("cBG_Auditor")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CBillCode).HasColumnName("cBillCode");

                entity.Property(e => e.CBusCode)
                    .HasColumnName("cBusCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBusType)
                    .HasColumnName("cBusType")
                    .HasMaxLength(12);

                entity.Property(e => e.CCheckSignFlag)
                    .HasColumnName("cCheckSignFlag")
                    .HasMaxLength(36);

                entity.Property(e => e.CChkCode)
                    .HasColumnName("cChkCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CChkPerson)
                    .HasColumnName("cChkPerson")
                    .HasMaxLength(40);

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasColumnName("cCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.CCusCode)
                    .HasColumnName("cCusCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7).HasColumnName("cDefine7");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepCode)
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CDlcode).HasColumnName("cDLCode");

                entity.Property(e => e.CExchName)
                    .HasColumnName("cExch_Name")
                    .HasMaxLength(8);

                entity.Property(e => e.CHandler)
                    .HasColumnName("cHandler")
                    .HasMaxLength(20);

                entity.Property(e => e.CMaker)
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CModifyPerson)
                    .HasColumnName("cModifyPerson")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.COrderCode)
                    .HasColumnName("cOrderCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CProBatch)
                    .HasColumnName("cProBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CPtcode)
                    .HasColumnName("cPTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CPzid)
                    .HasColumnName("cPZID")
                    .HasMaxLength(30);

                entity.Property(e => e.CRdCode)
                    .HasColumnName("cRdCode")
                    .HasMaxLength(5);

                entity.Property(e => e.CShipAddress)
                    .HasColumnName("cShipAddress")
                    .HasMaxLength(200);

                entity.Property(e => e.CSource)
                    .IsRequired()
                    .HasColumnName("cSource")
                    .HasMaxLength(50);

                entity.Property(e => e.CSourceCodeLs)
                    .HasColumnName("cSourceCodeLs")
                    .HasMaxLength(20);

                entity.Property(e => e.CSourceLs)
                    .HasColumnName("cSourceLs")
                    .HasMaxLength(4);

                entity.Property(e => e.CStcode)
                    .HasColumnName("cSTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CVenCode)
                    .HasColumnName("cVenCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVouchType)
                    .IsRequired()
                    .HasColumnName("cVouchType")
                    .HasMaxLength(2);

                entity.Property(e => e.CWhCode)
                    .IsRequired()
                    .HasColumnName("cWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.Caddcode)
                    .HasColumnName("caddcode")
                    .HasMaxLength(60);

                entity.Property(e => e.ControlResult).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Csyssource)
                    .HasColumnName("csyssource")
                    .HasMaxLength(10);

                entity.Property(e => e.Csyssourceid)
                    .HasColumnName("csyssourceid")
                    .HasMaxLength(50);

                entity.Property(e => e.Ctransflag)
                    .HasColumnName("ctransflag")
                    .HasMaxLength(2);

                entity.Property(e => e.DArvdate)
                    .HasColumnName("dARVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DChkDate)
                    .HasColumnName("dChkDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDate)
                    .HasColumnName("dDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DKeepDate)
                    .HasColumnName("dKeepDate")
                    .HasMaxLength(5);

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVeriDate)
                    .HasColumnName("dVeriDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmaketime)
                    .HasColumnName("dnmaketime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmodifytime)
                    .HasColumnName("dnmodifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnverifytime)
                    .HasColumnName("dnverifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gspcheck)
                    .HasColumnName("gspcheck")
                    .HasMaxLength(10);

                entity.Property(e => e.IBgOverFlag)
                    .HasColumnName("iBG_OverFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IDiscountTaxType)
                    .HasColumnName("iDiscountTaxType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IExchRate).HasColumnName("iExchRate");

                entity.Property(e => e.IFlowId).HasColumnName("iFlowId");

                entity.Property(e => e.IMquantity).HasColumnName("iMQuantity");

                entity.Property(e => e.IPrintCount)
                    .HasColumnName("iPrintCount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ireturncount)
                    .HasColumnName("ireturncount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iswfcontrolled)
                    .HasColumnName("iswfcontrolled")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iverifystate)
                    .HasColumnName("iverifystate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.VtId).HasColumnName("VT_ID");
            });

            modelBuilder.Entity<Rdrecord11>(entity =>
            {
                entity.ToTable("rdrecord11");

                entity.HasIndex(e => e.CBusCode)
                    .HasName("ix_rdecord11_cbuscode");

                entity.HasIndex(e => e.CCode)
                    .HasName("ix_rdecord11_ccode");

                entity.HasIndex(e => e.CRdCode)
                    .HasName("ix_rdecord11_crdcode");

                entity.HasIndex(e => e.CVenCode)
                    .HasName("aa_indexrdrecord11_CVenCode");

                entity.HasIndex(e => e.CWhCode)
                    .HasName("ix_rdecord11_cwhcode");

                entity.HasIndex(e => new { e.DDate, e.BIsStqc, e.Bpufirst, e.Biafirst, e.BOmfirst, e.CBusType, e.CVouchType, e.Id, e.BIsComplement })
                    .HasName("ix_rdecord11_date");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BFromPreYear)
                    .HasColumnName("bFromPreYear")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BHyvouch).HasColumnName("bHYVouch");

                entity.Property(e => e.BIsComplement)
                    .HasColumnName("bIsComplement")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsLsQuery).HasColumnName("bIsLsQuery");

                entity.Property(e => e.BIsStqc)
                    .IsRequired()
                    .HasColumnName("bIsSTQc")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BOmfirst).HasColumnName("bOMFirst");

                entity.Property(e => e.BRdFlag).HasColumnName("bRdFlag");

                entity.Property(e => e.BTransFlag)
                    .IsRequired()
                    .HasColumnName("bTransFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Biafirst)
                    .HasColumnName("biafirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bmotran).HasColumnName("bmotran");

                entity.Property(e => e.Bpufirst)
                    .HasColumnName("bpufirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bredvouch)
                    .HasColumnName("bredvouch")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CAccounter)
                    .HasColumnName("cAccounter")
                    .HasMaxLength(20);

                entity.Property(e => e.CArvcode)
                    .HasColumnName("cARVCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBillCode).HasColumnName("cBillCode");

                entity.Property(e => e.CBusCode)
                    .HasColumnName("cBusCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBusType)
                    .HasColumnName("cBusType")
                    .HasMaxLength(12);

                entity.Property(e => e.CCheckSignFlag)
                    .HasColumnName("cCheckSignFlag")
                    .HasMaxLength(36);

                entity.Property(e => e.CChkCode)
                    .HasColumnName("cChkCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CChkPerson)
                    .HasColumnName("cChkPerson")
                    .HasMaxLength(40);

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasColumnName("cCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.CCusCode)
                    .HasColumnName("cCusCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7).HasColumnName("cDefine7");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepCode)
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CDlcode).HasColumnName("cDLCode");

                entity.Property(e => e.CExchName)
                    .HasColumnName("cExch_Name")
                    .HasMaxLength(8);

                entity.Property(e => e.CHandler)
                    .HasColumnName("cHandler")
                    .HasMaxLength(20);

                entity.Property(e => e.CMaker)
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CModifyPerson)
                    .HasColumnName("cModifyPerson")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CMpoCode)
                    .HasColumnName("cMPoCode")
                    .HasMaxLength(30);

                entity.Property(e => e.COrderCode)
                    .HasColumnName("cOrderCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CProBatch)
                    .HasColumnName("cProBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CPsPcode)
                    .HasColumnName("cPsPcode")
                    .HasMaxLength(60);

                entity.Property(e => e.CPtcode)
                    .HasColumnName("cPTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CPzid)
                    .HasColumnName("cPZID")
                    .HasMaxLength(30);

                entity.Property(e => e.CRdCode)
                    .HasColumnName("cRdCode")
                    .HasMaxLength(5);

                entity.Property(e => e.CSource)
                    .IsRequired()
                    .HasColumnName("cSource")
                    .HasMaxLength(50);

                entity.Property(e => e.CSourceCodeLs)
                    .HasColumnName("cSourceCodeLs")
                    .HasMaxLength(20);

                entity.Property(e => e.CSourceLs)
                    .HasColumnName("cSourceLs")
                    .HasMaxLength(4);

                entity.Property(e => e.CStcode)
                    .HasColumnName("cSTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CVenCode)
                    .HasColumnName("cVenCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVouchType)
                    .IsRequired()
                    .HasColumnName("cVouchType")
                    .HasMaxLength(2);

                entity.Property(e => e.CWhCode)
                    .IsRequired()
                    .HasColumnName("cWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.DArvdate)
                    .HasColumnName("dARVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DChkDate)
                    .HasColumnName("dChkDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDate)
                    .HasColumnName("dDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DKeepDate)
                    .HasColumnName("dKeepDate")
                    .HasMaxLength(5);

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVeriDate)
                    .HasColumnName("dVeriDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmaketime)
                    .HasColumnName("dnmaketime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmodifytime)
                    .HasColumnName("dnmodifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnverifytime)
                    .HasColumnName("dnverifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gspcheck)
                    .HasColumnName("gspcheck")
                    .HasMaxLength(10);

                entity.Property(e => e.IDiscountTaxType)
                    .HasColumnName("iDiscountTaxType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IExchRate).HasColumnName("iExchRate");

                entity.Property(e => e.IFlowId).HasColumnName("iFlowId");

                entity.Property(e => e.IMquantity).HasColumnName("iMQuantity");

                entity.Property(e => e.IPrintCount)
                    .HasColumnName("iPrintCount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iproorderid).HasColumnName("iproorderid");

                entity.Property(e => e.Ipurorderid).HasColumnName("ipurorderid");

                entity.Property(e => e.Ireturncount)
                    .HasColumnName("ireturncount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iswfcontrolled)
                    .HasColumnName("iswfcontrolled")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iverifystate)
                    .HasColumnName("iverifystate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.VtId).HasColumnName("VT_ID");
            });

            modelBuilder.Entity<Rdrecord32>(entity =>
            {
                entity.ToTable("rdrecord32");

                entity.HasIndex(e => e.CBusCode)
                    .HasName("ix_rdecord32_cbuscode");

                entity.HasIndex(e => e.CCode)
                    .HasName("ix_rdecord32_ccode");

                entity.HasIndex(e => e.CDlcode)
                    .HasName("idx_rdrecord32_cdlcode");

                entity.HasIndex(e => e.CEbexpressCode)
                    .HasName("idx_rdrecord32_cebexpresscode");

                entity.HasIndex(e => e.CGcrouteCode)
                    .HasName("idx_rdrecord32_RouteCode");

                entity.HasIndex(e => e.CHandler)
                    .HasName("idx_rdrecord32_cHandler");

                entity.HasIndex(e => e.CRdCode)
                    .HasName("ix_rdecord32_crdcode");

                entity.HasIndex(e => e.CSource)
                    .HasName("idx_rdrecord32_cSource");

                entity.HasIndex(e => e.CVenCode)
                    .HasName("ix_RdRecord32_cvencode");

                entity.HasIndex(e => e.CWhCode)
                    .HasName("ix_rdecord32_cwhcode");

                entity.HasIndex(e => e.Cinspector)
                    .HasName("idx_rdrecord32_cinspector");

                entity.HasIndex(e => new { e.DDate, e.BIsStqc, e.Bpufirst, e.Biafirst, e.BOmfirst, e.CBusType, e.CVouchType, e.Id })
                    .HasName("ix_rdecord32_date");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BFromPreYear)
                    .HasColumnName("bFromPreYear")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsComplement)
                    .HasColumnName("bIsComplement")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsLsQuery).HasColumnName("bIsLsQuery");

                entity.Property(e => e.BIsStqc)
                    .IsRequired()
                    .HasColumnName("bIsSTQc")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BOmfirst).HasColumnName("bOMFirst");

                entity.Property(e => e.BRdFlag).HasColumnName("bRdFlag");

                entity.Property(e => e.BScanExpress).HasColumnName("bScanExpress");

                entity.Property(e => e.BTransFlag)
                    .IsRequired()
                    .HasColumnName("bTransFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BUpLoaded).HasColumnName("bUpLoaded");

                entity.Property(e => e.Biafirst)
                    .HasColumnName("biafirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bpufirst)
                    .HasColumnName("bpufirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bredvouch)
                    .HasColumnName("bredvouch")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CAccounter)
                    .HasColumnName("cAccounter")
                    .HasMaxLength(20);

                entity.Property(e => e.CArvcode)
                    .HasColumnName("cARVCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBillCode).HasColumnName("cBillCode");

                entity.Property(e => e.CBusCode)
                    .HasColumnName("cBusCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBusType)
                    .HasColumnName("cBusType")
                    .HasMaxLength(12);

                entity.Property(e => e.CCheckSignFlag)
                    .HasColumnName("cCheckSignFlag")
                    .HasMaxLength(36);

                entity.Property(e => e.CChkCode)
                    .HasColumnName("cChkCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CChkPerson)
                    .HasColumnName("cChkPerson")
                    .HasMaxLength(40);

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasColumnName("cCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.CCusCode)
                    .HasColumnName("cCusCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7).HasColumnName("cDefine7");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepCode)
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CDlcode).HasColumnName("cDLCode");

                entity.Property(e => e.CEbexpressCode)
                    .HasColumnName("cEBExpressCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CEbweightUnit)
                    .HasColumnName("cEBweightUnit")
                    .HasMaxLength(50);

                entity.Property(e => e.CExchName)
                    .HasColumnName("cExch_Name")
                    .HasMaxLength(8);

                entity.Property(e => e.CGcrouteCode)
                    .HasColumnName("cGCRouteCode")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CHandler)
                    .HasColumnName("cHandler")
                    .HasMaxLength(20);

                entity.Property(e => e.CMaker)
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CModifyPerson)
                    .HasColumnName("cModifyPerson")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.COrderCode)
                    .HasColumnName("cOrderCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CProBatch)
                    .HasColumnName("cProBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CPtcode)
                    .HasColumnName("cPTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CPzid)
                    .HasColumnName("cPZID")
                    .HasMaxLength(30);

                entity.Property(e => e.CRdCode)
                    .HasColumnName("cRdCode")
                    .HasMaxLength(5);

                entity.Property(e => e.CShipAddress)
                    .HasColumnName("cShipAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CSource)
                    .IsRequired()
                    .HasColumnName("cSource")
                    .HasMaxLength(50);

                entity.Property(e => e.CSourceCodeLs)
                    .HasColumnName("cSourceCodeLs")
                    .HasMaxLength(20);

                entity.Property(e => e.CSourceLs)
                    .HasColumnName("cSourceLs")
                    .HasMaxLength(4);

                entity.Property(e => e.CStcode)
                    .HasColumnName("cSTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CVenCode)
                    .HasColumnName("cVenCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVouchType)
                    .IsRequired()
                    .HasColumnName("cVouchType")
                    .HasMaxLength(2);

                entity.Property(e => e.CWhCode)
                    .IsRequired()
                    .HasColumnName("cWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.Caddcode)
                    .HasColumnName("caddcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinspector)
                    .HasColumnName("cinspector")
                    .HasMaxLength(40);

                entity.Property(e => e.Cinvoicecompany)
                    .HasColumnName("cinvoicecompany")
                    .HasMaxLength(20);

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cweighter)
                    .HasColumnName("cweighter")
                    .HasMaxLength(40);

                entity.Property(e => e.DArvdate)
                    .HasColumnName("dARVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DChkDate)
                    .HasColumnName("dChkDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDate)
                    .HasColumnName("dDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DKeepDate)
                    .HasColumnName("dKeepDate")
                    .HasMaxLength(5);

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVeriDate)
                    .HasColumnName("dVeriDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dinspecttime)
                    .HasColumnName("dinspecttime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmaketime)
                    .HasColumnName("dnmaketime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmodifytime)
                    .HasColumnName("dnmodifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnverifytime)
                    .HasColumnName("dnverifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dweighttime)
                    .HasColumnName("dweighttime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FEbweight)
                    .HasColumnName("fEBweight")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Gspcheck)
                    .HasColumnName("gspcheck")
                    .HasMaxLength(10);

                entity.Property(e => e.IDiscountTaxType)
                    .HasColumnName("iDiscountTaxType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IExchRate).HasColumnName("iExchRate");

                entity.Property(e => e.IFlowId).HasColumnName("iFlowId");

                entity.Property(e => e.IMquantity).HasColumnName("iMQuantity");

                entity.Property(e => e.IPrintCount)
                    .HasColumnName("iPrintCount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ireturncount)
                    .HasColumnName("ireturncount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IsMddispatch).HasColumnName("isMDdispatch");

                entity.Property(e => e.Isalebillid)
                    .HasColumnName("isalebillid")
                    .HasMaxLength(30);

                entity.Property(e => e.Iswfcontrolled)
                    .HasColumnName("iswfcontrolled")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iverifystate)
                    .HasColumnName("iverifystate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Outid).HasColumnName("outid");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.VtId).HasColumnName("VT_ID");
            });

            modelBuilder.Entity<Rdrecord34>(entity =>
            {
                entity.ToTable("rdrecord34");

                entity.HasIndex(e => e.CBusCode)
                    .HasName("ix_rdecord34_cbuscode");

                entity.HasIndex(e => e.CCode)
                    .HasName("ix_rdecord34_ccode");

                entity.HasIndex(e => e.CRdCode)
                    .HasName("ix_rdecord34_crdcode");

                entity.HasIndex(e => e.CVenCode)
                    .HasName("ix_RdRecord34_cvencode");

                entity.HasIndex(e => e.CWhCode)
                    .HasName("ix_rdecord34_cwhcode");

                entity.HasIndex(e => new { e.DDate, e.BIsStqc, e.Bpufirst, e.Biafirst, e.BOmfirst, e.CBusType, e.CVouchType, e.Id })
                    .HasName("ix_rdecord34_date");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BFromPreYear)
                    .HasColumnName("bFromPreYear")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsComplement)
                    .HasColumnName("bIsComplement")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsLsQuery).HasColumnName("bIsLsQuery");

                entity.Property(e => e.BIsStqc)
                    .IsRequired()
                    .HasColumnName("bIsSTQc")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BOmfirst).HasColumnName("bOMFirst");

                entity.Property(e => e.BRdFlag).HasColumnName("bRdFlag");

                entity.Property(e => e.BTransFlag)
                    .IsRequired()
                    .HasColumnName("bTransFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Biafirst)
                    .HasColumnName("biafirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bpufirst)
                    .HasColumnName("bpufirst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bredvouch)
                    .HasColumnName("bredvouch")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CAccounter)
                    .HasColumnName("cAccounter")
                    .HasMaxLength(20);

                entity.Property(e => e.CArvcode)
                    .HasColumnName("cARVCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBillCode).HasColumnName("cBillCode");

                entity.Property(e => e.CBusCode)
                    .HasColumnName("cBusCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBusType)
                    .HasColumnName("cBusType")
                    .HasMaxLength(12);

                entity.Property(e => e.CChkCode)
                    .HasColumnName("cChkCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CChkPerson)
                    .HasColumnName("cChkPerson")
                    .HasMaxLength(40);

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasColumnName("cCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCusCode)
                    .HasColumnName("cCusCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7).HasColumnName("cDefine7");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepCode)
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CDlcode).HasColumnName("cDLCode");

                entity.Property(e => e.CExchName)
                    .HasColumnName("cExch_Name")
                    .HasMaxLength(8);

                entity.Property(e => e.CHandler)
                    .HasColumnName("cHandler")
                    .HasMaxLength(20);

                entity.Property(e => e.CMaker)
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CModifyPerson)
                    .HasColumnName("cModifyPerson")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.COrderCode)
                    .HasColumnName("cOrderCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CProBatch)
                    .HasColumnName("cProBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CPtcode)
                    .HasColumnName("cPTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CPzid)
                    .HasColumnName("cPZID")
                    .HasMaxLength(30);

                entity.Property(e => e.CRdCode)
                    .HasColumnName("cRdCode")
                    .HasMaxLength(5);

                entity.Property(e => e.CSource)
                    .IsRequired()
                    .HasColumnName("cSource")
                    .HasMaxLength(50);

                entity.Property(e => e.CSourceCodeLs)
                    .HasColumnName("cSourceCodeLs")
                    .HasMaxLength(20);

                entity.Property(e => e.CSourceLs)
                    .HasColumnName("cSourceLs")
                    .HasMaxLength(4);

                entity.Property(e => e.CStcode)
                    .HasColumnName("cSTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CVenCode)
                    .HasColumnName("cVenCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVouchType)
                    .IsRequired()
                    .HasColumnName("cVouchType")
                    .HasMaxLength(2);

                entity.Property(e => e.CWhCode)
                    .IsRequired()
                    .HasColumnName("cWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.DArvdate)
                    .HasColumnName("dARVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DChkDate)
                    .HasColumnName("dChkDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDate)
                    .HasColumnName("dDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DKeepDate)
                    .HasColumnName("dKeepDate")
                    .HasMaxLength(5);

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVeriDate)
                    .HasColumnName("dVeriDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmaketime)
                    .HasColumnName("dnmaketime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmodifytime)
                    .HasColumnName("dnmodifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnverifytime)
                    .HasColumnName("dnverifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gspcheck)
                    .HasColumnName("gspcheck")
                    .HasMaxLength(10);

                entity.Property(e => e.IDiscountTaxType)
                    .HasColumnName("iDiscountTaxType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IExchRate).HasColumnName("iExchRate");

                entity.Property(e => e.IFlowId).HasColumnName("iFlowId");

                entity.Property(e => e.IMquantity).HasColumnName("iMQuantity");

                entity.Property(e => e.Ireturncount)
                    .HasColumnName("ireturncount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iswfcontrolled)
                    .HasColumnName("iswfcontrolled")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iverifystate)
                    .HasColumnName("iverifystate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.VtId).HasColumnName("VT_ID");
            });

            modelBuilder.Entity<Rdrecords01>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaaRdRecords01_PK");

                entity.ToTable("rdrecords01");

                entity.HasIndex(e => e.CBarCode)
                    .HasName("ix_RdRecords01_cbarcode");

                entity.HasIndex(e => e.CBvencode)
                    .HasName("ix_RdRecords01_cbvencode");

                entity.HasIndex(e => e.Cbaccounter)
                    .HasName("IX_Rdrecords01_cBaccounter_IA");

                entity.HasIndex(e => e.IArrsId)
                    .HasName("ix_rdecords01_iArrsId");

                entity.HasIndex(e => e.IImbsid)
                    .HasName("ix_rdecords01_iIMBSID");

                entity.HasIndex(e => e.IImosid)
                    .HasName("ix_rdecords01_iIMOSID");

                entity.HasIndex(e => e.IOmoDid)
                    .HasName("ix_rdecords01_iOMoDID");

                entity.HasIndex(e => e.IPosId)
                    .HasName("ix_rdecords01_iposid");

                entity.HasIndex(e => new { e.CInvCode, e.AutoId })
                    .HasName("ix_rdecords01_cinvcode");

                entity.HasIndex(e => new { e.GcsourceId, e.GcsourceIds })
                    .HasName("idx_rdrecords01_GCSourceIds");

                entity.HasIndex(e => new { e.GcupId, e.GcupIds })
                    .HasName("idx_rdrecords01_GCUpIds");

                entity.HasIndex(e => new { e.StrContractId, e.StrCode })
                    .HasName("ix_rdecords01_strContractId_strCode");

                entity.HasIndex(e => new { e.CVouchCode, e.Cinvouchtype, e.AutoId })
                    .HasName("ix_rdecords01_trackid");

                entity.HasIndex(e => new { e.Id, e.AutoId, e.CInvCode })
                    .HasName("ix_rdecords01_id");

                entity.Property(e => e.AutoId)
                    .HasColumnName("AutoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BChecked).HasColumnName("bChecked");

                entity.Property(e => e.BCosting).HasColumnName("bCosting");

                entity.Property(e => e.BGsp).HasColumnName("bGsp");

                entity.Property(e => e.BLpuseFree)
                    .HasColumnName("bLPUseFree")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BRelated).HasColumnName("bRelated");

                entity.Property(e => e.BTaxCost).HasColumnName("bTaxCost");

                entity.Property(e => e.BVmiused)
                    .HasColumnName("bVMIUsed")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bgift)
                    .HasColumnName("bgift")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bmergecheck).HasColumnName("bmergecheck");

                entity.Property(e => e.Bnoitemused).HasColumnName("bnoitemused");

                entity.Property(e => e.CAssUnit)
                    .HasColumnName("cAssUnit")
                    .HasMaxLength(35);

                entity.Property(e => e.CBarCode)
                    .HasColumnName("cBarCode")
                    .HasMaxLength(200);

                entity.Property(e => e.CBatch)
                    .HasColumnName("cBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CBatchProperty1)
                    .HasColumnName("cBatchProperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty10)
                    .HasColumnName("cBatchProperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.CBatchProperty2)
                    .HasColumnName("cBatchProperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty3)
                    .HasColumnName("cBatchProperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty4)
                    .HasColumnName("cBatchProperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty5)
                    .HasColumnName("cBatchProperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty6)
                    .HasColumnName("cBatchProperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty7)
                    .HasColumnName("cBatchProperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty8)
                    .HasColumnName("cBatchProperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty9)
                    .HasColumnName("cBatchProperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.CBvencode)
                    .HasColumnName("cBVencode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCheckCode)
                    .HasColumnName("cCheckCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCheckPersonCode)
                    .HasColumnName("cCheckPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26).HasColumnName("cDefine26");

                entity.Property(e => e.CDefine27).HasColumnName("cDefine27");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CExpirationdate)
                    .HasColumnName("cExpirationdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CGspState)
                    .HasColumnName("cGspState")
                    .HasMaxLength(20);

                entity.Property(e => e.CInVouchCode)
                    .HasColumnName("cInVouchCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CInvCode)
                    .IsRequired()
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CItemCname)
                    .HasColumnName("cItemCName")
                    .HasMaxLength(20);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CMainInvCode)
                    .HasColumnName("cMainInvCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CMassUnit).HasColumnName("cMassUnit");

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(255);

                entity.Property(e => e.CPoid)
                    .HasColumnName("cPOID")
                    .HasMaxLength(30);

                entity.Property(e => e.CPosition)
                    .HasColumnName("cPosition")
                    .HasMaxLength(20);

                entity.Property(e => e.CRejectCode)
                    .HasColumnName("cRejectCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CReworkMocode)
                    .HasColumnName("cReworkMOCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CVouchCode).HasColumnName("cVouchCode");

                entity.Property(e => e.CbMemo)
                    .HasColumnName("cbMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbaccounter)
                    .HasColumnName("cbaccounter")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Cbarvcode)
                    .HasColumnName("cbarvcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cciqbookcode)
                    .HasColumnName("cciqbookcode")
                    .HasMaxLength(20);

                entity.Property(e => e.ChVencode)
                    .HasColumnName("chVencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvouchtype)
                    .HasColumnName("cinvouchtype")
                    .HasMaxLength(2);

                entity.Property(e => e.Comcode)
                    .HasColumnName("comcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Coritracktype)
                    .HasColumnName("coritracktype")
                    .HasMaxLength(2);

                entity.Property(e => e.Corufts)
                    .HasColumnName("corufts")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cplanlotcode)
                    .HasColumnName("cplanlotcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Csyssourceautoid)
                    .HasColumnName("csyssourceautoid")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvmivencode)
                    .HasColumnName("cvmivencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cwhpersoncode)
                    .HasColumnName("cwhpersoncode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cwhpersonname)
                    .HasColumnName("cwhpersonname")
                    .HasMaxLength(50);

                entity.Property(e => e.DCheckDate)
                    .HasColumnName("dCheckDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DExpirationdate)
                    .HasColumnName("dExpirationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DMadeDate)
                    .HasColumnName("dMadeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DMsdate)
                    .HasColumnName("dMSDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DSdate)
                    .HasColumnName("dSDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVdate)
                    .HasColumnName("dVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DbKeepDate)
                    .HasColumnName("dbKeepDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dbarvdate)
                    .HasColumnName("dbarvdate")
                    .HasMaxLength(30);

                entity.Property(e => e.FAcost)
                    .HasColumnName("fACost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.FOldQuantity)
                    .HasColumnName("fOldQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.GcsourceId).HasColumnName("GCSourceId");

                entity.Property(e => e.GcsourceIds).HasColumnName("GCSourceIds");

                entity.Property(e => e.GcupCardNum)
                    .HasColumnName("GCUpCardNum")
                    .HasMaxLength(100);

                entity.Property(e => e.GcupId).HasColumnName("GCUpId");

                entity.Property(e => e.GcupIds).HasColumnName("GCUpIds");

                entity.Property(e => e.IAprice)
                    .HasColumnName("iAPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IArrsId).HasColumnName("iArrsId");

                entity.Property(e => e.IBillSettleCount)
                    .HasColumnName("iBillSettleCount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IBondedSumQty)
                    .HasColumnName("iBondedSumQty")
                    .HasColumnType("decimal(34, 8)");

                entity.Property(e => e.ICheckIdBaks).HasColumnName("iCheckIdBaks");

                entity.Property(e => e.ICheckIds).HasColumnName("iCheckIds");

                entity.Property(e => e.IDebitIds).HasColumnName("iDebitIDs");

                entity.Property(e => e.IExpiratDateCalcu).HasColumnName("iExpiratDateCalcu");

                entity.Property(e => e.IFaQty)
                    .HasColumnName("iFaQty")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.IFlag)
                    .HasColumnName("iFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IFnum)
                    .HasColumnName("iFNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IFquantity)
                    .HasColumnName("iFQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IImbsid).HasColumnName("iIMBSID");

                entity.Property(e => e.IImosid).HasColumnName("iIMOSID");

                entity.Property(e => e.IInvSncount).HasColumnName("iInvSNCount");

                entity.Property(e => e.IMainMoDetailsId).HasColumnName("iMainMoDetailsID");

                entity.Property(e => e.IMassDate).HasColumnName("iMassDate");

                entity.Property(e => e.IMatSettleState)
                    .HasColumnName("iMatSettleState")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IMaterialFee)
                    .HasColumnName("iMaterialFee")
                    .HasColumnType("money");

                entity.Property(e => e.IMergeCheckAutoId).HasColumnName("iMergeCheckAutoId");

                entity.Property(e => e.IMoney)
                    .HasColumnName("iMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INnum)
                    .HasColumnName("iNNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INquantity)
                    .HasColumnName("iNQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IOldPartId).HasColumnName("iOldPartId");

                entity.Property(e => e.IOmoDid).HasColumnName("iOMoDID");

                entity.Property(e => e.IOmoMid).HasColumnName("iOMoMID");

                entity.Property(e => e.IOriCost)
                    .HasColumnName("iOriCost")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.IOriMoney)
                    .HasColumnName("iOriMoney")
                    .HasColumnType("money");

                entity.Property(e => e.IOriTaxCost)
                    .HasColumnName("iOriTaxCost")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.IOriTaxPrice)
                    .HasColumnName("iOriTaxPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IOriTrackId)
                    .HasColumnName("iOriTrackID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IPosId).HasColumnName("iPOsID");

                entity.Property(e => e.IPprice)
                    .HasColumnName("iPPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IPrice)
                    .HasColumnName("iPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IProcessCost)
                    .HasColumnName("iProcessCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IProcessFee)
                    .HasColumnName("iProcessFee")
                    .HasColumnType("money");

                entity.Property(e => e.IProductType).HasColumnName("iProductType");

                entity.Property(e => e.IPunitCost)
                    .HasColumnName("iPUnitCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IRejectIds).HasColumnName("iRejectIds");

                entity.Property(e => e.IReworkModetailsid).HasColumnName("iReworkMODetailsid");

                entity.Property(e => e.IShareMaterialFee)
                    .HasColumnName("iShareMaterialFee")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.ISmaterialFee)
                    .HasColumnName("iSMaterialFee")
                    .HasColumnType("money");

                entity.Property(e => e.ISnum)
                    .HasColumnName("iSNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISoutNum)
                    .HasColumnName("iSOutNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISoutQuantity)
                    .HasColumnName("iSOutQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISprocessFee)
                    .HasColumnName("iSProcessFee")
                    .HasColumnType("money");

                entity.Property(e => e.ISquantity)
                    .HasColumnName("iSQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISum)
                    .HasColumnName("iSum")
                    .HasColumnType("money");

                entity.Property(e => e.ISumBillQuantity)
                    .HasColumnName("iSumBillQuantity")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ITax)
                    .HasColumnName("iTax")
                    .HasColumnType("money");

                entity.Property(e => e.ITaxPrice)
                    .HasColumnName("iTaxPrice")
                    .HasColumnType("money");

                entity.Property(e => e.ITaxRate)
                    .HasColumnName("iTaxRate")
                    .HasColumnType("decimal(20, 6)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IUnitCost)
                    .HasColumnName("iUnitCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IVmisettleNum)
                    .HasColumnName("iVMISettleNum")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IVmisettleQuantity)
                    .HasColumnName("iVMISettleQuantity")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Impcost)
                    .HasColumnName("impcost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Iordercode)
                    .HasColumnName("iordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype)
                    .HasColumnName("iordertype")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IoriSum)
                    .HasColumnName("ioriSum")
                    .HasColumnType("money");

                entity.Property(e => e.Iposflag)
                    .HasColumnName("iposflag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ipreuseinum)
                    .HasColumnName("ipreuseinum")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Ipreuseqty)
                    .HasColumnName("ipreuseqty")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.IsTax)
                    .HasColumnName("isTax")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Isodid)
                    .HasColumnName("isodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Isoseq).HasColumnName("isoseq");

                entity.Property(e => e.Isotype).HasColumnName("isotype");

                entity.Property(e => e.OutCopiedQuantity).HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rowufts)
                    .HasColumnName("rowufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StrCode)
                    .HasColumnName("strCode")
                    .HasMaxLength(150);

                entity.Property(e => e.StrContractGuid).HasColumnName("strContractGUID");

                entity.Property(e => e.StrContractId)
                    .HasColumnName("strContractId")
                    .HasMaxLength(64);

                entity.Property(e => e.Strowguid).HasColumnName("strowguid");
            });

            modelBuilder.Entity<Rdrecords08>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaaRdRecords08_PK");

                entity.ToTable("rdrecords08");

                entity.HasIndex(e => e.CBarCode)
                    .HasName("ix_RdRecords08_cbarcode");

                entity.HasIndex(e => e.CBvencode)
                    .HasName("ix_RdRecords08_cbvencode");

                entity.HasIndex(e => e.Cbaccounter)
                    .HasName("IX_Rdrecords08_cBaccounter_IA");

                entity.HasIndex(e => e.Cserviceoid)
                    .HasName("ix_rdrecords08_cserviceoid");

                entity.HasIndex(e => e.ICrmVouchids)
                    .HasName("idx_rds08_iCrmVouchids");

                entity.HasIndex(e => new { e.CInvCode, e.AutoId })
                    .HasName("ix_rdecords08_cinvcode");

                entity.HasIndex(e => new { e.ITrIds, e.AutoId })
                    .HasName("ix_rdecords08_itrids");

                entity.HasIndex(e => new { e.CVouchCode, e.Cinvouchtype, e.AutoId })
                    .HasName("ix_rdecords08_trackid");

                entity.HasIndex(e => new { e.Id, e.AutoId, e.CInvCode })
                    .HasName("ix_rdecords08_id");

                entity.Property(e => e.AutoId)
                    .HasColumnName("AutoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BChecked).HasColumnName("bChecked");

                entity.Property(e => e.BCosting).HasColumnName("bCosting");

                entity.Property(e => e.BGsp).HasColumnName("bGsp");

                entity.Property(e => e.BLpuseFree)
                    .HasColumnName("bLPUseFree")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BVmiused)
                    .HasColumnName("bVMIUsed")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CAssUnit)
                    .HasColumnName("cAssUnit")
                    .HasMaxLength(35);

                entity.Property(e => e.CBarCode)
                    .HasColumnName("cBarCode")
                    .HasMaxLength(200);

                entity.Property(e => e.CBatch)
                    .HasColumnName("cBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CBatchProperty1)
                    .HasColumnName("cBatchProperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty10)
                    .HasColumnName("cBatchProperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.CBatchProperty2)
                    .HasColumnName("cBatchProperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty3)
                    .HasColumnName("cBatchProperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty4)
                    .HasColumnName("cBatchProperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty5)
                    .HasColumnName("cBatchProperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty6)
                    .HasColumnName("cBatchProperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty7)
                    .HasColumnName("cBatchProperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty8)
                    .HasColumnName("cBatchProperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty9)
                    .HasColumnName("cBatchProperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.CBvencode)
                    .HasColumnName("cBVencode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCheckCode)
                    .HasColumnName("cCheckCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCheckPersonCode)
                    .HasColumnName("cCheckPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCrmVouchCode)
                    .HasColumnName("cCrmVouchCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26).HasColumnName("cDefine26");

                entity.Property(e => e.CDefine27).HasColumnName("cDefine27");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CExpirationdate)
                    .HasColumnName("cExpirationdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CGspState)
                    .HasColumnName("cGspState")
                    .HasMaxLength(20);

                entity.Property(e => e.CInVouchCode)
                    .HasColumnName("cInVouchCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CInvCode)
                    .IsRequired()
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CItemCname)
                    .HasColumnName("cItemCName")
                    .HasMaxLength(20);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CMassUnit).HasColumnName("cMassUnit");

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(255);

                entity.Property(e => e.CPosition)
                    .HasColumnName("cPosition")
                    .HasMaxLength(20);

                entity.Property(e => e.CRejectCode)
                    .HasColumnName("cRejectCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CVouchCode).HasColumnName("cVouchCode");

                entity.Property(e => e.CbMemo)
                    .HasColumnName("cbMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbaccounter)
                    .HasColumnName("cbaccounter")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Cbserviceoid)
                    .HasColumnName("cbserviceoid")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Cbsourcecodels)
                    .HasColumnName("cbsourcecodels")
                    .HasMaxLength(20);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cciqbookcode)
                    .HasColumnName("cciqbookcode")
                    .HasMaxLength(20);

                entity.Property(e => e.ChVencode)
                    .HasColumnName("chVencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvouchtype)
                    .HasColumnName("cinvouchtype")
                    .HasMaxLength(2);

                entity.Property(e => e.Coritracktype)
                    .HasColumnName("coritracktype")
                    .HasMaxLength(2);

                entity.Property(e => e.Corufts)
                    .HasColumnName("corufts")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cserviceoid)
                    .HasColumnName("cserviceoid")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Csyssourceautoid)
                    .HasColumnName("csyssourceautoid")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvmivencode)
                    .HasColumnName("cvmivencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cwhpersoncode)
                    .HasColumnName("cwhpersoncode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cwhpersonname)
                    .HasColumnName("cwhpersonname")
                    .HasMaxLength(50);

                entity.Property(e => e.DCheckDate)
                    .HasColumnName("dCheckDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DExpirationdate)
                    .HasColumnName("dExpirationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DMadeDate)
                    .HasColumnName("dMadeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVdate)
                    .HasColumnName("dVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DbKeepDate)
                    .HasColumnName("dbKeepDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IAprice)
                    .HasColumnName("iAPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IBondedSumQty)
                    .HasColumnName("iBondedSumQty")
                    .HasColumnType("decimal(34, 8)");

                entity.Property(e => e.ICheckIdBaks).HasColumnName("iCheckIdBaks");

                entity.Property(e => e.ICheckIds).HasColumnName("iCheckIds");

                entity.Property(e => e.ICrmVouchids).HasColumnName("iCrmVouchids");

                entity.Property(e => e.IDebitIds).HasColumnName("iDebitIDs");

                entity.Property(e => e.IExpiratDateCalcu).HasColumnName("iExpiratDateCalcu");

                entity.Property(e => e.IFlag)
                    .HasColumnName("iFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IFnum)
                    .HasColumnName("iFNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IFquantity)
                    .HasColumnName("iFQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IGroupNo).HasColumnName("iGroupNO");

                entity.Property(e => e.IInvSncount).HasColumnName("iInvSNCount");

                entity.Property(e => e.IMassDate).HasColumnName("iMassDate");

                entity.Property(e => e.INnum)
                    .HasColumnName("iNNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INquantity)
                    .HasColumnName("iNQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IOriTrackId)
                    .HasColumnName("iOriTrackID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IPprice)
                    .HasColumnName("iPPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IPrice)
                    .HasColumnName("iPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IPunitCost)
                    .HasColumnName("iPUnitCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IRejectIds).HasColumnName("iRejectIds");

                entity.Property(e => e.IRsrowNo)
                    .HasColumnName("iRSRowNO")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ISoutNum)
                    .HasColumnName("iSOutNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISoutQuantity)
                    .HasColumnName("iSOutQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ITrIds).HasColumnName("iTrIds");

                entity.Property(e => e.IUnitCost)
                    .HasColumnName("iUnitCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IVmisettleNum)
                    .HasColumnName("iVMISettleNum")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IVmisettleQuantity)
                    .HasColumnName("iVMISettleQuantity")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idebitchildids).HasColumnName("idebitchildids");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Iordercode)
                    .HasColumnName("iordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype)
                    .HasColumnName("iordertype")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iposflag)
                    .HasColumnName("iposflag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ipreuseinum)
                    .HasColumnName("ipreuseinum")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Ipreuseqty)
                    .HasColumnName("ipreuseqty")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isodid)
                    .HasColumnName("isodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Isoseq).HasColumnName("isoseq");

                entity.Property(e => e.Isotype).HasColumnName("isotype");

                entity.Property(e => e.OutCopiedQuantity).HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rowufts)
                    .HasColumnName("rowufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StrContractGuid).HasColumnName("strContractGUID");

                entity.Property(e => e.Strowguid).HasColumnName("strowguid");
            });

            modelBuilder.Entity<Rdrecords09>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaaRdRecords09_PK");

                entity.ToTable("rdrecords09");

                entity.HasIndex(e => e.CBarCode)
                    .HasName("ix_RdRecords09_cbarcode");

                entity.HasIndex(e => e.CBvencode)
                    .HasName("ix_RdRecords09_cbvencode");

                entity.HasIndex(e => e.CInVoucherLineId)
                    .HasName("idx_rdrecords09_cinvoucherlineid");

                entity.HasIndex(e => e.Cbaccounter)
                    .HasName("IX_Rdrecords09_cBaccounter_IA");

                entity.HasIndex(e => e.ICrmVouchids)
                    .HasName("idx_rds09_iCrmVouchids");

                entity.HasIndex(e => e.IDebitIds)
                    .HasName("idx_rdrecords09_idebitids");

                entity.HasIndex(e => e.Iimosid)
                    .HasName("ix_rdrecord09_iimosid");

                entity.HasIndex(e => e.Isrcvouchids)
                    .HasName("idx_rds09_isrcvouchids");

                entity.HasIndex(e => e.StrCode)
                    .HasName("ix_rdrecord09_strCode");

                entity.HasIndex(e => e.StrContractId)
                    .HasName("ix_rdrecord09_strContractId");

                entity.HasIndex(e => new { e.CInvCode, e.AutoId })
                    .HasName("ix_rdecords09_cinvcode");

                entity.HasIndex(e => new { e.IDlsId, e.AutoId })
                    .HasName("ix_rdecords09_idlsid");

                entity.HasIndex(e => new { e.ITrIds, e.AutoId })
                    .HasName("ix_rdecords09_itrids");

                entity.HasIndex(e => new { e.CVouchCode, e.Cinvouchtype, e.AutoId })
                    .HasName("ix_rdecords09_trackid");

                entity.HasIndex(e => new { e.Id, e.AutoId, e.CInvCode })
                    .HasName("ix_rdecords09_id");

                entity.Property(e => e.AutoId)
                    .HasColumnName("AutoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BChecked).HasColumnName("bChecked");

                entity.Property(e => e.BCosting).HasColumnName("bCosting");

                entity.Property(e => e.BGsp).HasColumnName("bGsp");

                entity.Property(e => e.BLpuseFree)
                    .HasColumnName("bLPUseFree")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BVmiused)
                    .HasColumnName("bVMIUsed")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CAssUnit)
                    .HasColumnName("cAssUnit")
                    .HasMaxLength(35);

                entity.Property(e => e.CBarCode)
                    .HasColumnName("cBarCode")
                    .HasMaxLength(200);

                entity.Property(e => e.CBatch)
                    .HasColumnName("cBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CBatchProperty1)
                    .HasColumnName("cBatchProperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty10)
                    .HasColumnName("cBatchProperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.CBatchProperty2)
                    .HasColumnName("cBatchProperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty3)
                    .HasColumnName("cBatchProperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty4)
                    .HasColumnName("cBatchProperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty5)
                    .HasColumnName("cBatchProperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty6)
                    .HasColumnName("cBatchProperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty7)
                    .HasColumnName("cBatchProperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty8)
                    .HasColumnName("cBatchProperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty9)
                    .HasColumnName("cBatchProperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.CBvencode)
                    .HasColumnName("cBVencode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCheckCode)
                    .HasColumnName("cCheckCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCheckPersonCode)
                    .HasColumnName("cCheckPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCrmVouchCode)
                    .HasColumnName("cCrmVouchCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26).HasColumnName("cDefine26");

                entity.Property(e => e.CDefine27).HasColumnName("cDefine27");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CExpirationdate)
                    .HasColumnName("cExpirationdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CGspState)
                    .HasColumnName("cGspState")
                    .HasMaxLength(20);

                entity.Property(e => e.CInVouchCode)
                    .HasColumnName("cInVouchCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CInVoucherCode)
                    .HasColumnName("cInVoucherCode")
                    .HasMaxLength(40);

                entity.Property(e => e.CInVoucherLineId).HasColumnName("cInVoucherLineID");

                entity.Property(e => e.CInVoucherType)
                    .HasColumnName("cInVoucherType")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvCode)
                    .IsRequired()
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CItemCname)
                    .HasColumnName("cItemCName")
                    .HasMaxLength(20);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CMassUnit).HasColumnName("cMassUnit");

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(255);

                entity.Property(e => e.CPoid)
                    .HasColumnName("cPOID")
                    .HasMaxLength(30);

                entity.Property(e => e.CPosition)
                    .HasColumnName("cPosition")
                    .HasMaxLength(20);

                entity.Property(e => e.CRejectCode)
                    .HasColumnName("cRejectCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CVouchCode).HasColumnName("cVouchCode");

                entity.Property(e => e.CbMemo)
                    .HasColumnName("cbMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbaccounter)
                    .HasColumnName("cbaccounter")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Cbdlcode)
                    .HasColumnName("cbdlcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cbserviceoid)
                    .HasColumnName("cbserviceoid")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Cbsourcecodels)
                    .HasColumnName("cbsourcecodels")
                    .HasMaxLength(20);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cciqbookcode)
                    .HasColumnName("cciqbookcode")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccusinvcode)
                    .HasColumnName("ccusinvcode")
                    .HasMaxLength(40);

                entity.Property(e => e.Ccusinvname)
                    .HasColumnName("ccusinvname")
                    .HasMaxLength(100);

                entity.Property(e => e.Cinvouchtype)
                    .HasColumnName("cinvouchtype")
                    .HasMaxLength(2);

                entity.Property(e => e.Coritracktype)
                    .HasColumnName("coritracktype")
                    .HasMaxLength(2);

                entity.Property(e => e.Corufts)
                    .HasColumnName("corufts")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Coutvouchid).HasColumnName("coutvouchid");

                entity.Property(e => e.Coutvouchtype)
                    .HasColumnName("coutvouchtype")
                    .HasMaxLength(2);

                entity.Property(e => e.Cserviceoid)
                    .HasColumnName("cserviceoid")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Csyssourceautoid)
                    .HasColumnName("csyssourceautoid")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvmivencode)
                    .HasColumnName("cvmivencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cwhpersoncode)
                    .HasColumnName("cwhpersoncode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cwhpersonname)
                    .HasColumnName("cwhpersonname")
                    .HasMaxLength(50);

                entity.Property(e => e.DCheckDate)
                    .HasColumnName("dCheckDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DExpirationdate)
                    .HasColumnName("dExpirationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DMadeDate)
                    .HasColumnName("dMadeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVdate)
                    .HasColumnName("dVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DbKeepDate)
                    .HasColumnName("dbKeepDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IAprice)
                    .HasColumnName("iAPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IBondedSumQty)
                    .HasColumnName("iBondedSumQty")
                    .HasColumnType("decimal(34, 8)");

                entity.Property(e => e.ICheckIdBaks).HasColumnName("iCheckIdBaks");

                entity.Property(e => e.ICheckIds).HasColumnName("iCheckIds");

                entity.Property(e => e.ICrmVouchids).HasColumnName("iCrmVouchids");

                entity.Property(e => e.IDebitIds).HasColumnName("iDebitIDs");

                entity.Property(e => e.IDlsId).HasColumnName("iDLsID");

                entity.Property(e => e.IEqDid).HasColumnName("iEqDID");

                entity.Property(e => e.IExpiratDateCalcu).HasColumnName("iExpiratDateCalcu");

                entity.Property(e => e.IFlag)
                    .HasColumnName("iFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IFnum)
                    .HasColumnName("iFNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IFquantity)
                    .HasColumnName("iFQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IGroupNo).HasColumnName("iGroupNO");

                entity.Property(e => e.IInvSncount).HasColumnName("iInvSNCount");

                entity.Property(e => e.IMassDate).HasColumnName("iMassDate");

                entity.Property(e => e.INnum)
                    .HasColumnName("iNNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INquantity)
                    .HasColumnName("iNQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IOriTrackId)
                    .HasColumnName("iOriTrackID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IPprice)
                    .HasColumnName("iPPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IPrice)
                    .HasColumnName("iPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IPunitCost)
                    .HasColumnName("iPUnitCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IRejectIds).HasColumnName("iRejectIds");

                entity.Property(e => e.IRsrowNo)
                    .HasColumnName("iRSRowNO")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ISoutNum)
                    .HasColumnName("iSOutNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISoutQuantity)
                    .HasColumnName("iSOutQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISredOutNum)
                    .HasColumnName("iSRedOutNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISredOutQuantity)
                    .HasColumnName("iSRedOutQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ITrIds).HasColumnName("iTrIds");

                entity.Property(e => e.IUnitCost)
                    .HasColumnName("iUnitCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IVmisettleNum)
                    .HasColumnName("iVMISettleNum")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IVmisettleQuantity)
                    .HasColumnName("iVMISettleQuantity")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idebitchildids).HasColumnName("idebitchildids");

                entity.Property(e => e.Iimosid).HasColumnName("iimosid");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Iordercode)
                    .HasColumnName("iordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype)
                    .HasColumnName("iordertype")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ipickednum)
                    .HasColumnName("ipickednum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ipickedquantity)
                    .HasColumnName("ipickedquantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Iposflag)
                    .HasColumnName("iposflag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ipreuseinum)
                    .HasColumnName("ipreuseinum")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Ipreuseqty)
                    .HasColumnName("ipreuseqty")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isodid)
                    .HasColumnName("isodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Isoseq).HasColumnName("isoseq");

                entity.Property(e => e.Isotype).HasColumnName("isotype");

                entity.Property(e => e.Isrcvouchids).HasColumnName("isrcvouchids");

                entity.Property(e => e.Rowufts)
                    .HasColumnName("rowufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StrCode)
                    .HasColumnName("strCode")
                    .HasMaxLength(150);

                entity.Property(e => e.StrContractGuid).HasColumnName("strContractGUID");

                entity.Property(e => e.StrContractId)
                    .HasColumnName("strContractId")
                    .HasMaxLength(64);

                entity.Property(e => e.Strowguid).HasColumnName("strowguid");
            });

            modelBuilder.Entity<Rdrecords11>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaardrecords11_PK");

                entity.ToTable("rdrecords11");

                entity.HasIndex(e => e.CBarCode)
                    .HasName("ix_RdRecords11_cbarcode");

                entity.HasIndex(e => e.CBvencode)
                    .HasName("ix_rdrecords11_cbvencode");

                entity.HasIndex(e => e.CInVoucherLineId)
                    .HasName("idx_rdrecords11_cinvoucherlineid");

                entity.HasIndex(e => e.Cbaccounter)
                    .HasName("IX_Rdrecords11_cBaccounter_IA");

                entity.HasIndex(e => e.Cserviceoid)
                    .HasName("ix_rdrecords11_cserviceoid");

                entity.HasIndex(e => e.IMpoIds)
                    .HasName("ix_rdrecords11_iMPoIds");

                entity.HasIndex(e => e.IOmoDid)
                    .HasName("ix_rdecords11_iOMoDID");

                entity.HasIndex(e => e.IOmoMid)
                    .HasName("ix_rdecords11_iOMoMID");

                entity.HasIndex(e => new { e.CInvCode, e.AutoId })
                    .HasName("ix_rdecords11_cinvcode");

                entity.HasIndex(e => new { e.IMaIds, e.AutoId })
                    .HasName("ix_rdecords11_imaids");

                entity.HasIndex(e => new { e.ITrIds, e.AutoId })
                    .HasName("ix_rdecords11_itrids");

                entity.HasIndex(e => new { e.CVouchCode, e.Cinvouchtype, e.AutoId })
                    .HasName("ix_rdecords11_trackid");

                entity.HasIndex(e => new { e.Id, e.AutoId, e.CInvCode })
                    .HasName("ix_rdecords11_id");

                entity.Property(e => e.AutoId)
                    .HasColumnName("AutoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Applycode)
                    .HasColumnName("applycode")
                    .HasMaxLength(30);

                entity.Property(e => e.Applydid).HasColumnName("applydid");

                entity.Property(e => e.BChecked).HasColumnName("bChecked");

                entity.Property(e => e.BCosting).HasColumnName("bCosting");

                entity.Property(e => e.BFilled).HasColumnName("bFilled");

                entity.Property(e => e.BGsp).HasColumnName("bGsp");

                entity.Property(e => e.BLpuseFree)
                    .HasColumnName("bLPUseFree")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BOutMaterials).HasColumnName("bOutMaterials");

                entity.Property(e => e.BVmiused)
                    .HasColumnName("bVMIUsed")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bcanreplace)
                    .HasColumnName("bcanreplace")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bsupersede)
                    .HasColumnName("bsupersede")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CAssUnit)
                    .HasColumnName("cAssUnit")
                    .HasMaxLength(35);

                entity.Property(e => e.CBarCode)
                    .HasColumnName("cBarCode")
                    .HasMaxLength(200);

                entity.Property(e => e.CBatch)
                    .HasColumnName("cBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CBatchProperty1)
                    .HasColumnName("cBatchProperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty10)
                    .HasColumnName("cBatchProperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.CBatchProperty2)
                    .HasColumnName("cBatchProperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty3)
                    .HasColumnName("cBatchProperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty4)
                    .HasColumnName("cBatchProperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty5)
                    .HasColumnName("cBatchProperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty6)
                    .HasColumnName("cBatchProperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty7)
                    .HasColumnName("cBatchProperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty8)
                    .HasColumnName("cBatchProperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty9)
                    .HasColumnName("cBatchProperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.CBvencode)
                    .HasColumnName("cBVencode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCheckCode)
                    .HasColumnName("cCheckCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCheckPersonCode)
                    .HasColumnName("cCheckPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26).HasColumnName("cDefine26");

                entity.Property(e => e.CDefine27).HasColumnName("cDefine27");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CExpirationdate)
                    .HasColumnName("cExpirationdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CGspState)
                    .HasColumnName("cGspState")
                    .HasMaxLength(20);

                entity.Property(e => e.CInVouchCode)
                    .HasColumnName("cInVouchCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CInVoucherCode)
                    .HasColumnName("cInVoucherCode")
                    .HasMaxLength(40);

                entity.Property(e => e.CInVoucherLineId).HasColumnName("cInVoucherLineID");

                entity.Property(e => e.CInVoucherType)
                    .HasColumnName("cInVoucherType")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvCode)
                    .IsRequired()
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CItemCname)
                    .HasColumnName("cItemCName")
                    .HasMaxLength(20);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CMassUnit).HasColumnName("cMassUnit");

                entity.Property(e => e.CMoLotCode)
                    .HasColumnName("cMoLotCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(255);

                entity.Property(e => e.CObjCode)
                    .HasColumnName("cObjCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CPosition)
                    .HasColumnName("cPosition")
                    .HasMaxLength(20);

                entity.Property(e => e.CRejectCode)
                    .HasColumnName("cRejectCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CSourceMocode)
                    .HasColumnName("cSourceMOCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CVouchCode).HasColumnName("cVouchCode");

                entity.Property(e => e.CbMemo)
                    .HasColumnName("cbMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbaccounter)
                    .HasColumnName("cbaccounter")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Cbserviceoid)
                    .HasColumnName("cbserviceoid")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cciqbookcode)
                    .HasColumnName("cciqbookcode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvouchtype)
                    .HasColumnName("cinvouchtype")
                    .HasMaxLength(2);

                entity.Property(e => e.Cmocode)
                    .HasColumnName("cmocode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cmworkcentercode)
                    .HasColumnName("cmworkcentercode")
                    .HasMaxLength(8);

                entity.Property(e => e.Comcode)
                    .HasColumnName("comcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Copdesc)
                    .HasColumnName("copdesc")
                    .HasMaxLength(60);

                entity.Property(e => e.Coritracktype)
                    .HasColumnName("coritracktype")
                    .HasMaxLength(2);

                entity.Property(e => e.Corufts)
                    .HasColumnName("corufts")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Coutvouchid).HasColumnName("coutvouchid");

                entity.Property(e => e.Coutvouchtype)
                    .HasColumnName("coutvouchtype")
                    .HasMaxLength(2);

                entity.Property(e => e.Cpesocode)
                    .HasColumnName("cpesocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cplanlotcode)
                    .HasColumnName("cplanlotcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cservicecode)
                    .HasColumnName("cservicecode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cserviceoid)
                    .HasColumnName("cserviceoid")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cvmivencode)
                    .HasColumnName("cvmivencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cwhpersoncode)
                    .HasColumnName("cwhpersoncode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cwhpersonname)
                    .HasColumnName("cwhpersonname")
                    .HasMaxLength(50);

                entity.Property(e => e.DCheckDate)
                    .HasColumnName("dCheckDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DExpirationdate)
                    .HasColumnName("dExpirationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DMadeDate)
                    .HasColumnName("dMadeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DMsdate)
                    .HasColumnName("dMSDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVdate)
                    .HasColumnName("dVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DbKeepDate)
                    .HasColumnName("dbKeepDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IAprice)
                    .HasColumnName("iAPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IBondedSumQty)
                    .HasColumnName("iBondedSumQty")
                    .HasColumnType("decimal(34, 8)");

                entity.Property(e => e.ICheckIdBaks).HasColumnName("iCheckIdBaks");

                entity.Property(e => e.ICheckIds).HasColumnName("iCheckIds");

                entity.Property(e => e.IExpiratDateCalcu).HasColumnName("iExpiratDateCalcu");

                entity.Property(e => e.IFlag)
                    .HasColumnName("iFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IFnum)
                    .HasColumnName("iFNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IFquantity)
                    .HasColumnName("iFQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IInvSncount).HasColumnName("iInvSNCount");

                entity.Property(e => e.IMaIds).HasColumnName("iMaIDs");

                entity.Property(e => e.IMassDate).HasColumnName("iMassDate");

                entity.Property(e => e.IMaterialFee)
                    .HasColumnName("iMaterialFee")
                    .HasColumnType("money");

                entity.Property(e => e.IMpoIds).HasColumnName("iMPoIds");

                entity.Property(e => e.INnum)
                    .HasColumnName("iNNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INquantity)
                    .HasColumnName("iNQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IOmoDid).HasColumnName("iOMoDID");

                entity.Property(e => e.IOmoMid).HasColumnName("iOMoMID");

                entity.Property(e => e.IOriTrackId)
                    .HasColumnName("iOriTrackID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IPprice)
                    .HasColumnName("iPPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IPrice)
                    .HasColumnName("iPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IProcessCost)
                    .HasColumnName("iProcessCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IProcessFee)
                    .HasColumnName("iProcessFee")
                    .HasColumnType("money");

                entity.Property(e => e.IPunitCost)
                    .HasColumnName("iPUnitCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IRejectIds).HasColumnName("iRejectIds");

                entity.Property(e => e.IRsrowNo)
                    .HasColumnName("iRSRowNO")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ISmaterialFee)
                    .HasColumnName("iSMaterialFee")
                    .HasColumnType("money");

                entity.Property(e => e.ISnum)
                    .HasColumnName("iSNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISourceModetailsid).HasColumnName("iSourceMODetailsid");

                entity.Property(e => e.ISoutNum)
                    .HasColumnName("iSOutNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISoutQuantity)
                    .HasColumnName("iSOutQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISprocessFee)
                    .HasColumnName("iSProcessFee")
                    .HasColumnType("money");

                entity.Property(e => e.ISquantity)
                    .HasColumnName("iSQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISredOutNum)
                    .HasColumnName("iSRedOutNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISredOutQuantity)
                    .HasColumnName("iSRedOutQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ITrIds).HasColumnName("iTrIds");

                entity.Property(e => e.IUnitCost)
                    .HasColumnName("iUnitCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IVmisettleNum)
                    .HasColumnName("iVMISettleNum")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IVmisettleQuantity)
                    .HasColumnName("iVMISettleQuantity")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Imoallocatesubid).HasColumnName("imoallocatesubid");

                entity.Property(e => e.Imoseq).HasColumnName("imoseq");

                entity.Property(e => e.Invcode)
                    .HasColumnName("invcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Iopseq)
                    .HasColumnName("iopseq")
                    .HasMaxLength(10);

                entity.Property(e => e.Iordercode)
                    .HasColumnName("iordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype)
                    .HasColumnName("iordertype")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ipesodid)
                    .HasColumnName("ipesodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Ipesoseq).HasColumnName("ipesoseq");

                entity.Property(e => e.Ipesotype).HasColumnName("ipesotype");

                entity.Property(e => e.Iposflag)
                    .HasColumnName("iposflag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ipreuseinum)
                    .HasColumnName("ipreuseinum")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Ipreuseqty)
                    .HasColumnName("ipreuseqty")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isodid)
                    .HasColumnName("isodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Isoseq).HasColumnName("isoseq");

                entity.Property(e => e.Isotype).HasColumnName("isotype");

                entity.Property(e => e.Isupersedempoids).HasColumnName("isupersedempoids");

                entity.Property(e => e.Isupersedeqty)
                    .HasColumnName("isupersedeqty")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Productinids).HasColumnName("productinids");

                entity.Property(e => e.Rowufts)
                    .HasColumnName("rowufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StrContractGuid).HasColumnName("strContractGUID");

                entity.Property(e => e.Strowguid).HasColumnName("strowguid");
            });

            modelBuilder.Entity<Rdrecords32>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaardrecords32_PK");

                entity.ToTable("rdrecords32");

                entity.HasIndex(e => e.CBarCode)
                    .HasName("ix_RdRecords32_cbarcode");

                entity.HasIndex(e => e.CBvencode)
                    .HasName("ix_RdRecords32_cbvencode");

                entity.HasIndex(e => e.Cbaccounter)
                    .HasName("IX_Rdrecords32_cBaccounter_IA");

                entity.HasIndex(e => e.Cbdlcode)
                    .HasName("idx_rdrecords32_cbdlcode");

                entity.HasIndex(e => e.Iorderdid)
                    .HasName("idx_rdrecords32_iorderdid");

                entity.HasIndex(e => new { e.CInvCode, e.AutoId })
                    .HasName("ix_rdecords32_cinvcode");

                entity.HasIndex(e => new { e.GcsourceId, e.GcsourceIds })
                    .HasName("idx_rdrecords32_GCSourceIds");

                entity.HasIndex(e => new { e.IDlsId, e.AutoId })
                    .HasName("ix_rdecords32_idlsid");

                entity.HasIndex(e => new { e.StrContractId, e.StrCode })
                    .HasName("ix_rdecords32_strContractId_strCode");

                entity.HasIndex(e => new { e.CVouchCode, e.Cinvouchtype, e.AutoId })
                    .HasName("ix_rdecords32_trackid");

                entity.HasIndex(e => new { e.Id, e.AutoId, e.CInvCode })
                    .HasName("ix_rdecords32_id");

                entity.Property(e => e.AutoId)
                    .HasColumnName("AutoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BChecked).HasColumnName("bChecked");

                entity.Property(e => e.BCosting).HasColumnName("bCosting");

                entity.Property(e => e.BGsp).HasColumnName("bGsp");

                entity.Property(e => e.BIacreatebill).HasColumnName("bIAcreatebill");

                entity.Property(e => e.BLpuseFree)
                    .HasColumnName("bLPUseFree")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BVmiused)
                    .HasColumnName("bVMIUsed")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bneedbill).HasColumnName("bneedbill");

                entity.Property(e => e.BodyOutid).HasColumnName("body_outid");

                entity.Property(e => e.Bsaleoutcreatebill).HasColumnName("bsaleoutcreatebill");

                entity.Property(e => e.CAssUnit)
                    .HasColumnName("cAssUnit")
                    .HasMaxLength(35);

                entity.Property(e => e.CBarCode)
                    .HasColumnName("cBarCode")
                    .HasMaxLength(200);

                entity.Property(e => e.CBatch)
                    .HasColumnName("cBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CBatchProperty1)
                    .HasColumnName("cBatchProperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty10)
                    .HasColumnName("cBatchProperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.CBatchProperty2)
                    .HasColumnName("cBatchProperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty3)
                    .HasColumnName("cBatchProperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty4)
                    .HasColumnName("cBatchProperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty5)
                    .HasColumnName("cBatchProperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty6)
                    .HasColumnName("cBatchProperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty7)
                    .HasColumnName("cBatchProperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty8)
                    .HasColumnName("cBatchProperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty9)
                    .HasColumnName("cBatchProperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.CBvencode)
                    .HasColumnName("cBVencode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCheckCode)
                    .HasColumnName("cCheckCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCheckPersonCode)
                    .HasColumnName("cCheckPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CConfirmer)
                    .HasColumnName("cConfirmer")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26).HasColumnName("cDefine26");

                entity.Property(e => e.CDefine27).HasColumnName("cDefine27");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CExpirationdate)
                    .HasColumnName("cExpirationdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CGspState)
                    .HasColumnName("cGspState")
                    .HasMaxLength(20);

                entity.Property(e => e.CInVouchCode)
                    .HasColumnName("cInVouchCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CInvCode)
                    .IsRequired()
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CItemCname)
                    .HasColumnName("cItemCName")
                    .HasMaxLength(20);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CMassUnit).HasColumnName("cMassUnit");

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(255);

                entity.Property(e => e.CPosition)
                    .HasColumnName("cPosition")
                    .HasMaxLength(20);

                entity.Property(e => e.CRejectCode)
                    .HasColumnName("cRejectCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CVouchCode).HasColumnName("cVouchCode");

                entity.Property(e => e.CbMemo)
                    .HasColumnName("cbMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbaccounter)
                    .HasColumnName("cbaccounter")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Cbdlcode)
                    .HasColumnName("cbdlcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cbserviceoid)
                    .HasColumnName("cbserviceoid")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cciqbookcode)
                    .HasColumnName("cciqbookcode")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccusinvcode)
                    .HasColumnName("ccusinvcode")
                    .HasMaxLength(40);

                entity.Property(e => e.Ccusinvname)
                    .HasColumnName("ccusinvname")
                    .HasMaxLength(100);

                entity.Property(e => e.Cinvouchtype)
                    .HasColumnName("cinvouchtype")
                    .HasMaxLength(2);

                entity.Property(e => e.Coritracktype)
                    .HasColumnName("coritracktype")
                    .HasMaxLength(2);

                entity.Property(e => e.Corufts)
                    .HasColumnName("corufts")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Coutvouchid).HasColumnName("coutvouchid");

                entity.Property(e => e.Coutvouchtype)
                    .HasColumnName("coutvouchtype")
                    .HasMaxLength(2);

                entity.Property(e => e.Cpesocode)
                    .HasColumnName("cpesocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cserviceoid)
                    .HasColumnName("cserviceoid")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cvmivencode)
                    .HasColumnName("cvmivencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cwhpersoncode)
                    .HasColumnName("cwhpersoncode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cwhpersonname)
                    .HasColumnName("cwhpersonname")
                    .HasMaxLength(50);

                entity.Property(e => e.DCheckDate)
                    .HasColumnName("dCheckDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DConfirmDate)
                    .HasColumnName("dConfirmDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DExpirationdate)
                    .HasColumnName("dExpirationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DMadeDate)
                    .HasColumnName("dMadeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVdate)
                    .HasColumnName("dVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DbKeepDate)
                    .HasColumnName("dbKeepDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fretqtywkp)
                    .HasColumnName("fretqtywkp")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Fretqtyykp)
                    .HasColumnName("fretqtyykp")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Fsettleqty)
                    .HasColumnName("fsettleqty")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.GcsourceId).HasColumnName("GCSourceId");

                entity.Property(e => e.GcsourceIds).HasColumnName("GCSourceIds");

                entity.Property(e => e.IAprice)
                    .HasColumnName("iAPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IBondedSumQty)
                    .HasColumnName("iBondedSumQty")
                    .HasColumnType("decimal(34, 8)");

                entity.Property(e => e.ICheckIdBaks).HasColumnName("iCheckIdBaks");

                entity.Property(e => e.ICheckIds).HasColumnName("iCheckIds");

                entity.Property(e => e.IDebitIds).HasColumnName("iDebitIDs");

                entity.Property(e => e.IDlsId).HasColumnName("iDLsID");

                entity.Property(e => e.IEnsId).HasColumnName("iEnsID");

                entity.Property(e => e.IEqDid).HasColumnName("iEqDID");

                entity.Property(e => e.IExpiratDateCalcu).HasColumnName("iExpiratDateCalcu");

                entity.Property(e => e.IFlag)
                    .HasColumnName("iFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IFnum)
                    .HasColumnName("iFNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IFquantity)
                    .HasColumnName("iFQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IInvSncount).HasColumnName("iInvSNCount");

                entity.Property(e => e.IMassDate).HasColumnName("iMassDate");

                entity.Property(e => e.INnum)
                    .HasColumnName("iNNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INquantity)
                    .HasColumnName("iNQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IOriTrackId)
                    .HasColumnName("iOriTrackID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IPprice)
                    .HasColumnName("iPPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IPrice)
                    .HasColumnName("iPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IPunitCost)
                    .HasColumnName("iPUnitCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IRefundInspectFlag).HasColumnName("iRefundInspectFlag");

                entity.Property(e => e.IRejectIds).HasColumnName("iRejectIds");

                entity.Property(e => e.IRsrowNo)
                    .HasColumnName("iRSRowNO")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ISbsId).HasColumnName("iSBsID");

                entity.Property(e => e.ISendNum)
                    .HasColumnName("iSendNum")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ISendQuantity)
                    .HasColumnName("iSendQuantity")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ISoutNum)
                    .HasColumnName("iSOutNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISoutQuantity)
                    .HasColumnName("iSOutQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISredOutNum)
                    .HasColumnName("iSRedOutNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISredOutQuantity)
                    .HasColumnName("iSRedOutQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IUnitCost)
                    .HasColumnName("iUnitCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IVmisettleNum)
                    .HasColumnName("iVMISettleNum")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IVmisettleQuantity)
                    .HasColumnName("iVMISettleQuantity")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Iordercode)
                    .HasColumnName("iordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype)
                    .HasColumnName("iordertype")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ipesodid)
                    .HasColumnName("ipesodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Ipesoseq).HasColumnName("ipesoseq");

                entity.Property(e => e.Ipesotype).HasColumnName("ipesotype");

                entity.Property(e => e.Iposflag)
                    .HasColumnName("iposflag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ipreuseinum)
                    .HasColumnName("ipreuseinum")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Ipreuseqty)
                    .HasColumnName("ipreuseqty")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isaleoutid).HasColumnName("isaleoutid");

                entity.Property(e => e.Isodid)
                    .HasColumnName("isodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Isoseq).HasColumnName("isoseq");

                entity.Property(e => e.Isotype).HasColumnName("isotype");

                entity.Property(e => e.Rowufts)
                    .HasColumnName("rowufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StrCode)
                    .HasColumnName("strCode")
                    .HasMaxLength(150);

                entity.Property(e => e.StrContractGuid).HasColumnName("strContractGUID");

                entity.Property(e => e.StrContractId)
                    .HasColumnName("strContractId")
                    .HasMaxLength(64);

                entity.Property(e => e.Strowguid).HasColumnName("strowguid");
            });

            modelBuilder.Entity<Rdrecords34>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaardrecords34_PK");

                entity.ToTable("rdrecords34");

                entity.HasIndex(e => e.CBarCode)
                    .HasName("ix_RdRecords34_cbarcode");

                entity.HasIndex(e => e.CBvencode)
                    .HasName("ix_RdRecords34_cbvencode");

                entity.HasIndex(e => new { e.CInvCode, e.AutoId })
                    .HasName("ix_rdecords34_cinvcode");

                entity.HasIndex(e => new { e.CVouchCode, e.Cinvouchtype, e.AutoId })
                    .HasName("ix_rdecords34_trackid");

                entity.HasIndex(e => new { e.Id, e.AutoId, e.CInvCode })
                    .HasName("ix_rdecords34_id");

                entity.Property(e => e.AutoId)
                    .HasColumnName("AutoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BChecked).HasColumnName("bChecked");

                entity.Property(e => e.BCosting).HasColumnName("bCosting");

                entity.Property(e => e.BLpuseFree)
                    .HasColumnName("bLPUseFree")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BVmiused)
                    .HasColumnName("bVMIUsed")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CAssUnit)
                    .HasColumnName("cAssUnit")
                    .HasMaxLength(35);

                entity.Property(e => e.CBarCode)
                    .HasColumnName("cBarCode")
                    .HasMaxLength(200);

                entity.Property(e => e.CBatch)
                    .HasColumnName("cBatch")
                    .HasMaxLength(60);

                entity.Property(e => e.CBatchProperty1)
                    .HasColumnName("cBatchProperty1")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty10)
                    .HasColumnName("cBatchProperty10")
                    .HasColumnType("datetime");

                entity.Property(e => e.CBatchProperty2)
                    .HasColumnName("cBatchProperty2")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty3)
                    .HasColumnName("cBatchProperty3")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty4)
                    .HasColumnName("cBatchProperty4")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty5)
                    .HasColumnName("cBatchProperty5")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.CBatchProperty6)
                    .HasColumnName("cBatchProperty6")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty7)
                    .HasColumnName("cBatchProperty7")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty8)
                    .HasColumnName("cBatchProperty8")
                    .HasMaxLength(120);

                entity.Property(e => e.CBatchProperty9)
                    .HasColumnName("cBatchProperty9")
                    .HasMaxLength(120);

                entity.Property(e => e.CBvencode)
                    .HasColumnName("cBVencode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCheckCode)
                    .HasColumnName("cCheckCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCheckPersonCode)
                    .HasColumnName("cCheckPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26).HasColumnName("cDefine26");

                entity.Property(e => e.CDefine27).HasColumnName("cDefine27");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CExpirationdate)
                    .HasColumnName("cExpirationdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CInVouchCode)
                    .HasColumnName("cInVouchCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CInvCode)
                    .IsRequired()
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CItemCname)
                    .HasColumnName("cItemCName")
                    .HasMaxLength(20);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CMassUnit).HasColumnName("cMassUnit");

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(255);

                entity.Property(e => e.CPosition)
                    .HasColumnName("cPosition")
                    .HasMaxLength(20);

                entity.Property(e => e.CRejectCode)
                    .HasColumnName("cRejectCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CVouchCode).HasColumnName("cVouchCode");

                entity.Property(e => e.CbMemo)
                    .HasColumnName("cbMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbaccounter)
                    .HasColumnName("cbaccounter")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Cbdlcode)
                    .HasColumnName("cbdlcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cbserviceoid)
                    .HasColumnName("cbserviceoid")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Cciqbookcode)
                    .HasColumnName("cciqbookcode")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccusinvcode)
                    .HasColumnName("ccusinvcode")
                    .HasMaxLength(40);

                entity.Property(e => e.Ccusinvname)
                    .HasColumnName("ccusinvname")
                    .HasMaxLength(100);

                entity.Property(e => e.Cinvouchtype)
                    .HasColumnName("cinvouchtype")
                    .HasMaxLength(2);

                entity.Property(e => e.Coritracktype)
                    .HasColumnName("coritracktype")
                    .HasMaxLength(2);

                entity.Property(e => e.Corufts)
                    .HasColumnName("corufts")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Coutvouchid).HasColumnName("coutvouchid");

                entity.Property(e => e.Coutvouchtype)
                    .HasColumnName("coutvouchtype")
                    .HasMaxLength(2);

                entity.Property(e => e.Cserviceoid)
                    .HasColumnName("cserviceoid")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cvmivencode)
                    .HasColumnName("cvmivencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cwhpersoncode)
                    .HasColumnName("cwhpersoncode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cwhpersonname)
                    .HasColumnName("cwhpersonname")
                    .HasMaxLength(50);

                entity.Property(e => e.DCheckDate)
                    .HasColumnName("dCheckDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DExpirationdate)
                    .HasColumnName("dExpirationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DMadeDate)
                    .HasColumnName("dMadeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVdate)
                    .HasColumnName("dVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DbKeepDate)
                    .HasColumnName("dbKeepDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasMaxLength(40);

                entity.Property(e => e.IAprice)
                    .HasColumnName("iAPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IBondedSumQty)
                    .HasColumnName("iBondedSumQty")
                    .HasColumnType("decimal(34, 8)");

                entity.Property(e => e.ICheckIdBaks).HasColumnName("iCheckIdBaks");

                entity.Property(e => e.IDlsId).HasColumnName("iDLsID");

                entity.Property(e => e.IEnsId).HasColumnName("iEnsID");

                entity.Property(e => e.IEqDid).HasColumnName("iEqDID");

                entity.Property(e => e.IExpiratDateCalcu).HasColumnName("iExpiratDateCalcu");

                entity.Property(e => e.IFlag)
                    .HasColumnName("iFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IFnum)
                    .HasColumnName("iFNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IFquantity)
                    .HasColumnName("iFQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IInvSncount).HasColumnName("iInvSNCount");

                entity.Property(e => e.IMassDate).HasColumnName("iMassDate");

                entity.Property(e => e.INnum)
                    .HasColumnName("iNNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INquantity)
                    .HasColumnName("iNQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IOriTrackId)
                    .HasColumnName("iOriTrackID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IPprice)
                    .HasColumnName("iPPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IPrice)
                    .HasColumnName("iPrice")
                    .HasColumnType("money");

                entity.Property(e => e.IPunitCost)
                    .HasColumnName("iPUnitCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IRefundInspectFlag).HasColumnName("iRefundInspectFlag");

                entity.Property(e => e.IRejectIds).HasColumnName("iRejectIds");

                entity.Property(e => e.IRsrowNo)
                    .HasColumnName("iRSRowNO")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ISbsId).HasColumnName("iSBsID");

                entity.Property(e => e.ISendNum)
                    .HasColumnName("iSendNum")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ISendQuantity)
                    .HasColumnName("iSendQuantity")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ISoutNum)
                    .HasColumnName("iSOutNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISoutQuantity)
                    .HasColumnName("iSOutQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISredOutNum)
                    .HasColumnName("iSRedOutNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.ISredOutQuantity)
                    .HasColumnName("iSRedOutQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IUnitCost)
                    .HasColumnName("iUnitCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IVmisettleNum)
                    .HasColumnName("iVMISettleNum")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IVmisettleQuantity)
                    .HasColumnName("iVMISettleQuantity")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Iordercode)
                    .HasColumnName("iordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype)
                    .HasColumnName("iordertype")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iposflag)
                    .HasColumnName("iposflag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ipreuseinum)
                    .HasColumnName("ipreuseinum")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Ipreuseqty)
                    .HasColumnName("ipreuseqty")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isodid)
                    .HasColumnName("isodid")
                    .HasMaxLength(40);

                entity.Property(e => e.Isoseq).HasColumnName("isoseq");

                entity.Property(e => e.Isotype).HasColumnName("isotype");

                entity.Property(e => e.Rowufts)
                    .HasColumnName("rowufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StrCode)
                    .HasColumnName("strCode")
                    .HasMaxLength(150);

                entity.Property(e => e.StrContractGuid).HasColumnName("strContractGUID");

                entity.Property(e => e.StrContractId)
                    .HasColumnName("strContractId")
                    .HasMaxLength(64);

                entity.Property(e => e.Strowguid).HasColumnName("strowguid");
            });

            modelBuilder.Entity<SaDispatchdetailmerp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("sa_dispatchdetailmerp");

                entity.Property(e => e.CDlcode)
                    .HasColumnName("cDLCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CInvCode)
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CInvStd)
                    .HasColumnName("cInvStd")
                    .HasMaxLength(255);

                entity.Property(e => e.CWhName)
                    .HasColumnName("cWhName")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree1)
                    .HasColumnName("cfree1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree10)
                    .HasColumnName("cfree10")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree2)
                    .HasColumnName("cfree2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree3)
                    .HasColumnName("cfree3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree4)
                    .HasColumnName("cfree4")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree5)
                    .HasColumnName("cfree5")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree6)
                    .HasColumnName("cfree6")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree7)
                    .HasColumnName("cfree7")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree8)
                    .HasColumnName("cfree8")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree9)
                    .HasColumnName("cfree9")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvaddcode)
                    .HasColumnName("cinvaddcode")
                    .HasMaxLength(255);

                entity.Property(e => e.CinvmUnit)
                    .HasColumnName("cinvm_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvname)
                    .HasColumnName("cinvname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cunitid)
                    .HasColumnName("cunitid")
                    .HasMaxLength(35);

                entity.Property(e => e.Dlid).HasColumnName("DLID");

                entity.Property(e => e.ITaxRate)
                    .HasColumnName("iTaxRate")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Idiscount)
                    .HasColumnName("idiscount")
                    .HasColumnType("money");

                entity.Property(e => e.Imoney)
                    .HasColumnName("imoney")
                    .HasColumnType("money");

                entity.Property(e => e.Inatmoney)
                    .HasColumnName("inatmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Inatsum)
                    .HasColumnName("inatsum")
                    .HasColumnType("money");

                entity.Property(e => e.Inatunitprice)
                    .HasColumnName("inatunitprice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Inum)
                    .HasColumnName("inum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Iquantity)
                    .HasColumnName("iquantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Isum)
                    .HasColumnName("isum")
                    .HasColumnType("money");

                entity.Property(e => e.Iunitprice)
                    .HasColumnName("iunitprice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Kl)
                    .HasColumnName("KL")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Kl2)
                    .HasColumnName("KL2")
                    .HasColumnType("decimal(30, 10)");
            });

            modelBuilder.Entity<SaDispatchlist>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SA_Dispatchlist");

                entity.Property(e => e.Baccswitchflag).HasColumnName("baccswitchflag");

                entity.Property(e => e.Bbillbluesalelist).HasColumnName("bbillbluesalelist");

                entity.Property(e => e.Bbillredsalelist).HasColumnName("bbillredsalelist");

                entity.Property(e => e.Bcal).HasColumnName("bcal");

                entity.Property(e => e.Bcashsale).HasColumnName("bcashsale");

                entity.Property(e => e.Bcredit)
                    .IsRequired()
                    .HasColumnName("bcredit")
                    .HasMaxLength(1);

                entity.Property(e => e.Bcreditdate).HasColumnName("bcreditdate");

                entity.Property(e => e.Bcusinvlimited).HasColumnName("bcusinvlimited");

                entity.Property(e => e.Bfirst).HasColumnName("bfirst");

                entity.Property(e => e.Billafterlosssettle).HasColumnName("billafterlosssettle");

                entity.Property(e => e.Bmustbook).HasColumnName("bmustbook");

                entity.Property(e => e.Bneedbill).HasColumnName("bneedbill");

                entity.Property(e => e.Bnottogoldtax).HasColumnName("bnottogoldtax");

                entity.Property(e => e.Brequestsign).HasColumnName("brequestsign");

                entity.Property(e => e.Breturnflag).HasColumnName("breturnflag");

                entity.Property(e => e.Bsaleoutcreatebill).HasColumnName("bsaleoutcreatebill");

                entity.Property(e => e.Bsigncreate).HasColumnName("bsigncreate");

                entity.Property(e => e.Caccounter)
                    .HasColumnName("caccounter")
                    .HasMaxLength(20);

                entity.Property(e => e.Caddcode)
                    .HasColumnName("caddcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cauthid)
                    .HasColumnName("cauthid")
                    .HasMaxLength(40);

                entity.Property(e => e.Cbaccount)
                    .HasColumnName("cbaccount")
                    .HasMaxLength(50);

                entity.Property(e => e.Cbcode)
                    .HasColumnName("cbcode")
                    .HasMaxLength(3);

                entity.Property(e => e.Cbname)
                    .HasColumnName("cbname")
                    .HasMaxLength(100);

                entity.Property(e => e.Cbookdepcode)
                    .HasColumnName("cbookdepcode")
                    .HasMaxLength(12);

                entity.Property(e => e.Cbooktype)
                    .HasColumnName("cbooktype")
                    .HasMaxLength(10);

                entity.Property(e => e.Cbustype)
                    .HasColumnName("cbustype")
                    .HasMaxLength(8);

                entity.Property(e => e.Ccccode)
                    .HasColumnName("ccccode")
                    .HasMaxLength(12);

                entity.Property(e => e.Cchangememo)
                    .HasColumnName("cchangememo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cchanger)
                    .HasColumnName("cchanger")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccloser)
                    .HasColumnName("ccloser")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccontactname)
                    .HasColumnName("ccontactname")
                    .HasMaxLength(255);

                entity.Property(e => e.Ccrechpname)
                    .HasColumnName("ccrechpname")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccreditcuscode)
                    .HasColumnName("ccreditcuscode")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccreditcusname)
                    .HasColumnName("ccreditcusname")
                    .HasMaxLength(98);

                entity.Property(e => e.Ccurrentauditor)
                    .HasColumnName("ccurrentauditor")
                    .HasMaxLength(200);

                entity.Property(e => e.Ccusabbname)
                    .IsRequired()
                    .HasColumnName("ccusabbname")
                    .HasMaxLength(60);

                entity.Property(e => e.Ccusaddress)
                    .HasColumnName("ccusaddress")
                    .HasMaxLength(255);

                entity.Property(e => e.Ccuscode)
                    .HasColumnName("ccuscode")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccusdefine1)
                    .HasColumnName("ccusdefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccusdefine10)
                    .HasColumnName("ccusdefine10")
                    .HasMaxLength(120);

                entity.Property(e => e.Ccusdefine11).HasColumnName("ccusdefine11");

                entity.Property(e => e.Ccusdefine12).HasColumnName("ccusdefine12");

                entity.Property(e => e.Ccusdefine13).HasColumnName("ccusdefine13");

                entity.Property(e => e.Ccusdefine14).HasColumnName("ccusdefine14");

                entity.Property(e => e.Ccusdefine15)
                    .HasColumnName("ccusdefine15")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ccusdefine16)
                    .HasColumnName("ccusdefine16")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ccusdefine2)
                    .HasColumnName("ccusdefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccusdefine3)
                    .HasColumnName("ccusdefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccusdefine4)
                    .HasColumnName("ccusdefine4")
                    .HasMaxLength(60);

                entity.Property(e => e.Ccusdefine5)
                    .HasColumnName("ccusdefine5")
                    .HasMaxLength(60);

                entity.Property(e => e.Ccusdefine6)
                    .HasColumnName("ccusdefine6")
                    .HasMaxLength(60);

                entity.Property(e => e.Ccusdefine7)
                    .HasColumnName("ccusdefine7")
                    .HasMaxLength(120);

                entity.Property(e => e.Ccusdefine8)
                    .HasColumnName("ccusdefine8")
                    .HasMaxLength(120);

                entity.Property(e => e.Ccusdefine9)
                    .HasColumnName("ccusdefine9")
                    .HasMaxLength(120);

                entity.Property(e => e.Ccushand)
                    .HasColumnName("ccushand")
                    .HasMaxLength(100);

                entity.Property(e => e.Ccusname)
                    .HasColumnName("ccusname")
                    .HasMaxLength(98);

                entity.Property(e => e.Ccusoaddress)
                    .HasColumnName("ccusoaddress")
                    .HasMaxLength(255);

                entity.Property(e => e.Ccusotype)
                    .HasColumnName("ccusotype")
                    .HasMaxLength(10);

                entity.Property(e => e.Ccuspaycond)
                    .HasColumnName("ccuspaycond")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccusperson)
                    .HasColumnName("ccusperson")
                    .HasMaxLength(100);

                entity.Property(e => e.Ccuspersoncode)
                    .HasColumnName("ccuspersoncode")
                    .HasMaxLength(30);

                entity.Property(e => e.Ccusphone)
                    .HasColumnName("ccusphone")
                    .HasMaxLength(100);

                entity.Property(e => e.Ccuspostcode)
                    .HasColumnName("ccuspostcode")
                    .HasMaxLength(20);

                entity.Property(e => e.Ccustradeccode)
                    .HasColumnName("ccustradeccode")
                    .HasMaxLength(12);

                entity.Property(e => e.Ccustradecname)
                    .HasColumnName("ccustradecname")
                    .HasMaxLength(50);

                entity.Property(e => e.Cdccode)
                    .HasColumnName("cdccode")
                    .HasMaxLength(12);

                entity.Property(e => e.Cdefine1)
                    .HasColumnName("cdefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cdefine10)
                    .HasColumnName("cdefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine11)
                    .HasColumnName("cdefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine12)
                    .HasColumnName("cdefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine13)
                    .HasColumnName("cdefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine14)
                    .HasColumnName("cdefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine15).HasColumnName("cdefine15");

                entity.Property(e => e.Cdefine16).HasColumnName("cdefine16");

                entity.Property(e => e.Cdefine2)
                    .HasColumnName("cdefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cdefine3)
                    .HasColumnName("cdefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cdefine4)
                    .HasColumnName("cdefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdefine5).HasColumnName("cdefine5");

                entity.Property(e => e.Cdefine6)
                    .HasColumnName("cdefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdefine7).HasColumnName("cdefine7");

                entity.Property(e => e.Cdefine8)
                    .HasColumnName("cdefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.Cdefine9)
                    .HasColumnName("cdefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.Cdeliverunit)
                    .HasColumnName("cdeliverunit")
                    .HasMaxLength(255);

                entity.Property(e => e.Cdepcode)
                    .IsRequired()
                    .HasColumnName("cdepcode")
                    .HasMaxLength(12);

                entity.Property(e => e.Cdepname)
                    .HasColumnName("cdepname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cdlcode)
                    .HasColumnName("cdlcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cebbuyer)
                    .HasColumnName("cebbuyer")
                    .HasMaxLength(2000);

                entity.Property(e => e.Cebbuyernote)
                    .HasColumnName("cebbuyernote")
                    .HasMaxLength(4000);

                entity.Property(e => e.Cebcity)
                    .HasColumnName("cebcity")
                    .HasMaxLength(20);

                entity.Property(e => e.Cebdistrict)
                    .HasColumnName("cebdistrict")
                    .HasMaxLength(60);

                entity.Property(e => e.Cebexpresscode)
                    .HasColumnName("cebexpresscode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cebprovince)
                    .HasColumnName("cebprovince")
                    .HasMaxLength(20);

                entity.Property(e => e.Cebtrnumber)
                    .HasColumnName("cebtrnumber")
                    .HasMaxLength(80);

                entity.Property(e => e.Cebweightunit)
                    .HasColumnName("cebweightunit")
                    .HasMaxLength(50);

                entity.Property(e => e.CexchName)
                    .IsRequired()
                    .HasColumnName("cexch_name")
                    .HasMaxLength(8);

                entity.Property(e => e.Cexpressconame)
                    .HasColumnName("cexpressconame")
                    .HasMaxLength(120);

                entity.Property(e => e.Cflowname)
                    .HasColumnName("cflowname")
                    .HasMaxLength(40);

                entity.Property(e => e.Cgatheringplan)
                    .HasColumnName("cgatheringplan")
                    .HasMaxLength(20);

                entity.Property(e => e.Cgatheringplanname)
                    .HasColumnName("cgatheringplanname")
                    .HasMaxLength(60);

                entity.Property(e => e.Cgathingcode)
                    .HasColumnName("cgathingcode")
                    .HasMaxLength(255);

                entity.Property(e => e.Cgcroutecode)
                    .HasColumnName("cgcroutecode")
                    .HasMaxLength(10);

                entity.Property(e => e.Cgcroutename)
                    .HasColumnName("cgcroutename")
                    .HasMaxLength(100);

                entity.Property(e => e.Cinvoicecompany)
                    .IsRequired()
                    .HasColumnName("cinvoicecompany")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvoicecompanyabbname)
                    .IsRequired()
                    .HasColumnName("cinvoicecompanyabbname")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvoicecusname)
                    .HasColumnName("cinvoicecusname")
                    .HasMaxLength(255);

                entity.Property(e => e.Clastcusname)
                    .HasColumnName("clastcusname")
                    .HasMaxLength(120);

                entity.Property(e => e.Clastcustname)
                    .HasColumnName("clastcustname")
                    .HasMaxLength(120);

                entity.Property(e => e.Cmaker)
                    .HasColumnName("cmaker")
                    .HasMaxLength(20);

                entity.Property(e => e.Cmemo)
                    .HasColumnName("cmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cmobilephone)
                    .HasColumnName("cmobilephone")
                    .HasMaxLength(100);

                entity.Property(e => e.Cmodifier)
                    .HasColumnName("cmodifier")
                    .HasMaxLength(20);

                entity.Property(e => e.Cofficephone)
                    .HasColumnName("cofficephone")
                    .HasMaxLength(100);

                entity.Property(e => e.Cpaycode)
                    .HasColumnName("cpaycode")
                    .HasMaxLength(3);

                entity.Property(e => e.Cpayname)
                    .HasColumnName("cpayname")
                    .HasMaxLength(60);

                entity.Property(e => e.Cpersoncode)
                    .HasColumnName("cpersoncode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cpersonname)
                    .HasColumnName("cpersonname")
                    .HasMaxLength(40);

                entity.Property(e => e.Cpsnmobilephone)
                    .HasColumnName("cpsnmobilephone")
                    .HasMaxLength(100);

                entity.Property(e => e.Cpsnophone)
                    .HasColumnName("cpsnophone")
                    .HasMaxLength(100);

                entity.Property(e => e.Crdcode)
                    .HasColumnName("crdcode")
                    .HasMaxLength(5);

                entity.Property(e => e.Csbvcode)
                    .HasColumnName("csbvcode")
                    .HasMaxLength(255);

                entity.Property(e => e.Csccode)
                    .HasColumnName("csccode")
                    .HasMaxLength(2);

                entity.Property(e => e.Cscname)
                    .HasColumnName("cscname")
                    .HasMaxLength(20);

                entity.Property(e => e.Cshipaddress)
                    .HasColumnName("cshipaddress")
                    .HasMaxLength(255);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(30);

                entity.Property(e => e.Csourcecode)
                    .HasColumnName("csourcecode")
                    .HasMaxLength(60);

                entity.Property(e => e.Csscode)
                    .HasColumnName("csscode")
                    .HasMaxLength(3);

                entity.Property(e => e.Cssname)
                    .HasColumnName("cssname")
                    .HasMaxLength(12);

                entity.Property(e => e.Cstcode)
                    .IsRequired()
                    .HasColumnName("cstcode")
                    .HasMaxLength(2);

                entity.Property(e => e.Cstname)
                    .HasColumnName("cstname")
                    .HasMaxLength(20);

                entity.Property(e => e.Csvouchtype)
                    .HasColumnName("csvouchtype")
                    .HasMaxLength(10);

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cverifier)
                    .HasColumnName("cverifier")
                    .HasMaxLength(20);

                entity.Property(e => e.Cvouchname)
                    .HasColumnName("cvouchname")
                    .HasMaxLength(150);

                entity.Property(e => e.Cvouchtype)
                    .IsRequired()
                    .HasColumnName("cvouchtype")
                    .HasMaxLength(2);

                entity.Property(e => e.Cweighter)
                    .HasColumnName("cweighter")
                    .HasMaxLength(40);

                entity.Property(e => e.Dcreatesystime)
                    .HasColumnName("dcreatesystime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dcreditstart)
                    .HasColumnName("dcreditstart")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ddate)
                    .HasColumnName("ddate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ddependdate)
                    .HasColumnName("ddependdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Denddate)
                    .HasColumnName("denddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dgatheringdate)
                    .HasColumnName("dgatheringdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dlid).HasColumnName("dlid");

                entity.Property(e => e.Dmoddate)
                    .HasColumnName("dmoddate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dmodifysystime)
                    .HasColumnName("dmodifysystime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dpinvaliddate)
                    .HasColumnName("dpinvaliddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dverifydate)
                    .HasColumnName("dverifydate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dverifysystime)
                    .HasColumnName("dverifysystime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dweighttime)
                    .HasColumnName("dweighttime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Febweight)
                    .HasColumnName("febweight")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Iarmoney).HasColumnName("iarmoney");

                entity.Property(e => e.Icreditdays).HasColumnName("icreditdays");

                entity.Property(e => e.Icreditstate)
                    .HasColumnName("icreditstate")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Icuscreline).HasColumnName("icuscreline");

                entity.Property(e => e.Iebexpresscoid).HasColumnName("iebexpresscoid");

                entity.Property(e => e.Iexchrate).HasColumnName("iexchrate");

                entity.Property(e => e.Iflowid).HasColumnName("iflowid");

                entity.Property(e => e.Inetlock).HasColumnName("inetlock");

                entity.Property(e => e.Ioutgolden).HasColumnName("ioutgolden");

                entity.Property(e => e.Iprintcount).HasColumnName("iprintcount");

                entity.Property(e => e.Ireturncount).HasColumnName("ireturncount");

                entity.Property(e => e.Isale).HasColumnName("isale");

                entity.Property(e => e.Iswfcontrolled).HasColumnName("iswfcontrolled");

                entity.Property(e => e.Itaxrate).HasColumnName("itaxrate");

                entity.Property(e => e.Iverifystate).HasColumnName("iverifystate");

                entity.Property(e => e.Ivouchstate)
                    .IsRequired()
                    .HasColumnName("ivouchstate")
                    .HasMaxLength(9);

                entity.Property(e => e.Ivtid).HasColumnName("ivtid");

                entity.Property(e => e.Linenum).HasColumnName("linenum");

                entity.Property(e => e.Outid)
                    .HasColumnName("outid")
                    .HasMaxLength(50);

                entity.Property(e => e.Sbvid).HasColumnName("sbvid");

                entity.Property(e => e.Separateid).HasColumnName("separateid");

                entity.Property(e => e.Signvtid)
                    .HasColumnName("signvtid")
                    .HasMaxLength(100);

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Zdsum)
                    .HasColumnName("zdsum")
                    .HasColumnType("decimal(26, 2)");
            });

            modelBuilder.Entity<SaDispatchmainmerp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("sa_dispatchmainmerp");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.CBusType)
                    .HasColumnName("cBusType")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepName)
                    .HasColumnName("cDepName")
                    .HasMaxLength(255);

                entity.Property(e => e.CDlcode)
                    .HasColumnName("cDLCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CPersonName)
                    .HasColumnName("cPersonName")
                    .HasMaxLength(40);

                entity.Property(e => e.CSccode)
                    .HasColumnName("cSCCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CShipAddress)
                    .HasColumnName("cShipAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.Ccusabbname)
                    .IsRequired()
                    .HasColumnName("ccusabbname")
                    .HasMaxLength(60);

                entity.Property(e => e.Ccusname)
                    .HasColumnName("ccusname")
                    .HasMaxLength(98);

                entity.Property(e => e.CexchName)
                    .IsRequired()
                    .HasColumnName("cexch_name")
                    .HasMaxLength(8);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dlid).HasColumnName("DLID");

                entity.Property(e => e.Iexchrate).HasColumnName("iexchrate");
            });

            modelBuilder.Entity<SaleOrderSq>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SaleOrderSQ");

                entity.Property(e => e.Autoid)
                    .HasColumnName("autoid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Ballpurchase).HasColumnName("ballpurchase");

                entity.Property(e => e.Batomodel)
                    .IsRequired()
                    .HasColumnName("batomodel")
                    .HasMaxLength(1);

                entity.Property(e => e.Bfree1).HasColumnName("bfree1");

                entity.Property(e => e.Bfree10).HasColumnName("bfree10");

                entity.Property(e => e.Bfree2).HasColumnName("bfree2");

                entity.Property(e => e.Bfree3).HasColumnName("bfree3");

                entity.Property(e => e.Bfree4).HasColumnName("bfree4");

                entity.Property(e => e.Bfree5).HasColumnName("bfree5");

                entity.Property(e => e.Bfree6).HasColumnName("bfree6");

                entity.Property(e => e.Bfree7).HasColumnName("bfree7");

                entity.Property(e => e.Bfree8).HasColumnName("bfree8");

                entity.Property(e => e.Bfree9).HasColumnName("bfree9");

                entity.Property(e => e.Bgift).HasColumnName("bgift");

                entity.Property(e => e.Binvbatch).HasColumnName("binvbatch");

                entity.Property(e => e.Binvmodel)
                    .IsRequired()
                    .HasColumnName("binvmodel")
                    .HasMaxLength(1);

                entity.Property(e => e.Binvtype).HasColumnName("binvtype");

                entity.Property(e => e.BodyOutid).HasColumnName("body_outid");

                entity.Property(e => e.Borderbom)
                    .IsRequired()
                    .HasColumnName("borderbom")
                    .HasMaxLength(1);

                entity.Property(e => e.Borderbomover).HasColumnName("borderbomover");

                entity.Property(e => e.Bproducebyfeatureallocate).HasColumnName("bproducebyfeatureallocate");

                entity.Property(e => e.Bproductbill).HasColumnName("bproductbill");

                entity.Property(e => e.Bproxyforeign).HasColumnName("bproxyforeign");

                entity.Property(e => e.Bptomodel)
                    .IsRequired()
                    .HasColumnName("bptomodel")
                    .HasMaxLength(1);

                entity.Property(e => e.Bsaleprice).HasColumnName("bsaleprice");

                entity.Property(e => e.Bsalepricefree1).HasColumnName("bsalepricefree1");

                entity.Property(e => e.Bsalepricefree10).HasColumnName("bsalepricefree10");

                entity.Property(e => e.Bsalepricefree2).HasColumnName("bsalepricefree2");

                entity.Property(e => e.Bsalepricefree3).HasColumnName("bsalepricefree3");

                entity.Property(e => e.Bsalepricefree4).HasColumnName("bsalepricefree4");

                entity.Property(e => e.Bsalepricefree5).HasColumnName("bsalepricefree5");

                entity.Property(e => e.Bsalepricefree6).HasColumnName("bsalepricefree6");

                entity.Property(e => e.Bsalepricefree7).HasColumnName("bsalepricefree7");

                entity.Property(e => e.Bsalepricefree8).HasColumnName("bsalepricefree8");

                entity.Property(e => e.Bsalepricefree9).HasColumnName("bsalepricefree9");

                entity.Property(e => e.Bservice).HasColumnName("bservice");

                entity.Property(e => e.Bspecialorder).HasColumnName("bspecialorder");

                entity.Property(e => e.Btrack).HasColumnName("btrack");

                entity.Property(e => e.Btracksalebill).HasColumnName("btracksalebill");

                entity.Property(e => e.Busecusbom).HasColumnName("busecusbom");

                entity.Property(e => e.Cbarcode)
                    .HasColumnName("cbarcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Cchildcode)
                    .HasColumnName("cchildcode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ccomunitcode)
                    .HasColumnName("ccomunitcode")
                    .HasMaxLength(35);

                entity.Property(e => e.Cconfigstatus)
                    .IsRequired()
                    .HasColumnName("cconfigstatus")
                    .HasMaxLength(3);

                entity.Property(e => e.Ccontractid)
                    .HasColumnName("ccontractid")
                    .HasMaxLength(64);

                entity.Property(e => e.Ccontractrowguid).HasColumnName("ccontractrowguid");

                entity.Property(e => e.Ccontracttagcode)
                    .HasColumnName("ccontracttagcode")
                    .HasMaxLength(150);

                entity.Property(e => e.Ccorvouchtype)
                    .HasColumnName("ccorvouchtype")
                    .HasMaxLength(10);

                entity.Property(e => e.Ccorvouchtypename)
                    .HasColumnName("ccorvouchtypename")
                    .HasMaxLength(150);

                entity.Property(e => e.Ccusinvcode)
                    .HasColumnName("ccusinvcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Ccusinvname)
                    .HasColumnName("ccusinvname")
                    .HasMaxLength(100);

                entity.Property(e => e.Cdefine22)
                    .HasColumnName("cdefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine23)
                    .HasColumnName("cdefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine24)
                    .HasColumnName("cdefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine25)
                    .HasColumnName("cdefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine26).HasColumnName("cdefine26");

                entity.Property(e => e.Cdefine27).HasColumnName("cdefine27");

                entity.Property(e => e.Cdefine28)
                    .HasColumnName("cdefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine29)
                    .HasColumnName("cdefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine30)
                    .HasColumnName("cdefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine31)
                    .HasColumnName("cdefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine32)
                    .HasColumnName("cdefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine33)
                    .HasColumnName("cdefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine34).HasColumnName("cdefine34");

                entity.Property(e => e.Cdefine35).HasColumnName("cdefine35");

                entity.Property(e => e.Cdefine36)
                    .HasColumnName("cdefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdefine37)
                    .HasColumnName("cdefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdemandcode)
                    .HasColumnName("cdemandcode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cdemandmemo)
                    .HasColumnName("cdemandmemo")
                    .HasMaxLength(300);

                entity.Property(e => e.Cdetailsdemandcode)
                    .HasColumnName("cdetailsdemandcode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cdetailsdemandmemo)
                    .HasColumnName("cdetailsdemandmemo")
                    .HasMaxLength(300);

                entity.Property(e => e.Cfactorycode)
                    .HasColumnName("cfactorycode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cfactoryname)
                    .HasColumnName("cfactoryname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cfree1)
                    .HasColumnName("cfree1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree10)
                    .HasColumnName("cfree10")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree2)
                    .HasColumnName("cfree2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree3)
                    .HasColumnName("cfree3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree4)
                    .HasColumnName("cfree4")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree5)
                    .HasColumnName("cfree5")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree6)
                    .HasColumnName("cfree6")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree7)
                    .HasColumnName("cfree7")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree8)
                    .HasColumnName("cfree8")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree9)
                    .HasColumnName("cfree9")
                    .HasMaxLength(20);

                entity.Property(e => e.Cgroupcode)
                    .HasColumnName("cgroupcode")
                    .HasMaxLength(35);

                entity.Property(e => e.CinvaUnit)
                    .HasColumnName("cinva_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvaddcode)
                    .HasColumnName("cinvaddcode")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvauthid).HasColumnName("cinvauthid");

                entity.Property(e => e.Cinvcode)
                    .HasColumnName("cinvcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine1)
                    .HasColumnName("cinvdefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine10)
                    .HasColumnName("cinvdefine10")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine11).HasColumnName("cinvdefine11");

                entity.Property(e => e.Cinvdefine12).HasColumnName("cinvdefine12");

                entity.Property(e => e.Cinvdefine13).HasColumnName("cinvdefine13");

                entity.Property(e => e.Cinvdefine14).HasColumnName("cinvdefine14");

                entity.Property(e => e.Cinvdefine15)
                    .HasColumnName("cinvdefine15")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cinvdefine16)
                    .HasColumnName("cinvdefine16")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cinvdefine2)
                    .HasColumnName("cinvdefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine3)
                    .HasColumnName("cinvdefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine4)
                    .HasColumnName("cinvdefine4")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine5)
                    .HasColumnName("cinvdefine5")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine6)
                    .HasColumnName("cinvdefine6")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine7)
                    .HasColumnName("cinvdefine7")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine8)
                    .HasColumnName("cinvdefine8")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine9)
                    .HasColumnName("cinvdefine9")
                    .HasMaxLength(120);

                entity.Property(e => e.CinvmUnit)
                    .HasColumnName("cinvm_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvname)
                    .HasColumnName("cinvname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvstd)
                    .HasColumnName("cinvstd")
                    .HasMaxLength(255);

                entity.Property(e => e.CitemClass)
                    .HasColumnName("citem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CitemCname)
                    .HasColumnName("citem_cname")
                    .HasMaxLength(20);

                entity.Property(e => e.Citemcode)
                    .HasColumnName("citemcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Citemname)
                    .HasColumnName("citemname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cmdepcode)
                    .HasColumnName("cmdepcode")
                    .HasMaxLength(12);

                entity.Property(e => e.Cmdepname)
                    .HasColumnName("cmdepname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cmemo)
                    .HasColumnName("cmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cordercode)
                    .HasColumnName("cordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cparentcode)
                    .HasColumnName("cparentcode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cpreordercode)
                    .HasColumnName("cpreordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cquocode)
                    .HasColumnName("cquocode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cscloser)
                    .IsRequired()
                    .HasColumnName("cscloser")
                    .HasMaxLength(20);

                entity.Property(e => e.Csrpolicy)
                    .HasColumnName("csrpolicy")
                    .HasMaxLength(2);

                entity.Property(e => e.Cunitid)
                    .HasColumnName("cunitid")
                    .HasMaxLength(35);

                entity.Property(e => e.Cvenabbname)
                    .HasColumnName("cvenabbname")
                    .HasMaxLength(60);

                entity.Property(e => e.Cvencode)
                    .HasColumnName("cvencode")
                    .HasMaxLength(20);

                entity.Property(e => e.Cvenname)
                    .HasColumnName("cvenname")
                    .HasMaxLength(98);

                entity.Property(e => e.Dbclosedate)
                    .HasColumnName("dbclosedate")
                    .HasMaxLength(10);

                entity.Property(e => e.Dbclosesystime)
                    .HasColumnName("dbclosesystime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dedate)
                    .HasColumnName("dedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dkl1)
                    .HasColumnName("dkl1")
                    .HasColumnType("decimal(31, 10)");

                entity.Property(e => e.Dkl2)
                    .HasColumnName("dkl2")
                    .HasColumnType("decimal(31, 10)");

                entity.Property(e => e.Dpredate)
                    .HasColumnName("dpredate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dpremodate)
                    .HasColumnName("dpremodate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dreleasedate)
                    .HasColumnName("dreleasedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fappqty)
                    .HasColumnName("fappqty")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fcanusequan)
                    .HasColumnName("fcanusequan")
                    .HasColumnType("decimal(38, 9)");

                entity.Property(e => e.Fcanusequano)
                    .HasColumnName("fcanusequano")
                    .HasColumnType("decimal(38, 9)");

                entity.Property(e => e.Fchildqty)
                    .HasColumnName("fchildqty")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fchildrate)
                    .HasColumnName("fchildrate")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fcusminprice)
                    .HasColumnName("fcusminprice")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Fimquantity)
                    .HasColumnName("fimquantity")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Finquantity)
                    .HasColumnName("finquantity")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Fomquantity)
                    .HasColumnName("fomquantity")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Forecastdid).HasColumnName("forecastdid");

                entity.Property(e => e.Foutquantity)
                    .HasColumnName("foutquantity")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Fpurquan)
                    .HasColumnName("fpurquan")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fretnum)
                    .HasColumnName("fretnum")
                    .HasColumnType("decimal(38, 9)");

                entity.Property(e => e.Fretquantity)
                    .HasColumnName("fretquantity")
                    .HasColumnType("decimal(29, 6)");

                entity.Property(e => e.Fsalecost)
                    .HasColumnName("fsalecost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fsaleprice)
                    .HasColumnName("fsaleprice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fstockquan)
                    .HasColumnName("fstockquan")
                    .HasColumnType("decimal(38, 9)");

                entity.Property(e => e.Fstockquano)
                    .HasColumnName("fstockquano")
                    .HasColumnType("decimal(38, 9)");

                entity.Property(e => e.Gcsourceid).HasColumnName("gcsourceid");

                entity.Property(e => e.Gcsourceids).HasColumnName("gcsourceids");

                entity.Property(e => e.Iadvancedate).HasColumnName("iadvancedate");

                entity.Property(e => e.Iaoids).HasColumnName("iaoids");

                entity.Property(e => e.Icalctype).HasColumnName("icalctype");

                entity.Property(e => e.Icorrowno).HasColumnName("icorrowno");

                entity.Property(e => e.Icurpartid).HasColumnName("icurpartid");

                entity.Property(e => e.Icusbomid).HasColumnName("icusbomid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idemandtype).HasColumnName("idemandtype");

                entity.Property(e => e.Idiscount)
                    .HasColumnName("idiscount")
                    .HasColumnType("money");

                entity.Property(e => e.Iexchsum)
                    .HasColumnName("iexchsum")
                    .HasColumnType("money");

                entity.Property(e => e.Ifhmoney)
                    .HasColumnName("ifhmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Ifhnum)
                    .HasColumnName("ifhnum")
                    .HasColumnType("decimal(38, 12)");

                entity.Property(e => e.Ifhquantity)
                    .HasColumnName("ifhquantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Igrouptype).HasColumnName("igrouptype");

                entity.Property(e => e.Iimid).HasColumnName("iimid");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iinvid).HasColumnName("iinvid");

                entity.Property(e => e.Iinvlscost).HasColumnName("iinvlscost");

                entity.Property(e => e.Iinvncost).HasColumnName("iinvncost");

                entity.Property(e => e.Iinvsprice).HasColumnName("iinvsprice");

                entity.Property(e => e.Ikpmoney)
                    .HasColumnName("ikpmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Ikpnum)
                    .HasColumnName("ikpnum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ikpquantity)
                    .HasColumnName("ikpquantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Imoney)
                    .HasColumnName("imoney")
                    .HasColumnType("money");

                entity.Property(e => e.Imoneysum)
                    .HasColumnName("imoneysum")
                    .HasColumnType("money");

                entity.Property(e => e.Imoquantity)
                    .HasColumnName("imoquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Inatdiscount)
                    .HasColumnName("inatdiscount")
                    .HasColumnType("money");

                entity.Property(e => e.Inatmoney)
                    .HasColumnName("inatmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Inatsum)
                    .HasColumnName("inatsum")
                    .HasColumnType("money");

                entity.Property(e => e.Inattax)
                    .HasColumnName("inattax")
                    .HasColumnType("money");

                entity.Property(e => e.Inatunitprice)
                    .HasColumnName("inatunitprice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Inum)
                    .HasColumnName("inum")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Ippartid).HasColumnName("ippartid");

                entity.Property(e => e.Ippartqty)
                    .HasColumnName("ippartqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Ippartseqid).HasColumnName("ippartseqid");

                entity.Property(e => e.Iprekeepnum)
                    .HasColumnName("iprekeepnum")
                    .HasColumnType("decimal(38, 10)");

                entity.Property(e => e.Iprekeepquantity)
                    .HasColumnName("iprekeepquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iprekeeptotnum)
                    .HasColumnName("iprekeeptotnum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iprekeeptotquantity)
                    .HasColumnName("iprekeeptotquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iquantity)
                    .HasColumnName("iquantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Iquoid).HasColumnName("iquoid");

                entity.Property(e => e.Iquotedprice)
                    .HasColumnName("iquotedprice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isosid).HasColumnName("isosid");

                entity.Property(e => e.Isum)
                    .HasColumnName("isum")
                    .HasColumnType("money");

                entity.Property(e => e.Itax)
                    .HasColumnName("itax")
                    .HasColumnType("money");

                entity.Property(e => e.Itaxrate)
                    .HasColumnName("itaxrate")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Itaxunitprice)
                    .HasColumnName("itaxunitprice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Iunitprice)
                    .HasColumnName("iunitprice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Kl)
                    .HasColumnName("kl")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Kl2)
                    .HasColumnName("kl2")
                    .HasColumnType("decimal(30, 10)");
            });

            modelBuilder.Entity<ScmItem>(entity =>
            {
                entity.HasKey(e => new { e.CInvCode, e.Id })
                    .HasName("PK_Item");

                entity.ToTable("SCM_Item");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_Item_1")
                    .IsUnique();

                entity.HasIndex(e => e.PartId)
                    .HasName("Index_2");

                entity.HasIndex(e => new { e.CInvCode, e.CFree1, e.CFree2, e.CFree3, e.CFree4, e.CFree5, e.CFree6, e.CFree7, e.CFree8, e.CFree9, e.CFree10 })
                    .HasName("IX_Item")
                    .IsUnique();

                entity.Property(e => e.CInvCode)
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CFree1)
                    .IsRequired()
                    .HasColumnName("cFree1")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree10)
                    .IsRequired()
                    .HasColumnName("cFree10")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree2)
                    .IsRequired()
                    .HasColumnName("cFree2")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree3)
                    .IsRequired()
                    .HasColumnName("cFree3")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree4)
                    .IsRequired()
                    .HasColumnName("cFree4")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree5)
                    .IsRequired()
                    .HasColumnName("cFree5")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree6)
                    .IsRequired()
                    .HasColumnName("cFree6")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree7)
                    .IsRequired()
                    .HasColumnName("cFree7")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree8)
                    .IsRequired()
                    .HasColumnName("cFree8")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CFree9)
                    .IsRequired()
                    .HasColumnName("cFree9")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PartId).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<SoSodetails>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("aaaaaSO_SODetails_PK")
                    .IsClustered(false);

                entity.ToTable("SO_SODetails");

                entity.HasIndex(e => e.CChildCode)
                    .HasName("IX_so_sodetails_cChildCode");

                entity.HasIndex(e => e.CInvCode)
                    .HasName("InventorySO_SODetails");

                entity.HasIndex(e => e.CParentCode)
                    .HasName("IX_so_sodetails_cParentCode");

                entity.HasIndex(e => e.CScloser)
                    .HasName("ix_sodetailcScloser");

                entity.HasIndex(e => e.CSocode)
                    .HasName("IX_so_sodetails_csocode");

                entity.HasIndex(e => e.Ccorvouchtype)
                    .HasName("IX_so_sodetails_ccorvouchtype");

                entity.HasIndex(e => e.ISosId)
                    .HasName("ix_sodetail_isosid")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => e.Id)
                    .HasName("SODetail_ID");

                entity.HasIndex(e => new { e.Icorrowno, e.Ccorvouchtype, e.CChildCode })
                    .HasName("idx_ebtypeidcode");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.BFh).HasColumnName("bFH");

                entity.Property(e => e.BOrderBom).HasColumnName("bOrderBOM");

                entity.Property(e => e.BOrderBomover).HasColumnName("bOrderBOMOver");

                entity.Property(e => e.Ballpurchase).HasColumnName("ballpurchase");

                entity.Property(e => e.Bgift).HasColumnName("bgift");

                entity.Property(e => e.BodyOutid).HasColumnName("body_outid");

                entity.Property(e => e.Bsaleprice).HasColumnName("bsaleprice");

                entity.Property(e => e.Busecusbom).HasColumnName("busecusbom");

                entity.Property(e => e.CChildCode)
                    .HasColumnName("cChildCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CContractId)
                    .HasColumnName("cContractID")
                    .HasMaxLength(64);

                entity.Property(e => e.CContractRowGuid).HasColumnName("cContractRowGuid");

                entity.Property(e => e.CContractTagCode)
                    .HasColumnName("cContractTagCode")
                    .HasMaxLength(150);

                entity.Property(e => e.CCusInvCode)
                    .HasColumnName("cCusInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CCusInvName)
                    .HasColumnName("cCusInvName")
                    .HasMaxLength(100);

                entity.Property(e => e.CDefine22)
                    .HasColumnName("cDefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine23)
                    .HasColumnName("cDefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine24)
                    .HasColumnName("cDefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine25)
                    .HasColumnName("cDefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine26).HasColumnName("cDefine26");

                entity.Property(e => e.CDefine27).HasColumnName("cDefine27");

                entity.Property(e => e.CDefine28)
                    .HasColumnName("cDefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine29)
                    .HasColumnName("cDefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine30)
                    .HasColumnName("cDefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine31)
                    .HasColumnName("cDefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine32)
                    .HasColumnName("cDefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine33)
                    .HasColumnName("cDefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine34).HasColumnName("cDefine34");

                entity.Property(e => e.CDefine35).HasColumnName("cDefine35");

                entity.Property(e => e.CDefine36)
                    .HasColumnName("cDefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine37)
                    .HasColumnName("cDefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.CFactoryCode)
                    .HasColumnName("cFactoryCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CInvCode)
                    .HasColumnName("cInvCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CInvName)
                    .HasColumnName("cInvName")
                    .HasMaxLength(255);

                entity.Property(e => e.CItemClass)
                    .HasColumnName("cItem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CItemCname)
                    .HasColumnName("cItem_CName")
                    .HasMaxLength(20);

                entity.Property(e => e.CItemCode)
                    .HasColumnName("cItemCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CItemName)
                    .HasColumnName("cItemName")
                    .HasMaxLength(255);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CParentCode)
                    .HasColumnName("cParentCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CQuoCode)
                    .HasColumnName("cQuoCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CScloser)
                    .HasColumnName("cSCloser")
                    .HasMaxLength(20);

                entity.Property(e => e.CSocode)
                    .HasColumnName("cSOCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CUnitId)
                    .HasColumnName("cUnitID")
                    .HasMaxLength(35);

                entity.Property(e => e.CbSysBarCode)
                    .HasColumnName("cbSysBarCode")
                    .HasMaxLength(80);

                entity.Property(e => e.Ccorvouchtype)
                    .HasColumnName("ccorvouchtype")
                    .HasMaxLength(10);

                entity.Property(e => e.Cdemandcode)
                    .HasColumnName("cdemandcode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cdemandmemo)
                    .HasColumnName("cdemandmemo")
                    .HasMaxLength(300);

                entity.Property(e => e.Cdetailsdemandcode)
                    .HasColumnName("cdetailsdemandcode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cdetailsdemandmemo)
                    .HasColumnName("cdetailsdemandmemo")
                    .HasMaxLength(300);

                entity.Property(e => e.Cpreordercode)
                    .HasColumnName("cpreordercode")
                    .HasMaxLength(30);

                entity.Property(e => e.DPreDate)
                    .HasColumnName("dPreDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DPreMoDate)
                    .HasColumnName("dPreMoDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dbclosedate)
                    .HasColumnName("dbclosedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dbclosesystime)
                    .HasColumnName("dbclosesystime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dreleasedate)
                    .HasColumnName("dreleasedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dufts)
                    .HasColumnName("dufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.FPurBillQty)
                    .HasColumnName("fPurBillQty")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.FPurBillSum)
                    .HasColumnName("fPurBillSum")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.FPurSum)
                    .HasColumnName("fPurSum")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.FSaleCost)
                    .HasColumnName("fSaleCost")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.FSalePrice)
                    .HasColumnName("fSalePrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.FTransedQty)
                    .HasColumnName("fTransedQty")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.FVeriDispQty)
                    .HasColumnName("fVeriDispQty")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.FVeriDispSum)
                    .HasColumnName("fVeriDispSum")
                    .HasColumnType("money");

                entity.Property(e => e.Fappqty)
                    .HasColumnName("fappqty")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fchildqty)
                    .HasColumnName("fchildqty")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fchildrate)
                    .HasColumnName("fchildrate")
                    .HasColumnType("decimal(30, 9)");

                entity.Property(e => e.Fcusminprice)
                    .HasColumnName("fcusminprice")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Fimquantity)
                    .HasColumnName("fimquantity")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Finquantity)
                    .HasColumnName("finquantity")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Fomquantity)
                    .HasColumnName("fomquantity")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Forecastdid).HasColumnName("forecastdid");

                entity.Property(e => e.Foutnum)
                    .HasColumnName("foutnum")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Foutquantity)
                    .HasColumnName("foutquantity")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.FpurQuan)
                    .HasColumnName("FPurQuan")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fretnum)
                    .HasColumnName("fretnum")
                    .HasColumnType("decimal(29, 6)");

                entity.Property(e => e.Fretquantity)
                    .HasColumnName("fretquantity")
                    .HasColumnType("decimal(29, 6)");

                entity.Property(e => e.GcsourceId).HasColumnName("GCSourceId");

                entity.Property(e => e.GcsourceIds).HasColumnName("GCSourceIds");

                entity.Property(e => e.ICalcType).HasColumnName("iCalcType");

                entity.Property(e => e.ICurPartid).HasColumnName("iCurPartid");

                entity.Property(e => e.ICusBomId).HasColumnName("iCusBomID");

                entity.Property(e => e.IDisCount)
                    .HasColumnName("iDisCount")
                    .HasColumnType("money");

                entity.Property(e => e.IFhmoney)
                    .HasColumnName("iFHMoney")
                    .HasColumnType("money");

                entity.Property(e => e.IFhnum)
                    .HasColumnName("iFHNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IFhquantity)
                    .HasColumnName("iFHQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IInvExchRate)
                    .HasColumnName("iInvExchRate")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IKpmoney)
                    .HasColumnName("iKPMoney")
                    .HasColumnType("money");

                entity.Property(e => e.IKpnum)
                    .HasColumnName("iKPNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IKpquantity)
                    .HasColumnName("iKPQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IMoQuantity)
                    .HasColumnName("iMoQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IMoney)
                    .HasColumnName("iMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INatDisCount)
                    .HasColumnName("iNatDisCount")
                    .HasColumnType("money");

                entity.Property(e => e.INatMoney)
                    .HasColumnName("iNatMoney")
                    .HasColumnType("money");

                entity.Property(e => e.INatSum)
                    .HasColumnName("iNatSum")
                    .HasColumnType("money");

                entity.Property(e => e.INatTax)
                    .HasColumnName("iNatTax")
                    .HasColumnType("money");

                entity.Property(e => e.INatUnitPrice)
                    .HasColumnName("iNatUnitPrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.INum)
                    .HasColumnName("iNum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IPpartId).HasColumnName("iPPartID");

                entity.Property(e => e.IPpartQty)
                    .HasColumnName("iPPartQty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IPpartSeqId).HasColumnName("iPPartSeqID");

                entity.Property(e => e.IPreKeepNum)
                    .HasColumnName("iPreKeepNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IPreKeepQuantity)
                    .HasColumnName("iPreKeepQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IPreKeepTotNum)
                    .HasColumnName("iPreKeepTotNum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IPreKeepTotQuantity)
                    .HasColumnName("iPreKeepTotQuantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IQuantity)
                    .HasColumnName("iQuantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IQuoId).HasColumnName("iQuoID");

                entity.Property(e => e.IQuotedPrice)
                    .HasColumnName("iQuotedPrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IRowNo).HasColumnName("iRowNo");

                entity.Property(e => e.ISosId)
                    .HasColumnName("iSOsID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ISum)
                    .HasColumnName("iSum")
                    .HasColumnType("money");

                entity.Property(e => e.ITax)
                    .HasColumnName("iTax")
                    .HasColumnType("money");

                entity.Property(e => e.ITaxRate)
                    .HasColumnName("iTaxRate")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ITaxUnitPrice)
                    .HasColumnName("iTaxUnitPrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.IUnitPrice)
                    .HasColumnName("iUnitPrice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Iaoids).HasColumnName("iaoids");

                entity.Property(e => e.Icorrowno).HasColumnName("icorrowno");

                entity.Property(e => e.Icostquantity)
                    .HasColumnName("icostquantity")
                    .HasColumnType("decimal(26, 9)");

                entity.Property(e => e.Icostsum)
                    .HasColumnName("icostsum")
                    .HasColumnType("money");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idemandtype).HasColumnName("idemandtype");

                entity.Property(e => e.Iexchsum)
                    .HasColumnName("iexchsum")
                    .HasColumnType("money");

                entity.Property(e => e.Iimid).HasColumnName("iimid");

                entity.Property(e => e.Imoneysum)
                    .HasColumnName("imoneysum")
                    .HasColumnType("money");

                entity.Property(e => e.Kl)
                    .HasColumnName("KL")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Kl2)
                    .HasColumnName("KL2")
                    .HasColumnType("decimal(30, 10)")
                    .HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<SoSomain>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("SO_SOMain");

                entity.HasIndex(e => e.CBusType)
                    .HasName("ix_somain_cbustype");

                entity.HasIndex(e => e.CCusCode)
                    .HasName("CustomerSO_SOMain");

                entity.HasIndex(e => e.CDepCode)
                    .HasName("DepartmentSO_SOMain");

                entity.HasIndex(e => e.CEbtrnumber)
                    .HasName("ix_so_somain_cEBTrnumber");

                entity.HasIndex(e => e.CPayCode)
                    .HasName("PayConditionSO_SOMain");

                entity.HasIndex(e => e.CPersonCode)
                    .HasName("PersonSO_SOMain");

                entity.HasIndex(e => e.CSccode)
                    .HasName("ShippingChoiceSO_SOMain");

                entity.HasIndex(e => e.CSocode)
                    .HasName("inx_so_somain_csocode")
                    .IsUnique();

                entity.HasIndex(e => e.CStcode)
                    .HasName("SaleTypeSO_SOMain");

                entity.HasIndex(e => e.CexchName)
                    .HasName("foreigncurrencySO_SOMain");

                entity.HasIndex(e => e.DDate)
                    .HasName("dDate");

                entity.HasIndex(e => e.IStatus)
                    .HasName("iStatus");

                entity.HasIndex(e => e.Id)
                    .HasName("ix_somain_ID")
                    .IsClustered();

                entity.HasIndex(e => e.Ufts)
                    .HasName("uftsso_somain");

                entity.HasIndex(e => new { e.CVerifier, e.CCloser })
                    .HasName("ix_somain_cVerifier_ccloser");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BDisFlag).HasColumnName("bDisFlag");

                entity.Property(e => e.BOrder)
                    .HasColumnName("bOrder")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BReturnFlag)
                    .IsRequired()
                    .HasColumnName("bReturnFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Bcashsale).HasColumnName("bcashsale");

                entity.Property(e => e.Bmustbook).HasColumnName("bmustbook");

                entity.Property(e => e.CAttachment)
                    .HasColumnName("cAttachment")
                    .HasMaxLength(255);

                entity.Property(e => e.CBusType)
                    .IsRequired()
                    .HasColumnName("cBusType")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("('普通销售')");

                entity.Property(e => e.CChangeVerifier)
                    .HasColumnName("cChangeVerifier")
                    .HasMaxLength(20);

                entity.Property(e => e.CChanger)
                    .HasColumnName("cChanger")
                    .HasMaxLength(20);

                entity.Property(e => e.CCloser)
                    .HasColumnName("cCloser")
                    .HasMaxLength(20);

                entity.Property(e => e.CCreChpName)
                    .HasColumnName("cCreChpName")
                    .HasMaxLength(20);

                entity.Property(e => e.CCrmPersonCode)
                    .HasColumnName("cCrmPersonCode")
                    .HasMaxLength(255);

                entity.Property(e => e.CCrmPersonName)
                    .HasColumnName("cCrmPersonName")
                    .HasMaxLength(255);

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.CCusCode)
                    .HasColumnName("cCusCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CCusName)
                    .HasColumnName("cCusName")
                    .HasMaxLength(120);

                entity.Property(e => e.CCusOaddress)
                    .HasColumnName("cCusOAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7).HasColumnName("cDefine7");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CDepCode)
                    .IsRequired()
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CEbbuyer)
                    .HasColumnName("cEBBuyer")
                    .HasMaxLength(2000);

                entity.Property(e => e.CEbbuyerNote)
                    .HasColumnName("cEBBuyerNote")
                    .HasMaxLength(4000);

                entity.Property(e => e.CEbcity)
                    .HasColumnName("cEBcity")
                    .HasMaxLength(20);

                entity.Property(e => e.CEbdistrict)
                    .HasColumnName("cEBdistrict")
                    .HasMaxLength(60);

                entity.Property(e => e.CEbprovince)
                    .HasColumnName("cEBprovince")
                    .HasMaxLength(20);

                entity.Property(e => e.CEbtrnumber)
                    .HasColumnName("cEBTrnumber")
                    .HasMaxLength(80);

                entity.Property(e => e.CGcrouteCode)
                    .HasColumnName("cGCRouteCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CInvoiceCusName)
                    .HasColumnName("cInvoiceCusName")
                    .HasMaxLength(255);

                entity.Property(e => e.CLocker)
                    .HasColumnName("cLocker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMainPersonCode)
                    .HasColumnName("cMainPersonCode")
                    .HasMaxLength(255);

                entity.Property(e => e.CMaker)
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CPayCode)
                    .HasColumnName("cPayCode")
                    .HasMaxLength(3);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CSccode)
                    .HasColumnName("cSCCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CSocode)
                    .HasColumnName("cSOCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CStcode)
                    .IsRequired()
                    .HasColumnName("cSTCode")
                    .HasMaxLength(2);

                entity.Property(e => e.CSysBarCode)
                    .HasColumnName("cSysBarCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CVerifier)
                    .HasColumnName("cVerifier")
                    .HasMaxLength(20);

                entity.Property(e => e.Caddcode)
                    .HasColumnName("caddcode")
                    .HasMaxLength(30);

                entity.Property(e => e.Cbcode)
                    .HasColumnName("cbcode")
                    .HasMaxLength(3);

                entity.Property(e => e.Ccontactname)
                    .HasColumnName("ccontactname")
                    .HasMaxLength(255);

                entity.Property(e => e.Ccusperson)
                    .HasColumnName("ccusperson")
                    .HasMaxLength(100);

                entity.Property(e => e.Ccuspersoncode)
                    .HasColumnName("ccuspersoncode")
                    .HasMaxLength(30);

                entity.Property(e => e.CexchName)
                    .IsRequired()
                    .HasColumnName("cexch_name")
                    .HasMaxLength(8);

                entity.Property(e => e.Cgatheringplan)
                    .HasColumnName("cgatheringplan")
                    .HasMaxLength(20);

                entity.Property(e => e.Cgathingcode)
                    .HasColumnName("cgathingcode")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvoicecompany)
                    .HasColumnName("cinvoicecompany")
                    .HasMaxLength(20);

                entity.Property(e => e.Cmobilephone)
                    .HasColumnName("cmobilephone")
                    .HasMaxLength(50);

                entity.Property(e => e.Cmodifier)
                    .HasColumnName("cmodifier")
                    .HasMaxLength(20);

                entity.Property(e => e.ContractStatus).HasColumnName("contract_status");

                entity.Property(e => e.Coppcode)
                    .HasColumnName("coppcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Csscode)
                    .HasColumnName("csscode")
                    .HasMaxLength(3);

                entity.Property(e => e.Csvouchtype)
                    .HasColumnName("csvouchtype")
                    .HasMaxLength(10);

                entity.Property(e => e.DChangeVerifyDate)
                    .HasColumnName("dChangeVerifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DChangeVerifyTime)
                    .HasColumnName("dChangeVerifyTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDate)
                    .HasColumnName("dDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DPreDateBt)
                    .HasColumnName("dPreDateBT")
                    .HasColumnType("datetime");

                entity.Property(e => e.DPreMoDateBt)
                    .HasColumnName("dPreMoDateBT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dclosedate)
                    .HasColumnName("dclosedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dclosesystime)
                    .HasColumnName("dclosesystime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dcreatesystime)
                    .HasColumnName("dcreatesystime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dmoddate)
                    .HasColumnName("dmoddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dmodifysystime)
                    .HasColumnName("dmodifysystime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dverifydate)
                    .HasColumnName("dverifydate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dverifysystime)
                    .HasColumnName("dverifysystime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fbooknatsum)
                    .HasColumnName("fbooknatsum")
                    .HasColumnType("money");

                entity.Property(e => e.Fbookratio).HasColumnName("fbookratio");

                entity.Property(e => e.Fbooksum)
                    .HasColumnName("fbooksum")
                    .HasColumnType("money");

                entity.Property(e => e.Fgbooknatsum)
                    .HasColumnName("fgbooknatsum")
                    .HasColumnType("money");

                entity.Property(e => e.Fgbooksum)
                    .HasColumnName("fgbooksum")
                    .HasColumnType("money");

                entity.Property(e => e.IExchRate).HasColumnName("iExchRate");

                entity.Property(e => e.IMoney)
                    .HasColumnName("iMoney")
                    .HasColumnType("money");

                entity.Property(e => e.IPrintCount).HasColumnName("iPrintCount");

                entity.Property(e => e.IStatus).HasColumnName("iStatus");

                entity.Property(e => e.ITaxRate).HasColumnName("iTaxRate");

                entity.Property(e => e.IVtid)
                    .HasColumnName("iVTid")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Icreditstate)
                    .HasColumnName("icreditstate")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Iflowid).HasColumnName("iflowid");

                entity.Property(e => e.Ioppid).HasColumnName("ioppid");

                entity.Property(e => e.Ireturncount)
                    .HasColumnName("ireturncount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iswfcontrolled)
                    .HasColumnName("iswfcontrolled")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iverifystate)
                    .HasColumnName("iverifystate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OptntyName)
                    .HasColumnName("optnty_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Outid).HasColumnName("outid");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CDepCodeNavigation)
                    .WithMany(p => p.SoSomain)
                    .HasForeignKey(d => d.CDepCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SO_SOMain__cDepC__3B8BB150");

                entity.HasOne(d => d.CPersonCodeNavigation)
                    .WithMany(p => p.SoSomain)
                    .HasForeignKey(d => d.CPersonCode)
                    .HasConstraintName("FK__SO_SOMain__cPers__19018F22");
            });

            modelBuilder.Entity<TransVouch>(entity =>
            {
                entity.HasKey(e => e.CTvcode)
                    .HasName("aaaaaTransVouch_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CIdepCode)
                    .HasName("DepartmentTransVouch1");

                entity.HasIndex(e => e.CIrdCode)
                    .HasName("Rd_StyleTransVouch");

                entity.HasIndex(e => e.CIwhCode)
                    .HasName("WarehouseTransVouch1");

                entity.HasIndex(e => e.COdepCode)
                    .HasName("DepartmentTransVouch");

                entity.HasIndex(e => e.COrdCode)
                    .HasName("Rd_StyleTransVouch1");

                entity.HasIndex(e => e.COwhCode)
                    .HasName("WarehouseTransVouch");

                entity.HasIndex(e => e.CPersonCode)
                    .HasName("PersonTransVouch");

                entity.HasIndex(e => e.DTvdate)
                    .HasName("dTVDate");

                entity.HasIndex(e => e.Id)
                    .HasName("tRid")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.CTvcode)
                    .HasColumnName("cTVCode")
                    .HasMaxLength(30);

                entity.Property(e => e.BTransFlag).HasColumnName("bTransFlag");

                entity.Property(e => e.CAccounter)
                    .HasColumnName("cAccounter")
                    .HasMaxLength(20);

                entity.Property(e => e.CAppTvcode)
                    .HasColumnName("cAppTVCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCurrentAuditor)
                    .HasColumnName("cCurrentAuditor")
                    .HasMaxLength(200);

                entity.Property(e => e.CDefine1)
                    .HasColumnName("cDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine10)
                    .HasColumnName("cDefine10")
                    .HasMaxLength(60);

                entity.Property(e => e.CDefine11)
                    .HasColumnName("cDefine11")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine12)
                    .HasColumnName("cDefine12")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine13)
                    .HasColumnName("cDefine13")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine14)
                    .HasColumnName("cDefine14")
                    .HasMaxLength(120);

                entity.Property(e => e.CDefine15).HasColumnName("cDefine15");

                entity.Property(e => e.CDefine16).HasColumnName("cDefine16");

                entity.Property(e => e.CDefine2)
                    .HasColumnName("cDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine3)
                    .HasColumnName("cDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CDefine4)
                    .HasColumnName("cDefine4")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine5).HasColumnName("cDefine5");

                entity.Property(e => e.CDefine6)
                    .HasColumnName("cDefine6")
                    .HasColumnType("datetime");

                entity.Property(e => e.CDefine7).HasColumnName("cDefine7");

                entity.Property(e => e.CDefine8)
                    .HasColumnName("cDefine8")
                    .HasMaxLength(4);

                entity.Property(e => e.CDefine9)
                    .HasColumnName("cDefine9")
                    .HasMaxLength(8);

                entity.Property(e => e.CFree1)
                    .HasColumnName("cFree1")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree10)
                    .HasColumnName("cFree10")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree2)
                    .HasColumnName("cFree2")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree3)
                    .HasColumnName("cFree3")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree4)
                    .HasColumnName("cFree4")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree5)
                    .HasColumnName("cFree5")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree6)
                    .HasColumnName("cFree6")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree7)
                    .HasColumnName("cFree7")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree8)
                    .HasColumnName("cFree8")
                    .HasMaxLength(20);

                entity.Property(e => e.CFree9)
                    .HasColumnName("cFree9")
                    .HasMaxLength(20);

                entity.Property(e => e.CIdepCode)
                    .HasColumnName("cIDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CIrdCode)
                    .HasColumnName("cIRdCode")
                    .HasMaxLength(5);

                entity.Property(e => e.CIwhCode)
                    .IsRequired()
                    .HasColumnName("cIWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CMaker)
                    .HasColumnName("cMaker")
                    .HasMaxLength(20);

                entity.Property(e => e.CModifyPerson)
                    .HasColumnName("cModifyPerson")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CMpoCode)
                    .HasColumnName("cMPoCode")
                    .HasMaxLength(30);

                entity.Property(e => e.COdepCode)
                    .HasColumnName("cODepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.COrdCode)
                    .HasColumnName("cORdCode")
                    .HasMaxLength(5);

                entity.Property(e => e.COrderType)
                    .HasColumnName("cOrderType")
                    .HasMaxLength(40);

                entity.Property(e => e.COwhCode)
                    .IsRequired()
                    .HasColumnName("cOWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CPersonCode)
                    .HasColumnName("cPersonCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CPspcode)
                    .HasColumnName("cPSPCode")
                    .HasMaxLength(60);

                entity.Property(e => e.CSourceCodeLs)
                    .HasColumnName("cSourceCodeLs")
                    .HasMaxLength(20);

                entity.Property(e => e.CTranRequestCode)
                    .HasColumnName("cTranRequestCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CTvmemo)
                    .HasColumnName("cTVMemo")
                    .HasMaxLength(255);

                entity.Property(e => e.CVerifyPerson)
                    .HasColumnName("cVerifyPerson")
                    .HasMaxLength(20);

                entity.Property(e => e.CVersion)
                    .HasColumnName("cVersion")
                    .HasMaxLength(20);

                entity.Property(e => e.Cbustype)
                    .HasColumnName("cbustype")
                    .HasMaxLength(20);

                entity.Property(e => e.Csource)
                    .HasColumnName("csource")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Csourceguid)
                    .HasColumnName("csourceguid")
                    .HasMaxLength(50);

                entity.Property(e => e.Csysbarcode)
                    .HasColumnName("csysbarcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Csyssource)
                    .HasColumnName("csyssource")
                    .HasMaxLength(10);

                entity.Property(e => e.Csyssourceid)
                    .HasColumnName("csyssourceid")
                    .HasMaxLength(50);

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DTvdate)
                    .HasColumnName("dTVDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVerifyDate)
                    .HasColumnName("dVerifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmaketime)
                    .HasColumnName("dnmaketime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnmodifytime)
                    .HasColumnName("dnmodifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dnverifytime)
                    .HasColumnName("dnverifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.INetLock).HasColumnName("iNetLock");

                entity.Property(e => e.IPrintCount)
                    .HasColumnName("iPrintCount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IQuantity).HasColumnName("iQuantity");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iproorderid).HasColumnName("iproorderid");

                entity.Property(e => e.Ireturncount)
                    .HasColumnName("ireturncount")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Iswfcontrolled)
                    .HasColumnName("iswfcontrolled")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Itransflag)
                    .HasColumnName("itransflag")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("(N'正向')");

                entity.Property(e => e.Iverifystate)
                    .HasColumnName("iverifystate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ufts)
                    .HasColumnName("ufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.VtId)
                    .HasColumnName("VT_ID")
                    .HasDefaultValueSql("(1)");

                entity.HasOne(d => d.CIdepCodeNavigation)
                    .WithMany(p => p.TransVouchCIdepCodeNavigation)
                    .HasForeignKey(d => d.CIdepCode)
                    .HasConstraintName("FK__TransVouc__cIDep__3D73F9C2");

                entity.HasOne(d => d.CIwhCodeNavigation)
                    .WithMany(p => p.TransVouchCIwhCodeNavigation)
                    .HasForeignKey(d => d.CIwhCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TransVouc__cIWhC__04C58C4B");

                entity.HasOne(d => d.COdepCodeNavigation)
                    .WithMany(p => p.TransVouchCOdepCodeNavigation)
                    .HasForeignKey(d => d.COdepCode)
                    .HasConstraintName("FK__TransVouc__cODep__3C7FD589");

                entity.HasOne(d => d.COwhCodeNavigation)
                    .WithMany(p => p.TransVouchCOwhCodeNavigation)
                    .HasForeignKey(d => d.COwhCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TransVouc__cOWhC__03D16812");

                entity.HasOne(d => d.CPersonCodeNavigation)
                    .WithMany(p => p.TransVouch)
                    .HasForeignKey(d => d.CPersonCode)
                    .HasConstraintName("FK__TransVouc__cPers__19F5B35B");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.CVenCode)
                    .HasName("aaaaaVendor_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CDccode)
                    .HasName("DistrictClassVendor");

                entity.HasIndex(e => e.CVccode)
                    .HasName("VendorClassVendor");

                entity.HasIndex(e => e.CVenAbbName)
                    .HasName("cVenAbbName")
                    .IsUnique();

                entity.HasIndex(e => e.CVenCode)
                    .HasName("PK_Vendor_cVenCode_Clustered_Index")
                    .IsClustered();

                entity.HasIndex(e => e.CVenDepart)
                    .HasName("DepartmentVendor");

                entity.HasIndex(e => e.CVenName)
                    .HasName("cVenName");

                entity.HasIndex(e => e.CVenWhCode)
                    .HasName("WarehouseVendor");

                entity.HasIndex(e => e.DModifyDate);

                entity.HasIndex(e => new { e.CVenMnemCode, e.CVenCode })
                    .HasName("IX_Vendor_cVenCode_cVenMnemCode");

                entity.Property(e => e.CVenCode)
                    .HasColumnName("cVenCode")
                    .HasMaxLength(20);

                entity.Property(e => e.BBusinessDate)
                    .IsRequired()
                    .HasColumnName("bBusinessDate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BIsVenAttachFile).HasColumnName("bIsVenAttachFile");

                entity.Property(e => e.BLicenceDate)
                    .IsRequired()
                    .HasColumnName("bLicenceDate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BPassGmp)
                    .IsRequired()
                    .HasColumnName("bPassGMP")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BProxyDate)
                    .IsRequired()
                    .HasColumnName("bProxyDate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BProxyForeign)
                    .IsRequired()
                    .HasColumnName("bProxyForeign")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BRetail)
                    .HasColumnName("bRetail")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BVenAccPeriodMng)
                    .IsRequired()
                    .HasColumnName("bVenAccPeriodMng")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BVenCargo)
                    .IsRequired()
                    .HasColumnName("bVenCargo")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.BVenHomeBranch)
                    .IsRequired()
                    .HasColumnName("bVenHomeBranch")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BVenOverseas)
                    .IsRequired()
                    .HasColumnName("bVenOverseas")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BVenService)
                    .IsRequired()
                    .HasColumnName("bVenService")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BVenTax).HasColumnName("bVenTax");

                entity.Property(e => e.CBarCode)
                    .HasColumnName("cBarCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CBusinessRange)
                    .HasColumnName("cBusinessRange")
                    .HasMaxLength(255);

                entity.Property(e => e.CCreatePerson)
                    .HasColumnName("cCreatePerson")
                    .HasMaxLength(20);

                entity.Property(e => e.CDccode)
                    .HasColumnName("cDCCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CLicenceRange)
                    .HasColumnName("cLicenceRange")
                    .HasMaxLength(255);

                entity.Property(e => e.CMemo)
                    .HasColumnName("cMemo")
                    .HasMaxLength(240);

                entity.Property(e => e.CModifyPerson)
                    .HasColumnName("cModifyPerson")
                    .HasMaxLength(20);

                entity.Property(e => e.COmwhCode)
                    .HasColumnName("cOMWhCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CRelCustomer)
                    .HasColumnName("cRelCustomer")
                    .HasMaxLength(20);

                entity.Property(e => e.CTrade)
                    .HasColumnName("cTrade")
                    .HasMaxLength(50);

                entity.Property(e => e.CVccode)
                    .HasColumnName("cVCCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CVenAbbName)
                    .IsRequired()
                    .HasColumnName("cVenAbbName")
                    .HasMaxLength(60);

                entity.Property(e => e.CVenAccount)
                    .HasColumnName("cVenAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.CVenAddress)
                    .HasColumnName("cVenAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CVenBank)
                    .HasColumnName("cVenBank")
                    .HasMaxLength(100);

                entity.Property(e => e.CVenBankCode)
                    .HasColumnName("cVenBankCode")
                    .HasMaxLength(5);

                entity.Property(e => e.CVenBp)
                    .HasColumnName("cVenBP")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenBranchAddr)
                    .HasColumnName("cVenBranchAddr")
                    .HasMaxLength(200);

                entity.Property(e => e.CVenBranchPerson)
                    .HasColumnName("cVenBranchPerson")
                    .HasMaxLength(50);

                entity.Property(e => e.CVenBranchPhone)
                    .HasColumnName("cVenBranchPhone")
                    .HasMaxLength(100);

                entity.Property(e => e.CVenBusinessNo)
                    .HasColumnName("cVenBusinessNo")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenCmprotocol)
                    .HasColumnName("cVenCMProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenContactCode).HasColumnName("cVenContactCode");

                entity.Property(e => e.CVenCountryCode)
                    .HasColumnName("cVenCountryCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CVenDefine1)
                    .HasColumnName("cVenDefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenDefine10)
                    .HasColumnName("cVenDefine10")
                    .HasMaxLength(120);

                entity.Property(e => e.CVenDefine11).HasColumnName("cVenDefine11");

                entity.Property(e => e.CVenDefine12).HasColumnName("cVenDefine12");

                entity.Property(e => e.CVenDefine13).HasColumnName("cVenDefine13");

                entity.Property(e => e.CVenDefine14).HasColumnName("cVenDefine14");

                entity.Property(e => e.CVenDefine15)
                    .HasColumnName("cVenDefine15")
                    .HasColumnType("datetime");

                entity.Property(e => e.CVenDefine16)
                    .HasColumnName("cVenDefine16")
                    .HasColumnType("datetime");

                entity.Property(e => e.CVenDefine2)
                    .HasColumnName("cVenDefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenDefine3)
                    .HasColumnName("cVenDefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenDefine4)
                    .HasColumnName("cVenDefine4")
                    .HasMaxLength(60);

                entity.Property(e => e.CVenDefine5)
                    .HasColumnName("cVenDefine5")
                    .HasMaxLength(60);

                entity.Property(e => e.CVenDefine6)
                    .HasColumnName("cVenDefine6")
                    .HasMaxLength(60);

                entity.Property(e => e.CVenDefine7)
                    .HasColumnName("cVenDefine7")
                    .HasMaxLength(120);

                entity.Property(e => e.CVenDefine8)
                    .HasColumnName("cVenDefine8")
                    .HasMaxLength(120);

                entity.Property(e => e.CVenDefine9)
                    .HasColumnName("cVenDefine9")
                    .HasMaxLength(120);

                entity.Property(e => e.CVenDepart)
                    .HasColumnName("cVenDepart")
                    .HasMaxLength(12);

                entity.Property(e => e.CVenEmail)
                    .HasColumnName("cVenEmail")
                    .HasMaxLength(100);

                entity.Property(e => e.CVenEnAddr1)
                    .HasColumnName("cVenEnAddr1")
                    .HasMaxLength(60);

                entity.Property(e => e.CVenEnAddr2)
                    .HasColumnName("cVenEnAddr2")
                    .HasMaxLength(60);

                entity.Property(e => e.CVenEnAddr3)
                    .HasColumnName("cVenEnAddr3")
                    .HasMaxLength(60);

                entity.Property(e => e.CVenEnAddr4)
                    .HasColumnName("cVenEnAddr4")
                    .HasMaxLength(60);

                entity.Property(e => e.CVenEnName)
                    .HasColumnName("cVenEnName")
                    .HasMaxLength(100);

                entity.Property(e => e.CVenExchName)
                    .HasColumnName("cVenExch_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CVenFax)
                    .HasColumnName("cVenFax")
                    .HasMaxLength(100);

                entity.Property(e => e.CVenGspauthNo)
                    .HasColumnName("cVenGSPAuthNo")
                    .HasMaxLength(40);

                entity.Property(e => e.CVenGsprange)
                    .HasColumnName("cVenGSPRange")
                    .HasMaxLength(255);

                entity.Property(e => e.CVenHand)
                    .HasColumnName("cVenHand")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenHeadCode)
                    .HasColumnName("cVenHeadCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenIaddress)
                    .HasColumnName("cVenIAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CVenImprotocol)
                    .HasColumnName("cVenIMProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenItype)
                    .HasColumnName("cVenIType")
                    .HasMaxLength(10);

                entity.Property(e => e.CVenLicenceNo)
                    .HasColumnName("cVenLicenceNo")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenLperson)
                    .HasColumnName("cVenLPerson")
                    .HasMaxLength(100);

                entity.Property(e => e.CVenMnemCode)
                    .HasColumnName("cVenMnemCode")
                    .HasMaxLength(98);

                entity.Property(e => e.CVenName)
                    .HasColumnName("cVenName")
                    .HasMaxLength(98);

                entity.Property(e => e.CVenOtherProtocol)
                    .HasColumnName("cVenOtherProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenPayCond)
                    .HasColumnName("cVenPayCond")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenPerson)
                    .HasColumnName("cVenPerson")
                    .HasMaxLength(50);

                entity.Property(e => e.CVenPhone)
                    .HasColumnName("cVenPhone")
                    .HasMaxLength(100);

                entity.Property(e => e.CVenPortCode)
                    .HasColumnName("cVenPortCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CVenPostCode)
                    .HasColumnName("cVenPostCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenPperson)
                    .HasColumnName("cVenPPerson")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenPrimaryVen)
                    .HasColumnName("cVenPrimaryVen")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenPuomprotocol)
                    .HasColumnName("cVenPUOMProtocol")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenRegCode)
                    .HasColumnName("cVenRegCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CVenSscode)
                    .HasColumnName("cVenSSCode")
                    .HasMaxLength(20);

                entity.Property(e => e.CVenTradeCcode)
                    .HasColumnName("cVenTradeCCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CVenWhCode)
                    .HasColumnName("cVenWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.Cvenbankall)
                    .HasColumnName("cvenbankall")
                    .HasMaxLength(50);

                entity.Property(e => e.DBusinessEdate)
                    .HasColumnName("dBusinessEDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DBusinessSdate)
                    .HasColumnName("dBusinessSDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DEndDate)
                    .HasColumnName("dEndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLastDate)
                    .HasColumnName("dLastDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLicenceEdate)
                    .HasColumnName("dLicenceEDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLicenceSdate)
                    .HasColumnName("dLicenceSDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DLrdate)
                    .HasColumnName("dLRDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DProxyEdate)
                    .HasColumnName("dProxyEDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DProxySdate)
                    .HasColumnName("dProxySDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVenCreateDatetime)
                    .HasColumnName("dVenCreateDatetime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DVenDevDate)
                    .HasColumnName("dVenDevDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVenGspedate)
                    .HasColumnName("dVenGSPEDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DVenGspsdate)
                    .HasColumnName("dVenGSPSDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FRegistFund).HasColumnName("fRegistFund");

                entity.Property(e => e.FVenCommisionRate).HasColumnName("fVenCommisionRate");

                entity.Property(e => e.FVenInsueRate).HasColumnName("fVenInsueRate");

                entity.Property(e => e.IApmoney).HasColumnName("iAPMoney");

                entity.Property(e => e.IBusinessAdays).HasColumnName("iBusinessADays");

                entity.Property(e => e.IEmployeeNum).HasColumnName("iEmployeeNum");

                entity.Property(e => e.IFrequency).HasColumnName("iFrequency");

                entity.Property(e => e.IGradeAbc).HasColumnName("iGradeABC");

                entity.Property(e => e.IId).HasColumnName("iId");

                entity.Property(e => e.ILastMoney).HasColumnName("iLastMoney");

                entity.Property(e => e.ILicenceAdays).HasColumnName("iLicenceADays");

                entity.Property(e => e.ILrmoney).HasColumnName("iLRMoney");

                entity.Property(e => e.IProxyAdays).HasColumnName("iProxyADays");

                entity.Property(e => e.IVenCreDate).HasColumnName("iVenCreDate");

                entity.Property(e => e.IVenCreGrade)
                    .HasColumnName("iVenCreGrade")
                    .HasMaxLength(6);

                entity.Property(e => e.IVenCreLine).HasColumnName("iVenCreLine");

                entity.Property(e => e.IVenDisRate).HasColumnName("iVenDisRate");

                entity.Property(e => e.IVenGspadays).HasColumnName("iVenGSPADays");

                entity.Property(e => e.IVenGspauth).HasColumnName("iVenGSPAuth");

                entity.Property(e => e.IVenGsptype)
                    .HasColumnName("iVenGSPType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IVenTaxRate).HasColumnName("iVenTaxRate");

                entity.Property(e => e.Pubufts)
                    .HasColumnName("pubufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CVenDepartNavigation)
                    .WithMany(p => p.Vendor)
                    .HasForeignKey(d => d.CVenDepart)
                    .HasConstraintName("FK__Vendor__cVenDepa__3E681DFB");

                entity.HasOne(d => d.CVenWhCodeNavigation)
                    .WithMany(p => p.Vendor)
                    .HasForeignKey(d => d.CVenWhCode)
                    .HasConstraintName("FK__Vendor__cVenWhCo__05B9B084");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.CWhCode)
                    .HasName("aaaaaWarehouse_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CDepCode)
                    .HasName("DepartmentWarehouse");

                entity.HasIndex(e => e.CWhCode)
                    .HasName("Warehouse_cWhCode_Idx");

                entity.HasIndex(e => e.CWhName)
                    .HasName("cWhName");

                entity.HasIndex(e => e.DModifyDate)
                    .HasName("IX_warehouse_dModifyDate");

                entity.HasIndex(e => new { e.CWhCode, e.CWhValueStyle })
                    .HasName("ix_IA_WareHouse_ValueStyle");

                entity.Property(e => e.CWhCode)
                    .HasColumnName("cWhCode")
                    .HasMaxLength(10);

                entity.Property(e => e.BBondedWh)
                    .IsRequired()
                    .HasColumnName("bBondedWh")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BCheckSubitemCost)
                    .HasColumnName("bCheckSubitemCost")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.BControlSerial)
                    .IsRequired()
                    .HasColumnName("bControlSerial")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.BEb).HasColumnName("bEB");

                entity.Property(e => e.BFreeze)
                    .IsRequired()
                    .HasColumnName("bFreeze")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BInAvailCalcu)
                    .IsRequired()
                    .HasColumnName("bInAvailCalcu")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.BInCost)
                    .IsRequired()
                    .HasColumnName("bInCost")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.BMrp)
                    .IsRequired()
                    .HasColumnName("bMRP")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.BProxyWh)
                    .IsRequired()
                    .HasColumnName("bProxyWh")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BRop)
                    .IsRequired()
                    .HasColumnName("bROP")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BShop)
                    .IsRequired()
                    .HasColumnName("bShop")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BWhAsset)
                    .IsRequired()
                    .HasColumnName("bWhAsset")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BWhPos).HasColumnName("bWhPos");

                entity.Property(e => e.CBarCode)
                    .HasColumnName("cBarCode")
                    .HasMaxLength(30);

                entity.Property(e => e.CCity)
                    .HasColumnName("cCity")
                    .HasMaxLength(100);

                entity.Property(e => e.CCounty)
                    .HasColumnName("cCounty")
                    .HasMaxLength(100);

                entity.Property(e => e.CDepCode)
                    .HasColumnName("cDepCode")
                    .HasMaxLength(12);

                entity.Property(e => e.CFactoryCode)
                    .HasColumnName("cFactoryCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CFrequency)
                    .HasColumnName("cFrequency")
                    .HasMaxLength(10);

                entity.Property(e => e.CMonth)
                    .HasColumnName("cMonth")
                    .HasMaxLength(6);

                entity.Property(e => e.CPickPos)
                    .HasColumnName("cPickPos")
                    .HasMaxLength(40);

                entity.Property(e => e.CProvince)
                    .HasColumnName("cProvince")
                    .HasMaxLength(100);

                entity.Property(e => e.CWareGroupCode)
                    .HasColumnName("cWareGroupCode")
                    .HasMaxLength(100);

                entity.Property(e => e.CWhAddress)
                    .HasColumnName("cWhAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.CWhMemo)
                    .HasColumnName("cWhMemo")
                    .HasMaxLength(20);

                entity.Property(e => e.CWhName)
                    .HasColumnName("cWhName")
                    .HasMaxLength(20);

                entity.Property(e => e.CWhPerson)
                    .HasColumnName("cWhPerson")
                    .HasMaxLength(20);

                entity.Property(e => e.CWhPhone)
                    .HasColumnName("cWhPhone")
                    .HasMaxLength(100);

                entity.Property(e => e.CWhValueStyle)
                    .IsRequired()
                    .HasColumnName("cWhValueStyle")
                    .HasMaxLength(12);

                entity.Property(e => e.DLastDate)
                    .HasColumnName("dLastDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DModifyDate)
                    .HasColumnName("dModifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DWhEndDate)
                    .HasColumnName("dWhEndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FWhQuota).HasColumnName("fWhQuota");

                entity.Property(e => e.IDays).HasColumnName("iDays");

                entity.Property(e => e.IExconMode)
                    .HasColumnName("iEXConMode")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IFrequency).HasColumnName("iFrequency");

                entity.Property(e => e.ISaconMode)
                    .HasColumnName("iSAConMode")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IStconMode)
                    .HasColumnName("iSTConMode")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IWhFundQuota).HasColumnName("iWhFundQuota");

                entity.Property(e => e.IWhproperty)
                    .HasColumnName("iWHProperty")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Pubufts)
                    .HasColumnName("pubufts")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CDepCodeNavigation)
                    .WithMany(p => p.Warehouse)
                    .HasForeignKey(d => d.CDepCode)
                    .HasConstraintName("FK__Warehouse__cDepC__46093FC3");
            });

            modelBuilder.Entity<Zpurpotail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("zpurpotail");

                entity.Property(e => e.Bgift).HasColumnName("bgift");

                entity.Property(e => e.Bgsp).HasColumnName("bgsp");

                entity.Property(e => e.Binvtype).HasColumnName("binvtype");

                entity.Property(e => e.Bservice).HasColumnName("bservice");

                entity.Property(e => e.Btaxcost).HasColumnName("btaxcost");

                entity.Property(e => e.Cbclosedate)
                    .HasColumnName("cbclosedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cbcloser)
                    .IsRequired()
                    .HasColumnName("cbcloser")
                    .HasMaxLength(20);

                entity.Property(e => e.Cbclosetime)
                    .HasColumnName("cbclosetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CbgAuditopinion)
                    .HasColumnName("cbg_auditopinion")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgCalibercode1)
                    .HasColumnName("cbg_calibercode1")
                    .HasMaxLength(90);

                entity.Property(e => e.CbgCalibercode2)
                    .HasColumnName("cbg_calibercode2")
                    .HasMaxLength(90);

                entity.Property(e => e.CbgCalibercode3)
                    .HasColumnName("cbg_calibercode3")
                    .HasMaxLength(90);

                entity.Property(e => e.CbgCalibercode4)
                    .HasColumnName("cbg_calibercode4")
                    .HasMaxLength(90);

                entity.Property(e => e.CbgCalibercode5)
                    .HasColumnName("cbg_calibercode5")
                    .HasMaxLength(90);

                entity.Property(e => e.CbgCalibercode6)
                    .HasColumnName("cbg_calibercode6")
                    .HasMaxLength(90);

                entity.Property(e => e.CbgCaliberkey1)
                    .HasColumnName("cbg_caliberkey1")
                    .HasMaxLength(50);

                entity.Property(e => e.CbgCaliberkey2)
                    .HasColumnName("cbg_caliberkey2")
                    .HasMaxLength(50);

                entity.Property(e => e.CbgCaliberkey3)
                    .HasColumnName("cbg_caliberkey3")
                    .HasMaxLength(50);

                entity.Property(e => e.CbgCaliberkey4)
                    .HasColumnName("cbg_caliberkey4")
                    .HasMaxLength(50);

                entity.Property(e => e.CbgCaliberkey5)
                    .HasColumnName("cbg_caliberkey5")
                    .HasMaxLength(50);

                entity.Property(e => e.CbgCaliberkey6)
                    .HasColumnName("cbg_caliberkey6")
                    .HasMaxLength(50);

                entity.Property(e => e.CbgCaliberkeyname1)
                    .HasColumnName("cbg_caliberkeyname1")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgCaliberkeyname2)
                    .HasColumnName("cbg_caliberkeyname2")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgCaliberkeyname3)
                    .HasColumnName("cbg_caliberkeyname3")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgCaliberkeyname4)
                    .HasColumnName("cbg_caliberkeyname4")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgCaliberkeyname5)
                    .HasColumnName("cbg_caliberkeyname5")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgCaliberkeyname6)
                    .HasColumnName("cbg_caliberkeyname6")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgCalibername1)
                    .HasColumnName("cbg_calibername1")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgCalibername2)
                    .HasColumnName("cbg_calibername2")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgCalibername3)
                    .HasColumnName("cbg_calibername3")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgCalibername4)
                    .HasColumnName("cbg_calibername4")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgCalibername5)
                    .HasColumnName("cbg_calibername5")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgCalibername6)
                    .HasColumnName("cbg_calibername6")
                    .HasMaxLength(100);

                entity.Property(e => e.CbgItemcode)
                    .HasColumnName("cbg_itemcode")
                    .HasMaxLength(50);

                entity.Property(e => e.CbgItemname)
                    .HasColumnName("cbg_itemname")
                    .HasMaxLength(100);

                entity.Property(e => e.Cbmemo)
                    .HasColumnName("cbmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cbsysbarcode)
                    .HasColumnName("cbsysbarcode")
                    .HasMaxLength(80);

                entity.Property(e => e.Ccomunitcode)
                    .HasColumnName("ccomunitcode")
                    .HasMaxLength(35);

                entity.Property(e => e.Cdefine22)
                    .HasColumnName("cdefine22")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine23)
                    .HasColumnName("cdefine23")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine24)
                    .HasColumnName("cdefine24")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine25)
                    .HasColumnName("cdefine25")
                    .HasMaxLength(60);

                entity.Property(e => e.Cdefine26).HasColumnName("cdefine26");

                entity.Property(e => e.Cdefine27).HasColumnName("cdefine27");

                entity.Property(e => e.Cdefine28)
                    .HasColumnName("cdefine28")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine29)
                    .HasColumnName("cdefine29")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine30)
                    .HasColumnName("cdefine30")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine31)
                    .HasColumnName("cdefine31")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine32)
                    .HasColumnName("cdefine32")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine33)
                    .HasColumnName("cdefine33")
                    .HasMaxLength(120);

                entity.Property(e => e.Cdefine34).HasColumnName("cdefine34");

                entity.Property(e => e.Cdefine35).HasColumnName("cdefine35");

                entity.Property(e => e.Cdefine36)
                    .HasColumnName("cdefine36")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdefine37)
                    .HasColumnName("cdefine37")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cdemandmemo)
                    .HasColumnName("cdemandmemo")
                    .HasMaxLength(255);

                entity.Property(e => e.Cfactorycode)
                    .HasColumnName("cfactorycode")
                    .HasMaxLength(50);

                entity.Property(e => e.Cfactoryname)
                    .HasColumnName("cfactoryname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cfree1)
                    .HasColumnName("cfree1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree10)
                    .HasColumnName("cfree10")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree2)
                    .HasColumnName("cfree2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree3)
                    .HasColumnName("cfree3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree4)
                    .HasColumnName("cfree4")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree5)
                    .HasColumnName("cfree5")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree6)
                    .HasColumnName("cfree6")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree7)
                    .HasColumnName("cfree7")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree8)
                    .HasColumnName("cfree8")
                    .HasMaxLength(20);

                entity.Property(e => e.Cfree9)
                    .HasColumnName("cfree9")
                    .HasMaxLength(20);

                entity.Property(e => e.Cgroupcode)
                    .HasColumnName("cgroupcode")
                    .HasMaxLength(35);

                entity.Property(e => e.CinvaUnit)
                    .HasColumnName("cinva_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvaddcode)
                    .HasColumnName("cinvaddcode")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvauthid).HasColumnName("cinvauthid");

                entity.Property(e => e.Cinvccode)
                    .HasColumnName("cinvccode")
                    .HasMaxLength(12);

                entity.Property(e => e.Cinvcode)
                    .IsRequired()
                    .HasColumnName("cinvcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine1)
                    .HasColumnName("cinvdefine1")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine10)
                    .HasColumnName("cinvdefine10")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine11).HasColumnName("cinvdefine11");

                entity.Property(e => e.Cinvdefine12).HasColumnName("cinvdefine12");

                entity.Property(e => e.Cinvdefine13).HasColumnName("cinvdefine13");

                entity.Property(e => e.Cinvdefine14).HasColumnName("cinvdefine14");

                entity.Property(e => e.Cinvdefine15)
                    .HasColumnName("cinvdefine15")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cinvdefine16)
                    .HasColumnName("cinvdefine16")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cinvdefine2)
                    .HasColumnName("cinvdefine2")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine3)
                    .HasColumnName("cinvdefine3")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvdefine4)
                    .HasColumnName("cinvdefine4")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine5)
                    .HasColumnName("cinvdefine5")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine6)
                    .HasColumnName("cinvdefine6")
                    .HasMaxLength(60);

                entity.Property(e => e.Cinvdefine7)
                    .HasColumnName("cinvdefine7")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine8)
                    .HasColumnName("cinvdefine8")
                    .HasMaxLength(120);

                entity.Property(e => e.Cinvdefine9)
                    .HasColumnName("cinvdefine9")
                    .HasMaxLength(120);

                entity.Property(e => e.CinvmUnit)
                    .HasColumnName("cinvm_unit")
                    .HasMaxLength(20);

                entity.Property(e => e.Cinvname)
                    .HasColumnName("cinvname")
                    .HasMaxLength(255);

                entity.Property(e => e.Cinvstd)
                    .HasColumnName("cinvstd")
                    .HasMaxLength(255);

                entity.Property(e => e.CitemClass)
                    .HasColumnName("citem_class")
                    .HasMaxLength(10);

                entity.Property(e => e.CitemName1)
                    .HasColumnName("citem_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Citemcode)
                    .HasColumnName("citemcode")
                    .HasMaxLength(60);

                entity.Property(e => e.Citemname)
                    .HasColumnName("citemname")
                    .HasMaxLength(255);

                entity.Property(e => e.Contractcode)
                    .HasColumnName("contractcode")
                    .HasMaxLength(128);

                entity.Property(e => e.Contractrowguid).HasColumnName("contractrowguid");

                entity.Property(e => e.Contractrowno)
                    .HasColumnName("contractrowno")
                    .HasMaxLength(150);

                entity.Property(e => e.Cplanmethod)
                    .HasColumnName("cplanmethod")
                    .HasMaxLength(1);

                entity.Property(e => e.Csocode)
                    .HasColumnName("csocode")
                    .HasMaxLength(40);

                entity.Property(e => e.Csoordercode)
                    .HasColumnName("csoordercode")
                    .HasMaxLength(50);

                entity.Property(e => e.Csource)
                    .HasColumnName("csource")
                    .HasMaxLength(10);

                entity.Property(e => e.Csrpolicy)
                    .HasColumnName("csrpolicy")
                    .HasMaxLength(2);

                entity.Property(e => e.Csyssourceautoid)
                    .HasColumnName("csyssourceautoid")
                    .HasMaxLength(50);

                entity.Property(e => e.Cunitid)
                    .HasColumnName("cunitid")
                    .HasMaxLength(35);

                entity.Property(e => e.Cupsocode)
                    .HasColumnName("cupsocode")
                    .HasMaxLength(64);

                entity.Property(e => e.Cveninvcode)
                    .HasColumnName("cveninvcode")
                    .HasMaxLength(40);

                entity.Property(e => e.Cveninvname)
                    .HasColumnName("cveninvname")
                    .HasMaxLength(100);

                entity.Property(e => e.Cxjspdids)
                    .HasColumnName("cxjspdids")
                    .HasMaxLength(60);

                entity.Property(e => e.Darrivedate)
                    .HasColumnName("darrivedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fexnum)
                    .HasColumnName("fexnum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Fexquantity)
                    .HasColumnName("fexquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Gcsourceid).HasColumnName("gcsourceid");

                entity.Property(e => e.Gcsourceids).HasColumnName("gcsourceids");

                entity.Property(e => e.Gcupcardnum)
                    .HasColumnName("gcupcardnum")
                    .HasMaxLength(100);

                entity.Property(e => e.Gcupid).HasColumnName("gcupid");

                entity.Property(e => e.Gcupids).HasColumnName("gcupids");

                entity.Property(e => e.INrorderAmt)
                    .HasColumnName("iNROrderAmt")
                    .HasColumnType("money");

                entity.Property(e => e.INrorderAmtF)
                    .HasColumnName("iNROrderAmt_f")
                    .HasColumnType("money");

                entity.Property(e => e.IOrderAmt)
                    .HasColumnName("iOrderAmt")
                    .HasColumnType("money");

                entity.Property(e => e.IOrderAmtF)
                    .HasColumnName("iOrderAmt_f")
                    .HasColumnType("money");

                entity.Property(e => e.Iappids).HasColumnName("iappids");

                entity.Property(e => e.Iarrmoney)
                    .HasColumnName("iarrmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Iarrnum)
                    .HasColumnName("iarrnum")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Iarrqty)
                    .HasColumnName("iarrqty")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.IbgCtrl).HasColumnName("ibg_ctrl");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idiscount)
                    .HasColumnName("idiscount")
                    .HasColumnType("money");

                entity.Property(e => e.Igrouptype).HasColumnName("igrouptype");

                entity.Property(e => e.Iinvexchrate)
                    .HasColumnName("iinvexchrate")
                    .HasColumnType("decimal(38, 8)");

                entity.Property(e => e.Iinvmoney)
                    .HasColumnName("iinvmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Iinvmpcost)
                    .HasColumnName("iinvmpcost")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.Iinvnum)
                    .HasColumnName("iinvnum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Iinvqty)
                    .HasColumnName("iinvqty")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Imoney)
                    .HasColumnName("imoney")
                    .HasColumnType("money");

                entity.Property(e => e.Inatarrmoney)
                    .HasColumnName("inatarrmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Inatdiscount)
                    .HasColumnName("inatdiscount")
                    .HasColumnType("money");

                entity.Property(e => e.Inatinvmoney)
                    .HasColumnName("inatinvmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Inatmoney)
                    .HasColumnName("inatmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Inatsum)
                    .HasColumnName("inatsum")
                    .HasColumnType("money");

                entity.Property(e => e.Inattax)
                    .HasColumnName("inattax")
                    .HasColumnType("money");

                entity.Property(e => e.Inatunitprice)
                    .HasColumnName("inatunitprice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Inum)
                    .HasColumnName("inum")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Iorderdid).HasColumnName("iorderdid");

                entity.Property(e => e.Iorderseq).HasColumnName("iorderseq");

                entity.Property(e => e.Iordertype).HasColumnName("iordertype");

                entity.Property(e => e.Ioritotal)
                    .HasColumnName("ioritotal")
                    .HasColumnType("money");

                entity.Property(e => e.Ipertaxrate)
                    .HasColumnName("ipertaxrate")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Ippartid).HasColumnName("ippartid");

                entity.Property(e => e.Ipquantity)
                    .HasColumnName("ipquantity")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Ipresentb).HasColumnName("ipresentb");

                entity.Property(e => e.Iptoseq).HasColumnName("iptoseq");

                entity.Property(e => e.Iquantity)
                    .HasColumnName("iquantity")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Iquotedprice)
                    .HasColumnName("iquotedprice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ireceivedmoney)
                    .HasColumnName("ireceivedmoney")
                    .HasColumnType("money");

                entity.Property(e => e.Ireceivednum)
                    .HasColumnName("ireceivednum")
                    .HasColumnType("decimal(38, 9)");

                entity.Property(e => e.Ireceivedqty)
                    .HasColumnName("ireceivedqty")
                    .HasColumnType("decimal(33, 10)");

                entity.Property(e => e.Irequiretrackstyle).HasColumnName("irequiretrackstyle");

                entity.Property(e => e.Irowno).HasColumnName("irowno");

                entity.Property(e => e.Isosid).HasColumnName("isosid");

                entity.Property(e => e.Isum)
                    .HasColumnName("isum")
                    .HasColumnType("money");

                entity.Property(e => e.Itax)
                    .HasColumnName("itax")
                    .HasColumnType("money");

                entity.Property(e => e.Itaxprice)
                    .HasColumnName("itaxprice")
                    .HasColumnType("decimal(28, 6)");

                entity.Property(e => e.Itotal)
                    .HasColumnName("itotal")
                    .HasColumnType("money");

                entity.Property(e => e.Iunitprice)
                    .HasColumnName("iunitprice")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ivouchrowno).HasColumnName("ivouchrowno");

                entity.Property(e => e.Planlotnumber)
                    .HasColumnName("planlotnumber")
                    .HasMaxLength(40);

                entity.Property(e => e.Poid).HasColumnName("poid");

                entity.Property(e => e.Ppcids).HasColumnName("ppcids");

                entity.Property(e => e.Sodid)
                    .HasColumnName("sodid")
                    .HasMaxLength(50);

                entity.Property(e => e.Sotype).HasColumnName("sotype");

                entity.Property(e => e.Upsotype)
                    .HasColumnName("upsotype")
                    .HasMaxLength(10);

                entity.Property(e => e.YycInvname)
                    .HasColumnName("yyc_invname")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
