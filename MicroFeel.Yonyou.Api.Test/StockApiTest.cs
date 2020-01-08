using MicroFeel.Yonyou.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Api.Test
{
    [TestClass]
    public class StockApiTest : ApiTest
    {
        [TestMethod]
        public async Task GetProductAsync()
        {
            var api = new StockApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = await api.Batch_Get_ProductinlistAsync();
            Assert.IsNotNull(result);
            System.Console.WriteLine($"productlist is :{result}");
        }

        [TestMethod]
        public void AddProductin()
        {
            var api = new StockApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = api.Add_ProductinAsync(new Productin()
            {
                Code = "1234",
                Maker = "测试",
                Date = DateTime.Now,
                Define8 = "高柏诗",
                Departmentcode = "1",
                Memory = "测试单据",
                Receivecode = "1",
                Warehousecode = "1",
                Productinentry = new List<ProductinEntry>() { new ProductinEntry() {
                    Assitantunit="",
                     Cost ="1.12",
                      Inventorycode ="12",
                       Irate ="1",
                        Makedate = DateTime.Now,
                         Number="2",
                          Quantity="1",
                           Price="12.1",
                            Serial="TEST20190109"

                } }
            }).Result;
            Console.WriteLine(result.Tradeid);
            Assert.IsTrue(result.Errcode == "0");
        }
    }
}
