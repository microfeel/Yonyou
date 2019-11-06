using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// API令牌
    /// </summary>
    public class Token
    {
        /// <summary>
        /// 应用程序appkey
        /// </summary>
        [JsonPropertyName("appkey")]
        public string AppKey { get; set; }
        /// <summary>
        /// 过期时间(秒)
        /// </summary>
        [JsonPropertyName("expiresIn")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 令牌Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
