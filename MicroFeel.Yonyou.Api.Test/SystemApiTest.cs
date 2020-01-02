using System.Text.Json;
using System.Threading.Tasks;
using MicroFeel.Yonyou.Api;
using MicroFeel.Yonyou.Api.Service;
using MicroFeel.Yonyou.Api.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MicroFeel.Yongyou.Api.Test
{
    [TestClass]
    public class SystemApiTest:ApiTest
    {
        
        [TestMethod]
        public async Task GetTokenAsync()
        {
            var api = new SystemApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var token = await api.TokenAsync();
            Assert.IsNotNull(token);
            System.Console.WriteLine($"Token is :{token}");
        }

        [TestMethod]
        public async Task GetTradeIdAsync()
        {
            var api = new SystemApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var tradeid = await api.TradeidAsync();
            Assert.IsNotNull(tradeid);
            System.Console.WriteLine($"tradeid is :{tradeid}");
        }

        [TestMethod]
        public async Task GetOrderStatusAsync()
        {
            var api = new SystemApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var os = await api.Get_OrderStatusAsync();
            Assert.IsNotNull(os);
            System.Console.WriteLine($"OrderStatus is :{os}");
        }

        [TestMethod]
        public async Task ConnectDbAsync()
        {
            var api = new SystemApi();
            api.Init(base_url, appkey, appSecret, from_account, to_account);
            var db = await api.Batch_get_DatasourceAsync();
            Assert.IsNotNull(db);
            System.Console.WriteLine($"DBSource is :{db}");
        }
    }
}
