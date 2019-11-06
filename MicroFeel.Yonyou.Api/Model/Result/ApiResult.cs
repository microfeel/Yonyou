using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class ApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
    }

}
