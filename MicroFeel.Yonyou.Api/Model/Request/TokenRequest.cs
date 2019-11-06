using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MicroFeel.Yonyou.Api
{
    public class TokenRequest : ApiRequest
    {
        /// <summary>
        /// 应用密钥
        /// </summary>
        [JsonPropertyName("app_secret")]
        public string AppSecret { get; set; }
        /// <summary>
        /// 调用方id
        /// </summary>
        [JsonPropertyName("from_account")]
        public string FromAccount { get; set; }

        public override string ToString()
        {
            return $"?from_account={FromAccount}&app_key={AppKey}&app_secret={AppSecret}";
        }
    }
}
