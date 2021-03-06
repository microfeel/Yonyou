﻿using MicroFeel.Finance;
using MicroFeel.Finance.Interfaces;
using MicroFeel.Finance.Models;
using MicroFeel.Finance.Models.DbDto;
using MicroFeel.YonYou.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Sugar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroFeel.YonYou.EntityFrameworkCore
{
    public class U8Service : IFinanceService
    {
        private U8DbContext db;
        public U8Service() { }

        public U8Service(U8DbContext dbcontext)
        {
            db = dbcontext;
        }

        /// <summary>
        /// 给测试或老系统使用的构造函数
        /// </summary>
        /// <param name="connectionString"></param>
        public U8Service(string connectionString)
        {
            var options = new DbContextOptionsBuilder<U8DbContext>().UseSqlServer(connectionString).Options;
            db = new U8DbContext(options);
        }

        void IDisposable.Dispose()
        {
            db.Dispose();
        }

        public Customer AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer AddCustomer(Customer customer, string predicate, params object[] parameters)
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

        Supplier IBasicService.AddSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }
        IList<Account> IVoucherService.GetAccount()
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

        Task<IEnumerable<Datasource>> IPlatformService.GetBatchDatasourceAsync()
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

        List<Store> IBasicService.GetPlaces(string storecode)
        {
            throw new NotImplementedException();
        }

        DataResult<Outsourcing> IOutsourcingService.GetOutsourcings(int pageindex, int pagesize, Action<Outsourcing> wherecodition)
        {
            throw new NotImplementedException();
        }
        List<Store> IBasicService.GetStores(string brand)
        {
            throw new NotImplementedException();
        }

        #region DB
        void IDbOperation.AddMaterialOrder(DtoStockOrder order)
        {
            db.AddMaterialOrder(order);
        }

        void IDbOperation.AddMetarialApply(DtoStockOrder order)
        {
            db.AddMetarialApply(order);
        }

        void IDbOperation.AddPuarrivalVouch(DtoStockOrder order)
        {
            db.AddPuarrivalVouch(order);
        }

        void IDbOperation.AddPurchaseArrivalVouch(DtoStockOrder order)
        {
            db.AddPurchaseArrivalVouch(order);
        }

        void IDbOperation.AddPurchaseOrder(DtoStockOrder order)
        {
            db.AddPurchaseOrder(order);
        }
        /// <summary>
        /// 添加退料申请单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>

        void IDbOperation.AddReturnMetarialApply(DtoStockOrder order)
        {
            db.AddReturnMetarialApply(order);
        }

        void IDbOperation.AddSellOrder(DtoStockOrder order)
        {
            db.AddSellOrder(order);
        }

        //IDbContextTransaction IDbOperation.BeginTransaction()
        //{
        //    return db.Database.BeginTransaction();
        //}

        bool IDbOperation.CheckAllotInRecord(string orderno)
        {
            return db.CheckAllotInRecord(orderno);
        }

        bool IDbOperation.CheckAllotOutRecord(string orderno)
        {
            return db.CheckAllotOutRecord(orderno);
        }

        bool IDbOperation.CheckAllotOutRecord(string orderno, string autoid)
        {
            return db.CheckAllotOutRecord(orderno, autoid);
        }

        void IDbOperation.ClosePurarrivalOrderTransaction(string orderno, string closer, Func<bool, bool> action)
        {
            db.ClosePurarrivalOrderTransaction(orderno, closer, action);
        }

        void IDbOperation.FromPuArrivalVouchToStoreRecord(string puarrivalOrderNo, string maker)
        {
            db.FromPuArrivalVouchToStoreRecord(puarrivalOrderNo, maker);
        }

        void IDbOperation.FromPuArrivalVouchToStoreRecord(string puarrivalOrderNo, Dictionary<string, string> batchs, string maker)
        {
            db.FromPuArrivalVouchToStoreRecord(puarrivalOrderNo, batchs, maker);
        }

        void IDbOperation.FromPuArrivalVouchToStoreRecord(string puarrivalOrderNo, string sendOrderNo, string maker)
        {
            db.FromPuArrivalVouchToStoreRecord(puarrivalOrderNo, sendOrderNo, maker);
        }

        PagedResult<DtoPurchaseOrder> IDbOperation.GetAffirmPOs(string brand, string suppliercode, int pageindex, int pagesize)
        {
            var list = db.GetAffirmPOs(brand, suppliercode, pageindex, pagesize);
            return new PagedResult<DtoPurchaseOrder>(list.TotalCount, list.Results.Select(v => v.GetDtoPurchaseOrder()), list.PageIndex, list.PageSize);
        }

        PagedResult<DtoAllotInRecord> IDbOperation.GetAllotInRecords(string brand,
            string orderno,
            DateTime? starttime,
            DateTime? endtime,
            bool isChecked,
            int pageindex,
            int pagesize)
        {
            var list = db.GetAllotInRecords(brand, orderno, starttime, endtime, isChecked, pageindex, pagesize);
            return new PagedResult<DtoAllotInRecord>(list.TotalCount, list.Results.Select(v => v.GetDtoAllotInOrder()), list.PageIndex, list.PageSize);
        }

        PagedResult<DtoAllotOrder> IDbOperation.GetAllotOrders(
            string brand,
            string orderno,
            DateTime? starttime,
            DateTime? endtime,
            bool isChecked,
            int pageindex,
            int pagesize)
        {
            var list = db.GetAllotOrders(brand, orderno, starttime, endtime, isChecked, pageindex, pagesize);
            return new PagedResult<DtoAllotOrder>(list.TotalCount, list.Results.Select(v => v.GetDtoAllotOrder()), list.PageIndex, list.PageSize);
        }

        PagedResult<DtoAllotOutRecord> IDbOperation.GetAllotOutRecords(
            string brand,
            string orderno,
            DateTime? starttime,
            DateTime? endtime,
            bool isChecked,
            int pageindex,
            int pagesize)
        {
            var list = db.GetAllotOutRecords(brand, orderno, starttime, endtime, isChecked, pageindex, pagesize);
            return new PagedResult<DtoAllotOutRecord>(list.TotalCount, list.Results.Select(v => v.GetDtoAllotOutOrder()), list.PageIndex, list.PageSize);
        }

        PagedResult<DtoAllotRecord> IDbOperation.GetAllotRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize)
        {
            var list = db.GetAllotRecords(brand, orderno, starttime, endtime, isChecked, pageindex, pagesize);
            return new PagedResult<DtoAllotRecord>(list.TotalCount, list.Results.Select(v => v.GetDtoAllotRecord()), list.PageIndex, list.PageSize);
        }

        string IDbOperation.GetAllotTargetWHCode(string outorderno)
        {
            return db.GetAllotTargetWHCode(outorderno);
        }

        PagedResult<DtoPurchaseOrder> IDbOperation.GetCheckedPOs(string brand, string suppliercode, int pageindex, int pagesize)
        {
            var list = db.GetCheckedPOs(brand, suppliercode, pageindex, pagesize);
            return new PagedResult<DtoPurchaseOrder>(list.TotalCount, list.Results.Select(v => v.GetDtoPurchaseOrder()), list.PageIndex, list.PageSize);
        }

        Dictionary<string, string> IDbOperation.GetCustomers()
        {
            return db.GetCustomers();
        }

        DtoCustomer IDbOperation.GetCustomers(string code)
        {
            return db.GetCustomersAsync(code).ConfigureAwait(false).GetAwaiter().GetResult().ToDtoCustomer();
        }

        (string, string) IDbOperation.GetCustomersByDispatch(string orderno)
        {
            throw new NotImplementedException();
        }

        DtoCustomer IDbOperation.GetCustomersByOrderNo(string orderno)
        {
            return db.GetCustomersByOrderNoAsync(orderno).ConfigureAwait(false).GetAwaiter().GetResult().ToDtoCustomer();
        }

        PagedResult<DtoPurchaseOrder> IDbOperation.GetDeliverPOs(string brand, string suppliercode, int pageindex, int pagesize)
        {
            var list = db.GetDeliverPOs(brand, suppliercode, pageindex, pagesize);
            return new PagedResult<DtoPurchaseOrder>(list.TotalCount, list.Results.Select(v => v.GetDtoPurchaseOrder()), list.PageIndex, list.PageSize);
        }

        Dictionary<string, string> IDbOperation.GetDepartments()
        {
            return db.GetDepartments();
        }

        Dictionary<string, string> IDbOperation.GetDepartments(string departmentcode)
        {
            return db.GetDepartments(departmentcode);
        }

        DtoInventory IDbOperation.GetInventory(string productcode)
        {
            return db.GetInventory(productcode).GetDtoInventory();
        }

        DtoInventory IDbOperation.GetInventory(string productcode, string batch)
        {
            return db.GetInventory(productcode, batch).GetDtoInventory();
        }

        PagedResult<DtoInventory> IDbOperation.GetInventory(string brand, string classcode, string storecode, string key, int pageindex, int pagesize)
        {
            var list = db.GetInventory(brand, classcode, storecode, key, pageindex, pagesize);
            return new PagedResult<DtoInventory>(list.TotalCount, list.Results.Select(v => v.GetDtoInventory()), list.PageIndex, list.PageSize);
        }

        List<DtoProductClass> IDbOperation.GetInventoryClass(string cwhcode)
        {
            return db.GetInventoryClass(cwhcode).Select(v => v.ToDtoProductClass()).ToList();
        }

        List<DtoProductClass> IDbOperation.GetInventoryClass()
        {
            return db.GetInventoryClass().Select(v => v.ToDtoProductClass()).ToList();
        }

        List<DtoMaterialOrderDetail> IDbOperation.GetMaterialDetails(string orderno)
        {
            return db.GetMaterialDetails(orderno).Select(v => v.GetDtoMaterialOrderDetail()).ToList();
        }

        List<DtoMaterialOrder> IDbOperation.GetMaterialOrders(string brand, string departmentcode)
        {
            return db.GetMaterialOrders(brand, departmentcode).Select(v => v.GetDtoMaterialOrder()).ToList();
        }

        public PagedResult<DtoMaterialOrder> GetMaterials(string departmentcode, string key, DateTime? starttime, DateTime? endtime, int pageindex, int pagesize)
        {
            var list = db.GetMaterials(departmentcode, key, starttime, endtime, pageindex, pagesize);
            return new PagedResult<DtoMaterialOrder>(list.TotalCount, list.Results.Select(v => v.GetDtoMaterialOrder()), list.PageIndex, list.PageSize);
        }

        public PagedResult<DtoMaterialOrder> GetMaterials(string departmentcode, string key, int pageindex, int pagesize)
        {
            var list = db.GetMaterials(departmentcode, key, pageindex, pagesize);
            return new PagedResult<DtoMaterialOrder>(list.TotalCount, list.Results.Select(v => v.GetDtoMaterialOrder()), list.PageIndex, list.PageSize);
        }

        public DtoMaterialOrder GetMaterials(string orderno)
        {
            return db.GetMaterials(orderno).GetDtoMaterialOrder();
        }

        PagedResult<DtoOutsourcingOrder> IDbOperation.GetOutsourcingOrders(string brand, string key, string supplier, DateTime? starttime, DateTime? endtime, int pageindex, int pagesize)
        {
            var list = db.GetOutsourcingOrders(brand, key, supplier, starttime, endtime, pageindex, pagesize);
            return new PagedResult<DtoOutsourcingOrder>(list.TotalCount, list.Results.Select(v => v.GetDtoOutsourcingOrder()), list.PageIndex, list.PageSize);
        }

        PagedResult<DtoPurchaseOrder> IDbOperation.GetOverPOs(string brand, string suppliercode, int pageindex, int pagesize)
        {
            var list = db.GetOverPOs(brand, suppliercode, pageindex, pagesize);
            return new PagedResult<DtoPurchaseOrder>(list.TotalCount, list.Results.Select(v => v.GetDtoPurchaseOrder()), list.PageIndex, list.PageSize);
        }

        DtoPerson IDbOperation.GetPerson(string code)
        {
            var person = db.GetPersonAsync(code).ConfigureAwait(false).GetAwaiter().GetResult()
                ?? throw new NullReferenceException($"没有找到编号为{code}的用友用户");
            return person.ToDtoPerson();
        }

        DtoPerson IDbOperation.GetPersonByName(string name)
        {
            var person = db.GetPersonByNameAsync(name).ConfigureAwait(false).GetAwaiter().GetResult()
                ?? throw new NullReferenceException($"没有找到名称为{name}的用友用户");

            return person.ToDtoPerson();
        }

        DtoPerson IDbOperation.GetPersonByPhone(string phonecode)
        {
            var person = db.GetPersonByPhoneAsync(phonecode).ConfigureAwait(false).GetAwaiter().GetResult()
                ?? throw new NullReferenceException($"没有找到手机号为{phonecode}的用友用户");
            return person.ToDtoPerson();
        }

        List<DtoPurchaseOrderDetail> IDbOperation.GetPODetails(string orderno)
        {
            return db.GetPODetails(orderno).Select(v => v.GetDtoPurchaseOrderDetail()).ToList();
        }

        DtoPurchaseOrder IDbOperation.GetPurchaseOrder(string ordertype, string brand, string orderno, string state)
        {
            return db.GetPurchaseOrders(ordertype, brand, orderno, state).GetDtoPurchaseOrder();

        }

        /// <summary>
        /// 获取采购订单
        /// </summary>
        /// <param name="ordertype"></param>
        /// <param name="brand"></param>
        /// <param name="key"></param>
        /// <param name="supplier"></param>
        /// <param name="state"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        PagedResult<DtoPurchaseOrder> IDbOperation.GetPurchaseOrders(string ordertype, string brand, string key, string supplier, string state, DateTime? starttime, DateTime? endtime, int pageindex, int pagesize)
        {
            var list = db.GetPurchaseOrders(ordertype, brand, key, supplier, state, starttime, endtime, pageindex, pagesize);
            return new PagedResult<DtoPurchaseOrder>(list.TotalCount, list.Results.Select(p => p.GetDtoPurchaseOrder()), list.PageIndex, list.PageSize);
        }

        List<DtoSellOrder> IDbOperation.GetSellOrders(string brand, string orderno, bool isclose)
        {
            return db.GetSellOrders(brand, orderno, isclose).Select(v => v.GetDtoSellOrder()).ToList();
        }

        DtoSupplier IDbOperation.GetSupplier(string code)
        {
            return db.GetSupplierAsync(code).ConfigureAwait(false).GetAwaiter().GetResult().GetDtoSupplier();
        }

        DtoSupplier IDbOperation.GetSupplierByPhone(string phonecode)
        {
            return db.GetSupplierByPhoneAsync(phonecode).ConfigureAwait(false).GetAwaiter().GetResult().GetDtoSupplier();
        }

        public Dictionary<string, string> GetWarehouses()
        {
            return db.GetWarehouses();
        }

        public void UpdatePurchaseOrderState(string orderno, string state)
        {
            db.UpdatePurchaseOrderState(orderno, state);
        }

        /// <summary>
        /// 更新发货单状态
        /// </summary>
        /// <param name="billNo"></param>
        /// <param name="statusName"></param>
        public void UpdateDispatchBillState(string billNo, string statusName)
        {
            db.UpdateDispatchBillState(billNo, statusName);
        }
        /// <summary>
        /// 获取发货单列表
        /// </summary>
        /// <param name="brand">品牌</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="billState">单据状态</param>
        /// <returns></returns>
        public PagedResult<DispatchBill> GetDispatchBills(string brand, int pageIndex, int pageSize, DispatchBillState billState)
        {
            var list = db.GetDispatchBills(brand, pageIndex, pageSize, billState);
            return new PagedResult<DispatchBill>(list.TotalCount, list.Results.Select(dl => dl.GetDispatchBill()), list.PageIndex, list.PageSize);
        }


        /// <summary>
        /// 获取指定单号的发货单明细
        /// </summary>
        /// <param name="billNo">单号</param>
        /// <returns></returns>
        public IList<DispatchBillDetail> GetDispatchBillDetail(string billNo)
        {
            return db.GetDispatchBillDetail(billNo).Select(v => v.GetDispatchBillDetail()).ToList();
        }

        /// <summary>
        /// 获取到货单
        /// </summary>
        /// <param name="orderno">到货单号</param>
        /// <returns></returns>
        public DtoPurchaseOrder GetPuArrVoucherOrder(string orderno)
        {
            var order = db.PuArrHead.FirstOrDefault(v => v.Ccode == orderno);
            order.Details = db.PuArrbody.Where(t => t.Id == order.Id).ToList();
            return order.GetDtoPurchaseOrder();
        }

        /// <summary>
        /// 获取委外订单原材料领用数据
        /// </summary>
        /// <param name="ommainBillNo">委外单号</param>
        /// <returns></returns>
        public IEnumerable<OmMaterialRecord> GetOmMaterialRecords(string ommainBillNo)
        {
            var ommain = db.GetFirstOrDefault<Data.OmMomain>(v => v.CCode == ommainBillNo)
                ?? throw new FinancialException($"无法找到单号为{ommainBillNo}的委外订单");
            return db.OmMomaterials.Where(v => v.Moid == ommain.Moid).Select(m => new OmMaterialRecord
            {
                MoDetailId = m.MoDetailsId,
                CInvCode = m.CInvCode,
                IQuantity = m.IQuantity,
                IUnitQuantity = m.IUnitQuantity,
                ISendQty = m.ISendQty,
                FBaseQtyN = m.FBaseQtyN ?? 1,
                FBaseQtyD = m.FBaseQtyD ?? 1
            });
        }

        public DispatchBill GetDispatchBillByCode(string billNo)
        {
            var bill = db.GetDispatchBillByCode(billNo);
            return bill.GetDispatchBill();
        }

        /// <summary>
        /// 生产退料
        /// </summary>
        /// <param name="dtoStockOrder"></param>
        public void BackStore(DtoBackStore order)
        {
            db.CreateRdrecord11(order);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="billno"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        public IEnumerable<DtoOutRecord> GetOmMomainRecords(string billno, bool includeDetails)
        {
            var bills = db.GetOmMainRdrecords(billno, includeDetails);
            var material = db.GetMaterialDetails(billno);
            var results = new List<DtoOutRecord>();
            foreach (var bill in bills)
            {
                foreach (var record in bill.Details)
                {
                    var invtory = db.GetInventory(record.CInvCode, record.CBatch);
                    results.Add(new DtoOutRecord
                    {
                        AutoId = record.AutoId,
                        Name = invtory.CInvName,
                        InvCode = record.CInvCode,
                        Batch = record.CBatch,
                        SendQuantity = record.IQuantity ?? 0,
                        WhCode = bill.CWhCode,
                        OrderNo = bill.CCode,
                        //可退料数
                        RQuantity = material.First(v => v.Cinvcode == record.CInvCode).AllowReturnQty,
                        Unit = invtory.UnitName,
                    });
                }
            }
            return results;
        }

        public void VerifyDispatchBill(string billNo, string makerName)
        {
            db.VerifyDispatchBill(billNo, makerName);
        }

        public List<OmModetailDto> GetOmMomainDetails(string mainNo)
        {
            var details = db.GetOmMomain(mainNo).Details;
            return details.Select(d => d.toMoDetailDto()).ToList();
        }
        #endregion

    }
}
