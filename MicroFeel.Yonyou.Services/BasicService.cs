using MicroFeel.Finance.Interfaces;
using MicroFeel.Finance.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.Yonyou.Services
{
    public class BasicService : IBasicService
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

        public Supplier AddSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
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

        public List<Store> GetWorkShops(string brand)
        {
            throw new NotImplementedException();
        }
    }
}
