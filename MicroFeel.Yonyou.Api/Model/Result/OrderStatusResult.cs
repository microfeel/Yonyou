using MicroFeel.Finance.Models;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class OrderStatusResult : ApiResult
    {
        [JsonPropertyName("orderstatus")]
        public OrderStatus OrderStatus { get; set; }
    }

}
