using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class DsResult : ApiResult
    {
        [JsonPropertyName("datasource")]
        public Datasource Datasource { get; set; }
    }
}