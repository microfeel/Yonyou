using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MicroFeel.Yonyou.Api;
using MicroFeel.Yonyou.Api.Service;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// Tradeid 生命周期维护器
    /// </summary>
    internal class TradeidManager
    {
        /// <summary>
        /// 获取Tradeid
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <param name="fromAccount"></param>
        /// <returns></returns>
        internal static async Task<string> GetTradeidAsync(string baseUrl, string appKey, string appSecret, string fromAccount, string toAccounnt)
        {
            var api = new SystemApi();
            api.Init(baseUrl, appKey, appSecret, fromAccount, toAccounnt);
            return await api.TradeidAsync(); 
        } 
    }
}
