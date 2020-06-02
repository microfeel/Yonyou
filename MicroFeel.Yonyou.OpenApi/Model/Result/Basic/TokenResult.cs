using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api.Model.Result
{
    public class TokenResult : ApiResult
    {
        [JsonPropertyName("token")]
        public Token Token { get; set; }
    }

}
