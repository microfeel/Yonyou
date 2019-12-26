using System.Text.Json;
using System.Threading.Tasks;
using MicroFeel.Yonyou.Api;
using MicroFeel.Yonyou.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MicroFeel.Yongyou.Api.Test
{
    [TestClass]
    public class SystemApiTest
    {
        string appkey = "opaddd40e399ef4e98a";
        string appSecret = "ee5e0ee78c5942ef91686b61d2b76239";
        string from_account = "microfeel";
        string to_account = "test_microfeel";
        string base_url = "https://api.yonyouup.com/";

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
            var db = await api.Get_DatasourceAsync();
            Assert.IsNotNull(db);
            System.Console.WriteLine($"DBSource is :{db}");
        }
    }
}
