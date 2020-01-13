using MicroFeel.Yonyou.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroFeel.Yonyou.Api.Test
{
    [TestClass]
    public class BomApiTest : ApiTest
    {
        [TestMethod]
        public async Task GetBomAsync()
        {
            var api = new BomApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = await api.Get_BomAsync("1000005244");
            Assert.IsNotNull(result);
            System.Console.WriteLine($"Purchaseorder is :{result}");
        }

        [TestMethod]
        public async Task BatchGetBomAsync()
        {
            var api = new BomApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var result = await api.Batch_Get_BomAsync();
            Console.WriteLine(result.Count);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
