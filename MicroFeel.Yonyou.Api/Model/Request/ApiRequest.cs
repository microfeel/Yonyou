using System.Text.Json;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// API请求抽象基类
    /// </summary>
    public abstract class ApiRequest
    {
        /// <summary>
        /// 应用 appKey
        /// </summary>
        [JsonPropertyName("app_key")]
        public string AppKey { get; set; }


        public string ToJson()
        {
            return JsonSerializer.Serialize(this, Api.JsOptions);
        }
    }
}
