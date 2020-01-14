using MicroFeel.Yonyou.Api.Model.Data;
using MicroFeel.Yonyou.Api.Model.Request;
using MicroFeel.Yonyou.Api.Model.Result;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Api.Service
{
    /// <summary>
    /// 基础档案 API  88
    /// </summary>
    public class BasicApi : Api
    {
        public BasicApi() : base("api") { }

        /// <summary>
        /// U8帐套 获取单个U8帐套信息  
        /// </summary> 
        /// <return></return>
        public async Task<AccountResult> Get_AccountAsync(string id, int dsSequence = 1)
        {
            return await GetSync<AccountResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取U8帐套信息  
        /// </summary> 
        /// <return></return>
        public async Task<List<Account>> Batch_Get_AccountAsync(int dsSequence = 1)
        {
            return await GetsSync<AccountListResult, Account>(dsSequence);
        }
        /// <summary>
        /// 首付款协议档案    获取单个首付款协议档案
        /// </summary>
        /// <returns></returns>
        public async Task<AgreementResult> Get_AgreementAsync(string id, int dsSequence = 1)
        {
            return await GetSync<AgreementResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取首付款协议档案
        /// </summary>
        /// <param name="dsSequence"></param>
        /// <returns></returns>
        public async Task<List<Agreement>> Batch_Get_AgreementAsync(int dsSequence = 1)
        {
            return await GetsSync<AgreementListResult, Agreement>(dsSequence);
        }
        /// <summary>
        /// 交易分类    获取单个交易分类信息 
        /// </summary> 
        /// <return></return>        
        public async Task<PayunitclassResult> Get_PayunitclassAsync(string id, int dsSequence = 1)
        {
            return await GetSync<PayunitclassResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取交易分类信息  
        /// </summary> 
        /// <return></return>
        public async Task<List<Payunitclass>> Batch_Get_PayunitclassAsync(int dsSequence = 1)
        {
            return await GetsSync<PayunitclassListResult, Payunitclass>(dsSequence);
        }
        /// <summary>
        /// 交易单位    获取单个交易单位信息 
        /// </summary> 
        /// <return></return>
        public async Task<PayunitResult> Get_PayunitAsync(string id, int dsSequence = 1)
        {
            return await GetSync<PayunitResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取交易单位信息  
        /// </summary> 
        /// <return></return>
        public async Task<List<Payunit>> Batch_Get_PayunitAsync(int dsSequence = 1)
        {
            return await GetsSync<PayunitListResult, Payunit>(dsSequence);
        }
        /// <summary>
        /// 人员  获取单个人员信息 
        /// </summary> 
        /// <return></return>
        public async Task<PersonResult> Get_PersonAsync(string id, int dsSequence = 1)
        {
            return await GetSync<PersonResult>(id, dsSequence);
        }
        /// <summary>
        /// 修改一个人员  
        /// </summary> 
        /// <return></return>
        public object edit_person() { return null; }
        /// <summary>
        /// 批量获取人员信息    
        /// </summary> 
        /// <return></return>
        public async Task<List<Person>> Batch_Get_PersonAsync(int dsSequence = 1)
        {
            return await GetsSync<PersonListResult, Person>(dsSequence);
        }
        /// <summary>
        /// 添加一个新人员 
        /// </summary> 
        /// <return></return>
        public object add_person() { return null; }
        /// <summary>
        /// 人员类别    获取单个人员类别 
        /// </summary> 
        /// <return></return>
        public async Task<PersontypeResult> Get_PersontypeAsync(string id, int dsSequence = 1)
        {
            return await GetSync<PersontypeResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取人员类别    
        /// </summary> 
        /// <return></return>
        public async Task<List<Persontype>> Batch_Get_PersontypeAsync(int dsSequence = 1)
        {
            return await GetsSync<PersontypeListResult, Persontype>(dsSequence);
        }
        /// <summary>
        /// 仓库  获取单个仓库信息 
        /// </summary> 
        /// <return></return>
        public async Task<WarehouseResult> Get_WarehouseAsync(string id, int dsSequence = 1)
        {
            return await GetSync<WarehouseResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取仓库信息    
        /// </summary> 
        /// <return></return>
        public async Task<List<Warehouse>> Batch_Get_WarehouseAsync(int dsSequence = 1)
        {
            return await GetsSync<WarehouseListResult, Warehouse>(dsSequence);
        }
        /// <summary>
        /// 新增一个仓库  
        /// </summary> 
        /// <return></return>
        public object add_warehouse() { return null; }
        /// <summary>
        /// 会计期间    批量获取会计期间 
        /// </summary> 
        /// <return></return>
        public async Task<List<Period>> Batch_Get_PeriodAsync(int dsSequence = 1)
        {
            return await GetsSync<PeriodListResult, Period>(dsSequence);
        }
        /// <summary>
        /// 供应商 获取单个供应商信息 
        /// </summary> 
        /// <return></return>
        public async Task<VendorResult> Get_VendorAsync(string id, int dsSequence = 1)
        {
            return await GetSync<VendorResult>(id, dsSequence);
        }
        /// <summary>
        /// 修改一个供应商 
        /// </summary> 
        /// <return></return>
        public object edit_vendor() { return null; }
        /// <summary>
        /// 批量获取供应商信息   
        /// </summary> 
        /// <return></return>
        public async Task<List<Vendor>> Batch_Get_VendorAsync(int dsSequence = 1)
        {
            return await GetsSync<VendorListResult, Vendor>(dsSequence);
        }
        /// <summary>
        /// 添加一个新供应商    
        /// </summary> 
        /// <return></return>
        public object add_vendor() { return null; }
        /// <summary>
        /// 供应商分类   获取单个供应商分类信息 
        /// </summary> 
        /// <return></return>
        public async Task<VendorclassResult> Get_VendorclassAsync(string id, int dsSequence = 1)
        {
            return await GetSync<VendorclassResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取供应商分类信息 
        /// </summary> 
        /// <return></return>
        public async Task<List<Vendorclass>> Batch_Get_VendorclassAsync(int dsSequence = 1)
        {
            return await GetsSync<VendorclassListResult, Vendorclass>(dsSequence);
        }
        /// <summary>
        /// 添加一个新供应商分类  
        /// </summary> 
        /// <return></return>
        public object add_vendorclass() { return null; }
        /// <summary>
        /// 供应商银行   获取单个供应商银行信息 
        /// </summary> 
        /// <return></return>
        public async Task<VendorbankResult> Get_Vendor_BankAsync(string id, int dsSequence = 1)
        {
            return await GetSync<VendorbankResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取供应商银行信息 
        /// </summary> 
        /// <return></return>
        public async Task<List<Vendorbank>> Batch_Get_Vendor_BankAsync(int dsSequence = 1)
        {
            return await GetsSync<VendorbankListResult, Vendorbank>(dsSequence);
        }
        /// <summary>
        /// 凭证类别    获取单个凭证类别 
        /// </summary> 
        /// <return></return>
        public async Task<DsignResult> Get_DsignAsync(string id, int dsSequence = 1)
        {
            return await GetSync<DsignResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取凭证类别    
        /// </summary> 
        /// <return></return>
        public async Task<List<Dsign>> Batch_Get_DsignAsync(int dsSequence = 1)
        {
            return await GetsSync<DsignListResult, Dsign>(dsSequence);
        }
        /// <summary>
        /// 地区分类    获取单个地区分类 
        /// </summary> 
        /// <return></return>
        public async Task<DistrictclassResult> Get_DistrictclassAsync(string id, int dsSequence = 1)
        {
            return await GetSync<DistrictclassResult>(id, dsSequence);
        }

        /// <summary>
        /// 批量获取地区分类    
        /// </summary> 
        /// <return></return>
        public async Task<List<Districtclass>> Batch_Get_DistrictclassAsync(int dsSequence = 1)
        {
            return await GetsSync<DistrictclassListResult, Districtclass>(dsSequence);
        }
        /// <summary>
        /// 存货分类    获取单个存货分类信息 
        /// </summary> 
        /// <return></return>
        public async Task<InventoryclassResult> Get_InventoryclassAsync(string id, int dsSequence = 1)
        {
            return await GetSync<InventoryclassResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取存货分类信息  
        /// </summary> 
        /// <return></return>
        public async Task<List<Inventoryclass>> Batch_Get_InventoryclassAsync(int dsSequence = 1)
        {
            return await GetsSync<InventoryclassListResult, Inventoryclass>(dsSequence);
        }

        /// <summary>
        /// 新增一张存货分类    
        /// </summary> 
        /// <return></return>
        public object add_inventoryclass() { return null; }
        /// <summary>
        /// 存货档案    获取单个存货信息 
        /// </summary> 
        /// <return></return>
        public async Task<InventoryResult> Get_InventoryAsync(string id, int dsSequence = 1)
        {
            return await GetSync<InventoryResult>(id, dsSequence);
        }
        /// <summary>
        /// 修改一个新存货 
        /// </summary> 
        /// <return></return>
        public object edit_inventory() { return null; }
        /// <summary>
        /// 批量获取存货信息    
        /// </summary> 
        /// <return></return>
        public async Task<List<Inventory>> Batch_Get_InventoryAsync(int dsSequence = 1)
        {
            return await GetsSync<InventoryListResult, Inventory>(dsSequence);
        }
        /// <summary>
        /// 添加一个新存货 
        /// </summary> 
        /// <return></return>
        public object add_inventory() { return null; }
        /// <summary>
        /// 客户  获取单个客户信息 
        /// </summary> 
        /// <return></return>
        public async Task<CustomerResult> Get_CustomerAsync(string id, int dsSequence = 1)
        {
            return await GetSync<CustomerResult>(id, dsSequence);
        }
        /// <summary>
        /// 修改一个客户  
        /// </summary> 
        /// <return></return>
        public object edit_customer() { return null; }
        /// <summary>
        /// 批量获取客户信息    
        /// </summary> 
        /// <return></return>
        public async Task<List<Customer>> Batch_Get_CustomerAsync(int dsSequence = 1)
        {
            return await GetsSync<CustomerListResult, Customer>(dsSequence);
        }
        /// <summary>
        /// 添加一个新客户 
        /// </summary> 
        /// <return></return>
        public object add_customer() { return null; }
        /// <summary>
        /// 客户分类    获取单个客户分类 
        /// </summary> 
        /// <return></return>
        public async Task<CustomerclassResult> Get_CustomerclassAsync(string id, int dsSequence = 1)
        {
            return await GetSync<CustomerclassResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取客户分类    
        /// </summary> 
        /// <return></return>
        public async Task<List<Customerclass>> Batch_Get_CustomerclassAsync(int dsSequence = 1)
        {
            return await GetsSync<CustomerclassListResult, Customerclass>(dsSequence);
        }
        /// <summary>
        /// 添加一个新客户分类   
        /// </summary> 
        /// <return></return>
        public object add_customerclass() { return null; }
        /// <summary>
        /// 客户地址    获取单个客户地址 
        /// </summary> 
        /// <return></return>
        public async Task<CustomeraddressResult> Get_CustomeraddressAsync(string id, int dsSequence = 1)
        {
            return await GetSync<CustomeraddressResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取客户地址    
        /// </summary> 
        /// <return></return>
        public async Task<List<Customeraddress>> Batch_Get_CustomeraddressAsync(int dsSequence = 1)
        {
            return await GetsSync<CustomeraddressListResult, Customeraddress>(dsSequence);
        }
        /// <summary>
        /// 客户联系人   获取单个客户联系人 
        /// </summary> 
        /// <return></return>
        public async Task<CustomercontactsResult> Get_CustomercontactsAsync(string id, int dsSequence = 1)
        {
            return await GetSync<CustomercontactsResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取客户联系人   
        /// </summary> 
        /// <return></return>
        public async Task<List<Customercontacts>> Batch_Get_CustomercontactsAsync(int dsSequence = 1)
        {
            return await GetsSync<CustomercontactsListResult, Customercontacts>(dsSequence);
        }
        /// <summary>
        /// 客户银行    获取单个客户银行信息 
        /// </summary> 
        /// <return></return>
        public async Task<Customer_BankResult> Get_Customer_BankAsync(string id, int dsSequence = 1)
        {
            return await GetSync<Customer_BankResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取客户银行信息  
        /// </summary> 
        /// <return></return>
        public async Task<List<Customer_Bank>> Batch_Get_Customer_BankAsync(int dsSequence = 1)
        {
            return await GetsSync<Customer_BankListResult, Customer_Bank>(dsSequence);
        }
        /// <summary>
        /// 币种  获取单个币种 
        /// </summary> 
        /// <return></return>
        public async Task<CurrencyResult> Get_CurrencyAsync(string id, int dsSequence = 1)
        {
            return await GetSync<CurrencyResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取币种  
        /// </summary> 
        /// <return></return>
        public async Task<List<Currency>> Batch_Get_CurrencyAsync(int dsSequence = 1)
        {
            return await GetsSync<CurrencyListResult, Currency>(dsSequence);
        }
        /// <summary>
        /// 常用摘要    获取单个常用摘要 
        /// </summary> 
        /// <return></return>
        public async Task<DigestResult> Get_DigestAsync(string id, int dsSequence = 1)
        {
            return await GetSync<DigestResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取常用摘要    
        /// </summary> 
        /// <return></return>
        public async Task<List<Digest>> Batch_Get_DigestAsync(int dsSequence = 1)
        {
            return await GetsSync<DigestListResult, Digest>(dsSequence);
        }
        /// <summary>
        /// 收发类别    获取单个收发类别 
        /// </summary> 
        /// <return></return>
        public async Task<ReceivesendtypeResult> Get_ReceivesendtypeAsync(string id, int dsSequence = 1)
        {
            return await GetSync<ReceivesendtypeResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取收发类别    
        /// </summary> 
        /// <return></return>
        public async Task<List<Receivesendtype>> Batch_Get_ReceivesendtypeAsync(int dsSequence = 1)
        {
            return await GetsSync<ReceivesendtypeListResult, Receivesendtype>(dsSequence);
        }
        /// <summary>
        /// 本单位开户银行 获取一个本单位开户银行 
        /// </summary> 
        /// <return></return>
        public async Task<AccountingbankResult> Get_AccountingbankAsync(string id, int dsSequence = 1)
        {
            return await GetSync<AccountingbankResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取本单位开户银行 
        /// </summary> 
        /// <return></return>
        public async Task<List<Accountingbank>> Batch_Get_AccountingbankAsync(int dsSequence = 1)
        {
            return await GetsSync<AccountingbankListResult, Accountingbank>(dsSequence);
        }
        /// <summary>
        /// 新增一个本单位开户银行 
        /// </summary> 
        /// <return></return>
        public object add_accountingbank() { return null; }
        /// <summary>
        /// 现金流量项目  获取单个现金流量项目 
        /// </summary> 
        /// <return></return>
        public async Task<CashflowitemResult> Get_CashflowitemAsync(string id, int dsSequence = 1)
        {
            return await GetSync<CashflowitemResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取现金流量项目  
        /// </summary> 
        /// <return></return>
        public async Task<List<Cashflowitem>> Batch_Get_CashflowitemAsync(int dsSequence = 1)
        {
            return await GetsSync<CashflowitemListResult, Cashflowitem>(dsSequence);
        }
        /// <summary>
        /// 科目  获取单个科目信息 
        /// </summary> 
        /// <return></return>
        public async Task<CodeResult> Get_CodeAsync(string id, int dsSequence = 1)
        {
            return await GetSync<CodeResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取科目信息    
        /// </summary> 
        /// <return></return>
        public async Task<List<Code>> Batch_Get_CodeAsync(int dsSequence = 1)
        {
            return await GetsSync<CodeListResult, Code>(dsSequence);
        }
        /// <summary>
        /// 结算方式    获取单个结算方式 
        /// </summary> 
        /// <return></return>
        public async Task<SettlestyleResult> Get_SettlestyleAsync(string id, int dsSequence = 1)
        {
            return await GetSync<SettlestyleResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取结算方式    
        /// </summary> 
        /// <return></return>
        public async Task<List<Settlestyle>> Batch_Get_SettlestyleAsync(int dsSequence = 1)
        {
            return await GetsSync<SettlestyleListResult, Settlestyle>(dsSequence);
        }
        /// <summary>
        /// 编码方案    获取单个编码方案 
        /// </summary> 
        /// <return></return>
        public async Task<CodeschemeResult> Get_CodeschemeAsync(string id, int dsSequence = 1)
        {
            return await GetSync<CodeschemeResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取编码方案    
        /// </summary> 
        /// <return></return>
        public async Task<List<Codescheme>> Batch_Get_CodeschemeAsync(int dsSequence = 1)
        {
            return await GetsSync<CodeschemeListResult, Codescheme>(dsSequence);
        }
        /// <summary>
        /// 职位档案    获取单个职位档案 
        /// </summary> 
        /// <return></return>
        public async Task<JobResult> Get_JobAsync(string id, int dsSequence = 1)
        {
            return await GetSync<JobResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取职位档案    
        /// </summary> 
        /// <return></return>
        public async Task<List<Job>> Batch_Get_JobAsync(int dsSequence = 1)
        {
            return await GetsSync<JobListResult, Job>(dsSequence);
        }
        /// <summary>
        /// 职务档案    获取单个职务档案 
        /// </summary> 
        /// <return></return>
        public async Task<DutyResult> Get_DutyAsync(string id, int dsSequence = 1)
        {
            return await GetSync<DutyResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取职务档案    
        /// </summary> 
        /// <return></return>
        public async Task<List<Duty>> Batch_Get_DutyAsync(int dsSequence = 1)
        {
            return await GetsSync<DutyListResult, Duty>(dsSequence);
        }
        /// <summary>
        /// 职务类别    获取单个职务类别 
        /// </summary> 
        /// <return></return>
        public async Task<DutytypeResult> Get_DutytypeAsync(string id, int dsSequence = 1)
        {
            return await GetSync<DutytypeResult>(id, dsSequence);
        }

        /// <summary>
        /// 批量获取职务类别    
        /// </summary> 
        /// <return></return>
        public async Task<List<Dutytype>> Batch_Get_DutytypeAsync(int dsSequence = 1)
        {
            return await GetsSync<DutytypeListResult, Dutytype>(dsSequence);
        }
        /// <summary>
        /// 自定义项档案  批量获取自定义项档案 
        /// </summary> 
        /// <return></return>
        public async Task<List<Define>> Batch_Get_DefineAsync(int dsSequence = 1)
        {
            return await GetsSync<DefineListResult, Define>(dsSequence);
        }
        /// <summary>
        /// 自由项 获取单个自由项信息 
        /// </summary> 
        /// <return></return>
        public async Task<FreearchResult> Get_FreearchAsync(string id, int dsSequence = 1)
        {
            return await GetSync<FreearchResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取自由项信息   
        /// </summary> 
        /// <return></return>
        public async Task<List<Freearch>> Batch_Get_FreearchAsync(int dsSequence = 1)
        {
            return await GetsSync<FreearchListResult, Freearch>(dsSequence);
        }
        /// <summary>
        /// 计量单位    获取单个计量单位信息 
        /// </summary> 
        /// <return></return>
        public async Task<UnitResult> Get_UnitAsync(string id, int dsSequence = 1)
        {
            return await GetSync<UnitResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取计量单位信息  
        /// </summary> 
        /// <return></return>
        public async Task<List<Unit>> Batch_Get_UnitAsync(int dsSequence = 1)
        {
            return await GetsSync<UnitListResult, Unit>(dsSequence);
        }

        /// <summary>
        /// 费用项目    获取单个费用项目 
        /// </summary> 
        /// <return></return>
        public async Task<ExpenseitemResult> Get_ExpenseitemAsync(string id, int dsSequence = 1)
        {
            return await GetSync<ExpenseitemResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取费用项目    
        /// </summary> 
        /// <return></return>
        public async Task<List<Expenseitem>> Batch_Get_ExpenseitemAsync(int dsSequence = 1)
        {
            return await GetsSync<ExpenseitemListResult, Expenseitem>(dsSequence);
        }
        /// <summary>
        /// 费用项目分类  获取单个费用项目分类 
        /// </summary> 
        /// <return></return>
        public async Task<ExpitemclassResult> Get_ExpitemclassAsync(string id, int dsSequence = 1)
        {
            return await GetSync<ExpitemclassResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取费用项目分类  
        /// </summary> 
        /// <return></return>
        public async Task<List<Expitemclass>> Batch_Get_ExpitemclassAsync(int dsSequence = 1)
        {
            return await GetsSync<ExpitemclassListResult, Expitemclass>(dsSequence);
        }
        /// <summary>
        /// 部门  获取单个部门信息 
        /// </summary> 
        /// <return></return>
        public async Task<DepartmentResult> Get_DepartmentAsync(string id, int dsSequence = 1)
        {
            return await GetSync<DepartmentResult>(id, dsSequence);
        }
        /// <summary>
        /// 修改一个部门  
        /// </summary> 
        /// <return></return>
        public object edit_department() { return null; }
        /// <summary>
        /// 批量获取部门信息    
        /// </summary> 
        /// <return></return>
        public async Task<List<Department>> Batch_Get_DepartmentAsync(int dsSequence = 1)
        {
            return await GetsSync<DepartmentListResult, Department>(dsSequence);
        }
        /// <summary>
        /// 添加一个新部门 
        /// </summary> 
        /// <return></return>
        public object add_department() { return null; }
        /// <summary>
        /// 银行  获取单个银行信息 
        /// </summary> 
        /// <return></return>
        public async Task<BankResult> Get_BankAsync(string id, int dsSequence = 1)
        {
            return await GetSync<BankResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取银行信息    
        /// </summary> 
        /// <return></return>Settlestyle
        public async Task<List<Bank>> Batch_Get_BankAsync(int dsSequence = 1)
        {
            return await GetsSync<BankListResult, Bank>(dsSequence);
        }
        /// <summary>
        /// 销售类型    获取单个销售类型 
        /// </summary> 
        /// <return></return>
        public async Task<SaletypeResult> Get_SaletypeAsync(string id, int dsSequence = 1)
        {
            return await GetSync<SaletypeResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取销售类型    
        /// </summary> 
        /// <return></return>
        public async Task<List<Saletype>> Batch_Get_SaletypeAsync(int dsSequence = 1)
        {
            return await GetsSync<SaletypeListResult, Saletype>(dsSequence);
        }
        /// <summary>
        /// 项目  批量获取项目信息 
        /// </summary> 
        /// <return></return>
        public async Task<List<Fitem>> Batch_Get_FitemAsync(int dsSequence = 1)
        {
            return await GetsSync<FitemListResult, Fitem>(dsSequence);
        }
        /// <summary>
        /// 添加一个新项目 
        /// </summary> 
        /// <return></return>
        public object add_fitem() { return null; }
        /// <summary>
        /// 项目分类    批量获取项目分类 
        /// </summary> 
        /// <return></return>
        public async Task<List<Fitemclass>> Batch_Get_FitemclassAsync(int dsSequence = 1)
        {
            return await GetsSync<FitemclassListResult, Fitemclass>(dsSequence);
        }
        /// <summary>
        /// 项目大类    获取单个项目大类 
        /// </summary> 
        /// <return></return>
        public async Task<FitemcategoryResult> Get_FitemcategoryAsync(string id, int dsSequence = 1)
        {
            return await GetSync<FitemcategoryResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取项目大类    
        /// </summary> 
        /// <return></return>
        public async Task<List<Fitemcategory>> Batch_Get_FitemcategoryAsync(int dsSequence = 1)
        {
            return await GetsSync<FitemcategoryListResult, Fitemcategory>(dsSequence);
        }

        /// <summary>
        /// 汇率    获取单个汇率
        /// </summary>        
        /// <returns></returns>
        public async Task<ExchangerateResult> Get_ExchangerateAsync(string id, int dsSequence = 1)
        {
            return await GetSync<ExchangerateResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取汇率
        /// </summary>        
        /// <returns></returns>
        public async Task<List<Exchangerate>> Batch_Get_ExchangerateAsync(int dsSequence = 1)
        {
            return await GetsSync<ExchangerateListResult, Exchangerate>(dsSequence);
        }

        /// <summary>
        /// 预算口径    获取单个预算口径
        /// </summary>        
        /// <returns></returns>
        public async Task<BudgetcaliberResult> Get_BudgetcaliberAsync(string id, int dsSequence = 1)
        {
            return await GetSync<BudgetcaliberResult>(id, dsSequence);
        }
        /// <summary>
        /// 批量获取预算口径
        /// </summary>        
        /// <returns></returns>
        public async Task<List<Budgetcaliber>> Batch_Get_BudgetcaliberAsync(int dsSequence = 1)
        {
            return await GetsSync<BudgetcaliberListResult, Budgetcaliber>(dsSequence);
        }
    }
}
