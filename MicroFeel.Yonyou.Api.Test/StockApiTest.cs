using MicroFeel.Yonyou.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Api.Test
{
    [TestClass]
    public class StockApiTest : ApiTest
    {
        [TestMethod]
        public async Task BatchGetProductAsync()
        {
            var api = new StockApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = await api.Batch_Get_ProductinlistAsync();
            Assert.IsNotNull(result);
            var json = JsonSerializer.Serialize(result, JsonOptions);
            System.Console.WriteLine($"productlist is :{json}");
        }

        /// <summary>
        /// 产成品入库
        /// </summary>
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

        /// <summary>
        ///采购入库
        /// </summary>
        [TestMethod]
        public void AddPurchasein()
        {
            var api = new StockApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = api.Add_PurchaseinAsync(new Purchasein()
            {
                Code = "0000101263",
                Maker = "测试",
                Date = DateTime.Now,
                Define8 = "高柏诗",
                Departmentcode = "04",
                Memory = "测试单据",
                Receivecode = "102",
                Warehousecode = "1001",
                Departmentname = "信息技术部",
                Receivename = "委外入库",
                Vendorabbname = "珠海祥茂辉",
                Vendorcode = "010105",
                Vendorname = "珠海祥茂辉",
                Taxrate = 1,
                Warehousename = "柏瑞美成品仓",
                Purchaseinentry = new List<PurchaseinEntry>() { new PurchaseinEntry()
                                    {
                                        Cost = 1.12f,
                                        Inventorycode = "131010018",
                                        Irate = 1f,
                                        Makedate = DateTime.Now,
                                        Number = 2,
                                        Quantity = 1,
                                        Price = 12.1f,
                                        Serial = "TEST20190109",
                                        Assitantunitname = "支",
                                        Cmassunitname = "支",
                                        Inventoryname = "轻盈感光隔离霜（金色）支盒",
                                        Inventorystd = "JGNT24",
                                        Ioritaxcost = 10
                                    }  }
            }, "PRPO20191230327").Result;
            Console.WriteLine(result.Tradeid);
            Assert.IsTrue(result.Errcode == "0");
        }

        [TestMethod]
        public async Task BatchGetPurchaseinAsync()
        {
            var api = new StockApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = await api.Batch_Get_PurchaseinlistAsync();
            Assert.IsNotNull(result);
            System.Console.WriteLine($"Purchasein count is :{result.Count}");
            var json = JsonSerializer.Serialize(result, JsonOptions);
            Console.WriteLine($"Result: {json}");
        }

        [TestMethod]
        public async Task GetPurchaseinAsync()
        {
            var api = new StockApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = await api.Get_PurchaseinAsync("0000001263");
            Assert.IsNotNull(result);
            System.Console.WriteLine($"Purchasein( is :{result}");
        }
    }
}
