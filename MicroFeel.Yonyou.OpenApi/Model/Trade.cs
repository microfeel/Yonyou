using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Trade
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
