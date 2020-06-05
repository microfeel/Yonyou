using MicroFeel.Finance;
using MicroFeel.Finance.Interfaces;
using MicroFeel.Finance.Models;
using MicroFeel.Finance.Models.DbDto;
using MicroFeel.YonYou.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using Sugar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroFeel.YonYou.EntityFrameworkCore
{
    public class U8Service : IFinanceService
    {
        private U8DbContext db;

        public U8Service(U8DbContext dbcontext)
        {
            db = dbcontext;
        }

        Customer IBasicService.AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        Customer IBasicService.AddCustomer(Customer customer, string predicate, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        Department IBasicService.AddDepartment(Department dep)
        {
            throw new NotImplementedException();
        }

        Emp IBasicService.AddEmployee(Emp emp)
        {
            throw new NotImplementedException();
        }

        Emp IBasicService.AddEmployee(Emp emp, string predicate, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        Item IBasicService.AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        Material IBasicService.AddMaterial(Material material)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.AddMaterialOrder(DtoStockOrder order, ref string errmsg)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.AddMetarialApply(DtoStockOrder order)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.AddPuarrivalVouch(DtoStockOrder order)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.AddPurchaseArrivalVouch(DtoStockOrder order)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.AddPurchaseOrder(DtoStockOrder order)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.AddReturnMetarialApply(DtoStockOrder order)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.AddSellOrder(DtoStockOrder order, ref string errmsg)
        {
            throw new NotImplementedException();
        }

        Supplier IBasicService.AddSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        Voucher IVoucherService.AddVoucher(IList<VoucherParmEntry> voucherParams, string explanation, string reference, string preparer, int groupID, DateTime date, DateTime transDate, string objectName, string parameter)
        {
            throw new NotImplementedException();
        }

        Voucher IVoucherService.AddVoucher(VoucherInfo voucherInfo)
        {
            throw new NotImplementedException();
        }

        IDbContextTransaction IDbOperation.BeginTransaction()
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.CheckAllotInRecord(string orderno)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.CheckAllotOutRecord(string orderno)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.CheckAllotOutRecord(string orderno, string autoid)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.ClosePurarrivalOrderTransaction(string orderno, string closer, Func<bool, bool> action)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.FromPuArrivalVouchToStoreRecord(string puarrivalOrderNo)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.FromPuArrivalVouchToStoreRecord(string puarrivalOrderNo, Dictionary<string, string> batchs)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.FromPuArrivalVouchToStoreRecord(string puarrivalOrderNo, string sendOrderNo)
        {
            throw new NotImplementedException();
        }

        IList<Account> IVoucherService.GetAccount()
        {
            throw new NotImplementedException();
        }

        List<DtoPurchaseOrder> IDbOperation.GetAffirmPOs(string brand, string suppliercode, int pageindex, int pagesize, out int total)
        {
            throw new NotImplementedException();
        }

        List<DtoAllotInRecord> IDbOperation.GetAllotInRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize, out int total)
        {
            throw new NotImplementedException();
        }

        List<DtoAllotOrder> IDbOperation.GetAllotOrders(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize, out int total)
        {
            throw new NotImplementedException();
        }

        List<DtoAllotOutRecord> IDbOperation.GetAllotOutRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize, out int total)
        {
            throw new NotImplementedException();
        }

        List<DtoAllotRecord> IDbOperation.GetAllotRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize, out int total)
        {
            throw new NotImplementedException();
        }

        string IDbOperation.GetAllotTargetWHCode(string outorderno)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Datasource>> IPlatformService.GetBatchDatasourceAsync()
        {
            throw new NotImplementedException();
        }

        List<DtoPurchaseOrder> IDbOperation.GetCheckedPOs(string brand, string suppliercode, int pageindex, int pagesize, out int total)
        {
            throw new NotImplementedException();
        }

        Dictionary<string, string> IDbOperation.GetCustomers()
        {
            throw new NotImplementedException();
        }

        DtoCustomer IDbOperation.GetCustomers(string code)
        {
            throw new NotImplementedException();
        }

        (string, string) IDbOperation.GetCustomersByDispatch(string orderno)
        {
            throw new NotImplementedException();
        }

        DtoCustomer IDbOperation.GetCustomersByOrderNo(string orderno)
        {
            throw new NotImplementedException();
        }

        List<DtoPurchaseOrder> IDbOperation.GetDeliverPOs(string brand, string suppliercode, int pageindex, int pagesize, out int total)
        {
            throw new NotImplementedException();
        }

        Dictionary<string, string> IDbOperation.GetDepartments()
        {
            throw new NotImplementedException();
        }

        Dictionary<string, string> IDbOperation.GetDepartments(string departmentcode)
        {
            throw new NotImplementedException();
        }

        DtoInventory IDbOperation.GetInventory(string productcode)
        {
            throw new NotImplementedException();
        }

        (int, List<DtoInventory>) IDbOperation.GetInventory(string brand, string classcode, string stroecode, string key, int pageindex, int pagesize)
        {
            throw new NotImplementedException();
        }

        List<DtoInventory> IDbOperation.GetInventory(string brand, string classcode, string storecode, string key, int pageindex, int pagesize, out int total)
        {
            throw new NotImplementedException();
        }

        List<DtoProductClass> IDbOperation.GetInventoryClass(string cwhcode)
        {
            throw new NotImplementedException();
        }

        List<DtoProductClass> IDbOperation.GetInventoryClass()
        {
            throw new NotImplementedException();
        }

        List<DtoMaterialOrderDetail> IDbOperation.GetMaterialDetails(string orderno)
        {
            throw new NotImplementedException();
        }

        List<DtoMaterialOrder> IDbOperation.GetMaterialOrders(string brand, string departmentcode)
        {
            throw new NotImplementedException();
        }

        List<DtoMaterialOrder> IDbOperation.GetMaterials(string departmentcode, string key, DateTime? starttime, DateTime? endtime, int pageindex, int pagesize, out int total)
        {
            throw new NotImplementedException();
        }

        DtoMaterialOrder IDbOperation.GetMaterials(string orderno)
        {
            throw new NotImplementedException();
        }

        Task<OrderStatus> IPlatformService.GetOrderStatusAsync()
        {
            throw new NotImplementedException();
        }

        SingleObjectResult<Outsourcing> IOutsourcingService.GetOutsourcing(string orderno, string productnumbers)
        {
            throw new NotImplementedException();
        }

        SingleObjectResult<Outsourcing> IOutsourcingService.GetOutsourcing(string orderno)
        {
            throw new NotImplementedException();
        }

        List<DtoOutsourcingOrder> IDbOperation.GetOutsourcingOrders(string brand, string key, string supplier, DateTime? starttime, DateTime? endtime, int pageindex, int pagesize, out int total)
        {
            throw new NotImplementedException();
        }

        DataResult<Outsourcing> IOutsourcingService.GetOutsourcings(int pageindex, int pagesize, Action<Outsourcing> wherecodition)
        {
            throw new NotImplementedException();
        }

        List<DtoPurchaseOrder> IDbOperation.GetOverPOs(string brand, string suppliercode, int pageindex, int pagesize, out int total)
        {
            throw new NotImplementedException();
        }

        DtoPerson IDbOperation.GetPerson(string code)
        {
            throw new NotImplementedException();
        }

        DtoPerson IDbOperation.GetPersonByName(string name)
        {
            throw new NotImplementedException();
        }

        DtoPerson IDbOperation.GetPersonByPhone(string phonecode)
        {
            throw new NotImplementedException();
        }

        List<Store> IBasicService.GetPlaces(string storecode)
        {
            throw new NotImplementedException();
        }

        List<DtoPurchaseOrderDetail> IDbOperation.GetPODetails(string orderno)
        {
            throw new NotImplementedException();
        }

        DtoPurchaseOrder IDbOperation.GetPurchaseOrder(string ordertype, string brand, string orderno, string state)
        {
            throw new NotImplementedException();

        }

        PagedResult<DtoPurchaseOrder> IDbOperation.GetPurchaseOrders(string ordertype, string brand, string key, string supplier, string state, DateTime? starttime, DateTime? endtime, int pageindex, int pagesize)
        {
            var list = db.GetPurchaseOrders(ordertype, brand, key, supplier, state, starttime, endtime, 1, 20);
            return new PagedResult<DtoPurchaseOrder>(list.TotalCount, list.Results.Select(p => p.GetDtoPurchaseOrder()));
        }

        List<DtoSellOrder> IDbOperation.GetSellOrders(string brand, string orderno, bool isclose)
        {
            throw new NotImplementedException();
        }

        List<Store> IBasicService.GetStores(string brand)
        {
            throw new NotImplementedException();
        }

        DtoSupplier IDbOperation.GetSupplier(string code)
        {
            throw new NotImplementedException();
        }

        DtoSupplier IDbOperation.GetSupplierByPhone(string phonecode)
        {
            throw new NotImplementedException();
        }

        IList<VoucherTemplate> IVoucherService.GetVoucherTemplate(IEnumerable<string> tempTypeNames)
        {
            throw new NotImplementedException();
        }

        IList<VoucherTemplate> IVoucherService.GetVoucherTemplate()
        {
            throw new NotImplementedException();
        }

        Dictionary<string, string> IDbOperation.GetWarehouses()
        {
            return db.GetWarehouses();
        }

        List<Store> IBasicService.GetWorkShops(string brand)
        {
            throw new NotImplementedException();
        }

        Task<Datasource> IPlatformService.Get_DatasourceAsync()
        {
            throw new NotImplementedException();
        }

        bool IStockService.Materialout(Materialout materialout)
        {
            throw new NotImplementedException();
        }

        bool IStockService.OtherIn(Otherin otherin)
        {
            throw new NotImplementedException();
        }

        bool IStockService.OtherOut(Otherout otherout)
        {
            throw new NotImplementedException();
        }

        bool IStockService.ProductIn(Productin productin)
        {
            throw new NotImplementedException();
        }

        Task<bool> IStockService.PurchaseInAsync(Purchasein purchasein, string purchaseorderno)
        {
            throw new NotImplementedException();
        }

        bool IStockService.Saleout(Saleout saleout)
        {
            throw new NotImplementedException();
        }

        Task<string> IPlatformService.TokenAsync()
        {
            throw new NotImplementedException();
        }

        Task<string> IPlatformService.TradeidAsync()
        {
            throw new NotImplementedException();
        }

        bool IStockService.Transvouch(Transvouch transvouch)
        {
            throw new NotImplementedException();
        }

        MessageResult IOutsourcingService.UpdateOutsourcing(Outsourcing outsourcing)
        {
            throw new NotImplementedException();
        }

        bool IDbOperation.UpdatePurchaseOrderState(string orderno, string state)
        {
            throw new NotImplementedException();
        }
    }
}
