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
                Departmentcode = "04",
                Memory = "测试单据",
                Receivecode = "102",
                Warehousecode = "1001",
                Productinentry = new List<ProductinEntry>() { new ProductinEntry() {
                    Assitantunit="0201",
                     Cost =1.12f,
                      Inventorycode ="211030007",
                       Irate = 1f,
                        Makedate = DateTime.Now,
                         Number=2 ,
                          Quantity= 1 ,
                           Price= 12.1f,
                            Serial="TEST20190109"

                } }
            }).Result;
            Console.WriteLine(result.Tradeid);
            Assert.IsTrue(result.Errcode == "0");
        }
    }
}
