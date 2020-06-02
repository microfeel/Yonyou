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
    /// Token 生命周期维护器。平台 Token 生效期为 2 小时，SDK 1小时55分钟为重新获取新 token 的周期。
    /// </summary>
    internal class TokenManager
    {
        private static long? timestamp;

        private const long MILLISECONDS_EXPIRED = 6900000; //1000 * 60 * 115 (1小时55分钟);
        private static string token = string.Empty;

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <param name="fromAccount"></param>
        /// <returns></returns>
        internal static async Task<string> GetTokenAsync(string baseUrl, string appKey, string appSecret, string fromAccount, string toAccounnt)
        {
            var nowTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            if ((timestamp == null) || (nowTimestamp - timestamp > MILLISECONDS_EXPIRED))
            {
                token = await GetNewTokenAsync(baseUrl, appKey, appSecret, fromAccount, toAccounnt);
                timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }
            return token;
        }

        /// <summary>
        /// 获取新令牌
        /// </summary>
        /// <param name="url">调用基地址</param>
        /// <param name="appKey">应用程序标识</param>
        /// <param name="appSecret">应用程序密钥</param>
        /// <param name="fromAccount">账号</param>
        /// <returns>申请到的令牌</returns>
        private static async Task<string> GetNewTokenAsync(string url, string appKey, string appSecret, string fromAccount, string toAccounnt)
        {
            var api = new SystemApi();
            api.Init(url, appKey, appSecret, fromAccount, toAccounnt);
            return await api.TokenAsync();
        }
    }
}
