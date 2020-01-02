using MicroFeel.Yonyou.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Api.Test
{
    [TestClass]
    public  class StockApiTest:ApiTest
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
    }
}
