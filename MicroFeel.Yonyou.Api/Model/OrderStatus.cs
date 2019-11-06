using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class OrderStatus
    {
        /// <summary>
        /// 应用版本
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        [JsonPropertyName("expiration_time")]
        public string ExpirationTime { get; set; }
    }
}