using MicroFeel.Finance;
using MicroFeel.Finance.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Services
{
    public class YongYouService : IFinanceService
    {
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

        public bool AddStock(Stock stock)
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

        public void Dispose()
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
            throw new NotImplementedException();
        }

        public List<Store> GetStores(string brand)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Task<Datasource> Get_DatasourceAsync()
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
    }
}
