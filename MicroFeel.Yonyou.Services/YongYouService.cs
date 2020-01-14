using MicroFeel.Finance;
using MicroFeel.Finance.Models;
using MicroFeel.Yonyou.Api.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Services
{
    public class YongYouService : IFinanceService
    {
        private const string appkey = "opaddd40e399ef4e98a";
        private const string appSecret = "ee5e0ee78c5942ef91686b61d2b76239";
        private const string from_account = "microfeel";
        private const string to_account = "test_microfeel";
        private const string base_url = "https://api.yonyouup.com/";
        private StockApi stockApi = new StockApi();
        private SystemApi systemApi = new SystemApi();
        private BasicApi basicApi = new BasicApi();

        public YongYouService()
        {
            stockApi.Init(base_url, appkey, appSecret, from_account, to_account);
            systemApi.Init(base_url, appkey, appSecret, from_account, to_account);
            basicApi.Init(base_url, appkey, appSecret, from_account, to_account);
        }

        public Customer AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer AddCustomer(Customer customer, string predicate, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Department AddDepartment(Department dep)
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


        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
