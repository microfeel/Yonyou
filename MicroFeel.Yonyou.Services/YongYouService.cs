using MicroFeel.Finance;
using MicroFeel.Finance.Models;
using MicroFeel.Finance.Models.DbDto;
using MicroFeel.YongYou.Models.Models;
using MicroFeel.Yonyou.Api.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Sugar.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Services
{
    public partial class YongYouService : IFinanceService
    {
        private const string appkey = "opaddd40e399ef4e98a";
        private const string appSecret = "ee5e0ee78c5942ef91686b61d2b76239";
        private const string from_account = "microfeel";
        private const string to_account = "18926990017";
        private const string base_url = "https://api.yonyouup.com/";
        private StockApi stockApi = new StockApi();
        private SystemApi systemApi = new SystemApi();
        private BasicApi basicApi = new BasicApi();
        private UFDbContext dbContext;
        private IConfiguration Configuration;

        public YongYouService()
        {
            stockApi.Init(base_url, appkey, appSecret, from_account, to_account);
            systemApi.Init(base_url, appkey, appSecret, from_account, to_account);
            basicApi.Init(base_url, appkey, appSecret, from_account, to_account);

            try
            {
                Configuration = new ConfigurationBuilder()
                          .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
                          .Build();

                var options = new DbContextOptionsBuilder().UseSqlServer(Configuration.GetConnectionString("UFDb")).Options;
                dbContext = new UFDbContext(options);
            }
            catch
            {

            }
        }

        public YongYouService(string connectstring) : this()
        {
            ConfigDbConnect(connectstring);
        }

        public void ConfigDbConnect(string connectstring)
        {
            var options = new DbContextOptionsBuilder().UseSqlServer(connectstring, op => op.UseRowNumberForPaging()).Options;

            dbContext = new UFDbContext(options);
        }

        public Finance.Models.Customer AddCustomer(Finance.Models.Customer customer)
        {
            throw new NotImplementedException();
        }

        public Finance.Models.Customer AddCustomer(Finance.Models.Customer customer, string predicate, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Finance.Models.Department AddDepartment(Finance.Models.Department dep)
        {
            throw new NotImplementedException();
        }

        public Emp AddEmployee(Emp emp)
        {
            throw new NotImplementedException();
        }

        public Emp AddEmployee(Emp emp, string predicate, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Item AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Material AddMaterial(Material material)
        {
            throw new NotImplementedException();
        }


        public Supplier AddSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public Voucher AddVoucher(IList<VoucherParmEntry> voucherParams, string explanation, string reference, string preparer, int groupID, DateTime date, DateTime transDate, string objectName = "", string parameter = "")
        {
            throw new NotImplementedException();
        }

        public Voucher AddVoucher(VoucherInfo voucherInfo)
        {
            throw new NotImplementedException();
        }

        public IList<Account> GetAccount()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Datasource>> GetBatchDatasourceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderStatus> GetOrderStatusAsync()
        {
            throw new NotImplementedException();
        }

        public List<Store> GetPlaces(string storecode)
        {
            return new List<Store>();

        }

        public List<Store> GetStores(string brand)
        {
            return basicApi.Batch_Get_WarehouseAsync().Result.Select<Api.Warehouse, Store>(t => { return t.To<Store>(); }).ToList();

        }

        public IList<VoucherTemplate> GetVoucherTemplate(IEnumerable<string> tempTypeNames)
        {
            throw new NotImplementedException();
        }

        public IList<VoucherTemplate> GetVoucherTemplate()
        {
            throw new NotImplementedException();
        }

        public List<Store> GetWorkShops(string brand)
        {
            return basicApi.Batch_Get_DepartmentAsync().Result.Select<Api.Department, Store>(t => { return t.To<Store>(); }).ToList();
        }

        public Task<Datasource> Get_DatasourceAsync()
        {
            return null;
        }

        #region Stock

        public bool Materialout(Materialout materialout)
        {
            throw new NotImplementedException();
        }

        public bool OtherIn(Otherin otherin)
        {
            throw new NotImplementedException();
        }

        public bool OtherOut(Otherout otherout)
        {
            throw new NotImplementedException();
        }

        public bool ProductIn(Productin productin)
        {
            var result = stockApi.Add_ProductinAsync(productin.To<Api.Productin>()).Result;
            return result.Errcode == "0";
        }

        public bool PurchaseIn(Purchasein purchasein)
        {
            throw new NotImplementedException();
        }

        public bool Saleout(Saleout saleout)
        {
            throw new NotImplementedException();
        }

        public Task<string> TokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> TradeidAsync()
        {
            throw new NotImplementedException();
        }

        public bool Transvouch(Transvouch transvouch)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Outsourcing
        public SingleObjectResult<Outsourcing> GetOutsourcing(string orderno, string productnumbers)
        {
            try
            {
                var order = dbContext.OmMomain.Where(t => t.CCode == orderno).Join(dbContext.OmModetails.Where(d => d.CInvCode == productnumbers || string.IsNullOrEmpty(productnumbers)), m => m.Moid, d => d.Moid, (m, d) => new { m, d }).FirstOrDefault();
                if (order == null)
                    return SingleObjectResult<Outsourcing>.Failed(MessageType.当前数据不存在);
                var product = dbContext.Inventory.FirstOrDefault(t => t.CInvCode == order.d.CInvCode);
                return SingleObjectResult<Outsourcing>.Success(new Outsourcing()
                {
                    CommitDate = order.d.DArriveDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    DateTime = order.m.DDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    Numbers = order.d.IQuantity ?? 0,
                    OrderNo = order.m.CCode,
                    Status = order.m.CState,
                    ProductNumber = order.d.CInvCode,
                    Supplier = dbContext.Vendor.FirstOrDefault(t => t.CVenCode == order.m.CVenCode)?.CVenName,
                    ProductName = product?.CInvName,
                    ProductBatch = "",
                    ProductModel = ""

                });

            }
            catch (Exception ex)
            {

                return SingleObjectResult<Outsourcing>.Failed(MessageType.服务器内部未知错误, ex.ToString());
            }
        }

        public SingleObjectResult<Outsourcing> GetOutsourcing(string orderno)
        {
            return GetOutsourcing(orderno, null);
        }

        public DataResult<Outsourcing> GetOutsourcings(int pageindex, int pagesize, Action<Outsourcing> wherecondition)
        {
            try
            {
                Outsourcing outsourcing = new Outsourcing();
                wherecondition?.Invoke(outsourcing);
                if (!string.IsNullOrEmpty(outsourcing.ProductName))
                    outsourcing.ProductName = dbContext.Inventory.FirstOrDefault(t => t.CInvName == outsourcing.ProductName)?.CInvCode;
                if (!string.IsNullOrEmpty(outsourcing.Supplier))
                    outsourcing.Supplier = dbContext.Vendor.FirstOrDefault(t => t.CVenName == outsourcing.Supplier)?.CVenCode;
                var temporary = dbContext.OmMomain.Where(t => (t.CCode == outsourcing.OrderNo || string.IsNullOrEmpty(outsourcing.OrderNo))
                            && (t.CVenCode == outsourcing.Supplier || string.IsNullOrEmpty(outsourcing.Supplier))).
                            Join(dbContext.OmModetails.Where(d => d.CInvCode == outsourcing.ProductName || string.IsNullOrEmpty(outsourcing.ProductName)),
                            m => m.Moid, d => d.Moid, (m, d) => new { m, d });
                var orders = temporary.Skip(pageindex * pagesize).Take(pagesize).ToList();
                if (orders == null || orders.Count() == 0)
                    return DataResult<Outsourcing>.Failed(MessageType.当前数据不存在);
                return DataResult<Outsourcing>.Success(pageindex, temporary.Count(),
                    orders.Select(order =>
                    {

                        var product = dbContext.Inventory.FirstOrDefault(t => t.CInvCode == order.d.CInvCode);
                        return new Outsourcing()
                        {
                            CommitDate = order.d.DArriveDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                            DateTime = order.m.DDate.ToString("yyyy-MM-dd HH:mm:ss"),
                            Numbers = order.d.IQuantity ?? 0,
                            OrderNo = order.m.CCode,
                            Status = order.m.CState,
                            ProductNumber = order.d.CInvCode,
                            Supplier = dbContext.Vendor.FirstOrDefault(t => t.CVenCode == order.m.CVenCode)?.CVenName,
                            ProductName = product?.CInvName,
                            ProductBatch = order.d.CPlanLotNumber,
                            ProductModel = product.CInvStd,
                            Brand = order.m.CDefine8
                        };
                    })
                    );

            }
            catch (Exception ex)
            {

                return DataResult<Outsourcing>.Failed(MessageType.服务器内部未知错误, ex.ToString());
            }
        }

        public MessageResult UpdateOutsourcing(Outsourcing outsourcing)
        {
            try
            {
                var order = dbContext.OmMomain.FirstOrDefault(t => t.CCode == outsourcing.OrderNo);
                if (order == null)
                    return SingleObjectResult<Outsourcing>.Failed(MessageType.当前数据不存在);
                //用友里面就有0，1，2三个状态，具体含义不清除。
                outsourcing.Status = outsourcing.Status > 2 ? 2 : outsourcing.Status;
                order.CState = (byte)outsourcing.Status;
                dbContext.SaveChanges();
                return MessageResult.Success();

            }
            catch (Exception ex)
            {

                return MessageResult.Failed(MessageType.服务器内部未知错误, ex.ToString());
            }
        }
        #endregion


        public void Dispose()
        {

        }

        #region 数据库直接操作
        public Dictionary<string, string> GetCustomers()
        {
            return dbContext.Customer.ToDictionary(t => t.CCusCode, t => t.CCusName);
        }

        public DtoCustomer GetCustomers(string code)
        {
            var c = dbContext.Customer.FirstOrDefault(t => t.CCusCode == code);
            if (c == null) return null;
            return new DtoCustomer()
            {
                Address = c.CCusAddress,
                City = c.CCity,
                Province = c.CProvince,
                Code = c.CCusCode,
                Name = c.CCusName
            };
        }

        public (string, string) GetCustomersByDispatch(string orderno)
        {
            var code = dbContext.DispatchList.FirstOrDefault(t => t.CDlcode == orderno)?.CCusCode;
            var c = dbContext.Customer.FirstOrDefault(t => t.CCusCode == code);
            if (c == null) return (null, null);
            return ($"{c.CProvince + c.CCity}", c.CCusAddress);
        }

        public DtoCustomer GetCustomersByOrderNo(string orderno)
        {
            var code = dbContext.DispatchList.FirstOrDefault(t => t.CDlcode == orderno)?.CCusCode;
            var c = dbContext.Customer.FirstOrDefault(t => t.CCusCode == code);
            if (c == null) return null;
            return new DtoCustomer()
            {
                Address = c.CCusAddress,
                City = c.CCity,
                Province = c.CProvince,
                Code = c.CCusCode,
                Name = c.CCusName
            };
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetDepartments()
        {
            return dbContext.Department.Where(t => t.BDepEnd == true).ToDictionary(t => t.CDepCode, t => t.CDepName);
        }

        public Dictionary<string, string> GetDepartments(string departmentcode)
        {
            return dbContext.Department.Where(t => t.BDepEnd == true && t.CDepCode == departmentcode).ToDictionary(t => t.CDepCode, t => t.CDepName);
        }
        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetWarehouses()
        {
            return dbContext.Warehouse.ToDictionary(t => t.CWhCode, t => t.CWhName);
        }

        public List<DtoProductClass> GetInventoryClass()
        {
            return dbContext.InventoryClass.Select(t => new DtoProductClass()
            {
                ClassCode = t.CInvCcode,
                ClassName = t.CInvCname,
                IsLeaf = t.BInvCend.Value,
                Level = t.IInvCgrade
            }).ToList();
        }

        public DtoPerson GetPersonByPhone(string phonecode)
        {
            var person = dbContext.Person.FirstOrDefault(t => t.CPersonPhone == phonecode);
            if (person == null) return null;
            return new DtoPerson()
            {
                Code = person.CPersonCode,
                DeparmentCode = person.CDepCode,
                Name = person.CPersonName,
                PhoneCode = person.CPersonPhone
            };
        }

        public DtoPerson GetPerson(string code)
        {
            var person = dbContext.Person.FirstOrDefault(t => t.CPersonCode == code);
            if (person == null) return null;
            return new DtoPerson()
            {
                Code = person.CPersonCode,
                DeparmentCode = person.CDepCode,
                Name = person.CPersonName,
                PhoneCode = person.CPersonPhone
            };
        }


        public DtoSupplier GetSupplierByPhone(string phonecode)
        {
            var supplier = dbContext.Vendor.FirstOrDefault(t => t.CVenPhone == phonecode);
            if (supplier == null) return null;
            return new DtoSupplier()
            {
                Code = supplier.CVenCode,
                Name = supplier.CVenName,
                PhoneCode = supplier.CVenPhone
            };
        }

        public DtoSupplier GetSupplier(string code)
        {
            var supplier = dbContext.Vendor.FirstOrDefault(t => t.CVenCode == code);
            if (supplier == null) return null;
            return new DtoSupplier()
            {
                Code = supplier.CVenCode,
                Name = supplier.CVenName,
                PhoneCode = supplier.CVenPhone
            };
        }

        /// <summary>
        /// 获取商品大类
        /// </summary>
        /// <param name="cwhcode"></param>
        /// <returns></returns>
        public List<DtoProductClass> GetInventoryClass(string cwhcode)
        {
            return dbContext.CurrentStocks.Where(t => (t.CWhCode == cwhcode || string.IsNullOrEmpty(cwhcode))).Select(t => t.CInvCode).Distinct().Join(dbContext.Inventory, t => t, c => c.CInvCode, (t, c) => c)
                .Join(dbContext.InventoryClass, t => t.CInvCcode, c => c.CInvCcode, (t, c) => c).Select(t => new DtoProductClass()
                {
                    ClassCode = t.CInvCcode,
                    ClassName = t.CInvCname,
                    IsLeaf = t.BInvCend.Value,
                    Level = t.IInvCgrade
                }).Distinct().ToList();
        }



        /// <summary>
        /// 获取销售发货单
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="orderno"></param>
        /// <param name="isclose"></param>
        /// <returns></returns>
        public List<DtoSellOrder> GetSellOrders(string brand, string orderno, bool isclose = false)
        {
            var query = dbContext.SADispatchlists.Where(t => t.CDefine8 == brand && (string.IsNullOrEmpty(orderno) || t.CDlcode.Contains(orderno)));
            if (isclose)
                query.Where(t => t.Ivouchstate == "Closed");
            else
                query.Where(t => t.Ivouchstate == "Approved");
            var orders = query.Join(dbContext.Customer, t => t.CCusCode, c => c.CCusCode, (t, c) => new { t, c }).Select(t => new DtoSellOrder()
            {
                Id = t.t.Dlid,
                CreateDate = DateTime.Parse(t.t.Ddate),
                Maker = t.t.CMaker,
                OrderNo = t.t.CDlcode,
                ReceiveCompany = t.t.CCusName,
                Receiver = t.c.CCusPerson,
                ReceiveTel = t.c.CCusPhone,
                RecevieAddress = t.c.CCusAddress,
                Remark = t.t.CMemo
            }).ToList();
            orders.ForEach(e =>
            {
                e.SellOrderDetails = dbContext.DispatchLists.Where(t => t.Dlid == e.Id).Join(dbContext.Inventory, t => t.CInvCode, d => d.CInvCode, (t, d) => new { t, d })
                //  .Join(dbContext.Warehouse, t => t.t.CWhCode, w => w.CWhCode, (t, w) => new { t = t.t, d = t.d, w = w })
                .Join(dbContext.ComputationUnit, t => t.d.CComUnitCode, u => u.CComunitCode, (t, u) => new { t = t.t, d = t.d, u = u })
                .Select(t => new DtoSellOrder.DtoSellOrderDetail()
                {
                    Id = t.t.AutoId,
                    IsBatchManage = t.d.BInvBatch,
                    Numbers = t.t.IQuantity.Value,
                    ProcutModel = t.d.CInvStd,
                    ProductBatchNo = "",
                    ProductName = t.d.CInvName,
                    ProductNumbers = t.t.CInvCode,
                    UnitName = t.u.CComUnitName
                }).ToList();
            });
            return orders;
        }

        /// <summary>
        /// 获取采购到货单
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public List<DtoPurchaseOrder> GetPurchaseOrders(string brand, string orderno)
        {
            var orders = dbContext.PuArrHeads.Where(t => t.Cdefine8 == brand && t.Cvoucherstate == "审核" && (string.IsNullOrEmpty(orderno) || t.Ccode.Contains(orderno)))
                .Select(t => new DtoPurchaseOrder()
                {
                    Maker = t.Cmaker,
                    Id = t.Id,
                    OrderNo = t.Ccode,
                    OrderType = t.Cbustype,
                    Remark = t.Cmemo,
                    Supplier = t.Cvenname,
                    SupplierCode = t.Cvencode,
                    CreateDate = t.Ddate
                }).ToList();
            orders.ForEach(e =>
            {
                e.PurchaseOrderDetails = dbContext.PuArrBodies.Where(t => t.Id == e.Id).Select(t => new DtoPurchaseOrder.DtoPurchaseOrderDetail
                {
                    AutoId = t.Autoid,
                    Numbers = t.Iquantity,
                    ProductModel = t.Cinvstd,
                    ProductName = t.Cinvname,
                    ProductNumbers = t.Cinvcode,
                    StoreCode = t.Cwhcode,
                    StoreName = t.Cwhname,
                    UnitName = t.Cinvm_Unit
                }).ToList();
            });
            return orders;
        }

        public List<DtoPurchaseOrder> GetPurchaseOrders(string brand, string key, string supplier, string state, DateTime? starttime, DateTime? endtime, int pageindex, int pagesize, out int total)
        {
            var tmp_datas = dbContext.PuArrHeads.Where(t => t.Cdefine8 == brand
                            && t.Cvoucherstate == state
                            && (string.IsNullOrEmpty(key) || t.Ccode.Contains(key))
                            && (starttime == null || t.Ddate >= starttime)
                            && (endtime == null || t.Ddate <= endtime)
                            && (string.IsNullOrEmpty(supplier) || t.Cvenname.Contains(supplier)));
            total = tmp_datas.Count();
            var orders = tmp_datas.Skip(pageindex * pagesize).Take(pagesize == 0 ? 200000 : pagesize).Select(t => new DtoPurchaseOrder()
            {
                Maker = t.Cmaker,
                Id = t.Id,
                OrderNo = t.Ccode,
                OrderType = t.Cbustype,
                Remark = t.Cmemo,
                Supplier = t.Cvenname,
                SupplierCode = t.Cvencode,
                CreateDate = t.Ddate
            }).ToList();
            orders.ForEach(e =>
            {
                e.PurchaseOrderDetails = dbContext.PuArrBodies.Where(t => t.Id == e.Id).Select(t => new DtoPurchaseOrder.DtoPurchaseOrderDetail
                {
                    AutoId = t.Autoid,
                    Numbers = t.Iquantity,
                    ProductModel = t.Cinvstd,
                    ProductName = t.Cinvname,
                    ProductNumbers = t.Cinvcode,
                    StoreCode = t.Cwhcode,
                    StoreName = t.Cwhname,
                    UnitName = t.Cinvm_Unit,
                    Price = t.Ioritaxcost
                }).ToList();
            });
            return orders;
        }

        /// <summary>
        /// 获取领料单
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="departmentcode"></param>
        /// <returns></returns>
        public List<DtoMaterialOrder> GetMaterialOrders(string brand, string departmentcode)
        {
            var orders = dbContext.Materialappms.Where(t => (t.Cdefine8 == brand || brand == null) && (string.IsNullOrEmpty(departmentcode) || t.Cdepcode == departmentcode) && string.IsNullOrEmpty(t.Ccloser))
               .Select(t => new DtoMaterialOrder()
               {
                   Maker = t.Cmaker,
                   Id = t.Id,
                   OrderNo = t.Ccode,
                   Remark = t.Cmemo,
                   CreateDate = t.Ddate,
                   DepartmentName = t.Cdepname
               }).ToList();
            orders.ForEach(e =>
            {
                e.MaterialOrderDetails = dbContext.Materialappds.Where(t => t.Id == e.Id).Select(t => new DtoMaterialOrder.DtoMaterialOrderDetail
                {
                    Id = t.Autoid,
                    Numbers = t.Iquantity.Value,
                    ProductModel = t.Cinvstd,
                    ProductName = t.Cinvname,
                    ProductNumbers = t.Cinvcode,
                    StoreCode = t.Cwhcode,
                    StoreName = t.Cwhname,
                    UnitName = t.Cinvm_Unit
                }).ToList();
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
        public List<DtoMaterialOrder> GetMaterials(string departmentcode, string key, DateTime? starttime, DateTime? endtime, int pageindex, int pagesize, out int total)
        {
            var tmp_orders = dbContext.OmMomain.Where(t => t.CDepCode == departmentcode && (starttime == null || t.DDate >= starttime) && (endtime == null || t.DDate <= endtime)).Join(dbContext.OmMomaterialsheads, t => t.Moid, t1 => t1.Moid, (t, t1) => new { t, t1 }).
                Select(t => new DtoMaterialOrder()
                {
                    Maker = t.t.CMaker,
                    Id = t.t.Moid,
                    OrderNo = t.t.CCode,
                    Remark = t.t.CMemo,
                    CreateDate = t.t.DDate,
                    DepartmentName = "",
                    ProductModel = t.t1.Cinvstd,
                    ProductName = t.t1.Cinvname,
                    Brand = t.t.CDefine8
                }).Where(t => (string.IsNullOrEmpty(key) || t.ProductModel.Contains(key)));
            total = tmp_orders.Count();
            var orders = tmp_orders.Skip(pageindex * pagesize - pagesize).Take(pagesize).ToList();
            return orders;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public DtoMaterialOrder GetMaterials(string orderno)
        {
            var order = dbContext.OmMomain.Where(t => t.CCode == orderno).Join(dbContext.OmMomaterialsheads, t => t.Moid, t1 => t1.Moid, (t, t1) => new { t, t1 }).
                Select(t => new DtoMaterialOrder()
                {
                    Maker = t.t.CMaker,
                    Id = t.t.Moid,
                    OrderNo = t.t.CCode,
                    Remark = t.t.CMemo,
                    CreateDate = t.t.DDate,
                    DepartmentName = "",
                    ProductModel = t.t1.Cinvstd,
                    ProductName = t.t1.Cinvname,
                    Brand = t.t.CDefine8,
                    ProductNumbers = t.t1.Cinvcode,
                    Numbers = t.t1.Iquantity.Value
                }).FirstOrDefault();
            return order;
        }


        /// <summary>
        /// 获取委外加工领料单明细
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public List<DtoMaterialOrder.DtoMaterialOrderDetail> GetMaterialDetails(string orderno)
        {
            var orders = dbContext.OmMomain.Where(t => t.CCode == orderno).Join(dbContext.OmMomaterialsbodies, t => t.Moid, d => d.Moid, (t, d) => d).
                Select(t => new DtoMaterialOrder.DtoMaterialOrderDetail
                {
                    Id = t.Momaterialsid,
                    ProductName = t.Cinvname,
                    ProductNumbers = t.Cinvcode,
                    ProductBatch = "",
                    ProductModel = t.Cinvstd,
                    Numbers = t.Iquantity.Value - (t.Isendqty ?? 0),
                    StoreCode = t.Cwhcode,
                    StoreName = t.Cwhname,
                    UnitName = t.Cinvm_Unit
                }).ToList();
            return orders;
        }
        /// <summary>
        /// 获取存货
        /// </summary>
        /// <param name="productcode"></param>
        public DtoInventory GetInventory(string productcode)
        {
            var product = dbContext.Inventory.FirstOrDefault(t => t.CInvCode == productcode);
            if (product == null) return null;
            var stocks = dbContext.CurrentStocks.Where(t => t.CInvCode == product.CInvCode).Select(t => new DtoInventory.DtoInventoryStock()
            {
                Numbers = t.IQuantity.Value,
                ProductBatchNo = t.CBatch,
                StoreCode = t.CWhCode,
                StoreName = dbContext.Warehouse.FirstOrDefault(w => w.CWhCode == t.CWhCode).CWhName

            }).ToList();
            var dtoInventory = new DtoInventory()
            {
                ProductName = product.CInvName,
                ProductNumbers = product.CInvCode,
                ProductModel = product.CInvStd,
                Rate = product.ITaxRate.Value,
                InventoryClassCode = product.CInvCcode,
                InventoryClassName = dbContext.InventoryClass.FirstOrDefault(c => c.CInvCcode == product.CInvCcode)?.CInvCname,
                UnitName = dbContext.ComputationUnit.FirstOrDefault(u => u.CComunitCode == product.CShopUnit)?.CComUnitName,
                InventoryStocks = stocks,
                MaxStoreNumbers = product.ITopSum,
                MinStoreNumbers = product.ILowSum
            };
            return dtoInventory;
        }

        public (int, List<DtoInventory>) GetInventory(string brand, string classcode, string storecode, string key, int pageindex, int pagesize)
        {
            int total;
            var result = GetInventory(brand, classcode, storecode, key, pageindex, pagesize, out total);
            return (total, result);
        }


        public List<DtoInventory> GetInventory(string brand, string classcode, string storecode, string key, int pageindex, int pagesize, out int total)
        {
            var products = dbContext.Inventory.Where(t => t.CInvDefine1 == brand && t.CInvCcode == classcode && (string.IsNullOrEmpty(key) || t.CInvName.Contains(key))).Join(dbContext.CurrentStocks.Where(t => t.CWhCode == storecode && t.IQuantity.HasValue && t.IQuantity.Value > 0).Select(t => t.CInvCode).Distinct(), t => t.CInvCode, d => d, (t, d) => t);
            total = products.Count();
            var result = products.Skip(pageindex * pagesize).Take(pagesize == 0 ? 200000 : pagesize).ToList().Select(product =>
            {
                var stocks = dbContext.CurrentStocks.Where(t => t.CInvCode == product.CInvCode).Select(t => new DtoInventory.DtoInventoryStock()
                {
                    Numbers = t.IQuantity.Value,
                    ProductBatchNo = t.CBatch,
                    StoreCode = t.CWhCode,
                    StoreName = dbContext.Warehouse.FirstOrDefault(w => w.CWhCode == t.CWhCode).CWhName

                }).ToList();
                var dtoInventory = new DtoInventory()
                {
                    ProductName = product.CInvName,
                    ProductNumbers = product.CInvCode,
                    ProductModel = product.CInvStd,
                    Rate = product.ITaxRate.HasValue ? product.ITaxRate.Value : 0,
                    InventoryClassCode = product.CInvCcode,
                    InventoryClassName = dbContext.InventoryClass.FirstOrDefault(c => c.CInvCcode == product.CInvCcode)?.CInvCname,
                    UnitName = dbContext.ComputationUnit.FirstOrDefault(u => u.CComunitCode == product.CComUnitCode)?.CComUnitName,
                    InventoryStocks = stocks,
                    MaxStoreNumbers = product.ITopSum,
                    MinStoreNumbers = product.ILowSum
                };
                return dtoInventory;
            }).ToList();
            return result;
        }

        #region Add
        #region 委外加工到货单
        public bool AddPuarrivalVouch(DtoStockOrder order)
        {
            using (var tran = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var momain = dbContext.OmMomain.Where(t => t.CCode == order.SourceOrderNo).Include(t => t.OmModetails).FirstOrDefault();
                    var result = CreatePuarrivalVouch(momain, order);
                    order.OrderNo = result.CCode;
                    dbContext.PuArrivalVouch.Add(result);
                    dbContext.PuArrivalVouchs.AddRange(result.PuArrivalVouchs);
                    //回填到货数量
                    // dbContext.OmModetails.UpdateRange(momain.OmModetails);
                    var commitResult = (dbContext.SaveChanges() > 0);
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

        private PuArrivalVouch CreatePuarrivalVouch(OmMomain momain, DtoStockOrder order)
        {
            var id = (dbContext.PuArrivalVouch.Max(t => t.Id) + 1) % 1000000000 + 2000000000;
            string code = $"OMWIN{DateTime.Now.ToString("yyyyMMdd")}{id.ToString().Substring(id.ToString().Length - 5)}";
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
                CMemo = momain.CMemo + $"(车间系统自动生成单据:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")})",
                CBusType = "委外加工",
                CMaker = "陈晓兰",
                BNegative = 0,
                CDefine4 = DateTime.Now.Date,
                CDefine8 = momain.CDefine8,
                CDefine10 = $"系统生成（{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}）",
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
                PuArrivalVouchs = new List<PuArrivalVouchs>()
            };
            int autoid = (dbContext.PuArrivalVouchs.Max(t => t.Autoid) + 1) % 1000000000 + 2000000000;
            foreach (var orderitem in order.StoreStockDetail)
            {
                var item = momain.OmModetails.First(t => t.CInvCode == orderitem.ProductNumbers);
                autoid += 1;
                puArrivalVouch.PuArrivalVouchs.Add(new PuArrivalVouchs()
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
                    Irowno = puArrivalVouch.PuArrivalVouchs.Count() + 1,
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
                //item.IArrQty = (item.IArrQty ?? 0) + orderitem.Numbers.Value;
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
            var pomain = dbContext.PoPomain.FirstOrDefault(t => t.CPoid == order.SourceOrderNo);
            if (pomain == null) return false;
            pomain.Podetails = dbContext.PoPodetails.Where(t => t.Poid == pomain.Poid).ToList();
            var result = CreatePurchaseArrivalVouch(pomain, order);
            order.OrderNo = result.CCode;
            dbContext.PuArrivalVouch.Add(result);
            dbContext.PuArrivalVouchs.AddRange(result.PuArrivalVouchs);

            return dbContext.SaveChanges() > 0;
        }

        private PuArrivalVouch CreatePurchaseArrivalVouch(PoPomain pomain, DtoStockOrder order)
        {
            var id = (dbContext.PuArrivalVouch.Max(t => t.Id) + 1) % 1000000000 + 2000000000;
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
                PuArrivalVouchs = new List<PuArrivalVouchs>()
            };
            int autoid = (dbContext.PuArrivalVouchs.Max(t => t.Autoid) + 1) % 1000000000 + 2000000000;
            foreach (var orderitem in order.StoreStockDetail)
            {
                var item = pomain.Podetails.First(t => t.CInvCode == orderitem.ProductNumbers);
                autoid += 1;
                puArrivalVouch.PuArrivalVouchs.Add(new PuArrivalVouchs()
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
                    Irowno = puArrivalVouch.PuArrivalVouchs.Count() + 1,
                    Iorderseq = orderitem.SourceEntryId,
                    FValidInQuan = 0,
                    FValidQuantity = null,
                    Iorderdid = item.Iorderdid,
                    Csoordercode = item.Csoordercode
                });
                item.IReceivedQty = (item.IReceivedQty ?? 0) + orderitem.Numbers.Value;
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
            var puarrival = dbContext.PuArrivalVouch.AsNoTracking().FirstOrDefault(t => t.CCode == order.SourceOrderNo);
            if (puarrival == null) return false;
            puarrival.PuArrivalVouchs = dbContext.PuArrivalVouchs.AsNoTracking().Where(t => t.Id == puarrival.Id).ToList();
            var results = CreateRdrecord01s(puarrival, order);
            results.ForEach(result =>
            {
                order.OrderNo = result.CCode;
                order.Note += result.CCode + ",";
                dbContext.RdRecord01.Add(result);
                dbContext.Rdrecords01.AddRange(result.Rdrecords01s);
            });
            if (!InsertOrUpdateStore(order, (s, t) => { return s + t; })) return false;

            UpdateModetailsReceiveNumber(puarrival.PuArrivalVouchs);

            var commitResult = dbContext.SaveChanges() > 0;
            if (commitResult)
                results.ForEach(t =>
                {
                    AddUnAccountRdrecord(t.Id, t.Rdrecords01s.Select(d => d.AutoId).ToList(), "01", t.CBusType);
                });
            return commitResult;
        }

        private List<RdRecord01> CreateRdrecord01s(PuArrivalVouch puArrival, DtoStockOrder order)
        {
            List<RdRecord01> list = new List<RdRecord01>();
            var dic = puArrival.PuArrivalVouchs.GroupBy(t => t.CWhCode).ToDictionary(t => t.Key, t => t.ToList());
            long id = 0, detailid = 0;
            foreach (var key in dic.Keys)
            {
                puArrival.PuArrivalVouchs = dic[key];
                list.Add(CreateRdrecord01(key, puArrival, order, ref id, ref detailid));
            }
            return list;
        }

        private RdRecord01 CreateRdrecord01(string cwhcode, PuArrivalVouch puArrival, DtoStockOrder order, ref long id, ref long detailid)
        {
            id = id == 0 ? (dbContext.RdRecord01.Max(t => t.Id) + 1) % 1000000000 + 2000000000 : id + 1;
            string code = $"MFIN{DateTime.Now.ToString("yyyyMMdd")}{id.ToString().Substring(id.ToString().Length - 5)}";
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
                Rdrecords01s = new List<Rdrecords01>()
            };
            detailid = detailid == 0 ? (dbContext.Rdrecords01.Max(t => t.AutoId) + 1) % 1000000000 + 2000000000 : detailid;
            foreach (var item in puArrival.PuArrivalVouchs)
            {
                var orderitem = order.StoreStockDetail.First(t => t.ProductNumbers == item.CInvCode);
                detailid += 1;
                rdrecord.Rdrecords01s.Add(new Rdrecords01()
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


        private List<RdRecord01> CreateRdrecord01s(PuArrivalVouch puArrival)
        {
            List<RdRecord01> list = new List<RdRecord01>();
            var dic = puArrival.PuArrivalVouchs.GroupBy(t => t.CWhCode).ToDictionary(t => t.Key, t => t.ToList());
            long id = 0, detailid = 0;
            foreach (var key in dic.Keys)
            {
                puArrival.PuArrivalVouchs = dic[key];
                list.Add(CreateRdrecord01(key, puArrival, ref id, ref detailid));
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
        private RdRecord01 CreateRdrecord01(string cwhcode, PuArrivalVouch puArrival, ref long id, ref long detailid)
        {
            id = id == 0 ? (dbContext.RdRecord01.Max(t => t.Id) + 1) % 1000000000 + 2000000000 : id + 1;
            string code = $"MFIN{DateTime.Now.ToString("yyyyMMdd")}{id.ToString().Substring(id.ToString().Length - 5)}";
            var rdrecord = new RdRecord01()
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
                Rdrecords01s = new List<Rdrecords01>()
            };
            detailid = detailid == 0 ? (dbContext.Rdrecords01.Max(t => t.AutoId) + 1) % 1000000000 + 2000000000 : detailid;
            foreach (var item in puArrival.PuArrivalVouchs)
            {
                detailid += 1;
                rdrecord.Rdrecords01s.Add(new Rdrecords01()
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
                    Rowufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
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
            var puarrival = dbContext.PuArrivalVouch.AsNoTracking().FirstOrDefault(t => t.CCode == puarrivalOrderNo);
            if (puarrival == null) return false;
            puarrival.PuArrivalVouchs = dbContext.PuArrivalVouchs.AsNoTracking().Where(t => t.Id == puarrival.Id).ToList();
            var results = CreateRdrecord01s(puarrival);
            results.ForEach(result =>
            {
                dbContext.RdRecord01.Add(result);
                dbContext.Rdrecords01.AddRange(result.Rdrecords01s);
            });
            if (puarrival.CBusType == "普通采购")
            {
                //更新采购订单到入库数量 
                foreach (var item in puarrival.PuArrivalVouchs)
                {
                    var detail = dbContext.PoPodetails.FirstOrDefault(t => t.Id == item.IPosId);
                    if (detail == null) continue;
                    detail.Freceivedqty = (detail.Freceivedqty ?? 0) + item.IQuantity;
                }
            }
            else if (puarrival.CBusType == "委外加工")
            {
                //更新委外单据入库数量
                foreach (var item in puarrival.PuArrivalVouchs)
                {
                    var detail = dbContext.OmModetails.FirstOrDefault(t => t.ModetailsId == item.IPosId);
                    if (detail == null) continue;
                    detail.Freceivedqty = (detail.Freceivedqty ?? 0) + item.IQuantity;
                }
            }
            puarrival.Ccloser = puarrival.CMaker;
            puarrival.Cverifier = puarrival.CMaker;
            puarrival.Dclosedate = puarrival.CAuditDate = DateTime.Now.Date;
            puarrival.Caudittime = DateTime.Now;
            dbContext.PuArrivalVouch.Update(puarrival);
            //更新库存
            if (!InsertOrUpdateStore(new DtoStockOrder()
            {
                Brand = puarrival.CDefine8,
                SourceOrderNo = puarrival.CCode,
                StoreStockDetail = puarrival.PuArrivalVouchs.Select(t => new DtoStockOrder.DtoStoreStockDetail()
                {
                    Numbers = t.IQuantity,
                    ProductBatch = t.CBatch,
                    ProductNumbers = t.CInvCode,
                    StoreId = t.CWhCode
                })
            }, (s, t) => { return s + t; })) return false;
            UpdateModetailsReceiveNumber(puarrival.PuArrivalVouchs);
            var commitResult = dbContext.SaveChanges() > 0;
            if (commitResult)
                results.ForEach(t =>
                {
                    AddUnAccountRdrecord(t.Id, t.Rdrecords01s.Select(d => d.AutoId).ToList(), "01", t.CBusType);
                });
            return commitResult;
        }
        #endregion

        #region 销售出库单
        /// <summary>
        /// 销售出库单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool AddSellOrder(DtoStockOrder order)
        {
            if (!UpdateStore(order, (s, t) => { return s - t; })) return false;

            var dispatch = dbContext.DispatchList.AsNoTracking().FirstOrDefault(t => t.CDlcode == order.SourceOrderNo);
            if (dispatch == null) return false;
            dispatch.DispatchLists = dbContext.DispatchLists.AsNoTracking().Where(t => t.Dlid == dispatch.Dlid).ToList();
            var results = CreateRdrecord32s(dispatch, order);
            results.ForEach(result =>
            {
                order.OrderNo = result.CCode;
                order.Note += result.CCode + ",";
                dbContext.Rdrecord32.Add(result);
                dbContext.Rdrecords32.AddRange(result.Rdrecords32s);
            });
            foreach (var item in dispatch.DispatchLists)
            {
                //更新销售订单发货数量
                var detail = dbContext.SoSodetails.FirstOrDefault(t => t.ISosId == item.ISosId);
                if (detail == null) continue;
                var orderdetail = order.StoreStockDetail.FirstOrDefault(t => t.ProductBatch == item.CBatch && t.ProductNumbers == item.CInvCode);
                detail.IFhquantity = (detail.IFhquantity ?? 0) + orderdetail?.Numbers ?? item.IQaquantity;
            }
            var commitResult = dbContext.SaveChanges() > 0;
            if (commitResult)
                results.ForEach(t =>
                {
                    AddUnAccountRdrecord(t.Id, t.Rdrecords32s.Select(d => d.AutoId).ToList(), "32", t.CBusType);
                });
            return commitResult;
        }
        private List<Rdrecord32> CreateRdrecord32s(DispatchList dispatch, DtoStockOrder order)
        {
            List<Rdrecord32> list = new List<Rdrecord32>();
            var dic = dispatch.DispatchLists.GroupBy(t => t.CWhCode).ToDictionary(t => t.Key, t => t.ToList());
            long id = 0, detailid = 0;
            foreach (var key in dic.Keys)
            {
                dispatch.DispatchLists = dic[key];
                list.Add(CreateRdrecord32(key, dispatch, order, ref id, ref detailid));
            }
            return list;
        }
        private Rdrecord32 CreateRdrecord32(string cwhcode, DispatchList dispatch, DtoStockOrder order, ref long id, ref long detailid)
        {
            id = id == 0 ? (dbContext.Rdrecord32.Max(t => t.Id) + 1) % 1000000000 + 2000000000 : id + 1;
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
                Rdrecords32s = new List<Rdrecords32>()
            };
            detailid = detailid == 0 ? (dbContext.Rdrecords32.Max(t => t.AutoId) + 1) % 1000000000 + 2000000000 : detailid;
            foreach (var item in dispatch.DispatchLists)
            {
                var orderitem = order.StoreStockDetail.First(t => t.ProductNumbers == item.CInvCode);
                detailid += 1;
                rdrecord.Rdrecords32s.Add(new Rdrecords32()
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
            if (!UpdateStore(order, (s, t) => { return s - t; })) return false;
            var materialApp = dbContext.MaterialAppVouch.AsNoTracking().FirstOrDefault(t => t.CCode == order.SourceOrderNo);
            if (materialApp == null) return false;
            materialApp.MaterialAppVouchs = dbContext.MaterialAppVouchs.AsNoTracking().Where(t => t.Id == materialApp.Id).ToList();
            var results = CreateRdrecord11s(materialApp, order);
            var list = new List<Rdrecords11>();
            results.ForEach(result =>
            {
                order.OrderNo = result.CCode;
                order.Note += result.CCode + ",";
                list.AddRange(result.Rdrecords11s);
            });
            var detailid = 0;
            foreach (var item in materialApp.MaterialAppVouchs)
            {
                //更新发料数量
                var detail = dbContext.OmMomaterials.FirstOrDefault(t => t.MomaterialsId.ToString() == item.Ipesodid);
                if (detail == null) continue;
                detailid = detail.MoDetailsId;
                var orderdetails = order.StoreStockDetail.Where(t => t.ProductNumbers == detail.CInvCode);
                detail.ISendQty = (detail.ISendQty ?? 0) + orderdetails.Sum(t => t.Numbers);
                detail.ISendNum = (detail.ISendNum ?? 0) + detail.ISendQty / item.Iinvexchrate;
            }
            if (detailid != 0)
            {
                //更新明细表中的领料数量
                var detail = dbContext.OmModetails.FirstOrDefault(t => t.ModetailsId == detailid);
                if (detail != null)
                    detail.IMaterialSendQty = order.StoreStockDetail.Sum(t => t.Numbers);
            }
            dbContext.Rdrecord11.AddRange(results);
            dbContext.Rdrecords11.AddRange(list);
            var app = dbContext.MaterialAppVouch.First(t => t.Id == materialApp.Id);
            app.CCloser = app.CMaker;
            var commitResult = dbContext.SaveChanges() > 0;
            if (commitResult)
                results.ForEach(t =>
                {
                    AddUnAccountRdrecord(t.Id, t.Rdrecords11s.Select(d => d.AutoId).ToList(), "11", t.CBusType);
                });
            return commitResult;
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
            var momain = dbContext.OmMomain.FirstOrDefault(t => t.CCode == materialApp.MaterialAppVouchs.FirstOrDefault().Comcode);
            if (momain == null)
                throw new FinancialException($"申请单（{materialApp.CCode})明细中关联的委外订单单号（{materialApp.MaterialAppVouchs.FirstOrDefault()?.Comcode}）没有对应的委外单据");
            id = id == 0 ? (dbContext.Rdrecord11.Max(t => t.Id) + 1) % 1000000000 + 2000000000 : id + 1;
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

                CPsPcode = dbContext.OmModetails.FirstOrDefault(o => o.ModetailsId == materialApp.MaterialAppVouchs.FirstOrDefault().IOmoMid)?.CInvCode,
                CMpoCode = materialApp.MaterialAppVouchs.FirstOrDefault()?.Comcode,

                Ufts = BitConverter.GetBytes(ConvertTimestamp(DateTime.Now)),
                Dnmaketime = DateTime.Now,
                Bredvouch = 0,
                IMquantity = materialApp.Imquantity.HasValue ? (double)materialApp.Imquantity.Value : 0,
                Iproorderid = momain.Moid,

                Csysbarcode = $"||st11|{materialApp.CCode}",
                Rdrecords11s = new List<Rdrecords11>()
            };
            detailid = detailid == 0 ? (dbContext.Rdrecords11.Max(t => t.AutoId) + 1) % 1000000000 + 2000000000 : detailid;
            foreach (var item in materialApp.MaterialAppVouchs)
            {
                var orderitem = order.StoreStockDetail.First(t => t.ProductNumbers == item.CInvCode);
                detailid += 1;
                rdrecord.Rdrecords11s.Add(new Rdrecords11()
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
            var apply = dbContext.OmMomain.FirstOrDefault(t => t.CCode == order.SourceOrderNo);
            if (apply == null) return false;
            var applydetails = dbContext.OmMomaterials.Where(t => t.Moid == apply.Moid).ToList();
            #region Create
            var id = dbContext.MaterialAppVouch.Any() ? (dbContext.MaterialAppVouch.Max(t => t.Id) + 1) % 1000000000 + 2000000000 : 1;
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
            var autoid = dbContext.MaterialAppVouchs.Any() ? (dbContext.MaterialAppVouchs.Max(t => t.AutoId) + 1) % 1000000000 + 2000000000 : 1;
            foreach (var item in order.StoreStockDetail)
            {
                var detail = applydetails.FirstOrDefault(t => t.CInvCode == item.ProductNumbers);
                vouch.MaterialAppVouchs.Add(new MaterialAppVouchs()
                {
                    AutoId = autoid++,
                    Id = id,
                    CInvCode = item.ProductNumbers,
                    INum = item.Numbers * detail?.FBaseQtyD ?? 0,
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
                    Invcode = dbContext.OmModetails.FirstOrDefault(t => t.ModetailsId == detail.MoDetailsId)?.CInvCode,
                    Corufts = "515862.3406",
                    Ipesodid = detail.MomaterialsId.ToString(),
                    Ipesotype = 8,
                    Cpesocode = apply.CCode,
                    Cbsysbarcode = $"||st64|{code}|{detail.Irowno}"
                });
                //更新申请数量
                detail.Fsendapplyqty = item.Numbers;
                detail.Fsendapplynum = item.Numbers * detail?.FBaseQtyD ?? 0;
            }
            #endregion  
            dbContext.MaterialAppVouch.Add(vouch);
            return dbContext.SaveChanges() > 0;
        }
        #endregion


        #region 退料申请单
        public bool AddReturnMetarialApply(DtoStockOrder order)
        {
            var apply = dbContext.OmMomain.FirstOrDefault(t => t.CCode == order.SourceOrderNo);
            if (apply == null) return false;
            var applydetails = dbContext.OmMomaterials.Where(t => t.Moid == apply.Moid).ToList();
            #region Create
            var id = (dbContext.MaterialAppVouch.Max(t => t.Id) + 1) % 1000000000 + 2000000000;
            var code = $"MFAPP{DateTime.Now.ToString("yyyyMMdd")}{(id > 10000 ? id.ToString().Substring(id.ToString().Length - 5) : id.ToString().PadLeft(5, '0'))}";
            MaterialAppVouch vouch = new MaterialAppVouch()
            {
                Id = (dbContext.MaterialAppVouch.Max(t => t.Id) + 1) % 1000000000 + 2000000000,
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
            var autoid = (dbContext.MaterialAppVouchs.Max(t => t.AutoId) + 1) % 1000000000 + 2000000000;
            foreach (var item in order.StoreStockDetail)
            {
                var detail = applydetails.FirstOrDefault(t => t.CInvCode == item.ProductNumbers);
                vouch.MaterialAppVouchs.Add(new MaterialAppVouchs()
                {
                    AutoId = autoid++,
                    Id = id,
                    CInvCode = item.ProductNumbers,
                    INum = item.Numbers * -1 * detail?.FBaseQtyD ?? 0,
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
                    Invcode = dbContext.OmModetails.FirstOrDefault(t => t.ModetailsId == detail.MoDetailsId)?.CInvCode,
                    Corufts = "515862.3406",
                    Ipesodid = detail.MomaterialsId.ToString(),
                    Ipesotype = 8,
                    Cpesocode = apply.CCode,
                    Cbsysbarcode = $"||st64|{code}|{detail.Irowno}"
                });
            }
            #endregion

            dbContext.MaterialAppVouch.Add(vouch);
            return dbContext.SaveChanges() > 0;
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
            return (time - new System.DateTime(1970, 1, 1)).TotalMilliseconds;
        }


        #region 查询采购
        public List<DtoPurchaseOrder> GetCheckedPOs(string brand, string suppliercode, int pageindex, int pagesize, out int total)
        {
            return GetPos((t => t.CDefine8 == brand && t.CVenCode == suppliercode && (t.Iverifystateex == 1 || t.Iverifystateex == 2) && string.IsNullOrEmpty(t.CDefine9) && string.IsNullOrEmpty(t.CCloser)), suppliercode, pageindex, pagesize, out total);
        }

        public List<DtoPurchaseOrder> GetAffirmPOs(string brand, string suppliercode, int pageindex, int pagesize, out int total)
        {
            return GetPos((t => t.CDefine8 == brand && t.CVenCode == suppliercode && t.CDefine9 == "已确认" && !string.IsNullOrEmpty(t.CVerifier)), suppliercode, pageindex, pagesize, out total);
        }

        public List<DtoPurchaseOrder> GetDeliverPOs(string brand, string suppliercode, int pageindex, int pagesize, out int total)
        {
            return GetPos((t => t.CDefine8 == brand && t.CVenCode == suppliercode && t.CDefine9 == "已发货" && !string.IsNullOrEmpty(t.CVerifier)), suppliercode, pageindex, pagesize, out total);
        }

        public List<DtoPurchaseOrder> GetOverPOs(string brand, string suppliercode, int pageindex, int pagesize, out int total)
        {
            return GetPos((t => t.CDefine8 == brand && t.CVenCode == suppliercode && !string.IsNullOrEmpty(t.CCloser)), suppliercode, pageindex, pagesize, out total);
        }

        public List<DtoPurchaseOrder.DtoPurchaseOrderDetail> GetPODetails(string orderno)
        {

            var po = dbContext.PoPomain.FirstOrDefault(t => t.CPoid == orderno);
            if (po == null) return null;
            var list = dbContext.VPoPodetails.Where(t => t.Poid == po.Poid).Select(t => new DtoPurchaseOrder.DtoPurchaseOrderDetail()
            {
                AutoId = t.Id,
                ArriveDate = t.Darrivedate,
                //Id = t.Id,
                Numbers = t.Iquantity.Value - (t.Ireceivedqty ?? 0),
                ProductModel = t.Cinvstd,
                ProductName = t.Cinvname,
                ProductNumbers = t.Cinvccode,
                UnitName = t.Cinvm_Unit,
                Price = t.Inatunitprice,
                Rate = 0m
            }).ToList();
            return list;
        }

        public bool UpdatePurchaseOrderState(string orderno, string state)
        {
            var po = dbContext.PoPomain.FirstOrDefault(t => t.CPoid == orderno);
            po.CDefine9 = state;
            return dbContext.SaveChanges() > 0;
        }

        private List<DtoPurchaseOrder> GetPos(Expression<Func<PoPomain, bool>> expression, string suppliercode, int pageindex, int pagesize, out int total)
        {
            var tmp_orders = dbContext.PoPomain.Where(expression);
            total = tmp_orders.Count();
            var orders = tmp_orders.OrderBy(t => t.DPodate).Skip(pageindex * pagesize - pagesize).Take(pagesize).Select(t => new DtoPurchaseOrder()
            {
                CreateDate = t.DPodate,
                Id = t.Poid,
                Maker = t.CMaker,
                MaxArriveDate = dbContext.PoPodetails.Where(d => d.Poid == t.Poid).Max(d => d.DArriveDate),
                OrderNo = t.CPoid,
                OrderType = t.CBusType,
                SupplierCode = suppliercode,
                Remark = t.CMemo,
                State = string.IsNullOrEmpty(t.CDefine9) ? "待处理" : t.CDefine9
            }).ToList();
            return orders;
        }
        #endregion


        #region 调拨

        public List<DtoAllotOrder> GetAllotOrders(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize, out int total)
        {
            var tmp_orders = dbContext.RdRecord09.Where(t => t.CBusType == "调拨出库" && t.CDefine8 == brand && (string.IsNullOrEmpty(orderno) || t.CCode.Contains(orderno)) && (starttime == null || t.DDate >= starttime) && (endtime == null || t.DDate <= endtime) && (isChecked ? !string.IsNullOrEmpty(t.CHandler) : string.IsNullOrEmpty(t.CHandler)))
            .Join(dbContext.TransVouch, t => t.CBusCode, d => d.CTvcode, (t, d) => new { t, d }).OrderByDescending(t => t.t.DDate);
            total = tmp_orders.Count();
            var datas = tmp_orders.Skip(pageindex * pagesize - pagesize).Take(pagesize).ToList();

            return datas.Select(t =>
            {
                var targetStoreName = dbContext.Warehouse.FirstOrDefault(w => w.CWhCode == t.t.CWhCode)?.CWhName ?? "";
                var sourceStoreName = dbContext.Warehouse.FirstOrDefault(w => w.CWhCode == t.d.COwhCode)?.CWhName ?? "";
                return new DtoAllotOrder()
                {
                    AllotOrderNo = t.d.CTvcode,
                    OrderNo = t.t.CCode,
                    CreateTime = t.t.DDate,
                    Remark = t.t.CMemo,
                    Brand = t.d.CDefine2,
                    TargetBrand = t.d.CDefine1,
                    TargetStoreName = targetStoreName,
                    SourceStoreName = sourceStoreName,
                    AllotOrderDetails = dbContext.Rdrecords09.Where(d => d.CDefine29 != "checked" && d.Id == t.t.Id).ToList().Select(d =>
                    {
                        var inventory = dbContext.Inventory.FirstOrDefault(i => i.CInvCode == d.CInvCode);
                        var unitcode = inventory?.CComUnitCode ?? "";
                        return new DtoAllotOrder.DtoAllotOrderDetail()
                        {
                            AutoId = d.AutoId,
                            ProductBathcNo = d.CBatch,
                            ProductName = inventory?.CInvName,
                            ProductNumbers = d.CInvCode,
                            Numbers = d.IQuantity.HasValue ? d.IQuantity.Value : 0,
                            ProductModel = inventory?.CInvStd,
                            UnitName = dbContext.ComputationUnit.FirstOrDefault(u => u.CComunitCode == unitcode)?.CComUnitName ?? ""
                        };
                    }).ToList(),

                };
            }).ToList();
        }

        public List<DtoAllotOutRecord> GetAllotOutRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize, out int total)
        {
            var tmp_orders = dbContext.RdRecord09.Where(t => t.CDefine8 == brand && (string.IsNullOrEmpty(orderno) || t.CCode.Contains(orderno)) && (starttime == null || t.DDate >= starttime) && (endtime == null || t.DDate <= endtime) && (isChecked ? !string.IsNullOrEmpty(t.CHandler) : string.IsNullOrEmpty(t.CHandler)));
            total = tmp_orders.Count();
            var datas = tmp_orders.Skip(pageindex * pagesize - pagesize).Take(pagesize).ToList();
            return datas.Select(t => new DtoAllotOutRecord()
            {
                OrderNo = t.CCode,
                CreateTime = t.DDate,
                Remark = t.CMemo,
                Brand = t.CDefine8,
                StoreName = dbContext.Warehouse.FirstOrDefault(w => w.CWhCode == t.CWhCode)?.CWhName ?? "",
                AllotOutRecordDetails = dbContext.Rdrecords09.Where(d => d.Id == t.Id).ToList().Select(d =>
                {
                    var inventory = dbContext.Inventory.FirstOrDefault(i => i.CInvCode == d.CInvCode);
                    var unitcode = inventory?.CComUnitCode ?? "";
                    return new DtoAllotOutRecord.DtoAllotOutRecordDetail()
                    {
                        OrderNo = t.CCode,
                        ProductBathcNo = d.CBatch,
                        ProductName = inventory?.CInvName,
                        ProductNumbers = d.CInvCode,
                        Numbers = d.IQuantity.HasValue ? d.IQuantity.Value : 0,
                        ProductModel = inventory?.CInvStd,
                        UnitName = dbContext.ComputationUnit.FirstOrDefault(u => u.CComunitCode == unitcode)?.CComUnitName ?? "",
                    };
                }).ToList()
            }).ToList();
        }

        public List<DtoAllotInRecord> GetAllotInRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize, out int total)
        {
            var tmp_orders = dbContext.RdRecord08.Where(t => t.CDefine8 == brand && (string.IsNullOrEmpty(orderno) || t.CCode.Contains(orderno)) && (starttime == null || t.DDate >= starttime) && (endtime == null || t.DDate <= endtime) && (isChecked ? !string.IsNullOrEmpty(t.CHandler) : string.IsNullOrEmpty(t.CHandler)));
            total = tmp_orders.Count();
            var datas = tmp_orders.Skip(pageindex * pagesize - pagesize).Take(pagesize).ToList();
            return datas.Select(t => new DtoAllotInRecord()
            {
                OrderNo = t.CCode,
                CreateTime = t.DDate,
                Remark = t.CMemo,
                Brand = t.CDefine8,
                StoreName = dbContext.Warehouse.FirstOrDefault(w => w.CWhCode == t.CWhCode)?.CWhName ?? "",
                AllotInRecordDetails = dbContext.Rdrecords08.Where(d => d.Id == t.Id).ToList().Select(d =>
                {
                    var inventory = dbContext.Inventory.FirstOrDefault(i => i.CInvCode == d.CInvCode);
                    var unitcode = inventory?.CComUnitCode ?? "";
                    return new DtoAllotInRecord.DtoAllotInRecordDetail()
                    {
                        ProductName = inventory?.CInvName,
                        ProductNumbers = d.CInvCode,
                        Numbers = d.IQuantity.HasValue ? d.IQuantity.Value : 0,
                        ProductModel = inventory?.CInvStd,
                        UnitName = dbContext.ComputationUnit.FirstOrDefault(u => u.CComunitCode == unitcode)?.CComUnitName ?? "",
                    };
                }).ToList()
            }).ToList();
        }


        public List<DtoAllotRecord> GetAllotRecords(string brand, string orderno, DateTime? starttime, DateTime? endtime, bool isChecked, int pageindex, int pagesize, out int total)
        {
            var tmp_orders = dbContext.RdRecord09.Where(t => t.CBusType == "调拨出库" && t.CDefine8 == brand && (string.IsNullOrEmpty(orderno) || t.CCode.Contains(orderno)) && (starttime == null || t.DDate >= starttime) && (endtime == null || t.DDate <= endtime) && (isChecked ? !string.IsNullOrEmpty(t.CHandler) : string.IsNullOrEmpty(t.CHandler)))
                .Join(dbContext.TransVouch, t => t.CBusCode, d => d.CTvcode, (t, d) => new { t, d }).Join(dbContext.Rdrecords09.Where(t => t.CDefine29 != "checked"), t => t.t.Id, d => d.Id, (t, d) => new { t = t.t, d });

            total = tmp_orders.Count();
            var datas = tmp_orders.Skip(pageindex * pagesize - pagesize).Take(pagesize).ToList();
            return datas.Select(t =>
            {
                var storename = dbContext.Warehouse.FirstOrDefault(w => w.CWhCode == t.t.CWhCode)?.CWhName ?? "";
                var inventory = dbContext.Inventory.FirstOrDefault(i => i.CInvCode == t.d.CInvCode);
                var unitcode = inventory?.CComUnitCode ?? "";
                return new DtoAllotRecord()
                {
                    AutoId = t.d.AutoId,
                    OrderNo = t.t.CCode,
                    CreateTime = t.t.DDate,
                    Remark = t.t.CMemo,
                    Brand = t.t.CDefine8,
                    StoreName = storename,
                    ProductBathcNo = t.d.CBatch,
                    ProductName = inventory?.CInvName,
                    ProductNumbers = t.d.CInvCode,
                    Numbers = t.d.IQuantity.HasValue ? t.d.IQuantity.Value : 0,
                    ProductModel = inventory?.CInvStd,
                    UnitName = dbContext.ComputationUnit.FirstOrDefault(u => u.CComunitCode == unitcode)?.CComUnitName ?? ""
                };
            }).ToList();
        }


        public bool CheckAllotInRecord(string orderno)
        {
            var record = dbContext.RdRecord08.FirstOrDefault(t => t.CCode == orderno);
            record.CHandler = record.CMaker;
            record.DVeriDate = DateTime.Now.Date;
            record.Dnverifytime = DateTime.Now;
            return dbContext.SaveChanges() > 0;
        }


        public bool CheckAllotOutRecord(string orderno)
        {
            var record = dbContext.RdRecord09.FirstOrDefault(t => t.CCode == orderno);
            record.CHandler = record.CMaker;
            record.DVeriDate = DateTime.Now.Date;
            record.Dnverifytime = DateTime.Now;
            return dbContext.SaveChanges() > 0;
        }

        public bool CheckAllotOutRecord(string orderno, string autoid)
        {
            var detailRecord = dbContext.RdRecord09.Where(t => t.CCode == orderno).Join(dbContext.Rdrecords09, t => t.Id, d => d.Id, (t, d) => d).FirstOrDefault(t => t.AutoId.ToString() == autoid);
            if (detailRecord == null) return false;
            if (detailRecord.CDefine29 == "checked") return true;
            detailRecord.CDefine29 = "checked";
            var result = dbContext.SaveChanges() > 0;
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
            var transVouchOrderNo = dbContext.RdRecord09.FirstOrDefault(t => t.CCode == outorderno)?.CBusCode;
            return dbContext.TransVouch.FirstOrDefault(t => t.CTvcode == transVouchOrderNo);
        }

        private bool CheckAllotInAndOutRecord(string outorderno)
        {
            var record = dbContext.RdRecord09.FirstOrDefault(t => t.CCode == outorderno);
            var detailRecords = dbContext.Rdrecords09.Where(t => t.Id == record.Id);
            if (!detailRecords.Any(t => t.CDefine29 != "checked"))
            {
                CheckAllotOutRecord(record);
                var allotno = GetTrans(outorderno)?.CTvcode;
                var inrecord = dbContext.RdRecord08.FirstOrDefault(t => t.CBusCode == allotno);
                CheckAllotInRecord(inrecord);
            }
            return dbContext.SaveChanges() > 0;

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
                var scmItems = dbContext.ScmItems.FirstOrDefault(t => t.CInvCode == item.ProductNumbers);
                if (scmItems == null) return false;
                var itemid = scmItems.Id;
                var stock = dbContext.CurrentStocks.FirstOrDefault(t => t.CInvCode == item.ProductNumbers && t.CBatch == item.ProductBatch && t.CWhCode == item.StoreId);
                if (stock != null)
                {
                    stock.IQuantity = action(stock.IQuantity ?? 0, item.Numbers ?? 0);
                    dbContext.Database.ExecuteSqlCommand("update currentstock set iQuantity =" + stock.IQuantity + " where cInvCode = '" + item.ProductNumbers + "' and cBatch = '" + item.ProductBatch + "' and cWhCode = " + item.StoreId);
                    continue;
                }

                //新增
                dbContext.Database.ExecuteSqlCommand(string.Format("insert into currentStock (cWhCode,cInvCode,ItemId,cBatch,cVMIVenCode,iSoType,iSodid,iQuantity,iNum,fOutQuantity,fOutNum,fInQuantity,fInNum,bStopFlag,fTransInQuantity,fTransInNum,fTransOutQuantity,fTransOutNum,fPlanQuantity,fPlanNum,fDisableQuantity,fDisableNum,fAvaQuantity,fAvaNum,BGSPSTOP,cCheckState,ipeqty,ipenum)  values ('{0}','{1}',{2},'{3}','',0,'',{4},{5},0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);",
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
        private bool UpdateStore(DtoStockOrder order, Func<decimal, decimal, decimal> action)
        {
            foreach (var item in order.StoreStockDetail)
            {
                var tmp_stocks = dbContext.CurrentStocks.Where(t => t.CInvCode == item.ProductNumbers);
                if (tmp_stocks.Count() == 0) return false;
                var itemid = tmp_stocks.First().ItemId;
                var stock = tmp_stocks.FirstOrDefault(t => t.CBatch == item.ProductBatch && t.CWhCode == item.StoreId);
                if (stock == null) return false;
                stock.IQuantity = action(stock.IQuantity ?? 0, item.Numbers ?? 0);
            }
            return true;
        }

        private void UpdateModetailsReceiveNumber(ICollection<PuArrivalVouchs> vouchs)
        {
            foreach (var item in vouchs)
            {
                var detail = dbContext.OmModetails.FirstOrDefault(t => t.ModetailsId == item.IPosId);
                if (detail == null) continue;
                detail.IReceivedQty = detail.IReceivedQty ?? 0 + item.IQuantity;
            }
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
            return dbContext.Database.ExecuteSqlCommand(sql) > 0;
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
            return dbContext.Database.ExecuteSqlCommand(sql.ToString()) > 0;
        }
        #endregion
    }
}
