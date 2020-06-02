using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class OrderStatusResult : ApiResult
    {
        [JsonPropertyName("orderstatus")]
        public OrderStatus OrderStatus { get; set; }
    }

}
