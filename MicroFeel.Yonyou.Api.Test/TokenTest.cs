using System.Text.Json;
using System.Threading.Tasks;
using MicroFeel.Yonyou.Api;
using MicroFeel.Yonyou.Api.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MicroFeel.Yongyou.Api.Test
{
    [TestClass]
    public class TokenTest
    {
        string appkey = "opa625543cbcf9f5f7a";
        string appSecret = "eb321812c12840c1bf83c60f28692f72";
        string from_account = "menxin";
        string to_account = "test_menxin";
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
    }
}
