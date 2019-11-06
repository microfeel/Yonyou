using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// 基本请求类型
    /// </summary>
    public class BaseRequest : ApiRequest
    {
        /// <summary>
        /// 调用方id
        /// </summary>
        [JsonPropertyName("from_account")]
        public string FromAccount { get; set; }
        /// <summary>
        /// 全局访问唯一识别码
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }

        public override string ToString()
        {
            return $"?from_account={FromAccount}&app_key={AppKey}&token={Token}";
        }
    }
}
