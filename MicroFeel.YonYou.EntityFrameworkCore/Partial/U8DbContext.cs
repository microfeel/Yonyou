using MicroFeel.Finance;
using MicroFeel.Finance.Models;
using MicroFeel.Finance.Models.DbDto;
using MicroFeel.YonYou.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public TEntity GetFirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return Set<TEntity>().FirstOrDefault(expression);
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
            return await GetFirstAsync<Data.Customer>(c => c.CCusCode == code);
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
            return await GetFirstAsync<Person>(t => t.CPersonCode == code);
        }

        public async Task<Person> GetPersonByNameAsync(string name)
        {
            return await GetFirstAsync<Person>(t => t.CPersonName == name);
        }

        public async Task<Vendor> GetSupplierByPhoneAsync(string phonecode)
        {
            return await GetFirstAsync<Vendor>(t => t.CVenPhone == phonecode);
        }

        public async Task<Vendor> GetSupplierAsync(string code)
        {
            return await GetFirstAsync<Vendor>(t => t.CVenCode == code);
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
        public PagedResult<OmModetails> GetOutsourcingOrders(string brand, string key, string supplier, DateTime? starttime, DateTime? endtime, int pageIndex, int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            var tmp_datas = OmMomain.Where(t => t.CState > 0 && t.CDefine8 == brand &&
                                                        (string.IsNullOrEmpty(key) || t.CCode.Contains(key)) &&
                                                        (string.IsNullOrEmpty(supplier) || t.CVenPerson.Contains(supplier)) &&
                                                        (starttime == null || t.DDate >= starttime) &&
                                                        (endtime == null || t.DDate <= endtime))
                .Join(OmModetails, t => t.Moid, d => d.Moid, (t, d) => new { t, d })
                .Where(t => (t.d.IQuantity - (t.d.IArrQty ?? t.d.IReceivedQty ?? t.d.Freceivedqty ?? 0)) > 0);
            var total = tmp_datas.Count();
            var datas = tmp_datas.Skip(pageIndex * pageSize).Take(pageSize).ToList().Select(t =>
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
            return new PagedResult<OmModetails>(total, datas, pageIndex + 1, pageSize);
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

        public PagedResult<PuArrHead> GetPurchaseOrders(string ordertype, string brand, string key, string supplier, string state, DateTime? starttime, DateTime? endtime, int pageIndex, int pageSize = U8Consts.DefaultPagesize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            var puarrOrders = PuArrHead
                .Where(pu => pu.Cdefine8 == brand
                            && pu.Cbustype == ordertype
                            && pu.Cvoucherstate == state
                            && (starttime == null || pu.Ddate >= starttime)
                            && (endtime == null || pu.Ddate <= endtime)
                            && (string.IsNullOrEmpty(supplier) || pu.Cvenname.Contains(supplier)));

            IEnumerable<RdRecord01> rdorders = RdRecord01;
            //if (!string.IsNullOrEmpty(key))
            //{
            //    rdorders = rdorders.Where(rd => !string.IsNullOrEmpty(rd.CDefine10) && rd.CDefine10.Contains(key)).ToList();
            //}

            //实现LEFT JOIN
            var tmp_datas = from pu in puarrOrders
                            join rd in RdRecord01
                            on pu.Id equals rd.Ipurarriveid
                            into pugroup
                            from rd2 in pugroup.DefaultIfEmpty()
                            select new { pu, rd2 };

            if (!string.IsNullOrEmpty(key))
            {
                tmp_datas = tmp_datas.Where(c => c.rd2 != null && c.rd2.CDefine10 != null && c.rd2.CDefine10.Contains(key));
            }

            var total = tmp_datas.Count();
            var orders = tmp_datas
                .OrderByDescending(v => v.pu.Ddate)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
            orders.ForEach(e =>
            {
                //填充对应的入库单号和明细
                e.pu.Details = PuArrbody.Where(t => t.Id == e.pu.Id).ToList();
                e.pu.RdRecordNo = e.rd2?.CCode ?? "";
                e.pu.SendOrderNo = e.rd2?.CDefine10 ?? "";
            });
            return new PagedResult<PuArrHead>(total, orders.Select(o => o.pu), pageIndex + 1, pageSize);
        }

        /// <summary>
        /// 获取领料申请单
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
        public PagedResult<OmMomain> GetMaterials(
            string departmentcode,
            string key,
            DateTime? starttime,
            DateTime? endtime,
            int pageIndex,
            int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            var tmp_orders = OmMomain.Include(main => main.OmModetails)
                .Join(OmMomaterialshead, main => main.Moid, head => head.Moid, (main, head) => new { main, head })
                .Where(t => t.main.CState < 2
                            && (t.main.CDepCode == departmentcode || string.IsNullOrEmpty(t.main.CDepCode))
                            && (starttime == null || t.main.DDate >= starttime)
                            && (endtime == null || t.main.DDate <= endtime)
                            && (string.IsNullOrEmpty(key) || t.head.Cinvname.Contains(key) || t.head.Ccode.Contains(key) || t.head.Cinvstd.Contains(key)));
            var total = tmp_orders.Count();
            var orders = tmp_orders.OrderByDescending(o => o.main.Moid).Skip(pageIndex * pageSize).Take(pageSize).ToList();
            orders.ForEach(o =>
            {
                o.main.ProductModel = o.head.Cinvstd;
                o.main.ProductName = o.head.Cinvname;
                o.main.Details = o.main.OmModetails.ToList();
            });
            return new PagedResult<OmMomain>(total, orders.Select(v => v.main), pageIndex + 1, pageSize);
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
        public PagedResult<OmMomain> GetMaterials(
            string departmentcode,
            string key,
            int pageIndex,
            int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            var tmp_orders = OmMomain
                .Join(OmMomaterialshead, main => main.Moid, head => head.Moid, (main, head) => new { main, head })
                .Where(t => t.main.CDepCode == departmentcode
                            && (string.IsNullOrEmpty(key) || t.head.Cinvstd.Contains(key)));
            var total = tmp_orders.Count();
            var orders = tmp_orders.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            orders.ForEach(o =>
            {
                o.main.ProductModel = o.head.Cinvstd;
                o.main.ProductName = o.head.Cinvname;
            });
            return new PagedResult<OmMomain>(total, orders.Select(v => v.main), pageIndex + 1, pageSize);
        }

        /// <summary>
        /// 获取委外订单领料单
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
            var orders = OmMomaterialshead.Where(t => t.Ccode == orderno)
                .Join(OmMomaterialsbody, t => t.Moid, d => d.Moid, (t, d) => new { d, InStoreQty = t.Ireceivedqty })
                .ToList();
            //为可退货数量赋值
            orders.ForEach(o => o.d.AllowReturnQty = (o.d.Isendqty ?? 0) - Math.Max(0, decimal.Divide((o.InStoreQty ?? 0) * (o.d.Fbaseqtyn ?? 0), (o.d.Fbaseqtyd ?? 1))));
            return orders.Select(o => o.d).ToList();
        }

        /// <summary>
        /// 获取委外订单材料出库单
        /// </summary>
        /// <param name="mainNo">订单编号</param>
        /// <param name="includeDetails">是否包含明细</param>
        /// <returns></returns>
        public List<Rdrecord11> GetOmMainRdrecords(string mainNo, bool includeDetails = true)
        {
            var rdrecode11s = Rdrecord11.Where(r => r.CMpoCode == mainNo).ToList();
            if (includeDetails)
            {
                foreach (var rdrecord in rdrecode11s)
                {
                    rdrecord.Details = Rdrecords11.Where(rds => rds.Id == rdrecord.Id).ToList();
                }
            }
            return rdrecode11s;
        }

        /// <summary>
        /// 获取委外订单
        /// </summary>
        /// <param name="mainNo"></param>
        /// <returns></returns>
        public OmMomain GetOmMomain(string mainNo, bool includeDetails = true)
        {
            var bill = OmMomain.FirstOrDefault(t => t.CCode == mainNo);
            if (includeDetails)
            {
                bill.Details = OmModetails.Where(v => v.Moid == bill.Moid).ToList();
            }
            return bill;
        }

        /// <summary>
        /// 获取存货
        /// </summary>
        /// <param name="productcode"></param>
        public Inventory GetInventory(string productcode)
        {
            return GetInventory(productcode, "");
        }

        /// <summary>
        /// 带批号获取存货
        /// </summary>
        /// <param name="productcode">存货编码</param>
        /// <param name="batch">批号</param>
        /// <returns></returns>
        internal Inventory GetInventory(string productcode, string batch)
        {
            var product = Inventory.FirstOrDefault(t => t.CInvCode == productcode);
            if (product != null)
            {
                product.InvClassName = InventoryClass.FirstOrDefault(c => c.CInvCcode == product.CInvCcode)?.CInvCname;
                product.Stock = GetInventoryStock(productcode, batch);
                product.UnitName = ComputationUnit.FirstOrDefault(u => u.CComunitCode == product.CShopUnit)?.CComUnitName;
            }
            return product;
        }

        /// <summary>
        /// 获取现存量
        /// </summary>
        /// <param name="inventoryCode"></param>
        /// <returns></returns>
        public List<CurrentStock> GetInventoryStock(string inventoryCode, string batch = "")
        {
            var cs = CurrentStock.Where(t => t.CInvCode == inventoryCode);
            if (!string.IsNullOrEmpty(batch))
            {
                cs = cs.Where(v => v.CBatch == batch);
            }
            var stocks = cs
                .Join(Warehouse, inv => inv.CWhCode, wh => wh.CWhCode, (inv, wh) => new { inv, wh.CWhName }).ToList();
            stocks.ForEach(s => s.inv.WhName = s.CWhName);
            return stocks.Select(s => s.inv).ToList();
        }

        //public PagedResult<Inventory> GetInventory(string brand, string classcode, string storecode, string key, int pageIndex, int pageSize)
        //{
        //    var result = GetInventory(brand, classcode, storecode, key, pageIndex, pageSize, out int total);
        //    return (total, result);
        //}

        /// <summary>
        /// 获取存货列表
        /// </summary>
        /// <param name="brand">品牌</param>
        /// <param name="classCode">大类编码</param>
        /// <param name="storecode">仓库编码</param>
        /// <param name="key">关键词</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public PagedResult<Inventory> GetInventory(string brand, string classCode, string storecode, string key, int pageIndex, int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            var products = Inventory
                            .Where(t => t.CInvDefine1 == brand && t.CInvCcode.StartsWith(classCode) && (string.IsNullOrEmpty(key) || t.CInvName.Contains(key)))
                            .Join(CurrentStock.Where(t => t.CWhCode == storecode && t.IQuantity.HasValue && t.IQuantity.Value > 0)
                            .Select(t => t.CInvCode).Distinct(), t => t.CInvCode, d => d, (t, d) => t);
            var total = products.Count();
            var result = products.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            result.ForEach(p =>
            {
                p.InvClassName = InventoryClass.FirstOrDefault(c => c.CInvCcode == p.CInvCcode)?.CInvCname;
                p.Stock = GetInventoryStock(p.CInvCode);
                p.UnitName = ComputationUnit.FirstOrDefault(u => u.CComunitCode == p.CShopUnit)?.CComUnitName;
            });
            return new PagedResult<Inventory>(total, result, pageIndex + 1, pageSize);
        }

        private static void CheckPageIndex(int pageIndex)
        {
            if (pageIndex <= 0)
            {
                throw new Exception($"页码为{pageIndex}，值应该大于0");
            }
        }

        private static void CheckPageSize(int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new Exception($"{pageSize} 不是有效的页大小");
            }
        }

        #region Add
        #region 委外加工到货单
        /// <summary>
        /// 创建委外到货单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
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
                    //更新委外明细 回填到货数量
                    foreach (var item in result.Details)
                    {
                        UpdateModetailsArrQty(item);
                        //更新待入库数量
                        UpdateCurrentStock(
                            item.CWhCode,
                            item.CInvCode,
                            item.CBatch,
                            item.IQuantity,
                            0,
                            true
                        );
                        //UpdateCurrentStock(
                        //    item.CWhCode,
                        //    item.CInvCode,
                        //    item.CBatch,
                        //    c => { c.FInQuantity += item.IQuantity; });
                    }
                    //更新现存量
                    var commitResult = SaveChanges() > 0;
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

        /// <summary>
        /// 更新现存量
        /// </summary>
        /// <param name="whcode"></param>
        /// <param name="invCode"></param>
        /// <param name="batch"></param>
        /// <param name="action"></param>
        [Obsolete("无主键表目前不能用此方法更新")]
        private void UpdateCurrentStock(string whcode, string invCode, string batch, Action<CurrentStock> action)
        {
            var cs = CurrentStock.AsNoTracking().FirstOrDefault(c => c.CWhCode == whcode && c.CInvCode == invCode && c.CBatch == batch);
            if (cs == null)
            {
                var itemid = GetSCMItem(invCode).Id;
                cs = new CurrentStock
                {
                    CWhCode = whcode,
                    CInvCode = invCode,
                    CBatch = batch,
                    ItemId = itemid
                };
                CurrentStock.Add(cs);
            }
            //对此现存量对象操作
            action(cs);
            CurrentStock.Update(cs);
        }

        /// <summary>
        /// 获取计算存量用临时表Id
        /// </summary>
        /// <param name="invCode">存货编码</param>
        /// <param name="v1">存货自由项1</param>
        /// <param name="v2">存货自由项2</param>
        /// <param name="v3">存货自由项3</param>
        /// <param name="v4">存货自由项4</param>
        /// <param name="v5">存货自由项5</param>
        /// <param name="v6">存货自由项6</param>
        /// <param name="v7">存货自由项7</param>
        /// <param name="v8">存货自由项8</param>
        /// <param name="v9">存货自由项9</param>
        /// <param name="v10">存货自由项10</param>
        /// <returns></returns>
        private ScmItem GetSCMItem(
            string invCode,
            string v1 = "",
            string v2 = "",
            string v3 = "",
            string v4 = "",
            string v5 = "",
            string v6 = "",
            string v7 = "",
            string v8 = "",
            string v9 = "",
            string v10 = "")
        {
            var item = ScmItem.FirstOrDefault(s => s.CInvCode == invCode
                && v1 == s.CFree1
                && v2 == s.CFree2
                && v3 == s.CFree3
                && v4 == s.CFree4
                && v5 == s.CFree5
                && v6 == s.CFree6
                && v7 == s.CFree7
                && v8 == s.CFree8
                && v9 == s.CFree9
                && v10 == s.CFree10);
            if (item == null)
            {
                var nid = ScmItem.OrderByDescending(item => item.Id).FirstOrDefault()?.Id + 1 ?? 1;
                item = new ScmItem
                {
                    Id = nid,
                    PartId = 0,
                    CInvCode = invCode,
                    CFree1 = v1,
                    CFree2 = v2,
                    CFree3 = v3,
                    CFree4 = v4,
                    CFree5 = v5,
                    CFree6 = v6,
                    CFree7 = v7,
                    CFree8 = v8,
                    CFree9 = v9,
                    CFree10 = v10
                };
                ScmItem.Add(item);
                ScmItem.Update(item);
            }
            return item;
        }

        /// <summary>
        /// 更新单条现存量
        /// </summary>
        /// <param name="whcode">仓库编号</param>
        /// <param name="invCode">存货编码</param>
        /// <param name="batch">批号</param>
        /// <param name="quantity">数量</param>
        /// <param name="isPrepare">是待入库</param>
        private void UpdateCurrentStock(string whcode, string invCode, string batch, decimal inQuantity, decimal outQuantity = 0, bool isPrepare = false)
        {
            if (inQuantity == 0 && outQuantity == 0)
            {
                throw new Exception("入库和出库数不能同时为零!");
            }

            var scmItem = ScmItem.FirstOrDefault(t => t.CInvCode == invCode);
            if (scmItem == null)
            {
                scmItem = new ScmItem(invCode);
                ScmItem.Add(scmItem);
                SaveChanges();
            }
            //?? throw new FinancialException($"scmitem(库存管理)中无法找到编码为{item.ProductNumbers}的存货");

            var itemid = scmItem.Id;
            var stock = CurrentStock.FirstOrDefault(t => t.CInvCode == invCode
                && t.CBatch == batch
                && t.CWhCode == whcode);

            if (stock != null)
            {
                stock.IQuantity = isPrepare ? (stock.IQuantity ?? 0) : (stock.IQuantity ?? 0) + inQuantity - outQuantity;
                stock.FInQuantity = isPrepare ? ((stock.FInQuantity ?? 0) + inQuantity) : ((stock.FInQuantity ?? 0) - inQuantity);
                stock.FOutQuantity = isPrepare ? ((stock.FOutQuantity ?? 0) + outQuantity) : ((stock.FOutQuantity ?? 0) - outQuantity);
                //if (stock.FInQuantity < 0)
                //{
                //    stock.FInQuantity = 0;
                //}
                Database.ExecuteSqlRaw($"update currentstock set iQuantity ={stock.IQuantity},finQuantity={stock.FInQuantity},foutQuantity = {stock.FOutQuantity} where cInvCode = '{invCode}' and cBatch = '{batch}' and cWhCode = '{whcode}'");
            }
            else
                //新增
                Database.ExecuteSqlRaw($"insert into currentStock (cWhCode,cInvCode,ItemId,cBatch,cVMIVenCode,iSoType,iSodid,iQuantity,iNum,fOutQuantity,fOutNum,fInQuantity,fInNum,bStopFlag,fTransInQuantity,fTransInNum,fTransOutQuantity,fTransOutNum,fPlanQuantity,fPlanNum,fDisableQuantity,fDisableNum,fAvaQuantity,fAvaNum,BGSPSTOP,cCheckState,ipeqty,ipenum)  values ('{whcode}','{invCode}',{itemid},'{batch}','',0,'',{(isPrepare ? 0 : inQuantity)},0,{(isPrepare ? outQuantity : 0)},0,{(isPrepare ? inQuantity : 0)},0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);");
            //Database.ExecuteSqlRaw($"insert into currentStock (cWhCode,cInvCode,ItemId,cBatch,cVMIVenCode,iSoType,iSodid,iQuantity,iNum,fOutQuantity,fOutNum,fInQuantity,fInNum,bStopFlag,fTransInQuantity,fTransInNum,fTransOutQuantity,fTransOutNum,fPlanQuantity,fPlanNum,fDisableQuantity,fDisableNum,fAvaQuantity,fAvaNum,BGSPSTOP,cCheckState,ipeqty,ipenum)  values ('{whcode}','{invCode}',{itemid},'{batch}','',0,'',{quantity},{0},0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);");
        }

        internal PagedResult<DispatchList> GetDispatchBills(string brand, int pageIndex, int pageSize, DispatchBillState billState)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;

            var startDate = new DateTime(2020, 7, 28);
            IEnumerable<DispatchList> dispatchbills = DispatchList.Where(dl => dl.DDate >= startDate && (!dl.BReturnFlag) && (dl.CDefine2 != "柜台") && (dl.CSocode != ""));
            if (!string.IsNullOrWhiteSpace(brand))
            {
                dispatchbills = dispatchbills.Where(dl => dl.CDefine8 == brand);
            }
            switch (billState)
            {
                case DispatchBillState.Processing:
                    dispatchbills = dispatchbills.Where(d => d.CChangeMemo is null && !d.Dverifysystime.HasValue);
                    break;
                case DispatchBillState.Sending:
                    dispatchbills = dispatchbills.Where(d => !(d.CChangeMemo is null) && d.CChangeMemo.StartsWith("待发货"));
                    break;
                case DispatchBillState.Completed:
                    dispatchbills = dispatchbills.Where(d => d.Dverifysystime.HasValue);
                    break;
                default:
                    break;
            }
            //TODO Dispatchbill没有索引,导致查询超时,暂时去掉合计
            var total = 100;//dispatchbills.Count();
            var result = dispatchbills.OrderByDescending(dl => dl.DDate)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
            return new PagedResult<DispatchList>(total, result, pageIndex + 1, pageSize);
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
            var id = GetDispatchBillByCode(billNo).Dlid;
            return GetDispatchBillDetail(id);
        }
        /// <summary>
        /// 获取发货单明细
        /// </summary>
        /// <param name="dlid">发货单ID</param>
        /// <returns></returns>
        internal IList<DispatchLists> GetDispatchBillDetail(int dlid)
        {
            return DispatchLists.Where(dls => dls.Dlid == dlid).OrderBy(dls => dls.AutoId).ToList();
        }

        internal DispatchList GetDispatchBillByCode(string billNo)
        {
            return DispatchList.AsNoTracking().FirstOrDefault(v => v.CDlcode == billNo)
                ?? throw new FinancialException($"找不到发货单:{billNo}");
        }

        /// <summary>
        /// 更新发货单状态
        /// </summary>
        /// <param name="billNo">单号</param>
        /// <param name="statusName">状态名称</param>
        public void UpdateDispatchBillState(string billNo, string statusName)
        {
            //没有主键没法跟踪
            //var dispatch = DispatchList.FirstOrDefault(v => v.CDlcode == billNo)
            //    ?? throw new FinancialException($"找不到发货单:{billNo}");
            //dispatch.CChangeMemo = statusName;
            //Update(dispatch);
            //SaveChanges();

            //TODO remove this usage
            var sql = $"UPDATE DispatchList SET CChangeMemo = '{statusName}' WHERE cDLCode = '{billNo}'";
            Database.ExecuteSqlRaw(sql);
        }

        /// <summary>
        /// 审核发货单
        /// </summary>
        /// <param name="billNo"></param>
        /// <param name="makerName"></param>
        internal void VerifyDispatchBill(string billNo, string makerName)
        {
            var sql = $"UPDATE DispatchList SET cVerifier = '{makerName}', Dverifydate='{DateTime.Today}', Dverifysystime='{DateTime.Now}' WHERE cDLCode = '{billNo}'";
            Database.ExecuteSqlRaw(sql);
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
                CMaker = order.Maker,
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
                    .FirstOrDefault(t => (t.CInvCode == orderitem.ProductNumbers))
                    ?? throw new FinancialException($"无法找到单据stockDto:{order.OrderNo},{order.SourceOrderNo},{orderitem.ProductNumbers},mainid.ccode :{momain.CCode}");

                //var item = momain.OmModetails
                //    .FirstOrDefault(t => (t.CInvCode == orderitem.ProductNumbers)
                //            && ((t.IQuantity - (t.IArrQty ?? 0)) >= orderitem.Numbers)) ?? throw new FinancialException($"是否存在合并到货?");

                autoid += 1;
                puArrivalVouch.Details.Add(new PuArrivalVouchs
                {
                    Autoid = autoid,
                    Id = id,
                    CWhCode = orderitem.StoreId,
                    CInvCode = item.CInvCode,
                    IQuantity = orderitem.Numbers ?? 0,
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
            string code = $"PuWIN{DateTime.Today:yyyyMMdd}{id.ToString().Substring(id.ToString().Length - 5)}";
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
            var puarrival = PuArrivalVouch.FirstOrDefault(t => t.CCode == order.SourceOrderNo);
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
            //更新现存量
            InsertOrUpdateStore(order);
            //foreach (var item in puarrival.Details)
            //    UpdateCurrentStock(
            //        item.CWhCode,
            //        item.CInvCode,
            //        item.CBatch,
            //        cs =>
            //        {
            //            cs.FInQuantity -= item.IQuantity; //更新待入库数量
            //            cs.IQuantity += item.IQuantity; //更新现存量
            //        });

            //UpdateModetailsReceiveNumber(puarrival.PuArrivalVouchs);
            //更新到货单状态
            ClosePuArrivalState(puarrival, order.Maker);
            //puarrival.CAuditDate = puarrival.Dclosedate = DateTime.Today;
            //puarrival.Cverifier = puarrival.Ccloser = order.Maker;

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
                //CBusCode = puArrival.CCode,
                CWhCode = cwhcode,
                DDate = DateTime.Now.Date,
                CRdCode = "101",
                CDepCode = puArrival.CDepCode,
                CPersonCode = puArrival.CPersonCode,
                CPtcode = null,
                CVenCode = puArrival.CVenCode,
                COrderCode = puArrival.Cpocode,
                CArvcode = puArrival.CCode,
                //CHandler = puArrival.CMaker,
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
        /// <param name="maker">制单人</param>
        /// <returns></returns>
        private List<RdRecord01> CreateRdrecord01(PuArrivalVouch puArrival, string maker)
        {
            List<RdRecord01> list = new List<RdRecord01>();
            var warehouses = puArrival.Details.GroupBy(t => t.CWhCode).ToDictionary(t => t.Key, t => t.ToList());
            long id = 0, detailid = 0;
            foreach (var whcode in warehouses.Keys)
            {
                puArrival.Details = warehouses[whcode];
                list.Add(CreateRdrecord01(whcode, puArrival, ref id, ref detailid, maker));
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
                Step = vn.IGlideStep,
                Prefix1Rule = vn.Prefix1Rule.Trim()
            };
        }

        /// <summary>
        /// 创建入库记录
        /// </summary>
        /// <param name="cwhcode">仓库编码</param>
        /// <param name="puArrival">到货单</param>
        /// <param name="id">入库单ID</param>
        /// <param name="detailid">明细ID</param>
        /// <param name="maker">制单人</param>
        /// <returns></returns>
        public RdRecord01 CreateRdrecord01(string cwhcode, PuArrivalVouch puArrival, ref long id, ref long detailid, string maker)
        {
            id = (id == 0) ? (RdRecord01.Max(t => t.Id) + 1) : (id + 1);
            var cp = GetCode("采购入库单");
            //var codePrefix = $"{cp.Prefix1Rule}{DateTime.Today:yyMM}";
            var code = $"{cp.Prefix}{"1".PadLeft(cp.GlideLen, '0')}";
            var maxCode = RdRecord01.AsNoTracking().Where(r => EF.Functions.Like(r.CCode, cp.Prefix + "%")).OrderByDescending(r => r.CCode).FirstOrDefault();
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
                //CBusCode = puArrival.CCode,
                CWhCode = cwhcode,
                DDate = DateTime.Now.Date,
                CRdCode = rdcode.ContainsKey(puArrival.CBusType) ? rdcode[puArrival.CBusType] : "103",
                CDepCode = puArrival.CDepCode,
                CPersonCode = puArrival.CPersonCode,
                CPtcode = null,
                CVenCode = puArrival.CVenCode,
                COrderCode = puArrival.Cpocode,
                CArvcode = puArrival.CCode,
                CMemo = puArrival.CMemo,
                BTransFlag = false,
                CMaker = maker,
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
        public bool FromPuArrivalVouchToStoreRecord(string puarrivalOrderNo, string maker)
        {
            return SaveRdRecordsTran(puarrivalOrderNo, null, maker);
        }

        /// <summary>
        /// 到货单下推入库单
        /// </summary>
        /// <param name="puarrivalOrderNo"></param>
        /// <param name="batch"></param>
        /// <returns></returns>
        public bool FromPuArrivalVouchToStoreRecord(string puarrivalOrderNo, Dictionary<string, string> batchs, string maker)
        {
            return SaveRdRecordsTran(puarrivalOrderNo, t =>
            {
                t.ForEach(item => item.Details.ToList().ForEach(d =>
                {
                    if (batchs.ContainsKey(d.CInvCode))
                        d.CBatch = batchs[d.CInvCode];
                }));
            },
            maker);
        }

        /// <summary>
        /// 到货单下推入库单
        /// </summary>
        /// <param name="puarrivalOrderNo"></param>
        /// <param name="sendOrderNo"></param>
        /// <returns></returns>
        public bool FromPuArrivalVouchToStoreRecord(string puarrivalOrderNo, string sendOrderNo, string maker)
        {
            if (sendOrderNo.Length > 55)
            {
                sendOrderNo = sendOrderNo.Substring(0, 55);
            }
            return SaveRdRecordsTran(puarrivalOrderNo, t => { t.ForEach(item => item.CDefine10 = sendOrderNo); }, maker);
        }

        /// <summary>
        /// 生成入库单
        /// </summary>
        /// <param name="puarrivalOrderNo"></param>
        /// <param name="action"></param>
        /// <param name="maker">制单人</param>
        /// <returns></returns>
        private bool SaveRdRecordsTran(string puarrivalOrderNo, Action<List<RdRecord01>> action, string maker)
        {
            using (var tran = Database.BeginTransaction())
            {
                try
                {
                    var puarrival = PuArrivalVouch.FirstOrDefault(t => t.CCode == puarrivalOrderNo);
                    if (puarrival is null)
                    {
                        throw new FinancialException($"找不到单号为{puarrivalOrderNo}的到货单。");
                    }
                    puarrival.Details = PuArrivalVouchs.Where(t => t.Id == puarrival.Id).ToList();
                    //创建入库单
                    var records = CreateRdrecord01(puarrival, maker);
                    action?.Invoke(records);
                    //保存记录并更新现存量
                    bool commitResult = SaveRdRecords(puarrival, records);
                    //更新到货单状态
                    ClosePuArrivalState(puarrival, maker);
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

        /// <summary>
        /// 关闭到货单
        /// </summary>
        /// <param name="puarrival">到货单</param>
        /// <param name="closer">关闭人</param>
        private void ClosePuArrivalState(PuArrivalVouch puarrival, string closer)
        {
            puarrival.Caudittime = DateTime.Now;
            puarrival.CAuditDate = puarrival.Dclosedate = DateTime.Today;
            puarrival.Ccloser = puarrival.Cverifier = closer;
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
                    UpdatePoDetailsReceiveNumber(item);
                }
                else if (puarrival.CBusType == "委外加工")
                {
                    //更新委外单据入库数量 
                    var detail = OmModetails.FirstOrDefault(t => t.ModetailsId == item.IPosId);
                    if (detail == null) continue;
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
            //更新现存量
            InsertOrUpdateStore(new DtoStockOrder
            {
                Brand = puarrival.CDefine8,
                SourceOrderNo = puarrival.CCode,
                StoreStockDetail = puarrival.Details.Select(t => new DtoStoreStockDetail
                {
                    Numbers = t.IQuantity,
                    ProductBatch = t.CBatch,
                    ProductNumbers = t.CInvCode,
                    StoreId = t.CWhCode
                })
            });
            //foreach (var item in puarrival.Details)
            //    UpdateCurrentStock(
            //        item.CWhCode,
            //        item.CInvCode,
            //        item.CBatch,
            //        cs =>
            //        {
            //            cs.FInQuantity -= item.IQuantity; //更新待入库数量
            //            cs.IQuantity += item.IQuantity; //更新现存量
            //        });

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
        /// <param name="order">订单</param>
        /// <param name="AddAccount">添加待记账数据</param>
        /// <returns></returns>
        public void AddSellOrder(DtoStockOrder order, bool AddAccount = false)
        {
            using (var tran = Database.BeginTransaction())
            {
                try
                {
                    var dispatch = GetDispatchBillByCode(order.SourceOrderNo);
                    if (Rdrecord32.Any(r => r.CDlcode == dispatch.Dlid))
                    {
                        //已经生成过入库单,不再重复生成
                        return;
                    }

                    //整理发货单明细 2020.10.29 暂停发货单合并
                    //ReBuildDispatchDetail(order.SourceOrderNo);

                    dispatch.Details = DispatchLists.Where(t => t.Dlid == dispatch.Dlid).ToList();
                    //生成收发记录
                    var results = CreateRdrecord32s(dispatch, order);
                    results.ForEach(result =>
                    {
                        order.OrderNo = result.CCode;
                        order.Note += result.CCode + ",";
                        Rdrecord32.Add(result);
                        Rdrecords32.AddRange(result.Details);
                    });
                    foreach (var disDetail in dispatch.Details)
                    {
                        //更新销售订单发货数量
                        var sodetail = SoSodetails.FirstOrDefault(t => t.ISosId == disDetail.ISosId);
                        if (sodetail == null)
                        {
                            //TODO Log warning...
                            continue;
                        }
                        var orderdetail = order.StoreStockDetail.FirstOrDefault(t => t.ProductNumbers == disDetail.CInvCode && t.ProductBatch == disDetail.CBatch);
                        sodetail.IFhquantity = (sodetail.IFhquantity ?? 0) + (orderdetail?.Numbers ?? 0);
                        //更新已出库数量
                        disDetail.FOutQuantity = (disDetail.FOutQuantity ?? 0) + (orderdetail?.Numbers ?? 0);
                    }
                    //添加未记账数据
                    if (AddAccount)
                    {
                        results.ForEach(t =>
                        {
                            if (!AddUnAccountRdrecord(t.Id, t.Details.Select(d => d.AutoId).ToList(), "32", t.CBusType))
                                throw new FinancialException($"添加未记账数据时发生异常");

                        });
                    }
                    DispatchLists.UpdateRange(dispatch.Details);
                    var commitResult = SaveChanges() > 0;
                    if (commitResult)
                        tran.Commit();
                    else
                        tran.Rollback();

                    //更新现存量待入库数量
                    foreach (var rdrecord32 in results)
                    {
                        foreach (var rdrecordDetail in rdrecord32.Details)
                        {
                            UpdateCurrentStock(rdrecord32.CWhCode, rdrecordDetail.CInvCode, rdrecordDetail.CBatch, 0, rdrecordDetail.IQuantity.Value, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 整理发货单明细
        /// </summary>
        /// <remarks>
        /// 需要将不同批次的发货单明细内容进行合并,以扫码结果为准生成出库单
        /// </remarks>
        /// <param name="dlid">发货单ID</param>
        private void ReBuildDispatchDetail(string billno)
        {
            var details = GetDispatchBillDetail(billno).OrderBy(v => v.Iorderrowno).ToList();
            var dlid = details.First().Dlid;
            //分组后忽略掉批号
            var newdetails = details.GroupBy(v => (v.CWhCode, v.CInvCode));
            ///更新所有有重复的明细
            foreach (var nd in newdetails.Where(n => n.Count() > 1))
            {
                //找到原来的第一条
                var detail = DispatchLists.First(v => v.Dlid == dlid && v.CWhCode == nd.Key.CWhCode && v.CInvCode == nd.Key.CInvCode);
                //更新为合计
                detail.IQuantity = nd.Sum(n => n.IQuantity);
                detail.IMoney = nd.Sum(n => n.IMoney);
                detail.ISum = nd.Sum(n => n.ISum);
                detail.IDisCount = nd.Sum(n => n.IDisCount);
                detail.INatMoney = nd.Sum(n => n.INatMoney);
                detail.INatSum = nd.Sum(n => n.INatSum);
                detail.INatDisCount = nd.Sum(n => n.INatDisCount);
                detail.CBatch = null;
                DispatchLists.Update(detail);
                //删除其他的记录
                var willRemoved = DispatchLists.Where(d => d.Dlid == dlid && d.CWhCode == nd.Key.CWhCode && d.CInvCode == nd.Key.CInvCode && d.AutoId != detail.AutoId);
                DispatchLists.RemoveRange(willRemoved);
            }
            SaveChanges();
            //整理rownumber
            var rowNo = 0;
            details = DispatchLists.Where(v => v.Dlid == dlid).ToList();
            foreach (var item in details)
            {
                item.Iorderrowno = ++rowNo;
                item.CbSysBarCode = $"||SA01|{billno}|{rowNo}";
                DispatchLists.Update(item);
            }
        }

        /// <summary>
        /// 创建销售出库单
        /// </summary>
        /// <param name="dispatch">发货单</param>
        /// <param name="order">库存单据对象</param>
        /// <returns></returns>
        private List<Rdrecord32> CreateRdrecord32s(DispatchList dispatch, DtoStockOrder order)
        {
            var list = new List<Rdrecord32>();
            var dic = dispatch.Details.GroupBy(t => t.CWhCode).ToDictionary(t => t.Key, t => t.ToList());
            //按仓库分组生成收发记录
            foreach (var key in dic.Keys)
            {
                dispatch.Details = dic[key];
                list.Add(CreateRdrecord32(key, dispatch, order));
            }
            return list;
        }
        /// <summary>
        /// 生成一张销售出库单
        /// </summary>
        /// <param name="cwhcode">仓库编码</param>
        /// <param name="dispatch">发货单</param>
        /// <param name="order">库存单据</param>
        /// <returns></returns>
        private Rdrecord32 CreateRdrecord32(string cwhcode, DispatchList dispatch, DtoStockOrder order)
        {
            var id = Rdrecord32.AsNoTracking().Max(t => t.Id) + 1;
            var cp = GetCode("销售出库单");
            //var codePrefix = $"QC{DateTime.Today:yyMM}";
            var code = $"{cp.Prefix}{"1".PadLeft(cp.GlideLen, '0')}";
            var maxCode = Rdrecord32.AsNoTracking().Where(r => EF.Functions.Like(r.CCode, cp.Prefix + "%")).OrderByDescending(r => r.CCode).FirstOrDefault();
            if (maxCode != null)
            {
                code = maxCode.CCode;
                var newCodeNumber = int.Parse(code.Substring(code.Length - cp.GlideLen)) + 1;
                code = $"{cp.Prefix}{newCodeNumber.ToString().PadLeft(cp.GlideLen, '0')}";
            }
            var rdrecord = new Rdrecord32
            {
                Id = id,
                CBusCode = dispatch.CDlcode,
                CCode = code,
                CWhCode = cwhcode,
                CRdCode = dispatch.CRdCode,
                CDepCode = dispatch.CDepCode,
                CPersonCode = dispatch.CPersonCode,
                CStcode = dispatch.CStcode,
                CCusCode = dispatch.CCusCode,
                CDlcode = dispatch.Dlid,
                //CHandler = dispatch.CMaker,      //不做自动审核
                // DVeriDate=dispatch.Dverifydate
                CMemo = $"(自动)从发货单:{order.SourceOrderNo}生成.{dispatch.CMemo}",
                CAccounter = dispatch.CAccounter,
                CMaker = order.Maker,
                CDefine1 = dispatch.CDefine1,
                CDefine2 = dispatch.CDefine2?.Trim(),
                CDefine10 = dispatch.CDefine10,
                CDefine11 = dispatch.CDefine11,
                CDefine12 = dispatch.CDefine12,
                CDefine13 = dispatch.CDefine13,
                CDefine14 = dispatch.CDefine14,
                CDefine15 = dispatch.CDefine15,
                CDefine16 = dispatch.CDefine16,
                CDefine3 = dispatch.CDefine3?.Trim(),
                CDefine4 = dispatch.CDefine4,
                CDefine5 = dispatch.CDefine5,
                CDefine6 = dispatch.CDefine6,
                CDefine7 = dispatch.CDefine7,
                CDefine8 = dispatch.CDefine8,
                CDefine9 = dispatch.CDefine9,
                Biafirst = dispatch.BIafirst,
                Csysbarcode = $"||st32|{code}",
                Cinvoicecompany = dispatch.Cinvoicecompany
            };
            if (string.IsNullOrWhiteSpace(rdrecord.CRdCode))
            {
                var others = new string[] { "试用装", "柜台", "物料", "货品" };

                //TODO 将逻辑移出类库
                if (rdrecord.CDefine2.Contains("不计任务"))
                {
                    rdrecord.CRdCode = "222"; //特殊
                }
                else if (rdrecord.CDefine2.Contains("计任务"))
                {
                    rdrecord.CRdCode = "209"; //政策
                }
                else if (others.Contains(rdrecord.CDefine2))
                {
                    rdrecord.CRdCode = "211";  //费用
                }
                else
                {
                    rdrecord.CRdCode = "208";  //正常
                }
            }
            var rowNumber = 0;
            var lastAutoId = Rdrecords32.AsNoTracking().Max(t => t.AutoId);
            //foreach (var orderitem in order.StoreStockDetail)
            //TODO 暂时使用发货单数据
            foreach (var item in dispatch.Details)
            {
                rowNumber++;
                //var v_本次已发料数量 = rdrecord.Details
                //    .Where(v => v.CInvCode == orderitem.ProductNumbers)
                //    .Sum(d => d.IQuantity ?? 0);
                //var item = dispatch.Details.First(v => v.CInvCode == orderitem.ProductNumbers);
                SoSodetails soDetailrow = null;
                if (item.ISosId.HasValue)
                {
                    //如果有销售订单，定位销售订单明细
                    soDetailrow = SoSodetails.FirstOrDefault(sd => sd.ISosId == item.ISosId);
                }
                rdrecord.Details.Add(new Rdrecords32
                {
                    AutoId = lastAutoId + rowNumber,
                    Id = rdrecord.Id,
                    CInvCode = item.CInvCode,
                    IQuantity = item.IQuantity,
                    Cbdlcode = rdrecord.CBusCode,
                    CBatch = item.CBatch,
                    CDefine27 = 0,
                    CItemClass = "97",
                    CItemCode = item.CItemCode,
                    IDlsId = item.IDlsId,
                    CName = item.CItemName,
                    CItemCname = "项目管理",
                    INquantity = item.IQuantity,
                    //IUnitCost = item.IUnitPrice,
                    //IPrice = item.IUnitPrice,
                    Iorderdid = item.ISosId,
                    Iordercode = item.CSoCode,
                    Iorderseq = soDetailrow?.IRowNo ?? null,
                    Ipesodid = item.ISosId.ToString(),
                    Ipesoseq = soDetailrow?.IRowNo ?? null,
                    Irowno = rowNumber,
                    Cbsysbarcode = $"||st32|{rdrecord.CCode}|{rowNumber}"
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
                    //查找领料申请单
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
        /// <summary>
        /// 创建材料出库单
        /// </summary>
        /// <param name="materialApp"></param>
        /// <param name="order"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 创建材料出库单(从领料申请单)
        /// </summary>
        /// <param name="cwhcode">创建编码</param>
        /// <param name="materialApp">领料申请单</param>
        /// <param name="order"></param>
        /// <param name="id"></param>
        /// <param name="detailid"></param>
        /// <returns></returns>
        private Rdrecord11 CreateRdrecord11(string cwhcode, MaterialAppVouch materialApp, DtoStockOrder order, ref long id, ref long detailid)
        {
            var momain = OmMomain.FirstOrDefault(t => t.CCode == materialApp.MaterialAppVouchs.FirstOrDefault().Comcode);
            if (momain == null)
                throw new FinancialException($"申请单（{materialApp.CCode})明细中关联的委外订单单号（{materialApp.MaterialAppVouchs.FirstOrDefault()?.Comcode}）没有对应的委外单据");
            var head = $"CC{DateTime.Now:yyMM}";
            id = id == 0 ? (Rdrecord11.Max(t => t.Id) + 1) : id + 1;
            var lastcode = Rdrecord11.Where(rd => rd.CCode.StartsWith(head)).OrderByDescending(rd => rd.CCode).FirstOrDefault();

            var codeNumber = lastcode?.CCode.Substring(7) ?? "0";

            string code = $"CC{DateTime.Now:yyMMdd}{int.Parse(codeNumber) + 1:d4}";

            var rdrecord = new Rdrecord11
            {
                Id = id,
                CBusType = "委外发料",
                CSource = "领料申请单",
                //CBusCode = materialApp.CCode,
                CWhCode = cwhcode,
                CCode = code,
                CRdCode = materialApp.CRdCode,
                CDepCode = materialApp.CDepCode,
                CPersonCode = materialApp.CPersonCode,
                CVenCode = materialApp.Cvencode,
                CHandler = materialApp.CMaker,
                CMemo = materialApp.CMemo,
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

                CPsPcode = OmModetails.FirstOrDefault(o => o.ModetailsId == materialApp.MaterialAppVouchs.FirstOrDefault().IOmoMid)?.CInvCode,
                CMpoCode = materialApp.MaterialAppVouchs.FirstOrDefault()?.Comcode,

                //Ufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                IMquantity = materialApp.Imquantity.HasValue ? (double)materialApp.Imquantity.Value : 0,
                Iproorderid = momain.Moid,

                Csysbarcode = $"||st11|{materialApp.CCode}",
                Details = new List<Rdrecords11>()
            };
            detailid = detailid == 0 ? (Rdrecords11.Max(t => t.AutoId) + 1) : detailid;
            foreach (var mavItem in materialApp.MaterialAppVouchs)
            {
                var orderitem = order.StoreStockDetail.First(t => t.ProductNumbers == mavItem.CInvCode);
                detailid += 1;
                rdrecord.Details.Add(new Rdrecords11
                {
                    AutoId = detailid,
                    Id = rdrecord.Id,
                    CInvCode = orderitem.ProductNumbers,
                    INum = mavItem.INum,
                    IQuantity = orderitem.Numbers,
                    CDefine22 = mavItem.CDefine22,
                    CDefine23 = mavItem.CDefine23,
                    CDefine24 = mavItem.CDefine24,
                    CDefine25 = mavItem.CDefine25,
                    CDefine26 = mavItem.CDefine26,
                    CDefine27 = mavItem.CDefine27,
                    CDefine28 = mavItem.CDefine28,
                    CDefine29 = mavItem.CDefine29,
                    CDefine30 = mavItem.CDefine30,
                    CDefine31 = mavItem.CDefine31,
                    CDefine32 = mavItem.CDefine32,
                    CDefine33 = mavItem.CDefine33,
                    CDefine34 = mavItem.CDefine34,
                    CDefine35 = mavItem.CDefine35,
                    CDefine36 = mavItem.CDefine36,
                    CDefine37 = mavItem.CDefine37,
                    CBatch = orderitem.ProductBatch,
                    CItemCode = mavItem.CItemCode,
                    CName = order.Brand,
                    CItemCname = mavItem.CItemCname,
                    CItemClass = mavItem.CItemClass,
                    INquantity = mavItem.FOutQuantity,
                    IOmoMid = mavItem.IOmoMid,
                    IOmoDid = mavItem.IOmoDid,
                    Cmocode = mavItem.Cmocode,
                    Ipesodid = mavItem.Ipesodid,
                    Cpesocode = mavItem.Cpesocode,
                    Ipesotype = mavItem.Ipesotype,
                    Ipesoseq = orderitem.SourceEntryId,
                    Irowno = orderitem.SourceEntryId,
                    //Rowufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                    Cbsysbarcode = $"||st11|{rdrecord.CCode}|{orderitem.SourceEntryId}",
                    //  CbMemo = item.CbMemo,
                });
            }
            return rdrecord;
        }

        /// <summary>
        /// 创建材料出库单(从退料数据)
        /// </summary>
        /// <param name="order">领料单号</param>
        /// <returns></returns>
        public void CreateRdrecord11(DtoBackStore order)
        {
            //查询材料出库单
            var momainBill = GetOmMomain(order.SourceOrderNo);
            var sourceBills = GetOmMainRdrecords(order.SourceOrderNo).OrderByDescending(o => o.CCode);
            ///所有退料编号
            //var invCodes = order.Details.Select(o => o.InvCode).ToList();

            //按仓库分组处理明细
            var orderDetails = order.Details.GroupBy(d => d.StoreCode);
            //遍历退料明细生成退料单
            foreach (var storeGroup in orderDetails)
            {
                //查找领出单据
                //源出库单明细
                var originalRecordDetail = Rdrecords11.FirstOrDefault(ords => ords.AutoId == storeGroup.First().AutoId); // sourceBills.FirstOrDefault(b => b.CWhCode == backDetail.StoreCode && b.Details.Any(d => d.Invcode == backDetail.InvCode && d.CBatch == backDetail.BatchCode))

                //源出库单
                var originalRecord = Rdrecord11.First(rd => rd.Id == originalRecordDetail.Id);
                //创建出库单
                //计算ID
                var id = Rdrecord11.Max(t => t.Id) + 1;
                //计算编号
                var head = $"CC{DateTime.Now:yyMM}";
                var lastcode = Rdrecord11.Where(rd => rd.CCode.StartsWith(head)).OrderByDescending(rd => rd.CCode).FirstOrDefault();
                var codeNumber = lastcode?.CCode.Substring(8) ?? "0";

                string code = $"CC{DateTime.Now:yyMMdd}{int.Parse(codeNumber) + 1:d4}";
                var currentRdrecord = new Rdrecord11
                {
                    Id = id,
                    CBusType = "委外发料",
                    CSource = "委外订单",
                    BRdFlag = 0,
                    CWhCode = storeGroup.Key,
                    CCode = code,
                    CRdCode = "201",    //委外出库-对外发料 from rd_style
                    CVenCode = momainBill.CVenCode,
                    CMemo = $"(自动) {order.SourceOrderNo}退料",
                    CMaker = order.Maker,
                    BTransFlag = false,
                    CDefine8 = order.Brand,
                    CDefine9 = "已同步",
                    Bpufirst = false,
                    Biafirst = false,
                    //产量
                    IMquantity = (double)(momainBill.Details.First().IQuantity ?? 0),
                    VtId = 65,
                    BIsStqc = false,

                    Iproorderid = originalRecord.Iproorderid,
                    CArvcode = originalRecord.CCode,
                    CPsPcode = originalRecord.CPsPcode,
                    CMpoCode = originalRecord.CPsPcode,
                    Csysbarcode = $"||st11|{originalRecord.CCode}",
                    //对OA工作流支持
                    Iswfcontrolled = 1,
                    Iverifystate = 1,

                    Details = new List<Rdrecords11>()
                };
                Rdrecord11.Add(currentRdrecord);
                var detailid = Rdrecords11.Max(t => t.AutoId);
                foreach (var backDetail in storeGroup)
                {
                    //查找领出单据
                    //源出库单明细
                    originalRecordDetail = Rdrecords11.FirstOrDefault(ords => ords.AutoId == backDetail.AutoId) // sourceBills.FirstOrDefault(b => b.CWhCode == backDetail.StoreCode && b.Details.Any(d => d.Invcode == backDetail.InvCode && d.CBatch == backDetail.BatchCode))
                        ?? throw new Exception($"无法找到需要退料的数据:invCode :{backDetail.InvCode},batch:{backDetail.BatchCode},whcode:{backDetail.StoreCode}");
                    //源出库单
                    originalRecord = Rdrecord11.First(rd => rd.Id == originalRecordDetail.Id);

                    var orderitem = order.Details.First(t => t.InvCode == originalRecordDetail.CInvCode && originalRecordDetail.CBatch == t.BatchCode);
                    //源投料单
                    var materialBill = OmMomaterials.First(md => md.MomaterialsId == originalRecordDetail.IOmoMid);
                    detailid += 1;
                    var newrds = new Rdrecords11
                    {
                        AutoId = detailid,
                        Id = currentRdrecord.Id,
                        CInvCode = orderitem.InvCode,
                        CBatch = orderitem.BatchCode,
                        IQuantity = -orderitem.Qty,
                        CDefine26 = originalRecordDetail.CDefine26.GetValueOrDefault(1),
                        IFlag = 0,//退料
                        INquantity = -(originalRecordDetail.IQuantity ?? 0),
                        INnum = -(originalRecordDetail.INum ?? 0),
                        CAssUnit = originalRecordDetail.CAssUnit,
                        BLpuseFree = originalRecordDetail.BLpuseFree,
                        IOriTrackId = originalRecordDetail.IOriTrackId,
                        BCosting = originalRecordDetail.BCosting,
                        BVmiused = originalRecordDetail.BVmiused,
                        Iinvexchrate = originalRecordDetail.Iinvexchrate,
                        Comcode = originalRecordDetail.Comcode,
                        Invcode = originalRecordDetail.Invcode,
                        IExpiratDateCalcu = originalRecordDetail.IExpiratDateCalcu,
                        Iorderdid = originalRecordDetail.Iorderdid,
                        Iordertype = originalRecordDetail.Iordertype,
                        Iordercode = originalRecordDetail.Iordercode,
                        Iopseq = originalRecordDetail.Iopseq,
                        Isotype = originalRecordDetail.Isotype,
                        Irowno = currentRdrecord.Details.Count + 1,
                        Cbsysbarcode = $"||st11|{currentRdrecord.CCode}|{currentRdrecord.Details.Count + 1}",
                        Cplanlotcode = originalRecordDetail.Cplanlotcode,
                        //下面是次要字段
                        CDefine22 = originalRecordDetail.CDefine22,
                        CDefine23 = originalRecordDetail.CDefine23,
                        CDefine24 = originalRecordDetail.CDefine24,
                        CDefine25 = originalRecordDetail.CDefine25,
                        CDefine27 = originalRecordDetail.CDefine27,
                        CDefine28 = originalRecordDetail.CDefine28,
                        CDefine29 = originalRecordDetail.CDefine29,
                        CDefine30 = originalRecordDetail.CDefine30,
                        CDefine31 = originalRecordDetail.CDefine31,
                        CDefine32 = originalRecordDetail.CDefine32,
                        CDefine33 = originalRecordDetail.CDefine33,
                        CDefine34 = originalRecordDetail.CDefine34,
                        CDefine35 = originalRecordDetail.CDefine35,
                        CDefine36 = originalRecordDetail.CDefine36,
                        CDefine37 = originalRecordDetail.CDefine37,
                        CItemCode = originalRecordDetail.CItemCode,
                        CName = originalRecordDetail.CName,
                        CItemCname = originalRecordDetail.CItemCname,
                        CItemClass = originalRecordDetail.CItemClass,
                        IOmoMid = originalRecordDetail.IOmoMid,
                        IOmoDid = originalRecordDetail.IOmoDid,
                        Cmocode = originalRecordDetail.Cmocode,
                        Ipesodid = originalRecordDetail.Ipesodid,
                        Cpesocode = originalRecordDetail.Cpesocode,
                        Ipesotype = originalRecordDetail.Ipesotype,
                        Ipesoseq = originalRecordDetail.Ipesoseq,
                        //Rowufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                        CbMemo = originalRecordDetail.CbMemo,
                    };
                    if (originalRecordDetail.CDefine26.GetValueOrDefault(1) != 1)
                    {
                        newrds.INum = decimal.Divide(-orderitem.Qty, (decimal)originalRecordDetail.CDefine26.GetValueOrDefault(1));
                    }
                    Rdrecords11.Add(newrds);
                }// foreach backorder.detail
                //保存出库单
                SaveChanges();
            }// foreach storeGroup
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
            //return new DateTimeOffset(time).ToUnixTimeMilliseconds();
            return (time - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        #region 查询采购
        public PagedResult<PoPomain> GetCheckedPOs(string brand, string suppliercode, int pageIndex, int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            return GetPos(t => t.CDefine8 == brand && t.CVenCode == suppliercode && (t.Iverifystateex == 1 || t.Iverifystateex == 2) && string.IsNullOrEmpty(t.CDefine9) && string.IsNullOrEmpty(t.CCloser), pageIndex, pageSize);
        }

        public PagedResult<PoPomain> GetAffirmPOs(string brand, string suppliercode, int pageIndex, int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            return GetPos(t => t.CDefine8 == brand && t.CVenCode == suppliercode && t.CDefine9 == "已确认" && !string.IsNullOrEmpty(t.CVerifier), pageIndex, pageSize);
        }

        public PagedResult<PoPomain> GetDeliverPOs(string brand, string suppliercode, int pageIndex, int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            return GetPos(t => t.CDefine8 == brand && t.CVenCode == suppliercode && t.CDefine9 == "已发货" && !string.IsNullOrEmpty(t.CVerifier), pageIndex, pageSize);
        }

        public PagedResult<PoPomain> GetOverPOs(string brand, string suppliercode, int pageIndex, int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            return GetPos(t => t.CDefine8 == brand && t.CVenCode == suppliercode && !string.IsNullOrEmpty(t.CCloser), pageIndex, pageSize);
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

        private PagedResult<PoPomain> GetPos(Expression<Func<PoPomain, bool>> expression, int pageIndex, int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            var tmp_orders = PoPomain.Where(expression);
            var total = tmp_orders.Count();
            var orders = tmp_orders.OrderBy(t => t.DPodate).Skip(pageIndex * pageSize).Take(pageSize).ToList();
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
            return new PagedResult<PoPomain>(total, orders, pageIndex + 1, pageSize);
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
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedResult<RdRecord09> GetAllotOrders(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageIndex, int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            var tmp_orders = RdRecord09.Where(t => t.CBusType == "调拨出库"
                                && t.CDefine8 == brand
                                && (string.IsNullOrEmpty(orderno) || t.CCode.Contains(orderno))
                                && (starttime == null || t.DDate >= starttime)
                                && (endtime == null || t.DDate <= endtime)
                                && (isChecked ? !string.IsNullOrEmpty(t.CHandler) : string.IsNullOrEmpty(t.CHandler)))
                            .OrderByDescending(t => t.DDate);

            var total = tmp_orders.Count();
            var result = tmp_orders.Skip(pageIndex * pageSize).Take(pageSize).ToList();

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
                    var inventory = GetInventory(d.CInvCode, d.CBatch);
                    d.ProductName = inventory.CInvName;
                    d.ProductModel = inventory.CInvStd;
                    d.UnitName = inventory.UnitName;
                });
            });
            return new PagedResult<RdRecord09>(total, result, pageIndex + 1, pageSize);
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
        public PagedResult<RdRecord09> GetAllotOutRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageIndex, int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            var tmp_orders = RdRecord09.Where(t => t.CDefine8 == brand
                        && (string.IsNullOrEmpty(orderno) || t.CCode.Contains(orderno))
                        && (starttime == null || t.DDate >= starttime)
                        && (endtime == null || t.DDate <= endtime)
                        && (isChecked ? !string.IsNullOrEmpty(t.CHandler) : string.IsNullOrEmpty(t.CHandler)));
            var total = tmp_orders.Count();
            var datas = tmp_orders.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            datas.ForEach(o =>
            {
                o.OutWhName = Warehouse.FirstOrDefault(w => w.CWhCode == o.CWhCode)?.CWhName ?? "";
                o.Details = Rdrecords09.Where(d => d.Id == o.Id).ToList();
                o.Details.ForEach(d =>
                {
                    var inv = GetInventory(d.CInvCode, d.CBatch);
                    d.ProductModel = inv.CInvStd;
                    d.ProductName = inv.CInvName;
                    d.OrderNo = o.CCode;
                    d.UnitName = inv.UnitName;
                });
            });

            return new PagedResult<RdRecord09>(total, datas, pageIndex + 1, pageSize);
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
        public PagedResult<RdRecord08> GetAllotInRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageIndex, int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
            var tmp_orders = RdRecord08.Where(t => t.CDefine8 == brand
                                && (string.IsNullOrEmpty(orderno) || t.CCode.Contains(orderno))
                                && (starttime == null || t.DDate >= starttime)
                                && (endtime == null || t.DDate <= endtime)
                                && (isChecked ? !string.IsNullOrEmpty(t.CHandler) : string.IsNullOrEmpty(t.CHandler)));

            var total = tmp_orders.Count();
            var datas = tmp_orders.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            datas.ForEach(o =>
            {
                o.WhName = Warehouse.FirstOrDefault(w => w.CWhCode == o.CWhCode)?.CWhName ?? "";
                o.Details = Rdrecords08.Where(d => d.Id == o.Id).ToList();
                o.Details.ForEach(d =>
                {
                    var inv = GetInventory(d.CInvCode, d.CBatch);
                    d.ProductModel = inv.CInvStd;
                    d.ProductName = inv.CInvName;
                    d.OrderNo = o.CCode;
                    d.UnitName = inv.UnitName;
                });
            });

            return new PagedResult<RdRecord08>(total, datas, pageIndex + 1, pageSize);
        }


        public PagedResult<Rdrecords09> GetAllotRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageIndex, int pageSize)
        {
            CheckPageIndex(pageIndex);
            CheckPageSize(pageSize);
            pageIndex--;
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
            var datas = orders.Skip(pageIndex * pageSize).Take(pageSize).ToList();
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
            return new PagedResult<Rdrecords09>(total, results, pageIndex + 1, pageSize);
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
        /// <param name="isPrepare">是待入库</param>
        /// <returns></returns>
        private void InsertOrUpdateStore(DtoStockOrder order, bool isPrepare = false)
        {
            ///currentStock没有主键,无法跟踪
            foreach (var item in order.StoreStockDetail)
            {
                UpdateCurrentStock(item.StoreId, item.ProductNumbers, item.ProductBatch, item.Numbers ?? 0, 0, isPrepare);
            }
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
                var tmp_stocks = CurrentStock.AsNoTracking().Where(t => t.CInvCode == item.ProductNumbers);
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
        /// 更新委外订单明细的收货数量
        /// </summary>
        /// <param name="item"></param>
        private void UpdateModetailsReceiveNumber(PuArrivalVouchs item)
        {
            var detail = OmModetails.FirstOrDefault(t => t.ModetailsId == item.IPosId)
                ?? throw new FinancialException($"无法找到委外订单明细：{item.IPosId}");
            //累计合格入库数
            detail.Freceivedqty = (detail.Freceivedqty ?? 0) + item.IQuantity;
        }

        /// <summary>
        /// 更新到货数
        /// </summary>
        /// <param name="item"></param>
        private void UpdateModetailsArrQty(PuArrivalVouchs item)
        {
            var detail = OmModetails.FirstOrDefault(t => t.ModetailsId == item.IPosId)
                ?? throw new FinancialException($"无法找到委外订单明细：{item.IPosId}");
            //累计到货数
            detail.IArrQty = (detail.IArrQty ?? 0) + item.IQuantity;
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
        /// <summary>
        /// 单据前缀
        /// </summary>
        public string Prefix1Rule { get; set; }
    }

}
