using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public interface IApiResult
    {
        [JsonPropertyName("errcode")]
        string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        string Errmsg { get; set; }
    }
    public class ApiResult : IApiResult
    {
        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }
    }

}
