using MicroFeel.Finance;
using MicroFeel.Finance.Models;
using MicroFeel.Finance.Models.DbDto;
using MicroFeel.YonYou.EntityFrameworkCore.Data;
using MicroFeel.YonYou.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Sugar.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicroFeel.YonYou.EntityFrameworkCore
{
    public partial class U8DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("U8dbcontext options not configured!");
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

        }

        public async Task<TEntity> GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return await Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return Set<TEntity>().Where(expression);
        }

        public Dictionary<string, string> GetCustomers()
        {
            return Customer.ToDictionary(t => t.CCusCode, t => t.CCusName);
        }

        public async Task<Data.Customer> GetCustomersAsync(string code)
        {
            return await GetFirstAsync<Data.Customer>(c => c.CCusCode == code).ConfigureAwait(false);
        }

        public (string, string) GetCustomersByDispatch(string orderno)
        {
            var code = DispatchList.FirstOrDefault(t => t.CDlcode == orderno)?.CCusCode;
            var c = Customer.FirstOrDefault(t => t.CCusCode == code);
            if (c == null) return (null, null);
            return ($"{c.CProvince + c.CCity}", c.CCusAddress);
        }

        public async Task<Data.Customer> GetCustomersByOrderNoAsync(string orderno)
        {
            var code = (await GetFirstAsync<DispatchList>(d => d.CDlcode == orderno))?.CCusCode ?? throw new Exception($"无法找到orderno为{orderno}的DispatchList。");
            return await GetFirstAsync<Data.Customer>(t => t.CCusCode == code);
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetDepartments()
        {
            return Department.Where(t => t.BDepEnd == true).ToDictionary(t => t.CDepCode, t => t.CDepName);
        }

        public Dictionary<string, string> GetDepartments(string departmentcode)
        {
            return Department.Where(t => t.BDepEnd == true && t.CDepCode == departmentcode).ToDictionary(t => t.CDepCode, t => t.CDepName);
        }
        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetWarehouses()
        {
            return Warehouse.ToDictionary(t => t.CWhCode, t => t.CWhName);
        }

        public List<InventoryClass> GetInventoryClass()
        {
            return InventoryClass.ToList();
        }

        public async Task<Person> GetPersonByPhoneAsync(string phonecode)
        {
            return await GetFirstAsync<Person>(t => t.CPersonPhone == phonecode);
        }

        public async Task<Person> GetPersonAsync(string code)
        {
            return await GetFirstAsync<Person>(t => t.CPersonCode == code).ConfigureAwait(false);
        }

        public async Task<Person> GetPersonByNameAsync(string name)
        {
            return await GetFirstAsync<Person>(t => t.CPersonName == name).ConfigureAwait(false);
        }

        public async Task<Vendor> GetSupplierByPhoneAsync(string phonecode)
        {
            return await GetFirstAsync<Vendor>(t => t.CVenPhone == phonecode).ConfigureAwait(false);
        }

        public async Task<Vendor> GetSupplierAsync(string code)
        {
            return await GetFirstAsync<Vendor>(t => t.CVenCode == code).ConfigureAwait(false);
        }

        /// <summary>
        /// 获取商品大类
        /// </summary>
        /// <param name="cwhcode"></param>
        /// <returns></returns>
        public List<InventoryClass> GetInventoryClass(string cwhcode)
        {
            return CurrentStock.Where(t => t.CWhCode == cwhcode || string.IsNullOrEmpty(cwhcode))
                .Select(t => t.CInvCode)
                .Distinct()
                .Join(Inventory, t => t, c => c.CInvCode, (t, c) => c)
                .Join(InventoryClass, t => t.CInvCcode, c => c.CInvCcode, (t, c) => c)
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// 获取委外生产产品明细单
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="key"></param>
        /// <param name="supplier"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public PagedResult<OmModetails> GetOutsourcingOrders(string brand, string key, string supplier, DateTime? starttime, DateTime? endtime, int pageindex, int pagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            var tmp_datas = OmMomain.Where(t => t.CState > 0 && t.CDefine8 == brand &&
                                                        (string.IsNullOrEmpty(key) || t.CCode.Contains(key)) &&
                                                        (string.IsNullOrEmpty(supplier) || t.CVenPerson.Contains(supplier)) &&
                                                        (starttime == null || t.DDate >= starttime) &&
                                                        (endtime == null || t.DDate <= endtime))
                .Join(OmModetails, t => t.Moid, d => d.Moid, (t, d) => new { t, d })
                .Where(t => (t.d.IQuantity - (t.d.IArrQty ?? t.d.IReceivedQty ?? t.d.Freceivedqty ?? 0)) > 0);
            var total = tmp_datas.Count();
            var datas = tmp_datas.Skip(pageindex * pagesize).Take(pagesize).ToList().Select(t =>
            {
                var product = Inventory.FirstOrDefault(i => i.CInvCode == t.d.CInvCode);
                return new OmModetails()
                {
                    OrderDate = t.t.DDate,
                    OrderNo = t.t.CCode,
                    ProductName = product?.CInvName,
                    ProductModel = product.CInvStd,
                    ProductNumbers = t.d.CInvCode
                };
            }).ToList();
            return new PagedResult<OmModetails>(total, datas);
        }

        /// <summary>
        /// 获取销售发货单
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="orderno"></param>
        /// <param name="isclose"></param>
        /// <returns></returns>
        public List<SaDispatchlist> GetSellOrders(string brand, string orderno, bool isclose = false)
        {
            var query = SaDispatchlist.Where(t => t.Cdefine8 == brand && (string.IsNullOrEmpty(orderno) || t.Cdlcode.Contains(orderno)));
            if (isclose)
                query.Where(t => t.Ivouchstate == "Closed");
            else
                query.Where(t => t.Ivouchstate == "Approved");

            var orders = query.ToList();
            orders.ForEach(
                async o =>
                {
                    var customer = await GetFirstAsync<Data.Customer>(c => c.CCusCode == o.Ccuscode);
                    o.Receiver = customer.CCusPerson;
                    o.ReceiveTel = customer.CCusPhone;
                    o.RecevieAddress = customer.CCusAddress;
                    o.Details = DispatchLists.Where(t => t.Dlid == o.Dlid && ((t.IQuantity ?? 0) - (t.FOutQuantity ?? 0)) > 0).ToList();
                });
            return orders;
        }

        /// <summary>
        /// 获取采购到货单
        /// </summary>
        /// <param name="ordertype"></param>
        /// <param name="brand"></param>
        /// <param name="orderno"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public PuArrHead GetPurchaseOrders(string ordertype, string brand, string orderno, string state)
        {
            var order = PuArrHead.FirstOrDefault(t => t.Cdefine8 == brand
                            && t.Cbustype == ordertype
                            && t.Cvoucherstate == state
                            && t.Ccode == orderno);
            if (order != null)
            {
                order.Details = PuArrbody.Where(t => t.Id == order.Id).ToList();
            }
            return order;
        }

        public PagedResult<PuArrHead> GetPurchaseOrders(string ordertype, string brand, string key, string supplier, string state, DateTime? starttime, DateTime? endtime, int pageindex, int pagesize = U8Consts.DefaultPagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            var tmp_datas = PuArrHead.Where(t => t.Cdefine8 == brand
                            && t.Cbustype == ordertype
                            && t.Cvoucherstate == state
                            && (string.IsNullOrEmpty(key) || t.Ccode.Contains(key))
                            && (starttime == null || t.Ddate >= starttime)
                            && (endtime == null || t.Ddate <= endtime)
                            && (string.IsNullOrEmpty(supplier) || t.Cvenname.Contains(supplier)));
            var total = tmp_datas.Count();
            var orders = tmp_datas.Skip(pageindex * pagesize).Take(pagesize).ToList();
            orders.ForEach(e =>
            {
                e.Details = PuArrbody.Where(t => t.Id == e.Id).ToList();
            });
            return new PagedResult<PuArrHead>(total, orders);
        }

        /// <summary>
        /// 获取领料单
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="departmentcode"></param>
        /// <returns></returns>
        public List<Materialappm> GetMaterialOrders(string brand, string departmentcode)
        {
            var orders = Materialappm
                .Where(t => (t.Cdefine8 == brand || brand == null) && (string.IsNullOrEmpty(departmentcode) || t.Cdepcode == departmentcode) && string.IsNullOrEmpty(t.Ccloser))
               .ToList();
            orders.ForEach(e =>
            {
                e.Details = Materialappd.Where(t => t.Id == e.Id).ToList();
            });
            return orders;
        }

        /// <summary>
        /// 获取委外加工领料单
        /// </summary>
        /// <param name="departmentcode"></param>
        /// <param name="key"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public PagedResult<OmMomain> GetMaterials(string departmentcode, string key, DateTime? starttime, DateTime? endtime, int pageindex, int pagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            var tmp_orders = OmMomain
                .Join(OmMomaterialshead, main => main.Moid, head => head.Moid, (main, head) => new { main, head })
                .Where(t => t.main.CDepCode == departmentcode
                            && (starttime == null || t.main.DDate >= starttime)
                            && (endtime == null || t.main.DDate <= endtime)
                            && (string.IsNullOrEmpty(key) || t.head.Cinvstd.Contains(key)));
            var total = tmp_orders.Count();
            var orders = tmp_orders.Skip(pageindex * pagesize - pagesize).Take(pagesize).ToList();
            orders.ForEach(o =>
            {
                o.main.ProductModel = o.head.Cinvstd;
                o.main.ProductName = o.head.Cinvname;
            });
            return new PagedResult<OmMomain>(total, tmp_orders.Select(v => v.main));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public OmMomain GetMaterials(string orderno)
        {
            var order = OmMomain.FirstOrDefault(t => t.CCode == orderno);
            if (order != null)
            {
                var head = OmMomaterialshead.FirstOrDefault(v => v.Moid == order.Moid) ?? throw new Exception($"编号为{orderno}的委外订单不能在head中找到");
                order.ProductModel = head.Cinvstd;
                order.ProductName = head.Cinvname;
            }
            return order;
        }

        /// <summary>
        /// 获取委外加工领料单明细
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public List<OmMomaterialsbody> GetMaterialDetails(string orderno)
        {
            var orders = OmMomain.Where(t => t.CCode == orderno)
                .Join(OmMomaterialsbody, t => t.Moid, d => d.Moid, (t, d) => d)
                .ToList();
            return orders;
        }
        /// <summary>
        /// 获取存货
        /// </summary>
        /// <param name="productcode"></param>
        public Inventory GetInventory(string productcode)
        {
            var product = Inventory.FirstOrDefault(t => t.CInvCode == productcode);
            if (product != null)
            {
                product.InvClassName = InventoryClass.FirstOrDefault(c => c.CInvCcode == product.CInvCcode)?.CInvCname;
                product.Stock = GetInventoryStock(productcode);
                product.UnitName = ComputationUnit.FirstOrDefault(u => u.CComunitCode == product.CShopUnit)?.CComUnitName;
            }
            return product;
        }

        /// <summary>
        /// 获取现存量
        /// </summary>
        /// <param name="inventoryCode"></param>
        /// <returns></returns>
        public List<CurrentStock> GetInventoryStock(string inventoryCode)
        {
            var stocks = CurrentStock.Where(t => t.CInvCode == inventoryCode)
                .Join(Warehouse, inv => inv.CWhCode, wh => wh.CWhCode, (inv, wh) => new { inv, wh }).ToList();
            stocks.ForEach(s => s.inv.WhName = s.wh.CWhName);
            return stocks.Select(s => s.inv).ToList();
        }

        //public PagedResult<Inventory> GetInventory(string brand, string classcode, string storecode, string key, int pageindex, int pagesize)
        //{
        //    var result = GetInventory(brand, classcode, storecode, key, pageindex, pagesize, out int total);
        //    return (total, result);
        //}


        public PagedResult<Inventory> GetInventory(string brand, string classCode, string storecode, string key, int pageindex, int pagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            var products = Inventory
                            .Where(t => t.CInvDefine1 == brand && t.CInvCcode == classCode && (string.IsNullOrEmpty(key) || t.CInvName.Contains(key)))
                            .Join(CurrentStock.Where(t => t.CWhCode == storecode && t.IQuantity.HasValue && t.IQuantity.Value > 0)
                            .Select(t => t.CInvCode).Distinct(), t => t.CInvCode, d => d, (t, d) => t);
            var total = products.Count();
            var result = products.Skip(pageindex * pagesize).Take(pagesize).ToList();
            result.ForEach(p =>
            {
                p.InvClassName = InventoryClass.FirstOrDefault(c => c.CInvCcode == p.CInvCcode)?.CInvCname;
                p.Stock = GetInventoryStock(p.CInvCode);
                p.UnitName = ComputationUnit.FirstOrDefault(u => u.CComunitCode == p.CShopUnit)?.CComUnitName;
            });
            return new PagedResult<Inventory>(total, result);
        }

        private static void CheckPageIndex(int pageIndex)
        {
            if (pageIndex <= 0)
            {
                throw new Exception($"页码为{pageIndex}，值应该大于0");
            }
        }

        private static void CheckPageSize(int pagesize)
        {
            if (pagesize <= 0)
            {
                throw new Exception($"{pagesize} 不是有效的页大小");
            }
        }

        #region Add
        #region 委外加工到货单
        public bool AddPuarrivalVouch(DtoStockOrder order)
        {
            using (var tran = Database.BeginTransaction())
            {
                try
                {
                    var momain = OmMomain.Where(t => t.CCode == order.SourceOrderNo)
                        .Include(t => t.OmModetails).AsNoTracking().FirstOrDefault();
                    var result = CreatePuarrivalVouch(momain, order);
                    order.OrderNo = result.CCode;
                    PuArrivalVouch.Add(result);
                    PuArrivalVouchs.AddRange(result.Details);
                    //回填到货数量
                    foreach (var item in result.Details)
                    {
                        UpdateModetailsReceiveNumber(item);
                        //UpdateModetailsArrQtyNumber(item);
                    }
                    // OmModetails.UpdateRange(momain.OmModetails);
                    var commitResult = (SaveChanges() > 0);
                    tran.Commit();
                    return commitResult;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }

            }

        }

        internal PagedResult<DispatchList> GetDispatchBills(int pageIndex, int pageSize, DispatchBillState billState)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;

            IEnumerable<DispatchList> dispatchbills = DispatchList.Where(dl => dl.CSocode != "");
            switch (billState)
            {
                case DispatchBillState.Processing:
                    dispatchbills = dispatchbills.Where(d => !d.Dverifysystime.HasValue);
                    break;
                case DispatchBillState.Checked:
                    dispatchbills = dispatchbills.Where(d => d.Dverifysystime.HasValue);
                    break;
                default:
                    break;
            }
            var total = dispatchbills.Count();
            var result = dispatchbills.OrderByDescending(dl => dl.DDate)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
            return new PagedResult<DispatchList>(total, result);
        }

        /// <summary>
        /// 获取指定发货单号的明细
        /// </summary>
        /// <param name="billNo">发货单号</param>
        /// <returns></returns>
        internal IList<DispatchLists> GetDispatchBillDetail(string billNo)
        {
            if (string.IsNullOrWhiteSpace(billNo))
            {
                throw new FinancialException("发货单号不能为空。");
            }
            var id = DispatchList.FirstOrDefault(v => v.CDlcode == billNo)?.Dlid
                ?? throw new FinancialException($"找不到发货单:{billNo}");
            return DispatchLists.Where(dls => dls.Dlid == id).OrderBy(dls => dls.AutoId).ToList();
        }

        /// <summary>
        /// 创建到货单
        /// </summary>
        /// <param name="momain"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private PuArrivalVouch CreatePuarrivalVouch(OmMomain momain, DtoStockOrder order)
        {
            var id = PuArrivalVouch.Max(t => t.Id) + 1;
            string code = $"OMWIN{DateTime.Now:yyyyMMdd}{id.ToString().Substring(id.ToString().Length - 5)}";
            PuArrivalVouch puArrivalVouch = new PuArrivalVouch()
            {
                IVtid = 8169,
                Ufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                Id = id,
                CCode = code,
                CPtcode = "04",
                DDate = DateTime.Now.Date,
                CVenCode = momain.CVenCode,
                CDepCode = momain.CDepCode,
                CPersonCode = "cj001",
                CPayCode = momain.CPayCode,
                CSccode = momain.CSccode,
                CexchName = momain.CexchName,
                IExchRate = 1,
                ITaxRate = momain.ITaxRate.HasValue ? (decimal)(momain.ITaxRate.Value) : 0,
                CMemo = momain.CMemo + $"(车间系统自动生成单据:{DateTime.Now:yyyy-MM-dd HH:mm:ss})",
                CBusType = "委外加工",
                CMaker = "陈晓兰",
                BNegative = 0,
                CDefine4 = DateTime.Now.Date,
                CDefine8 = momain.CDefine8,
                CDefine10 = $"系统生成（{DateTime.Now:yyyy-MM-dd HH:mm:ss}）",
                IDiscountTaxType = 0,
                IBillType = 0,
                CMakeTime = DateTime.Now,
                Iverifystateex = null,
                IsWfControlled = false,
                Iflowid = 0,
                IPrintCount = 0,
                Ccleanver = null,
                Cpocode = momain.CCode,
                Csysbarcode = $"||omdh|{code}",
                Details = new List<PuArrivalVouchs>()
            };
            int autoid = PuArrivalVouchs.Max(t => t.Autoid);
            foreach (var orderitem in order.StoreStockDetail)
            {
                //TODO 如果存在合并到货，这里将出现问题
                //找到未到货的明细
                var item = momain.OmModetails
                    .FirstOrDefault(t => t.CInvCode == orderitem.ProductNumbers
                            && t.IQuantity - (t.IArrQty ?? 0) > orderitem.Numbers) ?? throw new FinancialException("是否存在合并到货?");

                autoid += 1;
                puArrivalVouch.Details.Add(new PuArrivalVouchs
                {
                    Autoid = autoid,
                    Id = id,
                    CWhCode = orderitem.StoreId,
                    CInvCode = item.CInvCode,
                    IQuantity = orderitem.Numbers.Value,
                    INum = orderitem.Numbers.Value,
                    IOriCost = item.IUnitPrice,
                    IOriTaxCost = item.IUnitPrice + item.ITax,
                    IOriMoney = item.IUnitPrice * orderitem.Numbers.Value,
                    IOriTaxPrice = item.ITax,
                    IOriSum = (item.IUnitPrice + item.ITax) * orderitem.Numbers.Value,
                    ICost = item.INatUnitPrice,
                    IMoney = item.INatUnitPrice * orderitem.Numbers.Value,
                    ITaxPrice = item.INatTax,
                    ISum = (item.INatUnitPrice + item.INatTax) * orderitem.Numbers.Value,
                    ITaxRate = item.IPerTaxRate.Value,
                    IPosId = item.ModetailsId,
                    Cordercode = momain.CCode,
                    FKpquantity = null,
                    CBatch = orderitem.ProductBatch,
                    Ivouchrowno = orderitem.SourceEntryId,
                    Cbsysbarcode = $"||omdh|{code}|{orderitem.SourceEntryId}",
                    BGsp = 1,
                    BInspect = 0,
                    Irowno = puArrivalVouch.Details.Count() + 1,
                    Iorderseq = orderitem.SourceEntryId,
                    FValidInQuan = 0,
                    FRealQuantity = orderitem.Numbers.Value,
                    FValidQuantity = null,
                    Iorderdid = item.Iorderdid,
                    PlanLotNumber = item.CPlanLotNumber,
                    CItemClass = item.CItemClass,
                    CItemCode = item.CItemCode,
                    CItemName = momain.CDefine8,
                    Csoordercode = item.Csoordercode
                });
            }
            return puArrivalVouch;
        }
        #endregion

        #region 采购到货单
        /// <summary>
        /// 添加采购到货单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool AddPurchaseArrivalVouch(DtoStockOrder order)
        {
            var pomain = PoPomain.FirstOrDefault(t => t.CPoid == order.SourceOrderNo);
            if (pomain == null) return false;
            pomain.Details = PoPodetails.Where(t => t.Poid == pomain.Poid).ToList();
            var result = CreatePurchaseArrivalVouch(pomain, order);
            order.OrderNo = result.CCode;
            PuArrivalVouch.Add(result);
            PuArrivalVouchs.AddRange(result.Details);
            foreach (var item in result.Details)
            {
                UpdatePoDetailsArrQtyNumber(item);
            }
            return SaveChanges() > 0;
        }

        private PuArrivalVouch CreatePurchaseArrivalVouch(PoPomain pomain, DtoStockOrder order)
        {
            var id = PuArrivalVouch.Max(t => t.Id) + 1;
            string code = $"PuWIN{DateTime.Now.ToString("yyyyMMdd")}{id.ToString().Substring(id.ToString().Length - 5)}";
            PuArrivalVouch puArrivalVouch = new PuArrivalVouch()
            {
                IVtid = 8169,
                Ufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                Id = id,
                CCode = code,
                CPtcode = null,
                DDate = DateTime.Now.Date,
                CVenCode = pomain.CVenCode,
                CDepCode = pomain.CDepCode,
                CPersonCode = pomain.CPersonCode,
                CPayCode = pomain.CPayCode,
                CSccode = pomain.CSccode,
                CexchName = pomain.CexchName,
                IExchRate = 1,
                ITaxRate = pomain.ITaxRate.HasValue ? (decimal)(pomain.ITaxRate.Value) : 0,
                CMemo = pomain.CMemo,
                CBusType = "普通采购",
                CMaker = pomain.CMaker,
                BNegative = 0,
                CDefine4 = DateTime.Now.Date,
                CDefine8 = pomain.CDefine8,
                CDefine10 = $"系统生成（{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}）",
                IDiscountTaxType = 0,
                IBillType = 0,
                CMakeTime = DateTime.Now,
                Iverifystateex = null,
                IsWfControlled = false,
                Iflowid = 0,
                IPrintCount = 0,
                Ccleanver = null,
                Cpocode = pomain.CPoid,
                Csysbarcode = $"||pudh|{code}",
            };
            int autoid = PuArrivalVouchs.Max(t => t.Autoid) + 1;
            foreach (var orderitem in order.StoreStockDetail)
            {
                var item = pomain.Details.First(t => t.CInvCode == orderitem.ProductNumbers);
                autoid += 1;
                puArrivalVouch.Details.Add(new PuArrivalVouchs()
                {
                    Autoid = autoid,
                    Id = id,
                    CWhCode = orderitem.StoreId,
                    CInvCode = item.CInvCode,
                    IQuantity = orderitem.Numbers.Value,
                    INum = orderitem.Numbers.Value,
                    IOriCost = item.IUnitPrice,
                    IOriTaxCost = item.IUnitPrice + item.ITax,
                    IOriMoney = item.IUnitPrice * orderitem.Numbers.Value,
                    IOriTaxPrice = item.ITax,
                    IOriSum = (item.IUnitPrice + item.ITax) * orderitem.Numbers.Value,
                    ICost = item.INatUnitPrice,
                    IMoney = item.INatUnitPrice * orderitem.Numbers.Value,
                    ITaxPrice = item.INatTax,
                    ISum = (item.INatUnitPrice + item.INatTax) * orderitem.Numbers.Value,
                    ITaxRate = item.IPerTaxRate.Value,
                    IPosId = item.Id,
                    Cordercode = pomain.CPoid,
                    FKpquantity = null,
                    CBatch = orderitem.ProductBatch,
                    Ivouchrowno = orderitem.SourceEntryId,
                    Cbsysbarcode = $"||pudh|{code}|{orderitem.SourceEntryId}",
                    BGsp = 1,
                    BInspect = 0,
                    Irowno = puArrivalVouch.Details.Count() + 1,
                    Iorderseq = orderitem.SourceEntryId,
                    FValidInQuan = 0,
                    FValidQuantity = null,
                    Iorderdid = item.Iorderdid,
                    Csoordercode = item.Csoordercode
                });
                //item.IReceivedQty = (item.IReceivedQty ?? 0) + orderitem.Numbers.Value;
            }
            return puArrivalVouch;
        }
        #endregion

        #region 采购入库单
        /// <summary>
        /// 采购入库单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool AddPurchaseOrder(DtoStockOrder order)
        {
            var puarrival = PuArrivalVouch.AsNoTracking().FirstOrDefault(t => t.CCode == order.SourceOrderNo);
            if (puarrival == null) return false;
            puarrival.Details = PuArrivalVouchs.AsNoTracking().Where(t => t.Id == puarrival.Id).ToList();
            var results = CreateRdrecord01s(puarrival, order);
            results.ForEach(result =>
            {
                order.OrderNo = result.CCode;
                order.Note += result.CCode + ",";
                RdRecord01.Add(result);
                Rdrecords01.AddRange(result.Details);
            });
            if (!InsertOrUpdateStore(order, (s, t) => { return s + t; })) return false;
            //UpdateModetailsReceiveNumber(puarrival.PuArrivalVouchs);
            var commitResult = SaveChanges() > 0;
            if (commitResult)
                results.ForEach(t =>
                {
                    AddUnAccountRdrecord(t.Id, t.Details.Select(d => d.AutoId).ToList(), "01", t.CBusType);
                });
            return commitResult;
        }

        private List<RdRecord01> CreateRdrecord01s(PuArrivalVouch puArrival, DtoStockOrder order)
        {
            List<RdRecord01> list = new List<RdRecord01>();
            var dic = puArrival.Details.GroupBy(t => t.CWhCode).ToDictionary(t => t.Key, t => t.ToList());
            long id = 0, detailid = 0;
            foreach (var key in dic.Keys)
            {
                puArrival.Details = dic[key];
                list.Add(CreateRdrecord01(key, puArrival, order, ref id, ref detailid));
            }
            return list;
        }

        private RdRecord01 CreateRdrecord01(string cwhcode, PuArrivalVouch puArrival, DtoStockOrder order, ref long id, ref long detailid)
        {
            id = id == 0 ? (RdRecord01.Max(t => t.Id) + 1) : id + 1;
            string code = $"MFIN{DateTime.Now:yyyyMMdd}{id.ToString().Substring(id.ToString().Length - 5)}";
            var rdrecord = new RdRecord01()
            {

                Id = id,
                BRdFlag = 1,
                CVouchType = "01",
                CBusType = "普通采购",
                CSource = "采购订单",
                CCode = code,
                CBusCode = puArrival.CCode,
                CWhCode = cwhcode,
                DDate = DateTime.Now.Date,
                CRdCode = "101",
                CDepCode = puArrival.CDepCode,
                CPersonCode = puArrival.CPersonCode,
                CPtcode = null,
                CVenCode = puArrival.CVenCode,
                COrderCode = puArrival.Cpocode,
                CArvcode = puArrival.CCode,
                CHandler = puArrival.CMaker,
                CMemo = puArrival.CMemo,
                BTransFlag = false,
                CMaker = puArrival.CMaker,
                CDefine1 = puArrival.CDefine1,
                CDefine2 = puArrival.CDefine2,
                CDefine10 = puArrival.CDefine10,
                CDefine11 = puArrival.CDefine11,
                CDefine12 = puArrival.CDefine12,
                CDefine13 = puArrival.CDefine13,
                CDefine14 = puArrival.CDefine14,
                CDefine15 = puArrival.CDefine15,
                CDefine16 = puArrival.CDefine16,
                CDefine3 = puArrival.CDefine3,
                CDefine4 = puArrival.CDefine4,
                CDefine5 = puArrival.CDefine5,
                CDefine6 = puArrival.CDefine6,
                CDefine7 = puArrival.CDefine7,
                CDefine8 = puArrival.CDefine8,
                CDefine9 = puArrival.CDefine9,
                DArvdate = DateTime.Now.Date,
                VtId = 27,
                Ufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                Dnmaketime = DateTime.Now,
                Bredvouch = 0,
                Ipurarriveid = puArrival.Id,
                ITaxRate = puArrival.ITaxRate,
                IExchRate = puArrival.IExchRate,
                CExchName = puArrival.CexchName,
                Csysbarcode = $"||st01|{code}",
            };
            detailid = detailid == 0 ? (Rdrecords01.Max(t => t.AutoId) + 1) : detailid;
            foreach (var item in puArrival.Details)
            {
                var orderitem = order.StoreStockDetail.First(t => t.ProductNumbers == item.CInvCode);
                detailid += 1;
                rdrecord.Details.Add(new Rdrecords01()
                {
                    IOmoDid = item.IPosId,
                    AutoId = detailid,
                    Id = rdrecord.Id,
                    CInvCode = orderitem.ProductNumbers,
                    INum = item.INum,
                    IQuantity = orderitem.Numbers,
                    INquantity = orderitem.Numbers,
                    IUnitCost = item.IOriCost,
                    IPrice = item.ICost,
                    IAprice = item.IOriTaxCost,
                    CDefine22 = item.CDefine22,
                    CDefine23 = item.CDefine23,
                    CDefine24 = item.CDefine24,
                    CDefine25 = item.CDefine25,
                    CDefine26 = item.CDefine26,
                    CDefine27 = item.CDefine27,
                    CDefine28 = item.CDefine28,
                    CDefine29 = item.CDefine29,
                    CDefine30 = item.CDefine30,
                    CDefine31 = item.CDefine31,
                    CDefine32 = item.CDefine32,
                    CDefine33 = item.CDefine33,
                    CDefine34 = item.CDefine34,
                    CDefine35 = item.CDefine35,
                    CDefine36 = item.CDefine36,
                    CDefine37 = item.CDefine37,
                    CBatch = orderitem.ProductBatch,
                    CItemCode = item.CItemCode,
                    CName = order.Brand,
                    CItemCname = item.CItemName,
                    CItemClass = item.CItemClass,
                    IPosId = item.IPosId,
                    FAcost = item.ICost,
                    ChVencode = puArrival.CVenCode,
                    IArrsId = item.Autoid,
                    IOriTaxCost = item.IOriTaxCost,
                    IOriCost = item.IOriCost,
                    IOriMoney = item.IOriMoney,
                    IoriSum = item.IOriSum,
                    ITaxRate = item.ITaxRate,
                    ITaxPrice = item.ITaxPrice,
                    ISum = item.ISum,
                    BTaxCost = item.BTaxCost,
                    CPoid = item.Cordercode,
                    Cbarvcode = puArrival.CCode,
                    Dbarvdate = DateTime.Now.ToString("yyyy-MM-dd"),

                    IFlag = 0,
                    BLpuseFree = false,
                    IOriTrackId = 0,
                    BCosting = true,
                    BVmiused = false,
                    Iordertype = 1,
                    Iorderseq = orderitem.SourceEntryId,
                    Irowno = orderitem.SourceEntryId,
                    Rowufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                    Cbsysbarcode = $"||st01|{rdrecord.CCode}|{orderitem.SourceEntryId}",
                    Iorderdid = item.Iorderdid,
                    Iordercode = item.Csoordercode
                });
            }
            return rdrecord;
        }

        /// <summary>
        /// 根据到货单生成入库记录
        /// </summary>
        /// <param name="puArrival"></param>
        /// <returns></returns>
        private List<RdRecord01> CreateRdrecord01s(PuArrivalVouch puArrival)
        {
            List<RdRecord01> list = new List<RdRecord01>();
            var warehouses = puArrival.Details.GroupBy(t => t.CWhCode).ToDictionary(t => t.Key, t => t.ToList());
            long id = 0, detailid = 0;
            foreach (var whcode in warehouses.Keys)
            {
                puArrival.Details = warehouses[whcode];
                list.Add(CreateRdrecord01(whcode, puArrival, ref id, ref detailid));
            }
            return list;
        }
        private Dictionary<string, string> rdcode = new Dictionary<string, string>() {
            {"普通采购","101" },
            { "委外加工","102"}
        };
        private Dictionary<string, string> source = new Dictionary<string, string>() {
            {"普通采购","采购订单" },
            { "委外加工","委外订单"}
        };

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <param name="cardName">单据类型名称</param>
        /// <returns>流水号属性</returns>
        private CodeProperty GetCode(string cardName)
        {
            var vn = VoucherNumber.FirstOrDefault(v => v.CardName == cardName);
            if (vn is null)
            {
                throw new FinancialException($"无法找到单据类型{cardName}");
            }

            var prefix2 = vn.Prefix2Rule.Replace("年", "yyyy").Replace("月", "MM").Replace("日", "dd");
            var p2mask = prefix2.Substring(prefix2.Length - vn.Prefix2Len);
            //TODO support prefix3
            return new CodeProperty
            {
                Prefix = $"{vn.Prefix1Rule}{DateTime.Today.ToString(p2mask)}",
                GlideLen = vn.GlideLen,
                ResetOn = vn.GlideRule ?? "",
                Start = vn.IStartNumber,
                Step = vn.IGlideStep
            };
        }

        private RdRecord01 CreateRdrecord01(string cwhcode, PuArrivalVouch puArrival, ref long id, ref long detailid)
        {
            id = (id == 0) ? (RdRecord01.Max(t => t.Id) + 1) : (id + 1);
            //string code = $"MFIN{DateTime.:yyyyMMdd}{id.ToString().Substring(id.ToString().Length - 5)}";
            var codePrefix = $"CR{DateTime.Today:yyMM}";
            var cp = GetCode("采购入库单");
            var code = $"{cp.Prefix}{"1".PadLeft(cp.GlideLen, '0')}";
            var maxCode = RdRecord01.AsNoTracking().Where(r => EF.Functions.Like(r.CCode, codePrefix + "%")).OrderByDescending(r => r.CCode).FirstOrDefault();
            if (maxCode != null)
            {
                code = maxCode.CCode;
                var newCodeNumber = int.Parse(code.Substring(code.Length - cp.GlideLen)) + 1;
                code = $"{cp.Prefix}{newCodeNumber.ToString().PadLeft(cp.GlideLen, '0')}";
            }
            var rdrecord = new RdRecord01
            {
                Id = id,
                BRdFlag = 1,
                CVouchType = "01",
                CBusType = puArrival.CBusType,
                CSource = source.ContainsKey(puArrival.CBusType) ? source[puArrival.CBusType] : "微感服务",
                CCode = code,
                CBusCode = puArrival.CCode,
                CWhCode = cwhcode,
                DDate = DateTime.Now.Date,
                CRdCode = rdcode.ContainsKey(puArrival.CBusType) ? rdcode[puArrival.CBusType] : "103",
                CDepCode = puArrival.CDepCode,
                CPersonCode = puArrival.CPersonCode,
                CPtcode = null,
                CVenCode = puArrival.CVenCode,
                COrderCode = puArrival.Cpocode,
                CArvcode = puArrival.CCode,
                CHandler = puArrival.CMaker,
                CMemo = puArrival.CMemo,
                BTransFlag = false,
                CMaker = puArrival.CMaker,
                CDefine1 = puArrival.CDefine1,
                CDefine2 = puArrival.CDefine2,
                CDefine10 = puArrival.CDefine10,
                CDefine11 = puArrival.CDefine11,
                CDefine12 = puArrival.CDefine12,
                CDefine13 = puArrival.CDefine13,
                CDefine14 = puArrival.CDefine14,
                CDefine15 = puArrival.CDefine15,
                CDefine16 = puArrival.CDefine16,
                CDefine3 = puArrival.CDefine3,
                CDefine4 = puArrival.CDefine4,
                CDefine5 = puArrival.CDefine5,
                CDefine6 = puArrival.CDefine6,
                CDefine7 = puArrival.CDefine7,
                CDefine8 = puArrival.CDefine8,
                CDefine9 = puArrival.CDefine9,
                DArvdate = DateTime.Now.Date,
                VtId = 27,
                Ufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                Dnmaketime = DateTime.Now,
                Bredvouch = 0,
                Ipurarriveid = puArrival.Id,
                ITaxRate = puArrival.ITaxRate,
                IExchRate = puArrival.IExchRate,
                CExchName = puArrival.CexchName,
                Csysbarcode = $"||st01|{code}",
                Details = new List<Rdrecords01>()
            };
            detailid = detailid == 0 ? (Rdrecords01.Max(t => t.AutoId) + 1) : detailid;
            foreach (var item in puArrival.Details)
            {
                detailid += 1;
                rdrecord.Details.Add(new Rdrecords01()
                {
                    IOmoDid = item.IPosId,
                    AutoId = detailid,
                    Id = rdrecord.Id,
                    CInvCode = item.CInvCode,
                    INum = item.INum,
                    IQuantity = item.IQuantity,
                    IUnitCost = item.IOriCost,
                    IPrice = item.ICost,
                    IAprice = item.IOriTaxCost,
                    CDefine22 = item.CDefine22,
                    CDefine23 = item.CDefine23,
                    CDefine24 = item.CDefine24,
                    CDefine25 = item.CDefine25,
                    CDefine26 = item.CDefine26,
                    CDefine27 = item.CDefine27,
                    CDefine28 = item.CDefine28,
                    CDefine29 = item.CDefine29,
                    CDefine30 = item.CDefine30,
                    CDefine31 = item.CDefine31,
                    CDefine32 = item.CDefine32,
                    CDefine33 = item.CDefine33,
                    CDefine34 = item.CDefine34,
                    CDefine35 = item.CDefine35,
                    CDefine36 = item.CDefine36,
                    CDefine37 = item.CDefine37,
                    CBatch = item.CBatch,
                    CItemCode = item.CItemCode,
                    CName = puArrival.CDefine8,
                    CItemCname = item.CItemName,
                    CItemClass = item.CItemClass,
                    IPosId = item.IPosId,
                    FAcost = item.ICost,
                    INquantity = item.IQuantity,
                    ChVencode = puArrival.CVenCode,
                    IArrsId = item.Autoid,
                    IOriTaxCost = item.IOriTaxCost,
                    IOriCost = item.IOriCost,
                    IOriMoney = item.IOriMoney,
                    IoriSum = item.IOriSum,
                    ITaxRate = item.ITaxRate,
                    ITaxPrice = item.ITaxPrice,
                    ISum = item.ISum,
                    BTaxCost = item.BTaxCost,
                    CPoid = item.Cordercode,
                    Cbarvcode = puArrival.CCode,
                    Dbarvdate = DateTime.Now.ToString("yyyy-MM-dd"),

                    IFlag = 0,
                    BLpuseFree = false,
                    IOriTrackId = 0,
                    BCosting = true,
                    BVmiused = false,
                    Iordertype = item.Iordertype,
                    Iorderseq = item.Iorderseq,
                    Irowno = item.Irowno ?? item.Ivouchrowno,
                    //Rowufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                    Cbsysbarcode = $"||st01|{rdrecord.CCode}|{item.Iorderseq}",
                    Iorderdid = item.Iorderdid,
                    Iordercode = item.Csoordercode
                });
            }
            return rdrecord;
        }
        #endregion

        #region 到货单下推入库单
        /// <summary>
        /// 到货单下推入库单
        /// </summary>
        /// <param name="puarrivalOrderNo"></param>
        /// <returns></returns>
        public bool FromPuArrivalVouchToStoreRecord(string puarrivalOrderNo)
        {
            return SaveRdRecordsTran(puarrivalOrderNo, null);
        }

        /// <summary>
        /// 到货单下推入库单
        /// </summary>
        /// <param name="puarrivalOrderNo"></param>
        /// <param name="batch"></param>
        /// <returns></returns>
        public bool FromPuArrivalVouchToStoreRecord(string puarrivalOrderNo, Dictionary<string, string> batchs)
        {
            return SaveRdRecordsTran(puarrivalOrderNo, t =>
            {
                t.ForEach(item => item.Details.ToList().ForEach(d =>
                {
                    if (batchs.ContainsKey(d.CInvCode))
                        d.CBatch = batchs[d.CInvCode];
                }));
            });
        }

        /// <summary>
        /// 到货单下推入库单
        /// </summary>
        /// <param name="puarrivalOrderNo"></param>
        /// <param name="sendOrderNo"></param>
        /// <returns></returns>
        public bool FromPuArrivalVouchToStoreRecord(string puarrivalOrderNo, string sendOrderNo)
        {
            if (sendOrderNo.Length > 55)
            {
                sendOrderNo = sendOrderNo.Substring(0, 55);
            }
            return SaveRdRecordsTran(puarrivalOrderNo, t => { t.ForEach(item => item.CDefine10 = sendOrderNo); });
        }

        /// <summary>
        /// 生成入库单
        /// </summary>
        /// <param name="puarrivalOrderNo"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private bool SaveRdRecordsTran(string puarrivalOrderNo, Action<List<RdRecord01>> action)
        {
            using (var tran = Database.BeginTransaction())
            {
                try
                {
                    var puarrival = PuArrivalVouch.AsNoTracking().FirstOrDefault(t => t.CCode == puarrivalOrderNo);
                    if (puarrival is null)
                    {
                        throw new FinancialException($"找不到单号为{puarrivalOrderNo}的到货单。");
                    }
                    puarrival.Details = PuArrivalVouchs.Where(t => t.Id == puarrival.Id).ToList();
                    //创建入库单
                    var records = CreateRdrecord01s(puarrival);
                    action?.Invoke(records);
                    bool commitResult = SaveRdRecords(puarrival, records);
                    if (commitResult) tran.Commit();
                    else tran.Rollback();
                    return commitResult;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }
        private bool SaveRdRecords(PuArrivalVouch puarrival, List<RdRecord01> records)
        {
            foreach (var item in puarrival.Details)
            {
                //更新采购订单到入库数量 
                if (puarrival.CBusType == "普通采购")
                {
                    var detail = PoPodetails.FirstOrDefault(t => t.Id == item.IPosId);
                    if (detail == null) continue;
                    //detail.Freceivedqty = (detail.Freceivedqty ?? 0) + item.IQuantity;
                    UpdatePoDetailsReceiveNumber(item);
                }
                else if (puarrival.CBusType == "委外加工")
                {
                    //更新委外单据入库数量 
                    var detail = OmModetails.FirstOrDefault(t => t.ModetailsId == item.IPosId);
                    if (detail == null) continue;
                    //detail.Freceivedqty = (detail.Freceivedqty ?? 0) + item.IQuantity;
                    UpdateModetailsReceiveNumber(item);
                    // 更新加工费用
                    var rds = records.Where(t => t.Details.Any(d => d.IOmoDid == detail.ModetailsId)).Select(t => t.Details.FirstOrDefault(d => d.IOmoDid == detail.ModetailsId))?.FirstOrDefault();
                    if (rds != null)
                    {
                        //加工费单价 
                        rds.IProcessCost = detail.IUnitPrice;
                        //加工费
                        rds.IProcessFee = detail.IUnitPrice * item.IQuantity;
                        //累计结算加工费
                        //rds.ISprocessFee = 0;
                    }
                }
                // 实际入库数量应该在审核后赋值
                item.FValidInQuan = item.IQuantity;
                item.FValidQuantity = 0m;
                //2020.6.20 validquantity 在手工业务中没有值
                //item.FValidQuantity = item.FValidInQuan = item.IQuantity;
            }
            puarrival.Ccloser = puarrival.CMaker;
            puarrival.Cverifier = puarrival.CMaker;
            puarrival.Dclosedate = puarrival.CAuditDate = DateTime.Now.Date;
            puarrival.Caudittime = DateTime.Now;
            PuArrivalVouch.Update(puarrival);
            //更新库存
            if (!InsertOrUpdateStore(new DtoStockOrder()
            {
                Brand = puarrival.CDefine8,
                SourceOrderNo = puarrival.CCode,
                StoreStockDetail = puarrival.Details.Select(t => new DtoStoreStockDetail()
                {
                    Numbers = t.IQuantity,
                    ProductBatch = t.CBatch,
                    ProductNumbers = t.CInvCode,
                    StoreId = t.CWhCode
                })
            }, (s, t) => { return s + t; })) throw new Exception("更新库存时发生异常");
            records.ForEach(result =>
            {
                //添加未记账数据
                if (!AddUnAccountRdrecord(result.Id, result.Details.Select(d => d.AutoId).ToList(), "01", result.CBusType)) throw new Exception("添加未记账数据时发生异常");
                RdRecord01.Add(result);
                Rdrecords01.AddRange(result.Details);
            });
            var commitResult = SaveChanges() > 0;
            return commitResult;
        }
        #endregion

        #region 销售出库单
        /// <summary>
        /// 销售出库单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public void AddSellOrder(DtoStockOrder order)
        {
            using (var tran = Database.BeginTransaction())
            {
                try
                {
                    UpdateStore(order, (s, t) => s - t);

                    var dispatch = DispatchList.AsNoTracking().FirstOrDefault(t => t.CDlcode == order.SourceOrderNo);
                    if (dispatch == null) throw new FinancialException($"无法查询当前发货单[{order.SourceOrderNo}]");
                    dispatch.Details = DispatchLists.AsNoTracking().Where(t => t.Dlid == dispatch.Dlid).ToList();
                    var results = CreateRdrecord32s(dispatch, order);
                    results.ForEach(result =>
                    {
                        order.OrderNo = result.CCode;
                        order.Note += result.CCode + ",";
                        Rdrecord32.Add(result);
                        Rdrecords32.AddRange(result.Details);
                    });
                    foreach (var item in dispatch.Details)
                    {
                        //更新销售订单发货数量
                        var detail = SoSodetails.FirstOrDefault(t => t.ISosId == item.ISosId);
                        if (detail == null) continue;
                        var orderdetail = order.StoreStockDetail.FirstOrDefault(t => t.ProductBatch == item.CBatch && t.ProductNumbers == item.CInvCode);
                        detail.IFhquantity = (detail.IFhquantity ?? 0) + (orderdetail?.Numbers ?? item.IQaquantity);
                        //更新已出库数量
                        item.FOutQuantity = (item.FOutQuantity ?? 0) + (orderdetail?.Numbers ?? item.IQaquantity);
                    }
                    //添加未记账数据
                    results.ForEach(t =>
                    {
                        if (!AddUnAccountRdrecord(t.Id, t.Details.Select(d => d.AutoId).ToList(), "32", t.CBusType))
                            throw new FinancialException($"添加未记账数据时发生异常");

                    });
                    DispatchLists.UpdateRange(dispatch.Details);
                    var commitResult = SaveChanges() > 0;
                    if (commitResult) tran.Commit();
                    else tran.Rollback();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }
        private List<Rdrecord32> CreateRdrecord32s(DispatchList dispatch, DtoStockOrder order)
        {
            List<Rdrecord32> list = new List<Rdrecord32>();
            var dic = dispatch.Details.GroupBy(t => t.CWhCode).ToDictionary(t => t.Key, t => t.ToList());
            long id = 0, detailid = 0;
            foreach (var key in dic.Keys)
            {
                dispatch.Details = dic[key];
                list.Add(CreateRdrecord32(key, dispatch, order, ref id, ref detailid));
            }
            return list;
        }
        private Rdrecord32 CreateRdrecord32(string cwhcode, DispatchList dispatch, DtoStockOrder order, ref long id, ref long detailid)
        {
            id = id == 0 ? (Rdrecord32.Max(t => t.Id) + 1) % 1000000000 + 2000000000 : id + 1;
            string code = $"MFOUT{DateTime.Now.ToString("yyyyMMdd")}{id.ToString().Substring(id.ToString().Length - 5)}";
            var rdrecord = new Rdrecord32()
            {
                Id = id,
                BRdFlag = 0,
                CVouchType = "32",
                CBusType = "普通销售",
                CSource = "发货单",
                CBusCode = dispatch.CDlcode,
                CCode = code,
                CWhCode = cwhcode,
                DDate = DateTime.Now.Date,
                CRdCode = dispatch.CRdCode,
                CDepCode = dispatch.CDepCode,
                CPersonCode = dispatch.CPersonCode,
                CPtcode = null,
                CStcode = dispatch.CStcode,
                CCusCode = dispatch.CCusCode,
                CDlcode = dispatch.Dlid,
                CHandler = dispatch.CMaker,
                CMemo = dispatch.CMemo,
                BTransFlag = false,
                CAccounter = dispatch.CAccounter,
                CMaker = dispatch.CMaker,
                CDefine1 = dispatch.CDefine1,
                CDefine2 = dispatch.CDefine2,
                CDefine10 = dispatch.CDefine10,
                CDefine11 = dispatch.CDefine11,
                CDefine12 = dispatch.CDefine12,
                CDefine13 = dispatch.CDefine13,
                CDefine14 = dispatch.CDefine14,
                CDefine15 = dispatch.CDefine15,
                CDefine16 = dispatch.CDefine16,
                CDefine3 = dispatch.CDefine3,
                CDefine4 = dispatch.CDefine4,
                CDefine5 = dispatch.CDefine5,
                CDefine6 = dispatch.CDefine6,
                CDefine7 = dispatch.CDefine7,
                CDefine8 = dispatch.CDefine8,
                CDefine9 = dispatch.CDefine9,
                // DVeriDate=dispatch.Dverifydate
                Biafirst = dispatch.BIafirst,
                VtId = 87,
                Ufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                Dnmaketime = DateTime.Now,
                Bredvouch = 0,
                Csysbarcode = $"||st32|{code}",
                Cinvoicecompany = dispatch.Cinvoicecompany,
                Details = new List<Rdrecords32>()
            };
            detailid = detailid == 0 ? (Rdrecords32.Max(t => t.AutoId) + 1) % 1000000000 + 2000000000 : detailid;
            foreach (var item in dispatch.Details)
            {
                var orderitem = order.StoreStockDetail.First(t => t.ProductNumbers == item.CInvCode);
                detailid += 1;
                rdrecord.Details.Add(new Rdrecords32()
                {
                    AutoId = detailid,
                    Id = rdrecord.Id,
                    CInvCode = orderitem.ProductNumbers,
                    INum = item.INum,
                    IQuantity = orderitem.Numbers,
                    Cbdlcode = rdrecord.CBusCode,
                    CDefine22 = item.CDefine22,
                    CDefine23 = item.CDefine23,
                    CDefine24 = item.CDefine24,
                    CDefine25 = item.CDefine25,
                    CDefine26 = item.CDefine26,
                    CDefine27 = item.CDefine27,
                    CDefine28 = item.CDefine28,
                    CDefine29 = item.CDefine29,
                    CDefine30 = item.CDefine30,
                    CDefine31 = item.CDefine31,
                    CDefine32 = item.CDefine32,
                    CDefine33 = item.CDefine33,
                    CDefine34 = item.CDefine34,
                    CDefine35 = item.CDefine35,
                    CDefine36 = item.CDefine36,
                    CDefine37 = item.CDefine37,
                    CBatch = orderitem.ProductBatch,
                    IDlsId = item.AutoId,
                    CItemCode = item.CItemCode,
                    CName = order.Brand,
                    CItemCname = item.CItemCname,
                    CItemClass = item.CItemClass,
                    INquantity = item.FOutQuantity,
                    IUnitCost = item.IUnitPrice,
                    IPrice = item.IUnitPrice,
                    IFlag = 0,
                    BLpuseFree = false,
                    IRsrowNo = 0,
                    IOriTrackId = 0,
                    BCosting = true,
                    BVmiused = false,
                    Iorderdid = item.ISosId,
                    Iordercode = item.CSoCode,
                    Iordertype = 1,
                    Iorderseq = orderitem.SourceEntryId,
                    Ipesodid = item.ISosId.ToString(),
                    Ipesotype = 1,
                    Ipesoseq = orderitem.SourceEntryId,
                    Irowno = orderitem.SourceEntryId,
                    Rowufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                    Cbsysbarcode = $"||st32|{rdrecord.CCode}|{orderitem.SourceEntryId}"
                });
            }
            return rdrecord;
        }
        #endregion

        #region 领料出库单
        /// <summary>
        /// 领料出库单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool AddMaterialOrder(DtoStockOrder order)
        {
            using (var tran = Database.BeginTransaction())
            {
                try
                {
                    UpdateStore(order, (s, t) => s - t);
                    var materialApp = MaterialAppVouch.AsNoTracking().FirstOrDefault(t => t.CCode == order.SourceOrderNo);
                    if (materialApp == null) return false;
                    materialApp.MaterialAppVouchs = MaterialAppVouchs.AsNoTracking().Where(t => t.Id == materialApp.Id).ToList();
                    var results = CreateRdrecord11s(materialApp, order);
                    var list = new List<Rdrecords11>();
                    results.ForEach(result =>
                    {
                        order.OrderNo = result.CCode;
                        order.Note += result.CCode + ",";
                        list.AddRange(result.Details);
                        if (!AddUnAccountRdrecord(result.Id, result.Details.Select(d => d.AutoId).ToList(), "11", result.CBusType)) throw new Finance.FinancialException($"添加未记帐单时发生异常。单号：{result.CCode}");
                    });
                    var detailid = 0;
                    foreach (var item in materialApp.MaterialAppVouchs)
                    {
                        //更新发料数量
                        var detail = OmMomaterials.FirstOrDefault(t => t.MomaterialsId.ToString() == item.Ipesodid);
                        if (detail == null) continue;
                        detailid = detail.MoDetailsId;
                        var orderdetails = order.StoreStockDetail.Where(t => t.ProductNumbers == detail.CInvCode);
                        detail.ISendQty = (detail.ISendQty ?? 0) + orderdetails.Sum(t => t.Numbers);
                        detail.ISendNum = (detail.ISendNum ?? 0) + detail.ISendQty / item.Iinvexchrate;
                    }
                    if (detailid != 0)
                    {
                        //更新明细表中的领料数量
                        var detail = OmModetails.FirstOrDefault(t => t.ModetailsId == detailid);
                        if (detail != null)
                            detail.IMaterialSendQty = order.StoreStockDetail.Sum(t => t.Numbers);
                    }
                    Rdrecord11.AddRange(results);
                    Rdrecords11.AddRange(list);
                    var app = MaterialAppVouch.First(t => t.Id == materialApp.Id);
                    app.CCloser = app.CMaker;
                    var commitResult = SaveChanges() > 0;
                    if (commitResult) tran.Commit();
                    else tran.Rollback();
                    return commitResult;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        private List<Rdrecord11> CreateRdrecord11s(MaterialAppVouch materialApp, DtoStockOrder order)
        {
            List<Rdrecord11> list = new List<Rdrecord11>();
            var dic = materialApp.MaterialAppVouchs.GroupBy(t => t.CWhCode ?? "-1").ToDictionary(t => t.Key, t => t.ToList());
            long id = 0, detailid = 0;
            foreach (var key in dic.Keys)
            {
                materialApp.MaterialAppVouchs = dic[key];
                list.Add(CreateRdrecord11(key, materialApp, order, ref id, ref detailid));
            }
            return list;
        }
        private Rdrecord11 CreateRdrecord11(string cwhcode, MaterialAppVouch materialApp, DtoStockOrder order, ref long id, ref long detailid)
        {
            var momain = OmMomain.FirstOrDefault(t => t.CCode == materialApp.MaterialAppVouchs.FirstOrDefault().Comcode);
            if (momain == null)
                throw new Finance.FinancialException($"申请单（{materialApp.CCode})明细中关联的委外订单单号（{materialApp.MaterialAppVouchs.FirstOrDefault()?.Comcode}）没有对应的委外单据");
            id = id == 0 ? (Rdrecord11.Max(t => t.Id) + 1) : id + 1;
            string code = $"MFMA{DateTime.Now.ToString("yyyyMMdd")}{id.ToString().Substring(id.ToString().Length - 5)}";
            var rdrecord = new Rdrecord11()
            {
                Id = id,
                BRdFlag = 0,
                CVouchType = "11",
                CBusType = "委外发料",
                CSource = "领料申请单",
                CBusCode = materialApp.CCode,
                CWhCode = cwhcode,
                DDate = DateTime.Now.Date,
                CCode = code,
                CRdCode = materialApp.CRdCode,
                CDepCode = materialApp.CDepCode,
                CPersonCode = materialApp.CPersonCode,
                CPtcode = null,
                CVenCode = materialApp.Cvencode,
                CHandler = materialApp.CMaker,
                CMemo = materialApp.CMemo,
                BTransFlag = false,
                CMaker = materialApp.CMaker,
                CDefine1 = materialApp.CDefine1,
                CDefine2 = materialApp.CDefine2,
                CDefine10 = materialApp.CDefine10,
                CDefine11 = materialApp.CDefine11,
                CDefine12 = materialApp.CDefine12,
                CDefine13 = materialApp.CDefine13,
                CDefine14 = materialApp.CDefine14,
                CDefine15 = materialApp.CDefine15,
                CDefine16 = materialApp.CDefine16,
                CDefine3 = materialApp.CDefine3,
                CDefine4 = materialApp.CDefine4,
                CDefine5 = materialApp.CDefine5,
                CDefine6 = materialApp.CDefine6,
                CDefine7 = materialApp.CDefine7,
                CDefine8 = materialApp.CDefine8,
                CDefine9 = materialApp.CDefine9,
                CArvcode = materialApp.CCode,
                DArvdate = DateTime.Now.Date,
                VtId = 65,

                CPsPcode = OmModetails.FirstOrDefault(o => o.ModetailsId == materialApp.MaterialAppVouchs.FirstOrDefault().IOmoMid)?.CInvCode,
                CMpoCode = materialApp.MaterialAppVouchs.FirstOrDefault()?.Comcode,

                Ufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                Dnmaketime = DateTime.Now,
                Bredvouch = 0,
                IMquantity = materialApp.Imquantity.HasValue ? (double)materialApp.Imquantity.Value : 0,
                Iproorderid = momain.Moid,

                Csysbarcode = $"||st11|{materialApp.CCode}",
                Details = new List<Rdrecords11>()
            };
            detailid = detailid == 0 ? (Rdrecords11.Max(t => t.AutoId) + 1) : detailid;
            foreach (var item in materialApp.MaterialAppVouchs)
            {
                var orderitem = order.StoreStockDetail.First(t => t.ProductNumbers == item.CInvCode);
                detailid += 1;
                rdrecord.Details.Add(new Rdrecords11()
                {
                    AutoId = detailid,
                    Id = rdrecord.Id,
                    CInvCode = orderitem.ProductNumbers,
                    INum = item.INum,
                    IQuantity = orderitem.Numbers,
                    CDefine22 = item.CDefine22,
                    CDefine23 = item.CDefine23,
                    CDefine24 = item.CDefine24,
                    CDefine25 = item.CDefine25,
                    CDefine26 = item.CDefine26,
                    CDefine27 = item.CDefine27,
                    CDefine28 = item.CDefine28,
                    CDefine29 = item.CDefine29,
                    CDefine30 = item.CDefine30,
                    CDefine31 = item.CDefine31,
                    CDefine32 = item.CDefine32,
                    CDefine33 = item.CDefine33,
                    CDefine34 = item.CDefine34,
                    CDefine35 = item.CDefine35,
                    CDefine36 = item.CDefine36,
                    CDefine37 = item.CDefine37,
                    CBatch = orderitem.ProductBatch,
                    CItemCode = item.CItemCode,
                    CName = order.Brand,
                    CItemCname = item.CItemCname,
                    CItemClass = item.CItemClass,
                    INquantity = item.FOutQuantity,
                    IFlag = 0,
                    IOmoMid = item.IOmoMid,
                    IOmoDid = item.IOmoDid,
                    Cmocode = item.Cmocode,
                    Ipesodid = item.Ipesodid,
                    Cpesocode = item.Cpesocode,
                    BLpuseFree = false,
                    IRsrowNo = 0,
                    IOriTrackId = 0,
                    BCosting = true,
                    BVmiused = false,
                    Ipesotype = item.Ipesotype,
                    Ipesoseq = orderitem.SourceEntryId,
                    Irowno = orderitem.SourceEntryId,
                    Rowufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                    Cbsysbarcode = $"||st11|{rdrecord.CCode}|{orderitem.SourceEntryId}",
                    BOutMaterials = 1,
                    //Applycode ="",
                    // Applydid = 1,
                    //  CbMemo = item.CbMemo,
                    //    Iorderdid = 1,
                    //     Iorderseq =1, 
                });
            }
            return rdrecord;
        }
        #endregion

        #region 添加领料申请单
        public bool AddMetarialApply(DtoStockOrder order)
        {
            var apply = OmMomain.FirstOrDefault(t => t.CCode == order.SourceOrderNo);
            if (apply == null) return false;
            var applydetails = OmMomaterials.Where(t => t.Moid == apply.Moid).ToList();
            #region Create
            var id = MaterialAppVouch.Any() ? (MaterialAppVouch.Max(t => t.Id) + 1) : 1;
            var code = $"MFAPP{DateTime.Now.ToString("yyyyMMdd")}{(id > 10000 ? id.ToString().Substring(id.ToString().Length - 5) : id.ToString().PadLeft(5, '0'))}";
            MaterialAppVouch vouch = new MaterialAppVouch()
            {
                Id = id,
                DDate = DateTime.Now.Date,
                CCode = code,
                CDepCode = apply.CDepCode,
                CDefine1 = apply.CDefine1,
                CDefine2 = apply.CDefine2,
                CDefine10 = apply.CDefine10,
                CDefine11 = apply.CDefine11,
                CDefine12 = apply.CDefine12,
                CDefine13 = apply.CDefine13,
                CDefine14 = apply.CDefine14,
                CDefine15 = apply.CDefine15,
                CDefine16 = apply.CDefine16,
                CDefine3 = apply.CDefine3,
                CDefine4 = apply.CDefine4,
                CDefine5 = apply.CDefine5,
                CDefine6 = apply.CDefine6,
                CDefine7 = apply.CDefine7,
                CDefine8 = apply.CDefine8,
                CDefine9 = apply.CDefine9,
                CPersonCode = apply.CPersonCode,
                CHandler = apply.CMaker,
                CMaker = apply.CMaker,
                CMemo = apply.CMemo,
                VtId = 30718,
                Ufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                Dnmaketime = DateTime.Now,
                CSource = "委外订单",
                Cvencode = apply.CVenCode,
                Csysbarcode = $"||st64|{code}",
                MaterialAppVouchs = new List<MaterialAppVouchs>()
            };
            #endregion
            #region Create Detail
            var autoid = MaterialAppVouchs.Any() ? (MaterialAppVouchs.Max(t => t.AutoId) + 1) : 2000000001;
            foreach (var item in order.StoreStockDetail)
            {
                var detail = applydetails.FirstOrDefault(t => t.CInvCode == item.ProductNumbers);
                vouch.MaterialAppVouchs.Add(new MaterialAppVouchs()
                {
                    AutoId = autoid++,
                    Id = id,
                    CInvCode = item.ProductNumbers,
                    INum = item.Numbers * (detail?.FBaseQtyD ?? 0),
                    IQuantity = item.Numbers,
                    CBatch = item.ProductBatch,
                    DDueDate = DateTime.Now.Date,
                    FOutQuantity = 0,
                    CDefine22 = detail.CDefine22,
                    CDefine23 = detail.CDefine23,
                    CDefine24 = detail.CDefine24,
                    CDefine25 = detail.CDefine25,
                    CDefine26 = detail.CDefine26,
                    CDefine27 = detail.CDefine27,
                    CDefine28 = detail.CDefine28,
                    CDefine29 = detail.CDefine29,
                    CDefine30 = detail.CDefine30,
                    CDefine31 = detail.CDefine31,
                    CDefine32 = detail.CDefine32,
                    CDefine33 = detail.CDefine33,
                    CDefine34 = detail.CDefine34,
                    CDefine35 = detail.CDefine35,
                    CDefine36 = detail.CDefine36,
                    CDefine37 = detail.CDefine37,
                    CName = apply.CDefine8,
                    CItemCname = "项目管理",
                    CAssUnit = detail.CUnitId,
                    CWhCode = detail.CWhCode,
                    Iinvexchrate = 1 / (detail.FBaseQtyD ?? 1),
                    Irowno = detail.Irowno,
                    IOmoMid = detail.MoDetailsId,
                    IOmoDid = detail.MomaterialsId,
                    Comcode = apply.CCode,
                    Invcode = OmModetails.FirstOrDefault(t => t.ModetailsId == detail.MoDetailsId)?.CInvCode,
                    Corufts = "515862.3406",
                    Ipesodid = detail.MomaterialsId.ToString(),
                    Ipesotype = 8,
                    Cpesocode = apply.CCode,
                    Cbsysbarcode = $"||st64|{code}|{detail.Irowno}"
                });
                //更新申请数量
                detail.Fsendapplyqty = item.Numbers;
                detail.Fsendapplynum = item.Numbers * (detail?.FBaseQtyD ?? 0);
            }
            #endregion
            MaterialAppVouch.Add(vouch);
            return SaveChanges() > 0;
        }
        #endregion


        #region 退料申请单
        public bool AddReturnMetarialApply(DtoStockOrder order)
        {
            var apply = OmMomain.FirstOrDefault(t => t.CCode == order.SourceOrderNo);
            if (apply == null) return false;
            var applydetails = OmMomaterials.Where(t => t.Moid == apply.Moid).ToList();
            #region Create
            var id = MaterialAppVouch.Max(t => t.Id) + 1;
            var code = $"MFAPP{DateTime.Now.ToString("yyyyMMdd")}{(id > 10000 ? id.ToString().Substring(id.ToString().Length - 5) : id.ToString().PadLeft(5, '0'))}";
            MaterialAppVouch vouch = new MaterialAppVouch()
            {
                Id = MaterialAppVouch.Max(t => t.Id) + 1,
                DDate = DateTime.Now.Date,
                CCode = code,
                CDepCode = apply.CDepCode,
                CDefine1 = apply.CDefine1,
                CDefine2 = apply.CDefine2,
                CDefine10 = apply.CDefine10,
                CDefine11 = apply.CDefine11,
                CDefine12 = apply.CDefine12,
                CDefine13 = apply.CDefine13,
                CDefine14 = apply.CDefine14,
                CDefine15 = apply.CDefine15,
                CDefine16 = apply.CDefine16,
                CDefine3 = apply.CDefine3,
                CDefine4 = apply.CDefine4,
                CDefine5 = apply.CDefine5,
                CDefine6 = apply.CDefine6,
                CDefine7 = apply.CDefine7,
                CDefine8 = apply.CDefine8,
                CDefine9 = apply.CDefine9,
                CPersonCode = apply.CPersonCode,
                CHandler = apply.CMaker,
                CMaker = apply.CMaker,
                CMemo = apply.CMemo,
                VtId = 30718,
                Ufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                Dnmaketime = DateTime.Now,
                CSource = "委外订单",
                Cvencode = apply.CVenCode,
                Csysbarcode = $"||st64|{code}",
                MaterialAppVouchs = new List<MaterialAppVouchs>()
            };
            #endregion
            #region Create Detail
            var autoid = MaterialAppVouchs.Max(t => t.AutoId) + 1;
            foreach (var item in order.StoreStockDetail)
            {
                var detail = applydetails.FirstOrDefault(t => t.CInvCode == item.ProductNumbers);
                vouch.MaterialAppVouchs.Add(new MaterialAppVouchs()
                {
                    AutoId = autoid++,
                    Id = id,
                    CInvCode = item.ProductNumbers,
                    INum = item.Numbers * -1 * (detail?.FBaseQtyD ?? 0),
                    IQuantity = item.Numbers * -1,
                    CBatch = item.ProductBatch,
                    DDueDate = DateTime.Now.Date,
                    FOutQuantity = 0,
                    CDefine22 = detail.CDefine22,
                    CDefine23 = detail.CDefine23,
                    CDefine24 = detail.CDefine24,
                    CDefine25 = detail.CDefine25,
                    CDefine26 = detail.CDefine26,
                    CDefine27 = detail.CDefine27,
                    CDefine28 = detail.CDefine28,
                    CDefine29 = detail.CDefine29,
                    CDefine30 = detail.CDefine30,
                    CDefine31 = detail.CDefine31,
                    CDefine32 = detail.CDefine32,
                    CDefine33 = detail.CDefine33,
                    CDefine34 = detail.CDefine34,
                    CDefine35 = detail.CDefine35,
                    CDefine36 = detail.CDefine36,
                    CDefine37 = detail.CDefine37,
                    CName = apply.CDefine8,
                    CItemCname = "项目管理",
                    CAssUnit = detail.CUnitId,
                    CWhCode = detail.CWhCode,
                    Iinvexchrate = 1 / detail.FBaseQtyD,
                    Irowno = detail.Irowno,
                    IOmoMid = detail.MoDetailsId,
                    IOmoDid = detail.MomaterialsId,
                    Comcode = apply.CCode,
                    Invcode = OmModetails.FirstOrDefault(t => t.ModetailsId == detail.MoDetailsId)?.CInvCode,
                    Corufts = "515862.3406",
                    Ipesodid = detail.MomaterialsId.ToString(),
                    Ipesotype = 8,
                    Cpesocode = apply.CCode,
                    Cbsysbarcode = $"||st64|{code}|{detail.Irowno}"
                });
            }
            #endregion

            MaterialAppVouch.Add(vouch);
            return SaveChanges() > 0;
        }
        #endregion
        #endregion

        /// <summary>
        /// DateTime转换为Unix时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private double ConvertTimestamp(DateTime time)
        {
            return (time - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }


        #region 查询采购
        public PagedResult<PoPomain> GetCheckedPOs(string brand, string suppliercode, int pageindex, int pagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            return GetPos(t => t.CDefine8 == brand && t.CVenCode == suppliercode && (t.Iverifystateex == 1 || t.Iverifystateex == 2) && string.IsNullOrEmpty(t.CDefine9) && string.IsNullOrEmpty(t.CCloser), pageindex, pagesize);
        }

        public PagedResult<PoPomain> GetAffirmPOs(string brand, string suppliercode, int pageindex, int pagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            return GetPos(t => t.CDefine8 == brand && t.CVenCode == suppliercode && t.CDefine9 == "已确认" && !string.IsNullOrEmpty(t.CVerifier), pageindex, pagesize);
        }

        public PagedResult<PoPomain> GetDeliverPOs(string brand, string suppliercode, int pageindex, int pagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            return GetPos(t => t.CDefine8 == brand && t.CVenCode == suppliercode && t.CDefine9 == "已发货" && !string.IsNullOrEmpty(t.CVerifier), pageindex, pagesize);
        }

        public PagedResult<PoPomain> GetOverPOs(string brand, string suppliercode, int pageindex, int pagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            return GetPos(t => t.CDefine8 == brand && t.CVenCode == suppliercode && !string.IsNullOrEmpty(t.CCloser), pageindex, pagesize);
        }

        public List<Zpurpotail> GetPODetails(string orderno)
        {
            var po = PoPomain.FirstOrDefault(t => t.CPoid == orderno);
            if (po == null)
                return null;
            var list = Zpurpotail.Where(t => t.Poid == po.Poid).ToList();
            return list;
        }

        public bool UpdatePurchaseOrderState(string orderno, string state)
        {
            var po = PoPomain.FirstOrDefault(t => t.CPoid == orderno);
            po.CDefine9 = state;
            return SaveChanges() > 0;
        }

        private PagedResult<PoPomain> GetPos(Expression<Func<PoPomain, bool>> expression, int pageindex, int pagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            var tmp_orders = PoPomain.Where(expression);
            var total = tmp_orders.Count();
            var orders = tmp_orders.OrderBy(t => t.DPodate).Skip(pageindex * pagesize - pagesize).Take(pagesize).ToList();
            orders.ForEach(o =>
            {
                o.MaxArriveDate = PoPodetails.Where(d => d.Poid == o.Poid).Max(d => d.DArriveDate ?? DateTime.MinValue);
                o.Details.ForEach(d =>
                {
                    var inventory = GetInventory(d.CInvCode);
                    d.ProductName = inventory.CInvName;
                    d.ProductModel = inventory.CInvStd;
                    d.ProductNumbers = d.CInvCode;
                    d.UnitName = inventory.UnitName;
                });
            });
            return new PagedResult<PoPomain>(total, orders);
        }
        #endregion


        #region 调拨

        /// <summary>
        /// 分页获取调拨出库单
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="orderno"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="isChecked"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public PagedResult<RdRecord09> GetAllotOrders(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            var tmp_orders = RdRecord09.Where(t => t.CBusType == "调拨出库"
                                && t.CDefine8 == brand
                                && (string.IsNullOrEmpty(orderno) || t.CCode.Contains(orderno))
                                && (starttime == null || t.DDate >= starttime)
                                && (endtime == null || t.DDate <= endtime)
                                && (isChecked ? !string.IsNullOrEmpty(t.CHandler) : string.IsNullOrEmpty(t.CHandler)))
                            .OrderByDescending(t => t.DDate);

            var total = tmp_orders.Count();
            var result = tmp_orders.Skip(pageindex * pagesize - pagesize).Take(pagesize).ToList();

            result.ForEach(o =>
            {
                var tv = TransVouch.FirstOrDefault(t => t.CTvcode == o.CBusCode);
                o.OutWhName = Warehouse.FirstOrDefault(w => w.CWhCode == tv.COwhCode)?.CWhName ?? "";
                o.InWhName = Warehouse.FirstOrDefault(w => w.CWhCode == tv.CIwhCode)?.CWhName ?? "";
                o.Brand = tv.CDefine2;
                o.TargetBrand = tv.CDefine1;
                o.Details = Rdrecords09.Where(d => d.CDefine29 != "checked" && d.Id == o.Id).ToList();
                o.Details.ForEach(d =>
                {
                    var inventory = GetInventory(d.CInvCode);
                    d.ProductName = inventory.CInvName;
                    d.ProductModel = inventory.CInvStd;
                    d.UnitName = inventory.UnitName;
                });
            });
            return new PagedResult<RdRecord09>(total, result);
        }

        /// <summary>
        /// 分页获取其他出库单
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="orderno"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="isChecked"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public PagedResult<RdRecord09> GetAllotOutRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            var tmp_orders = RdRecord09.Where(t => t.CDefine8 == brand
                        && (string.IsNullOrEmpty(orderno) || t.CCode.Contains(orderno))
                        && (starttime == null || t.DDate >= starttime)
                        && (endtime == null || t.DDate <= endtime)
                        && (isChecked ? !string.IsNullOrEmpty(t.CHandler) : string.IsNullOrEmpty(t.CHandler)));
            var total = tmp_orders.Count();
            var datas = tmp_orders.Skip(pageindex * pagesize - pagesize).Take(pagesize).ToList();

            datas.ForEach(o =>
            {
                o.OutWhName = Warehouse.FirstOrDefault(w => w.CWhCode == o.CWhCode)?.CWhName ?? "";
                o.Details = Rdrecords09.Where(d => d.Id == o.Id).ToList();
                o.Details.ForEach(d =>
                {
                    var inv = GetInventory(d.CInvCode);
                    d.ProductModel = inv.CInvStd;
                    d.ProductName = inv.CInvName;
                    d.OrderNo = o.CCode;
                    d.UnitName = inv.UnitName;
                });
            });

            return new PagedResult<RdRecord09>(total, datas);
        }

        /// <summary>
        /// 其他入库单
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="orderno"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="isChecked"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public PagedResult<RdRecord08> GetAllotInRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            var tmp_orders = RdRecord08.Where(t => t.CDefine8 == brand
                                && (string.IsNullOrEmpty(orderno) || t.CCode.Contains(orderno))
                                && (starttime == null || t.DDate >= starttime)
                                && (endtime == null || t.DDate <= endtime)
                                && (isChecked ? !string.IsNullOrEmpty(t.CHandler) : string.IsNullOrEmpty(t.CHandler)));

            var total = tmp_orders.Count();
            var datas = tmp_orders.Skip(pageindex * pagesize - pagesize).Take(pagesize).ToList();
            datas.ForEach(o =>
            {
                o.WhName = Warehouse.FirstOrDefault(w => w.CWhCode == o.CWhCode)?.CWhName ?? "";
                o.Details = Rdrecords08.Where(d => d.Id == o.Id).ToList();
                o.Details.ForEach(d =>
                {
                    var inv = GetInventory(d.CInvCode);
                    d.ProductModel = inv.CInvStd;
                    d.ProductName = inv.CInvName;
                    d.OrderNo = o.CCode;
                    d.UnitName = inv.UnitName;
                });
            });

            return new PagedResult<RdRecord08>(total, datas);
        }


        public PagedResult<Rdrecords09> GetAllotRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize)
        {
            CheckPageIndex(pageindex);
            CheckPageSize(pagesize);
            pageindex--;
            //var tmp_orders = RdRecord09.Where(t => t.CBusType == "调拨出库"
            //                    && t.CDefine8 == brand
            //                    && (string.IsNullOrEmpty(orderno) || t.CCode.Contains(orderno))
            //                    && (starttime == null || t.DDate >= starttime)
            //                    && (endtime == null || t.DDate <= endtime)
            //                    && (isChecked ? !string.IsNullOrEmpty(t.CHandler) : string.IsNullOrEmpty(t.CHandler)))
            //    //.Join(TransVouch, r => r.CBusCode, tv => tv.CTvcode, (r, tv) => new { r, tv })
            //    .Join(Rdrecords09.Where(rs => rs.CDefine29 != "checked"), r => r.Id, rs => rs.Id, (r, rs) => new { r, rs });
            var orders = RdRecord09.Where(t => t.CBusType == "调拨出库"
                    && t.CDefine8 == brand
                    && (string.IsNullOrEmpty(orderno) || t.CCode.Contains(orderno))
                    && (starttime == null || t.DDate >= starttime)
                    && (endtime == null || t.DDate <= endtime)
                    && (isChecked ? !string.IsNullOrEmpty(t.CHandler) : string.IsNullOrEmpty(t.CHandler)))
                .Join(Rdrecords09.Where(rs => rs.CDefine29 != "checked"), r => r.Id, rs => rs.Id, (r, rs) => new { r, rs });

            var total = orders.Count();
            var datas = orders.Skip(pageindex * pagesize - pagesize).Take(pagesize).ToList();
            var list = new List<Rdrecords09>();

            var results = datas.Select(v =>
            {
                var storename = Warehouse.FirstOrDefault(w => w.CWhCode == v.r.CWhCode)?.CWhName ?? "";
                var inventory = Inventory.FirstOrDefault(i => i.CInvCode == v.rs.CInvCode);
                var unitcode = inventory?.CComUnitCode ?? "";
                return new Rdrecords09
                {
                    AutoId = v.rs.AutoId,
                    OrderNo = v.r.CCode,
                    CreateTime = v.r.DDate,
                    Remark = v.r.CMemo,
                    Brand = v.r.CDefine8,
                    StoreName = storename,
                    ProductModel = inventory?.CInvStd,
                    ProductName = inventory?.CInvName,
                    ProductNumbers = v.rs.CInvCode,
                    Numbers = v.rs.IQuantity ?? 0,
                    UnitName = ComputationUnit.FirstOrDefault(u => u.CComunitCode == unitcode)?.CComUnitName ?? ""
                };
            });
            return new PagedResult<Rdrecords09>(total, results);
        }


        public bool CheckAllotInRecord(string orderno)
        {
            var record = RdRecord08.FirstOrDefault(t => t.CCode == orderno);
            record.CHandler = record.CMaker;
            record.DVeriDate = DateTime.Now.Date;
            record.Dnverifytime = DateTime.Now;
            return SaveChanges() > 0;
        }


        public bool CheckAllotOutRecord(string orderno)
        {
            var record = RdRecord09.FirstOrDefault(t => t.CCode == orderno);
            record.CHandler = record.CMaker;
            record.DVeriDate = DateTime.Now.Date;
            record.Dnverifytime = DateTime.Now;
            return SaveChanges() > 0;
        }

        public bool CheckAllotOutRecord(string orderno, string autoid)
        {
            var detailRecord = RdRecord09.Where(t => t.CCode == orderno).Join(Rdrecords09, t => t.Id, d => d.Id, (t, d) => d).FirstOrDefault(t => t.AutoId.ToString() == autoid);
            if (detailRecord == null) return false;
            if (detailRecord.CDefine29 == "checked") return true;
            detailRecord.CDefine29 = "checked";
            var result = SaveChanges() > 0;
            CheckAllotInAndOutRecord(orderno);
            return result;
        }

        public string GetAllotTargetWHCode(string outorderno)
        {
            var InWhCode = GetTrans(outorderno)?.CIwhCode;
            return InWhCode;
        }

        private TransVouch GetTrans(string outorderno)
        {
            var transVouchOrderNo = RdRecord09.FirstOrDefault(t => t.CCode == outorderno)?.CBusCode;
            return TransVouch.FirstOrDefault(t => t.CTvcode == transVouchOrderNo);
        }

        private bool CheckAllotInAndOutRecord(string outorderno)
        {
            var record = RdRecord09.FirstOrDefault(t => t.CCode == outorderno);
            var detailRecords = Rdrecords09.Where(t => t.Id == record.Id);
            if (!detailRecords.Any(t => t.CDefine29 != "checked"))
            {
                CheckAllotOutRecord(record);
                var allotno = GetTrans(outorderno)?.CTvcode;
                var inrecord = RdRecord08.FirstOrDefault(t => t.CBusCode == allotno);
                CheckAllotInRecord(inrecord);
            }
            return SaveChanges() > 0;

        }

        private bool CheckAllotInRecord(RdRecord08 record)
        {
            if (record == null) return false;
            record.CHandler = record.CMaker;
            record.DVeriDate = DateTime.Now.Date;
            record.Dnverifytime = DateTime.Now;
            return true;
        }
        private bool CheckAllotOutRecord(RdRecord09 record)
        {
            if (record == null) return false;
            record.CHandler = record.CMaker;
            record.DVeriDate = DateTime.Now.Date;
            record.Dnverifytime = DateTime.Now;
            return true;
        }
        #endregion

        /// <summary>
        /// 新增或者更新仓储数据
        /// </summary>
        /// <param name="order"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private bool InsertOrUpdateStore(DtoStockOrder order, Func<decimal, decimal, decimal> action)
        {
            foreach (var item in order.StoreStockDetail)
            {
                var scmItems = ScmItem.FirstOrDefault(t => t.CInvCode == item.ProductNumbers);
                if (scmItems == null) return false;
                var itemid = scmItems.Id;
                var stock = CurrentStock.FirstOrDefault(t => t.CInvCode == item.ProductNumbers && t.CBatch == item.ProductBatch && t.CWhCode == item.StoreId);
                if (stock != null)
                {
                    stock.IQuantity = action(stock.IQuantity ?? 0, item.Numbers ?? 0);
                    Database.ExecuteSqlRaw("update currentstock set iQuantity =" + stock.IQuantity + " where cInvCode = '" + item.ProductNumbers + "' and cBatch = '" + item.ProductBatch + "' and cWhCode = " + item.StoreId);
                    continue;
                }

                //新增
                Database.ExecuteSqlRaw(string.Format("insert into currentStock (cWhCode,cInvCode,ItemId,cBatch,cVMIVenCode,iSoType,iSodid,iQuantity,iNum,fOutQuantity,fOutNum,fInQuantity,fInNum,bStopFlag,fTransInQuantity,fTransInNum,fTransOutQuantity,fTransOutNum,fPlanQuantity,fPlanNum,fDisableQuantity,fDisableNum,fAvaQuantity,fAvaNum,BGSPSTOP,cCheckState,ipeqty,ipenum)  values ('{0}','{1}',{2},'{3}','',0,'',{4},{5},0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);",
                                                                    item.StoreId, item.ProductNumbers, itemid, item.ProductBatch, item.Numbers, 0));

            }
            return true;
        }

        /// <summary>
        /// 更新仓储数据
        /// </summary>
        /// <param name="order"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private void UpdateStore(DtoStockOrder order, Func<decimal, decimal, decimal> action)
        {
            foreach (var item in order.StoreStockDetail)
            {
                var tmp_stocks = CurrentStock.Where(t => t.CInvCode == item.ProductNumbers);
                if (tmp_stocks.Count() == 0)
                {
                    throw new Exception($"{item.ProductNumbers}不存在任何库存记录");
                }
                var itemid = tmp_stocks.First().ItemId;
                var stocks = tmp_stocks.Where(t => t.CWhCode == item.StoreId);
                var stock = stocks.FirstOrDefault(t => t.CBatch == item.ProductBatch);
                var needNumber = item.Numbers ?? 0;
                var oddNumber = action(stock?.IQuantity ?? 0, needNumber);
                if (oddNumber < 0)
                {
                    if (stock != null) stock.IQuantity = 0;
                    needNumber = Math.Abs(oddNumber);
                    var stocksOderderByBatch = stocks.OrderBy(t => t.CBatch);
                    foreach (var s in stocksOderderByBatch)
                    {
                        if (s.CBatch == item.ProductBatch) continue;
                        if (s.IQuantity <= 0) continue;
                        s.IQuantity = action(s.IQuantity ?? 0, needNumber);
                        if (s.IQuantity < 0)
                        {
                            s.IQuantity = 0;
                            needNumber = Math.Abs(s.IQuantity ?? 0);
                            continue;
                        }
                        //已经够出库/入库的数量了
                        needNumber = 0;
                        break;
                    }//所有批号的都进行了递减后还是无法满足要出库/入库的数量
                    if (needNumber != 0)
                    {
                        throw new Exception($"{item.ProductNumbers}在仓库{item.StoreId}库存不足");
                    }
                }
            }
        }

        /// <summary>
        /// 更新委外订单明细的到货数量
        /// </summary>
        /// <param name="item"></param>
        private void UpdateModetailsReceiveNumber(PuArrivalVouchs item)
        {
            var detail = OmModetails.FirstOrDefault(t => t.ModetailsId == item.IPosId)
                ?? throw new FinancialException($"无法找到委外订单明细：{item.IPosId}");
            //运算符优先级BUG
            //detail.IReceivedQty = (detail.IReceivedQty ?? 0) + item.IQuantity;
            //累计合格入库数
            detail.Freceivedqty = (detail.Freceivedqty ?? 0) + item.IQuantity;
            //累计到货数
            var arrQty = (detail.IArrQty ?? 0) + item.IQuantity;
            //TODO 数据不对应的情况应该直接用异常处理
            detail.IArrQty = Math.Min(detail.IQuantity ?? 0, arrQty);
        }

        /// <summary>
        /// 更新采购订单收货数量
        /// </summary>
        /// <param name="item"></param>
        private void UpdatePoDetailsReceiveNumber(PuArrivalVouchs item)
        {
            var detail = PoPodetails.FirstOrDefault(t => t.Id == item.IPosId);
            if (detail == null) return;
            //detail.IReceivedQty = (detail.IReceivedQty ?? 0) + item.IQuantity;
            detail.Freceivedqty = (detail.Freceivedqty ?? 0) + item.IQuantity;
            detail.IArrQty = (detail.IArrQty ?? 0) + item.IQuantity;
        }

        private void UpdatePoDetailsArrQtyNumber(PuArrivalVouchs item)
        {
            var detail = PoPodetails.FirstOrDefault(t => t.Id == item.IPosId);
            if (detail == null) return;
            //累计到货数量
            var arrQty = (detail.IArrQty ?? 0) + item.IQuantity;
            ///不能超过订单明细数量
            //TODO 使用异常处理此处
            detail.IArrQty = Math.Min(detail.IQuantity ?? 0, arrQty);
        }

        /// <summary>
        /// 添加未记账数据
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="did"></param>
        /// <param name="vouchType"></param>
        /// <param name="busType"></param>
        /// <returns></returns>
        private bool AddUnAccountRdrecord(long mid, long did, string vouchType, string busType)
        {
            var sql = "insert IA_ST_UnAccountVouch" + vouchType + " (IDUN,IDSUN,cVouTypeUN,cBustypeUN) values (" + mid + "," + did + ",'" + vouchType + "','" + busType + "')";
            return Database.ExecuteSqlRaw(sql) > 0;
        }

        /// <summary>
        /// 添加未记账数据
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="dids"></param>
        /// <param name="vouchType"></param>
        /// <param name="busType"></param>
        /// <returns></returns>
        private bool AddUnAccountRdrecord(long mid, List<long> dids, string vouchType, string busType)
        {
            var sql = new StringBuilder();
            foreach (var did in dids)
            {
                sql.Append("insert IA_ST_UnAccountVouch" + vouchType + " (IDUN,IDSUN,cVouTypeUN,cBustypeUN) values (" + mid + "," + did + ",'" + vouchType + "','" + busType + "');");
            }
            return Database.ExecuteSqlRaw(sql.ToString()) > 0;
        }

        #region close
        public bool ClosePurarrivalOrderTransaction(string orderno, string closer, Func<bool, bool> action)
        {
            using (var tran = Database.BeginTransaction())
            {
                var order = PuArrivalVouch.FirstOrDefault(t => t.CCode == orderno);
                if (order == null) return false;
                order.Ccloser = closer;
                order.Cverifier = order.Cverifier ?? closer;
                order.Dclosedate = order.CAuditDate = DateTime.Now.Date;
                order.Caudittime = DateTime.Now;
                PuArrivalVouch.Update(order);
                var result = action(SaveChanges() > 0);
                if (result)
                    tran.Commit();
                else
                    tran.Rollback();
                return result;
            }
        }
        #endregion

    }

    /// <summary>
    /// 流水号属性
    /// </summary>
    public class CodeProperty
    {
        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// 流水号长度
        /// </summary>
        public int GlideLen { get; set; }
        /// <summary>
        /// 重置规则
        /// </summary>
        public string ResetOn { get; set; }
        /// <summary>
        /// 起始编号
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// 步进
        /// </summary>
        public int Step { get; set; }
    }

}
